using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_RuneBag))]
    [FriendOfAttribute(typeof(ES_RuneSlotItem))]
    [FriendOfAttribute(typeof(Scroll_Item_SockeRunetItem))]
    [EntitySystemOf(typeof(ES_Rune))]
    [FriendOfAttribute(typeof(ES_Rune))]
    public static partial class ES_RuneSystem
    {
        /// <summary>
        /// 预制体里孔位节点的名字前缀，完整名字形如 RuneSlotItem_11
        /// </summary>
        private const string SlotItemPrefix = "RuneSlotItem_";

        /// <summary>
        /// 镶嵌面板里可用符文条目的预制体
        /// </summary>
        private const string SocketItemPrefabPath = "Assets/Bundles/UI/Item/Item_SockeRunetItem.prefab";

        /// <summary>
        /// 符文背包预制体
        /// </summary>
        private const string RuneBagPrefabPath = "Assets/Bundles/UI/Common/ES_RuneBag.prefab";

        [EntitySystem]
        private static void Awake(this ES_Rune self, Transform transform)
        {
            self.uiTransform = transform;

            self.InitRuneSlotItems();
            self.InitUnlockSlotPanel();
            self.InitSocketPanel();
            self.InitUnsocketPanel();
            self.InitBagPanel();
        }

        [EntitySystem]
        private static void Destroy(this ES_Rune self)
        {
            if (self.AssetList != null)
            {
                ResourcesLoaderComponent resourcesLoaderComponent = self.Root()?.GetComponent<ResourcesLoaderComponent>();
                if (resourcesLoaderComponent != null)
                {
                    for (int i = 0; i < self.AssetList.Count; i++)
                    {
                        resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
                    }
                }

                self.AssetList.Clear();
            }

            self.DestroyWidget();
        }

        /// <summary>
        /// 孔位是美术在预制体里摆好的静态节点，这里按节点名里的槽位id创建实体，只创建一次
        /// </summary>
        private static void InitRuneSlotItems(this ES_Rune self)
        {
            Transform leftTrans = self.uiTransform.Find("Left");
            if (leftTrans == null)
            {
                Log.Error("ES_Rune 预制体缺少 Left 节点");
                return;
            }

            for (int i = 0; i < leftTrans.childCount; i++)
            {
                Transform child = leftTrans.GetChild(i);
                if (!child.name.StartsWith(SlotItemPrefix))
                {
                    continue;
                }

                if (!int.TryParse(child.name.Substring(SlotItemPrefix.Length), out int slotId))
                {
                    Log.Error($"符文孔位节点名无法解析出槽位id：{child.name}");
                    continue;
                }

                ES_RuneSlotItem item = self.AddChild<ES_RuneSlotItem, Transform>(child);
                item.Init(slotId);
                self.SlotItems.Add(item);
            }
        }

        private static void InitUnlockSlotPanel(this ES_Rune self)
        {
            self.E_UnlockSlotButton.AddListenerAsync(self.OnUnlockSlotButton);
            self.EG_UnlockSlotRectTransform.gameObject.SetActive(false);
        }

        private static void InitSocketPanel(this ES_Rune self)
        {
            self.E_SocketButton.AddListenerAsync(self.OnSocketButton);
            self.EG_SocketRectTransform.gameObject.SetActive(false);
        }

        private static void InitUnsocketPanel(this ES_Rune self)
        {
            self.E_UnsocketButton.AddListenerAsync(self.OnUnsocketButton);
            self.EG_UnsocketRectTransform.gameObject.SetActive(false);
        }

        private static void InitBagPanel(this ES_Rune self)
        {
            self.E_BagButton.AddListener(self.OnClickBagButton);
        }

        /// <summary>
        /// 刷新孔位状态：没解锁的孔位显示锁，选中的孔位显示选中框；
        /// 同时按选中孔位的状态切换开启条件、镶嵌、拆卸三个面板
        /// </summary>
        public static void OnUpdateUI(this ES_Rune self)
        {
            if (self.EG_UnlockSlotRectTransform == null || self.EG_SocketRectTransform == null || self.EG_UnsocketRectTransform == null)
            {
                return;
            }

            //回到符文主界面时收起符文背包
            self.HideRuneBag();

            RuneComponentC runeComponent = self.Root().GetComponent<RuneComponentC>();
            if (runeComponent == null)
            {
                return;
            }

            for (int i = 0; i < self.SlotItems.Count; i++)
            {
                ES_RuneSlotItem item = self.SlotItems[i];
                bool itemUnlocked = runeComponent.IsSlotUnlocked(item.SlotId);
                bool itemHasRune = runeComponent.GetSlotRuneId(item.SlotId) != 0;
                RuneConfig slotRuneConfig = runeComponent.GetRuneConfig(runeComponent.GetSlotRune(item.SlotId));
                string iconName = slotRuneConfig == null ? string.Empty : slotRuneConfig.Icon;
                item.OnUpdateUI(itemUnlocked, itemHasRune, self.SelectSlotId == item.SlotId, iconName);
            }

            bool hasSelect = self.SelectSlotId != 0;
            bool unlocked = hasSelect && runeComponent.IsSlotUnlocked(self.SelectSlotId);
            bool occupied = hasSelect && runeComponent.GetSlotRuneId(self.SelectSlotId) != 0;

            //没解锁的孔位显示开启条件，已解锁且空着的孔位显示镶嵌面板
            bool showUnlockSlot = hasSelect && !unlocked;
            self.EG_UnlockSlotRectTransform.gameObject.SetActive(showUnlockSlot);
            if (showUnlockSlot)
            {
                self.RefreshUnlockSlot(runeComponent);
            }

            bool showSocket = hasSelect && unlocked && !occupied;
            self.EG_SocketRectTransform.gameObject.SetActive(showSocket);
            if (showSocket)
            {
                self.RefreshSocketPanel(runeComponent);
            }

            //已经镶了符文的孔位显示拆卸面板
            bool showUnsocket = hasSelect && unlocked && occupied;
            self.EG_UnsocketRectTransform.gameObject.SetActive(showUnsocket);
            if (showUnsocket)
            {
                self.RefreshUnsocketPanel(runeComponent);
            }
        }

        /// <summary>
        /// 点击孔位：显示选中框，再按孔位状态弹开启条件、镶嵌或者拆卸面板
        /// </summary>
        public static void OnClickRuneSlot(this ES_Rune self, int slotId)
        {
            //换孔位时之前挑的符文就不算了
            if (self.SelectSlotId != slotId)
            {
                self.SelectSocketRuneId = 0;
            }

            self.SelectSlotId = slotId;
            self.OnUpdateUI();
        }

        /// <summary>
        /// 开启条件面板：孔位类型、说明，以及玩家等级和符文总等级两个条件
        /// </summary>
        private static void RefreshUnlockSlot(this ES_Rune self, RuneComponentC runeComponent)
        {
            RuneSlotConfig slotConfig = RuneSlotConfigCategory.Instance.GetOrDefault(self.SelectSlotId);
            if (slotConfig == null)
            {
                return;
            }

            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            int totalRuneLv = runeComponent.TotalRuneLv;

            self.E_RuneSlotType_UnlockSlotText.text = GetRuneTypeName(slotConfig.RuneType);
            self.E_RuneSlotDesText.text = $"仅可镶嵌{GetRuneTypeDesc(slotConfig.RuneType)}类型符文";

            //玩家等级条件
            bool playerLvEnough = playerLv >= slotConfig.UnlockLv;
            self.E_PlayerLvText.text = $"{playerLv}/{slotConfig.UnlockLv}";
            self.E_PlayerLvTargetText.text = playerLvEnough ? "已达成" : "未达成";
            self.E_LodingValue_PlayerLvImage.fillAmount = GetFillAmount(playerLv, slotConfig.UnlockLv);

            //符文总等级条件
            bool runeLvEnough = totalRuneLv >= slotConfig.UnlockRuneTotalLv;
            self.E_RuneLvText.text = $"{totalRuneLv}/{slotConfig.UnlockRuneTotalLv}";
            self.E_RuneLvTargetText.text = runeLvEnough ? "已达成" : "未达成";
            self.E_LodingValue_RuneLvImage.fillAmount = GetFillAmount(totalRuneLv, slotConfig.UnlockRuneTotalLv);

            //两个条件都满足才能点开启
            bool canUnlock = playerLvEnough && runeLvEnough;
            self.E_UnlockSlotButton.interactable = canUnlock;
            CommonViewHelper.SetImageGray(self.Root(), self.E_UnlockSlotButton.gameObject, !canUnlock);
        }

        private static async ETTask OnUnlockSlotButton(this ES_Rune self)
        {
            if (self.SelectSlotId == 0)
            {
                return;
            }

            int error = await RuneNetHelper.UnlockSlot(self.Root(), self.SelectSlotId);
            if (error != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), error);
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("孔位已开启");
            self.OnUpdateUI();
        }

        #region 镶嵌

        /// <summary>
        /// 镶嵌面板：列出背包里和孔位同类型、还没镶的符文，选中一枚后点确认镶嵌
        /// </summary>
        private static void RefreshSocketPanel(this ES_Rune self, RuneComponentC runeComponent)
        {
            RuneSlotConfig slotConfig = RuneSlotConfigCategory.Instance.GetOrDefault(self.SelectSlotId);
            if (slotConfig == null)
            {
                return;
            }

            self.E_RuneSlotType_SocketText.text = $"{GetRuneTypeDesc(slotConfig.RuneType)}属性槽";

            List<RuneData> candidateList = new List<RuneData>();
            List<RuneData> bagRuneList = runeComponent.GetBagRuneList();
            for (int i = 0; i < bagRuneList.Count; i++)
            {
                RuneConfig runeConfig = RuneConfigCategory.Instance.GetOrDefault(bagRuneList[i].ConfigId);
                if (runeConfig == null || runeConfig.RuneType != slotConfig.RuneType)
                {
                    continue;
                }

                candidateList.Add(bagRuneList[i]);
            }

            //选中的符文已经不在列表里了（镶掉了或者换了孔位），清掉选中
            bool selectExist = false;
            for (int i = 0; i < candidateList.Count; i++)
            {
                if (candidateList[i].Id == self.SelectSocketRuneId)
                {
                    selectExist = true;
                    break;
                }
            }

            if (!selectExist)
            {
                self.SelectSocketRuneId = 0;
            }

            Transform contentTrans = self.E_SockeRunetItemsScrollRect.transform.Find("Content");
            if (contentTrans == null)
            {
                Log.Error("ES_Rune 预制体缺少 EG_Socket/E_SockeRunetItems/Content 节点");
                return;
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < candidateList.Count; i++)
            {
                if (!self.SocketItems.ContainsKey(i))
                {
                    Scroll_Item_SockeRunetItem item = self.AddChild<Scroll_Item_SockeRunetItem>();
                    if (!self.AssetList.Contains(SocketItemPrefabPath))
                    {
                        self.AssetList.Add(SocketItemPrefabPath);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(SocketItemPrefabPath);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, contentTrans);
                    item.BindTrans(go.transform);
                    self.SocketItems.Add(i, item);
                }

                Scroll_Item_SockeRunetItem socketItem = self.SocketItems[i];
                socketItem.uiTransform.gameObject.SetActive(true);
                socketItem.OnInitUI(candidateList[i]);
                socketItem.SetSelected(self.SelectSocketRuneId == candidateList[i].Id);
            }

            //多出来的条目复用隐藏
            for (int i = candidateList.Count; i < self.SocketItems.Count; i++)
            {
                Scroll_Item_SockeRunetItem item = self.SocketItems[i];
                item.uiTransform.gameObject.SetActive(false);
            }

            self.RefreshSocketButton();
        }

        /// <summary>
        /// 点击可用符文条目：记住选中的符文，刷新高亮和确认按钮
        /// </summary>
        public static void OnClickSocketRune(this ES_Rune self, long runeId)
        {
            self.SelectSocketRuneId = runeId;

            for (int i = 0; i < self.SocketItems.Count; i++)
            {
                Scroll_Item_SockeRunetItem item = self.SocketItems[i];
                item.SetSelected(item.DataId == runeId);
            }

            self.RefreshSocketButton();
        }

        private static void RefreshSocketButton(this ES_Rune self)
        {
            bool canSocket = self.SelectSocketRuneId != 0;
            self.E_SocketButton.interactable = canSocket;
            CommonViewHelper.SetImageGray(self.Root(), self.E_SocketButton.gameObject, !canSocket);
        }

        private static async ETTask OnSocketButton(this ES_Rune self)
        {
            if (self.SelectSlotId == 0 || self.SelectSocketRuneId == 0)
            {
                return;
            }

            int error = await RuneNetHelper.SocketRune(self.Root(), self.SelectSlotId, self.SelectSocketRuneId);
            if (error != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), error);
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("镶嵌成功");
            self.SelectSocketRuneId = 0;
            self.OnUpdateUI();
        }

        #endregion

        #region 拆卸

        /// <summary>
        /// 拆卸面板：显示孔位里那枚符文的图标、名字、等级、类型和当前效果
        /// </summary>
        private static void RefreshUnsocketPanel(this ES_Rune self, RuneComponentC runeComponent)
        {
            RuneData rune = runeComponent.GetSlotRune(self.SelectSlotId);
            RuneConfig runeConfig = runeComponent.GetRuneConfig(rune);
            if (runeConfig == null)
            {
                self.EG_UnsocketRectTransform.gameObject.SetActive(false);
                return;
            }

            //RuneConfig 的 Icon 是 RoleSkillIcon 图集下的图标id
            Sprite iconSprite = self.LoadRuneIcon(runeConfig.Icon);
            if (iconSprite != null)
            {
                self.E_RuneIconImage.sprite = iconSprite;
            }

            self.E_RuneNameText.text = runeConfig.Name;
            self.E_RuneLv_UnsocketText.text = $"Lv.{runeConfig.Lv}";
            self.E_RuneTypeText.text = $"{GetRuneTypeDesc(runeConfig.RuneType)}属性槽";
            self.E_RuneDescText.text = runeConfig.Des;
        }

        private static async ETTask OnUnsocketButton(this ES_Rune self)
        {
            if (self.SelectSlotId == 0)
            {
                return;
            }

            int error = await RuneNetHelper.UnsocketRune(self.Root(), self.SelectSlotId);
            if (error != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), error);
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("拆卸成功");

            //符文回到背包，面板会切到镶嵌列表，之前挑的符文清掉
            self.SelectSocketRuneId = 0;
            self.OnUpdateUI();
        }

        #endregion

        #region 符文背包

        private static void OnClickBagButton(this ES_Rune self)
        {
            self.OpenRuneBag();
        }

        /// <summary>
        /// 打开符文背包：背包挂在 ES_Rune 下面，放到最后盖住符文主界面
        /// </summary>
        public static void OpenRuneBag(this ES_Rune self)
        {
            ES_RuneBag runeBag = self.GetOrCreateRuneBag();
            if (runeBag == null)
            {
                return;
            }

            runeBag.uiTransform.gameObject.SetActive(true);
            runeBag.uiTransform.SetAsLastSibling();

            //每次打开都清掉选中，并按最新数据刷一遍列表
            runeBag.OnOpenBag();
        }

        /// <summary>
        /// ES_RuneBag 里点 E_Return 回到符文主界面
        /// </summary>
        public static void CloseRuneBag(this ES_Rune self)
        {
            self.HideRuneBag();
            self.OnUpdateUI();
        }

        private static void HideRuneBag(this ES_Rune self)
        {
            ES_RuneBag runeBag = self.RuneBag;
            if (runeBag == null)
            {
                return;
            }

            runeBag.uiTransform.gameObject.SetActive(false);
        }

        /// <summary>
        /// 第一次点 E_Bag 才加载预制体，之后复用同一个
        /// </summary>
        private static ES_RuneBag GetOrCreateRuneBag(this ES_Rune self)
        {
            ES_RuneBag runeBag = self.RuneBag;
            if (runeBag != null)
            {
                return runeBag;
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(RuneBagPrefabPath);
            if (prefab == null)
            {
                Log.Error($"符文背包预制体加载失败：{RuneBagPrefabPath}");
                return null;
            }

            GameObject go = UnityEngine.Object.Instantiate(prefab, self.uiTransform);
            go.SetActive(false);

            if (!self.AssetList.Contains(RuneBagPrefabPath))
            {
                self.AssetList.Add(RuneBagPrefabPath);
            }

            runeBag = self.AddChild<ES_RuneBag, Transform>(go.transform);
            self.RuneBag = runeBag;
            return runeBag;
        }

        #endregion

        /// <summary>
        /// 符文图标：RuneConfig.Icon 就是 RoleSkillIcon 图集下的图标id，
        /// 资源由 ResourcesLoaderComponent 按路径缓存，不用自己卸载
        /// </summary>
        public static Sprite LoadRuneIcon(this ES_Rune self, string icon)
        {
            if (string.IsNullOrEmpty(icon))
            {
                return null;
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, icon);
            return self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
        }

        /// <summary>
        /// 进度条填充比例，要求为 0 时算满
        /// </summary>
        private static float GetFillAmount(int curValue, int targetValue)
        {
            if (targetValue <= 0)
            {
                return 1f;
            }

            return Mathf.Clamp01(curValue * 1f / targetValue);
        }

        private static string GetRuneTypeName(RuneType runeType)
        {
            switch (runeType)
            {
                case RuneType.Skill:
                    return "技能孔";
                case RuneType.Attack:
                    return "攻击孔";
                case RuneType.Defense:
                    return "防御孔";
                default:
                    return "未知孔位";
            }
        }

        private static string GetRuneTypeDesc(RuneType runeType)
        {
            switch (runeType)
            {
                case RuneType.Skill:
                    return "技能";
                case RuneType.Attack:
                    return "攻击";
                case RuneType.Defense:
                    return "防御";
                default:
                    return string.Empty;
            }
        }
    }
}
