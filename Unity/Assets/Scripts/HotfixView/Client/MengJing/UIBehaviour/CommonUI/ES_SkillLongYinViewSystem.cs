using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_SkillLongYin))]
    [FriendOfAttribute(typeof(ES_SkillLongYin))]
    [FriendOf(typeof(ES_SkillLongYinItem))]
    public static partial class ES_SkillLongYinSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillLongYin self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ActiveLongYinButton.AddListenerAsync(self.OnBtn_ActiveLongYinButton);
            self.E_ReSetButton.AddListenerAsync(self.OnBtn_ReSetLongYinButton);

            //觉醒信息默认不显示
            self.EG_LongYinAwakenRectTransform.gameObject.SetActive(false);

            Transform content = self.EG_LongYinContentRectTransform;
            for (int i = 0; i < content.childCount; i++)
            {
                Transform subTrans = content.GetChild(i);
                if (!subTrans.name.StartsWith("SkilLongYinItem_"))
                {
                    continue;
                }

                if (!int.TryParse(subTrans.name.Substring("SkilLongYinItem_".Length), out int index))
                {
                    continue;
                }

                ES_SkillLongYinItem item = self.AddChild<ES_SkillLongYinItem, Transform>(subTrans);
                item.Init(index);
                self.Items.Add(item);
            }

            self.InitLongYinAwakenNodes();

            self.RefreshLongYinList();
        }

        /// <summary>
        /// 绑定双龙/三龙/五龙觉醒节点的点击，节点名后缀为需要的龙印类型数量
        /// </summary>
        private static void InitLongYinAwakenNodes(this ES_SkillLongYin self)
        {
            Transform content = self.EG_LongYinContentRectTransform;
            for (int i = 0; i < content.childCount; i++)
            {
                Transform subTrans = content.GetChild(i);
                if (!subTrans.name.StartsWith("LongYinAwaken_"))
                {
                    continue;
                }

                if (!int.TryParse(subTrans.name.Substring("LongYinAwaken_".Length), out int awakenType))
                {
                    continue;
                }

                Button button = subTrans.GetComponentInChildren<Button>(true);
                if (button == null)
                {
                    continue;
                }

                button.AddListenerWithParam(self.OnClickLongYinAwaken, awakenType);
            }
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillLongYin self)
        {
            self.DestroyWidget();
        }

        public static void RefreshLongYinList(this ES_SkillLongYin self)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();

            self.RefreshLongYinPoint(skillSetComponent);
            self.RefreshLongYinAwakenNum(occ, skillSetComponent);

            foreach (ES_SkillLongYinItem item in self.Items)
            {
                item.Refresh(occ, self.SelectLongYinId);
            }

            self.RefreshLongYinBranchState(occ, skillSetComponent);
            self.RefreshLongYinAwakenNodeState();

            //正在查看觉醒信息时保持觉醒面板，不切回普通龙印信息
            if (self.SelectLongYinAwakenType != 0)
            {
                if (self.ShowLongYinAwaken(self.SelectLongYinAwakenType))
                {
                    return;
                }

                self.SelectLongYinAwakenType = 0;
            }

            ES_SkillLongYinItem selectItem = null;
            if (self.SelectLongYinId != 0)
            {
                foreach (ES_SkillLongYinItem item in self.Items)
                {
                    if (item.Visible && item.LongYinId == self.SelectLongYinId)
                    {
                        selectItem = item;
                        break;
                    }
                }
            }

            //没有选中项时默认选中编号最小的龙印
            if (selectItem == null)
            {
                foreach (ES_SkillLongYinItem item in self.Items)
                {
                    if (!item.Visible)
                    {
                        continue;
                    }

                    if (selectItem == null || item.Index < selectItem.Index)
                    {
                        selectItem = item;
                    }
                }
            }

            if (selectItem == null)
            {
                self.SelectLongYinId = 0;
                self.EG_LongYinRectTransform.gameObject.SetActive(false);
                return;
            }

            self.SelectLongYinItem(selectItem);
        }

        /// <summary>
        /// 刷新龙印点显示：龙印点不存变量，由玩家等级和已激活龙印等级实时换算
        /// </summary>
        private static void RefreshLongYinPoint(this ES_SkillLongYin self, SkillSetComponentC skillSetComponent)
        {
            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            int maxPoint = LongYinHelper.GetPointMax(playerLv);
            int leftPoint = skillSetComponent.GetLongYinPointLeft(playerLv);
            if (leftPoint < 0)
            {
                leftPoint = 0;
            }

            self.E_LongYinPointText.text = $"龙印点：{leftPoint}";
        }

        /// <summary>
        /// 刷新已觉醒数量显示：龙印类型全部激活且满级算觉醒1个，最多TypeCount个
        /// </summary>
        private static void RefreshLongYinAwakenNum(this ES_SkillLongYin self, int occ, SkillSetComponentC skillSetComponent)
        {
            int awakenNum = skillSetComponent.GetCompleteLongYinTypeCount(occ);
            self.E_LongYinAwakenNumText.text = $"已觉醒：{awakenNum}/{LongYinHelper.TypeCount}";
        }

        /// <summary>
        /// 刷新5个龙印分支的激活状态显示：分支第一个龙印需要击杀的Boss击杀过，显示Active，否则显示Inactive
        /// </summary>
        private static void RefreshLongYinBranchState(this ES_SkillLongYin self, int occ, SkillSetComponentC skillSetComponent)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            Transform content = self.EG_LongYinContentRectTransform;
            for (int branch = 1; branch <= 5; branch++)
            {
                Transform branchTrans = content.Find($"LongYinActive_{branch}");
                if (branchTrans == null)
                {
                    continue;
                }

                bool activated = self.IsLongYinBranchActivated(occ, branch, skillSetComponent, userInfoComponent);

                branchTrans.Find("Active")?.gameObject.SetActive(activated);
                branchTrans.Find("Inactive")?.gameObject.SetActive(!activated);
            }
        }

        /// <summary>
        /// 分支是否已激活：按分支第一个龙印配置的需要击杀Boss判断，全部击杀过才算激活；
        /// 该龙印没有配置Boss时，退回"分支龙印全部激活且满级"的判断
        /// </summary>
        private static bool IsLongYinBranchActivated(this ES_SkillLongYin self, int occ, int branch,
            SkillSetComponentC skillSetComponent, UserInfoComponentC userInfoComponent)
        {
            LongYinConfig firstConfig = LongYinHelper.GetFirstConfig(occ, branch);
            if (firstConfig == null)
            {
                return false;
            }

            bool haveBoss = false;
            for (int i = 0; i < firstConfig.NeedKillBoss.Length; i++)
            {
                int bossId = firstConfig.NeedKillBoss[i];
                if (bossId == 0)
                {
                    continue;
                }

                haveBoss = true;

                //击杀过的Boss不再提示，但击杀数可能为0，两个都要判断
                if (userInfoComponent.UserInfo.DefeatedBossIds.Contains(bossId) || userInfoComponent.GetMonsterKillNumber(bossId) > 0)
                {
                    continue;
                }

                return false;
            }

            if (!haveBoss)
            {
                return skillSetComponent.IsLongYinTypeComplete(occ, branch);
            }

            return true;
        }

        /// <summary>
        /// 刷新双龙/三龙/五龙觉醒节点的显示：已解锁显示ImageActive，被选中显示ImageSelect
        /// </summary>
        private static void RefreshLongYinAwakenNodeState(this ES_SkillLongYin self)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();

            Transform content = self.EG_LongYinContentRectTransform;
            for (int i = 0; i < content.childCount; i++)
            {
                Transform awakenTrans = content.GetChild(i);
                if (!awakenTrans.name.StartsWith("LongYinAwaken_"))
                {
                    continue;
                }

                if (!int.TryParse(awakenTrans.name.Substring("LongYinAwaken_".Length), out int awakenType))
                {
                    continue;
                }

                LongYinConfig longYinConfig = LongYinHelper.GetAwakenConfig(occ, (LongYinType)awakenType);
                bool unlocked = longYinConfig != null && skillSetComponent.HaveLongYin(longYinConfig.Id);

                awakenTrans.Find("ImageActive")?.gameObject.SetActive(unlocked);
                awakenTrans.Find("ImageSelect")?.gameObject.SetActive(self.SelectLongYinAwakenType == awakenType);
            }
        }

        public static void OnClickLongYinAwaken(this ES_SkillLongYin self, int awakenType)
        {
            //再次点击同一个觉醒节点则收起，回到普通龙印信息
            if (self.SelectLongYinAwakenType == awakenType)
            {
                self.HideLongYinAwaken();
                self.RefreshLongYinList();
                return;
            }

            self.SelectLongYinId = 0;
            self.SelectLongYinAwakenType = awakenType;
            self.RefreshLongYinList();
        }

        /// <summary>
        /// 显示双龙/三龙/五龙觉醒信息，没有配置返回false
        /// </summary>
        private static bool ShowLongYinAwaken(this ES_SkillLongYin self, int awakenType)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            LongYinConfig longYinConfig = LongYinHelper.GetAwakenConfig(occ, (LongYinType)awakenType);
            if (longYinConfig == null)
            {
                self.HideLongYinAwaken();
                return false;
            }

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            int needTypeCount = LongYinHelper.GetAwakenNeedTypeCount(longYinConfig.Type);
            int completeTypeCount = skillSetComponent.GetCompleteLongYinTypeCount(occ);
            bool unlocked = skillSetComponent.HaveLongYin(longYinConfig.Id);

            self.EG_LongYinRectTransform.gameObject.SetActive(false);
            self.EG_LongYinAwakenRectTransform.gameObject.SetActive(true);

            self.E_LongYinAwakenNameText.text = longYinConfig.Name;

            string desc = longYinConfig.Des ?? string.Empty;
            desc = desc.Replace("\\n", "\n");

            self.E_LongYinAwakenDescText.text = desc;
            TextFitTip textFitTip = self.E_LongYinAwakenDescText.GetComponent<TextFitTip>();
            if (textFitTip != null)
            {
                textFitTip.SetText(desc);
            }

            self.E_YinAwakenStateText.text = unlocked ? "已解锁" : "未解锁";

            //未解锁时显示解锁条件：需要几条分支全部点满
            self.E_YinAwakenConditionText.gameObject.SetActive(!unlocked);
            if (!unlocked)
            {
                self.E_YinAwakenConditionText.text = $"{needTypeCount}条分支全部点满";
            }

            Image icon = UIFindHelper.FindDeepChild<Image>(self.uiTransform.gameObject, "EG_LongYinAwaken/Icon");
            if (icon != null)
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, longYinConfig.Icon.ToString());
                icon.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            }

            return true;
        }

        private static void HideLongYinAwaken(this ES_SkillLongYin self)
        {
            self.SelectLongYinAwakenType = 0;
            self.EG_LongYinAwakenRectTransform.gameObject.SetActive(false);
        }

        public static void OnClickLongYinItem(this ES_SkillLongYin self, ES_SkillLongYinItem item)
        {
            if (item == null || !item.Visible)
            {
                return;
            }

            self.SelectLongYinItem(item);
        }

        private static void SelectLongYinItem(this ES_SkillLongYin self, ES_SkillLongYinItem item)
        {
            //从觉醒节点切回普通龙印时，要清掉觉醒节点的选中框
            bool awakenSelected = self.SelectLongYinAwakenType != 0;
            self.HideLongYinAwaken();
            if (awakenSelected)
            {
                self.RefreshLongYinAwakenNodeState();
            }

            self.EG_LongYinRectTransform.gameObject.SetActive(true);

            self.SelectLongYinId = item.LongYinId;
            foreach (ES_SkillLongYinItem longYinItem in self.Items)
            {
                longYinItem.SetSelected(longYinItem.LongYinId == self.SelectLongYinId);
            }

            self.ShowLongYinInfo(item);
        }

        private static void ShowLongYinInfo(this ES_SkillLongYin self, ES_SkillLongYinItem item)
        {
            LongYinConfig longYinConfig = LongYinConfigCategory.Instance.GetOrDefault(item.LongYinId);
            if (longYinConfig == null)
            {
                self.EG_LongYinRectTransform.gameObject.SetActive(false);
                return;
            }

            self.EG_LongYinRectTransform.gameObject.SetActive(true);

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            int curLevel = skillSetComponent.GetLongYinLevel(item.LongYinId);
            int maxLevel = longYinConfig.Lv;

            self.E_LongYinNameText.text = longYinConfig.Name;

            string desc = longYinConfig.Des ?? string.Empty;
            desc = desc.Replace("\\n", "\n");
            self.E_LongYinDescText.text = desc;

            TextFitTip textFitTip = self.E_LongYinDescText.GetComponent<TextFitTip>();
            if (textFitTip != null)
            {
                textFitTip.SetText(desc);
            }

            self.E_LongYinLevelText.text = $"龙印等级：{curLevel}/{maxLevel}";

            //未激活时显示解锁需要击杀的Boss，没有则隐藏
            string needKillBossNames = string.Empty;
            if (curLevel <= 0)
            {
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                for (int i = 0; i < longYinConfig.NeedKillBoss.Length; i++)
                {
                    int bossId = longYinConfig.NeedKillBoss[i];
                    if (bossId == 0)
                    {
                        continue;
                    }

                    //击杀过的Boss不再提示
                    if (userInfoComponent.UserInfo.DefeatedBossIds.Contains(bossId) || userInfoComponent.GetMonsterKillNumber(bossId) > 0)
                    {
                        continue;
                    }

                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.GetOrDefault(bossId);
                    string bossName = monsterConfig == null ? bossId.ToString() : monsterConfig.MonsterName;

                    if (needKillBossNames.Length > 0)
                    {
                        needKillBossNames += "、";
                    }

                    needKillBossNames += bossName;
                }
            }

            self.E_NeedKillBossText.gameObject.SetActive(needKillBossNames.Length > 0);
            if (needKillBossNames.Length > 0)
            {
                self.E_NeedKillBossText.text = $"需击杀：{needKillBossNames}";
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, longYinConfig.Icon.ToString());
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_LongYinIconImage.sprite = sprite;
            CommonViewHelper.SetImageGray(self.Root(), self.E_LongYinIconImage.gameObject, curLevel <= 0);

            //未激活时显示激活按钮，已满级则隐藏
            bool canUpgrade = curLevel < maxLevel;
            self.E_ActiveLongYinButton.gameObject.SetActive(canUpgrade);
            if (canUpgrade)
            {
                Text buttonText = self.E_ActiveLongYinButton.GetComponentInChildren<Text>();
                if (buttonText != null)
                {
                    buttonText.text = curLevel <= 0 ? "点亮" : "升级";
                }
            }
        }

        private static async ETTask OnBtn_ActiveLongYinButton(this ES_SkillLongYin self)
        {
            if (self.SelectLongYinId == 0)
            {
                return;
            }

            int error = await SkillNetHelper.LongYinActiveRequest(self.Root(), self.SelectLongYinId);
            if (error != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), error);
                return;
            }

            self.RefreshLongYinList();
        }

        private static async ETTask OnBtn_ReSetLongYinButton(this ES_SkillLongYin self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "重置龙印",
                "重置后所有已激活的龙印都会被清空，已消耗的龙印点全部返还，是否继续？",
                () => { self.ReSetLongYin().Coroutine(); }).Coroutine();

            await ETTask.CompletedTask;
        }

        private static async ETTask ReSetLongYin(this ES_SkillLongYin self)
        {
            int error = await SkillNetHelper.LongYinReSetRequest(self.Root());
            if (error != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), error);
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("重置成功");

            //觉醒也一起被清掉了，收起觉醒信息回到普通龙印信息
            self.HideLongYinAwaken();
            self.RefreshLongYinList();
        }
    }
}
