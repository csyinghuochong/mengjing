using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPet))]
    [FriendOf(typeof (PetComponentC))]
    [FriendOf(typeof (ES_PetInfoShow))]
    [EntitySystemOf(typeof (ES_PetHeCheng))]
    [FriendOfAttribute(typeof (ES_PetHeCheng))]
    public static partial class ES_PetHeChengSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetHeCheng self, Transform transform)
        {
            self.uiTransform = transform;

            // self.E_Btn_HeChengExplainButton.AddListener(() => { self.Root().GetComponent<UIComponent>().ShowWindowAsync().Coroutine(); });
            
            
            self.OnInitSubView();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetHeCheng self)
        {
            self.DestroyWidget();
        }

        private static void OnInitSubView(this ES_PetHeCheng self)
        {
            self.ES_PetInfoShow_1.Weizhi = -1;
            self.ES_PetInfoShow_1.BagOperationType = PetOperationType.HeCheng;

            self.ES_PetInfoShow_2.Weizhi = 1;
            self.ES_PetInfoShow_2.BagOperationType = PetOperationType.HeCheng;

            self.ES_PetInfoShow_1.OnInitData(null);
            self.ES_PetInfoShow_2.OnInitData(null);
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
            self.ES_PetInfoShow_1.OnInitData(null);
            self.ES_PetInfoShow_2.OnInitData(null);
        }

        public static void OnClickHeCheng(this ES_PetHeCheng self)
        {
            if (self.Root().GetComponent<PetComponentC>().RolePetInfos.Count < 3)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("最少有3个宠物才可以开启合成！");
                return;
            }

            if (self.HeChengPet_Left == null || self.HeChengPet_Right == null)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请选择要合成的宠物！");
                return;
            }

            if (PetHelper.IsShenShou(self.HeChengPet_Left.ConfigId)
                || PetHelper.IsShenShou(self.HeChengPet_Right.ConfigId))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("神兽不能合成！");
                return;
            }

            if (PetHelper.HavePetHeXin(self.HeChengPet_Left) || PetHelper.HavePetHeXin(self.HeChengPet_Right))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请先卸下宠物之核！");
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

            string addStr = havepetHexin? "当前放入的宠物身上穿戴了宠物之核，融合后会消失," : "";

            PopupTipHelp.OpenPopupTip(self.Root(), "宠物合成",
                $"合成后将随机保留一个宠物，另外一个宠物会销毁,<color=#ff0000>{addStr}</color> 请确认是否执行合成",
                () => { self.ReqestHeCheng().Coroutine(); }).Coroutine();
        }

        public static async ETTask OnBtn_Preview(this ES_PetHeCheng self)
        {
            // if (self.HeChengPet_Left == null || self.HeChengPet_Right == null)
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("请选择要合成的宠物！");
            //     return;
            // }
            //
            // if (PetHelper.IsShenShou(self.HeChengPet_Left.ConfigId)
            //     || PetHelper.IsShenShou(self.HeChengPet_Right.ConfigId))
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("神兽不能合成！");
            //     return;
            // }
            //
            // UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIPetHeChengPreview);
            // ui.GetComponent<UIPetHeChengPreviewComponent>().UpdateInfo(self.HeChengPet_Left, self.HeChengPet_Right);

            await ETTask.CompletedTask;
        }

        public static async ETTask ReqestHeCheng(this ES_PetHeCheng self)
        {
            // PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            // List<KeyValuePair> oldPetSkin = petComponent.GetPetSkinCopy();
            // C2M_RolePetHeCheng c2M_RolePetHeCheng =
            //         new C2M_RolePetHeCheng() { PetInfoId1 = self.HeChengPet_Left.Id, PetInfoId2 = self.HeChengPet_Right.Id };
            // M2C_RolePetHeCheng m2C_RolePetHeCheng =
            //         (M2C_RolePetHeCheng)await self.Root().GetComponent<SessionComponent>().Session.Call(c2M_RolePetHeCheng);
            // if (m2C_RolePetHeCheng.Error != 0 || m2C_RolePetHeCheng.rolePetInfo == null)
            // {
            //     return;
            // }
            //
            // self.HeChengPet_Left = null;
            // self.HeChengPet_Right = null;
            //
            // long instanceId = self.InstanceId;
            // UI uI = await UIHelper.Create(self.DomainScene(), UIType.UIPetChouKaGet);
            // if (instanceId != self.InstanceId)
            // {
            //     return;
            // }
            //
            // uI.GetComponent<UIPetChouKaGetComponent>().OnInitUI(m2C_RolePetHeCheng.rolePetInfo, oldPetSkin);
            // self.ZoneScene().GetComponent<PetComponent>().OnRecvHeCheng(m2C_RolePetHeCheng);

            await ETTask.CompletedTask;
        }

        public static void OnHeChengReturn(this ES_PetHeCheng self)
        {
            self.ES_PetInfoShow_1.OnInitData(null);
            self.ES_PetInfoShow_2.OnInitData(null);
        }

        public static void OnHeChengSelect(this ES_PetHeCheng self, RolePetInfo rolePetInfo)
        {
            if (self.GetParent<DlgPet>().PetItemWeizhi == -1)
            {
                self.HeChengPet_Left = rolePetInfo;
                self.ES_PetInfoShow_1.OnInitData(self.HeChengPet_Left);
            }
            else
            {
                self.HeChengPet_Right = rolePetInfo;
                self.ES_PetInfoShow_2.OnInitData(self.HeChengPet_Right);
            }
        }
    }
}