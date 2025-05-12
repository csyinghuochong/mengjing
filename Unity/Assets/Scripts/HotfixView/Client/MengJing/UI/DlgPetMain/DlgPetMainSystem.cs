using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.PetMainTimer)]
    public class PetMainTimer : ATimer<DlgPetMain>
    {
        protected override void Run(DlgPetMain self)
        {
            try
            {
                self.OnTimer();
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

    [FriendOf(typeof(DlgPetMain))]
    public static class DlgPetMainSystem
    {
        public static void RegisterUIEvent(this DlgPetMain self)
        {
            self.CameraTarget = self.Root().GetComponent<GlobalComponent>().MainCamera.transform;

            self.View.E_Btn_RerurnBuildingButton.AddListener(() => { self.OnBtn_RerurnBuilding(); });

            self.View.E_PetFubenFingerEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
                (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.View.E_PetFubenFingerEventTrigger.RegisterEvent(EventTriggerType.Drag,
                (pdata) => { self.Draging(pdata as PointerEventData); });
            self.View.E_PetFubenFingerEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
                (pdata) => { self.EndDrag(pdata as PointerEventData); });
            
            self.View.E_PetFubenFingerImage.color = new(255, 255, 255, 0);

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            self.View.E_PetFubenFingerImage.gameObject.SetActive(mapComponent.MapType == MapTypeEnum.PetDungeon);

            self.PetBattleList.Clear();
            self.View.EG_UIMonsterHpRectTransform.gameObject.SetActive(false);
            self.View.EG_UIPetHpRectTransform.gameObject.SetActive(false);

            self.View.E_Image_3Image.gameObject.SetActive(false);
            self.View.E_Image_2Image.gameObject.SetActive(false);
            self.View.E_Image_1Image.gameObject.SetActive(false);

            self.M2C_FubenSettlement = null;
            self.InitHpList();
            self.OnPlayAnimation().Coroutine();
        }

        public static void ShowWindow(this DlgPetMain self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgPetMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.PetBattleList.Clear();
        }

        public static void OnFubenResult(this DlgPetMain self, M2C_FubenSettlement m2C_FubenSettlement)
        {
            self.M2C_FubenSettlement = m2C_FubenSettlement;
        }

        public static void OnUnitHpUpdate(this DlgPetMain self, Unit defend, Unit attack, long changeHp)
        {
            if (!self.PetBattleList.ContainsKey(defend.Id))
            {
                return;
            }

            NumericComponentC numericComponent = defend.GetComponent<NumericComponentC>();
            float curhp = numericComponent.GetAsLong(NumericType.Now_Hp);
            float blood = curhp / numericComponent.GetAsLong(NumericType.Now_MaxHp);
            blood = Mathf.Max(blood, 0f);
            self.PetBattleList[defend.Id].Image.fillAmount = blood;

            if (attack != null && self.PetBattleList.ContainsKey(attack.Id) && defend != attack && changeHp < 0)
            {
                self.PetBattleList[attack.Id].hurt += (changeHp * -1);
                self.PetBattleList[defend.Id].receive += (changeHp * -1);
                self.UpdateHurtValue(attack.Id);
                self.UpdateHurtValue(defend.Id);
            }
        }

        public static void UpdateHurtValue(this DlgPetMain self, long unitId)
        {
            PetBattleInfo petBattleInfo = self.PetBattleList[unitId];
            using (zstring.Block())
            {
                self.PetBattleList[unitId].Text.text = zstring.Format("造成伤害:{0} 承受伤害:{1}", petBattleInfo.hurt, petBattleInfo.receive);
            }
        }

        public static void InitHpList(this DlgPetMain self)
        {
            List<EntityRef<Unit>> entities = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < entities.Count; i++)
            {
                Unit unit = entities[i];
                if (unit.Type == UnitType.Player)
                {
                    continue;
                }

                int camp = unit.GetBattleCamp();

                self.PetBattleList.Add(unit.Id, new());
                if (camp == CampEnum.CampPlayer_1)
                {
                    GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UIPetHpRectTransform.gameObject);
                    CommonViewHelper.SetParent(gameObject, self.View.EG_PetHpNodeRectTransform.gameObject);
                    gameObject.SetActive(true);

                    gameObject.transform.Find("Lal_Name").GetComponent<Text>().text = PetConfigCategory.Instance.Get(unit.ConfigId).PetName;
                    self.PetBattleList[unit.Id].Image = gameObject.transform.Find("Img_HpValue").GetComponent<Image>();
                    self.PetBattleList[unit.Id].Text = gameObject.transform.Find("Lal_Hurt").GetComponent<Text>();
                    continue;
                }

                if (unit.Type == UnitType.Pet)
                {
                    self.EnemyNumber++;
                    GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UIMonsterHpRectTransform.gameObject);
                    CommonViewHelper.SetParent(gameObject, self.View.EG_MonsterHpNodeRectTransform.gameObject);
                    gameObject.SetActive(true);

                    gameObject.transform.Find("Lal_Name").GetComponent<Text>().text = PetConfigCategory.Instance.Get(unit.ConfigId).PetName;
                    gameObject.transform.Find("Lal_Lv").GetComponent<Text>().text = "";
                    self.PetBattleList[unit.Id].Image = gameObject.transform.Find("Img_HpValue").GetComponent<Image>();
                    self.PetBattleList[unit.Id].Text = gameObject.transform.Find("Lal_Hurt").GetComponent<Text>();
                    continue;
                }

                if (unit.Type == UnitType.Monster)
                {
                    self.EnemyNumber++;
                    GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UIMonsterHpRectTransform.gameObject);
                    CommonViewHelper.SetParent(gameObject, self.View.EG_MonsterHpNodeRectTransform.gameObject);
                    gameObject.SetActive(true);

                    MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                    gameObject.transform.Find("Lal_Name").GetComponent<Text>().text = monsterCof.MonsterName;
                    gameObject.transform.Find("Lal_Lv").GetComponent<Text>().text = monsterCof.Lv.ToString();
                    self.PetBattleList[unit.Id].Image = gameObject.transform.Find("Img_HpValue").GetComponent<Image>();
                    self.PetBattleList[unit.Id].Text = gameObject.transform.Find("Lal_Hurt").GetComponent<Text>();
                    continue;
                }
            }
        }

        public static void OnTimer(this DlgPetMain self)
        {
            Camera camera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            float passTime = Time.time - self.BeginTime;
            float fieldOfView = 50f - (passTime / 10f) * 20;
            fieldOfView = Math.Max(fieldOfView, 30);
            camera.GetComponent<Camera>().fieldOfView = fieldOfView;
        }

        public static async ETTask OnPlayAnimation(this DlgPetMain self)
        {
            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            self.View.E_Image_3Image.gameObject.SetActive(true);
            self.BeginTime = Time.time;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.PetMainTimer, self);
            CommonViewHelper.DOScale(self.View.E_Image_3Image.transform, Vector3.zero, 1f);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.View.E_Image_3Image.gameObject.SetActive(false);
            self.View.E_Image_2Image.gameObject.SetActive(true);
            CommonViewHelper.DOScale(self.View.E_Image_2Image.transform, Vector3.zero, 1f);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.View.E_Image_2Image.gameObject.SetActive(false);
            self.View.E_Image_1Image.gameObject.SetActive(true);
            CommonViewHelper.DOScale(self.View.E_Image_1Image.transform, Vector3.zero, 1f);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.View.E_Image_1Image.gameObject.SetActive(false);
            self.View.E_DiImage.gameObject.SetActive(false);
            await PetNetHelper.PetFubenBeginRequest(self.Root());
            self.BeginCountdown().Coroutine();
        }

        public static async ETTask BeginCountdown(this DlgPetMain self)
        {
            long instanceId = self.InstanceId;
            int cdTime = GlobalValueConfigCategory.Instance.MaxPetLadderTime;

            if (self.EnemyNumber == 0)
            {
                cdTime = 10;
            }

            for (int i = cdTime; i >= 0; i--)
            {
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                if (self.M2C_FubenSettlement != null)
                {
                    return;
                }

                if (i == 0)
                {
                    self.View.E_CountdownTimeText.text = i.ToString();
                    PetNetHelper.PetFubenOverRequest(self.Root());
                }
                else
                {
                    self.View.E_CountdownTimeText.text = i.ToString();
                    await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
                }
            }
        }

        public static void BeginDrag(this DlgPetMain self, PointerEventData pdata)
        {
            self.m_scenePos = Input.mousePosition;
        }

        public static void Draging(this DlgPetMain self, PointerEventData pdata)
        {
            Vector3 move = new Vector3(pdata.delta.x * -0.01f, 0f, pdata.delta.y * -0.01f);
            Quaternion rotaion = Quaternion.Euler(0, -90, 0);
            Vector3 targ = self.CameraTarget.localPosition + rotaion * move;
            targ.x = Mathf.Clamp(targ.x, AIViewData.FuBenCameraPositionMin_X, AIViewData.FuBenCameraPositionMax_X);
            targ.z = Mathf.Clamp(targ.z, AIViewData.FuBenCameraPositionMin_Z, AIViewData.FuBenCameraPositionMax_Z);
            self.CameraTarget.localPosition = targ;
        }

        public static void EndDrag(this DlgPetMain self, PointerEventData pdata)
        {
        }

        public static void OnBtn_RerurnBuilding(this DlgPetMain self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "", LanguageComponent.Instance.LoadLocalization("确定返回主城？"),
                () => { EnterMapHelper.RequestQuitFuben(self.Root()); },
                null).Coroutine();
        }
    }
}
