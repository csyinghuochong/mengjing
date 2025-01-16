namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class A2NetClient_RequestHandler: MessageHandler<Scene, A2NetClient_Request, A2NetClient_Response>
    {
        protected override async ETTask Run(Scene root, A2NetClient_Request request, A2NetClient_Response response)
        {
            int rpcId = request.RpcId;
            SessionComponent sessionComponent = root.GetComponent<SessionComponent>();
            if (sessionComponent == null)
            {
                Log.Debug($"sessionComponent == null");
                response.Error = ErrorCode.ERR_SessionDisconnect;
                return;
            }

            Session session = sessionComponent.Session;
            if (session == null || session.IsDisposed)
            {
                Log.Debug($"session == null");
                response.Error = ErrorCode.ERR_SessionDisconnect;
                return;
            }
            
            IResponse res = await root.GetComponent<SessionComponent>().Session.Call(request.MessageObject);
            res.RpcId = rpcId;
            response.MessageObject = res;
        }
    }
}