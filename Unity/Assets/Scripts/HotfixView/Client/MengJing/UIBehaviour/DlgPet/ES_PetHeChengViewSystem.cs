using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPet))]
    [FriendOf(typeof(PetComponentC))]
    [FriendOf(typeof(ES_PetHeChengInfoShow))]
    [EntitySystemOf(typeof(ES_PetHeCheng))]
    [FriendOfAttribute(typeof(ES_PetHeCheng))]
    public static partial class ES_PetHeChengSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetHeCheng self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_HeChengExplainButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeChengExplain).Coroutine();
            });
            self.E_Btn_HeChengButton.AddListener(self.OnBtn_HeChengButton);
            self.E_Btn_PreviewButton.AddListenerAsync(self.OnBtn_PreviewButton);

            self.OnInitSubView();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetHeCheng self)
        {
            self.DestroyWidget();
        }

        private static void OnInitSubView(this ES_PetHeCheng self)
        {
            self.ES_PetHeChengInfoShow_1.Weizhi = -1;
            self.ES_PetHeChengInfoShow_1.BagOperationType = PetOperationType.HeCheng;

            self.ES_PetHeChengInfoShow_2.Weizhi = 1;
            self.ES_PetHeChengInfoShow_2.BagOperationType = PetOperationType.HeCheng;

            self.ES_PetHeChengInfoShow_1.OnInitData(null);
            self.ES_PetHeChengInfoShow_2.OnInitData(null);
        }

        public static List<long> GetSelectedPet(this ES_PetHeCheng self)
        {
            List<long> selected = new List<long>();
            if (self.HeChengPet_Left != null)
                selected.Add(self.HeChengPet_Left.Id);
            if (self.HeChengPet_Right != null)
                selected.Add(self.HeChengPet_Right.Id);

            return selected;
        }

        public static void OnUpdateUI(this ES_PetHeCheng self)
        {
            self.HeChengPet_Left = null;
            self.HeChengPet_Right = null;
            self.ES_PetHeChengInfoShow_1.OnInitData(null);
            self.ES_PetHeChengInfoShow_2.OnInitData(null);
        }

        public static void OnBtn_HeChengButton(this ES_PetHeCheng self)
        {
            if (self.Root().GetComponent<PetComponentC>().RolePetInfos.Count < 3)
            {
                FlyTipComponent.Instance.ShowFlyTip("最少有3个宠物才可以开启合成！");
                return;
            }

            if (self.HeChengPet_Left == null || self.HeChengPet_Right == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择要合成的宠物！");
                return;
            }

            if (PetHelper.IsShenShou(self.HeChengPet_Left.ConfigId)
                || PetHelper.IsShenShou(self.HeChengPet_Right.ConfigId))
            {
                FlyTipComponent.Instance.ShowFlyTip("神兽不能合成！");
                return;
            }

            if (PetHelper.HavePetHeXin(self.HeChengPet_Left) || PetHelper.HavePetHeXin(self.HeChengPet_Right))
            {
                FlyTipComponent.Instance.ShowFlyTip("请先卸下宠物之核！");
                return;
            }

            bool havepetHexin = false;
            for (int i = 0; i < self.HeChengPet_Left.PetHeXinList.Count; i++)
            {
                if (self.HeChengPet_Left.PetHeXinList[i] != 0)
                {
                    havepetHexin = true;
                    break;
                }
            }

            for (int i = 0; i < self.HeChengPet_Right.PetHeXinList.Count; i++)
            {
                if (self.HeChengPet_Right.PetHeXinList[i] != 0)
                {
                    havepetHexin = true;
                    break;
                }
            }

            string addStr = havepetHexin ? "当前放入的宠物身上穿戴了宠物之核，融合后会消失，" : " ";

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "宠物合成",
                    zstring.Format("合成后将随机保留一个宠物，另外一个宠物会销毁，<color=#ff0000>{0}</color> 请确认是否执行合成。", addStr),
                    () => { self.ReqestHeCheng().Coroutine(); }).Coroutine();
            }
        }

        private static async ETTask OnBtn_PreviewButton(this ES_PetHeCheng self)
        {
            if (self.HeChengPet_Left == null || self.HeChengPet_Right == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择要合成的宠物！");
                return;
            }

            if (PetHelper.IsShenShou(self.HeChengPet_Left.ConfigId)
                || PetHelper.IsShenShou(self.HeChengPet_Right.ConfigId))
            {
                FlyTipComponent.Instance.ShowFlyTip("神兽不能合成！");
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeChengPreview);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetHeChengPreview>().UpdateInfo(self.HeChengPet_Left, self.HeChengPet_Right);
        }

        private static async ETTask ReqestHeCheng(this ES_PetHeCheng self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            List<KeyValuePair> oldPetSkin = petComponent.GetPetSkinCopy();
            M2C_RolePetHeCheng response = await PetNetHelper.RequestRolePetHeCheng(self.Root(), self.HeChengPet_Left.Id, self.HeChengPet_Right.Id);
            if (response.Error != 0 || response.rolePetInfo == null)
            {
                return;
            }

            self.HeChengPet_Left = null;
            self.HeChengPet_Right = null;

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetChouKaGet);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetChouKaGet>().OnInitUI(response.rolePetInfo, oldPetSkin);
        }

        public static void OnHeChengReturn(this ES_PetHeCheng self)
        {
            self.ES_PetHeChengInfoShow_1.OnInitData(null);
            self.ES_PetHeChengInfoShow_2.OnInitData(null);
        }

        public static void OnHeChengSelect(this ES_PetHeCheng self, RolePetInfo rolePetInfo)
        {
            if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>().PetItemWeizhi == -1)
            {
                self.HeChengPet_Left = rolePetInfo;
                self.ES_PetHeChengInfoShow_1.OnInitData(self.HeChengPet_Left);
            }
            else
            {
                self.HeChengPet_Right = rolePetInfo;
                self.ES_PetHeChengInfoShow_2.OnInitData(self.HeChengPet_Right);
            }
        }
    }
}
