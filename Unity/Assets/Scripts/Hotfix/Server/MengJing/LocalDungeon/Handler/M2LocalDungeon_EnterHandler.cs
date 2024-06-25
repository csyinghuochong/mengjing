using System;

namespace ET.Server
{
    
    [MessageHandler(SceneType.LocalDungeon)]
    public class M2LocalDungeon_EnterHandler: MessageHandler<Scene, M2LocalDungeon_EnterRequest, LocalDungeon2M_EnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2LocalDungeon_EnterRequest request, LocalDungeon2M_EnterResponse response)
        {
            Log.Debug("M2LocalDungeon_EnterRequest_a");

             switch (request.SceneType)
             {
                 case SceneTypeEnum.LocalDungeon:
                     long fubenid = IdGenerater.Instance.GenerateId();
                     long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                     Scene fubnescene =  GateMapFactory.Create(scene.Root(), fubenid, fubenInstanceId, "LocalDungeon" + fubenid.ToString());
                     //fubnescene.AddComponent<YeWaiRefreshComponent>();
                     LocalDungeonComponent localDungeon = fubnescene.AddComponent<LocalDungeonComponent>();
                     localDungeon.FubenDifficulty = request.Difficulty;
                     MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
                     mapComponent.SetMapInfo((int)SceneTypeEnum.LocalDungeon, request.SceneId, 0);
                     mapComponent.NavMeshId = DungeonConfigCategory.Instance.Get(request.SceneId).MapID;
                     response.FubenInstanceId = fubenInstanceId;
                     response.RootId = scene.Fiber().Id;
                     response.Process = scene.Fiber().Process;
                     TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                     break;
                 case SceneTypeEnum.Battle:
                    
                     break;
             }
            
            await ETTask.CompletedTask;
        }
    }
    
    
}