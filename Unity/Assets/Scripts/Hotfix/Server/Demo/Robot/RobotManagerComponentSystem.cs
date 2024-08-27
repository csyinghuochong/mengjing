using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(RobotManagerComponent))]
    [FriendOf(typeof(RobotManagerComponent))]
    public static partial class RobotManagerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RobotManagerComponent self)
        {
        }
        
        [EntitySystem]
        private static void Destroy(this RobotManagerComponent self)
        {
            async ETTask Remove(int f)
            {
                await FiberManager.Instance.Remove(f);
            }
            
            foreach (int fiberId in self.robots.Keys)
            {
                Remove(fiberId).Coroutine();
            }
        }

        public static string GetRobotNumber(this RobotManagerComponent self, int zone, string robotid)
        {
            int robotNumber = 0;
            string account = string.Empty;
            foreach (var infos in self.robots.Values)
            {
                if (infos.KeyId  == -1)
                {
                    //该账号已经回收 可以直接拿来使用
                    account = infos.Value2;
                    break;
                }

                if (infos.KeyId == zone && infos.Value == robotid)
                {
                    robotNumber++;
                }
            }
            account = $"{zone}_{robotid}_{robotNumber}_0001";   //服务器
            return account;
        }

        public static async ETTask RemoveRobot(this RobotManagerComponent self, int fiberid)
        {
            KeyValuePair infos = null;
            self.robots.TryGetValue(fiberid, out infos);
            
            if (infos != null && infos.KeyId != -1 )
            {
                infos.KeyId = -1;
                FiberManager.Instance.Remove(fiberid).Coroutine();
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask<int> NewRobot(this RobotManagerComponent self, int zone, int robotid)
        {
            string account = self.GetRobotNumber(zone, robotid.ToString());
            
            int fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, self.Zone(), SceneType.Robot, account);
            KeyValuePair infos = new KeyValuePair() { KeyId = zone, Value = robotid.ToString(), Value2 = account };
            
            self.robots.Add(fiberId, infos);
            return fiberId;
        }
    }
}