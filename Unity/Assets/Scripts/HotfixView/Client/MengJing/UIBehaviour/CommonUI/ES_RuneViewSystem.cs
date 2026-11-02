using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ES_RuneSlotItem))]
    [EntitySystemOf(typeof(ES_Rune))]
    [FriendOfAttribute(typeof(ES_Rune))]
    public static partial class ES_RuneSystem
    {
        /// <summary>
        /// 预制体里孔位节点的名字前缀，完整名字形如 RuneSlotItem_11
        /// </summary>
        private const string SlotItemPrefix = "RuneSlotItem_";

        /// <summary>
        /// 孔位开启条件面板的节点名
        /// </summary>
        private const string UnlockSlotPanelName = "EG_UnlockSlot";

        [EntitySystem]
        private static void Awake(this ES_Rune self, Transform transform)
        {
            self.uiTransform = transform;

            self.InitRuneSlotItems();
            self.InitUnlockSlotPanel();
        }

        [EntitySystem]
        private static void Destroy(this ES_Rune self)
        {
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

        /// <summary>
        /// 开启条件面板里的文本和进度条没有 E_ 前缀的部分生成代码绑不到，这里按节点名手动取
        /// </summary>
        private static void InitUnlockSlotPanel(this ES_Rune self)
        {
            Transform panel = self.uiTransform.Find(UnlockSlotPanelName);
            if (panel == null)
            {
                Log.Error("ES_Rune 预制体缺少 EG_UnlockSlot 节点");
                return;
            }

            self.EG_UnlockSlotRectTransform = panel.GetComponent<RectTransform>();

            GameObject panelGo = panel.gameObject;
            self.E_RuneSlotType_UnlockSlotText = UIFindHelper.FindDeepChild<Text>(panelGo, "E_RuneSlotType_UnlockSlot");
            self.E_PlayerLvText = UIFindHelper.FindDeepChild<Text>(panelGo, "E_PlayerLv");
            self.E_PlayerLvTargetText = UIFindHelper.FindDeepChild<Text>(panelGo, "E_PlayerLvTarget");
            self.E_LodingValue_PlayerLvImage = UIFindHelper.FindDeepChild<Image>(panelGo, "E_LodingValue_PlayerLv");
            self.E_RuneLvText = UIFindHelper.FindDeepChild<Text>(panelGo, "E_RuneLv");
            self.E_RuneLvTargetText = UIFindHelper.FindDeepChild<Text>(panelGo, "E_RuneLvTarget");
            self.E_LodingValue_RuneLvImage = UIFindHelper.FindDeepChild<Image>(panelGo, "E_LodingValue_RuneLv");
            self.E_RuneSlotDesText = UIFindHelper.FindDeepChild<Text>(panelGo, "E_RuneSlotDes");
            self.E_UnlockSlotButton = UIFindHelper.FindDeepChild<Button>(panelGo, "E_UnlockSlot");

            self.E_UnlockSlotButton.AddListenerAsync(self.OnUnlockSlotButton);
            self.EG_UnlockSlotRectTransform.gameObject.SetActive(false);
        }

        /// <summary>
        /// 刷新孔位状态和开启条件面板：没解锁的孔位显示锁，选中的孔位显示选中框
        /// </summary>
        public static void OnUpdateUI(this ES_Rune self)
        {
            if (self.EG_UnlockSlotRectTransform == null)
            {
                return;
            }

            RuneComponentC runeComponent = self.Root().GetComponent<RuneComponentC>();
            if (runeComponent == null)
            {
                return;
            }

            for (int i = 0; i < self.SlotItems.Count; i++)
            {
                ES_RuneSlotItem item = self.SlotItems[i];
                bool unlocked = runeComponent.IsSlotUnlocked(item.SlotId);
                bool hasRune = runeComponent.GetSlotRuneId(item.SlotId) != 0;
                item.OnUpdateUI(unlocked, hasRune, self.SelectSlotId == item.SlotId);
            }

            //只有选中的孔位还没解锁时才弹开启条件面板
            bool showUnlockSlot = self.SelectSlotId != 0 && !runeComponent.IsSlotUnlocked(self.SelectSlotId);
            self.EG_UnlockSlotRectTransform.gameObject.SetActive(showUnlockSlot);
            if (showUnlockSlot)
            {
                self.RefreshUnlockSlot(runeComponent);
            }
        }

        /// <summary>
        /// 点击孔位：显示选中框，没解锁的孔位同时弹出开启条件面板
        /// </summary>
        public static void OnClickRuneSlot(this ES_Rune self, int slotId)
        {
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
