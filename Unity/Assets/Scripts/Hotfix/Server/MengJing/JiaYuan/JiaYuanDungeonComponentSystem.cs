using Unity.Mathematics;

namespace ET.Server
{



    [EntitySystemOf(typeof(JiaYuanDungeonComponent))]
    [FriendOf(typeof(JiaYuanDungeonComponent))]
    public static partial class JiaYuanDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.JiaYuanDungeonComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.JiaYuanDungeonComponent self)
        {

        }
        
        public static async ETTask CreateJiaYuanUnit(this JiaYuanDungeonComponent self,  long masterid, long unitid)
        {
            JiaYuanComponentS jiaYuanComponent = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(self.Root(), masterid);
            if (jiaYuanComponent.JiaYuanPastureList_7.Count > 100
                || jiaYuanComponent.JianYuanPlantList_7.Count > 100
                || jiaYuanComponent.JiaYuanMonster_2.Count > 100)
            {
                Log.Error($"CreateJiaYuanUnit:  {masterid}");
                return;
            }

            for (int i = 0; i < jiaYuanComponent.JiaYuanPastureList_7.Count; i++)
            {
                UnitFactory.CreatePasture(self.Scene(), jiaYuanComponent.JiaYuanPastureList_7[i], masterid);
            }

            for (int i = 0; i < jiaYuanComponent.JianYuanPlantList_7.Count; i++)
            {
                UnitFactory.CreatePlan(self.Scene(), jiaYuanComponent.JianYuanPlantList_7[i], masterid);
            }

            long serverTime = TimeHelper.ServerNow();
            for (int i = 0; i < jiaYuanComponent.JiaYuanMonster_2.Count; i++)
            {
                JiaYuanMonster keyValuePair = jiaYuanComponent.JiaYuanMonster_2[i];
                float3 vector3 = new float3(keyValuePair.x, keyValuePair.y, keyValuePair.z);
                UnitFactory.CreateMonster(self.Scene(), keyValuePair.ConfigId, vector3,
                    new CreateMonsterInfo()
                    {
                        Camp = CampEnum.CampMonster1, BornTime = serverTime - keyValuePair.BornTime, UnitId = keyValuePair.unitId
                    });
            }

            for (int i = 0; i < jiaYuanComponent.JiaYuanPetList_2.Count; i++)
            {
                UnitFactory.CreateJiaYuanPet(self.Scene(), masterid, jiaYuanComponent.JiaYuanPetList_2[i]);
            }
        }

    }

}