namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ReddotReadHandler : MessageLocationHandler<Unit, C2M_ReddotReadRequest, M2C_ReddotReadResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ReddotReadRequest request, M2C_ReddotReadResponse response)
        {
            unit.GetComponent<ReddotComponentS>().RemoveReddont(request.ReddotType);
            
            await ETTask.CompletedTask;
        }
    }
}
