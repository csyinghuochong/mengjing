﻿using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(DropFlyComponent))]
    [FriendOf(typeof(DropFlyComponent))]
    public static partial class DropFlyComponentSystem
    {
        [EntitySystem]
        private static void Awake(this DropFlyComponent self)
        {
            self.MyUnit = self.GetParent<Unit>();
            self.TargetUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.EffectPath = ABPathHelper.GetEffetPath("ScenceEffect/SceneEffect_DropFly");
        }

        [EntitySystem]
        private static void Update(this DropFlyComponent self)
        {
            if (self.MyUnit == null || self.MyUnit.IsDisposed)
            {
                return;
            }

            if (self.TargetUnit == null || self.TargetUnit.IsDisposed)
            {
                self.Dispose();
                return;
            }
            
            if (!self.IsPlayEffect)
            {
                self.IsPlayEffect = true;
                self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( self.EffectPath, self.InstanceId, true,self.OnLoadGameObject);
            }
            
            if (!self.Send && math.distance(self.MyUnit.Position, self.TargetUnit.Position) < self.Distance)
            {
                self.Send = true;
                // 只要靠近了就销毁拾取特效 不等消息返回
                self.Root().GetComponent<PickItemsComponent>().SendPick(self.MyUnit);
                self.Dispose();
                return;
            }

            if (self.StartPosition == Vector3.zero)
            {
                self.StartPosition = self.MyUnit.Position;
            }

            self.MyUnit.Position = Vector3.MoveTowards(self.MyUnit.Position, self.TargetUnit.Position, self.Speed * Time.deltaTime);
            if (self.EffectGameObject != null)
            {
                Vector3 direction = self.TargetUnit.Position - self.MyUnit.Position;
                if (direction == Vector3.zero)
                {
                    return;
                }

                self.EffectGameObject.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            }
        }

        [EntitySystem]
        private static void Destroy(this DropFlyComponent self)
        {
            self.RecoveryGameObject(self.EffectGameObject);
        }

        private static void OnLoadGameObject(this DropFlyComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed || formId != self.InstanceId || self.MyUnit.IsDisposed || self.TargetUnit.IsDisposed)
            {
                UnityEngine.Object.Destroy(gameObject);
                return;
            }

            self.EffectGameObject = gameObject;
            self.EffectGameObject.transform.SetParent(self.MyUnit.GetComponent<GameObjectComponent>().GameObject.transform);
            self.EffectGameObject.transform.localPosition = Vector3.zero;
            self.EffectGameObject.transform.localScale = Vector3.one;
            self.EffectGameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        private static void RecoveryGameObject(this DropFlyComponent self, GameObject gameObject)
        {
            if (gameObject == null)
            {
                return;
            }

            self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.EffectPath, gameObject, true);
        }
    }
}