namespace ET.Server
{

    [ChildOf(typeof(AccountInfoComponent))]
    public class AccountInfo : Entity
    { 
        public string Account { get; set; }
    }

    //"{\"errcode\":1005,\"errmsg\":\"SYS REQ IP ERROR\"}"
    [EnableClass]
    public sealed class RealNameCode
    {
        public int errcode;
        public string errmsg;

        public RealNameData data;
    }

    [EnableClass]
    public sealed class RealNameData
    {
        public RealNameResult result;
    }

    [EnableClass]
    public sealed class RealNameResult
    {
        //认证结果
        //0：认证成功
        //1：认证中
        //2：认证失败
        public int status;
        //已通过实名认证用户的唯一标识
        public string pi;
    }

    [EnableClass]
    public sealed class NidCardData
    {
        public string status;
        public string msg;
        public string idCard;
        public string name;
        public string traceId;
    }
    
    public enum EType
    {
        Check,
        Query,
        Collect,
    }

}