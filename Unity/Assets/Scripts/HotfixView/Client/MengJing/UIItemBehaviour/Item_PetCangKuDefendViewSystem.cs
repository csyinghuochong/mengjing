using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_ModelShow))]
    [FriendOf(typeof(Scroll_Item_PetCangKuDefend))]
    [EntitySystemOf(typeof(Scroll_Item_PetCangKuDefend))]
    public static partial class Scroll_Item_PetCangKuDefendSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetCangKuDefend self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetCangKuDefend self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonOpen(this Scroll_Item_PetCangKuDefend self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            if (petComponent.PetCangKuOpen.Contains(self.Index - 1))
            {
                FlyTipComponent.Instance.ShowFlyTip("已开启！");
                return;
            }

            int jiayuanlv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.JiaYuanLv;
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(jiayuanlv);
            int petNum = jiaYuanConfig.PetNum;
            if (petNum <= petComponent.PetCangKuOpen.Count)
            {
                FlyTipComponent.Instance.ShowFlyTip("家园等级不足！");
                return;
            }

            string costitem = ConfigData.PetOpenCangKu[self.Index - 1];

            string costdesc = CommonViewHelper.GetNeedItemDesc(costitem);
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "宠物仓库", zstring.Format("是否花费{0}开启宠物仓库?", costdesc),
                    () => { self.RequestOpenCangKu().Coroutine(); }, null).Coroutine();
            }
        }

        public static async ETTask RequestOpenCangKu(this Scroll_Item_PetCangKuDefend self)
        {
            string costitem = ConfigData.PetOpenCangKu[self.Index - 1];
            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(costitem))
            {
                FlyTipComponent.Instance.ShowFlyTip("家园资金不足！");
                return;
            }

            int error = await JiaYuanNetHelper.PetOpenCangKu(self.Root(), self.Index);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (self.IsDisposed)
            {
                return;
            }

            self.Root().GetComponent<PetComponentC>().PetCangKuOpen.Add(self.Index - 1);
            self.E_Text_NameText.text = string.Empty;
            self.E_ButtonQuHuiButton.gameObject.SetActive(false);
            self.E_ButtonOpenButton.gameObject.SetActive(false);
            self.PetCangKuAction?.Invoke();
        }

        public static async ETTask OnButtonQuHui(this Scroll_Item_PetCangKuDefend self)
        {
            if (self.RolePetInfo == null)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int petexpendNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber);
            int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, petexpendNumber);
            if (PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos) >= maxNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("宠物格子不足！");
                return;
            }

            int error = await JiaYuanNetHelper.PetPutCangKu(self.Root(), self.RolePetInfo.Id, 0);
            if (error != 0)
            {
                return;
            }

            self.Root().GetComponent<PetComponentC>().GetPetInfoByID(self.RolePetInfo.Id).PetStatus = 0;
            self.PetCangKuAction?.Invoke();
        }

        public static void SetAction(this Scroll_Item_PetCangKuDefend self, Action action)
        {
            self.PetCangKuAction = action;
        }

        public static void OnUpdateUI(this Scroll_Item_PetCangKuDefend self, int jiayuan, int index, int openindex)
        {
            self.ES_ModelShow.uiTransform.gameObject.SetActive(false);
            self.E_ButtonQuHuiButton.AddListenerAsync(self.OnButtonQuHui);
            self.E_ButtonOpenButton.AddListener(self.OnButtonOpen);

            self.Index = index;
            self.RolePetInfo = null;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(jiayuan);
            int petNum = jiaYuanConfig.PetNum;

            if (petNum < index || !petComponent.PetCangKuOpen.Contains(index - 1))
            {
                int openlv = PetHelper.GetCangKuOpenLv(index);
                using (zstring.Block())
                {
                    self.E_Text_NameText.text = zstring.Format("{0}级开启", JiaYuanConfigCategory.Instance.Get(openlv).Lv);
                }

                self.E_ButtonOpenButton.gameObject.SetActive(true);
                self.E_ButtonQuHuiButton.gameObject.SetActive(false);
                return;
            }

            int cangkuindex = 0;
            RolePetInfo rolePetInfo = null;
            for (int i = 0; i < petComponent.RolePetInfos.Count; i++)
            {
                if (petComponent.RolePetInfos[i].PetStatus == 3)
                {
                    cangkuindex++;
                }

                if (cangkuindex == openindex)
                {
                    rolePetInfo = petComponent.RolePetInfos[i];
                    break;
                }
            }

            if (rolePetInfo != null)
            {
                self.ES_ModelShow.uiTransform.gameObject.SetActive(true);
                self.E_Text_NameText.text = rolePetInfo.PetName;

                PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                self.ES_ModelShow.ShowOtherModel("Pet/" + petConfig.PetModel).Coroutine();
                self.ES_ModelShow.SetCameraPosition(new(0f, 100f, 450f));
                self.ES_ModelShow.Camera.fieldOfView = 30;
                // self.ES_ModelShow.SetRootPosition(new Vector2(index * 1000 + 1000, 0));
                self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));
            }
            else
            {
                self.ES_ModelShow.uiTransform.gameObject.SetActive(false);
            }

            self.E_Text_NameText.text = rolePetInfo != null ? rolePetInfo.PetName : string.Empty;
            self.E_ButtonQuHuiButton.gameObject.SetActive(rolePetInfo != null);
            self.E_ButtonOpenButton.gameObject.SetActive(!petComponent.PetCangKuOpen.Contains(index - 1));

            self.RolePetInfo = rolePetInfo;
        }
    }
}