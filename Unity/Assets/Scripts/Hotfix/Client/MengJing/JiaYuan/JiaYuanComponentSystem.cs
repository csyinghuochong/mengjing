namespace ET.Client
{
    [FriendOf(typeof (JiaYuanComponent))]
    [EntitySystemOf(typeof (JiaYuanComponent))]
    public static partial class JiaYuanComponentSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanComponent self)
        {
        }

        public static JiaYuanPet GetJiaYuanPet(this JiaYuanComponent self, long unitid)
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

        public static int GetPeopleNumber(this JiaYuanComponent self)
        {
            int number = 0;
            for (int i = 0; i < self.JiaYuanPastureList_7.Count; i++)
            {
                JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(self.JiaYuanPastureList_7[i].ConfigId);
                number += jiaYuanPastureConfig.PeopleNum;
            }

            return number;
        }

        public static int GetOpenPlanNumber(this JiaYuanComponent self)
        {
            return self.PlanOpenList_7.Count;
        }

        public static bool IsMyJiaYuan(this JiaYuanComponent self, long selfId)
        {
            return self.MasterId == selfId;
        }
    }
}