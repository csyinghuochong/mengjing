
namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TalentActiveHandler : MessageLocationHandler<Unit, C2M_TalentActiveRequest, M2C_TalentActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TalentActiveRequest request, M2C_TalentActiveResponse response)
        {
            
            await ETTask.CompletedTask;
        }
    }
}