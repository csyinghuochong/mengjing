using System;

namespace ET.Server
{

    [MessageHandler(SceneType.PetMatch)]
    public class M2PetMatch_MatchHandler : MessageHandler<Scene, M2PetMatch_MatchRequest, PetMatch2M_MatchResponse>
    {
        protected override async ETTask Run(Scene scene, M2PetMatch_MatchRequest request, PetMatch2M_MatchResponse response)
        {
            //收到匹配服务器发来的消息进行匹配处理
            
            //给当前solo场景加入匹配的玩家
            PetMatchSceneComponent soloSceneComponent = scene.GetComponent<PetMatchSceneComponent>();

            if (!soloSceneComponent.PetMatchOpen)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }

            //添加数据缓存
            response.Error =  soloSceneComponent.OnAddSoloDateList(request.SoloPlayerInfo);

            Console.WriteLine($"M2PetMatch_MatchHandler:  {request.SoloPlayerInfo.UnitId}  {soloSceneComponent.MatchList.Count}");
            
            await ETTask.CompletedTask;
        }
    }
}
