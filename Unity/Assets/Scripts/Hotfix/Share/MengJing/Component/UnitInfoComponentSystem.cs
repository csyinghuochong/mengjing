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


        public  static List<long> GetZhaoHuanList(this ET.UnitInfoComponent self)
        {
            return self.ZhaohuanIds;

        }
    }

}