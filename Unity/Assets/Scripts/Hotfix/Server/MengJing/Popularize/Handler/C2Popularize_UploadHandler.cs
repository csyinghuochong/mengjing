namespace ET.Server
{
    [MessageLocationHandler(SceneType.Popularize)]
    public class C2Popularize_UploadHandler : MessageHandler<Scene, C2Popularize_UploadRequest, Popularize2C_UploadResponse>
    {
        protected override async ETTask Run(Scene scene, C2Popularize_UploadRequest request, Popularize2C_UploadResponse response)
        {
            Log.Warning(  request.MemoryInfo );
            
            await ETTask.CompletedTask;
        }
    }
}
