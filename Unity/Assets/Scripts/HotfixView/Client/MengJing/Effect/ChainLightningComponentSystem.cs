using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ET.Client
{
    [EntitySystemOf(typeof(ChainLightningComponent))]
    [FriendOf(typeof(ChainLightningComponent))]
    public static partial class ChainLightningComponentSystem
    {
        [Invoke(TimerInvokeType.ChainLightningTimer)]
        public class ChainLightningTimer : ATimer<ChainLightningComponent>
        {
            protected override void Run(ChainLightningComponent self)
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
        private static void Awake(this ChainLightningComponent self, GameObject go)
        {
            self._lineRender = go.GetComponent<LineRenderer>();
            self._linePosList = new List<Vector3>();

            self.Start = go.transform;
            self.End = go.transform;

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(100, TimerInvokeType.ChainLightningTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this ChainLightningComponent self)
        {
            self.Start = null;
            self.End = null;
            self.UsePosition = false;
            self._linePosList = null;
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        public static void OnUpdate(this ChainLightningComponent self)
        {
            //判断是否暂停，未暂停则进入分支
            if (self.Start == null || self._lineRender == null)
            {
                return;
            }

            if (!self.UsePosition && self.End == null)
            {
                return;
            }

            if (Time.timeScale != 0)
            {
                self._linePosList.Clear();

                Vector3 startPos = self.Start.position + Vector3.up * self.yOffset;
                Vector3 endPos = Vector3.zero;
                if (self.UsePosition)
                {
                    endPos = self.EndPosition + Vector3.up * self.yOffset;
                }
                else
                {
                    endPos = self.End.position + Vector3.up * self.yOffset;
                }

                if (self.TextureOffsetX < 2f)
                {
                    self.TextureOffsetX += 0.1f;
                }
                else
                {
                    self.TextureOffsetX = 0;
                }

                Vector2 vector2 = new Vector2(self.TextureOffsetX, 0);
                self._lineRender.material.SetTextureOffset("_MainTex", vector2);

                //获得开始点与结束点之间的随机生成点
                self.CollectLinPos(startPos, endPos, self.displacement);

                self._linePosList.Add(endPos);
                //把点集合赋给LineRenderer

                self._lineRender.positionCount = (self._linePosList.Count);
                for (int i = 0, n = self._linePosList.Count; i < n; i++)
                {
                    self._lineRender.SetPosition(i, self._linePosList[i]);
                }
            }
        }

        //收集顶点，中点分形法插值抖动  
        public static void CollectLinPos(this ChainLightningComponent self, Vector3 startPos, Vector3 destPos, float displace)
        {
            //递归结束的条件
            if (displace < self.detail)
            {
                self._linePosList.Add(startPos);
            }
            else
            {
                float midX = (startPos.x + destPos.x) / 2;
                float midY = (startPos.y + destPos.y) / 2;
                float midZ = (startPos.z + destPos.z) / 2;

                midX += (float)(Random.value - 0.5) * displace;

                midY += (float)(Random.value - 0.5) * displace;

                midZ += (float)(Random.value - 0.5) * displace;

                Vector3 midPos = new Vector3(midX, midY, midZ);

                //递归获得点

                self.CollectLinPos(startPos, midPos, displace / 2);

                self.CollectLinPos(midPos, destPos, displace / 2);
            }
        }
    }
}