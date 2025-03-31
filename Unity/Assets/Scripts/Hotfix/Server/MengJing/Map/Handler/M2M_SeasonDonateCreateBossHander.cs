

using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class M2M_SeasonDonateCreateBossHander : MessageHandler<Scene, M2M_SeasonDonateCreateBossRequest, M2M_SeasonDonateCreateResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_SeasonDonateCreateBossRequest request, M2M_SeasonDonateCreateResponse response)
        {
            Console.WriteLine($"M2M_SeasonDonateCreateBossRequest:  {scene.Name}");
            
            await ETTask.CompletedTask;
        }
    }
}
