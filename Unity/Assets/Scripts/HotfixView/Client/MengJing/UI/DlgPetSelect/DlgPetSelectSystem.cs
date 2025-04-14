using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetSelectItem))]
    [FriendOf(typeof (ES_PetList))]
    [FriendOf(typeof (PetComponentC))]
    [FriendOf(typeof (DlgPetSelect))]
    public static class DlgPetSelectSystem
    {
        public static void RegisterUIEvent(this DlgPetSelect self)
        {
            self.View.E_PetSelectItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetSelectItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
        }

        public static void ShowWindow(this DlgPetSelect self, Entity contextData = null)
        {
        }

        private static void OnPetSelectItemsRefresh(this DlgPetSelect self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetSelectItem item in self.ScrollItemPetSelectItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetSelectItem scrollItemPetSelectItem = self.ScrollItemPetSelectItems[index].BindTrans(transform);
            scrollItemPetSelectItem.OnInitData(self.ShowRolePetInfos[index]);
            scrollItemPetSelectItem.OperationType = self.OperationType;
        }

        public static void OnSetType(this DlgPetSelect self, PetOperationType bagOperationType)
        {
            self.OperationType = bagOperationType;
            self.OnInitData();
        }

        public static List<long> GetSelectedPet(this DlgPetSelect self)
        {
            List<long> selected = new List<long>();
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            List<long> petTeamList = new List<long>();

            if (self.OperationType == PetOperationType.HeCheng)
            {
                DlgPet dlgPet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>();
                selected = dlgPet.View.ES_PetHeCheng.GetSelectedPet();

                long petid = petComponent.GetFightPetId();
                if (petid != 0 && !selected.Contains(petid))
                {
                    selected.Add(petid);
                }

                selected.AddRange(petTeamList);
            }

            if (self.OperationType == PetOperationType.UpStar_FuZh)
            {
                // DlgPet dlgPet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>();
                // selected = uipet.GetComponent<UIPetComponent>().UIPageView.UISubViewList[(int)PetPageEnum.PetUpStar]
                //         .GetComponent<UIPetUpStarComponent>().GetSelectedPet();
                // selected.AddRange(petTeamList);
            }

            if (self.OperationType == PetOperationType.XianJi)
            {
                DlgPet dlgPet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>();
                long petinfoId = dlgPet.View.ES_PetList.LastSelectItem.Id;
                selected.Add(petinfoId);
            }

            if (self.OperationType == PetOperationType.JiaYuan_Walk)
            {
                JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
                for (int i = 0; i < jiaYuanComponent.JiaYuanPetList_2.Count; i++)
                {
                    selected.Add(jiaYuanComponent.JiaYuanPetList_2[i].unitId);
                }
            }

            for (int i = 0; i < petComponent.RolePetInfos.Count; i++)
            {
                if (petComponent.RolePetInfos[i].PetStatus == 3 && !selected.Contains(petComponent.RolePetInfos[i].Id))
                {
                    selected.Add((petComponent.RolePetInfos[i].Id));
                }
            }

            return selected;
        }

        public static void OnInitData(this DlgPetSelect self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            self.ShowRolePetInfos.Clear();
            List<RolePetInfo> list = petComponent.RolePetInfos;

            List<long> selected = self.GetSelectedPet();
            for (int i = 0; i < list.Count; i++)
            {
                if (selected.Contains(list[i].Id))
                {
                    continue;
                }

                if (list[i].PetStatus == 2 || list[i].PetStatus == 3)
                {
                    continue;
                }

                if (self.OperationType == PetOperationType.UpStar_FuZh)
                {
                    // UI uipet = UIHelper.GetUI(self.DomainScene(), UIType.UIPet);
                    // UIPetUpStarComponent uIPetUpStarComponent = uipet.GetComponent<UIPetComponent>().UIPageView
                    //         .UISubViewList[(int)PetPageEnum.PetUpStar].GetComponent<UIPetUpStarComponent>();
                    // RolePetInfo rolePetInfo = uIPetUpStarComponent.MainPetInfo;
                    // if (list[i].Star != rolePetInfo.Star)
                    // {
                    //     continue;
                    // }
                }

                self.ShowRolePetInfos.Add(list[i]);
                self.AddUIScrollItems(ref self.ScrollItemPetSelectItems, self.ShowRolePetInfos.Count);
                self.View.E_PetSelectItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
            }
        }

        public static void OnBtn_CloseButton(this DlgPetSelect self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetSelect);
        }
    }
}
