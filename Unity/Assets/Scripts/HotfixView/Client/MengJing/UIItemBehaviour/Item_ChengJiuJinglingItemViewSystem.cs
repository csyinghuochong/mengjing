using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChengJiuJinglingItem))]
    [EntitySystemOf(typeof(Scroll_Item_ChengJiuJinglingItem))]
    public static partial class Scroll_Item_ChengJiuJinglingItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChengJiuJinglingItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChengJiuJinglingItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_ChengJiuJinglingItem self, int jid, JingLingInfo jingLingInfo)
        {
            self.E_ClickButton.AddListener(() => { self.GetParent<ES_ChengJiuJingling>().OnUpdateUI(self.JingLingId); });

            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jid);
            self.JingLingId = jid;
            self.E_NameText.text = jingLingConfig.Name;

            GameObject gameObject = self.ES_ModelShow.EG_RootRectTransform.gameObject;
            // self.ES_ModelShow.ShowOtherModel("JingLing/" + jingLingConfig.Assets).Coroutine();
            self.ES_ModelShow.ShowOtherModel("JingLing/70001001").Coroutine();
            gameObject.transform.Find("Camera").localPosition = new Vector3(0f, 40f, 200f);
            gameObject.transform.localPosition = new Vector2(jingLingConfig.Id % 10 * 1000, 0);
            gameObject.transform.Find("ModelParent").localRotation = Quaternion.Euler(0f, -45f, 0f);

            bool active = jingLingInfo.IsActive == 1;
            self.E_ActivatedText.text = active ? "已激活" : "未激活";
            CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, !active);

            self.E_SelectedImage.gameObject.SetActive(false);
        }
    }
}