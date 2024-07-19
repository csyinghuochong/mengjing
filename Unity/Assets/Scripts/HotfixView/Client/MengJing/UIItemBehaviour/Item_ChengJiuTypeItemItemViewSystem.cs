using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChengJiuTypeItemItem))]
    [EntitySystemOf(typeof(Scroll_Item_ChengJiuTypeItemItem))]
    public static partial class Scroll_Item_ChengJiuTypeItemItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChengJiuTypeItemItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChengJiuTypeItemItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this Scroll_Item_ChengJiuTypeItemItem self, int subTypeid)
        {
            self.E_Ima_SelectStatusImage.gameObject.SetActive(subTypeid == self.SubTypeId);
        }

        public static void OnUpdateData(this Scroll_Item_ChengJiuTypeItemItem self, int typeid, int subType)
        {
            self.SubTypeId = subType;

            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            List<int> ids = chengJiuComponent.GetTasksByChapter(typeid, subType);
            int number = 0;
            for (int i = 0; i < ids.Count; i++)
            {
                number += chengJiuComponent.ChengJiuCompleteList.Contains(ids[i]) ? 1 : 0;
            }

            using (zstring.Block())
            {
                self.E_Lab_TaskNumText.text = zstring.Format(" ({0}/{1})", number, ids.Count);
            }

            self.E_Lab_TaskNameText.text = ChengJiuData.ChapterIndexText[subType];
            self.E_Ima_ProgressImage.transform.localScale = new Vector3(number * 1f / ids.Count, 1f, 1f);
            self.E_Ima_CompleteTaskImage.gameObject.SetActive(number >= ids.Count);

            self.E_Ima_DiButton.AddListener(self.OnClickButtoin);
        }

        public static void SetClickSubTypeHandler(this Scroll_Item_ChengJiuTypeItemItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnClickButtoin(this Scroll_Item_ChengJiuTypeItemItem self)
        {
            self.ClickHandler(self.SubTypeId);
        }
    }
}