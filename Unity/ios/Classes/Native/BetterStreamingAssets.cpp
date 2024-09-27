#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


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

// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
// System.Char[]
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// System.IO.IOException
struct IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// System.String
struct String_t;
// System.Text.StringBuilder
struct StringBuilder_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Path_t8A38A801D0219E8209C1B1D90D82D4D755D998BC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* StringBuilder_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral15063F649207A4502DFEDF591587E7346BAB3F68;
IL2CPP_EXTERN_C String_t* _stringLiteral26DC9E6A16A2B862023CCDC29E42E5404E9ACD4F;
IL2CPP_EXTERN_C String_t* _stringLiteral623990995459AA52EC886FD82EF05F80DEA9ED84;
IL2CPP_EXTERN_C String_t* _stringLiteral73A0C07EF772937789C242D3D453CD9350FB99F0;
IL2CPP_EXTERN_C String_t* _stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D;
IL2CPP_EXTERN_C String_t* _stringLiteralD1BC37757802217E304B7B515215AC6EE461954E;
IL2CPP_EXTERN_C String_t* _stringLiteralFFEF3DBE279EE1F92E1E2E46F45BC18EBBF55A1A;
IL2CPP_EXTERN_C const RuntimeMethod* PathUtil_NormalizeRelativePath_m7B439205813D27F5E907C20AFAA7161A66D9A57E_RuntimeMethod_var;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tCDD6217B64AC66A9A5C56F0D53F95372BC0F36C5 
{
};

// BetterStreamingAssets
struct BetterStreamingAssets_t84724D489C99A9573CD7D596B20006279EA48A1E  : public RuntimeObject
{
};

// Better.StreamingAssets.PathUtil
struct PathUtil_tDDF679C9AAB0F8DB09575AC5925AAE3E8769C1C0  : public RuntimeObject
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

// System.Text.StringBuilder
struct StringBuilder_t  : public RuntimeObject
{
	// System.Char[] System.Text.StringBuilder::m_ChunkChars
	CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___m_ChunkChars_0;
	// System.Text.StringBuilder System.Text.StringBuilder::m_ChunkPrevious
	StringBuilder_t* ___m_ChunkPrevious_1;
	// System.Int32 System.Text.StringBuilder::m_ChunkLength
	int32_t ___m_ChunkLength_2;
	// System.Int32 System.Text.StringBuilder::m_ChunkOffset
	int32_t ___m_ChunkOffset_3;
	// System.Int32 System.Text.StringBuilder::m_MaxCapacity
	int32_t ___m_MaxCapacity_4;
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

// BetterStreamingAssets/LooseFilesImpl
struct LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD  : public RuntimeObject
{
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

// System.Char
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_0;
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

// BetterStreamingAssets/ReadInfo
struct ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642 
{
	// System.String BetterStreamingAssets/ReadInfo::readPath
	String_t* ___readPath_0;
	// System.Int64 BetterStreamingAssets/ReadInfo::size
	int64_t ___size_1;
	// System.Int64 BetterStreamingAssets/ReadInfo::offset
	int64_t ___offset_2;
	// System.UInt32 BetterStreamingAssets/ReadInfo::crc32
	uint32_t ___crc32_3;
};
// Native definition for P/Invoke marshalling of BetterStreamingAssets/ReadInfo
struct ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_pinvoke
{
	char* ___readPath_0;
	int64_t ___size_1;
	int64_t ___offset_2;
	uint32_t ___crc32_3;
};
// Native definition for COM marshalling of BetterStreamingAssets/ReadInfo
struct ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_com
{
	Il2CppChar* ___readPath_0;
	int64_t ___size_1;
	int64_t ___offset_2;
	uint32_t ___crc32_3;
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

// System.IO.IOException
struct IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// <Module>

// <Module>

// BetterStreamingAssets

// BetterStreamingAssets

// Better.StreamingAssets.PathUtil

// Better.StreamingAssets.PathUtil

// System.String
struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.String

// System.Text.StringBuilder

// System.Text.StringBuilder

// BetterStreamingAssets/LooseFilesImpl
struct LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_StaticFields
{
	// System.String BetterStreamingAssets/LooseFilesImpl::s_root
	String_t* ___s_root_0;
	// System.String[] BetterStreamingAssets/LooseFilesImpl::s_emptyArray
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___s_emptyArray_1;
};

// BetterStreamingAssets/LooseFilesImpl

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Boolean

// System.Char
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	// System.Byte[] System.Char::s_categoryForLatin1
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1_3;
};

// System.Char

// System.Int32

// System.Int32

// System.Void

// System.Void

// BetterStreamingAssets/ReadInfo

// BetterStreamingAssets/ReadInfo

// System.ArgumentException

// System.ArgumentException

// System.IO.IOException

// System.IO.IOException
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248  : public RuntimeArray
{
	ALIGN_FIELD (8) String_t* m_Items[1];

	inline String_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline String_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, String_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline String_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline String_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, String_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};



// System.String UnityEngine.Application::get_dataPath()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Application_get_dataPath_m4C8412CBEE4EAAAB6711CC9BEFFA73CEE5BDBEF7 (const RuntimeMethod* method) ;
// System.String UnityEngine.Application::get_streamingAssetsPath()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Application_get_streamingAssetsPath_mB904BCD9A7A4F18A52C175DE4A81F5DC3010CDB5 (const RuntimeMethod* method) ;
// System.Void BetterStreamingAssets/LooseFilesImpl::Initialize(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LooseFilesImpl_Initialize_mA45C20742E3B6F060990FBE1DEAE5B45DAC38C20 (String_t* ___0_dataPath, String_t* ___1_streamingAssetsPath, const RuntimeMethod* method) ;
// System.Boolean BetterStreamingAssets/LooseFilesImpl::TryGetInfo(System.String,BetterStreamingAssets/ReadInfo&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LooseFilesImpl_TryGetInfo_mEFEF1A59C1BF4D969DD0D66A6DFF9E4FB43E5FE3 (String_t* ___0_path, ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642* ___1_info, const RuntimeMethod* method) ;
// System.String System.IO.Path::GetFullPath(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Path_GetFullPath_m9E485D7D38A868A6A5863CBD24677231288EECE2 (String_t* ___0_path, const RuntimeMethod* method) ;
// System.String System.String::Replace(System.Char,System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Replace_m86403DC5F422D8D5E1CFAAF255B103CB807EDAAF (String_t* __this, Il2CppChar ___0_oldChar, Il2CppChar ___1_newChar, const RuntimeMethod* method) ;
// System.String System.String::TrimEnd(System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_TrimEnd_mDB4D96F8312F563656D4115A9F280062E05D2EE8 (String_t* __this, Il2CppChar ___0_trimChar, const RuntimeMethod* method) ;
// System.String Better.StreamingAssets.PathUtil::NormalizeRelativePath(System.String,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* PathUtil_NormalizeRelativePath_m7B439205813D27F5E907C20AFAA7161A66D9A57E (String_t* ___0_relative, bool ___1_forceTrailingSlash, const RuntimeMethod* method) ;
// System.String System.String::Concat(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m9E3155FB84015C823606188F53B47CB44C444991 (String_t* ___0_str0, String_t* ___1_str1, const RuntimeMethod* method) ;
// System.Boolean System.IO.File::Exists(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool File_Exists_m95E329ABBE3EAD6750FE1989BBA6884457136D4A (String_t* ___0_path, const RuntimeMethod* method) ;
// System.Boolean System.String::IsNullOrEmpty(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478 (String_t* ___0_value, const RuntimeMethod* method) ;
// System.Void System.ArgumentException::.ctor(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m8F9D40CE19D19B698A70F9A258640EB52DB39B62 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___0_message, String_t* ___1_paramName, const RuntimeMethod* method) ;
// System.Int32 System.String::get_Length()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) ;
// System.Void System.Text.StringBuilder::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void StringBuilder__ctor_m2619CA8D2C3476DF1A302D9D941498BB1C6164C5 (StringBuilder_t* __this, int32_t ___0_capacity, const RuntimeMethod* method) ;
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1 (StringBuilder_t* __this, Il2CppChar ___0_value, const RuntimeMethod* method) ;
// System.Char System.String::get_Chars(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3 (String_t* __this, int32_t ___0_index, const RuntimeMethod* method) ;
// System.Int32 System.Text.StringBuilder::get_Length()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8 (StringBuilder_t* __this, const RuntimeMethod* method) ;
// System.String System.Int32::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5 (int32_t* __this, const RuntimeMethod* method) ;
// System.String System.String::Concat(System.String,System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B (String_t* ___0_str0, String_t* ___1_str1, String_t* ___2_str2, const RuntimeMethod* method) ;
// System.Void System.IO.IOException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IOException__ctor_mE0612A16064F93C7EBB468D6874777BD70CB50CA (IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910* __this, String_t* ___0_message, const RuntimeMethod* method) ;
// System.Char System.Text.StringBuilder::get_Chars(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar StringBuilder_get_Chars_m254FD6F2F75C00B0D353D73B2A4A19316BD7624D (StringBuilder_t* __this, int32_t ___0_index, const RuntimeMethod* method) ;
// System.Text.StringBuilder System.Text.StringBuilder::Remove(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Remove_m0D93692674D1C09795C7D6542420A3B6C5F81E90 (StringBuilder_t* __this, int32_t ___0_startIndex, int32_t ___1_length, const RuntimeMethod* method) ;
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D (StringBuilder_t* __this, String_t* ___0_value, const RuntimeMethod* method) ;
// System.Boolean Better.StreamingAssets.PathUtil::IsValidCharacter(System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PathUtil_IsValidCharacter_mB61FAF3517472920384EC1280D78D48E2E629E6E (Il2CppChar ___0_c, const RuntimeMethod* method) ;
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
// System.Void BetterStreamingAssets::Initialize()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BetterStreamingAssets_Initialize_m4734FAB5D4C3B306447B4FB96033F4D6506E7CF8 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// BetterStreamingAssetsImp.Initialize(Application.dataPath, Application.streamingAssetsPath);
		String_t* L_0;
		L_0 = Application_get_dataPath_m4C8412CBEE4EAAAB6711CC9BEFFA73CEE5BDBEF7(NULL);
		String_t* L_1;
		L_1 = Application_get_streamingAssetsPath_mB904BCD9A7A4F18A52C175DE4A81F5DC3010CDB5(NULL);
		il2cpp_codegen_runtime_class_init_inline(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		LooseFilesImpl_Initialize_mA45C20742E3B6F060990FBE1DEAE5B45DAC38C20(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.Boolean BetterStreamingAssets::FileExists(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BetterStreamingAssets_FileExists_m9DB4D4860ED3C0090C0005DEBA238A80E24A77E1 (String_t* ___0_path, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// return BetterStreamingAssetsImp.TryGetInfo(path, out info);
		String_t* L_0 = ___0_path;
		il2cpp_codegen_runtime_class_init_inline(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = LooseFilesImpl_TryGetInfo_mEFEF1A59C1BF4D969DD0D66A6DFF9E4FB43E5FE3(L_0, (&V_0), NULL);
		return L_1;
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
// Conversion methods for marshalling of: BetterStreamingAssets/ReadInfo
IL2CPP_EXTERN_C void ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshal_pinvoke(const ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642& unmarshaled, ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_pinvoke& marshaled)
{
	marshaled.___readPath_0 = il2cpp_codegen_marshal_string(unmarshaled.___readPath_0);
	marshaled.___size_1 = unmarshaled.___size_1;
	marshaled.___offset_2 = unmarshaled.___offset_2;
	marshaled.___crc32_3 = unmarshaled.___crc32_3;
}
IL2CPP_EXTERN_C void ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshal_pinvoke_back(const ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_pinvoke& marshaled, ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642& unmarshaled)
{
	unmarshaled.___readPath_0 = il2cpp_codegen_marshal_string_result(marshaled.___readPath_0);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___readPath_0), (void*)il2cpp_codegen_marshal_string_result(marshaled.___readPath_0));
	int64_t unmarshaledsize_temp_1 = 0;
	unmarshaledsize_temp_1 = marshaled.___size_1;
	unmarshaled.___size_1 = unmarshaledsize_temp_1;
	int64_t unmarshaledoffset_temp_2 = 0;
	unmarshaledoffset_temp_2 = marshaled.___offset_2;
	unmarshaled.___offset_2 = unmarshaledoffset_temp_2;
	uint32_t unmarshaledcrc32_temp_3 = 0;
	unmarshaledcrc32_temp_3 = marshaled.___crc32_3;
	unmarshaled.___crc32_3 = unmarshaledcrc32_temp_3;
}
// Conversion method for clean up from marshalling of: BetterStreamingAssets/ReadInfo
IL2CPP_EXTERN_C void ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshal_pinvoke_cleanup(ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_pinvoke& marshaled)
{
	il2cpp_codegen_marshal_free(marshaled.___readPath_0);
	marshaled.___readPath_0 = NULL;
}
// Conversion methods for marshalling of: BetterStreamingAssets/ReadInfo
IL2CPP_EXTERN_C void ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshal_com(const ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642& unmarshaled, ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_com& marshaled)
{
	marshaled.___readPath_0 = il2cpp_codegen_marshal_bstring(unmarshaled.___readPath_0);
	marshaled.___size_1 = unmarshaled.___size_1;
	marshaled.___offset_2 = unmarshaled.___offset_2;
	marshaled.___crc32_3 = unmarshaled.___crc32_3;
}
IL2CPP_EXTERN_C void ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshal_com_back(const ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_com& marshaled, ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642& unmarshaled)
{
	unmarshaled.___readPath_0 = il2cpp_codegen_marshal_bstring_result(marshaled.___readPath_0);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___readPath_0), (void*)il2cpp_codegen_marshal_bstring_result(marshaled.___readPath_0));
	int64_t unmarshaledsize_temp_1 = 0;
	unmarshaledsize_temp_1 = marshaled.___size_1;
	unmarshaled.___size_1 = unmarshaledsize_temp_1;
	int64_t unmarshaledoffset_temp_2 = 0;
	unmarshaledoffset_temp_2 = marshaled.___offset_2;
	unmarshaled.___offset_2 = unmarshaledoffset_temp_2;
	uint32_t unmarshaledcrc32_temp_3 = 0;
	unmarshaledcrc32_temp_3 = marshaled.___crc32_3;
	unmarshaled.___crc32_3 = unmarshaledcrc32_temp_3;
}
// Conversion method for clean up from marshalling of: BetterStreamingAssets/ReadInfo
IL2CPP_EXTERN_C void ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshal_com_cleanup(ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642_marshaled_com& marshaled)
{
	il2cpp_codegen_marshal_free_bstring(marshaled.___readPath_0);
	marshaled.___readPath_0 = NULL;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void BetterStreamingAssets/LooseFilesImpl::Initialize(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LooseFilesImpl_Initialize_mA45C20742E3B6F060990FBE1DEAE5B45DAC38C20 (String_t* ___0_dataPath, String_t* ___1_streamingAssetsPath, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Path_t8A38A801D0219E8209C1B1D90D82D4D755D998BC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// s_root = Path.GetFullPath(streamingAssetsPath).Replace('\\', '/').TrimEnd('/');
		String_t* L_0 = ___1_streamingAssetsPath;
		il2cpp_codegen_runtime_class_init_inline(Path_t8A38A801D0219E8209C1B1D90D82D4D755D998BC_il2cpp_TypeInfo_var);
		String_t* L_1;
		L_1 = Path_GetFullPath_m9E485D7D38A868A6A5863CBD24677231288EECE2(L_0, NULL);
		NullCheck(L_1);
		String_t* L_2;
		L_2 = String_Replace_m86403DC5F422D8D5E1CFAAF255B103CB807EDAAF(L_1, ((int32_t)92), ((int32_t)47), NULL);
		NullCheck(L_2);
		String_t* L_3;
		L_3 = String_TrimEnd_mDB4D96F8312F563656D4115A9F280062E05D2EE8(L_2, ((int32_t)47), NULL);
		il2cpp_codegen_runtime_class_init_inline(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		((LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_StaticFields*)il2cpp_codegen_static_fields_for(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var))->___s_root_0 = L_3;
		Il2CppCodeGenWriteBarrier((void**)(&((LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_StaticFields*)il2cpp_codegen_static_fields_for(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var))->___s_root_0), (void*)L_3);
		// }
		return;
	}
}
// System.Boolean BetterStreamingAssets/LooseFilesImpl::TryGetInfo(System.String,BetterStreamingAssets/ReadInfo&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LooseFilesImpl_TryGetInfo_mEFEF1A59C1BF4D969DD0D66A6DFF9E4FB43E5FE3 (String_t* ___0_path, ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642* ___1_info, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		// path = PathUtil.NormalizeRelativePath(path);
		String_t* L_0 = ___0_path;
		String_t* L_1;
		L_1 = PathUtil_NormalizeRelativePath_m7B439205813D27F5E907C20AFAA7161A66D9A57E(L_0, (bool)0, NULL);
		___0_path = L_1;
		// info = new ReadInfo();
		ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642* L_2 = ___1_info;
		il2cpp_codegen_initobj(L_2, sizeof(ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642));
		// var fullPath = s_root + path;
		il2cpp_codegen_runtime_class_init_inline(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		String_t* L_3 = ((LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_StaticFields*)il2cpp_codegen_static_fields_for(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var))->___s_root_0;
		String_t* L_4 = ___0_path;
		String_t* L_5;
		L_5 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(L_3, L_4, NULL);
		V_0 = L_5;
		// if ( !File.Exists(fullPath) )
		String_t* L_6 = V_0;
		bool L_7;
		L_7 = File_Exists_m95E329ABBE3EAD6750FE1989BBA6884457136D4A(L_6, NULL);
		if (L_7)
		{
			goto IL_0026;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0026:
	{
		// info.readPath = fullPath;
		ReadInfo_t6C1BF9B2D953AC1D17F64D3C63EF47B6D6BD6642* L_8 = ___1_info;
		String_t* L_9 = V_0;
		L_8->___readPath_0 = L_9;
		Il2CppCodeGenWriteBarrier((void**)(&L_8->___readPath_0), (void*)L_9);
		// return true;
		return (bool)1;
	}
}
// System.Void BetterStreamingAssets/LooseFilesImpl::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LooseFilesImpl__cctor_m199F7DCB69E04988F592B5128C4716B19AD67239 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private static string[] s_emptyArray = new string[0];
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)SZArrayNew(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var, (uint32_t)0);
		((LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_StaticFields*)il2cpp_codegen_static_fields_for(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var))->___s_emptyArray_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_StaticFields*)il2cpp_codegen_static_fields_for(LooseFilesImpl_t4FED4CF9D6859BB2481DA41505AEA49A09FCF6DD_il2cpp_TypeInfo_var))->___s_emptyArray_1), (void*)L_0);
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
// System.String Better.StreamingAssets.PathUtil::NormalizeRelativePath(System.String,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* PathUtil_NormalizeRelativePath_m7B439205813D27F5E907C20AFAA7161A66D9A57E (String_t* ___0_relative, bool ___1_forceTrailingSlash, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringBuilder_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral26DC9E6A16A2B862023CCDC29E42E5404E9ACD4F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralFFEF3DBE279EE1F92E1E2E46F45BC18EBBF55A1A);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	{
		// if (string.IsNullOrEmpty(relative))
		String_t* L_0 = ___0_relative;
		bool L_1;
		L_1 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_0, NULL);
		if (!L_1)
		{
			goto IL_0018;
		}
	}
	{
		// throw new System.ArgumentException("Empty or null", "relative");
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_2 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_2);
		ArgumentException__ctor_m8F9D40CE19D19B698A70F9A258640EB52DB39B62(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD1BC37757802217E304B7B515215AC6EE461954E)), ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral623990995459AA52EC886FD82EF05F80DEA9ED84)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&PathUtil_NormalizeRelativePath_m7B439205813D27F5E907C20AFAA7161A66D9A57E_RuntimeMethod_var)));
	}

IL_0018:
	{
		// StringBuilder output = new StringBuilder(relative.Length);
		String_t* L_3 = ___0_relative;
		NullCheck(L_3);
		int32_t L_4;
		L_4 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_3, NULL);
		StringBuilder_t* L_5 = (StringBuilder_t*)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		StringBuilder__ctor_m2619CA8D2C3476DF1A302D9D941498BB1C6164C5(L_5, L_4, NULL);
		V_0 = L_5;
		// NormalizeState state = NormalizeState.PrevSlash;
		V_1 = 0;
		// output.Append('/');
		StringBuilder_t* L_6 = V_0;
		NullCheck(L_6);
		StringBuilder_t* L_7;
		L_7 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_6, ((int32_t)47), NULL);
		// int startIndex = 0;
		V_2 = 0;
		// int lastIndexPlus1 = relative.Length;
		String_t* L_8 = ___0_relative;
		NullCheck(L_8);
		int32_t L_9;
		L_9 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_8, NULL);
		V_3 = L_9;
		// if ( relative[0] == '"' && relative.Length > 2 && relative[relative.Length - 1] == '"')
		String_t* L_10 = ___0_relative;
		NullCheck(L_10);
		Il2CppChar L_11;
		L_11 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_10, 0, NULL);
		if ((!(((uint32_t)L_11) == ((uint32_t)((int32_t)34)))))
		{
			goto IL_0066;
		}
	}
	{
		String_t* L_12 = ___0_relative;
		NullCheck(L_12);
		int32_t L_13;
		L_13 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_12, NULL);
		if ((((int32_t)L_13) <= ((int32_t)2)))
		{
			goto IL_0066;
		}
	}
	{
		String_t* L_14 = ___0_relative;
		String_t* L_15 = ___0_relative;
		NullCheck(L_15);
		int32_t L_16;
		L_16 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_15, NULL);
		NullCheck(L_14);
		Il2CppChar L_17;
		L_17 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_14, ((int32_t)il2cpp_codegen_subtract(L_16, 1)), NULL);
		if ((!(((uint32_t)L_17) == ((uint32_t)((int32_t)34)))))
		{
			goto IL_0066;
		}
	}
	{
		// startIndex++;
		int32_t L_18 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_18, 1));
		// lastIndexPlus1--;
		int32_t L_19 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_19, 1));
	}

IL_0066:
	{
		// for ( int i = startIndex; i <= lastIndexPlus1; ++i )
		int32_t L_20 = V_2;
		V_4 = L_20;
		goto IL_019c;
	}

IL_006e:
	{
		// if (i == lastIndexPlus1 || relative[i] == '/' || relative[i] == '\\')
		int32_t L_21 = V_4;
		int32_t L_22 = V_3;
		if ((((int32_t)L_21) == ((int32_t)L_22)))
		{
			goto IL_008e;
		}
	}
	{
		String_t* L_23 = ___0_relative;
		int32_t L_24 = V_4;
		NullCheck(L_23);
		Il2CppChar L_25;
		L_25 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_23, L_24, NULL);
		if ((((int32_t)L_25) == ((int32_t)((int32_t)47))))
		{
			goto IL_008e;
		}
	}
	{
		String_t* L_26 = ___0_relative;
		int32_t L_27 = V_4;
		NullCheck(L_26);
		Il2CppChar L_28;
		L_28 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_26, L_27, NULL);
		if ((!(((uint32_t)L_28) == ((uint32_t)((int32_t)92)))))
		{
			goto IL_0112;
		}
	}

IL_008e:
	{
		// if ( state == NormalizeState.PrevSlash || state == NormalizeState.PrevDot )
		int32_t L_29 = V_1;
		if (!L_29)
		{
			goto IL_010b;
		}
	}
	{
		int32_t L_30 = V_1;
		if ((((int32_t)L_30) == ((int32_t)1)))
		{
			goto IL_010b;
		}
	}
	{
		// else if ( state == NormalizeState.PrevDoubleDot )
		int32_t L_31 = V_1;
		if ((!(((uint32_t)L_31) == ((uint32_t)2))))
		{
			goto IL_00f9;
		}
	}
	{
		// if ( output.Length == 1 )
		StringBuilder_t* L_32 = V_0;
		NullCheck(L_32);
		int32_t L_33;
		L_33 = StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8(L_32, NULL);
		if ((!(((uint32_t)L_33) == ((uint32_t)1))))
		{
			goto IL_00be;
		}
	}
	{
		// throw new System.IO.IOException("Invalid path: double dot error (before " + i + ")");
		String_t* L_34;
		L_34 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5((&V_4), NULL);
		String_t* L_35;
		L_35 = String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15063F649207A4502DFEDF591587E7346BAB3F68)), L_34, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D)), NULL);
		IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910* L_36 = (IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910_il2cpp_TypeInfo_var)));
		NullCheck(L_36);
		IOException__ctor_mE0612A16064F93C7EBB468D6874777BD70CB50CA(L_36, L_35, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_36, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&PathUtil_NormalizeRelativePath_m7B439205813D27F5E907C20AFAA7161A66D9A57E_RuntimeMethod_var)));
	}

IL_00be:
	{
		// for ( j = output.Length - 2; j >= 0 && output[j] != '/'; --j)
		StringBuilder_t* L_37 = V_0;
		NullCheck(L_37);
		int32_t L_38;
		L_38 = StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8(L_37, NULL);
		V_5 = ((int32_t)il2cpp_codegen_subtract(L_38, 2));
		goto IL_00d0;
	}

IL_00ca:
	{
		// for ( j = output.Length - 2; j >= 0 && output[j] != '/'; --j)
		int32_t L_39 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_subtract(L_39, 1));
	}

IL_00d0:
	{
		// for ( j = output.Length - 2; j >= 0 && output[j] != '/'; --j)
		int32_t L_40 = V_5;
		if ((((int32_t)L_40) < ((int32_t)0)))
		{
			goto IL_00e1;
		}
	}
	{
		StringBuilder_t* L_41 = V_0;
		int32_t L_42 = V_5;
		NullCheck(L_41);
		Il2CppChar L_43;
		L_43 = StringBuilder_get_Chars_m254FD6F2F75C00B0D353D73B2A4A19316BD7624D(L_41, L_42, NULL);
		if ((!(((uint32_t)L_43) == ((uint32_t)((int32_t)47)))))
		{
			goto IL_00ca;
		}
	}

IL_00e1:
	{
		// output.Remove(j + 1, output.Length - j - 1);
		StringBuilder_t* L_44 = V_0;
		int32_t L_45 = V_5;
		StringBuilder_t* L_46 = V_0;
		NullCheck(L_46);
		int32_t L_47;
		L_47 = StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8(L_46, NULL);
		int32_t L_48 = V_5;
		NullCheck(L_44);
		StringBuilder_t* L_49;
		L_49 = StringBuilder_Remove_m0D93692674D1C09795C7D6542420A3B6C5F81E90(L_44, ((int32_t)il2cpp_codegen_add(L_45, 1)), ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(L_47, L_48)), 1)), NULL);
		goto IL_010b;
	}

IL_00f9:
	{
		// else if ( i < lastIndexPlus1 || forceTrailingSlash )
		int32_t L_50 = V_4;
		int32_t L_51 = V_3;
		bool L_52 = ___1_forceTrailingSlash;
		if (!((int32_t)(((((int32_t)L_50) < ((int32_t)L_51))? 1 : 0)|(int32_t)L_52)))
		{
			goto IL_010b;
		}
	}
	{
		// output.Append('/');
		StringBuilder_t* L_53 = V_0;
		NullCheck(L_53);
		StringBuilder_t* L_54;
		L_54 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_53, ((int32_t)47), NULL);
	}

IL_010b:
	{
		// state = NormalizeState.PrevSlash;
		V_1 = 0;
		goto IL_0196;
	}

IL_0112:
	{
		// else if ( relative[i] == '.' )
		String_t* L_55 = ___0_relative;
		int32_t L_56 = V_4;
		NullCheck(L_55);
		Il2CppChar L_57;
		L_57 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_55, L_56, NULL);
		if ((!(((uint32_t)L_57) == ((uint32_t)((int32_t)46)))))
		{
			goto IL_014c;
		}
	}
	{
		// if ( state == NormalizeState.PrevSlash )
		int32_t L_58 = V_1;
		if (L_58)
		{
			goto IL_0125;
		}
	}
	{
		// state = NormalizeState.PrevDot;
		V_1 = 1;
		goto IL_0196;
	}

IL_0125:
	{
		// else if ( state == NormalizeState.PrevDot )
		int32_t L_59 = V_1;
		if ((!(((uint32_t)L_59) == ((uint32_t)1))))
		{
			goto IL_012d;
		}
	}
	{
		// state = NormalizeState.PrevDoubleDot;
		V_1 = 2;
		goto IL_0196;
	}

IL_012d:
	{
		// else if ( state == NormalizeState.PrevDoubleDot )
		int32_t L_60 = V_1;
		if ((!(((uint32_t)L_60) == ((uint32_t)2))))
		{
			goto IL_0141;
		}
	}
	{
		// state = NormalizeState.NothingSpecial;
		V_1 = 3;
		// output.Append("...");
		StringBuilder_t* L_61 = V_0;
		NullCheck(L_61);
		StringBuilder_t* L_62;
		L_62 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_61, _stringLiteralFFEF3DBE279EE1F92E1E2E46F45BC18EBBF55A1A, NULL);
		goto IL_0196;
	}

IL_0141:
	{
		// output.Append('.');
		StringBuilder_t* L_63 = V_0;
		NullCheck(L_63);
		StringBuilder_t* L_64;
		L_64 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_63, ((int32_t)46), NULL);
		goto IL_0196;
	}

IL_014c:
	{
		// if ( state == NormalizeState.PrevDot )
		int32_t L_65 = V_1;
		if ((!(((uint32_t)L_65) == ((uint32_t)1))))
		{
			goto IL_015b;
		}
	}
	{
		// output.Append('.');
		StringBuilder_t* L_66 = V_0;
		NullCheck(L_66);
		StringBuilder_t* L_67;
		L_67 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_66, ((int32_t)46), NULL);
		goto IL_016b;
	}

IL_015b:
	{
		// else if ( state == NormalizeState.PrevDoubleDot )
		int32_t L_68 = V_1;
		if ((!(((uint32_t)L_68) == ((uint32_t)2))))
		{
			goto IL_016b;
		}
	}
	{
		// output.Append("..");
		StringBuilder_t* L_69 = V_0;
		NullCheck(L_69);
		StringBuilder_t* L_70;
		L_70 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_69, _stringLiteral26DC9E6A16A2B862023CCDC29E42E5404E9ACD4F, NULL);
	}

IL_016b:
	{
		// if (!IsValidCharacter(relative[i]))
		String_t* L_71 = ___0_relative;
		int32_t L_72 = V_4;
		NullCheck(L_71);
		Il2CppChar L_73;
		L_73 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_71, L_72, NULL);
		bool L_74;
		L_74 = PathUtil_IsValidCharacter_mB61FAF3517472920384EC1280D78D48E2E629E6E(L_73, NULL);
		if (L_74)
		{
			goto IL_0185;
		}
	}
	{
		// throw new System.IO.IOException("Invalid characters");
		IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910* L_75 = (IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910_il2cpp_TypeInfo_var)));
		NullCheck(L_75);
		IOException__ctor_mE0612A16064F93C7EBB468D6874777BD70CB50CA(L_75, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral73A0C07EF772937789C242D3D453CD9350FB99F0)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_75, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&PathUtil_NormalizeRelativePath_m7B439205813D27F5E907C20AFAA7161A66D9A57E_RuntimeMethod_var)));
	}

IL_0185:
	{
		// output.Append(relative[i]);
		StringBuilder_t* L_76 = V_0;
		String_t* L_77 = ___0_relative;
		int32_t L_78 = V_4;
		NullCheck(L_77);
		Il2CppChar L_79;
		L_79 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_77, L_78, NULL);
		NullCheck(L_76);
		StringBuilder_t* L_80;
		L_80 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_76, L_79, NULL);
		// state = NormalizeState.NothingSpecial;
		V_1 = 3;
	}

IL_0196:
	{
		// for ( int i = startIndex; i <= lastIndexPlus1; ++i )
		int32_t L_81 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_81, 1));
	}

IL_019c:
	{
		// for ( int i = startIndex; i <= lastIndexPlus1; ++i )
		int32_t L_82 = V_4;
		int32_t L_83 = V_3;
		if ((((int32_t)L_82) <= ((int32_t)L_83)))
		{
			goto IL_006e;
		}
	}
	{
		// return output.ToString();
		StringBuilder_t* L_84 = V_0;
		NullCheck(L_84);
		String_t* L_85;
		L_85 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_84);
		return L_85;
	}
}
// System.Boolean Better.StreamingAssets.PathUtil::IsValidCharacter(System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PathUtil_IsValidCharacter_mB61FAF3517472920384EC1280D78D48E2E629E6E (Il2CppChar ___0_c, const RuntimeMethod* method) 
{
	{
		// if (c == '\"' || c == '<' || c == '>' || c == '|' || c < 32 || c == ':' || c == '*' || c == '?')
		Il2CppChar L_0 = ___0_c;
		if ((((int32_t)L_0) == ((int32_t)((int32_t)34))))
		{
			goto IL_0028;
		}
	}
	{
		Il2CppChar L_1 = ___0_c;
		if ((((int32_t)L_1) == ((int32_t)((int32_t)60))))
		{
			goto IL_0028;
		}
	}
	{
		Il2CppChar L_2 = ___0_c;
		if ((((int32_t)L_2) == ((int32_t)((int32_t)62))))
		{
			goto IL_0028;
		}
	}
	{
		Il2CppChar L_3 = ___0_c;
		if ((((int32_t)L_3) == ((int32_t)((int32_t)124))))
		{
			goto IL_0028;
		}
	}
	{
		Il2CppChar L_4 = ___0_c;
		if ((((int32_t)L_4) < ((int32_t)((int32_t)32))))
		{
			goto IL_0028;
		}
	}
	{
		Il2CppChar L_5 = ___0_c;
		if ((((int32_t)L_5) == ((int32_t)((int32_t)58))))
		{
			goto IL_0028;
		}
	}
	{
		Il2CppChar L_6 = ___0_c;
		if ((((int32_t)L_6) == ((int32_t)((int32_t)42))))
		{
			goto IL_0028;
		}
	}
	{
		Il2CppChar L_7 = ___0_c;
		if ((!(((uint32_t)L_7) == ((uint32_t)((int32_t)63)))))
		{
			goto IL_002a;
		}
	}

IL_0028:
	{
		// return false;
		return (bool)0;
	}

IL_002a:
	{
		// return true;
		return (bool)1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____stringLength_4;
		return L_0;
	}
}
