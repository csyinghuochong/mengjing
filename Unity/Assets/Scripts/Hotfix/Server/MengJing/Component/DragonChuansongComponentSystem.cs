using System;
using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(DragonChuansongComponent))]
    [FriendOf(typeof(DragonChuansongComponent))]
    public static partial class DragonChuansongComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DragonChuansongComponent self)
        {

        }
        
        [Invoke(TimerInvokeType.DragonChuansongTimer)]
        public class DragonChuansongTimer: ATimer<DragonChuansongComponent>
        {
            protected override void Run(DragonChuansongComponent self)
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

        public static void Check(this DragonChuansongComponent self)
        {
            
        }
    }
}