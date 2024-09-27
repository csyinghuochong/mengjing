#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>



// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;


struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tD0DFB154750CEF95F40DFD18F49DF0881C0A7176 
{
};

// HybridCLR.RuntimeApi
struct RuntimeApi_tA19E50636DDDC4D8EA30DEC54EE4DFD73CAE62D2  : public RuntimeObject
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

// System.Byte
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_0;
};

// <Module>

// <Module>

// HybridCLR.RuntimeApi

// HybridCLR.RuntimeApi

// System.Byte

// System.Byte
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};



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
// HybridCLR.LoadImageErrorCode HybridCLR.RuntimeApi::LoadMetadataForAOTAssembly(System.Byte[],HybridCLR.HomologousImageMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t RuntimeApi_LoadMetadataForAOTAssembly_mE1E398132DBF86D7DE042300E1EE6AC37B7649D8 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_dllBytes, int32_t ___1_mode, const RuntimeMethod* method) 
{
	typedef int32_t (*RuntimeApi_LoadMetadataForAOTAssembly_mE1E398132DBF86D7DE042300E1EE6AC37B7649D8_ftn) (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t);
	static RuntimeApi_LoadMetadataForAOTAssembly_mE1E398132DBF86D7DE042300E1EE6AC37B7649D8_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (RuntimeApi_LoadMetadataForAOTAssembly_mE1E398132DBF86D7DE042300E1EE6AC37B7649D8_ftn)il2cpp_codegen_resolve_icall ("HybridCLR.RuntimeApi::LoadMetadataForAOTAssembly(System.Byte[],HybridCLR.HomologousImageMode)");
	int32_t icallRetVal = _il2cpp_icall_func(___0_dllBytes, ___1_mode);
	return icallRetVal;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
