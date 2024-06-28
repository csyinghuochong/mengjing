using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
	[Message(OuterMessage.HttpGetRouterResponse)]
	[MemoryPackable]
	public partial class HttpGetRouterResponse: MessageObject
	{
		public static HttpGetRouterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetRouterResponse), isFromPool) as HttpGetRouterResponse; 
		}

		[MemoryPackOrder(0)]
		public List<string> Realms { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<string> Routers { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Realms.Clear();
			this.Routers.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RouterSync)]
	[MemoryPackable]
	public partial class RouterSync: MessageObject
	{
		public static RouterSync Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RouterSync), isFromPool) as RouterSync; 
		}

		[MemoryPackOrder(0)]
		public uint ConnectId { get; set; }

		[MemoryPackOrder(1)]
		public string Address { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ConnectId = default;
			this.Address = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterMessage.C2M_TestRequest)]
	[MemoryPackable]
	public partial class C2M_TestRequest: MessageObject, ILocationRequest
	{
		public static C2M_TestRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRequest), isFromPool) as C2M_TestRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string request { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.request = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestResponse)]
	[MemoryPackable]
	public partial class M2C_TestResponse: MessageObject, IResponse
	{
		public static M2C_TestResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestResponse), isFromPool) as M2C_TestResponse; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string response { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.response = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(C2C_SendBroadcastResponse))]
	[Message(OuterMessage.C2C_SendBroadcastRequest)]
	[MemoryPackable]
	public partial class C2C_SendBroadcastRequest: MessageObject, IChatActorRequest
	{
		public static C2C_SendBroadcastRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_SendBroadcastRequest), isFromPool) as C2C_SendBroadcastRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public ChatInfo ChatInfo { get; set; }

		[MemoryPackOrder(1)]
		public int ZoneType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChatInfo = default;
			this.ZoneType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2C_SendBroadcastResponse)]
	[MemoryPackable]
	public partial class C2C_SendBroadcastResponse: MessageObject, IChatActorResponse
	{
		public static C2C_SendBroadcastResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_SendBroadcastResponse), isFromPool) as C2C_SendBroadcastResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//GM邮件
	[ResponseType(nameof(E2C_GMEMailResponse))]
	[Message(OuterMessage.C2E_GMEMailRequest)]
	[MemoryPackable]
	public partial class C2E_GMEMailRequest: MessageObject, IMailActorRequest
	{
		public static C2E_GMEMailRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2E_GMEMailRequest), isFromPool) as C2E_GMEMailRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public string MailInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MailInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.E2C_GMEMailResponse)]
	[MemoryPackable]
	public partial class E2C_GMEMailResponse: MessageObject, IMailActorResponse
	{
		public static E2C_GMEMailResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(E2C_GMEMailResponse), isFromPool) as E2C_GMEMailResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//GM后台指令
	[ResponseType(nameof(C2C_GMCommonResponse))]
	[Message(OuterMessage.C2C_GMCommonRequest)]
	[MemoryPackable]
	public partial class C2C_GMCommonRequest: MessageObject, ICenterActorRequest
	{
		public static C2C_GMCommonRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_GMCommonRequest), isFromPool) as C2C_GMCommonRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string Account { get; set; }

		[MemoryPackOrder(1)]
		public string Context { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Account = default;
			this.Context = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2C_GMCommonResponse)]
	[MemoryPackable]
	public partial class C2C_GMCommonResponse: MessageObject, ICenterActorResponse
	{
		public static C2C_GMCommonResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_GMCommonResponse), isFromPool) as C2C_GMCommonResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Reload))]
	[Message(OuterMessage.C2G_Reload)]
	[MemoryPackable]
	public partial class C2G_Reload: MessageObject, IRequest
	{
		public static C2G_Reload Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Reload), isFromPool) as C2G_Reload; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string Account { get; set; }

		[MemoryPackOrder(1)]
		public string Password { get; set; }

		[MemoryPackOrder(2)]
		public int LoadType { get; set; }

		[MemoryPackOrder(3)]
		public string LoadValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			this.LoadType = default;
			this.LoadValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Reload)]
	[MemoryPackable]
	public partial class G2C_Reload: MessageObject, IResponse
	{
		public static G2C_Reload Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Reload), isFromPool) as G2C_Reload; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//GM数据
	[ResponseType(nameof(C2C_GMInfoResponse))]
	[Message(OuterMessage.C2C_GMInfoRequest)]
	[MemoryPackable]
	public partial class C2C_GMInfoRequest: MessageObject, ICenterActorRequest
	{
		public static C2C_GMInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_GMInfoRequest), isFromPool) as C2C_GMInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string Account { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Account = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2C_GMInfoResponse)]
	[MemoryPackable]
	public partial class C2C_GMInfoResponse: MessageObject, ICenterActorResponse
	{
		public static C2C_GMInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_GMInfoResponse), isFromPool) as C2C_GMInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int OnLineNumber { get; set; }

		[MemoryPackOrder(1)]
		public int OnLineRobot { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.OnLineNumber = default;
			this.OnLineRobot = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterMessage.C2G_EnterMap)]
	[MemoryPackable]
	public partial class C2G_EnterMap: MessageObject, ISessionRequest
	{
		public static C2G_EnterMap Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_EnterMap), isFromPool) as C2G_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_EnterMap)]
	[MemoryPackable]
	public partial class G2C_EnterMap: MessageObject, ISessionResponse
	{
		public static G2C_EnterMap Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_EnterMap), isFromPool) as G2C_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

// 自己unitId
		[MemoryPackOrder(3)]
		public long MyId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MyId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MoveInfo)]
	[MemoryPackable]
	public partial class MoveInfo: MessageObject
	{
		public static MoveInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MoveInfo), isFromPool) as MoveInfo; 
		}

		[MemoryPackOrder(0)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		[MemoryPackOrder(1)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		[MemoryPackOrder(2)]
		public int TurnSpeed { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Points.Clear();
			this.Rotation = default;
			this.TurnSpeed = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.UnitInfo)]
	[MemoryPackable]
	public partial class UnitInfo: MessageObject
	{
		public static UnitInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnitInfo), isFromPool) as UnitInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int Type { get; set; }

		[MemoryPackOrder(3)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(4)]
		public Unity.Mathematics.float3 Forward { get; set; }

		[MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
		[MemoryPackOrder(5)]
		public Dictionary<int, long> KV { get; set; } = new();
		[MemoryPackOrder(6)]
		public MoveInfo MoveInfo { get; set; }

		[MemoryPackOrder(18)]
		public List<KeyValuePair> Buffs { get; set; } = new();

		[MemoryPackOrder(19)]
		public List<SkillInfo> Skills { get; set; } = new();

		[MemoryPackOrder(20)]
		public string UnitName { get; set; }

		[MemoryPackOrder(21)]
		public string MasterName { get; set; }

		[MemoryPackOrder(23)]
		public string UnionName { get; set; }

		[MemoryPackOrder(24)]
		public string DemonName { get; set; }

		[MemoryPackOrder(25)]
		public List<int> FashionEquipList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.ConfigId = default;
			this.Type = default;
			this.Position = default;
			this.Forward = default;
			this.KV.Clear();
			this.MoveInfo = default;
			this.Buffs.Clear();
			this.Skills.Clear();
			this.UnitName = default;
			this.MasterName = default;
			this.UnionName = default;
			this.DemonName = default;
			this.FashionEquipList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CreateUnits)]
	[MemoryPackable]
	public partial class M2C_CreateUnits: MessageObject, IMessage
	{
		public static M2C_CreateUnits Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CreateUnits), isFromPool) as M2C_CreateUnits; 
		}

		[MemoryPackOrder(0)]
		public List<UnitInfo> Units { get; set; } = new();

		[MemoryPackOrder(7)]
		public int UpdateAll { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			this.UpdateAll = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CreateMyUnit)]
	[MemoryPackable]
	public partial class M2C_CreateMyUnit: MessageObject, IMessage
	{
		public static M2C_CreateMyUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CreateMyUnit), isFromPool) as M2C_CreateMyUnit; 
		}

		[MemoryPackOrder(0)]
		public UnitInfo Unit { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Unit = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StartSceneChange)]
	[MemoryPackable]
	public partial class M2C_StartSceneChange: MessageObject, IMessage
	{
		public static M2C_StartSceneChange Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StartSceneChange), isFromPool) as M2C_StartSceneChange; 
		}

		[MemoryPackOrder(0)]
		public long SceneInstanceId { get; set; }

		[MemoryPackOrder(1)]
		public int SceneType { get; set; }

		[MemoryPackOrder(2)]
		public int SceneId { get; set; }

		[MemoryPackOrder(3)]
		public int Difficulty { get; set; }

		[MemoryPackOrder(4)]
		public string ParamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneInstanceId = default;
			this.SceneType = default;
			this.SceneId = default;
			this.Difficulty = default;
			this.ParamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RemoveUnits)]
	[MemoryPackable]
	public partial class M2C_RemoveUnits: MessageObject, IMessage
	{
		public static M2C_RemoveUnits Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RemoveUnits), isFromPool) as M2C_RemoveUnits; 
		}

		[MemoryPackOrder(0)]
		public List<long> Units { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_PathfindingResult)]
	[MemoryPackable]
	public partial class C2M_PathfindingResult: MessageObject, ILocationMessage
	{
		public static C2M_PathfindingResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PathfindingResult), isFromPool) as C2M_PathfindingResult; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_Stop)]
	[MemoryPackable]
	public partial class C2M_Stop: MessageObject, ILocationMessage
	{
		public static C2M_Stop Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Stop), isFromPool) as C2M_Stop; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PathfindingResult)]
	[MemoryPackable]
	public partial class M2C_PathfindingResult: MessageObject, IMessage
	{
		public static M2C_PathfindingResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PathfindingResult), isFromPool) as M2C_PathfindingResult; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(2)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.Position = default;
			this.Points.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Stop)]
	[MemoryPackable]
	public partial class M2C_Stop: MessageObject, IMessage
	{
		public static M2C_Stop Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Stop), isFromPool) as M2C_Stop; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public long Id { get; set; }

		[MemoryPackOrder(2)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(3)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Id = default;
			this.Position = default;
			this.Rotation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterMessage.C2G_Ping)]
	[MemoryPackable]
	public partial class C2G_Ping: MessageObject, ISessionRequest
	{
		public static C2G_Ping Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Ping), isFromPool) as C2G_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Ping)]
	[MemoryPackable]
	public partial class G2C_Ping: MessageObject, ISessionResponse
	{
		public static G2C_Ping Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Ping), isFromPool) as G2C_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Test)]
	[MemoryPackable]
	public partial class G2C_Test: MessageObject, ISessionMessage
	{
		public static G2C_Test Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Test), isFromPool) as G2C_Test; 
		}

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterMessage.C2M_Reload)]
	[MemoryPackable]
	public partial class C2M_Reload: MessageObject, ISessionRequest
	{
		public static C2M_Reload Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Reload), isFromPool) as C2M_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Reload)]
	[MemoryPackable]
	public partial class M2C_Reload: MessageObject, ISessionResponse
	{
		public static M2C_Reload Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Reload), isFromPool) as M2C_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_LoginAccount))]
	[Message(OuterMessage.C2R_LoginAccount)]
	[MemoryPackable]
	public partial class C2R_LoginAccount: MessageObject, ISessionRequest
	{
		public static C2R_LoginAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_LoginAccount), isFromPool) as C2R_LoginAccount; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		[MemoryPackOrder(3)]
		public string Token { get; set; }

		[MemoryPackOrder(4)]
		public string ThirdLogin { get; set; }

		[MemoryPackOrder(5)]
		public bool Relink { get; set; }

		[MemoryPackOrder(6)]
		public int age_type { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			this.Token = default;
			this.ThirdLogin = default;
			this.Relink = default;
			this.age_type = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_LoginAccount)]
	[MemoryPackable]
	public partial class R2C_LoginAccount: MessageObject, ISessionResponse
	{
		public static R2C_LoginAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_LoginAccount), isFromPool) as R2C_LoginAccount; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string Address { get; set; }

		[MemoryPackOrder(4)]
		public long Key { get; set; }

		[MemoryPackOrder(5)]
		public long GateId { get; set; }

		[MemoryPackOrder(6)]
		public string Token { get; set; }

		[MemoryPackOrder(7)]
		public long AccountId { get; set; }

		[MemoryPackOrder(8)]
		public int QueueNumber { get; set; }

		[MemoryPackOrder(9)]
		public string QueueAddres { get; set; }

		[MemoryPackOrder(10)]
		public PlayerInfo PlayerInfo { get; set; }

		[MemoryPackOrder(11)]
		public List<CreateRoleInfo> RoleLists { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Address = default;
			this.Key = default;
			this.GateId = default;
			this.Token = default;
			this.AccountId = default;
			this.QueueNumber = default;
			this.QueueAddres = default;
			this.PlayerInfo = default;
			this.RoleLists.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RechargeInfo)]
	[MemoryPackable]
	public partial class RechargeInfo: MessageObject
	{
		public static RechargeInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RechargeInfo), isFromPool) as RechargeInfo; 
		}

		[MemoryPackOrder(0)]
		public int Amount { get; set; }

		[MemoryPackOrder(1)]
		public long Time { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public string OrderInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Amount = default;
			this.Time = default;
			this.UnitId = default;
			this.OrderInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.KeyValuePair)]
	[MemoryPackable]
	public partial class KeyValuePair: MessageObject
	{
		public static KeyValuePair Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(KeyValuePair), isFromPool) as KeyValuePair; 
		}

		[MemoryPackOrder(0)]
		public int KeyId { get; set; }

		[MemoryPackOrder(1)]
		public string Value { get; set; }

		[MemoryPackOrder(2)]
		public string Value2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.KeyId = default;
			this.Value = default;
			this.Value2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.KeyValuePairInt)]
	[MemoryPackable]
	public partial class KeyValuePairInt: MessageObject
	{
		public static KeyValuePairInt Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(KeyValuePairInt), isFromPool) as KeyValuePairInt; 
		}

		[MemoryPackOrder(0)]
		public int KeyId { get; set; }

		[MemoryPackOrder(1)]
		public long Value { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.KeyId = default;
			this.Value = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.KeyValuePairLong)]
	[MemoryPackable]
	public partial class KeyValuePairLong: MessageObject
	{
		public static KeyValuePairLong Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(KeyValuePairLong), isFromPool) as KeyValuePairLong; 
		}

		[MemoryPackOrder(0)]
		public long KeyId { get; set; }

		[MemoryPackOrder(1)]
		public long Value { get; set; }

		[MemoryPackOrder(2)]
		public long Value2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.KeyId = default;
			this.Value = default;
			this.Value2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PlayerInfo)]
	[MemoryPackable]
	public partial class PlayerInfo: MessageObject
	{
		public static PlayerInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PlayerInfo), isFromPool) as PlayerInfo; 
		}

		[MemoryPackOrder(0)]
		public int RealName { get; set; }

		[MemoryPackOrder(1)]
		public string Name { get; set; }

		[MemoryPackOrder(2)]
		public string IdCardNo { get; set; }

		[MemoryPackOrder(3)]
		public int RealNameReward { get; set; }

		[MemoryPackOrder(4)]
		public List<RechargeInfo> RechargeInfos { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<KeyValuePair> DeleteUserList { get; set; } = new();

		[MemoryPackOrder(6)]
		public List<int> BuChangZone { get; set; } = new();

		[MemoryPackOrder(7)]
		public string PhoneNumber { get; set; }

		[MemoryPackOrder(8)]
		public List<long> ShareTimes { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RealName = default;
			this.Name = default;
			this.IdCardNo = default;
			this.RealNameReward = default;
			this.RechargeInfos.Clear();
			this.DeleteUserList.Clear();
			this.BuChangZone.Clear();
			this.PhoneNumber = default;
			this.ShareTimes.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.CreateRoleInfo)]
	[MemoryPackable]
	public partial class CreateRoleInfo: MessageObject
	{
		public static CreateRoleInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(CreateRoleInfo), isFromPool) as CreateRoleInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int PlayerLv { get; set; }

		[MemoryPackOrder(2)]
		public int PlayerOcc { get; set; }

		[MemoryPackOrder(3)]
		public int WeaponId { get; set; }

		[MemoryPackOrder(4)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(5)]
		public int OccTwo { get; set; }

		[MemoryPackOrder(6)]
		public int EquipIndex { get; set; }

		[MemoryPackOrder(7)]
		public int RobotId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.PlayerLv = default;
			this.PlayerOcc = default;
			this.WeaponId = default;
			this.PlayerName = default;
			this.OccTwo = default;
			this.EquipIndex = default;
			this.RobotId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_LoginGameGate))]
	[Message(OuterMessage.C2G_LoginGameGate)]
	[MemoryPackable]
	public partial class C2G_LoginGameGate: MessageObject, ISessionRequest
	{
		public static C2G_LoginGameGate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_LoginGameGate), isFromPool) as C2G_LoginGameGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		[MemoryPackOrder(2)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_LoginGameGate)]
	[MemoryPackable]
	public partial class G2C_LoginGameGate: MessageObject, ISessionResponse
	{
		public static G2C_LoginGameGate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_LoginGameGate), isFromPool) as G2C_LoginGameGate; 
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
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ServerItem)]
	[MemoryPackable]
	public partial class ServerItem: MessageObject
	{
		public static ServerItem Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ServerItem), isFromPool) as ServerItem; 
		}

		[MemoryPackOrder(0)]
		public int ServerId { get; set; }

		[MemoryPackOrder(1)]
		public string ServerIp { get; set; }

		[MemoryPackOrder(2)]
		public string ServerName { get; set; }

		[MemoryPackOrder(3)]
		public long ServerOpenTime { get; set; }

		[MemoryPackOrder(4)]
		public int Show { get; set; }

		[MemoryPackOrder(5)]
		public int New { get; set; }

		[MemoryPackOrder(6)]
		public List<int> PlatformList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ServerId = default;
			this.ServerIp = default;
			this.ServerName = default;
			this.ServerOpenTime = default;
			this.Show = default;
			this.New = default;
			this.PlatformList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_CreateRoleData))]
	[Message(OuterMessage.C2G_CreateRoleData)]
	[MemoryPackable]
	public partial class C2G_CreateRoleData: MessageObject, ISessionRequest
	{
		public static C2G_CreateRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_CreateRoleData), isFromPool) as C2G_CreateRoleData; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int CreateOcc { get; set; }

		[MemoryPackOrder(2)]
		public string CreateName { get; set; }

		[MemoryPackOrder(3)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CreateOcc = default;
			this.CreateName = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_CreateRoleData)]
	[MemoryPackable]
	public partial class G2C_CreateRoleData: MessageObject, ISessionResponse
	{
		public static G2C_CreateRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_CreateRoleData), isFromPool) as G2C_CreateRoleData; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public CreateRoleInfo createRoleInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.createRoleInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_DeleteRoleData))]
	[Message(OuterMessage.C2G_DeleteRoleData)]
	[MemoryPackable]
	public partial class C2G_DeleteRoleData: MessageObject, ISessionRequest
	{
		public static C2G_DeleteRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_DeleteRoleData), isFromPool) as C2G_DeleteRoleData; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long AccountId { get; set; }

		[MemoryPackOrder(1)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AccountId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_DeleteRoleData)]
	[MemoryPackable]
	public partial class G2C_DeleteRoleData: MessageObject, ISessionResponse
	{
		public static G2C_DeleteRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_DeleteRoleData), isFromPool) as G2C_DeleteRoleData; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_TestHotfixMessage)]
	[MemoryPackable]
	public partial class G2C_TestHotfixMessage: MessageObject, ISessionMessage
	{
		public static G2C_TestHotfixMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_TestHotfixMessage), isFromPool) as G2C_TestHotfixMessage; 
		}

		[MemoryPackOrder(0)]
		public string Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterMessage.C2M_TestRobotCase)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase: MessageObject, ILocationRequest
	{
		public static C2M_TestRobotCase Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase), isFromPool) as C2M_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase: MessageObject, ILocationResponse
	{
		public static M2C_TestRobotCase Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase), isFromPool) as M2C_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_TestRobotCase2)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase2: MessageObject, ILocationMessage
	{
		public static C2M_TestRobotCase2 Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase2), isFromPool) as C2M_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase2)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase2: MessageObject, ILocationMessage
	{
		public static M2C_TestRobotCase2 Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase2), isFromPool) as M2C_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterMessage.C2M_TransferMap)]
	[MemoryPackable]
	public partial class C2M_TransferMap: MessageObject, ILocationRequest
	{
		public static C2M_TransferMap Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TransferMap), isFromPool) as C2M_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int SceneId { get; set; }

		[MemoryPackOrder(2)]
		public int SceneType { get; set; }

		[MemoryPackOrder(4)]
		public int Difficulty { get; set; }

		[MemoryPackOrder(5)]
		public string paramInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SceneId = default;
			this.SceneType = default;
			this.Difficulty = default;
			this.paramInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TransferMap)]
	[MemoryPackable]
	public partial class M2C_TransferMap: MessageObject, ILocationResponse
	{
		public static M2C_TransferMap Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TransferMap), isFromPool) as M2C_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Benchmark))]
	[Message(OuterMessage.C2G_Benchmark)]
	[MemoryPackable]
	public partial class C2G_Benchmark: MessageObject, ISessionRequest
	{
		public static C2G_Benchmark Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Benchmark), isFromPool) as C2G_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Benchmark)]
	[MemoryPackable]
	public partial class G2C_Benchmark: MessageObject, ISessionResponse
	{
		public static G2C_Benchmark Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Benchmark), isFromPool) as G2C_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.HideProList)]
	[MemoryPackable]
	public partial class HideProList: MessageObject
	{
		public static HideProList Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HideProList), isFromPool) as HideProList; 
		}

		[MemoryPackOrder(0)]
		public int HideID { get; set; }

		[MemoryPackOrder(1)]
		public long HideValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.HideID = default;
			this.HideValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.BagInfo)]
	[MemoryPackable]
	public partial class BagInfo: MessageObject
	{
		public static BagInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(BagInfo), isFromPool) as BagInfo; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Name { get; set; }

		[MemoryPackOrder(0)]
		public long BagInfoID { get; set; }

		[MemoryPackOrder(1)]
		public int ItemID { get; set; }

		[MemoryPackOrder(2)]
		public int ItemNum { get; set; }

		[MemoryPackOrder(3)]
		public string ItemPar { get; set; }

		[MemoryPackOrder(4)]
		public int HideID { get; set; }

		[MemoryPackOrder(5)]
		public string GemHole { get; set; }

		[MemoryPackOrder(7)]
		public int Loc { get; set; }

		[MemoryPackOrder(8)]
		public bool IfJianDing { get; set; }

		[MemoryPackOrder(9)]
		public List<HideProList> HideProLists { get; set; } = new();

		[MemoryPackOrder(10)]
		public List<HideProList> XiLianHideProLists { get; set; } = new();

		[MemoryPackOrder(11)]
		public List<int> HideSkillLists { get; set; } = new();

		[MemoryPackOrder(12)]
		public bool isBinging { get; set; }

		[MemoryPackOrder(13)]
		public List<HideProList> XiLianHideTeShuProLists { get; set; } = new();

		[MemoryPackOrder(15)]
		public string GetWay { get; set; }

		[MemoryPackOrder(16)]
		public string GemIDNew { get; set; }

		[MemoryPackOrder(17)]
		public string MakePlayer { get; set; }

		[MemoryPackOrder(19)]
		public List<HideProList> FumoProLists { get; set; } = new();

		[MemoryPackOrder(20)]
		public int InheritTimes { get; set; }

		[MemoryPackOrder(21)]
		public List<int> InheritSkills { get; set; } = new();

		[MemoryPackOrder(22)]
		public bool IsProtect { get; set; }

		[MemoryPackOrder(23)]
		public List<HideProList> IncreaseProLists { get; set; } = new();

		[MemoryPackOrder(24)]
		public List<int> IncreaseSkillLists { get; set; } = new();

		[MemoryPackOrder(25)]
		public int EquipPlan { get; set; }

		[MemoryPackOrder(26)]
		public int EquipIndex { get; set; }

		[MemoryPackOrder(27)]
		public int FuLing { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Name = default;
			this.BagInfoID = default;
			this.ItemID = default;
			this.ItemNum = default;
			this.ItemPar = default;
			this.HideID = default;
			this.GemHole = default;
			this.Loc = default;
			this.IfJianDing = default;
			this.HideProLists.Clear();
			this.XiLianHideProLists.Clear();
			this.HideSkillLists.Clear();
			this.isBinging = default;
			this.XiLianHideTeShuProLists.Clear();
			this.GetWay = default;
			this.GemIDNew = default;
			this.MakePlayer = default;
			this.FumoProLists.Clear();
			this.InheritTimes = default;
			this.InheritSkills.Clear();
			this.IsProtect = default;
			this.IncreaseProLists.Clear();
			this.IncreaseSkillLists.Clear();
			this.EquipPlan = default;
			this.EquipIndex = default;
			this.FuLing = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MysteryItemInfo)]
	[MemoryPackable]
	public partial class MysteryItemInfo: MessageObject
	{
		public static MysteryItemInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MysteryItemInfo), isFromPool) as MysteryItemInfo; 
		}

		[MemoryPackOrder(0)]
		public int MysteryId { get; set; }

		[MemoryPackOrder(2)]
		public int ItemID { get; set; }

		[MemoryPackOrder(3)]
		public int ItemNumber { get; set; }

		[MemoryPackOrder(4)]
		public int ProductId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.MysteryId = default;
			this.ItemID = default;
			this.ItemNumber = default;
			this.ProductId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//战区领取记录
	[Message(OuterMessage.ZhanQuReceiveNumber)]
	[MemoryPackable]
	public partial class ZhanQuReceiveNumber: MessageObject
	{
		public static ZhanQuReceiveNumber Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ZhanQuReceiveNumber), isFromPool) as ZhanQuReceiveNumber; 
		}

		[MemoryPackOrder(0)]
		public int ActivityId { get; set; }

		[MemoryPackOrder(1)]
		public int ReceiveNum { get; set; }

		[MemoryPackOrder(2)]
		public List<long> ReceiveUnitIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActivityId = default;
			this.ReceiveNum = default;
			this.ReceiveUnitIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.FirstWinInfo)]
	[MemoryPackable]
	public partial class FirstWinInfo: MessageObject
	{
		public static FirstWinInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(FirstWinInfo), isFromPool) as FirstWinInfo; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public int FirstWinId { get; set; }

		[MemoryPackOrder(2)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(3)]
		public long KillTime { get; set; }

		[MemoryPackOrder(4)]
		public int Difficulty { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.FirstWinId = default;
			this.PlayerName = default;
			this.KillTime = default;
			this.Difficulty = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PetMingPlayerInfo)]
	[MemoryPackable]
	public partial class PetMingPlayerInfo: MessageObject
	{
		public static PetMingPlayerInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PetMingPlayerInfo), isFromPool) as PetMingPlayerInfo; 
		}

		[MemoryPackOrder(0)]
		public int MineType { get; set; }

		[MemoryPackOrder(1)]
		public int Postion { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(4)]
		public List<int> PetConfig { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<long> PetIdList { get; set; } = new();

		[MemoryPackOrder(6)]
		public int TeamId { get; set; }

		[MemoryPackOrder(7)]
		public long OccupyTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.MineType = default;
			this.Postion = default;
			this.UnitId = default;
			this.PlayerName = default;
			this.PetConfig.Clear();
			this.PetIdList.Clear();
			this.TeamId = default;
			this.OccupyTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ChatInfo)]
	[MemoryPackable]
	public partial class ChatInfo: MessageObject
	{
		public static ChatInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ChatInfo), isFromPool) as ChatInfo; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(2)]
		public string ChatMsg { get; set; }

		[MemoryPackOrder(3)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(1)]
		public int ChannelId { get; set; }

		[MemoryPackOrder(4)]
		public long ParamId { get; set; }

		[MemoryPackOrder(5)]
		public long Time { get; set; }

		[MemoryPackOrder(6)]
		public int Occ { get; set; }

		[MemoryPackOrder(7)]
		public int PlayerLevel { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.ChatMsg = default;
			this.PlayerName = default;
			this.ChannelId = default;
			this.ParamId = default;
			this.Time = default;
			this.Occ = default;
			this.PlayerLevel = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MailInfo)]
	[MemoryPackable]
	public partial class MailInfo: MessageObject
	{
		public static MailInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MailInfo), isFromPool) as MailInfo; 
		}

		[MemoryPackOrder(0)]
		public int Status { get; set; }

		[MemoryPackOrder(2)]
		public string Context { get; set; }

		[MemoryPackOrder(4)]
		public long MailId { get; set; }

		[MemoryPackOrder(5)]
		public string Title { get; set; }

		[MemoryPackOrder(6)]
		public List<BagInfo> ItemList { get; set; } = new();

		[MemoryPackOrder(7)]
		public BagInfo ItemSell { get; set; }

		[MemoryPackOrder(8)]
		public long BuyPlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Status = default;
			this.Context = default;
			this.MailId = default;
			this.Title = default;
			this.ItemList.Clear();
			this.ItemSell = default;
			this.BuyPlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PaiMaiItemInfo)]
	[MemoryPackable]
	public partial class PaiMaiItemInfo: MessageObject
	{
		public static PaiMaiItemInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PaiMaiItemInfo), isFromPool) as PaiMaiItemInfo; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public long UserId { get; set; }

		[MemoryPackOrder(2)]
		public BagInfo BagInfo { get; set; }

		[MemoryPackOrder(4)]
		public int Price { get; set; }

		[MemoryPackOrder(5)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(6)]
		public long SellTime { get; set; }

		[MemoryPackOrder(7)]
		public string Account { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.UserId = default;
			this.BagInfo = default;
			this.Price = default;
			this.PlayerName = default;
			this.SellTime = default;
			this.Account = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PaiMaiShopItemInfo)]
	[MemoryPackable]
	public partial class PaiMaiShopItemInfo: MessageObject
	{
		public static PaiMaiShopItemInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PaiMaiShopItemInfo), isFromPool) as PaiMaiShopItemInfo; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ItemNumber { get; set; }

		[MemoryPackOrder(2)]
		public int PriceType { get; set; }

		[MemoryPackOrder(3)]
		public int Price { get; set; }

		[MemoryPackOrder(4)]
		public float PricePro { get; set; }

		[MemoryPackOrder(5)]
		public int BuyNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ItemNumber = default;
			this.PriceType = default;
			this.Price = default;
			this.PricePro = default;
			this.BuyNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PopularizeInfo)]
	[MemoryPackable]
	public partial class PopularizeInfo: MessageObject
	{
		public static PopularizeInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PopularizeInfo), isFromPool) as PopularizeInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public string Nmae { get; set; }

		[MemoryPackOrder(2)]
		public int Level { get; set; }

		[MemoryPackOrder(3)]
		public List<int> Rewards { get; set; } = new();

		[MemoryPackOrder(4)]
		public int Occ { get; set; }

		[MemoryPackOrder(5)]
		public int OccTwo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.Nmae = default;
			this.Level = default;
			this.Rewards.Clear();
			this.Occ = default;
			this.OccTwo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RankingInfo)]
	[MemoryPackable]
	public partial class RankingInfo: MessageObject
	{
		public static RankingInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RankingInfo), isFromPool) as RankingInfo; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public int PlayerLv { get; set; }

		[MemoryPackOrder(3)]
		public long Combat { get; set; }

		[MemoryPackOrder(4)]
		public int Occ { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.PlayerName = default;
			this.PlayerLv = default;
			this.Combat = default;
			this.Occ = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RankShouLieInfo)]
	[MemoryPackable]
	public partial class RankShouLieInfo: MessageObject
	{
		public static RankShouLieInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RankShouLieInfo), isFromPool) as RankShouLieInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitID { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public long KillNumber { get; set; }

		[MemoryPackOrder(3)]
		public int Occ { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitID = default;
			this.PlayerName = default;
			this.KillNumber = default;
			this.Occ = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RankPetInfo)]
	[MemoryPackable]
	public partial class RankPetInfo: MessageObject
	{
		public static RankPetInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RankPetInfo), isFromPool) as RankPetInfo; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public string TeamName { get; set; }

		[MemoryPackOrder(3)]
		public int RankId { get; set; }

		[MemoryPackOrder(4)]
		public List<int> PetConfigId { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<long> PetUId { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.PlayerName = default;
			this.TeamName = default;
			this.RankId = default;
			this.PetConfigId.Clear();
			this.PetUId.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ServerInfo)]
	[MemoryPackable]
	public partial class ServerInfo: MessageObject
	{
		public static ServerInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ServerInfo), isFromPool) as ServerInfo; 
		}

		[MemoryPackOrder(0)]
		public int WorldLv { get; set; }

		[MemoryPackOrder(1)]
		public long ExChangeGold { get; set; }

		[MemoryPackOrder(3)]
		public RankingInfo RankingInfo { get; set; }

		[MemoryPackOrder(4)]
		public int TianQi { get; set; }

		[MemoryPackOrder(5)]
		public bool ShouLieOpen { get; set; }

		[MemoryPackOrder(6)]
		public int ChouKaDropId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.WorldLv = default;
			this.ExChangeGold = default;
			this.RankingInfo = default;
			this.TianQi = default;
			this.ShouLieOpen = default;
			this.ChouKaDropId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ServerMailItem)]
	[MemoryPackable]
	public partial class ServerMailItem: MessageObject
	{
		public static ServerMailItem Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ServerMailItem), isFromPool) as ServerMailItem; 
		}

		[MemoryPackOrder(0)]
		public int MailType { get; set; }

		[MemoryPackOrder(1)]
		public string ParasmNew { get; set; }

		[MemoryPackOrder(2)]
		public List<BagInfo> ItemList { get; set; } = new();

		[MemoryPackOrder(3)]
		public long EndTime { get; set; }

		[MemoryPackOrder(4)]
		public int ServerMailIId { get; set; }

		[MemoryPackOrder(5)]
		public int Parasm { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.MailType = default;
			this.ParasmNew = default;
			this.ItemList.Clear();
			this.EndTime = default;
			this.ServerMailIId = default;
			this.Parasm = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.UnionInfo)]
	[MemoryPackable]
	public partial class UnionInfo: MessageObject
	{
		public static UnionInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnionInfo), isFromPool) as UnionInfo; 
		}

		[MemoryPackOrder(0)]
		public string UnionName { get; set; }

		[MemoryPackOrder(1)]
		public long LeaderId { get; set; }

		[MemoryPackOrder(2)]
		public string LeaderName { get; set; }

		[MemoryPackOrder(3)]
		public int LevelLimit { get; set; }

		[MemoryPackOrder(4)]
		public string UnionPurpose { get; set; }

		[MemoryPackOrder(5)]
		public List<long> ApplyList { get; set; } = new();

		[MemoryPackOrder(6)]
		public long UnionId { get; set; }

		[MemoryPackOrder(7)]
		public int Level { get; set; }

		[MemoryPackOrder(8)]
		public int Exp { get; set; }

		[MemoryPackOrder(9)]
		public List<UnionPlayerInfo> UnionPlayerList { get; set; } = new();

		[MemoryPackOrder(10)]
		public List<DonationRecord> DonationRecords { get; set; } = new();

		[MemoryPackOrder(11)]
		public List<long> JingXuanList { get; set; } = new();

		[MemoryPackOrder(12)]
		public long JingXuanEndTime { get; set; }

		[MemoryPackOrder(13)]
		public List<int> UnionKeJiList { get; set; } = new();

		[MemoryPackOrder(14)]
		public int KeJiActitePos { get; set; }

		[MemoryPackOrder(15)]
		public long KeJiActiteTime { get; set; }

		[MemoryPackOrder(16)]
		public long UnionGold { get; set; }

		[MemoryPackOrder(17)]
		public List<string> ActiveRecord { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnionName = default;
			this.LeaderId = default;
			this.LeaderName = default;
			this.LevelLimit = default;
			this.UnionPurpose = default;
			this.ApplyList.Clear();
			this.UnionId = default;
			this.Level = default;
			this.Exp = default;
			this.UnionPlayerList.Clear();
			this.DonationRecords.Clear();
			this.JingXuanList.Clear();
			this.JingXuanEndTime = default;
			this.UnionKeJiList.Clear();
			this.KeJiActitePos = default;
			this.KeJiActiteTime = default;
			this.UnionGold = default;
			this.ActiveRecord.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.UnionPlayerInfo)]
	[MemoryPackable]
	public partial class UnionPlayerInfo: MessageObject
	{
		public static UnionPlayerInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnionPlayerInfo), isFromPool) as UnionPlayerInfo; 
		}

		[MemoryPackOrder(0)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(1)]
		public int PlayerLevel { get; set; }

		[MemoryPackOrder(2)]
		public int Position { get; set; }

		[MemoryPackOrder(3)]
		public long UserID { get; set; }

		[MemoryPackOrder(4)]
		public int Combat { get; set; }

		[MemoryPackOrder(5)]
		public int Occ { get; set; }

		[MemoryPackOrder(6)]
		public int OccTwo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PlayerName = default;
			this.PlayerLevel = default;
			this.Position = default;
			this.UserID = default;
			this.Combat = default;
			this.Occ = default;
			this.OccTwo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.DonationRecord)]
	[MemoryPackable]
	public partial class DonationRecord: MessageObject
	{
		public static DonationRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(DonationRecord), isFromPool) as DonationRecord; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long Time { get; set; }

		[MemoryPackOrder(2)]
		public int Gold { get; set; }

		[MemoryPackOrder(3)]
		public string Name { get; set; }

		[MemoryPackOrder(4)]
		public int Occ { get; set; }

		[MemoryPackOrder(5)]
		public int Diamond { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.Time = default;
			this.Gold = default;
			this.Name = default;
			this.Occ = default;
			this.Diamond = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.A2C_Disconnect)]
	[MemoryPackable]
	public partial class A2C_Disconnect: MessageObject, IMessage
	{
		public static A2C_Disconnect Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_Disconnect), isFromPool) as A2C_Disconnect; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//等级 经验 货币 或者不变的数值都放在这。
	[Message(OuterMessage.UserInfo)]
	[MemoryPackable]
	public partial class UserInfo: MessageObject
	{
		public static UserInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UserInfo), isFromPool) as UserInfo; 
		}

		[MemoryPackOrder(0)]
		public long AccInfoID { get; set; }

		[MemoryPackOrder(1)]
		public string Name { get; set; }

		[MemoryPackOrder(2)]
		public long Gold { get; set; }

//钻石
		[MemoryPackOrder(3)]
		public long Diamond { get; set; }

// 等级
		[MemoryPackOrder(4)]
		public int Lv { get; set; }

// 经验
		[MemoryPackOrder(5)]
		public long Exp { get; set; }

// 疲劳
		[MemoryPackOrder(6)]
		public long PiLao { get; set; }

//职业
		[MemoryPackOrder(7)]
		public int Occ { get; set; }

//职业
		[MemoryPackOrder(8)]
		public int OccTwo { get; set; }

		[MemoryPackOrder(9)]
		public int Combat { get; set; }

		[MemoryPackOrder(10)]
		public int RobotId { get; set; }

		[MemoryPackOrder(12)]
		public int Sp { get; set; }

		[MemoryPackOrder(13)]
		public int Vitality { get; set; }

		[MemoryPackOrder(15)]
		public long RongYu { get; set; }

		[MemoryPackOrder(16)]
		public string UnionName { get; set; }

		[MemoryPackOrder(17)]
		public long UserId { get; set; }

		[MemoryPackOrder(18)]
		public List<KeyValuePair> GameSettingInfos { get; set; } = new();

		[MemoryPackOrder(19)]
		public List<int> MakeList { get; set; } = new();

		[MemoryPackOrder(20)]
		public List<int> CompleteGuideIds { get; set; } = new();

		[MemoryPackOrder(21)]
		public List<KeyValuePairInt> DayFubenTimes { get; set; } = new();

		[MemoryPackOrder(22)]
		public List<KeyValuePair> MonsterRevives { get; set; } = new();

		[MemoryPackOrder(23)]
		public List<int> TowerRewardIds { get; set; } = new();

		[MemoryPackOrder(24)]
		public List<int> ChouKaRewardIds { get; set; } = new();

		[MemoryPackOrder(25)]
		public List<int> XiuLianRewardIds { get; set; } = new();

//购买过的神秘商品
		[MemoryPackOrder(26)]
		public List<KeyValuePairInt> MysteryItems { get; set; } = new();

//已开启的宝箱记录
		[MemoryPackOrder(27)]
		public List<KeyValuePair> OpenChestList { get; set; } = new();

		[MemoryPackOrder(28)]
		public List<KeyValuePairInt> MakeIdList { get; set; } = new();

//已通关的副本列表
		[MemoryPackOrder(29)]
		public List<FubenPassInfo> FubenPassList { get; set; } = new();

//每日道具使用限制
		[MemoryPackOrder(30)]
		public List<KeyValuePairInt> DayItemUse { get; set; } = new();

		[MemoryPackOrder(31)]
		public List<int> HorseIds { get; set; } = new();

//剧情副本每日刷新 global79
		[MemoryPackOrder(32)]
		public List<KeyValuePairInt> DayMonsters { get; set; } = new();

//随机精灵每日刷新 global80
		[MemoryPackOrder(33)]
		public List<int> DayJingLing { get; set; } = new();

		[MemoryPackOrder(34)]
		public long JiaYuanFund { get; set; }

		[MemoryPackOrder(35)]
		public long JiaYuanExp { get; set; }

		[MemoryPackOrder(36)]
		public int JiaYuanLv { get; set; }

		[MemoryPackOrder(37)]
		public int BaoShiDu { get; set; }

		[MemoryPackOrder(38)]
		public List<KeyValuePair> FirstWinSelf { get; set; } = new();

		[MemoryPackOrder(39)]
		public long UnionZiJin { get; set; }

		[MemoryPackOrder(40)]
		public int ServerMailIdCur { get; set; }

		[MemoryPackOrder(41)]
		public List<int> DiamondGetWay { get; set; } = new();

		[MemoryPackOrder(42)]
		public string DemonName { get; set; }

		[MemoryPackOrder(43)]
		public List<int> PetMingRewards { get; set; } = new();

		[MemoryPackOrder(44)]
		public List<int> OpenJingHeIds { get; set; } = new();

		[MemoryPackOrder(45)]
		public int SeasonLevel { get; set; }

		[MemoryPackOrder(46)]
		public int SeasonExp { get; set; }

		[MemoryPackOrder(47)]
		public long SeasonCoin { get; set; }

		[MemoryPackOrder(48)]
		public List<int> WelfareTaskRewards { get; set; } = new();

		[MemoryPackOrder(49)]
		public long CreateTime { get; set; }

		[MemoryPackOrder(50)]
		public List<int> WelfareInvestList { get; set; } = new();

		[MemoryPackOrder(51)]
		public List<int> RechargeReward { get; set; } = new();

		[MemoryPackOrder(52)]
		public List<int> UnionKeJiList { get; set; } = new();

		[MemoryPackOrder(53)]
		public List<int> PetExploreRewardIds { get; set; } = new();

		[MemoryPackOrder(54)]
		public List<int> PetHeXinExploreRewardIds { get; set; } = new();

		[MemoryPackOrder(55)]
		public string StallName { get; set; }

		[MemoryPackOrder(56)]
		public List<int> SingleRechargeIds { get; set; } = new();

		[MemoryPackOrder(57)]
		public List<int> SingleRewardIds { get; set; } = new();

		[MemoryPackOrder(58)]
		public List<int> ItemXiLianNumRewardIds { get; set; } = new();

		[MemoryPackOrder(59)]
		public List<int> DefeatedBossIds { get; set; } = new();

		[MemoryPackOrder(60)]
		public List<KeyValuePairInt> BuyStoreItems { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.AccInfoID = default;
			this.Name = default;
			this.Gold = default;
			this.Diamond = default;
			this.Lv = default;
			this.Exp = default;
			this.PiLao = default;
			this.Occ = default;
			this.OccTwo = default;
			this.Combat = default;
			this.RobotId = default;
			this.Sp = default;
			this.Vitality = default;
			this.RongYu = default;
			this.UnionName = default;
			this.UserId = default;
			this.GameSettingInfos.Clear();
			this.MakeList.Clear();
			this.CompleteGuideIds.Clear();
			this.DayFubenTimes.Clear();
			this.MonsterRevives.Clear();
			this.TowerRewardIds.Clear();
			this.ChouKaRewardIds.Clear();
			this.XiuLianRewardIds.Clear();
			this.MysteryItems.Clear();
			this.OpenChestList.Clear();
			this.MakeIdList.Clear();
			this.FubenPassList.Clear();
			this.DayItemUse.Clear();
			this.HorseIds.Clear();
			this.DayMonsters.Clear();
			this.DayJingLing.Clear();
			this.JiaYuanFund = default;
			this.JiaYuanExp = default;
			this.JiaYuanLv = default;
			this.BaoShiDu = default;
			this.FirstWinSelf.Clear();
			this.UnionZiJin = default;
			this.ServerMailIdCur = default;
			this.DiamondGetWay.Clear();
			this.DemonName = default;
			this.PetMingRewards.Clear();
			this.OpenJingHeIds.Clear();
			this.SeasonLevel = default;
			this.SeasonExp = default;
			this.SeasonCoin = default;
			this.WelfareTaskRewards.Clear();
			this.CreateTime = default;
			this.WelfareInvestList.Clear();
			this.RechargeReward.Clear();
			this.UnionKeJiList.Clear();
			this.PetExploreRewardIds.Clear();
			this.PetHeXinExploreRewardIds.Clear();
			this.StallName = default;
			this.SingleRechargeIds.Clear();
			this.SingleRewardIds.Clear();
			this.ItemXiLianNumRewardIds.Clear();
			this.DefeatedBossIds.Clear();
			this.BuyStoreItems.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RoleDataUpdate)]
	[MemoryPackable]
	public partial class M2C_RoleDataUpdate: MessageObject, IMessage
	{
		public static M2C_RoleDataUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RoleDataUpdate), isFromPool) as M2C_RoleDataUpdate; 
		}

		[MemoryPackOrder(0)]
		public int UpdateType { get; set; }

		[MemoryPackOrder(1)]
		public string UpdateTypeValue { get; set; }

		[MemoryPackOrder(2)]
		public long UpdateValueLong { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UpdateType = default;
			this.UpdateTypeValue = default;
			this.UpdateValueLong = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RoleDataBroadcast)]
	[MemoryPackable]
	public partial class M2C_RoleDataBroadcast: MessageObject, IMessage
	{
		public static M2C_RoleDataBroadcast Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RoleDataBroadcast), isFromPool) as M2C_RoleDataBroadcast; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int UpdateType { get; set; }

		[MemoryPackOrder(1)]
		public string UpdateTypeValue { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UpdateType = default;
			this.UpdateTypeValue = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//技能列表
	[Message(OuterMessage.SkillPro)]
	[MemoryPackable]
	public partial class SkillPro: MessageObject
	{
		public static SkillPro Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SkillPro), isFromPool) as SkillPro; 
		}

		[MemoryPackOrder(0)]
		public int SkillID { get; set; }

		[MemoryPackOrder(1)]
		public int SkillPosition { get; set; }

		[MemoryPackOrder(2)]
		public int SkillSetType { get; set; }

		[MemoryPackOrder(3)]
		public int Actived { get; set; }

		[MemoryPackOrder(4)]
		public int SkillSource { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SkillID = default;
			this.SkillPosition = default;
			this.SkillSetType = default;
			this.Actived = default;
			this.SkillSource = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//通过奖励
	[Message(OuterMessage.RewardItem)]
	[MemoryPackable]
	public partial class RewardItem: MessageObject
	{
		public static RewardItem Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RewardItem), isFromPool) as RewardItem; 
		}

		[MemoryPackOrder(0)]
		public int ItemID { get; set; }

		[MemoryPackOrder(1)]
		public int ItemNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ItemID = default;
			this.ItemNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.FubenPassInfo)]
	[MemoryPackable]
	public partial class FubenPassInfo: MessageObject
	{
		public static FubenPassInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(FubenPassInfo), isFromPool) as FubenPassInfo; 
		}

		[MemoryPackOrder(0)]
		public int FubenId { get; set; }

		[MemoryPackOrder(1)]
		public int Difficulty { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.FubenId = default;
			this.Difficulty = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_GMCommand)]
	[MemoryPackable]
	public partial class C2M_GMCommand: MessageObject, ILocationMessage
	{
		public static C2M_GMCommand Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GMCommand), isFromPool) as C2M_GMCommand; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string GMMsg { get; set; }

		[MemoryPackOrder(2)]
		public string Account { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.GMMsg = default;
			this.Account = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2C_ActivityInfoResponse))]
	[Message(OuterMessage.C2A_ActivityInfoRequest)]
	[MemoryPackable]
	public partial class C2A_ActivityInfoRequest: MessageObject, IActivityActorRequest
	{
		public static C2A_ActivityInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2A_ActivityInfoRequest), isFromPool) as C2A_ActivityInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ActivityType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ActivityType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.A2C_ActivityInfoResponse)]
	[MemoryPackable]
	public partial class A2C_ActivityInfoResponse: MessageObject, IActivityActorResponse
	{
		public static A2C_ActivityInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_ActivityInfoResponse), isFromPool) as A2C_ActivityInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public string ActivityContent { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ActivityContent = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2C_FirstWinInfoResponse))]
	[Message(OuterMessage.C2A_FirstWinInfoRequest)]
	[MemoryPackable]
	public partial class C2A_FirstWinInfoRequest: MessageObject, IActivityActorRequest
	{
		public static C2A_FirstWinInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2A_FirstWinInfoRequest), isFromPool) as C2A_FirstWinInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.A2C_FirstWinInfoResponse)]
	[MemoryPackable]
	public partial class A2C_FirstWinInfoResponse: MessageObject, IActivityActorResponse
	{
		public static A2C_FirstWinInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_FirstWinInfoResponse), isFromPool) as A2C_FirstWinInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<FirstWinInfo> FirstWinInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FirstWinInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2C_MysteryListResponse))]
	[Message(OuterMessage.C2A_MysteryListRequest)]
	[MemoryPackable]
	public partial class C2A_MysteryListRequest: MessageObject, IActivityActorRequest
	{
		public static C2A_MysteryListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2A_MysteryListRequest), isFromPool) as C2A_MysteryListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.A2C_MysteryListResponse)]
	[MemoryPackable]
	public partial class A2C_MysteryListResponse: MessageObject, IActivityActorResponse
	{
		public static A2C_MysteryListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_MysteryListResponse), isFromPool) as A2C_MysteryListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<MysteryItemInfo> MysteryItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MysteryItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2C_PetMingChanChuResponse))]
	[Message(OuterMessage.C2A_PetMingChanChuRequest)]
	[MemoryPackable]
	public partial class C2A_PetMingChanChuRequest: MessageObject, IActivityActorRequest
	{
		public static C2A_PetMingChanChuRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2A_PetMingChanChuRequest), isFromPool) as C2A_PetMingChanChuRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.A2C_PetMingChanChuResponse)]
	[MemoryPackable]
	public partial class A2C_PetMingChanChuResponse: MessageObject, IActivityActorResponse
	{
		public static A2C_PetMingChanChuResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_PetMingChanChuResponse), isFromPool) as A2C_PetMingChanChuResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2C_PetMingListResponse))]
	[Message(OuterMessage.C2A_PetMingListRequest)]
	[MemoryPackable]
	public partial class C2A_PetMingListRequest: MessageObject, IActivityActorRequest
	{
		public static C2A_PetMingListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2A_PetMingListRequest), isFromPool) as C2A_PetMingListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.A2C_PetMingListResponse)]
	[MemoryPackable]
	public partial class A2C_PetMingListResponse: MessageObject, IActivityActorResponse
	{
		public static A2C_PetMingListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_PetMingListResponse), isFromPool) as A2C_PetMingListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long ChanChu { get; set; }

		[MemoryPackOrder(1)]
		public List<KeyValuePairInt> PetMineExtend { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<PetMingPlayerInfo> PetMingPlayerInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ChanChu = default;
			this.PetMineExtend.Clear();
			this.PetMingPlayerInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RolePetInfo)]
	[MemoryPackable]
	public partial class RolePetInfo: MessageObject
	{
		public static RolePetInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RolePetInfo), isFromPool) as RolePetInfo; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int PetStatus { get; set; }

		[MemoryPackOrder(2)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(3)]
		public int PetLv { get; set; }

		[MemoryPackOrder(4)]
		public int Star { get; set; }

		[MemoryPackOrder(6)]
		public int PetExp { get; set; }

		[MemoryPackOrder(7)]
		public string PetName { get; set; }

		[MemoryPackOrder(8)]
		public bool IfBaby { get; set; }

		[MemoryPackOrder(9)]
		public int AddPropretyNum { get; set; }

		[MemoryPackOrder(10)]
		public string AddPropretyValue { get; set; }

		[MemoryPackOrder(11)]
		public int PetPingFen { get; set; }

		[MemoryPackOrder(12)]
		public int ZiZhi_Hp { get; set; }

		[MemoryPackOrder(13)]
		public int ZiZhi_Act { get; set; }

		[MemoryPackOrder(14)]
		public int ZiZhi_MageAct { get; set; }

		[MemoryPackOrder(15)]
		public int ZiZhi_Def { get; set; }

		[MemoryPackOrder(16)]
		public int ZiZhi_Adf { get; set; }

		[MemoryPackOrder(17)]
		public int ZiZhi_ActSpeed { get; set; }

		[MemoryPackOrder(18)]
		public float ZiZhi_ChengZhang { get; set; }

		[MemoryPackOrder(19)]
		public List<int> PetSkill { get; set; } = new();

		[MemoryPackOrder(20)]
		public int EquipID_1 { get; set; }

		[MemoryPackOrder(21)]
		public string EquipIDHide_1 { get; set; }

		[MemoryPackOrder(22)]
		public int EquipID_2 { get; set; }

		[MemoryPackOrder(23)]
		public string EquipIDHide_2 { get; set; }

		[MemoryPackOrder(24)]
		public int EquipID_3 { get; set; }

		[MemoryPackOrder(25)]
		public string EquipIDHide_3 { get; set; }

		[MemoryPackOrder(29)]
		public List<int> Ks { get; set; } = new();

		[MemoryPackOrder(30)]
		public List<long> Vs { get; set; } = new();

		[MemoryPackOrder(31)]
		public int RoleCamp { get; set; }

		[MemoryPackOrder(32)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(33)]
		public int SkinId { get; set; }

		[MemoryPackOrder(34)]
		public List<long> PetHeXinList { get; set; } = new();

		[MemoryPackOrder(37)]
		public int UpStageStatus { get; set; }

		[MemoryPackOrder(38)]
		public int ShouHuPos { get; set; }

		[MemoryPackOrder(39)]
		public bool IsProtect { get; set; }

		[MemoryPackOrder(40)]
		public List<long> PetEquipList { get; set; } = new();

		[MemoryPackOrder(41)]
		public List<int> LockSkill { get; set; } = new();

		[MemoryPackOrder(42)]
		public int Luckly { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.PetStatus = default;
			this.ConfigId = default;
			this.PetLv = default;
			this.Star = default;
			this.PetExp = default;
			this.PetName = default;
			this.IfBaby = default;
			this.AddPropretyNum = default;
			this.AddPropretyValue = default;
			this.PetPingFen = default;
			this.ZiZhi_Hp = default;
			this.ZiZhi_Act = default;
			this.ZiZhi_MageAct = default;
			this.ZiZhi_Def = default;
			this.ZiZhi_Adf = default;
			this.ZiZhi_ActSpeed = default;
			this.ZiZhi_ChengZhang = default;
			this.PetSkill.Clear();
			this.EquipID_1 = default;
			this.EquipIDHide_1 = default;
			this.EquipID_2 = default;
			this.EquipIDHide_2 = default;
			this.EquipID_3 = default;
			this.EquipIDHide_3 = default;
			this.Ks.Clear();
			this.Vs.Clear();
			this.RoleCamp = default;
			this.PlayerName = default;
			this.SkinId = default;
			this.PetHeXinList.Clear();
			this.UpStageStatus = default;
			this.ShouHuPos = default;
			this.IsProtect = default;
			this.PetEquipList.Clear();
			this.LockSkill.Clear();
			this.Luckly = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PetFubenInfo)]
	[MemoryPackable]
	public partial class PetFubenInfo: MessageObject
	{
		public static PetFubenInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PetFubenInfo), isFromPool) as PetFubenInfo; 
		}

		[MemoryPackOrder(0)]
		public int PetFubenId { get; set; }

		[MemoryPackOrder(1)]
		public int Star { get; set; }

		[MemoryPackOrder(2)]
		public int Reward { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PetFubenId = default;
			this.Star = default;
			this.Reward = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PetMingRecord)]
	[MemoryPackable]
	public partial class PetMingRecord: MessageObject
	{
		public static PetMingRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PetMingRecord), isFromPool) as PetMingRecord; 
		}

		[MemoryPackOrder(0)]
		public long UnitID { get; set; }

		[MemoryPackOrder(1)]
		public long Time { get; set; }

		[MemoryPackOrder(2)]
		public int MineType { get; set; }

		[MemoryPackOrder(3)]
		public int Position { get; set; }

		[MemoryPackOrder(4)]
		public string WinPlayer { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitID = default;
			this.Time = default;
			this.MineType = default;
			this.Position = default;
			this.WinPlayer = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//宠物更新
	[Message(OuterMessage.M2C_RolePetBagUpdate)]
	[MemoryPackable]
	public partial class M2C_RolePetBagUpdate: MessageObject, IMessage
	{
		public static M2C_RolePetBagUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetBagUpdate), isFromPool) as M2C_RolePetBagUpdate; 
		}

		[MemoryPackOrder(0)]
		public List<RolePetInfo> RolePetBag { get; set; } = new();

		[MemoryPackOrder(1)]
		public int UpdateMode { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RolePetBag.Clear();
			this.UpdateMode = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//宠物更新
	[Message(OuterMessage.M2C_PetListMessage)]
	[MemoryPackable]
	public partial class M2C_PetListMessage: MessageObject, IMessage
	{
		public static M2C_PetListMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetListMessage), isFromPool) as M2C_PetListMessage; 
		}

		[MemoryPackOrder(0)]
		public List<RolePetInfo> PetList { get; set; } = new();

		[MemoryPackOrder(1)]
		public long RemovePetId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PetList.Clear();
			this.RemovePetId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//宠物更新
	[Message(OuterMessage.M2C_RolePetUpdate)]
	[MemoryPackable]
	public partial class M2C_RolePetUpdate: MessageObject, IMessage
	{
		public static M2C_RolePetUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetUpdate), isFromPool) as M2C_RolePetUpdate; 
		}

		[MemoryPackOrder(0)]
		public List<RolePetInfo> PetInfoAdd { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<RolePetInfo> PetInfoUpdate { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<RolePetInfo> PetInfoDelete { get; set; } = new();

		[MemoryPackOrder(3)]
		public int GetWay { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PetInfoAdd.Clear();
			this.PetInfoUpdate.Clear();
			this.PetInfoDelete.Clear();
			this.GetWay = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetDataUpdate)]
	[MemoryPackable]
	public partial class M2C_PetDataUpdate: MessageObject, IMessage
	{
		public static M2C_PetDataUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetDataUpdate), isFromPool) as M2C_PetDataUpdate; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long PetId { get; set; }

		[MemoryPackOrder(1)]
		public int UpdateType { get; set; }

		[MemoryPackOrder(2)]
		public string UpdateTypeValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PetId = default;
			this.UpdateType = default;
			this.UpdateTypeValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetDataBroadcast)]
	[MemoryPackable]
	public partial class M2C_PetDataBroadcast: MessageObject, IMessage
	{
		public static M2C_PetDataBroadcast Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetDataBroadcast), isFromPool) as M2C_PetDataBroadcast; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long PetId { get; set; }

		[MemoryPackOrder(1)]
		public int UpdateType { get; set; }

		[MemoryPackOrder(2)]
		public string UpdateTypeValue { get; set; }

		[MemoryPackOrder(3)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PetId = default;
			this.UpdateType = default;
			this.UpdateTypeValue = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//道具[装备]更新
	[Message(OuterMessage.M2C_RoleBagUpdate)]
	[MemoryPackable]
	public partial class M2C_RoleBagUpdate: MessageObject, IMessage
	{
		public static M2C_RoleBagUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RoleBagUpdate), isFromPool) as M2C_RoleBagUpdate; 
		}

		[MemoryPackOrder(0)]
		public List<BagInfo> BagInfoAdd { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<BagInfo> BagInfoUpdate { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<BagInfo> BagInfoDelete { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.BagInfoAdd.Clear();
			this.BagInfoUpdate.Clear();
			this.BagInfoDelete.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BagInitResponse))]
	[Message(OuterMessage.C2M_BagInitRequest)]
	[MemoryPackable]
	public partial class C2M_BagInitRequest: MessageObject, ILocationRequest
	{
		public static C2M_BagInitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BagInitRequest), isFromPool) as C2M_BagInitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BagInitResponse)]
	[MemoryPackable]
	public partial class M2C_BagInitResponse: MessageObject, ILocationResponse
	{
		public static M2C_BagInitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BagInitResponse), isFromPool) as M2C_BagInitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<BagInfo> BagInfos { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> QiangHuaLevel { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<int> QiangHuaFails { get; set; } = new();

//int32 BagAddedCell = 4;
		[MemoryPackOrder(4)]
		public List<int> WarehouseAddedCell { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<int> FashionActiveIds { get; set; } = new();

		[MemoryPackOrder(6)]
		public List<int> FashionEquipList { get; set; } = new();

		[MemoryPackOrder(7)]
		public int SeasonJingHePlan { get; set; }

		[MemoryPackOrder(8)]
		public List<int> AdditionalCellNum { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.BagInfos.Clear();
			this.QiangHuaLevel.Clear();
			this.QiangHuaFails.Clear();
			this.WarehouseAddedCell.Clear();
			this.FashionActiveIds.Clear();
			this.FashionEquipList.Clear();
			this.SeasonJingHePlan = default;
			this.AdditionalCellNum.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//开启宝箱
	[ResponseType(nameof(M2C_OpenBoxResponse))]
	[Message(OuterMessage.C2M_OpenBoxRequest)]
	[MemoryPackable]
	public partial class C2M_OpenBoxRequest: MessageObject, ILocationRequest
	{
		public static C2M_OpenBoxRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_OpenBoxRequest), isFromPool) as C2M_OpenBoxRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_OpenBoxResponse)]
	[MemoryPackable]
	public partial class M2C_OpenBoxResponse: MessageObject, ILocationResponse
	{
		public static M2C_OpenBoxResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_OpenBoxResponse), isFromPool) as M2C_OpenBoxResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.DropInfo)]
	[MemoryPackable]
	public partial class DropInfo: MessageObject
	{
		public static DropInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(DropInfo), isFromPool) as DropInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public int ItemID { get; set; }

		[MemoryPackOrder(3)]
		public int ItemNum { get; set; }

		[MemoryPackOrder(4)]
		public float X { get; set; }

		[MemoryPackOrder(5)]
		public float Y { get; set; }

		[MemoryPackOrder(6)]
		public float Z { get; set; }

		[MemoryPackOrder(7)]
		public int DropType { get; set; }

		[MemoryPackOrder(8)]
		public int CellIndex { get; set; }

		[MemoryPackOrder(9)]
		public long BeKillId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.ItemID = default;
			this.ItemNum = default;
			this.X = default;
			this.Y = default;
			this.Z = default;
			this.DropType = default;
			this.CellIndex = default;
			this.BeKillId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//拾取道具
	[ResponseType(nameof(M2C_PickItemResponse))]
	[Message(OuterMessage.C2M_PickItemRequest)]
	[MemoryPackable]
	public partial class C2M_PickItemRequest: MessageObject, ILocationRequest
	{
		public static C2M_PickItemRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PickItemRequest), isFromPool) as C2M_PickItemRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<DropInfo> ItemIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ItemIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PickItemResponse)]
	[MemoryPackable]
	public partial class M2C_PickItemResponse: MessageObject, ILocationResponse
	{
		public static M2C_PickItemResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PickItemResponse), isFromPool) as M2C_PickItemResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<long> RemoveIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RemoveIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

// 装备增幅
	[ResponseType(nameof(M2C_EquipmentIncreaseResponse))]
	[Message(OuterMessage.C2M_EquipmentIncreaseRequest)]
	[MemoryPackable]
	public partial class C2M_EquipmentIncreaseRequest: MessageObject, ILocationRequest
	{
		public static C2M_EquipmentIncreaseRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_EquipmentIncreaseRequest), isFromPool) as C2M_EquipmentIncreaseRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public BagInfo EquipmentBagInfo { get; set; }

		[MemoryPackOrder(1)]
		public BagInfo ReelBagInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.EquipmentBagInfo = default;
			this.ReelBagInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_EquipmentIncreaseResponse)]
	[MemoryPackable]
	public partial class M2C_EquipmentIncreaseResponse: MessageObject, ILocationResponse
	{
		public static M2C_EquipmentIncreaseResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_EquipmentIncreaseResponse), isFromPool) as M2C_EquipmentIncreaseResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_FashionActiveResponse))]
	[Message(OuterMessage.C2M_FashionActiveRequest)]
	[MemoryPackable]
	public partial class C2M_FashionActiveRequest: MessageObject, ILocationRequest
	{
		public static C2M_FashionActiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_FashionActiveRequest), isFromPool) as C2M_FashionActiveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int FashionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.FashionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FashionActiveResponse)]
	[MemoryPackable]
	public partial class M2C_FashionActiveResponse: MessageObject, ILocationResponse
	{
		public static M2C_FashionActiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FashionActiveResponse), isFromPool) as M2C_FashionActiveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_FashionWearResponse))]
	[Message(OuterMessage.C2M_FashionWearRequest)]
	[MemoryPackable]
	public partial class C2M_FashionWearRequest: MessageObject, ILocationRequest
	{
		public static C2M_FashionWearRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_FashionWearRequest), isFromPool) as C2M_FashionWearRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int FashionId { get; set; }

		[MemoryPackOrder(1)]
		public int OperatateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.FashionId = default;
			this.OperatateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FashionWearResponse)]
	[MemoryPackable]
	public partial class M2C_FashionWearResponse: MessageObject, ILocationResponse
	{
		public static M2C_FashionWearResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FashionWearResponse), isFromPool) as M2C_FashionWearResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GemHeChengQuickResponse))]
//宝石一键合成
	[Message(OuterMessage.C2M_GemHeChengQuickRequest)]
	[MemoryPackable]
	public partial class C2M_GemHeChengQuickRequest: MessageObject, ILocationRequest
	{
		public static C2M_GemHeChengQuickRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GemHeChengQuickRequest), isFromPool) as C2M_GemHeChengQuickRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int LocType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.LocType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GemHeChengQuickResponse)]
	[MemoryPackable]
	public partial class M2C_GemHeChengQuickResponse: MessageObject, ILocationResponse
	{
		public static M2C_GemHeChengQuickResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GemHeChengQuickResponse), isFromPool) as M2C_GemHeChengQuickResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemBuyCellResponse))]
	[Message(OuterMessage.C2M_ItemBuyCellRequest)]
	[MemoryPackable]
	public partial class C2M_ItemBuyCellRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemBuyCellRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemBuyCellRequest), isFromPool) as C2M_ItemBuyCellRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemBuyCellResponse)]
	[MemoryPackable]
	public partial class M2C_ItemBuyCellResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemBuyCellResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemBuyCellResponse), isFromPool) as M2C_ItemBuyCellResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

//int32 BagAddedCell = 1;
		[MemoryPackOrder(1)]
		public List<int> WarehouseAddedCell { get; set; } = new();

		[MemoryPackOrder(2)]
		public string GetItem { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.WarehouseAddedCell.Clear();
			this.GetItem = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RoleOpenCangKuResponse))]
	[Message(OuterMessage.C2M_RoleOpenCangKuRequest)]
	[MemoryPackable]
	public partial class C2M_RoleOpenCangKuRequest: MessageObject, ILocationRequest
	{
		public static C2M_RoleOpenCangKuRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RoleOpenCangKuRequest), isFromPool) as C2M_RoleOpenCangKuRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RoleOpenCangKuResponse)]
	[MemoryPackable]
	public partial class M2C_RoleOpenCangKuResponse: MessageObject, ILocationResponse
	{
		public static M2C_RoleOpenCangKuResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RoleOpenCangKuResponse), isFromPool) as M2C_RoleOpenCangKuResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//销毁装备
	[ResponseType(nameof(M2C_ItemDestoryResponse))]
	[Message(OuterMessage.C2M_ItemDestoryRequest)]
	[MemoryPackable]
	public partial class C2M_ItemDestoryRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemDestoryRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemDestoryRequest), isFromPool) as C2M_ItemDestoryRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemDestoryResponse)]
	[MemoryPackable]
	public partial class M2C_ItemDestoryResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemDestoryResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemDestoryResponse), isFromPool) as M2C_ItemDestoryResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemEquipIndexResponse))]
//猎人穿戴装备特殊处理
	[Message(OuterMessage.C2M_ItemEquipIndexRequest)]
	[MemoryPackable]
	public partial class C2M_ItemEquipIndexRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemEquipIndexRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemEquipIndexRequest), isFromPool) as C2M_ItemEquipIndexRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int EquipIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.EquipIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemEquipIndexResponse)]
	[MemoryPackable]
	public partial class M2C_ItemEquipIndexResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemEquipIndexResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemEquipIndexResponse), isFromPool) as M2C_ItemEquipIndexResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//附魔属性
	[ResponseType(nameof(M2C_ItemFumoProResponse))]
	[Message(OuterMessage.C2M_ItemFumoProRequest)]
	[MemoryPackable]
	public partial class C2M_ItemFumoProRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemFumoProRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemFumoProRequest), isFromPool) as C2M_ItemFumoProRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperateType = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemFumoProResponse)]
	[MemoryPackable]
	public partial class M2C_ItemFumoProResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemFumoProResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemFumoProResponse), isFromPool) as M2C_ItemFumoProResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemFumoUseResponse))]
//附魔使用
	[Message(OuterMessage.C2M_ItemFumoUseRequest)]
	[MemoryPackable]
	public partial class C2M_ItemFumoUseRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemFumoUseRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemFumoUseRequest), isFromPool) as C2M_ItemFumoUseRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(2)]
		public List<HideProList> FuMoProList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			this.FuMoProList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemFumoUseResponse)]
	[MemoryPackable]
	public partial class M2C_ItemFumoUseResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemFumoUseResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemFumoUseResponse), isFromPool) as M2C_ItemFumoUseResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//回收装备
	[ResponseType(nameof(M2C_ItemHuiShouResponse))]
	[Message(OuterMessage.C2M_ItemHuiShouRequest)]
	[MemoryPackable]
	public partial class C2M_ItemHuiShouRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemHuiShouRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemHuiShouRequest), isFromPool) as C2M_ItemHuiShouRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public List<long> OperateBagID { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemHuiShouResponse)]
	[MemoryPackable]
	public partial class M2C_ItemHuiShouResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemHuiShouResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemHuiShouResponse), isFromPool) as M2C_ItemHuiShouResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//增幅转移
	[ResponseType(nameof(M2C_ItemIncreaseTransferResponse))]
	[Message(OuterMessage.C2M_ItemIncreaseTransferRequest)]
	[MemoryPackable]
	public partial class C2M_ItemIncreaseTransferRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemIncreaseTransferRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemIncreaseTransferRequest), isFromPool) as C2M_ItemIncreaseTransferRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long OperateBagID_1 { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID_2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID_1 = default;
			this.OperateBagID_2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemIncreaseTransferResponse)]
	[MemoryPackable]
	public partial class M2C_ItemIncreaseTransferResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemIncreaseTransferResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemIncreaseTransferResponse), isFromPool) as M2C_ItemIncreaseTransferResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//装备传承
	[ResponseType(nameof(M2C_ItemInheritResponse))]
	[Message(OuterMessage.C2M_ItemInheritRequest)]
	[MemoryPackable]
	public partial class C2M_ItemInheritRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemInheritRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemInheritRequest), isFromPool) as C2M_ItemInheritRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long OperateBagID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemInheritResponse)]
	[MemoryPackable]
	public partial class M2C_ItemInheritResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemInheritResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemInheritResponse), isFromPool) as M2C_ItemInheritResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public List<int> InheritSkills { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.InheritSkills.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//传承确认
	[ResponseType(nameof(M2C_ItemInheritSelectResponse))]
	[Message(OuterMessage.C2M_ItemInheritSelectRequest)]
	[MemoryPackable]
	public partial class C2M_ItemInheritSelectRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemInheritSelectRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemInheritSelectRequest), isFromPool) as C2M_ItemInheritSelectRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(1)]
		public List<int> InheritSkills { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID = default;
			this.InheritSkills.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemInheritSelectResponse)]
	[MemoryPackable]
	public partial class M2C_ItemInheritSelectResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemInheritSelectResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemInheritSelectResponse), isFromPool) as M2C_ItemInheritSelectResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//装备熔炼
	[ResponseType(nameof(M2C_ItemMeltingResponse))]
	[Message(OuterMessage.C2M_ItemMeltingRequest)]
	[MemoryPackable]
	public partial class C2M_ItemMeltingRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemMeltingRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemMeltingRequest), isFromPool) as C2M_ItemMeltingRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public List<long> OperateBagID { get; set; } = new();

		[MemoryPackOrder(2)]
		public int MakeType { get; set; }

		[MemoryPackOrder(3)]
		public int Plan { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID.Clear();
			this.MakeType = default;
			this.Plan = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemMeltingResponse)]
	[MemoryPackable]
	public partial class M2C_ItemMeltingResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemMeltingResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemMeltingResponse), isFromPool) as M2C_ItemMeltingResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//一键盘出售
	[ResponseType(nameof(M2C_ItemOneSellResponse))]
	[Message(OuterMessage.C2M_ItemOneSellRequest)]
	[MemoryPackable]
	public partial class C2M_ItemOneSellRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemOneSellRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemOneSellRequest), isFromPool) as C2M_ItemOneSellRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public List<long> BagInfoIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.BagInfoIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemOneSellResponse)]
	[MemoryPackable]
	public partial class M2C_ItemOneSellResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemOneSellResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemOneSellResponse), isFromPool) as M2C_ItemOneSellResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemOperateGemResponse))]
	[Message(OuterMessage.C2M_ItemOperateGemRequest)]
	[MemoryPackable]
	public partial class C2M_ItemOperateGemRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemOperateGemRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemOperateGemRequest), isFromPool) as C2M_ItemOperateGemRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(2)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemOperateGemResponse)]
	[MemoryPackable]
	public partial class M2C_ItemOperateGemResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemOperateGemResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemOperateGemResponse), isFromPool) as M2C_ItemOperateGemResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//穿戴装备
	[ResponseType(nameof(M2C_ItemOperateResponse))]
	[Message(OuterMessage.C2M_ItemOperateRequest)]
	[MemoryPackable]
	public partial class C2M_ItemOperateRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemOperateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemOperateRequest), isFromPool) as C2M_ItemOperateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(2)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemOperateResponse)]
	[MemoryPackable]
	public partial class M2C_ItemOperateResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemOperateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemOperateResponse), isFromPool) as M2C_ItemOperateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//猎人穿戴装备特殊处理
	[ResponseType(nameof(M2C_ItemOperateWearResponse))]
	[Message(OuterMessage.C2M_ItemOperateWearRequest)]
	[MemoryPackable]
	public partial class C2M_ItemOperateWearRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemOperateWearRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemOperateWearRequest), isFromPool) as C2M_ItemOperateWearRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(2)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemOperateWearResponse)]
	[MemoryPackable]
	public partial class M2C_ItemOperateWearResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemOperateWearResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemOperateWearResponse), isFromPool) as M2C_ItemOperateWearResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//装备锁定
	[ResponseType(nameof(M2C_ItemProtectResponse))]
	[Message(OuterMessage.C2M_ItemProtectRequest)]
	[MemoryPackable]
	public partial class C2M_ItemProtectRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemProtectRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemProtectRequest), isFromPool) as C2M_ItemProtectRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(1)]
		public bool IsProtect { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID = default;
			this.IsProtect = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemProtectResponse)]
	[MemoryPackable]
	public partial class M2C_ItemProtectResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemProtectResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemProtectResponse), isFromPool) as M2C_ItemProtectResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//强化槽位
	[ResponseType(nameof(M2C_ItemQiangHuaResponse))]
	[Message(OuterMessage.C2M_ItemQiangHuaRequest)]
	[MemoryPackable]
	public partial class C2M_ItemQiangHuaRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemQiangHuaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemQiangHuaRequest), isFromPool) as C2M_ItemQiangHuaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int WeiZhi { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.WeiZhi = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemQiangHuaResponse)]
	[MemoryPackable]
	public partial class M2C_ItemQiangHuaResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemQiangHuaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemQiangHuaResponse), isFromPool) as M2C_ItemQiangHuaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public int QiangHuaLevel { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.QiangHuaLevel = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//一键存放
	[ResponseType(nameof(M2C_ItemQuickPutResponse))]
	[Message(OuterMessage.C2M_ItemQuickPutRequest)]
	[MemoryPackable]
	public partial class C2M_ItemQuickPutRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemQuickPutRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemQuickPutRequest), isFromPool) as C2M_ItemQuickPutRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int HorseId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.HorseId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemQuickPutResponse)]
	[MemoryPackable]
	public partial class M2C_ItemQuickPutResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemQuickPutResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemQuickPutResponse), isFromPool) as M2C_ItemQuickPutResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//物品排序[通知服务器排序，暂时不需要返回]
	[Message(OuterMessage.C2M_ItemSortRequest)]
	[MemoryPackable]
	public partial class C2M_ItemSortRequest: MessageObject, ILocationMessage
	{
		public static C2M_ItemSortRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemSortRequest), isFromPool) as C2M_ItemSortRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemSplitResponse))]
	[Message(OuterMessage.C2M_ItemSplitRequest)]
	[MemoryPackable]
	public partial class C2M_ItemSplitRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemSplitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemSplitRequest), isFromPool) as C2M_ItemSplitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(2)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemSplitResponse)]
	[MemoryPackable]
	public partial class M2C_ItemSplitResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemSplitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemSplitResponse), isFromPool) as M2C_ItemSplitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//藏宝图开启
	[ResponseType(nameof(M2C_ItemTreasureOpenResponse))]
	[Message(OuterMessage.C2M_ItemTreasureOpenRequest)]
	[MemoryPackable]
	public partial class C2M_ItemTreasureOpenRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemTreasureOpenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemTreasureOpenRequest), isFromPool) as C2M_ItemTreasureOpenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(2)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemTreasureOpenResponse)]
	[MemoryPackable]
	public partial class M2C_ItemTreasureOpenResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemTreasureOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemTreasureOpenResponse), isFromPool) as M2C_ItemTreasureOpenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public string OperatePar { get; set; }

		[MemoryPackOrder(4)]
		public RewardItem ReardItem { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.OperatePar = default;
			this.ReardItem = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.SkillInfo)]
	[MemoryPackable]
	public partial class SkillInfo: MessageObject
	{
		public static SkillInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SkillInfo), isFromPool) as SkillInfo; 
		}

		[MemoryPackOrder(1)]
		public long TargetID { get; set; }

		[MemoryPackOrder(2)]
		public int TargetAngle { get; set; }

		[MemoryPackOrder(4)]
		public int WeaponSkillID { get; set; }

		[MemoryPackOrder(5)]
		public float PosX { get; set; }

		[MemoryPackOrder(6)]
		public float PosY { get; set; }

		[MemoryPackOrder(7)]
		public float PosZ { get; set; }

		[MemoryPackOrder(10)]
		public long SkillBeginTime { get; set; }

		[MemoryPackOrder(11)]
		public long SkillEndTime { get; set; }

		[MemoryPackOrder(12)]
		public float SingValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.TargetID = default;
			this.TargetAngle = default;
			this.WeaponSkillID = default;
			this.PosX = default;
			this.PosY = default;
			this.PosZ = default;
			this.SkillBeginTime = default;
			this.SkillEndTime = default;
			this.SingValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnitNumericListUpdate)]
	[MemoryPackable]
	public partial class M2C_UnitNumericListUpdate: MessageObject, IMessage
	{
		public static M2C_UnitNumericListUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitNumericListUpdate), isFromPool) as M2C_UnitNumericListUpdate; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitID { get; set; }

		[MemoryPackOrder(1)]
		public List<int> Ks { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<long> Vs { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitID = default;
			this.Ks.Clear();
			this.Vs.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_UserInfoInitResponse))]
	[Message(OuterMessage.C2M_UserInfoInitRequest)]
	[MemoryPackable]
	public partial class C2M_UserInfoInitRequest: MessageObject, ILocationRequest
	{
		public static C2M_UserInfoInitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UserInfoInitRequest), isFromPool) as C2M_UserInfoInitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UserInfoInitResponse)]
	[MemoryPackable]
	public partial class M2C_UserInfoInitResponse: MessageObject, ILocationResponse
	{
		public static M2C_UserInfoInitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UserInfoInitResponse), isFromPool) as M2C_UserInfoInitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public UserInfo UserInfo { get; set; }

		[MemoryPackOrder(2)]
		public List<KeyValuePair> ReddontList { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<KeyValuePairInt> TreasureInfo { get; set; } = new();

		[MemoryPackOrder(4)]
		public List<ShouJiChapterInfo> ShouJiChapterInfos { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<KeyValuePairInt> TitleList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.UserInfo = default;
			this.ReddontList.Clear();
			this.TreasureInfo.Clear();
			this.ShouJiChapterInfos.Clear();
			this.TitleList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.FriendInfo)]
	[MemoryPackable]
	public partial class FriendInfo: MessageObject
	{
		public static FriendInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(FriendInfo), isFromPool) as FriendInfo; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public int PlayerLevel { get; set; }

		[MemoryPackOrder(2)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(3)]
		public long OnLineTime { get; set; }

		[MemoryPackOrder(4)]
		public List<string> ChatMsgList { get; set; } = new();

		[MemoryPackOrder(5)]
		public int Occ { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.PlayerLevel = default;
			this.PlayerName = default;
			this.OnLineTime = default;
			this.ChatMsgList.Clear();
			this.Occ = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//好友申请回复
	[ResponseType(nameof(F2C_FriendApplyReplyResponse))]
	[Message(OuterMessage.C2F_FriendApplyReplyRequest)]
	[MemoryPackable]
	public partial class C2F_FriendApplyReplyRequest: MessageObject, IFriendActorRequest
	{
		public static C2F_FriendApplyReplyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_FriendApplyReplyRequest), isFromPool) as C2F_FriendApplyReplyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long FriendID { get; set; }

		[MemoryPackOrder(2)]
		public int ReplyCode { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.FriendID = default;
			this.ReplyCode = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_FriendApplyReplyResponse)]
	[MemoryPackable]
	public partial class F2C_FriendApplyReplyResponse: MessageObject, IFriendActorResponse
	{
		public static F2C_FriendApplyReplyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_FriendApplyReplyResponse), isFromPool) as F2C_FriendApplyReplyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//黑名单
	[ResponseType(nameof(F2C_FriendBlacklistResponse))]
	[Message(OuterMessage.C2F_FriendBlacklistRequest)]
	[MemoryPackable]
	public partial class C2F_FriendBlacklistRequest: MessageObject, IFriendActorRequest
	{
		public static C2F_FriendBlacklistRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_FriendBlacklistRequest), isFromPool) as C2F_FriendBlacklistRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long FriendId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperateType = default;
			this.UnitId = default;
			this.FriendId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_FriendBlacklistResponse)]
	[MemoryPackable]
	public partial class F2C_FriendBlacklistResponse: MessageObject, IFriendActorResponse
	{
		public static F2C_FriendBlacklistResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_FriendBlacklistResponse), isFromPool) as F2C_FriendBlacklistResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//好友申请
	[ResponseType(nameof(F2C_FriendApplyResponse))]
	[Message(OuterMessage.C2F_FriendApplyRequest)]
	[MemoryPackable]
	public partial class C2F_FriendApplyRequest: MessageObject, IFriendActorRequest
	{
		public static C2F_FriendApplyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_FriendApplyRequest), isFromPool) as C2F_FriendApplyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(0)]
		public FriendInfo FriendInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.FriendInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_FriendApplyResponse)]
	[MemoryPackable]
	public partial class F2C_FriendApplyResponse: MessageObject, IFriendActorResponse
	{
		public static F2C_FriendApplyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_FriendApplyResponse), isFromPool) as F2C_FriendApplyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(F2C_FriendChatRead))]
	[Message(OuterMessage.C2F_FriendChatRead)]
	[MemoryPackable]
	public partial class C2F_FriendChatRead: MessageObject, IFriendActorRequest
	{
		public static C2F_FriendChatRead Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_FriendChatRead), isFromPool) as C2F_FriendChatRead; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long FriendID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.FriendID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_FriendChatRead)]
	[MemoryPackable]
	public partial class F2C_FriendChatRead: MessageObject, IFriendActorResponse
	{
		public static F2C_FriendChatRead Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_FriendChatRead), isFromPool) as F2C_FriendChatRead; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//好友删除
	[ResponseType(nameof(F2C_FriendDeleteResponse))]
	[Message(OuterMessage.C2F_FriendDeleteRequest)]
	[MemoryPackable]
	public partial class C2F_FriendDeleteRequest: MessageObject, IFriendActorRequest
	{
		public static C2F_FriendDeleteRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_FriendDeleteRequest), isFromPool) as C2F_FriendDeleteRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long FriendID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.FriendID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_FriendDeleteResponse)]
	[MemoryPackable]
	public partial class F2C_FriendDeleteResponse: MessageObject, IFriendActorResponse
	{
		public static F2C_FriendDeleteResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_FriendDeleteResponse), isFromPool) as F2C_FriendDeleteResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//好友列表
	[ResponseType(nameof(F2C_FriendInfoResponse))]
	[Message(OuterMessage.C2F_FriendInfoRequest)]
	[MemoryPackable]
	public partial class C2F_FriendInfoRequest: MessageObject, IFriendActorRequest
	{
		public static C2F_FriendInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_FriendInfoRequest), isFromPool) as C2F_FriendInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_FriendInfoResponse)]
	[MemoryPackable]
	public partial class F2C_FriendInfoResponse: MessageObject, IFriendActorResponse
	{
		public static F2C_FriendInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_FriendInfoResponse), isFromPool) as F2C_FriendInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(1)]
		public List<FriendInfo> FriendList { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<FriendInfo> ApplyList { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<FriendInfo> Blacklist { get; set; } = new();

		[MemoryPackOrder(4)]
		public List<ChatInfo> FriendChats { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FriendList.Clear();
			this.ApplyList.Clear();
			this.Blacklist.Clear();
			this.FriendChats.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(F2C_WatchPlayerResponse))]
	[Message(OuterMessage.C2F_WatchPlayerRequest)]
	[MemoryPackable]
	public partial class C2F_WatchPlayerRequest: MessageObject, IFriendActorRequest
	{
		public static C2F_WatchPlayerRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_WatchPlayerRequest), isFromPool) as C2F_WatchPlayerRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public int WatchType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			this.WatchType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_WatchPlayerResponse)]
	[MemoryPackable]
	public partial class F2C_WatchPlayerResponse: MessageObject, IFriendActorResponse
	{
		public static F2C_WatchPlayerResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_WatchPlayerResponse), isFromPool) as F2C_WatchPlayerResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public string Name { get; set; }

		[MemoryPackOrder(1)]
		public int Lv { get; set; }

		[MemoryPackOrder(2)]
		public List<BagInfo> EquipList { get; set; } = new();

		[MemoryPackOrder(3)]
		public long TeamId { get; set; }

		[MemoryPackOrder(4)]
		public int Occ { get; set; }

		[MemoryPackOrder(6)]
		public List<RolePetInfo> RolePetInfos { get; set; } = new();

		[MemoryPackOrder(7)]
		public List<KeyValuePair> PetSkinList { get; set; } = new();

		[MemoryPackOrder(8)]
		public List<BagInfo> PetHeXinList { get; set; } = new();

		[MemoryPackOrder(10)]
		public List<int> Ks { get; set; } = new();

		[MemoryPackOrder(11)]
		public List<long> Vs { get; set; } = new();

		[MemoryPackOrder(12)]
		public List<int> FashionIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Name = default;
			this.Lv = default;
			this.EquipList.Clear();
			this.TeamId = default;
			this.Occ = default;
			this.RolePetInfos.Clear();
			this.PetSkinList.Clear();
			this.PetHeXinList.Clear();
			this.Ks.Clear();
			this.Vs.Clear();
			this.FashionIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ItemXiLianResult)]
	[MemoryPackable]
	public partial class ItemXiLianResult: MessageObject
	{
		public static ItemXiLianResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ItemXiLianResult), isFromPool) as ItemXiLianResult; 
		}

		[MemoryPackOrder(0)]
		public List<HideProList> XiLianHideProLists { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> HideSkillLists { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<HideProList> XiLianHideTeShuProLists { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.XiLianHideProLists.Clear();
			this.HideSkillLists.Clear();
			this.XiLianHideTeShuProLists.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FashionUpdate)]
	[MemoryPackable]
	public partial class M2C_FashionUpdate: MessageObject, IMessage
	{
		public static M2C_FashionUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FashionUpdate), isFromPool) as M2C_FashionUpdate; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitID { get; set; }

		[MemoryPackOrder(1)]
		public List<int> FashionEquipList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitID = default;
			this.FashionEquipList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SkillCmd))]
	[Message(OuterMessage.C2M_SkillCmd)]
	[MemoryPackable]
	public partial class C2M_SkillCmd: MessageObject, ILocationRequest
	{
		public static C2M_SkillCmd Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SkillCmd), isFromPool) as C2M_SkillCmd; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillID { get; set; }

		[MemoryPackOrder(1)]
		public long TargetID { get; set; }

		[MemoryPackOrder(2)]
		public int TargetAngle { get; set; }

		[MemoryPackOrder(3)]
		public float TargetDistance { get; set; }

		[MemoryPackOrder(4)]
		public int WeaponSkillID { get; set; }

		[MemoryPackOrder(5)]
		public int ItemId { get; set; }

		[MemoryPackOrder(6)]
		public float SingValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SkillID = default;
			this.TargetID = default;
			this.TargetAngle = default;
			this.TargetDistance = default;
			this.WeaponSkillID = default;
			this.ItemId = default;
			this.SingValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillCmd)]
	[MemoryPackable]
	public partial class M2C_SkillCmd: MessageObject, ILocationResponse
	{
		public static M2C_SkillCmd Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillCmd), isFromPool) as M2C_SkillCmd; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long CDEndTime { get; set; }

		[MemoryPackOrder(1)]
		public long PublicCDTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.CDEndTime = default;
			this.PublicCDTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnitUseSkill)]
	[MemoryPackable]
	public partial class M2C_UnitUseSkill: MessageObject, IMessage
	{
		public static M2C_UnitUseSkill Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitUseSkill), isFromPool) as M2C_UnitUseSkill; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(93)]
		public long UnitId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillID { get; set; }

		[MemoryPackOrder(2)]
		public int TargetAngle { get; set; }

		[MemoryPackOrder(3)]
		public List<SkillInfo> SkillInfos { get; set; } = new();

		[MemoryPackOrder(5)]
		public int ItemId { get; set; }

		[MemoryPackOrder(6)]
		public long CDEndTime { get; set; }

		[MemoryPackOrder(7)]
		public long PublicCDTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.SkillID = default;
			this.TargetAngle = default;
			this.SkillInfos.Clear();
			this.ItemId = default;
			this.CDEndTime = default;
			this.PublicCDTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.LifeShieldInfo)]
	[MemoryPackable]
	public partial class LifeShieldInfo: MessageObject
	{
		public static LifeShieldInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(LifeShieldInfo), isFromPool) as LifeShieldInfo; 
		}

		[MemoryPackOrder(0)]
		public int ShieldType { get; set; }

		[MemoryPackOrder(1)]
		public int Level { get; set; }

		[MemoryPackOrder(2)]
		public int Exp { get; set; }

		[MemoryPackOrder(3)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ShieldType = default;
			this.Level = default;
			this.Exp = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.SkillSetInfo)]
	[MemoryPackable]
	public partial class SkillSetInfo: MessageObject
	{
		public static SkillSetInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SkillSetInfo), isFromPool) as SkillSetInfo; 
		}

		[MemoryPackOrder(0)]
		public List<SkillPro> SkillList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> TianFuList { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<LifeShieldInfo> LifeShieldList { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<int> TianFuList1 { get; set; } = new();

		[MemoryPackOrder(4)]
		public int TianFuPlan { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SkillList.Clear();
			this.TianFuList.Clear();
			this.LifeShieldList.Clear();
			this.TianFuList1.Clear();
			this.TianFuPlan = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//技能天赋更新
	[Message(OuterMessage.M2C_SkillSetMessage)]
	[MemoryPackable]
	public partial class M2C_SkillSetMessage: MessageObject, IMessage
	{
		public static M2C_SkillSetMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillSetMessage), isFromPool) as M2C_SkillSetMessage; 
		}

		[MemoryPackOrder(0)]
		public SkillSetInfo SkillSetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SkillSetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ChangeOccTwoResponse))]
//转换职业
	[Message(OuterMessage.C2M_ChangeOccTwoRequest)]
	[MemoryPackable]
	public partial class C2M_ChangeOccTwoRequest: MessageObject, ILocationRequest
	{
		public static C2M_ChangeOccTwoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChangeOccTwoRequest), isFromPool) as C2M_ChangeOccTwoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OccTwoID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OccTwoID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChangeOccTwoResponse)]
	[MemoryPackable]
	public partial class M2C_ChangeOccTwoResponse: MessageObject, ILocationResponse
	{
		public static M2C_ChangeOccTwoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChangeOccTwoResponse), isFromPool) as M2C_ChangeOccTwoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Chat2C_GetChatResponse))]
	[Message(OuterMessage.C2Chat_GetChatRequest)]
	[MemoryPackable]
	public partial class C2Chat_GetChatRequest: MessageObject, IChatActorRequest
	{
		public static C2Chat_GetChatRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Chat_GetChatRequest), isFromPool) as C2Chat_GetChatRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Chat2C_GetChatResponse)]
	[MemoryPackable]
	public partial class Chat2C_GetChatResponse: MessageObject, IChatActorResponse
	{
		public static Chat2C_GetChatResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Chat2C_GetChatResponse), isFromPool) as Chat2C_GetChatResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<ChatInfo> ChatInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ChatInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(C2C_SendChatResponse))]
	[Message(OuterMessage.C2C_SendChatRequest)]
	[MemoryPackable]
	public partial class C2C_SendChatRequest: MessageObject, IChatActorRequest
	{
		public static C2C_SendChatRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_SendChatRequest), isFromPool) as C2C_SendChatRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public ChatInfo ChatInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChatInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2C_SendChatResponse)]
	[MemoryPackable]
	public partial class C2C_SendChatResponse: MessageObject, IChatActorResponse
	{
		public static C2C_SendChatResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_SendChatResponse), isFromPool) as C2C_SendChatResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public string ChatMsg { get; set; }

		[MemoryPackOrder(1)]
		public int ChannelId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ChatMsg = default;
			this.ChannelId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2C_SyncChatInfo)]
	[MemoryPackable]
	public partial class C2C_SyncChatInfo: MessageObject, IMessage
	{
		public static C2C_SyncChatInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_SyncChatInfo), isFromPool) as C2C_SyncChatInfo; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public ChatInfo ChatInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChatInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//成就进度
	[Message(OuterMessage.ChengJiuInfo)]
	[MemoryPackable]
	public partial class ChengJiuInfo: MessageObject
	{
		public static ChengJiuInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ChengJiuInfo), isFromPool) as ChengJiuInfo; 
		}

		[MemoryPackOrder(0)]
		public int ChengJiuID { get; set; }

		[MemoryPackOrder(1)]
		public int ChengJiuProgess { get; set; }

		[MemoryPackOrder(2)]
		public long ChengJiuProgessLong { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ChengJiuID = default;
			this.ChengJiuProgess = default;
			this.ChengJiuProgessLong = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//激活成就
	[Message(OuterMessage.M2C_ChengJiuActiveMessage)]
	[MemoryPackable]
	public partial class M2C_ChengJiuActiveMessage: MessageObject, IMessage
	{
		public static M2C_ChengJiuActiveMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChengJiuActiveMessage), isFromPool) as M2C_ChengJiuActiveMessage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int ChengJiuId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ChengJiuId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//任务列表
	[Message(OuterMessage.TaskPro)]
	[MemoryPackable]
	public partial class TaskPro: MessageObject
	{
		public static TaskPro Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(TaskPro), isFromPool) as TaskPro; 
		}

		[MemoryPackOrder(0)]
		public int taskID { get; set; }

		[MemoryPackOrder(1)]
		public int taskTargetNum_1 { get; set; }

		[MemoryPackOrder(4)]
		public int taskTargetNum_2 { get; set; }

		[MemoryPackOrder(5)]
		public int taskTargetNum_3 { get; set; }

		[MemoryPackOrder(2)]
		public int taskStatus { get; set; }

		[MemoryPackOrder(3)]
		public int TrackStatus { get; set; }

		[MemoryPackOrder(6)]
		public int FubenId { get; set; }

		[MemoryPackOrder(7)]
		public int WaveId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.taskID = default;
			this.taskTargetNum_1 = default;
			this.taskTargetNum_2 = default;
			this.taskTargetNum_3 = default;
			this.taskStatus = default;
			this.TrackStatus = default;
			this.FubenId = default;
			this.WaveId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskCountryUpdate)]
	[MemoryPackable]
	public partial class M2C_TaskCountryUpdate: MessageObject, IMessage
	{
		public static M2C_TaskCountryUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskCountryUpdate), isFromPool) as M2C_TaskCountryUpdate; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int UpdateMode { get; set; }

		[MemoryPackOrder(1)]
		public List<TaskPro> TaskCountryList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.ActorId = default;
			this.UpdateMode = default;
			this.TaskCountryList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskUpdate)]
	[MemoryPackable]
	public partial class M2C_TaskUpdate: MessageObject, IMessage
	{
		public static M2C_TaskUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskUpdate), isFromPool) as M2C_TaskUpdate; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<TaskPro> RoleTaskList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<TaskPro> DayTaskList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.ActorId = default;
			this.RoleTaskList.Clear();
			this.DayTaskList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TianFuActiveResponse))]
	[Message(OuterMessage.C2M_TianFuActiveRequest)]
	[MemoryPackable]
	public partial class C2M_TianFuActiveRequest: MessageObject, ILocationRequest
	{
		public static C2M_TianFuActiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TianFuActiveRequest), isFromPool) as C2M_TianFuActiveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int TianFuId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TianFuId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TianFuActiveResponse)]
	[MemoryPackable]
	public partial class M2C_TianFuActiveResponse: MessageObject, ILocationResponse
	{
		public static M2C_TianFuActiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TianFuActiveResponse), isFromPool) as M2C_TianFuActiveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SkillSet))]
//技能设置
	[Message(OuterMessage.C2M_SkillSet)]
	[MemoryPackable]
	public partial class C2M_SkillSet: MessageObject, ILocationRequest
	{
		public static C2M_SkillSet Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SkillSet), isFromPool) as C2M_SkillSet; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillID { get; set; }

		[MemoryPackOrder(1)]
		public int Position { get; set; }

		[MemoryPackOrder(2)]
		public int SkillType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SkillID = default;
			this.Position = default;
			this.SkillType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillSet)]
	[MemoryPackable]
	public partial class M2C_SkillSet: MessageObject, ILocationResponse
	{
		public static M2C_SkillSet Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillSet), isFromPool) as M2C_SkillSet; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//提交任务
	[ResponseType(nameof(M2C_TaskCommitResponse))]
	[Message(OuterMessage.C2M_TaskCommitRequest)]
	[MemoryPackable]
	public partial class C2M_TaskCommitRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskCommitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskCommitRequest), isFromPool) as C2M_TaskCommitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int TaskId { get; set; }

		[MemoryPackOrder(1)]
		public long BagInfoID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TaskId = default;
			this.BagInfoID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskCommitResponse)]
	[MemoryPackable]
	public partial class M2C_TaskCommitResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskCommitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskCommitResponse), isFromPool) as M2C_TaskCommitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> RoleComoleteTaskList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RoleComoleteTaskList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//提交任务
	[ResponseType(nameof(M2C_CommitTaskCountryResponse))]
	[Message(OuterMessage.C2M_CommitTaskCountryRequest)]
	[MemoryPackable]
	public partial class C2M_CommitTaskCountryRequest: MessageObject, ILocationRequest
	{
		public static C2M_CommitTaskCountryRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_CommitTaskCountryRequest), isFromPool) as C2M_CommitTaskCountryRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int TaskId { get; set; }

		[MemoryPackOrder(1)]
		public long BagInfoID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TaskId = default;
			this.BagInfoID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CommitTaskCountryResponse)]
	[MemoryPackable]
	public partial class M2C_CommitTaskCountryResponse: MessageObject, ILocationResponse
	{
		public static M2C_CommitTaskCountryResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CommitTaskCountryResponse), isFromPool) as M2C_CommitTaskCountryResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//每日活跃
	[ResponseType(nameof(M2C_TaskCountryInitResponse))]
	[Message(OuterMessage.C2M_TaskCountryInitRequest)]
	[MemoryPackable]
	public partial class C2M_TaskCountryInitRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskCountryInitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskCountryInitRequest), isFromPool) as C2M_TaskCountryInitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskCountryInitResponse)]
	[MemoryPackable]
	public partial class M2C_TaskCountryInitResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskCountryInitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskCountryInitResponse), isFromPool) as M2C_TaskCountryInitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<TaskPro> TaskCountryList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> ReceiveHuoYueIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TaskCountryList.Clear();
			this.ReceiveHuoYueIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//接取任务
	[ResponseType(nameof(M2C_TaskGetResponse))]
	[Message(OuterMessage.C2M_TaskGetRequest)]
	[MemoryPackable]
	public partial class C2M_TaskGetRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskGetRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskGetRequest), isFromPool) as C2M_TaskGetRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int TaskId { get; set; }

		[MemoryPackOrder(1)]
		public int TaskStatus { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TaskId = default;
			this.TaskStatus = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskGetResponse)]
	[MemoryPackable]
	public partial class M2C_TaskGetResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskGetResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskGetResponse), isFromPool) as M2C_TaskGetResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public TaskPro TaskPro { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TaskPro = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//放弃任务
	[ResponseType(nameof(M2C_TaskGiveUpResponse))]
	[Message(OuterMessage.C2M_TaskGiveUpRequest)]
	[MemoryPackable]
	public partial class C2M_TaskGiveUpRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskGiveUpRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskGiveUpRequest), isFromPool) as C2M_TaskGiveUpRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int TaskId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TaskId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskGiveUpResponse)]
	[MemoryPackable]
	public partial class M2C_TaskGiveUpResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskGiveUpResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskGiveUpResponse), isFromPool) as M2C_TaskGiveUpResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//活跃宝箱
	[ResponseType(nameof(M2C_TaskHuoYueRewardResponse))]
	[Message(OuterMessage.C2M_TaskHuoYueRewardRequest)]
	[MemoryPackable]
	public partial class C2M_TaskHuoYueRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskHuoYueRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskHuoYueRewardRequest), isFromPool) as C2M_TaskHuoYueRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int HuoYueId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.HuoYueId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskHuoYueRewardResponse)]
	[MemoryPackable]
	public partial class M2C_TaskHuoYueRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskHuoYueRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskHuoYueRewardResponse), isFromPool) as M2C_TaskHuoYueRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//任务列表
	[ResponseType(nameof(M2C_TaskInitResponse))]
	[Message(OuterMessage.C2M_TaskInitRequest)]
	[MemoryPackable]
	public partial class C2M_TaskInitRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskInitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskInitRequest), isFromPool) as C2M_TaskInitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskInitResponse)]
	[MemoryPackable]
	public partial class M2C_TaskInitResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskInitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskInitResponse), isFromPool) as M2C_TaskInitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<TaskPro> RoleTaskList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> RoleComoleteTaskList { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<TaskPro> TaskCountryList { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<int> ReceiveHuoYueIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RoleTaskList.Clear();
			this.RoleComoleteTaskList.Clear();
			this.TaskCountryList.Clear();
			this.ReceiveHuoYueIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//任务通知【目前用于对话完成】
	[ResponseType(nameof(M2C_TaskNoticeResponse))]
	[Message(OuterMessage.C2M_TaskNoticeRequest)]
	[MemoryPackable]
	public partial class C2M_TaskNoticeRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskNoticeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskNoticeRequest), isFromPool) as C2M_TaskNoticeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int TaskId { get; set; }

		[MemoryPackOrder(1)]
		public int TaskStatus { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TaskId = default;
			this.TaskStatus = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskNoticeResponse)]
	[MemoryPackable]
	public partial class M2C_TaskNoticeResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskNoticeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskNoticeResponse), isFromPool) as M2C_TaskNoticeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TaskOnLoginResponse))]
	[Message(OuterMessage.C2M_TaskOnLoginRequest)]
	[MemoryPackable]
	public partial class C2M_TaskOnLoginRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskOnLoginRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskOnLoginRequest), isFromPool) as C2M_TaskOnLoginRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskOnLoginResponse)]
	[MemoryPackable]
	public partial class M2C_TaskOnLoginResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskOnLoginResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskOnLoginResponse), isFromPool) as M2C_TaskOnLoginResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//任务追踪
	[ResponseType(nameof(M2C_TaskTrackResponse))]
	[Message(OuterMessage.C2M_TaskTrackRequest)]
	[MemoryPackable]
	public partial class C2M_TaskTrackRequest: MessageObject, ILocationRequest
	{
		public static C2M_TaskTrackRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TaskTrackRequest), isFromPool) as C2M_TaskTrackRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int TaskId { get; set; }

		[MemoryPackOrder(1)]
		public int TrackStatus { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TaskId = default;
			this.TrackStatus = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TaskTrackResponse)]
	[MemoryPackable]
	public partial class M2C_TaskTrackResponse: MessageObject, ILocationResponse
	{
		public static M2C_TaskTrackResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TaskTrackResponse), isFromPool) as M2C_TaskTrackResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SkillInitResponse))]
//技能升级
	[Message(OuterMessage.C2M_SkillInitRequest)]
	[MemoryPackable]
	public partial class C2M_SkillInitRequest: MessageObject, ILocationRequest
	{
		public static C2M_SkillInitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SkillInitRequest), isFromPool) as C2M_SkillInitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillInitResponse)]
	[MemoryPackable]
	public partial class M2C_SkillInitResponse: MessageObject, ILocationResponse
	{
		public static M2C_SkillInitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillInitResponse), isFromPool) as M2C_SkillInitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public SkillSetInfo SkillSetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.SkillSetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//技能打断
	[Message(OuterMessage.C2M_SkillInterruptRequest)]
	[MemoryPackable]
	public partial class C2M_SkillInterruptRequest: MessageObject, ILocationMessage
	{
		public static C2M_SkillInterruptRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SkillInterruptRequest), isFromPool) as C2M_SkillInterruptRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SkillID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillInterruptResult)]
	[MemoryPackable]
	public partial class M2C_SkillInterruptResult: MessageObject, IMessage
	{
		public static M2C_SkillInterruptResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillInterruptResult), isFromPool) as M2C_SkillInterruptResult; 
		}

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int SkillId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActorId = default;
			this.UnitId = default;
			this.SkillId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SkillJueXingResponse))]
	[Message(OuterMessage.C2M_SkillJueXingRequest)]
	[MemoryPackable]
	public partial class C2M_SkillJueXingRequest: MessageObject, ILocationRequest
	{
		public static C2M_SkillJueXingRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SkillJueXingRequest), isFromPool) as C2M_SkillJueXingRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int JueXingId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.JueXingId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillJueXingResponse)]
	[MemoryPackable]
	public partial class M2C_SkillJueXingResponse: MessageObject, ILocationResponse
	{
		public static M2C_SkillJueXingResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillJueXingResponse), isFromPool) as M2C_SkillJueXingResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SkillOperation))]
//技能操作
	[Message(OuterMessage.C2M_SkillOperation)]
	[MemoryPackable]
	public partial class C2M_SkillOperation: MessageObject, ILocationRequest
	{
		public static C2M_SkillOperation Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SkillOperation), isFromPool) as C2M_SkillOperation; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillID { get; set; }

		[MemoryPackOrder(2)]
		public int OperationType { get; set; }

		[MemoryPackOrder(3)]
		public string OperationValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SkillID = default;
			this.OperationType = default;
			this.OperationValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillOperation)]
	[MemoryPackable]
	public partial class M2C_SkillOperation: MessageObject, ILocationResponse
	{
		public static M2C_SkillOperation Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillOperation), isFromPool) as M2C_SkillOperation; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SkillUp))]
//技能升级
	[Message(OuterMessage.C2M_SkillUp)]
	[MemoryPackable]
	public partial class C2M_SkillUp: MessageObject, ILocationRequest
	{
		public static C2M_SkillUp Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SkillUp), isFromPool) as C2M_SkillUp; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SkillID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillUp)]
	[MemoryPackable]
	public partial class M2C_SkillUp: MessageObject, ILocationResponse
	{
		public static M2C_SkillUp Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillUp), isFromPool) as M2C_SkillUp; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public int NewSkillID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.NewSkillID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_LifeShieldCostResponse))]
	[Message(OuterMessage.C2M_LifeShieldCostRequest)]
	[MemoryPackable]
	public partial class C2M_LifeShieldCostRequest: MessageObject, ILocationRequest
	{
		public static C2M_LifeShieldCostRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_LifeShieldCostRequest), isFromPool) as C2M_LifeShieldCostRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public List<long> OperateBagID { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.OperateBagID.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_LifeShieldCostResponse)]
	[MemoryPackable]
	public partial class M2C_LifeShieldCostResponse: MessageObject, ILocationResponse
	{
		public static M2C_LifeShieldCostResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_LifeShieldCostResponse), isFromPool) as M2C_LifeShieldCostResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<LifeShieldInfo> ShieldList { get; set; } = new();

		[MemoryPackOrder(1)]
		public int AddExp { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ShieldList.Clear();
			this.AddExp = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TianFuPlanResponse))]
	[Message(OuterMessage.C2M_TianFuPlanRequest)]
	[MemoryPackable]
	public partial class C2M_TianFuPlanRequest: MessageObject, ILocationRequest
	{
		public static C2M_TianFuPlanRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TianFuPlanRequest), isFromPool) as C2M_TianFuPlanRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int TianFuPlan { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TianFuPlan = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TianFuPlanResponse)]
	[MemoryPackable]
	public partial class M2C_TianFuPlanResponse: MessageObject, ILocationResponse
	{
		public static M2C_TianFuPlanResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TianFuPlanResponse), isFromPool) as M2C_TianFuPlanResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//终止技能
	[Message(OuterMessage.M2C_UnitFinishSkill)]
	[MemoryPackable]
	public partial class M2C_UnitFinishSkill: MessageObject, IMessage
	{
		public static M2C_UnitFinishSkill Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitFinishSkill), isFromPool) as M2C_UnitFinishSkill; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RoleAddPointResponse))]
	[Message(OuterMessage.C2M_RoleAddPointRequest)]
	[MemoryPackable]
	public partial class C2M_RoleAddPointRequest: MessageObject, ILocationRequest
	{
		public static C2M_RoleAddPointRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RoleAddPointRequest), isFromPool) as C2M_RoleAddPointRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(5)]
		public List<int> PointList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PointList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RoleAddPointResponse)]
	[MemoryPackable]
	public partial class M2C_RoleAddPointResponse: MessageObject, ILocationResponse
	{
		public static M2C_RoleAddPointResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RoleAddPointResponse), isFromPool) as M2C_RoleAddPointResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnitNumericUpdate)]
	[MemoryPackable]
	public partial class M2C_UnitNumericUpdate: MessageObject, IMessage
	{
		public static M2C_UnitNumericUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitNumericUpdate), isFromPool) as M2C_UnitNumericUpdate; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(93)]
		public long UnitId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillId { get; set; }

		[MemoryPackOrder(1)]
		public int NumericType { get; set; }

		[MemoryPackOrder(2)]
		public long OldValue { get; set; }

		[MemoryPackOrder(3)]
		public long NewValue { get; set; }

		[MemoryPackOrder(4)]
		public int DamgeType { get; set; }

		[MemoryPackOrder(5)]
		public long AttackId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.SkillId = default;
			this.NumericType = default;
			this.OldValue = default;
			this.NewValue = default;
			this.DamgeType = default;
			this.AttackId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ShouJiChapterInfo)]
	[MemoryPackable]
	public partial class ShouJiChapterInfo: MessageObject
	{
		public static ShouJiChapterInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ShouJiChapterInfo), isFromPool) as ShouJiChapterInfo; 
		}

		[MemoryPackOrder(0)]
		public int ChapterId { get; set; }

		[MemoryPackOrder(1)]
		public int StarNum { get; set; }

		[MemoryPackOrder(2)]
		public int RewardInfo { get; set; }

		[MemoryPackOrder(3)]
		public List<int> ShouJiItemList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ChapterId = default;
			this.StarNum = default;
			this.RewardInfo = default;
			this.ShouJiItemList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanRecord)]
	[MemoryPackable]
	public partial class JiaYuanRecord: MessageObject
	{
		public static JiaYuanRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanRecord), isFromPool) as JiaYuanRecord; 
		}

		[MemoryPackOrder(0)]
		public long Time { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public int OperateType { get; set; }

		[MemoryPackOrder(3)]
		public int OperateId { get; set; }

		[MemoryPackOrder(6)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Time = default;
			this.PlayerName = default;
			this.OperateType = default;
			this.OperateId = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanOperate)]
	[MemoryPackable]
	public partial class JiaYuanOperate: MessageObject
	{
		public static JiaYuanOperate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanOperate), isFromPool) as JiaYuanOperate; 
		}

		[MemoryPackOrder(0)]
		public long Time { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public int OperateType { get; set; }

		[MemoryPackOrder(3)]
		public int OperateId { get; set; }

		[MemoryPackOrder(4)]
		public string OperatePar { get; set; }

		[MemoryPackOrder(5)]
		public long UnitId { get; set; }

		[MemoryPackOrder(6)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Time = default;
			this.PlayerName = default;
			this.OperateType = default;
			this.OperateId = default;
			this.OperatePar = default;
			this.UnitId = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanPurchaseItem)]
	[MemoryPackable]
	public partial class JiaYuanPurchaseItem: MessageObject
	{
		public static JiaYuanPurchaseItem Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanPurchaseItem), isFromPool) as JiaYuanPurchaseItem; 
		}

		[MemoryPackOrder(0)]
		public int ItemID { get; set; }

		[MemoryPackOrder(1)]
		public int BuyZiJin { get; set; }

		[MemoryPackOrder(2)]
		public long MakeTime { get; set; }

		[MemoryPackOrder(3)]
		public int LeftNum { get; set; }

		[MemoryPackOrder(4)]
		public int PurchaseId { get; set; }

		[MemoryPackOrder(5)]
		public long EndTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ItemID = default;
			this.BuyZiJin = default;
			this.MakeTime = default;
			this.LeftNum = default;
			this.PurchaseId = default;
			this.EndTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanPlant)]
	[MemoryPackable]
	public partial class JiaYuanPlant: MessageObject
	{
		public static JiaYuanPlant Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanPlant), isFromPool) as JiaYuanPlant; 
		}

		[MemoryPackOrder(0)]
		public int CellIndex { get; set; }

		[MemoryPackOrder(1)]
		public int ItemId { get; set; }

		[MemoryPackOrder(2)]
		public long StartTime { get; set; }

		[MemoryPackOrder(3)]
		public int GatherNumber { get; set; }

		[MemoryPackOrder(4)]
		public long GatherLastTime { get; set; }

		[MemoryPackOrder(5)]
		public long UnitId { get; set; }

		[MemoryPackOrder(6)]
		public int StealNumber { get; set; }

		[MemoryPackOrder(7)]
		public List<JiaYuanRecord> GatherRecord { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.CellIndex = default;
			this.ItemId = default;
			this.StartTime = default;
			this.GatherNumber = default;
			this.GatherLastTime = default;
			this.UnitId = default;
			this.StealNumber = default;
			this.GatherRecord.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanPastures)]
	[MemoryPackable]
	public partial class JiaYuanPastures: MessageObject
	{
		public static JiaYuanPastures Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanPastures), isFromPool) as JiaYuanPastures; 
		}

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public long StartTime { get; set; }

		[MemoryPackOrder(3)]
		public int GatherNumber { get; set; }

		[MemoryPackOrder(4)]
		public long GatherLastTime { get; set; }

		[MemoryPackOrder(5)]
		public long UnitId { get; set; }

		[MemoryPackOrder(6)]
		public int StealNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ConfigId = default;
			this.StartTime = default;
			this.GatherNumber = default;
			this.GatherLastTime = default;
			this.UnitId = default;
			this.StealNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanMonster)]
	[MemoryPackable]
	public partial class JiaYuanMonster: MessageObject
	{
		public static JiaYuanMonster Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanMonster), isFromPool) as JiaYuanMonster; 
		}

		[MemoryPackOrder(0)]
		public long unitId { get; set; }

		[MemoryPackOrder(1)]
		public float x { get; set; }

		[MemoryPackOrder(2)]
		public float y { get; set; }

		[MemoryPackOrder(3)]
		public float z { get; set; }

		[MemoryPackOrder(4)]
		public long BornTime { get; set; }

		[MemoryPackOrder(5)]
		public int ConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.unitId = default;
			this.x = default;
			this.y = default;
			this.z = default;
			this.BornTime = default;
			this.ConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanPet)]
	[MemoryPackable]
	public partial class JiaYuanPet: MessageObject
	{
		public static JiaYuanPet Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanPet), isFromPool) as JiaYuanPet; 
		}

		[MemoryPackOrder(0)]
		public long unitId { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public long TotalExp { get; set; }

		[MemoryPackOrder(3)]
		public long CurExp { get; set; }

		[MemoryPackOrder(4)]
		public long StartTime { get; set; }

		[MemoryPackOrder(5)]
		public int MoodValue { get; set; }

		[MemoryPackOrder(6)]
		public int PetLv { get; set; }

		[MemoryPackOrder(7)]
		public long LastExpTime { get; set; }

		[MemoryPackOrder(8)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(9)]
		public string PetName { get; set; }

		[MemoryPackOrder(10)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.unitId = default;
			this.ConfigId = default;
			this.TotalExp = default;
			this.CurExp = default;
			this.StartTime = default;
			this.MoodValue = default;
			this.PetLv = default;
			this.LastExpTime = default;
			this.PlayerName = default;
			this.PetName = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetList))]
	[Message(OuterMessage.C2M_RolePetList)]
	[MemoryPackable]
	public partial class C2M_RolePetList: MessageObject, ILocationRequest
	{
		public static C2M_RolePetList Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetList), isFromPool) as C2M_RolePetList; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetList)]
	[MemoryPackable]
	public partial class M2C_RolePetList: MessageObject, ILocationResponse
	{
		public static M2C_RolePetList Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetList), isFromPool) as M2C_RolePetList; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<RolePetInfo> RolePetInfos { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<long> TeamPetList { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<KeyValuePairInt> RolePetEggs { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<long> PetFormations { get; set; } = new();

		[MemoryPackOrder(4)]
		public List<PetFubenInfo> PetFubenInfos { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<KeyValuePair> PetSkinList { get; set; } = new();

		[MemoryPackOrder(6)]
		public int PetFubeRewardId { get; set; }

		[MemoryPackOrder(7)]
		public List<long> PetShouHuList { get; set; } = new();

		[MemoryPackOrder(8)]
		public int PetShouHuActive { get; set; }

		[MemoryPackOrder(9)]
		public List<int> PetCangKuOpen { get; set; } = new();

		[MemoryPackOrder(10)]
		public List<long> PetMingList { get; set; } = new();

		[MemoryPackOrder(11)]
		public List<long> PetMingPosition { get; set; } = new();

		[MemoryPackOrder(12)]
		public List<RolePetInfo> RolePetBag { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetInfos.Clear();
			this.TeamPetList.Clear();
			this.RolePetEggs.Clear();
			this.PetFormations.Clear();
			this.PetFubenInfos.Clear();
			this.PetSkinList.Clear();
			this.PetFubeRewardId = default;
			this.PetShouHuList.Clear();
			this.PetShouHuActive = default;
			this.PetCangKuOpen.Clear();
			this.PetMingList.Clear();
			this.PetMingPosition.Clear();
			this.RolePetBag.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetFormationSet))]
//宠物出战设置
	[Message(OuterMessage.C2M_RolePetFormationSet)]
	[MemoryPackable]
	public partial class C2M_RolePetFormationSet: MessageObject, ILocationRequest
	{
		public static C2M_RolePetFormationSet Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetFormationSet), isFromPool) as C2M_RolePetFormationSet; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int Index { get; set; }

		[MemoryPackOrder(1)]
		public long PetId { get; set; }

		[MemoryPackOrder(2)]
		public int OperateType { get; set; }

		[MemoryPackOrder(3)]
		public int SceneType { get; set; }

		[MemoryPackOrder(4)]
		public List<long> PetFormat { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<long> PetPosition { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Index = default;
			this.PetId = default;
			this.OperateType = default;
			this.SceneType = default;
			this.PetFormat.Clear();
			this.PetPosition.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetFormationSet)]
	[MemoryPackable]
	public partial class M2C_RolePetFormationSet: MessageObject, ILocationResponse
	{
		public static M2C_RolePetFormationSet Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetFormationSet), isFromPool) as M2C_RolePetFormationSet; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetFight))]
//宠物出战[1出战 0休息]
	[Message(OuterMessage.C2M_RolePetFight)]
	[MemoryPackable]
	public partial class C2M_RolePetFight: MessageObject, ILocationRequest
	{
		public static C2M_RolePetFight Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetFight), isFromPool) as C2M_RolePetFight; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int PetStatus { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.PetStatus = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetFight)]
	[MemoryPackable]
	public partial class M2C_RolePetFight: MessageObject, ILocationResponse
	{
		public static M2C_RolePetFight Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetFight), isFromPool) as M2C_RolePetFight; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetUpStar))]
//宠物合成
	[Message(OuterMessage.C2M_RolePetUpStar)]
	[MemoryPackable]
	public partial class C2M_RolePetUpStar: MessageObject, ILocationRequest
	{
		public static C2M_RolePetUpStar Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetUpStar), isFromPool) as C2M_RolePetUpStar; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public List<long> CostPetInfoIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.CostPetInfoIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetUpStar)]
	[MemoryPackable]
	public partial class M2C_RolePetUpStar: MessageObject, ILocationResponse
	{
		public static M2C_RolePetUpStar Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetUpStar), isFromPool) as M2C_RolePetUpStar; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo rolePetInfo { get; set; }

		[MemoryPackOrder(1)]
		public List<long> CostPetInfoIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.rolePetInfo = default;
			this.CostPetInfoIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetFenjie))]
//宠物分解
	[Message(OuterMessage.C2M_RolePetFenjie)]
	[MemoryPackable]
	public partial class C2M_RolePetFenjie: MessageObject, ILocationRequest
	{
		public static C2M_RolePetFenjie Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetFenjie), isFromPool) as C2M_RolePetFenjie; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetFenjie)]
	[MemoryPackable]
	public partial class M2C_RolePetFenjie: MessageObject, ILocationResponse
	{
		public static M2C_RolePetFenjie Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetFenjie), isFromPool) as M2C_RolePetFenjie; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetXiLian))]
//宠物洗练
	[Message(OuterMessage.C2M_RolePetXiLian)]
	[MemoryPackable]
	public partial class C2M_RolePetXiLian: MessageObject, ILocationRequest
	{
		public static C2M_RolePetXiLian Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetXiLian), isFromPool) as C2M_RolePetXiLian; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public long BagInfoID { get; set; }

		[MemoryPackOrder(2)]
		public int CostItemNum { get; set; }

		[MemoryPackOrder(3)]
		public string ParamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.BagInfoID = default;
			this.CostItemNum = default;
			this.ParamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetXiLian)]
	[MemoryPackable]
	public partial class M2C_RolePetXiLian: MessageObject, ILocationResponse
	{
		public static M2C_RolePetXiLian Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetXiLian), isFromPool) as M2C_RolePetXiLian; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo rolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.rolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetHeCheng))]
//宠物合成
	[Message(OuterMessage.C2M_RolePetHeCheng)]
	[MemoryPackable]
	public partial class C2M_RolePetHeCheng: MessageObject, ILocationRequest
	{
		public static C2M_RolePetHeCheng Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetHeCheng), isFromPool) as C2M_RolePetHeCheng; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId1 { get; set; }

		[MemoryPackOrder(1)]
		public long PetInfoId2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId1 = default;
			this.PetInfoId2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetHeCheng)]
	[MemoryPackable]
	public partial class M2C_RolePetHeCheng: MessageObject, ILocationResponse
	{
		public static M2C_RolePetHeCheng Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetHeCheng), isFromPool) as M2C_RolePetHeCheng; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo rolePetInfo { get; set; }

		[MemoryPackOrder(1)]
		public long DeletePetInfoId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.rolePetInfo = default;
			this.DeletePetInfoId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetChangePosResponse))]
	[Message(OuterMessage.C2M_PetChangePosRequest)]
	[MemoryPackable]
	public partial class C2M_PetChangePosRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetChangePosRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetChangePosRequest), isFromPool) as C2M_PetChangePosRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int Index1 { get; set; }

		[MemoryPackOrder(1)]
		public int Index2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Index1 = default;
			this.Index2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetChangePosResponse)]
	[MemoryPackable]
	public partial class M2C_PetChangePosResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetChangePosResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetChangePosResponse), isFromPool) as M2C_PetChangePosResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetDuiHuanResponse))]
	[Message(OuterMessage.C2M_PetDuiHuanRequest)]
	[MemoryPackable]
	public partial class C2M_PetDuiHuanRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetDuiHuanRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetDuiHuanRequest), isFromPool) as C2M_PetDuiHuanRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetDuiHuanResponse)]
	[MemoryPackable]
	public partial class M2C_PetDuiHuanResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetDuiHuanResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetDuiHuanResponse), isFromPool) as M2C_PetDuiHuanResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo RolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetEggChouKaResponse))]
	[Message(OuterMessage.C2M_PetEggChouKaRequest)]
	[MemoryPackable]
	public partial class C2M_PetEggChouKaRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetEggChouKaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetEggChouKaRequest), isFromPool) as C2M_PetEggChouKaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ChouKaType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ChouKaType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetEggChouKaResponse)]
	[MemoryPackable]
	public partial class M2C_PetEggChouKaResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetEggChouKaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetEggChouKaResponse), isFromPool) as M2C_PetEggChouKaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<RewardItem> ReardList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.ReardList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetEggDuiHuanResponse))]
	[Message(OuterMessage.C2M_PetEggDuiHuanRequest)]
	[MemoryPackable]
	public partial class C2M_PetEggDuiHuanRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetEggDuiHuanRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetEggDuiHuanRequest), isFromPool) as C2M_PetEggDuiHuanRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ChouKaId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ChouKaId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetEggDuiHuanResponse)]
	[MemoryPackable]
	public partial class M2C_PetEggDuiHuanResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetEggDuiHuanResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetEggDuiHuanResponse), isFromPool) as M2C_PetEggDuiHuanResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<RewardItem> ReardList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.ReardList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetEquipResponse))]
//宠物装备
	[Message(OuterMessage.C2M_PetEquipRequest)]
	[MemoryPackable]
	public partial class C2M_PetEquipRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetEquipRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetEquipRequest), isFromPool) as C2M_PetEquipRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public long BagInfoId { get; set; }

		[MemoryPackOrder(3)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.BagInfoId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetEquipResponse)]
	[MemoryPackable]
	public partial class M2C_PetEquipResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetEquipResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetEquipResponse), isFromPool) as M2C_PetEquipResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo RolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetExploreReward))]
	[Message(OuterMessage.C2M_PetExploreReward)]
	[MemoryPackable]
	public partial class C2M_PetExploreReward: MessageObject, ILocationRequest
	{
		public static C2M_PetExploreReward Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetExploreReward), isFromPool) as C2M_PetExploreReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetExploreReward)]
	[MemoryPackable]
	public partial class M2C_PetExploreReward: MessageObject, ILocationResponse
	{
		public static M2C_PetExploreReward Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetExploreReward), isFromPool) as M2C_PetExploreReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetFragmentDuiHuan))]
	[Message(OuterMessage.C2M_PetFragmentDuiHuan)]
	[MemoryPackable]
	public partial class C2M_PetFragmentDuiHuan: MessageObject, ILocationRequest
	{
		public static C2M_PetFragmentDuiHuan Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetFragmentDuiHuan), isFromPool) as C2M_PetFragmentDuiHuan; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetFragmentDuiHuan)]
	[MemoryPackable]
	public partial class M2C_PetFragmentDuiHuan: MessageObject, ILocationResponse
	{
		public static M2C_PetFragmentDuiHuan Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetFragmentDuiHuan), isFromPool) as M2C_PetFragmentDuiHuan; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo RolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetFubenBeginResponse))]
//宠物副本开始战斗
	[Message(OuterMessage.C2M_PetFubenBeginRequest)]
	[MemoryPackable]
	public partial class C2M_PetFubenBeginRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetFubenBeginRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetFubenBeginRequest), isFromPool) as C2M_PetFubenBeginRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetFubenBeginResponse)]
	[MemoryPackable]
	public partial class M2C_PetFubenBeginResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetFubenBeginResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetFubenBeginResponse), isFromPool) as M2C_PetFubenBeginResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//宠物副本结束战斗
	[Message(OuterMessage.C2M_PetFubenOverRequest)]
	[MemoryPackable]
	public partial class C2M_PetFubenOverRequest: MessageObject, ILocationMessage
	{
		public static C2M_PetFubenOverRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetFubenOverRequest), isFromPool) as C2M_PetFubenOverRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetFubenRewardResponse))]
//宠物副本星级奖励
	[Message(OuterMessage.C2M_PetFubenRewardRequest)]
	[MemoryPackable]
	public partial class C2M_PetFubenRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetFubenRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetFubenRewardRequest), isFromPool) as C2M_PetFubenRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetFubenRewardResponse)]
	[MemoryPackable]
	public partial class M2C_PetFubenRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetFubenRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetFubenRewardResponse), isFromPool) as M2C_PetFubenRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetHeXinChouKaResponse))]
	[Message(OuterMessage.C2M_PetHeXinChouKaRequest)]
	[MemoryPackable]
	public partial class C2M_PetHeXinChouKaRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetHeXinChouKaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetHeXinChouKaRequest), isFromPool) as C2M_PetHeXinChouKaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ChouKaType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ChouKaType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetHeXinChouKaResponse)]
	[MemoryPackable]
	public partial class M2C_PetHeXinChouKaResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetHeXinChouKaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetHeXinChouKaResponse), isFromPool) as M2C_PetHeXinChouKaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<RewardItem> ReardList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.ReardList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetHeXinExploreReward))]
	[Message(OuterMessage.C2M_PetHeXinExploreReward)]
	[MemoryPackable]
	public partial class C2M_PetHeXinExploreReward: MessageObject, ILocationRequest
	{
		public static C2M_PetHeXinExploreReward Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetHeXinExploreReward), isFromPool) as C2M_PetHeXinExploreReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetHeXinExploreReward)]
	[MemoryPackable]
	public partial class M2C_PetHeXinExploreReward: MessageObject, ILocationResponse
	{
		public static M2C_PetHeXinExploreReward Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetHeXinExploreReward), isFromPool) as M2C_PetHeXinExploreReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetHeXinHeChengResponse))]
//宠物之核合成
	[Message(OuterMessage.C2M_PetHeXinHeChengRequest)]
	[MemoryPackable]
	public partial class C2M_PetHeXinHeChengRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetHeXinHeChengRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetHeXinHeChengRequest), isFromPool) as C2M_PetHeXinHeChengRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long BagInfoID_1 { get; set; }

		[MemoryPackOrder(1)]
		public long BagInfoID_2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.BagInfoID_1 = default;
			this.BagInfoID_2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetHeXinHeChengResponse)]
	[MemoryPackable]
	public partial class M2C_PetHeXinHeChengResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetHeXinHeChengResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetHeXinHeChengResponse), isFromPool) as M2C_PetHeXinHeChengResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetHeXinHeChengQuickResponse))]
//宠物之核一键合成
	[Message(OuterMessage.C2M_PetHeXinHeChengQuickRequest)]
	[MemoryPackable]
	public partial class C2M_PetHeXinHeChengQuickRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetHeXinHeChengQuickRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetHeXinHeChengQuickRequest), isFromPool) as C2M_PetHeXinHeChengQuickRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetHeXinHeChengQuickResponse)]
	[MemoryPackable]
	public partial class M2C_PetHeXinHeChengQuickResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetHeXinHeChengQuickResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetHeXinHeChengQuickResponse), isFromPool) as M2C_PetHeXinHeChengQuickResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetMingOccupyResponse))]
	[Message(OuterMessage.C2M_PetMingOccupyRequest)]
	[MemoryPackable]
	public partial class C2M_PetMingOccupyRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetMingOccupyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetMingOccupyRequest), isFromPool) as C2M_PetMingOccupyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Operate { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Operate = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetMingOccupyResponse)]
	[MemoryPackable]
	public partial class M2C_PetMingOccupyResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetMingOccupyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetMingOccupyResponse), isFromPool) as M2C_PetMingOccupyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetMingRecordResponse))]
	[Message(OuterMessage.C2M_PetMingRecordRequest)]
	[MemoryPackable]
	public partial class C2M_PetMingRecordRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetMingRecordRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetMingRecordRequest), isFromPool) as C2M_PetMingRecordRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetMingRecordResponse)]
	[MemoryPackable]
	public partial class M2C_PetMingRecordResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetMingRecordResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetMingRecordResponse), isFromPool) as M2C_PetMingRecordResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<PetMingRecord> PetMingRecords { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PetMingRecords.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetMingResetResponse))]
	[Message(OuterMessage.C2M_PetMingResetRequest)]
	[MemoryPackable]
	public partial class C2M_PetMingResetRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetMingResetRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetMingResetRequest), isFromPool) as C2M_PetMingResetRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetMingResetResponse)]
	[MemoryPackable]
	public partial class M2C_PetMingResetResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetMingResetResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetMingResetResponse), isFromPool) as M2C_PetMingResetResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetMingRewardResponse))]
	[Message(OuterMessage.C2M_PetMingRewardRequest)]
	[MemoryPackable]
	public partial class C2M_PetMingRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetMingRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetMingRewardRequest), isFromPool) as C2M_PetMingRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Number { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Number = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetMingRewardResponse)]
	[MemoryPackable]
	public partial class M2C_PetMingRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetMingRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetMingRewardResponse), isFromPool) as M2C_PetMingRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetOpenCangKu))]
	[Message(OuterMessage.C2M_PetOpenCangKu)]
	[MemoryPackable]
	public partial class C2M_PetOpenCangKu: MessageObject, ILocationRequest
	{
		public static C2M_PetOpenCangKu Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetOpenCangKu), isFromPool) as C2M_PetOpenCangKu; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OpenIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OpenIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetOpenCangKu)]
	[MemoryPackable]
	public partial class M2C_PetOpenCangKu: MessageObject, ILocationResponse
	{
		public static M2C_PetOpenCangKu Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetOpenCangKu), isFromPool) as M2C_PetOpenCangKu; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetPutCangKu))]
	[Message(OuterMessage.C2M_PetPutCangKu)]
	[MemoryPackable]
	public partial class C2M_PetPutCangKu: MessageObject, ILocationRequest
	{
		public static C2M_PetPutCangKu Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetPutCangKu), isFromPool) as C2M_PetPutCangKu; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int PetStatus { get; set; }

		[MemoryPackOrder(2)]
		public int OpenIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.PetStatus = default;
			this.OpenIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetPutCangKu)]
	[MemoryPackable]
	public partial class M2C_PetPutCangKu: MessageObject, ILocationResponse
	{
		public static M2C_PetPutCangKu Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetPutCangKu), isFromPool) as M2C_PetPutCangKu; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetShouHuActiveResponse))]
//宠物守护
	[Message(OuterMessage.C2M_PetShouHuActiveRequest)]
	[MemoryPackable]
	public partial class C2M_PetShouHuActiveRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetShouHuActiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetShouHuActiveRequest), isFromPool) as C2M_PetShouHuActiveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int PetShouHuActive { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PetShouHuActive = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetShouHuActiveResponse)]
	[MemoryPackable]
	public partial class M2C_PetShouHuActiveResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetShouHuActiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetShouHuActiveResponse), isFromPool) as M2C_PetShouHuActiveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int PetShouHuActive { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PetShouHuActive = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetShouHuResponse))]
//宠物守护
	[Message(OuterMessage.C2M_PetShouHuRequest)]
	[MemoryPackable]
	public partial class C2M_PetShouHuRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetShouHuRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetShouHuRequest), isFromPool) as C2M_PetShouHuRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PetInfoId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetShouHuResponse)]
	[MemoryPackable]
	public partial class M2C_PetShouHuResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetShouHuResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetShouHuResponse), isFromPool) as M2C_PetShouHuResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<long> PetShouHuList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PetShouHuList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetTakeOutBag))]
	[Message(OuterMessage.C2M_PetTakeOutBag)]
	[MemoryPackable]
	public partial class C2M_PetTakeOutBag: MessageObject, ILocationRequest
	{
		public static C2M_PetTakeOutBag Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetTakeOutBag), isFromPool) as C2M_PetTakeOutBag; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetTakeOutBag)]
	[MemoryPackable]
	public partial class M2C_PetTakeOutBag: MessageObject, ILocationResponse
	{
		public static M2C_PetTakeOutBag Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetTakeOutBag), isFromPool) as M2C_PetTakeOutBag; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PetTargetLockResponse))]
	[Message(OuterMessage.C2M_PetTargetLockRequest)]
	[MemoryPackable]
	public partial class C2M_PetTargetLockRequest: MessageObject, ILocationRequest
	{
		public static C2M_PetTargetLockRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PetTargetLockRequest), isFromPool) as C2M_PetTargetLockRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long TargetId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TargetId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PetTargetLockResponse)]
	[MemoryPackable]
	public partial class M2C_PetTargetLockResponse: MessageObject, ILocationResponse
	{
		public static M2C_PetTargetLockResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PetTargetLockResponse), isFromPool) as M2C_PetTargetLockResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetEggHatch))]
//宠物蛋孵化
	[Message(OuterMessage.C2M_RolePetEggHatch)]
	[MemoryPackable]
	public partial class C2M_RolePetEggHatch: MessageObject, ILocationRequest
	{
		public static C2M_RolePetEggHatch Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetEggHatch), isFromPool) as C2M_RolePetEggHatch; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long BagInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.BagInfoId = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetEggHatch)]
	[MemoryPackable]
	public partial class M2C_RolePetEggHatch: MessageObject, ILocationResponse
	{
		public static M2C_RolePetEggHatch Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetEggHatch), isFromPool) as M2C_RolePetEggHatch; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public KeyValuePairInt RolePetEgg { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetEgg = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetEggOpen))]
//宠物蛋开启【时间未到需要扣除钻石】
	[Message(OuterMessage.C2M_RolePetEggOpen)]
	[MemoryPackable]
	public partial class C2M_RolePetEggOpen: MessageObject, ILocationRequest
	{
		public static C2M_RolePetEggOpen Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetEggOpen), isFromPool) as C2M_RolePetEggOpen; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetEggOpen)]
	[MemoryPackable]
	public partial class M2C_RolePetEggOpen: MessageObject, ILocationResponse
	{
		public static M2C_RolePetEggOpen Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetEggOpen), isFromPool) as M2C_RolePetEggOpen; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo PetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.PetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetEggPutOut))]
//宠物蛋卸下
	[Message(OuterMessage.C2M_RolePetEggPutOut)]
	[MemoryPackable]
	public partial class C2M_RolePetEggPutOut: MessageObject, ILocationRequest
	{
		public static C2M_RolePetEggPutOut Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetEggPutOut), isFromPool) as C2M_RolePetEggPutOut; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetEggPutOut)]
	[MemoryPackable]
	public partial class M2C_RolePetEggPutOut: MessageObject, ILocationResponse
	{
		public static M2C_RolePetEggPutOut Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetEggPutOut), isFromPool) as M2C_RolePetEggPutOut; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public KeyValuePairInt RolePetEgg { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetEgg = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetHeXin))]
//更改宠物之核
	[Message(OuterMessage.C2M_RolePetHeXin)]
	[MemoryPackable]
	public partial class C2M_RolePetHeXin: MessageObject, ILocationRequest
	{
		public static C2M_RolePetHeXin Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetHeXin), isFromPool) as C2M_RolePetHeXin; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public long BagInfoId { get; set; }

		[MemoryPackOrder(2)]
		public int Position { get; set; }

		[MemoryPackOrder(3)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.BagInfoId = default;
			this.Position = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetHeXin)]
	[MemoryPackable]
	public partial class M2C_RolePetHeXin: MessageObject, ILocationResponse
	{
		public static M2C_RolePetHeXin Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetHeXin), isFromPool) as M2C_RolePetHeXin; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo RolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetJiadian))]
//宠物加点
	[Message(OuterMessage.C2M_RolePetJiadian)]
	[MemoryPackable]
	public partial class C2M_RolePetJiadian: MessageObject, ILocationRequest
	{
		public static C2M_RolePetJiadian Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetJiadian), isFromPool) as C2M_RolePetJiadian; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public List<int> AddPropretyValue { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.AddPropretyValue.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetJiadian)]
	[MemoryPackable]
	public partial class M2C_RolePetJiadian: MessageObject, ILocationResponse
	{
		public static M2C_RolePetJiadian Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetJiadian), isFromPool) as M2C_RolePetJiadian; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public RolePetInfo RolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetProtect))]
	[Message(OuterMessage.C2M_RolePetProtect)]
	[MemoryPackable]
	public partial class C2M_RolePetProtect: MessageObject, ILocationRequest
	{
		public static C2M_RolePetProtect Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetProtect), isFromPool) as C2M_RolePetProtect; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public bool IsProtect { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.IsProtect = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetProtect)]
	[MemoryPackable]
	public partial class M2C_RolePetProtect: MessageObject, ILocationResponse
	{
		public static M2C_RolePetProtect Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetProtect), isFromPool) as M2C_RolePetProtect; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetRName))]
//宠物改名
	[Message(OuterMessage.C2M_RolePetRName)]
	[MemoryPackable]
	public partial class C2M_RolePetRName: MessageObject, ILocationRequest
	{
		public static C2M_RolePetRName Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetRName), isFromPool) as C2M_RolePetRName; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public string PetName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.PetName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetRName)]
	[MemoryPackable]
	public partial class M2C_RolePetRName: MessageObject, ILocationResponse
	{
		public static M2C_RolePetRName Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetRName), isFromPool) as M2C_RolePetRName; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetSkinSet))]
//更改宠物皮肤
	[Message(OuterMessage.C2M_RolePetSkinSet)]
	[MemoryPackable]
	public partial class C2M_RolePetSkinSet: MessageObject, ILocationRequest
	{
		public static C2M_RolePetSkinSet Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetSkinSet), isFromPool) as C2M_RolePetSkinSet; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int SkinId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.SkinId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetSkinSet)]
	[MemoryPackable]
	public partial class M2C_RolePetSkinSet: MessageObject, ILocationResponse
	{
		public static M2C_RolePetSkinSet Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetSkinSet), isFromPool) as M2C_RolePetSkinSet; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetUpStage))]
//宠物进化
	[Message(OuterMessage.C2M_RolePetUpStage)]
	[MemoryPackable]
	public partial class C2M_RolePetUpStage: MessageObject, ILocationRequest
	{
		public static C2M_RolePetUpStage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetUpStage), isFromPool) as C2M_RolePetUpStage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public long PetInfoXianJiId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.PetInfoXianJiId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetUpStage)]
	[MemoryPackable]
	public partial class M2C_RolePetUpStage: MessageObject, ILocationResponse
	{
		public static M2C_RolePetUpStage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetUpStage), isFromPool) as M2C_RolePetUpStage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo OldPetInfo { get; set; }

		[MemoryPackOrder(1)]
		public RolePetInfo NewPetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.OldPetInfo = default;
			this.NewPetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetXiuLian))]
//宠物修炼
	[Message(OuterMessage.C2M_RolePetXiuLian)]
	[MemoryPackable]
	public partial class C2M_RolePetXiuLian: MessageObject, ILocationRequest
	{
		public static C2M_RolePetXiuLian Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetXiuLian), isFromPool) as C2M_RolePetXiuLian; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int XiuLianId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.XiuLianId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetXiuLian)]
	[MemoryPackable]
	public partial class M2C_RolePetXiuLian: MessageObject, ILocationResponse
	{
		public static M2C_RolePetXiuLian Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetXiuLian), isFromPool) as M2C_RolePetXiuLian; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo rolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.rolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetEggPut))]
//宠物蛋放入
	[Message(OuterMessage.C2M_RolePetEggPut)]
	[MemoryPackable]
	public partial class C2M_RolePetEggPut: MessageObject, ILocationRequest
	{
		public static C2M_RolePetEggPut Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetEggPut), isFromPool) as C2M_RolePetEggPut; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long BagInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.BagInfoId = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetEggPut)]
	[MemoryPackable]
	public partial class M2C_RolePetEggPut: MessageObject, ILocationResponse
	{
		public static M2C_RolePetEggPut Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetEggPut), isFromPool) as M2C_RolePetEggPut; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public KeyValuePairInt RolePetEgg { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RolePetEgg = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.BattleSummonInfo)]
	[MemoryPackable]
	public partial class BattleSummonInfo: MessageObject
	{
		public static BattleSummonInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(BattleSummonInfo), isFromPool) as BattleSummonInfo; 
		}

		[MemoryPackOrder(0)]
		public int SummonId { get; set; }

		[MemoryPackOrder(1)]
		public long SummonTime { get; set; }

		[MemoryPackOrder(2)]
		public int SummonNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SummonId = default;
			this.SummonTime = default;
			this.SummonNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FubenSettlement)]
	[MemoryPackable]
	public partial class M2C_FubenSettlement: MessageObject, IMessage
	{
		public static M2C_FubenSettlement Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FubenSettlement), isFromPool) as M2C_FubenSettlement; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int BattleResult { get; set; }

		[MemoryPackOrder(1)]
		public int BattleGrade { get; set; }

		[MemoryPackOrder(2)]
		public int RewardExp { get; set; }

		[MemoryPackOrder(3)]
		public int RewardGold { get; set; }

		[MemoryPackOrder(4)]
		public List<RewardItem> ReardList { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<RewardItem> ReardListExcess { get; set; } = new();

		[MemoryPackOrder(6)]
		public List<int> StarInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.ActorId = default;
			this.BattleResult = default;
			this.BattleGrade = default;
			this.RewardExp = default;
			this.RewardGold = default;
			this.ReardList.Clear();
			this.ReardListExcess.Clear();
			this.StarInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//家园刷新
	[Message(OuterMessage.M2C_JiaYuanUpdate)]
	[MemoryPackable]
	public partial class M2C_JiaYuanUpdate: MessageObject, IMessage
	{
		public static M2C_JiaYuanUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanUpdate), isFromPool) as M2C_JiaYuanUpdate; 
		}

		[MemoryPackOrder(1)]
		public List<JiaYuanPurchaseItem> PurchaseItemList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PurchaseItemList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FriendApplyResult)]
	[MemoryPackable]
	public partial class M2C_FriendApplyResult: MessageObject, IMessage
	{
		public static M2C_FriendApplyResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FriendApplyResult), isFromPool) as M2C_FriendApplyResult; 
		}

		[MemoryPackOrder(0)]
		public FriendInfo FriendInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.FriendInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ChengJiuListResponse))]
	[Message(OuterMessage.C2M_ChengJiuListRequest)]
	[MemoryPackable]
	public partial class C2M_ChengJiuListRequest: MessageObject, ILocationRequest
	{
		public static C2M_ChengJiuListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChengJiuListRequest), isFromPool) as C2M_ChengJiuListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChengJiuListResponse)]
	[MemoryPackable]
	public partial class M2C_ChengJiuListResponse: MessageObject, ILocationResponse
	{
		public static M2C_ChengJiuListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChengJiuListResponse), isFromPool) as M2C_ChengJiuListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<ChengJiuInfo> ChengJiuProgessList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> ChengJiuCompleteList { get; set; } = new();

		[MemoryPackOrder(2)]
		public int TotalChengJiuPoint { get; set; }

		[MemoryPackOrder(3)]
		public List<int> AlreadReceivedId { get; set; } = new();

		[MemoryPackOrder(4)]
		public List<int> JingLingList { get; set; } = new();

		[MemoryPackOrder(5)]
		public int JingLingId { get; set; }

		[MemoryPackOrder(6)]
		public int RandomDrop { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ChengJiuProgessList.Clear();
			this.ChengJiuCompleteList.Clear();
			this.TotalChengJiuPoint = default;
			this.AlreadReceivedId.Clear();
			this.JingLingList.Clear();
			this.JingLingId = default;
			this.RandomDrop = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ChengJiuRewardResponse))]
	[Message(OuterMessage.C2M_ChengJiuRewardRequest)]
	[MemoryPackable]
	public partial class C2M_ChengJiuRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_ChengJiuRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChengJiuRewardRequest), isFromPool) as C2M_ChengJiuRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChengJiuRewardResponse)]
	[MemoryPackable]
	public partial class M2C_ChengJiuRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_ChengJiuRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChengJiuRewardResponse), isFromPool) as M2C_ChengJiuRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//抓捕精灵
	[ResponseType(nameof(M2C_JingLingCatchResponse))]
	[Message(OuterMessage.C2M_JingLingCatchRequest)]
	[MemoryPackable]
	public partial class C2M_JingLingCatchRequest: MessageObject, ILocationRequest
	{
		public static C2M_JingLingCatchRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JingLingCatchRequest), isFromPool) as C2M_JingLingCatchRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long JingLingId { get; set; }

		[MemoryPackOrder(1)]
		public int ItemId { get; set; }

		[MemoryPackOrder(4)]
		public string OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.JingLingId = default;
			this.ItemId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JingLingCatchResponse)]
	[MemoryPackable]
	public partial class M2C_JingLingCatchResponse: MessageObject, ILocationResponse
	{
		public static M2C_JingLingCatchResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JingLingCatchResponse), isFromPool) as M2C_JingLingCatchResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//精灵掉落
	[ResponseType(nameof(M2C_JingLingDropResponse))]
	[Message(OuterMessage.C2M_JingLingDropRequest)]
	[MemoryPackable]
	public partial class C2M_JingLingDropRequest: MessageObject, ILocationRequest
	{
		public static C2M_JingLingDropRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JingLingDropRequest), isFromPool) as C2M_JingLingDropRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JingLingDropResponse)]
	[MemoryPackable]
	public partial class M2C_JingLingDropResponse: MessageObject, ILocationResponse
	{
		public static M2C_JingLingDropResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JingLingDropResponse), isFromPool) as M2C_JingLingDropResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//出战精灵
	[ResponseType(nameof(M2C_JingLingUseResponse))]
	[Message(OuterMessage.C2M_JingLingUseRequest)]
	[MemoryPackable]
	public partial class C2M_JingLingUseRequest: MessageObject, ILocationRequest
	{
		public static C2M_JingLingUseRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JingLingUseRequest), isFromPool) as C2M_JingLingUseRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int JingLingId { get; set; }

		[MemoryPackOrder(1)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.JingLingId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JingLingUseResponse)]
	[MemoryPackable]
	public partial class M2C_JingLingUseResponse: MessageObject, ILocationResponse
	{
		public static M2C_JingLingUseResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JingLingUseResponse), isFromPool) as M2C_JingLingUseResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int JingLingId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.JingLingId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_UnitStateUpdate)]
	[MemoryPackable]
	public partial class C2M_UnitStateUpdate: MessageObject, ILocationMessage
	{
		public static C2M_UnitStateUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnitStateUpdate), isFromPool) as C2M_UnitStateUpdate; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long StateType { get; set; }

		[MemoryPackOrder(2)]
		public int StateOperateType { get; set; }

		[MemoryPackOrder(3)]
		public int StateTime { get; set; }

		[MemoryPackOrder(4)]
		public string StateValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.StateType = default;
			this.StateOperateType = default;
			this.StateTime = default;
			this.StateValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnitBuffUpdate)]
	[MemoryPackable]
	public partial class M2C_UnitBuffUpdate: MessageObject, IMessage
	{
		public static M2C_UnitBuffUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitBuffUpdate), isFromPool) as M2C_UnitBuffUpdate; 
		}

		[MemoryPackOrder(0)]
		public int BuffID { get; set; }

		[MemoryPackOrder(1)]
		public long UnitIdBelongTo { get; set; }

		[MemoryPackOrder(3)]
		public int BuffOperateType { get; set; }

		[MemoryPackOrder(4)]
		public List<float> TargetPostion { get; set; } = new();

		[MemoryPackOrder(5)]
		public long BuffEndTime { get; set; }

		[MemoryPackOrder(6)]
		public string Spellcaster { get; set; }

		[MemoryPackOrder(7)]
		public int UnitType { get; set; }

		[MemoryPackOrder(8)]
		public int UnitConfigId { get; set; }

		[MemoryPackOrder(9)]
		public int SkillId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.BuffID = default;
			this.UnitIdBelongTo = default;
			this.BuffOperateType = default;
			this.TargetPostion.Clear();
			this.BuffEndTime = default;
			this.Spellcaster = default;
			this.UnitType = default;
			this.UnitConfigId = default;
			this.SkillId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnitBuffRemove)]
	[MemoryPackable]
	public partial class M2C_UnitBuffRemove: MessageObject, IMessage
	{
		public static M2C_UnitBuffRemove Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitBuffRemove), isFromPool) as M2C_UnitBuffRemove; 
		}

		[MemoryPackOrder(0)]
		public int BuffID { get; set; }

		[MemoryPackOrder(1)]
		public long UnitIdBelongTo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.BuffID = default;
			this.UnitIdBelongTo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnitBuffStatus)]
	[MemoryPackable]
	public partial class M2C_UnitBuffStatus: MessageObject, IMessage
	{
		public static M2C_UnitBuffStatus Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitBuffStatus), isFromPool) as M2C_UnitBuffStatus; 
		}

		[MemoryPackOrder(0)]
		public int BuffID { get; set; }

		[MemoryPackOrder(1)]
		public string FlyText { get; set; }

		[MemoryPackOrder(2)]
		public int FlyType { get; set; }

		[MemoryPackOrder(3)]
		public long UnitID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.BuffID = default;
			this.FlyText = default;
			this.FlyType = default;
			this.UnitID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//二段技能
	[Message(OuterMessage.M2C_SkillSecondResult)]
	[MemoryPackable]
	public partial class M2C_SkillSecondResult: MessageObject, IMessage
	{
		public static M2C_SkillSecondResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillSecondResult), isFromPool) as M2C_SkillSecondResult; 
		}

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int SkillId { get; set; }

		[MemoryPackOrder(2)]
		public List<long> HurtIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActorId = default;
			this.UnitId = default;
			this.SkillId = default;
			this.HurtIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.TokenRecvive)]
	[MemoryPackable]
	public partial class TokenRecvive: MessageObject
	{
		public static TokenRecvive Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(TokenRecvive), isFromPool) as TokenRecvive; 
		}

		[MemoryPackOrder(0)]
		public int ActivityId { get; set; }

		[MemoryPackOrder(1)]
		public int ReceiveIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActivityId = default;
			this.ReceiveIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//第一版的活动
	[Message(OuterMessage.ActivityV1Info)]
	[MemoryPackable]
	public partial class ActivityV1Info: MessageObject
	{
		public static ActivityV1Info Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ActivityV1Info), isFromPool) as ActivityV1Info; 
		}

		[MemoryPackOrder(0)]
		public List<int> GuessIds { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> LastGuessReward { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<int> ConsumeDiamondReward { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<int> ChouKaNumberReward { get; set; } = new();

		[MemoryPackOrder(4)]
		public int ChouKaDropId { get; set; }

		[MemoryPackOrder(5)]
		public List<int> LiBaoAllIds { get; set; } = new();

		[MemoryPackOrder(6)]
		public List<int> LiBaoBuyIds { get; set; } = new();

		[MemoryPackOrder(7)]
		public int BaoShiDu { get; set; }

		[MemoryPackOrder(8)]
		public string ChouKa2ItemList { get; set; }

		[MemoryPackOrder(9)]
		public List<int> ChouKa2RewardIds { get; set; } = new();

		[MemoryPackOrder(10)]
		public List<int> OpenGuessIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.GuessIds.Clear();
			this.LastGuessReward.Clear();
			this.ConsumeDiamondReward.Clear();
			this.ChouKaNumberReward.Clear();
			this.ChouKaDropId = default;
			this.LiBaoAllIds.Clear();
			this.LiBaoBuyIds.Clear();
			this.BaoShiDu = default;
			this.ChouKa2ItemList = default;
			this.ChouKa2RewardIds.Clear();
			this.OpenGuessIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//闪电链
	[Message(OuterMessage.M2C_ChainLightning)]
	[MemoryPackable]
	public partial class M2C_ChainLightning: MessageObject, IMessage
	{
		public static M2C_ChainLightning Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChainLightning), isFromPool) as M2C_ChainLightning; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long TargetID { get; set; }

		[MemoryPackOrder(2)]
		public int SkillID { get; set; }

		[MemoryPackOrder(5)]
		public float PosX { get; set; }

		[MemoryPackOrder(6)]
		public float PosY { get; set; }

		[MemoryPackOrder(7)]
		public float PosZ { get; set; }

		[MemoryPackOrder(8)]
		public int Type { get; set; }

		[MemoryPackOrder(9)]
		public long InstanceId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.TargetID = default;
			this.SkillID = default;
			this.PosX = default;
			this.PosY = default;
			this.PosZ = default;
			this.Type = default;
			this.InstanceId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_StoreBuyResponse))]
//商店购买
	[Message(OuterMessage.C2M_StoreBuyRequest)]
	[MemoryPackable]
	public partial class C2M_StoreBuyRequest: MessageObject, ILocationRequest
	{
		public static C2M_StoreBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_StoreBuyRequest), isFromPool) as C2M_StoreBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int SellItemID { get; set; }

		[MemoryPackOrder(1)]
		public int SellItemNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SellItemID = default;
			this.SellItemNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StoreBuyResponse)]
	[MemoryPackable]
	public partial class M2C_StoreBuyResponse: MessageObject, ILocationResponse
	{
		public static M2C_StoreBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StoreBuyResponse), isFromPool) as M2C_StoreBuyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_AccountWarehousOperateResponse))]
	[Message(OuterMessage.C2M_AccountWarehousOperateRequest)]
	[MemoryPackable]
	public partial class C2M_AccountWarehousOperateRequest: MessageObject, ILocationRequest
	{
		public static C2M_AccountWarehousOperateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_AccountWarehousOperateRequest), isFromPool) as C2M_AccountWarehousOperateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public int OperatateType { get; set; }

		[MemoryPackOrder(2)]
		public long OperateBagID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperatateType = default;
			this.OperateBagID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_AccountWarehousOperateResponse)]
	[MemoryPackable]
	public partial class M2C_AccountWarehousOperateResponse: MessageObject, ILocationResponse
	{
		public static M2C_AccountWarehousOperateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_AccountWarehousOperateResponse), isFromPool) as M2C_AccountWarehousOperateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(1)]
		public BagInfo BagInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.BagInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemXiLianResponse))]
//洗练装备
	[Message(OuterMessage.C2M_ItemXiLianRequest)]
	[MemoryPackable]
	public partial class C2M_ItemXiLianRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemXiLianRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemXiLianRequest), isFromPool) as C2M_ItemXiLianRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(0)]
		public int Times { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID = default;
			this.Times = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemXiLianResponse)]
	[MemoryPackable]
	public partial class M2C_ItemXiLianResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemXiLianResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemXiLianResponse), isFromPool) as M2C_ItemXiLianResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<ItemXiLianResult> ItemXiLianResults { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.ItemXiLianResults.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemXiLianNumReward))]
	[Message(OuterMessage.C2M_ItemXiLianNumReward)]
	[MemoryPackable]
	public partial class C2M_ItemXiLianNumReward: MessageObject, ILocationRequest
	{
		public static C2M_ItemXiLianNumReward Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemXiLianNumReward), isFromPool) as C2M_ItemXiLianNumReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemXiLianNumReward)]
	[MemoryPackable]
	public partial class M2C_ItemXiLianNumReward: MessageObject, ILocationResponse
	{
		public static M2C_ItemXiLianNumReward Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemXiLianNumReward), isFromPool) as M2C_ItemXiLianNumReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemXiLianRewardResponse))]
	[Message(OuterMessage.C2M_ItemXiLianRewardRequest)]
	[MemoryPackable]
	public partial class C2M_ItemXiLianRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemXiLianRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemXiLianRewardRequest), isFromPool) as C2M_ItemXiLianRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int XiLianId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.XiLianId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemXiLianRewardResponse)]
	[MemoryPackable]
	public partial class M2C_ItemXiLianRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemXiLianRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemXiLianRewardResponse), isFromPool) as M2C_ItemXiLianRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemXiLianSelectResponse))]
//洗练装备
	[Message(OuterMessage.C2M_ItemXiLianSelectRequest)]
	[MemoryPackable]
	public partial class C2M_ItemXiLianSelectRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemXiLianSelectRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemXiLianSelectRequest), isFromPool) as C2M_ItemXiLianSelectRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(0)]
		public ItemXiLianResult ItemXiLianResult { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID = default;
			this.ItemXiLianResult = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemXiLianSelectResponse)]
	[MemoryPackable]
	public partial class M2C_ItemXiLianSelectResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemXiLianSelectResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemXiLianSelectResponse), isFromPool) as M2C_ItemXiLianSelectResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ItemXiLianTransferResponse))]
//洗练转移
	[Message(OuterMessage.C2M_ItemXiLianTransferRequest)]
	[MemoryPackable]
	public partial class C2M_ItemXiLianTransferRequest: MessageObject, ILocationRequest
	{
		public static C2M_ItemXiLianTransferRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ItemXiLianTransferRequest), isFromPool) as C2M_ItemXiLianTransferRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long OperateBagID_1 { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID_2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateBagID_1 = default;
			this.OperateBagID_2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ItemXiLianTransferResponse)]
	[MemoryPackable]
	public partial class M2C_ItemXiLianTransferResponse: MessageObject, ILocationResponse
	{
		public static M2C_ItemXiLianTransferResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ItemXiLianTransferResponse), isFromPool) as M2C_ItemXiLianTransferResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MakeSelectResponse))]
	[Message(OuterMessage.C2M_MakeSelectRequest)]
	[MemoryPackable]
	public partial class C2M_MakeSelectRequest: MessageObject, ILocationRequest
	{
		public static C2M_MakeSelectRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_MakeSelectRequest), isFromPool) as C2M_MakeSelectRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int MakeType { get; set; }

		[MemoryPackOrder(1)]
		public int Plan { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MakeType = default;
			this.Plan = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_MakeSelectResponse)]
	[MemoryPackable]
	public partial class M2C_MakeSelectResponse: MessageObject, ILocationResponse
	{
		public static M2C_MakeSelectResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_MakeSelectResponse), isFromPool) as M2C_MakeSelectResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> MakeList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MakeList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MakeEquipResponse))]
	[Message(OuterMessage.C2M_MakeEquipRequest)]
	[MemoryPackable]
	public partial class C2M_MakeEquipRequest: MessageObject, ILocationRequest
	{
		public static C2M_MakeEquipRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_MakeEquipRequest), isFromPool) as C2M_MakeEquipRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int MakeId { get; set; }

		[MemoryPackOrder(1)]
		public long BagInfoID { get; set; }

		[MemoryPackOrder(2)]
		public int Plan { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MakeId = default;
			this.BagInfoID = default;
			this.Plan = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_MakeEquipResponse)]
	[MemoryPackable]
	public partial class M2C_MakeEquipResponse: MessageObject, ILocationResponse
	{
		public static M2C_MakeEquipResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_MakeEquipResponse), isFromPool) as M2C_MakeEquipResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int ItemId { get; set; }

		[MemoryPackOrder(1)]
		public int NewMakeId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ItemId = default;
			this.NewMakeId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TurtleRewardMessage)]
	[MemoryPackable]
	public partial class M2C_TurtleRewardMessage: MessageObject, IMessage
	{
		public static M2C_TurtleRewardMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TurtleRewardMessage), isFromPool) as M2C_TurtleRewardMessage; 
		}

		[MemoryPackOrder(0)]
		public long UnitID { get; set; }

		[MemoryPackOrder(1)]
		public List<string> PlayerName { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitID = default;
			this.PlayerName.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BloodstoneQiangHuaResponse))]
	[Message(OuterMessage.C2M_BloodstoneQiangHuaRequest)]
	[MemoryPackable]
	public partial class C2M_BloodstoneQiangHuaRequest: MessageObject, ILocationRequest
	{
		public static C2M_BloodstoneQiangHuaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BloodstoneQiangHuaRequest), isFromPool) as C2M_BloodstoneQiangHuaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BloodstoneQiangHuaResponse)]
	[MemoryPackable]
	public partial class M2C_BloodstoneQiangHuaResponse: MessageObject, ILocationResponse
	{
		public static M2C_BloodstoneQiangHuaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BloodstoneQiangHuaResponse), isFromPool) as M2C_BloodstoneQiangHuaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public int Level { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.Level = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//家族争霸赛捐献
	[ResponseType(nameof(M2C_DonationResponse))]
	[Message(OuterMessage.C2M_DonationRequest)]
	[MemoryPackable]
	public partial class C2M_DonationRequest: MessageObject, ILocationRequest
	{
		public static C2M_DonationRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_DonationRequest), isFromPool) as C2M_DonationRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Price { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Price = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_DonationResponse)]
	[MemoryPackable]
	public partial class M2C_DonationResponse: MessageObject, ILocationResponse
	{
		public static M2C_DonationResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_DonationResponse), isFromPool) as M2C_DonationResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//创建公会
	[ResponseType(nameof(M2C_UnionCreateResponse))]
	[Message(OuterMessage.C2M_UnionCreateRequest)]
	[MemoryPackable]
	public partial class C2M_UnionCreateRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnionCreateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionCreateRequest), isFromPool) as C2M_UnionCreateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string UnionName { get; set; }

		[MemoryPackOrder(1)]
		public string UnionPurpose { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionName = default;
			this.UnionPurpose = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionCreateResponse)]
	[MemoryPackable]
	public partial class M2C_UnionCreateResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnionCreateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionCreateResponse), isFromPool) as M2C_UnionCreateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_UnionDonationResponse))]
	[Message(OuterMessage.C2M_UnionDonationRequest)]
	[MemoryPackable]
	public partial class C2M_UnionDonationRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnionDonationRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionDonationRequest), isFromPool) as C2M_UnionDonationRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Price { get; set; }

		[MemoryPackOrder(1)]
		public int Type { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Price = default;
			this.Type = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionDonationResponse)]
	[MemoryPackable]
	public partial class M2C_UnionDonationResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnionDonationResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionDonationResponse), isFromPool) as M2C_UnionDonationResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//邀请玩家加入家族
	[Message(OuterMessage.C2M_UnionInviteRequest)]
	[MemoryPackable]
	public partial class C2M_UnionInviteRequest: MessageObject, ILocationMessage
	{
		public static C2M_UnionInviteRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionInviteRequest), isFromPool) as C2M_UnionInviteRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long InviteId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.InviteId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionInviteMessage)]
	[MemoryPackable]
	public partial class M2C_UnionInviteMessage: MessageObject, IMessage
	{
		public static M2C_UnionInviteMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionInviteMessage), isFromPool) as M2C_UnionInviteMessage; 
		}

		[MemoryPackOrder(0)]
		public string UnionName { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnionName = default;
			this.PlayerName = default;
			this.Message = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//邀请回复
	[Message(OuterMessage.C2M_UnionInviteReplyRequest)]
	[MemoryPackable]
	public partial class C2M_UnionInviteReplyRequest: MessageObject, ILocationMessage
	{
		public static C2M_UnionInviteReplyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionInviteReplyRequest), isFromPool) as C2M_UnionInviteReplyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int ReplyCode { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.ReplyCode = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//科技学习
	[ResponseType(nameof(M2C_UnionKeJiLearnResponse))]
	[Message(OuterMessage.C2M_UnionKeJiLearnRequest)]
	[MemoryPackable]
	public partial class C2M_UnionKeJiLearnRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnionKeJiLearnRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionKeJiLearnRequest), isFromPool) as C2M_UnionKeJiLearnRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionKeJiLearnResponse)]
	[MemoryPackable]
	public partial class M2C_UnionKeJiLearnResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnionKeJiLearnResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionKeJiLearnResponse), isFromPool) as M2C_UnionKeJiLearnResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> UnionKeJiList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionKeJiList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//离开公会
	[ResponseType(nameof(M2C_UnionLeaveResponse))]
	[Message(OuterMessage.C2M_UnionLeaveRequest)]
	[MemoryPackable]
	public partial class C2M_UnionLeaveRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnionLeaveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionLeaveRequest), isFromPool) as C2M_UnionLeaveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionLeaveResponse)]
	[MemoryPackable]
	public partial class M2C_UnionLeaveResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnionLeaveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionLeaveResponse), isFromPool) as M2C_UnionLeaveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//家族神秘商店道具
	[ResponseType(nameof(M2C_UnionMysteryBuyResponse))]
	[Message(OuterMessage.C2M_UnionMysteryBuyRequest)]
	[MemoryPackable]
	public partial class C2M_UnionMysteryBuyRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnionMysteryBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionMysteryBuyRequest), isFromPool) as C2M_UnionMysteryBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int MysteryId { get; set; }

		[MemoryPackOrder(2)]
		public int BuyNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MysteryId = default;
			this.BuyNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionMysteryBuyResponse)]
	[MemoryPackable]
	public partial class M2C_UnionMysteryBuyResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnionMysteryBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionMysteryBuyResponse), isFromPool) as M2C_UnionMysteryBuyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//转让族长
	[ResponseType(nameof(M2C_UnionTransferResponse))]
	[Message(OuterMessage.C2M_UnionTransferRequest)]
	[MemoryPackable]
	public partial class C2M_UnionTransferRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnionTransferRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionTransferRequest), isFromPool) as C2M_UnionTransferRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long NewLeader { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.NewLeader = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionTransferResponse)]
	[MemoryPackable]
	public partial class M2C_UnionTransferResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnionTransferResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionTransferResponse), isFromPool) as M2C_UnionTransferResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//家族修炼
	[ResponseType(nameof(M2C_UnionXiuLianResponse))]
	[Message(OuterMessage.C2M_UnionXiuLianRequest)]
	[MemoryPackable]
	public partial class C2M_UnionXiuLianRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnionXiuLianRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnionXiuLianRequest), isFromPool) as C2M_UnionXiuLianRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Position { get; set; }

		[MemoryPackOrder(1)]
		public int Type { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Position = default;
			this.Type = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionXiuLianResponse)]
	[MemoryPackable]
	public partial class M2C_UnionXiuLianResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnionXiuLianResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionXiuLianResponse), isFromPool) as M2C_UnionXiuLianResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(U2C_DonationRankListResponse))]
	[Message(OuterMessage.C2U_DonationRankListRequest)]
	[MemoryPackable]
	public partial class C2U_DonationRankListRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_DonationRankListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_DonationRankListRequest), isFromPool) as C2U_DonationRankListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RankType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RankType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_DonationRankListResponse)]
	[MemoryPackable]
	public partial class U2C_DonationRankListResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_DonationRankListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_DonationRankListResponse), isFromPool) as U2C_DonationRankListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionRaceInfoResult)]
	[MemoryPackable]
	public partial class M2C_UnionRaceInfoResult: MessageObject, ILocationMessage
	{
		public static M2C_UnionRaceInfoResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionRaceInfoResult), isFromPool) as M2C_UnionRaceInfoResult; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(4)]
		public int SceneType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.SceneType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterMessage.Actor_TransferRequest)]
	[MemoryPackable]
	public partial class Actor_TransferRequest: MessageObject, ILocationRequest
	{
		public static Actor_TransferRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_TransferRequest), isFromPool) as Actor_TransferRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SceneType { get; set; }

		[MemoryPackOrder(1)]
		public int SceneId { get; set; }

		[MemoryPackOrder(4)]
		public int Difficulty { get; set; }

		[MemoryPackOrder(5)]
		public string paramInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SceneType = default;
			this.SceneId = default;
			this.Difficulty = default;
			this.paramInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_TransferResponse)]
	[MemoryPackable]
	public partial class Actor_TransferResponse: MessageObject, ILocationResponse
	{
		public static Actor_TransferResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_TransferResponse), isFromPool) as Actor_TransferResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_HorseNoticeInfo)]
	[MemoryPackable]
	public partial class M2C_HorseNoticeInfo: MessageObject, IMessage
	{
		public static M2C_HorseNoticeInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_HorseNoticeInfo), isFromPool) as M2C_HorseNoticeInfo; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string NoticeText { get; set; }

		[MemoryPackOrder(1)]
		public int NoticeType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.NoticeText = default;
			this.NoticeType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.UnionListItem)]
	[MemoryPackable]
	public partial class UnionListItem: MessageObject
	{
		public static UnionListItem Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnionListItem), isFromPool) as UnionListItem; 
		}

		[MemoryPackOrder(0)]
		public string UnionName { get; set; }

		[MemoryPackOrder(1)]
		public long UnionId { get; set; }

		[MemoryPackOrder(2)]
		public int PlayerNumber { get; set; }

		[MemoryPackOrder(3)]
		public int LevelLimit { get; set; }

		[MemoryPackOrder(4)]
		public int UnionLevel { get; set; }

		[MemoryPackOrder(5)]
		public string UnionLeader { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnionName = default;
			this.UnionId = default;
			this.PlayerNumber = default;
			this.LevelLimit = default;
			this.UnionLevel = default;
			this.UnionLeader = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//公会列表
	[ResponseType(nameof(U2C_UnionListResponse))]
	[Message(OuterMessage.C2U_UnionListRequest)]
	[MemoryPackable]
	public partial class C2U_UnionListRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionListRequest), isFromPool) as C2U_UnionListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionListResponse)]
	[MemoryPackable]
	public partial class U2C_UnionListResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionListResponse), isFromPool) as U2C_UnionListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<UnionListItem> UnionList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//申请入会
	[ResponseType(nameof(U2C_UnionApplyResponse))]
	[Message(OuterMessage.C2U_UnionApplyRequest)]
	[MemoryPackable]
	public partial class C2U_UnionApplyRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionApplyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionApplyRequest), isFromPool) as C2U_UnionApplyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionApplyResponse)]
	[MemoryPackable]
	public partial class U2C_UnionApplyResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionApplyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionApplyResponse), isFromPool) as U2C_UnionApplyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnionApplyResult)]
	[MemoryPackable]
	public partial class M2C_UnionApplyResult: MessageObject, ILocationMessage
	{
		public static M2C_UnionApplyResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnionApplyResult), isFromPool) as M2C_UnionApplyResult; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//申请列表
	[ResponseType(nameof(U2C_UnionApplyListResponse))]
	[Message(OuterMessage.C2U_UnionApplyListRequest)]
	[MemoryPackable]
	public partial class C2U_UnionApplyListRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionApplyListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionApplyListRequest), isFromPool) as C2U_UnionApplyListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionApplyListResponse)]
	[MemoryPackable]
	public partial class U2C_UnionApplyListResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionApplyListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionApplyListResponse), isFromPool) as U2C_UnionApplyListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(9)]
		public List<UnionPlayerInfo> UnionPlayerList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionPlayerList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//申请回复
	[ResponseType(nameof(U2C_UnionApplyReplyResponse))]
	[Message(OuterMessage.C2U_UnionApplyReplyRequest)]
	[MemoryPackable]
	public partial class C2U_UnionApplyReplyRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionApplyReplyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionApplyReplyRequest), isFromPool) as C2U_UnionApplyReplyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public int ReplyCode { get; set; }

		[MemoryPackOrder(2)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			this.ReplyCode = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionApplyReplyResponse)]
	[MemoryPackable]
	public partial class U2C_UnionApplyReplyResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionApplyReplyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionApplyReplyResponse), isFromPool) as U2C_UnionApplyReplyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//家族竞选
	[ResponseType(nameof(U2C_UnionJingXuanResponse))]
	[Message(OuterMessage.C2U_UnionJingXuanRequest)]
	[MemoryPackable]
	public partial class C2U_UnionJingXuanRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionJingXuanRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionJingXuanRequest), isFromPool) as C2U_UnionJingXuanRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.UnitId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionJingXuanResponse)]
	[MemoryPackable]
	public partial class U2C_UnionJingXuanResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionJingXuanResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionJingXuanResponse), isFromPool) as U2C_UnionJingXuanResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(11)]
		public List<long> JingXuanList { get; set; } = new();

		[MemoryPackOrder(12)]
		public long JingXuanEndTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.JingXuanList.Clear();
			this.JingXuanEndTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//科技升级
	[ResponseType(nameof(U2C_UnionKeJiActiteResponse))]
	[Message(OuterMessage.C2U_UnionKeJiActiteRequest)]
	[MemoryPackable]
	public partial class C2U_UnionKeJiActiteRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionKeJiActiteRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionKeJiActiteRequest), isFromPool) as C2U_UnionKeJiActiteRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionKeJiActiteResponse)]
	[MemoryPackable]
	public partial class U2C_UnionKeJiActiteResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionKeJiActiteResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionKeJiActiteResponse), isFromPool) as U2C_UnionKeJiActiteResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public UnionInfo UnionInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//加速完成
	[ResponseType(nameof(U2C_UnionKeJiQuickResponse))]
	[Message(OuterMessage.C2U_UnionKeJiQuickRequest)]
	[MemoryPackable]
	public partial class C2U_UnionKeJiQuickRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionKeJiQuickRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionKeJiQuickRequest), isFromPool) as C2U_UnionKeJiQuickRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionKeJiQuickResponse)]
	[MemoryPackable]
	public partial class U2C_UnionKeJiQuickResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionKeJiQuickResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionKeJiQuickResponse), isFromPool) as U2C_UnionKeJiQuickResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public UnionInfo UnionInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//公会踢人
	[ResponseType(nameof(U2C_UnionKickOutResponse))]
	[Message(OuterMessage.C2U_UnionKickOutRequest)]
	[MemoryPackable]
	public partial class C2U_UnionKickOutRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionKickOutRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionKickOutRequest), isFromPool) as C2U_UnionKickOutRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionKickOutResponse)]
	[MemoryPackable]
	public partial class U2C_UnionKickOutResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionKickOutResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionKickOutResponse), isFromPool) as U2C_UnionKickOutResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//我的公会
	[ResponseType(nameof(U2C_UnionMyInfoResponse))]
	[Message(OuterMessage.C2U_UnionMyInfoRequest)]
	[MemoryPackable]
	public partial class C2U_UnionMyInfoRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionMyInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionMyInfoRequest), isFromPool) as C2U_UnionMyInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionMyInfoResponse)]
	[MemoryPackable]
	public partial class U2C_UnionMyInfoResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionMyInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionMyInfoResponse), isFromPool) as U2C_UnionMyInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public UnionInfo UnionMyInfo { get; set; }

		[MemoryPackOrder(1)]
		public List<long> OnLinePlayer { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionMyInfo = default;
			this.OnLinePlayer.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//家族神秘商店道具
	[ResponseType(nameof(U2C_UnionMysteryListResponse))]
	[Message(OuterMessage.C2U_UnionMysteryListRequest)]
	[MemoryPackable]
	public partial class C2U_UnionMysteryListRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionMysteryListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionMysteryListRequest), isFromPool) as C2U_UnionMysteryListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionMysteryListResponse)]
	[MemoryPackable]
	public partial class U2C_UnionMysteryListResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionMysteryListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionMysteryListResponse), isFromPool) as U2C_UnionMysteryListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<MysteryItemInfo> MysteryItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MysteryItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//公会操作
	[ResponseType(nameof(U2C_UnionOperatateResponse))]
	[Message(OuterMessage.C2U_UnionOperatateRequest)]
	[MemoryPackable]
	public partial class C2U_UnionOperatateRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionOperatateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionOperatateRequest), isFromPool) as C2U_UnionOperatateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long UnionId { get; set; }

		[MemoryPackOrder(2)]
		public int Operatate { get; set; }

		[MemoryPackOrder(3)]
		public string Value { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.UnionId = default;
			this.Operatate = default;
			this.Value = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionOperatateResponse)]
	[MemoryPackable]
	public partial class U2C_UnionOperatateResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionOperatateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionOperatateResponse), isFromPool) as U2C_UnionOperatateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(U2C_UnionRaceInfoResponse))]
	[Message(OuterMessage.C2U_UnionRaceInfoRequest)]
	[MemoryPackable]
	public partial class C2U_UnionRaceInfoRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionRaceInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionRaceInfoRequest), isFromPool) as C2U_UnionRaceInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RankType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RankType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionRaceInfoResponse)]
	[MemoryPackable]
	public partial class U2C_UnionRaceInfoResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionRaceInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionRaceInfoResponse), isFromPool) as U2C_UnionRaceInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<UnionListItem> UnionInfoList { get; set; } = new();

		[MemoryPackOrder(1)]
		public long TotalDonation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionInfoList.Clear();
			this.TotalDonation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//捐献记录
	[ResponseType(nameof(U2C_UnionRecordResponse))]
	[Message(OuterMessage.C2U_UnionRecordRequest)]
	[MemoryPackable]
	public partial class C2U_UnionRecordRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionRecordRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionRecordRequest), isFromPool) as C2U_UnionRecordRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionRecordResponse)]
	[MemoryPackable]
	public partial class U2C_UnionRecordResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionRecordResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionRecordResponse), isFromPool) as U2C_UnionRecordResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(10)]
		public List<DonationRecord> DonationRecords { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.DonationRecords.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//报名
	[ResponseType(nameof(U2C_UnionSignUpResponse))]
	[Message(OuterMessage.C2U_UnionSignUpRequest)]
	[MemoryPackable]
	public partial class C2U_UnionSignUpRequest: MessageObject, IUnionActorRequest
	{
		public static C2U_UnionSignUpRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2U_UnionSignUpRequest), isFromPool) as C2U_UnionSignUpRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.U2C_UnionSignUpResponse)]
	[MemoryPackable]
	public partial class U2C_UnionSignUpResponse: MessageObject, IUnionActorResponse
	{
		public static U2C_UnionSignUpResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2C_UnionSignUpResponse), isFromPool) as U2C_UnionSignUpResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//排行榜刷新
	[Message(OuterMessage.R2M_RankUpdateMessage)]
	[MemoryPackable]
	public partial class R2M_RankUpdateMessage: MessageObject, IMessage
	{
		public static R2M_RankUpdateMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankUpdateMessage), isFromPool) as R2M_RankUpdateMessage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RankType { get; set; }

		[MemoryPackOrder(1)]
		public int RankId { get; set; }

		[MemoryPackOrder(2)]
		public int OccRankId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RankType = default;
			this.RankId = default;
			this.OccRankId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RankingTrialInfo)]
	[MemoryPackable]
	public partial class RankingTrialInfo: MessageObject
	{
		public static RankingTrialInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RankingTrialInfo), isFromPool) as RankingTrialInfo; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public int PlayerLv { get; set; }

		[MemoryPackOrder(3)]
		public long Hurt { get; set; }

		[MemoryPackOrder(4)]
		public int Occ { get; set; }

		[MemoryPackOrder(5)]
		public int FubenId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.PlayerName = default;
			this.PlayerLv = default;
			this.Hurt = default;
			this.Occ = default;
			this.FubenId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RankSeasonTowerInfo)]
	[MemoryPackable]
	public partial class RankSeasonTowerInfo: MessageObject
	{
		public static RankSeasonTowerInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RankSeasonTowerInfo), isFromPool) as RankSeasonTowerInfo; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(2)]
		public int Occ { get; set; }

		[MemoryPackOrder(3)]
		public int PlayerLv { get; set; }

		[MemoryPackOrder(4)]
		public int FubenId { get; set; }

		[MemoryPackOrder(5)]
		public long TotalTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.PlayerName = default;
			this.Occ = default;
			this.PlayerLv = default;
			this.FubenId = default;
			this.TotalTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_AreneInfoResult)]
	[MemoryPackable]
	public partial class M2C_AreneInfoResult: MessageObject, IMessage
	{
		public static M2C_AreneInfoResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_AreneInfoResult), isFromPool) as M2C_AreneInfoResult; 
		}

		[MemoryPackOrder(0)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public int LeftPlayer { get; set; }

		[MemoryPackOrder(3)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActorId = default;
			this.UnitId = default;
			this.LeftPlayer = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BattleInfoResult)]
	[MemoryPackable]
	public partial class M2C_BattleInfoResult: MessageObject, IMessage
	{
		public static M2C_BattleInfoResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BattleInfoResult), isFromPool) as M2C_BattleInfoResult; 
		}

		[MemoryPackOrder(0)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public int CampKill_1 { get; set; }

		[MemoryPackOrder(3)]
		public int CampKill_2 { get; set; }

		[MemoryPackOrder(4)]
		public int SceneType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActorId = default;
			this.UnitId = default;
			this.CampKill_1 = default;
			this.CampKill_2 = default;
			this.SceneType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PaiMaiAuctionRecord)]
	[MemoryPackable]
	public partial class PaiMaiAuctionRecord: MessageObject
	{
		public static PaiMaiAuctionRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PaiMaiAuctionRecord), isFromPool) as PaiMaiAuctionRecord; 
		}

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int Occ { get; set; }

		[MemoryPackOrder(2)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(3)]
		public long Price { get; set; }

		[MemoryPackOrder(4)]
		public long Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnionId = default;
			this.Occ = default;
			this.PlayerName = default;
			this.Price = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.SoloPlayerInfo)]
	[MemoryPackable]
	public partial class SoloPlayerInfo: MessageObject
	{
		public static SoloPlayerInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SoloPlayerInfo), isFromPool) as SoloPlayerInfo; 
		}

		[MemoryPackOrder(0)]
		public long MatchTime { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long Combat { get; set; }

		[MemoryPackOrder(3)]
		public string Name { get; set; }

		[MemoryPackOrder(4)]
		public int Occ { get; set; }

		[MemoryPackOrder(5)]
		public int WinNum { get; set; }

		[MemoryPackOrder(6)]
		public int FailNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.MatchTime = default;
			this.UnitId = default;
			this.Combat = default;
			this.Name = default;
			this.Occ = default;
			this.WinNum = default;
			this.FailNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.SoloResultInfo)]
	[MemoryPackable]
	public partial class SoloResultInfo: MessageObject
	{
		public static SoloResultInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SoloResultInfo), isFromPool) as SoloResultInfo; 
		}

		[MemoryPackOrder(2)]
		public int WinTime { get; set; }

		[MemoryPackOrder(3)]
		public int FailTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.WinTime = default;
			this.FailTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.SoloMatchInfo)]
	[MemoryPackable]
	public partial class SoloMatchInfo: MessageObject
	{
		public static SoloMatchInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SoloMatchInfo), isFromPool) as SoloMatchInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitId_1 { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId_2 { get; set; }

		[MemoryPackOrder(2)]
		public long FubenId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId_1 = default;
			this.UnitId_2 = default;
			this.FubenId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SoloMatchResult)]
	[MemoryPackable]
	public partial class M2C_SoloMatchResult: MessageObject, IMessage
	{
		public static M2C_SoloMatchResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SoloMatchResult), isFromPool) as M2C_SoloMatchResult; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Result { get; set; }

		[MemoryPackOrder(1)]
		public long FubenId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Result = default;
			this.FubenId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.SoloPlayerResultInfo)]
	[MemoryPackable]
	public partial class SoloPlayerResultInfo: MessageObject
	{
		public static SoloPlayerResultInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SoloPlayerResultInfo), isFromPool) as SoloPlayerResultInfo; 
		}

		[MemoryPackOrder(0)]
		public long MatchTime { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long Combat { get; set; }

		[MemoryPackOrder(3)]
		public string Name { get; set; }

		[MemoryPackOrder(4)]
		public int Occ { get; set; }

		[MemoryPackOrder(5)]
		public int WinNum { get; set; }

		[MemoryPackOrder(6)]
		public int FailNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.MatchTime = default;
			this.UnitId = default;
			this.Combat = default;
			this.Name = default;
			this.Occ = default;
			this.WinNum = default;
			this.FailNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SoloDungeon)]
	[MemoryPackable]
	public partial class M2C_SoloDungeon: MessageObject, IMessage
	{
		public static M2C_SoloDungeon Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SoloDungeon), isFromPool) as M2C_SoloDungeon; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<RewardItem> RewardItem { get; set; } = new();

		[MemoryPackOrder(1)]
		public int SoloResult { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RewardItem.Clear();
			this.SoloResult = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.TeamPlayerInfo)]
	[MemoryPackable]
	public partial class TeamPlayerInfo: MessageObject
	{
		public static TeamPlayerInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(TeamPlayerInfo), isFromPool) as TeamPlayerInfo; 
		}

		[MemoryPackOrder(0)]
		public int HeadId { get; set; }

		[MemoryPackOrder(1)]
		public int PlayerLv { get; set; }

		[MemoryPackOrder(2)]
		public int WeaponId { get; set; }

		[MemoryPackOrder(3)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(4)]
		public long UserID { get; set; }

		[MemoryPackOrder(5)]
		public int Damage { get; set; }

		[MemoryPackOrder(6)]
		public long Combat { get; set; }

		[MemoryPackOrder(7)]
		public int Occ { get; set; }

		[MemoryPackOrder(8)]
		public int InFuben { get; set; }

		[MemoryPackOrder(9)]
		public int RobotId { get; set; }

		[MemoryPackOrder(10)]
		public int OccTwo { get; set; }

		[MemoryPackOrder(11)]
		public int Prepare { get; set; }

		[MemoryPackOrder(12)]
		public List<int> FashionIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.HeadId = default;
			this.PlayerLv = default;
			this.WeaponId = default;
			this.PlayerName = default;
			this.UserID = default;
			this.Damage = default;
			this.Combat = default;
			this.Occ = default;
			this.InFuben = default;
			this.RobotId = default;
			this.OccTwo = default;
			this.Prepare = default;
			this.FashionIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SyncMiJingDamage)]
	[MemoryPackable]
	public partial class M2C_SyncMiJingDamage: MessageObject, IMessage
	{
		public static M2C_SyncMiJingDamage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SyncMiJingDamage), isFromPool) as M2C_SyncMiJingDamage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<TeamPlayerInfo> DamageList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.DamageList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RunRaceBattleInfo)]
	[MemoryPackable]
	public partial class M2C_RunRaceBattleInfo: MessageObject, IMessage
	{
		public static M2C_RunRaceBattleInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RunRaceBattleInfo), isFromPool) as M2C_RunRaceBattleInfo; 
		}

		[MemoryPackOrder(0)]
		public long NextTransforTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.NextTransforTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RankRunRaceMessage)]
	[MemoryPackable]
	public partial class M2C_RankRunRaceMessage: MessageObject, IMessage
	{
		public static M2C_RankRunRaceMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RankRunRaceMessage), isFromPool) as M2C_RankRunRaceMessage; 
		}

		[MemoryPackOrder(0)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RankRunRaceReward)]
	[MemoryPackable]
	public partial class M2C_RankRunRaceReward: MessageObject, IMessage
	{
		public static M2C_RankRunRaceReward Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RankRunRaceReward), isFromPool) as M2C_RankRunRaceReward; 
		}

		[MemoryPackOrder(0)]
		public int RankId { get; set; }

		[MemoryPackOrder(1)]
		public int ByMail { get; set; }

		[MemoryPackOrder(2)]
		public List<RewardItem> RewardList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RankId = default;
			this.ByMail = default;
			this.RewardList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RankDemonMessage)]
	[MemoryPackable]
	public partial class M2C_RankDemonMessage: MessageObject, IMessage
	{
		public static M2C_RankDemonMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RankDemonMessage), isFromPool) as M2C_RankDemonMessage; 
		}

		[MemoryPackOrder(0)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.TeamInfo)]
	[MemoryPackable]
	public partial class TeamInfo: MessageObject
	{
		public static TeamInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(TeamInfo), isFromPool) as TeamInfo; 
		}

		[MemoryPackOrder(0)]
		public int SceneId { get; set; }

		[MemoryPackOrder(1)]
		public List<TeamPlayerInfo> PlayerList { get; set; } = new();

		[MemoryPackOrder(2)]
		public long TeamId { get; set; }

		[MemoryPackOrder(3)]
		public long FubenInstanceId { get; set; }

		[MemoryPackOrder(4)]
		public long FubenUUId { get; set; }

		[MemoryPackOrder(5)]
		public int FubenType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.PlayerList.Clear();
			this.TeamId = default;
			this.FubenInstanceId = default;
			this.FubenUUId = default;
			this.FubenType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamUpdateResult)]
	[MemoryPackable]
	public partial class M2C_TeamUpdateResult: MessageObject, IMessage
	{
		public static M2C_TeamUpdateResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamUpdateResult), isFromPool) as M2C_TeamUpdateResult; 
		}

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.TeamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//退出组队广播
	[Message(OuterMessage.M2C_TeamDungeonQuitMessage)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonQuitMessage: MessageObject, IMessage
	{
		public static M2C_TeamDungeonQuitMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonQuitMessage), isFromPool) as M2C_TeamDungeonQuitMessage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//紫色道具判断是否需要拾取
	[Message(OuterMessage.M2C_TeamPickMessage)]
	[MemoryPackable]
	public partial class M2C_TeamPickMessage: MessageObject, IMessage
	{
		public static M2C_TeamPickMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamPickMessage), isFromPool) as M2C_TeamPickMessage; 
		}

		[MemoryPackOrder(0)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public List<DropInfo> DropItems { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActorId = default;
			this.UnitId = default;
			this.DropItems.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CreateDropItems)]
	[MemoryPackable]
	public partial class M2C_CreateDropItems: MessageObject, IMessage
	{
		public static M2C_CreateDropItems Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CreateDropItems), isFromPool) as M2C_CreateDropItems; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(93)]
		public long UnitId { get; set; }

		[MemoryPackOrder(0)]
		public List<DropInfo> Drops { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.Drops.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//组队副本结算
	[Message(OuterMessage.M2C_TeamDungeonSettlement)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonSettlement: MessageObject, IMessage
	{
		public static M2C_TeamDungeonSettlement Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonSettlement), isFromPool) as M2C_TeamDungeonSettlement; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long PassTime { get; set; }

		[MemoryPackOrder(1)]
		public List<TeamPlayerInfo> PlayerList { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<RewardItem> RewardExtraItem { get; set; } = new();

		[MemoryPackOrder(4)]
		public List<RewardItem> ReardList { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<RewardItem> ReardListExcess { get; set; } = new();

		[MemoryPackOrder(6)]
		public int Star { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.ActorId = default;
			this.PassTime = default;
			this.PlayerList.Clear();
			this.RewardExtraItem.Clear();
			this.ReardList.Clear();
			this.ReardListExcess.Clear();
			this.Star = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SyncChatInfo)]
	[MemoryPackable]
	public partial class M2C_SyncChatInfo: MessageObject, IMessage
	{
		public static M2C_SyncChatInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SyncChatInfo), isFromPool) as M2C_SyncChatInfo; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public ChatInfo ChatInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChatInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Center2C_PhoneBinging))]
//手机号绑定
	[Message(OuterMessage.C2Center_PhoneBinging)]
	[MemoryPackable]
	public partial class C2Center_PhoneBinging: MessageObject, IRequest
	{
		public static C2Center_PhoneBinging Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Center_PhoneBinging), isFromPool) as C2Center_PhoneBinging; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string PhoneNumber { get; set; }

		[MemoryPackOrder(1)]
		public long AccountId { get; set; }

		[MemoryPackOrder(2)]
		public string Account { get; set; }

		[MemoryPackOrder(3)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PhoneNumber = default;
			this.AccountId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Center2C_PhoneBinging)]
	[MemoryPackable]
	public partial class Center2C_PhoneBinging: MessageObject, IResponse
	{
		public static Center2C_PhoneBinging Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2C_PhoneBinging), isFromPool) as Center2C_PhoneBinging; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Center2C_Register))]
	[Message(OuterMessage.C2Center_Register)]
	[MemoryPackable]
	public partial class C2Center_Register: MessageObject, IRequest
	{
		public static C2Center_Register Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Center_Register), isFromPool) as C2Center_Register; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string Account { get; set; }

		[MemoryPackOrder(1)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Center2C_Register)]
	[MemoryPackable]
	public partial class Center2C_Register: MessageObject, IResponse
	{
		public static Center2C_Register Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2C_Register), isFromPool) as Center2C_Register; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Center2C_BlackAccountResponse))]
	[Message(OuterMessage.C2Center_BlackAccountRequest)]
	[MemoryPackable]
	public partial class C2Center_BlackAccountRequest: MessageObject, IRequest
	{
		public static C2Center_BlackAccountRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Center_BlackAccountRequest), isFromPool) as C2Center_BlackAccountRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string Account { get; set; }

		[MemoryPackOrder(1)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Center2C_BlackAccountResponse)]
	[MemoryPackable]
	public partial class Center2C_BlackAccountResponse: MessageObject, IResponse
	{
		public static Center2C_BlackAccountResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2C_BlackAccountResponse), isFromPool) as Center2C_BlackAccountResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Center2M_BuChangeResponse))]
	[Message(OuterMessage.M2Center_BuChangeRequest)]
	[MemoryPackable]
	public partial class M2Center_BuChangeRequest: MessageObject, IRequest
	{
		public static M2Center_BuChangeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2Center_BuChangeRequest), isFromPool) as M2Center_BuChangeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long BuChangId { get; set; }

		[MemoryPackOrder(1)]
		public long UserId { get; set; }

		[MemoryPackOrder(2)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.BuChangId = default;
			this.UserId = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Center2M_BuChangeResponse)]
	[MemoryPackable]
	public partial class Center2M_BuChangeResponse: MessageObject, IResponse
	{
		public static Center2M_BuChangeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2M_BuChangeResponse), isFromPool) as Center2M_BuChangeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public PlayerInfo PlayerInfo { get; set; }

		[MemoryPackOrder(1)]
		public int BuChangRecharge { get; set; }

		[MemoryPackOrder(2)]
		public int BuChangDiamond { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerInfo = default;
			this.BuChangRecharge = default;
			this.BuChangDiamond = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(C2C_ChatJinYanResponse))]
	[Message(OuterMessage.C2C_ChatJinYanRequest)]
	[MemoryPackable]
	public partial class C2C_ChatJinYanRequest: MessageObject, IChatActorRequest
	{
		public static C2C_ChatJinYanRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_ChatJinYanRequest), isFromPool) as C2C_ChatJinYanRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long JinYanId { get; set; }

		[MemoryPackOrder(2)]
		public string JinYanPlayer { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.JinYanId = default;
			this.JinYanPlayer = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2C_ChatJinYanResponse)]
	[MemoryPackable]
	public partial class C2C_ChatJinYanResponse: MessageObject, IChatActorResponse
	{
		public static C2C_ChatJinYanResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_ChatJinYanResponse), isFromPool) as C2C_ChatJinYanResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ReceiveMailResponse))]
	[Message(OuterMessage.C2M_ReceiveMailRequest)]
	[MemoryPackable]
	public partial class C2M_ReceiveMailRequest: MessageObject, ILocationRequest
	{
		public static C2M_ReceiveMailRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ReceiveMailRequest), isFromPool) as C2M_ReceiveMailRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long MailId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MailId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReceiveMailResponse)]
	[MemoryPackable]
	public partial class M2C_ReceiveMailResponse: MessageObject, ILocationResponse
	{
		public static M2C_ReceiveMailResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveMailResponse), isFromPool) as M2C_ReceiveMailResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(E2C_ReceiveMailResponse))]
	[Message(OuterMessage.C2E_ReceiveMailRequest)]
	[MemoryPackable]
	public partial class C2E_ReceiveMailRequest: MessageObject, IMailActorRequest
	{
		public static C2E_ReceiveMailRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2E_ReceiveMailRequest), isFromPool) as C2E_ReceiveMailRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long MailId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MailId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.E2C_ReceiveMailResponse)]
	[MemoryPackable]
	public partial class E2C_ReceiveMailResponse: MessageObject, IMailActorResponse
	{
		public static E2C_ReceiveMailResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(E2C_ReceiveMailResponse), isFromPool) as E2C_ReceiveMailResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(E2C_GetAllMailResponse))]
	[Message(OuterMessage.C2E_GetAllMailRequest)]
	[MemoryPackable]
	public partial class C2E_GetAllMailRequest: MessageObject, IMailActorRequest
	{
		public static C2E_GetAllMailRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2E_GetAllMailRequest), isFromPool) as C2E_GetAllMailRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.E2C_GetAllMailResponse)]
	[MemoryPackable]
	public partial class E2C_GetAllMailResponse: MessageObject, IMailActorResponse
	{
		public static E2C_GetAllMailResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(E2C_GetAllMailResponse), isFromPool) as E2C_GetAllMailResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<MailInfo> MailInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MailInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(F2C_WatchPetResponse))]
	[Message(OuterMessage.C2F_WatchPetRequest)]
	[MemoryPackable]
	public partial class C2F_WatchPetRequest: MessageObject, IFriendActorRequest
	{
		public static C2F_WatchPetRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2F_WatchPetRequest), isFromPool) as C2F_WatchPetRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitID { get; set; }

		[MemoryPackOrder(1)]
		public long PetId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitID = default;
			this.PetId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.F2C_WatchPetResponse)]
	[MemoryPackable]
	public partial class F2C_WatchPetResponse: MessageObject, IFriendActorResponse
	{
		public static F2C_WatchPetResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2C_WatchPetResponse), isFromPool) as F2C_WatchPetResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(6)]
		public RolePetInfo RolePetInfos { get; set; }

		[MemoryPackOrder(7)]
		public List<BagInfo> PetHeXinList { get; set; } = new();

		[MemoryPackOrder(8)]
		public List<int> Ks { get; set; } = new();

		[MemoryPackOrder(9)]
		public List<long> Vs { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RolePetInfos = default;
			this.PetHeXinList.Clear();
			this.Ks.Clear();
			this.Vs.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//喜从天降刷新
	[ResponseType(nameof(M2C_HappyMoveResponse))]
	[Message(OuterMessage.C2M_HappyMoveRequest)]
	[MemoryPackable]
	public partial class C2M_HappyMoveRequest: MessageObject, ILocationRequest
	{
		public static C2M_HappyMoveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_HappyMoveRequest), isFromPool) as C2M_HappyMoveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperatateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperatateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_HappyMoveResponse)]
	[MemoryPackable]
	public partial class M2C_HappyMoveResponse: MessageObject, ILocationResponse
	{
		public static M2C_HappyMoveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_HappyMoveResponse), isFromPool) as M2C_HappyMoveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_HongBaoOpenResponse))]
//开启红包
	[Message(OuterMessage.C2M_HongBaoOpenRequest)]
	[MemoryPackable]
	public partial class C2M_HongBaoOpenRequest: MessageObject, ILocationRequest
	{
		public static C2M_HongBaoOpenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_HongBaoOpenRequest), isFromPool) as C2M_HongBaoOpenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_HongBaoOpenResponse)]
	[MemoryPackable]
	public partial class M2C_HongBaoOpenResponse: MessageObject, ILocationResponse
	{
		public static M2C_HongBaoOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_HongBaoOpenResponse), isFromPool) as M2C_HongBaoOpenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int HongbaoAmount { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.HongbaoAmount = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PaiMaiAuctionJoinResponse))]
//参入竞拍
	[Message(OuterMessage.C2M_PaiMaiAuctionJoinRequest)]
	[MemoryPackable]
	public partial class C2M_PaiMaiAuctionJoinRequest: MessageObject, ILocationRequest
	{
		public static C2M_PaiMaiAuctionJoinRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PaiMaiAuctionJoinRequest), isFromPool) as C2M_PaiMaiAuctionJoinRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PaiMaiAuctionJoinResponse)]
	[MemoryPackable]
	public partial class M2C_PaiMaiAuctionJoinResponse: MessageObject, ILocationResponse
	{
		public static M2C_PaiMaiAuctionJoinResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PaiMaiAuctionJoinResponse), isFromPool) as M2C_PaiMaiAuctionJoinResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PaiMaiAuctionPriceResponse))]
	[Message(OuterMessage.C2M_PaiMaiAuctionPriceRequest)]
	[MemoryPackable]
	public partial class C2M_PaiMaiAuctionPriceRequest: MessageObject, ILocationRequest
	{
		public static C2M_PaiMaiAuctionPriceRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PaiMaiAuctionPriceRequest), isFromPool) as C2M_PaiMaiAuctionPriceRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Price { get; set; }

		[MemoryPackOrder(1)]
		public string AuctionPlayer { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Price = default;
			this.AuctionPlayer = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PaiMaiAuctionPriceResponse)]
	[MemoryPackable]
	public partial class M2C_PaiMaiAuctionPriceResponse: MessageObject, ILocationResponse
	{
		public static M2C_PaiMaiAuctionPriceResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PaiMaiAuctionPriceResponse), isFromPool) as M2C_PaiMaiAuctionPriceResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PaiMaiBuyResponse))]
	[Message(OuterMessage.C2M_PaiMaiBuyRequest)]
	[MemoryPackable]
	public partial class C2M_PaiMaiBuyRequest: MessageObject, ILocationRequest
	{
		public static C2M_PaiMaiBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PaiMaiBuyRequest), isFromPool) as C2M_PaiMaiBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		[MemoryPackOrder(1)]
		public int BuyNum { get; set; }

		[MemoryPackOrder(2)]
		public int IsRecharge { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfo = default;
			this.BuyNum = default;
			this.IsRecharge = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PaiMaiBuyResponse)]
	[MemoryPackable]
	public partial class M2C_PaiMaiBuyResponse: MessageObject, ILocationResponse
	{
		public static M2C_PaiMaiBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PaiMaiBuyResponse), isFromPool) as M2C_PaiMaiBuyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PaiMaiDuiHuanResponse))]
	[Message(OuterMessage.C2M_PaiMaiDuiHuanRequest)]
	[MemoryPackable]
	public partial class C2M_PaiMaiDuiHuanRequest: MessageObject, ILocationRequest
	{
		public static C2M_PaiMaiDuiHuanRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PaiMaiDuiHuanRequest), isFromPool) as C2M_PaiMaiDuiHuanRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long DiamondsNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.DiamondsNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PaiMaiDuiHuanResponse)]
	[MemoryPackable]
	public partial class M2C_PaiMaiDuiHuanResponse: MessageObject, ILocationResponse
	{
		public static M2C_PaiMaiDuiHuanResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PaiMaiDuiHuanResponse), isFromPool) as M2C_PaiMaiDuiHuanResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PaiMaiSellResponse))]
	[Message(OuterMessage.C2M_PaiMaiSellRequest)]
	[MemoryPackable]
	public partial class C2M_PaiMaiSellRequest: MessageObject, ILocationRequest
	{
		public static C2M_PaiMaiSellRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PaiMaiSellRequest), isFromPool) as C2M_PaiMaiSellRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		[MemoryPackOrder(2)]
		public int IsRecharge { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfo = default;
			this.IsRecharge = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PaiMaiSellResponse)]
	[MemoryPackable]
	public partial class M2C_PaiMaiSellResponse: MessageObject, ILocationResponse
	{
		public static M2C_PaiMaiSellResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PaiMaiSellResponse), isFromPool) as M2C_PaiMaiSellResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PaiMaiItemInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PaiMaiShopResponse))]
	[Message(OuterMessage.C2M_PaiMaiShopRequest)]
	[MemoryPackable]
	public partial class C2M_PaiMaiShopRequest: MessageObject, ILocationRequest
	{
		public static C2M_PaiMaiShopRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PaiMaiShopRequest), isFromPool) as C2M_PaiMaiShopRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int PaiMaiId { get; set; }

		[MemoryPackOrder(1)]
		public int BuyNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiId = default;
			this.BuyNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PaiMaiShopResponse)]
	[MemoryPackable]
	public partial class M2C_PaiMaiShopResponse: MessageObject, ILocationResponse
	{
		public static M2C_PaiMaiShopResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PaiMaiShopResponse), isFromPool) as M2C_PaiMaiShopResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_PaiMaiXiaJiaResponse))]
	[Message(OuterMessage.C2M_PaiMaiXiaJiaRequest)]
	[MemoryPackable]
	public partial class C2M_PaiMaiXiaJiaRequest: MessageObject, ILocationRequest
	{
		public static C2M_PaiMaiXiaJiaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PaiMaiXiaJiaRequest), isFromPool) as C2M_PaiMaiXiaJiaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ItemType { get; set; }

		[MemoryPackOrder(1)]
		public long PaiMaiItemInfoId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ItemType = default;
			this.PaiMaiItemInfoId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PaiMaiXiaJiaResponse)]
	[MemoryPackable]
	public partial class M2C_PaiMaiXiaJiaResponse: MessageObject, ILocationResponse
	{
		public static M2C_PaiMaiXiaJiaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PaiMaiXiaJiaResponse), isFromPool) as M2C_PaiMaiXiaJiaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_StallBuyResponse))]
	[Message(OuterMessage.C2M_StallBuyRequest)]
	[MemoryPackable]
	public partial class C2M_StallBuyRequest: MessageObject, ILocationRequest
	{
		public static C2M_StallBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_StallBuyRequest), isFromPool) as C2M_StallBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StallBuyResponse)]
	[MemoryPackable]
	public partial class M2C_StallBuyResponse: MessageObject, ILocationResponse
	{
		public static M2C_StallBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StallBuyResponse), isFromPool) as M2C_StallBuyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//摆摊
	[ResponseType(nameof(M2C_StallOperationResponse))]
	[Message(OuterMessage.C2M_StallOperationRequest)]
	[MemoryPackable]
	public partial class C2M_StallOperationRequest: MessageObject, ILocationRequest
	{
		public static C2M_StallOperationRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_StallOperationRequest), isFromPool) as C2M_StallOperationRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int StallType { get; set; }

		[MemoryPackOrder(1)]
		public string Value { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.StallType = default;
			this.Value = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StallOperationResponse)]
	[MemoryPackable]
	public partial class M2C_StallOperationResponse: MessageObject, ILocationResponse
	{
		public static M2C_StallOperationResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StallOperationResponse), isFromPool) as M2C_StallOperationResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_StallSellResponse))]
	[Message(OuterMessage.C2M_StallSellRequest)]
	[MemoryPackable]
	public partial class C2M_StallSellRequest: MessageObject, ILocationRequest
	{
		public static C2M_StallSellRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_StallSellRequest), isFromPool) as C2M_StallSellRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StallSellResponse)]
	[MemoryPackable]
	public partial class M2C_StallSellResponse: MessageObject, ILocationResponse
	{
		public static M2C_StallSellResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StallSellResponse), isFromPool) as M2C_StallSellResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PaiMaiItemInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_StallXiaJiaResponse))]
	[Message(OuterMessage.C2M_StallXiaJiaRequest)]
	[MemoryPackable]
	public partial class C2M_StallXiaJiaRequest: MessageObject, ILocationRequest
	{
		public static C2M_StallXiaJiaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_StallXiaJiaRequest), isFromPool) as C2M_StallXiaJiaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long PaiMaiItemInfoId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfoId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StallXiaJiaResponse)]
	[MemoryPackable]
	public partial class M2C_StallXiaJiaResponse: MessageObject, ILocationResponse
	{
		public static M2C_StallXiaJiaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StallXiaJiaResponse), isFromPool) as M2C_StallXiaJiaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2C_PaiMaiAuctionInfoResponse))]
	[Message(OuterMessage.C2P_PaiMaiAuctionInfoRequest)]
	[MemoryPackable]
	public partial class C2P_PaiMaiAuctionInfoRequest: MessageObject, IPaiMaiListRequest
	{
		public static C2P_PaiMaiAuctionInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2P_PaiMaiAuctionInfoRequest), isFromPool) as C2P_PaiMaiAuctionInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.P2C_PaiMaiAuctionInfoResponse)]
	[MemoryPackable]
	public partial class P2C_PaiMaiAuctionInfoResponse: MessageObject, IPaiMaiListResponse
	{
		public static P2C_PaiMaiAuctionInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2C_PaiMaiAuctionInfoResponse), isFromPool) as P2C_PaiMaiAuctionInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int AuctionItem { get; set; }

		[MemoryPackOrder(1)]
		public long AuctionPrice { get; set; }

		[MemoryPackOrder(2)]
		public int AuctionStatus { get; set; }

		[MemoryPackOrder(3)]
		public int AuctionNumber { get; set; }

		[MemoryPackOrder(4)]
		public string AuctionPlayer { get; set; }

		[MemoryPackOrder(5)]
		public long AuctionStart { get; set; }

		[MemoryPackOrder(6)]
		public bool AuctionJoin { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.AuctionItem = default;
			this.AuctionPrice = default;
			this.AuctionStatus = default;
			this.AuctionNumber = default;
			this.AuctionPlayer = default;
			this.AuctionStart = default;
			this.AuctionJoin = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2C_PaiMaiAuctionRecordResponse))]
	[Message(OuterMessage.C2P_PaiMaiAuctionRecordRequest)]
	[MemoryPackable]
	public partial class C2P_PaiMaiAuctionRecordRequest: MessageObject, IPaiMaiListRequest
	{
		public static C2P_PaiMaiAuctionRecordRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2P_PaiMaiAuctionRecordRequest), isFromPool) as C2P_PaiMaiAuctionRecordRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.P2C_PaiMaiAuctionRecordResponse)]
	[MemoryPackable]
	public partial class P2C_PaiMaiAuctionRecordResponse: MessageObject, IPaiMaiListResponse
	{
		public static P2C_PaiMaiAuctionRecordResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2C_PaiMaiAuctionRecordResponse), isFromPool) as P2C_PaiMaiAuctionRecordResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<PaiMaiAuctionRecord> RecordList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RecordList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2C_PaiMaiFindResponse))]
	[Message(OuterMessage.C2P_PaiMaiFindRequest)]
	[MemoryPackable]
	public partial class C2P_PaiMaiFindRequest: MessageObject, IPaiMaiListRequest
	{
		public static C2P_PaiMaiFindRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2P_PaiMaiFindRequest), isFromPool) as C2P_PaiMaiFindRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ItemType { get; set; }

		[MemoryPackOrder(1)]
		public long PaiMaiItemInfoId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ItemType = default;
			this.PaiMaiItemInfoId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.P2C_PaiMaiFindResponse)]
	[MemoryPackable]
	public partial class P2C_PaiMaiFindResponse: MessageObject, IPaiMaiListResponse
	{
		public static P2C_PaiMaiFindResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2C_PaiMaiFindResponse), isFromPool) as P2C_PaiMaiFindResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int Page { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Page = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2C_PaiMaiListResponse))]
	[Message(OuterMessage.C2P_PaiMaiListRequest)]
	[MemoryPackable]
	public partial class C2P_PaiMaiListRequest: MessageObject, IPaiMaiListRequest
	{
		public static C2P_PaiMaiListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2P_PaiMaiListRequest), isFromPool) as C2P_PaiMaiListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public int PaiMaiType { get; set; }

		[MemoryPackOrder(2)]
		public int Page { get; set; }

		[MemoryPackOrder(3)]
		public int PaiMaiShowType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			this.PaiMaiType = default;
			this.Page = default;
			this.PaiMaiShowType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.P2C_PaiMaiListResponse)]
	[MemoryPackable]
	public partial class P2C_PaiMaiListResponse: MessageObject, IPaiMaiListResponse
	{
		public static P2C_PaiMaiListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2C_PaiMaiListResponse), isFromPool) as P2C_PaiMaiListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<PaiMaiItemInfo> PaiMaiItemInfos { get; set; } = new();

		[MemoryPackOrder(1)]
		public int NextPage { get; set; }

		[MemoryPackOrder(2)]
		public long PaiMaiCostGoldToday { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PaiMaiItemInfos.Clear();
			this.NextPage = default;
			this.PaiMaiCostGoldToday = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2C_PaiMaiSearchResponse))]
	[Message(OuterMessage.C2P_PaiMaiSearchRequest)]
	[MemoryPackable]
	public partial class C2P_PaiMaiSearchRequest: MessageObject, IPaiMaiListRequest
	{
		public static C2P_PaiMaiSearchRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2P_PaiMaiSearchRequest), isFromPool) as C2P_PaiMaiSearchRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<int> FindItemIdList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> FindTypeList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.FindItemIdList.Clear();
			this.FindTypeList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.P2C_PaiMaiSearchResponse)]
	[MemoryPackable]
	public partial class P2C_PaiMaiSearchResponse: MessageObject, IPaiMaiListResponse
	{
		public static P2C_PaiMaiSearchResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2C_PaiMaiSearchResponse), isFromPool) as P2C_PaiMaiSearchResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<PaiMaiItemInfo> PaiMaiItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PaiMaiItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2C_PaiMaiShopShowListResponse))]
	[Message(OuterMessage.C2P_PaiMaiShopShowListRequest)]
	[MemoryPackable]
	public partial class C2P_PaiMaiShopShowListRequest: MessageObject, IPaiMaiListRequest
	{
		public static C2P_PaiMaiShopShowListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2P_PaiMaiShopShowListRequest), isFromPool) as C2P_PaiMaiShopShowListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.P2C_PaiMaiShopShowListResponse)]
	[MemoryPackable]
	public partial class P2C_PaiMaiShopShowListResponse: MessageObject, IPaiMaiListResponse
	{
		public static P2C_PaiMaiShopShowListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2C_PaiMaiShopShowListResponse), isFromPool) as P2C_PaiMaiShopShowListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<PaiMaiShopItemInfo> PaiMaiShopItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PaiMaiShopItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2C_StallListResponse))]
	[Message(OuterMessage.C2P_StallListRequest)]
	[MemoryPackable]
	public partial class C2P_StallListRequest: MessageObject, IPaiMaiListRequest
	{
		public static C2P_StallListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2P_StallListRequest), isFromPool) as C2P_StallListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.P2C_StallListResponse)]
	[MemoryPackable]
	public partial class P2C_StallListResponse: MessageObject, IPaiMaiListResponse
	{
		public static P2C_StallListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2C_StallListResponse), isFromPool) as P2C_StallListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<PaiMaiItemInfo> PaiMaiItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PaiMaiItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BuChangeResponse))]
	[Message(OuterMessage.C2M_BuChangeRequest)]
	[MemoryPackable]
	public partial class C2M_BuChangeRequest: MessageObject, ILocationRequest
	{
		public static C2M_BuChangeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BuChangeRequest), isFromPool) as C2M_BuChangeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long BuChangId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.BuChangId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuChangeResponse)]
	[MemoryPackable]
	public partial class M2C_BuChangeResponse: MessageObject, ILocationResponse
	{
		public static M2C_BuChangeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuChangeResponse), isFromPool) as M2C_BuChangeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public PlayerInfo PlayerInfo { get; set; }

		[MemoryPackOrder(1)]
		public int BuChangRecharge { get; set; }

		[MemoryPackOrder(2)]
		public int BuChangDiamond { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerInfo = default;
			this.BuChangRecharge = default;
			this.BuChangDiamond = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_CreateSpiling)]
	[MemoryPackable]
	public partial class C2M_CreateSpiling: MessageObject, ILocationMessage
	{
		public static C2M_CreateSpiling Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_CreateSpiling), isFromPool) as C2M_CreateSpiling; 
		}

		[MemoryPackOrder(1)]
		public float X { get; set; }

		[MemoryPackOrder(2)]
		public float Y { get; set; }

		[MemoryPackOrder(3)]
		public float Z { get; set; }

//所归属的父实体id
		[MemoryPackOrder(4)]
		public long ParentUnitId { get; set; }

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(93)]
		public long Id { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.X = default;
			this.Y = default;
			this.Z = default;
			this.ParentUnitId = default;
			this.RpcId = default;
			this.ActorId = default;
			this.Id = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//个人副本喜从天降移动
	[ResponseType(nameof(M2C_DungeonHappyMoveResponse))]
	[Message(OuterMessage.C2M_DungeonHappyMoveRequest)]
	[MemoryPackable]
	public partial class C2M_DungeonHappyMoveRequest: MessageObject, ILocationRequest
	{
		public static C2M_DungeonHappyMoveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_DungeonHappyMoveRequest), isFromPool) as C2M_DungeonHappyMoveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperatateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperatateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_DungeonHappyMoveResponse)]
	[MemoryPackable]
	public partial class M2C_DungeonHappyMoveResponse: MessageObject, ILocationResponse
	{
		public static M2C_DungeonHappyMoveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_DungeonHappyMoveResponse), isFromPool) as M2C_DungeonHappyMoveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_FindJingLingResponse))]
	[Message(OuterMessage.C2M_FindJingLingRequest)]
	[MemoryPackable]
	public partial class C2M_FindJingLingRequest: MessageObject, ILocationRequest
	{
		public static C2M_FindJingLingRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_FindJingLingRequest), isFromPool) as C2M_FindJingLingRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FindJingLingResponse)]
	[MemoryPackable]
	public partial class M2C_FindJingLingResponse: MessageObject, ILocationResponse
	{
		public static M2C_FindJingLingResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FindJingLingResponse), isFromPool) as M2C_FindJingLingResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(4)]
		public int MonsterID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.MonsterID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_FindNearMonsterResponse))]
	[Message(OuterMessage.C2M_FindNearMonsterRequest)]
	[MemoryPackable]
	public partial class C2M_FindNearMonsterRequest: MessageObject, ILocationRequest
	{
		public static C2M_FindNearMonsterRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_FindNearMonsterRequest), isFromPool) as C2M_FindNearMonsterRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FindNearMonsterResponse)]
	[MemoryPackable]
	public partial class M2C_FindNearMonsterResponse: MessageObject, ILocationResponse
	{
		public static M2C_FindNearMonsterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FindNearMonsterResponse), isFromPool) as M2C_FindNearMonsterResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public float x { get; set; }

		[MemoryPackOrder(1)]
		public float y { get; set; }

		[MemoryPackOrder(2)]
		public float z { get; set; }

		[MemoryPackOrder(3)]
		public bool IfFindStatus { get; set; }

		[MemoryPackOrder(4)]
		public long MonsterID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.x = default;
			this.y = default;
			this.z = default;
			this.IfFindStatus = default;
			this.MonsterID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_FirstWinSelfRewardResponse))]
	[Message(OuterMessage.C2M_FirstWinSelfRewardRequest)]
	[MemoryPackable]
	public partial class C2M_FirstWinSelfRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_FirstWinSelfRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_FirstWinSelfRewardRequest), isFromPool) as C2M_FirstWinSelfRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int FirstWinId { get; set; }

		[MemoryPackOrder(1)]
		public int Difficulty { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.FirstWinId = default;
			this.Difficulty = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FirstWinSelfRewardResponse)]
	[MemoryPackable]
	public partial class M2C_FirstWinSelfRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_FirstWinSelfRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FirstWinSelfRewardResponse), isFromPool) as M2C_FirstWinSelfRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<KeyValuePair> FirstWinInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FirstWinInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//通用协议 应急用
	[ResponseType(nameof(M2C_FubenMessageResponse))]
	[Message(OuterMessage.C2M_FubenMessageRequest)]
	[MemoryPackable]
	public partial class C2M_FubenMessageRequest: MessageObject, ILocationRequest
	{
		public static C2M_FubenMessageRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_FubenMessageRequest), isFromPool) as C2M_FubenMessageRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SceneType { get; set; }

		[MemoryPackOrder(1)]
		public int MessageType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SceneType = default;
			this.MessageType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FubenMessageResponse)]
	[MemoryPackable]
	public partial class M2C_FubenMessageResponse: MessageObject, ILocationResponse
	{
		public static M2C_FubenMessageResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FubenMessageResponse), isFromPool) as M2C_FubenMessageResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public string MessageValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MessageValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_FubenTimesResetResponse))]
	[Message(OuterMessage.C2M_FubenTimesResetRequest)]
	[MemoryPackable]
	public partial class C2M_FubenTimesResetRequest: MessageObject, ILocationRequest
	{
		public static C2M_FubenTimesResetRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_FubenTimesResetRequest), isFromPool) as C2M_FubenTimesResetRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SceneType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SceneType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FubenTimesResetResponse)]
	[MemoryPackable]
	public partial class M2C_FubenTimesResetResponse: MessageObject, ILocationResponse
	{
		public static M2C_FubenTimesResetResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FubenTimesResetResponse), isFromPool) as M2C_FubenTimesResetResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GameSettingResponse))]
//游戏设置
	[Message(OuterMessage.C2M_GameSettingRequest)]
	[MemoryPackable]
	public partial class C2M_GameSettingRequest: MessageObject, ILocationRequest
	{
		public static C2M_GameSettingRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GameSettingRequest), isFromPool) as C2M_GameSettingRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public List<KeyValuePair> GameSettingInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.GameSettingInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GameSettingResponse)]
	[MemoryPackable]
	public partial class M2C_GameSettingResponse: MessageObject, ILocationResponse
	{
		public static M2C_GameSettingResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GameSettingResponse), isFromPool) as M2C_GameSettingResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GMCustomResponse))]
	[Message(OuterMessage.C2M_GMCustomRequest)]
	[MemoryPackable]
	public partial class C2M_GMCustomRequest: MessageObject, ILocationRequest
	{
		public static C2M_GMCustomRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GMCustomRequest), isFromPool) as C2M_GMCustomRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GMCustomResponse)]
	[MemoryPackable]
	public partial class M2C_GMCustomResponse: MessageObject, ILocationResponse
	{
		public static M2C_GMCustomResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GMCustomResponse), isFromPool) as M2C_GMCustomResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GuideUpdateResponse))]
	[Message(OuterMessage.C2M_GuideUpdateRequest)]
	[MemoryPackable]
	public partial class C2M_GuideUpdateRequest: MessageObject, ILocationRequest
	{
		public static C2M_GuideUpdateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GuideUpdateRequest), isFromPool) as C2M_GuideUpdateRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int GuideId { get; set; }

		[MemoryPackOrder(2)]
		public int GuideStep { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.GuideId = default;
			this.GuideStep = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GuideUpdateResponse)]
	[MemoryPackable]
	public partial class M2C_GuideUpdateResponse: MessageObject, ILocationResponse
	{
		public static M2C_GuideUpdateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GuideUpdateResponse), isFromPool) as M2C_GuideUpdateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_KillMonsterRewardResponse))]
	[Message(OuterMessage.C2M_KillMonsterRewardRequest)]
	[MemoryPackable]
	public partial class C2M_KillMonsterRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_KillMonsterRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_KillMonsterRewardRequest), isFromPool) as C2M_KillMonsterRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int Key { get; set; }

		[MemoryPackOrder(1)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_KillMonsterRewardResponse)]
	[MemoryPackable]
	public partial class M2C_KillMonsterRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_KillMonsterRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_KillMonsterRewardResponse), isFromPool) as M2C_KillMonsterRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_LeavlRewardResponse))]
	[Message(OuterMessage.C2M_LeavlRewardRequest)]
	[MemoryPackable]
	public partial class C2M_LeavlRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_LeavlRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_LeavlRewardRequest), isFromPool) as C2M_LeavlRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int LvKey { get; set; }

		[MemoryPackOrder(1)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.LvKey = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_LeavlRewardResponse)]
	[MemoryPackable]
	public partial class M2C_LeavlRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_LeavlRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_LeavlRewardResponse), isFromPool) as M2C_LeavlRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ModifyNameResponse))]
//改游戏名
	[Message(OuterMessage.C2M_ModifyNameRequest)]
	[MemoryPackable]
	public partial class C2M_ModifyNameRequest: MessageObject, ILocationRequest
	{
		public static C2M_ModifyNameRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ModifyNameRequest), isFromPool) as C2M_ModifyNameRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string NewName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.NewName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ModifyNameResponse)]
	[MemoryPackable]
	public partial class M2C_ModifyNameResponse: MessageObject, ILocationResponse
	{
		public static M2C_ModifyNameResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ModifyNameResponse), isFromPool) as M2C_ModifyNameResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MysteryBuyResponse))]
	[Message(OuterMessage.C2M_MysteryBuyRequest)]
	[MemoryPackable]
	public partial class C2M_MysteryBuyRequest: MessageObject, ILocationRequest
	{
		public static C2M_MysteryBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_MysteryBuyRequest), isFromPool) as C2M_MysteryBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public MysteryItemInfo MysteryItemInfo { get; set; }

		[MemoryPackOrder(1)]
		public int NpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MysteryItemInfo = default;
			this.NpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_MysteryBuyResponse)]
	[MemoryPackable]
	public partial class M2C_MysteryBuyResponse: MessageObject, ILocationResponse
	{
		public static M2C_MysteryBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_MysteryBuyResponse), isFromPool) as M2C_MysteryBuyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_OneChallengeResponse))]
	[Message(OuterMessage.C2M_OneChallengeRequest)]
	[MemoryPackable]
	public partial class C2M_OneChallengeRequest: MessageObject, ILocationRequest
	{
		public static C2M_OneChallengeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_OneChallengeRequest), isFromPool) as C2M_OneChallengeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long OtherId { get; set; }

		[MemoryPackOrder(1)]
		public int Operatate { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OtherId = default;
			this.Operatate = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_OneChallengeResponse)]
	[MemoryPackable]
	public partial class M2C_OneChallengeResponse: MessageObject, ILocationResponse
	{
		public static M2C_OneChallengeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_OneChallengeResponse), isFromPool) as M2C_OneChallengeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public int Operatate { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.Operatate = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_OneChallenge)]
	[MemoryPackable]
	public partial class M2C_OneChallenge: MessageObject, IMessage
	{
		public static M2C_OneChallenge Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_OneChallenge), isFromPool) as M2C_OneChallenge; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Operatate { get; set; }

		[MemoryPackOrder(1)]
		public long OtherId { get; set; }

		[MemoryPackOrder(2)]
		public string OtherName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Operatate = default;
			this.OtherId = default;
			this.OtherName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ReddotReadResponse))]
	[Message(OuterMessage.C2M_ReddotReadRequest)]
	[MemoryPackable]
	public partial class C2M_ReddotReadRequest: MessageObject, ILocationRequest
	{
		public static C2M_ReddotReadRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ReddotReadRequest), isFromPool) as C2M_ReddotReadRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int ReddotType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ReddotType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReddotReadResponse)]
	[MemoryPackable]
	public partial class M2C_ReddotReadResponse: MessageObject, ILocationResponse
	{
		public static M2C_ReddotReadResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReddotReadResponse), isFromPool) as M2C_ReddotReadResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//重连成功刷新Unit
	[Message(OuterMessage.C2M_RefreshUnitRequest)]
	[MemoryPackable]
	public partial class C2M_RefreshUnitRequest: MessageObject, ILocationMessage
	{
		public static C2M_RefreshUnitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RefreshUnitRequest), isFromPool) as C2M_RefreshUnitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SerialReardResponse))]
//序列号奖励
	[Message(OuterMessage.C2M_SerialReardRequest)]
	[MemoryPackable]
	public partial class C2M_SerialReardRequest: MessageObject, ILocationRequest
	{
		public static C2M_SerialReardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SerialReardRequest), isFromPool) as C2M_SerialReardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string SerialNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SerialNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SerialReardResponse)]
	[MemoryPackable]
	public partial class M2C_SerialReardResponse: MessageObject, ILocationResponse
	{
		public static M2C_SerialReardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SerialReardResponse), isFromPool) as M2C_SerialReardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ShareSucessResponse))]
	[Message(OuterMessage.C2M_ShareSucessRequest)]
	[MemoryPackable]
	public partial class C2M_ShareSucessRequest: MessageObject, ILocationRequest
	{
		public static C2M_ShareSucessRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ShareSucessRequest), isFromPool) as C2M_ShareSucessRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ShareType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ShareType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ShareSucessResponse)]
	[MemoryPackable]
	public partial class M2C_ShareSucessResponse: MessageObject, ILocationResponse
	{
		public static M2C_ShareSucessResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ShareSucessResponse), isFromPool) as M2C_ShareSucessResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_UnitInfoResponse))]
	[Message(OuterMessage.C2M_UnitInfoRequest)]
	[MemoryPackable]
	public partial class C2M_UnitInfoRequest: MessageObject, ILocationRequest
	{
		public static C2M_UnitInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnitInfoRequest), isFromPool) as C2M_UnitInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnitInfoResponse)]
	[MemoryPackable]
	public partial class M2C_UnitInfoResponse: MessageObject, ILocationResponse
	{
		public static M2C_UnitInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnitInfoResponse), isFromPool) as M2C_UnitInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(5)]
		public List<int> Ks { get; set; } = new();

		[MemoryPackOrder(6)]
		public List<long> Vs { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Ks.Clear();
			this.Vs.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_XiuLianCenterResponse))]
	[Message(OuterMessage.C2M_XiuLianCenterRequest)]
	[MemoryPackable]
	public partial class C2M_XiuLianCenterRequest: MessageObject, ILocationRequest
	{
		public static C2M_XiuLianCenterRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_XiuLianCenterRequest), isFromPool) as C2M_XiuLianCenterRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int XiuLianType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.XiuLianType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_XiuLianCenterResponse)]
	[MemoryPackable]
	public partial class M2C_XiuLianCenterResponse: MessageObject, ILocationResponse
	{
		public static M2C_XiuLianCenterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_XiuLianCenterResponse), isFromPool) as M2C_XiuLianCenterResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Popularize2C_ListResponse))]
//我的推广列表
	[Message(OuterMessage.C2Popularize_ListRequest)]
	[MemoryPackable]
	public partial class C2Popularize_ListRequest: MessageObject, IPopularizeActorRequest
	{
		public static C2Popularize_ListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Popularize_ListRequest), isFromPool) as C2Popularize_ListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Popularize2C_ListResponse)]
	[MemoryPackable]
	public partial class Popularize2C_ListResponse: MessageObject, IPopularizeActorResponse
	{
		public static Popularize2C_ListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Popularize2C_ListResponse), isFromPool) as Popularize2C_ListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public long PopularizeCode { get; set; }

		[MemoryPackOrder(1)]
		public long BePopularizeId { get; set; }

		[MemoryPackOrder(2)]
		public List<PopularizeInfo> MyPopularizeList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.PopularizeCode = default;
			this.BePopularizeId = default;
			this.MyPopularizeList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Popularize2C_PlayerResponse))]
//我推广的玩家
	[Message(OuterMessage.C2Popularize_PlayerRequest)]
	[MemoryPackable]
	public partial class C2Popularize_PlayerRequest: MessageObject, IPopularizeActorRequest
	{
		public static C2Popularize_PlayerRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Popularize_PlayerRequest), isFromPool) as C2Popularize_PlayerRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long PopularizeId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PopularizeId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Popularize2C_PlayerResponse)]
	[MemoryPackable]
	public partial class Popularize2C_PlayerResponse: MessageObject, IPopularizeActorResponse
	{
		public static Popularize2C_PlayerResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Popularize2C_PlayerResponse), isFromPool) as Popularize2C_PlayerResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_CampRankListResponse))]
	[Message(OuterMessage.C2R_CampRankListRequest)]
	[MemoryPackable]
	public partial class C2R_CampRankListRequest: MessageObject, IRankActorRequest
	{
		public static C2R_CampRankListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_CampRankListRequest), isFromPool) as C2R_CampRankListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_CampRankListResponse)]
	[MemoryPackable]
	public partial class R2C_CampRankListResponse: MessageObject, IRankActorResponse
	{
		public static R2C_CampRankListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_CampRankListResponse), isFromPool) as R2C_CampRankListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<RankingInfo> RankList_1 { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<RankingInfo> RankList_2 { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.RankList_1.Clear();
			this.RankList_2.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_DBServerInfoResponse))]
	[Message(OuterMessage.C2R_DBServerInfoRequest)]
	[MemoryPackable]
	public partial class C2R_DBServerInfoRequest: MessageObject, IRankActorRequest
	{
		public static C2R_DBServerInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_DBServerInfoRequest), isFromPool) as C2R_DBServerInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_DBServerInfoResponse)]
	[MemoryPackable]
	public partial class R2C_DBServerInfoResponse: MessageObject, IRankActorResponse
	{
		public static R2C_DBServerInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_DBServerInfoResponse), isFromPool) as R2C_DBServerInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public ServerInfo ServerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ServerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankDemonResponse))]
	[Message(OuterMessage.C2R_RankDemonRequest)]
	[MemoryPackable]
	public partial class C2R_RankDemonRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankDemonRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankDemonRequest), isFromPool) as C2R_RankDemonRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankDemonResponse)]
	[MemoryPackable]
	public partial class R2C_RankDemonResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankDemonResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankDemonResponse), isFromPool) as R2C_RankDemonResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankListResponse))]
	[Message(OuterMessage.C2R_RankListRequest)]
	[MemoryPackable]
	public partial class C2R_RankListRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankListRequest), isFromPool) as C2R_RankListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankListResponse)]
	[MemoryPackable]
	public partial class R2C_RankListResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankListResponse), isFromPool) as R2C_RankListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankPetListResponse))]
	[Message(OuterMessage.C2R_RankPetListRequest)]
	[MemoryPackable]
	public partial class C2R_RankPetListRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankPetListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankPetListRequest), isFromPool) as C2R_RankPetListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(93)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankPetListResponse)]
	[MemoryPackable]
	public partial class R2C_RankPetListResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankPetListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankPetListResponse), isFromPool) as R2C_RankPetListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int LeftCombatTime { get; set; }

		[MemoryPackOrder(1)]
		public List<RankPetInfo> RankPetList { get; set; } = new();

		[MemoryPackOrder(2)]
		public long RankNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.LeftCombatTime = default;
			this.RankPetList.Clear();
			this.RankNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankRunRaceResponse))]
	[Message(OuterMessage.C2R_RankRunRaceRequest)]
	[MemoryPackable]
	public partial class C2R_RankRunRaceRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankRunRaceRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankRunRaceRequest), isFromPool) as C2R_RankRunRaceRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankRunRaceResponse)]
	[MemoryPackable]
	public partial class R2C_RankRunRaceResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankRunRaceResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankRunRaceResponse), isFromPool) as R2C_RankRunRaceResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankSeasonTowerResponse))]
	[Message(OuterMessage.C2R_RankSeasonTowerRequest)]
	[MemoryPackable]
	public partial class C2R_RankSeasonTowerRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankSeasonTowerRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankSeasonTowerRequest), isFromPool) as C2R_RankSeasonTowerRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankSeasonTowerResponse)]
	[MemoryPackable]
	public partial class R2C_RankSeasonTowerResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankSeasonTowerResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankSeasonTowerResponse), isFromPool) as R2C_RankSeasonTowerResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankSeasonTowerInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankShowLieResponse))]
	[Message(OuterMessage.C2R_RankShowLieRequest)]
	[MemoryPackable]
	public partial class C2R_RankShowLieRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankShowLieRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankShowLieRequest), isFromPool) as C2R_RankShowLieRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankShowLieResponse)]
	[MemoryPackable]
	public partial class R2C_RankShowLieResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankShowLieResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankShowLieResponse), isFromPool) as R2C_RankShowLieResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankShouLieInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankTrialListResponse))]
	[Message(OuterMessage.C2R_RankTrialListRequest)]
	[MemoryPackable]
	public partial class C2R_RankTrialListRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankTrialListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankTrialListRequest), isFromPool) as C2R_RankTrialListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankTrialListResponse)]
	[MemoryPackable]
	public partial class R2C_RankTrialListResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankTrialListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankTrialListResponse), isFromPool) as R2C_RankTrialListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankingTrialInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_RankUnionRaceResponse))]
	[Message(OuterMessage.C2R_RankUnionRaceRequest)]
	[MemoryPackable]
	public partial class C2R_RankUnionRaceRequest: MessageObject, IRankActorRequest
	{
		public static C2R_RankUnionRaceRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_RankUnionRaceRequest), isFromPool) as C2R_RankUnionRaceRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_RankUnionRaceResponse)]
	[MemoryPackable]
	public partial class R2C_RankUnionRaceResponse: MessageObject, IRankActorResponse
	{
		public static R2C_RankUnionRaceResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_RankUnionRaceResponse), isFromPool) as R2C_RankUnionRaceResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankShouLieInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_WorldLvResponse))]
	[Message(OuterMessage.C2R_WorldLvRequest)]
	[MemoryPackable]
	public partial class C2R_WorldLvRequest: MessageObject, IRankActorRequest
	{
		public static C2R_WorldLvRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_WorldLvRequest), isFromPool) as C2R_WorldLvRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RankType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RankType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_WorldLvResponse)]
	[MemoryPackable]
	public partial class R2C_WorldLvResponse: MessageObject, IRankActorResponse
	{
		public static R2C_WorldLvResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_WorldLvResponse), isFromPool) as R2C_WorldLvResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public ServerInfo ServerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ServerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SoloMatchResponse))]
	[Message(OuterMessage.C2M_SoloMatchRequest)]
	[MemoryPackable]
	public partial class C2M_SoloMatchRequest: MessageObject, ILocationRequest
	{
		public static C2M_SoloMatchRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SoloMatchRequest), isFromPool) as C2M_SoloMatchRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SoloMatchResponse)]
	[MemoryPackable]
	public partial class M2C_SoloMatchResponse: MessageObject, ILocationResponse
	{
		public static M2C_SoloMatchResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SoloMatchResponse), isFromPool) as M2C_SoloMatchResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//solo战绩
	[ResponseType(nameof(S2C_SoloMyInfoResponse))]
	[Message(OuterMessage.C2S_SoloMyInfoRequest)]
	[MemoryPackable]
	public partial class C2S_SoloMyInfoRequest: MessageObject, ISoloActorRequest
	{
		public static C2S_SoloMyInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2S_SoloMyInfoRequest), isFromPool) as C2S_SoloMyInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.S2C_SoloMyInfoResponse)]
	[MemoryPackable]
	public partial class S2C_SoloMyInfoResponse: MessageObject, ISoloActorResponse
	{
		public static S2C_SoloMyInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(S2C_SoloMyInfoResponse), isFromPool) as S2C_SoloMyInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long MathTime { get; set; }

		[MemoryPackOrder(1)]
		public int WinTime { get; set; }

		[MemoryPackOrder(2)]
		public int FailTime { get; set; }

		[MemoryPackOrder(3)]
		public List<SoloPlayerResultInfo> SoloPlayerResultInfoList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MathTime = default;
			this.WinTime = default;
			this.FailTime = default;
			this.SoloPlayerResultInfoList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//副本选择奖励
	[ResponseType(nameof(M2C_TeamDungeonBoxRewardResponse))]
	[Message(OuterMessage.C2M_TeamDungeonBoxRewardRequest)]
	[MemoryPackable]
	public partial class C2M_TeamDungeonBoxRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_TeamDungeonBoxRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TeamDungeonBoxRewardRequest), isFromPool) as C2M_TeamDungeonBoxRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int BoxIndex { get; set; }

		[MemoryPackOrder(1)]
		public RewardItem RewardItem { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.BoxIndex = default;
			this.RewardItem = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamDungeonBoxRewardResponse)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonBoxRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_TeamDungeonBoxRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonBoxRewardResponse), isFromPool) as M2C_TeamDungeonBoxRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int Mail { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Mail = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//创建组队副本
	[ResponseType(nameof(M2C_TeamDungeonCreateResponse))]
	[Message(OuterMessage.C2M_TeamDungeonCreateRequest)]
	[MemoryPackable]
	public partial class C2M_TeamDungeonCreateRequest: MessageObject, ILocationRequest
	{
		public static C2M_TeamDungeonCreateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TeamDungeonCreateRequest), isFromPool) as C2M_TeamDungeonCreateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int FubenId { get; set; }

		[MemoryPackOrder(1)]
		public TeamPlayerInfo TeamPlayerInfo { get; set; }

		[MemoryPackOrder(2)]
		public int FubenType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.FubenId = default;
			this.TeamPlayerInfo = default;
			this.FubenType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamDungeonCreateResponse)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonCreateResponse: MessageObject, ILocationResponse
	{
		public static M2C_TeamDungeonCreateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonCreateResponse), isFromPool) as M2C_TeamDungeonCreateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		[MemoryPackOrder(2)]
		public int FubenType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TeamInfo = default;
			this.FubenType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//开启组队副本
	[ResponseType(nameof(M2C_TeamDungeonOpenResponse))]
	[Message(OuterMessage.C2M_TeamDungeonOpenRequest)]
	[MemoryPackable]
	public partial class C2M_TeamDungeonOpenRequest: MessageObject, ILocationRequest
	{
		public static C2M_TeamDungeonOpenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TeamDungeonOpenRequest), isFromPool) as C2M_TeamDungeonOpenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserID { get; set; }

		[MemoryPackOrder(1)]
		public int FubenType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserID = default;
			this.FubenType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamDungeonOpenResponse)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonOpenResponse: MessageObject, ILocationResponse
	{
		public static M2C_TeamDungeonOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonOpenResponse), isFromPool) as M2C_TeamDungeonOpenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public int FubenType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//请求准备
	[ResponseType(nameof(M2C_TeamDungeonPrepareResponse))]
	[Message(OuterMessage.C2M_TeamDungeonPrepareRequest)]
	[MemoryPackable]
	public partial class C2M_TeamDungeonPrepareRequest: MessageObject, ILocationRequest
	{
		public static C2M_TeamDungeonPrepareRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TeamDungeonPrepareRequest), isFromPool) as C2M_TeamDungeonPrepareRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		[MemoryPackOrder(1)]
		public int Prepare { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TeamInfo = default;
			this.Prepare = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamDungeonPrepareResponse)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonPrepareResponse: MessageObject, ILocationResponse
	{
		public static M2C_TeamDungeonPrepareResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonPrepareResponse), isFromPool) as M2C_TeamDungeonPrepareResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TeamerPositionResponse))]
	[Message(OuterMessage.C2M_TeamerPositionRequest)]
	[MemoryPackable]
	public partial class C2M_TeamerPositionRequest: MessageObject, ILocationRequest
	{
		public static C2M_TeamerPositionRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TeamerPositionRequest), isFromPool) as C2M_TeamerPositionRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamerPositionResponse)]
	[MemoryPackable]
	public partial class M2C_TeamerPositionResponse: MessageObject, ILocationResponse
	{
		public static M2C_TeamerPositionResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamerPositionResponse), isFromPool) as M2C_TeamerPositionResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<UnitInfo> UnitList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnitList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_TeamPickRequest)]
	[MemoryPackable]
	public partial class C2M_TeamPickRequest: MessageObject, ILocationMessage
	{
		public static C2M_TeamPickRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TeamPickRequest), isFromPool) as C2M_TeamPickRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public DropInfo DropItem { get; set; }

		[MemoryPackOrder(1)]
		public int Need { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.DropItem = default;
			this.Need = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamDungeonBoxRewardResult)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonBoxRewardResult: MessageObject, IMessage
	{
		public static M2C_TeamDungeonBoxRewardResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonBoxRewardResult), isFromPool) as M2C_TeamDungeonBoxRewardResult; 
		}

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		[MemoryPackOrder(1)]
		public int BoxIndex { get; set; }

		[MemoryPackOrder(2)]
		public string PlayerName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UserId = default;
			this.BoxIndex = default;
			this.PlayerName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//同意组队
	[ResponseType(nameof(T2C_TeamAgreeResponse))]
	[Message(OuterMessage.C2T_TeamAgreeRequest)]
	[MemoryPackable]
	public partial class C2T_TeamAgreeRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamAgreeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamAgreeRequest), isFromPool) as C2T_TeamAgreeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public TeamPlayerInfo TeamPlayerInfo_1 { get; set; }

		[MemoryPackOrder(1)]
		public TeamPlayerInfo TeamPlayerInfo_2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TeamPlayerInfo_1 = default;
			this.TeamPlayerInfo_2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamAgreeResponse)]
	[MemoryPackable]
	public partial class T2C_TeamAgreeResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamAgreeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamAgreeResponse), isFromPool) as T2C_TeamAgreeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//同意组队副本申请
	[ResponseType(nameof(T2C_TeamDungeonAgreeResponse))]
	[Message(OuterMessage.C2T_TeamDungeonAgreeRequest)]
	[MemoryPackable]
	public partial class C2T_TeamDungeonAgreeRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamDungeonAgreeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamDungeonAgreeRequest), isFromPool) as C2T_TeamDungeonAgreeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long TeamId { get; set; }

		[MemoryPackOrder(1)]
		public TeamPlayerInfo TeamPlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TeamId = default;
			this.TeamPlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamDungeonAgreeResponse)]
	[MemoryPackable]
	public partial class T2C_TeamDungeonAgreeResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamDungeonAgreeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamDungeonAgreeResponse), isFromPool) as T2C_TeamDungeonAgreeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//组队副本申请
	[ResponseType(nameof(T2C_TeamDungeonApplyResponse))]
	[Message(OuterMessage.C2T_TeamDungeonApplyRequest)]
	[MemoryPackable]
	public partial class C2T_TeamDungeonApplyRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamDungeonApplyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamDungeonApplyRequest), isFromPool) as C2T_TeamDungeonApplyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long TeamId { get; set; }

		[MemoryPackOrder(1)]
		public TeamPlayerInfo TeamPlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TeamId = default;
			this.TeamPlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamDungeonApplyResponse)]
	[MemoryPackable]
	public partial class T2C_TeamDungeonApplyResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamDungeonApplyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamDungeonApplyResponse), isFromPool) as T2C_TeamDungeonApplyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamDungeonApplyResult)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonApplyResult: MessageObject, IMessage
	{
		public static M2C_TeamDungeonApplyResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonApplyResult), isFromPool) as M2C_TeamDungeonApplyResult; 
		}

		[MemoryPackOrder(0)]
		public TeamPlayerInfo TeamPlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.TeamPlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//组队副本
	[ResponseType(nameof(T2C_TeamDungeonInfoResponse))]
	[Message(OuterMessage.C2T_TeamDungeonInfoRequest)]
	[MemoryPackable]
	public partial class C2T_TeamDungeonInfoRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamDungeonInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamDungeonInfoRequest), isFromPool) as C2T_TeamDungeonInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamDungeonInfoResponse)]
	[MemoryPackable]
	public partial class T2C_TeamDungeonInfoResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamDungeonInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamDungeonInfoResponse), isFromPool) as T2C_TeamDungeonInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<TeamInfo> TeamList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TeamList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//邀请组队
	[ResponseType(nameof(T2C_TeamInviteResponse))]
	[Message(OuterMessage.C2T_TeamInviteRequest)]
	[MemoryPackable]
	public partial class C2T_TeamInviteRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamInviteRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamInviteRequest), isFromPool) as C2T_TeamInviteRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserID { get; set; }

		[MemoryPackOrder(1)]
		public TeamPlayerInfo TeamPlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserID = default;
			this.TeamPlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamInviteResponse)]
	[MemoryPackable]
	public partial class T2C_TeamInviteResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamInviteResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamInviteResponse), isFromPool) as T2C_TeamInviteResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TeamInviteResult)]
	[MemoryPackable]
	public partial class M2C_TeamInviteResult: MessageObject, IMessage
	{
		public static M2C_TeamInviteResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamInviteResult), isFromPool) as M2C_TeamInviteResult; 
		}

		[MemoryPackOrder(0)]
		public TeamPlayerInfo TeamPlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.TeamPlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//踢出队伍
	[ResponseType(nameof(T2C_TeamKickOutResponse))]
	[Message(OuterMessage.C2T_TeamKickOutRequest)]
	[MemoryPackable]
	public partial class C2T_TeamKickOutRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamKickOutRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamKickOutRequest), isFromPool) as C2T_TeamKickOutRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamKickOutResponse)]
	[MemoryPackable]
	public partial class T2C_TeamKickOutResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamKickOutResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamKickOutResponse), isFromPool) as T2C_TeamKickOutResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//离开组队
	[ResponseType(nameof(T2C_TeamLeaveResponse))]
	[Message(OuterMessage.C2T_TeamLeaveRequest)]
	[MemoryPackable]
	public partial class C2T_TeamLeaveRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamLeaveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamLeaveRequest), isFromPool) as C2T_TeamLeaveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamLeaveResponse)]
	[MemoryPackable]
	public partial class T2C_TeamLeaveResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamLeaveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamLeaveResponse), isFromPool) as T2C_TeamLeaveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//邀请组队
	[ResponseType(nameof(T2C_TeamRobotResponse))]
	[Message(OuterMessage.C2T_TeamRobotRequest)]
	[MemoryPackable]
	public partial class C2T_TeamRobotRequest: MessageObject, ITeamActorRequest
	{
		public static C2T_TeamRobotRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_TeamRobotRequest), isFromPool) as C2T_TeamRobotRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.T2C_TeamRobotResponse)]
	[MemoryPackable]
	public partial class T2C_TeamRobotResponse: MessageObject, ITeamActorResponse
	{
		public static T2C_TeamRobotResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_TeamRobotResponse), isFromPool) as T2C_TeamRobotResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//副本开启
	[Message(OuterMessage.M2C_TeamDungeonOpenResult)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonOpenResult: MessageObject, IMessage
	{
		public static M2C_TeamDungeonOpenResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonOpenResult), isFromPool) as M2C_TeamDungeonOpenResult; 
		}

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.TeamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//玩家准备
	[Message(OuterMessage.M2C_TeamDungeonPrepareResult)]
	[MemoryPackable]
	public partial class M2C_TeamDungeonPrepareResult: MessageObject, IMessage
	{
		public static M2C_TeamDungeonPrepareResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TeamDungeonPrepareResult), isFromPool) as M2C_TeamDungeonPrepareResult; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		[MemoryPackOrder(1)]
		public int ErrorCode { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TeamInfo = default;
			this.ErrorCode = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//v1活动.抽奖
	[ResponseType(nameof(M2C_ActivityChouKaResponse))]
	[Message(OuterMessage.C2M_ActivityChouKaRequest)]
	[MemoryPackable]
	public partial class C2M_ActivityChouKaRequest: MessageObject, ILocationRequest
	{
		public static C2M_ActivityChouKaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ActivityChouKaRequest), isFromPool) as C2M_ActivityChouKaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ActivityChouKaResponse)]
	[MemoryPackable]
	public partial class M2C_ActivityChouKaResponse: MessageObject, ILocationResponse
	{
		public static M2C_ActivityChouKaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityChouKaResponse), isFromPool) as M2C_ActivityChouKaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//喂食物
	[ResponseType(nameof(M2C_ActivityFeedResponse))]
	[Message(OuterMessage.C2M_ActivityFeedRequest)]
	[MemoryPackable]
	public partial class C2M_ActivityFeedRequest: MessageObject, ILocationRequest
	{
		public static C2M_ActivityFeedRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ActivityFeedRequest), isFromPool) as C2M_ActivityFeedRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ItemID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ItemID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ActivityFeedResponse)]
	[MemoryPackable]
	public partial class M2C_ActivityFeedResponse: MessageObject, ILocationResponse
	{
		public static M2C_ActivityFeedResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityFeedResponse), isFromPool) as M2C_ActivityFeedResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public ActivityV1Info ActivityV1Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ActivityV1Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ActivityGuessResponse))]
	[Message(OuterMessage.C2M_ActivityGuessRequest)]
	[MemoryPackable]
	public partial class C2M_ActivityGuessRequest: MessageObject, ILocationRequest
	{
		public static C2M_ActivityGuessRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ActivityGuessRequest), isFromPool) as C2M_ActivityGuessRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int GuessId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.GuessId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ActivityGuessResponse)]
	[MemoryPackable]
	public partial class M2C_ActivityGuessResponse: MessageObject, ILocationResponse
	{
		public static M2C_ActivityGuessResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityGuessResponse), isFromPool) as M2C_ActivityGuessResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//活动信息
	[ResponseType(nameof(M2C_ActivityInfoResponse))]
	[Message(OuterMessage.C2M_ActivityInfoRequest)]
	[MemoryPackable]
	public partial class C2M_ActivityInfoRequest: MessageObject, ILocationRequest
	{
		public static C2M_ActivityInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ActivityInfoRequest), isFromPool) as C2M_ActivityInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ActivityType { get; set; }

		[MemoryPackOrder(1)]
		public int ActivityId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ActivityType = default;
			this.ActivityId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ActivityInfoResponse)]
	[MemoryPackable]
	public partial class M2C_ActivityInfoResponse: MessageObject, ILocationResponse
	{
		public static M2C_ActivityInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityInfoResponse), isFromPool) as M2C_ActivityInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> ReceiveIds { get; set; } = new();

		[MemoryPackOrder(2)]
		public long LastSignTime { get; set; }

		[MemoryPackOrder(3)]
		public int TotalSignNumber { get; set; }

		[MemoryPackOrder(4)]
		public List<TokenRecvive> QuTokenRecvive { get; set; } = new();

		[MemoryPackOrder(5)]
		public long LastLoginTime { get; set; }

		[MemoryPackOrder(6)]
		public List<int> DayTeHui { get; set; } = new();

		[MemoryPackOrder(7)]
		public ActivityV1Info ActivityV1Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ReceiveIds.Clear();
			this.LastSignTime = default;
			this.TotalSignNumber = default;
			this.QuTokenRecvive.Clear();
			this.LastLoginTime = default;
			this.DayTeHui.Clear();
			this.ActivityV1Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//领取奖励
	[ResponseType(nameof(M2C_ActivityReceiveResponse))]
	[Message(OuterMessage.C2M_ActivityReceiveRequest)]
	[MemoryPackable]
	public partial class C2M_ActivityReceiveRequest: MessageObject, ILocationRequest
	{
		public static C2M_ActivityReceiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ActivityReceiveRequest), isFromPool) as C2M_ActivityReceiveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ActivityType { get; set; }

		[MemoryPackOrder(1)]
		public int ActivityId { get; set; }

		[MemoryPackOrder(2)]
		public int ReceiveIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ActivityType = default;
			this.ActivityId = default;
			this.ReceiveIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ActivityReceiveResponse)]
	[MemoryPackable]
	public partial class M2C_ActivityReceiveResponse: MessageObject, ILocationResponse
	{
		public static M2C_ActivityReceiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityReceiveResponse), isFromPool) as M2C_ActivityReceiveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//领取充值签到奖励
	[ResponseType(nameof(M2C_ActivityRechargeSignResponse))]
	[Message(OuterMessage.C2M_ActivityRechargeSignRequest)]
	[MemoryPackable]
	public partial class C2M_ActivityRechargeSignRequest: MessageObject, ILocationRequest
	{
		public static C2M_ActivityRechargeSignRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ActivityRechargeSignRequest), isFromPool) as C2M_ActivityRechargeSignRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ActivityType { get; set; }

		[MemoryPackOrder(1)]
		public int ActivityId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ActivityType = default;
			this.ActivityId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ActivityRechargeSignResponse)]
	[MemoryPackable]
	public partial class M2C_ActivityRechargeSignResponse: MessageObject, ILocationResponse
	{
		public static M2C_ActivityRechargeSignResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityRechargeSignResponse), isFromPool) as M2C_ActivityRechargeSignResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ActivityRewardResponse))]
	[Message(OuterMessage.C2M_ActivityRewardRequest)]
	[MemoryPackable]
	public partial class C2M_ActivityRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_ActivityRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ActivityRewardRequest), isFromPool) as C2M_ActivityRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ActivityType { get; set; }

		[MemoryPackOrder(1)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ActivityType = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ActivityRewardResponse)]
	[MemoryPackable]
	public partial class M2C_ActivityRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_ActivityRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityRewardResponse), isFromPool) as M2C_ActivityRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public ActivityV1Info ActivityV1Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ActivityV1Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//刷新奖励
	[ResponseType(nameof(M2C_ChouKa2RefreshResponse))]
	[Message(OuterMessage.C2M_ChouKa2RefreshRequest)]
	[MemoryPackable]
	public partial class C2M_ChouKa2RefreshRequest: MessageObject, ILocationRequest
	{
		public static C2M_ChouKa2RefreshRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChouKa2RefreshRequest), isFromPool) as C2M_ChouKa2RefreshRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChouKa2RefreshResponse)]
	[MemoryPackable]
	public partial class M2C_ChouKa2RefreshResponse: MessageObject, ILocationResponse
	{
		public static M2C_ChouKa2RefreshResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChouKa2RefreshResponse), isFromPool) as M2C_ChouKa2RefreshResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public ActivityV1Info ActivityV1Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ActivityV1Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SingleRechargeRewardResponse))]
	[Message(OuterMessage.C2M_SingleRechargeRewardRequest)]
	[MemoryPackable]
	public partial class C2M_SingleRechargeRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_SingleRechargeRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SingleRechargeRewardRequest), isFromPool) as C2M_SingleRechargeRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SingleRechargeRewardResponse)]
	[MemoryPackable]
	public partial class M2C_SingleRechargeRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_SingleRechargeRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SingleRechargeRewardResponse), isFromPool) as M2C_SingleRechargeRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> RewardIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RewardIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ZhanQuInfoResponse))]
	[Message(OuterMessage.C2M_ZhanQuInfoRequest)]
	[MemoryPackable]
	public partial class C2M_ZhanQuInfoRequest: MessageObject, ILocationRequest
	{
		public static C2M_ZhanQuInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ZhanQuInfoRequest), isFromPool) as C2M_ZhanQuInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ZhanQuInfoResponse)]
	[MemoryPackable]
	public partial class M2C_ZhanQuInfoResponse: MessageObject, ILocationResponse
	{
		public static M2C_ZhanQuInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ZhanQuInfoResponse), isFromPool) as M2C_ZhanQuInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> ReceiveIds { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<ZhanQuReceiveNumber> ReceiveNum { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ReceiveIds.Clear();
			this.ReceiveNum.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//战区活动
	[ResponseType(nameof(M2C_ZhanQuReceiveResponse))]
	[Message(OuterMessage.C2M_ZhanQuReceiveRequest)]
	[MemoryPackable]
	public partial class C2M_ZhanQuReceiveRequest: MessageObject, ILocationRequest
	{
		public static C2M_ZhanQuReceiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ZhanQuReceiveRequest), isFromPool) as C2M_ZhanQuReceiveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ActivityType { get; set; }

		[MemoryPackOrder(1)]
		public int ActivityId { get; set; }

		[MemoryPackOrder(2)]
		public int ReceiveIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ActivityType = default;
			this.ActivityId = default;
			this.ReceiveIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ZhanQuReceiveResponse)]
	[MemoryPackable]
	public partial class M2C_ZhanQuReceiveResponse: MessageObject, ILocationResponse
	{
		public static M2C_ZhanQuReceiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ZhanQuReceiveResponse), isFromPool) as M2C_ZhanQuReceiveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//晶核激活
	[ResponseType(nameof(M2C_JingHeActivateResponse))]
	[Message(OuterMessage.C2M_JingHeActivateRequest)]
	[MemoryPackable]
	public partial class C2M_JingHeActivateRequest: MessageObject, ILocationRequest
	{
		public static C2M_JingHeActivateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JingHeActivateRequest), isFromPool) as C2M_JingHeActivateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long BagInfoId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.BagInfoId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JingHeActivateResponse)]
	[MemoryPackable]
	public partial class M2C_JingHeActivateResponse: MessageObject, ILocationResponse
	{
		public static M2C_JingHeActivateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JingHeActivateResponse), isFromPool) as M2C_JingHeActivateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//晶核使用方案
	[ResponseType(nameof(M2C_JingHePlanResponse))]
	[Message(OuterMessage.C2M_JingHePlanRequest)]
	[MemoryPackable]
	public partial class C2M_JingHePlanRequest: MessageObject, ILocationRequest
	{
		public static C2M_JingHePlanRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JingHePlanRequest), isFromPool) as C2M_JingHePlanRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int JingHePlan { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.JingHePlan = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JingHePlanResponse)]
	[MemoryPackable]
	public partial class M2C_JingHePlanResponse: MessageObject, ILocationResponse
	{
		public static M2C_JingHePlanResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JingHePlanResponse), isFromPool) as M2C_JingHePlanResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JingHeWearResponse))]
	[Message(OuterMessage.C2M_JingHeWearRequest)]
	[MemoryPackable]
	public partial class C2M_JingHeWearRequest: MessageObject, ILocationRequest
	{
		public static C2M_JingHeWearRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JingHeWearRequest), isFromPool) as C2M_JingHeWearRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long OperateBagID { get; set; }

		[MemoryPackOrder(2)]
		public string OperatePar { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.OperateBagID = default;
			this.OperatePar = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JingHeWearResponse)]
	[MemoryPackable]
	public partial class M2C_JingHeWearResponse: MessageObject, ILocationResponse
	{
		public static M2C_JingHeWearResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JingHeWearResponse), isFromPool) as M2C_JingHeWearResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//晶核注入
	[ResponseType(nameof(M2C_JingHeZhuruResponse))]
	[Message(OuterMessage.C2M_JingHeZhuruRequest)]
	[MemoryPackable]
	public partial class C2M_JingHeZhuruRequest: MessageObject, ILocationRequest
	{
		public static C2M_JingHeZhuruRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JingHeZhuruRequest), isFromPool) as C2M_JingHeZhuruRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long BagInfoId { get; set; }

		[MemoryPackOrder(1)]
		public List<long> OperateBagID { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.BagInfoId = default;
			this.OperateBagID.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JingHeZhuruResponse)]
	[MemoryPackable]
	public partial class M2C_JingHeZhuruResponse: MessageObject, ILocationResponse
	{
		public static M2C_JingHeZhuruResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JingHeZhuruResponse), isFromPool) as M2C_JingHeZhuruResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MakeLearnResponse))]
	[Message(OuterMessage.C2M_MakeLearnRequest)]
	[MemoryPackable]
	public partial class C2M_MakeLearnRequest: MessageObject, ILocationRequest
	{
		public static C2M_MakeLearnRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_MakeLearnRequest), isFromPool) as C2M_MakeLearnRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int MakeId { get; set; }

		[MemoryPackOrder(1)]
		public int Plan { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MakeId = default;
			this.Plan = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_MakeLearnResponse)]
	[MemoryPackable]
	public partial class M2C_MakeLearnResponse: MessageObject, ILocationResponse
	{
		public static M2C_MakeLearnResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_MakeLearnResponse), isFromPool) as M2C_MakeLearnResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(E2C_AccountWarehousInfoResponse))]
	[Message(OuterMessage.C2E_AccountWarehousInfoRequest)]
	[MemoryPackable]
	public partial class C2E_AccountWarehousInfoRequest: MessageObject, IMailActorRequest
	{
		public static C2E_AccountWarehousInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2E_AccountWarehousInfoRequest), isFromPool) as C2E_AccountWarehousInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long AccInfoID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.AccInfoID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.E2C_AccountWarehousInfoResponse)]
	[MemoryPackable]
	public partial class E2C_AccountWarehousInfoResponse: MessageObject, IMailActorResponse
	{
		public static E2C_AccountWarehousInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(E2C_AccountWarehousInfoResponse), isFromPool) as E2C_AccountWarehousInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<BagInfo> BagInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.BagInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BattleSummonRecord))]
//战场召唤记录
	[Message(OuterMessage.C2M_BattleSummonRecord)]
	[MemoryPackable]
	public partial class C2M_BattleSummonRecord: MessageObject, ILocationRequest
	{
		public static C2M_BattleSummonRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BattleSummonRecord), isFromPool) as C2M_BattleSummonRecord; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BattleSummonRecord)]
	[MemoryPackable]
	public partial class M2C_BattleSummonRecord: MessageObject, ILocationResponse
	{
		public static M2C_BattleSummonRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BattleSummonRecord), isFromPool) as M2C_BattleSummonRecord; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public List<BattleSummonInfo> BattleSummonList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.BattleSummonList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BattleSummonResponse))]
//战场召唤士兵
	[Message(OuterMessage.C2M_BattleSummonRequest)]
	[MemoryPackable]
	public partial class C2M_BattleSummonRequest: MessageObject, ILocationRequest
	{
		public static C2M_BattleSummonRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BattleSummonRequest), isFromPool) as C2M_BattleSummonRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int SummonId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SummonId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BattleSummonResponse)]
	[MemoryPackable]
	public partial class M2C_BattleSummonResponse: MessageObject, ILocationResponse
	{
		public static M2C_BattleSummonResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BattleSummonResponse), isFromPool) as M2C_BattleSummonResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public List<BattleSummonInfo> BattleSummonList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.BattleSummonList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_CampRankSelectResponse))]
	[Message(OuterMessage.C2M_CampRankSelectRequest)]
	[MemoryPackable]
	public partial class C2M_CampRankSelectRequest: MessageObject, ILocationRequest
	{
		public static C2M_CampRankSelectRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_CampRankSelectRequest), isFromPool) as C2M_CampRankSelectRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int CampId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CampId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CampRankSelectResponse)]
	[MemoryPackable]
	public partial class M2C_CampRankSelectResponse: MessageObject, ILocationResponse
	{
		public static M2C_CampRankSelectResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CampRankSelectResponse), isFromPool) as M2C_CampRankSelectResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_FubenEnergySkillResponse))]
	[Message(OuterMessage.Actor_FubenEnergySkillRequest)]
	[MemoryPackable]
	public partial class Actor_FubenEnergySkillRequest: MessageObject, ILocationRequest
	{
		public static Actor_FubenEnergySkillRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_FubenEnergySkillRequest), isFromPool) as Actor_FubenEnergySkillRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SkillId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SkillId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_FubenEnergySkillResponse)]
	[MemoryPackable]
	public partial class Actor_FubenEnergySkillResponse: MessageObject, ILocationResponse
	{
		public static Actor_FubenEnergySkillResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_FubenEnergySkillResponse), isFromPool) as Actor_FubenEnergySkillResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.FubenInfo)]
	[MemoryPackable]
	public partial class FubenInfo: MessageObject
	{
		public static FubenInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(FubenInfo), isFromPool) as FubenInfo; 
		}

		[MemoryPackOrder(1)]
		public int StartCell { get; set; }

		[MemoryPackOrder(2)]
		public int EndCell { get; set; }

		[MemoryPackOrder(3)]
		public List<KeyValuePair> FubenCellNpcs { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.StartCell = default;
			this.EndCell = default;
			this.FubenCellNpcs.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.SonFubenInfo)]
	[MemoryPackable]
	public partial class SonFubenInfo: MessageObject
	{
		public static SonFubenInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(SonFubenInfo), isFromPool) as SonFubenInfo; 
		}

		[MemoryPackOrder(0)]
		public int SonSceneId { get; set; }

		[MemoryPackOrder(1)]
		public int CurrentCell { get; set; }

		[MemoryPackOrder(2)]
		public List<int> PassableFlag { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SonSceneId = default;
			this.CurrentCell = default;
			this.PassableFlag.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_EnterFubenResponse))]
	[Message(OuterMessage.Actor_EnterFubenRequest)]
	[MemoryPackable]
	public partial class Actor_EnterFubenRequest: MessageObject, ILocationRequest
	{
		public static Actor_EnterFubenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_EnterFubenRequest), isFromPool) as Actor_EnterFubenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ChapterId { get; set; }

		[MemoryPackOrder(1)]
		public int Difficulty { get; set; }

		[MemoryPackOrder(2)]
		public int RepeatEnter { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChapterId = default;
			this.Difficulty = default;
			this.RepeatEnter = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_EnterFubenResponse)]
	[MemoryPackable]
	public partial class Actor_EnterFubenResponse: MessageObject, ILocationResponse
	{
		public static Actor_EnterFubenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_EnterFubenResponse), isFromPool) as Actor_EnterFubenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public FubenInfo FubenInfo { get; set; }

		[MemoryPackOrder(1)]
		public SonFubenInfo SonFubenInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenInfo = default;
			this.SonFubenInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_EnterSonFubenResponse))]
	[Message(OuterMessage.Actor_EnterSonFubenRequest)]
	[MemoryPackable]
	public partial class Actor_EnterSonFubenRequest: MessageObject, ILocationRequest
	{
		public static Actor_EnterSonFubenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_EnterSonFubenRequest), isFromPool) as Actor_EnterSonFubenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public int CurrentCell { get; set; }

		[MemoryPackOrder(2)]
		public int DirectionType { get; set; }

		[MemoryPackOrder(3)]
		public int ChuansongId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.CurrentCell = default;
			this.DirectionType = default;
			this.ChuansongId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_EnterSonFubenResponse)]
	[MemoryPackable]
	public partial class Actor_EnterSonFubenResponse: MessageObject, ILocationResponse
	{
		public static Actor_EnterSonFubenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_EnterSonFubenResponse), isFromPool) as Actor_EnterSonFubenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public SonFubenInfo SonFubenInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.SonFubenInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_GetFubenInfoResponse))]
	[Message(OuterMessage.Actor_GetFubenInfoRequest)]
	[MemoryPackable]
	public partial class Actor_GetFubenInfoRequest: MessageObject, ILocationRequest
	{
		public static Actor_GetFubenInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_GetFubenInfoRequest), isFromPool) as Actor_GetFubenInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_GetFubenInfoResponse)]
	[MemoryPackable]
	public partial class Actor_GetFubenInfoResponse: MessageObject, ILocationResponse
	{
		public static Actor_GetFubenInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_GetFubenInfoResponse), isFromPool) as Actor_GetFubenInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<FubenPassInfo> FubenPassInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenPassInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_GetFubenRewardReponse))]
	[Message(OuterMessage.Actor_GetFubenRewardRequest)]
	[MemoryPackable]
	public partial class Actor_GetFubenRewardRequest: MessageObject, ILocationRequest
	{
		public static Actor_GetFubenRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_GetFubenRewardRequest), isFromPool) as Actor_GetFubenRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public RewardItem RewardItem { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.RewardItem = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_GetFubenRewardReponse)]
	[MemoryPackable]
	public partial class Actor_GetFubenRewardReponse: MessageObject, ILocationResponse
	{
		public static Actor_GetFubenRewardReponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_GetFubenRewardReponse), isFromPool) as Actor_GetFubenRewardReponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_FubenMoNengResponse))]
	[Message(OuterMessage.Actor_FubenMoNengRequest)]
	[MemoryPackable]
	public partial class Actor_FubenMoNengRequest: MessageObject, ILocationRequest
	{
		public static Actor_FubenMoNengRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_FubenMoNengRequest), isFromPool) as Actor_FubenMoNengRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_FubenMoNengResponse)]
	[MemoryPackable]
	public partial class Actor_FubenMoNengResponse: MessageObject, ILocationResponse
	{
		public static Actor_FubenMoNengResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_FubenMoNengResponse), isFromPool) as Actor_FubenMoNengResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<MysteryItemInfo> MysteryItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MysteryItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_SendReviveResponse))]
	[Message(OuterMessage.Actor_SendReviveRequest)]
	[MemoryPackable]
	public partial class Actor_SendReviveRequest: MessageObject, ILocationRequest
	{
		public static Actor_SendReviveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_SendReviveRequest), isFromPool) as Actor_SendReviveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int MapIndex { get; set; }

		[MemoryPackOrder(1)]
		public bool Revive { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MapIndex = default;
			this.Revive = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_SendReviveResponse)]
	[MemoryPackable]
	public partial class Actor_SendReviveResponse: MessageObject, ILocationResponse
	{
		public static Actor_SendReviveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_SendReviveResponse), isFromPool) as Actor_SendReviveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ChouKaResponse))]
	[Message(OuterMessage.C2M_ChouKaRequest)]
	[MemoryPackable]
	public partial class C2M_ChouKaRequest: MessageObject, ILocationRequest
	{
		public static C2M_ChouKaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChouKaRequest), isFromPool) as C2M_ChouKaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ChouKaType { get; set; }

		[MemoryPackOrder(1)]
		public int ChapterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChouKaType = default;
			this.ChapterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChouKaResponse)]
	[MemoryPackable]
	public partial class M2C_ChouKaResponse: MessageObject, ILocationResponse
	{
		public static M2C_ChouKaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChouKaResponse), isFromPool) as M2C_ChouKaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RewardItem> RewardList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RewardList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ChouKaRewardResponse))]
	[Message(OuterMessage.C2M_ChouKaRewardRequest)]
	[MemoryPackable]
	public partial class C2M_ChouKaRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_ChouKaRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChouKaRewardRequest), isFromPool) as C2M_ChouKaRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChouKaRewardResponse)]
	[MemoryPackable]
	public partial class M2C_ChouKaRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_ChouKaRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChouKaRewardResponse), isFromPool) as M2C_ChouKaRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//答题
	[ResponseType(nameof(M2C_EnergyAnswerResponse))]
	[Message(OuterMessage.C2M_EnergyAnswerRequest)]
	[MemoryPackable]
	public partial class C2M_EnergyAnswerRequest: MessageObject, ILocationRequest
	{
		public static C2M_EnergyAnswerRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_EnergyAnswerRequest), isFromPool) as C2M_EnergyAnswerRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int AnswerIndex { get; set; }

		[MemoryPackOrder(1)]
		public int QuestionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.AnswerIndex = default;
			this.QuestionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_EnergyAnswerResponse)]
	[MemoryPackable]
	public partial class M2C_EnergyAnswerResponse: MessageObject, ILocationResponse
	{
		public static M2C_EnergyAnswerResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_EnergyAnswerResponse), isFromPool) as M2C_EnergyAnswerResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_EnergyInfoResponse))]
	[Message(OuterMessage.C2M_EnergyInfoRequest)]
	[MemoryPackable]
	public partial class C2M_EnergyInfoRequest: MessageObject, ILocationRequest
	{
		public static C2M_EnergyInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_EnergyInfoRequest), isFromPool) as C2M_EnergyInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_EnergyInfoResponse)]
	[MemoryPackable]
	public partial class M2C_EnergyInfoResponse: MessageObject, ILocationResponse
	{
		public static M2C_EnergyInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_EnergyInfoResponse), isFromPool) as M2C_EnergyInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> GetRewards { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> QuestionList { get; set; } = new();

		[MemoryPackOrder(2)]
		public int QuestionIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.GetRewards.Clear();
			this.QuestionList.Clear();
			this.QuestionIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_EnergyReceiveResponse))]
	[Message(OuterMessage.C2M_EnergyReceiveRequest)]
	[MemoryPackable]
	public partial class C2M_EnergyReceiveRequest: MessageObject, ILocationRequest
	{
		public static C2M_EnergyReceiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_EnergyReceiveRequest), isFromPool) as C2M_EnergyReceiveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RewardType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_EnergyReceiveResponse)]
	[MemoryPackable]
	public partial class M2C_EnergyReceiveResponse: MessageObject, ILocationResponse
	{
		public static M2C_EnergyReceiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_EnergyReceiveResponse), isFromPool) as M2C_EnergyReceiveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//上下马
	[ResponseType(nameof(M2C_HorseRideResponse))]
	[Message(OuterMessage.C2M_HorseRideRequest)]
	[MemoryPackable]
	public partial class C2M_HorseRideRequest: MessageObject, ILocationRequest
	{
		public static C2M_HorseRideRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_HorseRideRequest), isFromPool) as C2M_HorseRideRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int HorseId { get; set; }

		[MemoryPackOrder(1)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.HorseId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_HorseRideResponse)]
	[MemoryPackable]
	public partial class M2C_HorseRideResponse: MessageObject, ILocationResponse
	{
		public static M2C_HorseRideResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_HorseRideResponse), isFromPool) as M2C_HorseRideResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//坐骑出战
	[ResponseType(nameof(M2C_HorseFightResponse))]
	[Message(OuterMessage.C2M_HorseFightRequest)]
	[MemoryPackable]
	public partial class C2M_HorseFightRequest: MessageObject, ILocationRequest
	{
		public static C2M_HorseFightRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_HorseFightRequest), isFromPool) as C2M_HorseFightRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int HorseId { get; set; }

		[MemoryPackOrder(1)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.HorseId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_HorseFightResponse)]
	[MemoryPackable]
	public partial class M2C_HorseFightResponse: MessageObject, ILocationResponse
	{
		public static M2C_HorseFightResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_HorseFightResponse), isFromPool) as M2C_HorseFightResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//开启宝箱
	[ResponseType(nameof(M2C_JiaYuanPickResponse))]
	[Message(OuterMessage.C2M_JiaYuanPickRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPickRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPickRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPickRequest), isFromPool) as C2M_JiaYuanPickRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long MasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.MasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPickResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPickResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPickResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPickResponse), isFromPool) as M2C_JiaYuanPickResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanCangKuOpenResponse))]
	[Message(OuterMessage.C2M_JiaYuanCangKuOpenRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanCangKuOpenRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanCangKuOpenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanCangKuOpenRequest), isFromPool) as C2M_JiaYuanCangKuOpenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanCangKuOpenResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanCangKuOpenResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanCangKuOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanCangKuOpenResponse), isFromPool) as M2C_JiaYuanCangKuOpenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanCookBookOpen))]
//学习菜单
	[Message(OuterMessage.C2M_JiaYuanCookBookOpen)]
	[MemoryPackable]
	public partial class C2M_JiaYuanCookBookOpen: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanCookBookOpen Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanCookBookOpen), isFromPool) as C2M_JiaYuanCookBookOpen; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int LearnMakeId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.LearnMakeId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanCookBookOpen)]
	[MemoryPackable]
	public partial class M2C_JiaYuanCookBookOpen: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanCookBookOpen Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanCookBookOpen), isFromPool) as M2C_JiaYuanCookBookOpen; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public List<int> LearnMakeIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.LearnMakeIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanCookResponse))]
//制作菜肴
	[Message(OuterMessage.C2M_JiaYuanCookRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanCookRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanCookRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanCookRequest), isFromPool) as C2M_JiaYuanCookRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public List<long> BagInfoIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.BagInfoIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanCookResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanCookResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanCookResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanCookResponse), isFromPool) as M2C_JiaYuanCookResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public int ItemId { get; set; }

		[MemoryPackOrder(1)]
		public List<int> LearnMakeIds { get; set; } = new();

		[MemoryPackOrder(2)]
		public int LearnId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.ItemId = default;
			this.LearnMakeIds.Clear();
			this.LearnId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanDaShiResponse))]
//家园大师
	[Message(OuterMessage.C2M_JiaYuanDaShiRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanDaShiRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanDaShiRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanDaShiRequest), isFromPool) as C2M_JiaYuanDaShiRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public List<long> BagInfoIDs { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.BagInfoIDs.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanDaShiResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanDaShiResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanDaShiResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanDaShiResponse), isFromPool) as M2C_JiaYuanDaShiResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public long JiaYuanDaShiTime { get; set; }

		[MemoryPackOrder(1)]
		public List<KeyValuePairInt> JiaYuanProAdd { get; set; } = new();

		[MemoryPackOrder(6)]
		public List<KeyValuePair> JiaYuanProList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.JiaYuanDaShiTime = default;
			this.JiaYuanProAdd.Clear();
			this.JiaYuanProList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanExchangeResponse))]
//家园兑换
	[Message(OuterMessage.C2M_JiaYuanExchangeRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanExchangeRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanExchangeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanExchangeRequest), isFromPool) as C2M_JiaYuanExchangeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ExchangeType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ExchangeType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanExchangeResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanExchangeResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanExchangeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanExchangeResponse), isFromPool) as M2C_JiaYuanExchangeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanGatherResponse))]
	[Message(OuterMessage.C2M_JiaYuanGatherRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanGatherRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanGatherRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanGatherRequest), isFromPool) as C2M_JiaYuanGatherRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int CellIndex { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CellIndex = default;
			this.UnitId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanGatherResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanGatherResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanGatherResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanGatherResponse), isFromPool) as M2C_JiaYuanGatherResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanGatherOtherResponse))]
	[Message(OuterMessage.C2M_JiaYuanGatherOtherRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanGatherOtherRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanGatherOtherRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanGatherOtherRequest), isFromPool) as C2M_JiaYuanGatherOtherRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int CellIndex { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public long MasterId { get; set; }

		[MemoryPackOrder(4)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CellIndex = default;
			this.UnitId = default;
			this.MasterId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanGatherOtherResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanGatherOtherResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanGatherOtherResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanGatherOtherResponse), isFromPool) as M2C_JiaYuanGatherOtherResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanInitResponse))]
	[Message(OuterMessage.C2M_JiaYuanInitRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanInitRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanInitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanInitRequest), isFromPool) as C2M_JiaYuanInitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long MasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.MasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanInitResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanInitResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanInitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanInitResponse), isFromPool) as M2C_JiaYuanInitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public int JiaYuanLv { get; set; }

		[MemoryPackOrder(3)]
		public string MasterName { get; set; }

		[MemoryPackOrder(4)]
		public long JiaYuanDaShiTime { get; set; }

		[MemoryPackOrder(5)]
		public List<int> LearnMakeIds { get; set; } = new();

		[MemoryPackOrder(9)]
		public List<int> PlanOpenList { get; set; } = new();

		[MemoryPackOrder(10)]
		public List<JiaYuanPet> JiaYuanPetList { get; set; } = new();

		[MemoryPackOrder(11)]
		public List<KeyValuePair> JiaYuanProList { get; set; } = new();

		[MemoryPackOrder(12)]
		public List<JiaYuanRecord> JiaYuanRecordList { get; set; } = new();

		[MemoryPackOrder(13)]
		public List<JiaYuanPastures> JiaYuanPastureList { get; set; } = new();

		[MemoryPackOrder(14)]
		public List<JiaYuanPurchaseItem> PurchaseItemList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.JiaYuanLv = default;
			this.MasterName = default;
			this.JiaYuanDaShiTime = default;
			this.LearnMakeIds.Clear();
			this.PlanOpenList.Clear();
			this.JiaYuanPetList.Clear();
			this.JiaYuanProList.Clear();
			this.JiaYuanRecordList.Clear();
			this.JiaYuanPastureList.Clear();
			this.PurchaseItemList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanMysteryBuyResponse))]
	[Message(OuterMessage.C2M_JiaYuanMysteryBuyRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanMysteryBuyRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanMysteryBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanMysteryBuyRequest), isFromPool) as C2M_JiaYuanMysteryBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ProductId { get; set; }

		[MemoryPackOrder(1)]
		public int MysteryId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ProductId = default;
			this.MysteryId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanMysteryBuyResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanMysteryBuyResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanMysteryBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanMysteryBuyResponse), isFromPool) as M2C_JiaYuanMysteryBuyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<MysteryItemInfo> MysteryItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.MysteryItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanMysteryListResponse))]
	[Message(OuterMessage.C2M_JiaYuanMysteryListRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanMysteryListRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanMysteryListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanMysteryListRequest), isFromPool) as C2M_JiaYuanMysteryListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int NpcID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.NpcID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanMysteryListResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanMysteryListResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanMysteryListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanMysteryListResponse), isFromPool) as M2C_JiaYuanMysteryListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<MysteryItemInfo> MysteryItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.MysteryItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPastureBuyResponse))]
	[Message(OuterMessage.C2M_JiaYuanPastureBuyRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPastureBuyRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPastureBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPastureBuyRequest), isFromPool) as C2M_JiaYuanPastureBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ProductId { get; set; }

		[MemoryPackOrder(1)]
		public int MysteryId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ProductId = default;
			this.MysteryId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPastureBuyResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPastureBuyResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPastureBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPastureBuyResponse), isFromPool) as M2C_JiaYuanPastureBuyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<MysteryItemInfo> MysteryItemInfos { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<JiaYuanPastures> JiaYuanPastureList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.MysteryItemInfos.Clear();
			this.JiaYuanPastureList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPastureListResponse))]
	[Message(OuterMessage.C2M_JiaYuanPastureListRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPastureListRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPastureListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPastureListRequest), isFromPool) as C2M_JiaYuanPastureListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPastureListResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPastureListResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPastureListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPastureListResponse), isFromPool) as M2C_JiaYuanPastureListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<MysteryItemInfo> MysteryItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.MysteryItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//宠物喂食
	[ResponseType(nameof(M2C_JiaYuanPetFeedResponse))]
	[Message(OuterMessage.C2M_JiaYuanPetFeedRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPetFeedRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPetFeedRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPetFeedRequest), isFromPool) as C2M_JiaYuanPetFeedRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long PetId { get; set; }

		[MemoryPackOrder(2)]
		public List<long> BagInfoIDs { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.PetId = default;
			this.BagInfoIDs.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPetFeedResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPetFeedResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPetFeedResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPetFeedResponse), isFromPool) as M2C_JiaYuanPetFeedResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int MoodAdd { get; set; }

		[MemoryPackOrder(1)]
		public List<JiaYuanPet> JiaYuanPetList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MoodAdd = default;
			this.JiaYuanPetList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPetOperateResponse))]
	[Message(OuterMessage.C2M_JiaYuanPetOperateRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPetOperateRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPetOperateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPetOperateRequest), isFromPool) as C2M_JiaYuanPetOperateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long PetInfoId { get; set; }

		[MemoryPackOrder(1)]
		public int Operate { get; set; }

		[MemoryPackOrder(3)]
		public long MasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PetInfoId = default;
			this.Operate = default;
			this.MasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPetOperateResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPetOperateResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPetOperateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPetOperateResponse), isFromPool) as M2C_JiaYuanPetOperateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(4)]
		public List<UnitInfo> PetList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.PetList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPetPositionResponse))]
	[Message(OuterMessage.C2M_JiaYuanPetPositionRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPetPositionRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPetPositionRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPetPositionRequest), isFromPool) as C2M_JiaYuanPetPositionRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public long MasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.MasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPetPositionResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPetPositionResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPetPositionResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPetPositionResponse), isFromPool) as M2C_JiaYuanPetPositionResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(4)]
		public List<UnitInfo> PetList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.PetList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//宠物散步
	[ResponseType(nameof(M2C_JiaYuanPetWalkResponse))]
	[Message(OuterMessage.C2M_JiaYuanPetWalkRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPetWalkRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPetWalkRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPetWalkRequest), isFromPool) as C2M_JiaYuanPetWalkRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long PetId { get; set; }

		[MemoryPackOrder(2)]
		public int PetStatus { get; set; }

		[MemoryPackOrder(3)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.PetId = default;
			this.PetStatus = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPetWalkResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPetWalkResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPetWalkResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPetWalkResponse), isFromPool) as M2C_JiaYuanPetWalkResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(10)]
		public List<JiaYuanPet> JiaYuanPetList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.JiaYuanPetList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPlanOpenResponse))]
	[Message(OuterMessage.C2M_JiaYuanPlanOpenRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPlanOpenRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPlanOpenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPlanOpenRequest), isFromPool) as C2M_JiaYuanPlanOpenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int CellIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CellIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPlanOpenResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPlanOpenResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPlanOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPlanOpenResponse), isFromPool) as M2C_JiaYuanPlanOpenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<int> PlanOpenList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.PlanOpenList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPlantResponse))]
	[Message(OuterMessage.C2M_JiaYuanPlantRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPlantRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPlantRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPlantRequest), isFromPool) as C2M_JiaYuanPlantRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int CellIndex { get; set; }

		[MemoryPackOrder(1)]
		public int ItemId { get; set; }

		[MemoryPackOrder(2)]
		public long OperateBagID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CellIndex = default;
			this.ItemId = default;
			this.OperateBagID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPlantResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPlantResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPlantResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPlantResponse), isFromPool) as M2C_JiaYuanPlantResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPurchaseResponse))]
//家园收购
	[Message(OuterMessage.C2M_JiaYuanPurchaseRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPurchaseRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPurchaseRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPurchaseRequest), isFromPool) as C2M_JiaYuanPurchaseRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public int ItemId { get; set; }

		[MemoryPackOrder(4)]
		public int PurchaseId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.ItemId = default;
			this.PurchaseId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPurchaseResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPurchaseResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPurchaseResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPurchaseResponse), isFromPool) as M2C_JiaYuanPurchaseResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public List<JiaYuanPurchaseItem> PurchaseItemList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.PurchaseItemList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanPurchaseRefresh))]
//家园收购刷新
	[Message(OuterMessage.C2M_JiaYuanPurchaseRefresh)]
	[MemoryPackable]
	public partial class C2M_JiaYuanPurchaseRefresh: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanPurchaseRefresh Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanPurchaseRefresh), isFromPool) as C2M_JiaYuanPurchaseRefresh; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public int ItemId { get; set; }

		[MemoryPackOrder(4)]
		public int PurchaseId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OperateType = default;
			this.ItemId = default;
			this.PurchaseId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanPurchaseRefresh)]
	[MemoryPackable]
	public partial class M2C_JiaYuanPurchaseRefresh: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanPurchaseRefresh Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanPurchaseRefresh), isFromPool) as M2C_JiaYuanPurchaseRefresh; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public List<JiaYuanPurchaseItem> PurchaseItemList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.PurchaseItemList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanRecordListResponse))]
	[Message(OuterMessage.C2M_JiaYuanRecordListRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanRecordListRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanRecordListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanRecordListRequest), isFromPool) as C2M_JiaYuanRecordListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanRecordListResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanRecordListResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanRecordListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanRecordListResponse), isFromPool) as M2C_JiaYuanRecordListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(4)]
		public List<JiaYuanRecord> JiaYuanRecordList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.JiaYuanRecordList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//一键放入
	[ResponseType(nameof(M2C_JiaYuanStoreResponse))]
	[Message(OuterMessage.C2M_JiaYuanStoreRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanStoreRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanStoreRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanStoreRequest), isFromPool) as C2M_JiaYuanStoreRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int HorseId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.HorseId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanStoreResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanStoreResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanStoreResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanStoreResponse), isFromPool) as M2C_JiaYuanStoreResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanUpLvResponse))]
//家园升级
	[Message(OuterMessage.C2M_JiaYuanUpLvRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanUpLvRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanUpLvRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanUpLvRequest), isFromPool) as C2M_JiaYuanUpLvRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanUpLvResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanUpLvResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanUpLvResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanUpLvResponse), isFromPool) as M2C_JiaYuanUpLvResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanUprootResponse))]
	[Message(OuterMessage.C2M_JiaYuanUprootRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanUprootRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanUprootRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanUprootRequest), isFromPool) as C2M_JiaYuanUprootRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int CellIndex { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CellIndex = default;
			this.UnitId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanUprootResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanUprootResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanUprootResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanUprootResponse), isFromPool) as M2C_JiaYuanUprootResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public int CellIndex { get; set; }

		[MemoryPackOrder(3)]
		public List<JiaYuanPastures> JiaYuanPastureList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.CellIndex = default;
			this.JiaYuanPastureList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//好友家园
	[ResponseType(nameof(M2C_JiaYuanVisitListResponse))]
	[Message(OuterMessage.C2M_JiaYuanVisitListRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanVisitListRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanVisitListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanVisitListRequest), isFromPool) as C2M_JiaYuanVisitListRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long MasterId { get; set; }

		[MemoryPackOrder(2)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.MasterId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.JiaYuanVisit)]
	[MemoryPackable]
	public partial class JiaYuanVisit: MessageObject
	{
		public static JiaYuanVisit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(JiaYuanVisit), isFromPool) as JiaYuanVisit; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int Occ { get; set; }

		[MemoryPackOrder(2)]
		public int OccTwo { get; set; }

		[MemoryPackOrder(3)]
		public int Rubbish { get; set; }

		[MemoryPackOrder(4)]
		public int Gather { get; set; }

		[MemoryPackOrder(5)]
		public string PlayerName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.Occ = default;
			this.OccTwo = default;
			this.Rubbish = default;
			this.Gather = default;
			this.PlayerName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanVisitListResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanVisitListResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanVisitListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanVisitListResponse), isFromPool) as M2C_JiaYuanVisitListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<JiaYuanVisit> JiaYuanVisit_1 { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<JiaYuanVisit> JiaYuanVisit_2 { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.JiaYuanVisit_1.Clear();
			this.JiaYuanVisit_2.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_JiaYuanWatchResponse))]
	[Message(OuterMessage.C2M_JiaYuanWatchRequest)]
	[MemoryPackable]
	public partial class C2M_JiaYuanWatchRequest: MessageObject, ILocationRequest
	{
		public static C2M_JiaYuanWatchRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_JiaYuanWatchRequest), isFromPool) as C2M_JiaYuanWatchRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long MasterId { get; set; }

		[MemoryPackOrder(2)]
		public int OperateType { get; set; }

		[MemoryPackOrder(3)]
		public long OperateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.MasterId = default;
			this.OperateType = default;
			this.OperateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_JiaYuanWatchResponse)]
	[MemoryPackable]
	public partial class M2C_JiaYuanWatchResponse: MessageObject, ILocationResponse
	{
		public static M2C_JiaYuanWatchResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_JiaYuanWatchResponse), isFromPool) as M2C_JiaYuanWatchResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public List<JiaYuanRecord> JiaYuanRecord { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.JiaYuanRecord.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//一键取出
	[ResponseType(nameof(M2C_TakeOutAllResponse))]
	[Message(OuterMessage.C2M_TakeOutAllRequest)]
	[MemoryPackable]
	public partial class C2M_TakeOutAllRequest: MessageObject, ILocationRequest
	{
		public static C2M_TakeOutAllRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TakeOutAllRequest), isFromPool) as C2M_TakeOutAllRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int HorseId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.HorseId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TakeOutAllResponse)]
	[MemoryPackable]
	public partial class M2C_TakeOutAllResponse: MessageObject, ILocationResponse
	{
		public static M2C_TakeOutAllResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TakeOutAllResponse), isFromPool) as M2C_TakeOutAllResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_LingDiRewardResponse))]
	[Message(OuterMessage.C2M_LingDiRewardRequest)]
	[MemoryPackable]
	public partial class C2M_LingDiRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_LingDiRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_LingDiRewardRequest), isFromPool) as C2M_LingDiRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RewardId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_LingDiRewardResponse)]
	[MemoryPackable]
	public partial class M2C_LingDiRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_LingDiRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_LingDiRewardResponse), isFromPool) as M2C_LingDiRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_LingDiUpResponse))]
	[Message(OuterMessage.C2M_LingDiUpRequest)]
	[MemoryPackable]
	public partial class C2M_LingDiUpRequest: MessageObject, ILocationRequest
	{
		public static C2M_LingDiUpRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_LingDiUpRequest), isFromPool) as C2M_LingDiUpRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_LingDiUpResponse)]
	[MemoryPackable]
	public partial class M2C_LingDiUpResponse: MessageObject, ILocationResponse
	{
		public static M2C_LingDiUpResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_LingDiUpResponse), isFromPool) as M2C_LingDiUpResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RandomTowerBeginResponse))]
//随机副本开始战斗
	[Message(OuterMessage.C2M_RandomTowerBeginRequest)]
	[MemoryPackable]
	public partial class C2M_RandomTowerBeginRequest: MessageObject, ILocationRequest
	{
		public static C2M_RandomTowerBeginRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RandomTowerBeginRequest), isFromPool) as C2M_RandomTowerBeginRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RandomNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RandomNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RandomTowerBeginResponse)]
	[MemoryPackable]
	public partial class M2C_RandomTowerBeginResponse: MessageObject, ILocationResponse
	{
		public static M2C_RandomTowerBeginResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RandomTowerBeginResponse), isFromPool) as M2C_RandomTowerBeginResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RandomTowerRewardResponse))]
//随机副本领取奖励
	[Message(OuterMessage.C2M_RandomTowerRewardRequest)]
	[MemoryPackable]
	public partial class C2M_RandomTowerRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_RandomTowerRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RandomTowerRewardRequest), isFromPool) as C2M_RandomTowerRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RewardId { get; set; }

		[MemoryPackOrder(1)]
		public int SceneType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RewardId = default;
			this.SceneType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RandomTowerRewardResponse)]
	[MemoryPackable]
	public partial class M2C_RandomTowerRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_RandomTowerRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RandomTowerRewardResponse), isFromPool) as M2C_RandomTowerRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_IOSPayVerifyResponse))]
	[Message(OuterMessage.C2M_IOSPayVerifyRequest)]
	[MemoryPackable]
	public partial class C2M_IOSPayVerifyRequest: MessageObject, ILocationRequest
	{
		public static C2M_IOSPayVerifyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_IOSPayVerifyRequest), isFromPool) as C2M_IOSPayVerifyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public string payMessage { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.payMessage = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_IOSPayVerifyResponse)]
	[MemoryPackable]
	public partial class M2C_IOSPayVerifyResponse: MessageObject, ILocationResponse
	{
		public static M2C_IOSPayVerifyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_IOSPayVerifyResponse), isFromPool) as M2C_IOSPayVerifyResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RechargeResponse))]
	[Message(OuterMessage.C2M_RechargeRequest)]
	[MemoryPackable]
	public partial class C2M_RechargeRequest: MessageObject, ILocationRequest
	{
		public static C2M_RechargeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RechargeRequest), isFromPool) as C2M_RechargeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int RechargeNumber { get; set; }

		[MemoryPackOrder(1)]
		public long PayType { get; set; }

		[MemoryPackOrder(2)]
		public string RiskControlInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.RechargeNumber = default;
			this.PayType = default;
			this.RiskControlInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RechargeResponse)]
	[MemoryPackable]
	public partial class M2C_RechargeResponse: MessageObject, ILocationResponse
	{
		public static M2C_RechargeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RechargeResponse), isFromPool) as M2C_RechargeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public string PayMessage { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PayMessage = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//累计充值奖励
	[ResponseType(nameof(M2C_RechargeRewardResponse))]
	[Message(OuterMessage.C2M_RechargeRewardRequest)]
	[MemoryPackable]
	public partial class C2M_RechargeRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_RechargeRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RechargeRewardRequest), isFromPool) as C2M_RechargeRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int RechargeNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RechargeNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RechargeRewardResponse)]
	[MemoryPackable]
	public partial class M2C_RechargeRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_RechargeRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RechargeRewardResponse), isFromPool) as M2C_RechargeRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ExpToGoldResponse))]
	[Message(OuterMessage.C2M_ExpToGoldRequest)]
	[MemoryPackable]
	public partial class C2M_ExpToGoldRequest: MessageObject, ILocationRequest
	{
		public static C2M_ExpToGoldRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ExpToGoldRequest), isFromPool) as C2M_ExpToGoldRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ExpToGoldResponse)]
	[MemoryPackable]
	public partial class M2C_ExpToGoldResponse: MessageObject, ILocationResponse
	{
		public static M2C_ExpToGoldResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ExpToGoldResponse), isFromPool) as M2C_ExpToGoldResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RealNameRewardResponse))]
	[Message(OuterMessage.C2M_RealNameRewardRequest)]
	[MemoryPackable]
	public partial class C2M_RealNameRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_RealNameRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RealNameRewardRequest), isFromPool) as C2M_RealNameRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RealNameRewardResponse)]
	[MemoryPackable]
	public partial class M2C_RealNameRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_RealNameRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RealNameRewardResponse), isFromPool) as M2C_RealNameRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RolePetChouKaResponse))]
	[Message(OuterMessage.C2M_RolePetChouKaRequest)]
	[MemoryPackable]
	public partial class C2M_RolePetChouKaRequest: MessageObject, ILocationRequest
	{
		public static C2M_RolePetChouKaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RolePetChouKaRequest), isFromPool) as C2M_RolePetChouKaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ChouKaType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChouKaType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RolePetChouKaResponse)]
	[MemoryPackable]
	public partial class M2C_RolePetChouKaResponse: MessageObject, ILocationResponse
	{
		public static M2C_RolePetChouKaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RolePetChouKaResponse), isFromPool) as M2C_RolePetChouKaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public RolePetInfo RolePetInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RolePetInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//赛季等级奖励
	[ResponseType(nameof(M2C_SeasonLevelRewardResponse))]
	[Message(OuterMessage.C2M_SeasonLevelRewardRequest)]
	[MemoryPackable]
	public partial class C2M_SeasonLevelRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_SeasonLevelRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SeasonLevelRewardRequest), isFromPool) as C2M_SeasonLevelRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SeasonLevel { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SeasonLevel = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SeasonLevelRewardResponse)]
	[MemoryPackable]
	public partial class M2C_SeasonLevelRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_SeasonLevelRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SeasonLevelRewardResponse), isFromPool) as M2C_SeasonLevelRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//开启晶核
	[ResponseType(nameof(M2C_SeasonOpenJingHeResponse))]
	[Message(OuterMessage.C2M_SeasonOpenJingHeRequest)]
	[MemoryPackable]
	public partial class C2M_SeasonOpenJingHeRequest: MessageObject, ILocationRequest
	{
		public static C2M_SeasonOpenJingHeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SeasonOpenJingHeRequest), isFromPool) as C2M_SeasonOpenJingHeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int JingHeId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.JingHeId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SeasonOpenJingHeResponse)]
	[MemoryPackable]
	public partial class M2C_SeasonOpenJingHeResponse: MessageObject, ILocationResponse
	{
		public static M2C_SeasonOpenJingHeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SeasonOpenJingHeResponse), isFromPool) as M2C_SeasonOpenJingHeResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//使用赛季果实， 更新boss刷新时间
	[ResponseType(nameof(M2C_SeasonUseFruitResponse))]
	[Message(OuterMessage.C2M_SeasonUseFruitRequest)]
	[MemoryPackable]
	public partial class C2M_SeasonUseFruitRequest: MessageObject, ILocationRequest
	{
		public static C2M_SeasonUseFruitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SeasonUseFruitRequest), isFromPool) as C2M_SeasonUseFruitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<long> BagInfoIDs { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.BagInfoIDs.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SeasonUseFruitResponse)]
	[MemoryPackable]
	public partial class M2C_SeasonUseFruitResponse: MessageObject, ILocationResponse
	{
		public static M2C_SeasonUseFruitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SeasonUseFruitResponse), isFromPool) as M2C_SeasonUseFruitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ShoujiRewardResponse))]
	[Message(OuterMessage.C2M_ShoujiRewardRequest)]
	[MemoryPackable]
	public partial class C2M_ShoujiRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_ShoujiRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ShoujiRewardRequest), isFromPool) as C2M_ShoujiRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ChapterId { get; set; }

		[MemoryPackOrder(1)]
		public int RewardIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ChapterId = default;
			this.RewardIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ShoujiRewardResponse)]
	[MemoryPackable]
	public partial class M2C_ShoujiRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_ShoujiRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ShoujiRewardResponse), isFromPool) as M2C_ShoujiRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ShouJiTreasureResponse))]
//收集珍宝
	[Message(OuterMessage.C2M_ShouJiTreasureRequest)]
	[MemoryPackable]
	public partial class C2M_ShouJiTreasureRequest: MessageObject, ILocationRequest
	{
		public static C2M_ShouJiTreasureRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ShouJiTreasureRequest), isFromPool) as C2M_ShouJiTreasureRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ShouJiId { get; set; }

		[MemoryPackOrder(1)]
		public List<long> ItemIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ShouJiId = default;
			this.ItemIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ShouJiTreasureResponse)]
	[MemoryPackable]
	public partial class M2C_ShouJiTreasureResponse: MessageObject, ILocationResponse
	{
		public static M2C_ShouJiTreasureResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ShouJiTreasureResponse), isFromPool) as M2C_ShouJiTreasureResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		[MemoryPackOrder(0)]
		public int ActiveNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.ActiveNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//激活称号
	[ResponseType(nameof(M2C_TitleUseResponse))]
	[Message(OuterMessage.C2M_TitleUseRequest)]
	[MemoryPackable]
	public partial class C2M_TitleUseRequest: MessageObject, ILocationRequest
	{
		public static C2M_TitleUseRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TitleUseRequest), isFromPool) as C2M_TitleUseRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int TitleId { get; set; }

		[MemoryPackOrder(1)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.TitleId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TitleUseResponse)]
	[MemoryPackable]
	public partial class M2C_TitleUseResponse: MessageObject, ILocationResponse
	{
		public static M2C_TitleUseResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TitleUseResponse), isFromPool) as M2C_TitleUseResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TitleUpdateResult)]
	[MemoryPackable]
	public partial class M2C_TitleUpdateResult: MessageObject, IMessage
	{
		public static M2C_TitleUpdateResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TitleUpdateResult), isFromPool) as M2C_TitleUpdateResult; 
		}

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(5)]
		public List<KeyValuePairInt> TitleList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActorId = default;
			this.UnitId = default;
			this.TitleList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TowerFightBeginResponse))]
//挑战之地开始战斗
	[Message(OuterMessage.C2M_TowerFightBeginRequest)]
	[MemoryPackable]
	public partial class C2M_TowerFightBeginRequest: MessageObject, ILocationRequest
	{
		public static C2M_TowerFightBeginRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TowerFightBeginRequest), isFromPool) as C2M_TowerFightBeginRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TowerFightBeginResponse)]
	[MemoryPackable]
	public partial class M2C_TowerFightBeginResponse: MessageObject, ILocationResponse
	{
		public static M2C_TowerFightBeginResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TowerFightBeginResponse), isFromPool) as M2C_TowerFightBeginResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TowerExitResponse))]
	[Message(OuterMessage.C2M_TowerExitRequest)]
	[MemoryPackable]
	public partial class C2M_TowerExitRequest: MessageObject, ILocationRequest
	{
		public static C2M_TowerExitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TowerExitRequest), isFromPool) as C2M_TowerExitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TowerExitResponse)]
	[MemoryPackable]
	public partial class M2C_TowerExitResponse: MessageObject, ILocationResponse
	{
		public static M2C_TowerExitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TowerExitResponse), isFromPool) as M2C_TowerExitResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

// 封印之塔继续挑战
	[ResponseType(nameof(M2C_TowerOfSealNextResponse))]
	[Message(OuterMessage.C2M_TowerOfSealNextRequest)]
	[MemoryPackable]
	public partial class C2M_TowerOfSealNextRequest: MessageObject, ILocationRequest
	{
		public static C2M_TowerOfSealNextRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TowerOfSealNextRequest), isFromPool) as C2M_TowerOfSealNextRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int DiceResult { get; set; }

		[MemoryPackOrder(1)]
		public int CostType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.DiceResult = default;
			this.CostType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TowerOfSealNextResponse)]
	[MemoryPackable]
	public partial class M2C_TowerOfSealNextResponse: MessageObject, ILocationResponse
	{
		public static M2C_TowerOfSealNextResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TowerOfSealNextResponse), isFromPool) as M2C_TowerOfSealNextResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//试炼副本开始
	[ResponseType(nameof(M2C_TrialDungeonBeginResponse))]
	[Message(OuterMessage.C2M_TrialDungeonBeginRequest)]
	[MemoryPackable]
	public partial class C2M_TrialDungeonBeginRequest: MessageObject, ILocationRequest
	{
		public static C2M_TrialDungeonBeginRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TrialDungeonBeginRequest), isFromPool) as C2M_TrialDungeonBeginRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TrialDungeonBeginResponse)]
	[MemoryPackable]
	public partial class M2C_TrialDungeonBeginResponse: MessageObject, ILocationResponse
	{
		public static M2C_TrialDungeonBeginResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TrialDungeonBeginResponse), isFromPool) as M2C_TrialDungeonBeginResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//试炼副本结束
	[ResponseType(nameof(M2C_TrialDungeonFinishResponse))]
	[Message(OuterMessage.C2M_TrialDungeonFinishRequest)]
	[MemoryPackable]
	public partial class C2M_TrialDungeonFinishRequest: MessageObject, ILocationRequest
	{
		public static C2M_TrialDungeonFinishRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TrialDungeonFinishRequest), isFromPool) as C2M_TrialDungeonFinishRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TrialDungeonFinishResponse)]
	[MemoryPackable]
	public partial class M2C_TrialDungeonFinishResponse: MessageObject, ILocationResponse
	{
		public static M2C_TrialDungeonFinishResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TrialDungeonFinishResponse), isFromPool) as M2C_TrialDungeonFinishResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int CombatResult { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.CombatResult = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//小龟大赛记录
	[ResponseType(nameof(M2C_TurtleRecordResponse))]
	[Message(OuterMessage.C2M_TurtleRecordRequest)]
	[MemoryPackable]
	public partial class C2M_TurtleRecordRequest: MessageObject, ILocationRequest
	{
		public static C2M_TurtleRecordRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TurtleRecordRequest), isFromPool) as C2M_TurtleRecordRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TurtleRecordResponse)]
	[MemoryPackable]
	public partial class M2C_TurtleRecordResponse: MessageObject, ILocationResponse
	{
		public static M2C_TurtleRecordResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TurtleRecordResponse), isFromPool) as M2C_TurtleRecordResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(1)]
		public int SupportId { get; set; }

		[MemoryPackOrder(2)]
		public List<int> WinTimes { get; set; } = new();

		[MemoryPackOrder(3)]
		public List<int> SupportTimes { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.SupportId = default;
			this.WinTimes.Clear();
			this.SupportTimes.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//小龟大赛支持
	[ResponseType(nameof(M2C_TurtleSupportResponse))]
	[Message(OuterMessage.C2M_TurtleSupportRequest)]
	[MemoryPackable]
	public partial class C2M_TurtleSupportRequest: MessageObject, ILocationRequest
	{
		public static C2M_TurtleSupportRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TurtleSupportRequest), isFromPool) as C2M_TurtleSupportRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SupportId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SupportId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TurtleSupportResponse)]
	[MemoryPackable]
	public partial class M2C_TurtleSupportResponse: MessageObject, ILocationResponse
	{
		public static M2C_TurtleSupportResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TurtleSupportResponse), isFromPool) as M2C_TurtleSupportResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_WelfareDraw2Response))]
	[Message(OuterMessage.C2M_WelfareDraw2Request)]
	[MemoryPackable]
	public partial class C2M_WelfareDraw2Request: MessageObject, ILocationRequest
	{
		public static C2M_WelfareDraw2Request Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WelfareDraw2Request), isFromPool) as C2M_WelfareDraw2Request; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WelfareDraw2Response)]
	[MemoryPackable]
	public partial class M2C_WelfareDraw2Response: MessageObject, ILocationResponse
	{
		public static M2C_WelfareDraw2Response Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WelfareDraw2Response), isFromPool) as M2C_WelfareDraw2Response; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_WelfareDraw2RewardResponse))]
	[Message(OuterMessage.C2M_WelfareDraw2RewardRequest)]
	[MemoryPackable]
	public partial class C2M_WelfareDraw2RewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_WelfareDraw2RewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WelfareDraw2RewardRequest), isFromPool) as C2M_WelfareDraw2RewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WelfareDraw2RewardResponse)]
	[MemoryPackable]
	public partial class M2C_WelfareDraw2RewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_WelfareDraw2RewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WelfareDraw2RewardResponse), isFromPool) as M2C_WelfareDraw2RewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//幸运抽奖. 随机一个位置，并不会会道具， 该位置每天是固定的
	[ResponseType(nameof(M2C_WelfareDrawResponse))]
	[Message(OuterMessage.C2M_WelfareDrawRequest)]
	[MemoryPackable]
	public partial class C2M_WelfareDrawRequest: MessageObject, ILocationRequest
	{
		public static C2M_WelfareDrawRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WelfareDrawRequest), isFromPool) as C2M_WelfareDrawRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WelfareDrawResponse)]
	[MemoryPackable]
	public partial class M2C_WelfareDrawResponse: MessageObject, ILocationResponse
	{
		public static M2C_WelfareDrawResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WelfareDrawResponse), isFromPool) as M2C_WelfareDrawResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//转盘结束，给予道具
	[ResponseType(nameof(M2C_WelfareDrawRewardResponse))]
	[Message(OuterMessage.C2M_WelfareDrawRewardRequest)]
	[MemoryPackable]
	public partial class C2M_WelfareDrawRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_WelfareDrawRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WelfareDrawRewardRequest), isFromPool) as C2M_WelfareDrawRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WelfareDrawRewardResponse)]
	[MemoryPackable]
	public partial class M2C_WelfareDrawRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_WelfareDrawRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WelfareDrawRewardResponse), isFromPool) as M2C_WelfareDrawRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//投资
	[ResponseType(nameof(M2C_WelfareInvestResponse))]
	[Message(OuterMessage.C2M_WelfareInvestRequest)]
	[MemoryPackable]
	public partial class C2M_WelfareInvestRequest: MessageObject, ILocationRequest
	{
		public static C2M_WelfareInvestRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WelfareInvestRequest), isFromPool) as C2M_WelfareInvestRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Index { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Index = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WelfareInvestResponse)]
	[MemoryPackable]
	public partial class M2C_WelfareInvestResponse: MessageObject, ILocationResponse
	{
		public static M2C_WelfareInvestResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WelfareInvestResponse), isFromPool) as M2C_WelfareInvestResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//投资奖励。第七天可以领取奖励
	[ResponseType(nameof(M2C_WelfareInvestRewardResponse))]
	[Message(OuterMessage.C2M_WelfareInvestRewardRequest)]
	[MemoryPackable]
	public partial class C2M_WelfareInvestRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_WelfareInvestRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WelfareInvestRewardRequest), isFromPool) as C2M_WelfareInvestRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WelfareInvestRewardResponse)]
	[MemoryPackable]
	public partial class M2C_WelfareInvestRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_WelfareInvestRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WelfareInvestRewardResponse), isFromPool) as M2C_WelfareInvestRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//当前的任务全部完成，才可以领取
	[ResponseType(nameof(M2C_WelfareTaskRewardResponse))]
	[Message(OuterMessage.C2M_WelfareTaskRewardRequest)]
	[MemoryPackable]
	public partial class C2M_WelfareTaskRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_WelfareTaskRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WelfareTaskRewardRequest), isFromPool) as C2M_WelfareTaskRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int day { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.day = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WelfareTaskRewardResponse)]
	[MemoryPackable]
	public partial class M2C_WelfareTaskRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_WelfareTaskRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WelfareTaskRewardResponse), isFromPool) as M2C_WelfareTaskRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_YueKaOpenResponse))]
	[Message(OuterMessage.C2M_YueKaOpenRequest)]
	[MemoryPackable]
	public partial class C2M_YueKaOpenRequest: MessageObject, ILocationRequest
	{
		public static C2M_YueKaOpenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_YueKaOpenRequest), isFromPool) as C2M_YueKaOpenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_YueKaOpenResponse)]
	[MemoryPackable]
	public partial class M2C_YueKaOpenResponse: MessageObject, ILocationResponse
	{
		public static M2C_YueKaOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_YueKaOpenResponse), isFromPool) as M2C_YueKaOpenResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_YueKaRewardResponse))]
	[Message(OuterMessage.C2M_YueKaRewardRequest)]
	[MemoryPackable]
	public partial class C2M_YueKaRewardRequest: MessageObject, ILocationRequest
	{
		public static C2M_YueKaRewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_YueKaRewardRequest), isFromPool) as C2M_YueKaRewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_YueKaRewardResponse)]
	[MemoryPackable]
	public partial class M2C_YueKaRewardResponse: MessageObject, ILocationResponse
	{
		public static M2C_YueKaRewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_YueKaRewardResponse), isFromPool) as M2C_YueKaRewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Popularize2C_UploadResponse))]
//内存占用
	[Message(OuterMessage.C2Popularize_UploadRequest)]
	[MemoryPackable]
	public partial class C2Popularize_UploadRequest: MessageObject, IPopularizeActorRequest
	{
		public static C2Popularize_UploadRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Popularize_UploadRequest), isFromPool) as C2Popularize_UploadRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string MemoryInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MemoryInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Popularize2C_UploadResponse)]
	[MemoryPackable]
	public partial class Popularize2C_UploadResponse: MessageObject, IPopularizeActorResponse
	{
		public static Popularize2C_UploadResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Popularize2C_UploadResponse), isFromPool) as Popularize2C_UploadResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Popularize2C_RewardResponse))]
//我的推广奖励
	[Message(OuterMessage.C2Popularize_RewardRequest)]
	[MemoryPackable]
	public partial class C2Popularize_RewardRequest: MessageObject, IPopularizeActorRequest
	{
		public static C2Popularize_RewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Popularize_RewardRequest), isFromPool) as C2Popularize_RewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Popularize2C_RewardResponse)]
	[MemoryPackable]
	public partial class Popularize2C_RewardResponse: MessageObject, IPopularizeActorResponse
	{
		public static Popularize2C_RewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Popularize2C_RewardResponse), isFromPool) as Popularize2C_RewardResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public string Message { get; set; }

		[MemoryPackOrder(91)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	public static class OuterMessage
	{
		 public const ushort HttpGetRouterResponse = 10002;
		 public const ushort RouterSync = 10003;
		 public const ushort C2M_TestRequest = 10004;
		 public const ushort M2C_TestResponse = 10005;
		 public const ushort C2C_SendBroadcastRequest = 10006;
		 public const ushort C2C_SendBroadcastResponse = 10007;
		 public const ushort C2E_GMEMailRequest = 10008;
		 public const ushort E2C_GMEMailResponse = 10009;
		 public const ushort C2C_GMCommonRequest = 10010;
		 public const ushort C2C_GMCommonResponse = 10011;
		 public const ushort C2G_Reload = 10012;
		 public const ushort G2C_Reload = 10013;
		 public const ushort C2C_GMInfoRequest = 10014;
		 public const ushort C2C_GMInfoResponse = 10015;
		 public const ushort C2G_EnterMap = 10016;
		 public const ushort G2C_EnterMap = 10017;
		 public const ushort MoveInfo = 10018;
		 public const ushort UnitInfo = 10019;
		 public const ushort M2C_CreateUnits = 10020;
		 public const ushort M2C_CreateMyUnit = 10021;
		 public const ushort M2C_StartSceneChange = 10022;
		 public const ushort M2C_RemoveUnits = 10023;
		 public const ushort C2M_PathfindingResult = 10024;
		 public const ushort C2M_Stop = 10025;
		 public const ushort M2C_PathfindingResult = 10026;
		 public const ushort M2C_Stop = 10027;
		 public const ushort C2G_Ping = 10028;
		 public const ushort G2C_Ping = 10029;
		 public const ushort G2C_Test = 10030;
		 public const ushort C2M_Reload = 10031;
		 public const ushort M2C_Reload = 10032;
		 public const ushort C2R_LoginAccount = 10033;
		 public const ushort R2C_LoginAccount = 10034;
		 public const ushort RechargeInfo = 10035;
		 public const ushort KeyValuePair = 10036;
		 public const ushort KeyValuePairInt = 10037;
		 public const ushort KeyValuePairLong = 10038;
		 public const ushort PlayerInfo = 10039;
		 public const ushort CreateRoleInfo = 10040;
		 public const ushort C2G_LoginGameGate = 10041;
		 public const ushort G2C_LoginGameGate = 10042;
		 public const ushort ServerItem = 10043;
		 public const ushort C2G_CreateRoleData = 10044;
		 public const ushort G2C_CreateRoleData = 10045;
		 public const ushort C2G_DeleteRoleData = 10046;
		 public const ushort G2C_DeleteRoleData = 10047;
		 public const ushort G2C_TestHotfixMessage = 10048;
		 public const ushort C2M_TestRobotCase = 10049;
		 public const ushort M2C_TestRobotCase = 10050;
		 public const ushort C2M_TestRobotCase2 = 10051;
		 public const ushort M2C_TestRobotCase2 = 10052;
		 public const ushort C2M_TransferMap = 10053;
		 public const ushort M2C_TransferMap = 10054;
		 public const ushort C2G_Benchmark = 10055;
		 public const ushort G2C_Benchmark = 10056;
		 public const ushort HideProList = 10057;
		 public const ushort BagInfo = 10058;
		 public const ushort MysteryItemInfo = 10059;
		 public const ushort ZhanQuReceiveNumber = 10060;
		 public const ushort FirstWinInfo = 10061;
		 public const ushort PetMingPlayerInfo = 10062;
		 public const ushort ChatInfo = 10063;
		 public const ushort MailInfo = 10064;
		 public const ushort PaiMaiItemInfo = 10065;
		 public const ushort PaiMaiShopItemInfo = 10066;
		 public const ushort PopularizeInfo = 10067;
		 public const ushort RankingInfo = 10068;
		 public const ushort RankShouLieInfo = 10069;
		 public const ushort RankPetInfo = 10070;
		 public const ushort ServerInfo = 10071;
		 public const ushort ServerMailItem = 10072;
		 public const ushort UnionInfo = 10073;
		 public const ushort UnionPlayerInfo = 10074;
		 public const ushort DonationRecord = 10075;
		 public const ushort A2C_Disconnect = 10076;
		 public const ushort UserInfo = 10077;
		 public const ushort M2C_RoleDataUpdate = 10078;
		 public const ushort M2C_RoleDataBroadcast = 10079;
		 public const ushort SkillPro = 10080;
		 public const ushort RewardItem = 10081;
		 public const ushort FubenPassInfo = 10082;
		 public const ushort C2M_GMCommand = 10083;
		 public const ushort C2A_ActivityInfoRequest = 10084;
		 public const ushort A2C_ActivityInfoResponse = 10085;
		 public const ushort C2A_FirstWinInfoRequest = 10086;
		 public const ushort A2C_FirstWinInfoResponse = 10087;
		 public const ushort C2A_MysteryListRequest = 10088;
		 public const ushort A2C_MysteryListResponse = 10089;
		 public const ushort C2A_PetMingChanChuRequest = 10090;
		 public const ushort A2C_PetMingChanChuResponse = 10091;
		 public const ushort C2A_PetMingListRequest = 10092;
		 public const ushort A2C_PetMingListResponse = 10093;
		 public const ushort RolePetInfo = 10094;
		 public const ushort PetFubenInfo = 10095;
		 public const ushort PetMingRecord = 10096;
		 public const ushort M2C_RolePetBagUpdate = 10097;
		 public const ushort M2C_PetListMessage = 10098;
		 public const ushort M2C_RolePetUpdate = 10099;
		 public const ushort M2C_PetDataUpdate = 10100;
		 public const ushort M2C_PetDataBroadcast = 10101;
		 public const ushort M2C_RoleBagUpdate = 10102;
		 public const ushort C2M_BagInitRequest = 10103;
		 public const ushort M2C_BagInitResponse = 10104;
		 public const ushort C2M_OpenBoxRequest = 10105;
		 public const ushort M2C_OpenBoxResponse = 10106;
		 public const ushort DropInfo = 10107;
		 public const ushort C2M_PickItemRequest = 10108;
		 public const ushort M2C_PickItemResponse = 10109;
		 public const ushort C2M_EquipmentIncreaseRequest = 10110;
		 public const ushort M2C_EquipmentIncreaseResponse = 10111;
		 public const ushort C2M_FashionActiveRequest = 10112;
		 public const ushort M2C_FashionActiveResponse = 10113;
		 public const ushort C2M_FashionWearRequest = 10114;
		 public const ushort M2C_FashionWearResponse = 10115;
		 public const ushort C2M_GemHeChengQuickRequest = 10116;
		 public const ushort M2C_GemHeChengQuickResponse = 10117;
		 public const ushort C2M_ItemBuyCellRequest = 10118;
		 public const ushort M2C_ItemBuyCellResponse = 10119;
		 public const ushort C2M_RoleOpenCangKuRequest = 10120;
		 public const ushort M2C_RoleOpenCangKuResponse = 10121;
		 public const ushort C2M_ItemDestoryRequest = 10122;
		 public const ushort M2C_ItemDestoryResponse = 10123;
		 public const ushort C2M_ItemEquipIndexRequest = 10124;
		 public const ushort M2C_ItemEquipIndexResponse = 10125;
		 public const ushort C2M_ItemFumoProRequest = 10126;
		 public const ushort M2C_ItemFumoProResponse = 10127;
		 public const ushort C2M_ItemFumoUseRequest = 10128;
		 public const ushort M2C_ItemFumoUseResponse = 10129;
		 public const ushort C2M_ItemHuiShouRequest = 10130;
		 public const ushort M2C_ItemHuiShouResponse = 10131;
		 public const ushort C2M_ItemIncreaseTransferRequest = 10132;
		 public const ushort M2C_ItemIncreaseTransferResponse = 10133;
		 public const ushort C2M_ItemInheritRequest = 10134;
		 public const ushort M2C_ItemInheritResponse = 10135;
		 public const ushort C2M_ItemInheritSelectRequest = 10136;
		 public const ushort M2C_ItemInheritSelectResponse = 10137;
		 public const ushort C2M_ItemMeltingRequest = 10138;
		 public const ushort M2C_ItemMeltingResponse = 10139;
		 public const ushort C2M_ItemOneSellRequest = 10140;
		 public const ushort M2C_ItemOneSellResponse = 10141;
		 public const ushort C2M_ItemOperateGemRequest = 10142;
		 public const ushort M2C_ItemOperateGemResponse = 10143;
		 public const ushort C2M_ItemOperateRequest = 10144;
		 public const ushort M2C_ItemOperateResponse = 10145;
		 public const ushort C2M_ItemOperateWearRequest = 10146;
		 public const ushort M2C_ItemOperateWearResponse = 10147;
		 public const ushort C2M_ItemProtectRequest = 10148;
		 public const ushort M2C_ItemProtectResponse = 10149;
		 public const ushort C2M_ItemQiangHuaRequest = 10150;
		 public const ushort M2C_ItemQiangHuaResponse = 10151;
		 public const ushort C2M_ItemQuickPutRequest = 10152;
		 public const ushort M2C_ItemQuickPutResponse = 10153;
		 public const ushort C2M_ItemSortRequest = 10154;
		 public const ushort C2M_ItemSplitRequest = 10155;
		 public const ushort M2C_ItemSplitResponse = 10156;
		 public const ushort C2M_ItemTreasureOpenRequest = 10157;
		 public const ushort M2C_ItemTreasureOpenResponse = 10158;
		 public const ushort SkillInfo = 10159;
		 public const ushort M2C_UnitNumericListUpdate = 10160;
		 public const ushort C2M_UserInfoInitRequest = 10161;
		 public const ushort M2C_UserInfoInitResponse = 10162;
		 public const ushort FriendInfo = 10163;
		 public const ushort C2F_FriendApplyReplyRequest = 10164;
		 public const ushort F2C_FriendApplyReplyResponse = 10165;
		 public const ushort C2F_FriendBlacklistRequest = 10166;
		 public const ushort F2C_FriendBlacklistResponse = 10167;
		 public const ushort C2F_FriendApplyRequest = 10168;
		 public const ushort F2C_FriendApplyResponse = 10169;
		 public const ushort C2F_FriendChatRead = 10170;
		 public const ushort F2C_FriendChatRead = 10171;
		 public const ushort C2F_FriendDeleteRequest = 10172;
		 public const ushort F2C_FriendDeleteResponse = 10173;
		 public const ushort C2F_FriendInfoRequest = 10174;
		 public const ushort F2C_FriendInfoResponse = 10175;
		 public const ushort C2F_WatchPlayerRequest = 10176;
		 public const ushort F2C_WatchPlayerResponse = 10177;
		 public const ushort ItemXiLianResult = 10178;
		 public const ushort M2C_FashionUpdate = 10179;
		 public const ushort C2M_SkillCmd = 10180;
		 public const ushort M2C_SkillCmd = 10181;
		 public const ushort M2C_UnitUseSkill = 10182;
		 public const ushort LifeShieldInfo = 10183;
		 public const ushort SkillSetInfo = 10184;
		 public const ushort M2C_SkillSetMessage = 10185;
		 public const ushort C2M_ChangeOccTwoRequest = 10186;
		 public const ushort M2C_ChangeOccTwoResponse = 10187;
		 public const ushort C2Chat_GetChatRequest = 10188;
		 public const ushort Chat2C_GetChatResponse = 10189;
		 public const ushort C2C_SendChatRequest = 10190;
		 public const ushort C2C_SendChatResponse = 10191;
		 public const ushort C2C_SyncChatInfo = 10192;
		 public const ushort ChengJiuInfo = 10193;
		 public const ushort M2C_ChengJiuActiveMessage = 10194;
		 public const ushort TaskPro = 10195;
		 public const ushort M2C_TaskCountryUpdate = 10196;
		 public const ushort M2C_TaskUpdate = 10197;
		 public const ushort C2M_TianFuActiveRequest = 10198;
		 public const ushort M2C_TianFuActiveResponse = 10199;
		 public const ushort C2M_SkillSet = 10200;
		 public const ushort M2C_SkillSet = 10201;
		 public const ushort C2M_TaskCommitRequest = 10202;
		 public const ushort M2C_TaskCommitResponse = 10203;
		 public const ushort C2M_CommitTaskCountryRequest = 10204;
		 public const ushort M2C_CommitTaskCountryResponse = 10205;
		 public const ushort C2M_TaskCountryInitRequest = 10206;
		 public const ushort M2C_TaskCountryInitResponse = 10207;
		 public const ushort C2M_TaskGetRequest = 10208;
		 public const ushort M2C_TaskGetResponse = 10209;
		 public const ushort C2M_TaskGiveUpRequest = 10210;
		 public const ushort M2C_TaskGiveUpResponse = 10211;
		 public const ushort C2M_TaskHuoYueRewardRequest = 10212;
		 public const ushort M2C_TaskHuoYueRewardResponse = 10213;
		 public const ushort C2M_TaskInitRequest = 10214;
		 public const ushort M2C_TaskInitResponse = 10215;
		 public const ushort C2M_TaskNoticeRequest = 10216;
		 public const ushort M2C_TaskNoticeResponse = 10217;
		 public const ushort C2M_TaskOnLoginRequest = 10218;
		 public const ushort M2C_TaskOnLoginResponse = 10219;
		 public const ushort C2M_TaskTrackRequest = 10220;
		 public const ushort M2C_TaskTrackResponse = 10221;
		 public const ushort C2M_SkillInitRequest = 10222;
		 public const ushort M2C_SkillInitResponse = 10223;
		 public const ushort C2M_SkillInterruptRequest = 10224;
		 public const ushort M2C_SkillInterruptResult = 10225;
		 public const ushort C2M_SkillJueXingRequest = 10226;
		 public const ushort M2C_SkillJueXingResponse = 10227;
		 public const ushort C2M_SkillOperation = 10228;
		 public const ushort M2C_SkillOperation = 10229;
		 public const ushort C2M_SkillUp = 10230;
		 public const ushort M2C_SkillUp = 10231;
		 public const ushort C2M_LifeShieldCostRequest = 10232;
		 public const ushort M2C_LifeShieldCostResponse = 10233;
		 public const ushort C2M_TianFuPlanRequest = 10234;
		 public const ushort M2C_TianFuPlanResponse = 10235;
		 public const ushort M2C_UnitFinishSkill = 10236;
		 public const ushort C2M_RoleAddPointRequest = 10237;
		 public const ushort M2C_RoleAddPointResponse = 10238;
		 public const ushort M2C_UnitNumericUpdate = 10239;
		 public const ushort ShouJiChapterInfo = 10240;
		 public const ushort JiaYuanRecord = 10241;
		 public const ushort JiaYuanOperate = 10242;
		 public const ushort JiaYuanPurchaseItem = 10243;
		 public const ushort JiaYuanPlant = 10244;
		 public const ushort JiaYuanPastures = 10245;
		 public const ushort JiaYuanMonster = 10246;
		 public const ushort JiaYuanPet = 10247;
		 public const ushort C2M_RolePetList = 10248;
		 public const ushort M2C_RolePetList = 10249;
		 public const ushort C2M_RolePetFormationSet = 10250;
		 public const ushort M2C_RolePetFormationSet = 10251;
		 public const ushort C2M_RolePetFight = 10252;
		 public const ushort M2C_RolePetFight = 10253;
		 public const ushort C2M_RolePetUpStar = 10254;
		 public const ushort M2C_RolePetUpStar = 10255;
		 public const ushort C2M_RolePetFenjie = 10256;
		 public const ushort M2C_RolePetFenjie = 10257;
		 public const ushort C2M_RolePetXiLian = 10258;
		 public const ushort M2C_RolePetXiLian = 10259;
		 public const ushort C2M_RolePetHeCheng = 10260;
		 public const ushort M2C_RolePetHeCheng = 10261;
		 public const ushort C2M_PetChangePosRequest = 10262;
		 public const ushort M2C_PetChangePosResponse = 10263;
		 public const ushort C2M_PetDuiHuanRequest = 10264;
		 public const ushort M2C_PetDuiHuanResponse = 10265;
		 public const ushort C2M_PetEggChouKaRequest = 10266;
		 public const ushort M2C_PetEggChouKaResponse = 10267;
		 public const ushort C2M_PetEggDuiHuanRequest = 10268;
		 public const ushort M2C_PetEggDuiHuanResponse = 10269;
		 public const ushort C2M_PetEquipRequest = 10270;
		 public const ushort M2C_PetEquipResponse = 10271;
		 public const ushort C2M_PetExploreReward = 10272;
		 public const ushort M2C_PetExploreReward = 10273;
		 public const ushort C2M_PetFragmentDuiHuan = 10274;
		 public const ushort M2C_PetFragmentDuiHuan = 10275;
		 public const ushort C2M_PetFubenBeginRequest = 10276;
		 public const ushort M2C_PetFubenBeginResponse = 10277;
		 public const ushort C2M_PetFubenOverRequest = 10278;
		 public const ushort C2M_PetFubenRewardRequest = 10279;
		 public const ushort M2C_PetFubenRewardResponse = 10280;
		 public const ushort C2M_PetHeXinChouKaRequest = 10281;
		 public const ushort M2C_PetHeXinChouKaResponse = 10282;
		 public const ushort C2M_PetHeXinExploreReward = 10283;
		 public const ushort M2C_PetHeXinExploreReward = 10284;
		 public const ushort C2M_PetHeXinHeChengRequest = 10285;
		 public const ushort M2C_PetHeXinHeChengResponse = 10286;
		 public const ushort C2M_PetHeXinHeChengQuickRequest = 10287;
		 public const ushort M2C_PetHeXinHeChengQuickResponse = 10288;
		 public const ushort C2M_PetMingOccupyRequest = 10289;
		 public const ushort M2C_PetMingOccupyResponse = 10290;
		 public const ushort C2M_PetMingRecordRequest = 10291;
		 public const ushort M2C_PetMingRecordResponse = 10292;
		 public const ushort C2M_PetMingResetRequest = 10293;
		 public const ushort M2C_PetMingResetResponse = 10294;
		 public const ushort C2M_PetMingRewardRequest = 10295;
		 public const ushort M2C_PetMingRewardResponse = 10296;
		 public const ushort C2M_PetOpenCangKu = 10297;
		 public const ushort M2C_PetOpenCangKu = 10298;
		 public const ushort C2M_PetPutCangKu = 10299;
		 public const ushort M2C_PetPutCangKu = 10300;
		 public const ushort C2M_PetShouHuActiveRequest = 10301;
		 public const ushort M2C_PetShouHuActiveResponse = 10302;
		 public const ushort C2M_PetShouHuRequest = 10303;
		 public const ushort M2C_PetShouHuResponse = 10304;
		 public const ushort C2M_PetTakeOutBag = 10305;
		 public const ushort M2C_PetTakeOutBag = 10306;
		 public const ushort C2M_PetTargetLockRequest = 10307;
		 public const ushort M2C_PetTargetLockResponse = 10308;
		 public const ushort C2M_RolePetEggHatch = 10309;
		 public const ushort M2C_RolePetEggHatch = 10310;
		 public const ushort C2M_RolePetEggOpen = 10311;
		 public const ushort M2C_RolePetEggOpen = 10312;
		 public const ushort C2M_RolePetEggPutOut = 10313;
		 public const ushort M2C_RolePetEggPutOut = 10314;
		 public const ushort C2M_RolePetHeXin = 10315;
		 public const ushort M2C_RolePetHeXin = 10316;
		 public const ushort C2M_RolePetJiadian = 10317;
		 public const ushort M2C_RolePetJiadian = 10318;
		 public const ushort C2M_RolePetProtect = 10319;
		 public const ushort M2C_RolePetProtect = 10320;
		 public const ushort C2M_RolePetRName = 10321;
		 public const ushort M2C_RolePetRName = 10322;
		 public const ushort C2M_RolePetSkinSet = 10323;
		 public const ushort M2C_RolePetSkinSet = 10324;
		 public const ushort C2M_RolePetUpStage = 10325;
		 public const ushort M2C_RolePetUpStage = 10326;
		 public const ushort C2M_RolePetXiuLian = 10327;
		 public const ushort M2C_RolePetXiuLian = 10328;
		 public const ushort C2M_RolePetEggPut = 10329;
		 public const ushort M2C_RolePetEggPut = 10330;
		 public const ushort BattleSummonInfo = 10331;
		 public const ushort M2C_FubenSettlement = 10332;
		 public const ushort M2C_JiaYuanUpdate = 10333;
		 public const ushort M2C_FriendApplyResult = 10334;
		 public const ushort C2M_ChengJiuListRequest = 10335;
		 public const ushort M2C_ChengJiuListResponse = 10336;
		 public const ushort C2M_ChengJiuRewardRequest = 10337;
		 public const ushort M2C_ChengJiuRewardResponse = 10338;
		 public const ushort C2M_JingLingCatchRequest = 10339;
		 public const ushort M2C_JingLingCatchResponse = 10340;
		 public const ushort C2M_JingLingDropRequest = 10341;
		 public const ushort M2C_JingLingDropResponse = 10342;
		 public const ushort C2M_JingLingUseRequest = 10343;
		 public const ushort M2C_JingLingUseResponse = 10344;
		 public const ushort C2M_UnitStateUpdate = 10345;
		 public const ushort M2C_UnitBuffUpdate = 10346;
		 public const ushort M2C_UnitBuffRemove = 10347;
		 public const ushort M2C_UnitBuffStatus = 10348;
		 public const ushort M2C_SkillSecondResult = 10349;
		 public const ushort TokenRecvive = 10350;
		 public const ushort ActivityV1Info = 10351;
		 public const ushort M2C_ChainLightning = 10352;
		 public const ushort C2M_StoreBuyRequest = 10353;
		 public const ushort M2C_StoreBuyResponse = 10354;
		 public const ushort C2M_AccountWarehousOperateRequest = 10355;
		 public const ushort M2C_AccountWarehousOperateResponse = 10356;
		 public const ushort C2M_ItemXiLianRequest = 10357;
		 public const ushort M2C_ItemXiLianResponse = 10358;
		 public const ushort C2M_ItemXiLianNumReward = 10359;
		 public const ushort M2C_ItemXiLianNumReward = 10360;
		 public const ushort C2M_ItemXiLianRewardRequest = 10361;
		 public const ushort M2C_ItemXiLianRewardResponse = 10362;
		 public const ushort C2M_ItemXiLianSelectRequest = 10363;
		 public const ushort M2C_ItemXiLianSelectResponse = 10364;
		 public const ushort C2M_ItemXiLianTransferRequest = 10365;
		 public const ushort M2C_ItemXiLianTransferResponse = 10366;
		 public const ushort C2M_MakeSelectRequest = 10367;
		 public const ushort M2C_MakeSelectResponse = 10368;
		 public const ushort C2M_MakeEquipRequest = 10369;
		 public const ushort M2C_MakeEquipResponse = 10370;
		 public const ushort M2C_TurtleRewardMessage = 10371;
		 public const ushort C2M_BloodstoneQiangHuaRequest = 10372;
		 public const ushort M2C_BloodstoneQiangHuaResponse = 10373;
		 public const ushort C2M_DonationRequest = 10374;
		 public const ushort M2C_DonationResponse = 10375;
		 public const ushort C2M_UnionCreateRequest = 10376;
		 public const ushort M2C_UnionCreateResponse = 10377;
		 public const ushort C2M_UnionDonationRequest = 10378;
		 public const ushort M2C_UnionDonationResponse = 10379;
		 public const ushort C2M_UnionInviteRequest = 10380;
		 public const ushort M2C_UnionInviteMessage = 10381;
		 public const ushort C2M_UnionInviteReplyRequest = 10382;
		 public const ushort C2M_UnionKeJiLearnRequest = 10383;
		 public const ushort M2C_UnionKeJiLearnResponse = 10384;
		 public const ushort C2M_UnionLeaveRequest = 10385;
		 public const ushort M2C_UnionLeaveResponse = 10386;
		 public const ushort C2M_UnionMysteryBuyRequest = 10387;
		 public const ushort M2C_UnionMysteryBuyResponse = 10388;
		 public const ushort C2M_UnionTransferRequest = 10389;
		 public const ushort M2C_UnionTransferResponse = 10390;
		 public const ushort C2M_UnionXiuLianRequest = 10391;
		 public const ushort M2C_UnionXiuLianResponse = 10392;
		 public const ushort C2U_DonationRankListRequest = 10393;
		 public const ushort U2C_DonationRankListResponse = 10394;
		 public const ushort M2C_UnionRaceInfoResult = 10395;
		 public const ushort Actor_TransferRequest = 10396;
		 public const ushort Actor_TransferResponse = 10397;
		 public const ushort M2C_HorseNoticeInfo = 10398;
		 public const ushort UnionListItem = 10399;
		 public const ushort C2U_UnionListRequest = 10400;
		 public const ushort U2C_UnionListResponse = 10401;
		 public const ushort C2U_UnionApplyRequest = 10402;
		 public const ushort U2C_UnionApplyResponse = 10403;
		 public const ushort M2C_UnionApplyResult = 10404;
		 public const ushort C2U_UnionApplyListRequest = 10405;
		 public const ushort U2C_UnionApplyListResponse = 10406;
		 public const ushort C2U_UnionApplyReplyRequest = 10407;
		 public const ushort U2C_UnionApplyReplyResponse = 10408;
		 public const ushort C2U_UnionJingXuanRequest = 10409;
		 public const ushort U2C_UnionJingXuanResponse = 10410;
		 public const ushort C2U_UnionKeJiActiteRequest = 10411;
		 public const ushort U2C_UnionKeJiActiteResponse = 10412;
		 public const ushort C2U_UnionKeJiQuickRequest = 10413;
		 public const ushort U2C_UnionKeJiQuickResponse = 10414;
		 public const ushort C2U_UnionKickOutRequest = 10415;
		 public const ushort U2C_UnionKickOutResponse = 10416;
		 public const ushort C2U_UnionMyInfoRequest = 10417;
		 public const ushort U2C_UnionMyInfoResponse = 10418;
		 public const ushort C2U_UnionMysteryListRequest = 10419;
		 public const ushort U2C_UnionMysteryListResponse = 10420;
		 public const ushort C2U_UnionOperatateRequest = 10421;
		 public const ushort U2C_UnionOperatateResponse = 10422;
		 public const ushort C2U_UnionRaceInfoRequest = 10423;
		 public const ushort U2C_UnionRaceInfoResponse = 10424;
		 public const ushort C2U_UnionRecordRequest = 10425;
		 public const ushort U2C_UnionRecordResponse = 10426;
		 public const ushort C2U_UnionSignUpRequest = 10427;
		 public const ushort U2C_UnionSignUpResponse = 10428;
		 public const ushort R2M_RankUpdateMessage = 10429;
		 public const ushort RankingTrialInfo = 10430;
		 public const ushort RankSeasonTowerInfo = 10431;
		 public const ushort M2C_AreneInfoResult = 10432;
		 public const ushort M2C_BattleInfoResult = 10433;
		 public const ushort PaiMaiAuctionRecord = 10434;
		 public const ushort SoloPlayerInfo = 10435;
		 public const ushort SoloResultInfo = 10436;
		 public const ushort SoloMatchInfo = 10437;
		 public const ushort M2C_SoloMatchResult = 10438;
		 public const ushort SoloPlayerResultInfo = 10439;
		 public const ushort M2C_SoloDungeon = 10440;
		 public const ushort TeamPlayerInfo = 10441;
		 public const ushort M2C_SyncMiJingDamage = 10442;
		 public const ushort M2C_RunRaceBattleInfo = 10443;
		 public const ushort M2C_RankRunRaceMessage = 10444;
		 public const ushort M2C_RankRunRaceReward = 10445;
		 public const ushort M2C_RankDemonMessage = 10446;
		 public const ushort TeamInfo = 10447;
		 public const ushort M2C_TeamUpdateResult = 10448;
		 public const ushort M2C_TeamDungeonQuitMessage = 10449;
		 public const ushort M2C_TeamPickMessage = 10450;
		 public const ushort M2C_CreateDropItems = 10451;
		 public const ushort M2C_TeamDungeonSettlement = 10452;
		 public const ushort M2C_SyncChatInfo = 10453;
		 public const ushort C2Center_PhoneBinging = 10454;
		 public const ushort Center2C_PhoneBinging = 10455;
		 public const ushort C2Center_Register = 10456;
		 public const ushort Center2C_Register = 10457;
		 public const ushort C2Center_BlackAccountRequest = 10458;
		 public const ushort Center2C_BlackAccountResponse = 10459;
		 public const ushort M2Center_BuChangeRequest = 10460;
		 public const ushort Center2M_BuChangeResponse = 10461;
		 public const ushort C2C_ChatJinYanRequest = 10462;
		 public const ushort C2C_ChatJinYanResponse = 10463;
		 public const ushort C2M_ReceiveMailRequest = 10464;
		 public const ushort M2C_ReceiveMailResponse = 10465;
		 public const ushort C2E_ReceiveMailRequest = 10466;
		 public const ushort E2C_ReceiveMailResponse = 10467;
		 public const ushort C2E_GetAllMailRequest = 10468;
		 public const ushort E2C_GetAllMailResponse = 10469;
		 public const ushort C2F_WatchPetRequest = 10470;
		 public const ushort F2C_WatchPetResponse = 10471;
		 public const ushort C2M_HappyMoveRequest = 10472;
		 public const ushort M2C_HappyMoveResponse = 10473;
		 public const ushort C2M_HongBaoOpenRequest = 10474;
		 public const ushort M2C_HongBaoOpenResponse = 10475;
		 public const ushort C2M_PaiMaiAuctionJoinRequest = 10476;
		 public const ushort M2C_PaiMaiAuctionJoinResponse = 10477;
		 public const ushort C2M_PaiMaiAuctionPriceRequest = 10478;
		 public const ushort M2C_PaiMaiAuctionPriceResponse = 10479;
		 public const ushort C2M_PaiMaiBuyRequest = 10480;
		 public const ushort M2C_PaiMaiBuyResponse = 10481;
		 public const ushort C2M_PaiMaiDuiHuanRequest = 10482;
		 public const ushort M2C_PaiMaiDuiHuanResponse = 10483;
		 public const ushort C2M_PaiMaiSellRequest = 10484;
		 public const ushort M2C_PaiMaiSellResponse = 10485;
		 public const ushort C2M_PaiMaiShopRequest = 10486;
		 public const ushort M2C_PaiMaiShopResponse = 10487;
		 public const ushort C2M_PaiMaiXiaJiaRequest = 10488;
		 public const ushort M2C_PaiMaiXiaJiaResponse = 10489;
		 public const ushort C2M_StallBuyRequest = 10490;
		 public const ushort M2C_StallBuyResponse = 10491;
		 public const ushort C2M_StallOperationRequest = 10492;
		 public const ushort M2C_StallOperationResponse = 10493;
		 public const ushort C2M_StallSellRequest = 10494;
		 public const ushort M2C_StallSellResponse = 10495;
		 public const ushort C2M_StallXiaJiaRequest = 10496;
		 public const ushort M2C_StallXiaJiaResponse = 10497;
		 public const ushort C2P_PaiMaiAuctionInfoRequest = 10498;
		 public const ushort P2C_PaiMaiAuctionInfoResponse = 10499;
		 public const ushort C2P_PaiMaiAuctionRecordRequest = 10500;
		 public const ushort P2C_PaiMaiAuctionRecordResponse = 10501;
		 public const ushort C2P_PaiMaiFindRequest = 10502;
		 public const ushort P2C_PaiMaiFindResponse = 10503;
		 public const ushort C2P_PaiMaiListRequest = 10504;
		 public const ushort P2C_PaiMaiListResponse = 10505;
		 public const ushort C2P_PaiMaiSearchRequest = 10506;
		 public const ushort P2C_PaiMaiSearchResponse = 10507;
		 public const ushort C2P_PaiMaiShopShowListRequest = 10508;
		 public const ushort P2C_PaiMaiShopShowListResponse = 10509;
		 public const ushort C2P_StallListRequest = 10510;
		 public const ushort P2C_StallListResponse = 10511;
		 public const ushort C2M_BuChangeRequest = 10512;
		 public const ushort M2C_BuChangeResponse = 10513;
		 public const ushort C2M_CreateSpiling = 10514;
		 public const ushort C2M_DungeonHappyMoveRequest = 10515;
		 public const ushort M2C_DungeonHappyMoveResponse = 10516;
		 public const ushort C2M_FindJingLingRequest = 10517;
		 public const ushort M2C_FindJingLingResponse = 10518;
		 public const ushort C2M_FindNearMonsterRequest = 10519;
		 public const ushort M2C_FindNearMonsterResponse = 10520;
		 public const ushort C2M_FirstWinSelfRewardRequest = 10521;
		 public const ushort M2C_FirstWinSelfRewardResponse = 10522;
		 public const ushort C2M_FubenMessageRequest = 10523;
		 public const ushort M2C_FubenMessageResponse = 10524;
		 public const ushort C2M_FubenTimesResetRequest = 10525;
		 public const ushort M2C_FubenTimesResetResponse = 10526;
		 public const ushort C2M_GameSettingRequest = 10527;
		 public const ushort M2C_GameSettingResponse = 10528;
		 public const ushort C2M_GMCustomRequest = 10529;
		 public const ushort M2C_GMCustomResponse = 10530;
		 public const ushort C2M_GuideUpdateRequest = 10531;
		 public const ushort M2C_GuideUpdateResponse = 10532;
		 public const ushort C2M_KillMonsterRewardRequest = 10533;
		 public const ushort M2C_KillMonsterRewardResponse = 10534;
		 public const ushort C2M_LeavlRewardRequest = 10535;
		 public const ushort M2C_LeavlRewardResponse = 10536;
		 public const ushort C2M_ModifyNameRequest = 10537;
		 public const ushort M2C_ModifyNameResponse = 10538;
		 public const ushort C2M_MysteryBuyRequest = 10539;
		 public const ushort M2C_MysteryBuyResponse = 10540;
		 public const ushort C2M_OneChallengeRequest = 10541;
		 public const ushort M2C_OneChallengeResponse = 10542;
		 public const ushort M2C_OneChallenge = 10543;
		 public const ushort C2M_ReddotReadRequest = 10544;
		 public const ushort M2C_ReddotReadResponse = 10545;
		 public const ushort C2M_RefreshUnitRequest = 10546;
		 public const ushort C2M_SerialReardRequest = 10547;
		 public const ushort M2C_SerialReardResponse = 10548;
		 public const ushort C2M_ShareSucessRequest = 10549;
		 public const ushort M2C_ShareSucessResponse = 10550;
		 public const ushort C2M_UnitInfoRequest = 10551;
		 public const ushort M2C_UnitInfoResponse = 10552;
		 public const ushort C2M_XiuLianCenterRequest = 10553;
		 public const ushort M2C_XiuLianCenterResponse = 10554;
		 public const ushort C2Popularize_ListRequest = 10555;
		 public const ushort Popularize2C_ListResponse = 10556;
		 public const ushort C2Popularize_PlayerRequest = 10557;
		 public const ushort Popularize2C_PlayerResponse = 10558;
		 public const ushort C2R_CampRankListRequest = 10559;
		 public const ushort R2C_CampRankListResponse = 10560;
		 public const ushort C2R_DBServerInfoRequest = 10561;
		 public const ushort R2C_DBServerInfoResponse = 10562;
		 public const ushort C2R_RankDemonRequest = 10563;
		 public const ushort R2C_RankDemonResponse = 10564;
		 public const ushort C2R_RankListRequest = 10565;
		 public const ushort R2C_RankListResponse = 10566;
		 public const ushort C2R_RankPetListRequest = 10567;
		 public const ushort R2C_RankPetListResponse = 10568;
		 public const ushort C2R_RankRunRaceRequest = 10569;
		 public const ushort R2C_RankRunRaceResponse = 10570;
		 public const ushort C2R_RankSeasonTowerRequest = 10571;
		 public const ushort R2C_RankSeasonTowerResponse = 10572;
		 public const ushort C2R_RankShowLieRequest = 10573;
		 public const ushort R2C_RankShowLieResponse = 10574;
		 public const ushort C2R_RankTrialListRequest = 10575;
		 public const ushort R2C_RankTrialListResponse = 10576;
		 public const ushort C2R_RankUnionRaceRequest = 10577;
		 public const ushort R2C_RankUnionRaceResponse = 10578;
		 public const ushort C2R_WorldLvRequest = 10579;
		 public const ushort R2C_WorldLvResponse = 10580;
		 public const ushort C2M_SoloMatchRequest = 10581;
		 public const ushort M2C_SoloMatchResponse = 10582;
		 public const ushort C2S_SoloMyInfoRequest = 10583;
		 public const ushort S2C_SoloMyInfoResponse = 10584;
		 public const ushort C2M_TeamDungeonBoxRewardRequest = 10585;
		 public const ushort M2C_TeamDungeonBoxRewardResponse = 10586;
		 public const ushort C2M_TeamDungeonCreateRequest = 10587;
		 public const ushort M2C_TeamDungeonCreateResponse = 10588;
		 public const ushort C2M_TeamDungeonOpenRequest = 10589;
		 public const ushort M2C_TeamDungeonOpenResponse = 10590;
		 public const ushort C2M_TeamDungeonPrepareRequest = 10591;
		 public const ushort M2C_TeamDungeonPrepareResponse = 10592;
		 public const ushort C2M_TeamerPositionRequest = 10593;
		 public const ushort M2C_TeamerPositionResponse = 10594;
		 public const ushort C2M_TeamPickRequest = 10595;
		 public const ushort M2C_TeamDungeonBoxRewardResult = 10596;
		 public const ushort C2T_TeamAgreeRequest = 10597;
		 public const ushort T2C_TeamAgreeResponse = 10598;
		 public const ushort C2T_TeamDungeonAgreeRequest = 10599;
		 public const ushort T2C_TeamDungeonAgreeResponse = 10600;
		 public const ushort C2T_TeamDungeonApplyRequest = 10601;
		 public const ushort T2C_TeamDungeonApplyResponse = 10602;
		 public const ushort M2C_TeamDungeonApplyResult = 10603;
		 public const ushort C2T_TeamDungeonInfoRequest = 10604;
		 public const ushort T2C_TeamDungeonInfoResponse = 10605;
		 public const ushort C2T_TeamInviteRequest = 10606;
		 public const ushort T2C_TeamInviteResponse = 10607;
		 public const ushort M2C_TeamInviteResult = 10608;
		 public const ushort C2T_TeamKickOutRequest = 10609;
		 public const ushort T2C_TeamKickOutResponse = 10610;
		 public const ushort C2T_TeamLeaveRequest = 10611;
		 public const ushort T2C_TeamLeaveResponse = 10612;
		 public const ushort C2T_TeamRobotRequest = 10613;
		 public const ushort T2C_TeamRobotResponse = 10614;
		 public const ushort M2C_TeamDungeonOpenResult = 10615;
		 public const ushort M2C_TeamDungeonPrepareResult = 10616;
		 public const ushort C2M_ActivityChouKaRequest = 10617;
		 public const ushort M2C_ActivityChouKaResponse = 10618;
		 public const ushort C2M_ActivityFeedRequest = 10619;
		 public const ushort M2C_ActivityFeedResponse = 10620;
		 public const ushort C2M_ActivityGuessRequest = 10621;
		 public const ushort M2C_ActivityGuessResponse = 10622;
		 public const ushort C2M_ActivityInfoRequest = 10623;
		 public const ushort M2C_ActivityInfoResponse = 10624;
		 public const ushort C2M_ActivityReceiveRequest = 10625;
		 public const ushort M2C_ActivityReceiveResponse = 10626;
		 public const ushort C2M_ActivityRechargeSignRequest = 10627;
		 public const ushort M2C_ActivityRechargeSignResponse = 10628;
		 public const ushort C2M_ActivityRewardRequest = 10629;
		 public const ushort M2C_ActivityRewardResponse = 10630;
		 public const ushort C2M_ChouKa2RefreshRequest = 10631;
		 public const ushort M2C_ChouKa2RefreshResponse = 10632;
		 public const ushort C2M_SingleRechargeRewardRequest = 10633;
		 public const ushort M2C_SingleRechargeRewardResponse = 10634;
		 public const ushort C2M_ZhanQuInfoRequest = 10635;
		 public const ushort M2C_ZhanQuInfoResponse = 10636;
		 public const ushort C2M_ZhanQuReceiveRequest = 10637;
		 public const ushort M2C_ZhanQuReceiveResponse = 10638;
		 public const ushort C2M_JingHeActivateRequest = 10639;
		 public const ushort M2C_JingHeActivateResponse = 10640;
		 public const ushort C2M_JingHePlanRequest = 10641;
		 public const ushort M2C_JingHePlanResponse = 10642;
		 public const ushort C2M_JingHeWearRequest = 10643;
		 public const ushort M2C_JingHeWearResponse = 10644;
		 public const ushort C2M_JingHeZhuruRequest = 10645;
		 public const ushort M2C_JingHeZhuruResponse = 10646;
		 public const ushort C2M_MakeLearnRequest = 10647;
		 public const ushort M2C_MakeLearnResponse = 10648;
		 public const ushort C2E_AccountWarehousInfoRequest = 10649;
		 public const ushort E2C_AccountWarehousInfoResponse = 10650;
		 public const ushort C2M_BattleSummonRecord = 10651;
		 public const ushort M2C_BattleSummonRecord = 10652;
		 public const ushort C2M_BattleSummonRequest = 10653;
		 public const ushort M2C_BattleSummonResponse = 10654;
		 public const ushort C2M_CampRankSelectRequest = 10655;
		 public const ushort M2C_CampRankSelectResponse = 10656;
		 public const ushort Actor_FubenEnergySkillRequest = 10657;
		 public const ushort Actor_FubenEnergySkillResponse = 10658;
		 public const ushort FubenInfo = 10659;
		 public const ushort SonFubenInfo = 10660;
		 public const ushort Actor_EnterFubenRequest = 10661;
		 public const ushort Actor_EnterFubenResponse = 10662;
		 public const ushort Actor_EnterSonFubenRequest = 10663;
		 public const ushort Actor_EnterSonFubenResponse = 10664;
		 public const ushort Actor_GetFubenInfoRequest = 10665;
		 public const ushort Actor_GetFubenInfoResponse = 10666;
		 public const ushort Actor_GetFubenRewardRequest = 10667;
		 public const ushort Actor_GetFubenRewardReponse = 10668;
		 public const ushort Actor_FubenMoNengRequest = 10669;
		 public const ushort Actor_FubenMoNengResponse = 10670;
		 public const ushort Actor_SendReviveRequest = 10671;
		 public const ushort Actor_SendReviveResponse = 10672;
		 public const ushort C2M_ChouKaRequest = 10673;
		 public const ushort M2C_ChouKaResponse = 10674;
		 public const ushort C2M_ChouKaRewardRequest = 10675;
		 public const ushort M2C_ChouKaRewardResponse = 10676;
		 public const ushort C2M_EnergyAnswerRequest = 10677;
		 public const ushort M2C_EnergyAnswerResponse = 10678;
		 public const ushort C2M_EnergyInfoRequest = 10679;
		 public const ushort M2C_EnergyInfoResponse = 10680;
		 public const ushort C2M_EnergyReceiveRequest = 10681;
		 public const ushort M2C_EnergyReceiveResponse = 10682;
		 public const ushort C2M_HorseRideRequest = 10683;
		 public const ushort M2C_HorseRideResponse = 10684;
		 public const ushort C2M_HorseFightRequest = 10685;
		 public const ushort M2C_HorseFightResponse = 10686;
		 public const ushort C2M_JiaYuanPickRequest = 10687;
		 public const ushort M2C_JiaYuanPickResponse = 10688;
		 public const ushort C2M_JiaYuanCangKuOpenRequest = 10689;
		 public const ushort M2C_JiaYuanCangKuOpenResponse = 10690;
		 public const ushort C2M_JiaYuanCookBookOpen = 10691;
		 public const ushort M2C_JiaYuanCookBookOpen = 10692;
		 public const ushort C2M_JiaYuanCookRequest = 10693;
		 public const ushort M2C_JiaYuanCookResponse = 10694;
		 public const ushort C2M_JiaYuanDaShiRequest = 10695;
		 public const ushort M2C_JiaYuanDaShiResponse = 10696;
		 public const ushort C2M_JiaYuanExchangeRequest = 10697;
		 public const ushort M2C_JiaYuanExchangeResponse = 10698;
		 public const ushort C2M_JiaYuanGatherRequest = 10699;
		 public const ushort M2C_JiaYuanGatherResponse = 10700;
		 public const ushort C2M_JiaYuanGatherOtherRequest = 10701;
		 public const ushort M2C_JiaYuanGatherOtherResponse = 10702;
		 public const ushort C2M_JiaYuanInitRequest = 10703;
		 public const ushort M2C_JiaYuanInitResponse = 10704;
		 public const ushort C2M_JiaYuanMysteryBuyRequest = 10705;
		 public const ushort M2C_JiaYuanMysteryBuyResponse = 10706;
		 public const ushort C2M_JiaYuanMysteryListRequest = 10707;
		 public const ushort M2C_JiaYuanMysteryListResponse = 10708;
		 public const ushort C2M_JiaYuanPastureBuyRequest = 10709;
		 public const ushort M2C_JiaYuanPastureBuyResponse = 10710;
		 public const ushort C2M_JiaYuanPastureListRequest = 10711;
		 public const ushort M2C_JiaYuanPastureListResponse = 10712;
		 public const ushort C2M_JiaYuanPetFeedRequest = 10713;
		 public const ushort M2C_JiaYuanPetFeedResponse = 10714;
		 public const ushort C2M_JiaYuanPetOperateRequest = 10715;
		 public const ushort M2C_JiaYuanPetOperateResponse = 10716;
		 public const ushort C2M_JiaYuanPetPositionRequest = 10717;
		 public const ushort M2C_JiaYuanPetPositionResponse = 10718;
		 public const ushort C2M_JiaYuanPetWalkRequest = 10719;
		 public const ushort M2C_JiaYuanPetWalkResponse = 10720;
		 public const ushort C2M_JiaYuanPlanOpenRequest = 10721;
		 public const ushort M2C_JiaYuanPlanOpenResponse = 10722;
		 public const ushort C2M_JiaYuanPlantRequest = 10723;
		 public const ushort M2C_JiaYuanPlantResponse = 10724;
		 public const ushort C2M_JiaYuanPurchaseRequest = 10725;
		 public const ushort M2C_JiaYuanPurchaseResponse = 10726;
		 public const ushort C2M_JiaYuanPurchaseRefresh = 10727;
		 public const ushort M2C_JiaYuanPurchaseRefresh = 10728;
		 public const ushort C2M_JiaYuanRecordListRequest = 10729;
		 public const ushort M2C_JiaYuanRecordListResponse = 10730;
		 public const ushort C2M_JiaYuanStoreRequest = 10731;
		 public const ushort M2C_JiaYuanStoreResponse = 10732;
		 public const ushort C2M_JiaYuanUpLvRequest = 10733;
		 public const ushort M2C_JiaYuanUpLvResponse = 10734;
		 public const ushort C2M_JiaYuanUprootRequest = 10735;
		 public const ushort M2C_JiaYuanUprootResponse = 10736;
		 public const ushort C2M_JiaYuanVisitListRequest = 10737;
		 public const ushort JiaYuanVisit = 10738;
		 public const ushort M2C_JiaYuanVisitListResponse = 10739;
		 public const ushort C2M_JiaYuanWatchRequest = 10740;
		 public const ushort M2C_JiaYuanWatchResponse = 10741;
		 public const ushort C2M_TakeOutAllRequest = 10742;
		 public const ushort M2C_TakeOutAllResponse = 10743;
		 public const ushort C2M_LingDiRewardRequest = 10744;
		 public const ushort M2C_LingDiRewardResponse = 10745;
		 public const ushort C2M_LingDiUpRequest = 10746;
		 public const ushort M2C_LingDiUpResponse = 10747;
		 public const ushort C2M_RandomTowerBeginRequest = 10748;
		 public const ushort M2C_RandomTowerBeginResponse = 10749;
		 public const ushort C2M_RandomTowerRewardRequest = 10750;
		 public const ushort M2C_RandomTowerRewardResponse = 10751;
		 public const ushort C2M_IOSPayVerifyRequest = 10752;
		 public const ushort M2C_IOSPayVerifyResponse = 10753;
		 public const ushort C2M_RechargeRequest = 10754;
		 public const ushort M2C_RechargeResponse = 10755;
		 public const ushort C2M_RechargeRewardRequest = 10756;
		 public const ushort M2C_RechargeRewardResponse = 10757;
		 public const ushort C2M_ExpToGoldRequest = 10758;
		 public const ushort M2C_ExpToGoldResponse = 10759;
		 public const ushort C2M_RealNameRewardRequest = 10760;
		 public const ushort M2C_RealNameRewardResponse = 10761;
		 public const ushort C2M_RolePetChouKaRequest = 10762;
		 public const ushort M2C_RolePetChouKaResponse = 10763;
		 public const ushort C2M_SeasonLevelRewardRequest = 10764;
		 public const ushort M2C_SeasonLevelRewardResponse = 10765;
		 public const ushort C2M_SeasonOpenJingHeRequest = 10766;
		 public const ushort M2C_SeasonOpenJingHeResponse = 10767;
		 public const ushort C2M_SeasonUseFruitRequest = 10768;
		 public const ushort M2C_SeasonUseFruitResponse = 10769;
		 public const ushort C2M_ShoujiRewardRequest = 10770;
		 public const ushort M2C_ShoujiRewardResponse = 10771;
		 public const ushort C2M_ShouJiTreasureRequest = 10772;
		 public const ushort M2C_ShouJiTreasureResponse = 10773;
		 public const ushort C2M_TitleUseRequest = 10774;
		 public const ushort M2C_TitleUseResponse = 10775;
		 public const ushort M2C_TitleUpdateResult = 10776;
		 public const ushort C2M_TowerFightBeginRequest = 10777;
		 public const ushort M2C_TowerFightBeginResponse = 10778;
		 public const ushort C2M_TowerExitRequest = 10779;
		 public const ushort M2C_TowerExitResponse = 10780;
		 public const ushort C2M_TowerOfSealNextRequest = 10781;
		 public const ushort M2C_TowerOfSealNextResponse = 10782;
		 public const ushort C2M_TrialDungeonBeginRequest = 10783;
		 public const ushort M2C_TrialDungeonBeginResponse = 10784;
		 public const ushort C2M_TrialDungeonFinishRequest = 10785;
		 public const ushort M2C_TrialDungeonFinishResponse = 10786;
		 public const ushort C2M_TurtleRecordRequest = 10787;
		 public const ushort M2C_TurtleRecordResponse = 10788;
		 public const ushort C2M_TurtleSupportRequest = 10789;
		 public const ushort M2C_TurtleSupportResponse = 10790;
		 public const ushort C2M_WelfareDraw2Request = 10791;
		 public const ushort M2C_WelfareDraw2Response = 10792;
		 public const ushort C2M_WelfareDraw2RewardRequest = 10793;
		 public const ushort M2C_WelfareDraw2RewardResponse = 10794;
		 public const ushort C2M_WelfareDrawRequest = 10795;
		 public const ushort M2C_WelfareDrawResponse = 10796;
		 public const ushort C2M_WelfareDrawRewardRequest = 10797;
		 public const ushort M2C_WelfareDrawRewardResponse = 10798;
		 public const ushort C2M_WelfareInvestRequest = 10799;
		 public const ushort M2C_WelfareInvestResponse = 10800;
		 public const ushort C2M_WelfareInvestRewardRequest = 10801;
		 public const ushort M2C_WelfareInvestRewardResponse = 10802;
		 public const ushort C2M_WelfareTaskRewardRequest = 10803;
		 public const ushort M2C_WelfareTaskRewardResponse = 10804;
		 public const ushort C2M_YueKaOpenRequest = 10805;
		 public const ushort M2C_YueKaOpenResponse = 10806;
		 public const ushort C2M_YueKaRewardRequest = 10807;
		 public const ushort M2C_YueKaRewardResponse = 10808;
		 public const ushort C2Popularize_UploadRequest = 10809;
		 public const ushort Popularize2C_UploadResponse = 10810;
		 public const ushort C2Popularize_RewardRequest = 10811;
		 public const ushort Popularize2C_RewardResponse = 10812;
	}
}
