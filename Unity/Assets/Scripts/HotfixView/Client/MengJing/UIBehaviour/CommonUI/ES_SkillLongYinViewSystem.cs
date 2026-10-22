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

            //重置功能暂未开放
            self.E_ReSetTianFuButton.gameObject.SetActive(false);

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

            self.RefreshLongYinList();
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

            foreach (ES_SkillLongYinItem item in self.Items)
            {
                item.Refresh(occ, self.SelectLongYinId);
            }

            self.RefreshLongYinBranchState(occ, skillSetComponent);

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
        /// 刷新5个龙印分支的觉醒状态显示：分支下的龙印全部激活才算觉醒，显示Active，否则显示Inactive
        /// </summary>
        private static void RefreshLongYinBranchState(this ES_SkillLongYin self, int occ, SkillSetComponentC skillSetComponent)
        {
            Transform content = self.EG_LongYinContentRectTransform;
            for (int branch = 1; branch <= 5; branch++)
            {
                int nodeCount = 0;
                bool allActive = true;
                for (int node = 1; node <= 8; node++)
                {
                    int longYinId = LongYinHelper.GetLongYinId(occ, branch * 1000 + node);
                    if (LongYinConfigCategory.Instance.GetOrDefault(longYinId) == null)
                    {
                        continue;
                    }

                    nodeCount++;
                    if (skillSetComponent.GetLongYinLevel(longYinId) <= 0)
                    {
                        allActive = false;
                    }
                }

                //该分支没有任何龙印配置时不显示觉醒
                if (nodeCount == 0)
                {
                    allActive = false;
                }

                Transform branchTrans = content.Find($"LongYinActive_{branch}");
                if (branchTrans == null)
                {
                    continue;
                }

                branchTrans.Find("Active")?.gameObject.SetActive(allActive);
                branchTrans.Find("Inactive")?.gameObject.SetActive(!allActive);
            }
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
                    buttonText.text = curLevel <= 0 ? "激活" : "升级";
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

            FlyTipComponent.Instance.ShowFlyTip("激活成功");
            self.RefreshLongYinList();
        }
    }
}
