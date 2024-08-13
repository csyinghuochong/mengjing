using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetFormationItem))]
    [EntitySystemOf(typeof(ES_PetFormationSet))]
    [FriendOfAttribute(typeof(ES_PetFormationSet))]
    public static partial class ES_PetFormationSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetFormationSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_IconItemDragImage.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetFormationSet self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateFormation(this ES_PetFormationSet self, int sceneType, List<long> teamPets, bool drag = false)
        {
            var bundleGameObject = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>("Assets/Bundles/UI/Item/Item_PetFormationItem.prefab");

            Transform transform = self.uiTransform.Find("FormationNode");
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();

            for (int i = 0; i < teamPets.Count; i++)
            {
                Scroll_Item_PetFormationItem uIRolePetItemComponent = self.FormationItemComponents[i];
                if (teamPets[i] == 0)
                {
                    if (uIRolePetItemComponent != null)
                    {
                        uIRolePetItemComponent.uiTransform.gameObject.SetActive(false);
                    }

                    continue;
                }

                if (uIRolePetItemComponent == null)
                {
                    GameObject go = GameObject.Instantiate(bundleGameObject);
                    using (zstring.Block())
                    {
                        CommonViewHelper.SetParent(go, transform.Find(zstring.Format("FormationSet{0}", i)).gameObject);
                    }

                    uIRolePetItemComponent = self.AddChild<Scroll_Item_PetFormationItem>();
                    uIRolePetItemComponent.uiTransform = go.transform;
                    self.FormationItemComponents[i] = uIRolePetItemComponent;
                }

                uIRolePetItemComponent.uiTransform.gameObject.SetActive(true);
                RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(teamPets[i]);
                uIRolePetItemComponent.OnInitUI(rolePetInfo);
                uIRolePetItemComponent.SetDragEnable(drag);
                uIRolePetItemComponent.BeginDragHandler = (binfo, pdata) => { self.BeginDrag(binfo, pdata); };
                uIRolePetItemComponent.DragingHandler = (binfo, pdata) => { self.Draging(binfo, pdata); };
                uIRolePetItemComponent.EndDragHandler = (binfo, pdata) => { self.EndDrag(binfo, pdata); };
            }
        }

        public static void BeginDrag(this ES_PetFormationSet self, RolePetInfo binfo, PointerEventData pdata)
        {
            self.E_IconItemDragImage.gameObject.SetActive(true);
            PetConfig petConfig = PetConfigCategory.Instance.Get(binfo.ConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            GameObject icon = self.E_IconItemDragImage.transform.Find("ImageIcon").gameObject;
            icon.GetComponent<Image>().sprite = sp;
            CommonViewHelper.SetParent(self.E_IconItemDragImage.gameObject, self.uiTransform.parent.parent.gameObject);
        }

        public static void Draging(this ES_PetFormationSet self, RolePetInfo binfo, PointerEventData pdata)
        {
            Vector2 localPoint;
            RectTransform canvas = self.E_IconItemDragImage.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.E_IconItemDragImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static void EndDrag(this ES_PetFormationSet self, RolePetInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.E_IconItemDragImage.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (name.Contains("UIPetFormationAA"))
                {
                    self.DragEndHandler(binfo.Id, -1, 3);
                    break;
                }

                if (name.Contains("FormationSet"))
                {
                    int index = int.Parse(name.Substring(name.Length - 1, 1));
                    self.DragEndHandler(binfo.Id, index, 2);
                    break;
                }
            }

            CommonViewHelper.SetParent(self.E_IconItemDragImage.gameObject, self.uiTransform.gameObject);
            self.E_IconItemDragImage.gameObject.SetActive(false);
        }
    }
}
