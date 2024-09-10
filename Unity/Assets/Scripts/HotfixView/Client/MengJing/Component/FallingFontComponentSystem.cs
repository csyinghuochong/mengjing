using System;
using UnityEngine;

namespace ET.Client
{

    [EntitySystemOf(typeof(FallingFontComponent))]
    [FriendOf(typeof(FallingFontComponent))]
    public static partial class FallingFontComponentSystem
    {
        
        [Invoke(TimerInvokeType.FallingFont)]
        public class FallingFont: ATimer<FallingFontComponent>
        {
            protected override void Run(FallingFontComponent self)
            {
                try
                {
                    self.OnUpdate();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this FallingFontComponent self)
        {
           self.OnAwake();
        }
        [EntitySystem]
        private static void Destroy(this FallingFontComponent self)
        {
            for (int i = self.FallingFontShows.Count - 1; i >= 0; i--)
            {
                FallingFontShowComponent fallingFontShowComponent = self.FallingFontShows[i];
                self.FallingFontShows.RemoveAt(i);
                fallingFontShowComponent.Dispose();
            }
            self.FallingFontShows = null;
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
        
        public static void OnAwake(this FallingFontComponent self)
        {
            self.FallingFontShows = new ();
        }

        /// <summary>
        /// 播放飘字特效
        /// </summary>
        /// <param name="targetValue">目标值</param>
        public static void  Play(this FallingFontComponent self, GameObject HeadBar, long targetValue, Unit unit, int type)
        {
            //判断目标是否已经死亡

            FallingFontShowComponent fallingFont = self.AddChild<FallingFontShowComponent>();
            fallingFont.OnInitData(HeadBar, targetValue, unit, type);
            self.FallingFontShows.Add(fallingFont);

            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.FallingFont, self);
            }
        }

        public static void OnUpdate(this FallingFontComponent self)
        {
            if (self.Index < 0)
            {
                self.Index = self.FallingFontShows.Count - 1;
            }

            // 分帧执行
            for (int i = self.BatchSize; i > 0; i--)
            {
                if (self.Index < 0)
                {
                    break;
                }

                FallingFontShowComponent fallingFontShowComponent = self.FallingFontShows[self.Index];
                bool remove = fallingFontShowComponent.LateUpdate();
                if (remove)
                {
                    self.FallingFontShows.RemoveAt(self.Index);
                    fallingFontShowComponent.Dispose();
                }

                self.Index--;
            }

            if (self.FallingFontShows.Count == 0 && self.Timer != 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }
    }
}