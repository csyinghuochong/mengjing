using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIJingLingHpComponent))]
    [EntitySystemOf(typeof(UIJingLingHpComponent))]
    public static partial class UIJingLingHpComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIJingLingHpComponent self)
        {
            self.GameObject = null;

            self.UIPlayerHpText = null;
            self.Lal_Name = null;
            self.Lal_JiaZuName = null;

            self.HeadBarPath = ABPathHelper.GetUGUIPath("Blood/UIJingLingHp");

            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.HeadBarPath, self.InstanceId,true, self.OnLoadGameObject);
        }

        [EntitySystem]
        private static void Destroy(this UIJingLingHpComponent self)
        {
            self.RecoverGameObject(self.GameObject);
        }

        public static void ShowHearBar(this UIJingLingHpComponent self, bool show)
        {
            self.GameObject.SetActive(show);
        }

        public static void EnterHide(this UIJingLingHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.GameObject.SetActive(false);
            self.UIPlayerHpText.SetActive(false);
        }

        public static void ExitHide(this UIJingLingHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.GameObject.SetActive(true);
            self.UIPlayerHpText.SetActive(true);
        }

        public static void EnterStealth(this UIJingLingHpComponent self, float alpha)
        {
            if (self.GameObject == null)
            {
                return;
            }

            // 血条隐形
            Image[] hpImages = self.GameObject.GetComponentsInChildren<Image>();
            foreach (Image image in hpImages)
            {
                Color oldColor = image.color;
                image.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
            }

            //TextMeshProUGUI[] hpTextMeshPros = this.GameObject.GetComponentsInChildren<TextMeshProUGUI>();
            //foreach (TextMeshProUGUI textMeshPro in hpTextMeshPros)
            //{
            //    Color oldColor = textMeshPro.color;
            //    textMeshPro.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
            //}

            // 名称隐形
            Image[] nameImages = self.UIPlayerHpText.GetComponentsInChildren<Image>();
            foreach (Image image in nameImages)
            {
                Color oldColor = image.color;
                image.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
            }

            //TextMeshProUGUI[] nameTextMeshPros = this.UIPlayerHpText.GetComponentsInChildren<TextMeshProUGUI>();
            //foreach (TextMeshProUGUI textMeshPro in nameTextMeshPros)
            //{
            //    Color oldColor = textMeshPro.color;
            //    textMeshPro.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
            //}
        }

        public static void OnLoadGameObject(this UIJingLingHpComponent self, GameObject gameObject, long formId)
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
            bool canAttack = mainUnit.IsCanAttackUnit(unit);

            self.Lal_Name = rc.Get<GameObject>("Lal_Name");
            self.Lal_JiaZuName = rc.Get<GameObject>("Lal_JiaZuName");
            self.UIPosition = unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            GameObject bloodparent = globalComponent.BloodPlayer;
            self.GameObject.transform.SetParent(bloodparent.transform);
            self.GameObject.transform.localScale = Vector3.one;

            self.UIPlayerHpText = rc.Get<GameObject>("UIPlayerHpText");
            self.UIPlayerHpText.transform.SetParent(globalComponent.BloodText_Layer0.transform);
            self.UIPlayerHpText.transform.localScale = Vector3.one;
            HeadBarUI HeadBarUI_1 = self.UIPlayerHpText.GetComponent<HeadBarUI>();
            HeadBarUI_1.enabled = !unit.MainHero;
            HeadBarUI_1.enabled = true;
            HeadBarUI_1.HeadPos = self.UIPosition;
            HeadBarUI_1.HeadBar = self.UIPlayerHpText;
            HeadBarUI_1.UiCamera = globalComponent.UICamera.GetComponent<Camera>();
            HeadBarUI_1.MainCamera = globalComponent.MainCamera.GetComponent<Camera>();
            HeadBarUI_1.UpdatePostion();

            HeadBarUI HeadBarUI_2 = self.GameObject.GetComponent<HeadBarUI>();
            HeadBarUI_2.enabled = !unit.MainHero;
            HeadBarUI_2.enabled = true;
            HeadBarUI_2.HeadPos = self.UIPosition;
            HeadBarUI_2.HeadBar = self.GameObject;
            HeadBarUI_2.UiCamera = globalComponent.UICamera.GetComponent<Camera>();
            HeadBarUI_2.MainCamera = globalComponent.MainCamera.GetComponent<Camera>();
            HeadBarUI_2.UpdatePostion();

            self.GameObject.transform.SetAsFirstSibling();
            self.GameObject.SetActive(true);

            self.UpdateShow();

            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            if (stateComponent.StateTypeGet(StateTypeEnum.Stealth))
            {
                self.EnterStealth(canAttack ? 0f : 0.3f);
            }

            if (stateComponent.StateTypeGet(StateTypeEnum.Hide)
                || unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Stall) > 0)
            {
                self.EnterHide();
            }
        }

        public static void RecoverGameObject(this UIJingLingHpComponent self, GameObject gameobject)
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

        public static void UpdateShow(this UIJingLingHpComponent self)
        {
            UnitInfoComponent unitInfoComponent = self.GetParent<Unit>().GetComponent<UnitInfoComponent>();
            self.Lal_Name.GetComponent<Text>().text = unitInfoComponent.UnitName;
            using (zstring.Block())
            {
                self.Lal_JiaZuName.GetComponent<Text>().text = zstring.Format("{0}的精灵", unitInfoComponent.MasterName);
            }
        }
    }
}