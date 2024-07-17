namespace ET.Server
{

    public class AI_Transfer : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return (aiComponent.TargetPoint.Count > 0) ? 1 : 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            await ETTask.CompletedTask;
            Unit unit = aiComponent.GetParent<Unit>();
            unit.Stop(0);
            unit.SetBornPosition(unit.Position, true);
            aiComponent.IsRetreat = false;
            aiComponent.AIConfigId = int.Parse(aiConfig.NodeParams);
        }
    }
}
