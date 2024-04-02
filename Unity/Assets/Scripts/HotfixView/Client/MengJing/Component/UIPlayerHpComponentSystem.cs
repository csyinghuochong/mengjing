using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{


    [EntitySystemOf(typeof(UIPlayerHpComponent))]
    [FriendOf(typeof(UIPlayerHpComponent))]
    public static partial class UIPlayerHpComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UIPlayerHpComponent self)
        {
            self.GameObject = null;
            self.Img_HpValue = null;
            self.Img_AngleValue = null;
            self.Img_AngleValueDi = null;
            self.Img_MpValueDi = null;
            self.Img_MpValue = null;
            self.HeadBarPath = "";
            self.LastTime = 0f;
            self.HeadBarPath = ABPathHelper.GetUGUIPath("Blood/UIPlayerHp");
          
            GameObjectPoolComponent.Instance.AddLoadQueue(self.HeadBarPath, self.InstanceId, self.OnLoadGameObject);
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.UIPlayerHpComponent self)
        {

        }
        
         public static void ShowHearBar(this ET.Client.UIPlayerHpComponent self, bool show)
         {
             self.GameObject.SetActive(show);
         }

         public static void ExitStealth(this ET.Client.UIPlayerHpComponent self)
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

         public static  void EnterHide(this ET.Client.UIPlayerHpComponent self)
         {
             if (self.GameObject == null)
             {
                 return;
             }
             self.GameObject.SetActive(false);
             self.UIPlayerHpText.SetActive(false);
         }

         public static  void ExitHide(this ET.Client.UIPlayerHpComponent self)
         {
             if (self.GameObject == null)
             {
                 return;
             }
             self.GameObject.SetActive(true);
             self.UIPlayerHpText.SetActive(true);
         }

         public static void EnterStealth(this ET.Client.UIPlayerHpComponent self, float alpha)
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

         public static void OnLoadGameObject(this ET.Client.UIPlayerHpComponent self, GameObject gameObject, long formId)
         {
             if (self.IsDisposed)
             {
                 self.RecoverGameObject(gameObject);
                 return;
             }
             self.GameObject = gameObject;
             Unit unit = self.GetParent<Unit>();
             ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();

             Unit mainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
             bool canAttack = mainUnit.IsCanAttackUnit(unit);
             self.Img_HpValue = rc.Get<GameObject>("Img_HpValue");
            
             string   imageHp = canAttack ? ConfigData.UI_pro_4_2: ConfigData.UI_pro_3_2;
             Sprite sp = rc.Get<GameObject>(imageHp).GetComponent<Image>().sprite;
             self.DialogText = rc.Get<GameObject>("DialogText");
             self.DialogText.SetActive(false);
             self.PlayerNameSet = rc.Get<GameObject>("PlayerNameSet");
             self.Img_HpValue.GetComponent<Image>().sprite = sp;
             self.BuffShieldValue = rc.Get<GameObject>("BuffShieldValue");
             self.Img_ChengHao = rc.Get<GameObject>("Img_ChengHao");
             self.Img_ChengHao.SetActive(true);
             self.PlayerNameSet.SetActive(true);
             self.Lal_AddtionName = rc.Get<GameObject>("Lal_AddtionName");
             self.Img_AngleValue = rc.Get<GameObject>("Img_AngleValue").GetComponent<Image>();
             self.Img_AngleValue.gameObject.SetActive(false);
             self.Img_AngleValueDi = rc.Get<GameObject>("Img_AngleValueDi");
             self.Img_AngleValueDi.SetActive(false);
             self.Img_MpValueDi = rc.Get<GameObject>("Img_MpValueDi");
             self.Img_MpValueDi.SetActive(false);
             self.Img_MpValue = rc.Get<GameObject>("Img_MpValue").GetComponent<Image>();
             self.Img_MpValue.gameObject.SetActive(false);
             self.UIXuLieZhenComponent = self.AddChild<UIXuLieZhenComponent, GameObject>(self.Img_ChengHao);
             bool lierenxuetiao = unit.MainHero && unit.ConfigId == 3;
             self.Img_HpValue.GetComponent<RectTransform>().sizeDelta = lierenxuetiao ? new Vector2(160f, 14f) : new Vector2(160f, 18f);
             self.Img_HpValue.transform.localPosition = lierenxuetiao ? new Vector3(-82.5f, 1.9f, 0f) : new Vector3(-82.5f, 0.1f, 0f);

             
             self.Lal_Name = rc.Get<GameObject>("Lal_Name");
             self.Lal_JiaZuName = rc.Get<GameObject>("Lal_JiaZuName");
             self.UIPosition = unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
             GameObject bloodparent = unit.Type == UnitType.Monster ? UIEventComponent.Instance.BloodMonster :  UIEventComponent.Instance.BloodPlayer ;
             self.GameObject.transform.SetParent(bloodparent.transform);
             self.GameObject.transform.localScale = Vector3.one;

             self.UIPlayerHpText = rc.Get<GameObject>("UIPlayerHpText");
             self.UIPlayerHpText.transform.SetParent(UIEventComponent.Instance.BloodText.transform);
             self.UIPlayerHpText.transform.localScale = Vector3.one;
             HeadBarUI HeadBarUI_1 = self.UIPlayerHpText.GetComponent<HeadBarUI>();
             HeadBarUI_1.enabled = !unit.MainHero;
             HeadBarUI_1.HeadPos = self.UIPosition;
             HeadBarUI_1.HeadBar = self.UIPlayerHpText;
             HeadBarUI_1.UiCamera = UIEventComponent.Instance.UICamera;
             HeadBarUI_1.MainCamera = UIEventComponent.Instance.MainCamera;
             HeadBarUI_1.UpdatePostion();

             HeadBarUI HeadBarUI_2 = self.GameObject.GetComponent<HeadBarUI>();
             HeadBarUI_2.enabled =  !unit.MainHero;
             HeadBarUI_2.HeadPos = self.UIPosition;
             HeadBarUI_2.HeadBar = self.GameObject;
             HeadBarUI_2.UiCamera = UIEventComponent.Instance.UICamera;
             HeadBarUI_2.MainCamera = UIEventComponent.Instance.MainCamera;
             HeadBarUI_2.UpdatePostion();

             if (unit.MainHero)
             {
                 self.OnUpdateHorse();
                 self.GameObject.transform.SetAsLastSibling();
             }
             else
             {
                 self.GameObject.transform.SetAsFirstSibling();
             }
             self.GameObject.SetActive(true);

             //初始化当前血条
             self.UpdateBlood();
             //更新显示
             self.UpdateShow();

             self.ShowJueXingAnger();

             self.UpdateSkillUseMP();

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

         public static void OnUpdateHorse(this UIPlayerHpComponent self  )
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
                 vector3_zuoqi.y +=(float) zuoQiShowConfig.NameShowUp;
             }

             self.GameObject.transform.localPosition = horseRide > 0 ? vector3_zuoqi : vector3_normal;
             if (unit.MainHero)
             {
                 self.UIPlayerHpText.transform.localPosition = horseRide > 0 ? vector3_zuoqi : vector3_normal;
             }
         }

         public static void OnUpdateUnionName(this UIPlayerHpComponent self  )
         {
             if (self.Lal_JiaZuName == null)
             {
                 return;
             }
             Unit unit = self.GetParent<Unit>();
             NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
             UnitInfoComponent infoComponent = unit.GetComponent<UnitInfoComponent>();
             int firstUnionName = numericComponent.GetAsInt(NumericType.FirstUnionName);

             string unionname = string.Empty;
             //判断自身是否有家族进行显示
             if (firstUnionName == 1 && infoComponent.UnionName.Length > 0)
             {
                 string text1 = numericComponent.GetAsInt(NumericType.UnionLeader) == 1 ? "族长" : "成员";
                 unionname = infoComponent.UnionName + text1;

                 if (numericComponent.GetAsInt(NumericType.UnionRaceWin) == 1 && !string.IsNullOrEmpty(unionname))
                 {
                     unionname += "(争霸)";
                 }
             }
             if (string.IsNullOrEmpty(unionname) )
             {
                 int rankId = numericComponent.GetAsInt(NumericType.CombatRankID);
                 int occRankId = numericComponent.GetAsInt(NumericType.OccCombatRankID);
                 int occ = unit.ConfigId;
                 unionname = ConfigHelper.GetRankChengHao(rankId, occRankId, occ);
             }
             if (string.IsNullOrEmpty(unionname) )
             {
                 unionname = infoComponent.UnionName;
             }

             self.Lal_JiaZuName.GetComponent<Text>().text = unionname;
             Vector3 vector3_pos = unionname.Length > 0 ? new Vector3(0f, 100f, 0f) : new Vector3(0f, 75f, 0f);
             self.Img_ChengHao.transform.localPosition = vector3_pos;
         }

         //更新显示
         public static void UpdateShow(this UIPlayerHpComponent self )
         {
             Unit unit = self.GetParent<Unit>();
             UnitInfoComponent infoComponent = unit.GetComponent<UnitInfoComponent>();
             //显示玩家名称
             if (unit.Type == UnitType.Player)
             {
                 NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

                 int tilteid = numericComponent.GetAsInt(NumericType.TitleID);
                 
                 self.UIXuLieZhenComponent.OnUpdateTitle(tilteid).Coroutine();
                 self.Lal_Name.GetComponent<Text>().text = infoComponent.UnitName;
                 self.UpdateDemonName(infoComponent.DemonName);
                 self.OnUpdateUnionName();
             }
             //显示怪物名称
             if (unit.Type == UnitType.Monster)
             {
                 MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(self.GetParent<Unit>().ConfigId);
                 Text textMeshProUGUI = self.Lal_Name.GetComponent<Text>();
                 bool isboos = monsterCof.MonsterType == (int)MonsterTypeEnum.Boss;
                 textMeshProUGUI.fontSize = isboos ? 32 : 26;
                 textMeshProUGUI.color = isboos ? new Color(255,95,255): Color.white;
                 string colorstr = isboos ? "<color=#FF5FFF>" : "<color=#FFFFFF>";
                 //NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                 //this.ObjName.GetComponent<TextMeshProUGUI>().text = $"{colorstr}{monsterCof.MonsterName}_{numericComponent.GetAsInt(NumericType.Now_AI)}</color>";
                 MapComponent mapComponent = unit.Root().GetComponent<MapComponent>();    
                 bool shenYuan = mapComponent.SceneType == SceneTypeEnum.TeamDungeon && mapComponent.FubenDifficulty == TeamFubenType.ShenYuan;
                 if (shenYuan)
                 {
                     if (monsterCof.MonsterType == 3)
                     {
                         self.Lal_Name.GetComponent<Text>().text = $"深渊召唤:{colorstr}{monsterCof.MonsterName}</color>";
                     }
                     else
                     {
                         self.Lal_Name.GetComponent<Text>().text = $"{colorstr}{monsterCof.MonsterName}</color>";
                     }
                 }
                 else
                 {
                     self.Lal_Name.GetComponent<Text>().text = $"{colorstr}{monsterCof.MonsterName}</color>";
                 }

                 //怪物等级显示
                 ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
                 int monsterLv = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_Lv);
                 if (monsterLv > 0)
                 {
                     rc.Get<GameObject>("Lal_Lv").GetComponent<Text>().text = monsterLv.ToString();
                 }
                 else
                 {
                     rc.Get<GameObject>("Lal_Lv").GetComponent<Text>().text = monsterCof.Lv.ToString();
                 }
             }
             if (self.GetParent<Unit>().Type == UnitType.Pet) 
             {
                 UnitInfoComponent unitInfoComponent = self.GetParent<Unit>().GetComponent<UnitInfoComponent>();
                 self.Lal_Name.GetComponent<Text>().text = unitInfoComponent.UnitName;
                 self.Lal_JiaZuName.GetComponent<Text>().text = $"{unitInfoComponent.MasterName }的宠物";
             }
             if (self.GetParent<Unit>().Type == UnitType.JingLing)
             {
                 UnitInfoComponent unitInfoComponent = self.GetParent<Unit>().GetComponent<UnitInfoComponent>();
                 self.Lal_Name.GetComponent<Text>().text = unitInfoComponent.UnitName;
                 self.Lal_JiaZuName.GetComponent<Text>().text = $"{unitInfoComponent.MasterName }的精灵";
             }
             if (self.GetParent<Unit>().Type == UnitType.Stall)
             {
                 UnitInfoComponent unitInfoComponent = self.GetParent<Unit>().GetComponent<UnitInfoComponent>();
                 self.Lal_Name.GetComponent<Text>().text = unitInfoComponent.UnitName;
             }
         }

         public static void OnRevive(this UIPlayerHpComponent self )
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
             } 
             self.UpdateBlood();
         }

         public static void OnDead(this UIPlayerHpComponent self)
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

                 self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                 self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UIUnitReviveTime, self);
             }
         }

         public static void UpdateAI(this UIPlayerHpComponent self)
         {
             if (self.Lal_Name != null)
             {
                 self.UpdateShow();
             }
         }

         public static void UpdateBlood(this UIPlayerHpComponent self)
         {
             NumericComponentC numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
             float curhp = numericComponent.GetAsLong(NumericType.Now_Hp); // + value;
             float blood = curhp / numericComponent.GetAsLong(NumericType.Now_MaxHp);
             blood = Mathf.Max(blood, 0f);
             if (self.Img_HpValue == null)
             {
                 return;
             }
             int unitType = self.GetParent<Unit>().Type;
             switch (unitType)
             {
                 case UnitType.Player:
                     self.Img_HpValue.GetComponent<Image>().fillAmount = blood;
                     int shieldHp = numericComponent.GetAsInt(NumericType.Now_Shield_HP);
                     int shieldMax = numericComponent.GetAsInt(NumericType.Now_Shield_MaxHP);
                     if (shieldMax > 0)
                     {
                         self.BuffShieldValue.GetComponent<Image>().fillAmount = shieldHp * 1f / shieldMax;
                     }
                     else
                     {
                         self.BuffShieldValue.GetComponent<Image>().fillAmount = 0f;
                     }
                     break;
                 case UnitType.Pet:
                     self.Img_HpValue.GetComponent<Image>().fillAmount = blood;
                     break;
                 default:
                     self.Img_HpValue.GetComponent<Image>().fillAmount = blood;
                     break;
             }
         }

         public  static void OnTimer(this UIPlayerHpComponent self)
         {
             MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(self.GetParent<Unit>().ConfigId);
             long leftTime = self.GetParent<Unit>().GetComponent<NumericComponentC>().GetAsLong(NumericType.ReviveTime) - TimeHelper.ClientNow();
             leftTime = leftTime / 1000;
             ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
             GameObject reviveTime = rc.Get<GameObject>("ReviveTime");
             int hour = (int) leftTime / 3600;
             int min = (int)((leftTime - (hour * 3600))/60);
             int sec = (int)(leftTime - (hour * 3600) - (min * 60));
             string showStr = hour + "时" + min + "分" + sec + "秒";
             reviveTime.GetComponent<Text>().text = $"{monsterConfig.MonsterName} 刷新剩余时间:{showStr}";
         }

         public static void OnGetUseInfoUpdate(this UIPlayerHpComponent self)
         {
             self.ShowJueXingAnger();

             self.UpdateSkillUseMP();    
         }

         public static  void ShowJueXingAnger(this UIPlayerHpComponent self)
         {
             if (self.Img_AngleValue == null)
             {
                 return;
             }

             Unit unit = self.GetParent<Unit>();
             if (!unit.MainHero)
             {
                 self.Img_AngleValue.gameObject.SetActive(false);
                 self.Img_AngleValueDi.SetActive(false);
                 return;
             }
             UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
             if (userInfoComponent == null || userInfoComponent.UserInfo == null)
             {
                 return;
             }

             int occTwo = userInfoComponent.UserInfo.OccTwo;
             if (occTwo == 0)
             {
                 return;
             }
             SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
             OccupationTwoConfig occupationConfigCategory = OccupationTwoConfigCategory.Instance.Get(occTwo);
             self.Img_AngleValue.gameObject.SetActive(skillSetComponent.GetSkillPro(occupationConfigCategory.JueXingSkill[7]) != null);
             self.Img_AngleValueDi.SetActive(skillSetComponent.GetSkillPro(occupationConfigCategory.JueXingSkill[7]) != null);
         }
         
        public static void ShowDialog(this UIPlayerHpComponent self)
        {
            ChatInfo chatInfo = self.Root().GetComponent<ChatComponent>().LastChatInfo;
            if (chatInfo.ChannelId != ChannelEnum.Team)
            {
                return;
            }

            if (chatInfo.UserId != self.GetParent<Unit>().Id)
            {
                return;
            }

            self.DialogText.SetActive(true);
            self.DialogText.GetComponent<Text>().text = chatInfo.ChatMsg;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.DialogTimer);
            self.DialogTimer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeHelper.ServerNow() + 2000, TimerInvokeType.DialogTimer, self);
        }

        public static void HideDialog(this UIPlayerHpComponent self)
        {
            self.DialogText.SetActive(false);
        }

        public static void UpdateDemonName(this UIPlayerHpComponent self, string stallName)
        {
            if (string.IsNullOrEmpty(stallName))
            {
                self.Lal_AddtionName.GetComponent<Text>().text = string.Empty;
            }
            else
            {
                self.Lal_AddtionName.GetComponent<Text>().text = $"{stallName}的小跟班";
            }
        }

        public static void UpdateShield(this UIPlayerHpComponent self)
        { 
            
        }

        public static void UpdateSkillUseMP(this UIPlayerHpComponent self)
        {
            if (self.Img_MpValue == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int skillmp = numericComponent.GetAsInt(NumericType.SkillUseMP);
            int maxMp = numericComponent.GetAsInt(NumericType.Max_SkillUseMP);
            if (skillmp == 0)
            {
                self.Img_MpValueDi.gameObject.SetActive(false);
                self.Img_MpValue.gameObject.SetActive(false);
            }
            else
            {
                self.Img_MpValueDi.gameObject.SetActive(true);
                self.Img_MpValue.gameObject.SetActive(true);
                float value = skillmp * 1f / maxMp;
                self.Img_MpValue.fillAmount = math.min(value, 1f);
            }
        }

        public static void UptateJueXingAnger(this UIPlayerHpComponent self)
        {
            if (self.Img_AngleValue == null)
            {
                return;
            }
            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            float value = numericComponent.GetAsInt(NumericType.JueXingAnger) * 1f/ 500;
            self.Img_AngleValue.fillAmount = math.min( value, 1f );
        }

        /// <summary>
        /// 阵营改变，其他玩家的血条颜色做相应调整
        /// </summary>
        /// <param name="self"></param>
        public static void UpdateBattleCamp(Unit mainUnit,  long unitId)
        {
            if (mainUnit == null)
            {
                Log.Error("UpdateBattleCamp/mainUnit == null");

            }
            List<Unit> unitlist = UnitHelper.GetUnitsByType(mainUnit.Root(), UnitType.Player);
            for (int i = 0; i < unitlist.Count; i++)
            {
                bool update = false;
                if (unitlist[i].Id == mainUnit.Id || unitlist[i].Id == unitId || unitId == mainUnit.Id)
                {
                    update = true;
                }

                if (!update)
                {
                    continue;
                }

                bool canAttack = mainUnit.IsCanAttackUnit(unitlist[i]);
                string imageHp = canAttack ? ConfigData.UI_pro_4_2 : ConfigData.UI_pro_3_2;

                switch (unitlist[i].Type)
                {
                    case UnitType.Player:
                        UIPlayerHpComponent uIUnitHpComponent = unitlist[i].GetComponent<UIPlayerHpComponent>();
                        if (uIUnitHpComponent!= null && uIUnitHpComponent.Img_HpValue!= null)
                        {
                            ReferenceCollector rc = uIUnitHpComponent.GameObject.GetComponent<ReferenceCollector>();
                            Sprite sp = rc.Get<GameObject>(imageHp).GetComponent<Image>().sprite;
                            uIUnitHpComponent.Img_HpValue.GetComponent<Image>().sprite = sp;
                        }
                        break;
                }
            }
        }

         public static void RecoverGameObject(this UIPlayerHpComponent self, GameObject gameobject)
         {
             if (gameobject != null)
             {
                 gameobject.GetComponent<HeadBarUI>().enabled = false;
                 if (self.UIPlayerHpText != null)
                 {
                     self.UIPlayerHpText.GetComponent<HeadBarUI>().enabled = false;
                     self.UIPlayerHpText.transform.SetParent(gameobject.transform);
                 }
                
                 GameObjectPoolComponent.Instance.RecoverGameObject(self.HeadBarPath, gameobject);
                 self.GameObject = null;
             }
         }
    }

}