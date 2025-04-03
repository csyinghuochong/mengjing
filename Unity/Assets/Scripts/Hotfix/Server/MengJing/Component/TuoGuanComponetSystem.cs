using System;

namespace ET.Server
{

    [EntitySystemOf(typeof(TuoGuanComponet))]
    [FriendOf(typeof(TuoGuanComponet))]
    public static partial class TuoGuanComponetSystem
    {

        [Invoke(TimerInvokeType.TuoGuanTimer)]
        public class TuoGuanTimer : ATimer<TuoGuanComponet>
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
            self.AIConfigId = 14;
            self.PatrolRange = 0f;
            self.SceneType = self.Scene().GetComponent<MapComponent>().MapType;
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.TuoGuanComponet self)
        {

        }

        [EntitySystem]
        private static void Destroy(this ET.Server.TuoGuanComponet self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
            self.Current = 0;
        }
        
        private static void Check(this TuoGuanComponet self)
        {

        }
        
    }

}