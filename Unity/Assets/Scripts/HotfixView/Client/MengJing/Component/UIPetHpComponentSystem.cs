using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BuffUpdate_UIPetHpRefresh : AEvent<Scene, BuffUpdate>
    {
        protected override async ETTask Run(Scene scene, BuffUpdate args)
        {
            if (args.Unit.Type != UnitType.Pet)
            {
                return;
            }

            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.PetMelee
                && mapComponent.MapType != MapTypeEnum.PetMatch)
            {
                return;
            }

            args.Unit.GetComponent<UIPetHpComponent>()?.ES_MainBuff?.OnBuffUpdate(args.ABuffHandler, args.OperateType);

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(UIMainBuffItemComponent))]
    [FriendOf(typeof(UIPetHpComponent))]
    [EntitySystemOf(typeof(UIPetHpComponent))]
    public static partial class UIPetHpComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIPetHpComponent self)
        {
            self.GameObject = null;
            self.Img_HpValue = null;

            self.UIPlayerHpText = null;
            self.Lal_Name = null;
            self.Lal_JiaZuName = null;

            self.HeadBarPath = ABPathHelper.GetUGUIPath("Blood/UIPetHp");

            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.HeadBarPath, self.InstanceId,true, self.OnLoadGameObject);
        }

        [EntitySystem]
        private static void Destroy(this UIPetHpComponent self)
        {
            self.RecoverGameObject(self.GameObject);
        }

        public static void ShowHearBar(this UIPetHpComponent self, bool show)
        {
            self.GameObject.SetActive(show);
        }

        public static void EnterHide(this UIPetHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.GameObject.SetActive(false);
            self.UIPlayerHpText.SetActive(false);
        }

        public static void ExitHide(this UIPetHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.GameObject.SetActive(true);
            self.UIPlayerHpText.SetActive(true);
        }

        public static void EnterStealth(this UIPetHpComponent self, float alpha)
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

        public static void OnLoadGameObject(this UIPetHpComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.DestroyImmediate(gameObject);
                return;
            }

            self.GameObject = gameObject;
            Unit unit = self.GetParent<Unit>();
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();

            self.ES_MainBuff = self.AddChild<ES_MainBuff, Transform>(rc.Get<GameObject>("ES_MainBuff").transform);

            Unit mainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            bool canAttack = mainUnit.IsCanAttackUnit(unit);
            self.Img_HpValue = rc.Get<GameObject>("Img_HpValue");

            string imageHp = canAttack ? ConfigData.UI_pro_4_2 : ConfigData.UI_pro_3_2;
            Sprite sp = rc.Get<GameObject>(imageHp).GetComponent<Image>().sprite;
            self.Img_HpValue.GetComponent<Image>().sprite = sp;

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
            
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            Vector2 offset = Vector2.zero;
            offset = (mapComponent.MapType == MapTypeEnum.PetMelee || mapComponent.MapType == MapTypeEnum.PetMatch) ? new Vector2(0, 100f) : Vector2.zero;
            
            HeadBarUI HeadBarUI_1 = self.UIPlayerHpText.GetComponent<HeadBarUI>();
            HeadBarUI_1.enabled = true;
            HeadBarUI_1.Offset = offset;
            HeadBarUI_1.HeadPos = self.UIPosition;
            HeadBarUI_1.HeadBar = self.UIPlayerHpText;
            HeadBarUI_1.UiCamera = globalComponent.UICamera.GetComponent<Camera>();
            HeadBarUI_1.MainCamera = globalComponent.MainCamera.GetComponent<Camera>();
            HeadBarUI_1.UpdatePostion();

            HeadBarUI HeadBarUI_2 = self.GameObject.GetComponent<HeadBarUI>();
            HeadBarUI_2.enabled = true;
            HeadBarUI_2.Offset = offset;
            HeadBarUI_2.HeadPos = self.UIPosition;
            HeadBarUI_2.HeadBar = self.GameObject;
            HeadBarUI_2.UiCamera = globalComponent.UICamera.GetComponent<Camera>();
            HeadBarUI_2.MainCamera = globalComponent.MainCamera.GetComponent<Camera>();
            HeadBarUI_2.UpdatePostion();

            self.GameObject.transform.SetAsFirstSibling();
            self.GameObject.SetActive(true);

            //初始化当前血条
            self.UpdateBlood();

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

        public static void RecoverGameObject(this UIPetHpComponent self, GameObject gameobject)
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

        public static void UpdateBlood(this UIPetHpComponent self)
        {
            NumericComponentC numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
            float curhp = numericComponent.GetAsLong(NumericType.Now_Hp); // + value;
            float maxhp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
            float blood = curhp / maxhp;
            blood = Mathf.Max(blood, 0f);
            if (self.Img_HpValue == null)
            {
                return;
            }

            Log.Debug($"UpdateBloodPet: {self.GetParent<Unit>().Id} {curhp}  {maxhp}");
            self.Img_HpValue.GetComponent<Image>().fillAmount = blood;
        }

        public static void UpdateShow(this UIPetHpComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();

            using (zstring.Block())
            {
                string masterName = "";
                if (string.IsNullOrEmpty(unitInfoComponent.MasterName))
                {
                    // 角色切换成宠物了
                    masterName = unitInfoComponent.UnitName;
                }
                else
                {
                    masterName = unitInfoComponent.MasterName;
                }

                MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
                if (mapComponent.MapType != MapTypeEnum.PetMelee && mapComponent.MapType != MapTypeEnum.PetMatch)
                {
                    self.Lal_JiaZuName.GetComponent<Text>().text = zstring.Format("{0}的宠物", masterName);
                }
                else
                {
                    self.Lal_JiaZuName.GetComponent<Text>().text = "";
                }
            }

            if (unit.Type == UnitType.Player)
            {
                self.Lal_Name.GetComponent<Text>().text = unitInfoComponent.DemonName;
            }
            else
            {
                self.Lal_Name.GetComponent<Text>().text = unitInfoComponent.UnitName;
            }
        }
    }
}