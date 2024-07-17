
using Unity.Mathematics;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_CreateSpilingHandler : MessageLocationHandler<Unit, C2M_CreateSpiling>
    {
        protected override async ETTask Run(Unit entity, C2M_CreateSpiling message)
        {
            Unit unit = UnitFactory.CreateMonster(entity.Scene(), 70001960, float3.zero, new CreateMonsterInfo() 
            {
                Camp =CampEnum.CampMonster1
            });

            await ETTask.CompletedTask;
        }
    }
}
