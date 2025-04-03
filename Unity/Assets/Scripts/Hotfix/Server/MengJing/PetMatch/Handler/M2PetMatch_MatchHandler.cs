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

            //添加数据缓存
            soloSceneComponent.OnAddSoloDateList(request.SoloPlayerInfo.UnitId, request.SoloPlayerInfo.Name, request.SoloPlayerInfo.Occ);

            if (!soloSceneComponent.PlayerCombatList.ContainsKey(request.SoloPlayerInfo.UnitId))
            {
                soloSceneComponent.PlayerCombatList.Add(request.SoloPlayerInfo.UnitId, request.SoloPlayerInfo.Combat);
            }
            
            response.Error = soloSceneComponent.OnJoinMatch(request.SoloPlayerInfo);


            await ETTask.CompletedTask;
        }
    }
}
