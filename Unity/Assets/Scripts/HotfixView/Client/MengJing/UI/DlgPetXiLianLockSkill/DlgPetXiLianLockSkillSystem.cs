using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(DlgPetXiLianLockSkill))]
    public static class DlgPetXiLianLockSkillSystem
    {
        public static void RegisterUIEvent(this DlgPetXiLianLockSkill self)
        {
            self.View.E_LockBtnButton.AddListenerAsync(self.OnLockBtnButton);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
        }

        public static void ShowWindow(this DlgPetXiLianLockSkill self, Entity contextData = null)
        {
        }

        private static void OnCommonSkillItemsRefresh(this DlgPetXiLianLockSkill self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.ShowPetSkills[index], ABAtlasTypes.RoleSkillIcon, self.RolePetInfo.LockSkill.Contains(self.ShowPetSkills[index]));
            scrollItemCommonSkillItem.SelectAction = self.OnSelectSkill;
        }

        public static void UpdateSkillList(this DlgPetXiLianLockSkill self, RolePetInfo rolePetInfo, ItemInfo bagInfo)
        {
            self.RolePetInfo = rolePetInfo;
            self.CostItemInfo = bagInfo;

            // PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            List<int> zhuanzhuids = new List<int>();
            // string[] zhuanzhuskills = petConfig.ZhuanZhuSkillID.Split(';');
            // for (int i = 0; i < zhuanzhuskills.Length; i++)
            // {
            //     if (zhuanzhuskills[i].Length > 1)
            //     {
            //         zhuanzhuids.Add(int.Parse(zhuanzhuskills[i]));
            //     }
            // }

            self.ShowPetSkills.Clear();
            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                if (zhuanzhuids.Contains(rolePetInfo.PetSkill[i]))
                {
                    self.ShowPetSkills.Insert(0, rolePetInfo.PetSkill[i]);
                }
                else
                {
                    self.ShowPetSkills.Add(rolePetInfo.PetSkill[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.ShowPetSkills.Count);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkills.Count);
        }

        public static void OnSelectSkill(this DlgPetXiLianLockSkill self, int skillId)
        {
            self.SkillId = skillId;
            if (self.ScrollItemCommonSkillItems != null)
            {
                foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.E_BorderImgImage.gameObject?.SetActive(item.SkillId == self.SkillId);
                }
            }
        }

        public static async ETTask OnLockBtnButton(this DlgPetXiLianLockSkill self)
        {
            if (self.RolePetInfo.PetSkill.Count < 2)
            {
                FlyTipComponent.Instance.ShowFlyTip("宠物技能数量小于2不能使用次道具！");
                return;
            }

            if (self.SkillId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择需要锁定的技能！");
                return;
            }

            M2C_RolePetXiLian response =
                    await PetNetHelper.RequestXiLian(self.Root(), self.CostItemInfo.BagInfoID, self.RolePetInfo.Id, 1, self.SkillId.ToString());

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < petComponent.RolePetInfos.Count; i++)
            {
                if (petComponent.RolePetInfos[i].Id == response.rolePetInfo.Id)
                {
                    petComponent.RolePetInfos[i] = response.rolePetInfo;
                    break;
                }
            }

            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(response.rolePetInfo.Id);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>().View.ES_PetXiLian.OnXiLianSelect(rolePetInfo);

            self.OnBtn_CloseButton();
        }

        public static void OnBtn_CloseButton(this DlgPetXiLianLockSkill self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetXiLianLockSkill);
        }
    }
}
