using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"DOTween.dll",
		"MemoryPack.dll",
		"MongoDB.Bson.dll",
		"System.Core.dll",
		"System.Runtime.CompilerServices.Unsafe.dll",
		"System.dll",
		"Unity.Core.dll",
		"Unity.ThirdParty.dll",
		"UnityEngine.AndroidJNIModule.dll",
		"UnityEngine.CoreModule.dll",
		"UnityEngine.UI.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// ET.AEvent<object,ET.ChangePosition>
	// ET.AEvent<object,ET.ChangeRotation>
	// ET.AEvent<object,ET.Client.AfterCreateClientScene>
	// ET.AEvent<object,ET.Client.AfterCreateCurrentScene>
	// ET.AEvent<object,ET.Client.AfterUnitCreate>
	// ET.AEvent<object,ET.Client.AppStartInitFinish>
	// ET.AEvent<object,ET.Client.BeforeSkill>
	// ET.AEvent<object,ET.Client.BuffScale>
	// ET.AEvent<object,ET.Client.BuffUpdate>
	// ET.AEvent<object,ET.Client.ChangeCameraMoveType>
	// ET.AEvent<object,ET.Client.DataUpdate_BagItemUpdate>
	// ET.AEvent<object,ET.Client.DataUpdate_BeforeMove>
	// ET.AEvent<object,ET.Client.DataUpdate_ChouKaWarehouseAddItem>
	// ET.AEvent<object,ET.Client.DataUpdate_EquipHuiShow>
	// ET.AEvent<object,ET.Client.DataUpdate_EquipWear>
	// ET.AEvent<object,ET.Client.DataUpdate_FriendChat>
	// ET.AEvent<object,ET.Client.DataUpdate_FriendUpdate>
	// ET.AEvent<object,ET.Client.DataUpdate_HuiShouSelect>
	// ET.AEvent<object,ET.Client.DataUpdate_JingLingButton>
	// ET.AEvent<object,ET.Client.DataUpdate_MainHeroMove>
	// ET.AEvent<object,ET.Client.DataUpdate_OnAccountWarehous>
	// ET.AEvent<object,ET.Client.DataUpdate_OnActiveTianFu>
	// ET.AEvent<object,ET.Client.DataUpdate_OnMailUpdate>
	// ET.AEvent<object,ET.Client.DataUpdate_OnRecvChat>
	// ET.AEvent<object,ET.Client.DataUpdate_PetHeChengUpdate>
	// ET.AEvent<object,ET.Client.DataUpdate_PetItemSelect>
	// ET.AEvent<object,ET.Client.DataUpdate_PetXiLianUpdate>
	// ET.AEvent<object,ET.Client.DataUpdate_SettingUpdate>
	// ET.AEvent<object,ET.Client.DataUpdate_SkillReset>
	// ET.AEvent<object,ET.Client.DataUpdate_SkillSetting>
	// ET.AEvent<object,ET.Client.DataUpdate_SkillUpgrade>
	// ET.AEvent<object,ET.Client.DataUpdate_TaskComplete>
	// ET.AEvent<object,ET.Client.DataUpdate_TaskGet>
	// ET.AEvent<object,ET.Client.DataUpdate_TaskTrace>
	// ET.AEvent<object,ET.Client.DataUpdate_UpdateRoleProper>
	// ET.AEvent<object,ET.Client.DataUpdate_UpdateUserData>
	// ET.AEvent<object,ET.Client.EnterMapFinish>
	// ET.AEvent<object,ET.Client.FsmChange>
	// ET.AEvent<object,ET.Client.LSSceneChangeStart>
	// ET.AEvent<object,ET.Client.LSSceneInitFinish>
	// ET.AEvent<object,ET.Client.LoginFinish>
	// ET.AEvent<object,ET.Client.Now_Hp_Update>
	// ET.AEvent<object,ET.Client.OnSkillUse>
	// ET.AEvent<object,ET.Client.PlayAnimator>
	// ET.AEvent<object,ET.Client.ReddotChange>
	// ET.AEvent<object,ET.Client.ReturnLogin>
	// ET.AEvent<object,ET.Client.RoleDataBroadcase>
	// ET.AEvent<object,ET.Client.RolePetAdd>
	// ET.AEvent<object,ET.Client.RolePetUpdate>
	// ET.AEvent<object,ET.Client.SceneChangeFinish>
	// ET.AEvent<object,ET.Client.SceneChangeStart>
	// ET.AEvent<object,ET.Client.ShowFlyTip>
	// ET.AEvent<object,ET.Client.ShowItemTips>
	// ET.AEvent<object,ET.Client.SingingUpdate>
	// ET.AEvent<object,ET.Client.SkillBeging>
	// ET.AEvent<object,ET.Client.SkillCDUpdate>
	// ET.AEvent<object,ET.Client.SkillEffect>
	// ET.AEvent<object,ET.Client.SkillEffectFinish>
	// ET.AEvent<object,ET.Client.SkillEffectMove>
	// ET.AEvent<object,ET.Client.SkillEffectReset>
	// ET.AEvent<object,ET.Client.SkillFinish>
	// ET.AEvent<object,ET.Client.SkillSound>
	// ET.AEvent<object,ET.Client.SkillYuJing>
	// ET.AEvent<object,ET.Client.TaskNpcDialog>
	// ET.AEvent<object,ET.Client.TaskTypeItemClick>
	// ET.AEvent<object,ET.Client.UnitDead>
	// ET.AEvent<object,ET.Client.UserDataTypeUpdate_Diamond>
	// ET.AEvent<object,ET.Client.UserDataTypeUpdate_Gold>
	// ET.AEvent<object,ET.EntryEvent1>
	// ET.AEvent<object,ET.EntryEvent3>
	// ET.AEvent<object,ET.MoveStart>
	// ET.AEvent<object,ET.MoveStop>
	// ET.AEvent<object,ET.NumbericChange>
	// ET.AInvokeHandler<ET.FiberInit,object>
	// ET.AInvokeHandler<ET.MailBoxInvoker>
	// ET.AInvokeHandler<ET.NetComponentOnRead>
	// ET.AInvokeHandler<ET.TimerCallback>
	// ET.AwakeSystem<object,int,int>
	// ET.AwakeSystem<object,int,object>
	// ET.AwakeSystem<object,int>
	// ET.AwakeSystem<object,object,int>
	// ET.AwakeSystem<object,object,object>
	// ET.AwakeSystem<object,object>
	// ET.AwakeSystem<object>
	// ET.DestroySystem<object>
	// ET.DoubleMap<object,long>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>
	// ET.ETAsyncTaskMethodBuilder<System.ValueTuple<int,int>>
	// ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>
	// ET.ETAsyncTaskMethodBuilder<byte>
	// ET.ETAsyncTaskMethodBuilder<int>
	// ET.ETAsyncTaskMethodBuilder<long>
	// ET.ETAsyncTaskMethodBuilder<object>
	// ET.ETAsyncTaskMethodBuilder<uint>
	// ET.ETTask<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETTask<ET.Client.Wait_CreateMyUnit>
	// ET.ETTask<ET.Client.Wait_SceneChangeFinish>
	// ET.ETTask<ET.Client.Wait_UnitStop>
	// ET.ETTask<System.ValueTuple<int,int>>
	// ET.ETTask<System.ValueTuple<uint,object>>
	// ET.ETTask<byte>
	// ET.ETTask<int>
	// ET.ETTask<long>
	// ET.ETTask<object>
	// ET.ETTask<uint>
	// ET.EntityRef<object>
	// ET.IAwake<int,int>
	// ET.IAwake<int,object>
	// ET.IAwake<int>
	// ET.IAwake<object,int>
	// ET.IAwake<object,object,object>
	// ET.IAwake<object,object>
	// ET.IAwake<object>
	// ET.IAwakeSystem<int,int>
	// ET.IAwakeSystem<int,object>
	// ET.IAwakeSystem<int>
	// ET.IAwakeSystem<object,int>
	// ET.IAwakeSystem<object,object,object>
	// ET.IAwakeSystem<object,object>
	// ET.IAwakeSystem<object>
	// ET.LateUpdateSystem<object>
	// ET.ListComponent<Unity.Mathematics.float3>
	// ET.ListComponent<object>
	// ET.MultiDictionary<int,int,int>
	// ET.Singleton<object>
	// ET.StateMachineWrap<object>
	// ET.StructBsonSerialize<ET.LSInput>
	// ET.StructBsonSerialize<TrueSync.FP>
	// ET.StructBsonSerialize<TrueSync.TSQuaternion>
	// ET.StructBsonSerialize<TrueSync.TSVector2>
	// ET.StructBsonSerialize<TrueSync.TSVector4>
	// ET.StructBsonSerialize<TrueSync.TSVector>
	// ET.StructBsonSerialize<Unity.Mathematics.float2>
	// ET.StructBsonSerialize<Unity.Mathematics.float3>
	// ET.StructBsonSerialize<Unity.Mathematics.float4>
	// ET.StructBsonSerialize<Unity.Mathematics.quaternion>
	// ET.StructBsonSerialize<object>
	// ET.UnOrderMultiMap<object,object>
	// ET.UpdateSystem<object>
	// MemoryPack.Formatters.ArrayFormatter<ET.LSInput>
	// MemoryPack.Formatters.ArrayFormatter<byte>
	// MemoryPack.Formatters.ArrayFormatter<object>
	// MemoryPack.Formatters.DictionaryFormatter<int,long>
	// MemoryPack.Formatters.DictionaryFormatter<long,ET.LSInput>
	// MemoryPack.Formatters.ListFormatter<Unity.Mathematics.float3>
	// MemoryPack.Formatters.ListFormatter<float>
	// MemoryPack.Formatters.ListFormatter<int>
	// MemoryPack.Formatters.ListFormatter<long>
	// MemoryPack.Formatters.ListFormatter<object>
	// MemoryPack.IMemoryPackFormatter<Unity.Mathematics.float3>
	// MemoryPack.IMemoryPackFormatter<byte>
	// MemoryPack.IMemoryPackFormatter<float>
	// MemoryPack.IMemoryPackFormatter<int>
	// MemoryPack.IMemoryPackFormatter<long>
	// MemoryPack.IMemoryPackFormatter<object>
	// MemoryPack.IMemoryPackable<ET.LSInput>
	// MemoryPack.IMemoryPackable<object>
	// MemoryPack.MemoryPackFormatter<ET.LSInput>
	// MemoryPack.MemoryPackFormatter<System.UIntPtr>
	// MemoryPack.MemoryPackFormatter<object>
	// MongoDB.Bson.Serialization.IBsonSerializer<object>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<ET.LSInput>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<object>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<ET.LSInput>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<object>
	// System.Action<DotRecast.Detour.StraightPathItem>
	// System.Action<ET.ActivityTipConfig>
	// System.Action<ET.BuyCellCost>
	// System.Action<ET.Client.RolePetAdd>
	// System.Action<ET.DayJingLing>
	// System.Action<ET.DayMonsters>
	// System.Action<ET.DropItemInfo>
	// System.Action<ET.EquipChuanChengList>
	// System.Action<ET.JiaYuanPurchase>
	// System.Action<ET.PetMiningItem>
	// System.Action<ET.PropertyValue>
	// System.Action<ET.TypeButtonItem>
	// System.Action<ET.WorldSayConfig>
	// System.Action<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Action<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Action<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Action<System.ValueTuple<int,int>>
	// System.Action<Unity.Mathematics.float3>
	// System.Action<UnityEngine.CombineInstance>
	// System.Action<UnityEngine.EventSystems.RaycastResult>
	// System.Action<UnityEngine.Vector2>
	// System.Action<UnityEngine.Vector3>
	// System.Action<byte>
	// System.Action<float>
	// System.Action<int,int>
	// System.Action<int,object>
	// System.Action<int>
	// System.Action<long,int,int>
	// System.Action<long,int>
	// System.Action<long,object>
	// System.Action<long>
	// System.Action<object,int>
	// System.Action<object,long>
	// System.Action<object,object>
	// System.Action<object>
	// System.ArraySegment.Enumerator<byte>
	// System.ArraySegment<byte>
	// System.ByReference<byte>
	// System.Collections.Concurrent.ConcurrentDictionary.<GetEnumerator>d__35<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.DictionaryEnumerator<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Node<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Tables<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary<object,object>
	// System.Collections.Concurrent.ConcurrentQueue.<Enumerate>d__28<object>
	// System.Collections.Concurrent.ConcurrentQueue.Segment<object>
	// System.Collections.Concurrent.ConcurrentQueue<object>
	// System.Collections.Generic.ArraySortHelper<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ArraySortHelper<ET.ActivityTipConfig>
	// System.Collections.Generic.ArraySortHelper<ET.BuyCellCost>
	// System.Collections.Generic.ArraySortHelper<ET.Client.RolePetAdd>
	// System.Collections.Generic.ArraySortHelper<ET.DayJingLing>
	// System.Collections.Generic.ArraySortHelper<ET.DayMonsters>
	// System.Collections.Generic.ArraySortHelper<ET.DropItemInfo>
	// System.Collections.Generic.ArraySortHelper<ET.EquipChuanChengList>
	// System.Collections.Generic.ArraySortHelper<ET.JiaYuanPurchase>
	// System.Collections.Generic.ArraySortHelper<ET.PetMiningItem>
	// System.Collections.Generic.ArraySortHelper<ET.PropertyValue>
	// System.Collections.Generic.ArraySortHelper<ET.TypeButtonItem>
	// System.Collections.Generic.ArraySortHelper<ET.WorldSayConfig>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ArraySortHelper<System.ValueTuple<int,int>>
	// System.Collections.Generic.ArraySortHelper<Unity.Mathematics.float3>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.CombineInstance>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.Vector2>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.Vector3>
	// System.Collections.Generic.ArraySortHelper<float>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<long>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.Comparer<ET.ActivityTipConfig>
	// System.Collections.Generic.Comparer<ET.ActorId>
	// System.Collections.Generic.Comparer<ET.BuyCellCost>
	// System.Collections.Generic.Comparer<ET.Client.RolePetAdd>
	// System.Collections.Generic.Comparer<ET.DayJingLing>
	// System.Collections.Generic.Comparer<ET.DayMonsters>
	// System.Collections.Generic.Comparer<ET.DropItemInfo>
	// System.Collections.Generic.Comparer<ET.EquipChuanChengList>
	// System.Collections.Generic.Comparer<ET.JiaYuanPurchase>
	// System.Collections.Generic.Comparer<ET.PetMiningItem>
	// System.Collections.Generic.Comparer<ET.PropertyValue>
	// System.Collections.Generic.Comparer<ET.TypeButtonItem>
	// System.Collections.Generic.Comparer<ET.WorldSayConfig>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.Comparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.Comparer<Unity.Mathematics.float3>
	// System.Collections.Generic.Comparer<UnityEngine.CombineInstance>
	// System.Collections.Generic.Comparer<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.Comparer<UnityEngine.Vector2>
	// System.Collections.Generic.Comparer<UnityEngine.Vector3>
	// System.Collections.Generic.Comparer<float>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<long>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Comparer<uint>
	// System.Collections.Generic.Comparer<ushort>
	// System.Collections.Generic.ComparisonComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ComparisonComparer<ET.ActivityTipConfig>
	// System.Collections.Generic.ComparisonComparer<ET.ActorId>
	// System.Collections.Generic.ComparisonComparer<ET.BuyCellCost>
	// System.Collections.Generic.ComparisonComparer<ET.Client.RolePetAdd>
	// System.Collections.Generic.ComparisonComparer<ET.DayJingLing>
	// System.Collections.Generic.ComparisonComparer<ET.DayMonsters>
	// System.Collections.Generic.ComparisonComparer<ET.DropItemInfo>
	// System.Collections.Generic.ComparisonComparer<ET.EquipChuanChengList>
	// System.Collections.Generic.ComparisonComparer<ET.JiaYuanPurchase>
	// System.Collections.Generic.ComparisonComparer<ET.PetMiningItem>
	// System.Collections.Generic.ComparisonComparer<ET.PropertyValue>
	// System.Collections.Generic.ComparisonComparer<ET.TypeButtonItem>
	// System.Collections.Generic.ComparisonComparer<ET.WorldSayConfig>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ComparisonComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.ComparisonComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ComparisonComparer<UnityEngine.CombineInstance>
	// System.Collections.Generic.ComparisonComparer<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.ComparisonComparer<UnityEngine.Vector2>
	// System.Collections.Generic.ComparisonComparer<UnityEngine.Vector3>
	// System.Collections.Generic.ComparisonComparer<float>
	// System.Collections.Generic.ComparisonComparer<int>
	// System.Collections.Generic.ComparisonComparer<long>
	// System.Collections.Generic.ComparisonComparer<object>
	// System.Collections.Generic.ComparisonComparer<uint>
	// System.Collections.Generic.ComparisonComparer<ushort>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.Client.NumericAttribute>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.Enumerator<int,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.Enumerator<int,float>
	// System.Collections.Generic.Dictionary.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.Enumerator<long,long>
	// System.Collections.Generic.Dictionary.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.Dictionary.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.Client.NumericAttribute>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,float>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.Client.NumericAttribute>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection<int,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.KeyCollection<int,float>
	// System.Collections.Generic.Dictionary.KeyCollection<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.KeyCollection<long,long>
	// System.Collections.Generic.Dictionary.KeyCollection<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.Dictionary.KeyCollection<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.Client.NumericAttribute>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,float>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.Client.NumericAttribute>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection<int,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.ValueCollection<int,float>
	// System.Collections.Generic.Dictionary.ValueCollection<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.ValueCollection<long,long>
	// System.Collections.Generic.Dictionary.ValueCollection<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.Dictionary.ValueCollection<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<ushort,object>
	// System.Collections.Generic.Dictionary<int,ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.Dictionary<int,ET.Client.NumericAttribute>
	// System.Collections.Generic.Dictionary<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary<int,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary<int,float>
	// System.Collections.Generic.Dictionary<int,int>
	// System.Collections.Generic.Dictionary<int,long>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<long,ET.LSInput>
	// System.Collections.Generic.Dictionary<long,long>
	// System.Collections.Generic.Dictionary<long,object>
	// System.Collections.Generic.Dictionary<object,ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.Dictionary<object,int>
	// System.Collections.Generic.Dictionary<object,long>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.Dictionary<ushort,object>
	// System.Collections.Generic.EqualityComparer<ET.ActorId>
	// System.Collections.Generic.EqualityComparer<ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.EqualityComparer<ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.EqualityComparer<ET.Client.NumericAttribute>
	// System.Collections.Generic.EqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.EqualityComparer<ET.LSInput>
	// System.Collections.Generic.EqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.EqualityComparer<UnityEngine.Vector3>
	// System.Collections.Generic.EqualityComparer<float>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<long>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.EqualityComparer<uint>
	// System.Collections.Generic.EqualityComparer<ushort>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet.Enumerator<ushort>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.HashSet<ushort>
	// System.Collections.Generic.HashSetEqualityComparer<object>
	// System.Collections.Generic.HashSetEqualityComparer<ushort>
	// System.Collections.Generic.ICollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ICollection<ET.ActivityTipConfig>
	// System.Collections.Generic.ICollection<ET.BuyCellCost>
	// System.Collections.Generic.ICollection<ET.Client.RolePetAdd>
	// System.Collections.Generic.ICollection<ET.DayJingLing>
	// System.Collections.Generic.ICollection<ET.DayMonsters>
	// System.Collections.Generic.ICollection<ET.DropItemInfo>
	// System.Collections.Generic.ICollection<ET.EquipChuanChengList>
	// System.Collections.Generic.ICollection<ET.JiaYuanPurchase>
	// System.Collections.Generic.ICollection<ET.PetMiningItem>
	// System.Collections.Generic.ICollection<ET.PropertyValue>
	// System.Collections.Generic.ICollection<ET.RpcInfo>
	// System.Collections.Generic.ICollection<ET.TypeButtonItem>
	// System.Collections.Generic.ICollection<ET.WorldSayConfig>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.Client.ItemViewData.EquipWeiZhiInfo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.Client.NumericAttribute>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,UnityEngine.Vector3>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,float>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,ET.Client.GameSettingLanguge.LangugeType>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.ICollection<System.ValueTuple<int,int>>
	// System.Collections.Generic.ICollection<Unity.Mathematics.float3>
	// System.Collections.Generic.ICollection<UnityEngine.CombineInstance>
	// System.Collections.Generic.ICollection<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.ICollection<UnityEngine.Vector2>
	// System.Collections.Generic.ICollection<UnityEngine.Vector3>
	// System.Collections.Generic.ICollection<float>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<long>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.ICollection<ushort>
	// System.Collections.Generic.IComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IComparer<ET.ActivityTipConfig>
	// System.Collections.Generic.IComparer<ET.BuyCellCost>
	// System.Collections.Generic.IComparer<ET.Client.RolePetAdd>
	// System.Collections.Generic.IComparer<ET.DayJingLing>
	// System.Collections.Generic.IComparer<ET.DayMonsters>
	// System.Collections.Generic.IComparer<ET.DropItemInfo>
	// System.Collections.Generic.IComparer<ET.EquipChuanChengList>
	// System.Collections.Generic.IComparer<ET.JiaYuanPurchase>
	// System.Collections.Generic.IComparer<ET.PetMiningItem>
	// System.Collections.Generic.IComparer<ET.PropertyValue>
	// System.Collections.Generic.IComparer<ET.TypeButtonItem>
	// System.Collections.Generic.IComparer<ET.WorldSayConfig>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.IComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.IComparer<UnityEngine.CombineInstance>
	// System.Collections.Generic.IComparer<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IComparer<UnityEngine.Vector2>
	// System.Collections.Generic.IComparer<UnityEngine.Vector3>
	// System.Collections.Generic.IComparer<float>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<long>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerable<ET.ActivityTipConfig>
	// System.Collections.Generic.IEnumerable<ET.BuyCellCost>
	// System.Collections.Generic.IEnumerable<ET.Client.RolePetAdd>
	// System.Collections.Generic.IEnumerable<ET.DayJingLing>
	// System.Collections.Generic.IEnumerable<ET.DayMonsters>
	// System.Collections.Generic.IEnumerable<ET.DropItemInfo>
	// System.Collections.Generic.IEnumerable<ET.EquipChuanChengList>
	// System.Collections.Generic.IEnumerable<ET.JiaYuanPurchase>
	// System.Collections.Generic.IEnumerable<ET.PetMiningItem>
	// System.Collections.Generic.IEnumerable<ET.PropertyValue>
	// System.Collections.Generic.IEnumerable<ET.RpcInfo>
	// System.Collections.Generic.IEnumerable<ET.TypeButtonItem>
	// System.Collections.Generic.IEnumerable<ET.WorldSayConfig>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.Client.ItemViewData.EquipWeiZhiInfo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.Client.NumericAttribute>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,UnityEngine.Vector3>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,float>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,ET.Client.GameSettingLanguge.LangugeType>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerable<System.ValueTuple<int,int>>
	// System.Collections.Generic.IEnumerable<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerable<UnityEngine.CombineInstance>
	// System.Collections.Generic.IEnumerable<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IEnumerable<UnityEngine.Vector2>
	// System.Collections.Generic.IEnumerable<UnityEngine.Vector3>
	// System.Collections.Generic.IEnumerable<float>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<long>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerable<ushort>
	// System.Collections.Generic.IEnumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerator<ET.ActivityTipConfig>
	// System.Collections.Generic.IEnumerator<ET.BuyCellCost>
	// System.Collections.Generic.IEnumerator<ET.Client.RolePetAdd>
	// System.Collections.Generic.IEnumerator<ET.DayJingLing>
	// System.Collections.Generic.IEnumerator<ET.DayMonsters>
	// System.Collections.Generic.IEnumerator<ET.DropItemInfo>
	// System.Collections.Generic.IEnumerator<ET.EquipChuanChengList>
	// System.Collections.Generic.IEnumerator<ET.JiaYuanPurchase>
	// System.Collections.Generic.IEnumerator<ET.PetMiningItem>
	// System.Collections.Generic.IEnumerator<ET.PropertyValue>
	// System.Collections.Generic.IEnumerator<ET.RpcInfo>
	// System.Collections.Generic.IEnumerator<ET.TypeButtonItem>
	// System.Collections.Generic.IEnumerator<ET.WorldSayConfig>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.Client.ItemViewData.EquipWeiZhiInfo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.Client.NumericAttribute>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,UnityEngine.Vector3>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,float>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,ET.Client.GameSettingLanguge.LangugeType>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerator<System.ValueTuple<int,int>>
	// System.Collections.Generic.IEnumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerator<UnityEngine.CombineInstance>
	// System.Collections.Generic.IEnumerator<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IEnumerator<UnityEngine.Vector2>
	// System.Collections.Generic.IEnumerator<UnityEngine.Vector3>
	// System.Collections.Generic.IEnumerator<float>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<long>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEnumerator<ushort>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<long>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IEqualityComparer<ushort>
	// System.Collections.Generic.IList<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IList<ET.ActivityTipConfig>
	// System.Collections.Generic.IList<ET.BuyCellCost>
	// System.Collections.Generic.IList<ET.Client.RolePetAdd>
	// System.Collections.Generic.IList<ET.DayJingLing>
	// System.Collections.Generic.IList<ET.DayMonsters>
	// System.Collections.Generic.IList<ET.DropItemInfo>
	// System.Collections.Generic.IList<ET.EquipChuanChengList>
	// System.Collections.Generic.IList<ET.JiaYuanPurchase>
	// System.Collections.Generic.IList<ET.PetMiningItem>
	// System.Collections.Generic.IList<ET.PropertyValue>
	// System.Collections.Generic.IList<ET.TypeButtonItem>
	// System.Collections.Generic.IList<ET.WorldSayConfig>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IList<System.ValueTuple<int,int>>
	// System.Collections.Generic.IList<Unity.Mathematics.float3>
	// System.Collections.Generic.IList<UnityEngine.CombineInstance>
	// System.Collections.Generic.IList<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IList<UnityEngine.Vector2>
	// System.Collections.Generic.IList<UnityEngine.Vector3>
	// System.Collections.Generic.IList<float>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<long>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<int,ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.KeyValuePair<int,ET.Client.NumericAttribute>
	// System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>
	// System.Collections.Generic.KeyValuePair<int,UnityEngine.Vector3>
	// System.Collections.Generic.KeyValuePair<int,float>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<int,long>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<long,ET.LSInput>
	// System.Collections.Generic.KeyValuePair<long,long>
	// System.Collections.Generic.KeyValuePair<long,object>
	// System.Collections.Generic.KeyValuePair<object,ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.KeyValuePair<object,int>
	// System.Collections.Generic.KeyValuePair<object,long>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.KeyValuePair<ushort,object>
	// System.Collections.Generic.List.Enumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List.Enumerator<ET.ActivityTipConfig>
	// System.Collections.Generic.List.Enumerator<ET.BuyCellCost>
	// System.Collections.Generic.List.Enumerator<ET.Client.RolePetAdd>
	// System.Collections.Generic.List.Enumerator<ET.DayJingLing>
	// System.Collections.Generic.List.Enumerator<ET.DayMonsters>
	// System.Collections.Generic.List.Enumerator<ET.DropItemInfo>
	// System.Collections.Generic.List.Enumerator<ET.EquipChuanChengList>
	// System.Collections.Generic.List.Enumerator<ET.JiaYuanPurchase>
	// System.Collections.Generic.List.Enumerator<ET.PetMiningItem>
	// System.Collections.Generic.List.Enumerator<ET.PropertyValue>
	// System.Collections.Generic.List.Enumerator<ET.TypeButtonItem>
	// System.Collections.Generic.List.Enumerator<ET.WorldSayConfig>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List.Enumerator<System.ValueTuple<int,int>>
	// System.Collections.Generic.List.Enumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.List.Enumerator<UnityEngine.CombineInstance>
	// System.Collections.Generic.List.Enumerator<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.List.Enumerator<UnityEngine.Vector2>
	// System.Collections.Generic.List.Enumerator<UnityEngine.Vector3>
	// System.Collections.Generic.List.Enumerator<float>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<long>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List<ET.ActivityTipConfig>
	// System.Collections.Generic.List<ET.BuyCellCost>
	// System.Collections.Generic.List<ET.Client.RolePetAdd>
	// System.Collections.Generic.List<ET.DayJingLing>
	// System.Collections.Generic.List<ET.DayMonsters>
	// System.Collections.Generic.List<ET.DropItemInfo>
	// System.Collections.Generic.List<ET.EquipChuanChengList>
	// System.Collections.Generic.List<ET.JiaYuanPurchase>
	// System.Collections.Generic.List<ET.PetMiningItem>
	// System.Collections.Generic.List<ET.PropertyValue>
	// System.Collections.Generic.List<ET.TypeButtonItem>
	// System.Collections.Generic.List<ET.WorldSayConfig>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List<System.ValueTuple<int,int>>
	// System.Collections.Generic.List<Unity.Mathematics.float3>
	// System.Collections.Generic.List<UnityEngine.CombineInstance>
	// System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.List<UnityEngine.Vector2>
	// System.Collections.Generic.List<UnityEngine.Vector3>
	// System.Collections.Generic.List<float>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<long>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ObjectComparer<ET.ActivityTipConfig>
	// System.Collections.Generic.ObjectComparer<ET.ActorId>
	// System.Collections.Generic.ObjectComparer<ET.BuyCellCost>
	// System.Collections.Generic.ObjectComparer<ET.Client.RolePetAdd>
	// System.Collections.Generic.ObjectComparer<ET.DayJingLing>
	// System.Collections.Generic.ObjectComparer<ET.DayMonsters>
	// System.Collections.Generic.ObjectComparer<ET.DropItemInfo>
	// System.Collections.Generic.ObjectComparer<ET.EquipChuanChengList>
	// System.Collections.Generic.ObjectComparer<ET.JiaYuanPurchase>
	// System.Collections.Generic.ObjectComparer<ET.PetMiningItem>
	// System.Collections.Generic.ObjectComparer<ET.PropertyValue>
	// System.Collections.Generic.ObjectComparer<ET.TypeButtonItem>
	// System.Collections.Generic.ObjectComparer<ET.WorldSayConfig>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.ObjectComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ObjectComparer<UnityEngine.CombineInstance>
	// System.Collections.Generic.ObjectComparer<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.ObjectComparer<UnityEngine.Vector2>
	// System.Collections.Generic.ObjectComparer<UnityEngine.Vector3>
	// System.Collections.Generic.ObjectComparer<float>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<long>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectComparer<uint>
	// System.Collections.Generic.ObjectComparer<ushort>
	// System.Collections.Generic.ObjectEqualityComparer<ET.ActorId>
	// System.Collections.Generic.ObjectEqualityComparer<ET.Client.GameSettingLanguge.LangugeType>
	// System.Collections.Generic.ObjectEqualityComparer<ET.Client.ItemViewData.EquipWeiZhiInfo>
	// System.Collections.Generic.ObjectEqualityComparer<ET.Client.NumericAttribute>
	// System.Collections.Generic.ObjectEqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.ObjectEqualityComparer<ET.LSInput>
	// System.Collections.Generic.ObjectEqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectEqualityComparer<UnityEngine.Vector3>
	// System.Collections.Generic.ObjectEqualityComparer<float>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<long>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<uint>
	// System.Collections.Generic.ObjectEqualityComparer<ushort>
	// System.Collections.Generic.Queue.Enumerator<int>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<int>
	// System.Collections.Generic.Queue<object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<long,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<long,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<long,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<long,object>
	// System.Collections.Generic.SortedDictionary<long,object>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Stack.Enumerator<object>
	// System.Collections.Generic.Stack<object>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.ActivityTipConfig>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.BuyCellCost>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.Client.RolePetAdd>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.DayJingLing>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.DayMonsters>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.DropItemInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.EquipChuanChengList>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.JiaYuanPurchase>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.PetMiningItem>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.PropertyValue>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.TypeButtonItem>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.WorldSayConfig>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.ValueTuple<int,int>>
	// System.Collections.ObjectModel.ReadOnlyCollection<Unity.Mathematics.float3>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.CombineInstance>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.Vector2>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.Vector3>
	// System.Collections.ObjectModel.ReadOnlyCollection<float>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<long>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<DotRecast.Detour.StraightPathItem>
	// System.Comparison<ET.ActivityTipConfig>
	// System.Comparison<ET.ActorId>
	// System.Comparison<ET.BuyCellCost>
	// System.Comparison<ET.Client.RolePetAdd>
	// System.Comparison<ET.DayJingLing>
	// System.Comparison<ET.DayMonsters>
	// System.Comparison<ET.DropItemInfo>
	// System.Comparison<ET.EquipChuanChengList>
	// System.Comparison<ET.JiaYuanPurchase>
	// System.Comparison<ET.PetMiningItem>
	// System.Comparison<ET.PropertyValue>
	// System.Comparison<ET.TypeButtonItem>
	// System.Comparison<ET.WorldSayConfig>
	// System.Comparison<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Comparison<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Comparison<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Comparison<System.ValueTuple<int,int>>
	// System.Comparison<Unity.Mathematics.float3>
	// System.Comparison<UnityEngine.CombineInstance>
	// System.Comparison<UnityEngine.EventSystems.RaycastResult>
	// System.Comparison<UnityEngine.Vector2>
	// System.Comparison<UnityEngine.Vector3>
	// System.Comparison<float>
	// System.Comparison<int>
	// System.Comparison<long>
	// System.Comparison<object>
	// System.Comparison<uint>
	// System.Comparison<ushort>
	// System.Func<int,object>
	// System.Func<object,byte>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.Linq.Buffer<ET.RpcInfo>
	// System.Linq.Buffer<object>
	// System.Predicate<DotRecast.Detour.StraightPathItem>
	// System.Predicate<ET.ActivityTipConfig>
	// System.Predicate<ET.BuyCellCost>
	// System.Predicate<ET.Client.RolePetAdd>
	// System.Predicate<ET.DayJingLing>
	// System.Predicate<ET.DayMonsters>
	// System.Predicate<ET.DropItemInfo>
	// System.Predicate<ET.EquipChuanChengList>
	// System.Predicate<ET.JiaYuanPurchase>
	// System.Predicate<ET.PetMiningItem>
	// System.Predicate<ET.PropertyValue>
	// System.Predicate<ET.TypeButtonItem>
	// System.Predicate<ET.WorldSayConfig>
	// System.Predicate<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Predicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Predicate<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Predicate<System.ValueTuple<int,int>>
	// System.Predicate<Unity.Mathematics.float3>
	// System.Predicate<UnityEngine.CombineInstance>
	// System.Predicate<UnityEngine.EventSystems.RaycastResult>
	// System.Predicate<UnityEngine.Vector2>
	// System.Predicate<UnityEngine.Vector3>
	// System.Predicate<float>
	// System.Predicate<int>
	// System.Predicate<long>
	// System.Predicate<object>
	// System.Predicate<ushort>
	// System.ReadOnlySpan.Enumerator<byte>
	// System.ReadOnlySpan<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Span.Enumerator<byte>
	// System.Span<byte>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskFactory.<>c<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass32_0<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<object>
	// System.ValueTuple<ET.ActorId,object>
	// System.ValueTuple<float,float>
	// System.ValueTuple<int,int>
	// System.ValueTuple<int,object>
	// System.ValueTuple<object,object>
	// System.ValueTuple<uint,object>
	// System.ValueTuple<uint,uint>
	// System.ValueTuple<ushort,object>
	// UnityEngine.EventSystems.ExecuteEvents.EventFunction<object>
	// UnityEngine.Events.InvokableCall<byte>
	// UnityEngine.Events.InvokableCall<float>
	// UnityEngine.Events.InvokableCall<object>
	// UnityEngine.Events.UnityAction<byte>
	// UnityEngine.Events.UnityAction<float>
	// UnityEngine.Events.UnityAction<int>
	// UnityEngine.Events.UnityAction<object>
	// UnityEngine.Events.UnityEvent<byte>
	// UnityEngine.Events.UnityEvent<float>
	// UnityEngine.Events.UnityEvent<object>
	// UnityEngine.Pool.CollectionPool.<>c<object,object>
	// UnityEngine.Pool.CollectionPool<object,object>
	// }}

	public void RefMethods()
	{
		// object DG.Tweening.TweenSettingsExtensions.SetEase<object>(object,DG.Tweening.Ease)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,object>(ET.ETTaskCompleted&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,object>(System.Runtime.CompilerServices.TaskAwaiter&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,object>(System.Runtime.CompilerServices.TaskAwaiter<object>&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<int,int>>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,object>(System.Runtime.CompilerServices.TaskAwaiter<object>&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,object>(System.Runtime.CompilerServices.TaskAwaiter&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,object>(System.Runtime.CompilerServices.TaskAwaiter<object>&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.AppStartInitFinish>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.AppStartInitFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LSSceneChangeStart>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LSSceneChangeStart>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinish>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<int,int>>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.Start<object>(object&)
		// object ET.Entity.AddChild<object,int,object>(int,object,bool)
		// object ET.Entity.AddChild<object,object,object>(object,object,bool)
		// object ET.Entity.AddChild<object,object>(object,bool)
		// object ET.Entity.AddChild<object>(bool)
		// object ET.Entity.AddChildWithId<object,int>(long,int,bool)
		// object ET.Entity.AddChildWithId<object,object,object,object>(long,object,object,object,bool)
		// object ET.Entity.AddChildWithId<object,object,object>(long,object,object,bool)
		// object ET.Entity.AddChildWithId<object,object>(long,object,bool)
		// object ET.Entity.AddChildWithId<object>(long,bool)
		// object ET.Entity.AddComponent<object,int,int>(int,int,bool)
		// object ET.Entity.AddComponent<object,int>(int,bool)
		// object ET.Entity.AddComponent<object,object,int>(object,int,bool)
		// object ET.Entity.AddComponent<object,object>(object,bool)
		// object ET.Entity.AddComponent<object>(bool)
		// object ET.Entity.AddComponentWithId<object,int,int>(long,int,int,bool)
		// object ET.Entity.AddComponentWithId<object,int>(long,int,bool)
		// object ET.Entity.AddComponentWithId<object,object,int>(long,object,int,bool)
		// object ET.Entity.AddComponentWithId<object,object,object,object>(long,object,object,object,bool)
		// object ET.Entity.AddComponentWithId<object,object,object>(long,object,object,bool)
		// object ET.Entity.AddComponentWithId<object,object>(long,object,bool)
		// object ET.Entity.AddComponentWithId<object>(long,bool)
		// object ET.Entity.GetChild<object>(long)
		// object ET.Entity.GetComponent<object>()
		// object ET.Entity.GetParent<object>()
		// System.Void ET.Entity.RemoveComponent<object>()
		// System.Void ET.EntitySystemSingleton.Awake<int,int>(ET.Entity,int,int)
		// System.Void ET.EntitySystemSingleton.Awake<int,object>(ET.Entity,int,object)
		// System.Void ET.EntitySystemSingleton.Awake<int>(ET.Entity,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,int>(ET.Entity,object,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,object,object>(ET.Entity,object,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object,object>(ET.Entity,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object>(ET.Entity,object)
		// long ET.EnumHelper.FromString<long>(string)
		// System.Void ET.EventSystem.Invoke<ET.NetComponentOnRead>(long,ET.NetComponentOnRead)
		// System.Void ET.EventSystem.Publish<object,ET.ChangePosition>(object,ET.ChangePosition)
		// System.Void ET.EventSystem.Publish<object,ET.ChangeRotation>(object,ET.ChangeRotation)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterCreateCurrentScene>(object,ET.Client.AfterCreateCurrentScene)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterUnitCreate>(object,ET.Client.AfterUnitCreate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.BeforeSkill>(object,ET.Client.BeforeSkill)
		// System.Void ET.EventSystem.Publish<object,ET.Client.BuffScale>(object,ET.Client.BuffScale)
		// System.Void ET.EventSystem.Publish<object,ET.Client.BuffUpdate>(object,ET.Client.BuffUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ChangeCameraMoveType>(object,ET.Client.ChangeCameraMoveType)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_BagItemUpdate>(object,ET.Client.DataUpdate_BagItemUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_BeforeMove>(object,ET.Client.DataUpdate_BeforeMove)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_ChouKaWarehouseAddItem>(object,ET.Client.DataUpdate_ChouKaWarehouseAddItem)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_EquipHuiShow>(object,ET.Client.DataUpdate_EquipHuiShow)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_EquipWear>(object,ET.Client.DataUpdate_EquipWear)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_FriendChat>(object,ET.Client.DataUpdate_FriendChat)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_FriendUpdate>(object,ET.Client.DataUpdate_FriendUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_HuiShouSelect>(object,ET.Client.DataUpdate_HuiShouSelect)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_JingLingButton>(object,ET.Client.DataUpdate_JingLingButton)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_MainHeroMove>(object,ET.Client.DataUpdate_MainHeroMove)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_OnAccountWarehous>(object,ET.Client.DataUpdate_OnAccountWarehous)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_OnActiveTianFu>(object,ET.Client.DataUpdate_OnActiveTianFu)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_OnMailUpdate>(object,ET.Client.DataUpdate_OnMailUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_OnRecvChat>(object,ET.Client.DataUpdate_OnRecvChat)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_PetHeChengUpdate>(object,ET.Client.DataUpdate_PetHeChengUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_PetItemSelect>(object,ET.Client.DataUpdate_PetItemSelect)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_PetXiLianUpdate>(object,ET.Client.DataUpdate_PetXiLianUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_SettingUpdate>(object,ET.Client.DataUpdate_SettingUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_SkillReset>(object,ET.Client.DataUpdate_SkillReset)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_SkillSetting>(object,ET.Client.DataUpdate_SkillSetting)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_SkillUpgrade>(object,ET.Client.DataUpdate_SkillUpgrade)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_TaskComplete>(object,ET.Client.DataUpdate_TaskComplete)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_TaskGet>(object,ET.Client.DataUpdate_TaskGet)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_TaskTrace>(object,ET.Client.DataUpdate_TaskTrace)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_UpdateRoleProper>(object,ET.Client.DataUpdate_UpdateRoleProper)
		// System.Void ET.EventSystem.Publish<object,ET.Client.DataUpdate_UpdateUserData>(object,ET.Client.DataUpdate_UpdateUserData)
		// System.Void ET.EventSystem.Publish<object,ET.Client.EnterMapFinish>(object,ET.Client.EnterMapFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.FsmChange>(object,ET.Client.FsmChange)
		// System.Void ET.EventSystem.Publish<object,ET.Client.LSSceneInitFinish>(object,ET.Client.LSSceneInitFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.Now_Hp_Update>(object,ET.Client.Now_Hp_Update)
		// System.Void ET.EventSystem.Publish<object,ET.Client.OnSkillUse>(object,ET.Client.OnSkillUse)
		// System.Void ET.EventSystem.Publish<object,ET.Client.PlayAnimator>(object,ET.Client.PlayAnimator)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ReddotChange>(object,ET.Client.ReddotChange)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ReturnLogin>(object,ET.Client.ReturnLogin)
		// System.Void ET.EventSystem.Publish<object,ET.Client.RoleDataBroadcase>(object,ET.Client.RoleDataBroadcase)
		// System.Void ET.EventSystem.Publish<object,ET.Client.RolePetAdd>(object,ET.Client.RolePetAdd)
		// System.Void ET.EventSystem.Publish<object,ET.Client.RolePetUpdate>(object,ET.Client.RolePetUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeFinish>(object,ET.Client.SceneChangeFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeStart>(object,ET.Client.SceneChangeStart)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ShowFlyTip>(object,ET.Client.ShowFlyTip)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ShowItemTips>(object,ET.Client.ShowItemTips)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SingingUpdate>(object,ET.Client.SingingUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillBeging>(object,ET.Client.SkillBeging)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillCDUpdate>(object,ET.Client.SkillCDUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillEffect>(object,ET.Client.SkillEffect)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillEffectFinish>(object,ET.Client.SkillEffectFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillEffectMove>(object,ET.Client.SkillEffectMove)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillEffectReset>(object,ET.Client.SkillEffectReset)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillFinish>(object,ET.Client.SkillFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillSound>(object,ET.Client.SkillSound)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SkillYuJing>(object,ET.Client.SkillYuJing)
		// System.Void ET.EventSystem.Publish<object,ET.Client.TaskNpcDialog>(object,ET.Client.TaskNpcDialog)
		// System.Void ET.EventSystem.Publish<object,ET.Client.TaskTypeItemClick>(object,ET.Client.TaskTypeItemClick)
		// System.Void ET.EventSystem.Publish<object,ET.Client.UnitDead>(object,ET.Client.UnitDead)
		// System.Void ET.EventSystem.Publish<object,ET.Client.UserDataTypeUpdate_Diamond>(object,ET.Client.UserDataTypeUpdate_Diamond)
		// System.Void ET.EventSystem.Publish<object,ET.Client.UserDataTypeUpdate_Gold>(object,ET.Client.UserDataTypeUpdate_Gold)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStart>(object,ET.MoveStart)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStop>(object,ET.MoveStop)
		// System.Void ET.EventSystem.Publish<object,ET.NumbericChange>(object,ET.NumbericChange)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.AppStartInitFinish>(object,ET.Client.AppStartInitFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LSSceneChangeStart>(object,ET.Client.LSSceneChangeStart)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LoginFinish>(object,ET.Client.LoginFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent1>(object,ET.EntryEvent1)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent2>(object,ET.EntryEvent2)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent3>(object,ET.EntryEvent3)
		// object ET.MongoHelper.FromJson<object>(string)
		// System.Void ET.ObjectHelper.Swap<object>(object&,object&)
		// System.Void ET.RandomGenerator.BreakRank<object>(System.Collections.Generic.List<object>)
		// bool ET.RandomHelper.GetRandListByCount<int>(System.Collections.Generic.List<int>,System.Collections.Generic.List<int>,int)
		// object ET.World.AddSingleton<object>()
		// System.Collections.Generic.List<object> MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&)
		// System.Void MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&,System.Collections.Generic.List<object>&)
		// System.Void MemoryPack.Formatters.ListFormatter.SerializePackable<object>(MemoryPack.MemoryPackWriter&,System.Collections.Generic.List<object>&)
		// byte[] MemoryPack.Internal.MemoryMarshalEx.AllocateUninitializedArray<byte>(int,bool)
		// byte& MemoryPack.Internal.MemoryMarshalEx.GetArrayDataReference<byte>(byte[])
		// MemoryPack.MemoryPackFormatter<byte> MemoryPack.MemoryPackFormatterProvider.GetFormatter<byte>()
		// MemoryPack.MemoryPackFormatter<long> MemoryPack.MemoryPackFormatterProvider.GetFormatter<long>()
		// MemoryPack.MemoryPackFormatter<object> MemoryPack.MemoryPackFormatterProvider.GetFormatter<object>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<ET.LSInput>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<object>()
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<ET.LSInput>(MemoryPack.MemoryPackFormatter<ET.LSInput>)
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<object>(MemoryPack.MemoryPackFormatter<object>)
		// System.Void MemoryPack.MemoryPackReader.DangerousReadUnmanagedArray<byte>(byte[]&)
		// byte[] MemoryPack.MemoryPackReader.DangerousReadUnmanagedArray<byte>()
		// MemoryPack.IMemoryPackFormatter<byte> MemoryPack.MemoryPackReader.GetFormatter<byte>()
		// MemoryPack.IMemoryPackFormatter<long> MemoryPack.MemoryPackReader.GetFormatter<long>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackReader.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadPackable<object>(object&)
		// object MemoryPack.MemoryPackReader.ReadPackable<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.ActorId>(ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.LSInput>(ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<TrueSync.TSQuaternion>(TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<TrueSync.TSVector>(TrueSync.TSVector&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.float3>(Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion>(Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,float,float,float,byte,long,int>(byte&,float&,float&,float&,byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,float,float,float,long,int,long,long>(byte&,float&,float&,float&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,ET.ActorId>(byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,Unity.Mathematics.float3>(byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,byte,int,long>(byte&,int&,byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int,int,int,int,int,int>(byte&,int&,int&,int&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int,int,int>(byte&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int,int,long>(byte&,int&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int,int>(byte&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int,long>(byte&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int>(byte&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long,int,int,long>(byte&,int&,int&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long,int,long,long,int>(byte&,int&,int&,long&,int&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long,int>(byte&,int&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long,long,int,long,int,long,long>(byte&,int&,int&,long&,long&,int&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long>(byte&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int>(byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,ET.LSInput>(byte&,int&,long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,int,float,int,int,float,int,long>(byte&,int&,long&,int&,float&,int&,int&,float&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,int,int,long>(byte&,int&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,int,int>(byte&,int&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,int,long,long,int>(byte&,int&,long&,int&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,int,long>(byte&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,int>(byte&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long,int,int>(byte&,int&,long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long,int,long>(byte&,int&,long&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long>(byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long>(byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int>(byte&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,TrueSync.TSVector,TrueSync.TSQuaternion>(byte&,long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,Unity.Mathematics.float3>(byte&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,byte,int>(byte&,long&,byte&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,float,float,float,long,int>(byte&,long&,float&,float&,float&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,float,float,float,int,int,long>(byte&,long&,int&,int&,float&,float&,float&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,float,float,float,long,long,float>(byte&,long&,int&,int&,float&,float&,float&,long&,long&,float&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,int,float,int>(byte&,long&,int&,int&,int&,float&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,int,int,int>(byte&,long&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,int,int,long>(byte&,long&,int&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,int,int>(byte&,long&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,int>(byte&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,long>(byte&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int>(byte&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,int,long>(byte&,long&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,int>(byte&,long&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,long,long,int,int,long>(byte&,long&,int&,long&,long&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long>(byte&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int>(byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,float,float,float,int,long,int,long>(byte&,long&,long&,int&,float&,float&,float&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,int,int,long>(byte&,long&,long&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,int,int>(byte&,long&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,int,long>(byte&,long&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,int>(byte&,long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,long>(byte&,long&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int>(byte&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,long,int,long>(byte&,long&,long&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,long>(byte&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long>(byte&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long>(byte&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,uint>(byte&,uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte>(byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<float>(float&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,byte,int>(int&,byte&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,byte>(int&,byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,byte>(int&,int&,byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,int,int,int,int,int,float>(int&,int&,int&,int&,int&,int&,int&,float&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,int,int>(int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,int,long>(int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,int>(int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,long,int,int,int>(int&,int&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,long>(int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int>(int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,long,int,int>(int&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,long,int>(int&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,long,long,int,long,long>(int&,long&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,long,long>(int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,long>(int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,ET.LSInput>(long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,TrueSync.TSVector,TrueSync.TSQuaternion>(long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,byte,int,int>(long&,byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,int,int,int>(long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,int,int>(long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,int,long,int,int,int,int,int>(long&,int&,long&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,int,long>(long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,int>(long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long,int,int>(long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long,int,long,long,int,int,int,int,int,int,long>(long&,long&,int&,long&,long&,int&,int&,int&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long,long,int>(long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<uint>(uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanagedArray<byte>(byte[]&)
		// byte[] MemoryPack.MemoryPackReader.ReadUnmanagedArray<byte>()
		// System.Void MemoryPack.MemoryPackReader.ReadValue<object>(object&)
		// byte MemoryPack.MemoryPackReader.ReadValue<byte>()
		// long MemoryPack.MemoryPackReader.ReadValue<long>()
		// object MemoryPack.MemoryPackReader.ReadValue<object>()
		// System.Void MemoryPack.MemoryPackWriter.DangerousWriteUnmanagedArray<byte>(byte[])
		// MemoryPack.IMemoryPackFormatter<byte> MemoryPack.MemoryPackWriter.GetFormatter<byte>()
		// MemoryPack.IMemoryPackFormatter<long> MemoryPack.MemoryPackWriter.GetFormatter<long>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackWriter.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackWriter.WritePackable<object>(object&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<ET.LSInput>(ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<byte,int>(byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<byte>(byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,byte,int>(int&,byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,byte>(int&,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,byte>(int&,int&,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,int,int,int,int,int,float>(int&,int&,int&,int&,int&,int&,int&,float&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,int,int>(int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,int,long>(int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,int>(int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,long,int,int,int>(int&,int&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,long>(int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int>(int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,long,int,int>(int&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,long,int>(int&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,long,long,int,long,long>(int&,long&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,long,long>(int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,long>(int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,ET.LSInput>(long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,TrueSync.TSVector,TrueSync.TSQuaternion>(long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,byte,int,int>(long&,byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,int,int,int>(long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,int,int>(long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,int,long,int,int,int,int,int>(long&,int&,long&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,int,long>(long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,int>(long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long,int,int>(long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long,int,long,long,int,int,int,int,int,int,long>(long&,long&,int&,long&,long&,int&,int&,int&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long,long,int>(long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedArray<byte>(byte[])
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,float,float,float,byte,long,int>(byte,byte&,float&,float&,float&,byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,float,float,float,long,int,long,long>(byte,byte&,float&,float&,float&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,ET.ActorId>(byte,byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,Unity.Mathematics.float3>(byte,byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,byte,int,long>(byte,byte&,int&,byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int,int,int,int,int,int>(byte,byte&,int&,int&,int&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int,int,int>(byte,byte&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int,int,long>(byte,byte&,int&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int,int>(byte,byte&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int,long>(byte,byte&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int>(byte,byte&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long,int,int,long>(byte,byte&,int&,int&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long,int,long,long,int>(byte,byte&,int&,int&,long&,int&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long,int>(byte,byte&,int&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long,long,int,long,int,long,long>(byte,byte&,int&,int&,long&,long&,int&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long>(byte,byte&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int>(byte,byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,ET.LSInput>(byte,byte&,int&,long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte,byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,int,float,int,int,float,int,long>(byte,byte&,int&,long&,int&,float&,int&,int&,float&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,int,int,long>(byte,byte&,int&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,int,int>(byte,byte&,int&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,int,long,long,int>(byte,byte&,int&,long&,int&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,int,long>(byte,byte&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,int>(byte,byte&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long,int,int>(byte,byte&,int&,long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long,int,long>(byte,byte&,int&,long&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long>(byte,byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long>(byte,byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int>(byte,byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,TrueSync.TSVector,TrueSync.TSQuaternion>(byte,byte&,long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,Unity.Mathematics.float3>(byte,byte&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,byte,int>(byte,byte&,long&,byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,float,float,float,long,int>(byte,byte&,long&,float&,float&,float&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte,byte&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,float,float,float,int,int,long>(byte,byte&,long&,int&,int&,float&,float&,float&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,float,float,float,long,long,float>(byte,byte&,long&,int&,int&,float&,float&,float&,long&,long&,float&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,int,float,int>(byte,byte&,long&,int&,int&,int&,float&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,int,int,int>(byte,byte&,long&,int&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,int,int,long>(byte,byte&,long&,int&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,int,int>(byte,byte&,long&,int&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,int>(byte,byte&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,long>(byte,byte&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int>(byte,byte&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,int,long>(byte,byte&,long&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,int>(byte,byte&,long&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,long,long,int,int,long>(byte,byte&,long&,int&,long&,long&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long>(byte,byte&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int>(byte,byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,float,float,float,int,long,int,long>(byte,byte&,long&,long&,int&,float&,float&,float&,int&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,int,int,long>(byte,byte&,long&,long&,int&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,int,int>(byte,byte&,long&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,int,long>(byte,byte&,long&,long&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,int>(byte,byte&,long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,long>(byte,byte&,long&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int>(byte,byte&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,long,int,long>(byte,byte&,long&,long&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,long>(byte,byte&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long>(byte,byte&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long>(byte,byte&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,uint>(byte,byte&,uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte>(byte,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<byte>(byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<object>(object&)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(MongoDB.Bson.IO.IBsonReader,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(string,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// MongoDB.Bson.Serialization.IBsonSerializer<object> MongoDB.Bson.Serialization.BsonSerializer.LookupSerializer<object>()
		// object MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize<object>(MongoDB.Bson.Serialization.IBsonSerializer<object>,MongoDB.Bson.Serialization.BsonDeserializationContext)
		// object System.Activator.CreateInstance<object>()
		// byte[] System.Array.Empty<byte>()
		// object[] System.Array.Empty<object>()
		// System.Void System.Array.Resize<object>(object[]&,int)
		// int System.HashCode.Combine<TrueSync.TSVector2,int>(TrueSync.TSVector2,int)
		// int System.HashCode.Combine<object>(object)
		// bool System.Linq.Enumerable.Contains<int>(System.Collections.Generic.IEnumerable<int>,int)
		// bool System.Linq.Enumerable.Contains<int>(System.Collections.Generic.IEnumerable<int>,int,System.Collections.Generic.IEqualityComparer<int>)
		// ET.RpcInfo[] System.Linq.Enumerable.ToArray<ET.RpcInfo>(System.Collections.Generic.IEnumerable<ET.RpcInfo>)
		// object[] System.Linq.Enumerable.ToArray<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<int,int>> System.Linq.Enumerable.ToList<System.Collections.Generic.KeyValuePair<int,int>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,int>>)
		// System.Collections.Generic.List<int> System.Linq.Enumerable.ToList<int>(System.Collections.Generic.IEnumerable<int>)
		// System.Collections.Generic.List<object> System.Linq.Enumerable.ToList<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Span<byte> System.MemoryExtensions.AsSpan<byte>(byte[])
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<object>(object&)
		// byte& System.Runtime.CompilerServices.Unsafe.Add<byte>(byte&,int)
		// byte& System.Runtime.CompilerServices.Unsafe.As<byte,byte>(byte&)
		// object& System.Runtime.CompilerServices.Unsafe.As<object,object>(object&)
		// byte& System.Runtime.CompilerServices.Unsafe.AsRef<byte>(byte&)
		// long& System.Runtime.CompilerServices.Unsafe.AsRef<long>(long&)
		// object& System.Runtime.CompilerServices.Unsafe.AsRef<object>(object&)
		// ET.ActorId System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.ActorId>(byte&)
		// ET.LSInput System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.LSInput>(byte&)
		// TrueSync.TSQuaternion System.Runtime.CompilerServices.Unsafe.ReadUnaligned<TrueSync.TSQuaternion>(byte&)
		// TrueSync.TSVector System.Runtime.CompilerServices.Unsafe.ReadUnaligned<TrueSync.TSVector>(byte&)
		// Unity.Mathematics.float3 System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.float3>(byte&)
		// Unity.Mathematics.quaternion System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.quaternion>(byte&)
		// byte System.Runtime.CompilerServices.Unsafe.ReadUnaligned<byte>(byte&)
		// float System.Runtime.CompilerServices.Unsafe.ReadUnaligned<float>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.ReadUnaligned<int>(byte&)
		// long System.Runtime.CompilerServices.Unsafe.ReadUnaligned<long>(byte&)
		// uint System.Runtime.CompilerServices.Unsafe.ReadUnaligned<uint>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.ActorId>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.LSInput>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<TrueSync.TSQuaternion>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<TrueSync.TSVector>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.float3>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.quaternion>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<byte>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<float>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<int>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<long>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<uint>()
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.ActorId>(byte&,ET.ActorId)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.LSInput>(byte&,ET.LSInput)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<TrueSync.TSQuaternion>(byte&,TrueSync.TSQuaternion)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<TrueSync.TSVector>(byte&,TrueSync.TSVector)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.float3>(byte&,Unity.Mathematics.float3)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.quaternion>(byte&,Unity.Mathematics.quaternion)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<byte>(byte&,byte)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<float>(byte&,float)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<int>(byte&,int)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<long>(byte&,long)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<uint>(byte&,uint)
		// byte& System.Runtime.InteropServices.MemoryMarshal.GetReference<byte>(System.Span<byte>)
		// System.Threading.Tasks.Task<object> System.Threading.Tasks.TaskFactory.StartNew<object>(System.Func<object>,System.Threading.CancellationToken)
		// object UnityEngine.AndroidJNIHelper.ConvertFromJNIArray<object>(System.IntPtr)
		// System.IntPtr UnityEngine.AndroidJNIHelper.GetMethodID<object>(System.IntPtr,string,object[],bool)
		// object UnityEngine.AndroidJavaObject.CallStatic<object>(string,object[])
		// object UnityEngine.AndroidJavaObject.FromJavaArrayDeleteLocalRef<object>(System.IntPtr)
		// object UnityEngine.AndroidJavaObject._CallStatic<object>(string,object[])
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.Component.GetComponentInChildren<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>(bool)
		// bool UnityEngine.EventSystems.ExecuteEvents.Execute<object>(UnityEngine.GameObject,UnityEngine.EventSystems.BaseEventData,UnityEngine.EventSystems.ExecuteEvents.EventFunction<object>)
		// System.Void UnityEngine.EventSystems.ExecuteEvents.GetEventList<object>(UnityEngine.GameObject,System.Collections.Generic.IList<UnityEngine.EventSystems.IEventSystemHandler>)
		// bool UnityEngine.EventSystems.ExecuteEvents.ShouldSendToComponent<object>(UnityEngine.Component)
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>(bool)
		// System.Void UnityEngine.GameObject.GetComponents<object>(System.Collections.Generic.List<object>)
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// object UnityEngine._AndroidJNIHelper.ConvertFromJNIArray<object>(System.IntPtr)
		// System.IntPtr UnityEngine._AndroidJNIHelper.GetMethodID<object>(System.IntPtr,string,object[],bool)
		// string UnityEngine._AndroidJNIHelper.GetSignature<object>(object[])
		// YooAsset.AllAssetsOperationHandle YooAsset.ResourcePackage.LoadAllAssetsAsync<object>(string)
		// YooAsset.AssetOperationHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string)
		// YooAsset.AssetOperationHandle YooAsset.ResourcePackage.LoadAssetSync<object>(string)
	}
}