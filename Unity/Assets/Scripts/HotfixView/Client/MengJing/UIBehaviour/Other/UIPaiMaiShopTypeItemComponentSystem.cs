using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UIPaiMaiShopTypeItemComponent))]
    [EntitySystemOf(typeof (UIPaiMaiShopTypeItemComponent))]
    public static partial class UIPaiMaiShopTypeItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIPaiMaiShopTypeItemComponent self, GameObject gameObject)
        {
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.GameObject = gameObject;
            self.Lab_TaskName = rc.Get<GameObject>("Lab_TaskName");
            self.Ima_Di = rc.Get<GameObject>("Ima_Di");
            self.Ima_SelectStatus = rc.Get<GameObject>("Ima_SelectStatus");
            self.Ima_Di.GetComponent<Button>().onClick.AddListener(() => { self.OnClickButtoin(); });
        }

        public static void SetSelected(this UIPaiMaiShopTypeItemComponent self, int subTypeid)
        {
            self.Ima_SelectStatus.SetActive(subTypeid == self.SubTypeId);
        }

        public static void SetClickSubTypeHandler(this UIPaiMaiShopTypeItemComponent self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnUpdateData(this UIPaiMaiShopTypeItemComponent self, int typeid, int subType)
        {
            self.SubTypeId = subType;
            self.Lab_TaskName.GetComponent<Text>().text = PaiMaiData.PaiMaiIndexText[subType];
        }

        public static void OnClickButtoin(this UIPaiMaiShopTypeItemComponent self)
        {
            self.ClickHandler(self.SubTypeId);
        }
    }
}