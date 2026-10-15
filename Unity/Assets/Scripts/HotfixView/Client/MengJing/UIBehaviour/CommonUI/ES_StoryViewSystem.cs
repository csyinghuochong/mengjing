using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_Story))]
    [FriendOfAttribute(typeof(ES_Story))]
    public static partial class ES_StorySystem
    {
        [EntitySystem]
        private static void Awake(this ES_Story self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_PageTypeSetToggleGroup.AddListener(self.OnPageTypeSet);
            self.E_PageTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_Story self)
        {
            self.DestroyWidget();
        }

        private static void OnPageTypeSet(this ES_Story self, int index)
        {
            self.EG_MainRectTransform.gameObject.SetActive(index == 0);
            self.EG_StoryRectTransform.gameObject.SetActive(index == 1);
        }
    }
}
