namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemEquipIndexHandler: MessageLocationHandler<Unit, C2M_ItemEquipIndexRequest, M2C_ItemEquipIndexResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemEquipIndexRequest request, M2C_ItemEquipIndexResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}