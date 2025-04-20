using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BuffUpdate_UIMonsterHpRefresh : AEvent<Scene, BuffUpdate>
    {
        protected override async ETTask Run(Scene scene, BuffUpdate args)
        {
            if (args.Unit.Type != UnitType.Monster)
            {
                return;
            }

            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.PetMelee
                && mapComponent.MapType != MapTypeEnum.PetMatch)
            {
                return;
            }

            args.Unit.GetComponent<UIMonsterHpComponent>()?.ES_MainBuff?.OnBuffUpdate(args.ABuffHandler, args.OperateType);

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(UIMainBuffItemComponent))]
    [EntitySystemOf(typeof(UIMonsterHpComponent))]
    [FriendOf(typeof(UIMonsterHpComponent))]
    public static partial class UIMonsterHpComponentSystem
    {
        [Invoke(TimerInvokeType.UIUnitReviveTime)]
        public class UIUnitReviveTime : ATimer<UIMonsterHpComponent>
        {
            protected override void Run(UIMonsterHpComponent self)
            {
                try
                {
                    self.OnTimer();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this UIMonsterHpComponent self)
        {
            self.GameObject = null;
            self.Img_HpValue = null;
            self.Img_AngleValue = null;
            self.Img_AngleValueDi = null;
            self.Img_MpValueDi = null;
            self.Img_MpValue = null;
            self.HeadBarPath = "";
            self.LastTime = 0f;
            self.HeadBarPath = ABPathHelper.GetUGUIPath("Blood/UIMonsterHp");
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.HeadBarPath, self.InstanceId, true,self.OnLoadGameObject);
        }

        [EntitySystem]
        private static void Destroy(this UIMonsterHpComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.RecoverGameObject(self.GameObject);
        }

        public static void ShowHearBar(this UIMonsterHpComponent self, bool show)
        {
            self.GameObject.SetActive(show);
        }

        public static void ExitStealth(this UIMonsterHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            Image[] hpImages = self.GameObject.GetComponentsInChildren<Image>();
            foreach (Image image in hpImages)
            {
                Color oldColor = image.color;
                image.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1f);
            }

            //TextMeshProUGUI[] hpTextMeshPros = this.GameObject.GetComponentsInChildren<TextMeshProUGUI>();
            //foreach (TextMeshProUGUI textMeshPro in hpTextMeshPros)
            //{
            //    Color oldColor = textMeshPro.color;
            //    textMeshPro.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
            //}

            // 名称恢复
            Image[] nameImages = self.UIPlayerHpText.GetComponentsInChildren<Image>();
            foreach (Image image in nameImages)
            {
                Color oldColor = image.color;
                image.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1f);
            }

            //TextMeshProUGUI[] nameTextMeshPros = this.UIPlayerHpText.GetComponentsInChildren<TextMeshProUGUI>();
            //foreach (TextMeshProUGUI textMeshPro in nameTextMeshPros)
            //{
            //    Color oldColor = textMeshPro.color;
            //    textMeshPro.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1f);
            //}
        }

        public static void EnterHide(this UIMonsterHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.GameObject.SetActive(false);
            self.UIPlayerHpText.SetActive(false);
        }

        public static void ExitHide(this UIMonsterHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.GameObject.SetActive(true);
            self.UIPlayerHpText.SetActive(true);
        }

        public static void EnterStealth(this UIMonsterHpComponent self, float alpha)
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

        public static void UpdateCampToMain(this UIMonsterHpComponent self, bool canAttack)
        {
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();

            string imageHp = canAttack ? ConfigData.UI_pro_4_2 : ConfigData.UI_pro_3_2;
            Sprite sp = rc.Get<GameObject>(imageHp).GetComponent<Image>().sprite;
            self.Img_HpValue = rc.Get<GameObject>("Img_HpValue");
            rc.Get<GameObject>("Img_HpValue").SetActive(true);
            self.Img_HpValue.GetComponent<Image>().sprite = sp;
        }

        public static void OnLoadGameObject(this UIMonsterHpComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.DestroyImmediate(gameObject);
                return;
            }

            self.GameObject = gameObject;
            self.GameObject.SetActive(true);
            Unit unit = self.GetParent<Unit>();
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();

            self.ES_MainBuff = self.AddChild<ES_MainBuff, Transform>(rc.Get<GameObject>("ES_MainBuff").transform);

            Unit mainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            bool canAttack = mainUnit.IsCanAttackUnit(unit);

            self.UpdateCampToMain(canAttack);
            rc.Get<GameObject>("Alive").SetActive(true);
            rc.Get<GameObject>("Dead").SetActive(false);
            rc.Get<GameObject>("ReviveTime").SetActive(false);

            self.Lal_Name = rc.Get<GameObject>("Lal_Name");
            self.Lal_JiaZuName = rc.Get<GameObject>("Lal_JiaZuName");
            self.UIPosition = unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            GameObject bloodparent = globalComponent.BloodMonster;
            self.GameObject.transform.SetParent(bloodparent.transform);
            self.GameObject.transform.localScale = Vector3.one;

            self.UIPlayerHpText = rc.Get<GameObject>("UIPlayerHpText");
            self.UIPlayerHpText.transform.SetParent(globalComponent.BloodText_Layer0.transform);
            self.UIPlayerHpText.transform.localScale = Vector3.one;
            self.UIPlayerHpText.gameObject.SetActive(true);
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            Vector2 offset = Vector2.zero;
            offset =(  mapComponent.MapType == MapTypeEnum.PetMelee || mapComponent.MapType == MapTypeEnum.PetMatch) ? new Vector2(0, 70f) : Vector2.zero;
            
            HeadBarUI HeadBarUI_1 = self.UIPlayerHpText.GetComponent<HeadBarUI>();
            HeadBarUI_1.enabled = !unit.MainHero;
            HeadBarUI_1.Offset = offset;
            HeadBarUI_1.HeadPos = self.UIPosition;
            HeadBarUI_1.HeadBar = self.UIPlayerHpText;
            HeadBarUI_1.UiCamera = globalComponent.UICamera.GetComponent<Camera>();
            HeadBarUI_1.MainCamera = globalComponent.MainCamera.GetComponent<Camera>();
            HeadBarUI_1.UpdatePostion();

            HeadBarUI HeadBarUI_2 = self.GameObject.GetComponent<HeadBarUI>();
            HeadBarUI_2.enabled = !unit.MainHero;
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
            //更新显示
            self.UpdateShow();

            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();   
            if (stateComponent.StateTypeGet(StateTypeEnum.Stealth))
            {
                self.EnterStealth(canAttack ? 0f : 0.3f);
            }

            if (stateComponent.StateTypeGet(StateTypeEnum.Hide)
                || numericComponentC.GetAsLong(NumericType.Now_Stall) > 0)
            {
                self.EnterHide();
            }
            
            long leftTime = numericComponentC.GetAsLong(NumericType.ReviveTime) - TimeHelper.ClientNow();
            if (leftTime > 0)
            {
                self.OnDead();
            }
        }

        public static void OnUpdateHorse(this UIMonsterHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int horseRide = numericComponent.GetAsInt(NumericType.HorseRide);

            Vector3 vector3_zuoqi = new Vector3(0f, 180f, 0f);
            Vector3 vector3_normal = new Vector3(0f, 120f, 0f);
            if (horseRide > 0)
            {
                ZuoQiShowConfig zuoQiShowConfig = ZuoQiShowConfigCategory.Instance.Get(horseRide);
                vector3_zuoqi.y += (float)zuoQiShowConfig.NameShowUp;
            }

            self.GameObject.transform.localPosition = horseRide > 0 ? vector3_zuoqi : vector3_normal;
            if (unit.MainHero)
            {
                self.UIPlayerHpText.transform.localPosition = horseRide > 0 ? vector3_zuoqi : vector3_normal;
            }
        }

        //更新显示
        public static void UpdateShow(this UIMonsterHpComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            UnitInfoComponent infoComponent = unit.GetComponent<UnitInfoComponent>();

            //显示怪物名称
            if (unit.Type == UnitType.Monster)
            {
                MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(self.GetParent<Unit>().ConfigId);
                Text textMeshProUGUI = self.Lal_Name.GetComponent<Text>();
                bool isboos = monsterCof.MonsterType == (int)MonsterTypeEnum.Boss;
                textMeshProUGUI.fontSize = isboos ? 32 : 26;
                textMeshProUGUI.color = isboos ? new Color(255, 95, 255) : Color.white;
                string colorstr = isboos ? "<color=#FF5FFF>" : "<color=#FFFFFF>";
                //NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                //this.ObjName.GetComponent<TextMeshProUGUI>().text = $"{colorstr}{monsterCof.MonsterName}_{numericComponent.GetAsInt(NumericType.Now_AI)}</color>";
                MapComponent mapComponent = unit.Root().GetComponent<MapComponent>();
                NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
                bool shenYuan = mapComponent.MapType == MapTypeEnum.TeamDungeon && mapComponent.FubenDifficulty == TeamFubenType.ShenYuan;
                using (zstring.Block())
                {
                    if (shenYuan)
                    {
                        if (monsterCof.MonsterType == 3)
                        {
                            self.Lal_Name.GetComponent<Text>().text = zstring.Format("深渊召唤:{0}{1}</color>", colorstr, monsterCof.MonsterName);
                        }
                        else
                        {
                            self.Lal_Name.GetComponent<Text>().text = zstring.Format("{0}{1}</color>", colorstr, monsterCof.MonsterName);
                        }
                    }
                    else
                    {
                        int babyType =  numericComponentC.GetAsInt(NumericType.BaByType);
                        string addname = CommonViewHelper.GetMonsterShowName(babyType);
                        if (babyType == 1)
                        {
                            colorstr =  "<color=#A1FF36>" ;
                        }
                        if (babyType == 2)
                        {
                            colorstr =  "<color=#FF75F1>";
                        }

                        if (!string.IsNullOrEmpty(addname))
                        {
                            self.Lal_Name.GetComponent<Text>().text = zstring.Format("{0}{1}{2}</color>", colorstr, monsterCof.MonsterName, addname);
                        }
                        else
                        {
                            self.Lal_Name.GetComponent<Text>().text = zstring.Format("{0}{1}</color>", colorstr, monsterCof.MonsterName);
                        }
                    }
                }

                //怪物等级显示
                ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
                int monsterLv = numericComponentC.GetAsInt(NumericType.Now_Lv);
                if (monsterLv > 0)
                {
                    rc.Get<GameObject>("Lal_Lv").GetComponent<Text>().text = monsterLv.ToString();
                }
                else
                {
                    rc.Get<GameObject>("Lal_Lv").GetComponent<Text>().text = monsterCof.Lv.ToString();
                }
            }
        }

        public static void OnRevive(this UIMonsterHpComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            if (self.GetParent<Unit>().Type == UnitType.Monster)
            {
                ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
                rc.Get<GameObject>("Alive").SetActive(true);
                rc.Get<GameObject>("Dead").SetActive(false);
                rc.Get<GameObject>("ReviveTime").SetActive(false);
                rc.Get<GameObject>("Lal_Lv").SetActive(true);
                rc.Get<GameObject>("ReviveTime").transform.localPosition = new Vector3(0f, 66f, 0f);
                rc.Get<GameObject>("Lal_Name").transform.localPosition = new Vector3(0f, 28f, 0f);
            }

            self.UpdateBlood();
        }

        public static void OnDead(this UIMonsterHpComponent self)
        {
            if (self.GetParent<Unit>().Type != UnitType.Monster)
            {
                return;
            }

            if (self.GameObject == null)
            {
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(self.GetParent<Unit>().ConfigId);
            if (monsterConfig.ReviveTime > 0)
            {
                ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
                rc.Get<GameObject>("Alive").SetActive(false);
                rc.Get<GameObject>("Dead").SetActive(true);
                rc.Get<GameObject>("ReviveTime").SetActive(true);
                rc.Get<GameObject>("Lal_Lv").SetActive(false);
                rc.Get<GameObject>("ReviveTime").transform.localPosition = new Vector3(0f, 200f, 0f);
                rc.Get<GameObject>("Lal_Name").transform.localPosition = new Vector3(0f, 150f, 0f);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UIUnitReviveTime, self);
                self.OnTimer();     
            }
        }

        public static void UpdateAI(this UIMonsterHpComponent self)
        {
            if (self.Lal_Name != null)
            {
                self.UpdateShow();
            }
        }

        public static void UpdateBlood(this UIMonsterHpComponent self)
        {
            NumericComponentC numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
            long curhp = numericComponent.GetAsLong(NumericType.Now_Hp); // + value;
            long maxhp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
            float blood = (1f * curhp / maxhp);
            blood = Mathf.Max(blood, 0f);
            if (self.Img_HpValue == null)
            {
                return;
            }

            self.Img_HpValue.GetComponent<Image>().fillAmount = blood;

            // int unitType = self.GetParent<Unit>().Type;
            // switch (unitType)
            // {
            //     case UnitType.Player:
            //         self.Img_HpValue.GetComponent<Image>().fillAmount = blood;
            //         int shieldHp = numericComponent.GetAsInt(NumericType.Now_Shield_HP);
            //         int shieldMax = numericComponent.GetAsInt(NumericType.Now_Shield_MaxHP);
            //         if (shieldMax > 0)
            //         {
            //             self.BuffShieldValue.GetComponent<Image>().fillAmount = shieldHp * 1f / shieldMax;
            //         }
            //         else
            //         {
            //             self.BuffShieldValue.GetComponent<Image>().fillAmount = 0f;
            //         }
            //
            //         break;
            //     case UnitType.Pet:
            //         self.Img_HpValue.GetComponent<Image>().fillAmount = blood;
            //         break;
            //     default:
            //         self.Img_HpValue.GetComponent<Image>().fillAmount = blood;
            //         break;
            // }
        }

        public static void OnTimer(this UIMonsterHpComponent self)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(self.GetParent<Unit>().ConfigId);
            long leftTime = self.GetParent<Unit>().GetComponent<NumericComponentC>().GetAsLong(NumericType.ReviveTime) - TimeHelper.ClientNow();
            leftTime = leftTime / 1000;
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            GameObject reviveTime = rc.Get<GameObject>("ReviveTime");
            int hour = (int)leftTime / 3600;
            int min = (int)((leftTime - (hour * 3600)) / 60);
            int sec = (int)(leftTime - (hour * 3600) - (min * 60));
            using (zstring.Block())
            {
                string showStr = zstring.Format("{0}时{1}分{2}秒", hour, min, sec);
                reviveTime.GetComponent<Text>().text = zstring.Format("刷新剩余时间:{0}",  showStr);
            }
        }

        public static void RecoverGameObject(this UIMonsterHpComponent self, GameObject gameobject)
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