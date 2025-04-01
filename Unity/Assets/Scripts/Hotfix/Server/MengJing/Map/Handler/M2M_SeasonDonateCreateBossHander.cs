

using System;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class M2M_SeasonDonateCreateBossHander : MessageHandler<Scene, M2M_SeasonDonateCreateBossRequest, M2M_SeasonDonateCreateBossResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_SeasonDonateCreateBossRequest request, M2M_SeasonDonateCreateBossResponse response)
        {
            Console.WriteLine($"M2M_SeasonDonateCreateBossRequest:  {scene.Name}");

            int bosslv = request.SeasonBossLevel;
           
            UnitFactory.CreateMonster(scene, ConfigData.CommonSeasonBossList[bosslv].KeyId, float3.zero,  new CreateMonsterInfo());
            
            await ETTask.CompletedTask;
        }
    }
}
