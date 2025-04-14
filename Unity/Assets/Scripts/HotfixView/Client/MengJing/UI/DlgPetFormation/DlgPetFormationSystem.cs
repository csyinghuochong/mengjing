using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetFormationViewComponent))]
    [FriendOf(typeof(ES_PetFormationSet))]
    [FriendOf(typeof(Scroll_Item_PetFormationItem))]
    [FriendOf(typeof(DlgPetFormation))]
    public static class DlgPetFormationSystem
    {
        public static void RegisterUIEvent(this DlgPetFormation self)
        {
            self.View.E_PetFormationItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetFormationItemRefresh);
            self.View.E_ButtonConfirmButton.AddListenerAsync(self.OnButtonConfirmButton);
            self.View.E_ButtonChallengeButton.AddListener(self.OnButtonChallengeButton);
            self.View.E_CloseButtonButton.AddListener(() =>
            {
                self.SetHandler?.Invoke();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetFormation);
            });
        }

        public static void ShowWindow(this DlgPetFormation self, Entity contextData = null)
        {
            self.View.E_IconItemDragImage.gameObject.SetActive(false);
        }

        public static void OnUpdateNumber(this DlgPetFormation self, int sceneType)
        {
            int number = 0;
            List<long> pets = self.PetTeamList;
            for (int i = 0; i < pets.Count; i++)
            {
                number += (pets[i] != 0 ? 1 : 0);
            }

            using (zstring.Block())
            {
                self.View.E_TextNumberText.text = zstring.Format("阵容限制：{0}/{1}", number, self.PetNumberLimit);
            }
        }

        public static void UpdateFighting(this DlgPetFormation self, int sceneType)
        {
            List<long> pets = self.PetTeamList;

            if (self.ScrollItemPetFormationItems != null)
            {
                foreach (Scroll_Item_PetFormationItem item in self.ScrollItemPetFormationItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    long petId = item.RolePetInfo.Id;
                    item.SetFighting(pets.Contains(petId));
                }
            }
        }

        public static async ETTask OnButtonConfirmButton(this DlgPetFormation self)
        {
            long instanceid = self.InstanceId;
            int errorCode = await PetNetHelper.RequestRolePetFormationSet(self.Root(), self.SceneTypeEnum, self.PetTeamList, null);
            if (errorCode != ErrorCode.ERR_Success || instanceid != self.InstanceId)
            {
                return;
            }

            self.OnUpdateNumber(self.SceneTypeEnum);
            self.UpdateFighting(self.SceneTypeEnum);
        }

        public static void OnButtonChallengeButton(this DlgPetFormation self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetFormation);
            if (self.SceneTypeEnum == MapTypeEnum.PetDungeon)
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetSet).Coroutine();
                return;
            }

            if (self.SceneTypeEnum == MapTypeEnum.PetTianTi)
            {
                return;
            }
        }

        public static void RequestFormationSet(this DlgPetFormation self, long rolePetInfoId, int index, int operateType)
        {
            self.OnDragFormationSet(rolePetInfoId, index, operateType);
        }

        public static void OnInitUI(this DlgPetFormation self, int sceneType, Action action)
        {
            self.SetHandler = action;
            self.SceneTypeEnum = sceneType;
            self.PetNumberLimit = sceneType == MapTypeEnum.PetMatch ? ConfigData.PetMatchPetLimit : ConfigData.PetDungeonPetLimit;
            self.PetTeamList.AddRange(self.Root().GetComponent<PetComponentC>().GetPetFormatList(sceneType));
            self.View.ES_PetFormationSet.DragEndHandler = self.RequestFormationSet;
            self.View.ES_PetFormationSet.OnUpdateFormation(self.SceneTypeEnum, self.PetTeamList, true);

            self.OnUpdateNumber(sceneType);
            self.UpdateFighting(sceneType);
            self.OnInitPetList(sceneType);
        }

        /// <summary>
        /// 1 上阵 2 交换位置 3 下阵
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rolePetInfoId"></param>
        /// <param name="index"></param>
        /// <param name="operateType"></param>
        public static void OnDragFormationSet(this DlgPetFormation self, long rolePetInfoId, int index, int operateType)
        {
            //如果是上阵并且之前在队伍中
            int number = 0;
            for (int i = 0; i < self.PetTeamList.Count; i++)
            {
                number += (self.PetTeamList[i] != 0 ? 1 : 0);
            }

            if (index != -1 && number >= self.PetNumberLimit && self.PetTeamList[index] == 0 && operateType != 2)
            {
                FlyTipComponent.Instance.ShowFlyTip("已达到上阵最大数量！");
                return;
            }

            //index == -1 下阵
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

            if (operateType == 2)
            {
                int oldIndex = -1;
                for (int i = 0; i < self.PetTeamList.Count; i++)
                {
                    if (self.PetTeamList[i] == rolePetInfoId)
                    {
                        oldIndex = i;
                    }
                }

                self.PetTeamList[oldIndex] = self.PetTeamList[index];
                self.PetTeamList[index] = rolePetInfoId;
            }

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

            self.View.ES_PetFormationSet.OnUpdateFormation(self.SceneTypeEnum, self.PetTeamList, true);

            self.OnUpdateNumber(self.SceneTypeEnum);
            self.UpdateFighting(self.SceneTypeEnum);
            self.OnInitPetList(self.SceneTypeEnum);
        }

        public static void OnInitPetList(this DlgPetFormation self, int sceneType)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            self.ShowRolePetInfos.Clear();
            self.ShowRolePetInfos.AddRange(petComponent.RolePetInfos);

            self.AddUIScrollItems(ref self.ScrollItemPetFormationItems, self.ShowRolePetInfos.Count);
            self.View.E_PetFormationItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }

        private static void OnPetFormationItemRefresh(this DlgPetFormation self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetFormationItem item in self.ScrollItemPetFormationItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetFormationItem scrollItemPetFormationItem = self.ScrollItemPetFormationItems[index].BindTrans(transform);
            scrollItemPetFormationItem.BeginDragHandler = (binfo, pdata) => { self.BeginDrag(binfo, pdata); };
            scrollItemPetFormationItem.DragingHandler = (binfo, pdata) => { self.Draging(binfo, pdata); };
            scrollItemPetFormationItem.EndDragHandler = (binfo, pdata) => { self.EndDrag(binfo, pdata); };
            scrollItemPetFormationItem.OnInitUI(self.ShowRolePetInfos[index], self.PetTeamList.Contains(self.ShowRolePetInfos[index].Id));
        }

        public static void BeginDrag(this DlgPetFormation self, RolePetInfo binfo, PointerEventData pdata)
        {
            self.View.E_IconItemDragImage.gameObject.SetActive(true);
            PetConfig petConfig = PetConfigCategory.Instance.Get(binfo.ConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            GameObject icon = self.View.E_IconItemDragImage.transform.Find("ImageIcon").gameObject;
            icon.GetComponent<Image>().sprite = sp;
            CommonViewHelper.SetParent(self.View.E_IconItemDragImage.gameObject, self.View.uiTransform.gameObject);
        }

        public static void Draging(this DlgPetFormation self, RolePetInfo binfo, PointerEventData pdata)
        {
            Vector2 localPoint;
            RectTransform canvas = self.View.E_IconItemDragImage.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.View.E_IconItemDragImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static void EndDrag(this DlgPetFormation self, RolePetInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.View.E_IconItemDragImage.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("FormationSet"))
                {
                    continue;
                }

                int index = int.Parse(name.Substring(name.Length - 1, 1));
                self.OnDragFormationSet(binfo.Id, index, 1);
                break;
            }

            CommonViewHelper.SetParent(self.View.E_IconItemDragImage.gameObject, self.View.uiTransform.gameObject);
            self.View.E_IconItemDragImage.gameObject.SetActive(false);
        }
    }
}
