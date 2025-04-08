using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivityTokenItem))]
    [EntitySystemOf(typeof(Scroll_Item_ActivityTokenItem))]
    public static partial class Scroll_Item_ActivityTokenItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ActivityTokenItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ActivityTokenItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask On_Btn_LingQu(this Scroll_Item_ActivityTokenItem self, int index)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Lv < int.Parse(self.ActivityConfig.Par_1))
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包已满！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int selfRechage = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber);
            if (index == 3 && selfRechage < 298)
            {
                FlyTipComponent.Instance.ShowFlyTip("未达到领取条件！");
                return;
            }

            if (index == 2 && selfRechage < 98)
            {
                FlyTipComponent.Instance.ShowFlyTip("未达到领取条件！");
                return;
            }

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            List<TokenRecvive> zhanQuTokenRecvives = activityComponent.QuTokenRecvive;
            for (int i = 0; i < zhanQuTokenRecvives.Count; i++)
            {
                if (zhanQuTokenRecvives[i].ActivityId == self.ActivityConfig.Id
                    && zhanQuTokenRecvives[i].ReceiveIndex == index)
                {
                    return;
                }
            }
            
            M2C_ActivityReceiveResponse response =  await ActivityNetHelper.ActivityReceive(self.Root(), 24, self.ActivityConfig.Id, index);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }
            
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
            DlgCommonReward dlgCommonReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>();
            dlgCommonReward.OnUpdateUI(response.RewardList);

            TokenRecvive tokenRecvive = TokenRecvive.Create();
            tokenRecvive.ActivityId = self.ActivityConfig.Id;
            tokenRecvive.ReceiveIndex = index;
            zhanQuTokenRecvives.Add(tokenRecvive);
            self.SetReceiced(self.E_LingQuHint_3Image.gameObject, 3);
            self.SetReceiced(self.E_LingQuHint_2Image.gameObject, 2);
            self.SetReceiced(self.E_LingQuHint_1Image.gameObject, 1);
        }

        public static void OnInitUI(this Scroll_Item_ActivityTokenItem self, ActivityConfig activityConfig)
        {
            self.E_Btn_LingQu_3Button.AddListener(() => { self.On_Btn_LingQu(3).Coroutine(); });
            self.E_Btn_LingQu_2Button.AddListener(() => { self.On_Btn_LingQu(2).Coroutine(); });
            self.E_Btn_LingQu_1Button.AddListener(() => { self.On_Btn_LingQu(1).Coroutine(); });

            self.ActivityConfig = activityConfig;
            using (zstring.Block())
            {
                self.E_TextNameText.text = zstring.Format("{0}级", activityConfig.Par_1);
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int selfRechage = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber);

            int needLv = int.Parse(activityConfig.Par_1);
            int selflv = self.Root().GetComponent<UserInfoComponentC>().GetUserLv();
            
            ItemInfo bagInfo1 = new ItemInfo();
            bagInfo1.ItemID = int.Parse(activityConfig.Par_2.Split(';')[0]);
            bagInfo1.ItemNum = int.Parse(activityConfig.Par_2.Split(';')[1]);
            self.ES_CommonItem_1.UpdateItem(bagInfo1, ItemOperateEnum.None);
            CommonViewHelper.SetImageGray( self.Root(), self.ES_CommonItem_1.E_ItemIconImage.gameObject,  selflv < needLv);

            ItemInfo bagInfo2 = new ItemInfo();
            bagInfo2.ItemID = int.Parse(activityConfig.Par_3.Split(';')[0]);
            bagInfo2.ItemNum = int.Parse(activityConfig.Par_3.Split(';')[1]);
            self.ES_CommonItem_2.UpdateItem(bagInfo2, ItemOperateEnum.None);
            self.ES_CommonItem_2.ShowUIEffect(41100001);
            CommonViewHelper.SetImageGray( self.Root(), self.ES_CommonItem_2.E_ItemIconImage.gameObject, selfRechage < 98 || selflv < needLv);

            ItemInfo bagInfo3 = new ItemInfo();
            bagInfo3.ItemID = int.Parse(activityConfig.Par_4.Split(';')[0]);
            bagInfo3.ItemNum = int.Parse(activityConfig.Par_4.Split(';')[1]);
            self.ES_CommonItem_3.UpdateItem(bagInfo3, ItemOperateEnum.None);
            self.ES_CommonItem_3.ShowUIEffect(41100001); 
            CommonViewHelper.SetImageGray( self.Root(), self.ES_CommonItem_3.E_ItemIconImage.gameObject, selfRechage < 298|| selflv < needLv);

            self.SetReceiced(self.E_LingQuHint_3Image.gameObject, 3);
            self.SetReceiced(self.E_LingQuHint_2Image.gameObject, 2);
            self.SetReceiced(self.E_LingQuHint_1Image.gameObject, 1);
        }

        public static void SetReceiced(this Scroll_Item_ActivityTokenItem self, GameObject gameObject, int index)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            List<TokenRecvive> zhanQuTokenRecvives = activityComponent.QuTokenRecvive;
            for (int i = 0; i < zhanQuTokenRecvives.Count; i++)
            {
                if (zhanQuTokenRecvives[i].ActivityId == self.ActivityConfig.Id
                    && zhanQuTokenRecvives[i].ReceiveIndex == index)
                {
                    gameObject.SetActive(true);
                    return;
                }
            }

            gameObject.SetActive(false);
        }
    }
}