using System;

namespace ET.Server
{
    [FriendOf(typeof (ChatServerComponent))]
    [EntitySystemOf(typeof (ChatServerComponent))]
    public static partial class ChatSceneComponentSystem
    {
        [Invoke(TimerInvokeType.ChatSceneTimer)]
        public class ChatSceneTimer: ATimer<ChatServerComponent>
        {
            protected override void Run(ChatServerComponent self)
            {
                try
                {
                    self.OnCheck();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this ChatServerComponent self)
        {
            self.WordSayList.Clear();
            self.OnZeroClockUpdate();
        }

        [EntitySystem]
        private static void Destroy(this ChatServerComponent self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.Timer);

            foreach (var chatInfoUnit in self.ChatInfoUnitsDict.Values)
            {
                chatInfoUnit?.Dispose();
            }
        }

        public static void OnZeroClockUpdate(this ChatServerComponent self)
        {
            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeHelper.DateTimeNow();
            int huor = dateTime.Hour;
            int minute = dateTime.Minute;
            int second = dateTime.Second;
            int time1 = huor * 3600 + minute * 60 + second;

            for (int i = 0; i < ConfigData.WorldSayList.Count; i++)
            {
                WorldSayConfig worldSayConfig = ConfigData.WorldSayList[i];

                if (!worldSayConfig.OpenDay.Contains((int)dateTime.DayOfWeek) && worldSayConfig.OpenDay[0] != -1)
                {
                    continue;
                }

                int hour2 = worldSayConfig.Time / 100;
                int minute2 = worldSayConfig.Time % 100;
                int time2 = hour2 * 3600 + minute2 * 60;

                int leftTime = time2 - time1;
                if (leftTime > 0)
                {
                    worldSayConfig.ServerTime = serverTime + leftTime * 1000;
                    self.WordSayList.Add(worldSayConfig);
                }
            }

            self.WordSayList.Sort(delegate(WorldSayConfig a, WorldSayConfig b) { return a.Time - b.Time; });

            self.StartTimer();
        }

        public static void StartTimer(this ChatServerComponent self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            if (self.WordSayList.Count > 0)
            {
                timerComponent.Remove(ref self.Timer);
                self.Timer = timerComponent.NewOnceTimer(self.WordSayList[0].ServerTime, TimerInvokeType.ChatSceneTimer, self);
            }
            else
            {
                timerComponent.Remove(ref self.Timer);
            }
        }

        public static void OnCheck(this ChatServerComponent self)
        {
            if (self.WordSayList.Count > 0)
            {
                WorldSayConfig worldSayConfig = self.WordSayList[0];
                self.WordSayList.RemoveAt(0);

                // ServerMessageHelper.SendServerMessage(DBHelper.GetChatServerId(self.DomainZone()),
                //     NoticeType.Notice, worldSayConfig.Conent).Coroutine();
            }

            self.StartTimer();
        }

        public static void Add(this ChatServerComponent self, ChatInfoUnit chatInfoUnit)
        {
            if (self.ChatInfoUnitsDict.ContainsKey(chatInfoUnit.Id))
            {
                Log.Error($"chatInfoUnit is exist! ： {chatInfoUnit.Id}");
                return;
            }

            self.ChatInfoUnitsDict.Add(chatInfoUnit.Id, chatInfoUnit);
        }

        public static ChatInfoUnit Get(this ChatServerComponent self, long id)
        {
            self.ChatInfoUnitsDict.TryGetValue(id, out ChatInfoUnit chatInfoUnit);
            return chatInfoUnit;
        }

        public static void Remove(this ChatServerComponent self, long id)
        {
            if (self.ChatInfoUnitsDict.TryGetValue(id, out ChatInfoUnit chatInfoUnit))
            {
                self.ChatInfoUnitsDict.Remove(id);
                chatInfoUnit?.Dispose();
            }
        }
    }
}