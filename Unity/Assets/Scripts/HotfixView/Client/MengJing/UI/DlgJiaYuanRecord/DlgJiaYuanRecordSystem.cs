using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanRecord))]
    public static class DlgJiaYuanRecordSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanRecord self)
        {
            self.View.E_ImageCloseButton.AddListener(self.OnImageCloseButton);
            
            self.View.EG_UIJiaYuanRecordItemRectTransform.gameObject.SetActive(false);
            self.OnInitUI().Coroutine();
        }

        public static void ShowWindow(this DlgJiaYuanRecord self, Entity contextData = null)
        {
        }

        public static void OnImageCloseButton(this DlgJiaYuanRecord self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanRecord);
        }
        
        public static async ETTask OnInitUI(this DlgJiaYuanRecord self)
        {
            M2C_JiaYuanRecordListResponse response = await JiaYuanNetHelper.JiaYuanRecordListRequest(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            for (int i = 0; i < response.JiaYuanRecordList.Count; i++)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UIJiaYuanRecordItemRectTransform.gameObject);
                gameObject.SetActive(true);
                CommonViewHelper.SetParent(gameObject, self.View.EG_BuildingList2RectTransform.gameObject);
                JiaYuanRecord jiaYuanRecord = response.JiaYuanRecordList[i];
                string time = TimeInfo.Instance.ToDateTime(jiaYuanRecord.Time).ToString();
                time = time.Substring(5, time.Length - 5);
                Text Text = gameObject.transform.Find("Text").GetComponent<Text>();
                zstring tip = string.Empty;
                using (zstring.Block())
                {
                    tip = zstring.Format("{0} 玩家<color=#9CA606>{1}</color>", time, jiaYuanRecord.PlayerName);
                    switch (jiaYuanRecord.OperateType)
                    {
                        case JiaYuanOperateType.Visit:
                            tip += " 来到你的家园逛了一圈。";
                            break;
                        case JiaYuanOperateType.GatherPlant:
                            tip += zstring.Format(" 在你的家园拾取了<color=#9CA606> {0}</color>",
                                JiaYuanFarmConfigCategory.Instance.Get(jiaYuanRecord.OperateId).Name);
                            break;
                        case JiaYuanOperateType.GatherPasture:
                            tip += zstring.Format(" 在你的家园拾取了<color=#9CA606> {0}</color>",
                                JiaYuanPastureConfigCategory.Instance.Get(jiaYuanRecord.OperateId).Name);
                            break;
                        case JiaYuanOperateType.Pick:
                            tip += zstring.Format(" 在你的家园清理了<color=#9CA606> {0}</color>",
                                MonsterConfigCategory.Instance.Get(jiaYuanRecord.OperateId).MonsterName);
                            break;
                        default:
                            break;
                    }
                }

                Text.text = tip;
            }

            if (response.JiaYuanRecordList.Count > 6)
            {
                await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
                self.View.EG_BuildingList2RectTransform.localPosition = new Vector2(0, (response.JiaYuanRecordList.Count - 6) * 110);
            }
        }
    }
}
