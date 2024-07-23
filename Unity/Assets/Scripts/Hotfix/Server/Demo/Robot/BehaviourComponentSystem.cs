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
            self.MessageValue = string.Empty;

            RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
            self.RobotConfig = robotConfig;
            switch (robotConfig.Behaviour)
            {
                case 0:
                    self.Behaviours.Add(new KeyValuePair() { KeyId = BehaviourType.Behaviour_Test, Value = "Behaviour_Test" });
                    self.NewBehaviour = BehaviourType.Behaviour_Test;
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
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.BehaviourTimer, self);
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