using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(FallingFontShow1Component))]
    [FriendOf(typeof(FallingFontShow1Component))]
    public static partial class FallingFontShow1ComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FallingFontShow1Component self)
        {
            self.Transform = null;
            self.GameObject = null;
            self.DamgeFlyTimeSum = 0;
            self.Fly_Y_Sum = 0;
        }

        [EntitySystem]
        private static void Destroy(this FallingFontShow1Component self)
        {
            self.RecoveryGameObject(self.GameObject);
        }

        private static void RecoveryGameObject(this FallingFontShow1Component self, GameObject FlyFontObj)
        {
            if (FlyFontObj == null)
            {
                return;
            }

            if (self.ObjFlyText != null)
            {
                self.ObjFlyText.transform.localPosition = new Vector3(-5000f, 0f, 0f);
            }

            string uIBattleFly = StringBuilderData.UIBattleFly1;
            GameObjectLoadHelper.RecoverGameObject(uIBattleFly, FlyFontObj, true);
            FlyFontObj.transform.localPosition = new Vector2(-2000f, -2000f);
        }

        private static void OnLoadGameObject(this FallingFontShow1Component self, GameObject FlyFontObj, long formId)
        {
            if (self.IsDisposed || formId != self.InstanceId || self.Unit.IsDisposed)
            {
                self.RecoveryGameObject(FlyFontObj);
                return;
            }

            self.GameObject = FlyFontObj;
            self.Transform = FlyFontObj.transform;
            ReferenceCollector rc = FlyFontObj.GetComponent<ReferenceCollector>();
            GameObject ObjFlyText = self.FontType switch
            {
                FallingFont1Type.Type_0 => rc.Get<GameObject>("FlyText_0"),
                FallingFont1Type.Type_1 => rc.Get<GameObject>("FlyText_1"),
                _ => null
            };

            ObjFlyText.GetComponent<Text>().text = self.ShowText;

            //初始化,因为是对象池所有之前可能有不同大小的缓存
            ObjFlyText.GetComponent<Text>().transform.localScale = self.StartScale;

            ObjFlyText.SetActive(true);
            self.ObjFlyText = ObjFlyText;
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            ObjFlyText.transform.localPosition = Vector3.zero;
            ObjFlyText.transform.localPosition = new Vector3(Random.value * 150f - 50f, 0f, 0);
            FlyFontObj.transform.SetParent(globalComponent.BloodText_Layer1.transform);
            FlyFontObj.transform.localScale = Vector3.one;
            FlyFontObj.transform.localPosition = self.HeadBar.transform.localPosition + new Vector3(0f, 80f, 0);
        }

        public static void OnInitData(this FallingFontShow1Component self, GameObject HeadBar, Unit unit, string showText, FallingFont1Type fontType,
        Vector3 startScale)
        {
            self.HeadBar = HeadBar;
            self.Unit = unit;
            self.ShowText = showText;
            self.FontType = fontType;
            self.StartScale = startScale;

            string uIBattleFly = StringBuilderData.UIBattleFly1;
            GameObjectLoadHelper.AddLoadQueue(self.Root(), uIBattleFly, self.InstanceId, self.OnLoadGameObject);
        }

        public static bool LateUpdate(this FallingFontShow1Component self)
        {
            self.DamgeFlyTimeSum = self.DamgeFlyTimeSum + Time.deltaTime;
            if (self.Transform != null)
            {
                if (self.DamgeFlyTimeSum < 0.2f)
                {
                    self.Transform.localScale = self.DamgeFlyTimeSum < 0.03f ? new Vector3(0.8f, 0.8f, 0.8f) : new Vector3(1.5f, 1.5f, 1.5f);
                    self.Fly_Y_Sum += Time.deltaTime * 200f;
                }
                else
                {
                    self.Transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    self.Fly_Y_Sum += Time.deltaTime * 100f;
                }

                self.Transform.localPosition = self.HeadBar.transform.localPosition + new Vector3(0, 40f + self.Fly_Y_Sum, 0);
            }

            return self.DamgeFlyTimeSum >= 0.6f || !self.HeadBar.activeSelf;
        }
    }
}