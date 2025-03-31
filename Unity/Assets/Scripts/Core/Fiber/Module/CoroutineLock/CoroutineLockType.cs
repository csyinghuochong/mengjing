namespace ET
{
    public static class CoroutineLockType
    {
        public const int None = 0;
        public const int Location = 1;                  // location进程上使用
        public const int MessageLocationSender = 2;       // MessageLocationSender中队列消息 
        public const int Mailbox = 3;                   // Mailbox中队列
        public const int UnitId = 4;                    // Map服务器上线下线时使用
        public const int DB = 5;
        public const int Resources = 6;
        public const int ResourcesLoader = 7;
        public const int  LoadUIBaseWindows = 8;

        public const int LoginCenterLock = 9;
        public const int GateLoginLock = 10;
        public const int CreateRole = 11;
        public const int LoginRealm = 12;
        public const int LoginGate = 13;
        public const int Register = 14;
        public const int GetServerList = 15;
        public const int DBCache = 20;
        public const int NewRobot = 21;
        public const int TeamDungeon = 22;
        public const int Received = 23;
        public const int Sell = 24;
        public const int Buy = 25;
        public const int XiaJia = 26;
        public const int Recharge = 27;
        public const int RemoveRobot = 29;
        public const int Transfer = 30;
        public const int Popularize = 31;
        public const int JiaYuan = 32;
        public const int UnionCreate = 33;
        public const int UnionOperate = 34;
        public const int Donation = 35;  //捐献
        public const int PetMine = 36;
        public const int LoginAccount = 37;
        public const int Battle = 38;
        public const int Chat = 39;
        public const int EMail = 40;
        public const int Season = 41;
        
        public const int BeiYong = 99;
        public const int Max = 100; // 这个必须最大
    }
}