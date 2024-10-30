using System.Collections.Generic;

namespace ET.Client
{
    public static class DuiHuaHelper
    {

        public static Unit GetCanNpcDialog(Scene root)
        {
            Unit npc = null;
            
            float distance = ConfigData.NpcDialogDistance;
            Unit main = UnitHelper.GetMyUnitFromClientScene(root);
            List<EntityRef<Unit>> units = root.CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.Type == UnitType.Npc || unit.IsChest())
                {
                    float t_distance = PositionHelper.Distance2D(main.Position, unit.Position);
                    if (t_distance < distance)
                    {
                        distance = t_distance;
                        npc = unit;
                    }
                }
            }

            return npc;
        }

        public static void MoveToNpcDialog(Scene root)
        {
            Unit npc = GetCanNpcDialog(root);
            if (npc == null)
            {
                return;
            }

            if (npc.Type == UnitType.Npc)
            {
                root.CurrentScene().GetComponent<OperaComponent>().OnClickNpc(npc.ConfigId).Coroutine();
            }

            if (npc.Type == UnitType.Monster)
            {
                root.CurrentScene().GetComponent<OperaComponent>().OnClickChest(npc.Id);
            }
        }
    }
}