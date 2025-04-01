using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(EnergyComponentS))]
    [FriendOf(typeof(EnergyComponentS))]
    public static partial class EnergyComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this EnergyComponentS self)
        {

        }
        [EntitySystem]
        private static void Destroy(this EnergyComponentS self)
        {

        }

        public static void OnDisconnect(this EnergyComponentS self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            int huor = dateTime.Hour;
            if (huor < 6)
            {
                self.EarlySleepReward = false;
            }
        }

        public static void OnResetEnergyInfo(this EnergyComponentS self)
        {
            self.QuestionIndex = 0;

            DateTime dateTime = TimeHelper.DateTimeNow();
            int huor = dateTime.Hour;
            self.EarlySleepReward = huor >= 6;

            //领取记录
            for (int i = 0; i < self.GetRewards.Count; i++)
            {
                self.GetRewards[i] = 0;
            }

            //答题列表
            self.QuestionList.Clear();
            List<QuestionBankConfig> questionBankConfigs = QuestionBankConfigCategory.Instance.GetAll().Values.ToList();
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(12);
            int questionNumber = int.Parse(globalValueConfig.Value);
            int startIndex = RandomHelper.RandomNumber(0, questionBankConfigs.Count - questionNumber);
            for (int i = startIndex; i < startIndex + questionNumber; i++)
            {
                self.QuestionList.Add(questionBankConfigs[i].Id);
            }
        }

        public static void OnZeroClockUpdate(this EnergyComponentS self)
        {
            self.EarlySleepReward = false;

            for (int i = 0; i < self.GetRewards.Count; i++)
            {
                self.GetRewards[i] = 0;
            }
        }
        [EntitySystem]
        private static void Deserialize(this ET.Server.EnergyComponentS self)
        {

        }
    }

}