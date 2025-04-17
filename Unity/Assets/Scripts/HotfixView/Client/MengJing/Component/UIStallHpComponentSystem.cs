using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [FriendOf(typeof(UIStallHpComponent))]
    [EntitySystemOf(typeof(UIStallHpComponent))]
    public static partial class UIStallHpComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UIStallHpComponent self)
        {
            self.GameObject = null;
            self.Img_HpValue = null;
            self.Img_AngleValue = null;
            self.Img_AngleValueDi = null;
            self.Img_MpValueDi = null;
            self.Img_MpValue = null;
            self.HeadBarPath = "";
            self.LastTime = 0f;
            self.HeadBarPath = ABPathHelper.GetUGUIPath("Blood/UIStallIem");

            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( self.HeadBarPath, self.InstanceId,true, self.OnLoadGameObject);
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.UIStallHpComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.RecoverGameObject(self.GameObject);
        }
        
        public static void OnLoadGameObject(this UIStallHpComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.DestroyImmediate(gameObject);
                return;
            }

            self.GameObject = gameObject;
            Unit unit = self.GetParent<Unit>();
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();

            Unit mainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
  
            self.Lal_Name = rc.Get<GameObject>("Lal_Name");

            self.UIPosition = unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            GameObject bloodparent = unit.Type == UnitType.Monster ? globalComponent.BloodMonster : globalComponent.BloodPlayer;
            self.GameObject.transform.SetParent(bloodparent.transform);
            self.GameObject.transform.localScale = Vector3.one;

            self.UIPlayerHpText = rc.Get<GameObject>("UIPlayerHpText");

            self.UIPlayerHpText.transform.SetParent(globalComponent.BloodText_Layer0.transform);
            self.UIPlayerHpText.transform.localScale = Vector3.one;
            HeadBarUI HeadBarUI_1 = self.UIPlayerHpText.GetComponent<HeadBarUI>();
            HeadBarUI_1.enabled = true;
            HeadBarUI_1.HeadPos = self.UIPosition;
            HeadBarUI_1.HeadBar = self.UIPlayerHpText;
            HeadBarUI_1.UiCamera = globalComponent.UICamera.GetComponent<Camera>();
            HeadBarUI_1.MainCamera = globalComponent.MainCamera.GetComponent<Camera>();
            HeadBarUI_1.UpdatePostion();

            HeadBarUI HeadBarUI_2 = self.GameObject.GetComponent<HeadBarUI>();
            HeadBarUI_2.enabled = true;
            HeadBarUI_2.HeadPos = self.UIPosition;
            HeadBarUI_2.HeadBar = self.GameObject;
            HeadBarUI_2.UiCamera = globalComponent.UICamera.GetComponent<Camera>();
            HeadBarUI_2.MainCamera = globalComponent.MainCamera.GetComponent<Camera>();
            HeadBarUI_2.UpdatePostion();

            self.GameObject.transform.SetAsFirstSibling();

            self.GameObject.SetActive(true);

            self.UpdateShow();
        }

        public static void UpdateShow(this UIStallHpComponent self)
        {
            UnitInfoComponent unitInfoComponent = self.GetParent<Unit>().GetComponent<UnitInfoComponent>();
            self.Lal_Name.GetComponent<Text>().text = unitInfoComponent.UnitName;
        }
        
        public static void RecoverGameObject(this UIStallHpComponent self, GameObject gameobject)
        {
            if (gameobject != null)
            {
                gameobject.GetComponent<HeadBarUI>().enabled = false;
                if (self.UIPlayerHpText != null)
                {
                    self.UIPlayerHpText.GetComponent<HeadBarUI>().enabled = false;
                    self.UIPlayerHpText.transform.SetParent(gameobject.transform);
                }

                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.HeadBarPath, gameobject);
                self.GameObject = null;
            }
        }
    }
}