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

        
        [MemoryPackOrder(0)]
        public int  KeyId ;	
        
        [MemoryPackOrder(1)]
        public long  Value ;
    }

    [MemoryPackable]
    [EnableClass]
    public partial class KeyValuePairLong
    {
       
        [MemoryPackOrder(0)]
        public long KeyId;	
        
        [MemoryPackOrder(1)]
        public long Value ;
        
        [MemoryPackOrder(2)]
        public long Value2 ;
    }

    
}