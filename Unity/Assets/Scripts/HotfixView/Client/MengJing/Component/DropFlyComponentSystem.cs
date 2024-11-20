using Unity.Mathematics;
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
            if (self.MyUnit.IsDisposed || self.TargetUnit.IsDisposed)
            {
                return;
            }

            if (!self.IsPlayEffect)
            {
                self.IsPlayEffect = true;
                self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( self.EffectPath, self.InstanceId, self.OnLoadGameObject);
            }

            if (!self.Send && math.distance(self.MyUnit.Position, self.TargetUnit.Position) < self.Distance)
            {
                self.Send = true;
                self.SendShiquItem().Coroutine();
            }

            if (self.StartPosition == Vector3.zero)
            {
                self.StartPosition = self.MyUnit.Position;
            }

            self.MyUnit.Position = Vector3.MoveTowards(self.MyUnit.Position, self.TargetUnit.Position, self.Speed * Time.deltaTime);
            if (self.EffectGameObject != null)
            {
                self.EffectGameObject.transform.rotation = Quaternion.LookRotation(self.TargetUnit.Position - self.MyUnit.Position, Vector3.forward);
            }
        }

        [EntitySystem]
        private static void Destroy(this DropFlyComponent self)
        {
            self.RecoveryGameObject(self.EffectGameObject);
        }

        private static async ETTask SendShiquItem(this DropFlyComponent self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            bagComponentC.RealAddItem--;

            // 提前获取，消息返回后Drop会销毁
            Scene root = self.Root();

            int itemId = self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId);
            int itemNum = self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemNum);

            int error = await MapHelper.SendShiquItem(self.Root(), new() { self.MyUnit });

            if (error == ErrorCode.ERR_Success)
            {
                EventSystem.Instance.Publish(root, new GetDrop() { ItemId = itemId, ItemNum = itemNum });
            }

            bagComponentC.RealAddItem++;
        }

        private static void OnLoadGameObject(this DropFlyComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed || formId != self.InstanceId || self.MyUnit.IsDisposed || self.TargetUnit.IsDisposed)
            {
                self.RecoveryGameObject(gameObject);
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