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

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OldActorId = default;
			this.Unit = default;
			this.Entitys.Clear();
			
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
	}
}
