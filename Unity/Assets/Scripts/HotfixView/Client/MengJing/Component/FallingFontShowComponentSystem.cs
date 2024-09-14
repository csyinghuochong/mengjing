using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(FallingFontShowComponent))]
    [FriendOf(typeof(FallingFontShowComponent))]
    public static partial class FallingFontShowComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FallingFontShowComponent self)
        {
            self.Transform = null;
            self.GameObject = null;
            self.DamgeFlyTimeSum = 0;
            self.Fly_Y_Sum = 0;
        }

        [EntitySystem]
        private static void Destroy(this FallingFontShowComponent self)
        {
            self.RecoveryGameObject(self.GameObject);
        }

        private static void RecoveryGameObject(this FallingFontShowComponent self, GameObject FlyFontObj)
        {
            if (FlyFontObj == null)
            {
                return;
            }

            if (self.ObjFlyText != null)
            {
                self.ObjFlyText.transform.localPosition = new Vector3(-5000f, 0f, 0f);
            }

            GameObjectLoadHelper.RecoverGameObject(self.FallingFontPath, FlyFontObj, true);
            FlyFontObj.transform.localPosition = new Vector2(-2000f, -2000f);
        }

        private static void OnLoadGameObject(this FallingFontShowComponent self, GameObject FlyFontObj, long formId)
        {
            if (self.IsDisposed || formId != self.InstanceId || self.Unit.IsDisposed)
            {
                self.RecoveryGameObject(FlyFontObj);
                return;
            }

            self.GameObject = FlyFontObj;
            self.Transform = FlyFontObj.transform;
            ReferenceCollector rc = FlyFontObj.GetComponent<ReferenceCollector>();

            switch (self.BloodTextLayer)
            {
                case BloodTextLayer.Layer_0:
                    self.GameObject.transform.SetParent(GlobalComponent.Instance.BloodText_Layer0.transform);
                    break;
                case BloodTextLayer.Layer_1:
                    self.GameObject.transform.SetParent(GlobalComponent.Instance.BloodText_Layer1.transform);
                    break;
                case BloodTextLayer.Layer_2:
                    self.GameObject.transform.SetParent(GlobalComponent.Instance.BloodText_Layer2.transform);
                    break;
            }

            // 这里可以根据要求进行一些初始化设置，如一开始飘字位置的偏移
            switch (self.FallingFontExecuteType)
            {
                case FallingFontExecuteType.Type_0:
                {
                    self.GameObject.transform.localPosition = self.HeadBar.transform.localPosition + new Vector3(0f, 80f, 0);
                    self.ObjFlyText.transform.localPosition = new Vector3(Random.value * 150f - 50f, 0f, 0);
                    break;
                }
                case FallingFontExecuteType.Type_1:
                {
                    self.GameObject.transform.localPosition = self.HeadBar.transform.localPosition + new Vector3(0f, 80f, 0);
                    self.ObjFlyText.transform.localPosition = new Vector3(Random.value * 150f - 50f, 0f, 0);
                    break;
                }
                case FallingFontExecuteType.Type_2:
                {
                    self.GameObject.transform.localPosition = self.HeadBar.transform.localPosition + new Vector3(0f, 80f, 0);
                    self.ObjFlyText.transform.localPosition = new Vector3(Random.value * 150f - 50f, 0f, 0);
                    break;
                }
            }

            self.GameObject.transform.localScale = Vector3.one;

            self.ObjFlyText = rc.Get<GameObject>("FlyText");
            self.ObjFlyText.GetComponent<Text>().text = self.ShowText;
            self.ObjFlyText.GetComponent<Text>().transform.localScale = self.StartScale;
            self.ObjFlyText.SetActive(true);
        }

        public static void OnInitData(this FallingFontShowComponent self, GameObject HeadBar, Unit unit, string showText, FallingFontType fontType,
        Vector3 startScale, BloodTextLayer bloodTextLayer, FallingFontExecuteType fallingFontExecuteType)
        {
            self.HeadBar = HeadBar;
            self.Unit = unit;
            self.ShowText = showText;
            self.FontType = fontType;
            self.StartScale = startScale;
            self.BloodTextLayer = bloodTextLayer;
            self.FallingFontExecuteType = fallingFontExecuteType;

            self.FallingFontPath = self.FontType switch
            {
                FallingFontType.Normal => "Assets/Bundles/UI/Blood/UIBattleFly_Normal.prefab",
                FallingFontType.Self => "Assets/Bundles/UI/Blood/UIBattleFly_Self.prefab",
                FallingFontType.Target => "Assets/Bundles/UI/Blood/UIBattleFly_Target.prefab",
                FallingFontType.Add => "Assets/Bundles/UI/Blood/UIBattleFly_Add.prefab",
                FallingFontType.Special => "Assets/Bundles/UI/Blood/UIBattleFly_Special.prefab",
                FallingFontType.Yellow => "Assets/Bundles/UI/Blood/UIBattleFly_Yellow.prefab",
                FallingFontType.Purple => "Assets/Bundles/UI/Blood/UIBattleFly_Purple.prefab",
                FallingFontType.Orange => "Assets/Bundles/UI/Blood/UIBattleFly_Orange.prefab",
                _ => null
            };

            GameObjectLoadHelper.AddLoadQueue(self.Root(), self.FallingFontPath, self.InstanceId, self.OnLoadGameObject);
        }

        public static bool LateUpdate(this FallingFontShowComponent self)
        {
            switch (self.FallingFontExecuteType)
            {
                case FallingFontExecuteType.Type_0: // 战斗飘字逻辑
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
                case FallingFontExecuteType.Type_1: // 经验+金币+获取道具
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
                case FallingFontExecuteType.Type_2: // 完成任务 升级
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

                default:
                    return true;
            }
        }
    }
}