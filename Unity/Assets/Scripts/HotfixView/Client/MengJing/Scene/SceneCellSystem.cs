using System.Collections.Generic;
using System.Text;

namespace ET.Client
{


    [EntitySystemOf(typeof(SceneCell))]
    [FriendOf(typeof(SceneCell))]
    public static partial class SceneCellSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.SceneCell self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.SceneCell self)
        {
            self.AOIUnits.Clear();

            self.SubsEnterEntities.Clear();

            self.SubsLeaveEntities.Clear();
        }
        
        public static void Add(this SceneCell self, SceneAOIEntity aoiEntity)
        {
            self.AOIUnits.Add(aoiEntity.Id, aoiEntity);
        }
        
        public static void Remove(this SceneCell self, SceneAOIEntity aoiEntity)
        {
            self.AOIUnits.Remove(aoiEntity.Id);
        }

        public static string CellIdToString(this long cellId)
        {
            int y = (int)(cellId & 0xffffffff);
            int x = (int)((ulong)cellId >> 32);
            return $"{x}:{y}";
        }

        public static string CellIdToString(this HashSet<long> cellIds)
        {
            StringBuilder sb = new StringBuilder();
            foreach (long cellId in cellIds)
            {
                sb.Append(cellId.CellIdToString());
                sb.Append(",");
            }

            return sb.ToString();
        }

    }
}