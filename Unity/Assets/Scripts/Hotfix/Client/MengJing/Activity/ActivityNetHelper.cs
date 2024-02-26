
namespace ET.Client
{
    
    public static class ActivityNetHelper
    {
        public static async ETTask<int> RequestActivityInfo(Scene root)
        {
            Log.Debug($"C2A_ActivityInfoRequest: client0");
            C2A_ActivityInfoRequest reuqeust = new C2A_ActivityInfoRequest();
            A2C_ActivityInfoResponse initResponse = (A2C_ActivityInfoResponse) await root.GetComponent<ClientSenderCompnent>().Call(reuqeust);
            
            Log.Debug($"C2M_BagInitHandler: client1");
            return ErrorCode.ERR_Success;
        }
    }
}
