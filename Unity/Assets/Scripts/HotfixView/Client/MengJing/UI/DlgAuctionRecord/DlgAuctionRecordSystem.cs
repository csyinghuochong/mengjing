using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgAuctionRecord))]
    public static class DlgAuctionRecordSystem
    {
        public static void RegisterUIEvent(this DlgAuctionRecord self)
        {
            self.View.E_ButtonCloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_AuctionRecord);
            });
            
            self.View.EG_UIAuctionRecordItemRectTransform.gameObject.SetActive(false);

            self.OnInitUI().Coroutine();
        }

        public static void ShowWindow(this DlgAuctionRecord self, Entity contextData = null)
        {
        }

        public static async ETTask OnInitUI(this DlgAuctionRecord self)
        {
            P2C_PaiMaiAuctionRecordResponse response = await PaiMaiNetHelper.PaiMaiAuctionRecord(self.Root());

            long instanceid = self.InstanceId;
            if (instanceid != self.InstanceId)
            {
                return;
            }

            for (int i = 0; i < response.RecordList.Count; i++)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UIAuctionRecordItemRectTransform.gameObject);
                gameObject.SetActive(true);
                CommonViewHelper.SetParent(gameObject, self.View.EG_BuildingListRectTransform.gameObject);
                ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
                DateTime dateTime = TimeInfo.Instance.ToDateTime(response.RecordList[i].Time);
                using (zstring.Block())
                {
                    rc.Get<GameObject>("TextContent").GetComponent<Text>().text =
                            zstring.Format("玩家 <color=#{0}>{1}</color> {2} 出价： <color=#{3}>{4}</color>", CommonHelp.QualityReturnColor(4),
                                response.RecordList[i].PlayerName, dateTime.ToShortTimeString(), CommonHelp.QualityReturnColor(2),
                                response.RecordList[i].Price);
                }
            }
        }
    }
}