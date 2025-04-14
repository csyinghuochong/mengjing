using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(Scroll_Item_SkillSetItem))]
    [FriendOf(typeof (ES_CommonItem))]
    [EntitySystemOf(typeof (ES_SkillSet))]
    [FriendOfAttribute(typeof (ES_SkillSet))]
    public static partial class ES_SkillSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.EG_SkillIconItemRectTransform.gameObject.SetActive(false);
            self.E_SkillSetItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSkillSetItemsRefresh);
            self.E_CommonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonItemsRefresh);

            self.InitSkillSetIcons();
            self.OnSkillSetting();
            self.UpdateItemSkillUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillSet self)
        {
            self.DestroyWidget();
        }

        private static void InitSkillSetIcons(this ES_SkillSet self)
        {
            int childCount = self.EG_SkillIPositionSetRectTransform.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.EG_SkillIconItemRectTransform.gameObject);
                go.SetActive(false);
                CommonViewHelper.SetParent(go, self.EG_SkillIPositionSetRectTransform.transform.GetChild(i).gameObject);
                self.SkillSetIconList.Add(go);
                //self.SkillIPositionSet.transform.GetChild(i).gameObject.GetComponent<Image>().enabled = false;
            }
        }

        public static void OnSkillSetting(this ES_SkillSet self)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < self.SkillSetIconList.Count; i++)
            {
                GameObject itemgo = self.SkillSetIconList[i];
                GameObject addImage = itemgo.transform.parent.GetChild(0).gameObject;
                SkillPro skillPro = skillSetComponent.GetByPosition(i + 1);

                if (skillPro == null)
                {
                    addImage.GetComponent<Image>().fillAmount = 1;
                    itemgo.SetActive(false);
                    continue;
                }

                addImage.GetComponent<Image>().fillAmount = 0;
                itemgo.SetActive(true);
                if (skillPro.SkillSetType == (int)SkillSetEnum.Skill)
                {
                    BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(SkillHelp.GetWeaponSkill(skillPro.SkillID,
                        UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList));
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                    itemgo.transform.Find("Img_Mask/Img_SkillIcon").GetComponent<Image>().sprite = sp;
                }

                if (skillPro.SkillSetType == (int)SkillSetEnum.Item)
                {
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(skillPro.SkillID);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                    itemgo.transform.Find("Img_Mask/Img_SkillIcon").GetComponent<Image>().sprite = sp;
                }
            }
        }

        private static void OnSkillSetItemsRefresh(this ES_SkillSet self, Transform transform, int index)
        {
            foreach (Scroll_Item_SkillSetItem item in self.ScrollItemSkillSetItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SkillSetItem scrollItemSkillSetItem = self.ScrollItemSkillSetItems[index].BindTrans(transform);
            scrollItemSkillSetItem.OnUpdateUI(self.ShowSkillPros[index]);
        }

        private static void OnCommonItemsRefresh(this ES_SkillSet self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);

            scrollItemCommonItem.UpdateItem(self.ShowBagInfos[index], ItemOperateEnum.SkillSet);
            scrollItemCommonItem.SetEventTrigger(true);
            scrollItemCommonItem.BeginDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.BeginDrag(binfo, pdata); };
            scrollItemCommonItem.DragingHandler = (ItemInfo binfo, PointerEventData pdata) => { self.Draging(binfo, pdata); };
            scrollItemCommonItem.EndDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.EndDrag(binfo, pdata); };
        }

        public static void UpdateSkillListUI(this ES_SkillSet self)
        {
            List<SkillPro> skillPros = self.Root().GetComponent<SkillSetComponentC>().SkillList;

            self.ShowSkillPros.Clear();
            for (int i = 0; i < skillPros.Count; i++)
            {
                if (skillPros[i].SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }

                //没激活的不显示
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPros[i].SkillID);
                if (skillConfig.SkillLv == 0 || skillConfig.IsShow == 1)
                {
                    continue;
                }

                if (skillConfig.SkillType == (int)SkillTypeEnum.PassiveSkill
                    || skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkill
                    || skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkillNoFight)
                {
                    continue;
                }

                self.ShowSkillPros.Add(skillPros[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemSkillSetItems, self.ShowSkillPros.Count);
            self.E_SkillSetItemsLoopVerticalScrollRect.SetVisible(true, self.ShowSkillPros.Count);
        }

        private static void UpdateItemSkillUI(this ES_SkillSet self)
        {
            self.ShowBagInfos.Clear();
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                int itemID = bagInfos[i].ItemID;
                ItemConfig itemconf = ItemConfigCategory.Instance.Get(itemID);

                if (itemconf.ItemType == (int)ItemTypeEnum.Consume && (itemconf.ItemSubType == 101 || itemconf.ItemSubType == 110) &&
                    itemconf.ItemUsePar != "0" && itemconf.ItemUsePar != "")
                {
                    self.ShowBagInfos.Add(bagInfos[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_CommonItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void BeginDrag(this ES_SkillSet self, ItemInfo binfo, PointerEventData pdata)
        {
            self.SkillIconItemCopy = UnityEngine.Object.Instantiate(self.EG_SkillIconItemRectTransform.gameObject);
            self.SkillIconItemCopy.SetActive(true);
            CommonViewHelper.SetParent(self.SkillIconItemCopy, self.uiTransform.parent.parent.gameObject);

            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(binfo.ItemID);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.SkillIconItemCopy.transform.Find("Img_Mask/Img_SkillIcon").GetComponent<Image>().sprite = sp;
        }

        public static void Draging(this ES_SkillSet self, ItemInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.SkillIconItemCopy.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out self.localPoint);

            self.SkillIconItemCopy.transform.localPosition = new Vector3(self.localPoint.x, self.localPoint.y, 0f);
        }

        public static void EndDrag(this ES_SkillSet self, ItemInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.SkillIconItemCopy.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("Danger_Skill_Icon_"))
                {
                    continue;
                }

                int index = int.Parse(name.Remove(0, 18));
                if (index < 9)
                {
                    continue;
                }

                SkillNetHelper.SetSkillIdByPosition(self.Root(), binfo.ItemID, (int)SkillSetEnum.Item, index).Coroutine();
                break;
            }

            if (self.SkillIconItemCopy != null)
            {
                UnityEngine.Object.Destroy(self.SkillIconItemCopy);
                self.SkillIconItemCopy = null;
            }
        }

        public static void UpdateSkillSetUI(this ES_SkillSet self)
        {
        }
    }
}
