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
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<BuffManagerComponentS>();
            unit.AddComponent<AttackRecordComponent>();
            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);
            unit.GetComponent<DBSaveComponent>().Activeted();

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.BattleCamp, CampEnum.CampPlayer_1, false);
            numericComponent.ApplyValue(NumericType.RunRaceTransform, 0, false);
            numericComponent.ApplyValue(NumericType.CardTransform, 0, false);
            
            Function_Fight.UnitUpdateProperty_Base(unit, false, false);

            switch (request.SceneType)
            {
                case SceneTypeEnum.CellDungeon:
                    int sonid = scene.GetComponent<CellDungeonComponent>().CurrentFubenCell.sonid;
                    ChapterSonConfig chapterSon = ChapterSonConfigCategory.Instance.Get(sonid);
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                    //更新unit坐标
                    unit.Position = new float3(chapterSon.BornPosLeft[0] * 0.01f, chapterSon.BornPosLeft[1] * 0.01f, chapterSon.BornPosLeft[2] * 0.01f);
                    unit.Rotation = quaternion.identity;
                    scene.GetComponent<CellDungeonComponent>().GenerateFubenScene(false);
                    TransferHelper.AfterTransfer(unit);
                    break;
                
                case SceneTypeEnum.MainCityScene:
                    unit.Position = new float3(-10, 0, -10);
                    unit.AddComponent<PathfindingComponent, int>(101);
                    unit.GetComponent<HeroDataComponentS>().OnReturn();
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
            M2C_StartSceneChange m2CStartSceneChange = new() { SceneInstanceId = scene.InstanceId, SceneId = request.SceneId, SceneType = request.SceneType, Difficulty = request.Difficulty, ParamInfo = request.ParamInfo };
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