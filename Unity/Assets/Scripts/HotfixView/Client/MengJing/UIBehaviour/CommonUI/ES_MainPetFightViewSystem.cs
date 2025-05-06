using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.MainPetFightSwitchCD)]
    public class MainPetFightSwitchCD : ATimer<ES_MainPetFight>
    {
        protected override void Run(ES_MainPetFight self)
        {
            try
            {
                //self.OpenUI().Coroutine();

                self.UpdateSwitchCD();
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
        }

        private static void PointerUp(this ES_MainPetFight self, PointerEventData pdata)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            long petId = petComponentC.GetNowPetFightList()[self.FightIndex - 1].PetId;
            if (petId == 0)
            {
                return;
            }

            int petfightindex = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetFightIndex);

            if (petfightindex != self.FightIndex)
            {
                int leftTime = (int)(0.001f * (self.LastTimer - TimeHelper.ServerNow()));
                if (leftTime > 0)
                {
                    string lefttimestr = "{0}秒后可以切换！";
                    using (zstring.Block())
                    {
                        lefttimestr = zstring.Format(lefttimestr, leftTime);
                    }

                    FlyTipComponent.Instance.ShowFlyTip(lefttimestr);
                    return;
                }

                self.LastTimer = TimeHelper.ServerNow() + ConfigData.PetSwichCD1 * TimeHelper.Second;
            }

            PetNetHelper.RequestPetFightSwitch(self.Root(), self.FightIndex).Coroutine();
        }

        public static void UpdateSwitchCD(this ES_MainPetFight self)
        {
            float leftTime = (0.001f * (self.LastTimer - TimeHelper.ServerNow()));

            if (leftTime <= 0f)
            {
                self.ResetSwitchCD();
                return;
            }

            self.E_PetHPImage.fillAmount = (ConfigData.PetSwichCD1 - leftTime) * ConfigData.PetSwichCD2;
        }

        private static void ResetSwitchCD(this ES_MainPetFight self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.E_PetHPImage.fillAmount = 1f;
        }

        public static void AddSwitchTimer(this ES_MainPetFight self)
        {
            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(200, TimerInvokeType.MainPetFightSwitchCD, self);
            }
        }

        /// <summary>
        /// 切换到宠物 当前显示的玩家的血量
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rolePetInfo"></param>
        /// <param name="fightIndex"></param>
        public static void Refresh(this ES_MainPetFight self, RolePetInfo rolePetInfo, int fightIndex)
        {
            self.FightIndex = fightIndex;

            if (rolePetInfo == null)
            {
                self.ResetSwitchCD();
                self.E_PetIconImage.gameObject.SetActive(false);
                self.E_PetLvText.gameObject.SetActive(false);
                self.E_PetHPImage.fillAmount = 0f;

                return;
            }
            
            int leftTime = (int)(0.001f * (self.LastTimer - TimeHelper.ServerNow()));
            if (leftTime > 0)
            {
                self.AddSwitchTimer();
            }
            else
            {
                self.ResetSwitchCD();
            }
            
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_PetIconImage.gameObject.SetActive(true);
            self.E_PetIconImage.sprite = sp;
            self.E_PetLvText.gameObject.SetActive(true);
            self.E_PetLvText.text = rolePetInfo.PetLv.ToString();
            
            Unit pet = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(rolePetInfo.Id);
            
            //切换到宠物 当前显示的玩家的血量
            if (pet == null)
            {
                // self.ResetSwitchCD();
                // self.E_PetHPImage.fillAmount = 0f;
                // return;
            }
        }
        
        public static async ETTask OpenUI(this ES_MainPetFight self)
        {
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
    }
}