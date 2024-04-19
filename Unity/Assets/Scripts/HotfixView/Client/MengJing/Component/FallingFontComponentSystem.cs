using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        private static void Awake(this ET.Client.FallingFontComponent self)
        {
           self.OnAwake();
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.FallingFontComponent self)
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
            self.FallingFontShows = new List<FallingFontShowComponent>();
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
            for (int i = self.FallingFontShows.Count - 1; i >= 0; i--)
            {
                FallingFontShowComponent fallingFontShowComponent = self.FallingFontShows[i];
                bool remove = fallingFontShowComponent.LateUpdate();
                if (remove)
                {
                    self.FallingFontShows.RemoveAt(i);
                    fallingFontShowComponent.Dispose();
                }
            }

            if (self.FallingFontShows.Count == 0 && self.Timer!=0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }
    }

}