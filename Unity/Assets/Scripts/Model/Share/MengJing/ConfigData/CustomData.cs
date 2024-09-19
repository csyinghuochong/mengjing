using MemoryPack;

namespace ET
{

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

    [MemoryPackable]
    [EnableClass]
    public partial class KeyValuePairLong4
    {
       
        [MemoryPackOrder(0)]
        public long KeyId;	
        
        [MemoryPackOrder(1)]
        public long Value ;
        
        [MemoryPackOrder(2)]
        public long Value2 ;
        
        [MemoryPackOrder(2)]
        public long Value3 ;
    }
}