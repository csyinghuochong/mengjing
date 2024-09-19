using System;

namespace ET.Server
{

    [EntitySystemOf(typeof(TuoGuanComponet))]
    [FriendOf(typeof(TuoGuanComponet))]
    public static partial class TuoGuanComponetSystem
    {
        
        [Invoke(TimerInvokeType.TuoGuanTimer)]
        public class TuoGuanTimer: ATimer<TuoGuanComponet>
        {
            protected override void Run(TuoGuanComponet self)
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
        private static void Awake(this ET.Server.TuoGuanComponet self)
        {

        }
        
        [EntitySystem]
        private static void Deserialize(this ET.Server.TuoGuanComponet self)
        {

        }

        private static void Check(this TuoGuanComponet self)
        {
            
        }
    }

}