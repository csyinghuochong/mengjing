namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemIncreaseTransferHandler: MessageLocationHandler<Unit, C2M_ItemIncreaseTransferRequest, M2C_ItemIncreaseTransferResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemIncreaseTransferRequest request, M2C_ItemIncreaseTransferResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}