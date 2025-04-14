using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_PetInfoShow))]
    [FriendOf(typeof(Scroll_Item_PetListItem))]
    [FriendOf(typeof(DlgGivePet))]
    public static class DlgGivePetSystem
    {
        public static void RegisterUIEvent(this DlgGivePet self)
        {
            self.View.E_PetListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetListItemsRefresh);
            self.View.E_CloseBtnButton.AddListener(self.OnCloseBtnButton);
            self.View.E_GiveBtnButton.AddListener(self.OnGiveBtnButton);
            
            self.View.ES_PetInfoShow.uiTransform.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgGivePet self, Entity contextData = null)
        {
        }

        public static void InitTask(this DlgGivePet self, int taskId)
        {
            self.TaskId = taskId;

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            self.View.E_TaskDesTextText.text = taskConfig.TaskDes;
        }

        public static void OnCloseBtnButton(this DlgGivePet self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GivePet);
        }

        public static void OnUpdateUI(this DlgGivePet self)
        {
            self.PetSkinId = 0;
            self.LastSelectItem = null;

            self.OnInitPetList();
        }

        private static void OnPetListItemsRefresh(this DlgGivePet self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetListItem item in self.ScrollItemPetListItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index].BindTrans(transform);
            scrollItemPetListItem.SetClickHandler(self.OnClickPetHandler);
            scrollItemPetListItem.OnInitData(self.ShowRolePetInfos[index], self.NextPetNumber());
        }

        public static void OnInitPetList(this DlgGivePet self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();

            List<RolePetInfo> rolePetInfos = petComponent.RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                if (rolePetInfos[i].IsProtect)
                {
                    // 宠物已锁定！
                    continue;
                }

                if (rolePetInfos[i].PetStatus == 1)
                {
                    // 出战宠物不能提交！
                    continue;
                }

                if (rolePetInfos[i].PetStatus == 2)
                {
                    // 请先停止家园散步！
                    continue;
                }

                if (rolePetInfos[i].PetStatus == 3)
                {
                    // 请先从仓库取出！
                    continue;
                }

                if (petComponent.TeamPetList.Contains(rolePetInfos[i].Id))
                {
                    // 当前宠物存在于宠物天梯上阵中,不能提交！
                    continue;
                }

                if (petComponent.PetFormations.Contains(rolePetInfos[i].Id))
                {
                    // 当前宠物存在于宠物副本上阵中,不能提交！
                    continue;
                }

                if (petComponent.PetMingList.Contains(rolePetInfos[i].Id))
                {
                    // 当前宠物存在于宠物矿场队伍中,不能提交！
                    continue;
                }

                self.ShowRolePetInfos.Add(rolePetInfos[i]);
            }

            int nextLv = self.NextPetNumber();
            if (nextLv > 0)
            {
                self.ShowRolePetInfos.Add(null);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetListItems, self.ShowRolePetInfos.Count);
            self.View.E_PetListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);

            if (self.ScrollItemPetListItems != null && self.ScrollItemPetListItems.Count > 0)
            {
                self.View.ES_PetInfoShow.uiTransform.gameObject.SetActive(true);
                Scroll_Item_PetListItem item = self.ScrollItemPetListItems[0];
                item.OnClickPetItem();
            }
            else
            {
                self.View.ES_PetInfoShow.uiTransform.gameObject.SetActive(false);
            }
        }

        public static int NextPetNumber(this DlgGivePet self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int level = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            int curNumber = PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int petexpendNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber);
            if (curNumber < PetHelper.GetPetMaxNumber(userInfo.Lv, petexpendNumber))
            {
                return 0;
            }

            string[] petInfos = GlobalValueConfigCategory.Instance.Get(34).Value.Split('@');
            for (int i = 0; i < petInfos.Length; i++)
            {
                string[] petNumber = petInfos[i].Split(';');
                if (level < int.Parse(petNumber[0]))
                {
                    return int.Parse(petNumber[0]);
                }
            }

            return 0;
        }

        public static void OnClickPetHandler(this DlgGivePet self, long petId)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();

            if (petComponent.GetPetInfoByID(petId) == null)
            {
                return;
            }

            self.PetSkinId = 0;
            self.LastSelectItem = petComponent.GetPetInfoByID(petId);
            self.UpdatePetSelected(self.LastSelectItem);
            self.View.ES_PetInfoShow.OnInitData(self.LastSelectItem);
        }

        public static void UpdatePetSelected(this DlgGivePet self, RolePetInfo rolePetItem)
        {
            if (self.ScrollItemPetListItems != null)
            {
                foreach (Scroll_Item_PetListItem item in self.ScrollItemPetListItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnSelectUI(rolePetItem);
                }
            }
        }

        public static void OnGiveBtnButton(this DlgGivePet self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();

            if (self.LastSelectItem == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("未选择宠物！");
                return;
            }

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskId);

            if (!TaskHelper.IsTaskGivePet(taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue, self.LastSelectItem))
            {
                FlyTipComponent.Instance.ShowFlyTip("宠物不符合任务要求！");
                return;
            }

            if (TaskHelper.IsTaskGivePet(taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue, self.LastSelectItem))
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "提交宠物任务", LanguageComponent.Instance.LoadLocalization("确定提交宠物?"),
                    async () =>
                    {
                        TaskPro taskPro = self.Root().GetComponent<TaskComponentC>().GetTaskById(self.TaskId);
                        taskPro.taskStatus = (int)TaskStatuEnum.Completed; // 手动修改
                        int errorCode = await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskId, self.LastSelectItem.Id);
                        if (errorCode == ErrorCode.ERR_Success)
                        {
                            FlyTipComponent.Instance.ShowFlyTip("完成任务");
                            self.OnGiveAction?.Invoke();
                            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GivePet);
                        }
                    },
                    null).Coroutine();
            }
        }
    }
}
