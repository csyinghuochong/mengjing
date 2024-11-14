using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.MainPetShowQuickFightTimer)]
    public class MainPetShowQuickFightTimer : ATimer<ES_MainPetFight>
    {
        protected override void Run(ES_MainPetFight self)
        {
            try
            {
                self.OpenUI().Coroutine();
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

    [EntitySystemOf(typeof(ES_MainPetFight))]
    [FriendOfAttribute(typeof(ES_MainPetFight))]
    public static partial class ES_MainPetFightSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainPetFight self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ClickEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.E_ClickEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
        }

        [EntitySystem]
        private static void Destroy(this ES_MainPetFight self)
        {
            self.DestroyWidget();
        }

        private static void PointerDown(this ES_MainPetFight self, PointerEventData pdata)
        {
            self.LongPress = false;
            self.Timer = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(TimeInfo.Instance.ServerNow() + 600, TimerInvokeType.MainPetShowQuickFightTimer, self);
        }

        private static void PointerUp(this ES_MainPetFight self, PointerEventData pdata)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            if (self.LongPress == false)
            {
                PetNetHelper.RequestPetFightSwitch(self.Root(), self.FightIndex).Coroutine();
            }
        }

        public static async ETTask OpenUI(this ES_MainPetFight self)
        {
            self.LongPress = true;
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetQuickFight);
            DlgPetQuickFight dlgPetQuickFight = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetQuickFight>();
            dlgPetQuickFight.OnInitUI(self.FightIndex);

            //弹出宠物出战界面。
            //选择出战或者休息， 把新的fightpets传给服务器。
            //假如之前fightpets是{8， 3， 9}；
            //      点击第二个格子， 弹出的宠物列表，不显示8 和 9。。。。。
            //      点击第二个格子， 弹出的宠物列表，选择新宠物4， 新的fightpets就是{8， 4， 9}.  
            //      点击第二个格子， 弹出的宠物列表，对应的宠物3， 就显示休息按钮，点击休息fightpets就是{8， 0， 9}.  
            //await PetNetHelper.RequestRolePetFormationSet(self.Root(), SceneTypeEnum.MainCityScene, fightpets, null);
        }

        public static void Refresh(this ES_MainPetFight self, RolePetInfo rolePetInfo, int fightIndex)
        {
            self.FightIndex = fightIndex;

            if (rolePetInfo == null)
            {
                self.E_PetIconImage.gameObject.SetActive(false);
                self.E_PetHPImage.fillAmount = 0;
                self.E_PetLvText.gameObject.SetActive(false);
                return;
            }

            Unit pet = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(rolePetInfo.Id);
            if (pet == null)
            {
                self.E_PetHPImage.fillAmount = 0;
                return;
            }

            self.Pet = pet;

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_PetIconImage.gameObject.SetActive(true);
            self.E_PetIconImage.sprite = sp;
            self.E_PetLvText.gameObject.SetActive(true);
            self.E_PetLvText.text = rolePetInfo.PetLv.ToString();

            self.UpdateHp();
        }

        public static void UpdateHp(this ES_MainPetFight self)
        {
            if (self.Pet == null || self.Pet.IsDisposed || !self.uiTransform.gameObject.activeSelf)
            {
                return;
            }

            NumericComponentC numericComponent = self.Pet.GetComponent<NumericComponentC>();
            float curhp = numericComponent.GetAsLong(NumericType.Now_Hp);
            float blood = curhp / numericComponent.GetAsLong(NumericType.Now_MaxHp);
            self.E_PetHPImage.fillAmount = blood;
        }
    }
}