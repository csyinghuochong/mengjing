using System;
using ET.Client;
using ET.Server;
using Unity.Mathematics;

namespace ET
{
    [EntitySystemOf(typeof(BehaviourComponent))]
    [FriendOf(typeof(BehaviourComponent))]
    public static partial class BehaviourComponentSystem
    {
        
        [Invoke(TimerInvokeType.BehaviourTimer)]
        public class BehaviourTimer : ATimer<BehaviourComponent>
        {
            protected override void Run(BehaviourComponent self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this ET.BehaviourComponent self, int robotId)
        {
            self.TargetID = 0;
            self.Behaviours.Clear();

            RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
            self.RobotConfig = robotConfig;
            
            //0   测试机器人
            //1   任务机器人
            //2   组队副本机器人
            //3   战场机器人
            //4   世界boos机器人
            //5   角斗场机器人
            //6   solo场机器人
            //7   副本机器人
            //8   塔防机器人
            //9   奔跑大赛机器人
            //10  恶魔活动机器人
            //11  龙与地下城机器人
            //12  宠物挑战赛机器人
            switch (robotConfig.Behaviour)
            {
                case 0:
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Test, Value = "Behaviour_Test" });
                    self.NewBehaviour = BehaviourType.Behaviour_Test;
                    break;
                case 2:
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_TeamDungeon, Value = "Behaviour_TeamDungeon" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_ZhuiJi, Value = "Behaviour_ZhuiJi" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Attack, Value = "Behaviour_Attack" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Target, Value = "Behaviour_Target" });
                    self.NewBehaviour = BehaviourType.Behaviour_TeamDungeon;
                    break;
                case 3:
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Battle, Value = "Behaviour_Battle" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_ZhuiJi, Value = "Behaviour_ZhuiJi" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Attack, Value = "Behaviour_Attack" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Target, Value = "Behaviour_Target" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Retreat, Value = "Behaviour_Retreat" });
                    self.NewBehaviour = BehaviourType.Behaviour_Battle;
                    break;
                case 11:
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_DragonDungeon, Value = "Behaviour_DragonDungeon" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_ZhuiJi, Value = "Behaviour_ZhuiJi" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Attack, Value = "Behaviour_Attack" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Target, Value = "Behaviour_Target" });
                    self.NewBehaviour = BehaviourType.Behaviour_DragonDungeon;
                    break;
                case 12:
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_PetMatch, Value = "Behaviour_PetMatch" });
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_PetMatchFight, Value = "Behaviour_PetMatchFight" });
                    self.NewBehaviour = BehaviourType.Behaviour_PetMatch;
                    break;
                default:
                    break;
            }

            if (!CommonHelp.IfNull(robotConfig.AIParameter))
            {
                string[] positionList = robotConfig.AIParameter.Split('@');
                string[] positions = positionList[RandomHelper.RandomNumber(0, positionList.Length)].Split(';');
                if (positions != null && positions.Length >= 4)
                {
                    float range = float.Parse(positions[3]);
                    self.TargetPosition = new float3(float.Parse(positions[0]) + RandomHelper.RandomNumberFloat(-1 * range, range),
                        float.Parse(positions[1]),
                        float.Parse(positions[2]) + RandomHelper.RandomNumberFloat(-1 * range, range));
                }
            }

            self.ActDistance = self.Root().GetComponent<AttackComponent>().AttackDistance;

            self.InitBehaviour();
        }

        public static void InitBehaviour(this BehaviourComponent self)
        {
            self.TargetID = 0;
            
            int NewBehaviour = -1;
            switch (self.RobotConfig.Behaviour)
            { 
                case 0:
                    NewBehaviour = BehaviourType.Behaviour_Test;
                    break;
                case 2:
                    NewBehaviour = BehaviourType.Behaviour_TeamDungeon;
                    break;
                case 3:
                    NewBehaviour = BehaviourType.Behaviour_Battle;
                    break;
                case 11:
                    NewBehaviour = BehaviourType.Behaviour_DragonDungeon;
                    break;
                case 12:
                    NewBehaviour = BehaviourType.Behaviour_PetMatch;
                    break;
                default:
                    break;
            }
                
            if (NewBehaviour < 0)
            {
                Log.Error($"behaviourComponent.RobotConfig:  {self.RobotConfig}");
                return;
            }
            self.Stop();
            self.ChangeBehaviour(NewBehaviour);
            self.Start();
        }

        public static int GetBehaviour(this BehaviourComponent self)
        {
            return self.RobotConfig != null ? self.RobotConfig.Behaviour : 0;
        }

        public static bool HaveHaviour(this BehaviourComponent self, int behaviour)
        {
            for (int i = 0; i < self.Behaviours.Count; i++)
            {
                if (self.Behaviours[i].KeyId == behaviour)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ChangeBehaviour(this BehaviourComponent self, int behaviour)
        {
            for (int i = 0; i < self.Behaviours.Count; i++)
            {
                if (self.Behaviours[i].KeyId == behaviour)
                {
                    //Log.Debug($"ChangeBehaviour: {self.Behaviours[i].Value}");
                }
            }

            self.NewBehaviour = behaviour;
        }

        public static void Check(this BehaviourComponent self)
        {
            if (self.NewBehaviour < 0)
            {
                return;
            }
            if (self.Parent == null)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                return;
            }

            for (int i = 0; i < self.Behaviours.Count; i++)
            {
                BehaviourDispatcherComponent.Instance.AIHandlers.TryGetValue(self.Behaviours[i].Value, out BehaviourHandler aaiHandler);
                if (aaiHandler == null)
                {
                    Log.Error($"not found aihandler: {self.Behaviours[i].Value}");
                    continue;
                }

                bool ret = aaiHandler.Check(self, null);
                if (!ret) //不满足条件
                {
                    continue;
                }

                if (self.Current == aaiHandler.BehaviourId())
                {
                    break;
                }

                self.NewBehaviour = 0;
                self.Cancel(); // 取消之前的行为
                ETCancellationToken cancellationToken = new ETCancellationToken();
                self.CancellationToken = cancellationToken;
                self.Current = aaiHandler.BehaviourId();

                aaiHandler.Execute(self, null, cancellationToken).Coroutine();
                return;
            }
        }

        public static void Start(this BehaviourComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.BehaviourTimer, self);
        }

        public static void Stop(this BehaviourComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.TargetID = 0;
            self.NewBehaviour = 0;
            self.Cancel();
        }

        private static void Cancel(this BehaviourComponent self)
        {
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
            self.Current = 0;
        }

        public static void Exit(this BehaviourComponent self, string btype)
        {
            Scene zoneScene = self.Root();
            //zoneScene.GetParent<RobotManagerComponent>().RemoveRobot(zoneScene, btype).Coroutine();
        }
        
        
        [EntitySystem]
        private static void Destroy(this ET.BehaviourComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
            self.Current = 0;
        }
    }
}