using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIPetEquipSetItem))]
    [EntitySystemOf(typeof(UIPetEquipSetItem))]
    public static partial class UIPetEquipSetItemSystem
    {
        [EntitySystem]
        private static void Awake(this UIPetEquipSetItem self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            Transform tf = gameObject.transform;
            self.Img_EquipIcon = tf.Find("Img_EquipIcon").gameObject;
            self.Btn_Equip = tf.Find("Btn_Equip").gameObject;
            self.Img_EquipQuality = tf.Find("Img_EquipQuality").gameObject;
            self.Img_EquipBangDing = tf.Find("Img_BangDing").gameObject;
            self.Img_EquipBack = tf.Find("Img_EquipBack").gameObject;
            //self.Btn_Equip.GetComponent<Button>().onClick.AddListener(() => { self.OnClickEquip(); });

            //ButtonHelp.AddEventTriggers(self.Btn_Equip, (PointerEventData pdata) => { self.BeginDrag(pdata); }, EventTriggerType.BeginDrag);
            //ButtonHelp.AddEventTriggers(self.Btn_Equip, (PointerEventData pdata) => { self.Draging(pdata); }, EventTriggerType.Drag);
            //ButtonHelp.AddEventTriggers(self.Btn_Equip, (PointerEventData pdata) => { self.EndDrag(pdata); }, EventTriggerType.EndDrag);
            
            self.Btn_Equip.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.Btn_Equip.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
        }

        [EntitySystem]
        private static void Destroy(this UIPetEquipSetItem self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.PointDownTime);
            for (int i = 0; i < self.AssetPath.Count; i++)
            {
                if (!string.IsNullOrEmpty(self.AssetPath[i]))
                {
                    self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(self.AssetPath[i]);
                }
            }

            self.AssetPath = null;
        }

        public static void PointerDown(this UIPetEquipSetItem self, PointerEventData pdata)
        {
            self.ShowEquiTip = true;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.PointDownTime);
            self.PointDownTime = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeHelper.ServerNow() + 300, TimerInvokeType.PetEquipSetItemTimer, self);
            self.OnClickEquip();
        }

        public static void ShowEquipItemTips(this UIPetEquipSetItem self)
        {
            self.ShowEquiTip = false;

            if (self.BagInfo == null)
                return;
            
            
            //弹出Tips
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = self.BagInfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new List<ItemInfo>()
                });
        }

        public static void PointerUp(this UIPetEquipSetItem self, PointerEventData pdata)
        {
            self.ShowEquiTip = false;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.PointDownTime);
        }

        public static void OnClickEquip(this UIPetEquipSetItem self)
        {
            if (self.BagInfo == null)
                return;

            if (self.OnClickAction != null)
            {
                // self.OnClickAction.Invoke(self.BagInfo);
                return;
            }

            // EventType.ShowItemTips.Instance.ZoneScene = self.DomainScene();
            // EventType.ShowItemTips.Instance.bagInfo = self.BagInfo;
            // EventType.ShowItemTips.Instance.itemOperateEnum = self.itemOperateEnum;
            // EventType.ShowItemTips.Instance.inputPoint = Input.mousePosition;
            // EventType.ShowItemTips.Instance.EquipList = self.EquipIdList;
            // Game.EventSystem.PublishClass(EventType.ShowItemTips.Instance);
        }

        public static void InitUI(this UIPetEquipSetItem self, int subType)
        {
            self.BagInfo = null;

            self.Img_EquipIcon.SetActive(false);
            self.Img_EquipQuality.SetActive(false);
            self.Img_EquipBangDing.SetActive(false);

            // if (subType < 100)
            // {
            //     string qianghuaName = ItemViewHelp.EquipWeiZhiToName[subType].Icon;
            //     string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, qianghuaName);
            //     Sprite sp = ResourcesComponent.Instance.LoadAsset<Sprite>(path);
            //     if (!self.AssetPath.Contains(path))
            //     {
            //         self.AssetPath.Add(path);
            //     }
            //
            //     self.Img_EquipBack.GetComponent<Image>().sprite = sp;
            // }
        }

        public static void UpdateData(this UIPetEquipSetItem self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum, List<BagInfo> equipIdList)
        {
            try
            {
                self.BagInfo = bagInfo;
                self.itemOperateEnum = itemOperateEnum;
                self.EquipIdList = equipIdList;
                ItemConfig itemconfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                if (!self.AssetPath.Contains(path))
                {
                    self.AssetPath.Add(path);
                }

                self.Img_EquipIcon.SetActive(true);
                self.Img_EquipIcon.GetComponent<Image>().sprite = sp;

                //设置品质
                string ItemQuality = FunctionUI.ItemQualiytoPath(itemconfig.ItemQuality);
                self.Img_EquipQuality.SetActive(true);
                string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality);
                Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
                if (!self.AssetPath.Contains(path2))
                {
                    self.AssetPath.Add(path2);
                }

                self.Img_EquipQuality.GetComponent<Image>().sprite = sp2;

                //显示绑定
                if (bagInfo.isBinging)
                {
                    self.Img_EquipBangDing.SetActive(true);
                }
                else
                {
                    self.Img_EquipBangDing.SetActive(false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}