namespace ET.Client
{
    [FriendOf(typeof (JiaYuanComponentC))]
    [EntitySystemOf(typeof (JiaYuanComponentC))]
    public static partial class JiaYuanComponentSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanComponentC self)
        {
        }

        public static JiaYuanPet GetJiaYuanPet(this JiaYuanComponentC self, long unitid)
        {
            for (int i = 0; i < self.JiaYuanPetList_2.Count; i++)
            {
                if (self.JiaYuanPetList_2[i].unitId == unitid)
                {
                    return self.JiaYuanPetList_2[i];
                }
            }

            return null;
        }

        public static int GetPeopleNumber(this JiaYuanComponentC self)
        {
            int number = 0;
            for (int i = 0; i < self.JiaYuanPastureList_7.Count; i++)
            {
                JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(self.JiaYuanPastureList_7[i].ConfigId);
                number += jiaYuanPastureConfig.PeopleNum;
            }

            return number;
        }

        public static int GetOpenPlanNumber(this JiaYuanComponentC self)
        {
            return self.PlanOpenList_7.Count;
        }

        public static bool IsMyJiaYuan(this JiaYuanComponentC self, long selfId)
        {
            return self.MasterId == selfId;
        }

        public static KeyValuePair GetDaShiProInfo(this JiaYuanComponentC self, int keyid)
        {
            for (int i = 0; i < self.JiaYuanProList_7.Count; i++)
            {
                if (self.JiaYuanProList_7[i].KeyId == keyid)
                {
                    return self.JiaYuanProList_7[i];
                }
            }

            return null;
        }
    }
}