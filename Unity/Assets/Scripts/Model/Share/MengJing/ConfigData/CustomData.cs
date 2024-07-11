using System;
using System.Runtime.InteropServices;
using MemoryPack;
using MongoDB.Bson.Serialization.Attributes;
using NativeCollection;

namespace ET
{
    [MemoryPackable]
    [EnableClass]
    public partial class  ServerItem
    {
        [MemoryPackOrder(0)]
        public int ServerId ;
        
        [MemoryPackOrder(1)]
        public string ServerIp ;
        
        [MemoryPackOrder(2)]
        public string ServerName ;
        
        [MemoryPackOrder(3)]
        public long ServerOpenTime ;
        
        [MemoryPackOrder(4)]
        public int Show ;
        
        [MemoryPackOrder(5)]
        public int New ;
        
        [MemoryPackOrder(6)]
        public List<int> PlatformList ;   //不配置或者-1全部显示
    }

    
    //通过奖励
    [MemoryPackable]
    [EnableClass]
    public partial class RewardItem
    {

        [MemoryPackOrder(0)]
        public int ItemID;

        [MemoryPackOrder(1)]
        public int ItemNum;
    }

    [MemoryPackable]
    [EnableClass]
    public partial class HideProList
    {
        [MemoryPackOrder(0)]
        public int  HideID;
    
        [MemoryPackOrder(1)]
        public long  HideValue ;
    }

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