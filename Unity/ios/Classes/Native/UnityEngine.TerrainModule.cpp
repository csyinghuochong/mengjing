#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3;
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3<T1*, T2, T3>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2, T3 p3)
	{
		void* params[3] = { p1, &p2, &p3 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct InvokerActionInvoker4;
template <typename T1, typename T2, typename T3, typename T4>
struct InvokerActionInvoker4<T1*, T2*, T3, T4>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3 p3, T4 p4)
	{
		void* params[4] = { p1, p2, &p3, &p4 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5>
struct InvokerActionInvoker5;
template <typename T1, typename T2, typename T3, typename T4, typename T5>
struct InvokerActionInvoker5<T1*, T2*, T3*, T4, T5>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3* p3, T4 p4, T5 p5)
	{
		void* params[5] = { p1, p2, p3, &p4, &p5 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};

// System.Collections.Generic.Dictionary`2<System.Int32,System.Object>
struct Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907;
// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>
struct Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C;
// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>
struct Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F;
// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119;
// System.Collections.Generic.IEqualityComparer`1<System.Int32>
struct IEqualityComparer_1_tDBFC8496F14612776AF930DBF84AFE7D06D1F0E9;
// System.Collections.Generic.IEqualityComparer`1<UnityEngine.TerrainUtils.TerrainTileCoord>
struct IEqualityComparer_1_t88286C29EF8964DB1FA6326A0679A19AC8C74709;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.Int32,UnityEngine.TerrainUtils.TerrainMap>
struct KeyCollection_t97828E793E08E7AE593254EBFD6895A9E9604AF2;
// System.Collections.Generic.Dictionary`2/KeyCollection<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>
struct KeyCollection_t8A862CFF968D9AAD432E0AFA29DECB342BF06F59;
// System.Collections.Generic.Dictionary`2/KeyCollection<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E;
// System.Collections.Generic.List`1<UnityEngine.Rendering.ReflectionProbeBlendInfo>
struct List_1_t1100962F75A3C1A8DDD989C01DEE91D38A84082A;
// System.Collections.Generic.List`1<UnityEngine.Terrain>
struct List_1_tD2AD001A66810CB968E98D9E635A799408554017;
// System.Predicate`1<System.Object>
struct Predicate_1_t8342C85FF4E41CD1F7024AC0CDC3E5312A32CB12;
// System.Predicate`1<UnityEngine.Terrain>
struct Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.Int32,UnityEngine.TerrainUtils.TerrainMap>
struct ValueCollection_tBB50DA6B04BF6793F609F48ADA1A351088E36D60;
// System.Collections.Generic.Dictionary`2/ValueCollection<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct ValueCollection_tAD845AD3A8539F70A13D1BE6F0351D29799ADEAB;
// System.Collections.Generic.Dictionary`2/Entry<System.Int32,UnityEngine.TerrainUtils.TerrainMap>[]
struct EntryU5BU5D_t0D4B039A690585E4A149FAC6B11C554E9BAA164A;
// System.Collections.Generic.Dictionary`2/Entry<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>[]
struct EntryU5BU5D_tF5367AE3FB34F62A304459CBC2E961FB1A82E6DA;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// UnityEngine.DetailPrototype[]
struct DetailPrototypeU5BU5D_tB9391EFBDD64B38867DFB8179C6C0E8C81998AB7;
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// UnityEngine.Rendering.ReflectionProbeBlendInfo[]
struct ReflectionProbeBlendInfoU5BU5D_tA9D04082580498268C1B2FB0BC26B2F335D86766;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// UnityEngine.Terrain[]
struct TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE;
// UnityEngine.TerrainLayer[]
struct TerrainLayerU5BU5D_t259E391D6115F121FCD284E79F62012D70956EB0;
// UnityEngine.Texture2D[]
struct Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191;
// UnityEngine.TreeInstance[]
struct TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429;
// UnityEngine.TreePrototype[]
struct TreePrototypeU5BU5D_tB0255CA167F991C2C9BA3BA55DF7417168D93B7A;
// System.Type[]
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
// System.Boolean[,]
struct BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6;
// System.Int32[,]
struct Int32U5BU2CU5D_t46F2694E7DAD7B2B05C940EC5B9DE04E40D0516F;
// System.Single[,,]
struct SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488;
// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263;
// System.ArgumentNullException
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// System.Attribute
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA;
// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA;
// System.Reflection.Binder
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// UnityEngine.DetailPrototype
struct DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B;
// Microsoft.CodeAnalysis.EmbeddedAttribute
struct EmbeddedAttribute_t62225631BB65062906FDEF1ED16845EF6E34BB4A;
// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// System.Runtime.CompilerServices.IsReadOnlyAttribute
struct IsReadOnlyAttribute_tA42E96C61DFF3800E657E708BCD33A06F6CD2D7B;
// UnityEngine.Material
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3;
// UnityEngine.MaterialPropertyBlock
struct MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D;
// System.Reflection.MemberFilter
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
// UnityEngine.RenderTexture
struct RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// System.String
struct String_t;
// UnityEngine.Terrain
struct Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667;
// UnityEngine.TerrainData
struct TerrainData_t615A68EAC648066681875D47FC641496D12F2E24;
// UnityEngine.TerrainLayer
struct TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9;
// UnityEngine.TerrainUtils.TerrainMap
struct TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB;
// UnityEngine.Texture
struct Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700;
// UnityEngine.Texture2D
struct Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4;
// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1;
// UnityEngine.TreePrototype
struct TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D;
// System.Type
struct Type_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// UnityEngine.TerrainCallbacks/HeightmapChangedCallback
struct HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0;
// UnityEngine.TerrainCallbacks/TextureChangedCallback
struct TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F;
// UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0
struct U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3;
// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0
struct U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E;
// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1
struct U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951;

IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral532F5429956965038FA49DA954E9A0D4D34B41A9;
IL2CPP_EXTERN_C String_t* _stringLiteral84C1B2E6507AF77B7FC524F3D2F88289EB512D41;
IL2CPP_EXTERN_C String_t* _stringLiteralFAA7C04A851925650B82E9B390175EE79E020DB1;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_Add_m265E9FB46C80D234AEB47C08D701628D57DBA132_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_Add_m4E7AE6465929CEEA79B5921CFF3D4BD64E249AF9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_ContainsKey_m384365266E590EDD82F8949169A3C502E643AC95_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_GetEnumerator_m50800AFD24DEE5F8ACB58E1535F2A472B478E473_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_GetEnumerator_m5461BE3EE48320EA8E593506F16860A2CB4E9056_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_TryGetValue_mA4944115ADCBA991881F907C9E48413EB1EFE42A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2__ctor_m5665AD243B285B8D26138C699D544F4124AC7D78_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2__ctor_mCA22422F902B1FF70914D8FA2EF849DA0DCDC87D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_get_Count_m001233C3B4F8B3D1A8F044C9D43104F1671688DC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_get_Keys_mBE9BF06497225D54AC2D2D7AEF6D0F94169B10D4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_m09F8467FB404D375259C17136F2213FC8455F2BF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_mC60AECD5D4FA770371F4B374F2B026F7198CEF03_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_mDDABE6027BD9E377D6E3FC7F60CE5DDB0ADC47D7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_m1BA7CBA94F8FC389211722A43E22BB110102ABB4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_m1CEA4A6A000E5344DB72DFF5E4FF563FF67F3558_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_m6430F89661ED2AEDEAD6FD241BBDA21BF02135DC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_m1F085EA2ABB67CCEB29CC4A10D6FBC0F2B963349_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_m88A7ECB72C871AEFAD87667D8512A109C33E7080_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_mCD48A37B44C4A6E441AF6806E0821A24A22A51F3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* KeyCollection_GetEnumerator_m7D86741C1BEF055A22281CF69C6235BFD1E7D521_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* KeyValuePair_2_get_Key_mFE7731B1C41692F16EB45AC2D63092AC73156A8A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* KeyValuePair_2_get_Value_m32D4949D8D2F580E35346D41EBB14C7933B93482_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TerrainData_GetAlphamaps_m2DEF5D2068D54BDAE78661483C1FC4936B06EA01_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TerrainData_GetHoles_mE81BB7B6E8764586CC5BA130AC075536D0617318_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Terrain_GetSplatMaterialPropertyBlock_m12C9F2F14B6D92021E72AE994D438E2C6DF69FEF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec__DisplayClass2_1_U3CCollectTerrainsU3Eb__0_m57E871EB2399E5FB7DF78B3C9EBFBF152116AC2C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec__DisplayClass3_0_U3CCreateFromPlacementU3Eb__0_m703A4D4E3D378C9896199B70A89FCDF1A07C737B_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct DetailPrototypeU5BU5D_tB9391EFBDD64B38867DFB8179C6C0E8C81998AB7;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE;
struct TerrainLayerU5BU5D_t259E391D6115F121FCD284E79F62012D70956EB0;
struct Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191;
struct TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429;
struct TreePrototypeU5BU5D_tB0255CA167F991C2C9BA3BA55DF7417168D93B7A;
struct BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6;
struct Int32U5BU2CU5D_t46F2694E7DAD7B2B05C940EC5B9DE04E40D0516F;
struct SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t72986D6E9DA49B1952335DAFFF9250DC3CDDEA8E 
{
};

// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>
struct Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C  : public RuntimeObject
{
	// System.Int32[] System.Collections.Generic.Dictionary`2::_buckets
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets_0;
	// System.Collections.Generic.Dictionary`2/Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::_entries
	EntryU5BU5D_t0D4B039A690585E4A149FAC6B11C554E9BAA164A* ____entries_1;
	// System.Int32 System.Collections.Generic.Dictionary`2::_count
	int32_t ____count_2;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeList
	int32_t ____freeList_3;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeCount
	int32_t ____freeCount_4;
	// System.Int32 System.Collections.Generic.Dictionary`2::_version
	int32_t ____version_5;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::_comparer
	RuntimeObject* ____comparer_6;
	// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_keys
	KeyCollection_t97828E793E08E7AE593254EBFD6895A9E9604AF2* ____keys_7;
	// System.Collections.Generic.Dictionary`2/ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_values
	ValueCollection_tBB50DA6B04BF6793F609F48ADA1A351088E36D60* ____values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject* ____syncRoot_9;
};

// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119  : public RuntimeObject
{
	// System.Int32[] System.Collections.Generic.Dictionary`2::_buckets
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets_0;
	// System.Collections.Generic.Dictionary`2/Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::_entries
	EntryU5BU5D_tF5367AE3FB34F62A304459CBC2E961FB1A82E6DA* ____entries_1;
	// System.Int32 System.Collections.Generic.Dictionary`2::_count
	int32_t ____count_2;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeList
	int32_t ____freeList_3;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeCount
	int32_t ____freeCount_4;
	// System.Int32 System.Collections.Generic.Dictionary`2::_version
	int32_t ____version_5;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::_comparer
	RuntimeObject* ____comparer_6;
	// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_keys
	KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E* ____keys_7;
	// System.Collections.Generic.Dictionary`2/ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_values
	ValueCollection_tAD845AD3A8539F70A13D1BE6F0351D29799ADEAB* ____values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject* ____syncRoot_9;
};

// System.Collections.Generic.Dictionary`2/KeyCollection<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E  : public RuntimeObject
{
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/KeyCollection::_dictionary
	Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* ____dictionary_0;
};

// System.Collections.Generic.List`1<UnityEngine.Rendering.ReflectionProbeBlendInfo>
struct List_1_t1100962F75A3C1A8DDD989C01DEE91D38A84082A  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	ReflectionProbeBlendInfoU5BU5D_tA9D04082580498268C1B2FB0BC26B2F335D86766* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

// System.Collections.Generic.List`1<UnityEngine.Terrain>
struct List_1_tD2AD001A66810CB968E98D9E635A799408554017  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

// System.Attribute
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};

// System.Reflection.MemberInfo
struct MemberInfo_t  : public RuntimeObject
{
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

// UnityEngine.TerrainCallbacks
struct TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C  : public RuntimeObject
{
};

// UnityEngine.TerrainUtils.TerrainUtility
struct TerrainUtility_t2033CBF4E86976650C0371A424B6BDD6B051451D  : public RuntimeObject
{
};

// UnityEngine.TreePrototype
struct TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D  : public RuntimeObject
{
	// UnityEngine.GameObject UnityEngine.TreePrototype::m_Prefab
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___m_Prefab_0;
	// System.Single UnityEngine.TreePrototype::m_BendFactor
	float ___m_BendFactor_1;
	// System.Int32 UnityEngine.TreePrototype::m_NavMeshLod
	int32_t ___m_NavMeshLod_2;
};
// Native definition for P/Invoke marshalling of UnityEngine.TreePrototype
struct TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_pinvoke
{
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___m_Prefab_0;
	float ___m_BendFactor_1;
	int32_t ___m_NavMeshLod_2;
};
// Native definition for COM marshalling of UnityEngine.TreePrototype
struct TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_com
{
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___m_Prefab_0;
	float ___m_BendFactor_1;
	int32_t ___m_NavMeshLod_2;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0
struct U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3  : public RuntimeObject
{
	// System.Int32 UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0::groupID
	int32_t ___groupID_0;
};

// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0
struct U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E  : public RuntimeObject
{
	// System.Boolean UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0::onlyAutoConnectedTerrains
	bool ___onlyAutoConnectedTerrains_0;
};

// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1
struct U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951  : public RuntimeObject
{
	// UnityEngine.Terrain UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1::t
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___t_0;
	// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0 UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1::CS$<>8__locals1
	U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* ___CSU24U3CU3E8__locals1_1;
};

// System.Collections.Generic.KeyValuePair`2<System.Int32,System.Object>
struct KeyValuePair_2_tDC26B09C26BA829DDE331BCB6AF7C508C763D7A3 
{
	// TKey System.Collections.Generic.KeyValuePair`2::key
	int32_t ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	RuntimeObject* ___value_1;
};

// System.Collections.Generic.KeyValuePair`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>
struct KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873 
{
	// TKey System.Collections.Generic.KeyValuePair`2::key
	int32_t ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* ___value_1;
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

// UnityEngine.Color
struct Color_tD001788D726C3A7F1379BEED0260B9591F440C1F 
{
	// System.Single UnityEngine.Color::r
	float ___r_0;
	// System.Single UnityEngine.Color::g
	float ___g_1;
	// System.Single UnityEngine.Color::b
	float ___b_2;
	// System.Single UnityEngine.Color::a
	float ___a_3;
};

// UnityEngine.Color32
struct Color32_t73C5004937BF5BB8AD55323D51AAA40A898EF48B 
{
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Int32 UnityEngine.Color32::rgba
			int32_t ___rgba_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			int32_t ___rgba_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Byte UnityEngine.Color32::r
			uint8_t ___r_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint8_t ___r_1_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___g_2_OffsetPadding[1];
			// System.Byte UnityEngine.Color32::g
			uint8_t ___g_2;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___g_2_OffsetPadding_forAlignmentOnly[1];
			uint8_t ___g_2_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___b_3_OffsetPadding[2];
			// System.Byte UnityEngine.Color32::b
			uint8_t ___b_3;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___b_3_OffsetPadding_forAlignmentOnly[2];
			uint8_t ___b_3_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___a_4_OffsetPadding[3];
			// System.Byte UnityEngine.Color32::a
			uint8_t ___a_4;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___a_4_OffsetPadding_forAlignmentOnly[3];
			uint8_t ___a_4_forAlignmentOnly;
		};
	};
};

// System.Double
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	// System.Double System.Double::m_value
	double ___m_value_0;
};

// Microsoft.CodeAnalysis.EmbeddedAttribute
struct EmbeddedAttribute_t62225631BB65062906FDEF1ED16845EF6E34BB4A  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

// System.Runtime.CompilerServices.IsReadOnlyAttribute
struct IsReadOnlyAttribute_tA42E96C61DFF3800E657E708BCD33A06F6CD2D7B  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};

// UnityEngine.Mathf
struct Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682 
{
	union
	{
		struct
		{
		};
		uint8_t Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682__padding[1];
	};
};

// UnityEngine.RectInt
struct RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 
{
	// System.Int32 UnityEngine.RectInt::m_XMin
	int32_t ___m_XMin_0;
	// System.Int32 UnityEngine.RectInt::m_YMin
	int32_t ___m_YMin_1;
	// System.Int32 UnityEngine.RectInt::m_Width
	int32_t ___m_Width_2;
	// System.Int32 UnityEngine.RectInt::m_Height
	int32_t ___m_Height_3;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
};

// UnityEngine.TerrainUtils.TerrainTileCoord
struct TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 
{
	// System.Int32 UnityEngine.TerrainUtils.TerrainTileCoord::tileX
	int32_t ___tileX_0;
	// System.Int32 UnityEngine.TerrainUtils.TerrainTileCoord::tileZ
	int32_t ___tileZ_1;
};

// System.UInt32
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;
};

// UnityEngine.Vector2
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	// System.Single UnityEngine.Vector2::x
	float ___x_0;
	// System.Single UnityEngine.Vector2::y
	float ___y_1;
};

// UnityEngine.Vector3
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;
};

// UnityEngine.Vector4
struct Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 
{
	// System.Single UnityEngine.Vector4::x
	float ___x_1;
	// System.Single UnityEngine.Vector4::y
	float ___y_2;
	// System.Single UnityEngine.Vector4::z
	float ___z_3;
	// System.Single UnityEngine.Vector4::w
	float ___w_4;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Object>
struct Enumerator_tE92C1AC40A104A179B94F8A013728FD9314CFBD3 
{
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_dictionary
	Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907* ____dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_version
	int32_t ____version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_index
	int32_t ____index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_current
	KeyValuePair_2_tDC26B09C26BA829DDE331BCB6AF7C508C763D7A3 ____current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_getEnumeratorRetType
	int32_t ____getEnumeratorRetType_4;
};

// System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,UnityEngine.TerrainUtils.TerrainMap>
struct Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F 
{
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_dictionary
	Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* ____dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_version
	int32_t ____version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_index
	int32_t ____index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_current
	KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873 ____current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_getEnumeratorRetType
	int32_t ____getEnumeratorRetType_4;
};

// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>
struct Enumerator_tF5348A6D692C0422DAF82BC55E5276A4D29BEF53 
{
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_dictionary
	Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* ____dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_index
	int32_t ____index_1;
	// System.Int32 System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_version
	int32_t ____version_2;
	// TKey System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_currentKey
	TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ____currentKey_3;
};

// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689 
{
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_dictionary
	Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* ____dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_index
	int32_t ____index_1;
	// System.Int32 System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_version
	int32_t ____version_2;
	// TKey System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator::_currentKey
	TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ____currentKey_3;
};

// System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>
struct KeyValuePair_2_t8760984FFCA6E11154C918347EA4C7CFB2D0B8CE 
{
	// TKey System.Collections.Generic.KeyValuePair`2::key
	TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	RuntimeObject* ___value_1;
};

// System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3 
{
	// TKey System.Collections.Generic.KeyValuePair`2::key
	TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___value_1;
};

// System.Delegate
struct Delegate_t  : public RuntimeObject
{
	// System.IntPtr System.Delegate::method_ptr
	intptr_t ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject* ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.IntPtr System.Delegate::interp_method
	intptr_t ___interp_method_7;
	// System.IntPtr System.Delegate::interp_invoke_impl
	intptr_t ___interp_invoke_impl_8;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t* ___method_info_9;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t* ___original_method_info_10;
	// System.DelegateData System.Delegate::data
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_12;
};
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

// UnityEngine.DetailPrototype
struct DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B  : public RuntimeObject
{
	// UnityEngine.GameObject UnityEngine.DetailPrototype::m_Prototype
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___m_Prototype_2;
	// UnityEngine.Texture2D UnityEngine.DetailPrototype::m_PrototypeTexture
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___m_PrototypeTexture_3;
	// UnityEngine.Color UnityEngine.DetailPrototype::m_HealthyColor
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_HealthyColor_4;
	// UnityEngine.Color UnityEngine.DetailPrototype::m_DryColor
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_DryColor_5;
	// System.Single UnityEngine.DetailPrototype::m_MinWidth
	float ___m_MinWidth_6;
	// System.Single UnityEngine.DetailPrototype::m_MaxWidth
	float ___m_MaxWidth_7;
	// System.Single UnityEngine.DetailPrototype::m_MinHeight
	float ___m_MinHeight_8;
	// System.Single UnityEngine.DetailPrototype::m_MaxHeight
	float ___m_MaxHeight_9;
	// System.Int32 UnityEngine.DetailPrototype::m_NoiseSeed
	int32_t ___m_NoiseSeed_10;
	// System.Single UnityEngine.DetailPrototype::m_NoiseSpread
	float ___m_NoiseSpread_11;
	// System.Single UnityEngine.DetailPrototype::m_HoleEdgePadding
	float ___m_HoleEdgePadding_12;
	// System.Int32 UnityEngine.DetailPrototype::m_RenderMode
	int32_t ___m_RenderMode_13;
	// System.Int32 UnityEngine.DetailPrototype::m_UsePrototypeMesh
	int32_t ___m_UsePrototypeMesh_14;
	// System.Int32 UnityEngine.DetailPrototype::m_UseInstancing
	int32_t ___m_UseInstancing_15;
};
// Native definition for P/Invoke marshalling of UnityEngine.DetailPrototype
struct DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_pinvoke
{
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___m_Prototype_2;
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___m_PrototypeTexture_3;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_HealthyColor_4;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_DryColor_5;
	float ___m_MinWidth_6;
	float ___m_MaxWidth_7;
	float ___m_MinHeight_8;
	float ___m_MaxHeight_9;
	int32_t ___m_NoiseSeed_10;
	float ___m_NoiseSpread_11;
	float ___m_HoleEdgePadding_12;
	int32_t ___m_RenderMode_13;
	int32_t ___m_UsePrototypeMesh_14;
	int32_t ___m_UseInstancing_15;
};
// Native definition for COM marshalling of UnityEngine.DetailPrototype
struct DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_com
{
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___m_Prototype_2;
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___m_PrototypeTexture_3;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_HealthyColor_4;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_DryColor_5;
	float ___m_MinWidth_6;
	float ___m_MaxWidth_7;
	float ___m_MinHeight_8;
	float ___m_MaxHeight_9;
	int32_t ___m_NoiseSeed_10;
	float ___m_NoiseSpread_11;
	float ___m_HoleEdgePadding_12;
	int32_t ___m_RenderMode_13;
	int32_t ___m_UsePrototypeMesh_14;
	int32_t ___m_UseInstancing_15;
};

// System.Exception
struct Exception_t  : public RuntimeObject
{
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t* ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject* ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject* ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips_15;
	// System.Int32 System.Exception::caught_in_unmanaged
	int32_t ___caught_in_unmanaged_16;
};
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};

// UnityEngine.MaterialPropertyBlock
struct MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D  : public RuntimeObject
{
	// System.IntPtr UnityEngine.MaterialPropertyBlock::m_Ptr
	intptr_t ___m_Ptr_0;
};

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;
};
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// System.RuntimeTypeHandle
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;
};

// UnityEngine.TerrainUtils.TerrainMap
struct TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB  : public RuntimeObject
{
	// UnityEngine.Vector3 UnityEngine.TerrainUtils.TerrainMap::m_patchSize
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_patchSize_0;
	// UnityEngine.TerrainUtils.TerrainMapStatusCode UnityEngine.TerrainUtils.TerrainMap::m_errorCode
	int32_t ___m_errorCode_1;
	// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain> UnityEngine.TerrainUtils.TerrainMap::m_terrainTiles
	Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* ___m_terrainTiles_2;
};

// UnityEngine.TreeInstance
struct TreeInstance_t382B018173ED020660D262061EA9424682614F50 
{
	// UnityEngine.Vector3 UnityEngine.TreeInstance::position
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position_0;
	// System.Single UnityEngine.TreeInstance::widthScale
	float ___widthScale_1;
	// System.Single UnityEngine.TreeInstance::heightScale
	float ___heightScale_2;
	// System.Single UnityEngine.TreeInstance::rotation
	float ___rotation_3;
	// UnityEngine.Color32 UnityEngine.TreeInstance::color
	Color32_t73C5004937BF5BB8AD55323D51AAA40A898EF48B ___color_4;
	// UnityEngine.Color32 UnityEngine.TreeInstance::lightmapColor
	Color32_t73C5004937BF5BB8AD55323D51AAA40A898EF48B ___lightmapColor_5;
	// System.Int32 UnityEngine.TreeInstance::prototypeIndex
	int32_t ___prototypeIndex_6;
	// System.Single UnityEngine.TreeInstance::temporaryDistance
	float ___temporaryDistance_7;
};

// System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>
struct Enumerator_tB06F293668D09F345A54C8C836ABF567B9087FB7 
{
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_dictionary
	Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* ____dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_version
	int32_t ____version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_index
	int32_t ____index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_current
	KeyValuePair_2_t8760984FFCA6E11154C918347EA4C7CFB2D0B8CE ____current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_getEnumeratorRetType
	int32_t ____getEnumeratorRetType_4;
};

// System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>
struct Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B 
{
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_dictionary
	Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* ____dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_version
	int32_t ____version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_index
	int32_t ____index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator::_current
	KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3 ____current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2/Enumerator::_getEnumeratorRetType
	int32_t ____getEnumeratorRetType_4;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.Material
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

// System.SystemException
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

// UnityEngine.TerrainData
struct TerrainData_t615A68EAC648066681875D47FC641496D12F2E24  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.TerrainLayer
struct TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
// Native definition for P/Invoke marshalling of UnityEngine.TerrainLayer
struct TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_pinvoke : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
};
// Native definition for COM marshalling of UnityEngine.TerrainLayer
struct TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_com : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
};

// UnityEngine.Texture
struct Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// System.Type
struct Type_t  : public MemberInfo_t
{
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl_8;
};

// System.Predicate`1<System.Object>
struct Predicate_1_t8342C85FF4E41CD1F7024AC0CDC3E5312A32CB12  : public MulticastDelegate_t
{
};

// System.Predicate`1<UnityEngine.Terrain>
struct Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055  : public MulticastDelegate_t
{
};

// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	// System.String System.ArgumentException::_paramName
	String_t* ____paramName_18;
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.RenderTexture
struct RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27  : public Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700
{
};

// UnityEngine.Texture2D
struct Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4  : public Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700
{
};

// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.TerrainCallbacks/HeightmapChangedCallback
struct HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0  : public MulticastDelegate_t
{
};

// UnityEngine.TerrainCallbacks/TextureChangedCallback
struct TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F  : public MulticastDelegate_t
{
};

// System.ArgumentNullException
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
};

// UnityEngine.Terrain
struct Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// <Module>

// <Module>

// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>

// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>

// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.Dictionary`2/KeyCollection<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.Dictionary`2/KeyCollection<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.List`1<UnityEngine.Rendering.ReflectionProbeBlendInfo>
struct List_1_t1100962F75A3C1A8DDD989C01DEE91D38A84082A_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	ReflectionProbeBlendInfoU5BU5D_tA9D04082580498268C1B2FB0BC26B2F335D86766* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<UnityEngine.Rendering.ReflectionProbeBlendInfo>

// System.Collections.Generic.List`1<UnityEngine.Terrain>
struct List_1_tD2AD001A66810CB968E98D9E635A799408554017_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<UnityEngine.Terrain>

// System.Attribute

// System.Attribute

// System.String
struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.String

// UnityEngine.TerrainCallbacks
struct TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_StaticFields
{
	// UnityEngine.TerrainCallbacks/HeightmapChangedCallback UnityEngine.TerrainCallbacks::heightmapChanged
	HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* ___heightmapChanged_0;
	// UnityEngine.TerrainCallbacks/TextureChangedCallback UnityEngine.TerrainCallbacks::textureChanged
	TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* ___textureChanged_1;
};

// UnityEngine.TerrainCallbacks

// UnityEngine.TerrainUtils.TerrainUtility

// UnityEngine.TerrainUtils.TerrainUtility

// UnityEngine.TreePrototype

// UnityEngine.TreePrototype

// UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0

// UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0

// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0

// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0

// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1

// UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1

// System.Collections.Generic.KeyValuePair`2<System.Int32,System.Object>

// System.Collections.Generic.KeyValuePair`2<System.Int32,System.Object>

// System.Collections.Generic.KeyValuePair`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>

// System.Collections.Generic.KeyValuePair`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Boolean

// UnityEngine.Color

// UnityEngine.Color

// System.Double

// System.Double

// Microsoft.CodeAnalysis.EmbeddedAttribute

// Microsoft.CodeAnalysis.EmbeddedAttribute

// System.Int32

// System.Int32

// System.IntPtr
struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// System.IntPtr

// System.Runtime.CompilerServices.IsReadOnlyAttribute

// System.Runtime.CompilerServices.IsReadOnlyAttribute

// UnityEngine.Mathf
struct Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_StaticFields
{
	// System.Single UnityEngine.Mathf::Epsilon
	float ___Epsilon_5;
};

// UnityEngine.Mathf

// UnityEngine.RectInt

// UnityEngine.RectInt

// System.Single

// System.Single

// UnityEngine.TerrainUtils.TerrainTileCoord

// UnityEngine.TerrainUtils.TerrainTileCoord

// System.UInt32

// System.UInt32

// UnityEngine.Vector2
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_StaticFields
{
	// UnityEngine.Vector2 UnityEngine.Vector2::zeroVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___zeroVector_2;
	// UnityEngine.Vector2 UnityEngine.Vector2::oneVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___oneVector_3;
	// UnityEngine.Vector2 UnityEngine.Vector2::upVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___upVector_4;
	// UnityEngine.Vector2 UnityEngine.Vector2::downVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___downVector_5;
	// UnityEngine.Vector2 UnityEngine.Vector2::leftVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___leftVector_6;
	// UnityEngine.Vector2 UnityEngine.Vector2::rightVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rightVector_7;
	// UnityEngine.Vector2 UnityEngine.Vector2::positiveInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___positiveInfinityVector_8;
	// UnityEngine.Vector2 UnityEngine.Vector2::negativeInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___negativeInfinityVector_9;
};

// UnityEngine.Vector2

// UnityEngine.Vector3
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields
{
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___negativeInfinityVector_14;
};

// UnityEngine.Vector3

// UnityEngine.Vector4
struct Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3_StaticFields
{
	// UnityEngine.Vector4 UnityEngine.Vector4::zeroVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___zeroVector_5;
	// UnityEngine.Vector4 UnityEngine.Vector4::oneVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___oneVector_6;
	// UnityEngine.Vector4 UnityEngine.Vector4::positiveInfinityVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___positiveInfinityVector_7;
	// UnityEngine.Vector4 UnityEngine.Vector4::negativeInfinityVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___negativeInfinityVector_8;
};

// UnityEngine.Vector4

// System.Void

// System.Void

// System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Object>

// System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Object>

// System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,UnityEngine.TerrainUtils.TerrainMap>

// System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,UnityEngine.TerrainUtils.TerrainMap>

// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>

// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>

// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>

// System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>

// System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Delegate

// System.Delegate

// UnityEngine.DetailPrototype
struct DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_StaticFields
{
	// UnityEngine.Color UnityEngine.DetailPrototype::DefaultHealthColor
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___DefaultHealthColor_0;
	// UnityEngine.Color UnityEngine.DetailPrototype::DefaultDryColor
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___DefaultDryColor_1;
};

// UnityEngine.DetailPrototype

// UnityEngine.MaterialPropertyBlock

// UnityEngine.MaterialPropertyBlock

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;
};

// UnityEngine.Object

// UnityEngine.TerrainUtils.TerrainMap

// UnityEngine.TerrainUtils.TerrainMap

// UnityEngine.TreeInstance

// UnityEngine.TreeInstance

// System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>

// System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>

// System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>

// UnityEngine.Component

// UnityEngine.Component

// UnityEngine.GameObject

// UnityEngine.GameObject

// UnityEngine.Material

// UnityEngine.Material

// UnityEngine.TerrainData
struct TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields
{
	// System.Int32 UnityEngine.TerrainData::k_MaximumResolution
	int32_t ___k_MaximumResolution_10;
	// System.Int32 UnityEngine.TerrainData::k_MinimumDetailResolutionPerPatch
	int32_t ___k_MinimumDetailResolutionPerPatch_11;
	// System.Int32 UnityEngine.TerrainData::k_MaximumDetailResolutionPerPatch
	int32_t ___k_MaximumDetailResolutionPerPatch_12;
	// System.Int32 UnityEngine.TerrainData::k_MaximumDetailPatchCount
	int32_t ___k_MaximumDetailPatchCount_13;
	// System.Int32 UnityEngine.TerrainData::k_MaximumDetailsPerRes
	int32_t ___k_MaximumDetailsPerRes_14;
	// System.Int32 UnityEngine.TerrainData::k_MinimumAlphamapResolution
	int32_t ___k_MinimumAlphamapResolution_15;
	// System.Int32 UnityEngine.TerrainData::k_MaximumAlphamapResolution
	int32_t ___k_MaximumAlphamapResolution_16;
	// System.Int32 UnityEngine.TerrainData::k_MinimumBaseMapResolution
	int32_t ___k_MinimumBaseMapResolution_17;
	// System.Int32 UnityEngine.TerrainData::k_MaximumBaseMapResolution
	int32_t ___k_MaximumBaseMapResolution_18;
};

// UnityEngine.TerrainData

// UnityEngine.TerrainLayer

// UnityEngine.TerrainLayer

// UnityEngine.Texture
struct Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700_StaticFields
{
	// System.Int32 UnityEngine.Texture::GenerateAllMips
	int32_t ___GenerateAllMips_4;
};

// UnityEngine.Texture

// System.Type
struct Type_t_StaticFields
{
	// System.Reflection.Binder modreq(System.Runtime.CompilerServices.IsVolatile) System.Type::s_defaultBinder
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder_0;
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_1;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes_2;
	// System.Object System.Type::Missing
	RuntimeObject* ___Missing_3;
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute_4;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName_5;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase_6;
};

// System.Type

// System.Predicate`1<System.Object>

// System.Predicate`1<System.Object>

// System.Predicate`1<UnityEngine.Terrain>

// System.Predicate`1<UnityEngine.Terrain>

// System.ArgumentException

// System.ArgumentException

// UnityEngine.Behaviour

// UnityEngine.Behaviour

// UnityEngine.RenderTexture

// UnityEngine.RenderTexture

// UnityEngine.Texture2D

// UnityEngine.Texture2D

// UnityEngine.Transform

// UnityEngine.Transform

// UnityEngine.TerrainCallbacks/HeightmapChangedCallback

// UnityEngine.TerrainCallbacks/HeightmapChangedCallback

// UnityEngine.TerrainCallbacks/TextureChangedCallback

// UnityEngine.TerrainCallbacks/TextureChangedCallback

// System.ArgumentNullException

// System.ArgumentNullException

// UnityEngine.Terrain

// UnityEngine.Terrain
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Boolean[,]
struct BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6  : public RuntimeArray
{
	ALIGN_FIELD (8) bool m_Items[1];

	inline bool GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline bool* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, bool value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline bool GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline bool* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, bool value)
	{
		m_Items[index] = value;
	}
	inline bool GetAt(il2cpp_array_size_t i, il2cpp_array_size_t j) const
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items[index];
	}
	inline bool* GetAddressAt(il2cpp_array_size_t i, il2cpp_array_size_t j)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t i, il2cpp_array_size_t j, bool value)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);

		il2cpp_array_size_t index = i * jBound + j;
		m_Items[index] = value;
	}
	inline bool GetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j) const
	{
		il2cpp_array_size_t jBound = bounds[1].length;

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items[index];
	}
	inline bool* GetAddressAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j)
	{
		il2cpp_array_size_t jBound = bounds[1].length;

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, bool value)
	{
		il2cpp_array_size_t jBound = bounds[1].length;

		il2cpp_array_size_t index = i * jBound + j;
		m_Items[index] = value;
	}
};
// UnityEngine.DetailPrototype[]
struct DetailPrototypeU5BU5D_tB9391EFBDD64B38867DFB8179C6C0E8C81998AB7  : public RuntimeArray
{
	ALIGN_FIELD (8) DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* m_Items[1];

	inline DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C  : public RuntimeArray
{
	ALIGN_FIELD (8) int32_t m_Items[1];

	inline int32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int32_t value)
	{
		m_Items[index] = value;
	}
};
// System.Int32[,]
struct Int32U5BU2CU5D_t46F2694E7DAD7B2B05C940EC5B9DE04E40D0516F  : public RuntimeArray
{
	ALIGN_FIELD (8) int32_t m_Items[1];

	inline int32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int32_t value)
	{
		m_Items[index] = value;
	}
	inline int32_t GetAt(il2cpp_array_size_t i, il2cpp_array_size_t j) const
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t i, il2cpp_array_size_t j)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t i, il2cpp_array_size_t j, int32_t value)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);

		il2cpp_array_size_t index = i * jBound + j;
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j) const
	{
		il2cpp_array_size_t jBound = bounds[1].length;

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j)
	{
		il2cpp_array_size_t jBound = bounds[1].length;

		il2cpp_array_size_t index = i * jBound + j;
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, int32_t value)
	{
		il2cpp_array_size_t jBound = bounds[1].length;

		il2cpp_array_size_t index = i * jBound + j;
		m_Items[index] = value;
	}
};
// UnityEngine.TreeInstance[]
struct TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429  : public RuntimeArray
{
	ALIGN_FIELD (8) TreeInstance_t382B018173ED020660D262061EA9424682614F50 m_Items[1];

	inline TreeInstance_t382B018173ED020660D262061EA9424682614F50 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline TreeInstance_t382B018173ED020660D262061EA9424682614F50* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, TreeInstance_t382B018173ED020660D262061EA9424682614F50 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline TreeInstance_t382B018173ED020660D262061EA9424682614F50 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline TreeInstance_t382B018173ED020660D262061EA9424682614F50* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, TreeInstance_t382B018173ED020660D262061EA9424682614F50 value)
	{
		m_Items[index] = value;
	}
};
// UnityEngine.TreePrototype[]
struct TreePrototypeU5BU5D_tB0255CA167F991C2C9BA3BA55DF7417168D93B7A  : public RuntimeArray
{
	ALIGN_FIELD (8) TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* m_Items[1];

	inline TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Single[,,]
struct SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488  : public RuntimeArray
{
	ALIGN_FIELD (8) float m_Items[1];

	inline float GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, float value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, float value)
	{
		m_Items[index] = value;
	}
	inline float GetAt(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k) const
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);
		il2cpp_array_size_t kBound = bounds[2].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(k, kBound);

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);
		il2cpp_array_size_t kBound = bounds[2].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(k, kBound);

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k, float value)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);
		il2cpp_array_size_t kBound = bounds[2].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(k, kBound);

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k) const
	{
		il2cpp_array_size_t jBound = bounds[1].length;
		il2cpp_array_size_t kBound = bounds[2].length;

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k)
	{
		il2cpp_array_size_t jBound = bounds[1].length;
		il2cpp_array_size_t kBound = bounds[2].length;

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k, float value)
	{
		il2cpp_array_size_t jBound = bounds[1].length;
		il2cpp_array_size_t kBound = bounds[2].length;

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		m_Items[index] = value;
	}
};
// UnityEngine.Texture2D[]
struct Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191  : public RuntimeArray
{
	ALIGN_FIELD (8) Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* m_Items[1];

	inline Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// UnityEngine.TerrainLayer[]
struct TerrainLayerU5BU5D_t259E391D6115F121FCD284E79F62012D70956EB0  : public RuntimeArray
{
	ALIGN_FIELD (8) TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* m_Items[1];

	inline TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// UnityEngine.Terrain[]
struct TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE  : public RuntimeArray
{
	ALIGN_FIELD (8) Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* m_Items[1];

	inline Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


// System.Boolean System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::TryGetValue(TKey,TValue&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Dictionary_2_TryGetValue_mF6F2C5F869485AA206FDE526CAA58BBC691A8AD5_gshared (Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* __this, TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ___0_key, RuntimeObject** ___1_value, const RuntimeMethod* method) ;
// System.Void System.Predicate`1<System.Object>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Predicate_1__ctor_m3E007299121A15DF80F4A210FF8C20E5DF688F20_gshared (Predicate_1_t8342C85FF4E41CD1F7024AC0CDC3E5312A32CB12* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
// System.Boolean System.Predicate`1<System.Object>::Invoke(T)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Predicate_1_Invoke_m6AC449189DCEE89A4FA2A2B724DE296A1DFB6A9B_gshared_inline (Predicate_1_t8342C85FF4E41CD1F7024AC0CDC3E5312A32CB12* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::get_Count()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Dictionary_2_get_Count_m7D1C8AC9355A50AF1C84A0A4B186C1D52083FBB7_gshared (Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2__ctor_mBEB6B3A304C6A01DA2A2E016B112DD4E73D6A0B8_gshared (Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::Add(TKey,TValue)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2_Add_mCDB94B777C71A4AEC648AEE14D9C777B05667901_gshared (Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* __this, TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ___0_key, RuntimeObject* ___1_value, const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::get_Keys()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR KeyCollection_t8A862CFF968D9AAD432E0AFA29DECB342BF06F59* Dictionary_2_get_Keys_m1A371FDB5221EB779B15B24DE039B1191CB9394D_gshared (Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<TKey,TValue> System.Collections.Generic.Dictionary`2/KeyCollection<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Enumerator_tF5348A6D692C0422DAF82BC55E5276A4D29BEF53 KeyCollection_GetEnumerator_m0046DC4034F114EC3737521FFB2F49F4C1E6F869_gshared (KeyCollection_t8A862CFF968D9AAD432E0AFA29DECB342BF06F59* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enumerator_Dispose_m499372F99070BD8E7376FF1B2EE3040325A7E141_gshared (Enumerator_tF5348A6D692C0422DAF82BC55E5276A4D29BEF53* __this, const RuntimeMethod* method) ;
// TKey System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::get_Current()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 Enumerator_get_Current_mC41EF0278150018906F2AB9D7CF81AE865E6AA1C_gshared_inline (Enumerator_tF5348A6D692C0422DAF82BC55E5276A4D29BEF53* __this, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_mEE338DC5230565298472253C6A1646332E2E83CF_gshared (Enumerator_tF5348A6D692C0422DAF82BC55E5276A4D29BEF53* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.Int32,System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m92E9AB321FBD7147CA109C822D99C8B0610C27B7_gshared (Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907* __this, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int32,System.Object>::ContainsKey(TKey)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Dictionary_2_ContainsKey_mED5C451F158CDDD2B3F4B0720CD248DA9DB27B25_gshared (Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907* __this, int32_t ___0_key, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.Int32,System.Object>::Add(TKey,TValue)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2_Add_mAF1EF7DA16BD70E252EA5C4B0F74DE519A02CBCD_gshared (Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907* __this, int32_t ___0_key, RuntimeObject* ___1_value, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.Dictionary`2<System.Int32,System.Object>::get_Count()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Dictionary_2_get_Count_mB1687BC0FFB3D5E49E5129641D4FB9EA23743F91_gshared (Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2/Enumerator<TKey,TValue> System.Collections.Generic.Dictionary`2<System.Int32,System.Object>::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Enumerator_tE92C1AC40A104A179B94F8A013728FD9314CFBD3 Dictionary_2_GetEnumerator_m3F1620145BA0815B7C7CD648EF054558AA26556A_gshared (Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Object>::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enumerator_Dispose_mAECCBE12C0427D7ACF88F82FA266F1AE37402565_gshared (Enumerator_tE92C1AC40A104A179B94F8A013728FD9314CFBD3* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Object>::get_Current()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR KeyValuePair_2_tDC26B09C26BA829DDE331BCB6AF7C508C763D7A3 Enumerator_get_Current_m90160D324DA0D9F5624A345F47D8E226A118911A_gshared_inline (Enumerator_tE92C1AC40A104A179B94F8A013728FD9314CFBD3* __this, const RuntimeMethod* method) ;
// TValue System.Collections.Generic.KeyValuePair`2<System.Int32,System.Object>::get_Value()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* KeyValuePair_2_get_Value_m8508BCECB0654E2E93B1A141382E2688ADE7EE7C_gshared_inline (KeyValuePair_2_tDC26B09C26BA829DDE331BCB6AF7C508C763D7A3* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2/Enumerator<TKey,TValue> System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Enumerator_tB06F293668D09F345A54C8C836ABF567B9087FB7 Dictionary_2_GetEnumerator_mE58E6AC88AD044F9EB9989FF2F6AA6F05ECA402F_gshared (Dictionary_2_t22B5EE7684537D7D143E6F6FCDC4C58B5D53F68F* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enumerator_Dispose_mE3662EBE47C6E066285CDB5B63ACB07D73B5CD84_gshared (Enumerator_tB06F293668D09F345A54C8C836ABF567B9087FB7* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::get_Current()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR KeyValuePair_2_t8760984FFCA6E11154C918347EA4C7CFB2D0B8CE Enumerator_get_Current_mAB48908F9E456DE35489D40F781F13159CD102CA_gshared_inline (Enumerator_tB06F293668D09F345A54C8C836ABF567B9087FB7* __this, const RuntimeMethod* method) ;
// TKey System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::get_Key()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 KeyValuePair_2_get_Key_mE27FF2218D103DBF58A36186AA62595EC4079388_gshared_inline (KeyValuePair_2_t8760984FFCA6E11154C918347EA4C7CFB2D0B8CE* __this, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,System.Object>::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_m0192F3C0DFB719827E8F40E0992166F0CE78BEE6_gshared (Enumerator_tB06F293668D09F345A54C8C836ABF567B9087FB7* __this, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Object>::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_m4DC143BC57F14EDD85AB13B6D6F3B5D0E319B30E_gshared (Enumerator_tE92C1AC40A104A179B94F8A013728FD9314CFBD3* __this, const RuntimeMethod* method) ;

// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2 (Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_m2149FA40CEC8D82AC20D3508AB40C0D8EFEF68E6 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::Internal_Create(UnityEngine.TerrainLayer)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_Internal_Create_mA5EB262D9B9D9B3180705A14040FBEAA4257D3E1 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* ___0_layer, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::get_tileSize_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_tileSize_Injected_m8D8A89EA332B064157DB6A83826870E691AA4FC5 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::set_tileSize_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_tileSize_Injected_m2D6D83EA3DFBB1948BDC4D1984BCE9D43CAF18B2 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::get_tileOffset_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_tileOffset_Injected_mA2FADD8981A297BFB4DE8663FA757834324DB8E0 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::set_tileOffset_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_tileOffset_Injected_m4082583251015F2D3621EE132031B852741C092C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::get_specular_Injected(UnityEngine.Color&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_specular_Injected_m17BCA78D6D0B917E71AE7D441367C8A30149BC3C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::set_specular_Injected(UnityEngine.Color&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_specular_Injected_mB6275B761452010AEE54E6B15F63435FA7A1D485 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::get_diffuseRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_diffuseRemapMin_Injected_m12394DF34C1CC7B138FA3389D4583EC00D555FF0 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::set_diffuseRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_diffuseRemapMin_Injected_mFA1B63F9AA91C8EA82104C4CC1A7778C5AED7706 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::get_diffuseRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_diffuseRemapMax_Injected_m2E247FD71A4D51D8E54DA3BF504C1731FB6F23AC (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::set_diffuseRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_diffuseRemapMax_Injected_m90271AB60993CFD03E422C688FAFC64017D4BEE3 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::get_maskMapRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_maskMapRemapMin_Injected_mEC87DA9E3173F7D39C047FABAB507CC4351FDF24 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::set_maskMapRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_maskMapRemapMin_Injected_m388350F2F0C06A10AF0DA39725B59103F6EE7F2C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::get_maskMapRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_maskMapRemapMax_Injected_m1BA6C54D1C610E455C6A7919E5E08EA304CA7403 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainLayer::set_maskMapRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_maskMapRemapMax_Injected_m10CF5BC6AA549FC669BCB7881D6D75D569EC20EE (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) ;
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.TreePrototype::Equals(UnityEngine.TreePrototype)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TreePrototype_Equals_m6F39B894827A28E1ADBF4403922FFCA8CF55E265 (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* ___0_other, const RuntimeMethod* method) ;
// System.Int32 System.Object::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Object_GetHashCode_m372C5A7AB16CAC13307C11C4256D706CE57E090C (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Type System.Object::GetType()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Object_GetType_mE10A8FC1E57F3DF29972CCBC026C2DC3942263B3 (RuntimeObject* __this, const RuntimeMethod* method) ;
// UnityEngine.GameObject UnityEngine.TreePrototype::get_prefab()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* TreePrototype_get_prefab_mCE1630C35B09770D35B2ECA45B98D1CB6D5AC67C (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Equality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_x, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___1_y, const RuntimeMethod* method) ;
// System.Single UnityEngine.TreePrototype::get_bendFactor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float TreePrototype_get_bendFactor_mC78774070395FFBEF5588233ED4C40D253F2B087 (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TreePrototype::get_navMeshLod()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TreePrototype_get_navMeshLod_m68F7C292A64B7560076E09BF0B3AB6D681886C6C (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.DetailPrototype::Equals(UnityEngine.DetailPrototype)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DetailPrototype_Equals_mDCF0B4B10AB82B883A1B1EE9F286D92A99636B20 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* ___0_other, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Color::op_Equality(UnityEngine.Color,UnityEngine.Color)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Color_op_Equality_mB2BDC39B0B367BA15AA8DF22F8CB0D02D20BDC71_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___0_lhs, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___1_rhs, const RuntimeMethod* method) ;
// System.Void UnityEngine.Color::.ctor(System.Single,System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___0_r, float ___1_g, float ___2_b, float ___3_a, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainData::Internal_Create(UnityEngine.TerrainData)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_Internal_Create_m79BF764CFF5F49D17E2BFC8B20F60B4CF70BE4E1 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* ___0_terrainData, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::get_internalHeightmapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_internalHeightmapResolution_m83C6A32499AAAAFDD57DF73BA460CBCF02F98118 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.TerrainData::IsHolesTextureCompressed()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainData_IsHolesTextureCompressed_mBFE653BBF59360E5382F66592EF1F3E48ED4057D (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// UnityEngine.Texture2D UnityEngine.TerrainData::GetCompressedHolesTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* TerrainData_GetCompressedHolesTexture_m219472651551DC5C4613B441C27E504DA693411F (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// UnityEngine.RenderTexture UnityEngine.TerrainData::GetHolesTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* TerrainData_GetHolesTexture_mE1BC7A225983716A760BA8ACEFEC6DEFF6EA572A (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::get_heightmapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_heightmapResolution_m39FE9A5C31A80B28021F8E2484EF5F2664798836 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainData::get_size_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_get_size_Injected_m0F56E87C4D7EDD1D84F038E4AF0F273D328CF661 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_ret, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::get_holesResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_holesResolution_m9DE109FB3A0874F7F4706543D0903AFA12D1BC53 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Void System.ArgumentException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___0_message, const RuntimeMethod* method) ;
// System.Boolean[,] UnityEngine.TerrainData::Internal_GetHoles(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* TerrainData_Internal_GetHoles_m13EE36473247F7D4E96C627CE8A4CBF0D4C329C8 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_xBase, int32_t ___1_yBase, int32_t ___2_width, int32_t ___3_height, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainData::GetInterpolatedNormal_Injected(System.Single,System.Single,UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_GetInterpolatedNormal_Injected_mF6E35FCDF546E498658E864D47EB87C22B41E571 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, float ___0_x, float ___1_y, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___2_ret, const RuntimeMethod* method) ;
// UnityEngine.TreeInstance[] UnityEngine.TerrainData::Internal_GetTreeInstances()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* TerrainData_Internal_GetTreeInstances_m0DCDC4D93E2CEC457C5BD8D0FE898B5A632E8347 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Single[,,] UnityEngine.TerrainData::Internal_GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* TerrainData_Internal_GetAlphamaps_m6891C19FF72B4394D6BAC3B098A3FCAC1FC6BF36 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::get_Internal_alphamapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_Internal_alphamapResolution_mDA8EF6055A2022B3E1E4E6ECBF8DF4387DE8A930 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::get_alphamapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_alphamapResolution_mC5D1C8FF4A5AFFCCFCF1382FED0D1AD46563D6F8 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::get_Internal_baseMapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_Internal_baseMapResolution_m160A9621FE9E5BE642C8CE8C8DA64A07DDF5830F (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::get_alphamapTextureCount()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_alphamapTextureCount_mF378908EA58CA135A4D58D586179418F1A6F14CD (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// UnityEngine.Texture2D UnityEngine.TerrainData::GetAlphamapTexture(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* TerrainData_GetAlphamapTexture_mFA6A25F6C09FE64114F69D528046E78B1581366C (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_index, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.TerrainData::GetBoundaryValue(UnityEngine.TerrainData/BoundaryValueType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E (int32_t ___0_type, const RuntimeMethod* method) ;
// System.Single UnityEngine.Terrain::get_basemapDistance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_basemapDistance_m19DDA753F682B416665C5A7E171376EEE3BF312B (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::set_basemapDistance(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_basemapDistance_m3CC75A7D5D67BA75A0E030F300A462C16905CF40 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) ;
// UnityEngine.Rendering.ShadowCastingMode UnityEngine.Terrain::get_shadowCastingMode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_shadowCastingMode_m4070042014ED55612368631D6335105FDF951114 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::set_shadowCastingMode(UnityEngine.Rendering.ShadowCastingMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_shadowCastingMode_m1267E7389BEF6EBA9B6E23044225362CD6EA79BD (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) ;
// UnityEngine.Color UnityEngine.Color::get_gray()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Color_get_gray_m6D01087E0F20F34718EBA5B213853B4BB49F1DEF_inline (const RuntimeMethod* method) ;
// UnityEngine.TerrainData UnityEngine.Terrain::get_terrainData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainData::SyncHeightmap()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_SyncHeightmap_mD8D77E9DD9063B7201D062C810CFEAF2BE743267 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::get_lightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_get_lightmapScaleOffset_Injected_mD2EAABA59EC39ABCF49DAF4F0EA8273664B65562 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::set_lightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_lightmapScaleOffset_Injected_m6EE17634B3B017635B441AB3224BA8E3A1E5DE47 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::get_realtimeLightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_get_realtimeLightmapScaleOffset_Injected_m29ECF237E6B854DBF05C2BF365431CDAE3B4EDE4 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::set_realtimeLightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_realtimeLightmapScaleOffset_Injected_mF70656C179FC898C168A2F8AD8009D6CF21FE4FF (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::get_patchBoundsMultiplier_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_get_patchBoundsMultiplier_Injected_m50860EC61F48B0DEB611BED7571AE29B436982F6 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::set_patchBoundsMultiplier_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_patchBoundsMultiplier_Injected_mD42F66A68FF0A7BE6E39B7C962EEEAC055F2E462 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_value, const RuntimeMethod* method) ;
// System.Single UnityEngine.Terrain::SampleHeight_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_SampleHeight_Injected_m08851544EDBB88AFD061CD7E63E7995203BC7557 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_worldPosition, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::AddTreeInstance_Injected(UnityEngine.TreeInstance&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_AddTreeInstance_Injected_m68720D1D8743CF74F8911B424DD9284C78563210 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, TreeInstance_t382B018173ED020660D262061EA9424682614F50* ___0_instance, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::GetPosition_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_GetPosition_Injected_m23EC0958466016EFB553CFBBE1B6E4FB076FE419 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_ret, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::RemoveTrees_Injected(UnityEngine.Vector2&,System.Single,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_RemoveTrees_Injected_m7401D70AB9B44261A015FB398996D1041CB46846 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_position, float ___1_radius, int32_t ___2_prototypeIndex, const RuntimeMethod* method) ;
// System.Void System.ArgumentNullException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* __this, String_t* ___0_paramName, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::Internal_GetSplatMaterialPropertyBlock(UnityEngine.MaterialPropertyBlock)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_Internal_GetSplatMaterialPropertyBlock_m30EF43010BAE0F7F7AD19041E36A4F44F023D61E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* ___0_dest, const RuntimeMethod* method) ;
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_heightmapFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_heightmapFormat_m7BDD479FF7710457999A405C226D2AEE901DDF87 (const RuntimeMethod* method) ;
// UnityEngine.TextureFormat UnityEngine.Experimental.Rendering.GraphicsFormatUtility::GetTextureFormat(UnityEngine.Experimental.Rendering.GraphicsFormat)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GraphicsFormatUtility_GetTextureFormat_mBFDD045E2526CDF13BC3C34D8E342F4797D467F4 (int32_t ___0_format, const RuntimeMethod* method) ;
// UnityEngine.RenderTextureFormat UnityEngine.Experimental.Rendering.GraphicsFormatUtility::GetRenderTextureFormat(UnityEngine.Experimental.Rendering.GraphicsFormat)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GraphicsFormatUtility_GetRenderTextureFormat_mA538222F90B6079E95ADA1DFB3DDDA740B27D8D5 (int32_t ___0_format, const RuntimeMethod* method) ;
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_normalmapFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_normalmapFormat_m70C88E3838D7938A60BFBBEF5BB2EFCD99EBA716 (const RuntimeMethod* method) ;
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_holesFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_holesFormat_m3BCE4632B6CE7D1A058070DC65CEDEF5365838BE (const RuntimeMethod* method) ;
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_compressedHolesFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_compressedHolesFormat_m386E6544EE29FC198609605B796C8DD06983658C (const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::Internal_FillActiveTerrainList(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_Internal_FillActiveTerrainList_m00E77C57C0ED1C10647C734780A511DF56B50692 (RuntimeObject* ___0_terrainList, const RuntimeMethod* method) ;
// System.Void UnityEngine.Behaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Behaviour__ctor_m00422B6EFEA829BCB116D715E74F1EAD2CB6F4F8 (Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA* __this, const RuntimeMethod* method) ;
// UnityEngine.Terrain[] UnityEngine.TerrainData::get_users()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* TerrainData_get_users_m0C569F1AD5853CEBF3C572723A1CAD04AC8433C4 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainCallbacks/HeightmapChangedCallback::Invoke(UnityEngine.Terrain,UnityEngine.RectInt,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_inline (HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainCallbacks/TextureChangedCallback::Invoke(UnityEngine.Terrain,System.String,UnityEngine.RectInt,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_inline (TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainUtils.TerrainTileCoord::.ctor(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainTileCoord__ctor_m6B6744655B9C3BA9B1A92076F07002B4B4EB899A (TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09* __this, int32_t ___0_tileX, int32_t ___1_tileZ, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::TryGetValue(TKey,TValue&)
inline bool Dictionary_2_TryGetValue_mA4944115ADCBA991881F907C9E48413EB1EFE42A (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* __this, TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ___0_key, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667** ___1_value, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119*, TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667**, const RuntimeMethod*))Dictionary_2_TryGetValue_mF6F2C5F869485AA206FDE526CAA58BBC691A8AD5_gshared)(__this, ___0_key, ___1_value, method);
}
// System.Void UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass3_0__ctor_mAFD4AEF760F5CC7CE66BAD750DAD3697397E8945 (U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3* __this, const RuntimeMethod* method) ;
// UnityEngine.Terrain[] UnityEngine.Terrain::get_activeTerrains()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701 (const RuntimeMethod* method) ;
// System.Int32 UnityEngine.Terrain::get_groupingID()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) ;
// UnityEngine.Transform UnityEngine.Component::get_transform()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371 (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Transform::get_position()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.TerrainData::get_size()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) ;
// System.Void System.Predicate`1<UnityEngine.Terrain>::.ctor(System.Object,System.IntPtr)
inline void Predicate_1__ctor_m80A5EFAAAC439A069D5782C725DF325FDD5D891C (Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method)
{
	((  void (*) (Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055*, RuntimeObject*, intptr_t, const RuntimeMethod*))Predicate_1__ctor_m3E007299121A15DF80F4A210FF8C20E5DF688F20_gshared)(__this, ___0_object, ___1_method, method);
}
// System.Void UnityEngine.Vector2::.ctor(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___0_x, float ___1_y, const RuntimeMethod* method) ;
// UnityEngine.TerrainUtils.TerrainMap UnityEngine.TerrainUtils.TerrainMap::CreateFromPlacement(UnityEngine.Vector2,UnityEngine.Vector2,System.Predicate`1<UnityEngine.Terrain>,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* TerrainMap_CreateFromPlacement_m64B90ADBC1D3A1AE18CEC7D0B452377E10B2BCB5 (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___0_gridOrigin, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___1_gridSize, Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* ___2_filter, bool ___3_fullValidation, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainUtils.TerrainMap::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainMap__ctor_mCDB47BA50D9D54E65754028F9CF8F91828FE616F (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, const RuntimeMethod* method) ;
// System.Boolean System.Predicate`1<UnityEngine.Terrain>::Invoke(T)
inline bool Predicate_1_Invoke_mA6B25B82B5FF8BFA2DCF9E5A8600C761222B0B2A_inline (Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_obj, const RuntimeMethod* method)
{
	return ((  bool (*) (Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, const RuntimeMethod*))Predicate_1_Invoke_m6AC449189DCEE89A4FA2A2B724DE296A1DFB6A9B_gshared_inline)(__this, ___0_obj, method);
}
// System.Int32 UnityEngine.Mathf::RoundToInt(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Mathf_RoundToInt_m60F8B66CF27F1FA75AA219342BD184B75771EB4B_inline (float ___0_f, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.TerrainUtils.TerrainMap::TryToAddTerrain(System.Int32,System.Int32,UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainMap_TryToAddTerrain_m03A05C883F317FD2E6956ADD6625409E8A90BE15 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_tileX, int32_t ___1_tileZ, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___2_terrain, const RuntimeMethod* method) ;
// UnityEngine.TerrainUtils.TerrainMapStatusCode UnityEngine.TerrainUtils.TerrainMap::Validate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainMap_Validate_mAFBB4A2D0290E25D59902A1BD5DA1EBC2ACD1326 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::get_Count()
inline int32_t Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024 (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119*, const RuntimeMethod*))Dictionary_2_get_Count_m7D1C8AC9355A50AF1C84A0A4B186C1D52083FBB7_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::.ctor()
inline void Dictionary_2__ctor_mCA22422F902B1FF70914D8FA2EF849DA0DCDC87D (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119*, const RuntimeMethod*))Dictionary_2__ctor_mBEB6B3A304C6A01DA2A2E016B112DD4E73D6A0B8_gshared)(__this, method);
}
// System.Boolean UnityEngine.Vector3::op_Inequality(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Inequality_m9F170CDFBF1E490E559DA5D06D6547501A402BBF_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___0_lhs, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___1_rhs, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::Add(TKey,TValue)
inline void Dictionary_2_Add_m265E9FB46C80D234AEB47C08D701628D57DBA132 (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* __this, TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 ___0_key, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___1_value, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119*, TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, const RuntimeMethod*))Dictionary_2_Add_mCDB94B777C71A4AEC648AEE14D9C777B05667901_gshared)(__this, ___0_key, ___1_value, method);
}
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_x, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___1_y, const RuntimeMethod* method) ;
// UnityEngine.Terrain UnityEngine.TerrainUtils.TerrainMap::GetTerrain(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_tileX, int32_t ___1_tileZ, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainUtils.TerrainMap::AddTerrainInternal(System.Int32,System.Int32,UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainMap_AddTerrainInternal_m507CE3A3F880B33CA2330F69464E3511D5B9BD71 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_x, int32_t ___1_z, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___2_terrain, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Implicit(UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_exists, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Mathf::Approximately(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline (float ___0_a, float ___1_b, const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::get_Keys()
inline KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E* Dictionary_2_get_Keys_mBE9BF06497225D54AC2D2D7AEF6D0F94169B10D4 (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* __this, const RuntimeMethod* method)
{
	return ((  KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E* (*) (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119*, const RuntimeMethod*))Dictionary_2_get_Keys_m1A371FDB5221EB779B15B24DE039B1191CB9394D_gshared)(__this, method);
}
// System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<TKey,TValue> System.Collections.Generic.Dictionary`2/KeyCollection<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::GetEnumerator()
inline Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689 KeyCollection_GetEnumerator_m7D86741C1BEF055A22281CF69C6235BFD1E7D521 (KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E* __this, const RuntimeMethod* method)
{
	return ((  Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689 (*) (KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E*, const RuntimeMethod*))KeyCollection_GetEnumerator_m0046DC4034F114EC3737521FFB2F49F4C1E6F869_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::Dispose()
inline void Enumerator_Dispose_mC60AECD5D4FA770371F4B374F2B026F7198CEF03 (Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689* __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689*, const RuntimeMethod*))Enumerator_Dispose_m499372F99070BD8E7376FF1B2EE3040325A7E141_gshared)(__this, method);
}
// TKey System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::get_Current()
inline TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 Enumerator_get_Current_m88A7ECB72C871AEFAD87667D8512A109C33E7080_inline (Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689* __this, const RuntimeMethod* method)
{
	return ((  TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 (*) (Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689*, const RuntimeMethod*))Enumerator_get_Current_mC41EF0278150018906F2AB9D7CF81AE865E6AA1C_gshared_inline)(__this, method);
}
// System.Void UnityEngine.TerrainUtils.TerrainMap::ValidateTerrain(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainMap_ValidateTerrain_m8D9B035B3851E0ED8BB5877BD11F63BA85029653 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_tileX, int32_t ___1_tileZ, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2/KeyCollection/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::MoveNext()
inline bool Enumerator_MoveNext_m6430F89661ED2AEDEAD6FD241BBDA21BF02135DC (Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689*, const RuntimeMethod*))Enumerator_MoveNext_mEE338DC5230565298472253C6A1646332E2E83CF_gshared)(__this, method);
}
// System.Boolean UnityEngine.Terrain::get_allowAutoConnect()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Terrain::SetNeighbors(UnityEngine.Terrain,UnityEngine.Terrain,UnityEngine.Terrain,UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_SetNeighbors_m2FFA89D199120125D264EF7EE0BC749A35514C1E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_left, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___1_top, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___2_right, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___3_bottom, const RuntimeMethod* method) ;
// System.Void UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass2_0__ctor_m4C022C4675BA4CFC7E7AAA5692979CDE6CD8E611 (U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.TerrainUtils.TerrainUtility::ValidTerrainsExist()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainUtility_ValidTerrainsExist_m0DD08E4CEC739929A9AEBCEA849EDFE79985A207 (const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::.ctor()
inline void Dictionary_2__ctor_m5665AD243B285B8D26138C699D544F4124AC7D78 (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*, const RuntimeMethod*))Dictionary_2__ctor_m92E9AB321FBD7147CA109C822D99C8B0610C27B7_gshared)(__this, method);
}
// System.Void UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass2_1__ctor_mA329ED5B221AE8787EAEA1124A2A95675FDD1695 (U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* __this, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::ContainsKey(TKey)
inline bool Dictionary_2_ContainsKey_m384365266E590EDD82F8949169A3C502E643AC95 (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* __this, int32_t ___0_key, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*, int32_t, const RuntimeMethod*))Dictionary_2_ContainsKey_mED5C451F158CDDD2B3F4B0720CD248DA9DB27B25_gshared)(__this, ___0_key, method);
}
// UnityEngine.TerrainUtils.TerrainMap UnityEngine.TerrainUtils.TerrainMap::CreateFromPlacement(UnityEngine.Terrain,System.Predicate`1<UnityEngine.Terrain>,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* TerrainMap_CreateFromPlacement_mC7822A5F4FC2A2CB119259A48F19D364ACEC5AE7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_originTerrain, Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* ___1_filter, bool ___2_fullValidation, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::Add(TKey,TValue)
inline void Dictionary_2_Add_m4E7AE6465929CEEA79B5921CFF3D4BD64E249AF9 (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* __this, int32_t ___0_key, TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* ___1_value, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*, int32_t, TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB*, const RuntimeMethod*))Dictionary_2_Add_mAF1EF7DA16BD70E252EA5C4B0F74DE519A02CBCD_gshared)(__this, ___0_key, ___1_value, method);
}
// System.Int32 System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::get_Count()
inline int32_t Dictionary_2_get_Count_m001233C3B4F8B3D1A8F044C9D43104F1671688DC (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*, const RuntimeMethod*))Dictionary_2_get_Count_mB1687BC0FFB3D5E49E5129641D4FB9EA23743F91_gshared)(__this, method);
}
// System.Void UnityEngine.TerrainUtils.TerrainUtility::ClearConnectivity()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainUtility_ClearConnectivity_m7448E42CD3F2941EF02C10DE358778EEAF9B0AA9 (const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap> UnityEngine.TerrainUtils.TerrainUtility::CollectTerrains(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* TerrainUtility_CollectTerrains_mDFCA0AFA00FFD16CEC8B4EFA9C55E3B7B6803EC4 (bool ___0_onlyAutoConnectedTerrains, const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2/Enumerator<TKey,TValue> System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::GetEnumerator()
inline Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F Dictionary_2_GetEnumerator_m5461BE3EE48320EA8E593506F16860A2CB4E9056 (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* __this, const RuntimeMethod* method)
{
	return ((  Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F (*) (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*, const RuntimeMethod*))Dictionary_2_GetEnumerator_m3F1620145BA0815B7C7CD648EF054558AA26556A_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::Dispose()
inline void Enumerator_Dispose_m09F8467FB404D375259C17136F2213FC8455F2BF (Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F* __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F*, const RuntimeMethod*))Enumerator_Dispose_mAECCBE12C0427D7ACF88F82FA266F1AE37402565_gshared)(__this, method);
}
// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::get_Current()
inline KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873 Enumerator_get_Current_m1F085EA2ABB67CCEB29CC4A10D6FBC0F2B963349_inline (Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F* __this, const RuntimeMethod* method)
{
	return ((  KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873 (*) (Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F*, const RuntimeMethod*))Enumerator_get_Current_m90160D324DA0D9F5624A345F47D8E226A118911A_gshared_inline)(__this, method);
}
// TValue System.Collections.Generic.KeyValuePair`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::get_Value()
inline TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* KeyValuePair_2_get_Value_m32D4949D8D2F580E35346D41EBB14C7933B93482_inline (KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873* __this, const RuntimeMethod* method)
{
	return ((  TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* (*) (KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873*, const RuntimeMethod*))KeyValuePair_2_get_Value_m8508BCECB0654E2E93B1A141382E2688ADE7EE7C_gshared_inline)(__this, method);
}
// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain> UnityEngine.TerrainUtils.TerrainMap::get_terrainTiles()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* TerrainMap_get_terrainTiles_m9EAA8FCB972C834E2093DDD49B26DBBA2E74A2AB_inline (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.Dictionary`2/Enumerator<TKey,TValue> System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::GetEnumerator()
inline Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B Dictionary_2_GetEnumerator_m50800AFD24DEE5F8ACB58E1535F2A472B478E473 (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* __this, const RuntimeMethod* method)
{
	return ((  Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B (*) (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119*, const RuntimeMethod*))Dictionary_2_GetEnumerator_mE58E6AC88AD044F9EB9989FF2F6AA6F05ECA402F_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::Dispose()
inline void Enumerator_Dispose_mDDABE6027BD9E377D6E3FC7F60CE5DDB0ADC47D7 (Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B* __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B*, const RuntimeMethod*))Enumerator_Dispose_mE3662EBE47C6E066285CDB5B63ACB07D73B5CD84_gshared)(__this, method);
}
// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::get_Current()
inline KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3 Enumerator_get_Current_mCD48A37B44C4A6E441AF6806E0821A24A22A51F3_inline (Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B* __this, const RuntimeMethod* method)
{
	return ((  KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3 (*) (Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B*, const RuntimeMethod*))Enumerator_get_Current_mAB48908F9E456DE35489D40F781F13159CD102CA_gshared_inline)(__this, method);
}
// TKey System.Collections.Generic.KeyValuePair`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::get_Key()
inline TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 KeyValuePair_2_get_Key_mFE7731B1C41692F16EB45AC2D63092AC73156A8A_inline (KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3* __this, const RuntimeMethod* method)
{
	return ((  TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 (*) (KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3*, const RuntimeMethod*))KeyValuePair_2_get_Key_mE27FF2218D103DBF58A36186AA62595EC4079388_gshared_inline)(__this, method);
}
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain>::MoveNext()
inline bool Enumerator_MoveNext_m1BA7CBA94F8FC389211722A43E22BB110102ABB4 (Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B*, const RuntimeMethod*))Enumerator_MoveNext_m0192F3C0DFB719827E8F40E0992166F0CE78BEE6_gshared)(__this, method);
}
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,UnityEngine.TerrainUtils.TerrainMap>::MoveNext()
inline bool Enumerator_MoveNext_m1CEA4A6A000E5344DB72DFF5E4FF563FF67F3558 (Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F*, const RuntimeMethod*))Enumerator_MoveNext_m4DC143BC57F14EDD85AB13B6D6F3B5D0E319B30E_gshared)(__this, method);
}
// UnityEngine.Vector4 UnityEngine.Color::op_Implicit(UnityEngine.Color)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 Color_op_Implicit_m9B3228DAFA8DC57A75DE00CBBF13ED4F1E7B01FF_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___0_c, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Vector4::op_Equality(UnityEngine.Vector4,UnityEngine.Vector4)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector4_op_Equality_mCEA0E5F229F4AE8C55152F7A8F84345F24F52DC6_inline (Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_lhs, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___1_rhs, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Vector3::op_Equality(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Equality_mCDCBB8D2EDC3D3BF20F31A25ACB34705D352B479_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___0_lhs, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___1_rhs, const RuntimeMethod* method) ;
// System.Single UnityEngine.Mathf::Max(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Max_mF5379E63D2BBAC76D090748695D833934F8AD051_inline (float ___0_a, float ___1_b, const RuntimeMethod* method) ;
// System.Void UnityEngine.Vector4::.ctor(System.Single,System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector4__ctor_m96B2CD8B862B271F513AF0BDC2EABD58E4DBC813_inline (Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* __this, float ___0_x, float ___1_y, float ___2_z, float ___3_w, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EmbeddedAttribute__ctor_mBB01735E786E7770A1B2ECAA65D1219B6D039DA5 (EmbeddedAttribute_t62225631BB65062906FDEF1ED16845EF6E34BB4A* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IsReadOnlyAttribute__ctor_mC20B41FF7D952FD1FE27E289E221F34681837870 (IsReadOnlyAttribute_tA42E96C61DFF3800E657E708BCD33A06F6CD2D7B* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Conversion methods for marshalling of: UnityEngine.TerrainLayer
IL2CPP_EXTERN_C void TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshal_pinvoke(const TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9& unmarshaled, TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_pinvoke& marshaled)
{
	marshaled.___m_CachedPtr_0 = unmarshaled.___m_CachedPtr_0;
}
IL2CPP_EXTERN_C void TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshal_pinvoke_back(const TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_pinvoke& marshaled, TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9& unmarshaled)
{
	intptr_t unmarshaledm_CachedPtr_temp_0;
	memset((&unmarshaledm_CachedPtr_temp_0), 0, sizeof(unmarshaledm_CachedPtr_temp_0));
	unmarshaledm_CachedPtr_temp_0 = marshaled.___m_CachedPtr_0;
	unmarshaled.___m_CachedPtr_0 = unmarshaledm_CachedPtr_temp_0;
}
// Conversion method for clean up from marshalling of: UnityEngine.TerrainLayer
IL2CPP_EXTERN_C void TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshal_pinvoke_cleanup(TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: UnityEngine.TerrainLayer
IL2CPP_EXTERN_C void TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshal_com(const TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9& unmarshaled, TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_com& marshaled)
{
	marshaled.___m_CachedPtr_0 = unmarshaled.___m_CachedPtr_0;
}
IL2CPP_EXTERN_C void TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshal_com_back(const TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_com& marshaled, TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9& unmarshaled)
{
	intptr_t unmarshaledm_CachedPtr_temp_0;
	memset((&unmarshaledm_CachedPtr_temp_0), 0, sizeof(unmarshaledm_CachedPtr_temp_0));
	unmarshaledm_CachedPtr_temp_0 = marshaled.___m_CachedPtr_0;
	unmarshaled.___m_CachedPtr_0 = unmarshaledm_CachedPtr_temp_0;
}
// Conversion method for clean up from marshalling of: UnityEngine.TerrainLayer
IL2CPP_EXTERN_C void TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshal_com_cleanup(TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9_marshaled_com& marshaled)
{
}
// System.Void UnityEngine.TerrainLayer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer__ctor_m3B6D12B4296D98B5813C08DF87D09022BD8FDC74 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		Object__ctor_m2149FA40CEC8D82AC20D3508AB40C0D8EFEF68E6(__this, NULL);
		TerrainLayer_Internal_Create_mA5EB262D9B9D9B3180705A14040FBEAA4257D3E1(__this, NULL);
		return;
	}
}
// System.Void UnityEngine.TerrainLayer::Internal_Create(UnityEngine.TerrainLayer)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_Internal_Create_mA5EB262D9B9D9B3180705A14040FBEAA4257D3E1 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* ___0_layer, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_Internal_Create_mA5EB262D9B9D9B3180705A14040FBEAA4257D3E1_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*);
	static TerrainLayer_Internal_Create_mA5EB262D9B9D9B3180705A14040FBEAA4257D3E1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_Internal_Create_mA5EB262D9B9D9B3180705A14040FBEAA4257D3E1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::Internal_Create(UnityEngine.TerrainLayer)");
	_il2cpp_icall_func(___0_layer);
}
// UnityEngine.Texture2D UnityEngine.TerrainLayer::get_diffuseTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* TerrainLayer_get_diffuseTexture_mAF75D09F08293C26B26D7D422B4A0ACC9732DD31 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	typedef Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* (*TerrainLayer_get_diffuseTexture_mAF75D09F08293C26B26D7D422B4A0ACC9732DD31_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*);
	static TerrainLayer_get_diffuseTexture_mAF75D09F08293C26B26D7D422B4A0ACC9732DD31_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_diffuseTexture_mAF75D09F08293C26B26D7D422B4A0ACC9732DD31_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_diffuseTexture()");
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainLayer::set_diffuseTexture(UnityEngine.Texture2D)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_diffuseTexture_mC21DEF81B6B58FD1BA8FA381FD569E2DB6173C53 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_diffuseTexture_mC21DEF81B6B58FD1BA8FA381FD569E2DB6173C53_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*);
	static TerrainLayer_set_diffuseTexture_mC21DEF81B6B58FD1BA8FA381FD569E2DB6173C53_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_diffuseTexture_mC21DEF81B6B58FD1BA8FA381FD569E2DB6173C53_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_diffuseTexture(UnityEngine.Texture2D)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Texture2D UnityEngine.TerrainLayer::get_normalMapTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* TerrainLayer_get_normalMapTexture_mCBC9DFA1E5243F5227A99A2D7CBF53BE259E9620 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	typedef Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* (*TerrainLayer_get_normalMapTexture_mCBC9DFA1E5243F5227A99A2D7CBF53BE259E9620_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*);
	static TerrainLayer_get_normalMapTexture_mCBC9DFA1E5243F5227A99A2D7CBF53BE259E9620_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_normalMapTexture_mCBC9DFA1E5243F5227A99A2D7CBF53BE259E9620_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_normalMapTexture()");
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainLayer::set_normalMapTexture(UnityEngine.Texture2D)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_normalMapTexture_m6E4BC16FFD3E9C2351E208F38CB1C8B99DD3F5AE (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_normalMapTexture_m6E4BC16FFD3E9C2351E208F38CB1C8B99DD3F5AE_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*);
	static TerrainLayer_set_normalMapTexture_m6E4BC16FFD3E9C2351E208F38CB1C8B99DD3F5AE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_normalMapTexture_m6E4BC16FFD3E9C2351E208F38CB1C8B99DD3F5AE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_normalMapTexture(UnityEngine.Texture2D)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Texture2D UnityEngine.TerrainLayer::get_maskMapTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* TerrainLayer_get_maskMapTexture_m184F1143BA11213B5B6E1D3487BCDF8A747954EA (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	typedef Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* (*TerrainLayer_get_maskMapTexture_m184F1143BA11213B5B6E1D3487BCDF8A747954EA_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*);
	static TerrainLayer_get_maskMapTexture_m184F1143BA11213B5B6E1D3487BCDF8A747954EA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_maskMapTexture_m184F1143BA11213B5B6E1D3487BCDF8A747954EA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_maskMapTexture()");
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainLayer::set_maskMapTexture(UnityEngine.Texture2D)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_maskMapTexture_m7A5384131F06DF24AB8F9B2D0E8C7A8510A17F78 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_maskMapTexture_m7A5384131F06DF24AB8F9B2D0E8C7A8510A17F78_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*);
	static TerrainLayer_set_maskMapTexture_m7A5384131F06DF24AB8F9B2D0E8C7A8510A17F78_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_maskMapTexture_m7A5384131F06DF24AB8F9B2D0E8C7A8510A17F78_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_maskMapTexture(UnityEngine.Texture2D)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Vector2 UnityEngine.TerrainLayer::get_tileSize()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 TerrainLayer_get_tileSize_mF6313141BE22D6AC7362DA9A40FB41236458E0A3 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainLayer_get_tileSize_Injected_m8D8A89EA332B064157DB6A83826870E691AA4FC5(__this, (&V_0), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainLayer::set_tileSize(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_tileSize_m53D498E2704EF4B92B11588CF47C726923D57F84 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___0_value, const RuntimeMethod* method) 
{
	{
		TerrainLayer_set_tileSize_Injected_m2D6D83EA3DFBB1948BDC4D1984BCE9D43CAF18B2(__this, (&___0_value), NULL);
		return;
	}
}
// UnityEngine.Vector2 UnityEngine.TerrainLayer::get_tileOffset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 TerrainLayer_get_tileOffset_m1E81B6D002E91BE4EF402337C595227221E8163D (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainLayer_get_tileOffset_Injected_mA2FADD8981A297BFB4DE8663FA757834324DB8E0(__this, (&V_0), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainLayer::set_tileOffset(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_tileOffset_m259D3D0F278A65D405923BF0338766BDA79556A9 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___0_value, const RuntimeMethod* method) 
{
	{
		TerrainLayer_set_tileOffset_Injected_m4082583251015F2D3621EE132031B852741C092C(__this, (&___0_value), NULL);
		return;
	}
}
// UnityEngine.Color UnityEngine.TerrainLayer::get_specular()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F TerrainLayer_get_specular_m14209D88524F3739C026F906A8D34B3597EEE07A (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainLayer_get_specular_Injected_m17BCA78D6D0B917E71AE7D441367C8A30149BC3C(__this, (&V_0), NULL);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainLayer::set_specular(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_specular_mE0E85F57BCD6D771826D57562E6EADDA4E14F538 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___0_value, const RuntimeMethod* method) 
{
	{
		TerrainLayer_set_specular_Injected_mB6275B761452010AEE54E6B15F63435FA7A1D485(__this, (&___0_value), NULL);
		return;
	}
}
// System.Single UnityEngine.TerrainLayer::get_metallic()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float TerrainLayer_get_metallic_m99FCD988D3CE9CADBDD23C9E0C92095DB66F2EE8 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	typedef float (*TerrainLayer_get_metallic_m99FCD988D3CE9CADBDD23C9E0C92095DB66F2EE8_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*);
	static TerrainLayer_get_metallic_m99FCD988D3CE9CADBDD23C9E0C92095DB66F2EE8_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_metallic_m99FCD988D3CE9CADBDD23C9E0C92095DB66F2EE8_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_metallic()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainLayer::set_metallic(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_metallic_mAD23C76C3953D3A6D54CFC9B399A13841F8F1E87 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_metallic_mAD23C76C3953D3A6D54CFC9B399A13841F8F1E87_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, float);
	static TerrainLayer_set_metallic_mAD23C76C3953D3A6D54CFC9B399A13841F8F1E87_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_metallic_mAD23C76C3953D3A6D54CFC9B399A13841F8F1E87_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_metallic(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.TerrainLayer::get_smoothness()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float TerrainLayer_get_smoothness_m79BBB46810976A88A0BADB0D52A0C028781C7120 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	typedef float (*TerrainLayer_get_smoothness_m79BBB46810976A88A0BADB0D52A0C028781C7120_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*);
	static TerrainLayer_get_smoothness_m79BBB46810976A88A0BADB0D52A0C028781C7120_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_smoothness_m79BBB46810976A88A0BADB0D52A0C028781C7120_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_smoothness()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainLayer::set_smoothness(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_smoothness_mB79F6272E5AA2F3F103B22382A2FFEB418EB1172 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_smoothness_mB79F6272E5AA2F3F103B22382A2FFEB418EB1172_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, float);
	static TerrainLayer_set_smoothness_mB79F6272E5AA2F3F103B22382A2FFEB418EB1172_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_smoothness_mB79F6272E5AA2F3F103B22382A2FFEB418EB1172_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_smoothness(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.TerrainLayer::get_normalScale()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float TerrainLayer_get_normalScale_m63EA677D87ABD1DCF0195D35A8B9738B80C70B3C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	typedef float (*TerrainLayer_get_normalScale_m63EA677D87ABD1DCF0195D35A8B9738B80C70B3C_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*);
	static TerrainLayer_get_normalScale_m63EA677D87ABD1DCF0195D35A8B9738B80C70B3C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_normalScale_m63EA677D87ABD1DCF0195D35A8B9738B80C70B3C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_normalScale()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainLayer::set_normalScale(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_normalScale_m0758116D1F0B171EDB48B4E2A13490C1A5703991 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_normalScale_m0758116D1F0B171EDB48B4E2A13490C1A5703991_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, float);
	static TerrainLayer_set_normalScale_m0758116D1F0B171EDB48B4E2A13490C1A5703991_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_normalScale_m0758116D1F0B171EDB48B4E2A13490C1A5703991_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_normalScale(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Vector4 UnityEngine.TerrainLayer::get_diffuseRemapMin()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 TerrainLayer_get_diffuseRemapMin_m949BAC51C5758A977052835D009CC8A2949E9F98 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainLayer_get_diffuseRemapMin_Injected_m12394DF34C1CC7B138FA3389D4583EC00D555FF0(__this, (&V_0), NULL);
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainLayer::set_diffuseRemapMin(UnityEngine.Vector4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_diffuseRemapMin_m5899CADEF34D6193180D9B79B1E86E38C05869A9 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_value, const RuntimeMethod* method) 
{
	{
		TerrainLayer_set_diffuseRemapMin_Injected_mFA1B63F9AA91C8EA82104C4CC1A7778C5AED7706(__this, (&___0_value), NULL);
		return;
	}
}
// UnityEngine.Vector4 UnityEngine.TerrainLayer::get_diffuseRemapMax()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 TerrainLayer_get_diffuseRemapMax_mCA5648C5150800713F24E7D2AB96B4D548E2D4BC (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainLayer_get_diffuseRemapMax_Injected_m2E247FD71A4D51D8E54DA3BF504C1731FB6F23AC(__this, (&V_0), NULL);
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainLayer::set_diffuseRemapMax(UnityEngine.Vector4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_diffuseRemapMax_mEFA03F94C12ECEFEC2060901D966DD15BDA89D3C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_value, const RuntimeMethod* method) 
{
	{
		TerrainLayer_set_diffuseRemapMax_Injected_m90271AB60993CFD03E422C688FAFC64017D4BEE3(__this, (&___0_value), NULL);
		return;
	}
}
// UnityEngine.Vector4 UnityEngine.TerrainLayer::get_maskMapRemapMin()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 TerrainLayer_get_maskMapRemapMin_m7DF5C3CD76EA311585C8AC7102DF8FE843465368 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainLayer_get_maskMapRemapMin_Injected_mEC87DA9E3173F7D39C047FABAB507CC4351FDF24(__this, (&V_0), NULL);
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainLayer::set_maskMapRemapMin(UnityEngine.Vector4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_maskMapRemapMin_mD8778273503FD0FD05869EB86DB6EADDA553856F (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_value, const RuntimeMethod* method) 
{
	{
		TerrainLayer_set_maskMapRemapMin_Injected_m388350F2F0C06A10AF0DA39725B59103F6EE7F2C(__this, (&___0_value), NULL);
		return;
	}
}
// UnityEngine.Vector4 UnityEngine.TerrainLayer::get_maskMapRemapMax()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 TerrainLayer_get_maskMapRemapMax_mE05D91C74E45DE9F2A5AB6ABE75B2BC561ED6342 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, const RuntimeMethod* method) 
{
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainLayer_get_maskMapRemapMax_Injected_m1BA6C54D1C610E455C6A7919E5E08EA304CA7403(__this, (&V_0), NULL);
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainLayer::set_maskMapRemapMax(UnityEngine.Vector4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_maskMapRemapMax_m7E81C871C9AABC01E2F743E690FD3E9002DB008C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_value, const RuntimeMethod* method) 
{
	{
		TerrainLayer_set_maskMapRemapMax_Injected_m10CF5BC6AA549FC669BCB7881D6D75D569EC20EE(__this, (&___0_value), NULL);
		return;
	}
}
// System.Void UnityEngine.TerrainLayer::get_tileSize_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_tileSize_Injected_m8D8A89EA332B064157DB6A83826870E691AA4FC5 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_get_tileSize_Injected_m8D8A89EA332B064157DB6A83826870E691AA4FC5_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*);
	static TerrainLayer_get_tileSize_Injected_m8D8A89EA332B064157DB6A83826870E691AA4FC5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_tileSize_Injected_m8D8A89EA332B064157DB6A83826870E691AA4FC5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_tileSize_Injected(UnityEngine.Vector2&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainLayer::set_tileSize_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_tileSize_Injected_m2D6D83EA3DFBB1948BDC4D1984BCE9D43CAF18B2 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_tileSize_Injected_m2D6D83EA3DFBB1948BDC4D1984BCE9D43CAF18B2_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*);
	static TerrainLayer_set_tileSize_Injected_m2D6D83EA3DFBB1948BDC4D1984BCE9D43CAF18B2_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_tileSize_Injected_m2D6D83EA3DFBB1948BDC4D1984BCE9D43CAF18B2_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_tileSize_Injected(UnityEngine.Vector2&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.TerrainLayer::get_tileOffset_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_tileOffset_Injected_mA2FADD8981A297BFB4DE8663FA757834324DB8E0 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_get_tileOffset_Injected_mA2FADD8981A297BFB4DE8663FA757834324DB8E0_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*);
	static TerrainLayer_get_tileOffset_Injected_mA2FADD8981A297BFB4DE8663FA757834324DB8E0_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_tileOffset_Injected_mA2FADD8981A297BFB4DE8663FA757834324DB8E0_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_tileOffset_Injected(UnityEngine.Vector2&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainLayer::set_tileOffset_Injected(UnityEngine.Vector2&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_tileOffset_Injected_m4082583251015F2D3621EE132031B852741C092C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_tileOffset_Injected_m4082583251015F2D3621EE132031B852741C092C_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*);
	static TerrainLayer_set_tileOffset_Injected_m4082583251015F2D3621EE132031B852741C092C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_tileOffset_Injected_m4082583251015F2D3621EE132031B852741C092C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_tileOffset_Injected(UnityEngine.Vector2&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.TerrainLayer::get_specular_Injected(UnityEngine.Color&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_specular_Injected_m17BCA78D6D0B917E71AE7D441367C8A30149BC3C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_get_specular_Injected_m17BCA78D6D0B917E71AE7D441367C8A30149BC3C_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F*);
	static TerrainLayer_get_specular_Injected_m17BCA78D6D0B917E71AE7D441367C8A30149BC3C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_specular_Injected_m17BCA78D6D0B917E71AE7D441367C8A30149BC3C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_specular_Injected(UnityEngine.Color&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainLayer::set_specular_Injected(UnityEngine.Color&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_specular_Injected_mB6275B761452010AEE54E6B15F63435FA7A1D485 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_specular_Injected_mB6275B761452010AEE54E6B15F63435FA7A1D485_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F*);
	static TerrainLayer_set_specular_Injected_mB6275B761452010AEE54E6B15F63435FA7A1D485_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_specular_Injected_mB6275B761452010AEE54E6B15F63435FA7A1D485_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_specular_Injected(UnityEngine.Color&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.TerrainLayer::get_diffuseRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_diffuseRemapMin_Injected_m12394DF34C1CC7B138FA3389D4583EC00D555FF0 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_get_diffuseRemapMin_Injected_m12394DF34C1CC7B138FA3389D4583EC00D555FF0_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_get_diffuseRemapMin_Injected_m12394DF34C1CC7B138FA3389D4583EC00D555FF0_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_diffuseRemapMin_Injected_m12394DF34C1CC7B138FA3389D4583EC00D555FF0_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_diffuseRemapMin_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainLayer::set_diffuseRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_diffuseRemapMin_Injected_mFA1B63F9AA91C8EA82104C4CC1A7778C5AED7706 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_diffuseRemapMin_Injected_mFA1B63F9AA91C8EA82104C4CC1A7778C5AED7706_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_set_diffuseRemapMin_Injected_mFA1B63F9AA91C8EA82104C4CC1A7778C5AED7706_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_diffuseRemapMin_Injected_mFA1B63F9AA91C8EA82104C4CC1A7778C5AED7706_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_diffuseRemapMin_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.TerrainLayer::get_diffuseRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_diffuseRemapMax_Injected_m2E247FD71A4D51D8E54DA3BF504C1731FB6F23AC (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_get_diffuseRemapMax_Injected_m2E247FD71A4D51D8E54DA3BF504C1731FB6F23AC_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_get_diffuseRemapMax_Injected_m2E247FD71A4D51D8E54DA3BF504C1731FB6F23AC_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_diffuseRemapMax_Injected_m2E247FD71A4D51D8E54DA3BF504C1731FB6F23AC_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_diffuseRemapMax_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainLayer::set_diffuseRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_diffuseRemapMax_Injected_m90271AB60993CFD03E422C688FAFC64017D4BEE3 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_diffuseRemapMax_Injected_m90271AB60993CFD03E422C688FAFC64017D4BEE3_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_set_diffuseRemapMax_Injected_m90271AB60993CFD03E422C688FAFC64017D4BEE3_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_diffuseRemapMax_Injected_m90271AB60993CFD03E422C688FAFC64017D4BEE3_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_diffuseRemapMax_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.TerrainLayer::get_maskMapRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_maskMapRemapMin_Injected_mEC87DA9E3173F7D39C047FABAB507CC4351FDF24 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_get_maskMapRemapMin_Injected_mEC87DA9E3173F7D39C047FABAB507CC4351FDF24_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_get_maskMapRemapMin_Injected_mEC87DA9E3173F7D39C047FABAB507CC4351FDF24_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_maskMapRemapMin_Injected_mEC87DA9E3173F7D39C047FABAB507CC4351FDF24_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_maskMapRemapMin_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainLayer::set_maskMapRemapMin_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_maskMapRemapMin_Injected_m388350F2F0C06A10AF0DA39725B59103F6EE7F2C (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_maskMapRemapMin_Injected_m388350F2F0C06A10AF0DA39725B59103F6EE7F2C_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_set_maskMapRemapMin_Injected_m388350F2F0C06A10AF0DA39725B59103F6EE7F2C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_maskMapRemapMin_Injected_m388350F2F0C06A10AF0DA39725B59103F6EE7F2C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_maskMapRemapMin_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.TerrainLayer::get_maskMapRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_get_maskMapRemapMax_Injected_m1BA6C54D1C610E455C6A7919E5E08EA304CA7403 (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_get_maskMapRemapMax_Injected_m1BA6C54D1C610E455C6A7919E5E08EA304CA7403_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_get_maskMapRemapMax_Injected_m1BA6C54D1C610E455C6A7919E5E08EA304CA7403_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_get_maskMapRemapMax_Injected_m1BA6C54D1C610E455C6A7919E5E08EA304CA7403_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::get_maskMapRemapMax_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainLayer::set_maskMapRemapMax_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainLayer_set_maskMapRemapMax_Injected_m10CF5BC6AA549FC669BCB7881D6D75D569EC20EE (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainLayer_set_maskMapRemapMax_Injected_m10CF5BC6AA549FC669BCB7881D6D75D569EC20EE_ftn) (TerrainLayer_t52E14A94A0CF76B0B5509B7FDFDE64FF8A9FEFF9*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static TerrainLayer_set_maskMapRemapMax_Injected_m10CF5BC6AA549FC669BCB7881D6D75D569EC20EE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainLayer_set_maskMapRemapMax_Injected_m10CF5BC6AA549FC669BCB7881D6D75D569EC20EE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainLayer::set_maskMapRemapMax_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_value);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Conversion methods for marshalling of: UnityEngine.TreePrototype
IL2CPP_EXTERN_C void TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshal_pinvoke(const TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D& unmarshaled, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_Prefab_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prefab' of type 'TreePrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prefab_0Exception, NULL);
}
IL2CPP_EXTERN_C void TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshal_pinvoke_back(const TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_pinvoke& marshaled, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D& unmarshaled)
{
	Exception_t* ___m_Prefab_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prefab' of type 'TreePrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prefab_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: UnityEngine.TreePrototype
IL2CPP_EXTERN_C void TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshal_pinvoke_cleanup(TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: UnityEngine.TreePrototype
IL2CPP_EXTERN_C void TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshal_com(const TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D& unmarshaled, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_com& marshaled)
{
	Exception_t* ___m_Prefab_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prefab' of type 'TreePrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prefab_0Exception, NULL);
}
IL2CPP_EXTERN_C void TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshal_com_back(const TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_com& marshaled, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D& unmarshaled)
{
	Exception_t* ___m_Prefab_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prefab' of type 'TreePrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prefab_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: UnityEngine.TreePrototype
IL2CPP_EXTERN_C void TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshal_com_cleanup(TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_marshaled_com& marshaled)
{
}
// UnityEngine.GameObject UnityEngine.TreePrototype::get_prefab()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* TreePrototype_get_prefab_mCE1630C35B09770D35B2ECA45B98D1CB6D5AC67C (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) 
{
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* V_0 = NULL;
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0 = __this->___m_Prefab_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.TreePrototype::get_bendFactor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float TreePrototype_get_bendFactor_mC78774070395FFBEF5588233ED4C40D253F2B087 (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_BendFactor_1;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.TreePrototype::get_navMeshLod()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TreePrototype_get_navMeshLod_m68F7C292A64B7560076E09BF0B3AB6D681886C6C (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->___m_NavMeshLod_2;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.TreePrototype::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TreePrototype__ctor_m319858B89E2F9AF0FD4009A015E2A34776F6CAC5 (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.Boolean UnityEngine.TreePrototype::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TreePrototype_Equals_m50E85BD703A2633D4ECA590DB0F1B803EE192F9A (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		RuntimeObject* L_0 = ___0_obj;
		bool L_1;
		L_1 = TreePrototype_Equals_m6F39B894827A28E1ADBF4403922FFCA8CF55E265(__this, ((TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D*)IsInstSealed((RuntimeObject*)L_0, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D_il2cpp_TypeInfo_var)), NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
// System.Int32 UnityEngine.TreePrototype::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TreePrototype_GetHashCode_m3E71334805650043E1C12F1FD6228D6281560E91 (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Object_GetHashCode_m372C5A7AB16CAC13307C11C4256D706CE57E090C(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Boolean UnityEngine.TreePrototype::Equals(UnityEngine.TreePrototype)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TreePrototype_Equals_m6F39B894827A28E1ADBF4403922FFCA8CF55E265 (TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* __this, TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* ___0_other, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	int32_t G_B10_0 = 0;
	{
		TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* L_0 = ___0_other;
		V_1 = (bool)((((RuntimeObject*)(TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_000d;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_006b;
	}

IL_000d:
	{
		TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* L_2 = ___0_other;
		V_3 = (bool)((((RuntimeObject*)(TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D*)L_2) == ((RuntimeObject*)(TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D*)__this))? 1 : 0);
		bool L_3 = V_3;
		if (!L_3)
		{
			goto IL_0019;
		}
	}
	{
		V_2 = (bool)1;
		goto IL_006b;
	}

IL_0019:
	{
		Type_t* L_4;
		L_4 = Object_GetType_mE10A8FC1E57F3DF29972CCBC026C2DC3942263B3(__this, NULL);
		TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* L_5 = ___0_other;
		NullCheck(L_5);
		Type_t* L_6;
		L_6 = Object_GetType_mE10A8FC1E57F3DF29972CCBC026C2DC3942263B3(L_5, NULL);
		V_4 = (bool)((((int32_t)((((RuntimeObject*)(Type_t*)L_4) == ((RuntimeObject*)(Type_t*)L_6))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_7 = V_4;
		if (!L_7)
		{
			goto IL_0034;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_006b;
	}

IL_0034:
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_8;
		L_8 = TreePrototype_get_prefab_mCE1630C35B09770D35B2ECA45B98D1CB6D5AC67C(__this, NULL);
		TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* L_9 = ___0_other;
		NullCheck(L_9);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_10;
		L_10 = TreePrototype_get_prefab_mCE1630C35B09770D35B2ECA45B98D1CB6D5AC67C(L_9, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_11;
		L_11 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_8, L_10, NULL);
		if (!L_11)
		{
			goto IL_0065;
		}
	}
	{
		float L_12;
		L_12 = TreePrototype_get_bendFactor_mC78774070395FFBEF5588233ED4C40D253F2B087(__this, NULL);
		TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* L_13 = ___0_other;
		NullCheck(L_13);
		float L_14;
		L_14 = TreePrototype_get_bendFactor_mC78774070395FFBEF5588233ED4C40D253F2B087(L_13, NULL);
		if ((!(((float)L_12) == ((float)L_14))))
		{
			goto IL_0065;
		}
	}
	{
		int32_t L_15;
		L_15 = TreePrototype_get_navMeshLod_m68F7C292A64B7560076E09BF0B3AB6D681886C6C(__this, NULL);
		TreePrototype_tA221EF2DEEEF8152E67DC6C07B55EACFDF2AF07D* L_16 = ___0_other;
		NullCheck(L_16);
		int32_t L_17;
		L_17 = TreePrototype_get_navMeshLod_m68F7C292A64B7560076E09BF0B3AB6D681886C6C(L_16, NULL);
		G_B10_0 = ((((int32_t)L_15) == ((int32_t)L_17))? 1 : 0);
		goto IL_0066;
	}

IL_0065:
	{
		G_B10_0 = 0;
	}

IL_0066:
	{
		V_0 = (bool)G_B10_0;
		bool L_18 = V_0;
		V_2 = L_18;
		goto IL_006b;
	}

IL_006b:
	{
		bool L_19 = V_2;
		return L_19;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Conversion methods for marshalling of: UnityEngine.DetailPrototype
IL2CPP_EXTERN_C void DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshal_pinvoke(const DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B& unmarshaled, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_Prototype_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prototype' of type 'DetailPrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prototype_2Exception, NULL);
}
IL2CPP_EXTERN_C void DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshal_pinvoke_back(const DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_pinvoke& marshaled, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B& unmarshaled)
{
	Exception_t* ___m_Prototype_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prototype' of type 'DetailPrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prototype_2Exception, NULL);
}
// Conversion method for clean up from marshalling of: UnityEngine.DetailPrototype
IL2CPP_EXTERN_C void DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshal_pinvoke_cleanup(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: UnityEngine.DetailPrototype
IL2CPP_EXTERN_C void DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshal_com(const DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B& unmarshaled, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_com& marshaled)
{
	Exception_t* ___m_Prototype_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prototype' of type 'DetailPrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prototype_2Exception, NULL);
}
IL2CPP_EXTERN_C void DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshal_com_back(const DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_com& marshaled, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B& unmarshaled)
{
	Exception_t* ___m_Prototype_2Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Prototype' of type 'DetailPrototype': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Prototype_2Exception, NULL);
}
// Conversion method for clean up from marshalling of: UnityEngine.DetailPrototype
IL2CPP_EXTERN_C void DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshal_com_cleanup(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_marshaled_com& marshaled)
{
}
// UnityEngine.GameObject UnityEngine.DetailPrototype::get_prototype()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* DetailPrototype_get_prototype_m4231116338BF5EA568B47405CD7626FA511EA695 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* V_0 = NULL;
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0 = __this->___m_Prototype_2;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_1 = V_0;
		return L_1;
	}
}
// UnityEngine.Texture2D UnityEngine.DetailPrototype::get_prototypeTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* DetailPrototype_get_prototypeTexture_m293614A486AE92BBAE7CA448B1A87BE5F64B4D7E (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* V_0 = NULL;
	{
		Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* L_0 = __this->___m_PrototypeTexture_3;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.DetailPrototype::get_minWidth()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float DetailPrototype_get_minWidth_m41AAF89F1E5EBFBD6D064684D6956F6796F8CE7C (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_MinWidth_6;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.DetailPrototype::get_maxWidth()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float DetailPrototype_get_maxWidth_m428CF8DDC8FE3BB9E55051702ACBBA7431E8C073 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_MaxWidth_7;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.DetailPrototype::get_minHeight()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float DetailPrototype_get_minHeight_mD714BF9D18EBC2E2920908302EAFE31F014A44A8 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_MinHeight_8;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.DetailPrototype::get_maxHeight()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float DetailPrototype_get_maxHeight_m6048EC459FF0A728CDB5D2DD1169894F3A3A7C15 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_MaxHeight_9;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.DetailPrototype::get_noiseSpread()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float DetailPrototype_get_noiseSpread_m7FC289CF0B780679986A5395ECA4318FB696EBE1 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_NoiseSpread_11;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
// UnityEngine.Color UnityEngine.DetailPrototype::get_healthyColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F DetailPrototype_get_healthyColor_mD81828F1E2867C4819B38B0466ABAF2B10E10FD9 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = __this->___m_HealthyColor_4;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = V_0;
		return L_1;
	}
}
// UnityEngine.Color UnityEngine.DetailPrototype::get_dryColor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F DetailPrototype_get_dryColor_mCA70253238F53DC22FE0F6D6A644F6ED839A310F (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = __this->___m_DryColor_5;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.DetailPrototype::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DetailPrototype__ctor_m9157B5DBD1A80AF51E9090177A751EB401247103 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->___m_Prototype_2 = (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_Prototype_2), (void*)(GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*)NULL);
		__this->___m_PrototypeTexture_3 = (Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_PrototypeTexture_3), (void*)(Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*)NULL);
		il2cpp_codegen_runtime_class_init_inline(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = ((DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_StaticFields*)il2cpp_codegen_static_fields_for(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var))->___DefaultHealthColor_0;
		__this->___m_HealthyColor_4 = L_0;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = ((DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_StaticFields*)il2cpp_codegen_static_fields_for(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var))->___DefaultDryColor_1;
		__this->___m_DryColor_5 = L_1;
		__this->___m_MinWidth_6 = (1.0f);
		__this->___m_MaxWidth_7 = (2.0f);
		__this->___m_MinHeight_8 = (1.0f);
		__this->___m_MaxHeight_9 = (2.0f);
		__this->___m_NoiseSeed_10 = 0;
		__this->___m_NoiseSpread_11 = (0.100000001f);
		__this->___m_HoleEdgePadding_12 = (0.0f);
		__this->___m_RenderMode_13 = 2;
		__this->___m_UsePrototypeMesh_14 = 0;
		__this->___m_UseInstancing_15 = 0;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.Void UnityEngine.DetailPrototype::.ctor(UnityEngine.DetailPrototype)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DetailPrototype__ctor_mA958B452872D2004C50CBFD24B5998FF933D5BA0 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* ___0_other, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->___m_Prototype_2 = (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_Prototype_2), (void*)(GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*)NULL);
		__this->___m_PrototypeTexture_3 = (Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_PrototypeTexture_3), (void*)(Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*)NULL);
		il2cpp_codegen_runtime_class_init_inline(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = ((DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_StaticFields*)il2cpp_codegen_static_fields_for(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var))->___DefaultHealthColor_0;
		__this->___m_HealthyColor_4 = L_0;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = ((DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_StaticFields*)il2cpp_codegen_static_fields_for(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var))->___DefaultDryColor_1;
		__this->___m_DryColor_5 = L_1;
		__this->___m_MinWidth_6 = (1.0f);
		__this->___m_MaxWidth_7 = (2.0f);
		__this->___m_MinHeight_8 = (1.0f);
		__this->___m_MaxHeight_9 = (2.0f);
		__this->___m_NoiseSeed_10 = 0;
		__this->___m_NoiseSpread_11 = (0.100000001f);
		__this->___m_HoleEdgePadding_12 = (0.0f);
		__this->___m_RenderMode_13 = 2;
		__this->___m_UsePrototypeMesh_14 = 0;
		__this->___m_UseInstancing_15 = 0;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_2 = ___0_other;
		NullCheck(L_2);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_3 = L_2->___m_Prototype_2;
		__this->___m_Prototype_2 = L_3;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_Prototype_2), (void*)L_3);
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_4 = ___0_other;
		NullCheck(L_4);
		Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* L_5 = L_4->___m_PrototypeTexture_3;
		__this->___m_PrototypeTexture_3 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_PrototypeTexture_3), (void*)L_5);
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_6 = ___0_other;
		NullCheck(L_6);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_7 = L_6->___m_HealthyColor_4;
		__this->___m_HealthyColor_4 = L_7;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_8 = ___0_other;
		NullCheck(L_8);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_9 = L_8->___m_DryColor_5;
		__this->___m_DryColor_5 = L_9;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_10 = ___0_other;
		NullCheck(L_10);
		float L_11 = L_10->___m_MinWidth_6;
		__this->___m_MinWidth_6 = L_11;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_12 = ___0_other;
		NullCheck(L_12);
		float L_13 = L_12->___m_MaxWidth_7;
		__this->___m_MaxWidth_7 = L_13;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_14 = ___0_other;
		NullCheck(L_14);
		float L_15 = L_14->___m_MinHeight_8;
		__this->___m_MinHeight_8 = L_15;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_16 = ___0_other;
		NullCheck(L_16);
		float L_17 = L_16->___m_MaxHeight_9;
		__this->___m_MaxHeight_9 = L_17;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_18 = ___0_other;
		NullCheck(L_18);
		int32_t L_19 = L_18->___m_NoiseSeed_10;
		__this->___m_NoiseSeed_10 = L_19;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_20 = ___0_other;
		NullCheck(L_20);
		float L_21 = L_20->___m_NoiseSpread_11;
		__this->___m_NoiseSpread_11 = L_21;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_22 = ___0_other;
		NullCheck(L_22);
		float L_23 = L_22->___m_HoleEdgePadding_12;
		__this->___m_HoleEdgePadding_12 = L_23;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_24 = ___0_other;
		NullCheck(L_24);
		int32_t L_25 = L_24->___m_RenderMode_13;
		__this->___m_RenderMode_13 = L_25;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_26 = ___0_other;
		NullCheck(L_26);
		int32_t L_27 = L_26->___m_UsePrototypeMesh_14;
		__this->___m_UsePrototypeMesh_14 = L_27;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_28 = ___0_other;
		NullCheck(L_28);
		int32_t L_29 = L_28->___m_UseInstancing_15;
		__this->___m_UseInstancing_15 = L_29;
		return;
	}
}
// System.Boolean UnityEngine.DetailPrototype::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DetailPrototype_Equals_m4366EA36A57FC1391A85828835FD5B493A573E93 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		RuntimeObject* L_0 = ___0_obj;
		bool L_1;
		L_1 = DetailPrototype_Equals_mDCF0B4B10AB82B883A1B1EE9F286D92A99636B20(__this, ((DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B*)IsInstSealed((RuntimeObject*)L_0, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var)), NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
// System.Int32 UnityEngine.DetailPrototype::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DetailPrototype_GetHashCode_m7C87FF388D92F7A9396DC46F1F4DB4AC436D9ED0 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Object_GetHashCode_m372C5A7AB16CAC13307C11C4256D706CE57E090C(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Boolean UnityEngine.DetailPrototype::Equals(UnityEngine.DetailPrototype)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DetailPrototype_Equals_mDCF0B4B10AB82B883A1B1EE9F286D92A99636B20 (DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* __this, DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* ___0_other, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	int32_t G_B21_0 = 0;
	{
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_0 = ___0_other;
		V_0 = (bool)((((RuntimeObject*)(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0010;
		}
	}
	{
		V_1 = (bool)0;
		goto IL_0128;
	}

IL_0010:
	{
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_2 = ___0_other;
		V_2 = (bool)((((RuntimeObject*)(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B*)L_2) == ((RuntimeObject*)(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B*)__this))? 1 : 0);
		bool L_3 = V_2;
		if (!L_3)
		{
			goto IL_001f;
		}
	}
	{
		V_1 = (bool)1;
		goto IL_0128;
	}

IL_001f:
	{
		Type_t* L_4;
		L_4 = Object_GetType_mE10A8FC1E57F3DF29972CCBC026C2DC3942263B3(__this, NULL);
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_5 = ___0_other;
		NullCheck(L_5);
		Type_t* L_6;
		L_6 = Object_GetType_mE10A8FC1E57F3DF29972CCBC026C2DC3942263B3(L_5, NULL);
		V_3 = (bool)((((int32_t)((((RuntimeObject*)(Type_t*)L_4) == ((RuntimeObject*)(Type_t*)L_6))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_7 = V_3;
		if (!L_7)
		{
			goto IL_003b;
		}
	}
	{
		V_1 = (bool)0;
		goto IL_0128;
	}

IL_003b:
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_8 = __this->___m_Prototype_2;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_9 = ___0_other;
		NullCheck(L_9);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_10 = L_9->___m_Prototype_2;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_11;
		L_11 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_8, L_10, NULL);
		if (!L_11)
		{
			goto IL_0124;
		}
	}
	{
		Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* L_12 = __this->___m_PrototypeTexture_3;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_13 = ___0_other;
		NullCheck(L_13);
		Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* L_14 = L_13->___m_PrototypeTexture_3;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_15;
		L_15 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_12, L_14, NULL);
		if (!L_15)
		{
			goto IL_0124;
		}
	}
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_16 = __this->___m_HealthyColor_4;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_17 = ___0_other;
		NullCheck(L_17);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_18 = L_17->___m_HealthyColor_4;
		bool L_19;
		L_19 = Color_op_Equality_mB2BDC39B0B367BA15AA8DF22F8CB0D02D20BDC71_inline(L_16, L_18, NULL);
		if (!L_19)
		{
			goto IL_0124;
		}
	}
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_20 = __this->___m_DryColor_5;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_21 = ___0_other;
		NullCheck(L_21);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_22 = L_21->___m_DryColor_5;
		bool L_23;
		L_23 = Color_op_Equality_mB2BDC39B0B367BA15AA8DF22F8CB0D02D20BDC71_inline(L_20, L_22, NULL);
		if (!L_23)
		{
			goto IL_0124;
		}
	}
	{
		float L_24 = __this->___m_MinWidth_6;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_25 = ___0_other;
		NullCheck(L_25);
		float L_26 = L_25->___m_MinWidth_6;
		if ((!(((float)L_24) == ((float)L_26))))
		{
			goto IL_0124;
		}
	}
	{
		float L_27 = __this->___m_MaxWidth_7;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_28 = ___0_other;
		NullCheck(L_28);
		float L_29 = L_28->___m_MaxWidth_7;
		if ((!(((float)L_27) == ((float)L_29))))
		{
			goto IL_0124;
		}
	}
	{
		float L_30 = __this->___m_MinHeight_8;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_31 = ___0_other;
		NullCheck(L_31);
		float L_32 = L_31->___m_MinHeight_8;
		if ((!(((float)L_30) == ((float)L_32))))
		{
			goto IL_0124;
		}
	}
	{
		float L_33 = __this->___m_MaxHeight_9;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_34 = ___0_other;
		NullCheck(L_34);
		float L_35 = L_34->___m_MaxHeight_9;
		if ((!(((float)L_33) == ((float)L_35))))
		{
			goto IL_0124;
		}
	}
	{
		int32_t L_36 = __this->___m_NoiseSeed_10;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_37 = ___0_other;
		NullCheck(L_37);
		int32_t L_38 = L_37->___m_NoiseSeed_10;
		if ((!(((uint32_t)L_36) == ((uint32_t)L_38))))
		{
			goto IL_0124;
		}
	}
	{
		float L_39 = __this->___m_NoiseSpread_11;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_40 = ___0_other;
		NullCheck(L_40);
		float L_41 = L_40->___m_NoiseSpread_11;
		if ((!(((float)L_39) == ((float)L_41))))
		{
			goto IL_0124;
		}
	}
	{
		float L_42 = __this->___m_HoleEdgePadding_12;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_43 = ___0_other;
		NullCheck(L_43);
		float L_44 = L_43->___m_HoleEdgePadding_12;
		if ((!(((float)L_42) == ((float)L_44))))
		{
			goto IL_0124;
		}
	}
	{
		int32_t L_45 = __this->___m_RenderMode_13;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_46 = ___0_other;
		NullCheck(L_46);
		int32_t L_47 = L_46->___m_RenderMode_13;
		if ((!(((uint32_t)L_45) == ((uint32_t)L_47))))
		{
			goto IL_0124;
		}
	}
	{
		int32_t L_48 = __this->___m_UsePrototypeMesh_14;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_49 = ___0_other;
		NullCheck(L_49);
		int32_t L_50 = L_49->___m_UsePrototypeMesh_14;
		if ((!(((uint32_t)L_48) == ((uint32_t)L_50))))
		{
			goto IL_0124;
		}
	}
	{
		int32_t L_51 = __this->___m_UseInstancing_15;
		DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B* L_52 = ___0_other;
		NullCheck(L_52);
		int32_t L_53 = L_52->___m_UseInstancing_15;
		G_B21_0 = ((((int32_t)L_51) == ((int32_t)L_53))? 1 : 0);
		goto IL_0125;
	}

IL_0124:
	{
		G_B21_0 = 0;
	}

IL_0125:
	{
		V_1 = (bool)G_B21_0;
		goto IL_0128;
	}

IL_0128:
	{
		bool L_54 = V_1;
		return L_54;
	}
}
// System.Void UnityEngine.DetailPrototype::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DetailPrototype__cctor_m5D5A4C448F2584173CF5618DD3CB725B16F6406F (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0;
		memset((&L_0), 0, sizeof(L_0));
		Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline((&L_0), (0.262745112f), (0.97647059f), (0.164705887f), (1.0f), /*hidden argument*/NULL);
		((DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_StaticFields*)il2cpp_codegen_static_fields_for(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var))->___DefaultHealthColor_0 = L_0;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1;
		memset((&L_1), 0, sizeof(L_1));
		Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline((&L_1), (0.80392158f), (0.737254918f), (0.101960786f), (1.0f), /*hidden argument*/NULL);
		((DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_StaticFields*)il2cpp_codegen_static_fields_for(DetailPrototype_t131E17755ED167435F60BA3F70869DA3876E254B_il2cpp_TypeInfo_var))->___DefaultDryColor_1 = L_1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Int32 UnityEngine.TerrainData::GetBoundaryValue(UnityEngine.TerrainData/BoundaryValueType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E (int32_t ___0_type, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E_ftn) (int32_t);
	static TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetBoundaryValue(UnityEngine.TerrainData/BoundaryValueType)");
	int32_t icallRetVal = _il2cpp_icall_func(___0_type);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainData::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData__ctor_m1B68EB89248D5706C2528F47279812F824E27A2E (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		Object__ctor_m2149FA40CEC8D82AC20D3508AB40C0D8EFEF68E6(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var);
		TerrainData_Internal_Create_m79BF764CFF5F49D17E2BFC8B20F60B4CF70BE4E1(__this, NULL);
		return;
	}
}
// System.Void UnityEngine.TerrainData::Internal_Create(UnityEngine.TerrainData)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_Internal_Create_m79BF764CFF5F49D17E2BFC8B20F60B4CF70BE4E1 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* ___0_terrainData, const RuntimeMethod* method) 
{
	typedef void (*TerrainData_Internal_Create_m79BF764CFF5F49D17E2BFC8B20F60B4CF70BE4E1_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_Internal_Create_m79BF764CFF5F49D17E2BFC8B20F60B4CF70BE4E1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_Internal_Create_m79BF764CFF5F49D17E2BFC8B20F60B4CF70BE4E1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::Internal_Create(UnityEngine.TerrainData)");
	_il2cpp_icall_func(___0_terrainData);
}
// UnityEngine.RenderTexture UnityEngine.TerrainData::get_heightmapTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* TerrainData_get_heightmapTexture_m26CB863455F0048CEA74741C71BF3021576FF8CE (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* (*TerrainData_get_heightmapTexture_m26CB863455F0048CEA74741C71BF3021576FF8CE_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_heightmapTexture_m26CB863455F0048CEA74741C71BF3021576FF8CE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_heightmapTexture_m26CB863455F0048CEA74741C71BF3021576FF8CE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_heightmapTexture()");
	RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_heightmapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_heightmapResolution_m39FE9A5C31A80B28021F8E2484EF5F2664798836 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = TerrainData_get_internalHeightmapResolution_m83C6A32499AAAAFDD57DF73BA460CBCF02F98118(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.TerrainData::get_internalHeightmapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_internalHeightmapResolution_m83C6A32499AAAAFDD57DF73BA460CBCF02F98118 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_get_internalHeightmapResolution_m83C6A32499AAAAFDD57DF73BA460CBCF02F98118_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_internalHeightmapResolution_m83C6A32499AAAAFDD57DF73BA460CBCF02F98118_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_internalHeightmapResolution_m83C6A32499AAAAFDD57DF73BA460CBCF02F98118_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_internalHeightmapResolution()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.Texture UnityEngine.TerrainData::get_holesTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700* TerrainData_get_holesTexture_m967249F842D3BFC631ED03C847C41EE4D0A56912 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700* V_1 = NULL;
	{
		bool L_0;
		L_0 = TerrainData_IsHolesTextureCompressed_mBFE653BBF59360E5382F66592EF1F3E48ED4057D(__this, NULL);
		V_0 = L_0;
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0015;
		}
	}
	{
		Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* L_2;
		L_2 = TerrainData_GetCompressedHolesTexture_m219472651551DC5C4613B441C27E504DA693411F(__this, NULL);
		V_1 = L_2;
		goto IL_001f;
	}

IL_0015:
	{
		RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* L_3;
		L_3 = TerrainData_GetHolesTexture_mE1BC7A225983716A760BA8ACEFEC6DEFF6EA572A(__this, NULL);
		V_1 = L_3;
		goto IL_001f;
	}

IL_001f:
	{
		Texture_t791CBB51219779964E0E8A2ED7C1AA5F92A4A700* L_4 = V_1;
		return L_4;
	}
}
// System.Boolean UnityEngine.TerrainData::get_enableHolesTextureCompression()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainData_get_enableHolesTextureCompression_m6BA8BB7840CEF3B832D7C64D91689BECBBA1E920 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef bool (*TerrainData_get_enableHolesTextureCompression_m6BA8BB7840CEF3B832D7C64D91689BECBBA1E920_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_enableHolesTextureCompression_m6BA8BB7840CEF3B832D7C64D91689BECBBA1E920_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_enableHolesTextureCompression_m6BA8BB7840CEF3B832D7C64D91689BECBBA1E920_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_enableHolesTextureCompression()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainData::set_enableHolesTextureCompression(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_set_enableHolesTextureCompression_mDD73FBE3EA89453DB6FA3BA236FB527B2F71EE7C (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainData_set_enableHolesTextureCompression_mDD73FBE3EA89453DB6FA3BA236FB527B2F71EE7C_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, bool);
	static TerrainData_set_enableHolesTextureCompression_mDD73FBE3EA89453DB6FA3BA236FB527B2F71EE7C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_set_enableHolesTextureCompression_mDD73FBE3EA89453DB6FA3BA236FB527B2F71EE7C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::set_enableHolesTextureCompression(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Boolean UnityEngine.TerrainData::IsHolesTextureCompressed()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainData_IsHolesTextureCompressed_mBFE653BBF59360E5382F66592EF1F3E48ED4057D (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef bool (*TerrainData_IsHolesTextureCompressed_mBFE653BBF59360E5382F66592EF1F3E48ED4057D_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_IsHolesTextureCompressed_mBFE653BBF59360E5382F66592EF1F3E48ED4057D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_IsHolesTextureCompressed_mBFE653BBF59360E5382F66592EF1F3E48ED4057D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::IsHolesTextureCompressed()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.RenderTexture UnityEngine.TerrainData::GetHolesTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* TerrainData_GetHolesTexture_mE1BC7A225983716A760BA8ACEFEC6DEFF6EA572A (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* (*TerrainData_GetHolesTexture_mE1BC7A225983716A760BA8ACEFEC6DEFF6EA572A_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_GetHolesTexture_mE1BC7A225983716A760BA8ACEFEC6DEFF6EA572A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetHolesTexture_mE1BC7A225983716A760BA8ACEFEC6DEFF6EA572A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetHolesTexture()");
	RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.Texture2D UnityEngine.TerrainData::GetCompressedHolesTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* TerrainData_GetCompressedHolesTexture_m219472651551DC5C4613B441C27E504DA693411F (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* (*TerrainData_GetCompressedHolesTexture_m219472651551DC5C4613B441C27E504DA693411F_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_GetCompressedHolesTexture_m219472651551DC5C4613B441C27E504DA693411F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetCompressedHolesTexture_m219472651551DC5C4613B441C27E504DA693411F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetCompressedHolesTexture()");
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_holesResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_holesResolution_m9DE109FB3A0874F7F4706543D0903AFA12D1BC53 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0;
		L_0 = TerrainData_get_heightmapResolution_m39FE9A5C31A80B28021F8E2484EF5F2664798836(__this, NULL);
		return ((int32_t)il2cpp_codegen_subtract(L_0, 1));
	}
}
// UnityEngine.Vector3 UnityEngine.TerrainData::get_size()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		TerrainData_get_size_Injected_m0F56E87C4D7EDD1D84F038E4AF0F273D328CF661(__this, (&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = V_0;
		return L_0;
	}
}
// System.Single UnityEngine.TerrainData::GetInterpolatedHeight(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float TerrainData_GetInterpolatedHeight_m30AAF72C79B6BE19E23962304DB80B21023B5752 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, float ___0_x, float ___1_y, const RuntimeMethod* method) 
{
	typedef float (*TerrainData_GetInterpolatedHeight_m30AAF72C79B6BE19E23962304DB80B21023B5752_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, float, float);
	static TerrainData_GetInterpolatedHeight_m30AAF72C79B6BE19E23962304DB80B21023B5752_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetInterpolatedHeight_m30AAF72C79B6BE19E23962304DB80B21023B5752_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetInterpolatedHeight(System.Single,System.Single)");
	float icallRetVal = _il2cpp_icall_func(__this, ___0_x, ___1_y);
	return icallRetVal;
}
// System.Boolean[,] UnityEngine.TerrainData::GetHoles(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* TerrainData_GetHoles_mE81BB7B6E8764586CC5BA130AC075536D0617318 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_xBase, int32_t ___1_yBase, int32_t ___2_width, int32_t ___3_height, const RuntimeMethod* method) 
{
	bool V_0 = false;
	BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* V_1 = NULL;
	int32_t G_B7_0 = 0;
	{
		int32_t L_0 = ___0_xBase;
		if ((((int32_t)L_0) < ((int32_t)0)))
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_1 = ___1_yBase;
		if ((((int32_t)L_1) < ((int32_t)0)))
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_2 = ___2_width;
		if ((((int32_t)L_2) <= ((int32_t)0)))
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_3 = ___3_height;
		if ((((int32_t)L_3) <= ((int32_t)0)))
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_4 = ___0_xBase;
		int32_t L_5 = ___2_width;
		int32_t L_6;
		L_6 = TerrainData_get_holesResolution_m9DE109FB3A0874F7F4706543D0903AFA12D1BC53(__this, NULL);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_4, L_5))) > ((int32_t)L_6)))
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_7 = ___1_yBase;
		int32_t L_8 = ___3_height;
		int32_t L_9;
		L_9 = TerrainData_get_holesResolution_m9DE109FB3A0874F7F4706543D0903AFA12D1BC53(__this, NULL);
		G_B7_0 = ((((int32_t)((int32_t)il2cpp_codegen_add(L_7, L_8))) > ((int32_t)L_9))? 1 : 0);
		goto IL_002c;
	}

IL_002b:
	{
		G_B7_0 = 1;
	}

IL_002c:
	{
		V_0 = (bool)G_B7_0;
		bool L_10 = V_0;
		if (!L_10)
		{
			goto IL_003c;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_11 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_11);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_11, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralFAA7C04A851925650B82E9B390175EE79E020DB1)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_11, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TerrainData_GetHoles_mE81BB7B6E8764586CC5BA130AC075536D0617318_RuntimeMethod_var)));
	}

IL_003c:
	{
		int32_t L_12 = ___0_xBase;
		int32_t L_13 = ___1_yBase;
		int32_t L_14 = ___2_width;
		int32_t L_15 = ___3_height;
		BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* L_16;
		L_16 = TerrainData_Internal_GetHoles_m13EE36473247F7D4E96C627CE8A4CBF0D4C329C8(__this, L_12, L_13, L_14, L_15, NULL);
		V_1 = L_16;
		goto IL_004a;
	}

IL_004a:
	{
		BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* L_17 = V_1;
		return L_17;
	}
}
// System.Boolean[,] UnityEngine.TerrainData::Internal_GetHoles(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* TerrainData_Internal_GetHoles_m13EE36473247F7D4E96C627CE8A4CBF0D4C329C8 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_xBase, int32_t ___1_yBase, int32_t ___2_width, int32_t ___3_height, const RuntimeMethod* method) 
{
	typedef BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* (*TerrainData_Internal_GetHoles_m13EE36473247F7D4E96C627CE8A4CBF0D4C329C8_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, int32_t, int32_t, int32_t, int32_t);
	static TerrainData_Internal_GetHoles_m13EE36473247F7D4E96C627CE8A4CBF0D4C329C8_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_Internal_GetHoles_m13EE36473247F7D4E96C627CE8A4CBF0D4C329C8_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::Internal_GetHoles(System.Int32,System.Int32,System.Int32,System.Int32)");
	BooleanU5BU2CU5D_t0A96EF7DC71D7FB5C1757A719712D1DFB2D571B6* icallRetVal = _il2cpp_icall_func(__this, ___0_xBase, ___1_yBase, ___2_width, ___3_height);
	return icallRetVal;
}
// UnityEngine.Vector3 UnityEngine.TerrainData::GetInterpolatedNormal(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 TerrainData_GetInterpolatedNormal_m2925F25FF12A4DC2F2CDD9331F3E2A55D42D7DCE (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, float ___0_x, float ___1_y, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = ___0_x;
		float L_1 = ___1_y;
		TerrainData_GetInterpolatedNormal_Injected_mF6E35FCDF546E498658E864D47EB87C22B41E571(__this, L_0, L_1, (&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = V_0;
		return L_2;
	}
}
// System.Int32 UnityEngine.TerrainData::get_detailWidth()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_detailWidth_m145CC1C91FF8C752907B80338DF03440E53AEBB4 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_get_detailWidth_m145CC1C91FF8C752907B80338DF03440E53AEBB4_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_detailWidth_m145CC1C91FF8C752907B80338DF03440E53AEBB4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_detailWidth_m145CC1C91FF8C752907B80338DF03440E53AEBB4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_detailWidth()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_detailHeight()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_detailHeight_m1DBBB1664689DD08F64A9AF4023248F23865D304 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_get_detailHeight_m1DBBB1664689DD08F64A9AF4023248F23865D304_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_detailHeight_m1DBBB1664689DD08F64A9AF4023248F23865D304_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_detailHeight_m1DBBB1664689DD08F64A9AF4023248F23865D304_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_detailHeight()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_detailResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_detailResolution_m999CE72D34D858E7D35182FA8DA05CE3C92F8D72 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_get_detailResolution_m999CE72D34D858E7D35182FA8DA05CE3C92F8D72_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_detailResolution_m999CE72D34D858E7D35182FA8DA05CE3C92F8D72_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_detailResolution_m999CE72D34D858E7D35182FA8DA05CE3C92F8D72_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_detailResolution()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.DetailPrototype[] UnityEngine.TerrainData::get_detailPrototypes()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DetailPrototypeU5BU5D_tB9391EFBDD64B38867DFB8179C6C0E8C81998AB7* TerrainData_get_detailPrototypes_m057F428D22C9FCCD36C6BE6768263DE777C6B2C4 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef DetailPrototypeU5BU5D_tB9391EFBDD64B38867DFB8179C6C0E8C81998AB7* (*TerrainData_get_detailPrototypes_m057F428D22C9FCCD36C6BE6768263DE777C6B2C4_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_detailPrototypes_m057F428D22C9FCCD36C6BE6768263DE777C6B2C4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_detailPrototypes_m057F428D22C9FCCD36C6BE6768263DE777C6B2C4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_detailPrototypes()");
	DetailPrototypeU5BU5D_tB9391EFBDD64B38867DFB8179C6C0E8C81998AB7* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32[] UnityEngine.TerrainData::GetSupportedLayers(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* TerrainData_GetSupportedLayers_m207D3CF276D6D6CC2F2E6BEF2271245C1DB99BD5 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_xBase, int32_t ___1_yBase, int32_t ___2_totalWidth, int32_t ___3_totalHeight, const RuntimeMethod* method) 
{
	typedef Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* (*TerrainData_GetSupportedLayers_m207D3CF276D6D6CC2F2E6BEF2271245C1DB99BD5_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, int32_t, int32_t, int32_t, int32_t);
	static TerrainData_GetSupportedLayers_m207D3CF276D6D6CC2F2E6BEF2271245C1DB99BD5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetSupportedLayers_m207D3CF276D6D6CC2F2E6BEF2271245C1DB99BD5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetSupportedLayers(System.Int32,System.Int32,System.Int32,System.Int32)");
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* icallRetVal = _il2cpp_icall_func(__this, ___0_xBase, ___1_yBase, ___2_totalWidth, ___3_totalHeight);
	return icallRetVal;
}
// System.Int32[,] UnityEngine.TerrainData::GetDetailLayer(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Int32U5BU2CU5D_t46F2694E7DAD7B2B05C940EC5B9DE04E40D0516F* TerrainData_GetDetailLayer_m8EB9B85C8CE8836E10D4D54B3A43BFE9AF888591 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_xBase, int32_t ___1_yBase, int32_t ___2_width, int32_t ___3_height, int32_t ___4_layer, const RuntimeMethod* method) 
{
	typedef Int32U5BU2CU5D_t46F2694E7DAD7B2B05C940EC5B9DE04E40D0516F* (*TerrainData_GetDetailLayer_m8EB9B85C8CE8836E10D4D54B3A43BFE9AF888591_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, int32_t, int32_t, int32_t, int32_t, int32_t);
	static TerrainData_GetDetailLayer_m8EB9B85C8CE8836E10D4D54B3A43BFE9AF888591_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetDetailLayer_m8EB9B85C8CE8836E10D4D54B3A43BFE9AF888591_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetDetailLayer(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)");
	Int32U5BU2CU5D_t46F2694E7DAD7B2B05C940EC5B9DE04E40D0516F* icallRetVal = _il2cpp_icall_func(__this, ___0_xBase, ___1_yBase, ___2_width, ___3_height, ___4_layer);
	return icallRetVal;
}
// UnityEngine.TreeInstance[] UnityEngine.TerrainData::get_treeInstances()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* TerrainData_get_treeInstances_mDAB68FD1F3677BD5CB122EA943493D5FC94B2147 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* V_0 = NULL;
	{
		TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* L_0;
		L_0 = TerrainData_Internal_GetTreeInstances_m0DCDC4D93E2CEC457C5BD8D0FE898B5A632E8347(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* L_1 = V_0;
		return L_1;
	}
}
// UnityEngine.TreeInstance[] UnityEngine.TerrainData::Internal_GetTreeInstances()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* TerrainData_Internal_GetTreeInstances_m0DCDC4D93E2CEC457C5BD8D0FE898B5A632E8347 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* (*TerrainData_Internal_GetTreeInstances_m0DCDC4D93E2CEC457C5BD8D0FE898B5A632E8347_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_Internal_GetTreeInstances_m0DCDC4D93E2CEC457C5BD8D0FE898B5A632E8347_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_Internal_GetTreeInstances_m0DCDC4D93E2CEC457C5BD8D0FE898B5A632E8347_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::Internal_GetTreeInstances()");
	TreeInstanceU5BU5D_tA728320FD1360BBC648153584A156DB0B90C2429* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.TreePrototype[] UnityEngine.TerrainData::get_treePrototypes()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TreePrototypeU5BU5D_tB0255CA167F991C2C9BA3BA55DF7417168D93B7A* TerrainData_get_treePrototypes_m0A43789B50E554DACB5DF88C86DA23B89DB33EEB (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef TreePrototypeU5BU5D_tB0255CA167F991C2C9BA3BA55DF7417168D93B7A* (*TerrainData_get_treePrototypes_m0A43789B50E554DACB5DF88C86DA23B89DB33EEB_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_treePrototypes_m0A43789B50E554DACB5DF88C86DA23B89DB33EEB_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_treePrototypes_m0A43789B50E554DACB5DF88C86DA23B89DB33EEB_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_treePrototypes()");
	TreePrototypeU5BU5D_tB0255CA167F991C2C9BA3BA55DF7417168D93B7A* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Single[,,] UnityEngine.TerrainData::GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* TerrainData_GetAlphamaps_m2DEF5D2068D54BDAE78661483C1FC4936B06EA01 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, const RuntimeMethod* method) 
{
	bool V_0 = false;
	SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* V_1 = NULL;
	int32_t G_B5_0 = 0;
	{
		int32_t L_0 = ___0_x;
		if ((((int32_t)L_0) < ((int32_t)0)))
		{
			goto IL_0014;
		}
	}
	{
		int32_t L_1 = ___1_y;
		if ((((int32_t)L_1) < ((int32_t)0)))
		{
			goto IL_0014;
		}
	}
	{
		int32_t L_2 = ___2_width;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_0014;
		}
	}
	{
		int32_t L_3 = ___3_height;
		G_B5_0 = ((((int32_t)L_3) < ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B5_0 = 1;
	}

IL_0015:
	{
		V_0 = (bool)G_B5_0;
		bool L_4 = V_0;
		if (!L_4)
		{
			goto IL_0024;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_5 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_5);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_5, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral84C1B2E6507AF77B7FC524F3D2F88289EB512D41)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TerrainData_GetAlphamaps_m2DEF5D2068D54BDAE78661483C1FC4936B06EA01_RuntimeMethod_var)));
	}

IL_0024:
	{
		int32_t L_6 = ___0_x;
		int32_t L_7 = ___1_y;
		int32_t L_8 = ___2_width;
		int32_t L_9 = ___3_height;
		SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* L_10;
		L_10 = TerrainData_Internal_GetAlphamaps_m6891C19FF72B4394D6BAC3B098A3FCAC1FC6BF36(__this, L_6, L_7, L_8, L_9, NULL);
		V_1 = L_10;
		goto IL_0032;
	}

IL_0032:
	{
		SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* L_11 = V_1;
		return L_11;
	}
}
// System.Single[,,] UnityEngine.TerrainData::Internal_GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* TerrainData_Internal_GetAlphamaps_m6891C19FF72B4394D6BAC3B098A3FCAC1FC6BF36 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, const RuntimeMethod* method) 
{
	typedef SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* (*TerrainData_Internal_GetAlphamaps_m6891C19FF72B4394D6BAC3B098A3FCAC1FC6BF36_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, int32_t, int32_t, int32_t, int32_t);
	static TerrainData_Internal_GetAlphamaps_m6891C19FF72B4394D6BAC3B098A3FCAC1FC6BF36_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_Internal_GetAlphamaps_m6891C19FF72B4394D6BAC3B098A3FCAC1FC6BF36_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::Internal_GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)");
	SingleU5BU2CU2CU5D_tE902E5192C7283A470AAADB477117789A9682488* icallRetVal = _il2cpp_icall_func(__this, ___0_x, ___1_y, ___2_width, ___3_height);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_alphamapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_alphamapResolution_mC5D1C8FF4A5AFFCCFCF1382FED0D1AD46563D6F8 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = TerrainData_get_Internal_alphamapResolution_mDA8EF6055A2022B3E1E4E6ECBF8DF4387DE8A930(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.TerrainData::GetAlphamapResolutionInternal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float TerrainData_GetAlphamapResolutionInternal_m5C312434763B8F0BD8DE760ACF439DFEFAC2F3E5 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef float (*TerrainData_GetAlphamapResolutionInternal_m5C312434763B8F0BD8DE760ACF439DFEFAC2F3E5_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_GetAlphamapResolutionInternal_m5C312434763B8F0BD8DE760ACF439DFEFAC2F3E5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetAlphamapResolutionInternal_m5C312434763B8F0BD8DE760ACF439DFEFAC2F3E5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetAlphamapResolutionInternal()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_Internal_alphamapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_Internal_alphamapResolution_mDA8EF6055A2022B3E1E4E6ECBF8DF4387DE8A930 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_get_Internal_alphamapResolution_mDA8EF6055A2022B3E1E4E6ECBF8DF4387DE8A930_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_Internal_alphamapResolution_mDA8EF6055A2022B3E1E4E6ECBF8DF4387DE8A930_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_Internal_alphamapResolution_mDA8EF6055A2022B3E1E4E6ECBF8DF4387DE8A930_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_Internal_alphamapResolution()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_alphamapWidth()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_alphamapWidth_m07E5B04B08E87AC9F66D766B363000F94C8612D4 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = TerrainData_get_alphamapResolution_mC5D1C8FF4A5AFFCCFCF1382FED0D1AD46563D6F8(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.TerrainData::get_alphamapHeight()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_alphamapHeight_m4A8273D6E0E3526A31E2669FBAB240353C086AED (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = TerrainData_get_alphamapResolution_mC5D1C8FF4A5AFFCCFCF1382FED0D1AD46563D6F8(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.TerrainData::get_baseMapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_baseMapResolution_mCD5E59C7A2778009CD4A4CA571B6B85CC0993C0C (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = TerrainData_get_Internal_baseMapResolution_m160A9621FE9E5BE642C8CE8C8DA64A07DDF5830F(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.TerrainData::get_Internal_baseMapResolution()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_Internal_baseMapResolution_m160A9621FE9E5BE642C8CE8C8DA64A07DDF5830F (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_get_Internal_baseMapResolution_m160A9621FE9E5BE642C8CE8C8DA64A07DDF5830F_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_Internal_baseMapResolution_m160A9621FE9E5BE642C8CE8C8DA64A07DDF5830F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_Internal_baseMapResolution_m160A9621FE9E5BE642C8CE8C8DA64A07DDF5830F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_Internal_baseMapResolution()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.Texture2D UnityEngine.TerrainData::GetAlphamapTexture(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* TerrainData_GetAlphamapTexture_mFA6A25F6C09FE64114F69D528046E78B1581366C (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	typedef Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* (*TerrainData_GetAlphamapTexture_mFA6A25F6C09FE64114F69D528046E78B1581366C_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, int32_t);
	static TerrainData_GetAlphamapTexture_mFA6A25F6C09FE64114F69D528046E78B1581366C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetAlphamapTexture_mFA6A25F6C09FE64114F69D528046E78B1581366C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetAlphamapTexture(System.Int32)");
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* icallRetVal = _il2cpp_icall_func(__this, ___0_index);
	return icallRetVal;
}
// System.Int32 UnityEngine.TerrainData::get_alphamapTextureCount()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainData_get_alphamapTextureCount_mF378908EA58CA135A4D58D586179418F1A6F14CD (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*TerrainData_get_alphamapTextureCount_mF378908EA58CA135A4D58D586179418F1A6F14CD_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_alphamapTextureCount_mF378908EA58CA135A4D58D586179418F1A6F14CD_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_alphamapTextureCount_mF378908EA58CA135A4D58D586179418F1A6F14CD_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_alphamapTextureCount()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.Texture2D[] UnityEngine.TerrainData::get_alphamapTextures()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* TerrainData_get_alphamapTextures_m82B7287C772D95D4E3D6A5793A8B9A15745D8C45 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* V_3 = NULL;
	{
		int32_t L_0;
		L_0 = TerrainData_get_alphamapTextureCount_mF378908EA58CA135A4D58D586179418F1A6F14CD(__this, NULL);
		Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* L_1 = (Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191*)(Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191*)SZArrayNew(Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191_il2cpp_TypeInfo_var, (uint32_t)L_0);
		V_0 = L_1;
		V_1 = 0;
		goto IL_001f;
	}

IL_0011:
	{
		Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* L_2 = V_0;
		int32_t L_3 = V_1;
		int32_t L_4 = V_1;
		Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* L_5;
		L_5 = TerrainData_GetAlphamapTexture_mFA6A25F6C09FE64114F69D528046E78B1581366C(__this, L_4, NULL);
		NullCheck(L_2);
		ArrayElementTypeCheck (L_2, L_5);
		(L_2)->SetAt(static_cast<il2cpp_array_size_t>(L_3), (Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4*)L_5);
		int32_t L_6 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_6, 1));
	}

IL_001f:
	{
		int32_t L_7 = V_1;
		Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* L_8 = V_0;
		NullCheck(L_8);
		V_2 = (bool)((((int32_t)L_7) < ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length))))? 1 : 0);
		bool L_9 = V_2;
		if (L_9)
		{
			goto IL_0011;
		}
	}
	{
		Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* L_10 = V_0;
		V_3 = L_10;
		goto IL_002d;
	}

IL_002d:
	{
		Texture2DU5BU5D_t05332F1E3F7D4493E304C702201F9BE4F9236191* L_11 = V_3;
		return L_11;
	}
}
// UnityEngine.TerrainLayer[] UnityEngine.TerrainData::get_terrainLayers()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainLayerU5BU5D_t259E391D6115F121FCD284E79F62012D70956EB0* TerrainData_get_terrainLayers_m3B436DF37DDD9F18A46DD6BF112925AD5B8857C8 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef TerrainLayerU5BU5D_t259E391D6115F121FCD284E79F62012D70956EB0* (*TerrainData_get_terrainLayers_m3B436DF37DDD9F18A46DD6BF112925AD5B8857C8_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_terrainLayers_m3B436DF37DDD9F18A46DD6BF112925AD5B8857C8_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_terrainLayers_m3B436DF37DDD9F18A46DD6BF112925AD5B8857C8_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_terrainLayers()");
	TerrainLayerU5BU5D_t259E391D6115F121FCD284E79F62012D70956EB0* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainData::SyncHeightmap()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_SyncHeightmap_mD8D77E9DD9063B7201D062C810CFEAF2BE743267 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef void (*TerrainData_SyncHeightmap_mD8D77E9DD9063B7201D062C810CFEAF2BE743267_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_SyncHeightmap_mD8D77E9DD9063B7201D062C810CFEAF2BE743267_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_SyncHeightmap_mD8D77E9DD9063B7201D062C810CFEAF2BE743267_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::SyncHeightmap()");
	_il2cpp_icall_func(__this);
}
// UnityEngine.Terrain[] UnityEngine.TerrainData::get_users()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* TerrainData_get_users_m0C569F1AD5853CEBF3C572723A1CAD04AC8433C4 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, const RuntimeMethod* method) 
{
	typedef TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* (*TerrainData_get_users_m0C569F1AD5853CEBF3C572723A1CAD04AC8433C4_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainData_get_users_m0C569F1AD5853CEBF3C572723A1CAD04AC8433C4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_users_m0C569F1AD5853CEBF3C572723A1CAD04AC8433C4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_users()");
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.TerrainData::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData__cctor_m525F8AF6DEDDACF640BD2D24767502121ED6D9B0 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0;
		L_0 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(0, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MaximumResolution_10 = L_0;
		int32_t L_1;
		L_1 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(1, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MinimumDetailResolutionPerPatch_11 = L_1;
		int32_t L_2;
		L_2 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(2, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MaximumDetailResolutionPerPatch_12 = L_2;
		int32_t L_3;
		L_3 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(3, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MaximumDetailPatchCount_13 = L_3;
		int32_t L_4;
		L_4 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(4, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MaximumDetailsPerRes_14 = L_4;
		int32_t L_5;
		L_5 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(5, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MinimumAlphamapResolution_15 = L_5;
		int32_t L_6;
		L_6 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(6, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MaximumAlphamapResolution_16 = L_6;
		int32_t L_7;
		L_7 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(7, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MinimumBaseMapResolution_17 = L_7;
		int32_t L_8;
		L_8 = TerrainData_GetBoundaryValue_mA9217CC15BBC958C9F7071B96CE74769EFDC322E(8, NULL);
		((TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_il2cpp_TypeInfo_var))->___k_MaximumBaseMapResolution_18 = L_8;
		return;
	}
}
// System.Void UnityEngine.TerrainData::get_size_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_get_size_Injected_m0F56E87C4D7EDD1D84F038E4AF0F273D328CF661 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainData_get_size_Injected_m0F56E87C4D7EDD1D84F038E4AF0F273D328CF661_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*);
	static TerrainData_get_size_Injected_m0F56E87C4D7EDD1D84F038E4AF0F273D328CF661_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_size_Injected_m0F56E87C4D7EDD1D84F038E4AF0F273D328CF661_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_size_Injected(UnityEngine.Vector3&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.TerrainData::GetInterpolatedNormal_Injected(System.Single,System.Single,UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainData_GetInterpolatedNormal_Injected_mF6E35FCDF546E498658E864D47EB87C22B41E571 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* __this, float ___0_x, float ___1_y, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___2_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainData_GetInterpolatedNormal_Injected_mF6E35FCDF546E498658E864D47EB87C22B41E571_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*, float, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*);
	static TerrainData_GetInterpolatedNormal_Injected_mF6E35FCDF546E498658E864D47EB87C22B41E571_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetInterpolatedNormal_Injected_mF6E35FCDF546E498658E864D47EB87C22B41E571_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetInterpolatedNormal_Injected(System.Single,System.Single,UnityEngine.Vector3&)");
	_il2cpp_icall_func(__this, ___0_x, ___1_y, ___2_ret);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single UnityEngine.Terrain::get_splatmapDistance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_splatmapDistance_m0FC2686DCFB5606FE515B9B7EC720FE92C96065E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0;
		L_0 = Terrain_get_basemapDistance_m19DDA753F682B416665C5A7E171376EEE3BF312B(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.Terrain::set_splatmapDistance(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_splatmapDistance_m863B50B87A1DF039426E79D916E690A1E2EAFAF3 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	{
		float L_0 = ___0_value;
		Terrain_set_basemapDistance_m3CC75A7D5D67BA75A0E030F300A462C16905CF40(__this, L_0, NULL);
		return;
	}
}
// System.Boolean UnityEngine.Terrain::get_castShadows()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_castShadows_m3323F44BE250A712E8D34CE3C5D4EC7F1AD87BC7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = Terrain_get_shadowCastingMode_m4070042014ED55612368631D6335105FDF951114(__this, NULL);
		V_0 = (bool)((!(((uint32_t)L_0) <= ((uint32_t)0)))? 1 : 0);
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.Terrain::set_castShadows(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_castShadows_mEC211FA9586B718ED5436632A566DE8D6C0E26AB (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* G_B2_0 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* G_B1_0 = NULL;
	int32_t G_B3_0 = 0;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* G_B3_1 = NULL;
	{
		bool L_0 = ___0_value;
		G_B1_0 = __this;
		if (L_0)
		{
			G_B2_0 = __this;
			goto IL_0008;
		}
	}
	{
		G_B3_0 = 0;
		G_B3_1 = G_B1_0;
		goto IL_0009;
	}

IL_0008:
	{
		G_B3_0 = 2;
		G_B3_1 = G_B2_0;
	}

IL_0009:
	{
		NullCheck(G_B3_1);
		Terrain_set_shadowCastingMode_m1267E7389BEF6EBA9B6E23044225362CD6EA79BD(G_B3_1, G_B3_0, NULL);
		return;
	}
}
// UnityEngine.Terrain/MaterialType UnityEngine.Terrain::get_materialType()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_materialType_m4DA6FCD1D6E98FFB51B163E852CB904522B60FCB (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 3;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.Terrain::set_materialType(UnityEngine.Terrain/MaterialType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_materialType_mC78AA6B3C29A28909943D2498C281CE882E8D50F (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		return;
	}
}
// UnityEngine.Color UnityEngine.Terrain::get_legacySpecular()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Terrain_get_legacySpecular_m9066C975D891182376AB99BEDDC9B66EAB841C30 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0;
		L_0 = Color_get_gray_m6D01087E0F20F34718EBA5B213853B4BB49F1DEF_inline(NULL);
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.Terrain::set_legacySpecular(UnityEngine.Color)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_legacySpecular_m8576A8BD0E10E6C5F88D324C317367522BEF7242 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___0_value, const RuntimeMethod* method) 
{
	{
		return;
	}
}
// System.Single UnityEngine.Terrain::get_legacyShininess()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_legacyShininess_mA4C410EBAF37DB0A6986890C41ED2627AE9846B7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		V_0 = (0.078125f);
		goto IL_0009;
	}

IL_0009:
	{
		float L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.Terrain::set_legacyShininess(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_legacyShininess_mA4716046912CE099D9B58B1CD70F2063455BE757 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	{
		return;
	}
}
// System.Void UnityEngine.Terrain::ApplyDelayedHeightmapModification()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_ApplyDelayedHeightmapModification_m7C23AC364F9431B7F890B47F8D3EFA3FB268DB01 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* G_B2_0 = NULL;
	TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* G_B1_0 = NULL;
	{
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_0;
		L_0 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(__this, NULL);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000d;
		}
	}
	{
		goto IL_0013;
	}

IL_000d:
	{
		NullCheck(G_B2_0);
		TerrainData_SyncHeightmap_mD8D77E9DD9063B7201D062C810CFEAF2BE743267(G_B2_0, NULL);
	}

IL_0013:
	{
		return;
	}
}
// UnityEngine.TerrainData UnityEngine.Terrain::get_terrainData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* (*Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_terrainData()");
	TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_terrainData(UnityEngine.TerrainData)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_terrainData_m59F63BECF7DC2657DC887F1F59DA3427ED59994C (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_terrainData_m59F63BECF7DC2657DC887F1F59DA3427ED59994C_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static Terrain_set_terrainData_m59F63BECF7DC2657DC887F1F59DA3427ED59994C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_terrainData_m59F63BECF7DC2657DC887F1F59DA3427ED59994C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_terrainData(UnityEngine.TerrainData)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::get_treeDistance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_treeDistance_mE5394C9AAD12F1BD5474B51615D2E3906404F77A (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_treeDistance_mE5394C9AAD12F1BD5474B51615D2E3906404F77A_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_treeDistance_mE5394C9AAD12F1BD5474B51615D2E3906404F77A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_treeDistance_mE5394C9AAD12F1BD5474B51615D2E3906404F77A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_treeDistance()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_treeDistance(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_treeDistance_m8836D1691B1C7BDC76725A624601E6543806C14C (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_treeDistance_m8836D1691B1C7BDC76725A624601E6543806C14C_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_treeDistance_m8836D1691B1C7BDC76725A624601E6543806C14C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_treeDistance_m8836D1691B1C7BDC76725A624601E6543806C14C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_treeDistance(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::get_treeBillboardDistance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_treeBillboardDistance_m5A9D3F3B388042BE9C19F346426AA7BA01CBE1D8 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_treeBillboardDistance_m5A9D3F3B388042BE9C19F346426AA7BA01CBE1D8_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_treeBillboardDistance_m5A9D3F3B388042BE9C19F346426AA7BA01CBE1D8_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_treeBillboardDistance_m5A9D3F3B388042BE9C19F346426AA7BA01CBE1D8_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_treeBillboardDistance()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_treeBillboardDistance(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_treeBillboardDistance_m654B35A6BEE23489F2E4DEF0D12214D9F4A5FD8E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_treeBillboardDistance_m654B35A6BEE23489F2E4DEF0D12214D9F4A5FD8E_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_treeBillboardDistance_m654B35A6BEE23489F2E4DEF0D12214D9F4A5FD8E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_treeBillboardDistance_m654B35A6BEE23489F2E4DEF0D12214D9F4A5FD8E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_treeBillboardDistance(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::get_treeCrossFadeLength()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_treeCrossFadeLength_m037BF60679DC6C878F5D7B5189F4555CF496AFD4 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_treeCrossFadeLength_m037BF60679DC6C878F5D7B5189F4555CF496AFD4_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_treeCrossFadeLength_m037BF60679DC6C878F5D7B5189F4555CF496AFD4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_treeCrossFadeLength_m037BF60679DC6C878F5D7B5189F4555CF496AFD4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_treeCrossFadeLength()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_treeCrossFadeLength(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_treeCrossFadeLength_m639B8CAD49CF4AF938477D3F1E080932F2DBE6F1 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_treeCrossFadeLength_m639B8CAD49CF4AF938477D3F1E080932F2DBE6F1_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_treeCrossFadeLength_m639B8CAD49CF4AF938477D3F1E080932F2DBE6F1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_treeCrossFadeLength_m639B8CAD49CF4AF938477D3F1E080932F2DBE6F1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_treeCrossFadeLength(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Int32 UnityEngine.Terrain::get_treeMaximumFullLODCount()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_treeMaximumFullLODCount_m3626EB8E365A9B8620375AEB15604D112F669812 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_treeMaximumFullLODCount_m3626EB8E365A9B8620375AEB15604D112F669812_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_treeMaximumFullLODCount_m3626EB8E365A9B8620375AEB15604D112F669812_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_treeMaximumFullLODCount_m3626EB8E365A9B8620375AEB15604D112F669812_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_treeMaximumFullLODCount()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_treeMaximumFullLODCount(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_treeMaximumFullLODCount_mCDE91147B62F207B2841D41A2710A4B563A953D1 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_treeMaximumFullLODCount_mCDE91147B62F207B2841D41A2710A4B563A953D1_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_treeMaximumFullLODCount_mCDE91147B62F207B2841D41A2710A4B563A953D1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_treeMaximumFullLODCount_mCDE91147B62F207B2841D41A2710A4B563A953D1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_treeMaximumFullLODCount(System.Int32)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::get_detailObjectDistance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_detailObjectDistance_m230A961919F3B468A7F79312C164C1D50C648EBA (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_detailObjectDistance_m230A961919F3B468A7F79312C164C1D50C648EBA_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_detailObjectDistance_m230A961919F3B468A7F79312C164C1D50C648EBA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_detailObjectDistance_m230A961919F3B468A7F79312C164C1D50C648EBA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_detailObjectDistance()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_detailObjectDistance(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_detailObjectDistance_mE8B84B8EDE307BEB41E477CC9C35F8BA3A969EDE (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_detailObjectDistance_mE8B84B8EDE307BEB41E477CC9C35F8BA3A969EDE_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_detailObjectDistance_mE8B84B8EDE307BEB41E477CC9C35F8BA3A969EDE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_detailObjectDistance_mE8B84B8EDE307BEB41E477CC9C35F8BA3A969EDE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_detailObjectDistance(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::get_detailObjectDensity()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_detailObjectDensity_m2FEBE42D389A14F98A38888A423B21FD91E605E9 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_detailObjectDensity_m2FEBE42D389A14F98A38888A423B21FD91E605E9_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_detailObjectDensity_m2FEBE42D389A14F98A38888A423B21FD91E605E9_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_detailObjectDensity_m2FEBE42D389A14F98A38888A423B21FD91E605E9_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_detailObjectDensity()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_detailObjectDensity(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_detailObjectDensity_mFDE71C06416A56C18C54ED41485CBB1D1CB3520D (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_detailObjectDensity_mFDE71C06416A56C18C54ED41485CBB1D1CB3520D_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_detailObjectDensity_mFDE71C06416A56C18C54ED41485CBB1D1CB3520D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_detailObjectDensity_mFDE71C06416A56C18C54ED41485CBB1D1CB3520D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_detailObjectDensity(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::get_heightmapPixelError()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_heightmapPixelError_m9051CAA3D0939B5F0F5719F53A3B5E4CF55438C5 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_heightmapPixelError_m9051CAA3D0939B5F0F5719F53A3B5E4CF55438C5_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_heightmapPixelError_m9051CAA3D0939B5F0F5719F53A3B5E4CF55438C5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_heightmapPixelError_m9051CAA3D0939B5F0F5719F53A3B5E4CF55438C5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_heightmapPixelError()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_heightmapPixelError(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_heightmapPixelError_mEE31EA7AF7F41EB82C643468B52F4B10109C7FFF (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_heightmapPixelError_mEE31EA7AF7F41EB82C643468B52F4B10109C7FFF_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_heightmapPixelError_mEE31EA7AF7F41EB82C643468B52F4B10109C7FFF_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_heightmapPixelError_mEE31EA7AF7F41EB82C643468B52F4B10109C7FFF_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_heightmapPixelError(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Int32 UnityEngine.Terrain::get_heightmapMaximumLOD()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_heightmapMaximumLOD_mC57749C8FF75F58EE1F209BBD26C2B1C5292C829 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_heightmapMaximumLOD_mC57749C8FF75F58EE1F209BBD26C2B1C5292C829_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_heightmapMaximumLOD_mC57749C8FF75F58EE1F209BBD26C2B1C5292C829_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_heightmapMaximumLOD_mC57749C8FF75F58EE1F209BBD26C2B1C5292C829_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_heightmapMaximumLOD()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_heightmapMaximumLOD(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_heightmapMaximumLOD_m0638986CDAF871DDD4C80EA55E1CF60F44DF6F5E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_heightmapMaximumLOD_m0638986CDAF871DDD4C80EA55E1CF60F44DF6F5E_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_heightmapMaximumLOD_m0638986CDAF871DDD4C80EA55E1CF60F44DF6F5E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_heightmapMaximumLOD_m0638986CDAF871DDD4C80EA55E1CF60F44DF6F5E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_heightmapMaximumLOD(System.Int32)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::get_basemapDistance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_basemapDistance_m19DDA753F682B416665C5A7E171376EEE3BF312B (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_basemapDistance_m19DDA753F682B416665C5A7E171376EEE3BF312B_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_basemapDistance_m19DDA753F682B416665C5A7E171376EEE3BF312B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_basemapDistance_m19DDA753F682B416665C5A7E171376EEE3BF312B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_basemapDistance()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_basemapDistance(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_basemapDistance_m3CC75A7D5D67BA75A0E030F300A462C16905CF40 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_basemapDistance_m3CC75A7D5D67BA75A0E030F300A462C16905CF40_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_basemapDistance_m3CC75A7D5D67BA75A0E030F300A462C16905CF40_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_basemapDistance_m3CC75A7D5D67BA75A0E030F300A462C16905CF40_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_basemapDistance(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Int32 UnityEngine.Terrain::get_lightmapIndex()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_lightmapIndex_m79CF88EEEA60C4FACBA6D568C10A769D9654803E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_lightmapIndex_m79CF88EEEA60C4FACBA6D568C10A769D9654803E_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_lightmapIndex_m79CF88EEEA60C4FACBA6D568C10A769D9654803E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_lightmapIndex_m79CF88EEEA60C4FACBA6D568C10A769D9654803E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_lightmapIndex()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_lightmapIndex(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_lightmapIndex_m771ADCC6B582144408D4736C93E97EFFE21319C4 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_lightmapIndex_m771ADCC6B582144408D4736C93E97EFFE21319C4_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_lightmapIndex_m771ADCC6B582144408D4736C93E97EFFE21319C4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_lightmapIndex_m771ADCC6B582144408D4736C93E97EFFE21319C4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_lightmapIndex(System.Int32)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Int32 UnityEngine.Terrain::get_realtimeLightmapIndex()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_realtimeLightmapIndex_m7DA20D23C390C3525A3245A8CF3340188541BB64 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_realtimeLightmapIndex_m7DA20D23C390C3525A3245A8CF3340188541BB64_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_realtimeLightmapIndex_m7DA20D23C390C3525A3245A8CF3340188541BB64_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_realtimeLightmapIndex_m7DA20D23C390C3525A3245A8CF3340188541BB64_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_realtimeLightmapIndex()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_realtimeLightmapIndex(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_realtimeLightmapIndex_m1D972992A2DCBBD141D21DD089ADEB561CF6EA30 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_realtimeLightmapIndex_m1D972992A2DCBBD141D21DD089ADEB561CF6EA30_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_realtimeLightmapIndex_m1D972992A2DCBBD141D21DD089ADEB561CF6EA30_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_realtimeLightmapIndex_m1D972992A2DCBBD141D21DD089ADEB561CF6EA30_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_realtimeLightmapIndex(System.Int32)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Vector4 UnityEngine.Terrain::get_lightmapScaleOffset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 Terrain_get_lightmapScaleOffset_m27B3E8FD4CF439470223ABF5F077AAC2A045480B (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Terrain_get_lightmapScaleOffset_Injected_mD2EAABA59EC39ABCF49DAF4F0EA8273664B65562(__this, (&V_0), NULL);
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.Terrain::set_lightmapScaleOffset(UnityEngine.Vector4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_lightmapScaleOffset_m5ABDFF3AAA8BC1243B976AD50A89AA864C8D218D (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_value, const RuntimeMethod* method) 
{
	{
		Terrain_set_lightmapScaleOffset_Injected_m6EE17634B3B017635B441AB3224BA8E3A1E5DE47(__this, (&___0_value), NULL);
		return;
	}
}
// UnityEngine.Vector4 UnityEngine.Terrain::get_realtimeLightmapScaleOffset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 Terrain_get_realtimeLightmapScaleOffset_m028BC94F9D808480C241BD2D1A55F857E2D5287D (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Terrain_get_realtimeLightmapScaleOffset_Injected_m29ECF237E6B854DBF05C2BF365431CDAE3B4EDE4(__this, (&V_0), NULL);
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.Terrain::set_realtimeLightmapScaleOffset(UnityEngine.Vector4)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_realtimeLightmapScaleOffset_m599578984D728DC7EF3AE412879D7DC293A66E77 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_value, const RuntimeMethod* method) 
{
	{
		Terrain_set_realtimeLightmapScaleOffset_Injected_mF70656C179FC898C168A2F8AD8009D6CF21FE4FF(__this, (&___0_value), NULL);
		return;
	}
}
// System.Boolean UnityEngine.Terrain::get_freeUnusedRenderingResources()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_freeUnusedRenderingResources_mB7750A5195DFE7A96E99763E9EF0143D52124715 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_freeUnusedRenderingResources_mB7750A5195DFE7A96E99763E9EF0143D52124715_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_freeUnusedRenderingResources_mB7750A5195DFE7A96E99763E9EF0143D52124715_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_freeUnusedRenderingResources_mB7750A5195DFE7A96E99763E9EF0143D52124715_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_freeUnusedRenderingResources()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_freeUnusedRenderingResources(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_freeUnusedRenderingResources_mAFBEB163234FB5F808B453246765B980A8A28DDA (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_freeUnusedRenderingResources_mAFBEB163234FB5F808B453246765B980A8A28DDA_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_freeUnusedRenderingResources_mAFBEB163234FB5F808B453246765B980A8A28DDA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_freeUnusedRenderingResources_mAFBEB163234FB5F808B453246765B980A8A28DDA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_freeUnusedRenderingResources(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Boolean UnityEngine.Terrain::get_keepUnusedRenderingResources()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_keepUnusedRenderingResources_m795AD911467CB1E237543208A48A9E5DDFFF5032 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_keepUnusedRenderingResources_m795AD911467CB1E237543208A48A9E5DDFFF5032_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_keepUnusedRenderingResources_m795AD911467CB1E237543208A48A9E5DDFFF5032_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_keepUnusedRenderingResources_m795AD911467CB1E237543208A48A9E5DDFFF5032_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_keepUnusedRenderingResources()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_keepUnusedRenderingResources(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_keepUnusedRenderingResources_mFFE068865CA7F9EF1B875E0C1B0548A4D14E8C9F (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_keepUnusedRenderingResources_mFFE068865CA7F9EF1B875E0C1B0548A4D14E8C9F_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_keepUnusedRenderingResources_mFFE068865CA7F9EF1B875E0C1B0548A4D14E8C9F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_keepUnusedRenderingResources_mFFE068865CA7F9EF1B875E0C1B0548A4D14E8C9F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_keepUnusedRenderingResources(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Boolean UnityEngine.Terrain::GetKeepUnusedCameraRenderingResources(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_GetKeepUnusedCameraRenderingResources_m36AE2CC2933A8ED02A0A6B1581B1733C9309BA97 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_cameraInstanceID, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_GetKeepUnusedCameraRenderingResources_m36AE2CC2933A8ED02A0A6B1581B1733C9309BA97_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_GetKeepUnusedCameraRenderingResources_m36AE2CC2933A8ED02A0A6B1581B1733C9309BA97_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_GetKeepUnusedCameraRenderingResources_m36AE2CC2933A8ED02A0A6B1581B1733C9309BA97_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::GetKeepUnusedCameraRenderingResources(System.Int32)");
	bool icallRetVal = _il2cpp_icall_func(__this, ___0_cameraInstanceID);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::SetKeepUnusedCameraRenderingResources(System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_SetKeepUnusedCameraRenderingResources_m00A637BC1210C488F62A6D39A7E60EDD843371D0 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_cameraInstanceID, bool ___1_keepUnused, const RuntimeMethod* method) 
{
	typedef void (*Terrain_SetKeepUnusedCameraRenderingResources_m00A637BC1210C488F62A6D39A7E60EDD843371D0_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t, bool);
	static Terrain_SetKeepUnusedCameraRenderingResources_m00A637BC1210C488F62A6D39A7E60EDD843371D0_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_SetKeepUnusedCameraRenderingResources_m00A637BC1210C488F62A6D39A7E60EDD843371D0_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::SetKeepUnusedCameraRenderingResources(System.Int32,System.Boolean)");
	_il2cpp_icall_func(__this, ___0_cameraInstanceID, ___1_keepUnused);
}
// UnityEngine.Rendering.ShadowCastingMode UnityEngine.Terrain::get_shadowCastingMode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_shadowCastingMode_m4070042014ED55612368631D6335105FDF951114 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_shadowCastingMode_m4070042014ED55612368631D6335105FDF951114_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_shadowCastingMode_m4070042014ED55612368631D6335105FDF951114_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_shadowCastingMode_m4070042014ED55612368631D6335105FDF951114_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_shadowCastingMode()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_shadowCastingMode(UnityEngine.Rendering.ShadowCastingMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_shadowCastingMode_m1267E7389BEF6EBA9B6E23044225362CD6EA79BD (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_shadowCastingMode_m1267E7389BEF6EBA9B6E23044225362CD6EA79BD_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_shadowCastingMode_m1267E7389BEF6EBA9B6E23044225362CD6EA79BD_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_shadowCastingMode_m1267E7389BEF6EBA9B6E23044225362CD6EA79BD_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_shadowCastingMode(UnityEngine.Rendering.ShadowCastingMode)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Rendering.ReflectionProbeUsage UnityEngine.Terrain::get_reflectionProbeUsage()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_reflectionProbeUsage_mAAFE9BC6BD45E280BF1EFD911184A630CC91C090 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_reflectionProbeUsage_mAAFE9BC6BD45E280BF1EFD911184A630CC91C090_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_reflectionProbeUsage_mAAFE9BC6BD45E280BF1EFD911184A630CC91C090_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_reflectionProbeUsage_mAAFE9BC6BD45E280BF1EFD911184A630CC91C090_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_reflectionProbeUsage()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_reflectionProbeUsage(UnityEngine.Rendering.ReflectionProbeUsage)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_reflectionProbeUsage_m9D034C6790A0F28D118E330F590772E3240373B6 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_reflectionProbeUsage_m9D034C6790A0F28D118E330F590772E3240373B6_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_reflectionProbeUsage_m9D034C6790A0F28D118E330F590772E3240373B6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_reflectionProbeUsage_m9D034C6790A0F28D118E330F590772E3240373B6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_reflectionProbeUsage(UnityEngine.Rendering.ReflectionProbeUsage)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.Terrain::GetClosestReflectionProbes(System.Collections.Generic.List`1<UnityEngine.Rendering.ReflectionProbeBlendInfo>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_GetClosestReflectionProbes_m6DFCD7ACACF5566A37691DBDD466BFD0F96A0B29 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, List_1_t1100962F75A3C1A8DDD989C01DEE91D38A84082A* ___0_result, const RuntimeMethod* method) 
{
	typedef void (*Terrain_GetClosestReflectionProbes_m6DFCD7ACACF5566A37691DBDD466BFD0F96A0B29_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, List_1_t1100962F75A3C1A8DDD989C01DEE91D38A84082A*);
	static Terrain_GetClosestReflectionProbes_m6DFCD7ACACF5566A37691DBDD466BFD0F96A0B29_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_GetClosestReflectionProbes_m6DFCD7ACACF5566A37691DBDD466BFD0F96A0B29_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::GetClosestReflectionProbes(System.Collections.Generic.List`1<UnityEngine.Rendering.ReflectionProbeBlendInfo>)");
	_il2cpp_icall_func(__this, ___0_result);
}
// UnityEngine.Material UnityEngine.Terrain::get_materialTemplate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* Terrain_get_materialTemplate_mB3BE06B73866CF772A9B2B42069CE3AECA288DE7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* (*Terrain_get_materialTemplate_mB3BE06B73866CF772A9B2B42069CE3AECA288DE7_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_materialTemplate_mB3BE06B73866CF772A9B2B42069CE3AECA288DE7_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_materialTemplate_mB3BE06B73866CF772A9B2B42069CE3AECA288DE7_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_materialTemplate()");
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_materialTemplate(UnityEngine.Material)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_materialTemplate_mAC433DD496BAB83C63718B862C11064FD20EB7F0 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_materialTemplate_mAC433DD496BAB83C63718B862C11064FD20EB7F0_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3*);
	static Terrain_set_materialTemplate_mAC433DD496BAB83C63718B862C11064FD20EB7F0_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_materialTemplate_mAC433DD496BAB83C63718B862C11064FD20EB7F0_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_materialTemplate(UnityEngine.Material)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Boolean UnityEngine.Terrain::get_drawHeightmap()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_drawHeightmap_m41EBA9E260C303324FD8A24A9FD155001D4715FE (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_drawHeightmap_m41EBA9E260C303324FD8A24A9FD155001D4715FE_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_drawHeightmap_m41EBA9E260C303324FD8A24A9FD155001D4715FE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_drawHeightmap_m41EBA9E260C303324FD8A24A9FD155001D4715FE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_drawHeightmap()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_drawHeightmap(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_drawHeightmap_m39CA641057F8C3482CF7BADD65B1FD89106195F9 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_drawHeightmap_m39CA641057F8C3482CF7BADD65B1FD89106195F9_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_drawHeightmap_m39CA641057F8C3482CF7BADD65B1FD89106195F9_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_drawHeightmap_m39CA641057F8C3482CF7BADD65B1FD89106195F9_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_drawHeightmap(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Boolean UnityEngine.Terrain::get_allowAutoConnect()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_allowAutoConnect()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_allowAutoConnect(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_allowAutoConnect_mBAA98DD489268404D1157A29759982CDFB45BF11 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_allowAutoConnect_mBAA98DD489268404D1157A29759982CDFB45BF11_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_allowAutoConnect_mBAA98DD489268404D1157A29759982CDFB45BF11_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_allowAutoConnect_mBAA98DD489268404D1157A29759982CDFB45BF11_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_allowAutoConnect(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Int32 UnityEngine.Terrain::get_groupingID()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_groupingID()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_groupingID(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_groupingID_m0C89CE036FD16514CDC70B52270B853F7FCBF334 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_groupingID_m0C89CE036FD16514CDC70B52270B853F7FCBF334_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_groupingID_m0C89CE036FD16514CDC70B52270B853F7FCBF334_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_groupingID_m0C89CE036FD16514CDC70B52270B853F7FCBF334_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_groupingID(System.Int32)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Boolean UnityEngine.Terrain::get_drawInstanced()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_drawInstanced_m7E8C2EB30B4F778927EE017163B79B113598CB34 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_drawInstanced_m7E8C2EB30B4F778927EE017163B79B113598CB34_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_drawInstanced_m7E8C2EB30B4F778927EE017163B79B113598CB34_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_drawInstanced_m7E8C2EB30B4F778927EE017163B79B113598CB34_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_drawInstanced()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_drawInstanced(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_drawInstanced_m8846CAE84A778178A98DE6C0A764EBEA7B45D1F3 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_drawInstanced_m8846CAE84A778178A98DE6C0A764EBEA7B45D1F3_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_drawInstanced_m8846CAE84A778178A98DE6C0A764EBEA7B45D1F3_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_drawInstanced_m8846CAE84A778178A98DE6C0A764EBEA7B45D1F3_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_drawInstanced(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.RenderTexture UnityEngine.Terrain::get_normalmapTexture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* Terrain_get_normalmapTexture_m0B073CA3D5CD8E6176A8512B6B095F7BBE0D4C53 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* (*Terrain_get_normalmapTexture_m0B073CA3D5CD8E6176A8512B6B095F7BBE0D4C53_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_normalmapTexture_m0B073CA3D5CD8E6176A8512B6B095F7BBE0D4C53_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_normalmapTexture_m0B073CA3D5CD8E6176A8512B6B095F7BBE0D4C53_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_normalmapTexture()");
	RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Boolean UnityEngine.Terrain::get_drawTreesAndFoliage()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_drawTreesAndFoliage_mD04FA3FDAAF4C49C875AFF6DA926531AD2190187 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_drawTreesAndFoliage_mD04FA3FDAAF4C49C875AFF6DA926531AD2190187_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_drawTreesAndFoliage_mD04FA3FDAAF4C49C875AFF6DA926531AD2190187_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_drawTreesAndFoliage_mD04FA3FDAAF4C49C875AFF6DA926531AD2190187_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_drawTreesAndFoliage()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_drawTreesAndFoliage(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_drawTreesAndFoliage_mCF36A66A7AC9072D3EC5706A9213CFC46D38689A (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_drawTreesAndFoliage_mCF36A66A7AC9072D3EC5706A9213CFC46D38689A_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_drawTreesAndFoliage_mCF36A66A7AC9072D3EC5706A9213CFC46D38689A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_drawTreesAndFoliage_mCF36A66A7AC9072D3EC5706A9213CFC46D38689A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_drawTreesAndFoliage(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Vector3 UnityEngine.Terrain::get_patchBoundsMultiplier()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Terrain_get_patchBoundsMultiplier_m9FFCE6D0355BE5853182DAEF3DA4043EE3CC7435 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Terrain_get_patchBoundsMultiplier_Injected_m50860EC61F48B0DEB611BED7571AE29B436982F6(__this, (&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.Terrain::set_patchBoundsMultiplier(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_patchBoundsMultiplier_mD5B6AED331E3843988403FD13BBC2E625344BAAC (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___0_value, const RuntimeMethod* method) 
{
	{
		Terrain_set_patchBoundsMultiplier_Injected_mD42F66A68FF0A7BE6E39B7C962EEEAC055F2E462(__this, (&___0_value), NULL);
		return;
	}
}
// System.Single UnityEngine.Terrain::SampleHeight(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_SampleHeight_m460F9060BC4D5F05275391A6AC05570047EF3177 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___0_worldPosition, const RuntimeMethod* method) 
{
	{
		float L_0;
		L_0 = Terrain_SampleHeight_Injected_m08851544EDBB88AFD061CD7E63E7995203BC7557(__this, (&___0_worldPosition), NULL);
		return L_0;
	}
}
// System.Void UnityEngine.Terrain::AddTreeInstance(UnityEngine.TreeInstance)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_AddTreeInstance_mD11FD23312CDF066606036F336EC317FC63B6436 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, TreeInstance_t382B018173ED020660D262061EA9424682614F50 ___0_instance, const RuntimeMethod* method) 
{
	{
		Terrain_AddTreeInstance_Injected_m68720D1D8743CF74F8911B424DD9284C78563210(__this, (&___0_instance), NULL);
		return;
	}
}
// System.Void UnityEngine.Terrain::SetNeighbors(UnityEngine.Terrain,UnityEngine.Terrain,UnityEngine.Terrain,UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_SetNeighbors_m2FFA89D199120125D264EF7EE0BC749A35514C1E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_left, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___1_top, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___2_right, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___3_bottom, const RuntimeMethod* method) 
{
	typedef void (*Terrain_SetNeighbors_m2FFA89D199120125D264EF7EE0BC749A35514C1E_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_SetNeighbors_m2FFA89D199120125D264EF7EE0BC749A35514C1E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_SetNeighbors_m2FFA89D199120125D264EF7EE0BC749A35514C1E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::SetNeighbors(UnityEngine.Terrain,UnityEngine.Terrain,UnityEngine.Terrain,UnityEngine.Terrain)");
	_il2cpp_icall_func(__this, ___0_left, ___1_top, ___2_right, ___3_bottom);
}
// System.Single UnityEngine.Terrain::get_treeLODBiasMultiplier()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_get_treeLODBiasMultiplier_m1BB2454CBE32BB3AE525E5F0FAD8F9363CBB7DCA (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef float (*Terrain_get_treeLODBiasMultiplier_m1BB2454CBE32BB3AE525E5F0FAD8F9363CBB7DCA_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_treeLODBiasMultiplier_m1BB2454CBE32BB3AE525E5F0FAD8F9363CBB7DCA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_treeLODBiasMultiplier_m1BB2454CBE32BB3AE525E5F0FAD8F9363CBB7DCA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_treeLODBiasMultiplier()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_treeLODBiasMultiplier(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_treeLODBiasMultiplier_mD8287BC51A55A0B68C2066F3C22AD1C18AE863E5 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, float ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_treeLODBiasMultiplier_mD8287BC51A55A0B68C2066F3C22AD1C18AE863E5_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, float);
	static Terrain_set_treeLODBiasMultiplier_mD8287BC51A55A0B68C2066F3C22AD1C18AE863E5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_treeLODBiasMultiplier_mD8287BC51A55A0B68C2066F3C22AD1C18AE863E5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_treeLODBiasMultiplier(System.Single)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Boolean UnityEngine.Terrain::get_collectDetailPatches()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_collectDetailPatches_m0E86F73ABD8BDC8DE29A062D307BCEC4E03EE64B (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_collectDetailPatches_m0E86F73ABD8BDC8DE29A062D307BCEC4E03EE64B_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_collectDetailPatches_m0E86F73ABD8BDC8DE29A062D307BCEC4E03EE64B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_collectDetailPatches_m0E86F73ABD8BDC8DE29A062D307BCEC4E03EE64B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_collectDetailPatches()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_collectDetailPatches(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_collectDetailPatches_m1FC681318E104B97274412E3C80F04FF90E6B564 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_collectDetailPatches_m1FC681318E104B97274412E3C80F04FF90E6B564_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_collectDetailPatches_m1FC681318E104B97274412E3C80F04FF90E6B564_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_collectDetailPatches_m1FC681318E104B97274412E3C80F04FF90E6B564_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_collectDetailPatches(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.TerrainRenderFlags UnityEngine.Terrain::get_editorRenderFlags()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_editorRenderFlags_mE55875C5D3E964CC1275FC4ACAF3674D9D8793F4 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_editorRenderFlags_mE55875C5D3E964CC1275FC4ACAF3674D9D8793F4_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_editorRenderFlags_mE55875C5D3E964CC1275FC4ACAF3674D9D8793F4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_editorRenderFlags_mE55875C5D3E964CC1275FC4ACAF3674D9D8793F4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_editorRenderFlags()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_editorRenderFlags(UnityEngine.TerrainRenderFlags)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_editorRenderFlags_m891E1F37730C9E3D6ABDED416B360A3EB0468C8A (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_editorRenderFlags_m891E1F37730C9E3D6ABDED416B360A3EB0468C8A_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, int32_t);
	static Terrain_set_editorRenderFlags_m891E1F37730C9E3D6ABDED416B360A3EB0468C8A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_editorRenderFlags_m891E1F37730C9E3D6ABDED416B360A3EB0468C8A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_editorRenderFlags(UnityEngine.TerrainRenderFlags)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Vector3 UnityEngine.Terrain::GetPosition()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Terrain_GetPosition_m5A1020F22CA4B1818E69A3B9687668AFAB2C43F5 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Terrain_GetPosition_Injected_m23EC0958466016EFB553CFBBE1B6E4FB076FE419(__this, (&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = V_0;
		return L_0;
	}
}
// System.Void UnityEngine.Terrain::Flush()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_Flush_m960CA9087AB6C18BE3C6B54DD993B5E728E5FA95 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef void (*Terrain_Flush_m960CA9087AB6C18BE3C6B54DD993B5E728E5FA95_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_Flush_m960CA9087AB6C18BE3C6B54DD993B5E728E5FA95_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_Flush_m960CA9087AB6C18BE3C6B54DD993B5E728E5FA95_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::Flush()");
	_il2cpp_icall_func(__this);
}
// System.Void UnityEngine.Terrain::RemoveTrees(UnityEngine.Vector2,System.Single,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_RemoveTrees_mD2D7E380123771264CEB2306594DE290AD604EB7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___0_position, float ___1_radius, int32_t ___2_prototypeIndex, const RuntimeMethod* method) 
{
	{
		float L_0 = ___1_radius;
		int32_t L_1 = ___2_prototypeIndex;
		Terrain_RemoveTrees_Injected_m7401D70AB9B44261A015FB398996D1041CB46846(__this, (&___0_position), L_0, L_1, NULL);
		return;
	}
}
// System.Void UnityEngine.Terrain::SetSplatMaterialPropertyBlock(UnityEngine.MaterialPropertyBlock)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_SetSplatMaterialPropertyBlock_mF7D441C25CA04812F7A95D5CDBAA6F4ACA6D7F0E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* ___0_properties, const RuntimeMethod* method) 
{
	typedef void (*Terrain_SetSplatMaterialPropertyBlock_mF7D441C25CA04812F7A95D5CDBAA6F4ACA6D7F0E_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D*);
	static Terrain_SetSplatMaterialPropertyBlock_mF7D441C25CA04812F7A95D5CDBAA6F4ACA6D7F0E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_SetSplatMaterialPropertyBlock_mF7D441C25CA04812F7A95D5CDBAA6F4ACA6D7F0E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::SetSplatMaterialPropertyBlock(UnityEngine.MaterialPropertyBlock)");
	_il2cpp_icall_func(__this, ___0_properties);
}
// System.Void UnityEngine.Terrain::GetSplatMaterialPropertyBlock(UnityEngine.MaterialPropertyBlock)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_GetSplatMaterialPropertyBlock_m12C9F2F14B6D92021E72AE994D438E2C6DF69FEF (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* ___0_dest, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* L_0 = ___0_dest;
		V_0 = (bool)((((RuntimeObject*)(MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0014;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_2 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		NullCheck(L_2);
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral532F5429956965038FA49DA954E9A0D4D34B41A9)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Terrain_GetSplatMaterialPropertyBlock_m12C9F2F14B6D92021E72AE994D438E2C6DF69FEF_RuntimeMethod_var)));
	}

IL_0014:
	{
		MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* L_3 = ___0_dest;
		Terrain_Internal_GetSplatMaterialPropertyBlock_m30EF43010BAE0F7F7AD19041E36A4F44F023D61E(__this, L_3, NULL);
		return;
	}
}
// System.Void UnityEngine.Terrain::Internal_GetSplatMaterialPropertyBlock(UnityEngine.MaterialPropertyBlock)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_Internal_GetSplatMaterialPropertyBlock_m30EF43010BAE0F7F7AD19041E36A4F44F023D61E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* ___0_dest, const RuntimeMethod* method) 
{
	typedef void (*Terrain_Internal_GetSplatMaterialPropertyBlock_m30EF43010BAE0F7F7AD19041E36A4F44F023D61E_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D*);
	static Terrain_Internal_GetSplatMaterialPropertyBlock_m30EF43010BAE0F7F7AD19041E36A4F44F023D61E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_Internal_GetSplatMaterialPropertyBlock_m30EF43010BAE0F7F7AD19041E36A4F44F023D61E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::Internal_GetSplatMaterialPropertyBlock(UnityEngine.MaterialPropertyBlock)");
	_il2cpp_icall_func(__this, ___0_dest);
}
// System.Boolean UnityEngine.Terrain::get_preserveTreePrototypeLayers()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Terrain_get_preserveTreePrototypeLayers_m8C45D508EBB7A14A25920093D24AFC66E2ACFBD6 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef bool (*Terrain_get_preserveTreePrototypeLayers_m8C45D508EBB7A14A25920093D24AFC66E2ACFBD6_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_preserveTreePrototypeLayers_m8C45D508EBB7A14A25920093D24AFC66E2ACFBD6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_preserveTreePrototypeLayers_m8C45D508EBB7A14A25920093D24AFC66E2ACFBD6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_preserveTreePrototypeLayers()");
	bool icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_preserveTreePrototypeLayers(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_preserveTreePrototypeLayers_mCBE60BF8EE44DA31170E32B8C31B64393A8EC4DA (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, bool ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_preserveTreePrototypeLayers_mCBE60BF8EE44DA31170E32B8C31B64393A8EC4DA_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, bool);
	static Terrain_set_preserveTreePrototypeLayers_mCBE60BF8EE44DA31170E32B8C31B64393A8EC4DA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_preserveTreePrototypeLayers_mCBE60BF8EE44DA31170E32B8C31B64393A8EC4DA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_preserveTreePrototypeLayers(System.Boolean)");
	_il2cpp_icall_func(__this, ___0_value);
}
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_heightmapFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_heightmapFormat_m7BDD479FF7710457999A405C226D2AEE901DDF87 (const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_heightmapFormat_m7BDD479FF7710457999A405C226D2AEE901DDF87_ftn) ();
	static Terrain_get_heightmapFormat_m7BDD479FF7710457999A405C226D2AEE901DDF87_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_heightmapFormat_m7BDD479FF7710457999A405C226D2AEE901DDF87_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_heightmapFormat()");
	int32_t icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
// UnityEngine.TextureFormat UnityEngine.Terrain::get_heightmapTextureFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_heightmapTextureFormat_mD3B13DC4664DDB71E4C4CD1CE95ACC9DF35B9722 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Terrain_get_heightmapFormat_m7BDD479FF7710457999A405C226D2AEE901DDF87(NULL);
		il2cpp_codegen_runtime_class_init_inline(GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = GraphicsFormatUtility_GetTextureFormat_mBFDD045E2526CDF13BC3C34D8E342F4797D467F4(L_0, NULL);
		V_0 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.RenderTextureFormat UnityEngine.Terrain::get_heightmapRenderTextureFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_heightmapRenderTextureFormat_m81550AE5326309C22601E667FA4F5032DDE56BC5 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Terrain_get_heightmapFormat_m7BDD479FF7710457999A405C226D2AEE901DDF87(NULL);
		il2cpp_codegen_runtime_class_init_inline(GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = GraphicsFormatUtility_GetRenderTextureFormat_mA538222F90B6079E95ADA1DFB3DDDA740B27D8D5(L_0, NULL);
		V_0 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_normalmapFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_normalmapFormat_m70C88E3838D7938A60BFBBEF5BB2EFCD99EBA716 (const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_normalmapFormat_m70C88E3838D7938A60BFBBEF5BB2EFCD99EBA716_ftn) ();
	static Terrain_get_normalmapFormat_m70C88E3838D7938A60BFBBEF5BB2EFCD99EBA716_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_normalmapFormat_m70C88E3838D7938A60BFBBEF5BB2EFCD99EBA716_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_normalmapFormat()");
	int32_t icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
// UnityEngine.TextureFormat UnityEngine.Terrain::get_normalmapTextureFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_normalmapTextureFormat_m4599EE3389898A7589ABC29F50DB337BC2F81BFC (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Terrain_get_normalmapFormat_m70C88E3838D7938A60BFBBEF5BB2EFCD99EBA716(NULL);
		il2cpp_codegen_runtime_class_init_inline(GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = GraphicsFormatUtility_GetTextureFormat_mBFDD045E2526CDF13BC3C34D8E342F4797D467F4(L_0, NULL);
		V_0 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.RenderTextureFormat UnityEngine.Terrain::get_normalmapRenderTextureFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_normalmapRenderTextureFormat_mE32604BFA382DEE5EF9E223FC5B0AED451FBB7A5 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Terrain_get_normalmapFormat_m70C88E3838D7938A60BFBBEF5BB2EFCD99EBA716(NULL);
		il2cpp_codegen_runtime_class_init_inline(GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = GraphicsFormatUtility_GetRenderTextureFormat_mA538222F90B6079E95ADA1DFB3DDDA740B27D8D5(L_0, NULL);
		V_0 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_holesFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_holesFormat_m3BCE4632B6CE7D1A058070DC65CEDEF5365838BE (const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_holesFormat_m3BCE4632B6CE7D1A058070DC65CEDEF5365838BE_ftn) ();
	static Terrain_get_holesFormat_m3BCE4632B6CE7D1A058070DC65CEDEF5365838BE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_holesFormat_m3BCE4632B6CE7D1A058070DC65CEDEF5365838BE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_holesFormat()");
	int32_t icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
// UnityEngine.RenderTextureFormat UnityEngine.Terrain::get_holesRenderTextureFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_holesRenderTextureFormat_m960C437EC8DA9338ED56323263AD6F8B5CB6CD3B (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Terrain_get_holesFormat_m3BCE4632B6CE7D1A058070DC65CEDEF5365838BE(NULL);
		il2cpp_codegen_runtime_class_init_inline(GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = GraphicsFormatUtility_GetRenderTextureFormat_mA538222F90B6079E95ADA1DFB3DDDA740B27D8D5(L_0, NULL);
		V_0 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Experimental.Rendering.GraphicsFormat UnityEngine.Terrain::get_compressedHolesFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_compressedHolesFormat_m386E6544EE29FC198609605B796C8DD06983658C (const RuntimeMethod* method) 
{
	typedef int32_t (*Terrain_get_compressedHolesFormat_m386E6544EE29FC198609605B796C8DD06983658C_ftn) ();
	static Terrain_get_compressedHolesFormat_m386E6544EE29FC198609605B796C8DD06983658C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_compressedHolesFormat_m386E6544EE29FC198609605B796C8DD06983658C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_compressedHolesFormat()");
	int32_t icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
// UnityEngine.TextureFormat UnityEngine.Terrain::get_compressedHolesTextureFormat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Terrain_get_compressedHolesTextureFormat_m1613558760307F7999EEFE230A1DFC612BE73A33 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0;
		L_0 = Terrain_get_compressedHolesFormat_m386E6544EE29FC198609605B796C8DD06983658C(NULL);
		il2cpp_codegen_runtime_class_init_inline(GraphicsFormatUtility_t3DAD8CAC84EA38F28613F98184F871773CB282FD_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = GraphicsFormatUtility_GetTextureFormat_mBFDD045E2526CDF13BC3C34D8E342F4797D467F4(L_0, NULL);
		V_0 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Terrain UnityEngine.Terrain::get_activeTerrain()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* Terrain_get_activeTerrain_mAE5A7FE933C2C1A57FC9542E9BFA315A413F224E (const RuntimeMethod* method) 
{
	typedef Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* (*Terrain_get_activeTerrain_mAE5A7FE933C2C1A57FC9542E9BFA315A413F224E_ftn) ();
	static Terrain_get_activeTerrain_mAE5A7FE933C2C1A57FC9542E9BFA315A413F224E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_activeTerrain_mAE5A7FE933C2C1A57FC9542E9BFA315A413F224E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_activeTerrain()");
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::SetConnectivityDirty()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_SetConnectivityDirty_mE2F27F3B012109EC58BA2B37711EAAA9329CF91C (const RuntimeMethod* method) 
{
	typedef void (*Terrain_SetConnectivityDirty_mE2F27F3B012109EC58BA2B37711EAAA9329CF91C_ftn) ();
	static Terrain_SetConnectivityDirty_mE2F27F3B012109EC58BA2B37711EAAA9329CF91C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_SetConnectivityDirty_mE2F27F3B012109EC58BA2B37711EAAA9329CF91C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::SetConnectivityDirty()");
	_il2cpp_icall_func();
}
// UnityEngine.Terrain[] UnityEngine.Terrain::get_activeTerrains()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701 (const RuntimeMethod* method) 
{
	typedef TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* (*Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701_ftn) ();
	static Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_activeTerrains()");
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::GetActiveTerrains(System.Collections.Generic.List`1<UnityEngine.Terrain>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_GetActiveTerrains_mED4BDC0714F7743290CEC886012B04A81DC77686 (List_1_tD2AD001A66810CB968E98D9E635A799408554017* ___0_terrainList, const RuntimeMethod* method) 
{
	{
		List_1_tD2AD001A66810CB968E98D9E635A799408554017* L_0 = ___0_terrainList;
		Terrain_Internal_FillActiveTerrainList_m00E77C57C0ED1C10647C734780A511DF56B50692(L_0, NULL);
		return;
	}
}
// System.Void UnityEngine.Terrain::Internal_FillActiveTerrainList(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_Internal_FillActiveTerrainList_m00E77C57C0ED1C10647C734780A511DF56B50692 (RuntimeObject* ___0_terrainList, const RuntimeMethod* method) 
{
	typedef void (*Terrain_Internal_FillActiveTerrainList_m00E77C57C0ED1C10647C734780A511DF56B50692_ftn) (RuntimeObject*);
	static Terrain_Internal_FillActiveTerrainList_m00E77C57C0ED1C10647C734780A511DF56B50692_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_Internal_FillActiveTerrainList_m00E77C57C0ED1C10647C734780A511DF56B50692_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::Internal_FillActiveTerrainList(System.Object)");
	_il2cpp_icall_func(___0_terrainList);
}
// UnityEngine.GameObject UnityEngine.Terrain::CreateTerrainGameObject(UnityEngine.TerrainData)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* Terrain_CreateTerrainGameObject_m31CBC26A8971667B09CC08C868EA31E8A5D29522 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* ___0_assignTerrain, const RuntimeMethod* method) 
{
	typedef GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* (*Terrain_CreateTerrainGameObject_m31CBC26A8971667B09CC08C868EA31E8A5D29522_ftn) (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static Terrain_CreateTerrainGameObject_m31CBC26A8971667B09CC08C868EA31E8A5D29522_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_CreateTerrainGameObject_m31CBC26A8971667B09CC08C868EA31E8A5D29522_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::CreateTerrainGameObject(UnityEngine.TerrainData)");
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* icallRetVal = _il2cpp_icall_func(___0_assignTerrain);
	return icallRetVal;
}
// UnityEngine.Terrain UnityEngine.Terrain::get_leftNeighbor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* Terrain_get_leftNeighbor_mA42E758BD513BC9E0FB87888FC24B3C4349A353E (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* (*Terrain_get_leftNeighbor_mA42E758BD513BC9E0FB87888FC24B3C4349A353E_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_leftNeighbor_mA42E758BD513BC9E0FB87888FC24B3C4349A353E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_leftNeighbor_mA42E758BD513BC9E0FB87888FC24B3C4349A353E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_leftNeighbor()");
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.Terrain UnityEngine.Terrain::get_rightNeighbor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* Terrain_get_rightNeighbor_mA50D19F61FFBA544E94733B097D4409B15FECC17 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* (*Terrain_get_rightNeighbor_mA50D19F61FFBA544E94733B097D4409B15FECC17_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_rightNeighbor_mA50D19F61FFBA544E94733B097D4409B15FECC17_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_rightNeighbor_mA50D19F61FFBA544E94733B097D4409B15FECC17_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_rightNeighbor()");
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.Terrain UnityEngine.Terrain::get_topNeighbor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* Terrain_get_topNeighbor_mCBC502C4CC0D617863D7A3A726EBFA4BD18BDF8C (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* (*Terrain_get_topNeighbor_mCBC502C4CC0D617863D7A3A726EBFA4BD18BDF8C_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_topNeighbor_mCBC502C4CC0D617863D7A3A726EBFA4BD18BDF8C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_topNeighbor_mCBC502C4CC0D617863D7A3A726EBFA4BD18BDF8C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_topNeighbor()");
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// UnityEngine.Terrain UnityEngine.Terrain::get_bottomNeighbor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* Terrain_get_bottomNeighbor_m31306E01318F62D214B5E0966C988FB24255406F (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* (*Terrain_get_bottomNeighbor_m31306E01318F62D214B5E0966C988FB24255406F_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_bottomNeighbor_m31306E01318F62D214B5E0966C988FB24255406F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_bottomNeighbor_m31306E01318F62D214B5E0966C988FB24255406F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_bottomNeighbor()");
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.UInt32 UnityEngine.Terrain::get_renderingLayerMask()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t Terrain_get_renderingLayerMask_m8A0C2E21E7DC988D9DF2E058DA231D0AA13ECC31 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	typedef uint32_t (*Terrain_get_renderingLayerMask_m8A0C2E21E7DC988D9DF2E058DA231D0AA13ECC31_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*);
	static Terrain_get_renderingLayerMask_m8A0C2E21E7DC988D9DF2E058DA231D0AA13ECC31_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_renderingLayerMask_m8A0C2E21E7DC988D9DF2E058DA231D0AA13ECC31_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_renderingLayerMask()");
	uint32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::set_renderingLayerMask(System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_renderingLayerMask_m5F843E15CF24EF2BE27AEB21F1C9E6C846F2D249 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, uint32_t ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_renderingLayerMask_m5F843E15CF24EF2BE27AEB21F1C9E6C846F2D249_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, uint32_t);
	static Terrain_set_renderingLayerMask_m5F843E15CF24EF2BE27AEB21F1C9E6C846F2D249_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_renderingLayerMask_m5F843E15CF24EF2BE27AEB21F1C9E6C846F2D249_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_renderingLayerMask(System.UInt32)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.Terrain::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain__ctor_m11F03EC6C1E68752DDCAE8EF2DED99CFD939FCDC (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, const RuntimeMethod* method) 
{
	{
		Behaviour__ctor_m00422B6EFEA829BCB116D715E74F1EAD2CB6F4F8(__this, NULL);
		return;
	}
}
// System.Void UnityEngine.Terrain::get_lightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_get_lightmapScaleOffset_Injected_mD2EAABA59EC39ABCF49DAF4F0EA8273664B65562 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*Terrain_get_lightmapScaleOffset_Injected_mD2EAABA59EC39ABCF49DAF4F0EA8273664B65562_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static Terrain_get_lightmapScaleOffset_Injected_mD2EAABA59EC39ABCF49DAF4F0EA8273664B65562_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_lightmapScaleOffset_Injected_mD2EAABA59EC39ABCF49DAF4F0EA8273664B65562_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_lightmapScaleOffset_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.Terrain::set_lightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_lightmapScaleOffset_Injected_m6EE17634B3B017635B441AB3224BA8E3A1E5DE47 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_lightmapScaleOffset_Injected_m6EE17634B3B017635B441AB3224BA8E3A1E5DE47_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static Terrain_set_lightmapScaleOffset_Injected_m6EE17634B3B017635B441AB3224BA8E3A1E5DE47_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_lightmapScaleOffset_Injected_m6EE17634B3B017635B441AB3224BA8E3A1E5DE47_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_lightmapScaleOffset_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.Terrain::get_realtimeLightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_get_realtimeLightmapScaleOffset_Injected_m29ECF237E6B854DBF05C2BF365431CDAE3B4EDE4 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*Terrain_get_realtimeLightmapScaleOffset_Injected_m29ECF237E6B854DBF05C2BF365431CDAE3B4EDE4_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static Terrain_get_realtimeLightmapScaleOffset_Injected_m29ECF237E6B854DBF05C2BF365431CDAE3B4EDE4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_realtimeLightmapScaleOffset_Injected_m29ECF237E6B854DBF05C2BF365431CDAE3B4EDE4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_realtimeLightmapScaleOffset_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.Terrain::set_realtimeLightmapScaleOffset_Injected(UnityEngine.Vector4&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_realtimeLightmapScaleOffset_Injected_mF70656C179FC898C168A2F8AD8009D6CF21FE4FF (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_realtimeLightmapScaleOffset_Injected_mF70656C179FC898C168A2F8AD8009D6CF21FE4FF_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3*);
	static Terrain_set_realtimeLightmapScaleOffset_Injected_mF70656C179FC898C168A2F8AD8009D6CF21FE4FF_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_realtimeLightmapScaleOffset_Injected_mF70656C179FC898C168A2F8AD8009D6CF21FE4FF_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_realtimeLightmapScaleOffset_Injected(UnityEngine.Vector4&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Void UnityEngine.Terrain::get_patchBoundsMultiplier_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_get_patchBoundsMultiplier_Injected_m50860EC61F48B0DEB611BED7571AE29B436982F6 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*Terrain_get_patchBoundsMultiplier_Injected_m50860EC61F48B0DEB611BED7571AE29B436982F6_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*);
	static Terrain_get_patchBoundsMultiplier_Injected_m50860EC61F48B0DEB611BED7571AE29B436982F6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_patchBoundsMultiplier_Injected_m50860EC61F48B0DEB611BED7571AE29B436982F6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_patchBoundsMultiplier_Injected(UnityEngine.Vector3&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.Terrain::set_patchBoundsMultiplier_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_set_patchBoundsMultiplier_Injected_mD42F66A68FF0A7BE6E39B7C962EEEAC055F2E462 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*Terrain_set_patchBoundsMultiplier_Injected_mD42F66A68FF0A7BE6E39B7C962EEEAC055F2E462_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*);
	static Terrain_set_patchBoundsMultiplier_Injected_mD42F66A68FF0A7BE6E39B7C962EEEAC055F2E462_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_set_patchBoundsMultiplier_Injected_mD42F66A68FF0A7BE6E39B7C962EEEAC055F2E462_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::set_patchBoundsMultiplier_Injected(UnityEngine.Vector3&)");
	_il2cpp_icall_func(__this, ___0_value);
}
// System.Single UnityEngine.Terrain::SampleHeight_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Terrain_SampleHeight_Injected_m08851544EDBB88AFD061CD7E63E7995203BC7557 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_worldPosition, const RuntimeMethod* method) 
{
	typedef float (*Terrain_SampleHeight_Injected_m08851544EDBB88AFD061CD7E63E7995203BC7557_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*);
	static Terrain_SampleHeight_Injected_m08851544EDBB88AFD061CD7E63E7995203BC7557_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_SampleHeight_Injected_m08851544EDBB88AFD061CD7E63E7995203BC7557_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::SampleHeight_Injected(UnityEngine.Vector3&)");
	float icallRetVal = _il2cpp_icall_func(__this, ___0_worldPosition);
	return icallRetVal;
}
// System.Void UnityEngine.Terrain::AddTreeInstance_Injected(UnityEngine.TreeInstance&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_AddTreeInstance_Injected_m68720D1D8743CF74F8911B424DD9284C78563210 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, TreeInstance_t382B018173ED020660D262061EA9424682614F50* ___0_instance, const RuntimeMethod* method) 
{
	typedef void (*Terrain_AddTreeInstance_Injected_m68720D1D8743CF74F8911B424DD9284C78563210_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, TreeInstance_t382B018173ED020660D262061EA9424682614F50*);
	static Terrain_AddTreeInstance_Injected_m68720D1D8743CF74F8911B424DD9284C78563210_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_AddTreeInstance_Injected_m68720D1D8743CF74F8911B424DD9284C78563210_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::AddTreeInstance_Injected(UnityEngine.TreeInstance&)");
	_il2cpp_icall_func(__this, ___0_instance);
}
// System.Void UnityEngine.Terrain::GetPosition_Injected(UnityEngine.Vector3&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_GetPosition_Injected_m23EC0958466016EFB553CFBBE1B6E4FB076FE419 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___0_ret, const RuntimeMethod* method) 
{
	typedef void (*Terrain_GetPosition_Injected_m23EC0958466016EFB553CFBBE1B6E4FB076FE419_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*);
	static Terrain_GetPosition_Injected_m23EC0958466016EFB553CFBBE1B6E4FB076FE419_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_GetPosition_Injected_m23EC0958466016EFB553CFBBE1B6E4FB076FE419_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::GetPosition_Injected(UnityEngine.Vector3&)");
	_il2cpp_icall_func(__this, ___0_ret);
}
// System.Void UnityEngine.Terrain::RemoveTrees_Injected(UnityEngine.Vector2&,System.Single,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Terrain_RemoveTrees_Injected_m7401D70AB9B44261A015FB398996D1041CB46846 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___0_position, float ___1_radius, int32_t ___2_prototypeIndex, const RuntimeMethod* method) 
{
	typedef void (*Terrain_RemoveTrees_Injected_m7401D70AB9B44261A015FB398996D1041CB46846_ftn) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, float, int32_t);
	static Terrain_RemoveTrees_Injected_m7401D70AB9B44261A015FB398996D1041CB46846_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_RemoveTrees_Injected_m7401D70AB9B44261A015FB398996D1041CB46846_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::RemoveTrees_Injected(UnityEngine.Vector2&,System.Single,System.Int32)");
	_il2cpp_icall_func(__this, ___0_position, ___1_radius, ___2_prototypeIndex);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.TerrainCallbacks::InvokeHeightmapChangedCallback(UnityEngine.TerrainData,UnityEngine.RectInt,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainCallbacks_InvokeHeightmapChangedCallback_m731ED939CBD563CCCE503062602DF5908205AD04 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* ___0_terrainData, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* V_1 = NULL;
	int32_t V_2 = 0;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_3 = NULL;
	{
		HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* L_0 = ((TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_StaticFields*)il2cpp_codegen_static_fields_for(TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_il2cpp_TypeInfo_var))->___heightmapChanged_0;
		V_0 = (bool)((!(((RuntimeObject*)(HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0037;
		}
	}
	{
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_2 = ___0_terrainData;
		NullCheck(L_2);
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_3;
		L_3 = TerrainData_get_users_m0C569F1AD5853CEBF3C572723A1CAD04AC8433C4(L_2, NULL);
		V_1 = L_3;
		V_2 = 0;
		goto IL_0030;
	}

IL_001a:
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_4 = V_1;
		int32_t L_5 = V_2;
		NullCheck(L_4);
		int32_t L_6 = L_5;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		V_3 = L_7;
		HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* L_8 = ((TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_StaticFields*)il2cpp_codegen_static_fields_for(TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_il2cpp_TypeInfo_var))->___heightmapChanged_0;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_9 = V_3;
		RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 L_10 = ___1_heightRegion;
		bool L_11 = ___2_synched;
		NullCheck(L_8);
		HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_inline(L_8, L_9, L_10, L_11, NULL);
		int32_t L_12 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0030:
	{
		int32_t L_13 = V_2;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_14 = V_1;
		NullCheck(L_14);
		if ((((int32_t)L_13) < ((int32_t)((int32_t)(((RuntimeArray*)L_14)->max_length)))))
		{
			goto IL_001a;
		}
	}
	{
	}

IL_0037:
	{
		return;
	}
}
// System.Void UnityEngine.TerrainCallbacks::InvokeTextureChangedCallback(UnityEngine.TerrainData,System.String,UnityEngine.RectInt,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainCallbacks_InvokeTextureChangedCallback_mB508E8B7A884854AA01AE5B88AB33E1AE40F4318 (TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* ___0_terrainData, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* V_1 = NULL;
	int32_t V_2 = 0;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_3 = NULL;
	{
		TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* L_0 = ((TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_StaticFields*)il2cpp_codegen_static_fields_for(TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_il2cpp_TypeInfo_var))->___textureChanged_1;
		V_0 = (bool)((!(((RuntimeObject*)(TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0038;
		}
	}
	{
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_2 = ___0_terrainData;
		NullCheck(L_2);
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_3;
		L_3 = TerrainData_get_users_m0C569F1AD5853CEBF3C572723A1CAD04AC8433C4(L_2, NULL);
		V_1 = L_3;
		V_2 = 0;
		goto IL_0031;
	}

IL_001a:
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_4 = V_1;
		int32_t L_5 = V_2;
		NullCheck(L_4);
		int32_t L_6 = L_5;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		V_3 = L_7;
		TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* L_8 = ((TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_StaticFields*)il2cpp_codegen_static_fields_for(TerrainCallbacks_tE504E6C7F9609FDE7009DFEA9E405218E5212B5C_il2cpp_TypeInfo_var))->___textureChanged_1;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_9 = V_3;
		String_t* L_10 = ___1_textureName;
		RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 L_11 = ___2_texelRegion;
		bool L_12 = ___3_synched;
		NullCheck(L_8);
		TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_inline(L_8, L_9, L_10, L_11, L_12, NULL);
		int32_t L_13 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_13, 1));
	}

IL_0031:
	{
		int32_t L_14 = V_2;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_15 = V_1;
		NullCheck(L_15);
		if ((((int32_t)L_14) < ((int32_t)((int32_t)(((RuntimeArray*)L_15)->max_length)))))
		{
			goto IL_001a;
		}
	}
	{
	}

IL_0038:
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_Multicast(HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* currentDelegate = reinterpret_cast<HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___0_terrain, ___1_heightRegion, ___2_synched, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_OpenInst(HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method)
{
	NullCheck(___0_terrain);
	typedef void (*FunctionPointerType) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___0_terrain, ___1_heightRegion, ___2_synched, method);
}
void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_OpenStatic(HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___0_terrain, ___1_heightRegion, ___2_synched, method);
}
void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_OpenStaticInvoker(HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method)
{
	InvokerActionInvoker3< Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool >::Invoke((Il2CppMethodPointer)__this->___method_ptr_0, method, NULL, ___0_terrain, ___1_heightRegion, ___2_synched);
}
void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_ClosedStaticInvoker(HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method)
{
	InvokerActionInvoker4< RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool >::Invoke((Il2CppMethodPointer)__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___0_terrain, ___1_heightRegion, ___2_synched);
}
// System.Void UnityEngine.TerrainCallbacks/HeightmapChangedCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HeightmapChangedCallback__ctor_m6A7E4189E0A7A1B70EE73818B93B0FC9F613648C (HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = (intptr_t)il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___1_method);
	__this->___method_3 = ___1_method;
	__this->___m_target_2 = ___0_object;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___0_object);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___1_method);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___1_method))
	{
		bool isOpen = parameterCount == 3;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___1_method))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = __this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 2;
		if (isOpen)
		{
			__this->___invoke_impl_1 = (intptr_t)&HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_OpenInst;
		}
		else
		{
			if (___0_object == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = __this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_Multicast;
}
// System.Void UnityEngine.TerrainCallbacks/HeightmapChangedCallback::Invoke(UnityEngine.Terrain,UnityEngine.RectInt,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875 (HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___0_terrain, ___1_heightRegion, ___2_synched, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_Multicast(TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* currentDelegate = reinterpret_cast<TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, String_t*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___0_terrain, ___1_textureName, ___2_texelRegion, ___3_synched, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_OpenInst(TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method)
{
	NullCheck(___0_terrain);
	typedef void (*FunctionPointerType) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, String_t*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___0_terrain, ___1_textureName, ___2_texelRegion, ___3_synched, method);
}
void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_OpenStatic(TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, String_t*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___0_terrain, ___1_textureName, ___2_texelRegion, ___3_synched, method);
}
void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_OpenStaticInvoker(TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method)
{
	InvokerActionInvoker4< Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, String_t*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool >::Invoke((Il2CppMethodPointer)__this->___method_ptr_0, method, NULL, ___0_terrain, ___1_textureName, ___2_texelRegion, ___3_synched);
}
void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_ClosedStaticInvoker(TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method)
{
	InvokerActionInvoker5< RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, String_t*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool >::Invoke((Il2CppMethodPointer)__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___0_terrain, ___1_textureName, ___2_texelRegion, ___3_synched);
}
// System.Void UnityEngine.TerrainCallbacks/TextureChangedCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TextureChangedCallback__ctor_m64076D799FEB79E3D6BE2C4EB33CD081A398F0EF (TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = (intptr_t)il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___1_method);
	__this->___method_3 = ___1_method;
	__this->___m_target_2 = ___0_object;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___0_object);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___1_method);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___1_method))
	{
		bool isOpen = parameterCount == 4;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___1_method))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = __this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 3;
		if (isOpen)
		{
			__this->___invoke_impl_1 = (intptr_t)&TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_OpenInst;
		}
		else
		{
			if (___0_object == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = __this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_Multicast;
}
// System.Void UnityEngine.TerrainCallbacks/TextureChangedCallback::Invoke(UnityEngine.Terrain,System.String,UnityEngine.RectInt,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE (TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, String_t*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___0_terrain, ___1_textureName, ___2_texelRegion, ___3_synched, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.TerrainUtils.TerrainTileCoord::.ctor(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainTileCoord__ctor_m6B6744655B9C3BA9B1A92076F07002B4B4EB899A (TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09* __this, int32_t ___0_tileX, int32_t ___1_tileZ, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_tileX;
		__this->___tileX_0 = L_0;
		int32_t L_1 = ___1_tileZ;
		__this->___tileZ_1 = L_1;
		return;
	}
}
IL2CPP_EXTERN_C  void TerrainTileCoord__ctor_m6B6744655B9C3BA9B1A92076F07002B4B4EB899A_AdjustorThunk (RuntimeObject* __this, int32_t ___0_tileX, int32_t ___1_tileZ, const RuntimeMethod* method)
{
	TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09*>(__this + _offset);
	TerrainTileCoord__ctor_m6B6744655B9C3BA9B1A92076F07002B4B4EB899A(_thisAdjusted, ___0_tileX, ___1_tileZ, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Terrain UnityEngine.TerrainUtils.TerrainMap::GetTerrain(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_tileX, int32_t ___1_tileZ, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_TryGetValue_mA4944115ADCBA991881F907C9E48413EB1EFE42A_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_0 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_1 = NULL;
	{
		V_0 = (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*)NULL;
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_0 = __this->___m_terrainTiles_2;
		int32_t L_1 = ___0_tileX;
		int32_t L_2 = ___1_tileZ;
		TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_3;
		memset((&L_3), 0, sizeof(L_3));
		TerrainTileCoord__ctor_m6B6744655B9C3BA9B1A92076F07002B4B4EB899A((&L_3), L_1, L_2, /*hidden argument*/NULL);
		NullCheck(L_0);
		bool L_4;
		L_4 = Dictionary_2_TryGetValue_mA4944115ADCBA991881F907C9E48413EB1EFE42A(L_0, L_3, (&V_0), Dictionary_2_TryGetValue_mA4944115ADCBA991881F907C9E48413EB1EFE42A_RuntimeMethod_var);
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_5 = V_0;
		V_1 = L_5;
		goto IL_001c;
	}

IL_001c:
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_6 = V_1;
		return L_6;
	}
}
// UnityEngine.TerrainUtils.TerrainMap UnityEngine.TerrainUtils.TerrainMap::CreateFromPlacement(UnityEngine.Terrain,System.Predicate`1<UnityEngine.Terrain>,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* TerrainMap_CreateFromPlacement_mC7822A5F4FC2A2CB119259A48F19D364ACEC5AE7 (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_originTerrain, Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* ___1_filter, bool ___2_fullValidation, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass3_0_U3CCreateFromPlacementU3Eb__0_m703A4D4E3D378C9896199B70A89FCDF1A07C737B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3* V_0 = NULL;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	float V_4 = 0.0f;
	bool V_5 = false;
	TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* V_6 = NULL;
	bool V_7 = false;
	bool V_8 = false;
	int32_t G_B4_0 = 0;
	{
		U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3* L_0 = (U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3*)il2cpp_codegen_object_new(U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CU3Ec__DisplayClass3_0__ctor_mAFD4AEF760F5CC7CE66BAD750DAD3697397E8945(L_0, NULL);
		V_0 = L_0;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_1;
		L_1 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		if (!L_1)
		{
			goto IL_001f;
		}
	}
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_2;
		L_2 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		NullCheck(L_2);
		if (!(((RuntimeArray*)L_2)->max_length))
		{
			goto IL_001f;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_3 = ___0_originTerrain;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_3, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B4_0 = ((int32_t)(L_4));
		goto IL_0020;
	}

IL_001f:
	{
		G_B4_0 = 1;
	}

IL_0020:
	{
		V_5 = (bool)G_B4_0;
		bool L_5 = V_5;
		if (!L_5)
		{
			goto IL_002e;
		}
	}
	{
		V_6 = (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB*)NULL;
		goto IL_00cb;
	}

IL_002e:
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_6 = ___0_originTerrain;
		NullCheck(L_6);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_7;
		L_7 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_6, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_8;
		L_8 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_7, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_7 = L_8;
		bool L_9 = V_7;
		if (!L_9)
		{
			goto IL_0048;
		}
	}
	{
		V_6 = (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB*)NULL;
		goto IL_00cb;
	}

IL_0048:
	{
		U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3* L_10 = V_0;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_11 = ___0_originTerrain;
		NullCheck(L_11);
		int32_t L_12;
		L_12 = Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24(L_11, NULL);
		NullCheck(L_10);
		L_10->___groupID_0 = L_12;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_13 = ___0_originTerrain;
		NullCheck(L_13);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_14;
		L_14 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_13, NULL);
		NullCheck(L_14);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15;
		L_15 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_14, NULL);
		float L_16 = L_15.___x_2;
		V_1 = L_16;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_17 = ___0_originTerrain;
		NullCheck(L_17);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_18;
		L_18 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_17, NULL);
		NullCheck(L_18);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19;
		L_19 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_18, NULL);
		float L_20 = L_19.___z_4;
		V_2 = L_20;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_21 = ___0_originTerrain;
		NullCheck(L_21);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_22;
		L_22 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_21, NULL);
		NullCheck(L_22);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_22, NULL);
		float L_24 = L_23.___x_2;
		V_3 = L_24;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_25 = ___0_originTerrain;
		NullCheck(L_25);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_26;
		L_26 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_25, NULL);
		NullCheck(L_26);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27;
		L_27 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_26, NULL);
		float L_28 = L_27.___z_4;
		V_4 = L_28;
		Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* L_29 = ___1_filter;
		V_8 = (bool)((((RuntimeObject*)(Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055*)L_29) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_30 = V_8;
		if (!L_30)
		{
			goto IL_00b1;
		}
	}
	{
		U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3* L_31 = V_0;
		Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* L_32 = (Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055*)il2cpp_codegen_object_new(Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055_il2cpp_TypeInfo_var);
		NullCheck(L_32);
		Predicate_1__ctor_m80A5EFAAAC439A069D5782C725DF325FDD5D891C(L_32, L_31, (intptr_t)((void*)U3CU3Ec__DisplayClass3_0_U3CCreateFromPlacementU3Eb__0_m703A4D4E3D378C9896199B70A89FCDF1A07C737B_RuntimeMethod_var), NULL);
		___1_filter = L_32;
	}

IL_00b1:
	{
		float L_33 = V_1;
		float L_34 = V_2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_35;
		memset((&L_35), 0, sizeof(L_35));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_35), L_33, L_34, /*hidden argument*/NULL);
		float L_36 = V_3;
		float L_37 = V_4;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_38;
		memset((&L_38), 0, sizeof(L_38));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_38), L_36, L_37, /*hidden argument*/NULL);
		Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* L_39 = ___1_filter;
		bool L_40 = ___2_fullValidation;
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_41;
		L_41 = TerrainMap_CreateFromPlacement_m64B90ADBC1D3A1AE18CEC7D0B452377E10B2BCB5(L_35, L_38, L_39, L_40, NULL);
		V_6 = L_41;
		goto IL_00cb;
	}

IL_00cb:
	{
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_42 = V_6;
		return L_42;
	}
}
// UnityEngine.TerrainUtils.TerrainMap UnityEngine.TerrainUtils.TerrainMap::CreateFromPlacement(UnityEngine.Vector2,UnityEngine.Vector2,System.Predicate`1<UnityEngine.Terrain>,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* TerrainMap_CreateFromPlacement_m64B90ADBC1D3A1AE18CEC7D0B452377E10B2BCB5 (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___0_gridOrigin, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___1_gridSize, Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* ___2_filter, bool ___3_fullValidation, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* V_0 = NULL;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	bool V_3 = false;
	TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* V_4 = NULL;
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* V_5 = NULL;
	int32_t V_6 = 0;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_7 = NULL;
	bool V_8 = false;
	bool V_9 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_10;
	memset((&V_10), 0, sizeof(V_10));
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	bool V_13 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B11_0 = 0;
	TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* G_B21_0 = NULL;
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_0;
		L_0 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_1;
		L_1 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		NullCheck(L_1);
		G_B3_0 = ((((int32_t)(((RuntimeArray*)L_1)->max_length)) == ((int32_t)0))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		V_3 = (bool)G_B3_0;
		bool L_2 = V_3;
		if (!L_2)
		{
			goto IL_0020;
		}
	}
	{
		V_4 = (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB*)NULL;
		goto IL_0102;
	}

IL_0020:
	{
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_3 = (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB*)il2cpp_codegen_object_new(TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB_il2cpp_TypeInfo_var);
		NullCheck(L_3);
		TerrainMap__ctor_mCDB47BA50D9D54E65754028F9CF8F91828FE616F(L_3, NULL);
		V_0 = L_3;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4 = ___1_gridSize;
		float L_5 = L_4.___x_0;
		V_1 = ((float)((1.0f)/L_5));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_6 = ___1_gridSize;
		float L_7 = L_6.___y_1;
		V_2 = ((float)((1.0f)/L_7));
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_8;
		L_8 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		V_5 = L_8;
		V_6 = 0;
		goto IL_00d3;
	}

IL_0050:
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_9 = V_5;
		int32_t L_10 = V_6;
		NullCheck(L_9);
		int32_t L_11 = L_10;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_12 = (L_9)->GetAt(static_cast<il2cpp_array_size_t>(L_11));
		V_7 = L_12;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_13 = V_7;
		NullCheck(L_13);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_14;
		L_14 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_13, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_15;
		L_15 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_14, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_8 = L_15;
		bool L_16 = V_8;
		if (!L_16)
		{
			goto IL_006d;
		}
	}
	{
		goto IL_00cd;
	}

IL_006d:
	{
		Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* L_17 = ___2_filter;
		if (!L_17)
		{
			goto IL_007a;
		}
	}
	{
		Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* L_18 = ___2_filter;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_19 = V_7;
		NullCheck(L_18);
		bool L_20;
		L_20 = Predicate_1_Invoke_mA6B25B82B5FF8BFA2DCF9E5A8600C761222B0B2A_inline(L_18, L_19, NULL);
		G_B11_0 = ((int32_t)(L_20));
		goto IL_007b;
	}

IL_007a:
	{
		G_B11_0 = 1;
	}

IL_007b:
	{
		V_9 = (bool)G_B11_0;
		bool L_21 = V_9;
		if (!L_21)
		{
			goto IL_00cc;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_22 = V_7;
		NullCheck(L_22);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_23;
		L_23 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_22, NULL);
		NullCheck(L_23);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_23, NULL);
		V_10 = L_24;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25 = V_10;
		float L_26 = L_25.___x_2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_27 = ___0_gridOrigin;
		float L_28 = L_27.___x_0;
		float L_29 = V_1;
		int32_t L_30;
		L_30 = Mathf_RoundToInt_m60F8B66CF27F1FA75AA219342BD184B75771EB4B_inline(((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_26, L_28)), L_29)), NULL);
		V_11 = L_30;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = V_10;
		float L_32 = L_31.___z_4;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_33 = ___0_gridOrigin;
		float L_34 = L_33.___y_1;
		float L_35 = V_2;
		int32_t L_36;
		L_36 = Mathf_RoundToInt_m60F8B66CF27F1FA75AA219342BD184B75771EB4B_inline(((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_32, L_34)), L_35)), NULL);
		V_12 = L_36;
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_37 = V_0;
		int32_t L_38 = V_11;
		int32_t L_39 = V_12;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_40 = V_7;
		NullCheck(L_37);
		bool L_41;
		L_41 = TerrainMap_TryToAddTerrain_m03A05C883F317FD2E6956ADD6625409E8A90BE15(L_37, L_38, L_39, L_40, NULL);
	}

IL_00cc:
	{
	}

IL_00cd:
	{
		int32_t L_42 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add(L_42, 1));
	}

IL_00d3:
	{
		int32_t L_43 = V_6;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_44 = V_5;
		NullCheck(L_44);
		if ((((int32_t)L_43) < ((int32_t)((int32_t)(((RuntimeArray*)L_44)->max_length)))))
		{
			goto IL_0050;
		}
	}
	{
		bool L_45 = ___3_fullValidation;
		V_13 = L_45;
		bool L_46 = V_13;
		if (!L_46)
		{
			goto IL_00ec;
		}
	}
	{
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_47 = V_0;
		NullCheck(L_47);
		int32_t L_48;
		L_48 = TerrainMap_Validate_mAFBB4A2D0290E25D59902A1BD5DA1EBC2ACD1326(L_47, NULL);
	}

IL_00ec:
	{
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_49 = V_0;
		NullCheck(L_49);
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_50 = L_49->___m_terrainTiles_2;
		NullCheck(L_50);
		int32_t L_51;
		L_51 = Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024(L_50, Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024_RuntimeMethod_var);
		if ((((int32_t)L_51) > ((int32_t)0)))
		{
			goto IL_00fd;
		}
	}
	{
		G_B21_0 = ((TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB*)(NULL));
		goto IL_00fe;
	}

IL_00fd:
	{
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_52 = V_0;
		G_B21_0 = L_52;
	}

IL_00fe:
	{
		V_4 = G_B21_0;
		goto IL_0102;
	}

IL_0102:
	{
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_53 = V_4;
		return L_53;
	}
}
// System.Collections.Generic.Dictionary`2<UnityEngine.TerrainUtils.TerrainTileCoord,UnityEngine.Terrain> UnityEngine.TerrainUtils.TerrainMap::get_terrainTiles()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* TerrainMap_get_terrainTiles_m9EAA8FCB972C834E2093DDD49B26DBBA2E74A2AB (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, const RuntimeMethod* method) 
{
	{
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_0 = __this->___m_terrainTiles_2;
		return L_0;
	}
}
// System.Void UnityEngine.TerrainUtils.TerrainMap::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainMap__ctor_mCDB47BA50D9D54E65754028F9CF8F91828FE616F (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_mCA22422F902B1FF70914D8FA2EF849DA0DCDC87D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		__this->___m_errorCode_1 = 0;
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_0 = (Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119*)il2cpp_codegen_object_new(Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Dictionary_2__ctor_mCA22422F902B1FF70914D8FA2EF849DA0DCDC87D(L_0, Dictionary_2__ctor_mCA22422F902B1FF70914D8FA2EF849DA0DCDC87D_RuntimeMethod_var);
		__this->___m_terrainTiles_2 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_terrainTiles_2), (void*)L_0);
		return;
	}
}
// System.Void UnityEngine.TerrainUtils.TerrainMap::AddTerrainInternal(System.Int32,System.Int32,UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainMap_AddTerrainInternal_m507CE3A3F880B33CA2330F69464E3511D5B9BD71 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_x, int32_t ___1_z, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___2_terrain, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_Add_m265E9FB46C80D234AEB47C08D701628D57DBA132_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	{
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_0 = __this->___m_terrainTiles_2;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024(L_0, Dictionary_2_get_Count_m876E3F2E32CD5DE6F869A52E21B755854D74C024_RuntimeMethod_var);
		V_0 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0026;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_3 = ___2_terrain;
		NullCheck(L_3);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_4;
		L_4 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_3, NULL);
		NullCheck(L_4);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		L_5 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_4, NULL);
		__this->___m_patchSize_0 = L_5;
		goto IL_0052;
	}

IL_0026:
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_6 = ___2_terrain;
		NullCheck(L_6);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_7;
		L_7 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_6, NULL);
		NullCheck(L_7);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_7, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = __this->___m_patchSize_0;
		bool L_10;
		L_10 = Vector3_op_Inequality_m9F170CDFBF1E490E559DA5D06D6547501A402BBF_inline(L_8, L_9, NULL);
		V_1 = L_10;
		bool L_11 = V_1;
		if (!L_11)
		{
			goto IL_0051;
		}
	}
	{
		int32_t L_12 = __this->___m_errorCode_1;
		__this->___m_errorCode_1 = ((int32_t)((int32_t)L_12|4));
	}

IL_0051:
	{
	}

IL_0052:
	{
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_13 = __this->___m_terrainTiles_2;
		int32_t L_14 = ___0_x;
		int32_t L_15 = ___1_z;
		TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_16;
		memset((&L_16), 0, sizeof(L_16));
		TerrainTileCoord__ctor_m6B6744655B9C3BA9B1A92076F07002B4B4EB899A((&L_16), L_14, L_15, /*hidden argument*/NULL);
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_17 = ___2_terrain;
		NullCheck(L_13);
		Dictionary_2_Add_m265E9FB46C80D234AEB47C08D701628D57DBA132(L_13, L_16, L_17, Dictionary_2_Add_m265E9FB46C80D234AEB47C08D701628D57DBA132_RuntimeMethod_var);
		return;
	}
}
// System.Boolean UnityEngine.TerrainUtils.TerrainMap::TryToAddTerrain(System.Int32,System.Int32,UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainMap_TryToAddTerrain_m03A05C883F317FD2E6956ADD6625409E8A90BE15 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_tileX, int32_t ___1_tileZ, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___2_terrain, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_2 = NULL;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	{
		V_0 = (bool)0;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_0 = ___2_terrain;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_1 = L_1;
		bool L_2 = V_1;
		if (!L_2)
		{
			goto IL_0053;
		}
	}
	{
		int32_t L_3 = ___0_tileX;
		int32_t L_4 = ___1_tileZ;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_5;
		L_5 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(__this, L_3, L_4, NULL);
		V_2 = L_5;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_6 = V_2;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_7;
		L_7 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_6, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_3 = L_7;
		bool L_8 = V_3;
		if (!L_8)
		{
			goto IL_0044;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_9 = V_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_10 = ___2_terrain;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_11;
		L_11 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_9, L_10, NULL);
		V_4 = L_11;
		bool L_12 = V_4;
		if (!L_12)
		{
			goto IL_0041;
		}
	}
	{
		int32_t L_13 = __this->___m_errorCode_1;
		__this->___m_errorCode_1 = ((int32_t)((int32_t)L_13|1));
	}

IL_0041:
	{
		goto IL_0052;
	}

IL_0044:
	{
		int32_t L_14 = ___0_tileX;
		int32_t L_15 = ___1_tileZ;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_16 = ___2_terrain;
		TerrainMap_AddTerrainInternal_m507CE3A3F880B33CA2330F69464E3511D5B9BD71(__this, L_14, L_15, L_16, NULL);
		V_0 = (bool)1;
	}

IL_0052:
	{
	}

IL_0053:
	{
		bool L_17 = V_0;
		V_5 = L_17;
		goto IL_0058;
	}

IL_0058:
	{
		bool L_18 = V_5;
		return L_18;
	}
}
// System.Void UnityEngine.TerrainUtils.TerrainMap::ValidateTerrain(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainMap_ValidateTerrain_m8D9B035B3851E0ED8BB5877BD11F63BA85029653 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, int32_t ___0_tileX, int32_t ___1_tileZ, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_0 = NULL;
	bool V_1 = false;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_2 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_3 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_4 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_5 = NULL;
	bool V_6 = false;
	bool V_7 = false;
	bool V_8 = false;
	bool V_9 = false;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B5_0 = 0;
	int32_t G_B12_0 = 0;
	int32_t G_B19_0 = 0;
	int32_t G_B26_0 = 0;
	{
		int32_t L_0 = ___0_tileX;
		int32_t L_1 = ___1_tileZ;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_2;
		L_2 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(__this, L_0, L_1, NULL);
		V_0 = L_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_3 = V_0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_3, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_1 = L_4;
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_026d;
		}
	}
	{
		int32_t L_6 = ___0_tileX;
		int32_t L_7 = ___1_tileZ;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_8;
		L_8 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(__this, ((int32_t)il2cpp_codegen_subtract(L_6, 1)), L_7, NULL);
		V_2 = L_8;
		int32_t L_9 = ___0_tileX;
		int32_t L_10 = ___1_tileZ;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_11;
		L_11 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(__this, ((int32_t)il2cpp_codegen_add(L_9, 1)), L_10, NULL);
		V_3 = L_11;
		int32_t L_12 = ___0_tileX;
		int32_t L_13 = ___1_tileZ;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_14;
		L_14 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(__this, L_12, ((int32_t)il2cpp_codegen_add(L_13, 1)), NULL);
		V_4 = L_14;
		int32_t L_15 = ___0_tileX;
		int32_t L_16 = ___1_tileZ;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_17;
		L_17 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(__this, L_15, ((int32_t)il2cpp_codegen_subtract(L_16, 1)), NULL);
		V_5 = L_17;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_18 = V_2;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_19;
		L_19 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_18, NULL);
		V_6 = L_19;
		bool L_20 = V_6;
		if (!L_20)
		{
			goto IL_00cf;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_21 = V_0;
		NullCheck(L_21);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_22;
		L_22 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_21, NULL);
		NullCheck(L_22);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_22, NULL);
		float L_24 = L_23.___x_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_25 = V_2;
		NullCheck(L_25);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_26;
		L_26 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_25, NULL);
		NullCheck(L_26);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27;
		L_27 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_26, NULL);
		float L_28 = L_27.___x_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_29 = V_2;
		NullCheck(L_29);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_30;
		L_30 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_29, NULL);
		NullCheck(L_30);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31;
		L_31 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_30, NULL);
		float L_32 = L_31.___x_2;
		bool L_33;
		L_33 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(L_24, ((float)il2cpp_codegen_add(L_28, L_32)), NULL);
		if (!L_33)
		{
			goto IL_00b7;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_34 = V_0;
		NullCheck(L_34);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_35;
		L_35 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_34, NULL);
		NullCheck(L_35);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36;
		L_36 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_35, NULL);
		float L_37 = L_36.___z_4;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_38 = V_2;
		NullCheck(L_38);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_39;
		L_39 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_38, NULL);
		NullCheck(L_39);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40;
		L_40 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_39, NULL);
		float L_41 = L_40.___z_4;
		bool L_42;
		L_42 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(L_37, L_41, NULL);
		G_B5_0 = ((((int32_t)L_42) == ((int32_t)0))? 1 : 0);
		goto IL_00b8;
	}

IL_00b7:
	{
		G_B5_0 = 1;
	}

IL_00b8:
	{
		V_7 = (bool)G_B5_0;
		bool L_43 = V_7;
		if (!L_43)
		{
			goto IL_00ce;
		}
	}
	{
		int32_t L_44 = __this->___m_errorCode_1;
		__this->___m_errorCode_1 = ((int32_t)((int32_t)L_44|8));
	}

IL_00ce:
	{
	}

IL_00cf:
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_45 = V_3;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_46;
		L_46 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_45, NULL);
		V_8 = L_46;
		bool L_47 = V_8;
		if (!L_47)
		{
			goto IL_0156;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_48 = V_0;
		NullCheck(L_48);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_49;
		L_49 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_48, NULL);
		NullCheck(L_49);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50;
		L_50 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_49, NULL);
		float L_51 = L_50.___x_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_52 = V_0;
		NullCheck(L_52);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_53;
		L_53 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_52, NULL);
		NullCheck(L_53);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_54;
		L_54 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_53, NULL);
		float L_55 = L_54.___x_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_56 = V_3;
		NullCheck(L_56);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_57;
		L_57 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_56, NULL);
		NullCheck(L_57);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_58;
		L_58 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_57, NULL);
		float L_59 = L_58.___x_2;
		bool L_60;
		L_60 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(((float)il2cpp_codegen_add(L_51, L_55)), L_59, NULL);
		if (!L_60)
		{
			goto IL_013e;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_61 = V_0;
		NullCheck(L_61);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_62;
		L_62 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_61, NULL);
		NullCheck(L_62);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_63;
		L_63 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_62, NULL);
		float L_64 = L_63.___z_4;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_65 = V_3;
		NullCheck(L_65);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_66;
		L_66 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_65, NULL);
		NullCheck(L_66);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_67;
		L_67 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_66, NULL);
		float L_68 = L_67.___z_4;
		bool L_69;
		L_69 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(L_64, L_68, NULL);
		G_B12_0 = ((((int32_t)L_69) == ((int32_t)0))? 1 : 0);
		goto IL_013f;
	}

IL_013e:
	{
		G_B12_0 = 1;
	}

IL_013f:
	{
		V_9 = (bool)G_B12_0;
		bool L_70 = V_9;
		if (!L_70)
		{
			goto IL_0155;
		}
	}
	{
		int32_t L_71 = __this->___m_errorCode_1;
		__this->___m_errorCode_1 = ((int32_t)((int32_t)L_71|8));
	}

IL_0155:
	{
	}

IL_0156:
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_72 = V_4;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_73;
		L_73 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_72, NULL);
		V_10 = L_73;
		bool L_74 = V_10;
		if (!L_74)
		{
			goto IL_01e0;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_75 = V_0;
		NullCheck(L_75);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_76;
		L_76 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_75, NULL);
		NullCheck(L_76);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_77;
		L_77 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_76, NULL);
		float L_78 = L_77.___x_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_79 = V_4;
		NullCheck(L_79);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_80;
		L_80 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_79, NULL);
		NullCheck(L_80);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_81;
		L_81 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_80, NULL);
		float L_82 = L_81.___x_2;
		bool L_83;
		L_83 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(L_78, L_82, NULL);
		if (!L_83)
		{
			goto IL_01c8;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_84 = V_0;
		NullCheck(L_84);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_85;
		L_85 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_84, NULL);
		NullCheck(L_85);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_86;
		L_86 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_85, NULL);
		float L_87 = L_86.___z_4;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_88 = V_0;
		NullCheck(L_88);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_89;
		L_89 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_88, NULL);
		NullCheck(L_89);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_90;
		L_90 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_89, NULL);
		float L_91 = L_90.___z_4;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_92 = V_4;
		NullCheck(L_92);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_93;
		L_93 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_92, NULL);
		NullCheck(L_93);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_94;
		L_94 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_93, NULL);
		float L_95 = L_94.___z_4;
		bool L_96;
		L_96 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(((float)il2cpp_codegen_add(L_87, L_91)), L_95, NULL);
		G_B19_0 = ((((int32_t)L_96) == ((int32_t)0))? 1 : 0);
		goto IL_01c9;
	}

IL_01c8:
	{
		G_B19_0 = 1;
	}

IL_01c9:
	{
		V_11 = (bool)G_B19_0;
		bool L_97 = V_11;
		if (!L_97)
		{
			goto IL_01df;
		}
	}
	{
		int32_t L_98 = __this->___m_errorCode_1;
		__this->___m_errorCode_1 = ((int32_t)((int32_t)L_98|8));
	}

IL_01df:
	{
	}

IL_01e0:
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_99 = V_5;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_100;
		L_100 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_99, NULL);
		V_12 = L_100;
		bool L_101 = V_12;
		if (!L_101)
		{
			goto IL_026b;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_102 = V_0;
		NullCheck(L_102);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_103;
		L_103 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_102, NULL);
		NullCheck(L_103);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_104;
		L_104 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_103, NULL);
		float L_105 = L_104.___x_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_106 = V_5;
		NullCheck(L_106);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_107;
		L_107 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_106, NULL);
		NullCheck(L_107);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_108;
		L_108 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_107, NULL);
		float L_109 = L_108.___x_2;
		bool L_110;
		L_110 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(L_105, L_109, NULL);
		if (!L_110)
		{
			goto IL_0253;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_111 = V_0;
		NullCheck(L_111);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_112;
		L_112 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_111, NULL);
		NullCheck(L_112);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_113;
		L_113 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_112, NULL);
		float L_114 = L_113.___z_4;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_115 = V_5;
		NullCheck(L_115);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_116;
		L_116 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_115, NULL);
		NullCheck(L_116);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_117;
		L_117 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_116, NULL);
		float L_118 = L_117.___z_4;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_119 = V_5;
		NullCheck(L_119);
		TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* L_120;
		L_120 = Terrain_get_terrainData_m3B6C1D89471A4E1C60FC19C168DB37A011B924FD(L_119, NULL);
		NullCheck(L_120);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_121;
		L_121 = TerrainData_get_size_mCD3977F344B9DEBFF61DD537D03FEB9473838DA5(L_120, NULL);
		float L_122 = L_121.___z_4;
		bool L_123;
		L_123 = Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline(L_114, ((float)il2cpp_codegen_add(L_118, L_122)), NULL);
		G_B26_0 = ((((int32_t)L_123) == ((int32_t)0))? 1 : 0);
		goto IL_0254;
	}

IL_0253:
	{
		G_B26_0 = 1;
	}

IL_0254:
	{
		V_13 = (bool)G_B26_0;
		bool L_124 = V_13;
		if (!L_124)
		{
			goto IL_026a;
		}
	}
	{
		int32_t L_125 = __this->___m_errorCode_1;
		__this->___m_errorCode_1 = ((int32_t)((int32_t)L_125|8));
	}

IL_026a:
	{
	}

IL_026b:
	{
	}

IL_026d:
	{
		return;
	}
}
// UnityEngine.TerrainUtils.TerrainMapStatusCode UnityEngine.TerrainUtils.TerrainMap::Validate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TerrainMap_Validate_mAFBB4A2D0290E25D59902A1BD5DA1EBC2ACD1326 (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_get_Keys_mBE9BF06497225D54AC2D2D7AEF6D0F94169B10D4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_mC60AECD5D4FA770371F4B374F2B026F7198CEF03_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m6430F89661ED2AEDEAD6FD241BBDA21BF02135DC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m88A7ECB72C871AEFAD87667D8512A109C33E7080_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyCollection_GetEnumerator_m7D86741C1BEF055A22281CF69C6235BFD1E7D521_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689 V_0;
	memset((&V_0), 0, sizeof(V_0));
	TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	{
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_0 = __this->___m_terrainTiles_2;
		NullCheck(L_0);
		KeyCollection_tE33A2EB76F7F1DBF4EF03A4D82E8E0A13B74637E* L_1;
		L_1 = Dictionary_2_get_Keys_mBE9BF06497225D54AC2D2D7AEF6D0F94169B10D4(L_0, Dictionary_2_get_Keys_mBE9BF06497225D54AC2D2D7AEF6D0F94169B10D4_RuntimeMethod_var);
		NullCheck(L_1);
		Enumerator_t608060746142FE814AB6D19ACFCB6AF049D89689 L_2;
		L_2 = KeyCollection_GetEnumerator_m7D86741C1BEF055A22281CF69C6235BFD1E7D521(L_1, KeyCollection_GetEnumerator_m7D86741C1BEF055A22281CF69C6235BFD1E7D521_RuntimeMethod_var);
		V_0 = L_2;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_003d:
			{// begin finally (depth: 1)
				Enumerator_Dispose_mC60AECD5D4FA770371F4B374F2B026F7198CEF03((&V_0), Enumerator_Dispose_mC60AECD5D4FA770371F4B374F2B026F7198CEF03_RuntimeMethod_var);
				return;
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				goto IL_0032_1;
			}

IL_0015_1:
			{
				TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_3;
				L_3 = Enumerator_get_Current_m88A7ECB72C871AEFAD87667D8512A109C33E7080_inline((&V_0), Enumerator_get_Current_m88A7ECB72C871AEFAD87667D8512A109C33E7080_RuntimeMethod_var);
				V_1 = L_3;
				TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_4 = V_1;
				int32_t L_5 = L_4.___tileX_0;
				TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_6 = V_1;
				int32_t L_7 = L_6.___tileZ_1;
				TerrainMap_ValidateTerrain_m8D9B035B3851E0ED8BB5877BD11F63BA85029653(__this, L_5, L_7, NULL);
			}

IL_0032_1:
			{
				bool L_8;
				L_8 = Enumerator_MoveNext_m6430F89661ED2AEDEAD6FD241BBDA21BF02135DC((&V_0), Enumerator_MoveNext_m6430F89661ED2AEDEAD6FD241BBDA21BF02135DC_RuntimeMethod_var);
				if (L_8)
				{
					goto IL_0015_1;
				}
			}
			{
				goto IL_004c;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_004c:
	{
		int32_t L_9 = __this->___m_errorCode_1;
		V_2 = L_9;
		goto IL_0055;
	}

IL_0055:
	{
		int32_t L_10 = V_2;
		return L_10;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass3_0__ctor_mAFD4AEF760F5CC7CE66BAD750DAD3697397E8945 (U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.Boolean UnityEngine.TerrainUtils.TerrainMap/<>c__DisplayClass3_0::<CreateFromPlacement>b__0(UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CU3Ec__DisplayClass3_0_U3CCreateFromPlacementU3Eb__0_m703A4D4E3D378C9896199B70A89FCDF1A07C737B (U3CU3Ec__DisplayClass3_0_t5A3BA129A3DFF96B5C0658B95E1ED4A678218CC3* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_x, const RuntimeMethod* method) 
{
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_0 = ___0_x;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24(L_0, NULL);
		int32_t L_2 = __this->___groupID_0;
		return (bool)((((int32_t)L_1) == ((int32_t)L_2))? 1 : 0);
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean UnityEngine.TerrainUtils.TerrainUtility::ValidTerrainsExist()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainUtility_ValidTerrainsExist_m0DD08E4CEC739929A9AEBCEA849EDFE79985A207 (const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_0;
		L_0 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_1;
		L_1 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		NullCheck(L_1);
		G_B3_0 = ((!(((uint32_t)(((RuntimeArray*)L_1)->max_length)) <= ((uint32_t)0)))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 0;
	}

IL_0014:
	{
		V_0 = (bool)G_B3_0;
		goto IL_0017;
	}

IL_0017:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
// System.Void UnityEngine.TerrainUtils.TerrainUtility::ClearConnectivity()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainUtility_ClearConnectivity_m7448E42CD3F2941EF02C10DE358778EEAF9B0AA9 (const RuntimeMethod* method) 
{
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* V_0 = NULL;
	int32_t V_1 = 0;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_2 = NULL;
	bool V_3 = false;
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_0;
		L_0 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		V_0 = L_0;
		V_1 = 0;
		goto IL_002b;
	}

IL_000c:
	{
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_1 = V_0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		int32_t L_3 = L_2;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_4 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
		V_2 = L_4;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_5 = V_2;
		NullCheck(L_5);
		bool L_6;
		L_6 = Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7(L_5, NULL);
		V_3 = L_6;
		bool L_7 = V_3;
		if (!L_7)
		{
			goto IL_0026;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_8 = V_2;
		NullCheck(L_8);
		Terrain_SetNeighbors_m2FFA89D199120125D264EF7EE0BC749A35514C1E(L_8, (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*)NULL, (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*)NULL, (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*)NULL, (Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*)NULL, NULL);
	}

IL_0026:
	{
		int32_t L_9 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_9, 1));
	}

IL_002b:
	{
		int32_t L_10 = V_1;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_11 = V_0;
		NullCheck(L_11);
		if ((((int32_t)L_10) < ((int32_t)((int32_t)(((RuntimeArray*)L_11)->max_length)))))
		{
			goto IL_000c;
		}
	}
	{
		return;
	}
}
// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.TerrainUtils.TerrainMap> UnityEngine.TerrainUtils.TerrainUtility::CollectTerrains(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* TerrainUtility_CollectTerrains_mDFCA0AFA00FFD16CEC8B4EFA9C55E3B7B6803EC4 (bool ___0_onlyAutoConnectedTerrains, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_Add_m4E7AE6465929CEEA79B5921CFF3D4BD64E249AF9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_ContainsKey_m384365266E590EDD82F8949169A3C502E643AC95_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m5665AD243B285B8D26138C699D544F4124AC7D78_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_get_Count_m001233C3B4F8B3D1A8F044C9D43104F1671688DC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass2_1_U3CCollectTerrainsU3Eb__0_m57E871EB2399E5FB7DF78B3C9EBFBF152116AC2C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* V_0 = NULL;
	Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* V_1 = NULL;
	bool V_2 = false;
	Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* V_3 = NULL;
	TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* V_4 = NULL;
	int32_t V_5 = 0;
	U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* V_6 = NULL;
	bool V_7 = false;
	bool V_8 = false;
	TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* V_9 = NULL;
	bool V_10 = false;
	int32_t G_B6_0 = 0;
	Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* G_B18_0 = NULL;
	{
		U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* L_0 = (U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E*)il2cpp_codegen_object_new(U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CU3Ec__DisplayClass2_0__ctor_m4C022C4675BA4CFC7E7AAA5692979CDE6CD8E611(L_0, NULL);
		V_0 = L_0;
		U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* L_1 = V_0;
		bool L_2 = ___0_onlyAutoConnectedTerrains;
		NullCheck(L_1);
		L_1->___onlyAutoConnectedTerrains_0 = L_2;
		bool L_3;
		L_3 = TerrainUtility_ValidTerrainsExist_m0DD08E4CEC739929A9AEBCEA849EDFE79985A207(NULL);
		V_2 = (bool)((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0021;
		}
	}
	{
		V_3 = (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*)NULL;
		goto IL_00f5;
	}

IL_0021:
	{
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_5 = (Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*)il2cpp_codegen_object_new(Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		Dictionary_2__ctor_m5665AD243B285B8D26138C699D544F4124AC7D78(L_5, Dictionary_2__ctor_m5665AD243B285B8D26138C699D544F4124AC7D78_RuntimeMethod_var);
		V_1 = L_5;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_6;
		L_6 = Terrain_get_activeTerrains_mB90A9BC89764F626D13F3EF1420EA8D3E186B701(NULL);
		V_4 = L_6;
		V_5 = 0;
		goto IL_00db;
	}

IL_0037:
	{
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_7 = (U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951*)il2cpp_codegen_object_new(U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951_il2cpp_TypeInfo_var);
		NullCheck(L_7);
		U3CU3Ec__DisplayClass2_1__ctor_mA329ED5B221AE8787EAEA1124A2A95675FDD1695(L_7, NULL);
		V_6 = L_7;
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_8 = V_6;
		U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* L_9 = V_0;
		NullCheck(L_8);
		L_8->___CSU24U3CU3E8__locals1_1 = L_9;
		Il2CppCodeGenWriteBarrier((void**)(&L_8->___CSU24U3CU3E8__locals1_1), (void*)L_9);
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_10 = V_6;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_11 = V_4;
		int32_t L_12 = V_5;
		NullCheck(L_11);
		int32_t L_13 = L_12;
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_14 = (L_11)->GetAt(static_cast<il2cpp_array_size_t>(L_13));
		NullCheck(L_10);
		L_10->___t_0 = L_14;
		Il2CppCodeGenWriteBarrier((void**)(&L_10->___t_0), (void*)L_14);
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_15 = V_6;
		NullCheck(L_15);
		U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* L_16 = L_15->___CSU24U3CU3E8__locals1_1;
		NullCheck(L_16);
		bool L_17 = L_16->___onlyAutoConnectedTerrains_0;
		if (!L_17)
		{
			goto IL_0072;
		}
	}
	{
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_18 = V_6;
		NullCheck(L_18);
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_19 = L_18->___t_0;
		NullCheck(L_19);
		bool L_20;
		L_20 = Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7(L_19, NULL);
		G_B6_0 = ((((int32_t)L_20) == ((int32_t)0))? 1 : 0);
		goto IL_0073;
	}

IL_0072:
	{
		G_B6_0 = 0;
	}

IL_0073:
	{
		V_7 = (bool)G_B6_0;
		bool L_21 = V_7;
		if (!L_21)
		{
			goto IL_007b;
		}
	}
	{
		goto IL_00d5;
	}

IL_007b:
	{
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_22 = V_1;
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_23 = V_6;
		NullCheck(L_23);
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_24 = L_23->___t_0;
		NullCheck(L_24);
		int32_t L_25;
		L_25 = Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24(L_24, NULL);
		NullCheck(L_22);
		bool L_26;
		L_26 = Dictionary_2_ContainsKey_m384365266E590EDD82F8949169A3C502E643AC95(L_22, L_25, Dictionary_2_ContainsKey_m384365266E590EDD82F8949169A3C502E643AC95_RuntimeMethod_var);
		V_8 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_8;
		if (!L_27)
		{
			goto IL_00d4;
		}
	}
	{
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_28 = V_6;
		NullCheck(L_28);
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_29 = L_28->___t_0;
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_30 = V_6;
		Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055* L_31 = (Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055*)il2cpp_codegen_object_new(Predicate_1_tF9C1F3093AD3E74A0F6BE3895143021CAFB64055_il2cpp_TypeInfo_var);
		NullCheck(L_31);
		Predicate_1__ctor_m80A5EFAAAC439A069D5782C725DF325FDD5D891C(L_31, L_30, (intptr_t)((void*)U3CU3Ec__DisplayClass2_1_U3CCollectTerrainsU3Eb__0_m57E871EB2399E5FB7DF78B3C9EBFBF152116AC2C_RuntimeMethod_var), NULL);
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_32;
		L_32 = TerrainMap_CreateFromPlacement_mC7822A5F4FC2A2CB119259A48F19D364ACEC5AE7(L_29, L_31, (bool)1, NULL);
		V_9 = L_32;
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_33 = V_9;
		V_10 = (bool)((!(((RuntimeObject*)(TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB*)L_33) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_34 = V_10;
		if (!L_34)
		{
			goto IL_00d3;
		}
	}
	{
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_35 = V_1;
		U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* L_36 = V_6;
		NullCheck(L_36);
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_37 = L_36->___t_0;
		NullCheck(L_37);
		int32_t L_38;
		L_38 = Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24(L_37, NULL);
		TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_39 = V_9;
		NullCheck(L_35);
		Dictionary_2_Add_m4E7AE6465929CEEA79B5921CFF3D4BD64E249AF9(L_35, L_38, L_39, Dictionary_2_Add_m4E7AE6465929CEEA79B5921CFF3D4BD64E249AF9_RuntimeMethod_var);
	}

IL_00d3:
	{
	}

IL_00d4:
	{
	}

IL_00d5:
	{
		int32_t L_40 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_40, 1));
	}

IL_00db:
	{
		int32_t L_41 = V_5;
		TerrainU5BU5D_t89E2F0565563C3D9005990300ADEDD183F1823FE* L_42 = V_4;
		NullCheck(L_42);
		if ((((int32_t)L_41) < ((int32_t)((int32_t)(((RuntimeArray*)L_42)->max_length)))))
		{
			goto IL_0037;
		}
	}
	{
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_43 = V_1;
		NullCheck(L_43);
		int32_t L_44;
		L_44 = Dictionary_2_get_Count_m001233C3B4F8B3D1A8F044C9D43104F1671688DC(L_43, Dictionary_2_get_Count_m001233C3B4F8B3D1A8F044C9D43104F1671688DC_RuntimeMethod_var);
		if (L_44)
		{
			goto IL_00f1;
		}
	}
	{
		G_B18_0 = ((Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*)(NULL));
		goto IL_00f2;
	}

IL_00f1:
	{
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_45 = V_1;
		G_B18_0 = L_45;
	}

IL_00f2:
	{
		V_3 = G_B18_0;
		goto IL_00f5;
	}

IL_00f5:
	{
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_46 = V_3;
		return L_46;
	}
}
// System.Void UnityEngine.TerrainUtils.TerrainUtility::AutoConnect()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainUtility_AutoConnect_m3E435D139BE402DC495248EDD1FF2C1E9377A897 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_GetEnumerator_m50800AFD24DEE5F8ACB58E1535F2A472B478E473_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_GetEnumerator_m5461BE3EE48320EA8E593506F16860A2CB4E9056_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m09F8467FB404D375259C17136F2213FC8455F2BF_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_mDDABE6027BD9E377D6E3FC7F60CE5DDB0ADC47D7_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m1BA7CBA94F8FC389211722A43E22BB110102ABB4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_m1CEA4A6A000E5344DB72DFF5E4FF563FF67F3558_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m1F085EA2ABB67CCEB29CC4A10D6FBC0F2B963349_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_mCD48A37B44C4A6E441AF6806E0821A24A22A51F3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyValuePair_2_get_Key_mFE7731B1C41692F16EB45AC2D63092AC73156A8A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyValuePair_2_get_Value_m32D4949D8D2F580E35346D41EBB14C7933B93482_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* V_0 = NULL;
	bool V_1 = false;
	bool V_2 = false;
	Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F V_3;
	memset((&V_3), 0, sizeof(V_3));
	KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873 V_4;
	memset((&V_4), 0, sizeof(V_4));
	TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* V_5 = NULL;
	Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B V_6;
	memset((&V_6), 0, sizeof(V_6));
	KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3 V_7;
	memset((&V_7), 0, sizeof(V_7));
	TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 V_8;
	memset((&V_8), 0, sizeof(V_8));
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_9 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_10 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_11 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_12 = NULL;
	Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* V_13 = NULL;
	{
		bool L_0;
		L_0 = TerrainUtility_ValidTerrainsExist_m0DD08E4CEC739929A9AEBCEA849EDFE79985A207(NULL);
		V_1 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_0012;
		}
	}
	{
		goto IL_013a;
	}

IL_0012:
	{
		TerrainUtility_ClearConnectivity_m7448E42CD3F2941EF02C10DE358778EEAF9B0AA9(NULL);
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_2;
		L_2 = TerrainUtility_CollectTerrains_mDFCA0AFA00FFD16CEC8B4EFA9C55E3B7B6803EC4((bool)1, NULL);
		V_0 = L_2;
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_3 = V_0;
		V_2 = (bool)((((RuntimeObject*)(Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C*)L_3) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_002c;
		}
	}
	{
		goto IL_013a;
	}

IL_002c:
	{
		Dictionary_2_t2A7962936E35A63A01CBCE08C2732E037C7FCF4C* L_5 = V_0;
		NullCheck(L_5);
		Enumerator_tB3EC2B6C57FCD9C7E78B708686BCBF5852E2AA3F L_6;
		L_6 = Dictionary_2_GetEnumerator_m5461BE3EE48320EA8E593506F16860A2CB4E9056(L_5, Dictionary_2_GetEnumerator_m5461BE3EE48320EA8E593506F16860A2CB4E9056_RuntimeMethod_var);
		V_3 = L_6;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_012b:
			{// begin finally (depth: 1)
				Enumerator_Dispose_m09F8467FB404D375259C17136F2213FC8455F2BF((&V_3), Enumerator_Dispose_m09F8467FB404D375259C17136F2213FC8455F2BF_RuntimeMethod_var);
				return;
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				goto IL_011d_1;
			}

IL_0039_1:
			{
				KeyValuePair_2_t5106DD80E20DAA18F0718F331B82E30C0F196873 L_7;
				L_7 = Enumerator_get_Current_m1F085EA2ABB67CCEB29CC4A10D6FBC0F2B963349_inline((&V_3), Enumerator_get_Current_m1F085EA2ABB67CCEB29CC4A10D6FBC0F2B963349_RuntimeMethod_var);
				V_4 = L_7;
				TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_8;
				L_8 = KeyValuePair_2_get_Value_m32D4949D8D2F580E35346D41EBB14C7933B93482_inline((&V_4), KeyValuePair_2_get_Value_m32D4949D8D2F580E35346D41EBB14C7933B93482_RuntimeMethod_var);
				V_5 = L_8;
				TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_9 = V_5;
				NullCheck(L_9);
				Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_10;
				L_10 = TerrainMap_get_terrainTiles_m9EAA8FCB972C834E2093DDD49B26DBBA2E74A2AB_inline(L_9, NULL);
				NullCheck(L_10);
				Enumerator_t4B54697825D0059AED7437C1585FDF185FF80B5B L_11;
				L_11 = Dictionary_2_GetEnumerator_m50800AFD24DEE5F8ACB58E1535F2A472B478E473(L_10, Dictionary_2_GetEnumerator_m50800AFD24DEE5F8ACB58E1535F2A472B478E473_RuntimeMethod_var);
				V_6 = L_11;
			}
			{
				auto __finallyBlock = il2cpp::utils::Finally([&]
				{

FINALLY_010d_1:
					{// begin finally (depth: 2)
						Enumerator_Dispose_mDDABE6027BD9E377D6E3FC7F60CE5DDB0ADC47D7((&V_6), Enumerator_Dispose_mDDABE6027BD9E377D6E3FC7F60CE5DDB0ADC47D7_RuntimeMethod_var);
						return;
					}// end finally (depth: 2)
				});
				try
				{// begin try (depth: 2)
					{
						goto IL_00ff_2;
					}

IL_0060_2:
					{
						KeyValuePair_2_t69A51C36FF679E64375AD7C88BC0B6EC664E71E3 L_12;
						L_12 = Enumerator_get_Current_mCD48A37B44C4A6E441AF6806E0821A24A22A51F3_inline((&V_6), Enumerator_get_Current_mCD48A37B44C4A6E441AF6806E0821A24A22A51F3_RuntimeMethod_var);
						V_7 = L_12;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_13;
						L_13 = KeyValuePair_2_get_Key_mFE7731B1C41692F16EB45AC2D63092AC73156A8A_inline((&V_7), KeyValuePair_2_get_Key_mFE7731B1C41692F16EB45AC2D63092AC73156A8A_RuntimeMethod_var);
						V_8 = L_13;
						TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_14 = V_5;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_15 = V_8;
						int32_t L_16 = L_15.___tileX_0;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_17 = V_8;
						int32_t L_18 = L_17.___tileZ_1;
						NullCheck(L_14);
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_19;
						L_19 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(L_14, L_16, L_18, NULL);
						V_9 = L_19;
						TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_20 = V_5;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_21 = V_8;
						int32_t L_22 = L_21.___tileX_0;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_23 = V_8;
						int32_t L_24 = L_23.___tileZ_1;
						NullCheck(L_20);
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_25;
						L_25 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(L_20, ((int32_t)il2cpp_codegen_subtract(L_22, 1)), L_24, NULL);
						V_10 = L_25;
						TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_26 = V_5;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_27 = V_8;
						int32_t L_28 = L_27.___tileX_0;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_29 = V_8;
						int32_t L_30 = L_29.___tileZ_1;
						NullCheck(L_26);
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_31;
						L_31 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(L_26, ((int32_t)il2cpp_codegen_add(L_28, 1)), L_30, NULL);
						V_11 = L_31;
						TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_32 = V_5;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_33 = V_8;
						int32_t L_34 = L_33.___tileX_0;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_35 = V_8;
						int32_t L_36 = L_35.___tileZ_1;
						NullCheck(L_32);
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_37;
						L_37 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(L_32, L_34, ((int32_t)il2cpp_codegen_add(L_36, 1)), NULL);
						V_12 = L_37;
						TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* L_38 = V_5;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_39 = V_8;
						int32_t L_40 = L_39.___tileX_0;
						TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_41 = V_8;
						int32_t L_42 = L_41.___tileZ_1;
						NullCheck(L_38);
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_43;
						L_43 = TerrainMap_GetTerrain_mFF9C935F05859DF70E95994E727565BD67CDD6FC(L_38, L_40, ((int32_t)il2cpp_codegen_subtract(L_42, 1)), NULL);
						V_13 = L_43;
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_44 = V_9;
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_45 = V_10;
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_46 = V_12;
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_47 = V_11;
						Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_48 = V_13;
						NullCheck(L_44);
						Terrain_SetNeighbors_m2FFA89D199120125D264EF7EE0BC749A35514C1E(L_44, L_45, L_46, L_47, L_48, NULL);
					}

IL_00ff_2:
					{
						bool L_49;
						L_49 = Enumerator_MoveNext_m1BA7CBA94F8FC389211722A43E22BB110102ABB4((&V_6), Enumerator_MoveNext_m1BA7CBA94F8FC389211722A43E22BB110102ABB4_RuntimeMethod_var);
						if (L_49)
						{
							goto IL_0060_2;
						}
					}
					{
						goto IL_011c_1;
					}
				}// end try (depth: 2)
				catch(Il2CppExceptionWrapper& e)
				{
					__finallyBlock.StoreException(e.ex);
				}
			}

IL_011c_1:
			{
			}

IL_011d_1:
			{
				bool L_50;
				L_50 = Enumerator_MoveNext_m1CEA4A6A000E5344DB72DFF5E4FF563FF67F3558((&V_3), Enumerator_MoveNext_m1CEA4A6A000E5344DB72DFF5E4FF563FF67F3558_RuntimeMethod_var);
				if (L_50)
				{
					goto IL_0039_1;
				}
			}
			{
				goto IL_013a;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_013a:
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass2_0__ctor_m4C022C4675BA4CFC7E7AAA5692979CDE6CD8E611 (U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass2_1__ctor_mA329ED5B221AE8787EAEA1124A2A95675FDD1695 (U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.Boolean UnityEngine.TerrainUtils.TerrainUtility/<>c__DisplayClass2_1::<CollectTerrains>b__0(UnityEngine.Terrain)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CU3Ec__DisplayClass2_1_U3CCollectTerrainsU3Eb__0_m57E871EB2399E5FB7DF78B3C9EBFBF152116AC2C (U3CU3Ec__DisplayClass2_1_t550F5BA64A779BA6B1FDFAC1457F462892D2A951* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_x, const RuntimeMethod* method) 
{
	int32_t G_B4_0 = 0;
	int32_t G_B6_0 = 0;
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_0 = ___0_x;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24(L_0, NULL);
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_2 = __this->___t_0;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = Terrain_get_groupingID_mE52E78018126A5D00F837081287BE076E7709C24(L_2, NULL);
		if ((!(((uint32_t)L_1) == ((uint32_t)L_3))))
		{
			goto IL_002b;
		}
	}
	{
		U3CU3Ec__DisplayClass2_0_t0E9CE80E29A8238529BFBB9FCD0C8D0AAD68A57E* L_4 = __this->___CSU24U3CU3E8__locals1_1;
		NullCheck(L_4);
		bool L_5 = L_4->___onlyAutoConnectedTerrains_0;
		if (!L_5)
		{
			goto IL_0028;
		}
	}
	{
		Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* L_6 = ___0_x;
		NullCheck(L_6);
		bool L_7;
		L_7 = Terrain_get_allowAutoConnect_m4E9CB87D130BB118517C5504C8FB4A5CC3AA91D7(L_6, NULL);
		G_B4_0 = ((int32_t)(L_7));
		goto IL_0029;
	}

IL_0028:
	{
		G_B4_0 = 1;
	}

IL_0029:
	{
		G_B6_0 = G_B4_0;
		goto IL_002c;
	}

IL_002b:
	{
		G_B6_0 = 0;
	}

IL_002c:
	{
		return (bool)G_B6_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Color_op_Equality_mB2BDC39B0B367BA15AA8DF22F8CB0D02D20BDC71_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___0_lhs, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___1_rhs, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = ___0_lhs;
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_1;
		L_1 = Color_op_Implicit_m9B3228DAFA8DC57A75DE00CBBF13ED4F1E7B01FF_inline(L_0, NULL);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_2 = ___1_rhs;
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_3;
		L_3 = Color_op_Implicit_m9B3228DAFA8DC57A75DE00CBBF13ED4F1E7B01FF_inline(L_2, NULL);
		bool L_4;
		L_4 = Vector4_op_Equality_mCEA0E5F229F4AE8C55152F7A8F84345F24F52DC6_inline(L_1, L_3, NULL);
		V_0 = L_4;
		goto IL_0015;
	}

IL_0015:
	{
		bool L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___0_r, float ___1_g, float ___2_b, float ___3_a, const RuntimeMethod* method) 
{
	{
		float L_0 = ___0_r;
		__this->___r_0 = L_0;
		float L_1 = ___1_g;
		__this->___g_1 = L_1;
		float L_2 = ___2_b;
		__this->___b_2 = L_2;
		float L_3 = ___3_a;
		__this->___a_3 = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Color_get_gray_m6D01087E0F20F34718EBA5B213853B4BB49F1DEF_inline (const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0;
		memset((&L_0), 0, sizeof(L_0));
		Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline((&L_0), (0.5f), (0.5f), (0.5f), (1.0f), /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_001d;
	}

IL_001d:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void HeightmapChangedCallback_Invoke_m63C1C93709641DBE02DCE9F71B7895C5793AF875_inline (HeightmapChangedCallback_tDF97623B4D5F5E1F3F7F75CC922345B098036EC0* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___1_heightRegion, bool ___2_synched, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___0_terrain, ___1_heightRegion, ___2_synched, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TextureChangedCallback_Invoke_m1194A44102843272B51A70C302EBDBC8214647DE_inline (TextureChangedCallback_tA2D79601BF5AFEC6C8674AA03DAD28844CE69D2F* __this, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667* ___0_terrain, String_t* ___1_textureName, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___2_texelRegion, bool ___3_synched, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, Terrain_t7F309492F67238DBFBC4566F47385B2A665CF667*, String_t*, RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___0_terrain, ___1_textureName, ___2_texelRegion, ___3_synched, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___0_x, float ___1_y, const RuntimeMethod* method) 
{
	{
		float L_0 = ___0_x;
		__this->___x_0 = L_0;
		float L_1 = ___1_y;
		__this->___y_1 = L_1;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Mathf_RoundToInt_m60F8B66CF27F1FA75AA219342BD184B75771EB4B_inline (float ___0_f, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		float L_0 = ___0_f;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_1;
		L_1 = bankers_round(((double)L_0));
		V_0 = il2cpp_codegen_cast_double_to_int<int32_t>(L_1);
		goto IL_000c;
	}

IL_000c:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Inequality_m9F170CDFBF1E490E559DA5D06D6547501A402BBF_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___0_lhs, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___1_rhs, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___0_lhs;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___1_rhs;
		bool L_2;
		L_2 = Vector3_op_Equality_mCDCBB8D2EDC3D3BF20F31A25ACB34705D352B479_inline(L_0, L_1, NULL);
		V_0 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		goto IL_000e;
	}

IL_000e:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Mathf_Approximately_m1DADD012A8FC82E11FB282501AE2EBBF9A77150B_inline (float ___0_a, float ___1_b, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		float L_0 = ___1_b;
		float L_1 = ___0_a;
		float L_2;
		L_2 = fabsf(((float)il2cpp_codegen_subtract(L_0, L_1)));
		float L_3 = ___0_a;
		float L_4;
		L_4 = fabsf(L_3);
		float L_5 = ___1_b;
		float L_6;
		L_6 = fabsf(L_5);
		float L_7;
		L_7 = Mathf_Max_mF5379E63D2BBAC76D090748695D833934F8AD051_inline(L_4, L_6, NULL);
		float L_8 = ((Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_StaticFields*)il2cpp_codegen_static_fields_for(Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var))->___Epsilon_5;
		float L_9;
		L_9 = Mathf_Max_mF5379E63D2BBAC76D090748695D833934F8AD051_inline(((float)il2cpp_codegen_multiply((9.99999997E-07f), L_7)), ((float)il2cpp_codegen_multiply(L_8, (8.0f))), NULL);
		V_0 = (bool)((((float)L_2) < ((float)L_9))? 1 : 0);
		goto IL_0035;
	}

IL_0035:
	{
		bool L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* TerrainMap_get_terrainTiles_m9EAA8FCB972C834E2093DDD49B26DBBA2E74A2AB_inline (TerrainMap_t6E07590E3151F47FFC6D5536635AC428ABDA79EB* __this, const RuntimeMethod* method) 
{
	{
		Dictionary_2_t5C5FBA59FA0804C53874B619629A7AF7EA74A119* L_0 = __this->___m_terrainTiles_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Predicate_1_Invoke_m6AC449189DCEE89A4FA2A2B724DE296A1DFB6A9B_gshared_inline (Predicate_1_t8342C85FF4E41CD1F7024AC0CDC3E5312A32CB12* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	typedef bool (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___0_obj, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 Enumerator_get_Current_mC41EF0278150018906F2AB9D7CF81AE865E6AA1C_gshared_inline (Enumerator_tF5348A6D692C0422DAF82BC55E5276A4D29BEF53* __this, const RuntimeMethod* method) 
{
	{
		TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_0 = __this->____currentKey_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR KeyValuePair_2_tDC26B09C26BA829DDE331BCB6AF7C508C763D7A3 Enumerator_get_Current_m90160D324DA0D9F5624A345F47D8E226A118911A_gshared_inline (Enumerator_tE92C1AC40A104A179B94F8A013728FD9314CFBD3* __this, const RuntimeMethod* method) 
{
	{
		KeyValuePair_2_tDC26B09C26BA829DDE331BCB6AF7C508C763D7A3 L_0 = __this->____current_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* KeyValuePair_2_get_Value_m8508BCECB0654E2E93B1A141382E2688ADE7EE7C_gshared_inline (KeyValuePair_2_tDC26B09C26BA829DDE331BCB6AF7C508C763D7A3* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___value_1;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR KeyValuePair_2_t8760984FFCA6E11154C918347EA4C7CFB2D0B8CE Enumerator_get_Current_mAB48908F9E456DE35489D40F781F13159CD102CA_gshared_inline (Enumerator_tB06F293668D09F345A54C8C836ABF567B9087FB7* __this, const RuntimeMethod* method) 
{
	{
		KeyValuePair_2_t8760984FFCA6E11154C918347EA4C7CFB2D0B8CE L_0 = __this->____current_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 KeyValuePair_2_get_Key_mE27FF2218D103DBF58A36186AA62595EC4079388_gshared_inline (KeyValuePair_2_t8760984FFCA6E11154C918347EA4C7CFB2D0B8CE* __this, const RuntimeMethod* method) 
{
	{
		TerrainTileCoord_t2181DDF40A8A428A84817957CB7FB19A314F4F09 L_0 = __this->___key_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 Color_op_Implicit_m9B3228DAFA8DC57A75DE00CBBF13ED4F1E7B01FF_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___0_c, const RuntimeMethod* method) 
{
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = ___0_c;
		float L_1 = L_0.___r_0;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_2 = ___0_c;
		float L_3 = L_2.___g_1;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_4 = ___0_c;
		float L_5 = L_4.___b_2;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_6 = ___0_c;
		float L_7 = L_6.___a_3;
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_8;
		memset((&L_8), 0, sizeof(L_8));
		Vector4__ctor_m96B2CD8B862B271F513AF0BDC2EABD58E4DBC813_inline((&L_8), L_1, L_3, L_5, L_7, /*hidden argument*/NULL);
		V_0 = L_8;
		goto IL_0021;
	}

IL_0021:
	{
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_9 = V_0;
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector4_op_Equality_mCEA0E5F229F4AE8C55152F7A8F84345F24F52DC6_inline (Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___0_lhs, Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___1_rhs, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	float V_4 = 0.0f;
	bool V_5 = false;
	{
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_0 = ___0_lhs;
		float L_1 = L_0.___x_1;
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_2 = ___1_rhs;
		float L_3 = L_2.___x_1;
		V_0 = ((float)il2cpp_codegen_subtract(L_1, L_3));
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_4 = ___0_lhs;
		float L_5 = L_4.___y_2;
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_6 = ___1_rhs;
		float L_7 = L_6.___y_2;
		V_1 = ((float)il2cpp_codegen_subtract(L_5, L_7));
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_8 = ___0_lhs;
		float L_9 = L_8.___z_3;
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_10 = ___1_rhs;
		float L_11 = L_10.___z_3;
		V_2 = ((float)il2cpp_codegen_subtract(L_9, L_11));
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_12 = ___0_lhs;
		float L_13 = L_12.___w_4;
		Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 L_14 = ___1_rhs;
		float L_15 = L_14.___w_4;
		V_3 = ((float)il2cpp_codegen_subtract(L_13, L_15));
		float L_16 = V_0;
		float L_17 = V_0;
		float L_18 = V_1;
		float L_19 = V_1;
		float L_20 = V_2;
		float L_21 = V_2;
		float L_22 = V_3;
		float L_23 = V_3;
		V_4 = ((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_16, L_17)), ((float)il2cpp_codegen_multiply(L_18, L_19)))), ((float)il2cpp_codegen_multiply(L_20, L_21)))), ((float)il2cpp_codegen_multiply(L_22, L_23))));
		float L_24 = V_4;
		V_5 = (bool)((((float)L_24) < ((float)(9.99999944E-11f)))? 1 : 0);
		goto IL_0057;
	}

IL_0057:
	{
		bool L_25 = V_5;
		return L_25;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Equality_mCDCBB8D2EDC3D3BF20F31A25ACB34705D352B479_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___0_lhs, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___1_rhs, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	bool V_4 = false;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___0_lhs;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___1_rhs;
		float L_3 = L_2.___x_2;
		V_0 = ((float)il2cpp_codegen_subtract(L_1, L_3));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___0_lhs;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___1_rhs;
		float L_7 = L_6.___y_3;
		V_1 = ((float)il2cpp_codegen_subtract(L_5, L_7));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___0_lhs;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___1_rhs;
		float L_11 = L_10.___z_4;
		V_2 = ((float)il2cpp_codegen_subtract(L_9, L_11));
		float L_12 = V_0;
		float L_13 = V_0;
		float L_14 = V_1;
		float L_15 = V_1;
		float L_16 = V_2;
		float L_17 = V_2;
		V_3 = ((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_12, L_13)), ((float)il2cpp_codegen_multiply(L_14, L_15)))), ((float)il2cpp_codegen_multiply(L_16, L_17))));
		float L_18 = V_3;
		V_4 = (bool)((((float)L_18) < ((float)(9.99999944E-11f)))? 1 : 0);
		goto IL_0043;
	}

IL_0043:
	{
		bool L_19 = V_4;
		return L_19;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Max_mF5379E63D2BBAC76D090748695D833934F8AD051_inline (float ___0_a, float ___1_b, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float G_B3_0 = 0.0f;
	{
		float L_0 = ___0_a;
		float L_1 = ___1_b;
		if ((((float)L_0) > ((float)L_1)))
		{
			goto IL_0008;
		}
	}
	{
		float L_2 = ___1_b;
		G_B3_0 = L_2;
		goto IL_0009;
	}

IL_0008:
	{
		float L_3 = ___0_a;
		G_B3_0 = L_3;
	}

IL_0009:
	{
		V_0 = G_B3_0;
		goto IL_000c;
	}

IL_000c:
	{
		float L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector4__ctor_m96B2CD8B862B271F513AF0BDC2EABD58E4DBC813_inline (Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3* __this, float ___0_x, float ___1_y, float ___2_z, float ___3_w, const RuntimeMethod* method) 
{
	{
		float L_0 = ___0_x;
		__this->___x_1 = L_0;
		float L_1 = ___1_y;
		__this->___y_2 = L_1;
		float L_2 = ___2_z;
		__this->___z_3 = L_2;
		float L_3 = ___3_w;
		__this->___w_4 = L_3;
		return;
	}
}
