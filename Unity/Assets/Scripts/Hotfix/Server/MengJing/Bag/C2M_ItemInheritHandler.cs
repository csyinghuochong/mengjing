namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemInheritHandler: MessageLocationHandler<Unit, C2M_ItemInheritRequest, M2C_ItemInheritResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemInheritRequest request, M2C_ItemInheritResponse response)
        {


            await ETTask.CompletedTask;
        }
    }
}