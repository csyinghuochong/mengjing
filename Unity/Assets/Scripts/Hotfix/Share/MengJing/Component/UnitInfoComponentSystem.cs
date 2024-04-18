using System.Collections.Generic;

namespace ET
{


    [EntitySystemOf(typeof(UnitInfoComponent))]
    [FriendOf(typeof(UnitInfoComponent))]
    public static partial class UnitInfoComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.UnitInfoComponent self)
        {

        }
        
        [EntitySystem]
        private static void Destroy(this ET.UnitInfoComponent self)
        {

        }

        public static List<long> GetZhaoHuanList(this ET.UnitInfoComponent self)
        {
            return self.ZhaohuanIds;
        }

        public static int GetZhaoHuanNumber(this UnitInfoComponent self, UnitComponent unitComponent)
        {
            int number = 0;
            for (int i = self.ZhaohuanIds.Count - 1; i >= 0; i--)
            {
                Unit zhaohuan = unitComponent.Get(self.ZhaohuanIds[i]);
                if (zhaohuan == null)
                {
                    continue;
                }
                number++;
            }
            return number;
        }
       
    }

}