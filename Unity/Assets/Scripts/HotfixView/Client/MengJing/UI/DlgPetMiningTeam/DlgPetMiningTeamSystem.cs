using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetFormationItem))]
    [FriendOf(typeof(DlgPetMiningTeamViewComponent))]
    [FriendOf(typeof(Scroll_Item_PetMiningTeamItem))]
    [FriendOf(typeof(DlgPetMiningTeam))]
    public static class DlgPetMiningTeamSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningTeam self)
        {
            self.View.E_PetFormationItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetFormationItemsRefresh);
            self.View.E_ButtonCloseButton.AddListenerAsync(self.OnButtonCloseButton);
            
            for (int i = 0; i < 3; i++)
            {
                GameObject gameObject = self.View.EG_TeamListNodeRectTransform.GetChild(i).gameObject;
                Scroll_Item_PetMiningTeamItem TeamItem = self.AddChild<Scroll_Item_PetMiningTeamItem>();
                TeamItem.uiTransform = gameObject.transform;
                TeamItem.OnInitUI(i);
                TeamItem.IconItemDrag = self.View.E_IconItemDragImage.gameObject;
                self.MiningTeamList.Add(TeamItem);
            }

            self.View.E_IconItemDragImage.gameObject.SetActive(false);

            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            self.PetTeamList.Clear();
            self.PetTeamList.AddRange(petComponent.PetMingList);

            self.PetMingPosition.Clear();
            self.PetMingPosition.AddRange(petComponent.PetMingPosition);

            self.OnUpdatePetList();
            self.UpdateTeamList();
        }

        public static void ShowWindow(this DlgPetMiningTeam self, Entity contextData = null)
        {
        }

        private static void OnPetFormationItemsRefresh(this DlgPetMiningTeam self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetFormationItem item in self.ScrollItemPetFormationItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetFormationItem scrollItemPetFormationItem = self.ScrollItemPetFormationItems[index].BindTrans(transform);
            scrollItemPetFormationItem.BeginDragHandler = (RolePetInfo binfo, PointerEventData pdata) => { self.BeginDrag(binfo, pdata); };
            scrollItemPetFormationItem.DragingHandler = (RolePetInfo binfo, PointerEventData pdata) => { self.Draging(binfo, pdata); };
            scrollItemPetFormationItem.EndDragHandler = (RolePetInfo binfo, PointerEventData pdata) => { self.EndDrag(binfo, pdata); };
            scrollItemPetFormationItem.OnInitUI(self.ShowRolePetInfos[index], self.PetTeamList.Contains(self.ShowRolePetInfos[index].Id));
        }

        public static void BeginDrag(this DlgPetMiningTeam self, RolePetInfo binfo, PointerEventData pdata)
        {
            self.View.E_IconItemDragImage.gameObject.SetActive(true);
            PetConfig petConfig = PetConfigCategory.Instance.Get(binfo.ConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            GameObject icon = self.View.E_IconItemDragImage.transform.Find("ImageIcon").gameObject;
            icon.GetComponent<Image>().sprite = sp;
            CommonViewHelper.SetParent(self.View.E_IconItemDragImage.gameObject, self.View.uiTransform.gameObject);
        }

        public static void Draging(this DlgPetMiningTeam self, RolePetInfo binfo, PointerEventData pdata)
        {
            Vector2 localPoint;
            RectTransform canvas = self.View.E_IconItemDragImage.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.View.E_IconItemDragImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static void EndDrag(this DlgPetMiningTeam self, RolePetInfo binfo, PointerEventData pdata)
        {
            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            RectTransform canvas = self.View.E_IconItemDragImage.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("PetIcon_di_"))
                {
                    continue;
                }

                Transform parent = results[i].gameObject.transform.parent;
                int team = int.Parse(parent.name);
                int openLv = ConfigData.PetMiningTeamOpenLevel[team];
                if (playerLv < openLv)
                {
                    break;
                }

                int index = int.Parse(name.Substring(name.Length - 1, 1));
                Log.Debug($"index:   {index} {parent.name} ");
                self.OnDragFormationSet(binfo.Id, team * 5 + index, 1, team);
                break;
            }

            CommonViewHelper.SetParent(self.View.E_IconItemDragImage.gameObject, self.View.uiTransform.gameObject);
            self.View.E_IconItemDragImage.gameObject.SetActive(false);
        }

        /// <summary>
        /// 1 上阵  3 下阵
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rolePetInfoId"></param>
        /// <param name="index"></param>
        /// <param name="operateType"></param>
        public static void OnDragFormationSet(this DlgPetMiningTeam self, long rolePetInfoId, int index, int operateType, int team)
        {
            DlgPetSet dlgPetSet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetSet>();

            List<int> defendteamids = dlgPetSet.View.ES_PetMining.GetSelfPetMingTeam();

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (defendteamids.Contains(team) && unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.PetMineCDTime) > TimeHelper.ServerNow())
            {
                FlyTipComponent.Instance.ShowFlyTip("挑战冷却中，无法更换。");
                return;
            }

            //上阵
            if (operateType == 1)
            {
                for (int i = 0; i < self.PetTeamList.Count; i++)
                {
                    if (self.PetTeamList[i] == rolePetInfoId && i != index)
                    {
                        self.PetTeamList[i] = 0;
                    }
                }

                self.PetTeamList[index] = rolePetInfoId;
            }

            //下阵
            if (operateType == 3)
            {
                for (int i = 0; i < self.PetTeamList.Count; i++)
                {
                    if (self.PetTeamList[i] == rolePetInfoId)
                    {
                        self.PetTeamList[i] = 0;
                    }
                }
            }

            self.OnUpdatePetList();
            self.UpdateTeamList();

            PetHelper.CheckPetPosition(self.PetTeamList, self.PetMingPosition);
        }

        public static async ETTask OnButtonCloseButton(this DlgPetMiningTeam self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            long instanceid = self.InstanceId;
            int errorCode = await PetNetHelper.RequestRolePetFormationSet(self.Root(), MapTypeEnum.PetMing, self.PetTeamList, self.PetMingPosition);
            if (errorCode != ErrorCode.ERR_Success || instanceid != self.InstanceId)
            {
                return;
            }

            self.UpdateTeam?.Invoke();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMiningTeam);
        }

        public static void UpdateTeamList(this DlgPetMiningTeam self)
        {
            Scroll_Item_PetMiningTeamItem item0 = self.MiningTeamList[0];
            Scroll_Item_PetMiningTeamItem item1 = self.MiningTeamList[1];
            Scroll_Item_PetMiningTeamItem item2 = self.MiningTeamList[2];
            item0.UpdatePetTeam(self.PetTeamList);
            item1.UpdatePetTeam(self.PetTeamList);
            item2.UpdatePetTeam(self.PetTeamList);
        }

        public static void OnUpdatePetList(this DlgPetMiningTeam self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            self.ShowRolePetInfos = petComponent.RolePetInfos;

            self.AddUIScrollItems(ref self.ScrollItemPetFormationItems, self.ShowRolePetInfos.Count);
            self.View.E_PetFormationItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }
    }
}
