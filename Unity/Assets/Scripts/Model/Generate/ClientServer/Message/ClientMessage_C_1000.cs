using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    // using
    [MemoryPackable]
    [Message(ClientMessage.Main2NetClient_ServerList)]
    [ResponseType(nameof(NetClient2Main_ServerList))]
    public partial class Main2NetClient_ServerList : MessageObject, IRequest
    {
        public static Main2NetClient_ServerList Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2NetClient_ServerList), isFromPool) as Main2NetClient_ServerList;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int OwnerFiberId { get; set; }

        [MemoryPackOrder(2)]
        public int VersionMode { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OwnerFiberId = default;
            this.VersionMode = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.NetClient2Main_ServerList)]
    public partial class NetClient2Main_ServerList : MessageObject, IResponse
    {
        public static NetClient2Main_ServerList Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_ServerList), isFromPool) as NetClient2Main_ServerList;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        /// <summary>
        /// 服务器列表
        /// </summary>
        [MemoryPackOrder(3)]
        public List<ServerItem> ServerItems { get; set; } = new();

        [MemoryPackOrder(4)]
        public string NoticeVersion { get; set; }

        [MemoryPackOrder(5)]
        public string NoticeText { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ServerItems.Clear();
            this.NoticeVersion = default;
            this.NoticeText = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Main2NetClient_Login)]
    [ResponseType(nameof(NetClient2Main_Login))]
    public partial class Main2NetClient_Login : MessageObject, IRequest
    {
        public static Main2NetClient_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2NetClient_Login), isFromPool) as Main2NetClient_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int OwnerFiberId { get; set; }

        [MemoryPackOrder(2)]
        public string Account { get; set; }

        [MemoryPackOrder(3)]
        public string Password { get; set; }

        [MemoryPackOrder(4)]
        public int ServerId { get; set; }

        [MemoryPackOrder(5)]
        public int Relink { get; set; }

        [MemoryPackOrder(6)]
        public int VersionMode { get; set; }

        [MemoryPackOrder(7)]
        public bool CheckRealName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OwnerFiberId = default;
            this.Account = default;
            this.Password = default;
            this.ServerId = default;
            this.Relink = default;
            this.VersionMode = default;
            this.CheckRealName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.NetClient2Main_Login)]
    public partial class NetClient2Main_Login : MessageObject, IResponse
    {
        public static NetClient2Main_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_Login), isFromPool) as NetClient2Main_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(4)]
        public long AccountId { get; set; }

        [MemoryPackOrder(5)]
        public string Token { get; set; }

        [MemoryPackOrder(10)]
        public PlayerInfo PlayerInfo { get; set; }

        [MemoryPackOrder(11)]
        public List<CreateRoleInfo> RoleLists { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PlayerId = default;
            this.AccountId = default;
            this.Token = default;
            this.PlayerInfo = default;
            this.RoleLists.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Main2NetClient_RealName)]
    [ResponseType(nameof(NetClient2Main_RealName))]
    public partial class Main2NetClient_RealName : MessageObject, IRequest
    {
        public static Main2NetClient_RealName Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2NetClient_RealName), isFromPool) as Main2NetClient_RealName;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int OwnerFiberId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MemoryPackOrder(2)]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [MemoryPackOrder(3)]
        public string IdCardNO { get; set; }

        /// <summary>
        /// 1认证 2查询 3上报
        /// </summary>
        [MemoryPackOrder(4)]
        public int AiType { get; set; }

        /// <summary>
        /// 帐号Id
        /// </summary>
        [MemoryPackOrder(5)]
        public long AccountId { get; set; }

        [MemoryPackOrder(6)]
        public int VersionMode { get; set; }

        [MemoryPackOrder(7)]
        public string Account { get; set; }

        [MemoryPackOrder(8)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OwnerFiberId = default;
            this.Name = default;
            this.IdCardNO = default;
            this.AiType = default;
            this.AccountId = default;
            this.VersionMode = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.NetClient2Main_RealName)]
    public partial class NetClient2Main_RealName : MessageObject, IResponse
    {
        public static NetClient2Main_RealName Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_RealName), isFromPool) as NetClient2Main_RealName;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        /// <summary>
        /// 实名认证返回
        /// </summary>
        [MemoryPackOrder(3)]
        public int ErrorCode { get; set; }

        [MemoryPackOrder(10)]
        public PlayerInfo PlayerInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ErrorCode = default;
            this.PlayerInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Main2NetClient_LoginGame)]
    [ResponseType(nameof(NetClient2Main_LoginGame))]
    public partial class Main2NetClient_LoginGame : MessageObject, IRequest
    {
        public static Main2NetClient_LoginGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2NetClient_LoginGame), isFromPool) as Main2NetClient_LoginGame;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        [MemoryPackOrder(2)]
        public long RealmKey { get; set; }

        [MemoryPackOrder(3)]
        public long RoleId { get; set; }

        [MemoryPackOrder(4)]
        public string GateAddress { get; set; }

        [MemoryPackOrder(5)]
        public long AccountId { get; set; }

        [MemoryPackOrder(6)]
        public int ReLink { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.RealmKey = default;
            this.RoleId = default;
            this.GateAddress = default;
            this.AccountId = default;
            this.ReLink = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.NetClient2Main_LoginGame)]
    public partial class NetClient2Main_LoginGame : MessageObject, IResponse
    {
        public static NetClient2Main_LoginGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_LoginGame), isFromPool) as NetClient2Main_LoginGame;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Main2RobotClient_Message)]
    [ResponseType(nameof(RobotClient2Main_Message))]
    public partial class Main2RobotClient_Message : MessageObject, IRequest
    {
        public static Main2RobotClient_Message Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2RobotClient_Message), isFromPool) as Main2RobotClient_Message;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.RobotClient2Main_Message)]
    public partial class RobotClient2Main_Message : MessageObject, IResponse
    {
        public static RobotClient2Main_Message Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RobotClient2Main_Message), isFromPool) as RobotClient2Main_Message;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Main2RobotManager_Message)]
    [ResponseType(nameof(RobotManager2Main_Message))]
    public partial class Main2RobotManager_Message : MessageObject, IRequest
    {
        public static Main2RobotManager_Message Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2RobotManager_Message), isFromPool) as Main2RobotManager_Message;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Message { get; set; }

        [MemoryPackOrder(2)]
        public int OpType { get; set; }

        [MemoryPackOrder(3)]
        public string OpParam { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.OpType = default;
            this.OpParam = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.RobotManager2Main_Message)]
    public partial class RobotManager2Main_Message : MessageObject, IResponse
    {
        public static RobotManager2Main_Message Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RobotManager2Main_Message), isFromPool) as RobotManager2Main_Message;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.Main2NetClient_CheckSession)]
    [ResponseType(nameof(NetClient2Main_CheckSession))]
    public partial class Main2NetClient_CheckSession : MessageObject, IRequest
    {
        public static Main2NetClient_CheckSession Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Main2NetClient_CheckSession), isFromPool) as Main2NetClient_CheckSession;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int MapType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.MapType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(ClientMessage.NetClient2Main_CheckSession)]
    public partial class NetClient2Main_CheckSession : MessageObject, IResponse
    {
        public static NetClient2Main_CheckSession Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_CheckSession), isFromPool) as NetClient2Main_CheckSession;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static class ClientMessage
    {
        public const ushort Main2NetClient_ServerList = 1001;
        public const ushort NetClient2Main_ServerList = 1002;
        public const ushort Main2NetClient_Login = 1003;
        public const ushort NetClient2Main_Login = 1004;
        public const ushort Main2NetClient_RealName = 1005;
        public const ushort NetClient2Main_RealName = 1006;
        public const ushort Main2NetClient_LoginGame = 1007;
        public const ushort NetClient2Main_LoginGame = 1008;
        public const ushort Main2RobotClient_Message = 1009;
        public const ushort RobotClient2Main_Message = 1010;
        public const ushort Main2RobotManager_Message = 1011;
        public const ushort RobotManager2Main_Message = 1012;
        public const ushort Main2NetClient_CheckSession = 1013;
        public const ushort NetClient2Main_CheckSession = 1014;
    }
}