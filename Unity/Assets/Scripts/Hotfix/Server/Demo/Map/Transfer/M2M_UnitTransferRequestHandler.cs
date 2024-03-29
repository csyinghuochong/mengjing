using System;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2M_UnitTransferRequestHandler: MessageHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            Log.Debug($"M2M_UnitTransferRequest:1");
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = MongoHelper.Deserialize<Unit>(request.Unit);

            unitComponent.AddChild(unit);
            unitComponent.Add(unit);

            foreach (byte[] bytes in request.Entitys)
            {
                try
                {
                    Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                    unit.AddComponent(entity);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            Log.Debug($"M2M_UnitTransferRequest:2");
            
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);
            unit.GetComponent<DBSaveComponent>().Activeted();
            switch (request.SceneType)
            {
                case SceneTypeEnum.MainCityScene:
                    unit.Position = new float3(-10, 0, -10);
                    unit.AddComponent<PathfindingComponent, int>(101);
                    break;
                case  SceneTypeEnum.LocalDungeon:
                    unit.Position = new float3(-0.72f, 0, -2.57f);
                    unit.AddComponent<PathfindingComponent, int>(10001);
                    scene.GetComponent<LocalDungeonComponent>().MainUnit = unit;
                    scene.GetComponent<LocalDungeonComponent>().GenerateFubenScene(request.SceneId);
                    break;
            }
            
            //TransferHelper.AfterTransfer();
            
            
            Log.Debug($"M2M_UnitTransferRequest:3");
            // 通知客户端开始切场景
            M2C_StartSceneChange m2CStartSceneChange = new() { SceneInstanceId = scene.InstanceId, SceneName = request.SceneId.ToString() };
            MapMessageHelper.SendToClient(unit, m2CStartSceneChange);

            Log.Debug($"M2M_UnitTransferRequest:4");
            
            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = new();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MapMessageHelper.SendToClient(unit, m2CCreateUnits);
            Log.Debug($"M2M_UnitTransferRequest:5");
            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}