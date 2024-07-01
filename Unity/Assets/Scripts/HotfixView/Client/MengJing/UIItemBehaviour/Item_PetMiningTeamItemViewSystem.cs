using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetFormationItem))]
    [FriendOf(typeof (Scroll_Item_PetMiningTeamItem))]
    [EntitySystemOf(typeof (Scroll_Item_PetMiningTeamItem))]
    public static partial class Scroll_Item_PetMiningTeamItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMiningTeamItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMiningTeamItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonSet(this Scroll_Item_PetMiningTeamItem self)
        {
            long intanceid = self.InstanceId;
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMiningFormation);

            if (intanceid != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMiningFormation>().OnInitUI(SceneTypeEnum.PetMing, self.TeamId, null);
        }

        public static void OnInitUI(this Scroll_Item_PetMiningTeamItem self, int position)
        {
            self.TextTip11 = self.uiTransform.Find("TextTip11").gameObject;
            self.TextTip12 = self.uiTransform.Find("TextTip12").gameObject;

            for (int i = 0; i < self.FormationItemComponents.Length; i++)
            {
                self.PetIcon_di_List[i] = self.uiTransform.Find($"PetIcon_di_{i}").gameObject;
                self.FormationItemComponents[i] = null;
            }

            self.PetComponent = self.Root().GetComponent<PetComponentC>();

            self.ButtonSet = self.uiTransform.Find("ButtonSet").gameObject;
            self.ButtonSet.gameObject.SetActive(true);
            self.ButtonSet.GetComponent<Button>().onClick.AddListener(() => { self.OnButtonSet().Coroutine(); });

            self.TeamId = position;
            self.TextTip11.GetComponent<Text>().text = $"{position + 1}队";

            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            int openLv = ConfigData.PetMiningTeamOpenLevel[position];
            if (playerLv < openLv)
            {
                self.TextTip12.GetComponent<Text>().text = $"{openLv}级开启";
            }
            else
            {
                self.TextTip12.SetActive(false);
            }

            for (int i = 0; i < self.PetIcon_di_List.Length; i++)
            {
                self.PetIcon_di_List[i].gameObject.SetActive(playerLv >= openLv);
            }
        }

        public static void UpdatePetTeam(this Scroll_Item_PetMiningTeamItem self, List<long> petlist)
        {
            var path = ABPathHelper.GetUGUIPath("Item/Item_PetFormationItem_2");
            var bundleGameObject = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);

            for (int i = 0; i < self.FormationItemComponents.Length; i++)
            {
                long petId = petlist[i + self.TeamId * 5];
                RolePetInfo rolePetInfo = self.PetComponent.GetPetInfoByID(petId);

                if (rolePetInfo != null && self.FormationItemComponents[i] == null)
                {
                    GameObject goItem = GameObject.Instantiate(bundleGameObject);
                    CommonViewHelper.SetParent(goItem, self.PetIcon_di_List[i]);
                    goItem.transform.localScale = Vector3.one * 0.6f;
                    Scroll_Item_PetFormationItem FormationItem = self.AddChild<Scroll_Item_PetFormationItem>();
                    FormationItem.uiTransform = goItem.transform;
                    self.FormationItemComponents[i] = FormationItem;
                    FormationItem.BeginDragHandler = (RolePetInfo binfo, PointerEventData pdata) => { self.BeginDrag(binfo, pdata); };
                    FormationItem.DragingHandler = (RolePetInfo binfo, PointerEventData pdata) => { self.Draging(binfo, pdata); };
                    FormationItem.EndDragHandler = (RolePetInfo binfo, PointerEventData pdata) => { self.EndDrag(binfo, pdata); };
                    FormationItem.SetDragEnable(true);
                }

                if (rolePetInfo == null && self.FormationItemComponents[i] != null)
                {
                    self.FormationItemComponents[i].uiTransform.gameObject.SetActive(false);
                }

                if (rolePetInfo != null)
                {
                    self.FormationItemComponents[i].OnInitUI(rolePetInfo);
                    self.FormationItemComponents[i].uiTransform.gameObject.SetActive(true);
                }
            }
        }

        public static void BeginDrag(this Scroll_Item_PetMiningTeamItem self, RolePetInfo binfo, PointerEventData pdata)
        {
            self.IconItemDrag.SetActive(true);
            PetConfig petConfig = PetConfigCategory.Instance.Get(binfo.ConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            GameObject icon = self.IconItemDrag.transform.Find("ImageIcon").gameObject;
            icon.GetComponent<Image>().sprite = sp;
            CommonViewHelper.SetParent(self.IconItemDrag, self.uiTransform.parent.parent.gameObject);
        }

        public static void Draging(this Scroll_Item_PetMiningTeamItem self, RolePetInfo binfo, PointerEventData pdata)
        {
            Vector2 localPoint;
            RectTransform canvas = self.IconItemDrag.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.IconItemDrag.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static void RequestFormationSet(this Scroll_Item_PetMiningTeamItem self, long rolePetInfoId, int index, int operateType)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMiningTeam>()
                    .OnDragFormationSet(rolePetInfoId, index, operateType, self.TeamId);
        }

        public static void EndDrag(this Scroll_Item_PetMiningTeamItem self, RolePetInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.IconItemDrag.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (name.Contains("UIPetFormationAA"))
                {
                    self.RequestFormationSet(binfo.Id, -1, 3);
                    break;
                }
            }

            CommonViewHelper.SetParent(self.IconItemDrag, self.uiTransform.gameObject);
            self.IconItemDrag.SetActive(false);
        }
    }
}