using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (FallingFontShowComponent))]
    [FriendOf(typeof (FallingFontShowComponent))]
    public static partial class FallingFontShowComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.FallingFontShowComponent self)
        {  
            self.Transform = null;
            self.GameObject = null;
            self.DamgeFlyTimeSum = 0;
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.FallingFontShowComponent self)
        {
            self.RecoveryGameObject(self.GameObject);
        }

        public static void RecoveryGameObject(this FallingFontShowComponent self, GameObject FlyFontObj)
        {
            if (FlyFontObj == null)
            {
                return;
            }

            ReferenceCollector rc = FlyFontObj.GetComponent<ReferenceCollector>();
            rc.Get<GameObject>("FlyText_Self").SetActive(false);
            rc.Get<GameObject>("FlyText_Add").SetActive(false);
            rc.Get<GameObject>("FlyText_Target").SetActive(false);
            if (self.ObjFlyText != null)
            {
                self.ObjFlyText.transform.localPosition = new Vector3(-5000f, 0f, 0f);
            }

            string uIBattleFly = StringBuilderData.UIBattleFly;
            GameObjectPoolComponent.Instance.RecoverGameObject(uIBattleFly, FlyFontObj, true);
            FlyFontObj.transform.localPosition = new Vector2(-2000f, -2000f);
        }

        public static void OnLoadGameObject(this FallingFontShowComponent self, GameObject FlyFontObj, long formId)
        {
            Unit unit = self.Unit;
            if (self.IsDisposed || formId != self.InstanceId || unit.IsDisposed)
            {
                self.RecoveryGameObject(FlyFontObj);
                return;
            }

            int type = self.FontType;
            long targetValue = self.TargetValue;
            self.GameObject = FlyFontObj;
            self.Transform = FlyFontObj.transform;
            ReferenceCollector rc = FlyFontObj.GetComponent<ReferenceCollector>();
            GameObject ObjFlyText = rc.Get<GameObject>("FlyText_Target");
            //根据目标Unit设定飘字字体
            string selfNull = "";
            if (unit.MainHero)
            {
                //设置字体
                ObjFlyText = rc.Get<GameObject>("FlyText_Self");
                selfNull = " ";
            }

            //恢复血量
            if (type == 2 || type == 11 || type == 12 || targetValue > 0)
            {
                //设置字体
                ObjFlyText = rc.Get<GameObject>("FlyText_Add");
            }

            string addStr = "";
            if (targetValue >= 0 && type == 2)
            {
                addStr = "+";
            }

            if (type == 1)
            {
                //addStr = "AJ";  //暴击
                addStr = "暴击"; //暴击
            }

            if (type != 2 && type != 11 && type != 12 && targetValue == 0)
            {
                //addStr = "SB";  //闪避
                addStr = "闪避"; //闪避
            }
            else if (type == 11)
            {
                addStr = "抵抗";
            }
            else if (type == 12)
            {
                addStr = "免疫";

            }
            else
            {
                addStr = StringBuilderHelper.GetFallText(addStr + selfNull, targetValue);
            }
            ObjFlyText.GetComponent<Text>().text = addStr;
            self.ObjFlyText = ObjFlyText;
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            ObjFlyText.transform.localPosition = Vector3.zero;
            FlyFontObj.transform.SetParent(globalComponent.BloodText.transform);
            FlyFontObj.transform.localScale = Vector3.one;
            FlyFontObj.transform.localPosition = self.HeadBar.transform.localPosition + new Vector3(0, 80f, 0);
            
            Log.Debug($"addStr:  {addStr}");
        }

        public static void OnInitData(this FallingFontShowComponent self, GameObject HeadBar, long targetValue, Unit unit, int type)
        {
            self.Unit = unit;
            self.FontType = type;
            self.TargetValue = targetValue;
            self.HeadBar = HeadBar;
            string uIBattleFly = StringBuilderData.UIBattleFly;
            GameObjectPoolComponent.Instance.AddLoadQueue(uIBattleFly, self.InstanceId, self.OnLoadGameObject);
        }

        public static bool LateUpdate(this FallingFontShowComponent self)
        {
            self.DamgeFlyTimeSum = self.DamgeFlyTimeSum + Time.deltaTime;
            if (self.Transform != null)
            {
                if (self.DamgeFlyTimeSum < 0.15f)
                {
                    self.Transform.localScale = self.DamgeFlyTimeSum < 0.03f? new Vector3(0.8f, 0.8f, 0.8f) : new Vector3(1.5f, 1.5f, 1.5f);
                }
                else
                {
                    self.Transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                }

                self.Transform.localPosition = self.HeadBar.transform.localPosition + new Vector3(0, 80f + self.DamgeFlyTimeSum * 10f, 0);
            }

            return self.DamgeFlyTimeSum >= 0.3f || !self.HeadBar.activeSelf;
        }
    }
}