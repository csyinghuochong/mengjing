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

        public static int GetRobotNumber(this RobotManagerComponent self, int zone, int robotid)
        {
            int number = 0;
            foreach (var infos in self.robots.Values)
            {
                if (infos.Key == zone && infos.Value == robotid)
                {
                    number++;
                }
            }

            return number;
        }

        public static async ETTask RemoveRobot(this RobotManagerComponent self, int fiberid)
        {
            
            await ETTask.CompletedTask;
        }

        public static async ETTask<int> NewRobot(this RobotManagerComponent self, int zone, int robotid)
        {
            int robotNumber = self.GetRobotNumber(zone, robotid);
            string account = $"{zone}_{robotid}_{robotNumber}_0001";   //服务器
            int fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, self.Zone(), SceneType.Robot, account);
            KeyValuePair<int, int> infos = new KeyValuePair<int, int>(zone, robotid);
            self.robots.Add(fiberId, infos);
            return fiberId;
        }
    }
}