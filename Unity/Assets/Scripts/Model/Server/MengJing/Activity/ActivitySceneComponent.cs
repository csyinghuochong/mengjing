using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 活动服
    /// </summary>
    [ComponentOf(typeof(Scene))]
    [FriendOf(typeof(DBDayActivityInfo))]
    public class ActivitySceneComponent:        Entity, IAwake, IDestroy
    {

        public long Timer;
        public long ActivityTimer;

        public List<ActivityTimer> ActivityTimerList = new List<ActivityTimer>();

        //map进程ID，用来给进程广播消息，以后可能需要拆分出去
        public List<ActorId> MapIdList = new List<ActorId>();
        
        public long NextSingleHappyTime = 0;

        public DBDayActivityInfo DBDayActivityInfo { get; set; }

        public Dictionary<int, List<KeyValuePair<long, long>>> TurtleSupportList = new Dictionary<int, List<KeyValuePair<long, long>>>();

        public List<PetMingPlayerInfo> PetMingList = new List<PetMingPlayerInfo>();
        public long PetMingLastTime = 0;

        public int CheckIndex = 0;
    }
    
}
