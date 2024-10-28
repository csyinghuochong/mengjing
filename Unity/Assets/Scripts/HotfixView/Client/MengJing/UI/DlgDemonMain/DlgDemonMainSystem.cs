using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgDemonMainViewComponent))]
    [FriendOf(typeof(DlgDemonMain))]
    public static class DlgDemonMainSystem
    {
        public static void RegisterUIEvent(this DlgDemonMain self)
        {
            self.Rankings.Add(self.View.EG_PlayerInfoItem_1RectTransform.gameObject);
            self.Rankings.Add(self.View.EG_PlayerInfoItem_2RectTransform.gameObject);
            self.Rankings.Add(self.View.EG_PlayerInfoItem_3RectTransform.gameObject);
            self.Rankings.Add(self.View.EG_PlayerInfoItem_OtherRectTransform.gameObject);

            self.View.EG_PlayerInfoItem_1RectTransform.gameObject.SetActive(false);
            self.View.EG_PlayerInfoItem_2RectTransform.gameObject.SetActive(false);
            self.View.EG_PlayerInfoItem_3RectTransform.gameObject.SetActive(false);
            self.View.EG_PlayerInfoItem_OtherRectTransform.gameObject.SetActive(false);

            FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(1059);
            string[] openTimes = funtionConfig.OpenTime.Split('@');
            self.ReadyTime = (int.Parse(openTimes[1].Split(';')[0]) * 60 + int.Parse(openTimes[1].Split(';')[1])) * 60;
            self.EndTime = (int.Parse(openTimes[2].Split(';')[0]) * 60 + int.Parse(openTimes[2].Split(';')[1])) * 60;
            
            self.UpdateRanking().Coroutine();
            self.ShoweTime().Coroutine();
        }

        public static void ShowWindow(this DlgDemonMain self, Entity contextData = null)
        {
        }

        public static async ETTask ShoweTime(this DlgDemonMain self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
                long endTime = self.EndTime - curTime;

                long readyTime = self.ReadyTime - curTime;
                using (zstring.Block())
                {
                    if (readyTime > 0)
                    {
                        self.View.E_ReadyTimeTextText.text = zstring.Format("准备倒计时 {0}:{1}", readyTime / 60, readyTime % 60);
                    }
                    else if (endTime > 0)
                    {
                        self.View.E_ReadyTimeTextText.text = zstring.Format("活动结束倒计时 {0}:{1}", endTime / 60, endTime % 60);
                    }
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static async ETTask UpdateRanking(this DlgDemonMain self)
        {
            long instacnid = self.InstanceId;
            R2C_RankDemonResponse response = await ActivityNetHelper.RankDemonRequest(self.Root());

            if (instacnid != self.InstanceId)
            {
                return;
            }

            self.View.uiTransform.SetAsFirstSibling();

            if (response.RankList == null || response.RankList.Count < 1)
            {
                return;
            }

            int num = 0;
            for (int i = 0; i < response.RankList.Count; i++)
            {
                if (i == 0)
                {
                    using (zstring.Block())
                    {
                        self.View.EG_PlayerInfoItem_1RectTransform.GetComponentInChildren<Text>().text =
                                zstring.Format("第{0}名 {1}", i + 1, response.RankList[i].PlayerName);
                    }

                    self.View.EG_PlayerInfoItem_1RectTransform.gameObject.SetActive(true);
                }
                else if (i == 1)
                {
                    using (zstring.Block())
                    {
                        self.View.EG_PlayerInfoItem_2RectTransform.GetComponentInChildren<Text>().text =
                                zstring.Format("第{0}名 {1}", i + 1, response.RankList[i].PlayerName);
                    }

                    self.View.EG_PlayerInfoItem_2RectTransform.gameObject.SetActive(true);
                }
                else if (i == 2)
                {
                    using (zstring.Block())
                    {
                        self.View.EG_PlayerInfoItem_3RectTransform.GetComponentInChildren<Text>().text =
                                zstring.Format("第{0}名 {1}", i + 1, response.RankList[i].PlayerName);
                    }

                    self.View.EG_PlayerInfoItem_3RectTransform.gameObject.SetActive(true);
                }
                else
                {
                    if (num < self.Rankings.Count)
                    {
                        self.Rankings[i].SetActive(true);
                        using (zstring.Block())
                        {
                            self.Rankings[i].GetComponentInChildren<Text>().text =
                                    zstring.Format("第{0}名 {1}", i + 1, response.RankList[i].PlayerName);
                        }
                    }
                    else
                    {
                        GameObject go = UnityEngine.Object.Instantiate(self.View.EG_PlayerInfoItem_OtherRectTransform.gameObject);
                        using (zstring.Block())
                        {
                            go.GetComponentInChildren<Text>().text = zstring.Format("第{0}名 {1}", i + 1, response.RankList[i].PlayerName);
                        }

                        go.SetActive(true);
                        CommonViewHelper.SetParent(go, self.View.EG_RankingListNodeRectTransform.gameObject);
                        self.Rankings.Add(go);
                    }
                }

                num++;
            }

            for (int i = num; i < self.Rankings.Count; i++)
            {
                self.Rankings[i].SetActive(false);
            }

            await ETTask.CompletedTask;
        }

        public static void UpdateRanking(this DlgDemonMain self, M2C_RankDemonMessage message)
        {
            int num = 0;
            for (int i = 0; i < message.RankList.Count; i++)
            {
                if (i == 0)
                {
                    using (zstring.Block())
                    {
                        self.View.EG_PlayerInfoItem_1RectTransform.GetComponentInChildren<Text>().text =
                                zstring.Format("第{0}名 {1}", i + 1, message.RankList[i].PlayerName);
                    }

                    self.View.EG_PlayerInfoItem_1RectTransform.gameObject.SetActive(true);
                }
                else if (i == 1)
                {
                    using (zstring.Block())
                    {
                        self.View.EG_PlayerInfoItem_2RectTransform.GetComponentInChildren<Text>().text =
                                zstring.Format("第{0}名 {1}", i + 1, message.RankList[i].PlayerName);
                    }

                    self.View.EG_PlayerInfoItem_2RectTransform.gameObject.SetActive(true);
                }
                else if (i == 2)
                {
                    using (zstring.Block())
                    {
                        self.View.EG_PlayerInfoItem_3RectTransform.GetComponentInChildren<Text>().text =
                                zstring.Format("第{0}名 {1}", i + 1, message.RankList[i].PlayerName);
                    }

                    self.View.EG_PlayerInfoItem_3RectTransform.gameObject.SetActive(true);
                }
                else
                {
                    if (num < self.Rankings.Count)
                    {
                        self.Rankings[i].SetActive(true);
                        using (zstring.Block())
                        {
                            self.Rankings[i].GetComponentInChildren<Text>().text =
                                    zstring.Format("第{0}名 {1}", i + 1, message.RankList[i].PlayerName);
                        }
                    }
                    else
                    {
                        GameObject go = GameObject.Instantiate(self.View.EG_PlayerInfoItem_OtherRectTransform.gameObject);
                        using (zstring.Block())
                        {
                            go.GetComponentInChildren<Text>().text = zstring.Format("第{0}名 {1}", i + 1, message.RankList[i].PlayerName);
                        }

                        go.SetActive(true);
                        CommonViewHelper.SetParent(go, self.View.EG_RankingListNodeRectTransform.gameObject);
                        self.Rankings.Add(go);
                    }
                }

                num++;
            }

            for (int i = num; i < self.Rankings.Count; i++)
            {
                self.Rankings[i].SetActive(false);
            }
        }
    }
}
