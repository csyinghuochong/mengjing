namespace ET
{
    
    public partial struct KeyValuePair
    {
        public KeyValuePair(int key, string value, string value2)
        {
            this.KeyId = key;
            this.Value = value;
            this.Value2 = value2;
        }
        public int KeyId ;
        public string Value ;
        public string Value2 ;
    }

    public partial struct KeyValuePairInt 
    {
        public KeyValuePairInt(int key, long value)
        {
            this.KeyId = key;
            this.Value = value;
        }
        public int  KeyId ;	
        public long  Value ;
    }


    public partial struct KeyValuePairLong
    {
        public KeyValuePairLong(long key, long value, long value2)
        {
            this.KeyId = key;
            this.Value = value;
            this.Value2 = value2;
        }
        public long KeyId;	
        public long Value ;
        public long Value2 ;
    }

    
}