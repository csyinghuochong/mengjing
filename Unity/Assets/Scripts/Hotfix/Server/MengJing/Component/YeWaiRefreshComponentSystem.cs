using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (YeWaiRefreshComponent))]
    [FriendOf(typeof (YeWaiRefreshComponent))]
    public static partial class YeWaiRefreshComponentSystem
    {
        
        [Invoke(TimerInvokeType.RefreshMonsterTimer)]
        public class RefreshMonsterTimer: ATimer<YeWaiRefreshComponent>
        {
            protected override void Run(YeWaiRefreshComponent self)
            {
                try
                {
                    self.OnTimer();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this YeWaiRefreshComponent self)
        {
            self.LogTest = false;
            self.RandomTime = RandomHelper.RandomNumber(0, 10);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.RefreshMonsterTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this YeWaiRefreshComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        /// <summary>
        /// 起服 和 零点会调用
        /// </summary>
        /// <param name="self"></param>
        /// <param name="openDay"></param>
        public static void OnBaoZangMonster(this YeWaiRefreshComponent self, int openDay)
        {
            int monsterPosiID = 0;
            switch (openDay)
            {
                case 1:
                    monsterPosiID = 90001;
                    break;
                case 2:
                    monsterPosiID = 90002;
                    break;
                case 3:
                    monsterPosiID = 90003;
                    break;
                case 4:
                    monsterPosiID = 90003;
                    break;
                case 5:
                    monsterPosiID = 90004;
                    break;
                case 6:
                    monsterPosiID = 90004;
                    break;
                case 7:
                    monsterPosiID = 90005;
                    break;
            }

            //monsterPosiID = 90001;

            //超过7天不刷新
            if (monsterPosiID == 0)
            {
                return;
            }

            // 将指定日期转换成时间戳：如 2022-8-22 22:56:30
            //获取当前时间
            DateTime dateTime = TimeHelper.DateTimeNow();

            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            int hour = 12;
            int min = 0;
            int sec = 0;

            bool AddEveningStatus = false;

            if (dateTime.Hour >= 12)
            {
                if (dateTime.Hour <= 22 && dateTime.Minute < 30)
                {
                    //设置晚上刷新
                    AddEveningStatus = true;
                }
            }
            else
            {
                //刷新2次

                //白天刷新
                long createTime = ((new DateTime(year, month, day, hour, min, sec).ToUniversalTime().Ticks - 621355968000000000) / 10000);
                self.TimeCreateMonster(createTime, monsterPosiID); //第一次刷新

                //设置晚上刷新
                AddEveningStatus = true;
            }

            if (AddEveningStatus)
            {
                //刷新一次
                hour = 22;
                min = 30;

                long createTime = ((new DateTime(year, month, day, hour, min, sec).ToUniversalTime().Ticks - 621355968000000000) / 10000);

                self.TimeCreateMonster(createTime, monsterPosiID);
            }
        }

        public static void TimeCreateMonster(this YeWaiRefreshComponent self, long createTime, int monsterPosiID)
        {
            MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.Get(monsterPosiID);
            int mtype = monsterPosition.Type;
            string[] position = monsterPosition.Position.Split(',');
            string[] refreshPar = monsterPosition.Par.Split(',');

            for (int i = 0; i <monsterPosition.MonsterID.Length; i++ )
            {
                self.RefreshMonsters.Add(new RefreshMonster()
                {
                    MonsterId = monsterPosition.MonsterID[i],
                    //NextTime = TimeHelper.ServerNow() + int.Parse(refreshPar[0]) * 1000,  //下次刷的时间戳
                    NextTime = createTime, //下次刷的时间戳
                    PositionX = float.Parse(position[0]),
                    PositionY = float.Parse(position[1]),
                    PositionZ = float.Parse(position[2]),
                    Number = monsterPosition.CreateNum[i],
                    Range = (float)monsterPosition.CreateRange,
                    Rotation = monsterPosition.Create,
                    Interval = -1, //-1只刷一次
                });
            }
        }

        /// <summary>
        /// 起服或者零点刷新一次
        /// </summary>
        /// <param name="self"></param>
        /// <param name="openDay"></param>
        public static void OnZeroClockUpdate_Old(this YeWaiRefreshComponent self, int openDay)
        {
            //if (openDay <= 0)
            //{
            //    openDay = 1;
            //}

            //MapComponent mapComponent = self.DomainScene().GetComponent<MapComponent>();
            //if (mapComponent.SceneTypeEnum == SceneTypeEnum.BaoZang)
            //{
            //    self.OnBaoZangMonster(openDay);
            //}
            //Log.Debug($"YeWaiRefreshComponentOnZeroClockUpdate: {self.DomainZone()}  {openDay}");
        }

        /// <summary>
        /// 起服或者零点刷新一次
        /// </summary>
        /// <param name="self"></param>
        /// <param name="openDay"></param>
        public static void OnZeroClockUpdate(this YeWaiRefreshComponent self, int openDay)
        {
            if (openDay <= 0)
            {
                openDay = 1;
            }
            Log.Error($"FubenCenter定时刷新: {self.Zone()} {self}");
            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            int sceneId = mapComponent.SceneId;

            Dictionary<int, FuntionConfig> keyValuePairs = FuntionConfigCategory.Instance.GetAll();
            foreach ((int functionId, FuntionConfig FuntionConfig) in keyValuePairs)
            {
                if (sceneId == 0 || sceneId != FuntionConfig.SceneId)
                {
                    continue;
                }

                if (!FunctionHelp.IsFunctionDayOpen((int)dateTime.DayOfWeek, functionId))
                {
                    continue;
                }

                if (functionId == 1060)
                {
                    Log.Warning($"活动-世界领主: {FuntionConfig.CreateMonsterPosi[0]}");
                }

                if (functionId == 1061)
                {
                    Log.Warning($"活动-宝藏之地: {FuntionConfig.CreateMonsterPosi[0]}");
                }

                FubenHelp.CreateMonsterList(self.Scene(), FuntionConfig.CreateMonsterPosi);
            }
            
        }

        public static void OnAddRefreshList(this YeWaiRefreshComponent self, Unit unit, long reTime)
        {
            float3 vector3 = unit.GetBornPostion();
            self.RefreshMonsters.Add(new RefreshMonster()
            {
                MonsterId = unit.ConfigId,
                NextTime = TimeHelper.ServerNow() + reTime,
                PositionX = vector3.x,
                PositionY = vector3.y,
                PositionZ = vector3.z,
                Number = 1,
                Range = 0,
                Interval = -1,
            });
        }

        /// <summary>
        /// 间隔时间刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="createMonster"></param>
        /// <param name="fubenDifficulty"></param>
        public static void CreateMonsterList(this YeWaiRefreshComponent self, string createMonster)
        {
            if (CommonHelp.IfNull(createMonster))
            {
                return;
            }

            string[] monsters = createMonster.Split('@');
            for (int i = 0; i < monsters.Length; i++)
            {
                if (string.IsNullOrEmpty(monsters[i]))
                {
                    continue;
                }

                //3;-63.68,0.00,-19.01;71010001;1,1,100,600
                string[] mondels = monsters[i].Split(';');
                string[] position = mondels[1].Split(',');
                string monsterid = mondels[2];
                string[] mcount = mondels[3].Split(',');

                self.RefreshMonsters.Add(new RefreshMonster()
                {
                    MonsterId = int.Parse(monsterid),
                    NextTime = TimeHelper.ServerNow() + int.Parse(mcount[2]) * 1000,
                    PositionX = float.Parse(position[0]),
                    PositionY = float.Parse(position[1]),
                    PositionZ = float.Parse(position[2]),
                    Number = int.Parse(mcount[0]),
                    Range = int.Parse(mcount[1]),
                    Interval = int.Parse(mcount[3]) * 1000,
                });
            }
        }

        /// <summary>
        /// 间隔时间刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="monsterPos"></param>
        /// <param name="fubenDifficulty"></param>
        public static void CreateMonsterByPos(this YeWaiRefreshComponent self, int monsterPos)
        {
            if (monsterPos == 0)
            {
                return;
            }

            //Id      NextID  Type Position             MonsterID CreateRange CreateNum Create    Par(3代表刷新时间)
            //10001   10002   2    - 71.46,0.34,-5.35   81000002       0           1       90    30,60
            MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.Get(monsterPos);
            int mtype = monsterPosition.Type;
            string[] position = monsterPosition.Position.Split(',');
            string[] refreshPar = monsterPosition.Par.Split(',');
            //Log.Debug($"野外怪定时刷新bbbbbb:  {self.DomainZone()}区：   MonsterID：{monsterPosition.MonsterID} ");

            for (int i = 0; i < monsterPosition.MonsterID.Length; i++)
            {
                self.RefreshMonsters.Add(new RefreshMonster()
                {
                    MonsterId = monsterPosition.MonsterID[i],
                    NextTime = TimeHelper.ServerNow() + int.Parse(refreshPar[0]) * 1000,
                    PositionX = float.Parse(position[0]),
                    PositionY = float.Parse(position[1]),
                    PositionZ = float.Parse(position[2]),
                    Number = monsterPosition.CreateNum[i],
                    Range = (float)monsterPosition.CreateRange,
                    Interval = int.Parse(refreshPar[1]) * 1000,
                    Rotation = monsterPosition.Create,
                });
            }
        }
        
        /// <summary>
        /// 间隔时间刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="monsterPos"></param>
        /// <param name="fubenDifficulty"></param>
        /// // 类型3：  30,60 30s后开始刷新     每60s刷一轮
        // 类型7    10,2@20,2             10s 刷新一波 20刷新2波  后面跟的是怪物数量,怪物ID从前面随机获取
        public static void CreateMonsterByRandom(this YeWaiRefreshComponent self, MonsterPositionConfig monsterPosition)
        {
            if (monsterPosition == null)
            {
                return;
            }

            //521401,521402,521403
            //10,2@20,2@30,2@40,2@50,2@60,2
            
            //Id      NextID  Type Position             MonsterID CreateRange CreateNum Create    Par(3代表刷新时间)
            //10001   10002   2    - 71.46,0.34,-5.35   81000002       0           1       90    30,60
            int mtype = monsterPosition.Type;
            if (mtype != 7)
            {
                Log.Error("mtype != 7");
                return;
            }

            string[] position = monsterPosition.Position.Split(',');
            string[] refreshPar = monsterPosition.Par.Split('@'); //10,2@20,2@30,2@40,2@50,2@60,2
            
            
            List<float3> positionList = new List<float3>();
            for (int i = 0; i < position.Length; i+=3)
            {
                positionList.Add(new float3(float.Parse(position[i]), float.Parse(position[i+1]), float.Parse(position[i+2])));
            }
            

            //Log.Debug($"野外怪定时刷新bbbbbb:  {self.DomainZone()}区：   MonsterID：{monsterPosition.MonsterID} ");
            
            for ( int wave = 0; wave < refreshPar.Length; wave++  )
            {
                string[] wavePar = refreshPar[wave].Split(',');
                long waitTimer = int.Parse(wavePar[0]) * 1000;
                int monsterNum = int.Parse(wavePar[1]);
                
                List<float3> monsterpositionList = new List<float3>();  
                
                int[] indexlist = RandomHelper.GetRandoms(positionList.Count, 0, positionList.Count);
                for (int i = 0; i < indexlist.Length; i++)
                {
                    monsterpositionList.Add(positionList[indexlist[i]]);
                }
                
                for (int i = monsterpositionList.Count; i < monsterNum; i++)
                { 
                    int positionindex = RandomHelper.RandomNumber(0, positionList.Count);
                    monsterpositionList.Add(positionList[positionindex]);
                }

                for (int i = 0; i < monsterNum; i++)
                {
                    int randomIndex =   RandomHelper.RandomNumber(0, monsterPosition.MonsterID.Length);
                    int randomMonsterid = monsterPosition.MonsterID[ randomIndex ];
                    self.RefreshMonsters.Add(new RefreshMonster()
                    {
                        MonsterId = randomMonsterid,
                        NextTime = TimeHelper.ServerNow() + waitTimer,
                        PositionX = monsterpositionList[i].x,
                        PositionY = monsterpositionList[i].y,
                        PositionZ = monsterpositionList[i].z,
                        Number = 1,
                        Range = (float)monsterPosition.CreateRange,
                        Interval = -1,
                        Rotation = monsterPosition.Create,
                    });
                }
            }


            //Log.Debug($"野外怪定时刷新bbbbbb:  {self.DomainZone()}区：   MonsterID：{monsterPosition.MonsterID} ");

            
        }

        /// <summary>
        /// 固定时间刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="createMonster"></param>
        /// <param name="fubenDifficulty"></param>
        public static void CreateMonsterList_2(this YeWaiRefreshComponent self, string createMonster)
        {
            if (CommonHelp.IfNull(createMonster))
            {
                return;
            }

            string[] monsters = createMonster.Split('@');
            for (int i = 0; i < monsters.Length; i++)
            {
                if (string.IsNullOrEmpty(monsters[i]))
                {
                    continue;
                }

                //5;-50,0,2;80002001;10,25;1230,2030
                //5;-29,0,0;72009002;1,1;2015
                string[] mondels = monsters[i].Split(';');
                int mtype = int.Parse(mondels[0]);
                string[] position = mondels[1].Split(','); //-50,0,2
                int monsterid = int.Parse(mondels[2]); //80002001
                string[] mcount = mondels[3].Split(','); //10,25
                string[] timers = mondels[4].Split(','); //1230,2030
                for (int t = 0; t < timers.Length; t++)
                {
                    long leftTime = self.LeftTime(timers[t]);
                    if (leftTime < 0)
                    {
                        leftTime += TimeHelper.OneDay;
                    }

                    Log.Debug($"野外怪定时刷新ccccc  {self.Zone()}  区：MonsterID： {monsterid} ");

                    self.RefreshMonsters.Add(new RefreshMonster()
                    {
                        MonsterId = monsterid,
                        NextTime = TimeHelper.ServerNow() + leftTime,
                        PositionX = float.Parse(position[0]),
                        PositionY = float.Parse(position[1]),
                        PositionZ = float.Parse(position[2]),
                        Number = int.Parse(mcount[0]),
                        Range = int.Parse(mcount[1]),
                        Interval = mtype == 5? TimeHelper.OneDay : -1,
                    });
                }
            }
        }

        /// <summary>
        /// 固定时间刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="monsterPos"></param>
        /// <param name="fubenDifficulty"></param>
        public static void CreateMonsterByPos_2(this YeWaiRefreshComponent self, int monsterPos)
        {
            if (monsterPos == 0)
            {
                return;
            }

            //5;-50,0,2;80002001;10,25;1230,203060
            MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.Get(monsterPos);
            int mtype = monsterPosition.Type;
            string[] position = monsterPosition.Position.Split(',');

            string[] timers = monsterPosition.Par.Split(','); //1230,2030
            for (int t = 0; t < timers.Length; t++)
            {
                long leftTime = self.LeftTime(timers[t]);
                if (leftTime < 0)
                {
                    leftTime += TimeHelper.OneDay;
                }

                //Log.Debug($"野外怪定时刷新ddddd  {self.DomainZone()} 区： MonsterID： {monsterPosition.MonsterID} ");
                for (int monster = 0; monster < monsterPosition.MonsterID.Length; monster++)
                {
                    self.RefreshMonsters.Add(new RefreshMonster()
                    {
                        MonsterId = monsterPosition.MonsterID[monster],
                        NextTime = TimeHelper.ServerNow() + leftTime,
                        PositionX = float.Parse(position[0]),
                        PositionY = float.Parse(position[1]),
                        PositionZ = float.Parse(position[2]),
                        Number = monsterPosition.CreateNum[monster],
                        Range = (float)monsterPosition.CreateRange,
                        Interval = mtype == 5? TimeHelper.OneDay : -1,
                        Rotation = monsterPosition.Create,
                    });
                }
            }
        }

        public static long LeftTime(this YeWaiRefreshComponent self, string targetTime)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            int huor = dateTime.Hour;
            int minute = dateTime.Minute;
            int second = dateTime.Second;
            int curtime = huor * 3600 + minute * 60 + second;

            int targetHour = int.Parse(targetTime.Substring(0, 2));
            int targetMinute = int.Parse(targetTime.Substring(2, 2));
            int dsttime = targetHour * 3600 + targetMinute * 60;
            return (dsttime - curtime) * 1000;
        }

        public static void BaozangzhiRefresh(this YeWaiRefreshComponent self)
        {
            self.RefreshMonsters.Clear();

            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);

            FubenHelp.CreateMonsterList(self.Scene(), sceneConfig.CreateMonsterPosi);
        }

        public static void OnTimer(this YeWaiRefreshComponent self)
        {
            long time = TimeHelper.ServerNow() + self.RandomTime;
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();

            if (!self.LogTest && mapComponent.SceneType == SceneTypeEnum.BaoZang)
            {
                self.LogTest = true;
                //self.BaozangzhiRefresh();
                //Log.Console($"野外定时怪[数量]：{self.DomainZone()} {self.RefreshMonsters.Count}");
            }

            for (int i = self.RefreshMonsters.Count - 1; i >= 0; i--)
            {
                RefreshMonster refreshMonster = self.RefreshMonsters[i];

                if (time < refreshMonster.NextTime)
                {
                    continue;
                }

                if (refreshMonster.Interval == -1)
                {
                    self.RefreshMonsters.RemoveAt(i);

                    if (mapComponent.SceneType == SceneTypeEnum.BaoZang)
                    {
                        Log.Debug($" self.RefreshMonsters.RemoveAt : {i}");
                    }
                }
                else
                {
                    refreshMonster.NextTime = refreshMonster.NextTime + refreshMonster.Interval;
                    self.RefreshMonsters[i] = refreshMonster;
                }

                //DateTime dateTime =  TimeHelper.DateTimeNow();
                //根据refreshMonster.Time可以纠正时间
                self.CreateMonsters(refreshMonster).Coroutine();
            }
        }

        public static async ETTask CreateMonsters(this YeWaiRefreshComponent self, RefreshMonster refreshMonster)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(refreshMonster.MonsterId);
            float3 form = new float3(refreshMonster.PositionX, refreshMonster.PositionY, refreshMonster.PositionZ);
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();

            if (mapComponent.SceneType == SceneTypeEnum.UnionRace)
            {
                Log.Warning($"refreshMonster.UnionRace: {refreshMonster.MonsterId}");
            }

            if (mapComponent.SceneType == SceneTypeEnum.MiJing && monsterConfig.MonsterType == MonsterTypeEnum.Boss)
            {
                self.Scene().GetComponent<MiJingDungeonComponent>().BossId = refreshMonster.MonsterId;

                if (!CommonHelp.IsBanHaoZone(self.Zone()) && ServerHelper.GetServeOpenrDay( self.Zone()) > 0)
                {
                    G2Robot_MessageRequest G2Robot_MessageRequest = G2Robot_MessageRequest.Create();
                    G2Robot_MessageRequest.Zone = self.Zone();
                    G2Robot_MessageRequest.MessageType = NoticeType.YeWaiBoss;
                    G2Robot_MessageRequest.Message = $"{mapComponent.SceneId}@{form.x};{form.y};{form.z}@{refreshMonster.MonsterId}@2";
                    ActorId robotSceneId = UnitCacheHelper.GetRobotServerId();
                    self.Root().GetComponent<MessageSender>() .Send(robotSceneId,G2Robot_MessageRequest);
                }
            }

            int monsterNumber = UnitHelper.GetUnitListByCamp(self.GetParent<Scene>(), UnitType.Monster, monsterConfig.MonsterCamp).Count;
            if (mapComponent.SceneType == SceneTypeEnum.Battle)
            {
                if (monsterConfig.MonsterSonType != 55 && monsterConfig.MonsterSonType != 56
                    && monsterNumber >= GlobalValueConfigCategory.Instance.Get(59).Value2)
                {
                    return;
                }
            }
            else if (mapComponent.SceneType == SceneTypeEnum.BaoZang)
            {
                if (monsterNumber >= GlobalValueConfigCategory.Instance.Get(78).Value2)
                {
                    return;
                }
            }
            else
            {
                if (monsterNumber >= 1000)
                {
                    Log.Console($"monsterNumber >= 1000:  {mapComponent.SceneId}");
                    return;
                }
            }

            if (refreshMonster.Number > 100)
            {
                Log.Error($"refreshMonster.Number > 100");
                return;
            }

            for (int i = 0; i < refreshMonster.Number; i++)
            {
                float range = refreshMonster.Range;
                float3 vector3 = new float3(form.x + RandomHelper.RandomNumberFloat(-1 * range, range), form.y,
                    form.z + RandomHelper.RandomNumberFloat(-1 * range, range));
                UnitFactory.CreateMonster(self.GetParent<Scene>(), refreshMonster.MonsterId, vector3,
                    new CreateMonsterInfo() { Camp = monsterConfig.MonsterCamp, Rotation = refreshMonster.Rotation, });
                await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            }

            if (monsterConfig.Id == 72009021 || monsterConfig.Id == 72009022 || monsterConfig.Id == 72009023 || monsterConfig.Id == 72009024 ||
                monsterConfig.Id == 72009021)
            {
                string noticeContent =
                        $"神器活动!<color=#B6FF00>{monsterConfig.MonsterName}</color>携带神器出现在地图<color=#FFA313>{"宝藏之地"}</color>,想要挑战的玩家请在主城宝藏之地处进入!";
                BroadCastHelper.SendBroadMessage(self.Root(), NoticeType.Notice, noticeContent);
            }
        }
    }
}