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

// ResponseType L2R_LoginAccountRequest
	[Message(InnerMessage.R2L_LoginAccountRequest)]
	[MemoryPackable]
	public partial class R2L_LoginAccountRequest: MessageObject, IRequest
	{
		public static R2L_LoginAccountRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2L_LoginAccountRequest), isFromPool) as R2L_LoginAccountRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string AccountName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AccountName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.L2R_LoginAccountRequest)]
	[MemoryPackable]
	public partial class L2R_LoginAccountRequest: MessageObject, IResponse
	{
		public static L2R_LoginAccountRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(L2R_LoginAccountRequest), isFromPool) as L2R_LoginAccountRequest; 
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

// ResponseType G2L_DisconnectGateUnit
	[Message(InnerMessage.L2G_DisconnectGateUnit)]
	[MemoryPackable]
	public partial class L2G_DisconnectGateUnit: MessageObject, IRequest
	{
		public static L2G_DisconnectGateUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(L2G_DisconnectGateUnit), isFromPool) as L2G_DisconnectGateUnit; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string AccountName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AccountName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.G2L_DisconnectGateUnit)]
	[MemoryPackable]
	public partial class G2L_DisconnectGateUnit: MessageObject, IResponse
	{
		public static G2L_DisconnectGateUnit Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2L_DisconnectGateUnit), isFromPool) as G2L_DisconnectGateUnit; 
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

// ResponseType L2G_AddLoginRecord
	[Message(InnerMessage.G2L_AddLoginRecord)]
	[MemoryPackable]
	public partial class G2L_AddLoginRecord: MessageObject, IRequest
	{
		public static G2L_AddLoginRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2L_AddLoginRecord), isFromPool) as G2L_AddLoginRecord; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string AccountName { get; set; }

		[MemoryPackOrder(2)]
		public int ServerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AccountName = default;
			this.ServerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.L2G_AddLoginRecord)]
	[MemoryPackable]
	public partial class L2G_AddLoginRecord: MessageObject, IResponse
	{
		public static L2G_AddLoginRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(L2G_AddLoginRecord), isFromPool) as L2G_AddLoginRecord; 
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

// ResponseType L2G_RemoveLoginRecord
	[Message(InnerMessage.G2L_RemoveLoginRecord)]
	[MemoryPackable]
	public partial class G2L_RemoveLoginRecord: MessageObject, IRequest
	{
		public static G2L_RemoveLoginRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2L_RemoveLoginRecord), isFromPool) as G2L_RemoveLoginRecord; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string AccountName { get; set; }

		[MemoryPackOrder(2)]
		public int ServerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AccountName = default;
			this.ServerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.L2G_RemoveLoginRecord)]
	[MemoryPackable]
	public partial class L2G_RemoveLoginRecord: MessageObject, IResponse
	{
		public static L2G_RemoveLoginRecord Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(L2G_RemoveLoginRecord), isFromPool) as L2G_RemoveLoginRecord; 
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

// ResponseType M2G_SecondLogin
	[Message(InnerMessage.G2M_SecondLogin)]
	[MemoryPackable]
	public partial class G2M_SecondLogin: MessageObject, ILocationRequest
	{
		public static G2M_SecondLogin Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2M_SecondLogin), isFromPool) as G2M_SecondLogin; 
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

	[Message(InnerMessage.M2G_SecondLogin)]
	[MemoryPackable]
	public partial class M2G_SecondLogin: MessageObject, ILocationResponse
	{
		public static M2G_SecondLogin Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2G_SecondLogin), isFromPool) as M2G_SecondLogin; 
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

// ResponseType M2G_RequestExitGame
	[Message(InnerMessage.G2M_RequestExitGame)]
	[MemoryPackable]
	public partial class G2M_RequestExitGame: MessageObject, ILocationRequest
	{
		public static G2M_RequestExitGame Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2M_RequestExitGame), isFromPool) as G2M_RequestExitGame; 
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

	[Message(InnerMessage.M2G_RequestExitGame)]
	[MemoryPackable]
	public partial class M2G_RequestExitGame: MessageObject, ILocationResponse
	{
		public static M2G_RequestExitGame Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2G_RequestExitGame), isFromPool) as M2G_RequestExitGame; 
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

		[MemoryPackOrder(2)]
		public ActorId FubenActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenId = default;
			this.FubenInstanceId = default;
			this.FubenActorId = default;
			
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
	[ResponseType(nameof(A2A_BroadcastResponse))]
	[Message(InnerMessage.A2A_BroadcastRequest)]
	[MemoryPackable]
	public partial class A2A_BroadcastRequest: MessageObject, IRequest
	{
		public static A2A_BroadcastRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2A_BroadcastRequest), isFromPool) as A2A_BroadcastRequest; 
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

	[Message(InnerMessage.A2A_BroadcastResponse)]
	[MemoryPackable]
	public partial class A2A_BroadcastResponse: MessageObject, IResponse
	{
		public static A2A_BroadcastResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2A_BroadcastResponse), isFromPool) as A2A_BroadcastResponse; 
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

//退出副本
	[ResponseType(nameof(LocalDungeon2M_ExitResponse))]
	[Message(InnerMessage.M2LocalDungeon_ExitRequest)]
	[MemoryPackable]
	public partial class M2LocalDungeon_ExitRequest: MessageObject, IRequest
	{
		public static M2LocalDungeon_ExitRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2LocalDungeon_ExitRequest), isFromPool) as M2LocalDungeon_ExitRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int SceneType { get; set; }

		[MemoryPackOrder(1)]
		public long FubenInstanceId { get; set; }

		[MemoryPackOrder(2)]
		public long FubenId { get; set; }

		[MemoryPackOrder(3)]
		public List<long> Camp1Player { get; set; } = new();

		[MemoryPackOrder(4)]
		public List<long> Camp2Player { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SceneType = default;
			this.FubenInstanceId = default;
			this.FubenId = default;
			this.Camp1Player.Clear();
			this.Camp2Player.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.LocalDungeon2M_ExitResponse)]
	[MemoryPackable]
	public partial class LocalDungeon2M_ExitResponse: MessageObject, IResponse
	{
		public static LocalDungeon2M_ExitResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(LocalDungeon2M_ExitResponse), isFromPool) as LocalDungeon2M_ExitResponse; 
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

	[ResponseType(nameof(M2P_PaiMaiAuctionOverResponse))]
	[Message(InnerMessage.P2M_PaiMaiAuctionOverRequest)]
	[MemoryPackable]
	public partial class P2M_PaiMaiAuctionOverRequest: MessageObject, IRequest
	{
		public static P2M_PaiMaiAuctionOverRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_PaiMaiAuctionOverRequest), isFromPool) as P2M_PaiMaiAuctionOverRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Price { get; set; }

		[MemoryPackOrder(1)]
		public long UnitID { get; set; }

		[MemoryPackOrder(2)]
		public int ItemID { get; set; }

		[MemoryPackOrder(3)]
		public int ItemNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Price = default;
			this.UnitID = default;
			this.ItemID = default;
			this.ItemNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2P_PaiMaiAuctionOverResponse)]
	[MemoryPackable]
	public partial class M2P_PaiMaiAuctionOverResponse: MessageObject, IResponse
	{
		public static M2P_PaiMaiAuctionOverResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_PaiMaiAuctionOverResponse), isFromPool) as M2P_PaiMaiAuctionOverResponse; 
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

	[ResponseType(nameof(E2P_PaiMaiOverTimeResponse))]
	[Message(InnerMessage.P2E_PaiMaiOverTimeRequest)]
	[MemoryPackable]
	public partial class P2E_PaiMaiOverTimeRequest: MessageObject, IRequest
	{
		public static P2E_PaiMaiOverTimeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2E_PaiMaiOverTimeRequest), isFromPool) as P2E_PaiMaiOverTimeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
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

	[Message(InnerMessage.E2P_PaiMaiOverTimeResponse)]
	[MemoryPackable]
	public partial class E2P_PaiMaiOverTimeResponse: MessageObject, IResponse
	{
		public static E2P_PaiMaiOverTimeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(E2P_PaiMaiOverTimeResponse), isFromPool) as E2P_PaiMaiOverTimeResponse; 
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

	[ResponseType(nameof(R2S_SoloResultResponse))]
	[Message(InnerMessage.S2R_SoloResultRequest)]
	[MemoryPackable]
	public partial class S2R_SoloResultRequest: MessageObject, IRequest
	{
		public static S2R_SoloResultRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(S2R_SoloResultRequest), isFromPool) as S2R_SoloResultRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int CampId { get; set; }

		[MemoryPackOrder(1)]
		public RankingInfo RankingInfo { get; set; }

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

	[Message(InnerMessage.R2S_SoloResultResponse)]
	[MemoryPackable]
	public partial class R2S_SoloResultResponse: MessageObject, IResponse
	{
		public static R2S_SoloResultResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2S_SoloResultResponse), isFromPool) as R2S_SoloResultResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int RankId { get; set; }

		[MemoryPackOrder(1)]
		public int PetRankId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankId = default;
			this.PetRankId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2M_RankRunRaceResponse))]
	[Message(InnerMessage.M2R_RankRunRaceRequest)]
	[MemoryPackable]
	public partial class M2R_RankRunRaceRequest: MessageObject, IRequest
	{
		public static M2R_RankRunRaceRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RankRunRaceRequest), isFromPool) as M2R_RankRunRaceRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
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

	[Message(InnerMessage.R2M_RankRunRaceResponse)]
	[MemoryPackable]
	public partial class R2M_RankRunRaceResponse: MessageObject, IResponse
	{
		public static R2M_RankRunRaceResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankRunRaceResponse), isFromPool) as R2M_RankRunRaceResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int RankId { get; set; }

		[MemoryPackOrder(1)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankId = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2M_RankDemonResponse))]
	[Message(InnerMessage.M2R_RankDemonRequest)]
	[MemoryPackable]
	public partial class M2R_RankDemonRequest: MessageObject, IRequest
	{
		public static M2R_RankDemonRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RankDemonRequest), isFromPool) as M2R_RankDemonRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
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

	[Message(InnerMessage.R2M_RankDemonResponse)]
	[MemoryPackable]
	public partial class R2M_RankDemonResponse: MessageObject, IResponse
	{
		public static R2M_RankDemonResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankDemonResponse), isFromPool) as R2M_RankDemonResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int RankId { get; set; }

		[MemoryPackOrder(1)]
		public List<RankingInfo> RankList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankId = default;
			this.RankList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.T2M_TeamUpdateRequest)]
	[MemoryPackable]
	public partial class T2M_TeamUpdateRequest: MessageObject, IMessage
	{
		public static T2M_TeamUpdateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2M_TeamUpdateRequest), isFromPool) as T2M_TeamUpdateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long TeamId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.TeamId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Center2A_RechargeResponse))]
	[Message(InnerMessage.A2Center_RechargeRequest)]
	[MemoryPackable]
	public partial class A2Center_RechargeRequest: MessageObject, IRequest
	{
		public static A2Center_RechargeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2Center_RechargeRequest), isFromPool) as A2Center_RechargeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long AccountId { get; set; }

		[MemoryPackOrder(1)]
		public RechargeInfo RechargeInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.AccountId = default;
			this.RechargeInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Center2A_RechargeResponse)]
	[MemoryPackable]
	public partial class Center2A_RechargeResponse: MessageObject, IResponse
	{
		public static Center2A_RechargeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2A_RechargeResponse), isFromPool) as Center2A_RechargeResponse; 
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

	[ResponseType(nameof(Center2A_SaveAccount))]
	[Message(InnerMessage.A2Center_SaveAccount)]
	[MemoryPackable]
	public partial class A2Center_SaveAccount: MessageObject, IRequest
	{
		public static A2Center_SaveAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2Center_SaveAccount), isFromPool) as A2Center_SaveAccount; 
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
		public PlayerInfo PlayerInfo { get; set; }

		[MemoryPackOrder(3)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.AccountName = default;
			this.Password = default;
			this.PlayerInfo = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Center2A_SaveAccount)]
	[MemoryPackable]
	public partial class Center2A_SaveAccount: MessageObject, IResponse
	{
		public static Center2A_SaveAccount Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2A_SaveAccount), isFromPool) as Center2A_SaveAccount; 
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

	[ResponseType(nameof(C2C_CenterServerInfoRespone))]
	[Message(InnerMessage.C2C_CenterServerInfoReuest)]
	[MemoryPackable]
	public partial class C2C_CenterServerInfoReuest: MessageObject, IRequest
	{
		public static C2C_CenterServerInfoReuest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_CenterServerInfoReuest), isFromPool) as C2C_CenterServerInfoReuest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int infoType { get; set; }

		[MemoryPackOrder(1)]
		public int Zone { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.infoType = default;
			this.Zone = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.C2C_CenterServerInfoRespone)]
	[MemoryPackable]
	public partial class C2C_CenterServerInfoRespone: MessageObject, IResponse
	{
		public static C2C_CenterServerInfoRespone Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2C_CenterServerInfoRespone), isFromPool) as C2C_CenterServerInfoRespone; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public string Value { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Value = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Center2C_DeleteAccountResponse))]
	[Message(InnerMessage.C2Center_DeleteAccountRequest)]
	[MemoryPackable]
	public partial class C2Center_DeleteAccountRequest: MessageObject, IRequest
	{
		public static C2Center_DeleteAccountRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2Center_DeleteAccountRequest), isFromPool) as C2Center_DeleteAccountRequest; 
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

	[Message(InnerMessage.Center2C_DeleteAccountResponse)]
	[MemoryPackable]
	public partial class Center2C_DeleteAccountResponse: MessageObject, IResponse
	{
		public static Center2C_DeleteAccountResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2C_DeleteAccountResponse), isFromPool) as Center2C_DeleteAccountResponse; 
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

	[ResponseType(nameof(Center2M_SerialReardResponse))]
//序列号奖励
	[Message(InnerMessage.M2Center_SerialReardRequest)]
	[MemoryPackable]
	public partial class M2Center_SerialReardRequest: MessageObject, IRequest
	{
		public static M2Center_SerialReardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2Center_SerialReardRequest), isFromPool) as M2Center_SerialReardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public string SerialNumber { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SerialNumber = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Center2M_SerialReardResponse)]
	[MemoryPackable]
	public partial class Center2M_SerialReardResponse: MessageObject, IResponse
	{
		public static Center2M_SerialReardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2M_SerialReardResponse), isFromPool) as Center2M_SerialReardResponse; 
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

	[ResponseType(nameof(Center2M_ShareSucessResponse))]
	[Message(InnerMessage.M2Center_ShareSucessRequest)]
	[MemoryPackable]
	public partial class M2Center_ShareSucessRequest: MessageObject, IRequest
	{
		public static M2Center_ShareSucessRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2Center_ShareSucessRequest), isFromPool) as M2Center_ShareSucessRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ShareType { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ShareType = default;
			this.UnitId = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Center2M_ShareSucessResponse)]
	[MemoryPackable]
	public partial class Center2M_ShareSucessResponse: MessageObject, IResponse
	{
		public static Center2M_ShareSucessResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Center2M_ShareSucessResponse), isFromPool) as Center2M_ShareSucessResponse; 
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

	[ResponseType(nameof(T2C_GetTeamInfoResponse))]
	[Message(InnerMessage.C2T_GetTeamInfoRequest)]
	[MemoryPackable]
	public partial class C2T_GetTeamInfoRequest: MessageObject, IRequest
	{
		public static C2T_GetTeamInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2T_GetTeamInfoRequest), isFromPool) as C2T_GetTeamInfoRequest; 
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

	[Message(InnerMessage.T2C_GetTeamInfoResponse)]
	[MemoryPackable]
	public partial class T2C_GetTeamInfoResponse: MessageObject, IResponse
	{
		public static T2C_GetTeamInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2C_GetTeamInfoResponse), isFromPool) as T2C_GetTeamInfoResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TeamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Chat2M_UpdateLevel))]
	[Message(InnerMessage.M2Chat_UpdateLevel)]
	[MemoryPackable]
	public partial class M2Chat_UpdateLevel: MessageObject, IRequest
	{
		public static M2Chat_UpdateLevel Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2Chat_UpdateLevel), isFromPool) as M2Chat_UpdateLevel; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(4)]
		public int Level { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.Level = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Chat2M_UpdateLevel)]
	[MemoryPackable]
	public partial class Chat2M_UpdateLevel: MessageObject, IResponse
	{
		public static Chat2M_UpdateLevel Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Chat2M_UpdateLevel), isFromPool) as Chat2M_UpdateLevel; 
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

	[ResponseType(nameof(Chat2Mail_GetUnitList))]
	[Message(InnerMessage.Mail2Chat_GetUnitList)]
	[MemoryPackable]
	public partial class Mail2Chat_GetUnitList: MessageObject, IRequest
	{
		public static Mail2Chat_GetUnitList Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Mail2Chat_GetUnitList), isFromPool) as Mail2Chat_GetUnitList; 
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

	[Message(InnerMessage.Chat2Mail_GetUnitList)]
	[MemoryPackable]
	public partial class Chat2Mail_GetUnitList: MessageObject, IResponse
	{
		public static Chat2Mail_GetUnitList Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Chat2Mail_GetUnitList), isFromPool) as Chat2Mail_GetUnitList; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<long> OnlineUnitIdList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.OnlineUnitIdList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Mail2G_EnterMail))]
	[Message(InnerMessage.G2Mail_EnterMail)]
	[MemoryPackable]
	public partial class G2Mail_EnterMail: MessageObject, IRequest
	{
		public static G2Mail_EnterMail Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2Mail_EnterMail), isFromPool) as G2Mail_EnterMail; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public int ServerMailIdCur { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.ServerMailIdCur = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Mail2G_EnterMail)]
	[MemoryPackable]
	public partial class Mail2G_EnterMail: MessageObject, IResponse
	{
		public static Mail2G_EnterMail Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Mail2G_EnterMail), isFromPool) as Mail2G_EnterMail; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public int ServerMailIdMax { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ServerMailIdMax = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(E2M_EMailReceiveResponse))]
	[Message(InnerMessage.M2E_EMailReceiveRequest)]
	[MemoryPackable]
	public partial class M2E_EMailReceiveRequest: MessageObject, IRequest
	{
		public static M2E_EMailReceiveRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2E_EMailReceiveRequest), isFromPool) as M2E_EMailReceiveRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public long MailId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Id = default;
			this.MailId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.E2M_EMailReceiveResponse)]
	[MemoryPackable]
	public partial class E2M_EMailReceiveResponse: MessageObject, IResponse
	{
		public static E2M_EMailReceiveResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(E2M_EMailReceiveResponse), isFromPool) as E2M_EMailReceiveResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public MailInfo MailInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MailInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2C_UpdateMailInfo)]
	[MemoryPackable]
	public partial class M2C_UpdateMailInfo: MessageObject, IMessage
	{
		public static M2C_UpdateMailInfo Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UpdateMailInfo), isFromPool) as M2C_UpdateMailInfo; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<MailInfo> MailInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MailInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(F2M_FubenCenterListResponse))]
	[Message(InnerMessage.M2F_FubenCenterListRequest)]
	[MemoryPackable]
	public partial class M2F_FubenCenterListRequest: MessageObject, IRequest
	{
		public static M2F_FubenCenterListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2F_FubenCenterListRequest), isFromPool) as M2F_FubenCenterListRequest; 
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

	[Message(InnerMessage.F2M_FubenCenterListResponse)]
	[MemoryPackable]
	public partial class F2M_FubenCenterListResponse: MessageObject, IResponse
	{
		public static F2M_FubenCenterListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2M_FubenCenterListResponse), isFromPool) as F2M_FubenCenterListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<long> FubenInstanceList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenInstanceList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//副本分配中心服
	[ResponseType(nameof(F2M_FubenCenterOpenResponse))]
	[Message(InnerMessage.M2F_FubenCenterOperateRequest)]
	[MemoryPackable]
	public partial class M2F_FubenCenterOperateRequest: MessageObject, IRequest
	{
		public static M2F_FubenCenterOperateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2F_FubenCenterOperateRequest), isFromPool) as M2F_FubenCenterOperateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int OperateType { get; set; }

		[MemoryPackOrder(1)]
		public long FubenInstanceId { get; set; }

		[MemoryPackOrder(2)]
		public int SceneType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.OperateType = default;
			this.FubenInstanceId = default;
			this.SceneType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.F2M_FubenCenterOpenResponse)]
	[MemoryPackable]
	public partial class F2M_FubenCenterOpenResponse: MessageObject, IResponse
	{
		public static F2M_FubenCenterOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2M_FubenCenterOpenResponse), isFromPool) as F2M_FubenCenterOpenResponse; 
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

//野外副本Id
	[ResponseType(nameof(F2M_FubenSceneIdResponse))]
	[Message(InnerMessage.M2F_FubenSceneIdRequest)]
	[MemoryPackable]
	public partial class M2F_FubenSceneIdRequest: MessageObject, IRequest
	{
		public static M2F_FubenSceneIdRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2F_FubenSceneIdRequest), isFromPool) as M2F_FubenSceneIdRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public int SceneId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SceneId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.F2M_FubenSceneIdResponse)]
	[MemoryPackable]
	public partial class F2M_FubenSceneIdResponse: MessageObject, IResponse
	{
		public static F2M_FubenSceneIdResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2M_FubenSceneIdResponse), isFromPool) as F2M_FubenSceneIdResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(1)]
		public long FubenInstanceId { get; set; }

		[MemoryPackOrder(2)]
		public ActorId FubenActorId { get; set; }

		[MemoryPackOrder(3)]
		public int Camp { get; set; }

		[MemoryPackOrder(4)]
		public int Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenInstanceId = default;
			this.FubenActorId = default;
			this.Camp = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//通知其他服务进程刷新肝帝
	[ResponseType(nameof(M2F_ServerInfoUpdateResponse))]
	[Message(InnerMessage.F2M_ServerInfoUpdateRequest)]
	[MemoryPackable]
	public partial class F2M_ServerInfoUpdateRequest: MessageObject, IRequest
	{
		public static F2M_ServerInfoUpdateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(F2M_ServerInfoUpdateRequest), isFromPool) as F2M_ServerInfoUpdateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public ServerInfo ServerInfo { get; set; }

		[MemoryPackOrder(1)]
		public int operareType { get; set; }

		[MemoryPackOrder(2)]
		public string operateValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ServerInfo = default;
			this.operareType = default;
			this.operateValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2F_ServerInfoUpdateResponse)]
	[MemoryPackable]
	public partial class M2F_ServerInfoUpdateResponse: MessageObject, IResponse
	{
		public static M2F_ServerInfoUpdateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2F_ServerInfoUpdateResponse), isFromPool) as M2F_ServerInfoUpdateResponse; 
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

	[ResponseType(nameof(P2M_PaiMaiAuctionJoinResponse))]
//参入竞拍
	[Message(InnerMessage.M2P_PaiMaiAuctionJoinRequest)]
	[MemoryPackable]
	public partial class M2P_PaiMaiAuctionJoinRequest: MessageObject, IRequest
	{
		public static M2P_PaiMaiAuctionJoinRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_PaiMaiAuctionJoinRequest), isFromPool) as M2P_PaiMaiAuctionJoinRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Gold { get; set; }

		[MemoryPackOrder(1)]
		public long UnitID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Gold = default;
			this.UnitID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.P2M_PaiMaiAuctionJoinResponse)]
	[MemoryPackable]
	public partial class P2M_PaiMaiAuctionJoinResponse: MessageObject, IResponse
	{
		public static P2M_PaiMaiAuctionJoinResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_PaiMaiAuctionJoinResponse), isFromPool) as P2M_PaiMaiAuctionJoinResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long CostGold { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.CostGold = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2M_PaiMaiAuctionPriceResponse))]
	[Message(InnerMessage.M2P_PaiMaiAuctionPriceRequest)]
	[MemoryPackable]
	public partial class M2P_PaiMaiAuctionPriceRequest: MessageObject, IRequest
	{
		public static M2P_PaiMaiAuctionPriceRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_PaiMaiAuctionPriceRequest), isFromPool) as M2P_PaiMaiAuctionPriceRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Price { get; set; }

		[MemoryPackOrder(1)]
		public long UnitID { get; set; }

		[MemoryPackOrder(2)]
		public int Occ { get; set; }

		[MemoryPackOrder(4)]
		public string AuctionPlayer { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Price = default;
			this.UnitID = default;
			this.Occ = default;
			this.AuctionPlayer = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.P2M_PaiMaiAuctionPriceResponse)]
	[MemoryPackable]
	public partial class P2M_PaiMaiAuctionPriceResponse: MessageObject, IResponse
	{
		public static P2M_PaiMaiAuctionPriceResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_PaiMaiAuctionPriceResponse), isFromPool) as P2M_PaiMaiAuctionPriceResponse; 
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

	[ResponseType(nameof(P2M_PaiMaiBuyResponse))]
	[Message(InnerMessage.M2P_PaiMaiBuyRequest)]
	[MemoryPackable]
	public partial class M2P_PaiMaiBuyRequest: MessageObject, IRequest
	{
		public static M2P_PaiMaiBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_PaiMaiBuyRequest), isFromPool) as M2P_PaiMaiBuyRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		[MemoryPackOrder(1)]
		public long Gold { get; set; }

		[MemoryPackOrder(2)]
		public int BuyNum { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfo = default;
			this.Gold = default;
			this.BuyNum = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.P2M_PaiMaiBuyResponse)]
	[MemoryPackable]
	public partial class P2M_PaiMaiBuyResponse: MessageObject, IResponse
	{
		public static P2M_PaiMaiBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_PaiMaiBuyResponse), isFromPool) as P2M_PaiMaiBuyResponse; 
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

	[ResponseType(nameof(M2M_PaiMaiBuyInfoResponse))]
	[Message(InnerMessage.M2M_PaiMaiBuyInfoRequest)]
	[MemoryPackable]
	public partial class M2M_PaiMaiBuyInfoRequest: MessageObject, IRequest
	{
		public static M2M_PaiMaiBuyInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_PaiMaiBuyInfoRequest), isFromPool) as M2M_PaiMaiBuyInfoRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long PlayerId { get; set; }

		[MemoryPackOrder(1)]
		public long CostGold { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PlayerId = default;
			this.CostGold = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2M_PaiMaiBuyInfoResponse)]
	[MemoryPackable]
	public partial class M2M_PaiMaiBuyInfoResponse: MessageObject, IResponse
	{
		public static M2M_PaiMaiBuyInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_PaiMaiBuyInfoResponse), isFromPool) as M2M_PaiMaiBuyInfoResponse; 
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

	[ResponseType(nameof(R2M_DBServerInfoResponse))]
	[Message(InnerMessage.M2R_DBServerInfoRequest)]
	[MemoryPackable]
	public partial class M2R_DBServerInfoRequest: MessageObject, IRequest
	{
		public static M2R_DBServerInfoRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_DBServerInfoRequest), isFromPool) as M2R_DBServerInfoRequest; 
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

	[Message(InnerMessage.R2M_DBServerInfoResponse)]
	[MemoryPackable]
	public partial class R2M_DBServerInfoResponse: MessageObject, IResponse
	{
		public static R2M_DBServerInfoResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_DBServerInfoResponse), isFromPool) as R2M_DBServerInfoResponse; 
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

	[ResponseType(nameof(P2M_PaiMaiSellResponse))]
	[Message(InnerMessage.M2P_PaiMaiSellRequest)]
	[MemoryPackable]
	public partial class M2P_PaiMaiSellRequest: MessageObject, IRequest
	{
		public static M2P_PaiMaiSellRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_PaiMaiSellRequest), isFromPool) as M2P_PaiMaiSellRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		[MemoryPackOrder(3)]
		public long PaiMaiTodayGold { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfo = default;
			this.UnitID = default;
			this.PaiMaiTodayGold = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.P2M_PaiMaiSellResponse)]
	[MemoryPackable]
	public partial class P2M_PaiMaiSellResponse: MessageObject, IResponse
	{
		public static P2M_PaiMaiSellResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_PaiMaiSellResponse), isFromPool) as P2M_PaiMaiSellResponse; 
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

	[ResponseType(nameof(P2M_PaiMaiShopResponse))]
	[Message(InnerMessage.M2P_PaiMaiShopRequest)]
	[MemoryPackable]
	public partial class M2P_PaiMaiShopRequest: MessageObject, IRequest
	{
		public static M2P_PaiMaiShopRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_PaiMaiShopRequest), isFromPool) as M2P_PaiMaiShopRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ItemID { get; set; }

		[MemoryPackOrder(1)]
		public int BuyNum { get; set; }

		[MemoryPackOrder(2)]
		public int Price { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ItemID = default;
			this.BuyNum = default;
			this.Price = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.P2M_PaiMaiShopResponse)]
	[MemoryPackable]
	public partial class P2M_PaiMaiShopResponse: MessageObject, IResponse
	{
		public static P2M_PaiMaiShopResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_PaiMaiShopResponse), isFromPool) as P2M_PaiMaiShopResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public PaiMaiShopItemInfo PaiMaiShopItemInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PaiMaiShopItemInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(P2M_PaiMaiXiaJiaResponse))]
	[Message(InnerMessage.M2P_PaiMaiXiaJiaRequest)]
	[MemoryPackable]
	public partial class M2P_PaiMaiXiaJiaRequest: MessageObject, IRequest
	{
		public static M2P_PaiMaiXiaJiaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_PaiMaiXiaJiaRequest), isFromPool) as M2P_PaiMaiXiaJiaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int ItemType { get; set; }

		[MemoryPackOrder(1)]
		public long PaiMaiItemInfoId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ItemType = default;
			this.PaiMaiItemInfoId = default;
			this.UnitID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.P2M_PaiMaiXiaJiaResponse)]
	[MemoryPackable]
	public partial class P2M_PaiMaiXiaJiaResponse: MessageObject, IResponse
	{
		public static P2M_PaiMaiXiaJiaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_PaiMaiXiaJiaResponse), isFromPool) as P2M_PaiMaiXiaJiaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(1)]
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

	[ResponseType(nameof(P2M_StallBuyResponse))]
	[Message(InnerMessage.M2P_StallBuyRequest)]
	[MemoryPackable]
	public partial class M2P_StallBuyRequest: MessageObject, IRequest
	{
		public static M2P_StallBuyRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_StallBuyRequest), isFromPool) as M2P_StallBuyRequest; 
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

	[Message(InnerMessage.P2M_StallBuyResponse)]
	[MemoryPackable]
	public partial class P2M_StallBuyResponse: MessageObject, IResponse
	{
		public static P2M_StallBuyResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_StallBuyResponse), isFromPool) as P2M_StallBuyResponse; 
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

	[ResponseType(nameof(P2M_StallSellResponse))]
	[Message(InnerMessage.M2P_StallSellRequest)]
	[MemoryPackable]
	public partial class M2P_StallSellRequest: MessageObject, IRequest
	{
		public static M2P_StallSellRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_StallSellRequest), isFromPool) as M2P_StallSellRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
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

	[Message(InnerMessage.P2M_StallSellResponse)]
	[MemoryPackable]
	public partial class P2M_StallSellResponse: MessageObject, IResponse
	{
		public static P2M_StallSellResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_StallSellResponse), isFromPool) as P2M_StallSellResponse; 
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

	[ResponseType(nameof(P2M_StallXiaJiaResponse))]
	[Message(InnerMessage.M2P_StallXiaJiaRequest)]
	[MemoryPackable]
	public partial class M2P_StallXiaJiaRequest: MessageObject, IRequest
	{
		public static M2P_StallXiaJiaRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2P_StallXiaJiaRequest), isFromPool) as M2P_StallXiaJiaRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long PaiMaiItemInfoId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.PaiMaiItemInfoId = default;
			this.UnitID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.P2M_StallXiaJiaResponse)]
	[MemoryPackable]
	public partial class P2M_StallXiaJiaResponse: MessageObject, IResponse
	{
		public static P2M_StallXiaJiaResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(P2M_StallXiaJiaResponse), isFromPool) as P2M_StallXiaJiaResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(1)]
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

//踢出掉线玩家
	[Message(InnerMessage.G2M_KickPlayerRequest)]
	[MemoryPackable]
	public partial class G2M_KickPlayerRequest: MessageObject, IMessage
	{
		public static G2M_KickPlayerRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2M_KickPlayerRequest), isFromPool) as G2M_KickPlayerRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public long SceneId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitId = default;
			this.SceneId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2G_RechargeResultResponse))]
	[Message(InnerMessage.G2M_RechargeResultRequest)]
	[MemoryPackable]
	public partial class G2M_RechargeResultRequest: MessageObject, IRequest
	{
		public static G2M_RechargeResultRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2M_RechargeResultRequest), isFromPool) as G2M_RechargeResultRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int RechargeNumber { get; set; }

		[MemoryPackOrder(3)]
		public string OrderInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Id = default;
			this.RechargeNumber = default;
			this.OrderInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2G_RechargeResultResponse)]
	[MemoryPackable]
	public partial class M2G_RechargeResultResponse: MessageObject, IResponse
	{
		public static M2G_RechargeResultResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2G_RechargeResultResponse), isFromPool) as M2G_RechargeResultResponse; 
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

	[ResponseType(nameof(M2M_AllPlayerListResponse))]
	[Message(InnerMessage.M2M_AllPlayerListRequest)]
	[MemoryPackable]
	public partial class M2M_AllPlayerListRequest: MessageObject, IRequest
	{
		public static M2M_AllPlayerListRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_AllPlayerListRequest), isFromPool) as M2M_AllPlayerListRequest; 
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

	[Message(InnerMessage.M2M_AllPlayerListResponse)]
	[MemoryPackable]
	public partial class M2M_AllPlayerListResponse: MessageObject, IResponse
	{
		public static M2M_AllPlayerListResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_AllPlayerListResponse), isFromPool) as M2M_AllPlayerListResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<long> AllPlayers { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.AllPlayers.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2Popularize_RewardResponse))]
	[Message(InnerMessage.Popularize2M_RewardRequest)]
	[MemoryPackable]
	public partial class Popularize2M_RewardRequest: MessageObject, IRequest
	{
		public static Popularize2M_RewardRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Popularize2M_RewardRequest), isFromPool) as Popularize2M_RewardRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public List<RewardItem> ReardList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.ReardList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2Popularize_RewardResponse)]
	[MemoryPackable]
	public partial class M2Popularize_RewardResponse: MessageObject, IResponse
	{
		public static M2Popularize_RewardResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2Popularize_RewardResponse), isFromPool) as M2Popularize_RewardResponse; 
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

	[ResponseType(nameof(R2A_DeleteRoleData))]
	[Message(InnerMessage.A2R_DeleteRoleData)]
	[MemoryPackable]
	public partial class A2R_DeleteRoleData: MessageObject, IRequest
	{
		public static A2R_DeleteRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2R_DeleteRoleData), isFromPool) as A2R_DeleteRoleData; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int DeleXuhaoID { get; set; }

		[MemoryPackOrder(2)]
		public long DeleUserID { get; set; }

		[MemoryPackOrder(3)]
		public long AccountId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.DeleXuhaoID = default;
			this.DeleUserID = default;
			this.AccountId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.R2A_DeleteRoleData)]
	[MemoryPackable]
	public partial class R2A_DeleteRoleData: MessageObject, IResponse
	{
		public static R2A_DeleteRoleData Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2A_DeleteRoleData), isFromPool) as R2A_DeleteRoleData; 
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

	[ResponseType(nameof(Rank2G_EnterRank))]
	[Message(InnerMessage.G2Rank_EnterRank)]
	[MemoryPackable]
	public partial class G2Rank_EnterRank: MessageObject, IRequest
	{
		public static G2Rank_EnterRank Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2Rank_EnterRank), isFromPool) as G2Rank_EnterRank; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string Name { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(2)]
		public int Occ { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Name = default;
			this.UnitId = default;
			this.Occ = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.Rank2G_EnterRank)]
	[MemoryPackable]
	public partial class Rank2G_EnterRank: MessageObject, IResponse
	{
		public static Rank2G_EnterRank Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Rank2G_EnterRank), isFromPool) as Rank2G_EnterRank; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int RankId { get; set; }

		[MemoryPackOrder(1)]
		public int PetRankId { get; set; }

		[MemoryPackOrder(2)]
		public int SoloRankId { get; set; }

		[MemoryPackOrder(3)]
		public int TrialRankId { get; set; }

		[MemoryPackOrder(4)]
		public int OccRankId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankId = default;
			this.PetRankId = default;
			this.SoloRankId = default;
			this.TrialRankId = default;
			this.OccRankId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//赛季副本
	[ResponseType(nameof(R2M_RankSeasonTowerResponse))]
	[Message(InnerMessage.M2R_RankSeasonTowerRequest)]
	[MemoryPackable]
	public partial class M2R_RankSeasonTowerRequest: MessageObject, IRequest
	{
		public static M2R_RankSeasonTowerRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RankSeasonTowerRequest), isFromPool) as M2R_RankSeasonTowerRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(1)]
		public KeyValuePairLong RankingInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.RankingInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.R2M_RankSeasonTowerResponse)]
	[MemoryPackable]
	public partial class R2M_RankSeasonTowerResponse: MessageObject, IResponse
	{
		public static R2M_RankSeasonTowerResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankSeasonTowerResponse), isFromPool) as R2M_RankSeasonTowerResponse; 
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

	[ResponseType(nameof(R2M_RankShowLieResponse))]
	[Message(InnerMessage.M2R_RankShowLieRequest)]
	[MemoryPackable]
	public partial class M2R_RankShowLieRequest: MessageObject, IRequest
	{
		public static M2R_RankShowLieRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RankShowLieRequest), isFromPool) as M2R_RankShowLieRequest; 
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

	[Message(InnerMessage.R2M_RankShowLieResponse)]
	[MemoryPackable]
	public partial class R2M_RankShowLieResponse: MessageObject, IResponse
	{
		public static R2M_RankShowLieResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankShowLieResponse), isFromPool) as R2M_RankShowLieResponse; 
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

//试炼副本伤害
	[ResponseType(nameof(R2M_RankTrialResponse))]
	[Message(InnerMessage.M2R_RankTrialRequest)]
	[MemoryPackable]
	public partial class M2R_RankTrialRequest: MessageObject, IRequest
	{
		public static M2R_RankTrialRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RankTrialRequest), isFromPool) as M2R_RankTrialRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int CampId { get; set; }

		[MemoryPackOrder(1)]
		public KeyValuePairLong RankingInfo { get; set; }

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

	[Message(InnerMessage.R2M_RankTrialResponse)]
	[MemoryPackable]
	public partial class R2M_RankTrialResponse: MessageObject, IResponse
	{
		public static R2M_RankTrialResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankTrialResponse), isFromPool) as R2M_RankTrialResponse; 
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

	[ResponseType(nameof(R2M_RankUpdateResponse))]
	[Message(InnerMessage.M2R_RankUpdateRequest)]
	[MemoryPackable]
	public partial class M2R_RankUpdateRequest: MessageObject, IRequest
	{
		public static M2R_RankUpdateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RankUpdateRequest), isFromPool) as M2R_RankUpdateRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public int CampId { get; set; }

		[MemoryPackOrder(1)]
		public RankingInfo RankingInfo { get; set; }

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

	[Message(InnerMessage.R2M_RankUpdateResponse)]
	[MemoryPackable]
	public partial class R2M_RankUpdateResponse: MessageObject, IResponse
	{
		public static R2M_RankUpdateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RankUpdateResponse), isFromPool) as R2M_RankUpdateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int RankId { get; set; }

		[MemoryPackOrder(1)]
		public int PetRankId { get; set; }

		[MemoryPackOrder(2)]
		public int SoloRankId { get; set; }

		[MemoryPackOrder(3)]
		public int OccRankId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankId = default;
			this.PetRankId = default;
			this.SoloRankId = default;
			this.OccRankId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(S2M_SoloMatchResponse))]
	[Message(InnerMessage.M2S_SoloMatchRequest)]
	[MemoryPackable]
	public partial class M2S_SoloMatchRequest: MessageObject, IRequest
	{
		public static M2S_SoloMatchRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2S_SoloMatchRequest), isFromPool) as M2S_SoloMatchRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public SoloPlayerInfo SoloPlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.SoloPlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.S2M_SoloMatchResponse)]
	[MemoryPackable]
	public partial class S2M_SoloMatchResponse: MessageObject, IResponse
	{
		public static S2M_SoloMatchResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(S2M_SoloMatchResponse), isFromPool) as S2M_SoloMatchResponse; 
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

	[ResponseType(nameof(S2M_SoloEnterResponse))]
	[Message(InnerMessage.M2S_SoloEnterRequest)]
	[MemoryPackable]
	public partial class M2S_SoloEnterRequest: MessageObject, IRequest
	{
		public static M2S_SoloEnterRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2S_SoloEnterRequest), isFromPool) as M2S_SoloEnterRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long FubenId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.FubenId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.S2M_SoloEnterResponse)]
	[MemoryPackable]
	public partial class S2M_SoloEnterResponse: MessageObject, IResponse
	{
		public static S2M_SoloEnterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(S2M_SoloEnterResponse), isFromPool) as S2M_SoloEnterResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public long FubenInstanceId { get; set; }

		[MemoryPackOrder(1)]
		public ActorId FubenActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenInstanceId = default;
			this.FubenActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//创建组队副本
	[ResponseType(nameof(T2M_TeamDungeonCreateResponse))]
	[Message(InnerMessage.M2T_TeamDungeonCreateRequest)]
	[MemoryPackable]
	public partial class M2T_TeamDungeonCreateRequest: MessageObject, IRequest
	{
		public static M2T_TeamDungeonCreateRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2T_TeamDungeonCreateRequest), isFromPool) as M2T_TeamDungeonCreateRequest; 
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

	[Message(InnerMessage.T2M_TeamDungeonCreateResponse)]
	[MemoryPackable]
	public partial class T2M_TeamDungeonCreateResponse: MessageObject, IResponse
	{
		public static T2M_TeamDungeonCreateResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2M_TeamDungeonCreateResponse), isFromPool) as T2M_TeamDungeonCreateResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TeamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//开启组队副本
	[ResponseType(nameof(T2M_TeamDungeonOpenResponse))]
	[Message(InnerMessage.M2T_TeamDungeonOpenRequest)]
	[MemoryPackable]
	public partial class M2T_TeamDungeonOpenRequest: MessageObject, IRequest
	{
		public static M2T_TeamDungeonOpenRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2T_TeamDungeonOpenRequest), isFromPool) as M2T_TeamDungeonOpenRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long UserID { get; set; }

		[MemoryPackOrder(2)]
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

	[Message(InnerMessage.T2M_TeamDungeonOpenResponse)]
	[MemoryPackable]
	public partial class T2M_TeamDungeonOpenResponse: MessageObject, IResponse
	{
		public static T2M_TeamDungeonOpenResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2M_TeamDungeonOpenResponse), isFromPool) as T2M_TeamDungeonOpenResponse; 
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
	[ResponseType(nameof(T2M_TeamDungeonPrepareResponse))]
	[Message(InnerMessage.M2T_TeamDungeonPrepareRequest)]
	[MemoryPackable]
	public partial class M2T_TeamDungeonPrepareRequest: MessageObject, IRequest
	{
		public static M2T_TeamDungeonPrepareRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2T_TeamDungeonPrepareRequest), isFromPool) as M2T_TeamDungeonPrepareRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long TeamId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitID { get; set; }

		[MemoryPackOrder(2)]
		public int Prepare { get; set; }

		[MemoryPackOrder(3)]
		public int ErrorCode { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TeamId = default;
			this.UnitID = default;
			this.Prepare = default;
			this.ErrorCode = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.T2M_TeamDungeonPrepareResponse)]
	[MemoryPackable]
	public partial class T2M_TeamDungeonPrepareResponse: MessageObject, IResponse
	{
		public static T2M_TeamDungeonPrepareResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2M_TeamDungeonPrepareResponse), isFromPool) as T2M_TeamDungeonPrepareResponse; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public TeamInfo TeamInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TeamInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//进入组队副本
	[ResponseType(nameof(T2M_TeamDungeonEnterResponse))]
	[Message(InnerMessage.M2T_TeamDungeonEnterRequest)]
	[MemoryPackable]
	public partial class M2T_TeamDungeonEnterRequest: MessageObject, IRequest
	{
		public static M2T_TeamDungeonEnterRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2T_TeamDungeonEnterRequest), isFromPool) as M2T_TeamDungeonEnterRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long TeamId { get; set; }

		[MemoryPackOrder(1)]
		public long UserID { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.TeamId = default;
			this.UserID = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.T2M_TeamDungeonEnterResponse)]
	[MemoryPackable]
	public partial class T2M_TeamDungeonEnterResponse: MessageObject, IResponse
	{
		public static T2M_TeamDungeonEnterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(T2M_TeamDungeonEnterResponse), isFromPool) as T2M_TeamDungeonEnterResponse; 
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

		[MemoryPackOrder(2)]
		public int FubenType { get; set; }

		[MemoryPackOrder(3)]
		public ActorId FubenActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenId = default;
			this.FubenInstanceId = default;
			this.FubenType = default;
			this.FubenActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2A_PetMingChanChuResponse))]
	[Message(InnerMessage.A2M_PetMingChanChuRequest)]
	[MemoryPackable]
	public partial class A2M_PetMingChanChuRequest: MessageObject, IRequest
	{
		public static A2M_PetMingChanChuRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_PetMingChanChuRequest), isFromPool) as A2M_PetMingChanChuRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		[MemoryPackOrder(3)]
		public long ChanChu { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitID = default;
			this.ChanChu = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2A_PetMingChanChuResponse)]
	[MemoryPackable]
	public partial class M2A_PetMingChanChuResponse: MessageObject, IResponse
	{
		public static M2A_PetMingChanChuResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_PetMingChanChuResponse), isFromPool) as M2A_PetMingChanChuResponse; 
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

	[ResponseType(nameof(M2A_PetMingLoginResponse))]
	[Message(InnerMessage.A2M_PetMingLoginRequest)]
	[MemoryPackable]
	public partial class A2M_PetMingLoginRequest: MessageObject, IRequest
	{
		public static A2M_PetMingLoginRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(A2M_PetMingLoginRequest), isFromPool) as A2M_PetMingLoginRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(2)]
		public long UnitID { get; set; }

		[MemoryPackOrder(0)]
		public List<PetMingPlayerInfo> PetMineList { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<KeyValuePairInt> PetMingExtend { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.UnitID = default;
			this.PetMineList.Clear();
			this.PetMingExtend.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2A_PetMingLoginResponse)]
	[MemoryPackable]
	public partial class M2A_PetMingLoginResponse: MessageObject, IResponse
	{
		public static M2A_PetMingLoginResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2A_PetMingLoginResponse), isFromPool) as M2A_PetMingLoginResponse; 
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

//进入家园
	[ResponseType(nameof(J2M_JiaYuanEnterResponse))]
	[Message(InnerMessage.M2J_JiaYuanEnterRequest)]
	[MemoryPackable]
	public partial class M2J_JiaYuanEnterRequest: MessageObject, IRequest
	{
		public static M2J_JiaYuanEnterRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2J_JiaYuanEnterRequest), isFromPool) as M2J_JiaYuanEnterRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long MasterId { get; set; }

		[MemoryPackOrder(1)]
		public long UnitId { get; set; }

		[MemoryPackOrder(3)]
		public int SceneId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.MasterId = default;
			this.UnitId = default;
			this.SceneId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.J2M_JiaYuanEnterResponse)]
	[MemoryPackable]
	public partial class J2M_JiaYuanEnterResponse: MessageObject, IResponse
	{
		public static J2M_JiaYuanEnterResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(J2M_JiaYuanEnterResponse), isFromPool) as J2M_JiaYuanEnterResponse; 
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

		[MemoryPackOrder(2)]
		public ActorId FubenActorId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.FubenId = default;
			this.FubenInstanceId = default;
			this.FubenActorId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.M2M_JiaYuanOperateMessage)]
	[MemoryPackable]
	public partial class M2M_JiaYuanOperateMessage: MessageObject, IMessage
	{
		public static M2M_JiaYuanOperateMessage Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2M_JiaYuanOperateMessage), isFromPool) as M2M_JiaYuanOperateMessage; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public JiaYuanOperate JiaYuanOperate { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.JiaYuanOperate = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2M_RechargeResponse))]
	[Message(InnerMessage.M2R_RechargeRequest)]
	[MemoryPackable]
	public partial class M2R_RechargeRequest: MessageObject, IRequest
	{
		public static M2R_RechargeRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2R_RechargeRequest), isFromPool) as M2R_RechargeRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long UnitId { get; set; }

		[MemoryPackOrder(0)]
		public int RechargeNumber { get; set; }

		[MemoryPackOrder(1)]
		public long PayType { get; set; }

		[MemoryPackOrder(2)]
		public int Zone { get; set; }

		[MemoryPackOrder(3)]
		public string payMessage { get; set; }

		[MemoryPackOrder(4)]
		public string UnitName { get; set; }

		[MemoryPackOrder(5)]
		public string Account { get; set; }

		[MemoryPackOrder(6)]
		public string ClientIp { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			this.RechargeNumber = default;
			this.PayType = default;
			this.Zone = default;
			this.payMessage = default;
			this.UnitName = default;
			this.Account = default;
			this.ClientIp = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.R2M_RechargeResponse)]
	[MemoryPackable]
	public partial class R2M_RechargeResponse: MessageObject, IResponse
	{
		public static R2M_RechargeResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2M_RechargeResponse), isFromPool) as R2M_RechargeResponse; 
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

	[ResponseType(nameof(G2R_RechargeResultResponse))]
	[Message(InnerMessage.R2G_RechargeResultRequest)]
	[MemoryPackable]
	public partial class R2G_RechargeResultRequest: MessageObject, IRequest
	{
		public static R2G_RechargeResultRequest Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2G_RechargeResultRequest), isFromPool) as R2G_RechargeResultRequest; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(92)]
		public long ActorId { get; set; }

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int RechargeNumber { get; set; }

		[MemoryPackOrder(2)]
		public long UserID { get; set; }

		[MemoryPackOrder(3)]
		public string OrderInfo { get; set; }

		[MemoryPackOrder(4)]
		public string CpOrder { get; set; }

		[MemoryPackOrder(5)]
		public int RechargetType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActorId = default;
			this.Id = default;
			this.RechargeNumber = default;
			this.UserID = default;
			this.OrderInfo = default;
			this.CpOrder = default;
			this.RechargetType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(InnerMessage.G2R_RechargeResultResponse)]
	[MemoryPackable]
	public partial class G2R_RechargeResultResponse: MessageObject, IResponse
	{
		public static G2R_RechargeResultResponse Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2R_RechargeResultResponse), isFromPool) as G2R_RechargeResultResponse; 
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
		 public const ushort R2L_LoginAccountRequest = 20023;
		 public const ushort L2R_LoginAccountRequest = 20024;
		 public const ushort L2G_DisconnectGateUnit = 20025;
		 public const ushort G2L_DisconnectGateUnit = 20026;
		 public const ushort G2L_AddLoginRecord = 20027;
		 public const ushort L2G_AddLoginRecord = 20028;
		 public const ushort G2L_RemoveLoginRecord = 20029;
		 public const ushort L2G_RemoveLoginRecord = 20030;
		 public const ushort G2M_SecondLogin = 20031;
		 public const ushort M2G_SecondLogin = 20032;
		 public const ushort G2M_RequestExitGame = 20033;
		 public const ushort M2G_RequestExitGame = 20034;
		 public const ushort M2M_UnitTransferRequest = 20035;
		 public const ushort M2M_UnitTransferResponse = 20036;
		 public const ushort Other2UnitCache_AddOrUpdateUnit = 20037;
		 public const ushort UnitCache2Other_AddOrUpdateUnit = 20038;
		 public const ushort Other2UnitCache_GetUnit = 20039;
		 public const ushort UnitCache2Other_GetUnit = 20040;
		 public const ushort Other2UnitCache_DeleteUnit = 20041;
		 public const ushort UnitCache2Other_DeleteUnit = 20042;
		 public const ushort Other2UnitCache_GetComponent = 20043;
		 public const ushort UnitCache2Other_GetComponent = 20044;
		 public const ushort A2Center_CheckAccount = 20045;
		 public const ushort Center2A_CheckAccount = 20046;
		 public const ushort A2Center_RegisterAccount = 20047;
		 public const ushort Center2A_RegisterAccount = 20048;
		 public const ushort A2L_LoginAccountRequest = 20049;
		 public const ushort L2A_LoginAccountResponse = 20050;
		 public const ushort G2Chat_EnterChat = 20051;
		 public const ushort Chat2G_EnterChat = 20052;
		 public const ushort G2Chat_RequestExitChat = 20053;
		 public const ushort Chat2G_RequestExitChat = 20054;
		 public const ushort M2R_RankUnionRaceRequest = 20055;
		 public const ushort R2M_RankUnionRaceResponse = 20056;
		 public const ushort M2R_PetRankUpdateRequest = 20057;
		 public const ushort R2M_PetRankUpdateResponse = 20058;
		 public const ushort M2A_PetMingBattleWinRequest = 20059;
		 public const ushort A2M_PetMingBattleWinResponse = 20060;
		 public const ushort M2A_PetMingPlayerInfoRequest = 20061;
		 public const ushort A2M_PetMingPlayerInfoResponse = 20062;
		 public const ushort M2A_ActivityFeedRequest = 20063;
		 public const ushort A2M_ActivityFeedResponse = 20064;
		 public const ushort M2A_ActivityGuessRequest = 20065;
		 public const ushort A2M_ActivityGuessResponse = 20066;
		 public const ushort M2A_ActivitySelfInfo = 20067;
		 public const ushort A2M_ActivitySelfInfo = 20068;
		 public const ushort M2A_FirstWinInfoMessage = 20069;
		 public const ushort M2A_MysteryBuyRequest = 20070;
		 public const ushort A2M_MysteryBuyResponse = 20071;
		 public const ushort M2A_TurtleRecordRequest = 20072;
		 public const ushort A2M_TurtleRecordResponse = 20073;
		 public const ushort M2A_TurtleReportRequest = 20074;
		 public const ushort A2M_TurtleReportResponse = 20075;
		 public const ushort M2A_TurtleSupportRequest = 20076;
		 public const ushort A2M_TurtleSupportResponse = 20077;
		 public const ushort M2A_ZhanQuInfoRequest = 20078;
		 public const ushort A2M_ZhanQuInfoResponse = 20079;
		 public const ushort M2A_ZhanQuReceiveRequest = 20080;
		 public const ushort A2M_ZhanQuReceiveResponse = 20081;
		 public const ushort M2E_EMailSendRequest = 20082;
		 public const ushort E2M_EMailSendResponse = 20083;
		 public const ushort A2M_PetMingRecordRequest = 20084;
		 public const ushort M2A_PetMingRecordResponse = 20085;
		 public const ushort Mail2M_SendServerMailItem = 20086;
		 public const ushort A2A_ServerMessageRequest = 20087;
		 public const ushort A2A_ServerMessageRResponse = 20088;
		 public const ushort M2U_DonationRequest = 20089;
		 public const ushort U2M_DonationResponse = 20090;
		 public const ushort M2U_UnionCreateRequest = 20091;
		 public const ushort U2M_UnionCreateResponse = 20092;
		 public const ushort M2Chat_UpdateUnion = 20093;
		 public const ushort Chat2M_UpdateUnion = 20094;
		 public const ushort M2U_UnionOperationRequest = 20095;
		 public const ushort U2M_UnionOperationResponse = 20096;
		 public const ushort M2U_UnionInviteReplyMessage = 20097;
		 public const ushort M2U_UnionKeJiLearnRequest = 20098;
		 public const ushort U2M_UnionKeJiLearnResponse = 20099;
		 public const ushort M2U_UnionLeaveRequest = 20100;
		 public const ushort U2M_UnionLeaveResponse = 20101;
		 public const ushort M2U_UnionMysteryBuyRequest = 20102;
		 public const ushort U2M_UnionMysteryBuyResponse = 20103;
		 public const ushort M2U_UnionTransferRequest = 20104;
		 public const ushort U2M_UnionTransferResponse = 20105;
		 public const ushort U2M_UnionApplyRequest = 20106;
		 public const ushort M2U_UnionApplyResponse = 20107;
		 public const ushort T2G_GateUnitInfoRequest = 20108;
		 public const ushort G2T_GateUnitInfoResponse = 20109;
		 public const ushort U2M_UnionKeJiQuickRequest = 20110;
		 public const ushort M2U_UnionKeJiQuickResponse = 20111;
		 public const ushort U2M_UnionKickOutRequest = 20112;
		 public const ushort M2U_UnionKickOutResponse = 20113;
		 public const ushort M2M_UnionTransferMessage = 20114;
		 public const ushort G2Union_EnterUnion = 20115;
		 public const ushort Union2G_EnterUnion = 20116;
		 public const ushort M2U_UnionEnterRequest = 20117;
		 public const ushort U2M_UnionEnterResponse = 20118;
		 public const ushort A2A_ActivityUpdateRequest = 20119;
		 public const ushort A2A_ActivityUpdateResponse = 20120;
		 public const ushort G2M_ActivityUpdate = 20121;
		 public const ushort M2C_HappyInfoResult = 20122;
		 public const ushort R2F_WorldLvUpdateRequest = 20123;
		 public const ushort F2R_WorldLvUpdateResponse = 20124;
		 public const ushort A2A_BroadcastRequest = 20125;
		 public const ushort A2A_BroadcastResponse = 20126;
		 public const ushort G2Robot_MessageRequest = 20127;
		 public const ushort M2LocalDungeon_ExitRequest = 20128;
		 public const ushort LocalDungeon2M_ExitResponse = 20129;
		 public const ushort P2M_PaiMaiAuctionOverRequest = 20130;
		 public const ushort M2P_PaiMaiAuctionOverResponse = 20131;
		 public const ushort P2E_PaiMaiOverTimeRequest = 20132;
		 public const ushort E2P_PaiMaiOverTimeResponse = 20133;
		 public const ushort S2R_SoloResultRequest = 20134;
		 public const ushort R2S_SoloResultResponse = 20135;
		 public const ushort M2R_RankRunRaceRequest = 20136;
		 public const ushort R2M_RankRunRaceResponse = 20137;
		 public const ushort M2R_RankDemonRequest = 20138;
		 public const ushort R2M_RankDemonResponse = 20139;
		 public const ushort T2M_TeamUpdateRequest = 20140;
		 public const ushort A2Center_RechargeRequest = 20141;
		 public const ushort Center2A_RechargeResponse = 20142;
		 public const ushort A2Center_SaveAccount = 20143;
		 public const ushort Center2A_SaveAccount = 20144;
		 public const ushort C2C_CenterServerInfoReuest = 20145;
		 public const ushort C2C_CenterServerInfoRespone = 20146;
		 public const ushort C2Center_DeleteAccountRequest = 20147;
		 public const ushort Center2C_DeleteAccountResponse = 20148;
		 public const ushort M2Center_SerialReardRequest = 20149;
		 public const ushort Center2M_SerialReardResponse = 20150;
		 public const ushort M2Center_ShareSucessRequest = 20151;
		 public const ushort Center2M_ShareSucessResponse = 20152;
		 public const ushort C2T_GetTeamInfoRequest = 20153;
		 public const ushort T2C_GetTeamInfoResponse = 20154;
		 public const ushort M2Chat_UpdateLevel = 20155;
		 public const ushort Chat2M_UpdateLevel = 20156;
		 public const ushort Mail2Chat_GetUnitList = 20157;
		 public const ushort Chat2Mail_GetUnitList = 20158;
		 public const ushort G2Mail_EnterMail = 20159;
		 public const ushort Mail2G_EnterMail = 20160;
		 public const ushort M2E_EMailReceiveRequest = 20161;
		 public const ushort E2M_EMailReceiveResponse = 20162;
		 public const ushort M2C_UpdateMailInfo = 20163;
		 public const ushort M2F_FubenCenterListRequest = 20164;
		 public const ushort F2M_FubenCenterListResponse = 20165;
		 public const ushort M2F_FubenCenterOperateRequest = 20166;
		 public const ushort F2M_FubenCenterOpenResponse = 20167;
		 public const ushort M2F_FubenSceneIdRequest = 20168;
		 public const ushort F2M_FubenSceneIdResponse = 20169;
		 public const ushort F2M_ServerInfoUpdateRequest = 20170;
		 public const ushort M2F_ServerInfoUpdateResponse = 20171;
		 public const ushort M2P_PaiMaiAuctionJoinRequest = 20172;
		 public const ushort P2M_PaiMaiAuctionJoinResponse = 20173;
		 public const ushort M2P_PaiMaiAuctionPriceRequest = 20174;
		 public const ushort P2M_PaiMaiAuctionPriceResponse = 20175;
		 public const ushort M2P_PaiMaiBuyRequest = 20176;
		 public const ushort P2M_PaiMaiBuyResponse = 20177;
		 public const ushort M2M_PaiMaiBuyInfoRequest = 20178;
		 public const ushort M2M_PaiMaiBuyInfoResponse = 20179;
		 public const ushort M2R_DBServerInfoRequest = 20180;
		 public const ushort R2M_DBServerInfoResponse = 20181;
		 public const ushort M2P_PaiMaiSellRequest = 20182;
		 public const ushort P2M_PaiMaiSellResponse = 20183;
		 public const ushort M2P_PaiMaiShopRequest = 20184;
		 public const ushort P2M_PaiMaiShopResponse = 20185;
		 public const ushort M2P_PaiMaiXiaJiaRequest = 20186;
		 public const ushort P2M_PaiMaiXiaJiaResponse = 20187;
		 public const ushort M2P_StallBuyRequest = 20188;
		 public const ushort P2M_StallBuyResponse = 20189;
		 public const ushort M2P_StallSellRequest = 20190;
		 public const ushort P2M_StallSellResponse = 20191;
		 public const ushort M2P_StallXiaJiaRequest = 20192;
		 public const ushort P2M_StallXiaJiaResponse = 20193;
		 public const ushort G2M_KickPlayerRequest = 20194;
		 public const ushort G2M_RechargeResultRequest = 20195;
		 public const ushort M2G_RechargeResultResponse = 20196;
		 public const ushort M2M_AllPlayerListRequest = 20197;
		 public const ushort M2M_AllPlayerListResponse = 20198;
		 public const ushort Popularize2M_RewardRequest = 20199;
		 public const ushort M2Popularize_RewardResponse = 20200;
		 public const ushort A2R_DeleteRoleData = 20201;
		 public const ushort R2A_DeleteRoleData = 20202;
		 public const ushort G2Rank_EnterRank = 20203;
		 public const ushort Rank2G_EnterRank = 20204;
		 public const ushort M2R_RankSeasonTowerRequest = 20205;
		 public const ushort R2M_RankSeasonTowerResponse = 20206;
		 public const ushort M2R_RankShowLieRequest = 20207;
		 public const ushort R2M_RankShowLieResponse = 20208;
		 public const ushort M2R_RankTrialRequest = 20209;
		 public const ushort R2M_RankTrialResponse = 20210;
		 public const ushort M2R_RankUpdateRequest = 20211;
		 public const ushort R2M_RankUpdateResponse = 20212;
		 public const ushort M2S_SoloMatchRequest = 20213;
		 public const ushort S2M_SoloMatchResponse = 20214;
		 public const ushort M2S_SoloEnterRequest = 20215;
		 public const ushort S2M_SoloEnterResponse = 20216;
		 public const ushort M2T_TeamDungeonCreateRequest = 20217;
		 public const ushort T2M_TeamDungeonCreateResponse = 20218;
		 public const ushort M2T_TeamDungeonOpenRequest = 20219;
		 public const ushort T2M_TeamDungeonOpenResponse = 20220;
		 public const ushort M2T_TeamDungeonPrepareRequest = 20221;
		 public const ushort T2M_TeamDungeonPrepareResponse = 20222;
		 public const ushort M2T_TeamDungeonEnterRequest = 20223;
		 public const ushort T2M_TeamDungeonEnterResponse = 20224;
		 public const ushort A2M_PetMingChanChuRequest = 20225;
		 public const ushort M2A_PetMingChanChuResponse = 20226;
		 public const ushort A2M_PetMingLoginRequest = 20227;
		 public const ushort M2A_PetMingLoginResponse = 20228;
		 public const ushort M2J_JiaYuanEnterRequest = 20229;
		 public const ushort J2M_JiaYuanEnterResponse = 20230;
		 public const ushort M2M_JiaYuanOperateMessage = 20231;
		 public const ushort M2R_RechargeRequest = 20232;
		 public const ushort R2M_RechargeResponse = 20233;
		 public const ushort R2G_RechargeResultRequest = 20234;
		 public const ushort G2R_RechargeResultResponse = 20235;
	}
}
