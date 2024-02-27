namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemInheritSelectHandler: MessageLocationHandler<Unit, C2M_ItemInheritSelectRequest, M2C_ItemInheritSelectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemInheritSelectRequest request, M2C_ItemInheritSelectResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}