using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Client
{
    public static class DuiHuaHelper
    {
        public static void MoveToNpcDialog(Scene root)
        {
            float distance = 20f;
            Unit npc = null;
            Unit main = UnitHelper.GetMyUnitFromClientScene(root);
            List<Unit> units = root.CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Type == UnitType.Npc || units[i].IsChest())
                {
                    float t_distance = PositionHelper.Distance2D(main.Position, units[i].Position);
                    if (t_distance < distance)
                    {
                        distance = t_distance;
                        npc = units[i];
                    }
                }
            }

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