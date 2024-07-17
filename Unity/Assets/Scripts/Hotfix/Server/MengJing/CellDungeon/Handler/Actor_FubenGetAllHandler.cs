
namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class Actor_FubenGetAllHandler : MessageLocationHandler<Unit, Actor_GetFubenInfoRequest, Actor_GetFubenInfoResponse>
    {

        protected override async ETTask Run(Unit unit, Actor_GetFubenInfoRequest request, Actor_GetFubenInfoResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}
