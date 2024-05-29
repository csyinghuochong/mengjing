using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.PetEggListItemTimer)]
    public class PetEggListItemTimer: ATimer<ES_PetEggListItem>
    {
        protected override void Run(ES_PetEggListItem self)
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

    [EntitySystemOf(typeof (ES_PetEggListItem))]
    [FriendOfAttribute(typeof (ES_PetEggListItem))]
    public static partial class ES_PetEggListItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetEggListItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_PetEggListItem self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void BeginDrag(this ES_PetEggListItem self, PointerEventData pdata)
        {
            self.BeginDragHandler?.Invoke(self.Index, pdata);
        }

        public static void Draging(this ES_PetEggListItem self, PointerEventData pdata)
        {
            self.DragingHandler?.Invoke(self.Index, pdata);
        }

        public static void EndDrag(this ES_PetEggListItem self, PointerEventData pdata)
        {
            self.EndDragHandler?.Invoke(self.Index, pdata);
        }

        public static void OnButtonOpen(this ES_PetEggListItem self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int maxNum = PetHelper.GetPetMaxNumber(self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv, userInfo.Lv);
            if (maxNum <= PetHelper.GetCangKuPetNum(petComponent.RolePetInfos))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("已达到最大宠物数量");
                return;
            }

            int costValue = ComHelp.ReturnPetOpenTimeDiamond(self.RolePetEgg.KeyId, self.RolePetEgg.Value);
            PopupTipHelp.OpenPopupTip(self.Root(), "开启宠物蛋", $"开启需要花费 {costValue}钻石", () => { self.OnButtonGet().Coroutine(); }).Coroutine();
        }

        public static async ETTask OnButtonFuHua(this ES_PetEggListItem self)
        {
            int error = await PetNetHelper.RequestPetEggHatch(self.Root(), self.Index);

            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            DlgPetEgg dlgPetEgg = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetEgg>();
            dlgPetEgg.OnRolePetEggOpen();
        }

        public static async ETTask OnButtonGet(this ES_PetEggListItem self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int maxNum = PetHelper.GetPetMaxNumber(self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv, userInfo.Lv);
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            if (maxNum <= PetHelper.GetBagPetNum(petComponent.RolePetInfos))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("已达到最大宠物数量");
                return;
            }

            KeyValuePairInt rolePetEgg = petComponent.RolePetEggs[self.Index];
            if (rolePetEgg.KeyId == 0)
            {
                return;
            }

            int needCost = 0;
            if (TimeHelper.ServerNow() < rolePetEgg.Value)
            {
                needCost = ComHelp.ReturnPetOpenTimeDiamond(self.RolePetEgg.KeyId, self.RolePetEgg.Value);
            }

            if (userInfo.Diamond < needCost)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("钻石不足！");
                return;
            }

            int error = await PetNetHelper.RequestPetEggOpen(self.Root(), self.Index);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            DlgPetEgg dlgPetEgg = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetEgg>();
            dlgPetEgg.OnRolePetEggOpen();
        }

        public static void OnTimer(this ES_PetEggListItem self)
        {
            long timeNow = self.RolePetEgg.Value - TimeHelper.ServerNow();
            self.E_Text_TimeText.text = "剩余时间:" + TimeHelper.ShowLeftTime(timeNow);
            if (timeNow <= 0)
            {
                self.SetFuHuaEnd();
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        public static void SetEggNoFuhua(this ES_PetEggListItem self)
        {
            self.E_ButtonFuHuaButton.gameObject.SetActive(true);

            string[] useparams = ItemConfigCategory.Instance.Get(self.RolePetEgg.KeyId).ItemUsePar.Split('@');
            long timeNow = long.Parse(useparams[0]);
            self.E_Text_TimeText.text = "孵化时间:" + TimeHelper.ShowLeftTime(timeNow * 1000);
            self.E_ButtonOpenButton.gameObject.SetActive(false);
            self.E_ButtonGetButton.gameObject.SetActive(false);
        }

        public static void SetFuhua(this ES_PetEggListItem self)
        {
            self.E_ButtonFuHuaButton.gameObject.SetActive(false);
            self.E_Text_TimeText.gameObject.SetActive(true);
            self.E_ButtonOpenButton.gameObject.SetActive(true);
            self.E_ButtonGetButton.gameObject.SetActive(false);
        }

        public static void SetFuHuaEnd(this ES_PetEggListItem self)
        {
            self.E_ButtonFuHuaButton.gameObject.SetActive(false);
            self.E_Text_TimeText.gameObject.SetActive(false);
            self.E_ButtonOpenButton.gameObject.SetActive(false);
            self.E_ButtonGetButton.gameObject.SetActive(true);
        }

        public static void OnUpdateUI(this ES_PetEggListItem self, KeyValuePairInt rolePetEgg, int index)
        {
            self.Index = index;
            self.RolePetEgg = rolePetEgg;
            self.EG_Node1RectTransform.gameObject.SetActive(rolePetEgg != null && rolePetEgg.KeyId > 0);
            self.EG_Node0RectTransform.gameObject.SetActive(!self.EG_Node1RectTransform.gameObject.activeSelf);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            if (self.EG_Node0RectTransform.gameObject.activeSelf)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(rolePetEgg.KeyId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_PetEggIconImage.sprite = sp;
            if (rolePetEgg.Value == 0)
            {
                self.SetEggNoFuhua();
                return;
            }

            long timeNow = rolePetEgg.Value - TimeHelper.ServerNow();
            if (timeNow < 0)
            {
                self.SetFuHuaEnd();
                return;
            }

            self.SetFuhua();
            self.OnTimer();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.PetEggListItemTimer, self);
        }
    }
}