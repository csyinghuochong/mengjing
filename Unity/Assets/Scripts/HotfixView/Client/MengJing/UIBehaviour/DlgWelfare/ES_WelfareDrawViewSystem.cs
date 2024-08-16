using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_WelfareDraw))]
    [FriendOfAttribute(typeof(ES_WelfareDraw))]
    public static partial class ES_WelfareDrawSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WelfareDraw self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_DrawBtnButton.AddListenerAsync(self.OnDrawBtnButton);
            self.Init();
        }

        [EntitySystem]
        private static void Destroy(this ES_WelfareDraw self)
        {
            self.DestroyWidget();
        }

        public static void Init(this ES_WelfareDraw self)
        {
            self.Draws.Clear();
            self.OutLines.Clear();

            GameObject outLine6 = null;
            for (int i = 0; i < self.EG_DrawListRectTransform.childCount; i++)
            {
                GameObject go = self.EG_DrawListRectTransform.GetChild(i).gameObject;
                self.Draws.Add(go);
                List<RewardItem> rewardItems = null;
                if (i == 6)
                {
                    UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                    int weaponId = CommonHelp.GetWelfareWeapon(userInfoComponent.UserInfo.Occ, userInfoComponent.UserInfo.OccTwo);
                    using (zstring.Block())
                    {
                        string reward = zstring.Format("{0};1", weaponId);
                        rewardItems = ItemHelper.GetRewardItems(reward);
                    }
                }
                else
                {
                    rewardItems = ItemHelper.GetRewardItems(ConfigData.WelfareDrawList[i].Value);
                }

                switch (i)
                {
                    case 0:
                        self.ES_RewardList_1.Refresh(rewardItems, 0.8f, true, true);
                        break;
                    case 1:
                        self.ES_RewardList_2.Refresh(rewardItems, 0.8f, true, true);
                        break;
                    case 2:
                        self.ES_RewardList_3.Refresh(rewardItems, 0.8f, true, true);
                        break;
                    case 3:
                        self.ES_RewardList_4.Refresh(rewardItems, 0.8f, true, true);
                        break;
                    case 4:
                        self.ES_RewardList_5.Refresh(rewardItems, 0.8f, true, true);
                        break;
                    case 5:
                        self.ES_RewardList_6.Refresh(rewardItems, 0.8f, true, true);
                        break;
                    case 6:
                        self.ES_RewardList_7.Refresh(rewardItems, 0.8f, true, true);
                        break;
                }

                GameObject outline = go.GetComponent<ReferenceCollector>().Get<GameObject>("SelectImg");
                // 第6和7互换一下位置
                if (i == 5)
                {
                    outLine6 = outline;
                }
                else
                {
                    self.OutLines.Add(outline);
                }

                outline.SetActive(false);
            }

            self.OutLines.Add(outLine6);

            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            int drawReward = numericComponent.GetAsInt(NumericType.DrawReward);
            if (drawReward == 1)
            {
                int index = numericComponent.GetAsInt(NumericType.DrawIndex) - 1;
                self.E_DrawBtnButton.interactable = true;
                self.Draws[index].GetComponent<ReferenceCollector>().Get<GameObject>("ReceivedImg").SetActive(true);
                GameObject rewardList = self.Draws[index].GetComponent<ReferenceCollector>().Get<GameObject>("RewardListNode");
                for (int j = 0; j < rewardList.transform.childCount; j++)
                {
                    GameObject uiItem = rewardList.transform.GetChild(j).gameObject;

                    CommonViewHelper.SetImageGray(self.Root(), uiItem.GetComponent<ReferenceCollector>().Get<GameObject>("Image_ItemIcon"), true);
                    CommonViewHelper.SetImageGray(self.Root(), uiItem.GetComponent<ReferenceCollector>().Get<GameObject>("Image_ItemQuality"), true);
                    uiItem.GetComponent<ReferenceCollector>().Get<GameObject>("Label_ItemName").SetActive(false);
                }

                self.Draws[index].GetComponent<ReferenceCollector>().Get<GameObject>("Text")?.SetActive(false);
            }
        }

        public static async ETTask OnDrawBtnButton(this ES_WelfareDraw self)
        {
            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            int drawReward = numericComponent.GetAsInt(NumericType.DrawReward);
            if (drawReward == 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经参与过抽奖！");
                return;
            }

            // long haveHuoyue = self.Root().GetComponent<TaskComponentC>().GetHuoYueDu();
            // if (haveHuoyue < 60)
            // {
            //     FlyTipComponent.Instance.ShowFlyTip("活跃度不足！");
            //     return;
            // }

            self.E_DrawBtnButton.interactable = true;

            int drawIndex = numericComponent.GetAsInt(NumericType.DrawIndex);
            if (drawIndex > 0)
            {
                self.StartRotation(drawIndex - 1).Coroutine();
            }
            else
            {
                M2C_WelfareDrawResponse response = await ActivityNetHelper.WelfareDraw(self.Root());

                if (response.Error != ErrorCode.ERR_Success)
                {
                    return;
                }

                self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareDraw);
                drawIndex = numericComponent.GetAsInt(NumericType.DrawIndex);
                self.StartRotation(drawIndex - 1).Coroutine();
            }
        }

        public static async ETTask StartRotation(this ES_WelfareDraw self, int index)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            self.E_DrawBtnButton.interactable = false;
            int ran = RandomHelper.RandomNumber(20, 30);
            int i = 0;
            while (!self.IsDisposed)
            {
                if (i % 7 == 0)
                {
                    self.OutLines[6].SetActive(false);
                }
                else
                {
                    self.OutLines[i % 7 - 1].SetActive(false);
                }

                self.OutLines[i % 7].SetActive(true);

                if (i > ran)
                {
                    if (index < 5 && i % 7 == index)
                    {
                        await ActivityNetHelper.WelfareDraw(self.Root());
                        break;
                    }

                    if (index == 5 && i % 7 == 6)
                    {
                        await ActivityNetHelper.WelfareDraw(self.Root());
                        break;
                    }

                    if (index == 6 && i % 7 == 5)
                    {
                        await ActivityNetHelper.WelfareDraw(self.Root());
                        break;
                    }
                }

                i++;
                await timerComponent.WaitAsync(250);
                if (self.IsDisposed)
                {
                    return;
                }
            }

            self.E_DrawBtnButton.interactable = true;
            self.Draws[index].GetComponent<ReferenceCollector>().Get<GameObject>("ReceivedImg").SetActive(true);
            GameObject rewardList = self.Draws[index].GetComponent<ReferenceCollector>().Get<GameObject>("RewardListNode");
            for (int j = 0; j < rewardList.transform.childCount; j++)
            {
                GameObject uiItem = rewardList.transform.GetChild(j).gameObject;

                ReferenceCollector rc = uiItem.transform.GetChild(1).GetComponent<ReferenceCollector>();
                CommonViewHelper.SetImageGray(self.Root(), rc.Get<GameObject>("Image_ItemIcon"), true);
                CommonViewHelper.SetImageGray(self.Root(), rc.Get<GameObject>("Image_ItemQuality"), true);
                rc.Get<GameObject>("Label_ItemName").SetActive(false);
            }

            self.Draws[index].GetComponent<ReferenceCollector>().Get<GameObject>("Text")?.SetActive(false);
        }
    }
}