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

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			
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
		public long UpdateValueLong { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
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
		 public const ushort C2M_BagInitRequest = 10047;
		 public const ushort M2C_BagInitResponse = 10048;
		 public const ushort MysteryItemInfo = 10049;
		 public const ushort ZhanQuReceiveNumber = 10050;
		 public const ushort FirstWinInfo = 10051;
		 public const ushort PetMingPlayerInfo = 10052;
		 public const ushort ChatInfo = 10053;
		 public const ushort MailInfo = 10054;
		 public const ushort PaiMaiItemInfo = 10055;
		 public const ushort PaiMaiShopItemInfo = 10056;
		 public const ushort PopularizeInfo = 10057;
		 public const ushort RankingInfo = 10058;
		 public const ushort RankShouLieInfo = 10059;
		 public const ushort RankPetInfo = 10060;
		 public const ushort ServerInfo = 10061;
		 public const ushort ServerMailItem = 10062;
		 public const ushort UnionInfo = 10063;
		 public const ushort UnionPlayerInfo = 10064;
		 public const ushort DonationRecord = 10065;
		 public const ushort A2C_Disconnect = 10066;
		 public const ushort UserInfo = 10067;
		 public const ushort M2C_RoleDataUpdate = 10068;
		 public const ushort M2C_RoleDataBroadcast = 10069;
		 public const ushort SkillPro = 10070;
		 public const ushort RewardItem = 10071;
		 public const ushort FubenPassInfo = 10072;
		 public const ushort C2A_DeleteRoleData = 10073;
		 public const ushort A2C_DeleteRoleData = 10074;
	}
}
