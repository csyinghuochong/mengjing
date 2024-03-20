namespace ET.Server
{
    public class AI_Attack: AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            long sec = TimeInfo.Instance.ClientNow() / 1000 % 15;
            if (sec >= 10)
            {
                return 0;
            }
            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Fiber fiber = aiComponent.Fiber();

            Unit myUnit = null;//UnitHelper.GetMyUnitFromClientScene(fiber.Root);
            if (myUnit == null)
            {
                return;
            }

            // 停在当前位置
            //fiber.Root.GetComponent<ClientSenderCompnent>().Send(new C2M_Stop());

            await ETTask.CompletedTask;
        }
    }
}