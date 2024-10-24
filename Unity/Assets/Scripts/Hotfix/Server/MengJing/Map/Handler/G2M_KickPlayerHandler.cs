﻿using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class G2M_KickPlayerHandler : MessageHandler<Scene, G2M_KickPlayerRequest>
    {
        protected override async ETTask Run(Scene scene, G2M_KickPlayerRequest request)
        {
            Unit unit = scene.GetComponent<UnitComponent>().Get(request.UnitId);
            if (unit != null)
            {
                //MessageHelper.SendToClient(unit, new M2C_KickPlayerMessage());
                //await unit.RemoveLocation();
                //DBSaveComponent dBSaveComponent = unit.GetComponent<DBSaveComponent>();
                //if (dBSaveComponent != null)
                //{
                //    Console.WriteLine($"G2M_KickPlayerRequest: dBSaveComponent != null");
                //    dBSaveComponent.OnDisconnect();
                //}
                //else
                //{
                //    Console.WriteLine($"G2M_KickPlayerRequest: dBSaveComponent == null");
                //    unit.GetParent<UnitComponent>().Remove(unit.Id);
                //}
                //unit.OnKickPlayer(false).Coroutine();
            }
            else
            {
                //Console.WriteLine($"G2M_KickPlayerRequest ==null");
            }

            await ETTask.CompletedTask;
        }
    }
}
