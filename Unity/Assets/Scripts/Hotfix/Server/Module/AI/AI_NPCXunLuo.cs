namespace ET.Server
{


    public class AI_NPCXunLuo : AAIHandler
    {

        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            while (true)
            {
                await  aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(5000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}
