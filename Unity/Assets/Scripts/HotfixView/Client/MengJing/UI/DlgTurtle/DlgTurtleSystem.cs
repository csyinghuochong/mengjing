using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgTurtle))]
    public static class DlgTurtleSystem
    {
        public static void RegisterUIEvent(this DlgTurtle self)
        {
            self.View.E_Btn1Button.AddListener(() => self.OnTurtleBtn(20099011).Coroutine());
            self.View.E_Btn2Button.AddListener(() => self.OnTurtleBtn(20099012).Coroutine());
            self.View.E_Btn3Button.AddListener(() => self.OnTurtleBtn(20099013).Coroutine());
            
            self.EndTime = FunctionHelp.GetCloseTime(1057);
            self.InitModel();
            self.InitInfo().Coroutine();
            self.ShowTime().Coroutine();
            self.ShowRewards();
        }

        public static void ShowWindow(this DlgTurtle self, Entity contextData = null)
        {
        }

        public static void InitModel(this DlgTurtle self)
        {
            self.View.ES_ModelShow1.ShowOtherModel("NPC/" + NpcConfigCategory.Instance.Get(20099008).Asset).Coroutine();
            self.View.ES_ModelShow1.SetCameraPosition(new Vector3(0f, 100f, 450f));
            self.View.ES_ModelShow1.Camera.fieldOfView = 30;
            // self.View.ES_ModelShow1.SetRootPosition(new Vector2(1000 + 1000, 0));
            self.View.ES_ModelShow1.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            self.View.ES_ModelShow2.ShowOtherModel("NPC/" + NpcConfigCategory.Instance.Get(20099009).Asset).Coroutine();
            self.View.ES_ModelShow2.SetCameraPosition(new Vector3(0f, 100f, 450f));
            self.View.ES_ModelShow2.Camera.fieldOfView = 30;
            // self.View.ES_ModelShow2.SetRootPosition(new Vector2(1000 + 1000, 0));
            self.View.ES_ModelShow2.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            self.View.ES_ModelShow3.ShowOtherModel("NPC/" + NpcConfigCategory.Instance.Get(20099010).Asset).Coroutine();
            self.View.ES_ModelShow3.SetCameraPosition(new Vector3(0f, 100f, 450f));
            self.View.ES_ModelShow3.Camera.fieldOfView = 30;
            // self.View.ES_ModelShow3.SetRootPosition(new Vector2(1000 + 1000, 0));
            self.View.ES_ModelShow3.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));
        }

        public static async ETTask OnTurtleBtn(this DlgTurtle self, int supportId)
        {
            if (self.SupportId != 0 || !(supportId == 20099011 || supportId == 20099012 || supportId == 20099013))
            {
                FlyTipComponent.Instance.ShowFlyTip("已有支持的小龟!");
                return;
            }

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), $"小龟大赛", zstring.Format("是否消耗{0}金币支持该小龟?", GlobalValueConfigCategory.Instance.Get(98).Value),
                    async () =>
                    {
                        int error = await ActivityNetHelper.TurtleSupportRequest(self.Root(), supportId);
                        if (error != ErrorCode.ERR_Success)
                        {
                            return;
                        }

                        if (supportId == 20099011)
                        {
                            self.View.E_BtnText1Text.text = "竞猜小龟";
                        }
                        else if (supportId == 20099012)
                        {
                            self.View.E_BtnText2Text.text = "竞猜小龟";
                        }
                        else if (supportId == 20099013)
                        {
                            self.View.E_BtnText3Text.text = "竞猜小龟";
                        }

                        self.SupportId = supportId;
                        await self.InitInfo();
                    }).Coroutine();
            }

            await ETTask.CompletedTask;
        }

        public static void ShowRewards(this DlgTurtle self)
        {
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(97);
            self.View.ES_RewardList.Refresh(globalValueConfig.Value, 0.9f);
        }

        public static async ETTask InitInfo(this DlgTurtle self)
        {
            M2C_TurtleRecordResponse response = await ActivityNetHelper.TurtleRecordRequest(self.Root());
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.SupportId = response.SupportId;

            using (zstring.Block())
            {
                self.View.E_WinNumText1Text.text = zstring.Format("获胜次数:{0}", response.WinTimes[0]);
                self.View.E_WinNumText2Text.text = zstring.Format("获胜次数:{0}", response.WinTimes[1]);
                self.View.E_WinNumText3Text.text = zstring.Format("获胜次数:{0}", response.WinTimes[2]);

                self.View.E_SupportNumText1Text.text = zstring.Format("本次支持数:{0}", response.SupportTimes[0]);
                self.View.E_SupportNumText2Text.text = zstring.Format("本次支持数:{0}", response.SupportTimes[1]);
                self.View.E_SupportNumText2Text.text = zstring.Format("本次支持数:{0}", response.SupportTimes[2]);
            }

            if (response.SupportId == 20099011)
            {
                self.View.E_BtnText1Text.text = "竞猜小龟";
            }
            else if (response.SupportId == 20099012)
            {
                self.View.E_BtnText2Text.text = "竞猜小龟";
            }
            else if (response.SupportId == 20099013)
            {
                self.View.E_BtnText3Text.text = "竞猜小龟";
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask ShowTime(this DlgTurtle self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
                long endTime = self.EndTime - curTime;
                if (endTime > 0)
                {
                    using (zstring.Block())
                    {
                        self.View.E_TimeTextText.text = zstring.Format("活动开启倒计时 {0}分{1}秒", endTime / 60, endTime % 60);
                    }
                }
                else
                {
                    self.View.E_TimeTextText.text = "活动开始!!!";
                }

                await timerComponent.WaitAsync(1000);

                if (self.IsDisposed)
                {
                    break;
                }
            }
        }
    }
}