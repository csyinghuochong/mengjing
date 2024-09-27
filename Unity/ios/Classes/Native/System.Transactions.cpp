#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


template <typename T1>
struct VirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct VirtualFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct GenericVirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct GenericInterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2;
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1*, T2*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2)
	{
		void* params[2] = { p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3;
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3<T1*, T2*, T3*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3* p3)
	{
		void* params[3] = { p1, p2, p3 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};

// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t5C8F46F5D57502270DD9E1DA8303B23C7FE85588;
// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>
struct List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3;
// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>
struct List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C;
// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.Transactions.IEnlistmentNotification[]
struct IEnlistmentNotificationU5BU5D_t43C61449FC3AA7F3AC02A1E6FE315C31416357F4;
// System.Transactions.ISinglePhaseNotification[]
struct ISinglePhaseNotificationU5BU5D_tBCC1EA9782E893D8F493B8983F1B686826558207;
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// System.Type[]
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
// System.ArgumentOutOfRangeException
struct ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F;
// System.Collections.ArrayList
struct ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// System.Attribute
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// System.Transactions.Enlistment
struct Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552;
// System.EventArgs
struct EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377;
// System.Threading.EventWaitHandle
struct EventWaitHandle_t18F2EB0161747B0646A9A406015A61A214A1EB7E;
// System.Exception
struct Exception_t;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// System.Transactions.IEnlistmentNotification
struct IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66;
// System.Runtime.Serialization.IFormatterConverter
struct IFormatterConverter_t726606DAC82C384B08C82471313C340968DDB609;
// System.Transactions.IPromotableSinglePhaseNotification
struct IPromotableSinglePhaseNotification_t55FA5C677628E609C73561E23A834E464F5B1321;
// System.Transactions.ISinglePhaseNotification
struct ISinglePhaseNotification_tA01F24695E100E9C38BC5009D1AFE7BF90296335;
// System.InvalidOperationException
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB;
// System.Threading.ManualResetEvent
struct ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.MonoTODOAttribute
struct MonoTODOAttribute_t7B6AA25D7749BF3B05CEEAC921F8A2AC37A0A22B;
// System.NotImplementedException
struct NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8;
// System.PlatformNotSupportedException
struct PlatformNotSupportedException_tD2BD7EB9278518AA5FE8AE75AD5D0D4298A4631A;
// System.Transactions.PreparingEnlistment
struct PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// Microsoft.Win32.SafeHandles.SafeWaitHandle
struct SafeWaitHandle_t58F5662CD56F6462A687198A64987F8980804449;
// System.Runtime.Serialization.SerializationInfo
struct SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37;
// System.Transactions.SinglePhaseEnlistment
struct SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C;
// System.String
struct String_t;
// System.SystemException
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295;
// System.TimeoutException
struct TimeoutException_t7552449BA7E0911AEA1B6C7D1BEAC6534819305F;
// System.Threading.Timer
struct Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00;
// System.Threading.TimerCallback
struct TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD;
// System.Transactions.Transaction
struct Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD;
// System.Transactions.TransactionAbortedException
struct TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF;
// System.Transactions.TransactionCompletedEventHandler
struct TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB;
// System.Transactions.TransactionEventArgs
struct TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82;
// System.Transactions.TransactionException
struct TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF;
// System.Transactions.TransactionInformation
struct TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA;
// System.Transactions.TransactionScope
struct TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4;
// System.Type
struct Type_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// System.Threading.WaitCallback
struct WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3;
// System.Threading.WaitHandle
struct WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8;

IL2CPP_EXTERN_C RuntimeClass* ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Guid_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IPromotableSinglePhaseNotification_t55FA5C677628E609C73561E23A834E464F5B1321_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ISinglePhaseNotification_tA01F24695E100E9C38BC5009D1AFE7BF90296335_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PlatformNotSupportedException_tD2BD7EB9278518AA5FE8AE75AD5D0D4298A4631A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimeoutException_t7552449BA7E0911AEA1B6C7D1BEAC6534819305F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral2B3EB81375F9432101A9E05B2C117E92F4E7F833;
IL2CPP_EXTERN_C String_t* _stringLiteral6AB2BBD66829F3B447D944E2A6EEB9436AE7506E;
IL2CPP_EXTERN_C String_t* _stringLiteral7DB2A4D5C9EB86ADA8CB0DD94ECFAFBBD8333BDA;
IL2CPP_EXTERN_C String_t* _stringLiteral83A962F377FDA097D2DCADA8B2CE959C16EBEBB0;
IL2CPP_EXTERN_C String_t* _stringLiteral87104EDA2ADE7D066F82338C32E0CC6EA29AEE34;
IL2CPP_EXTERN_C String_t* _stringLiteralB0FCBD1BB0D5DDFC7C1E4FBDBC8880AC0B13F325;
IL2CPP_EXTERN_C String_t* _stringLiteralD41D80DA5EAC5279DC86938BA5757D74E331447D;
IL2CPP_EXTERN_C String_t* _stringLiteralDD00274E883EE073F2E90CCF5B0E850F5BA98E95;
IL2CPP_EXTERN_C String_t* _stringLiteralE450D74F5D2BAAB6C582160F56F824E1F2E7676D;
IL2CPP_EXTERN_C String_t* _stringLiteralE6CD40D15D8228A3C4A01FAEB721E097AD1C590A;
IL2CPP_EXTERN_C String_t* _stringLiteralF3F20C515F1F87C09E46BECFD63FFE9AFF0DCF8C;
IL2CPP_EXTERN_C String_t* _stringLiteralF781F2380A4ED1A562E1441F123A21E9DBCE41D3;
IL2CPP_EXTERN_C String_t* _stringLiteralF9789EC5E59C155776C9BDFF4642FAB40304D870;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m461856AF5428B8A52C0CFBF61D88239241CC0D08_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mC3B48F43E26A08BF2940C08CC90EFABB187D157F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_mDD09942EE453A07ECBA49A06DA6255870CB3E1E3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* ThrowStub_ThrowNotSupportedException_m53C3B333318540135E1FEA2D1ADAD8EC68844340_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TransactionScope_Complete_m58458AAD462903EAD152D08813D8AA2CEB74AB2C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TransactionScope_Dispose_m69C2C2B57EB8CADA3A3D763EADA27E2F27DD1CB4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TransactionScope_Initialize_mED0CFC28756E181F5C5175B85A2F0788F866FB8B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TransactionScope_TimerCallback_mF0837984321FE50ADD6CD2EBB3FB3F35CF058185_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_DoPreparePhase_m88ABEC8C24281671F33674AFD8DAA54755D39BDB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_EnsureIncompleteCurrentScope_m50358C964D025F5EAF27CC2F0D24229E86BBA031_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_InitScope_mF57A5705AAAC4B3EA7D8E3AA7F99F0BAE2145605_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_PrepareCallbackWrapper_mDCF9E2F62CFCA967ED59FF8A1398A4746E9B03E6_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_Rollback_m298E5E20A30D81EFD61CC338DF07E9E3BA82C28D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_mCD8C8392E3EE07D0A0D0AB5362E7659BC4A83AB5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Transaction__ctor_mDF856DFDF7C245002C76F0B0E0AC7821B25E7ADC_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tC7572A22E8932A2696F3A78168D22324B896BC29 
{
};

// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>
struct List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	IEnlistmentNotificationU5BU5D_t43C61449FC3AA7F3AC02A1E6FE315C31416357F4* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>
struct List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	ISinglePhaseNotificationU5BU5D_tBCC1EA9782E893D8F493B8983F1B686826558207* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

// System.Collections.ArrayList
struct ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A  : public RuntimeObject
{
	// System.Object[] System.Collections.ArrayList::_items
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____items_0;
	// System.Int32 System.Collections.ArrayList::_size
	int32_t ____size_1;
	// System.Int32 System.Collections.ArrayList::_version
	int32_t ____version_2;
	// System.Object System.Collections.ArrayList::_syncRoot
	RuntimeObject* ____syncRoot_3;
};

// System.Attribute
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};

// System.Transactions.Enlistment
struct Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552  : public RuntimeObject
{
	// System.Boolean System.Transactions.Enlistment::done
	bool ___done_0;
};

// System.EventArgs
struct EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377  : public RuntimeObject
{
};

// System.MarshalByRefObject
struct MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE  : public RuntimeObject
{
	// System.Object System.MarshalByRefObject::_identity
	RuntimeObject* ____identity_0;
};
// Native definition for P/Invoke marshalling of System.MarshalByRefObject
struct MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE_marshaled_pinvoke
{
	Il2CppIUnknown* ____identity_0;
};
// Native definition for COM marshalling of System.MarshalByRefObject
struct MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE_marshaled_com
{
	Il2CppIUnknown* ____identity_0;
};

// System.Runtime.Serialization.SerializationInfo
struct SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37  : public RuntimeObject
{
	// System.String[] System.Runtime.Serialization.SerializationInfo::m_members
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___m_members_3;
	// System.Object[] System.Runtime.Serialization.SerializationInfo::m_data
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___m_data_4;
	// System.Type[] System.Runtime.Serialization.SerializationInfo::m_types
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___m_types_5;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Runtime.Serialization.SerializationInfo::m_nameToIndex
	Dictionary_2_t5C8F46F5D57502270DD9E1DA8303B23C7FE85588* ___m_nameToIndex_6;
	// System.Int32 System.Runtime.Serialization.SerializationInfo::m_currMember
	int32_t ___m_currMember_7;
	// System.Runtime.Serialization.IFormatterConverter System.Runtime.Serialization.SerializationInfo::m_converter
	RuntimeObject* ___m_converter_8;
	// System.String System.Runtime.Serialization.SerializationInfo::m_fullTypeName
	String_t* ___m_fullTypeName_9;
	// System.String System.Runtime.Serialization.SerializationInfo::m_assemName
	String_t* ___m_assemName_10;
	// System.Type System.Runtime.Serialization.SerializationInfo::objectType
	Type_t* ___objectType_11;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::isFullTypeNameSetExplicit
	bool ___isFullTypeNameSetExplicit_12;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::isAssemblyNameSetExplicit
	bool ___isAssemblyNameSetExplicit_13;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::requireSameTokenInPartialTrust
	bool ___requireSameTokenInPartialTrust_14;
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

// System.Transactions.TransactionManager
struct TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98  : public RuntimeObject
{
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

// System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>
struct Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 
{
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::_list
	List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* ____list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::_index
	int32_t ____index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::_version
	int32_t ____version_2;
	// T System.Collections.Generic.List`1/Enumerator::_current
	RuntimeObject* ____current_3;
};

// System.Collections.Generic.List`1/Enumerator<System.Object>
struct Enumerator_t9473BAB568A27E2339D48C1F91319E0F6D244D7A 
{
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::_list
	List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* ____list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::_index
	int32_t ____index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::_version
	int32_t ____version_2;
	// T System.Collections.Generic.List`1/Enumerator::_current
	RuntimeObject* ____current_3;
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

// System.DateTime
struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D 
{
	// System.UInt64 System.DateTime::_dateData
	uint64_t ____dateData_46;
};

// System.Guid
struct Guid_t 
{
	// System.Int32 System.Guid::_a
	int32_t ____a_1;
	// System.Int16 System.Guid::_b
	int16_t ____b_2;
	// System.Int16 System.Guid::_c
	int16_t ____c_3;
	// System.Byte System.Guid::_d
	uint8_t ____d_4;
	// System.Byte System.Guid::_e
	uint8_t ____e_5;
	// System.Byte System.Guid::_f
	uint8_t ____f_6;
	// System.Byte System.Guid::_g
	uint8_t ____g_7;
	// System.Byte System.Guid::_h
	uint8_t ____h_8;
	// System.Byte System.Guid::_i
	uint8_t ____i_9;
	// System.Byte System.Guid::_j
	uint8_t ____j_10;
	// System.Byte System.Guid::_k
	uint8_t ____k_11;
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

// System.MonoTODOAttribute
struct MonoTODOAttribute_t7B6AA25D7749BF3B05CEEAC921F8A2AC37A0A22B  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};

// System.Transactions.PreparingEnlistment
struct PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324  : public Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552
{
	// System.Boolean System.Transactions.PreparingEnlistment::prepared
	bool ___prepared_1;
	// System.Transactions.Transaction System.Transactions.PreparingEnlistment::tx
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___tx_2;
	// System.Transactions.IEnlistmentNotification System.Transactions.PreparingEnlistment::enlisted
	RuntimeObject* ___enlisted_3;
	// System.Threading.WaitHandle System.Transactions.PreparingEnlistment::waitHandle
	WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* ___waitHandle_4;
	// System.Exception System.Transactions.PreparingEnlistment::ex
	Exception_t* ___ex_5;
};

// System.Transactions.SinglePhaseEnlistment
struct SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C  : public Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552
{
	// System.Transactions.Transaction System.Transactions.SinglePhaseEnlistment::tx
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___tx_1;
	// System.Object System.Transactions.SinglePhaseEnlistment::abortingEnlisted
	RuntimeObject* ___abortingEnlisted_2;
};

// System.Runtime.Serialization.StreamingContext
struct StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 
{
	// System.Object System.Runtime.Serialization.StreamingContext::m_additionalContext
	RuntimeObject* ___m_additionalContext_0;
	// System.Runtime.Serialization.StreamingContextStates System.Runtime.Serialization.StreamingContext::m_state
	int32_t ___m_state_1;
};
// Native definition for P/Invoke marshalling of System.Runtime.Serialization.StreamingContext
struct StreamingContext_t56760522A751890146EE45F82F866B55B7E33677_marshaled_pinvoke
{
	Il2CppIUnknown* ___m_additionalContext_0;
	int32_t ___m_state_1;
};
// Native definition for COM marshalling of System.Runtime.Serialization.StreamingContext
struct StreamingContext_t56760522A751890146EE45F82F866B55B7E33677_marshaled_com
{
	Il2CppIUnknown* ___m_additionalContext_0;
	int32_t ___m_state_1;
};

// System.TimeSpan
struct TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A 
{
	// System.Int64 System.TimeSpan::_ticks
	int64_t ____ticks_22;
};

// System.Threading.Timer
struct Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00  : public MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE
{
	// System.Threading.TimerCallback System.Threading.Timer::callback
	TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD* ___callback_1;
	// System.Object System.Threading.Timer::state
	RuntimeObject* ___state_2;
	// System.Int64 System.Threading.Timer::due_time_ms
	int64_t ___due_time_ms_3;
	// System.Int64 System.Threading.Timer::period_ms
	int64_t ___period_ms_4;
	// System.Int64 System.Threading.Timer::next_run
	int64_t ___next_run_5;
	// System.Boolean System.Threading.Timer::disposed
	bool ___disposed_6;
	// System.Boolean System.Threading.Timer::is_dead
	bool ___is_dead_7;
	// System.Boolean System.Threading.Timer::is_added
	bool ___is_added_8;
};

// System.Transactions.TransactionEventArgs
struct TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82  : public EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377
{
	// System.Transactions.Transaction System.Transactions.TransactionEventArgs::transaction
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___transaction_1;
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

// System.Transactions.Transaction
struct Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD  : public RuntimeObject
{
	// System.Transactions.IsolationLevel System.Transactions.Transaction::level
	int32_t ___level_1;
	// System.Transactions.TransactionInformation System.Transactions.Transaction::info
	TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* ___info_2;
	// System.Collections.ArrayList System.Transactions.Transaction::dependents
	ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A* ___dependents_3;
	// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification> System.Transactions.Transaction::volatiles
	List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* ___volatiles_4;
	// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification> System.Transactions.Transaction::durables
	List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* ___durables_5;
	// System.Transactions.IPromotableSinglePhaseNotification System.Transactions.Transaction::pspe
	RuntimeObject* ___pspe_6;
	// System.Boolean System.Transactions.Transaction::committing
	bool ___committing_7;
	// System.Boolean System.Transactions.Transaction::committed
	bool ___committed_8;
	// System.Boolean System.Transactions.Transaction::aborted
	bool ___aborted_9;
	// System.Transactions.TransactionScope System.Transactions.Transaction::scope
	TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* ___scope_10;
	// System.Exception System.Transactions.Transaction::innerException
	Exception_t* ___innerException_11;
	// System.Guid System.Transactions.Transaction::tag
	Guid_t ___tag_12;
	// System.Transactions.TransactionCompletedEventHandler System.Transactions.Transaction::TransactionCompletedInternal
	TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* ___TransactionCompletedInternal_13;
};

// System.Transactions.TransactionInformation
struct TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA  : public RuntimeObject
{
	// System.String System.Transactions.TransactionInformation::local_id
	String_t* ___local_id_0;
	// System.Guid System.Transactions.TransactionInformation::dtcId
	Guid_t ___dtcId_1;
	// System.DateTime System.Transactions.TransactionInformation::creation_time
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___creation_time_2;
	// System.Transactions.TransactionStatus System.Transactions.TransactionInformation::status
	int32_t ___status_3;
};

// System.Transactions.TransactionOptions
struct TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD 
{
	// System.Transactions.IsolationLevel System.Transactions.TransactionOptions::level
	int32_t ___level_0;
	// System.TimeSpan System.Transactions.TransactionOptions::timeout
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___timeout_1;
};

// System.Transactions.TransactionScope
struct TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4  : public RuntimeObject
{
	// System.Threading.Timer System.Transactions.TransactionScope::scopeTimer
	Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00* ___scopeTimer_1;
	// System.Transactions.Transaction System.Transactions.TransactionScope::transaction
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___transaction_2;
	// System.Transactions.Transaction System.Transactions.TransactionScope::oldTransaction
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___oldTransaction_3;
	// System.Transactions.TransactionScope System.Transactions.TransactionScope::parentScope
	TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* ___parentScope_4;
	// System.TimeSpan System.Transactions.TransactionScope::timeout
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___timeout_5;
	// System.Int32 System.Transactions.TransactionScope::nested
	int32_t ___nested_6;
	// System.Boolean System.Transactions.TransactionScope::disposed
	bool ___disposed_7;
	// System.Boolean System.Transactions.TransactionScope::completed
	bool ___completed_8;
	// System.Boolean System.Transactions.TransactionScope::aborted
	bool ___aborted_9;
	// System.Boolean System.Transactions.TransactionScope::isRoot
	bool ___isRoot_10;
	// System.Boolean System.Transactions.TransactionScope::asyncFlowEnabled
	bool ___asyncFlowEnabled_11;
};

// System.Threading.WaitHandle
struct WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8  : public MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE
{
	// System.IntPtr System.Threading.WaitHandle::waitHandle
	intptr_t ___waitHandle_3;
	// Microsoft.Win32.SafeHandles.SafeWaitHandle modreq(System.Runtime.CompilerServices.IsVolatile) System.Threading.WaitHandle::safeWaitHandle
	SafeWaitHandle_t58F5662CD56F6462A687198A64987F8980804449* ___safeWaitHandle_4;
	// System.Boolean System.Threading.WaitHandle::hasThreadAffinity
	bool ___hasThreadAffinity_5;
};
// Native definition for P/Invoke marshalling of System.Threading.WaitHandle
struct WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8_marshaled_pinvoke : public MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE_marshaled_pinvoke
{
	intptr_t ___waitHandle_3;
	void* ___safeWaitHandle_4;
	int32_t ___hasThreadAffinity_5;
};
// Native definition for COM marshalling of System.Threading.WaitHandle
struct WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8_marshaled_com : public MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE_marshaled_com
{
	intptr_t ___waitHandle_3;
	void* ___safeWaitHandle_4;
	int32_t ___hasThreadAffinity_5;
};

// System.Threading.EventWaitHandle
struct EventWaitHandle_t18F2EB0161747B0646A9A406015A61A214A1EB7E  : public WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8
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

// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	// System.String System.ArgumentException::_paramName
	String_t* ____paramName_18;
};

// System.InvalidOperationException
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.Threading.ManualResetEvent
struct ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158  : public EventWaitHandle_t18F2EB0161747B0646A9A406015A61A214A1EB7E
{
};

// System.NotImplementedException
struct NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.NotSupportedException
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.TimeoutException
struct TimeoutException_t7552449BA7E0911AEA1B6C7D1BEAC6534819305F  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.Threading.TimerCallback
struct TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD  : public MulticastDelegate_t
{
};

// System.Transactions.TransactionCompletedEventHandler
struct TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB  : public MulticastDelegate_t
{
};

// System.Transactions.TransactionException
struct TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.Threading.WaitCallback
struct WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3  : public MulticastDelegate_t
{
};

// System.ArgumentOutOfRangeException
struct ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
	// System.Object System.ArgumentOutOfRangeException::_actualValue
	RuntimeObject* ____actualValue_19;
};

// System.ObjectDisposedException
struct ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB  : public InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB
{
	// System.String System.ObjectDisposedException::_objectName
	String_t* ____objectName_18;
};

// System.PlatformNotSupportedException
struct PlatformNotSupportedException_tD2BD7EB9278518AA5FE8AE75AD5D0D4298A4631A  : public NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A
{
};

// System.Transactions.TransactionAbortedException
struct TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF  : public TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF
{
};

// Unity.ThrowStub
struct ThrowStub_t0BE5E40CC257CB268BDB9004F8775ECE8FB0CBCF  : public ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB
{
};

// <Module>

// <Module>

// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>
struct List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	IEnlistmentNotificationU5BU5D_t43C61449FC3AA7F3AC02A1E6FE315C31416357F4* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>

// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>
struct List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	ISinglePhaseNotificationU5BU5D_tBCC1EA9782E893D8F493B8983F1B686826558207* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>

// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<System.Object>

// System.Collections.ArrayList

// System.Collections.ArrayList

// System.Attribute

// System.Attribute

// System.Transactions.Enlistment

// System.Transactions.Enlistment

// System.EventArgs
struct EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377_StaticFields
{
	// System.EventArgs System.EventArgs::Empty
	EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377* ___Empty_0;
};

// System.EventArgs

// System.Runtime.Serialization.SerializationInfo

// System.Runtime.Serialization.SerializationInfo

// System.String
struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.String

// System.Transactions.TransactionManager
struct TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_StaticFields
{
	// System.TimeSpan System.Transactions.TransactionManager::defaultTimeout
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___defaultTimeout_0;
	// System.TimeSpan System.Transactions.TransactionManager::maxTimeout
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___maxTimeout_1;
};

// System.Transactions.TransactionManager

// System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>

// System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>

// System.Collections.Generic.List`1/Enumerator<System.Object>

// System.Collections.Generic.List`1/Enumerator<System.Object>

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Boolean

// System.DateTime
struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_StaticFields
{
	// System.Int32[] System.DateTime::s_daysToMonth365
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth365_30;
	// System.Int32[] System.DateTime::s_daysToMonth366
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth366_31;
	// System.DateTime System.DateTime::MinValue
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MinValue_32;
	// System.DateTime System.DateTime::MaxValue
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MaxValue_33;
	// System.DateTime System.DateTime::UnixEpoch
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___UnixEpoch_34;
};

// System.DateTime

// System.Guid
struct Guid_t_StaticFields
{
	// System.Guid System.Guid::Empty
	Guid_t ___Empty_0;
};

// System.Guid

// System.Int32

// System.Int32

// System.IntPtr
struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// System.IntPtr

// System.MonoTODOAttribute

// System.MonoTODOAttribute

// System.Transactions.PreparingEnlistment

// System.Transactions.PreparingEnlistment

// System.Transactions.SinglePhaseEnlistment

// System.Transactions.SinglePhaseEnlistment

// System.Runtime.Serialization.StreamingContext

// System.Runtime.Serialization.StreamingContext

// System.TimeSpan
struct TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_StaticFields
{
	// System.TimeSpan System.TimeSpan::Zero
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___Zero_19;
	// System.TimeSpan System.TimeSpan::MaxValue
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___MaxValue_20;
	// System.TimeSpan System.TimeSpan::MinValue
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___MinValue_21;
};

// System.TimeSpan

// System.Threading.Timer

// System.Threading.Timer

// System.Transactions.TransactionEventArgs

// System.Transactions.TransactionEventArgs

// System.Void

// System.Void

// System.Delegate

// System.Delegate

// System.Exception
struct Exception_t_StaticFields
{
	// System.Object System.Exception::s_EDILock
	RuntimeObject* ___s_EDILock_0;
};

// System.Exception

// System.Transactions.Transaction

// System.Transactions.Transaction
struct Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_ThreadStaticFields
{
	// System.Transactions.Transaction System.Transactions.Transaction::ambient
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___ambient_0;
};

// System.Transactions.TransactionInformation

// System.Transactions.TransactionInformation

// System.Transactions.TransactionOptions

// System.Transactions.TransactionOptions

// System.Transactions.TransactionScope
struct TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_StaticFields
{
	// System.Transactions.TransactionOptions System.Transactions.TransactionScope::defaultOptions
	TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___defaultOptions_0;
};

// System.Transactions.TransactionScope

// System.Threading.WaitHandle
struct WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8_StaticFields
{
	// System.IntPtr System.Threading.WaitHandle::InvalidHandle
	intptr_t ___InvalidHandle_11;
};

// System.Threading.WaitHandle

// System.Threading.EventWaitHandle

// System.Threading.EventWaitHandle

// System.SystemException

// System.SystemException

// System.InvalidOperationException

// System.InvalidOperationException

// System.Threading.ManualResetEvent

// System.Threading.ManualResetEvent

// System.NotImplementedException

// System.NotImplementedException

// System.TimeoutException

// System.TimeoutException

// System.Threading.TimerCallback

// System.Threading.TimerCallback

// System.Transactions.TransactionCompletedEventHandler

// System.Transactions.TransactionCompletedEventHandler

// System.Transactions.TransactionException

// System.Transactions.TransactionException

// System.Threading.WaitCallback

// System.Threading.WaitCallback

// System.ArgumentOutOfRangeException

// System.ArgumentOutOfRangeException

// System.ObjectDisposedException

// System.ObjectDisposedException

// System.PlatformNotSupportedException

// System.PlatformNotSupportedException

// System.Transactions.TransactionAbortedException

// System.Transactions.TransactionAbortedException

// Unity.ThrowStub

// Unity.ThrowStub
#ifdef __clang__
#pragma clang diagnostic pop
#endif
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


// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1/Enumerator<T> System.Collections.Generic.List`1<System.Object>::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Enumerator_t9473BAB568A27E2339D48C1F91319E0F6D244D7A List_1_GetEnumerator_mD8294A7FA2BEB1929487127D476F8EC1CDC23BFC_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1/Enumerator<System.Object>::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enumerator_Dispose_mD9DC3E3C3697830A4823047AB29A77DBBB5ED419_gshared (Enumerator_t9473BAB568A27E2339D48C1F91319E0F6D244D7A* __this, const RuntimeMethod* method) ;
// T System.Collections.Generic.List`1/Enumerator<System.Object>::get_Current()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* Enumerator_get_Current_m6330F15D18EE4F547C05DF9BF83C5EB710376027_gshared_inline (Enumerator_t9473BAB568A27E2339D48C1F91319E0F6D244D7A* __this, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.List`1/Enumerator<System.Object>::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_mE921CC8F29FBBDE7CC3209A0ED0D921D58D00BCB_gshared (Enumerator_t9473BAB568A27E2339D48C1F91319E0F6D244D7A* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.List`1<System.Object>::get_Count()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
// T System.Collections.Generic.List`1<System.Object>::get_Item(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, int32_t ___0_index, const RuntimeMethod* method) ;

// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2 (Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA* __this, const RuntimeMethod* method) ;
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Enlistment::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enlistment__ctor_m8A01B2DCBBE2F2BB4CD040581D0D3521A449583F (Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* __this, const RuntimeMethod* method) ;
// System.Void System.Threading.ManualResetEvent::.ctor(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ManualResetEvent__ctor_m361CFCF6AC28BFFF5C8790DC2B5951791A1C4CEE (ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158* __this, bool ___0_initialState, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::.ctor()
inline void List_1__ctor_m461856AF5428B8A52C0CFBF61D88239241CC0D08 (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>::.ctor()
inline void List_1__ctor_mC3B48F43E26A08BF2940C08CC90EFABB187D157F (List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
// System.Void System.Collections.ArrayList::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArrayList__ctor_m07DC369002304B483B9FC41DBDAF4A25AC3C9F80 (ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A* __this, const RuntimeMethod* method) ;
// System.Guid System.Guid::NewGuid()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Guid_t Guid_NewGuid_m1F4894E8DC089811D6252148AD5858E58D43A7BD (const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionInformation::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionInformation__ctor_m3961D2A87A4E85093413BB79F666FEA2A10F5269 (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, const RuntimeMethod* method) ;
// System.Void System.NotImplementedException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::EnsureIncompleteCurrentScope()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_EnsureIncompleteCurrentScope_m50358C964D025F5EAF27CC2F0D24229E86BBA031 (const RuntimeMethod* method) ;
// System.Transactions.TransactionInformation System.Transactions.Transaction::get_TransactionInformation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* Transaction_get_TransactionInformation_mB4DBFB45362745793F6E268C7F5BD9ADED3E5861 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Transactions.TransactionStatus System.Transactions.TransactionInformation::get_Status()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TransactionInformation_get_Status_mB45D34431DAC463611A59869926E98513B97414A_inline (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::Rollback()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.Transaction::Equals(System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Transaction_Equals_mC586D4C5C87F45DCF282AF7B071738E8E8B2F6ED (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_t, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.Transaction::op_Equality(System.Transactions.Transaction,System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_x, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___1_y, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::Rollback(System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Rollback_m7BEAC0E95FA3B45F0E78C5FF1857F914AAA1909E (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, Exception_t* ___0_e, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::Rollback(System.Exception,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Rollback_m298E5E20A30D81EFD61CC338DF07E9E3BA82C28D (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, Exception_t* ___0_ex, RuntimeObject* ___1_abortingEnlisted, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::FireCompleted()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_FireCompleted_mD21E71C2CDB94A3F1ED8AEBD8F258C70F8210440 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_mD6A1BC6487DB3CE81488727A3D811024D45F8859 (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, String_t* ___0_message, const RuntimeMethod* method) ;
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_mFE1891FDD22473024672131E28D94176F7D74A01 (SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification> System.Transactions.Transaction::get_Volatiles()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* Transaction_get_Volatiles_mCD1BF84C66655C8FD244A1F5578DD02DBED0129A (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1/Enumerator<T> System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::GetEnumerator()
inline Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367 (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* __this, const RuntimeMethod* method)
{
	return ((  Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 (*) (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3*, const RuntimeMethod*))List_1_GetEnumerator_mD8294A7FA2BEB1929487127D476F8EC1CDC23BFC_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>::Dispose()
inline void Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB (Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040* __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040*, const RuntimeMethod*))Enumerator_Dispose_mD9DC3E3C3697830A4823047AB29A77DBBB5ED419_gshared)(__this, method);
}
// T System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>::get_Current()
inline RuntimeObject* Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_inline (Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040*, const RuntimeMethod*))Enumerator_get_Current_m6330F15D18EE4F547C05DF9BF83C5EB710376027_gshared_inline)(__this, method);
}
// System.Boolean System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>::MoveNext()
inline bool Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A (Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040*, const RuntimeMethod*))Enumerator_MoveNext_mE921CC8F29FBBDE7CC3209A0ED0D921D58D00BCB_gshared)(__this, method);
}
// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification> System.Transactions.Transaction::get_Durables()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* Transaction_get_Durables_mCFB83FC73DFCF3EBD3A758327D3EE835389566A3 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>::get_Count()
inline int32_t List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_inline (List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C*, const RuntimeMethod*))List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline)(__this, method);
}
// T System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>::get_Item(System.Int32)
inline RuntimeObject* List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147 (List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C*, int32_t, const RuntimeMethod*))List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared)(__this, ___0_index, method);
}
// System.Void System.Transactions.Transaction::set_Aborted(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_set_Aborted_m24683739B6DC84AF5BEAF5E83C6ECA1D4B44BE17 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, bool ___0_value, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionInformation::set_Status(System.Transactions.TransactionStatus)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TransactionInformation_set_Status_m6D0E87BE8EDD80DC7AFD5A3CEC8E8EA4B1626AFE_inline (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, int32_t ___0_value, const RuntimeMethod* method) ;
// System.Void System.InvalidOperationException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162 (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* __this, String_t* ___0_message, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::DoCommit()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoCommit_m3F3D8AC947B522A74307E790B58E3A5955C8EDBD (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.String,System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_m9B248FC15B4187F9271081AF004DDFBA164C07B3 (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* __this, String_t* ___0_message, Exception_t* ___1_innerException, const RuntimeMethod* method) ;
// System.Transactions.TransactionScope System.Transactions.Transaction::get_Scope()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.TransactionScope::get_IsComplete()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TransactionScope_get_IsComplete_mA48470D9FFCC137101B3972C9B1D46ED5EC51C8C_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.TransactionScope::get_IsDisposed()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TransactionScope_get_IsDisposed_mBE2D47F728A37F239A3C3AB0A1630A6BDB1F66F5_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::CheckAborted()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::get_Count()
inline int32_t List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_inline (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3*, const RuntimeMethod*))List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline)(__this, method);
}
// T System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::get_Item(System.Int32)
inline RuntimeObject* List_1_get_Item_mDD09942EE453A07ECBA49A06DA6255870CB3E1E3 (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3*, int32_t, const RuntimeMethod*))List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared)(__this, ___0_index, method);
}
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.ISinglePhaseNotification)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m63A77FAEE5B90B5B48BCCF58F778DEDA76DE1F5B (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, RuntimeObject* ___0_single, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::Complete()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Complete_mEABE80EC6973F408138539E94FF7DF29A7D9E8A1 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::DoPreparePhase()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoPreparePhase_m88ABEC8C24281671F33674AFD8DAA54755D39BDB (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.IPromotableSinglePhaseNotification)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m34351FBEBC8D263709545E67437859B156533A9E (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, RuntimeObject* ___0_single, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::DoCommitPhase()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoCommitPhase_mC0DC123CB7534B3AABF8522C81CFDDFFF8A512E1 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::set_Scope(System.Transactions.TransactionScope)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* ___0_value, const RuntimeMethod* method) ;
// System.Transactions.IEnlistmentNotification System.Transactions.PreparingEnlistment::get_EnlistmentNotification()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* PreparingEnlistment_get_EnlistmentNotification_m6E0C291F9F6A40FC43C4E215697980C93E345596_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.PreparingEnlistment::set_Exception(System.Exception)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PreparingEnlistment_set_Exception_m594BFBA84F1EED8E911AC573E9D2BFEFD6F8CBB8_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, Exception_t* ___0_value, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.PreparingEnlistment::get_IsPrepared()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PreparingEnlistment_get_IsPrepared_m446B89A1F1859453F9B570D7DDD61925800D3EB2_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) ;
// System.Threading.WaitHandle System.Transactions.PreparingEnlistment::get_WaitHandle()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* PreparingEnlistment_get_WaitHandle_m97FAB47F8B5288954C6182F9459986DE97F4C0FB_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) ;
// System.Boolean System.Threading.EventWaitHandle::Set()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool EventWaitHandle_Set_mDF98D67F214714A9590DF82A1C51D3D851281E4D (EventWaitHandle_t18F2EB0161747B0646A9A406015A61A214A1EB7E* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.PreparingEnlistment::.ctor(System.Transactions.Transaction,System.Transactions.IEnlistmentNotification)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PreparingEnlistment__ctor_mA17634B83034CC29A385144E81D879A3B70053AE (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_tx, RuntimeObject* ___1_enlisted, const RuntimeMethod* method) ;
// System.Void System.Threading.WaitCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void WaitCallback__ctor_m9730564F9A28ECB72462D05AA92CA9E43DE9B41C (WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
// System.Boolean System.Threading.ThreadPool::QueueUserWorkItem(System.Threading.WaitCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR bool ThreadPool_QueueUserWorkItem_mE534D14C47699D1D37288AE0710B19FC7EC02BAB (WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3* ___0_callBack, RuntimeObject* ___1_state, const RuntimeMethod* method) ;
// System.TimeSpan System.Transactions.TransactionManager::get_DefaultTimeout()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TransactionManager_get_DefaultTimeout_m986CEE04836E5DCF3328652175C50A276DD75E0F_inline (const RuntimeMethod* method) ;
// System.TimeSpan System.Transactions.TransactionScope::get_Timeout()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TransactionScope_get_Timeout_mE3C1143951329A6EF6AA5E49A9DEE2F598EA26C3_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) ;
// System.Void System.TimeoutException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeoutException__ctor_mAC3BF713E7242641234A1E292C470655E1EFA964 (TimeoutException_t7552449BA7E0911AEA1B6C7D1BEAC6534819305F* __this, String_t* ___0_message, const RuntimeMethod* method) ;
// System.Exception System.Transactions.PreparingEnlistment::get_Exception()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Exception_t* PreparingEnlistment_get_Exception_m61CD5819121927F3E76F17F0EAF69D7139429405_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor(System.Transactions.Transaction,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_mC0F13D08CCEB20FEE99855565546E171F82C5D0E (SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_tx, RuntimeObject* ___1_abortingEnlisted, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.TransactionScope::get_IsAborted()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TransactionScope_get_IsAborted_mD768F94F9BB2B571D4ECA17EA6DBD0147261D301_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionEventArgs::.ctor(System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_mDE16E072857474C6DD16928DB47058E2A9F98046 (TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_transaction, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionCompletedEventHandler::Invoke(System.Object,System.Transactions.TransactionEventArgs)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_inline (TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method) ;
// System.Transactions.Transaction System.Transactions.Transaction::get_CurrentInternal()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline (const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_m3C29A3EB6D1A3AA42E78B96EF45C22CC1F8171BB (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionException::.ctor(System.String,System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_m58CD66C4B381A0AF26F8EB9855908042A359B8BE (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, String_t* ___0_message, Exception_t* ___1_innerException, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_m3FDD9AE8E185D636E05D9A9D83E738C6A63715E4 (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ___0_info, StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 ___1_context, const RuntimeMethod* method) ;
// System.Void System.EventArgs::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EventArgs__ctor_mC6F9412D03203ADEF854117542C8EBF61624C8C3 (EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionEventArgs::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_mFD81A5A7A11F8417373C43F9BEB03EAABF6B28B3 (TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* __this, const RuntimeMethod* method) ;
// System.Void System.SystemException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SystemException__ctor_mB30C3C4B8AB4DF43F4A453C97CCA76DC4AE63B80 (SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295* __this, const RuntimeMethod* method) ;
// System.Void System.SystemException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SystemException__ctor_mC481DFD60F19362A0B3523FBD5E429EC4F1F3FB5 (SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295* __this, String_t* ___0_message, const RuntimeMethod* method) ;
// System.Void System.SystemException::.ctor(System.String,System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SystemException__ctor_m0FC84CACD2A5D66222998AA601A5C41CEC36A611 (SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295* __this, String_t* ___0_message, Exception_t* ___1_innerException, const RuntimeMethod* method) ;
// System.Void System.SystemException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SystemException__ctor_mA2BB392E0F4CD8A4C132984F76B7A9FBDB3B6879 (SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295* __this, SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ___0_info, StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 ___1_context, const RuntimeMethod* method) ;
// System.DateTime System.DateTime::get_Now()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D DateTime_get_Now_m636CB9651A9099D20BA1CF813A0C69637317325C (const RuntimeMethod* method) ;
// System.DateTime System.DateTime::ToUniversalTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D DateTime_ToUniversalTime_m52CA1EAD0BE0A357BCACC38747ECA4A8810155A9 (DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* __this, const RuntimeMethod* method) ;
// System.String System.Guid::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Guid_ToString_m2BFFD5FA726E03FA707AAFCCF065896C46D5290C (Guid_t* __this, const RuntimeMethod* method) ;
// System.String System.String::Concat(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m9E3155FB84015C823606188F53B47CB44C444991 (String_t* ___0_str0, String_t* ___1_str1, const RuntimeMethod* method) ;
// System.Void System.TimeSpan::.ctor(System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeSpan__ctor_mF8B85616C009D35D860DA0254327E8AAF54822A1 (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* __this, int32_t ___0_hours, int32_t ___1_minutes, int32_t ___2_seconds, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionOptions::.ctor(System.Transactions.IsolationLevel,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionOptions__ctor_mB6E01EA3E9A536D3DD7518541B0A19791D044910 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, int32_t ___0_level, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_timeout, const RuntimeMethod* method) ;
// System.Transactions.IsolationLevel System.Transactions.TransactionOptions::get_IsolationLevel()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TransactionOptions_get_IsolationLevel_m982A0A8E35EB6445ED55E47169297E9DAEA1C1A8_inline (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, const RuntimeMethod* method) ;
// System.Boolean System.TimeSpan::op_Equality(System.TimeSpan,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TimeSpan_op_Equality_m951689F806957B14F237DAFCEE4CB322799A723E (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___0_t1, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_t2, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.TransactionOptions::op_Equality(System.Transactions.TransactionOptions,System.Transactions.TransactionOptions)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TransactionOptions_op_Equality_m5B9B64DE16F3F0C7BBDE6C6201B59679B90E6C97 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___0_x, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___1_y, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.TransactionOptions::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TransactionOptions_Equals_m6E5D4EFB290F14239D57B0C7D364109797600E48 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
// System.Int32 System.TimeSpan::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TimeSpan_GetHashCode_m2CBBAD27522E17FE6006390ED0E3874676CAA76D (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* __this, const RuntimeMethod* method) ;
// System.Int32 System.Transactions.TransactionOptions::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TransactionOptions_GetHashCode_mD8274DC4F6F15118D764DB6D0043BB82AD162234 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionScope::.ctor(System.Transactions.TransactionScopeOption,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope__ctor_m121A69F29EE98C0EB203A32251D1F92035C8BECA (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, int32_t ___0_scopeOption, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_scopeTimeout, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionScope::.ctor(System.Transactions.TransactionScopeOption,System.TimeSpan,System.Transactions.TransactionScopeAsyncFlowOption)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope__ctor_mE97A059D5990400B94665193FFB5D1DCBA361AA4 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, int32_t ___0_scopeOption, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_scopeTimeout, int32_t ___2_asyncFlow, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionScope::Initialize(System.Transactions.TransactionScopeOption,System.Transactions.Transaction,System.Transactions.TransactionOptions,System.Transactions.EnterpriseServicesInteropOption,System.TimeSpan,System.Transactions.TransactionScopeAsyncFlowOption)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope_Initialize_mED0CFC28756E181F5C5175B85A2F0788F866FB8B (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, int32_t ___0_scopeOption, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___1_tx, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___2_options, int32_t ___3_interop, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___4_scopeTimeout, int32_t ___5_asyncFlow, const RuntimeMethod* method) ;
// System.Boolean System.TimeSpan::op_LessThan(System.TimeSpan,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TimeSpan_op_LessThan_m91C76FBEB38D80680A92A5FACA3A93810349B0FF (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___0_t1, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_t2, const RuntimeMethod* method) ;
// System.Void System.ArgumentOutOfRangeException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentOutOfRangeException__ctor_mBC1D5DEEA1BA41DE77228CB27D6BAFEB6DCCBF4A (ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F* __this, String_t* ___0_paramName, const RuntimeMethod* method) ;
// System.Transactions.Transaction System.Transactions.TransactionScope::InitTransaction(System.Transactions.Transaction,System.Transactions.TransactionScopeOption,System.Transactions.TransactionOptions)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* TransactionScope_InitTransaction_m40CC584915151A844FF7EF591034F6150705CEB6 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_tx, int32_t ___1_scopeOption, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___2_options, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::set_CurrentInternal(System.Transactions.Transaction)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Transaction_set_CurrentInternal_mB1E7D608782C542652C5FAD9D72BA73CB6558565_inline (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_value, const RuntimeMethod* method) ;
// System.Boolean System.Transactions.Transaction::op_Inequality(System.Transactions.Transaction,System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_x, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___1_y, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::InitScope(System.Transactions.TransactionScope)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_InitScope_mF57A5705AAAC4B3EA7D8E3AA7F99F0BAE2145605 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* ___0_scope, const RuntimeMethod* method) ;
// System.Boolean System.TimeSpan::op_Inequality(System.TimeSpan,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TimeSpan_op_Inequality_m2248419A8BCC8744CADE25174238B24AE34F17DB (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___0_t1, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_t2, const RuntimeMethod* method) ;
// System.Void System.Threading.TimerCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimerCallback__ctor_mDA748EAAD184861871872C3B672A848AEF2A1E4A (TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
// System.Void System.Threading.Timer::.ctor(System.Threading.TimerCallback,System.Object,System.TimeSpan,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Timer__ctor_m55493ADD5358606EC599394E7614E3D0186A731C (Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00* __this, TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD* ___0_callback, RuntimeObject* ___1_state, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___2_dueTime, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___3_period, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionScope::TimeoutScope()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope_TimeoutScope_m8E692F04DF810A9681D0B03948CE632F55B2A995 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::.ctor(System.Transactions.IsolationLevel)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction__ctor_m943B558863FECAEF52EE040D675C974230CB52E9 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, int32_t ___0_isolationLevel, const RuntimeMethod* method) ;
// System.Void System.Threading.Timer::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Timer_Dispose_m75A06B0748FE7958C296A5E39849A0FB6EA03C86 (Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00* __this, const RuntimeMethod* method) ;
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_m1BD924B419534951343ED788F32737E432FE275C (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* __this, String_t* ___0_message, const RuntimeMethod* method) ;
// System.Void System.Transactions.Transaction::CommitInternal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) ;
// System.Void System.PlatformNotSupportedException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlatformNotSupportedException__ctor_mD5DBE8E9A6FF4B75EF02671029C6D67A51EAFBD1 (PlatformNotSupportedException_tD2BD7EB9278518AA5FE8AE75AD5D0D4298A4631A* __this, const RuntimeMethod* method) ;
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
// System.Void System.MonoTODOAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoTODOAttribute__ctor_m40097723D242705105133D2FEE544CDD0D4892F0 (MonoTODOAttribute_t7B6AA25D7749BF3B05CEEAC921F8A2AC37A0A22B* __this, const RuntimeMethod* method) 
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
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_Multicast(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* currentDelegate = reinterpret_cast<TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___0_sender, ___1_e, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenInst(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	typedef void (*FunctionPointerType) (RuntimeObject*, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___0_sender, ___1_e, method);
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenStatic(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (RuntimeObject*, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___0_sender, ___1_e, method);
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenStaticInvoker(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	InvokerActionInvoker2< RuntimeObject*, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* >::Invoke((Il2CppMethodPointer)__this->___method_ptr_0, method, NULL, ___0_sender, ___1_e);
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_ClosedStaticInvoker(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	InvokerActionInvoker3< RuntimeObject*, RuntimeObject*, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* >::Invoke((Il2CppMethodPointer)__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___0_sender, ___1_e);
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenVirtual(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	VirtualActionInvoker1< TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* >::Invoke(il2cpp_codegen_method_get_slot(method), ___0_sender, ___1_e);
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenInterface(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	InterfaceActionInvoker1< TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___0_sender, ___1_e);
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenGenericVirtual(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	GenericVirtualActionInvoker1< TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* >::Invoke(method, ___0_sender, ___1_e);
}
void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenGenericInterface(TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	GenericInterfaceActionInvoker1< TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* >::Invoke(method, ___0_sender, ___1_e);
}
// System.Void System.Transactions.TransactionCompletedEventHandler::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler__ctor_mAC6B56920A35858254ACE4F75E3645DD9C394CB4 (TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = (intptr_t)il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___1_method);
	__this->___method_3 = ___1_method;
	__this->___m_target_2 = ___0_object;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___0_object);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___1_method);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___1_method))
	{
		bool isOpen = parameterCount == 2;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___1_method))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = __this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 1;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___1_method))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___1_method))
						__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___1_method))
						__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_OpenInst;
			}
		}
		else
		{
			if (___0_object == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = __this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_Multicast;
}
// System.Void System.Transactions.TransactionCompletedEventHandler::Invoke(System.Object,System.Transactions.TransactionEventArgs)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D (TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___0_sender, ___1_e, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.Enlistment::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enlistment__ctor_m8A01B2DCBBE2F2BB4CD040581D0D3521A449583F (Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		__this->___done_0 = (bool)0;
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
// System.Void System.Transactions.PreparingEnlistment::.ctor(System.Transactions.Transaction,System.Transactions.IEnlistmentNotification)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PreparingEnlistment__ctor_mA17634B83034CC29A385144E81D879A3B70053AE (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_tx, RuntimeObject* ___1_enlisted, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Enlistment__ctor_m8A01B2DCBBE2F2BB4CD040581D0D3521A449583F(__this, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_tx;
		__this->___tx_2 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___tx_2), (void*)L_0);
		RuntimeObject* L_1 = ___1_enlisted;
		__this->___enlisted_3 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___enlisted_3), (void*)L_1);
		ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158* L_2 = (ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158*)il2cpp_codegen_object_new(ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		ManualResetEvent__ctor_m361CFCF6AC28BFFF5C8790DC2B5951791A1C4CEE(L_2, (bool)0, NULL);
		__this->___waitHandle_4 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___waitHandle_4), (void*)L_2);
		return;
	}
}
// System.Boolean System.Transactions.PreparingEnlistment::get_IsPrepared()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PreparingEnlistment_get_IsPrepared_m446B89A1F1859453F9B570D7DDD61925800D3EB2 (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___prepared_1;
		return L_0;
	}
}
// System.Threading.WaitHandle System.Transactions.PreparingEnlistment::get_WaitHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* PreparingEnlistment_get_WaitHandle_m97FAB47F8B5288954C6182F9459986DE97F4C0FB (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* L_0 = __this->___waitHandle_4;
		return L_0;
	}
}
// System.Transactions.IEnlistmentNotification System.Transactions.PreparingEnlistment::get_EnlistmentNotification()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* PreparingEnlistment_get_EnlistmentNotification_m6E0C291F9F6A40FC43C4E215697980C93E345596 (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___enlisted_3;
		return L_0;
	}
}
// System.Exception System.Transactions.PreparingEnlistment::get_Exception()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Exception_t* PreparingEnlistment_get_Exception_m61CD5819121927F3E76F17F0EAF69D7139429405 (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		Exception_t* L_0 = __this->___ex_5;
		return L_0;
	}
}
// System.Void System.Transactions.PreparingEnlistment::set_Exception(System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PreparingEnlistment_set_Exception_m594BFBA84F1EED8E911AC573E9D2BFEFD6F8CBB8 (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, Exception_t* ___0_value, const RuntimeMethod* method) 
{
	{
		Exception_t* L_0 = ___0_value;
		__this->___ex_5 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ex_5), (void*)L_0);
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
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_mFE1891FDD22473024672131E28D94176F7D74A01 (SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* __this, const RuntimeMethod* method) 
{
	{
		Enlistment__ctor_m8A01B2DCBBE2F2BB4CD040581D0D3521A449583F(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor(System.Transactions.Transaction,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_mC0F13D08CCEB20FEE99855565546E171F82C5D0E (SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_tx, RuntimeObject* ___1_abortingEnlisted, const RuntimeMethod* method) 
{
	{
		Enlistment__ctor_m8A01B2DCBBE2F2BB4CD040581D0D3521A449583F(__this, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_tx;
		__this->___tx_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___tx_1), (void*)L_0);
		RuntimeObject* L_1 = ___1_abortingEnlisted;
		__this->___abortingEnlisted_2 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___abortingEnlisted_2), (void*)L_1);
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
// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification> System.Transactions.Transaction::get_Volatiles()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* Transaction_get_Volatiles_mCD1BF84C66655C8FD244A1F5578DD02DBED0129A (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m461856AF5428B8A52C0CFBF61D88239241CC0D08_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_0 = __this->___volatiles_4;
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_1 = (List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3*)il2cpp_codegen_object_new(List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		List_1__ctor_m461856AF5428B8A52C0CFBF61D88239241CC0D08(L_1, List_1__ctor_m461856AF5428B8A52C0CFBF61D88239241CC0D08_RuntimeMethod_var);
		__this->___volatiles_4 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___volatiles_4), (void*)L_1);
	}

IL_0013:
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_2 = __this->___volatiles_4;
		return L_2;
	}
}
// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification> System.Transactions.Transaction::get_Durables()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* Transaction_get_Durables_mCFB83FC73DFCF3EBD3A758327D3EE835389566A3 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mC3B48F43E26A08BF2940C08CC90EFABB187D157F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_0 = __this->___durables_5;
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_1 = (List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C*)il2cpp_codegen_object_new(List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		List_1__ctor_mC3B48F43E26A08BF2940C08CC90EFABB187D157F(L_1, List_1__ctor_mC3B48F43E26A08BF2940C08CC90EFABB187D157F_RuntimeMethod_var);
		__this->___durables_5 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___durables_5), (void*)L_1);
	}

IL_0013:
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_2 = __this->___durables_5;
		return L_2;
	}
}
// System.Void System.Transactions.Transaction::.ctor(System.Transactions.IsolationLevel)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction__ctor_m943B558863FECAEF52EE040D675C974230CB52E9 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, int32_t ___0_isolationLevel, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Guid_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A* L_0 = (ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A*)il2cpp_codegen_object_new(ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		ArrayList__ctor_m07DC369002304B483B9FC41DBDAF4A25AC3C9F80(L_0, NULL);
		__this->___dependents_3 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___dependents_3), (void*)L_0);
		il2cpp_codegen_runtime_class_init_inline(Guid_t_il2cpp_TypeInfo_var);
		Guid_t L_1;
		L_1 = Guid_NewGuid_m1F4894E8DC089811D6252148AD5858E58D43A7BD(NULL);
		__this->___tag_12 = L_1;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_2 = (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA*)il2cpp_codegen_object_new(TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		TransactionInformation__ctor_m3961D2A87A4E85093413BB79F666FEA2A10F5269(L_2, NULL);
		__this->___info_2 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___info_2), (void*)L_2);
		int32_t L_3 = ___0_isolationLevel;
		__this->___level_1 = L_3;
		return;
	}
}
// System.Void System.Transactions.Transaction::System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_mCD8C8392E3EE07D0A0D0AB5362E7659BC4A83AB5 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ___0_info, StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 ___1_context, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NullCheck(L_0);
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_mCD8C8392E3EE07D0A0D0AB5362E7659BC4A83AB5_RuntimeMethod_var)));
	}
}
// System.Transactions.Transaction System.Transactions.Transaction::get_CurrentInternal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ((Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var))->___ambient_0;
		return L_0;
	}
}
// System.Void System.Transactions.Transaction::set_CurrentInternal(System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_set_CurrentInternal_mB1E7D608782C542652C5FAD9D72BA73CB6558565 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_value;
		((Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var))->___ambient_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var))->___ambient_0), (void*)L_0);
		return;
	}
}
// System.Transactions.TransactionInformation System.Transactions.Transaction::get_TransactionInformation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* Transaction_get_TransactionInformation_mB4DBFB45362745793F6E268C7F5BD9ADED3E5861 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		Transaction_EnsureIncompleteCurrentScope_m50358C964D025F5EAF27CC2F0D24229E86BBA031(NULL);
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_0 = __this->___info_2;
		return L_0;
	}
}
// System.Void System.Transactions.Transaction::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Dispose_m8507F1AF0ADFB3D1201F30E58BAB1166BD748585 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_0;
		L_0 = Transaction_get_TransactionInformation_mB4DBFB45362745793F6E268C7F5BD9ADED3E5861(__this, NULL);
		NullCheck(L_0);
		int32_t L_1;
		L_1 = TransactionInformation_get_Status_mB45D34431DAC463611A59869926E98513B97414A_inline(L_0, NULL);
		if (L_1)
		{
			goto IL_0013;
		}
	}
	{
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(__this, NULL);
	}

IL_0013:
	{
		return;
	}
}
// System.Boolean System.Transactions.Transaction::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Transaction_Equals_m6F34A0E9EC2422A790EA8E9774E3E6BAB6B3C11A (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___0_obj;
		bool L_1;
		L_1 = Transaction_Equals_mC586D4C5C87F45DCF282AF7B071738E8E8B2F6ED(__this, ((Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)IsInstClass((RuntimeObject*)L_0, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var)), NULL);
		return L_1;
	}
}
// System.Boolean System.Transactions.Transaction::Equals(System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Transaction_Equals_mC586D4C5C87F45DCF282AF7B071738E8E8B2F6ED (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_t, const RuntimeMethod* method) 
{
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_t;
		if ((!(((RuntimeObject*)(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)L_0) == ((RuntimeObject*)(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)__this))))
		{
			goto IL_0006;
		}
	}
	{
		return (bool)1;
	}

IL_0006:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_1 = ___0_t;
		if (L_1)
		{
			goto IL_000b;
		}
	}
	{
		return (bool)0;
	}

IL_000b:
	{
		int32_t L_2 = __this->___level_1;
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_3 = ___0_t;
		NullCheck(L_3);
		int32_t L_4 = L_3->___level_1;
		if ((!(((uint32_t)L_2) == ((uint32_t)L_4))))
		{
			goto IL_0028;
		}
	}
	{
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_5 = __this->___info_2;
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_6 = ___0_t;
		NullCheck(L_6);
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_7 = L_6->___info_2;
		return (bool)((((RuntimeObject*)(TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA*)L_5) == ((RuntimeObject*)(TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA*)L_7))? 1 : 0);
	}

IL_0028:
	{
		return (bool)0;
	}
}
// System.Boolean System.Transactions.Transaction::op_Equality(System.Transactions.Transaction,System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_x, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___1_y, const RuntimeMethod* method) 
{
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_x;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_1 = ___1_y;
		return (bool)((((RuntimeObject*)(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)L_1) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
	}

IL_0008:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_2 = ___0_x;
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_3 = ___1_y;
		NullCheck(L_2);
		bool L_4;
		L_4 = Transaction_Equals_mC586D4C5C87F45DCF282AF7B071738E8E8B2F6ED(L_2, L_3, NULL);
		return L_4;
	}
}
// System.Boolean System.Transactions.Transaction::op_Inequality(System.Transactions.Transaction,System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_x, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___1_y, const RuntimeMethod* method) 
{
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_x;
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_1 = ___1_y;
		bool L_2;
		L_2 = Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC(L_0, L_1, NULL);
		return (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
	}
}
// System.Int32 System.Transactions.Transaction::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Transaction_GetHashCode_mAE0370AD6752F802566D7F7D56997BE72D8E4CDB (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___level_1;
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_1 = __this->___info_2;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = VirtualFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_1);
		ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A* L_3 = __this->___dependents_3;
		NullCheck(L_3);
		int32_t L_4;
		L_4 = VirtualFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_3);
		return ((int32_t)(((int32_t)((int32_t)L_0^L_2))^L_4));
	}
}
// System.Void System.Transactions.Transaction::Rollback()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		Transaction_Rollback_m7BEAC0E95FA3B45F0E78C5FF1857F914AAA1909E(__this, (Exception_t*)NULL, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::Rollback(System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Rollback_m7BEAC0E95FA3B45F0E78C5FF1857F914AAA1909E (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, Exception_t* ___0_e, const RuntimeMethod* method) 
{
	{
		Transaction_EnsureIncompleteCurrentScope_m50358C964D025F5EAF27CC2F0D24229E86BBA031(NULL);
		Exception_t* L_0 = ___0_e;
		Transaction_Rollback_m298E5E20A30D81EFD61CC338DF07E9E3BA82C28D(__this, L_0, NULL, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::Rollback(System.Exception,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Rollback_m298E5E20A30D81EFD61CC338DF07E9E3BA82C28D (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, Exception_t* ___0_ex, RuntimeObject* ___1_abortingEnlisted, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPromotableSinglePhaseNotification_t55FA5C677628E609C73561E23A834E464F5B1321_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* V_0 = NULL;
	List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* V_1 = NULL;
	Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 V_2;
	memset((&V_2), 0, sizeof(V_2));
	RuntimeObject* V_3 = NULL;
	{
		bool L_0 = __this->___aborted_9;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		Transaction_FireCompleted_mD21E71C2CDB94A3F1ED8AEBD8F258C70F8210440(__this, NULL);
		return;
	}

IL_000f:
	{
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_1 = __this->___info_2;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = TransactionInformation_get_Status_mB45D34431DAC463611A59869926E98513B97414A_inline(L_1, NULL);
		if ((!(((uint32_t)L_2) == ((uint32_t)1))))
		{
			goto IL_0028;
		}
	}
	{
		TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* L_3 = (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF_il2cpp_TypeInfo_var)));
		NullCheck(L_3);
		TransactionException__ctor_mD6A1BC6487DB3CE81488727A3D811024D45F8859(L_3, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE450D74F5D2BAAB6C582160F56F824E1F2E7676D)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_Rollback_m298E5E20A30D81EFD61CC338DF07E9E3BA82C28D_RuntimeMethod_var)));
	}

IL_0028:
	{
		Exception_t* L_4 = ___0_ex;
		__this->___innerException_11 = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___innerException_11), (void*)L_4);
		SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* L_5 = (SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C*)il2cpp_codegen_object_new(SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		SinglePhaseEnlistment__ctor_mFE1891FDD22473024672131E28D94176F7D74A01(L_5, NULL);
		V_0 = L_5;
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_6;
		L_6 = Transaction_get_Volatiles_mCD1BF84C66655C8FD244A1F5578DD02DBED0129A(__this, NULL);
		NullCheck(L_6);
		Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 L_7;
		L_7 = List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367(L_6, List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367_RuntimeMethod_var);
		V_2 = L_7;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0061:
			{// begin finally (depth: 1)
				Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB((&V_2), Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB_RuntimeMethod_var);
				return;
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				goto IL_0056_1;
			}

IL_0043_1:
			{
				RuntimeObject* L_8;
				L_8 = Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_inline((&V_2), Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_RuntimeMethod_var);
				V_3 = L_8;
				RuntimeObject* L_9 = V_3;
				RuntimeObject* L_10 = ___1_abortingEnlisted;
				if ((((RuntimeObject*)(RuntimeObject*)L_9) == ((RuntimeObject*)(RuntimeObject*)L_10)))
				{
					goto IL_0056_1;
				}
			}
			{
				RuntimeObject* L_11 = V_3;
				SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* L_12 = V_0;
				NullCheck(L_11);
				InterfaceActionInvoker1< Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* >::Invoke(2 /* System.Void System.Transactions.IEnlistmentNotification::Rollback(System.Transactions.Enlistment) */, IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var, L_11, L_12);
			}

IL_0056_1:
			{
				bool L_13;
				L_13 = Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A((&V_2), Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A_RuntimeMethod_var);
				if (L_13)
				{
					goto IL_0043_1;
				}
			}
			{
				goto IL_006f;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_006f:
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_14;
		L_14 = Transaction_get_Durables_mCFB83FC73DFCF3EBD3A758327D3EE835389566A3(__this, NULL);
		V_1 = L_14;
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_15 = V_1;
		NullCheck(L_15);
		int32_t L_16;
		L_16 = List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_inline(L_15, List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_RuntimeMethod_var);
		if ((((int32_t)L_16) <= ((int32_t)0)))
		{
			goto IL_0096;
		}
	}
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_17 = V_1;
		NullCheck(L_17);
		RuntimeObject* L_18;
		L_18 = List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147(L_17, 0, List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147_RuntimeMethod_var);
		RuntimeObject* L_19 = ___1_abortingEnlisted;
		if ((((RuntimeObject*)(RuntimeObject*)L_18) == ((RuntimeObject*)(RuntimeObject*)L_19)))
		{
			goto IL_0096;
		}
	}
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_20 = V_1;
		NullCheck(L_20);
		RuntimeObject* L_21;
		L_21 = List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147(L_20, 0, List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147_RuntimeMethod_var);
		SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* L_22 = V_0;
		NullCheck(L_21);
		InterfaceActionInvoker1< Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* >::Invoke(2 /* System.Void System.Transactions.IEnlistmentNotification::Rollback(System.Transactions.Enlistment) */, IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var, L_21, L_22);
	}

IL_0096:
	{
		RuntimeObject* L_23 = __this->___pspe_6;
		if (!L_23)
		{
			goto IL_00b3;
		}
	}
	{
		RuntimeObject* L_24 = __this->___pspe_6;
		RuntimeObject* L_25 = ___1_abortingEnlisted;
		if ((((RuntimeObject*)(RuntimeObject*)L_24) == ((RuntimeObject*)(RuntimeObject*)L_25)))
		{
			goto IL_00b3;
		}
	}
	{
		RuntimeObject* L_26 = __this->___pspe_6;
		SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* L_27 = V_0;
		NullCheck(L_26);
		InterfaceActionInvoker1< SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* >::Invoke(0 /* System.Void System.Transactions.IPromotableSinglePhaseNotification::Rollback(System.Transactions.SinglePhaseEnlistment) */, IPromotableSinglePhaseNotification_t55FA5C677628E609C73561E23A834E464F5B1321_il2cpp_TypeInfo_var, L_26, L_27);
	}

IL_00b3:
	{
		Transaction_set_Aborted_m24683739B6DC84AF5BEAF5E83C6ECA1D4B44BE17(__this, (bool)1, NULL);
		Transaction_FireCompleted_mD21E71C2CDB94A3F1ED8AEBD8F258C70F8210440(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::set_Aborted(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_set_Aborted_m24683739B6DC84AF5BEAF5E83C6ECA1D4B44BE17 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, bool ___0_value, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___0_value;
		__this->___aborted_9 = L_0;
		bool L_1 = __this->___aborted_9;
		if (!L_1)
		{
			goto IL_001b;
		}
	}
	{
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_2 = __this->___info_2;
		NullCheck(L_2);
		TransactionInformation_set_Status_m6D0E87BE8EDD80DC7AFD5A3CEC8E8EA4B1626AFE_inline(L_2, 2, NULL);
	}

IL_001b:
	{
		return;
	}
}
// System.Transactions.TransactionScope System.Transactions.Transaction::get_Scope()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_0 = __this->___scope_10;
		return L_0;
	}
}
// System.Void System.Transactions.Transaction::set_Scope(System.Transactions.TransactionScope)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* ___0_value, const RuntimeMethod* method) 
{
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_0 = ___0_value;
		__this->___scope_10 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___scope_10), (void*)L_0);
		return;
	}
}
// System.Void System.Transactions.Transaction::CommitInternal()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	Exception_t* V_0 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		bool L_0 = __this->___committed_8;
		if (L_0)
		{
			goto IL_0010;
		}
	}
	{
		bool L_1 = __this->___committing_7;
		if (!L_1)
		{
			goto IL_001b;
		}
	}

IL_0010:
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_2 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_2);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD41D80DA5EAC5279DC86938BA5757D74E331447D)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C_RuntimeMethod_var)));
	}

IL_001b:
	{
		__this->___committing_7 = (bool)1;
	}
	try
	{// begin try (depth: 1)
		Transaction_DoCommit_m3F3D8AC947B522A74307E790B58E3A5955C8EDBD(__this, NULL);
		goto IL_003a;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_002a;
		}
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_002d;
		}
		throw e;
	}

CATCH_002a:
	{// begin catch(System.Transactions.TransactionException)
		IL2CPP_RETHROW_MANAGED_EXCEPTION(IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
	}// end catch (depth: 1)

CATCH_002d:
	{// begin catch(System.Exception)
		V_0 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
		Exception_t* L_3 = V_0;
		TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* L_4 = (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		TransactionAbortedException__ctor_m9B248FC15B4187F9271081AF004DDFBA164C07B3(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral83A962F377FDA097D2DCADA8B2CE959C16EBEBB0)), L_3, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C_RuntimeMethod_var)));
	}// end catch (depth: 1)

IL_003a:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::DoCommit()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoCommit_m3F3D8AC947B522A74307E790B58E3A5955C8EDBD (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ISinglePhaseNotification_tA01F24695E100E9C38BC5009D1AFE7BF90296335_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_mDD09942EE453A07ECBA49A06DA6255870CB3E1E3_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* V_0 = NULL;
	List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* V_1 = NULL;
	RuntimeObject* V_2 = NULL;
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_0;
		L_0 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_0030;
		}
	}
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_1;
		L_1 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(__this, NULL);
		NullCheck(L_1);
		bool L_2;
		L_2 = TransactionScope_get_IsComplete_mA48470D9FFCC137101B3972C9B1D46ED5EC51C8C_inline(L_1, NULL);
		if (!L_2)
		{
			goto IL_0022;
		}
	}
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_3;
		L_3 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(__this, NULL);
		NullCheck(L_3);
		bool L_4;
		L_4 = TransactionScope_get_IsDisposed_mBE2D47F728A37F239A3C3AB0A1630A6BDB1F66F5_inline(L_3, NULL);
		if (L_4)
		{
			goto IL_0030;
		}
	}

IL_0022:
	{
		Transaction_Rollback_m298E5E20A30D81EFD61CC338DF07E9E3BA82C28D(__this, (Exception_t*)NULL, NULL, NULL);
		Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1(__this, NULL);
	}

IL_0030:
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_5;
		L_5 = Transaction_get_Volatiles_mCD1BF84C66655C8FD244A1F5578DD02DBED0129A(__this, NULL);
		V_0 = L_5;
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_6;
		L_6 = Transaction_get_Durables_mCFB83FC73DFCF3EBD3A758327D3EE835389566A3(__this, NULL);
		V_1 = L_6;
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_7 = V_0;
		NullCheck(L_7);
		int32_t L_8;
		L_8 = List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_inline(L_7, List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_RuntimeMethod_var);
		if ((!(((uint32_t)L_8) == ((uint32_t)1))))
		{
			goto IL_006d;
		}
	}
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_9 = V_1;
		NullCheck(L_9);
		int32_t L_10;
		L_10 = List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_inline(L_9, List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_RuntimeMethod_var);
		if (L_10)
		{
			goto IL_006d;
		}
	}
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_11 = V_0;
		NullCheck(L_11);
		RuntimeObject* L_12;
		L_12 = List_1_get_Item_mDD09942EE453A07ECBA49A06DA6255870CB3E1E3(L_11, 0, List_1_get_Item_mDD09942EE453A07ECBA49A06DA6255870CB3E1E3_RuntimeMethod_var);
		V_2 = ((RuntimeObject*)IsInst((RuntimeObject*)L_12, ISinglePhaseNotification_tA01F24695E100E9C38BC5009D1AFE7BF90296335_il2cpp_TypeInfo_var));
		RuntimeObject* L_13 = V_2;
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		RuntimeObject* L_14 = V_2;
		Transaction_DoSingleCommit_m63A77FAEE5B90B5B48BCCF58F778DEDA76DE1F5B(__this, L_14, NULL);
		Transaction_Complete_mEABE80EC6973F408138539E94FF7DF29A7D9E8A1(__this, NULL);
		return;
	}

IL_006d:
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_15 = V_0;
		NullCheck(L_15);
		int32_t L_16;
		L_16 = List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_inline(L_15, List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_RuntimeMethod_var);
		if ((((int32_t)L_16) <= ((int32_t)0)))
		{
			goto IL_007c;
		}
	}
	{
		Transaction_DoPreparePhase_m88ABEC8C24281671F33674AFD8DAA54755D39BDB(__this, NULL);
	}

IL_007c:
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_17 = V_1;
		NullCheck(L_17);
		int32_t L_18;
		L_18 = List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_inline(L_17, List_1_get_Count_m17E6803A26B094A16DC42F1F23438275606091C1_RuntimeMethod_var);
		if ((((int32_t)L_18) <= ((int32_t)0)))
		{
			goto IL_0092;
		}
	}
	{
		List_1_t151A1BC1807DD3664F9A0AD5F5D74FF992C57A4C* L_19 = V_1;
		NullCheck(L_19);
		RuntimeObject* L_20;
		L_20 = List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147(L_19, 0, List_1_get_Item_m81C246985A289579522B217404C0B8C99E5C0147_RuntimeMethod_var);
		Transaction_DoSingleCommit_m63A77FAEE5B90B5B48BCCF58F778DEDA76DE1F5B(__this, L_20, NULL);
	}

IL_0092:
	{
		RuntimeObject* L_21 = __this->___pspe_6;
		if (!L_21)
		{
			goto IL_00a6;
		}
	}
	{
		RuntimeObject* L_22 = __this->___pspe_6;
		Transaction_DoSingleCommit_m34351FBEBC8D263709545E67437859B156533A9E(__this, L_22, NULL);
	}

IL_00a6:
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_23 = V_0;
		NullCheck(L_23);
		int32_t L_24;
		L_24 = List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_inline(L_23, List_1_get_Count_m7F6318BC1C84BB21EF1E42D3FFD9F401802C9553_RuntimeMethod_var);
		if ((((int32_t)L_24) <= ((int32_t)0)))
		{
			goto IL_00b5;
		}
	}
	{
		Transaction_DoCommitPhase_mC0DC123CB7534B3AABF8522C81CFDDFFF8A512E1(__this, NULL);
	}

IL_00b5:
	{
		Transaction_Complete_mEABE80EC6973F408138539E94FF7DF29A7D9E8A1(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::Complete()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_Complete_mEABE80EC6973F408138539E94FF7DF29A7D9E8A1 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		__this->___committing_7 = (bool)0;
		__this->___committed_8 = (bool)1;
		bool L_0 = __this->___aborted_9;
		if (L_0)
		{
			goto IL_0022;
		}
	}
	{
		TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* L_1 = __this->___info_2;
		NullCheck(L_1);
		TransactionInformation_set_Status_m6D0E87BE8EDD80DC7AFD5A3CEC8E8EA4B1626AFE_inline(L_1, 1, NULL);
	}

IL_0022:
	{
		Transaction_FireCompleted_mD21E71C2CDB94A3F1ED8AEBD8F258C70F8210440(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::InitScope(System.Transactions.TransactionScope)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_InitScope_mF57A5705AAAC4B3EA7D8E3AA7F99F0BAE2145605 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* ___0_scope, const RuntimeMethod* method) 
{
	{
		Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1(__this, NULL);
		bool L_0 = __this->___committed_8;
		if (!L_0)
		{
			goto IL_0019;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_1 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_1);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral87104EDA2ADE7D066F82338C32E0CC6EA29AEE34)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_InitScope_mF57A5705AAAC4B3EA7D8E3AA7F99F0BAE2145605_RuntimeMethod_var)));
	}

IL_0019:
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_2 = ___0_scope;
		Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline(__this, L_2, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::PrepareCallbackWrapper(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_PrepareCallbackWrapper_mDCF9E2F62CFCA967ED59FF8A1398A4746E9B03E6 (RuntimeObject* ___0_state, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* V_0 = NULL;
	Exception_t* V_1 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		RuntimeObject* L_0 = ___0_state;
		V_0 = ((PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324*)IsInstClass((RuntimeObject*)L_0, PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324_il2cpp_TypeInfo_var));
	}
	try
	{// begin try (depth: 1)
		PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_1 = V_0;
		NullCheck(L_1);
		RuntimeObject* L_2;
		L_2 = PreparingEnlistment_get_EnlistmentNotification_m6E0C291F9F6A40FC43C4E215697980C93E345596_inline(L_1, NULL);
		PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_3 = V_0;
		NullCheck(L_2);
		InterfaceActionInvoker1< PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* >::Invoke(1 /* System.Void System.Transactions.IEnlistmentNotification::Prepare(System.Transactions.PreparingEnlistment) */, IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var, L_2, L_3);
		goto IL_0038;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0015;
		}
		throw e;
	}

CATCH_0015:
	{// begin catch(System.Exception)
		{
			V_1 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
			PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_4 = V_0;
			Exception_t* L_5 = V_1;
			NullCheck(L_4);
			PreparingEnlistment_set_Exception_m594BFBA84F1EED8E911AC573E9D2BFEFD6F8CBB8_inline(L_4, L_5, NULL);
			PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_6 = V_0;
			NullCheck(L_6);
			bool L_7;
			L_7 = PreparingEnlistment_get_IsPrepared_m446B89A1F1859453F9B570D7DDD61925800D3EB2_inline(L_6, NULL);
			if (L_7)
			{
				goto IL_0036;
			}
		}
		{
			PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_8 = V_0;
			NullCheck(L_8);
			WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* L_9;
			L_9 = PreparingEnlistment_get_WaitHandle_m97FAB47F8B5288954C6182F9459986DE97F4C0FB_inline(L_8, NULL);
			NullCheck(((ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158*)CastclassSealed((RuntimeObject*)L_9, ((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158_il2cpp_TypeInfo_var)))));
			bool L_10;
			L_10 = EventWaitHandle_Set_mDF98D67F214714A9590DF82A1C51D3D851281E4D(((ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158*)CastclassSealed((RuntimeObject*)L_9, ((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ManualResetEvent_t63959486AA41A113A4353D0BF4A68E77EBA0A158_il2cpp_TypeInfo_var)))), NULL);
		}

IL_0036:
		{
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_0038;
		}
	}// end catch (depth: 1)

IL_0038:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::DoPreparePhase()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoPreparePhase_m88ABEC8C24281671F33674AFD8DAA54755D39BDB (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction_PrepareCallbackWrapper_mDCF9E2F62CFCA967ED59FF8A1398A4746E9B03E6_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 V_0;
	memset((&V_0), 0, sizeof(V_0));
	RuntimeObject* V_1 = NULL;
	PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* V_2 = NULL;
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A V_3;
	memset((&V_3), 0, sizeof(V_3));
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A G_B5_0;
	memset((&G_B5_0), 0, sizeof(G_B5_0));
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_0;
		L_0 = Transaction_get_Volatiles_mCD1BF84C66655C8FD244A1F5578DD02DBED0129A(__this, NULL);
		NullCheck(L_0);
		Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 L_1;
		L_1 = List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367(L_0, List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367_RuntimeMethod_var);
		V_0 = L_1;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_00ac:
			{// begin finally (depth: 1)
				Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB((&V_0), Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB_RuntimeMethod_var);
				return;
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				goto IL_009e_1;
			}

IL_0011_1:
			{
				RuntimeObject* L_2;
				L_2 = Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_inline((&V_0), Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_RuntimeMethod_var);
				V_1 = L_2;
				RuntimeObject* L_3 = V_1;
				PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_4 = (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324*)il2cpp_codegen_object_new(PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324_il2cpp_TypeInfo_var);
				NullCheck(L_4);
				PreparingEnlistment__ctor_mA17634B83034CC29A385144E81D879A3B70053AE(L_4, __this, L_3, NULL);
				V_2 = L_4;
				WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3* L_5 = (WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3*)il2cpp_codegen_object_new(WaitCallback_tFB2C7FD58D024BBC2B0333DC7A4CB63B8DEBD5D3_il2cpp_TypeInfo_var);
				NullCheck(L_5);
				WaitCallback__ctor_m9730564F9A28ECB72462D05AA92CA9E43DE9B41C(L_5, NULL, (intptr_t)((void*)Transaction_PrepareCallbackWrapper_mDCF9E2F62CFCA967ED59FF8A1398A4746E9B03E6_RuntimeMethod_var), NULL);
				PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_6 = V_2;
				bool L_7;
				L_7 = ThreadPool_QueueUserWorkItem_mE534D14C47699D1D37288AE0710B19FC7EC02BAB(L_5, L_6, NULL);
				TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_8;
				L_8 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(__this, NULL);
				if (L_8)
				{
					goto IL_0043_1;
				}
			}
			{
				il2cpp_codegen_runtime_class_init_inline(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
				TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_9;
				L_9 = TransactionManager_get_DefaultTimeout_m986CEE04836E5DCF3328652175C50A276DD75E0F_inline(NULL);
				G_B5_0 = L_9;
				goto IL_004e_1;
			}

IL_0043_1:
			{
				TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_10;
				L_10 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(__this, NULL);
				NullCheck(L_10);
				TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_11;
				L_11 = TransactionScope_get_Timeout_mE3C1143951329A6EF6AA5E49A9DEE2F598EA26C3_inline(L_10, NULL);
				G_B5_0 = L_11;
			}

IL_004e_1:
			{
				V_3 = G_B5_0;
				PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_12 = V_2;
				NullCheck(L_12);
				WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* L_13;
				L_13 = PreparingEnlistment_get_WaitHandle_m97FAB47F8B5288954C6182F9459986DE97F4C0FB_inline(L_12, NULL);
				TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_14 = V_3;
				NullCheck(L_13);
				bool L_15;
				L_15 = VirtualFuncInvoker2< bool, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A, bool >::Invoke(11 /* System.Boolean System.Threading.WaitHandle::WaitOne(System.TimeSpan,System.Boolean) */, L_13, L_14, (bool)1);
				if (L_15)
				{
					goto IL_0070_1;
				}
			}
			{
				Transaction_set_Aborted_m24683739B6DC84AF5BEAF5E83C6ECA1D4B44BE17(__this, (bool)1, NULL);
				TimeoutException_t7552449BA7E0911AEA1B6C7D1BEAC6534819305F* L_16 = (TimeoutException_t7552449BA7E0911AEA1B6C7D1BEAC6534819305F*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TimeoutException_t7552449BA7E0911AEA1B6C7D1BEAC6534819305F_il2cpp_TypeInfo_var)));
				NullCheck(L_16);
				TimeoutException__ctor_mAC3BF713E7242641234A1E292C470655E1EFA964(L_16, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral6AB2BBD66829F3B447D944E2A6EEB9436AE7506E)), NULL);
				IL2CPP_RAISE_MANAGED_EXCEPTION(L_16, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_DoPreparePhase_m88ABEC8C24281671F33674AFD8DAA54755D39BDB_RuntimeMethod_var)));
			}

IL_0070_1:
			{
				PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_17 = V_2;
				NullCheck(L_17);
				Exception_t* L_18;
				L_18 = PreparingEnlistment_get_Exception_m61CD5819121927F3E76F17F0EAF69D7139429405_inline(L_17, NULL);
				if (!L_18)
				{
					goto IL_008d_1;
				}
			}
			{
				PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_19 = V_2;
				NullCheck(L_19);
				Exception_t* L_20;
				L_20 = PreparingEnlistment_get_Exception_m61CD5819121927F3E76F17F0EAF69D7139429405_inline(L_19, NULL);
				__this->___innerException_11 = L_20;
				Il2CppCodeGenWriteBarrier((void**)(&__this->___innerException_11), (void*)L_20);
				Transaction_set_Aborted_m24683739B6DC84AF5BEAF5E83C6ECA1D4B44BE17(__this, (bool)1, NULL);
				goto IL_00ba;
			}

IL_008d_1:
			{
				PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* L_21 = V_2;
				NullCheck(L_21);
				bool L_22;
				L_22 = PreparingEnlistment_get_IsPrepared_m446B89A1F1859453F9B570D7DDD61925800D3EB2_inline(L_21, NULL);
				if (L_22)
				{
					goto IL_009e_1;
				}
			}
			{
				Transaction_set_Aborted_m24683739B6DC84AF5BEAF5E83C6ECA1D4B44BE17(__this, (bool)1, NULL);
				goto IL_00ba;
			}

IL_009e_1:
			{
				bool L_23;
				L_23 = Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A((&V_0), Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A_RuntimeMethod_var);
				if (L_23)
				{
					goto IL_0011_1;
				}
			}
			{
				goto IL_00ba;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_00ba:
	{
		Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::DoCommitPhase()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoCommitPhase_mC0DC123CB7534B3AABF8522C81CFDDFFF8A512E1 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* V_1 = NULL;
	{
		List_1_t9F4F8EB487AD8634210B33C2FD40A9DB5604EDB3* L_0;
		L_0 = Transaction_get_Volatiles_mCD1BF84C66655C8FD244A1F5578DD02DBED0129A(__this, NULL);
		NullCheck(L_0);
		Enumerator_t99B22733591FFD9FAE27C9EFDB0DE1D3BFC99040 L_1;
		L_1 = List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367(L_0, List_1_GetEnumerator_mA6A172F9F86EADBD4F544B8289E71343B533E367_RuntimeMethod_var);
		V_0 = L_1;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_002c:
			{// begin finally (depth: 1)
				Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB((&V_0), Enumerator_Dispose_mDB1BBD5EEB58E2F4C09ED5E3A1840B1C4D60A1DB_RuntimeMethod_var);
				return;
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				goto IL_0021_1;
			}

IL_000e_1:
			{
				RuntimeObject* L_2;
				L_2 = Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_inline((&V_0), Enumerator_get_Current_m58D3F44C5938CA7235526999C2B9C068517BF822_RuntimeMethod_var);
				Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* L_3 = (Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552*)il2cpp_codegen_object_new(Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552_il2cpp_TypeInfo_var);
				NullCheck(L_3);
				Enlistment__ctor_m8A01B2DCBBE2F2BB4CD040581D0D3521A449583F(L_3, NULL);
				V_1 = L_3;
				Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* L_4 = V_1;
				NullCheck(L_2);
				InterfaceActionInvoker1< Enlistment_tDF858DEFBA405B6DF5EF4DC746A92C59DE007552* >::Invoke(0 /* System.Void System.Transactions.IEnlistmentNotification::Commit(System.Transactions.Enlistment) */, IEnlistmentNotification_tACB7F43A9D736E8B9F4045339E86D063B540EC66_il2cpp_TypeInfo_var, L_2, L_4);
			}

IL_0021_1:
			{
				bool L_5;
				L_5 = Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A((&V_0), Enumerator_MoveNext_mBD39361874346D0E2EE2AA7CE005113DE0A7312A_RuntimeMethod_var);
				if (L_5)
				{
					goto IL_000e_1;
				}
			}
			{
				goto IL_003a;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_003a:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.ISinglePhaseNotification)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m63A77FAEE5B90B5B48BCCF58F778DEDA76DE1F5B (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, RuntimeObject* ___0_single, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ISinglePhaseNotification_tA01F24695E100E9C38BC5009D1AFE7BF90296335_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___0_single;
		if (L_0)
		{
			goto IL_0004;
		}
	}
	{
		return;
	}

IL_0004:
	{
		RuntimeObject* L_1 = ___0_single;
		RuntimeObject* L_2 = ___0_single;
		SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* L_3 = (SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C*)il2cpp_codegen_object_new(SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C_il2cpp_TypeInfo_var);
		NullCheck(L_3);
		SinglePhaseEnlistment__ctor_mC0F13D08CCEB20FEE99855565546E171F82C5D0E(L_3, __this, L_2, NULL);
		NullCheck(L_1);
		InterfaceActionInvoker1< SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* >::Invoke(0 /* System.Void System.Transactions.ISinglePhaseNotification::SinglePhaseCommit(System.Transactions.SinglePhaseEnlistment) */, ISinglePhaseNotification_tA01F24695E100E9C38BC5009D1AFE7BF90296335_il2cpp_TypeInfo_var, L_1, L_3);
		Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.IPromotableSinglePhaseNotification)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m34351FBEBC8D263709545E67437859B156533A9E (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, RuntimeObject* ___0_single, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPromotableSinglePhaseNotification_t55FA5C677628E609C73561E23A834E464F5B1321_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___0_single;
		if (L_0)
		{
			goto IL_0004;
		}
	}
	{
		return;
	}

IL_0004:
	{
		RuntimeObject* L_1 = ___0_single;
		RuntimeObject* L_2 = ___0_single;
		SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* L_3 = (SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C*)il2cpp_codegen_object_new(SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C_il2cpp_TypeInfo_var);
		NullCheck(L_3);
		SinglePhaseEnlistment__ctor_mC0F13D08CCEB20FEE99855565546E171F82C5D0E(L_3, __this, L_2, NULL);
		NullCheck(L_1);
		InterfaceActionInvoker1< SinglePhaseEnlistment_t7AA936D444F929C7355B1D02E9A9B6B2B55D135C* >::Invoke(1 /* System.Void System.Transactions.IPromotableSinglePhaseNotification::SinglePhaseCommit(System.Transactions.SinglePhaseEnlistment) */, IPromotableSinglePhaseNotification_t55FA5C677628E609C73561E23A834E464F5B1321_il2cpp_TypeInfo_var, L_1, L_3);
		Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::CheckAborted()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___aborted_9;
		if (L_0)
		{
			goto IL_001d;
		}
	}
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_1;
		L_1 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(__this, NULL);
		if (!L_1)
		{
			goto IL_002e;
		}
	}
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_2;
		L_2 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(__this, NULL);
		NullCheck(L_2);
		bool L_3;
		L_3 = TransactionScope_get_IsAborted_mD768F94F9BB2B571D4ECA17EA6DBD0147261D301_inline(L_2, NULL);
		if (!L_3)
		{
			goto IL_002e;
		}
	}

IL_001d:
	{
		Exception_t* L_4 = __this->___innerException_11;
		TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* L_5 = (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF_il2cpp_TypeInfo_var)));
		NullCheck(L_5);
		TransactionAbortedException__ctor_m9B248FC15B4187F9271081AF004DDFBA164C07B3(L_5, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral2B3EB81375F9432101A9E05B2C117E92F4E7F833)), L_4, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_CheckAborted_m5C0D30286CB8F237BA79D6C1217813CBACB41AC1_RuntimeMethod_var)));
	}

IL_002e:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::FireCompleted()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_FireCompleted_mD21E71C2CDB94A3F1ED8AEBD8F258C70F8210440 (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* L_0 = __this->___TransactionCompletedInternal_13;
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* L_1 = __this->___TransactionCompletedInternal_13;
		TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* L_2 = (TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82*)il2cpp_codegen_object_new(TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		TransactionEventArgs__ctor_mDE16E072857474C6DD16928DB47058E2A9F98046(L_2, __this, NULL);
		NullCheck(L_1);
		TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_inline(L_1, __this, L_2, NULL);
	}

IL_001a:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::EnsureIncompleteCurrentScope()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction_EnsureIncompleteCurrentScope_m50358C964D025F5EAF27CC2F0D24229E86BBA031 (const RuntimeMethod* method) 
{
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0;
		L_0 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		bool L_1;
		L_1 = Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC(L_0, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_1)
		{
			goto IL_000e;
		}
	}
	{
		return;
	}

IL_000e:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_2;
		L_2 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		NullCheck(L_2);
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_3;
		L_3 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(L_2, NULL);
		if (!L_3)
		{
			goto IL_0036;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_4;
		L_4 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		NullCheck(L_4);
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_5;
		L_5 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(L_4, NULL);
		NullCheck(L_5);
		bool L_6;
		L_6 = TransactionScope_get_IsComplete_mA48470D9FFCC137101B3972C9B1D46ED5EC51C8C_inline(L_5, NULL);
		if (!L_6)
		{
			goto IL_0036;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_7 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_7);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_7, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0FCBD1BB0D5DDFC7C1E4FBDBC8880AC0B13F325)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Transaction_EnsureIncompleteCurrentScope_m50358C964D025F5EAF27CC2F0D24229E86BBA031_RuntimeMethod_var)));
	}

IL_0036:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transaction__ctor_mDF856DFDF7C245002C76F0B0E0AC7821B25E7ADC (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction__ctor_mDF856DFDF7C245002C76F0B0E0AC7821B25E7ADC_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_raise_profile_exception(Transaction__ctor_mDF856DFDF7C245002C76F0B0E0AC7821B25E7ADC_RuntimeMethod_var);
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
// System.Void System.Transactions.TransactionAbortedException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_mE17B5A4668B9FA43D669F0B3AB71E0F4402FF215 (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* __this, const RuntimeMethod* method) 
{
	{
		TransactionException__ctor_m3C29A3EB6D1A3AA42E78B96EF45C22CC1F8171BB(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_m1BD924B419534951343ED788F32737E432FE275C (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* __this, String_t* ___0_message, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_message;
		TransactionException__ctor_mD6A1BC6487DB3CE81488727A3D811024D45F8859(__this, L_0, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.String,System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_m9B248FC15B4187F9271081AF004DDFBA164C07B3 (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* __this, String_t* ___0_message, Exception_t* ___1_innerException, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_message;
		Exception_t* L_1 = ___1_innerException;
		TransactionException__ctor_m58CD66C4B381A0AF26F8EB9855908042A359B8BE(__this, L_0, L_1, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_m919C68C8C22EDE415D82081303D0E44D8E0B00D3 (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* __this, SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ___0_info, StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 ___1_context, const RuntimeMethod* method) 
{
	{
		SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* L_0 = ___0_info;
		StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 L_1 = ___1_context;
		TransactionException__ctor_m3FDD9AE8E185D636E05D9A9D83E738C6A63715E4(__this, L_0, L_1, NULL);
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
// System.Void System.Transactions.TransactionEventArgs::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_mFD81A5A7A11F8417373C43F9BEB03EAABF6B28B3 (TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377_il2cpp_TypeInfo_var);
		EventArgs__ctor_mC6F9412D03203ADEF854117542C8EBF61624C8C3(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionEventArgs::.ctor(System.Transactions.Transaction)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_mDE16E072857474C6DD16928DB47058E2A9F98046 (TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_transaction, const RuntimeMethod* method) 
{
	{
		TransactionEventArgs__ctor_mFD81A5A7A11F8417373C43F9BEB03EAABF6B28B3(__this, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_transaction;
		__this->___transaction_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___transaction_1), (void*)L_0);
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
// System.Void System.Transactions.TransactionException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_m3C29A3EB6D1A3AA42E78B96EF45C22CC1F8171BB (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, const RuntimeMethod* method) 
{
	{
		SystemException__ctor_mB30C3C4B8AB4DF43F4A453C97CCA76DC4AE63B80(__this, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_mD6A1BC6487DB3CE81488727A3D811024D45F8859 (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, String_t* ___0_message, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_message;
		SystemException__ctor_mC481DFD60F19362A0B3523FBD5E429EC4F1F3FB5(__this, L_0, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionException::.ctor(System.String,System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_m58CD66C4B381A0AF26F8EB9855908042A359B8BE (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, String_t* ___0_message, Exception_t* ___1_innerException, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_message;
		Exception_t* L_1 = ___1_innerException;
		SystemException__ctor_m0FC84CACD2A5D66222998AA601A5C41CEC36A611(__this, L_0, L_1, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionException__ctor_m3FDD9AE8E185D636E05D9A9D83E738C6A63715E4 (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* __this, SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ___0_info, StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 ___1_context, const RuntimeMethod* method) 
{
	{
		SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* L_0 = ___0_info;
		StreamingContext_t56760522A751890146EE45F82F866B55B7E33677 L_1 = ___1_context;
		SystemException__ctor_mA2BB392E0F4CD8A4C132984F76B7A9FBDB3B6879(__this, L_0, L_1, NULL);
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
// System.Void System.Transactions.TransactionInformation::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionInformation__ctor_m3961D2A87A4E85093413BB79F666FEA2A10F5269 (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Guid_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF9789EC5E59C155776C9BDFF4642FAB40304D870);
		s_Il2CppMethodInitialized = true;
	}
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D V_0;
	memset((&V_0), 0, sizeof(V_0));
	Guid_t V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_runtime_class_init_inline(Guid_t_il2cpp_TypeInfo_var);
		Guid_t L_0 = ((Guid_t_StaticFields*)il2cpp_codegen_static_fields_for(Guid_t_il2cpp_TypeInfo_var))->___Empty_0;
		__this->___dtcId_1 = L_0;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		__this->___status_3 = 0;
		il2cpp_codegen_runtime_class_init_inline(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_1;
		L_1 = DateTime_get_Now_m636CB9651A9099D20BA1CF813A0C69637317325C(NULL);
		V_0 = L_1;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_2;
		L_2 = DateTime_ToUniversalTime_m52CA1EAD0BE0A357BCACC38747ECA4A8810155A9((&V_0), NULL);
		__this->___creation_time_2 = L_2;
		Guid_t L_3;
		L_3 = Guid_NewGuid_m1F4894E8DC089811D6252148AD5858E58D43A7BD(NULL);
		V_1 = L_3;
		String_t* L_4;
		L_4 = Guid_ToString_m2BFFD5FA726E03FA707AAFCCF065896C46D5290C((&V_1), NULL);
		String_t* L_5;
		L_5 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(L_4, _stringLiteralF9789EC5E59C155776C9BDFF4642FAB40304D870, NULL);
		__this->___local_id_0 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___local_id_0), (void*)L_5);
		return;
	}
}
// System.Transactions.TransactionStatus System.Transactions.TransactionInformation::get_Status()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TransactionInformation_get_Status_mB45D34431DAC463611A59869926E98513B97414A (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___status_3;
		return L_0;
	}
}
// System.Void System.Transactions.TransactionInformation::set_Status(System.Transactions.TransactionStatus)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionInformation_set_Status_m6D0E87BE8EDD80DC7AFD5A3CEC8E8EA4B1626AFE (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___status_3 = L_0;
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
// System.Void System.Transactions.TransactionManager::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionManager__cctor_m4E4759360B22227816CDA61B5E775400B5D490C4 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0;
		memset((&L_0), 0, sizeof(L_0));
		TimeSpan__ctor_mF8B85616C009D35D860DA0254327E8AAF54822A1((&L_0), 0, 1, 0, /*hidden argument*/NULL);
		((TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_StaticFields*)il2cpp_codegen_static_fields_for(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var))->___defaultTimeout_0 = L_0;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_1;
		memset((&L_1), 0, sizeof(L_1));
		TimeSpan__ctor_mF8B85616C009D35D860DA0254327E8AAF54822A1((&L_1), 0, ((int32_t)10), 0, /*hidden argument*/NULL);
		((TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_StaticFields*)il2cpp_codegen_static_fields_for(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var))->___maxTimeout_1 = L_1;
		return;
	}
}
// System.TimeSpan System.Transactions.TransactionManager::get_DefaultTimeout()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TransactionManager_get_DefaultTimeout_m986CEE04836E5DCF3328652175C50A276DD75E0F (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0 = ((TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_StaticFields*)il2cpp_codegen_static_fields_for(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var))->___defaultTimeout_0;
		return L_0;
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
// System.Void System.Transactions.TransactionOptions::.ctor(System.Transactions.IsolationLevel,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionOptions__ctor_mB6E01EA3E9A536D3DD7518541B0A19791D044910 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, int32_t ___0_level, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_timeout, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_level;
		__this->___level_0 = L_0;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_1 = ___1_timeout;
		__this->___timeout_1 = L_1;
		return;
	}
}
IL2CPP_EXTERN_C  void TransactionOptions__ctor_mB6E01EA3E9A536D3DD7518541B0A19791D044910_AdjustorThunk (RuntimeObject* __this, int32_t ___0_level, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_timeout, const RuntimeMethod* method)
{
	TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*>(__this + _offset);
	TransactionOptions__ctor_mB6E01EA3E9A536D3DD7518541B0A19791D044910(_thisAdjusted, ___0_level, ___1_timeout, method);
}
// System.Transactions.IsolationLevel System.Transactions.TransactionOptions::get_IsolationLevel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TransactionOptions_get_IsolationLevel_m982A0A8E35EB6445ED55E47169297E9DAEA1C1A8 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___level_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t TransactionOptions_get_IsolationLevel_m982A0A8E35EB6445ED55E47169297E9DAEA1C1A8_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = TransactionOptions_get_IsolationLevel_m982A0A8E35EB6445ED55E47169297E9DAEA1C1A8_inline(_thisAdjusted, method);
	return _returnValue;
}
// System.Boolean System.Transactions.TransactionOptions::op_Equality(System.Transactions.TransactionOptions,System.Transactions.TransactionOptions)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TransactionOptions_op_Equality_m5B9B64DE16F3F0C7BBDE6C6201B59679B90E6C97 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___0_x, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___1_y, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_0 = ___0_x;
		int32_t L_1 = L_0.___level_0;
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_2 = ___1_y;
		int32_t L_3 = L_2.___level_0;
		if ((!(((uint32_t)L_1) == ((uint32_t)L_3))))
		{
			goto IL_0020;
		}
	}
	{
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_4 = ___0_x;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_5 = L_4.___timeout_1;
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_6 = ___1_y;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_7 = L_6.___timeout_1;
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		bool L_8;
		L_8 = TimeSpan_op_Equality_m951689F806957B14F237DAFCEE4CB322799A723E(L_5, L_7, NULL);
		return L_8;
	}

IL_0020:
	{
		return (bool)0;
	}
}
// System.Boolean System.Transactions.TransactionOptions::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TransactionOptions_Equals_m6E5D4EFB290F14239D57B0C7D364109797600E48 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___0_obj;
		if (((RuntimeObject*)IsInstSealed((RuntimeObject*)L_0, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD_il2cpp_TypeInfo_var)))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_1 = (*(TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*)__this);
		RuntimeObject* L_2 = ___0_obj;
		bool L_3;
		L_3 = TransactionOptions_op_Equality_m5B9B64DE16F3F0C7BBDE6C6201B59679B90E6C97(L_1, ((*(TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*)((TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*)(TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*)UnBox(L_2, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD_il2cpp_TypeInfo_var)))), NULL);
		return L_3;
	}
}
IL2CPP_EXTERN_C  bool TransactionOptions_Equals_m6E5D4EFB290F14239D57B0C7D364109797600E48_AdjustorThunk (RuntimeObject* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method)
{
	TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*>(__this + _offset);
	bool _returnValue;
	_returnValue = TransactionOptions_Equals_m6E5D4EFB290F14239D57B0C7D364109797600E48(_thisAdjusted, ___0_obj, method);
	return _returnValue;
}
// System.Int32 System.Transactions.TransactionOptions::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t TransactionOptions_GetHashCode_mD8274DC4F6F15118D764DB6D0043BB82AD162234 (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = __this->___level_0;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_1 = (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)(&__this->___timeout_1);
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		int32_t L_2;
		L_2 = TimeSpan_GetHashCode_m2CBBAD27522E17FE6006390ED0E3874676CAA76D(L_1, NULL);
		return ((int32_t)((int32_t)L_0^L_2));
	}
}
IL2CPP_EXTERN_C  int32_t TransactionOptions_GetHashCode_mD8274DC4F6F15118D764DB6D0043BB82AD162234_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = TransactionOptions_GetHashCode_mD8274DC4F6F15118D764DB6D0043BB82AD162234(_thisAdjusted, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionScope::.ctor(System.Transactions.TransactionScopeOption)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope__ctor_m7BC17C37287AEA34CB908DFF581E6BF3D7A2DFB9 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, int32_t ___0_scopeOption, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___0_scopeOption;
		il2cpp_codegen_runtime_class_init_inline(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_1;
		L_1 = TransactionManager_get_DefaultTimeout_m986CEE04836E5DCF3328652175C50A276DD75E0F_inline(NULL);
		TransactionScope__ctor_m121A69F29EE98C0EB203A32251D1F92035C8BECA(__this, L_0, L_1, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionScope::.ctor(System.Transactions.TransactionScopeOption,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope__ctor_m121A69F29EE98C0EB203A32251D1F92035C8BECA (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, int32_t ___0_scopeOption, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_scopeTimeout, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_scopeOption;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_1 = ___1_scopeTimeout;
		TransactionScope__ctor_mE97A059D5990400B94665193FFB5D1DCBA361AA4(__this, L_0, L_1, 0, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionScope::.ctor(System.Transactions.TransactionScopeOption,System.TimeSpan,System.Transactions.TransactionScopeAsyncFlowOption)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope__ctor_mE97A059D5990400B94665193FFB5D1DCBA361AA4 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, int32_t ___0_scopeOption, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___1_scopeTimeout, int32_t ___2_asyncFlow, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_scopeOption;
		il2cpp_codegen_runtime_class_init_inline(TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var);
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_1 = ((TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_StaticFields*)il2cpp_codegen_static_fields_for(TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var))->___defaultOptions_0;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_2 = ___1_scopeTimeout;
		int32_t L_3 = ___2_asyncFlow;
		TransactionScope_Initialize_mED0CFC28756E181F5C5175B85A2F0788F866FB8B(__this, L_0, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, L_1, 0, L_2, L_3, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionScope::Initialize(System.Transactions.TransactionScopeOption,System.Transactions.Transaction,System.Transactions.TransactionOptions,System.Transactions.EnterpriseServicesInteropOption,System.TimeSpan,System.Transactions.TransactionScopeAsyncFlowOption)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope_Initialize_mED0CFC28756E181F5C5175B85A2F0788F866FB8B (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, int32_t ___0_scopeOption, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___1_tx, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___2_options, int32_t ___3_interop, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___4_scopeTimeout, int32_t ___5_asyncFlow, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionScope_TimerCallback_mF0837984321FE50ADD6CD2EBB3FB3F35CF058185_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* V_0 = NULL;
	{
		__this->___completed_8 = (bool)0;
		__this->___isRoot_10 = (bool)0;
		__this->___nested_6 = 0;
		int32_t L_0 = ___5_asyncFlow;
		__this->___asyncFlowEnabled_11 = (bool)((((int32_t)L_0) == ((int32_t)1))? 1 : 0);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_1 = ___4_scopeTimeout;
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_2 = ((TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_StaticFields*)il2cpp_codegen_static_fields_for(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var))->___Zero_19;
		bool L_3;
		L_3 = TimeSpan_op_LessThan_m91C76FBEB38D80680A92A5FACA3A93810349B0FF(L_1, L_2, NULL);
		if (!L_3)
		{
			goto IL_0039;
		}
	}
	{
		ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F* L_4 = (ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		ArgumentOutOfRangeException__ctor_mBC1D5DEEA1BA41DE77228CB27D6BAFEB6DCCBF4A(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE6CD40D15D8228A3C4A01FAEB721E097AD1C590A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionScope_Initialize_mED0CFC28756E181F5C5175B85A2F0788F866FB8B_RuntimeMethod_var)));
	}

IL_0039:
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_5 = ___4_scopeTimeout;
		__this->___timeout_5 = L_5;
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_6;
		L_6 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		__this->___oldTransaction_3 = L_6;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___oldTransaction_3), (void*)L_6);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_7 = ___1_tx;
		int32_t L_8 = ___0_scopeOption;
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_9 = ___2_options;
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_10;
		L_10 = TransactionScope_InitTransaction_m40CC584915151A844FF7EF591034F6150705CEB6(__this, L_7, L_8, L_9, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_11 = L_10;
		V_0 = L_11;
		__this->___transaction_2 = L_11;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___transaction_2), (void*)L_11);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_12 = V_0;
		Transaction_set_CurrentInternal_mB1E7D608782C542652C5FAD9D72BA73CB6558565_inline(L_12, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_13 = __this->___transaction_2;
		bool L_14;
		L_14 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_13, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_14)
		{
			goto IL_007d;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_15 = __this->___transaction_2;
		NullCheck(L_15);
		Transaction_InitScope_mF57A5705AAAC4B3EA7D8E3AA7F99F0BAE2145605(L_15, __this, NULL);
	}

IL_007d:
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_16 = __this->___parentScope_4;
		if (!L_16)
		{
			goto IL_0098;
		}
	}
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_17 = __this->___parentScope_4;
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_18 = L_17;
		NullCheck(L_18);
		int32_t L_19 = L_18->___nested_6;
		NullCheck(L_18);
		L_18->___nested_6 = ((int32_t)il2cpp_codegen_add(L_19, 1));
	}

IL_0098:
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_20 = __this->___timeout_5;
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_21 = ((TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_StaticFields*)il2cpp_codegen_static_fields_for(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var))->___Zero_19;
		bool L_22;
		L_22 = TimeSpan_op_Inequality_m2248419A8BCC8744CADE25174238B24AE34F17DB(L_20, L_21, NULL);
		if (!L_22)
		{
			goto IL_00c9;
		}
	}
	{
		TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD* L_23 = (TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD*)il2cpp_codegen_object_new(TimerCallback_t7455CAFACC7054E62879920AFC84C5DA98B8C7CD_il2cpp_TypeInfo_var);
		NullCheck(L_23);
		TimerCallback__ctor_mDA748EAAD184861871872C3B672A848AEF2A1E4A(L_23, NULL, (intptr_t)((void*)TransactionScope_TimerCallback_mF0837984321FE50ADD6CD2EBB3FB3F35CF058185_RuntimeMethod_var), NULL);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_24 = ___4_scopeTimeout;
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_25 = ((TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_StaticFields*)il2cpp_codegen_static_fields_for(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var))->___Zero_19;
		Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00* L_26 = (Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00*)il2cpp_codegen_object_new(Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00_il2cpp_TypeInfo_var);
		NullCheck(L_26);
		Timer__ctor_m55493ADD5358606EC599394E7614E3D0186A731C(L_26, L_23, __this, L_24, L_25, NULL);
		__this->___scopeTimer_1 = L_26;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___scopeTimer_1), (void*)L_26);
	}

IL_00c9:
	{
		return;
	}
}
// System.Void System.Transactions.TransactionScope::TimerCallback(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope_TimerCallback_mF0837984321FE50ADD6CD2EBB3FB3F35CF058185 (RuntimeObject* ___0_state, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* V_0 = NULL;
	{
		RuntimeObject* L_0 = ___0_state;
		V_0 = ((TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4*)IsInstSealed((RuntimeObject*)L_0, TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var));
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_1 = V_0;
		if (L_1)
		{
			goto IL_0016;
		}
	}
	{
		TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF* L_2 = (TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF_il2cpp_TypeInfo_var)));
		NullCheck(L_2);
		TransactionException__ctor_m58CD66C4B381A0AF26F8EB9855908042A359B8BE(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF781F2380A4ED1A562E1441F123A21E9DBCE41D3)), (Exception_t*)NULL, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionScope_TimerCallback_mF0837984321FE50ADD6CD2EBB3FB3F35CF058185_RuntimeMethod_var)));
	}

IL_0016:
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_3 = V_0;
		NullCheck(L_3);
		TransactionScope_TimeoutScope_m8E692F04DF810A9681D0B03948CE632F55B2A995(L_3, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionScope::TimeoutScope()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope_TimeoutScope_m8E692F04DF810A9681D0B03948CE632F55B2A995 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		bool L_0 = __this->___completed_8;
		if (L_0)
		{
			goto IL_0030;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_1 = __this->___transaction_2;
		bool L_2;
		L_2 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_1, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_2)
		{
			goto IL_0030;
		}
	}
	try
	{// begin try (depth: 1)
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_3 = __this->___transaction_2;
		NullCheck(L_3);
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(L_3, NULL);
		__this->___aborted_9 = (bool)1;
		goto IL_0030;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_002a;
		}
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionException_t93E8D757BC2F2616DA953B8A714A645EBCE730AF_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_002d;
		}
		throw e;
	}

CATCH_002a:
	{// begin catch(System.ObjectDisposedException)
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0030;
	}// end catch (depth: 1)

CATCH_002d:
	{// begin catch(System.Transactions.TransactionException)
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0030;
	}// end catch (depth: 1)

IL_0030:
	{
		return;
	}
}
// System.Transactions.Transaction System.Transactions.TransactionScope::InitTransaction(System.Transactions.Transaction,System.Transactions.TransactionScopeOption,System.Transactions.TransactionOptions)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* TransactionScope_InitTransaction_m40CC584915151A844FF7EF591034F6150705CEB6 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_tx, int32_t ___1_scopeOption, TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD ___2_options, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_tx;
		bool L_1;
		L_1 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_0, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_1)
		{
			goto IL_000b;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_2 = ___0_tx;
		return L_2;
	}

IL_000b:
	{
		int32_t L_3 = ___1_scopeOption;
		if ((!(((uint32_t)L_3) == ((uint32_t)2))))
		{
			goto IL_002e;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_4;
		L_4 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		bool L_5;
		L_5 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_4, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_5)
		{
			goto IL_002c;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_6;
		L_6 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		NullCheck(L_6);
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_7;
		L_7 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(L_6, NULL);
		__this->___parentScope_4 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___parentScope_4), (void*)L_7);
	}

IL_002c:
	{
		return (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL;
	}

IL_002e:
	{
		int32_t L_8 = ___1_scopeOption;
		if (L_8)
		{
			goto IL_0068;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_9;
		L_9 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		bool L_10;
		L_10 = Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC(L_9, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_10)
		{
			goto IL_0052;
		}
	}
	{
		__this->___isRoot_10 = (bool)1;
		int32_t L_11;
		L_11 = TransactionOptions_get_IsolationLevel_m982A0A8E35EB6445ED55E47169297E9DAEA1C1A8_inline((&___2_options), NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_12 = (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)il2cpp_codegen_object_new(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		NullCheck(L_12);
		Transaction__ctor_m943B558863FECAEF52EE040D675C974230CB52E9(L_12, L_11, NULL);
		return L_12;
	}

IL_0052:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_13;
		L_13 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		NullCheck(L_13);
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_14;
		L_14 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(L_13, NULL);
		__this->___parentScope_4 = L_14;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___parentScope_4), (void*)L_14);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_15;
		L_15 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		return L_15;
	}

IL_0068:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_16;
		L_16 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		bool L_17;
		L_17 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_16, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_17)
		{
			goto IL_0085;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_18;
		L_18 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		NullCheck(L_18);
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_19;
		L_19 = Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline(L_18, NULL);
		__this->___parentScope_4 = L_19;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___parentScope_4), (void*)L_19);
	}

IL_0085:
	{
		__this->___isRoot_10 = (bool)1;
		int32_t L_20;
		L_20 = TransactionOptions_get_IsolationLevel_m982A0A8E35EB6445ED55E47169297E9DAEA1C1A8_inline((&___2_options), NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_21 = (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)il2cpp_codegen_object_new(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		NullCheck(L_21);
		Transaction__ctor_m943B558863FECAEF52EE040D675C974230CB52E9(L_21, L_20, NULL);
		return L_21;
	}
}
// System.Void System.Transactions.TransactionScope::Complete()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope_Complete_m58458AAD462903EAD152D08813D8AA2CEB74AB2C (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___completed_8;
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_1 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_1);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralDD00274E883EE073F2E90CCF5B0E850F5BA98E95)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionScope_Complete_m58458AAD462903EAD152D08813D8AA2CEB74AB2C_RuntimeMethod_var)));
	}

IL_0013:
	{
		__this->___completed_8 = (bool)1;
		return;
	}
}
// System.Boolean System.Transactions.TransactionScope::get_IsAborted()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TransactionScope_get_IsAborted_mD768F94F9BB2B571D4ECA17EA6DBD0147261D301 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___aborted_9;
		return L_0;
	}
}
// System.Boolean System.Transactions.TransactionScope::get_IsDisposed()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TransactionScope_get_IsDisposed_mBE2D47F728A37F239A3C3AB0A1630A6BDB1F66F5 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___disposed_7;
		return L_0;
	}
}
// System.Boolean System.Transactions.TransactionScope::get_IsComplete()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TransactionScope_get_IsComplete_mA48470D9FFCC137101B3972C9B1D46ED5EC51C8C (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___completed_8;
		return L_0;
	}
}
// System.TimeSpan System.Transactions.TransactionScope::get_Timeout()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TransactionScope_get_Timeout_mE3C1143951329A6EF6AA5E49A9DEE2F598EA26C3 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0 = __this->___timeout_5;
		return L_0;
	}
}
// System.Void System.Transactions.TransactionScope::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope_Dispose_m69C2C2B57EB8CADA3A3D763EADA27E2F27DD1CB4 (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* V_0 = NULL;
	{
		bool L_0 = __this->___disposed_7;
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		return;
	}

IL_0009:
	{
		__this->___disposed_7 = (bool)1;
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_1 = __this->___parentScope_4;
		if (!L_1)
		{
			goto IL_002b;
		}
	}
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_2 = __this->___parentScope_4;
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_3 = L_2;
		NullCheck(L_3);
		int32_t L_4 = L_3->___nested_6;
		NullCheck(L_3);
		L_3->___nested_6 = ((int32_t)il2cpp_codegen_subtract(L_4, 1));
	}

IL_002b:
	{
		int32_t L_5 = __this->___nested_6;
		if ((((int32_t)L_5) <= ((int32_t)0)))
		{
			goto IL_004a;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_6 = __this->___transaction_2;
		NullCheck(L_6);
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(L_6, NULL);
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_7 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_7);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_7, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral7DB2A4D5C9EB86ADA8CB0DD94ECFAFBBD8333BDA)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionScope_Dispose_m69C2C2B57EB8CADA3A3D763EADA27E2F27DD1CB4_RuntimeMethod_var)));
	}

IL_004a:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_8;
		L_8 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_9 = __this->___transaction_2;
		bool L_10;
		L_10 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_8, L_9, NULL);
		if (!L_10)
		{
			goto IL_009f;
		}
	}
	{
		bool L_11 = __this->___asyncFlowEnabled_11;
		if (L_11)
		{
			goto IL_009f;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_12 = __this->___transaction_2;
		bool L_13;
		L_13 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_12, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_13)
		{
			goto IL_007d;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_14 = __this->___transaction_2;
		NullCheck(L_14);
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(L_14, NULL);
	}

IL_007d:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_15;
		L_15 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		bool L_16;
		L_16 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_15, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_16)
		{
			goto IL_0094;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_17;
		L_17 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		NullCheck(L_17);
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(L_17, NULL);
	}

IL_0094:
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_18 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_18);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_18, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF3F20C515F1F87C09E46BECFD63FFE9AFF0DCF8C)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_18, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionScope_Dispose_m69C2C2B57EB8CADA3A3D763EADA27E2F27DD1CB4_RuntimeMethod_var)));
	}

IL_009f:
	{
		Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00* L_19 = __this->___scopeTimer_1;
		if (!L_19)
		{
			goto IL_00b2;
		}
	}
	{
		Timer_t763C1D5F5A36087DC92C7DA4D1F8AB578F83AB00* L_20 = __this->___scopeTimer_1;
		NullCheck(L_20);
		Timer_Dispose_m75A06B0748FE7958C296A5E39849A0FB6EA03C86(L_20, NULL);
	}

IL_00b2:
	{
		bool L_21 = __this->___asyncFlowEnabled_11;
		if (!L_21)
		{
			goto IL_0165;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_22 = __this->___oldTransaction_3;
		bool L_23;
		L_23 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_22, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_23)
		{
			goto IL_00dc;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_24 = __this->___oldTransaction_3;
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_25 = __this->___parentScope_4;
		NullCheck(L_24);
		Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline(L_24, L_25, NULL);
	}

IL_00dc:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_26;
		L_26 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		V_0 = L_26;
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_27 = __this->___transaction_2;
		bool L_28;
		L_28 = Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC(L_27, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_28)
		{
			goto IL_00fa;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_29 = V_0;
		bool L_30;
		L_30 = Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC(L_29, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_30)
		{
			goto IL_00fa;
		}
	}
	{
		return;
	}

IL_00fa:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_31 = V_0;
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_32 = __this->___parentScope_4;
		NullCheck(L_31);
		Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline(L_31, L_32, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_33 = __this->___oldTransaction_3;
		Transaction_set_CurrentInternal_mB1E7D608782C542652C5FAD9D72BA73CB6558565_inline(L_33, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_34 = __this->___transaction_2;
		NullCheck(L_34);
		Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline(L_34, (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4*)NULL, NULL);
		bool L_35;
		L_35 = TransactionScope_get_IsAborted_mD768F94F9BB2B571D4ECA17EA6DBD0147261D301_inline(__this, NULL);
		if (!L_35)
		{
			goto IL_0130;
		}
	}
	{
		TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* L_36 = (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF_il2cpp_TypeInfo_var)));
		NullCheck(L_36);
		TransactionAbortedException__ctor_m1BD924B419534951343ED788F32737E432FE275C(L_36, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral2B3EB81375F9432101A9E05B2C117E92F4E7F833)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_36, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionScope_Dispose_m69C2C2B57EB8CADA3A3D763EADA27E2F27DD1CB4_RuntimeMethod_var)));
	}

IL_0130:
	{
		bool L_37;
		L_37 = TransactionScope_get_IsComplete_mA48470D9FFCC137101B3972C9B1D46ED5EC51C8C_inline(__this, NULL);
		if (L_37)
		{
			goto IL_014a;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_38 = __this->___transaction_2;
		NullCheck(L_38);
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(L_38, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_39 = V_0;
		NullCheck(L_39);
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(L_39, NULL);
		return;
	}

IL_014a:
	{
		bool L_40 = __this->___isRoot_10;
		if (L_40)
		{
			goto IL_0153;
		}
	}
	{
		return;
	}

IL_0153:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_41 = V_0;
		NullCheck(L_41);
		Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C(L_41, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_42 = __this->___transaction_2;
		NullCheck(L_42);
		Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C(L_42, NULL);
		return;
	}

IL_0165:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_43;
		L_43 = Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline(NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_44 = __this->___oldTransaction_3;
		bool L_45;
		L_45 = Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC(L_43, L_44, NULL);
		if (!L_45)
		{
			goto IL_0196;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_46 = __this->___oldTransaction_3;
		bool L_47;
		L_47 = Transaction_op_Inequality_mDDF0206373667C46B4E753596C1C0F1CC1DD730D(L_46, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_47)
		{
			goto IL_0196;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_48 = __this->___oldTransaction_3;
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_49 = __this->___parentScope_4;
		NullCheck(L_48);
		Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline(L_48, L_49, NULL);
	}

IL_0196:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_50 = __this->___oldTransaction_3;
		Transaction_set_CurrentInternal_mB1E7D608782C542652C5FAD9D72BA73CB6558565_inline(L_50, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_51 = __this->___transaction_2;
		bool L_52;
		L_52 = Transaction_op_Equality_m39B1A486DD944290954B17E02B0BFBDC248659BC(L_51, (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD*)NULL, NULL);
		if (!L_52)
		{
			goto IL_01b0;
		}
	}
	{
		return;
	}

IL_01b0:
	{
		bool L_53;
		L_53 = TransactionScope_get_IsAborted_mD768F94F9BB2B571D4ECA17EA6DBD0147261D301_inline(__this, NULL);
		if (!L_53)
		{
			goto IL_01cf;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_54 = __this->___transaction_2;
		NullCheck(L_54);
		Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline(L_54, (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4*)NULL, NULL);
		TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF* L_55 = (TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionAbortedException_t8B92520C5347AA8E944F570573B9D799C2769FAF_il2cpp_TypeInfo_var)));
		NullCheck(L_55);
		TransactionAbortedException__ctor_m1BD924B419534951343ED788F32737E432FE275C(L_55, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral2B3EB81375F9432101A9E05B2C117E92F4E7F833)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_55, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransactionScope_Dispose_m69C2C2B57EB8CADA3A3D763EADA27E2F27DD1CB4_RuntimeMethod_var)));
	}

IL_01cf:
	{
		bool L_56;
		L_56 = TransactionScope_get_IsComplete_mA48470D9FFCC137101B3972C9B1D46ED5EC51C8C_inline(__this, NULL);
		if (L_56)
		{
			goto IL_01e3;
		}
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_57 = __this->___transaction_2;
		NullCheck(L_57);
		Transaction_Rollback_m700FBC7080668AD032FCDA055719E100117F14B5(L_57, NULL);
		return;
	}

IL_01e3:
	{
		bool L_58 = __this->___isRoot_10;
		if (L_58)
		{
			goto IL_01ec;
		}
	}
	{
		return;
	}

IL_01ec:
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_59 = __this->___transaction_2;
		NullCheck(L_59);
		Transaction_CommitInternal_mEF66B574C2B76332360FC50769C5F34DD77B106C(L_59, NULL);
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_60 = __this->___transaction_2;
		NullCheck(L_60);
		Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline(L_60, (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4*)NULL, NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionScope::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TransactionScope__cctor_m3EFA247165D4145B3459A1B3D476309A6D5DCB48 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0;
		L_0 = TransactionManager_get_DefaultTimeout_m986CEE04836E5DCF3328652175C50A276DD75E0F_inline(NULL);
		TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD L_1;
		memset((&L_1), 0, sizeof(L_1));
		TransactionOptions__ctor_mB6E01EA3E9A536D3DD7518541B0A19791D044910((&L_1), 0, L_0, /*hidden argument*/NULL);
		((TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_StaticFields*)il2cpp_codegen_static_fields_for(TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4_il2cpp_TypeInfo_var))->___defaultOptions_0 = L_1;
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
// System.Void Unity.ThrowStub::ThrowNotSupportedException()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ThrowStub_ThrowNotSupportedException_m53C3B333318540135E1FEA2D1ADAD8EC68844340 (const RuntimeMethod* method) 
{
	{
		PlatformNotSupportedException_tD2BD7EB9278518AA5FE8AE75AD5D0D4298A4631A* L_0 = (PlatformNotSupportedException_tD2BD7EB9278518AA5FE8AE75AD5D0D4298A4631A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&PlatformNotSupportedException_tD2BD7EB9278518AA5FE8AE75AD5D0D4298A4631A_il2cpp_TypeInfo_var)));
		NullCheck(L_0);
		PlatformNotSupportedException__ctor_mD5DBE8E9A6FF4B75EF02671029C6D67A51EAFBD1(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ThrowStub_ThrowNotSupportedException_m53C3B333318540135E1FEA2D1ADAD8EC68844340_RuntimeMethod_var)));
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TransactionInformation_get_Status_mB45D34431DAC463611A59869926E98513B97414A_inline (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___status_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TransactionInformation_set_Status_m6D0E87BE8EDD80DC7AFD5A3CEC8E8EA4B1626AFE_inline (TransactionInformation_tFB7D26BBE9CEB8F44CAC3930B739922628AD17EA* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___status_3 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* Transaction_get_Scope_mCB49E7F6BABD63238A74D8C3D08B7267B01CFB8E_inline (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, const RuntimeMethod* method) 
{
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_0 = __this->___scope_10;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TransactionScope_get_IsComplete_mA48470D9FFCC137101B3972C9B1D46ED5EC51C8C_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___completed_8;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TransactionScope_get_IsDisposed_mBE2D47F728A37F239A3C3AB0A1630A6BDB1F66F5_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___disposed_7;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Transaction_set_Scope_m3F7C7232708366E1B07363353D8FD84CCA40611E_inline (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* __this, TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* ___0_value, const RuntimeMethod* method) 
{
	{
		TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* L_0 = ___0_value;
		__this->___scope_10 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___scope_10), (void*)L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* PreparingEnlistment_get_EnlistmentNotification_m6E0C291F9F6A40FC43C4E215697980C93E345596_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___enlisted_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PreparingEnlistment_set_Exception_m594BFBA84F1EED8E911AC573E9D2BFEFD6F8CBB8_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, Exception_t* ___0_value, const RuntimeMethod* method) 
{
	{
		Exception_t* L_0 = ___0_value;
		__this->___ex_5 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ex_5), (void*)L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PreparingEnlistment_get_IsPrepared_m446B89A1F1859453F9B570D7DDD61925800D3EB2_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___prepared_1;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* PreparingEnlistment_get_WaitHandle_m97FAB47F8B5288954C6182F9459986DE97F4C0FB_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		WaitHandle_t08F8DB54593B241FE32E0DD0BD3D82785D3AE3D8* L_0 = __this->___waitHandle_4;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TransactionManager_get_DefaultTimeout_m986CEE04836E5DCF3328652175C50A276DD75E0F_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0 = ((TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_StaticFields*)il2cpp_codegen_static_fields_for(TransactionManager_t66CE9AFC4ED0943EF1DAC0186B32D84DBF39EA98_il2cpp_TypeInfo_var))->___defaultTimeout_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TransactionScope_get_Timeout_mE3C1143951329A6EF6AA5E49A9DEE2F598EA26C3_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0 = __this->___timeout_5;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Exception_t* PreparingEnlistment_get_Exception_m61CD5819121927F3E76F17F0EAF69D7139429405_inline (PreparingEnlistment_tA7578C13EDB71108E45B5AABCEFFB0E11705F324* __this, const RuntimeMethod* method) 
{
	{
		Exception_t* L_0 = __this->___ex_5;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TransactionScope_get_IsAborted_mD768F94F9BB2B571D4ECA17EA6DBD0147261D301_inline (TransactionScope_tB6032DAC900A60B7BC491532717C3707414B9BC4* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___aborted_9;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler_Invoke_mBFD780E1344550FC207E7DC648CE87AD1BF5E08D_inline (TransactionCompletedEventHandler_tE63F4C59FFEDF5500FAD819D585CBCAE192CE3DB* __this, RuntimeObject* ___0_sender, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82* ___1_e, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, TransactionEventArgs_t061FE4DA10D8A039736DB2C1A8ACB37D856FAD82*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___0_sender, ___1_e, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* Transaction_get_CurrentInternal_m195CAC9933D30007BD941BF68FA56CE0C7C7FBEE_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ((Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var))->___ambient_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TransactionOptions_get_IsolationLevel_m982A0A8E35EB6445ED55E47169297E9DAEA1C1A8_inline (TransactionOptions_tF977EA80CD543D25883B20A41B8EBAD0E39D21AD* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___level_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Transaction_set_CurrentInternal_mB1E7D608782C542652C5FAD9D72BA73CB6558565_inline (Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD* L_0 = ___0_value;
		((Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var))->___ambient_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tB36D4D179023FCFA37362B3BC0C4DC533D2EE1AD_il2cpp_TypeInfo_var))->___ambient_0), (void*)L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* Enumerator_get_Current_m6330F15D18EE4F547C05DF9BF83C5EB710376027_gshared_inline (Enumerator_t9473BAB568A27E2339D48C1F91319E0F6D244D7A* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->____current_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____size_2;
		return L_0;
	}
}
