using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_WelfareDraw2))]
    [FriendOfAttribute(typeof(ES_WelfareDraw2))]
    public static partial class ES_WelfareDraw2System
    {
        [EntitySystem]
        private static void Awake(this ES_WelfareDraw2 self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_DrawBtnButton.AddListenerAsync(self.OnDrawBtnButton);

            self.Init();
        }

        [EntitySystem]
        private static void Destroy(this ES_WelfareDraw2 self)
        {
            self.DestroyWidget();
        }

        public static void Init(this ES_WelfareDraw2 self)
        {
            self.Draws.Clear();
            self.OutLines.Clear();

            List<ItemInfo> bagInfos = new List<ItemInfo>();
            foreach (List<ItemInfo> infos in self.Root().GetComponent<BagComponentC>().AllItemList.Values)
            {
                bagInfos.AddRange(infos);
            }

            List<string> rewardItems = ActivityHelper.GetWelfareChouKaReward(bagInfos);
            for (int i = 0; i < self.EG_DrawListRectTransform.childCount; i++)
            {
                GameObject go = self.EG_DrawListRectTransform.GetChild(i).gameObject;
                GameObject RewardListNode = go.GetComponent<ReferenceCollector>().Get<GameObject>("RewardListNode");
                self.Draws.Add(go);

                switch (i)
                {
                    case 0:
                        self.ES_RewardList_1.Refresh(rewardItems[i], 0.8f);
                        break;
                    case 1:
                        self.ES_RewardList_2.Refresh(rewardItems[i], 0.8f);
                        break;
                    case 2:
                        self.ES_RewardList_3.Refresh(rewardItems[i], 0.8f);
                        break;
                    case 3:
                        self.ES_RewardList_4.Refresh(rewardItems[i], 0.8f);
                        break;
                    case 4:
                        self.ES_RewardList_5.Refresh(rewardItems[i], 0.8f);
                        break;
                    case 5:
                        self.ES_RewardList_6.Refresh(rewardItems[i], 0.8f);
                        break;
                    case 6:
                        self.ES_RewardList_7.Refresh(rewardItems[i], 0.8f);
                        break;
                    case 7:
                        self.ES_RewardList_8.Refresh(rewardItems[i], 0.8f);
                        break;
                }

                go.GetComponent<ReferenceCollector>().Get<GameObject>("ReceivedImg").SetActive(false);
                GameObject outline = go.GetComponent<ReferenceCollector>().Get<GameObject>("SelectImg");

                self.OutLines.Add(outline);

                outline.SetActive(false);
            }

            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            self.E_NumTextText.text = (numericComponent.GetAsLong(NumericType.RechargeNumber) / 50 -
                numericComponent.GetAsLong(NumericType.WelfareChouKaNumber)).ToString();
        }

        public static async ETTask OnDrawBtnButton(this ES_WelfareDraw2 self)
        {
            self.Init();

            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            self.E_DrawBtnButton.interactable = true;

            int drawIndex = numericComponent.GetAsInt(NumericType.DrawIndex2);

            if (drawIndex > 0)
            {
                // 有奖励未领取，直接开始
                self.StartRotation(drawIndex - 1).Coroutine();
            }
            else
            {
                if (numericComponent.GetAsLong(NumericType.RechargeNumber) / 50 - numericComponent.GetAsLong(NumericType.WelfareChouKaNumber) <= 0)
                {
                    FlyTipComponent.Instance.ShowFlyTip("次数不足");
                    return;
                }

                M2C_WelfareDraw2Response response = await ActivityNetHelper.WelfareDraw2(self.Root());

                if (response.Error != ErrorCode.ERR_Success)
                {
                    return;
                }

                self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareDraw);
                drawIndex = numericComponent.GetAsInt(NumericType.DrawIndex2);
                self.StartRotation(drawIndex - 1).Coroutine();
            }

            self.E_NumTextText.text = (numericComponent.GetAsLong(NumericType.RechargeNumber) / 50 -
                numericComponent.GetAsLong(NumericType.WelfareChouKaNumber)).ToString();
        }

        public static async ETTask StartRotation(this ES_WelfareDraw2 self, int index)
        {
            self.E_DrawBtnButton.interactable = false;
            int ran = RandomHelper.RandomNumber(20, 30);
            int i = 0;

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                if (i % 8 == 0)
                {
                    self.OutLines[7].SetActive(false);
                }
                else
                {
                    self.OutLines[i % 8 - 1].SetActive(false);
                }

                self.OutLines[i % 8].SetActive(true);

                if (i > ran)
                {
                    if (i % 8 == index)
                    {
                        // 抽奖有一个转圈的效果，转圈结束后获取道具
                        await ActivityNetHelper.WelfareDraw2Reward(self.Root());
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