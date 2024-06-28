namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class G2L_AddLoginRecordHandler : MessageHandler<Scene,G2L_AddLoginRecord,L2G_AddLoginRecord>
    {
        protected override async ETTask Run(Scene scene, G2L_AddLoginRecord request, L2G_AddLoginRecord response)
        {
            scene.GetComponent<LoginInfoRecordComponent>().Remove(request.AccountName.GetLongHashCode());
            scene.GetComponent<LoginInfoRecordComponent>().Add(request.AccountName.GetLongHashCode(),request.ServerId);
            
            await ETTask.CompletedTask;
        }
    }
}