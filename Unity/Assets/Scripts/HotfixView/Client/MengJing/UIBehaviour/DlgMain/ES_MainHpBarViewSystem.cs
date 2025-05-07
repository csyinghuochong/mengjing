using System;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UIMonsterSingingTimer)]
    public class UIMonsterSingingTimer : ATimer<ES_MainHpBar>
    {
        protected override void Run(ES_MainHpBar self)
        {
            try
            {
                self.OnSinging();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [EntitySystemOf(typeof(ES_MainHpBar))]
    [FriendOfAttribute(typeof(ES_MainHpBar))]
    public static partial class ES_MainHpBarSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainHpBar self, Transform transform)
        {
            self.uiTransform = transform;

            self.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
            self.EG_BossNodeRectTransform.gameObject.SetActive(false);
            self.ES_ModelShow.ClickHandler = () => { self.OnImg_BossIcon().Coroutine(); };

            self.E_Lab_DeveText.gameObject.SetActive(true);

            self.EG_SingNodeRectTransform.gameObject.SetActive(false);
            self.EG_HurtTextNodeRectTransform.gameObject.SetActive(false);
            self.UpdateHurtText();

            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 100f, 378f));
            self.LockTargetComponent = self.Root().GetComponent<LockTargetComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ES_MainHpBar self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.SingTimer);
            self.DestroyWidget();
        }

        public static async ETTask OnImg_BossIcon(this ES_MainHpBar self)
        {
            if (self.BossConfiId == 0)
            {
                return;
            }

            KeyValuePairInt keyValuePair = FirstWinConfigCategory.Instance.GetBossChapter(self.BossConfiId);
            if (keyValuePair == null)
            {
                return;
            }

            //70001011 野猪王
            long instanceid = self.InstanceId;

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ZhanQu);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<BattleMessageComponent>().FirstWinBossId = self.BossConfiId;
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgZhanQu>().OnClickGoToFirstWin(self.BossConfiId);
        }

        public static void BeforeEnterScene(this ES_MainHpBar self)
        {
            self.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
            self.E_Lab_OwnerText.text = string.Empty;
            self.PetHurt = 0;
            self.PlayerHurt = 0;
            self.MyUnitId = UnitHelper.GetMyUnitId(self.Root());
            self.UpdateHurtText();
            self.EG_BossNodeRectTransform.gameObject.SetActive(false);
        }

        public static void AfterEnterScene(this ES_MainHpBar self, int sceneType)
        {
            self.SceneType = sceneType;
        }

        public static void OnUpdateBelongID(this ES_MainHpBar self, long bossid, long belongid)
        {
            if (bossid != self.LockBossId)
            {
                return;
            }

            self.E_Lab_OwnerText.text = string.Empty;
            Unit unitmain = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Unit unitboss = unitmain.GetParent<UnitComponent>().Get(bossid);
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.LocalDungeon)
            {
                int killNumber = self.Root().GetComponent<UserInfoComponentC>().GetMonsterKillNumber(unitboss.ConfigId);
                int chpaterid = DungeonConfigCategory.Instance.GetChapterByDungeon(mapComponent.SceneId);
                BossDevelopment bossDevelopment = ConfigHelper.GetBossDevelopmentByKill(chpaterid, killNumber);
                self.E_Lab_DeveText.text = bossDevelopment.Name;
            }
            else
            {
                self.E_Lab_DeveText.text = string.Empty;
            }

            Unit unitbelong = unitmain.GetParent<UnitComponent>().Get(belongid);
            if (unitbelong == null)
            {
                self.E_Lab_OwnerText.text = string.Empty;
                return;
            }

            if (unitbelong.Id == unitmain.Id)
            {
                self.E_Lab_OwnerText.color = new Color(148f / 255f, 1, 0); //绿色
            }
            else
            {
                self.E_Lab_OwnerText.color = new Color(255f / 255f, 99f / 255f, 66f / 255f); //红色
            }

            using (zstring.Block())
            {
                self.E_Lab_OwnerText.text = zstring.Format("掉落归属:{0}", unitbelong.GetComponent<UnitInfoComponent>().UnitName);
            }
        }

        public static void OnLockUnit(this ES_MainHpBar self, Unit unit)
        {
            int configid = unit.ConfigId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(configid);
            if (monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss)
            {
                return;
            }
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            int babyType =  numericComponentC.GetAsInt(NumericType.BaByType);
            string addname = CommonViewHelper.GetMonsterShowName(babyType);
            self.EG_MonsterNodeRectTransform.gameObject.SetActive(true);
            
            if (!string.IsNullOrEmpty(addname))
            {
                using (zstring.Block())
                {
                  self.E_Lab_MonsterNameText.text = zstring.Format("{0}{1}", monsterConfig.MonsterName, addname);
                }

            }
            else
            {
                self.E_Lab_MonsterNameText.text = monsterConfig.MonsterName;
            }
            
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == (int)MapTypeEnum.Tower)
            {
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                self.E_Lab_MonsterLvText.text = userInfoComponent.UserInfo.Lv.ToString();
            }
            else
            {
                self.E_Lab_MonsterLvText.text = monsterConfig.Lv.ToString();
            }

            self.OnUpdateHP(unit);
        }

        public static void OnUpdateDamage(this ES_MainHpBar self, Unit defend, Unit attack, long hurtvalue)
        {
            if (defend.Id != self.LockBossId)
            {
                return;
            }

            if (hurtvalue > 0 || attack == null)
            {
                return;
            }

            hurtvalue *= -1;

            if (attack.MainHero)
            {
                //玩家伤害
                self.PlayerHurt += hurtvalue;
                self.UpdateHurtText();
            }
            else if (attack.GetMasterId() == self.MyUnitId)
            {
                self.PetHurt += hurtvalue;
                self.UpdateHurtText();
            }
        }

        public static void OnUpdateHP(this ES_MainHpBar self, long playerHurt, long petHurt)
        {
            self.PlayerHurt = playerHurt;
            self.PetHurt = petHurt;
            self.UpdateHurtText();
        }

        public static string ShowHurtString(this ES_MainHpBar self, long hurt)
        {
            if (hurt == 0)
            {
                return self.DefaultString;
            }

            if (hurt <= 10000)
            {
                return hurt.ToString();
            }

            float value = hurt / 10000f;
            using (zstring.Block())
            {
                return (zstring)value.ToString("0.#") + "万";
            }
        }

        public static void UpdateHurtText(this ES_MainHpBar self)
        {
            if (self.PlayerHurt == 0 && self.PetHurt == 0)
            {
                self.EG_HurtTextNodeRectTransform.gameObject.SetActive(false);
            }
            else
            {
                self.EG_HurtTextNodeRectTransform.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.E_HurtTextPlayerText.text = zstring.Format("玩家: {0}", self.ShowHurtString(self.PlayerHurt));
                    self.E_HurtTextPetText.text = zstring.Format("宠物: {0}", self.ShowHurtString(self.PetHurt));
                }
            }
        }

        public static void OnSinging(this ES_MainHpBar self)
        {
            long leftTime = self.SingEndTime - TimeHelper.ClientNow();
            float rage = Math.Max(0f, (1f * leftTime / self.SingTotalTime));
            self.E_Img_SingValueImage.fillAmount = rage;
        }

        public static void OnUpdateSing(this ES_MainHpBar self, string paramsinfo)
        {
            string[] infolist = paramsinfo.Split('_');
            long unitid = long.Parse(infolist[0]);
            if (unitid != self.LockBossId)
            {
                return;
            }

            int operate = int.Parse(infolist[1]);
            int paramid = int.Parse(infolist[2]);
            if (operate == 1)
            {
                self.EG_SingNodeRectTransform.gameObject.SetActive(true);
                self.EG_HurtTextNodeRectTransform.gameObject.SetActive(false);
                self.E_Img_SingValueImage.fillAmount = 1f;
                self.Root().GetComponent<TimerComponent>().Remove(ref self.SingTimer);
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(paramid);
                self.SingTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(100, TimerInvokeType.UIMonsterSingingTimer, self);
                self.SingTotalTime = (long)(skillConfig.SkillFrontSingTime * 1000);
                self.SingEndTime = self.SingTotalTime + TimeHelper.ClientNow();
            }

            if (operate == 2)
            {
                self.EG_SingNodeRectTransform.gameObject.SetActive(false);
                self.EG_HurtTextNodeRectTransform.gameObject.SetActive(true);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.SingTimer);
            }
        }

        public static void OnUpdateHP(this ES_MainHpBar self, Unit unit)
        {
            if (self.LockTargetComponent.LastLockId != unit.Id
                && self.LockBossId != unit.Id)
            {
                return;
            }

            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            float curhp = numericComponent.GetAsLong(NumericType.Now_Hp);
            float maxHp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
            if (maxHp == 0)
            {
                return;
            }

            float blood = curhp / numericComponent.GetAsLong(NumericType.Now_MaxHp);
            if (blood < 0)
            {
                blood = 0;
            }

            
            if (self.LockTargetComponent.LastLockId == unit.Id)
            {
                //更新怪物血条
                self.E_Img_MonsterHpImage.fillAmount = blood;
                RectTransform HpRight = self.E_Img_MonsterHpImage.transform.Find("HpRight").transform.GetComponent<RectTransform>();
                if (blood <= 0 || Mathf.Approximately(blood, 1f))
                {
                    HpRight.gameObject.SetActive(false);
                }
                else
                {
                    HpRight.gameObject.SetActive(true);
                    Vector2 highlightPos = HpRight.localPosition;
                    highlightPos.x =self.E_Img_MonsterHpImage.rectTransform.sizeDelta.x * blood - 7f;
                    HpRight.localPosition = highlightPos;
                }
            }

            if (self.LockBossId == unit.Id)
            {
                //更新Boss血条
                self.E_Img_BossHpImage.fillAmount = blood;
                if (blood <= 0)
                {
                    self.E_Img_BoosHpRightImage.gameObject.SetActive(false);
                }
                else
                {
                    self.E_Img_BoosHpRightImage.gameObject.SetActive(true);
                    self.E_Img_BoosHpRightImage.rectTransform.localPosition =
                            new Vector3(self.E_Img_BossHpImage.rectTransform.sizeDelta.x * blood - 26f, 0.5f, 0);
                }
            }
        }

        public static void OnUnitDead(this ES_MainHpBar self, long unitid)
        {
            if (self.LockTargetComponent.LastLockId == unitid)
            {
                self.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
            }

            if (self.LockBossId == unitid)
            {
                self.PetHurt = 0;
                self.PlayerHurt = 0;
                self.UpdateHurtText();
                self.EG_BossNodeRectTransform.gameObject.SetActive(false);
                self.E_Lab_OwnerText.text = string.Empty;
            }
        }

        public static void OnCancelLock(this ES_MainHpBar self)
        {
            self.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
        }

        public static void UpdateModelShowView(this ES_MainHpBar self, int monsterId)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            using (zstring.Block())
            {
                //self.ES_ModelShow.ShowOtherModel(zstring.Format("Monster/{0}", monsterConfig.MonsterModelID)).Coroutine();
            }
            self.ES_ModelShow.SetShow(false);
            
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_Boss_Icon.gameObject.SetActive(true);
            self.E_Boss_Icon.sprite = sp;
        }

        public static void ShowBossHPBar(this ES_MainHpBar self, Unit unit)
        {
            bool activeSelf = self.EG_BossNodeRectTransform.gameObject.activeSelf;
           
            if (!activeSelf && unit == null)
            {
                return;
            }
            
            if (activeSelf && unit != null && unit.Id ==  self.LockBossId)
            {
                return;
            }


            if (unit == null || unit.GetComponent<NumericComponentC>()?.GetAsInt(NumericType.Now_Dead) == 1)
            {
                self.LockBossId = 0;
                self.BossConfiId = 0;
                self.PetHurt = 0;
                self.PlayerHurt = 0;
                self.UpdateHurtText();
                self.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
                self.E_Lab_OwnerText.text = string.Empty;
                self.ES_ModelShow.RemoveModel();
            }
            else
            {
                int configid = unit.ConfigId;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(configid);
                self.LockBossId = unit.Id;
                self.BossConfiId = unit.ConfigId;
                self.EG_BossNodeRectTransform.gameObject.SetActive(true);
                self.E_Lab_BossLvText.text = monsterConfig.Lv.ToString();
                self.E_Lab_BossNameText.text = monsterConfig.MonsterName;
                self.UpdateModelShowView(configid);
                self.OnUpdateHP(unit);
                self.OnUpdateBelongID(unit.Id, unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.BossBelongID));

                //掉落类型为3,名字上移
                if (monsterConfig.DropType == 3 && !string.IsNullOrEmpty(self.E_Lab_OwnerText.text))
                {
                    self.E_Lab_BossNameText.transform.localPosition = new Vector3(self.E_Lab_BossNameText.transform.localPosition.x, 385,
                        self.E_Lab_BossNameText.transform.localPosition.z);
                    self.E_Lab_OwnerText.gameObject.SetActive(true);
                }
                else
                {
                    self.E_Lab_OwnerText.text = "";
                    self.E_Lab_OwnerText.gameObject.SetActive(false);
                }

                self.ES_MainBuff.ResetUI();
            }
        }
    }
}
