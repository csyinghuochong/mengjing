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

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			
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
		public string SceneName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneInstanceId = default;
			this.SceneName = default;
			
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

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterMessage.C2R_Login)]
	[MemoryPackable]
	public partial class C2R_Login: MessageObject, ISessionRequest
	{
		public static C2R_Login Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_Login), isFromPool) as C2R_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		[MemoryPackOrder(2)]
		public string Token { get; set; }

		[MemoryPackOrder(2)]
		public string ThirdLogin { get; set; }

		[MemoryPackOrder(4)]
		public bool Relink { get; set; }

		[MemoryPackOrder(5)]
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

	[Message(OuterMessage.R2C_Login)]
	[MemoryPackable]
	public partial class R2C_Login: MessageObject, ISessionResponse
	{
		public static R2C_Login Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_Login), isFromPool) as R2C_Login; 
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

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterMessage.C2G_LoginGate)]
	[MemoryPackable]
	public partial class C2G_LoginGate: MessageObject, ISessionRequest
	{
		public static C2G_LoginGate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_LoginGate), isFromPool) as C2G_LoginGate; 
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

	[Message(OuterMessage.G2C_LoginGate)]
	[MemoryPackable]
	public partial class G2C_LoginGate: MessageObject, ISessionResponse
	{
		public static G2C_LoginGate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_LoginGate), isFromPool) as G2C_LoginGate; 
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

	[ResponseType(nameof(A2C_CreateRoleData))]
	[Message(OuterMessage.C2A_CreateRoleData)]
	[MemoryPackable]
	public partial class C2A_CreateRoleData: MessageObject, ISessionRequest
	{
		public static C2A_CreateRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2A_CreateRoleData), isFromPool) as C2A_CreateRoleData; 
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

	[Message(OuterMessage.A2C_CreateRoleData)]
	[MemoryPackable]
	public partial class A2C_CreateRoleData: MessageObject, ISessionResponse
	{
		public static A2C_CreateRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_CreateRoleData), isFromPool) as A2C_CreateRoleData; 
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

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
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

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Status = default;
			this.Context = default;
			this.MailId = default;
			this.Title = default;
			this.ItemList.Clear();
			this.ItemSell = default;
			
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

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.UserId = default;
			this.BagInfo = default;
			this.Price = default;
			this.PlayerName = default;
			this.SellTime = default;
			
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

	[ResponseType(nameof(A2C_DeleteRoleData))]
	[Message(OuterMessage.C2A_DeleteRoleData)]
	[MemoryPackable]
	public partial class C2A_DeleteRoleData: MessageObject, ISessionRequest
	{
		public static C2A_DeleteRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2A_DeleteRoleData), isFromPool) as C2A_DeleteRoleData; 
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

	[Message(OuterMessage.A2C_DeleteRoleData)]
	[MemoryPackable]
	public partial class A2C_DeleteRoleData: MessageObject, ISessionResponse
	{
		public static A2C_DeleteRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2C_DeleteRoleData), isFromPool) as A2C_DeleteRoleData; 
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
	public partial class M2C_UnitNumericListUpdate: MessageObject, ILocationMessage
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

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Message = default;
			this.Error = default;
			this.UserInfo = default;
			
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

	public static class OuterMessage
	{
		 public const ushort HttpGetRouterResponse = 10002;
		 public const ushort RouterSync = 10003;
		 public const ushort C2M_TestRequest = 10004;
		 public const ushort M2C_TestResponse = 10005;
		 public const ushort C2G_EnterMap = 10006;
		 public const ushort G2C_EnterMap = 10007;
		 public const ushort MoveInfo = 10008;
		 public const ushort UnitInfo = 10009;
		 public const ushort M2C_CreateUnits = 10010;
		 public const ushort M2C_CreateMyUnit = 10011;
		 public const ushort M2C_StartSceneChange = 10012;
		 public const ushort M2C_RemoveUnits = 10013;
		 public const ushort C2M_PathfindingResult = 10014;
		 public const ushort C2M_Stop = 10015;
		 public const ushort M2C_PathfindingResult = 10016;
		 public const ushort M2C_Stop = 10017;
		 public const ushort C2G_Ping = 10018;
		 public const ushort G2C_Ping = 10019;
		 public const ushort G2C_Test = 10020;
		 public const ushort C2M_Reload = 10021;
		 public const ushort M2C_Reload = 10022;
		 public const ushort C2R_Login = 10023;
		 public const ushort RechargeInfo = 10024;
		 public const ushort KeyValuePair = 10025;
		 public const ushort KeyValuePairInt = 10026;
		 public const ushort KeyValuePairLong = 10027;
		 public const ushort PlayerInfo = 10028;
		 public const ushort CreateRoleInfo = 10029;
		 public const ushort R2C_Login = 10030;
		 public const ushort C2G_LoginGate = 10031;
		 public const ushort G2C_LoginGate = 10032;
		 public const ushort ServerItem = 10033;
		 public const ushort C2A_CreateRoleData = 10034;
		 public const ushort A2C_CreateRoleData = 10035;
		 public const ushort G2C_TestHotfixMessage = 10036;
		 public const ushort C2M_TestRobotCase = 10037;
		 public const ushort M2C_TestRobotCase = 10038;
		 public const ushort C2M_TestRobotCase2 = 10039;
		 public const ushort M2C_TestRobotCase2 = 10040;
		 public const ushort C2M_TransferMap = 10041;
		 public const ushort M2C_TransferMap = 10042;
		 public const ushort C2G_Benchmark = 10043;
		 public const ushort G2C_Benchmark = 10044;
		 public const ushort HideProList = 10045;
		 public const ushort BagInfo = 10046;
		 public const ushort MysteryItemInfo = 10047;
		 public const ushort ZhanQuReceiveNumber = 10048;
		 public const ushort FirstWinInfo = 10049;
		 public const ushort PetMingPlayerInfo = 10050;
		 public const ushort ChatInfo = 10051;
		 public const ushort MailInfo = 10052;
		 public const ushort PaiMaiItemInfo = 10053;
		 public const ushort PaiMaiShopItemInfo = 10054;
		 public const ushort PopularizeInfo = 10055;
		 public const ushort RankingInfo = 10056;
		 public const ushort RankShouLieInfo = 10057;
		 public const ushort RankPetInfo = 10058;
		 public const ushort ServerInfo = 10059;
		 public const ushort ServerMailItem = 10060;
		 public const ushort UnionInfo = 10061;
		 public const ushort UnionPlayerInfo = 10062;
		 public const ushort DonationRecord = 10063;
		 public const ushort A2C_Disconnect = 10064;
		 public const ushort UserInfo = 10065;
		 public const ushort M2C_RoleDataUpdate = 10066;
		 public const ushort M2C_RoleDataBroadcast = 10067;
		 public const ushort SkillPro = 10068;
		 public const ushort RewardItem = 10069;
		 public const ushort FubenPassInfo = 10070;
		 public const ushort C2A_DeleteRoleData = 10071;
		 public const ushort A2C_DeleteRoleData = 10072;
		 public const ushort C2M_GMCommand = 10073;
		 public const ushort C2A_ActivityInfoRequest = 10074;
		 public const ushort A2C_ActivityInfoResponse = 10075;
		 public const ushort C2A_FirstWinInfoRequest = 10076;
		 public const ushort A2C_FirstWinInfoResponse = 10077;
		 public const ushort C2A_MysteryListRequest = 10078;
		 public const ushort A2C_MysteryListResponse = 10079;
		 public const ushort C2A_PetMingChanChuRequest = 10080;
		 public const ushort A2C_PetMingChanChuResponse = 10081;
		 public const ushort C2A_PetMingListRequest = 10082;
		 public const ushort A2C_PetMingListResponse = 10083;
		 public const ushort RolePetInfo = 10084;
		 public const ushort PetFubenInfo = 10085;
		 public const ushort PetMingRecord = 10086;
		 public const ushort M2C_RolePetBagUpdate = 10087;
		 public const ushort M2C_PetListMessage = 10088;
		 public const ushort M2C_RolePetUpdate = 10089;
		 public const ushort M2C_PetDataUpdate = 10090;
		 public const ushort M2C_PetDataBroadcast = 10091;
		 public const ushort M2C_RoleBagUpdate = 10092;
		 public const ushort C2M_BagInitRequest = 10093;
		 public const ushort M2C_BagInitResponse = 10094;
		 public const ushort C2M_OpenBoxRequest = 10095;
		 public const ushort M2C_OpenBoxResponse = 10096;
		 public const ushort DropInfo = 10097;
		 public const ushort C2M_PickItemRequest = 10098;
		 public const ushort M2C_PickItemResponse = 10099;
		 public const ushort C2M_EquipmentIncreaseRequest = 10100;
		 public const ushort M2C_EquipmentIncreaseResponse = 10101;
		 public const ushort C2M_FashionActiveRequest = 10102;
		 public const ushort M2C_FashionActiveResponse = 10103;
		 public const ushort C2M_FashionWearRequest = 10104;
		 public const ushort M2C_FashionWearResponse = 10105;
		 public const ushort C2M_GemHeChengQuickRequest = 10106;
		 public const ushort M2C_GemHeChengQuickResponse = 10107;
		 public const ushort C2M_ItemBuyCellRequest = 10108;
		 public const ushort M2C_ItemBuyCellResponse = 10109;
		 public const ushort C2M_ItemDestoryRequest = 10110;
		 public const ushort M2C_ItemDestoryResponse = 10111;
		 public const ushort C2M_ItemEquipIndexRequest = 10112;
		 public const ushort M2C_ItemEquipIndexResponse = 10113;
		 public const ushort C2M_ItemFumoProRequest = 10114;
		 public const ushort M2C_ItemFumoProResponse = 10115;
		 public const ushort C2M_ItemFumoUseRequest = 10116;
		 public const ushort M2C_ItemFumoUseResponse = 10117;
		 public const ushort C2M_ItemHuiShouRequest = 10118;
		 public const ushort M2C_ItemHuiShouResponse = 10119;
		 public const ushort C2M_ItemIncreaseTransferRequest = 10120;
		 public const ushort M2C_ItemIncreaseTransferResponse = 10121;
		 public const ushort C2M_ItemInheritRequest = 10122;
		 public const ushort M2C_ItemInheritResponse = 10123;
		 public const ushort C2M_ItemInheritSelectRequest = 10124;
		 public const ushort M2C_ItemInheritSelectResponse = 10125;
		 public const ushort C2M_ItemMeltingRequest = 10126;
		 public const ushort M2C_ItemMeltingResponse = 10127;
		 public const ushort C2M_ItemOneSellRequest = 10128;
		 public const ushort M2C_ItemOneSellResponse = 10129;
		 public const ushort C2M_ItemOperateGemRequest = 10130;
		 public const ushort M2C_ItemOperateGemResponse = 10131;
		 public const ushort C2M_ItemOperateRequest = 10132;
		 public const ushort M2C_ItemOperateResponse = 10133;
		 public const ushort C2M_ItemOperateWearRequest = 10134;
		 public const ushort M2C_ItemOperateWearResponse = 10135;
		 public const ushort C2M_ItemProtectRequest = 10136;
		 public const ushort M2C_ItemProtectResponse = 10137;
		 public const ushort C2M_ItemQiangHuaRequest = 10138;
		 public const ushort M2C_ItemQiangHuaResponse = 10139;
		 public const ushort C2M_ItemQuickPutRequest = 10140;
		 public const ushort M2C_ItemQuickPutResponse = 10141;
		 public const ushort C2M_ItemSortRequest = 10142;
		 public const ushort C2M_ItemSplitRequest = 10143;
		 public const ushort M2C_ItemSplitResponse = 10144;
		 public const ushort C2M_ItemTreasureOpenRequest = 10145;
		 public const ushort M2C_ItemTreasureOpenResponse = 10146;
		 public const ushort SkillInfo = 10147;
		 public const ushort M2C_UnitNumericListUpdate = 10148;
		 public const ushort C2M_UserInfoInitRequest = 10149;
		 public const ushort M2C_UserInfoInitResponse = 10150;
		 public const ushort FriendInfo = 10151;
		 public const ushort C2F_FriendApplyReplyRequest = 10152;
		 public const ushort F2C_FriendApplyReplyResponse = 10153;
		 public const ushort C2F_FriendBlacklistRequest = 10154;
		 public const ushort F2C_FriendBlacklistResponse = 10155;
		 public const ushort C2F_FriendApplyRequest = 10156;
		 public const ushort F2C_FriendApplyResponse = 10157;
		 public const ushort C2F_FriendChatRead = 10158;
		 public const ushort F2C_FriendChatRead = 10159;
		 public const ushort C2F_FriendDeleteRequest = 10160;
		 public const ushort F2C_FriendDeleteResponse = 10161;
		 public const ushort C2F_FriendInfoRequest = 10162;
		 public const ushort F2C_FriendInfoResponse = 10163;
		 public const ushort ItemXiLianResult = 10164;
		 public const ushort M2C_FashionUpdate = 10165;
		 public const ushort C2M_SkillCmd = 10166;
		 public const ushort M2C_SkillCmd = 10167;
		 public const ushort M2C_UnitUseSkill = 10168;
		 public const ushort LifeShieldInfo = 10169;
		 public const ushort SkillSetInfo = 10170;
		 public const ushort M2C_SkillSetMessage = 10171;
		 public const ushort C2Chat_GetChatRequest = 10172;
		 public const ushort Chat2C_GetChatResponse = 10173;
		 public const ushort C2C_SendChatRequest = 10174;
		 public const ushort C2C_SendChatResponse = 10175;
		 public const ushort C2C_SyncChatInfo = 10176;
		 public const ushort ChengJiuInfo = 10177;
		 public const ushort M2C_ChengJiuActiveMessage = 10178;
	}
}
