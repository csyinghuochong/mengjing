using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.MonsterSingingTimer)]
    public class MonsterSingingTimer: ATimer<ES_MainHpBar>
    {
        protected override void Run(ES_MainHpBar self)
        {
            try
            {
                self.OnSinging();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [EntitySystemOf(typeof (ES_MainHpBar))]
    [FriendOfAttribute(typeof (ES_MainHpBar))]
    public static partial class ES_MainHpBarSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainHpBar self, Transform transform)
        {
            self.uiTransform = transform;
            
            self.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
            self.EG_BossNodeRectTransform.gameObject.SetActive(false);
            self.E_r
        }

        [EntitySystem]
        private static void Destroy(this ES_MainHpBar self)
        {
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
            UI uI = await UIHelper.Create(self.ZoneScene(), UIType.UIZhanQu);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.ZoneScene().GetComponent<BattleMessageComponent>().FirstWinBossId = self.BossConfiId;
            uI.GetComponent<UIZhanQuComponent>().OnClickGoToFirstWin(self.BossConfiId).Coroutine();
        }

        public static void BeginEnterScene(this ES_MainHpBar self)
        {
            self.MonsterNode.SetActive(false);
            self.Lab_Owner.text = string.Empty;
            self.PetHurt = 0;
            self.PlayerHurt = 0;
            self.MyUnitId = UnitHelper.GetMyUnitId(self.ZoneScene());
            self.UpdateHurtText();
            self.BossNode.SetActive(false);
        }

        public static void OnUpdateBelongID(this ES_MainHpBar self, long bossid, long belongid)
        {
            if (bossid != self.LockBossId)
            {
                return;
            }

            self.Lab_Owner.text = string.Empty;
            Unit unitmain = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            Unit unitboss = unitmain.GetParent<UnitComponent>().Get(bossid);
            MapComponent mapComponent = self.ZoneScene().GetComponent<MapComponent>();
            if (mapComponent.SceneTypeEnum == SceneTypeEnum.LocalDungeon)
            {
                int killNumber = self.ZoneScene().GetComponent<UserInfoComponent>().GetMonsterKillNumber(unitboss.ConfigId);
                int chpaterid = DungeonConfigCategory.Instance.GetChapterByDungeon(mapComponent.SceneId);
                BossDevelopment bossDevelopment = ConfigHelper.GetBossDevelopmentByKill(chpaterid, killNumber);
                self.Lab_Deve.text = bossDevelopment.Name;
            }
            else
            {
                self.Lab_Deve.text = string.Empty;
            }

            Unit unitbelong = unitmain.GetParent<UnitComponent>().Get(belongid);
            if (unitbelong == null)
            {
                self.Lab_Owner.text = string.Empty;
                return;
            }

            if (unitbelong.Id == unitmain.Id)
            {
                self.Lab_Owner.color = new Color(148f / 255f, 1, 0); //绿色
            }
            else
            {
                self.Lab_Owner.color = new Color(255f / 255f, 99f / 255f, 66f / 255f); //红色
            }

            self.Lab_Owner.text = $"掉落归属:{unitbelong.GetComponent<UnitInfoComponent>().UnitName}";
        }

        public static void OnLockUnit(this ES_MainHpBar self, Unit unit)
        {
            int configid = unit.ConfigId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(configid);
            if (monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss)
            {
                return;
            }

            self.MonsterNode.SetActive(true);
            self.Lab_MonsterName.GetComponent<Text>().text = monsterConfig.MonsterName;
            MapComponent mapComponent = self.ZoneScene().GetComponent<MapComponent>();
            if (mapComponent.SceneTypeEnum == (int)SceneTypeEnum.Tower)
            {
                UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
                self.Lab_MonsterLv.GetComponent<Text>().text = userInfoComponent.UserInfo.Lv.ToString();
            }
            else
            {
                self.Lab_MonsterLv.GetComponent<Text>().text = monsterConfig.Lv.ToString();
            }

            self.OnUpdateHP(unit);
        }

        public static void OnUpdateHP(this ES_MainHpBar self, Unit defend, Unit attack, long hurtvalue)
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
            return value.ToString("0.#") + "万";
        }

        public static void UpdateHurtText(this ES_MainHpBar self)
        {
            if (self.PlayerHurt == 0 && self.PetHurt == 0)
            {
                self.HurtTextNode.SetActive(false);
            }
            else
            {
                self.HurtTextNode.SetActive(true);
                self.HurtTextPlayer.text = "玩家: " + self.ShowHurtString(self.PlayerHurt);
                self.HurtTextPet.text = "宠物: " + self.ShowHurtString(self.PetHurt);
            }
        }

        public static void OnSinging(this ES_MainHpBar self)
        {
            long leftTime = self.SingEndTime - TimeHelper.ClientNow();
            float rage = Math.Max(0f, (1f * leftTime / self.SingTotalTime));
            self.Img_SingValue.fillAmount = rage;
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
                self.SingNode.SetActive(true);
                self.HurtTextNode.SetActive(false);
                self.Img_SingValue.fillAmount = 1f;
                TimerComponent.Instance?.Remove(ref self.SingTimer);
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(paramid);
                self.SingTimer = TimerComponent.Instance.NewRepeatedTimer(100, TimerType.MonsterSingingTimer, self);
                self.SingTotalTime = (long)(skillConfig.SkillFrontSingTime * 1000);
                self.SingEndTime = self.SingTotalTime + TimeHelper.ClientNow();
            }

            if (operate == 2)
            {
                self.SingNode.SetActive(false);
                self.HurtTextNode.SetActive(true);
                TimerComponent.Instance?.Remove(ref self.SingTimer);
            }
        }

        public static void OnUpdateHP(this ES_MainHpBar self, Unit unit)
        {
            if (self.LockTargetComponent.LastLockId != unit.Id
                && self.LockBossId != unit.Id)
            {
                return;
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
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

            self.Vector3.x = blood;
            if (self.LockTargetComponent.LastLockId == unit.Id)
            {
                //更新怪物血条
                self.Img_MonsterHp.transform.localScale = self.Vector3;
            }

            if (self.LockBossId == unit.Id)
            {
                //更新Boss血条
                self.Img_BossHp.transform.localScale = self.Vector3;
            }
        }

        public static void OnUnitDead(this ES_MainHpBar self, long unitid)
        {
            if (self.LockTargetComponent.LastLockId == unitid)
            {
                self.MonsterNode.SetActive(false);
            }

            if (self.LockBossId == unitid)
            {
                self.PetHurt = 0;
                self.PlayerHurt = 0;
                self.UpdateHurtText();
                self.BossNode.SetActive(false);
                self.Lab_Owner.text = string.Empty;
            }
        }

        public static void OnCancelLock(this ES_MainHpBar self)
        {
            self.MonsterNode.SetActive(false);
        }

        public static void UpdateModelShowView(this ES_MainHpBar self, int monsterId)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            self.UIModelShowComponent.ShowModel("Monster/" + monsterConfig.MonsterModelID.ToString()).Coroutine();
        }

        public static void ShowBossHPBar(this ES_MainHpBar self, Unit unit)
        {
            if (self.BossNode.activeSelf && unit != null)
            {
                return;
            }

            if (!self.BossNode.activeSelf && unit == null)
            {
                return;
            }

            if (unit == null || unit.GetComponent<NumericComponent>()?.GetAsInt(NumericType.Now_Dead) == 1)
            {
                self.LockBossId = 0;
                self.BossConfiId = 0;
                self.PetHurt = 0;
                self.PlayerHurt = 0;
                self.UpdateHurtText();
                self.BossNode.SetActive(false);
                self.Lab_Owner.text = string.Empty;
                self.UIModelShowComponent.RemoveModel();
            }
            else
            {
                int configid = unit.ConfigId;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(configid);
                self.LockBossId = unit.Id;
                self.BossConfiId = unit.ConfigId;
                self.BossNode.SetActive(true);
                self.Lab_BossLv.GetComponent<Text>().text = monsterConfig.Lv.ToString();
                self.Lab_BossName.GetComponent<Text>().text = monsterConfig.MonsterName;
                self.UpdateModelShowView(configid);
                self.OnUpdateHP(unit);
                self.OnUpdateBelongID(unit.Id, unit.GetComponent<NumericComponent>().GetAsLong(NumericType.BossBelongID));

                //掉落类型为3,名字上移
                if (monsterConfig.DropType == 3)
                {
                    self.Lab_BossName.transform.localPosition = new Vector3(self.Lab_BossName.transform.localPosition.x, 385,
                        self.Lab_BossName.transform.localPosition.z);
                    self.Lab_Owner.gameObject.SetActive(true);
                }
                else
                {
                    self.Lab_Owner.text = "";
                    self.Lab_Owner.gameObject.SetActive(false);
                }

                self.UIMainBuffComponent.ResetUI();
            }
        }
    }
}