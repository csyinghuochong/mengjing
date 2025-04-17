using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChengJiuPetTuJianItem))]
    [EntitySystemOf(typeof(Scroll_Item_ChengJiuPetTuJianItem))]
    public static partial class Item_ChengJiuPetTuJianItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChengJiuPetTuJianItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChengJiuPetTuJianItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_ChengJiuPetTuJianItem self, int jid, bool active)
        {
            self.E_ClickButton.AddListener(() => { self.GetParent<ES_ChengJiuPetTuJian>().OnUpdateUI(self.JingLingId); });

            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jid);
            self.JingLingId = jid;
            self.E_NameText.text = jingLingConfig.Name;
            self.ES_ModelShow.ShowOtherModel($"Pet/{jingLingConfig.Assets}").Coroutine();
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 40f, 200f));
            // self.ES_ModelShow.SetRootPosition(new Vector2(jingLingConfig.Id % 10 * 1000, 0));
            self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));
            
            // self.E_ActivatedText.text = active ? "已激活" : "未激活";
            self.E_ActivatedText.gameObject.SetActive(active);
            CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, !active);

            self.E_SelectedImage.gameObject.SetActive(false);
        }
    }
}