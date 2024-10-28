using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgUnionDonationRecordViewComponent))]
    [FriendOf(typeof(DlgUnionDonationRecord))]
    public static class DlgUnionDonationRecordSystem
    {
        public static void RegisterUIEvent(this DlgUnionDonationRecord self)
        {
            self.View.EG_UIUnionDonationRecordItemRectTransform.gameObject.SetActive(false);
            self.View.EG_UIUnionDonationRecordItemRectTransform.SetParent(self.View.uiTransform);

            self.View.E_ButtonCloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_UnionDonationRecord);
            });
            
            self.OnInitUI().Coroutine();
        }

        public static void ShowWindow(this DlgUnionDonationRecord self, Entity contextData = null)
        {
        }

        public static async ETTask OnInitUI(this DlgUnionDonationRecord self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long unionid = numericComponent.GetAsLong(NumericType.UnionId_0);
            long instanceId = self.InstanceId;
            U2C_UnionRecordResponse response = await UnionNetHelper.UnionRecordRequest(self.Root(), unionid);
            for (int i = 0; i < response.DonationRecords.Count; i++)
            {
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UIUnionDonationRecordItemRectTransform.gameObject);
                gameObject.SetActive(true);
                CommonViewHelper.SetParent(gameObject, self.View.EG_BuildingListRectTransform.gameObject);

                ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
                GameObject TextContent = rc.Get<GameObject>("TextContent");
                GameObject HeadIcon = rc.Get<GameObject>("HeadIcon");
                DonationRecord donationRecord = response.DonationRecords[i];
                DateTime dateTime = TimeInfo.Instance.ToDateTime(donationRecord.Time);
                using (zstring.Block())
                {
                    if (donationRecord.Gold > 0)
                    {
                        TextContent.GetComponent<Text>().text =
                                zstring.Format("玩家 <color=#{0}>{1}</color> {2} 捐献： <color=#{3}>{4}</color>金币",
                                    CommonHelp.QualityReturnColor(4), donationRecord.Name, dateTime.ToShortTimeString(),
                                    CommonHelp.QualityReturnColor(2), donationRecord.Gold);
                    }
                    else
                    {
                        TextContent.GetComponent<Text>().text =
                                zstring.Format("玩家 <color=#{0}>{1}</color> {2} 捐献： <color=#{3}>{4}</color>钻石",
                                    CommonHelp.QualityReturnColor(4), donationRecord.Name, dateTime.ToShortTimeString(),
                                    CommonHelp.QualityReturnColor(2), donationRecord.Diamond);
                    }
                }

                HeadIcon.GetComponent<Image>().sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, donationRecord.Occ.ToString()));
            }
        }
    }
}