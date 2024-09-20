using Unity.Mathematics;

namespace ET.Server
{
    
    public class TuoGuan_ZhuiJi :AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            await ETTask.CompletedTask;
        }
    }
}