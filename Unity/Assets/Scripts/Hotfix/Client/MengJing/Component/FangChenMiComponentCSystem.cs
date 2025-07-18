using System;
using System.Collections.Generic;
using ET.Client;

namespace ET.Client
{
    [FriendOf(typeof(PlayerInfoComponent))]
    [FriendOf(typeof(FangChenMiComponentC))]
    [EntitySystemOf(typeof(FangChenMiComponentC))]
    public static partial class FangChenMiComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this FangChenMiComponentC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this FangChenMiComponentC self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static async ETTask OnLoginOut(this FangChenMiComponentC self)
        {
            EventSystem.Instance.Publish(self.Root(), new CommonPopup() { HintText = "防沉迷提示:当前可游玩时间结束，请安心休息吧！将立即退出游戏。" });

            await self.Root().GetComponent<TimerComponent>().WaitAsync(10000);

            EventSystem.Instance.Publish(self.Root(), new ReturnLogin());
        }
        
        public static async ETTask OnLogin(this FangChenMiComponentC self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            bool jiari = await HttpHelper.IsHolidayByDate(dateTime);
            int huor = dateTime.Hour;
            int minute = dateTime.Minute;
            if (self.GetPlayerAge() >= 18)
            {
                return;
            }

            if (!jiari && huor != 20)
            {
                self.OnLoginOut().Coroutine();
            }
            else
            {
                int leftTime = (60 - minute) * 60 - dateTime.Second;
                long instanceid = self.InstanceId;
                await self.Root().GetComponent<TimerComponent>().WaitAsync(leftTime * 1000);
                if (instanceid != self.InstanceId)
                {
                    return;
                }

                self.OnLoginOut().Coroutine();
            }
        }

        /// <summary>
        /// 是否未成年
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetPlayerAge(this FangChenMiComponentC self)
        {
            PlayerInfoComponent accountInfoInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            return IDCardHelper.GetBirthdayAgeSex(accountInfoInfoComponent.PlayerInfo.IdCardNo, accountInfoInfoComponent.Age_Type);
        }

        public static int GetMouthTotal(this FangChenMiComponentC self)
        {
            int total = 0;
            DateTime dateTime = TimeHelper.DateTimeNow();
            int monsth = dateTime.Month;

            List<RechargeInfo> rechargeInfos = self.Root().GetComponent<PlayerInfoComponent>().PlayerInfo.RechargeInfos;
            for (int i = 0; i < rechargeInfos.Count; i++)
            {
                dateTime = TimeInfo.Instance.ToDateTime(rechargeInfos[i].Time);
                if (monsth == dateTime.Month)
                {
                    total += rechargeInfos[i].Amount;
                }
            }

            return total;
        }
        
        public static int GetToDayNum(this FangChenMiComponentC self)
        {
            int total = 0;
            DateTime dateTime = TimeHelper.DateTimeNow();
            int monsth = dateTime.Month;
            int day = dateTime.Day;

            List<RechargeInfo> rechargeInfos = self.Root().GetComponent<PlayerInfoComponent>().PlayerInfo.RechargeInfos;
            for (int i = 0; i < rechargeInfos.Count; i++)
            {
                dateTime = TimeInfo.Instance.ToDateTime(rechargeInfos[i].Time);
                if (monsth == dateTime.Month && day == dateTime.Day)
                {
                    total += 1;
                }
            }

            return total;
        }

        public static int CanRechage(this FangChenMiComponentC self, int number)
        {
            int age = self.GetPlayerAge();
            if (age < 8)
            {
                return ErrorCode.ERR_FangChengMi_Tip3;
            }

            if (age < 16)
            {
                if (number > 50)
                {
                    return ErrorCode.ERR_FangChengMi_Tip4;
                }

                if (number + self.GetMouthTotal() > 200)
                {
                    return ErrorCode.ERR_FangChengMi_Tip4;
                }
            }

            if (age < 18)
            {
                if (number > 100)
                {
                    return ErrorCode.ERR_FangChengMi_Tip5;
                }

                if (number + self.GetMouthTotal() > 400)
                {
                    return ErrorCode.ERR_FangChengMi_Tip5;
                }
            }

            return ErrorCode.ERR_Success;
        }
    }
}
