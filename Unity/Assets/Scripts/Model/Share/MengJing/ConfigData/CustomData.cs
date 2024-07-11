using System;
using System.Runtime.InteropServices;
using MemoryPack;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{

    [MemoryPackable]
    [EnableClass]
    public partial class KeyValuePair
    {
        public KeyValuePair(int key, string value, string value2)
        {
            this.KeyId = key;
            this.Value = value;
            this.Value2 = value2;
        }
        
        [MemoryPackOrder(0)]
        public int KeyId ;
        
        [MemoryPackOrder(1)]
        public string Value ;
        
        [MemoryPackOrder(2)]
        public string Value2 ;
    }

    [MemoryPackable]
    [EnableClass]
    public partial class KeyValuePairInt 
    {
        public KeyValuePairInt(int key, long value)
        {
            this.KeyId = key;
            this.Value = value;
        }
        
        [MemoryPackOrder(0)]
        public int  KeyId ;	
        
        [MemoryPackOrder(1)]
        public long  Value ;
    }

    [MemoryPackable]
    [EnableClass]
    public partial class KeyValuePairLong
    {
        public KeyValuePairLong(long key, long value, long value2)
        {
            this.KeyId = key;
            this.Value = value;
            this.Value2 = value2;
        }
        
        [MemoryPackOrder(0)]
        public long KeyId;	
        
        [MemoryPackOrder(1)]
        public long Value ;
        
        [MemoryPackOrder(2)]
        public long Value2 ;
    }

    
}