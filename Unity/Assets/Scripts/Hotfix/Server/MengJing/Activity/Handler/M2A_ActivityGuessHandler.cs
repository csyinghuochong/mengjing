using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_ActivityGuessHandler : MessageHandler<Scene, M2A_ActivityGuessRequest, A2M_ActivityGuessResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_ActivityGuessRequest request, A2M_ActivityGuessResponse response)
        {
            Dictionary<int, List<long>> guessplayers = scene.GetComponent<ActivitySceneComponent>().DBDayActivityInfo.GuessPlayerList;

            if (!guessplayers.ContainsKey(request.GuessId))
            {
                guessplayers.Add(request.GuessId, new List<long>());
            }

            if (!guessplayers[request.GuessId].Contains(request.UnitId))
            {
                guessplayers[request.GuessId].Add(request.UnitId);
            }
            await ETTask.CompletedTask;
        }
    }
}
