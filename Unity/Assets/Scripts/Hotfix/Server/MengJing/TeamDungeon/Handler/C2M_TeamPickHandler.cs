﻿using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TeamPickHandlerr : MessageLocationHandler<Unit, C2M_TeamPickRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamPickRequest request)
        {
            TeamDungeonComponent teamDungeonComponent = unit.Scene().GetComponent<TeamDungeonComponent>();
            if (teamDungeonComponent == null)
            {
                return;
            }

            List<TeamDropItem> teamDropItems = teamDungeonComponent.TeamDropItems;
            TeamDropItem teamDropItem = null;
            for (int i = 0; i < teamDropItems.Count; i++)
            {
                if (teamDropItems[i].DropInfo.UnitId == request.DropItem)
                {
                    teamDropItem = teamDropItems[i];
                    break;
                }
            }

            if (teamDropItem == null)
            {
                return;
            }

            if (request.Need == 1 && !teamDropItem.NeedPlayers.Contains(unit.Id))
            {
                teamDropItem.NeedPlayers.Add(unit.Id);
            }

            if (request.Need == 2 && !teamDropItem.GivePlayers.Contains(unit.Id))
            {
                teamDropItem.GivePlayers.Add(unit.Id);
            }

            teamDungeonComponent.Check();
            await ETTask.CompletedTask;
        }
    }
}