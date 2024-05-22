using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2M_UnionTransferHandler : MessageHandler<Unit, M2M_UnionTransferMessage>
    {
        protected override async ETTask Run(Unit unit, M2M_UnionTransferMessage message)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue( NumericType.UnionLeader, message.UnionLeader, true );
            await ETTask.CompletedTask;
        }
    }
}
