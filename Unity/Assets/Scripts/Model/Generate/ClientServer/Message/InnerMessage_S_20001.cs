using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
// using
	[ResponseType(nameof(ObjectQueryResponse))]
	[Message(InnerMessage.ObjectQueryRequest)]
	[MemoryPackable]
	public partial class ObjectQueryRequest: MessageObject, IRequest
	{
		public static ObjectQueryRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectQueryRequest), isFromPool) as ObjectQueryRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		[MemoryPackOrder(2)]
		public long InstanceId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.InstanceId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2M_Reload))]
	[Message(InnerMessage.M2A_Reload)]
	[MemoryPackable]
	public partial class M2A_Reload: MessageObject, IRequest
	{
		public static M2A_Reload Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_Reload), isFromPool) as M2A_Reload; 
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

	[Message(InnerMessage.A2M_Reload)]
	[MemoryPackable]
	public partial class A2M_Reload: MessageObject, IResponse
	{
		public static A2M_Reload Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_Reload), isFromPool) as A2M_Reload; 
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

	[ResponseType(nameof(G2G_LockResponse))]
	[Message(InnerMessage.G2G_LockRequest)]
	[MemoryPackable]
	public partial class G2G_LockRequest: MessageObject, IRequest
	{
		public static G2G_LockRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2G_LockRequest), isFromPool) as G2G_LockRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Id { get; set; }

		[MemoryPackOrder(2)]
		public string Address { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Id = default;
			this.Address = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.G2G_LockResponse)]
	[MemoryPackable]
	public partial class G2G_LockResponse: MessageObject, IResponse
	{
		public static G2G_LockResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2G_LockResponse), isFromPool) as G2G_LockResponse; 
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

	[ResponseType(nameof(G2G_LockReleaseResponse))]
	[Message(InnerMessage.G2G_LockReleaseRequest)]
	[MemoryPackable]
	public partial class G2G_LockReleaseRequest: MessageObject, IRequest
	{
		public static G2G_LockReleaseRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2G_LockReleaseRequest), isFromPool) as G2G_LockReleaseRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Id { get; set; }

		[MemoryPackOrder(2)]
		public string Address { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Id = default;
			this.Address = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.G2G_LockReleaseResponse)]
	[MemoryPackable]
	public partial class G2G_LockReleaseResponse: MessageObject, IResponse
	{
		public static G2G_LockReleaseResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2G_LockReleaseResponse), isFromPool) as G2G_LockReleaseResponse; 
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

	[ResponseType(nameof(ObjectAddResponse))]
	[Message(InnerMessage.ObjectAddRequest)]
	[MemoryPackable]
	public partial class ObjectAddRequest: MessageObject, IRequest
	{
		public static ObjectAddRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectAddRequest), isFromPool) as ObjectAddRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Type { get; set; }

		[MemoryPackOrder(2)]
		public long Key { get; set; }

		[MemoryPackOrder(3)]
		public ActorId ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Type = default;
			this.Key = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.ObjectAddResponse)]
	[MemoryPackable]
	public partial class ObjectAddResponse: MessageObject, IResponse
	{
		public static ObjectAddResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectAddResponse), isFromPool) as ObjectAddResponse; 
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

	[ResponseType(nameof(ObjectLockResponse))]
	[Message(InnerMessage.ObjectLockRequest)]
	[MemoryPackable]
	public partial class ObjectLockRequest: MessageObject, IRequest
	{
		public static ObjectLockRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectLockRequest), isFromPool) as ObjectLockRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Type { get; set; }

		[MemoryPackOrder(2)]
		public long Key { get; set; }

		[MemoryPackOrder(3)]
		public ActorId ActorId { get; set; }

		[MemoryPackOrder(4)]
		public int Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Type = default;
			this.Key = default;
			this.ActorId = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.ObjectLockResponse)]
	[MemoryPackable]
	public partial class ObjectLockResponse: MessageObject, IResponse
	{
		public static ObjectLockResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectLockResponse), isFromPool) as ObjectLockResponse; 
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

	[ResponseType(nameof(ObjectUnLockResponse))]
	[Message(InnerMessage.ObjectUnLockRequest)]
	[MemoryPackable]
	public partial class ObjectUnLockRequest: MessageObject, IRequest
	{
		public static ObjectUnLockRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectUnLockRequest), isFromPool) as ObjectUnLockRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Type { get; set; }

		[MemoryPackOrder(2)]
		public long Key { get; set; }

		[MemoryPackOrder(3)]
		public ActorId OldActorId { get; set; }

		[MemoryPackOrder(4)]
		public ActorId NewActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Type = default;
			this.Key = default;
			this.OldActorId = default;
			this.NewActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.ObjectUnLockResponse)]
	[MemoryPackable]
	public partial class ObjectUnLockResponse: MessageObject, IResponse
	{
		public static ObjectUnLockResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectUnLockResponse), isFromPool) as ObjectUnLockResponse; 
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

	[ResponseType(nameof(ObjectRemoveResponse))]
	[Message(InnerMessage.ObjectRemoveRequest)]
	[MemoryPackable]
	public partial class ObjectRemoveRequest: MessageObject, IRequest
	{
		public static ObjectRemoveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectRemoveRequest), isFromPool) as ObjectRemoveRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Type { get; set; }

		[MemoryPackOrder(2)]
		public long Key { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Type = default;
			this.Key = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.ObjectRemoveResponse)]
	[MemoryPackable]
	public partial class ObjectRemoveResponse: MessageObject, IResponse
	{
		public static ObjectRemoveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectRemoveResponse), isFromPool) as ObjectRemoveResponse; 
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

	[ResponseType(nameof(ObjectGetResponse))]
	[Message(InnerMessage.ObjectGetRequest)]
	[MemoryPackable]
	public partial class ObjectGetRequest: MessageObject, IRequest
	{
		public static ObjectGetRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectGetRequest), isFromPool) as ObjectGetRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Type { get; set; }

		[MemoryPackOrder(2)]
		public long Key { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Type = default;
			this.Key = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.ObjectGetResponse)]
	[MemoryPackable]
	public partial class ObjectGetResponse: MessageObject, IResponse
	{
		public static ObjectGetResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectGetResponse), isFromPool) as ObjectGetResponse; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public int Type { get; set; }

		[MemoryPackOrder(4)]
		public ActorId ActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Type = default;
			this.ActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2R_GetLoginKey))]
	[Message(InnerMessage.R2G_GetLoginKey)]
	[MemoryPackable]
	public partial class R2G_GetLoginKey: MessageObject, IRequest
	{
		public static R2G_GetLoginKey Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2G_GetLoginKey), isFromPool) as R2G_GetLoginKey; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.G2R_GetLoginKey)]
	[MemoryPackable]
	public partial class G2R_GetLoginKey: MessageObject, IResponse
	{
		public static G2R_GetLoginKey Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2R_GetLoginKey), isFromPool) as G2R_GetLoginKey; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Key { get; set; }

		[MemoryPackOrder(4)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.G2M_SessionDisconnect)]
	[MemoryPackable]
	public partial class G2M_SessionDisconnect: MessageObject, ILocationMessage
	{
		public static G2M_SessionDisconnect Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2M_SessionDisconnect), isFromPool) as G2M_SessionDisconnect; 
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

	[Message(InnerMessage.ObjectQueryResponse)]
	[MemoryPackable]
	public partial class ObjectQueryResponse: MessageObject, IResponse
	{
		public static ObjectQueryResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ObjectQueryResponse), isFromPool) as ObjectQueryResponse; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public byte[] Entity { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Entity = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2M_UnitTransferResponse))]
	[Message(InnerMessage.M2M_UnitTransferRequest)]
	[MemoryPackable]
	public partial class M2M_UnitTransferRequest: MessageObject, IRequest
	{
		public static M2M_UnitTransferRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_UnitTransferRequest), isFromPool) as M2M_UnitTransferRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public ActorId OldActorId { get; set; }

		[MemoryPackOrder(2)]
		public byte[] Unit { get; set; }

		[MemoryPackOrder(3)]
		public List<byte[]> Entitys { get; set; } = new();

		[MemoryPackOrder(4)]
		public int SceneType { get; set; }

		[MemoryPackOrder(5)]
		public int SceneId { get; set; }

		[MemoryPackOrder(6)]
		public int Difficulty { get; set; }

		[MemoryPackOrder(7)]
		public string ParamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OldActorId = default;
			this.Unit = default;
			this.Entitys.Clear();
			this.SceneType = default;
			this.SceneId = default;
			this.Difficulty = default;
			this.ParamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2M_UnitTransferResponse)]
	[MemoryPackable]
	public partial class M2M_UnitTransferResponse: MessageObject, IResponse
	{
		public static M2M_UnitTransferResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_UnitTransferResponse), isFromPool) as M2M_UnitTransferResponse; 
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

//----------玩家缓存相关----------------
//增加或者更新Unit缓存
	[ResponseType(nameof(UnitCache2Other_AddOrUpdateUnit))]
	[Message(InnerMessage.Other2UnitCache_AddOrUpdateUnit)]
	[MemoryPackable]
	public partial class Other2UnitCache_AddOrUpdateUnit: MessageObject, IRequest
	{
		public static Other2UnitCache_AddOrUpdateUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_AddOrUpdateUnit), isFromPool) as Other2UnitCache_AddOrUpdateUnit; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public List<string> EntityTypes { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<byte[]> EntityBytes { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.EntityTypes.Clear();
			this.EntityBytes.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.UnitCache2Other_AddOrUpdateUnit)]
	[MemoryPackable]
	public partial class UnitCache2Other_AddOrUpdateUnit: MessageObject, IResponse
	{
		public static UnitCache2Other_AddOrUpdateUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_AddOrUpdateUnit), isFromPool) as UnitCache2Other_AddOrUpdateUnit; 
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

//获取Unit缓存
	[ResponseType(nameof(UnitCache2Other_GetUnit))]
	[Message(InnerMessage.Other2UnitCache_GetUnit)]
	[MemoryPackable]
	public partial class Other2UnitCache_GetUnit: MessageObject, IRequest
	{
		public static Other2UnitCache_GetUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_GetUnit), isFromPool) as Other2UnitCache_GetUnit; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public List<string> ComponentNameList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.ComponentNameList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.UnitCache2Other_GetUnit)]
	[MemoryPackable]
	public partial class UnitCache2Other_GetUnit: MessageObject, IResponse
	{
		public static UnitCache2Other_GetUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_GetUnit), isFromPool) as UnitCache2Other_GetUnit; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<Entity> EntityList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<string> ComponentNameList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.EntityList.Clear();
			this.ComponentNameList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//删除Unit缓存
	[ResponseType(nameof(UnitCache2Other_DeleteUnit))]
	[Message(InnerMessage.Other2UnitCache_DeleteUnit)]
	[MemoryPackable]
	public partial class Other2UnitCache_DeleteUnit: MessageObject, IRequest
	{
		public static Other2UnitCache_DeleteUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_DeleteUnit), isFromPool) as Other2UnitCache_DeleteUnit; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.UnitCache2Other_DeleteUnit)]
	[MemoryPackable]
	public partial class UnitCache2Other_DeleteUnit: MessageObject, IResponse
	{
		public static UnitCache2Other_DeleteUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_DeleteUnit), isFromPool) as UnitCache2Other_DeleteUnit; 
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

	[ResponseType(nameof(UnitCache2Other_GetComponent))]
	[Message(InnerMessage.Other2UnitCache_GetComponent)]
	[MemoryPackable]
	public partial class Other2UnitCache_GetComponent: MessageObject, IRequest
	{
		public static Other2UnitCache_GetComponent Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_GetComponent), isFromPool) as Other2UnitCache_GetComponent; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public string Component { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.Component = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.UnitCache2Other_GetComponent)]
	[MemoryPackable]
	public partial class UnitCache2Other_GetComponent: MessageObject, IResponse
	{
		public static UnitCache2Other_GetComponent Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_GetComponent), isFromPool) as UnitCache2Other_GetComponent; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public Entity Component { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Component = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//----------玩家缓存相关----------------
	[ResponseType(nameof(Center2A_CheckAccount))]
	[Message(InnerMessage.A2Center_CheckAccount)]
	[MemoryPackable]
	public partial class A2Center_CheckAccount: MessageObject, IRequest
	{
		public static A2Center_CheckAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2Center_CheckAccount), isFromPool) as A2Center_CheckAccount; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string AccountName { get; set; }

		[MemoryPackOrder(1)]
		public string Password { get; set; }

		[MemoryPackOrder(3)]
		public string ThirdLogin { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.AccountName = default;
			this.Password = default;
			this.ThirdLogin = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Center2A_CheckAccount)]
	[MemoryPackable]
	public partial class Center2A_CheckAccount: MessageObject, IResponse
	{
		public static Center2A_CheckAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2A_CheckAccount), isFromPool) as Center2A_CheckAccount; 
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
		public long AccountId { get; set; }

		[MemoryPackOrder(2)]
		public bool IsHoliday { get; set; }

		[MemoryPackOrder(3)]
		public bool StopServer { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerInfo = default;
			this.AccountId = default;
			this.IsHoliday = default;
			this.StopServer = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Center2A_RegisterAccount))]
	[Message(InnerMessage.A2Center_RegisterAccount)]
	[MemoryPackable]
	public partial class A2Center_RegisterAccount: MessageObject, IRequest
	{
		public static A2Center_RegisterAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2Center_RegisterAccount), isFromPool) as A2Center_RegisterAccount; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string AccountName { get; set; }

		[MemoryPackOrder(1)]
		public string Password { get; set; }

		[MemoryPackOrder(2)]
		public int LoginType { get; set; }

		[MemoryPackOrder(3)]
		public int age_type { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.AccountName = default;
			this.Password = default;
			this.LoginType = default;
			this.age_type = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Center2A_RegisterAccount)]
	[MemoryPackable]
	public partial class Center2A_RegisterAccount: MessageObject, IResponse
	{
		public static Center2A_RegisterAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2A_RegisterAccount), isFromPool) as Center2A_RegisterAccount; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(L2A_LoginAccountResponse))]
	[Message(InnerMessage.A2L_LoginAccountRequest)]
	[MemoryPackable]
	public partial class A2L_LoginAccountRequest: MessageObject, IRequest
	{
		public static A2L_LoginAccountRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2L_LoginAccountRequest), isFromPool) as A2L_LoginAccountRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long AccountId { get; set; }

		[MemoryPackOrder(4)]
		public bool Relink { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AccountId = default;
			this.Relink = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.L2A_LoginAccountResponse)]
	[MemoryPackable]
	public partial class L2A_LoginAccountResponse: MessageObject, IResponse
	{
		public static L2A_LoginAccountResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(L2A_LoginAccountResponse), isFromPool) as L2A_LoginAccountResponse; 
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

	[ResponseType(nameof(Chat2G_EnterChat))]
	[Message(InnerMessage.G2Chat_EnterChat)]
	[MemoryPackable]
	public partial class G2Chat_EnterChat: MessageObject, IRequest
	{
		public static G2Chat_EnterChat Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2Chat_EnterChat), isFromPool) as G2Chat_EnterChat; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string Name { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long GateSessionActorId { get; set; }

		[MemoryPackOrder(3)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Name = default;
			this.UnitId = default;
			this.GateSessionActorId = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Chat2G_EnterChat)]
	[MemoryPackable]
	public partial class Chat2G_EnterChat: MessageObject, IResponse
	{
		public static Chat2G_EnterChat Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Chat2G_EnterChat), isFromPool) as Chat2G_EnterChat; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long ChatInfoUnitInstanceId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ChatInfoUnitInstanceId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Chat2G_RequestExitChat))]
	[Message(InnerMessage.G2Chat_RequestExitChat)]
	[MemoryPackable]
	public partial class G2Chat_RequestExitChat: MessageObject, IRequest
	{
		public static G2Chat_RequestExitChat Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2Chat_RequestExitChat), isFromPool) as G2Chat_RequestExitChat; 
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

	[Message(InnerMessage.Chat2G_RequestExitChat)]
	[MemoryPackable]
	public partial class Chat2G_RequestExitChat: MessageObject, IResponse
	{
		public static Chat2G_RequestExitChat Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Chat2G_RequestExitChat), isFromPool) as Chat2G_RequestExitChat; 
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

	[ResponseType(nameof(R2M_RankUnionRaceResponse))]
	[Message(InnerMessage.M2R_RankUnionRaceRequest)]
	[MemoryPackable]
	public partial class M2R_RankUnionRaceRequest: MessageObject, IRequest
	{
		public static M2R_RankUnionRaceRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RankUnionRaceRequest), isFromPool) as M2R_RankUnionRaceRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int CampId { get; set; }

		[MemoryPackOrder(1)]
		public RankShouLieInfo RankingInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.CampId = default;
			this.RankingInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.R2M_RankUnionRaceResponse)]
	[MemoryPackable]
	public partial class R2M_RankUnionRaceResponse: MessageObject, IResponse
	{
		public static R2M_RankUnionRaceResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankUnionRaceResponse), isFromPool) as R2M_RankUnionRaceResponse; 
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

	[ResponseType(nameof(R2M_PetRankUpdateResponse))]
	[Message(InnerMessage.M2R_PetRankUpdateRequest)]
	[MemoryPackable]
	public partial class M2R_PetRankUpdateRequest: MessageObject, IRequest
	{
		public static M2R_PetRankUpdateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_PetRankUpdateRequest), isFromPool) as M2R_PetRankUpdateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long EnemyId { get; set; }

		[MemoryPackOrder(1)]
		public RankPetInfo RankPetInfo { get; set; }

		[MemoryPackOrder(2)]
		public int Win { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.EnemyId = default;
			this.RankPetInfo = default;
			this.Win = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.R2M_PetRankUpdateResponse)]
	[MemoryPackable]
	public partial class R2M_PetRankUpdateResponse: MessageObject, IResponse
	{
		public static R2M_PetRankUpdateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_PetRankUpdateResponse), isFromPool) as R2M_PetRankUpdateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int SelfRank { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.SelfRank = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2M_PetMingBattleWinResponse))]
	[Message(InnerMessage.M2A_PetMingBattleWinRequest)]
	[MemoryPackable]
	public partial class M2A_PetMingBattleWinRequest: MessageObject, IRequest
	{
		public static M2A_PetMingBattleWinRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_PetMingBattleWinRequest), isFromPool) as M2A_PetMingBattleWinRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int MingType { get; set; }

		[MemoryPackOrder(1)]
		public int Postion { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		[MemoryPackOrder(3)]
		public int TeamId { get; set; }

		[MemoryPackOrder(4)]
		public string WinPlayer { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MingType = default;
			this.Postion = default;
			this.UnitID = default;
			this.TeamId = default;
			this.WinPlayer = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_PetMingBattleWinResponse)]
	[MemoryPackable]
	public partial class A2M_PetMingBattleWinResponse: MessageObject, IResponse
	{
		public static A2M_PetMingBattleWinResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_PetMingBattleWinResponse), isFromPool) as A2M_PetMingBattleWinResponse; 
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

	[ResponseType(nameof(A2M_PetMingPlayerInfoResponse))]
	[Message(InnerMessage.M2A_PetMingPlayerInfoRequest)]
	[MemoryPackable]
	public partial class M2A_PetMingPlayerInfoRequest: MessageObject, IRequest
	{
		public static M2A_PetMingPlayerInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_PetMingPlayerInfoRequest), isFromPool) as M2A_PetMingPlayerInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int MingType { get; set; }

		[MemoryPackOrder(1)]
		public int Postion { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MingType = default;
			this.Postion = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_PetMingPlayerInfoResponse)]
	[MemoryPackable]
	public partial class A2M_PetMingPlayerInfoResponse: MessageObject, IResponse
	{
		public static A2M_PetMingPlayerInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_PetMingPlayerInfoResponse), isFromPool) as A2M_PetMingPlayerInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public PetMingPlayerInfo PetMingPlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PetMingPlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//进入副本
	[ResponseType(nameof(LocalDungeon2M_EnterResponse))]
	[Message(InnerMessage.M2LocalDungeon_EnterRequest)]
	[MemoryPackable]
	public partial class M2LocalDungeon_EnterRequest: MessageObject, IRequest
	{
		public static M2LocalDungeon_EnterRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2LocalDungeon_EnterRequest), isFromPool) as M2LocalDungeon_EnterRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserID { get; set; }

		[MemoryPackOrder(1)]
		public int SceneId { get; set; }

		[MemoryPackOrder(2)]
		public int TransferId { get; set; }

		[MemoryPackOrder(3)]
		public int Difficulty { get; set; }

		[MemoryPackOrder(4)]
		public int SceneType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserID = default;
			this.SceneId = default;
			this.TransferId = default;
			this.Difficulty = default;
			this.SceneType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.LocalDungeon2M_EnterResponse)]
	[MemoryPackable]
	public partial class LocalDungeon2M_EnterResponse: MessageObject, IResponse
	{
		public static LocalDungeon2M_EnterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(LocalDungeon2M_EnterResponse), isFromPool) as LocalDungeon2M_EnterResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public long FubenId { get; set; }

		[MemoryPackOrder(3)]
		public long FubenInstanceId { get; set; }

		[MemoryPackOrder(4)]
		public int RootId { get; set; }

		[MemoryPackOrder(5)]
		public int Process { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenId = default;
			this.FubenInstanceId = default;
			this.RootId = default;
			this.Process = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//喂食物
	[ResponseType(nameof(A2M_ActivityFeedResponse))]
	[Message(InnerMessage.M2A_ActivityFeedRequest)]
	[MemoryPackable]
	public partial class M2A_ActivityFeedRequest: MessageObject, IRequest
	{
		public static M2A_ActivityFeedRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_ActivityFeedRequest), isFromPool) as M2A_ActivityFeedRequest; 
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

	[Message(InnerMessage.A2M_ActivityFeedResponse)]
	[MemoryPackable]
	public partial class A2M_ActivityFeedResponse: MessageObject, IResponse
	{
		public static A2M_ActivityFeedResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_ActivityFeedResponse), isFromPool) as A2M_ActivityFeedResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int BaoShiDu { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.BaoShiDu = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2M_ActivityGuessResponse))]
	[Message(InnerMessage.M2A_ActivityGuessRequest)]
	[MemoryPackable]
	public partial class M2A_ActivityGuessRequest: MessageObject, IRequest
	{
		public static M2A_ActivityGuessRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_ActivityGuessRequest), isFromPool) as M2A_ActivityGuessRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int GuessId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.GuessId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_ActivityGuessResponse)]
	[MemoryPackable]
	public partial class A2M_ActivityGuessResponse: MessageObject, IResponse
	{
		public static A2M_ActivityGuessResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_ActivityGuessResponse), isFromPool) as A2M_ActivityGuessResponse; 
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

	[ResponseType(nameof(A2M_ActivitySelfInfo))]
	[Message(InnerMessage.M2A_ActivitySelfInfo)]
	[MemoryPackable]
	public partial class M2A_ActivitySelfInfo: MessageObject, IRequest
	{
		public static M2A_ActivitySelfInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_ActivitySelfInfo), isFromPool) as M2A_ActivitySelfInfo; 
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

	[Message(InnerMessage.A2M_ActivitySelfInfo)]
	[MemoryPackable]
	public partial class A2M_ActivitySelfInfo: MessageObject, IResponse
	{
		public static A2M_ActivitySelfInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_ActivitySelfInfo), isFromPool) as A2M_ActivitySelfInfo; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> GuessIds { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<int> LastGuessReward { get; set; } = new();

		[MemoryPackOrder(2)]
		public int BaoShiDu { get; set; }

		[MemoryPackOrder(3)]
		public List<int> OpenGuessIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.GuessIds.Clear();
			this.LastGuessReward.Clear();
			this.BaoShiDu = default;
			this.OpenGuessIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2A_FirstWinInfoMessage)]
	[MemoryPackable]
	public partial class M2A_FirstWinInfoMessage: MessageObject, IMessage
	{
		public static M2A_FirstWinInfoMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_FirstWinInfoMessage), isFromPool) as M2A_FirstWinInfoMessage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public FirstWinInfo FirstWinInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.FirstWinInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2M_MysteryBuyResponse))]
	[Message(InnerMessage.M2A_MysteryBuyRequest)]
	[MemoryPackable]
	public partial class M2A_MysteryBuyRequest: MessageObject, IRequest
	{
		public static M2A_MysteryBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_MysteryBuyRequest), isFromPool) as M2A_MysteryBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public MysteryItemInfo MysteryItemInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MysteryItemInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_MysteryBuyResponse)]
	[MemoryPackable]
	public partial class A2M_MysteryBuyResponse: MessageObject, IResponse
	{
		public static A2M_MysteryBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_MysteryBuyResponse), isFromPool) as A2M_MysteryBuyResponse; 
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

	[ResponseType(nameof(A2M_TurtleRecordResponse))]
	[Message(InnerMessage.M2A_TurtleRecordRequest)]
	[MemoryPackable]
	public partial class M2A_TurtleRecordRequest: MessageObject, IRequest
	{
		public static M2A_TurtleRecordRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_TurtleRecordRequest), isFromPool) as M2A_TurtleRecordRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_TurtleRecordResponse)]
	[MemoryPackable]
	public partial class A2M_TurtleRecordResponse: MessageObject, IResponse
	{
		public static A2M_TurtleRecordResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_TurtleRecordResponse), isFromPool) as A2M_TurtleRecordResponse; 
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

	[ResponseType(nameof(A2M_TurtleReportResponse))]
	[Message(InnerMessage.M2A_TurtleReportRequest)]
	[MemoryPackable]
	public partial class M2A_TurtleReportRequest: MessageObject, IRequest
	{
		public static M2A_TurtleReportRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_TurtleReportRequest), isFromPool) as M2A_TurtleReportRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int TurtleId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TurtleId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_TurtleReportResponse)]
	[MemoryPackable]
	public partial class A2M_TurtleReportResponse: MessageObject, IResponse
	{
		public static A2M_TurtleReportResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_TurtleReportResponse), isFromPool) as A2M_TurtleReportResponse; 
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

	[ResponseType(nameof(A2M_TurtleSupportResponse))]
	[Message(InnerMessage.M2A_TurtleSupportRequest)]
	[MemoryPackable]
	public partial class M2A_TurtleSupportRequest: MessageObject, IRequest
	{
		public static M2A_TurtleSupportRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_TurtleSupportRequest), isFromPool) as M2A_TurtleSupportRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SupportId { get; set; }

		[MemoryPackOrder(1)]
		public long AccountId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SupportId = default;
			this.AccountId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_TurtleSupportResponse)]
	[MemoryPackable]
	public partial class A2M_TurtleSupportResponse: MessageObject, IResponse
	{
		public static A2M_TurtleSupportResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_TurtleSupportResponse), isFromPool) as A2M_TurtleSupportResponse; 
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

	[ResponseType(nameof(A2M_ZhanQuInfoResponse))]
	[Message(InnerMessage.M2A_ZhanQuInfoRequest)]
	[MemoryPackable]
	public partial class M2A_ZhanQuInfoRequest: MessageObject, IRequest
	{
		public static M2A_ZhanQuInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_ZhanQuInfoRequest), isFromPool) as M2A_ZhanQuInfoRequest; 
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

	[Message(InnerMessage.A2M_ZhanQuInfoResponse)]
	[MemoryPackable]
	public partial class A2M_ZhanQuInfoResponse: MessageObject, IResponse
	{
		public static A2M_ZhanQuInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_ZhanQuInfoResponse), isFromPool) as A2M_ZhanQuInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> DayTeHui { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<ZhanQuReceiveNumber> ReceiveNum { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.DayTeHui.Clear();
			this.ReceiveNum.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2M_ZhanQuReceiveResponse))]
	[Message(InnerMessage.M2A_ZhanQuReceiveRequest)]
	[MemoryPackable]
	public partial class M2A_ZhanQuReceiveRequest: MessageObject, IRequest
	{
		public static M2A_ZhanQuReceiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_ZhanQuReceiveRequest), isFromPool) as M2A_ZhanQuReceiveRequest; 
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
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ActivityType = default;
			this.ActivityId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2M_ZhanQuReceiveResponse)]
	[MemoryPackable]
	public partial class A2M_ZhanQuReceiveResponse: MessageObject, IResponse
	{
		public static A2M_ZhanQuReceiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_ZhanQuReceiveResponse), isFromPool) as A2M_ZhanQuReceiveResponse; 
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

	[ResponseType(nameof(E2M_EMailSendResponse))]
	[Message(InnerMessage.M2E_EMailSendRequest)]
	[MemoryPackable]
	public partial class M2E_EMailSendRequest: MessageObject, IRequest
	{
		public static M2E_EMailSendRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2E_EMailSendRequest), isFromPool) as M2E_EMailSendRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(2)]
		public MailInfo MailInfo { get; set; }

		[MemoryPackOrder(3)]
		public int GetWay { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Id = default;
			this.MailInfo = default;
			this.GetWay = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.E2M_EMailSendResponse)]
	[MemoryPackable]
	public partial class E2M_EMailSendResponse: MessageObject, IResponse
	{
		public static E2M_EMailSendResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(E2M_EMailSendResponse), isFromPool) as E2M_EMailSendResponse; 
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

	[ResponseType(nameof(M2A_PetMingRecordResponse))]
	[Message(InnerMessage.A2M_PetMingRecordRequest)]
	[MemoryPackable]
	public partial class A2M_PetMingRecordRequest: MessageObject, IRequest
	{
		public static A2M_PetMingRecordRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_PetMingRecordRequest), isFromPool) as A2M_PetMingRecordRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		[MemoryPackOrder(0)]
		public PetMingRecord PetMingRecord { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitID = default;
			this.PetMingRecord = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2A_PetMingRecordResponse)]
	[MemoryPackable]
	public partial class M2A_PetMingRecordResponse: MessageObject, IResponse
	{
		public static M2A_PetMingRecordResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_PetMingRecordResponse), isFromPool) as M2A_PetMingRecordResponse; 
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

	[Message(InnerMessage.Mail2M_SendServerMailItem)]
	[MemoryPackable]
	public partial class Mail2M_SendServerMailItem: MessageObject, ILocationMessage
	{
		public static Mail2M_SendServerMailItem Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Mail2M_SendServerMailItem), isFromPool) as Mail2M_SendServerMailItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public ServerMailItem ServerMailItem { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ServerMailItem = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2A_ServerMessageRResponse))]
	[Message(InnerMessage.A2A_ServerMessageRequest)]
	[MemoryPackable]
	public partial class A2A_ServerMessageRequest: MessageObject, IRequest
	{
		public static A2A_ServerMessageRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2A_ServerMessageRequest), isFromPool) as A2A_ServerMessageRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public int MessageType { get; set; }

		[MemoryPackOrder(4)]
		public string MessageValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MessageType = default;
			this.MessageValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2A_ServerMessageRResponse)]
	[MemoryPackable]
	public partial class A2A_ServerMessageRResponse: MessageObject, IResponse
	{
		public static A2A_ServerMessageRResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2A_ServerMessageRResponse), isFromPool) as A2A_ServerMessageRResponse; 
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

//捐献
	[ResponseType(nameof(U2M_DonationResponse))]
	[Message(InnerMessage.M2U_DonationRequest)]
	[MemoryPackable]
	public partial class M2U_DonationRequest: MessageObject, IRequest
	{
		public static M2U_DonationRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_DonationRequest), isFromPool) as M2U_DonationRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(2)]
		public RankingInfo RankingInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RankingInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.U2M_DonationResponse)]
	[MemoryPackable]
	public partial class U2M_DonationResponse: MessageObject, IResponse
	{
		public static U2M_DonationResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_DonationResponse), isFromPool) as U2M_DonationResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int RankId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(U2M_UnionCreateResponse))]
	[Message(InnerMessage.M2U_UnionCreateRequest)]
	[MemoryPackable]
	public partial class M2U_UnionCreateRequest: MessageObject, IRequest
	{
		public static M2U_UnionCreateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionCreateRequest), isFromPool) as M2U_UnionCreateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string UnionName { get; set; }

		[MemoryPackOrder(1)]
		public string UnionPurpose { get; set; }

		[MemoryPackOrder(3)]
		public long UserID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionName = default;
			this.UnionPurpose = default;
			this.UserID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.U2M_UnionCreateResponse)]
	[MemoryPackable]
	public partial class U2M_UnionCreateResponse: MessageObject, IResponse
	{
		public static U2M_UnionCreateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionCreateResponse), isFromPool) as U2M_UnionCreateResponse; 
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

	[ResponseType(nameof(Chat2M_UpdateUnion))]
	[Message(InnerMessage.M2Chat_UpdateUnion)]
	[MemoryPackable]
	public partial class M2Chat_UpdateUnion: MessageObject, IRequest
	{
		public static M2Chat_UpdateUnion Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2Chat_UpdateUnion), isFromPool) as M2Chat_UpdateUnion; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Chat2M_UpdateUnion)]
	[MemoryPackable]
	public partial class Chat2M_UpdateUnion: MessageObject, IResponse
	{
		public static Chat2M_UpdateUnion Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Chat2M_UpdateUnion), isFromPool) as Chat2M_UpdateUnion; 
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

//家族操作  1增加经验  2获取等级
	[ResponseType(nameof(U2M_UnionOperationResponse))]
	[Message(InnerMessage.M2U_UnionOperationRequest)]
	[MemoryPackable]
	public partial class M2U_UnionOperationRequest: MessageObject, IRequest
	{
		public static M2U_UnionOperationRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionOperationRequest), isFromPool) as M2U_UnionOperationRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int OperateType { get; set; }

		[MemoryPackOrder(2)]
		public string Par { get; set; }

		[MemoryPackOrder(3)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.OperateType = default;
			this.Par = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.U2M_UnionOperationResponse)]
	[MemoryPackable]
	public partial class U2M_UnionOperationResponse: MessageObject, IResponse
	{
		public static U2M_UnionOperationResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionOperationResponse), isFromPool) as U2M_UnionOperationResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public string Par { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Par = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2U_UnionInviteReplyMessage)]
	[MemoryPackable]
	public partial class M2U_UnionInviteReplyMessage: MessageObject, ILocationMessage
	{
		public static M2U_UnionInviteReplyMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionInviteReplyMessage), isFromPool) as M2U_UnionInviteReplyMessage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int ReplyCode { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.UnionId = default;
			this.ReplyCode = default;
			this.UnitID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(U2M_UnionKeJiLearnResponse))]
	[Message(InnerMessage.M2U_UnionKeJiLearnRequest)]
	[MemoryPackable]
	public partial class M2U_UnionKeJiLearnRequest: MessageObject, IRequest
	{
		public static M2U_UnionKeJiLearnRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionKeJiLearnRequest), isFromPool) as M2U_UnionKeJiLearnRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int KeJiId { get; set; }

		[MemoryPackOrder(2)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.KeJiId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.U2M_UnionKeJiLearnResponse)]
	[MemoryPackable]
	public partial class U2M_UnionKeJiLearnResponse: MessageObject, IResponse
	{
		public static U2M_UnionKeJiLearnResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionKeJiLearnResponse), isFromPool) as U2M_UnionKeJiLearnResponse; 
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

//离开公会
	[ResponseType(nameof(U2M_UnionLeaveResponse))]
	[Message(InnerMessage.M2U_UnionLeaveRequest)]
	[MemoryPackable]
	public partial class M2U_UnionLeaveRequest: MessageObject, IRequest
	{
		public static M2U_UnionLeaveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionLeaveRequest), isFromPool) as M2U_UnionLeaveRequest; 
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

	[Message(InnerMessage.U2M_UnionLeaveResponse)]
	[MemoryPackable]
	public partial class U2M_UnionLeaveResponse: MessageObject, IResponse
	{
		public static U2M_UnionLeaveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionLeaveResponse), isFromPool) as U2M_UnionLeaveResponse; 
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

	[ResponseType(nameof(U2M_UnionMysteryBuyResponse))]
	[Message(InnerMessage.M2U_UnionMysteryBuyRequest)]
	[MemoryPackable]
	public partial class M2U_UnionMysteryBuyRequest: MessageObject, IRequest
	{
		public static M2U_UnionMysteryBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionMysteryBuyRequest), isFromPool) as M2U_UnionMysteryBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public int MysteryId { get; set; }

		[MemoryPackOrder(2)]
		public int BuyNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.MysteryId = default;
			this.BuyNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.U2M_UnionMysteryBuyResponse)]
	[MemoryPackable]
	public partial class U2M_UnionMysteryBuyResponse: MessageObject, IResponse
	{
		public static U2M_UnionMysteryBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionMysteryBuyResponse), isFromPool) as U2M_UnionMysteryBuyResponse; 
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
	[ResponseType(nameof(U2M_UnionTransferResponse))]
	[Message(InnerMessage.M2U_UnionTransferRequest)]
	[MemoryPackable]
	public partial class M2U_UnionTransferRequest: MessageObject, IRequest
	{
		public static M2U_UnionTransferRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionTransferRequest), isFromPool) as M2U_UnionTransferRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long NewLeader { get; set; }

		[MemoryPackOrder(1)]
		public long UnitID { get; set; }

		[MemoryPackOrder(2)]
		public long UnionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.NewLeader = default;
			this.UnitID = default;
			this.UnionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.U2M_UnionTransferResponse)]
	[MemoryPackable]
	public partial class U2M_UnionTransferResponse: MessageObject, IResponse
	{
		public static U2M_UnionTransferResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionTransferResponse), isFromPool) as U2M_UnionTransferResponse; 
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

//入会通知
	[ResponseType(nameof(M2U_UnionApplyResponse))]
	[Message(InnerMessage.U2M_UnionApplyRequest)]
	[MemoryPackable]
	public partial class U2M_UnionApplyRequest: MessageObject, IRequest
	{
		public static U2M_UnionApplyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionApplyRequest), isFromPool) as U2M_UnionApplyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UnionId { get; set; }

		[MemoryPackOrder(1)]
		public string UnionName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.UnionName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2U_UnionApplyResponse)]
	[MemoryPackable]
	public partial class M2U_UnionApplyResponse: MessageObject, IResponse
	{
		public static M2U_UnionApplyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionApplyResponse), isFromPool) as M2U_UnionApplyResponse; 
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

	[ResponseType(nameof(G2T_GateUnitInfoResponse))]
	[Message(InnerMessage.T2G_GateUnitInfoRequest)]
	[MemoryPackable]
	public partial class T2G_GateUnitInfoRequest: MessageObject, IRequest
	{
		public static T2G_GateUnitInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2G_GateUnitInfoRequest), isFromPool) as T2G_GateUnitInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UserID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.G2T_GateUnitInfoResponse)]
	[MemoryPackable]
	public partial class G2T_GateUnitInfoResponse: MessageObject, IResponse
	{
		public static G2T_GateUnitInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2T_GateUnitInfoResponse), isFromPool) as G2T_GateUnitInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long SessionInstanceId { get; set; }

		[MemoryPackOrder(1)]
		public int PlayerState { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.SessionInstanceId = default;
			this.PlayerState = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//加速完成
	[ResponseType(nameof(M2U_UnionKeJiQuickResponse))]
	[Message(InnerMessage.U2M_UnionKeJiQuickRequest)]
	[MemoryPackable]
	public partial class U2M_UnionKeJiQuickRequest: MessageObject, IRequest
	{
		public static U2M_UnionKeJiQuickRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionKeJiQuickRequest), isFromPool) as U2M_UnionKeJiQuickRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Cost { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Cost = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2U_UnionKeJiQuickResponse)]
	[MemoryPackable]
	public partial class M2U_UnionKeJiQuickResponse: MessageObject, IResponse
	{
		public static M2U_UnionKeJiQuickResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionKeJiQuickResponse), isFromPool) as M2U_UnionKeJiQuickResponse; 
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

//公会踢人
	[ResponseType(nameof(M2U_UnionKickOutResponse))]
	[Message(InnerMessage.U2M_UnionKickOutRequest)]
	[MemoryPackable]
	public partial class U2M_UnionKickOutRequest: MessageObject, IRequest
	{
		public static U2M_UnionKickOutRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionKickOutRequest), isFromPool) as U2M_UnionKickOutRequest; 
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

	[Message(InnerMessage.M2U_UnionKickOutResponse)]
	[MemoryPackable]
	public partial class M2U_UnionKickOutResponse: MessageObject, IResponse
	{
		public static M2U_UnionKickOutResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionKickOutResponse), isFromPool) as M2U_UnionKickOutResponse; 
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

///转让族长
	[Message(InnerMessage.M2M_UnionTransferMessage)]
	[MemoryPackable]
	public partial class M2M_UnionTransferMessage: MessageObject, IMessage
	{
		public static M2M_UnionTransferMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_UnionTransferMessage), isFromPool) as M2M_UnionTransferMessage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int UnionLeader { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnionLeader = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Union2G_EnterUnion))]
	[Message(InnerMessage.G2Union_EnterUnion)]
	[MemoryPackable]
	public partial class G2Union_EnterUnion: MessageObject, IRequest
	{
		public static G2Union_EnterUnion Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2Union_EnterUnion), isFromPool) as G2Union_EnterUnion; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string Name { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Name = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Union2G_EnterUnion)]
	[MemoryPackable]
	public partial class Union2G_EnterUnion: MessageObject, IResponse
	{
		public static Union2G_EnterUnion Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Union2G_EnterUnion), isFromPool) as Union2G_EnterUnion; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(1)]
		public long WinUnionId { get; set; }

		[MemoryPackOrder(2)]
		public int DonationRankId { get; set; }

		[MemoryPackOrder(3)]
		public long LeaderId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.WinUnionId = default;
			this.DonationRankId = default;
			this.LeaderId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//进入家族地图
	[ResponseType(nameof(U2M_UnionEnterResponse))]
	[Message(InnerMessage.M2U_UnionEnterRequest)]
	[MemoryPackable]
	public partial class M2U_UnionEnterRequest: MessageObject, IRequest
	{
		public static M2U_UnionEnterRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2U_UnionEnterRequest), isFromPool) as M2U_UnionEnterRequest; 
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
		public int SceneId { get; set; }

		[MemoryPackOrder(3)]
		public int OperateType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnionId = default;
			this.UnitId = default;
			this.SceneId = default;
			this.OperateType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.U2M_UnionEnterResponse)]
	[MemoryPackable]
	public partial class U2M_UnionEnterResponse: MessageObject, IResponse
	{
		public static U2M_UnionEnterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(U2M_UnionEnterResponse), isFromPool) as U2M_UnionEnterResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int FubenId { get; set; }

		[MemoryPackOrder(1)]
		public long FubenInstanceId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenId = default;
			this.FubenInstanceId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(A2A_ActivityUpdateResponse))]
	[Message(InnerMessage.A2A_ActivityUpdateRequest)]
	[MemoryPackable]
	public partial class A2A_ActivityUpdateRequest: MessageObject, IRequest
	{
		public static A2A_ActivityUpdateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2A_ActivityUpdateRequest), isFromPool) as A2A_ActivityUpdateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Hour { get; set; }

		[MemoryPackOrder(1)]
		public int OpenDay { get; set; }

		[MemoryPackOrder(2)]
		public int FunctionId { get; set; }

		[MemoryPackOrder(3)]
		public int FunctionType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Hour = default;
			this.OpenDay = default;
			this.FunctionId = default;
			this.FunctionType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2A_ActivityUpdateResponse)]
	[MemoryPackable]
	public partial class A2A_ActivityUpdateResponse: MessageObject, IResponse
	{
		public static A2A_ActivityUpdateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2A_ActivityUpdateResponse), isFromPool) as A2A_ActivityUpdateResponse; 
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

	[Message(InnerMessage.G2M_ActivityUpdate)]
	[MemoryPackable]
	public partial class G2M_ActivityUpdate: MessageObject, IMessage
	{
		public static G2M_ActivityUpdate Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2M_ActivityUpdate), isFromPool) as G2M_ActivityUpdate; 
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

	[Message(InnerMessage.M2C_HappyInfoResult)]
	[MemoryPackable]
	public partial class M2C_HappyInfoResult: MessageObject, IMessage
	{
		public static M2C_HappyInfoResult Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_HappyInfoResult), isFromPool) as M2C_HappyInfoResult; 
		}

		[MemoryPackOrder(0)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long NextRefreshTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActorId = default;
			this.UnitId = default;
			this.NextRefreshTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//通知其他服务进程刷新肝帝
	[ResponseType(nameof(F2R_WorldLvUpdateResponse))]
	[Message(InnerMessage.R2F_WorldLvUpdateRequest)]
	[MemoryPackable]
	public partial class R2F_WorldLvUpdateRequest: MessageObject, IRequest
	{
		public static R2F_WorldLvUpdateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2F_WorldLvUpdateRequest), isFromPool) as R2F_WorldLvUpdateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public ServerInfo ServerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ServerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.F2R_WorldLvUpdateResponse)]
	[MemoryPackable]
	public partial class F2R_WorldLvUpdateResponse: MessageObject, IResponse
	{
		public static F2R_WorldLvUpdateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2R_WorldLvUpdateResponse), isFromPool) as F2R_WorldLvUpdateResponse; 
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

//广播
	[ResponseType(nameof(A2R_Broadcast))]
	[Message(InnerMessage.R2A_Broadcast)]
	[MemoryPackable]
	public partial class R2A_Broadcast: MessageObject, IRequest
	{
		public static R2A_Broadcast Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2A_Broadcast), isFromPool) as R2A_Broadcast; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(2)]
		public int LoadType { get; set; }

		[MemoryPackOrder(3)]
		public string LoadValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.LoadType = default;
			this.LoadValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.A2R_Broadcast)]
	[MemoryPackable]
	public partial class A2R_Broadcast: MessageObject, IResponse
	{
		public static A2R_Broadcast Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2R_Broadcast), isFromPool) as A2R_Broadcast; 
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

//通知机器人进程
	[Message(InnerMessage.G2Robot_MessageRequest)]
	[MemoryPackable]
	public partial class G2Robot_MessageRequest: MessageObject, IMessage
	{
		public static G2Robot_MessageRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2Robot_MessageRequest), isFromPool) as G2Robot_MessageRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int Zone { get; set; }

		[MemoryPackOrder(1)]
		public int MessageType { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Zone = default;
			this.MessageType = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	public static class InnerMessage
	{
		 public const ushort ObjectQueryRequest = 20002;
		 public const ushort M2A_Reload = 20003;
		 public const ushort A2M_Reload = 20004;
		 public const ushort G2G_LockRequest = 20005;
		 public const ushort G2G_LockResponse = 20006;
		 public const ushort G2G_LockReleaseRequest = 20007;
		 public const ushort G2G_LockReleaseResponse = 20008;
		 public const ushort ObjectAddRequest = 20009;
		 public const ushort ObjectAddResponse = 20010;
		 public const ushort ObjectLockRequest = 20011;
		 public const ushort ObjectLockResponse = 20012;
		 public const ushort ObjectUnLockRequest = 20013;
		 public const ushort ObjectUnLockResponse = 20014;
		 public const ushort ObjectRemoveRequest = 20015;
		 public const ushort ObjectRemoveResponse = 20016;
		 public const ushort ObjectGetRequest = 20017;
		 public const ushort ObjectGetResponse = 20018;
		 public const ushort R2G_GetLoginKey = 20019;
		 public const ushort G2R_GetLoginKey = 20020;
		 public const ushort G2M_SessionDisconnect = 20021;
		 public const ushort ObjectQueryResponse = 20022;
		 public const ushort M2M_UnitTransferRequest = 20023;
		 public const ushort M2M_UnitTransferResponse = 20024;
		 public const ushort Other2UnitCache_AddOrUpdateUnit = 20025;
		 public const ushort UnitCache2Other_AddOrUpdateUnit = 20026;
		 public const ushort Other2UnitCache_GetUnit = 20027;
		 public const ushort UnitCache2Other_GetUnit = 20028;
		 public const ushort Other2UnitCache_DeleteUnit = 20029;
		 public const ushort UnitCache2Other_DeleteUnit = 20030;
		 public const ushort Other2UnitCache_GetComponent = 20031;
		 public const ushort UnitCache2Other_GetComponent = 20032;
		 public const ushort A2Center_CheckAccount = 20033;
		 public const ushort Center2A_CheckAccount = 20034;
		 public const ushort A2Center_RegisterAccount = 20035;
		 public const ushort Center2A_RegisterAccount = 20036;
		 public const ushort A2L_LoginAccountRequest = 20037;
		 public const ushort L2A_LoginAccountResponse = 20038;
		 public const ushort G2Chat_EnterChat = 20039;
		 public const ushort Chat2G_EnterChat = 20040;
		 public const ushort G2Chat_RequestExitChat = 20041;
		 public const ushort Chat2G_RequestExitChat = 20042;
		 public const ushort M2R_RankUnionRaceRequest = 20043;
		 public const ushort R2M_RankUnionRaceResponse = 20044;
		 public const ushort M2R_PetRankUpdateRequest = 20045;
		 public const ushort R2M_PetRankUpdateResponse = 20046;
		 public const ushort M2A_PetMingBattleWinRequest = 20047;
		 public const ushort A2M_PetMingBattleWinResponse = 20048;
		 public const ushort M2A_PetMingPlayerInfoRequest = 20049;
		 public const ushort A2M_PetMingPlayerInfoResponse = 20050;
		 public const ushort M2LocalDungeon_EnterRequest = 20051;
		 public const ushort LocalDungeon2M_EnterResponse = 20052;
		 public const ushort M2A_ActivityFeedRequest = 20053;
		 public const ushort A2M_ActivityFeedResponse = 20054;
		 public const ushort M2A_ActivityGuessRequest = 20055;
		 public const ushort A2M_ActivityGuessResponse = 20056;
		 public const ushort M2A_ActivitySelfInfo = 20057;
		 public const ushort A2M_ActivitySelfInfo = 20058;
		 public const ushort M2A_FirstWinInfoMessage = 20059;
		 public const ushort M2A_MysteryBuyRequest = 20060;
		 public const ushort A2M_MysteryBuyResponse = 20061;
		 public const ushort M2A_TurtleRecordRequest = 20062;
		 public const ushort A2M_TurtleRecordResponse = 20063;
		 public const ushort M2A_TurtleReportRequest = 20064;
		 public const ushort A2M_TurtleReportResponse = 20065;
		 public const ushort M2A_TurtleSupportRequest = 20066;
		 public const ushort A2M_TurtleSupportResponse = 20067;
		 public const ushort M2A_ZhanQuInfoRequest = 20068;
		 public const ushort A2M_ZhanQuInfoResponse = 20069;
		 public const ushort M2A_ZhanQuReceiveRequest = 20070;
		 public const ushort A2M_ZhanQuReceiveResponse = 20071;
		 public const ushort M2E_EMailSendRequest = 20072;
		 public const ushort E2M_EMailSendResponse = 20073;
		 public const ushort A2M_PetMingRecordRequest = 20074;
		 public const ushort M2A_PetMingRecordResponse = 20075;
		 public const ushort Mail2M_SendServerMailItem = 20076;
		 public const ushort A2A_ServerMessageRequest = 20077;
		 public const ushort A2A_ServerMessageRResponse = 20078;
		 public const ushort M2U_DonationRequest = 20079;
		 public const ushort U2M_DonationResponse = 20080;
		 public const ushort M2U_UnionCreateRequest = 20081;
		 public const ushort U2M_UnionCreateResponse = 20082;
		 public const ushort M2Chat_UpdateUnion = 20083;
		 public const ushort Chat2M_UpdateUnion = 20084;
		 public const ushort M2U_UnionOperationRequest = 20085;
		 public const ushort U2M_UnionOperationResponse = 20086;
		 public const ushort M2U_UnionInviteReplyMessage = 20087;
		 public const ushort M2U_UnionKeJiLearnRequest = 20088;
		 public const ushort U2M_UnionKeJiLearnResponse = 20089;
		 public const ushort M2U_UnionLeaveRequest = 20090;
		 public const ushort U2M_UnionLeaveResponse = 20091;
		 public const ushort M2U_UnionMysteryBuyRequest = 20092;
		 public const ushort U2M_UnionMysteryBuyResponse = 20093;
		 public const ushort M2U_UnionTransferRequest = 20094;
		 public const ushort U2M_UnionTransferResponse = 20095;
		 public const ushort U2M_UnionApplyRequest = 20096;
		 public const ushort M2U_UnionApplyResponse = 20097;
		 public const ushort T2G_GateUnitInfoRequest = 20098;
		 public const ushort G2T_GateUnitInfoResponse = 20099;
		 public const ushort U2M_UnionKeJiQuickRequest = 20100;
		 public const ushort M2U_UnionKeJiQuickResponse = 20101;
		 public const ushort U2M_UnionKickOutRequest = 20102;
		 public const ushort M2U_UnionKickOutResponse = 20103;
		 public const ushort M2M_UnionTransferMessage = 20104;
		 public const ushort G2Union_EnterUnion = 20105;
		 public const ushort Union2G_EnterUnion = 20106;
		 public const ushort M2U_UnionEnterRequest = 20107;
		 public const ushort U2M_UnionEnterResponse = 20108;
		 public const ushort A2A_ActivityUpdateRequest = 20109;
		 public const ushort A2A_ActivityUpdateResponse = 20110;
		 public const ushort G2M_ActivityUpdate = 20111;
		 public const ushort M2C_HappyInfoResult = 20112;
		 public const ushort R2F_WorldLvUpdateRequest = 20113;
		 public const ushort F2R_WorldLvUpdateResponse = 20114;
		 public const ushort R2A_Broadcast = 20115;
		 public const ushort A2R_Broadcast = 20116;
		 public const ushort G2Robot_MessageRequest = 20117;
	}
}
