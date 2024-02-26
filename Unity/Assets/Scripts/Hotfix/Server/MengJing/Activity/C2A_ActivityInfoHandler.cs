using System.Collections.Generic;


namespace ET.Server
{
    
    [MessageHandler(SceneType.Activity)]
    public class C2A_ActivityInfoHandler : MessageHandler<Scene,C2A_ActivityInfoRequest,  A2C_ActivityInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_ActivityInfoRequest request, A2C_ActivityInfoResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            await ETTask.CompletedTask;
        }
    }
}
