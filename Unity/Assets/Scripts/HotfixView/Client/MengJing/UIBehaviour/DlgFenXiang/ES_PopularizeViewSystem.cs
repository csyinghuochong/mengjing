using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_Popularize))]
    [FriendOfAttribute(typeof(ES_Popularize))]
    public static partial class ES_PopularizeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_Popularize self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Text_Button_CopyButton.AddListener(self.OnText_Button_CopyButton);
            self.E_ButtonGetButton.AddListenerAsync(self.OnButtonGetButton);
            self.E_ButtonOkButton.AddListenerAsync(self.OnButtonOkButton);
            self.EG_UIPopularizeItemRectTransform.gameObject.SetActive(false);

            self.OnUpdateUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_Popularize self)
        {
            self.DestroyWidget();
        }

        public static void OnText_Button_CopyButton(this ES_Popularize self)
        {
            GUIUtility.systemCopyBuffer = self.E_Text_My_CodeText.text;
        }

        public static async ETTask OnButtonGetButton(this ES_Popularize self)
        {
            await ActivityNetHelper.Popularize_RewardRequest(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            self.E_ButtonGetButton.gameObject.SetActive(false);
        }

        public static async ETTask OnButtonOkButton(this ES_Popularize self)
        {
            if (self.BePopularize)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经作为被推广人");
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Lv >= 15)
            {
                FlyTipComponent.Instance.ShowFlyTip("大于15级不能作为推广人");
                return;
            }

            string inputtext = self.E_InputField_CodeInputField.text;
            if (string.IsNullOrEmpty(inputtext))
            {
                return;
            }

            long playerid = 0;
            try
            {
                playerid = long.Parse(inputtext);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return;
            }

            int error = await ActivityNetHelper.Popularize_PlayerRequest(self.Root(), playerid);
            if (self.IsDisposed)
            {
                return;
            }

            if (error == ErrorCode.ERR_Success)
            {
                self.BePopularize = true;
                self.E_InputField_CodeInputField.text = playerid.ToString();
            }
        }

        public static async ETTask OnUpdateUI(this ES_Popularize self)
        {
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            battleMessageComponent.LastPopularize_ListTime = TimeHelper.ServerNow();

            Popularize2C_ListResponse response = await ActivityNetHelper.Popularize_ListRequest(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            self.BePopularize = response.BePopularizeId > 0;
            self.E_InputField_CodeInputField.text = response.BePopularizeId.ToString();
            self.E_Text_My_CodeText.text = response.PopularizeCode.ToString();
            List<RewardItem> rewardlist = PopularizeHelper.GetRewardList(response.MyPopularizeList);
            int goldReward = 0;
            int diamondReward = 0;
            for (int i = 0; i < rewardlist.Count; i++)
            {
                if (rewardlist[i].ItemID == (int)UserDataType.Gold)
                {
                    goldReward += rewardlist[i].ItemNum;
                    continue;
                }

                if (rewardlist[i].ItemID == (int)UserDataType.Diamond)
                {
                    diamondReward += rewardlist[i].ItemNum;
                    continue;
                }
            }

            using (zstring.Block())
            {
                self.E_Text_Reward_1Text.text = zstring.Format("金币： {0}", goldReward);
                self.E_Text_Reward_2Text.text = zstring.Format("钻石： {0}", diamondReward);
                self.E_ButtonGetButton.gameObject.SetActive(rewardlist.Count > 0);

                // 测试数据
                // response.MyPopularizeList.Add(new PopularizeInfo() { Nmae = "测试角色1", Level = 20 });
                // response.MyPopularizeList.Add(new PopularizeInfo() { Nmae = "测试角色2", Level = 30 });

                for (int i = 0; i < response.MyPopularizeList.Count; i++)
                {
                    GameObject go = UnityEngine.Object.Instantiate(self.EG_UIPopularizeItemRectTransform.gameObject);
                    go.SetActive(true);
                    CommonViewHelper.SetParent(go, self.EG_BuildingListRectTransform.gameObject);

                    ReferenceCollector rc = go.GetComponent<ReferenceCollector>();
                    rc.Get<GameObject>("Text_Name").GetComponent<Text>().text = response.MyPopularizeList[i].Nmae;

                    rc.Get<GameObject>("Text_Level").GetComponent<Text>().text = zstring.Format("等级:{0}", response.MyPopularizeList[i].Level);
                }
            }
        }
    }
}
