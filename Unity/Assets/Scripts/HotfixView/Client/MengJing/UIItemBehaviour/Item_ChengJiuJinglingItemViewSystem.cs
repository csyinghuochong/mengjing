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

        private static async ETTask OnButtonActivite(this Scroll_Item_ChengJiuJinglingItem self)
        {
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
           
            int error = await JingLingNetHelper.RequestJingLingUse(self.Root(), self.JingLingId, 1);
            if (error != 0)
            {
                return;
            }

            bool current = chengJiuComponent.JingLingId == self.JingLingId;
            self.E_ButtonShouHuiButton.gameObject.SetActive(current);
            self.E_ButtonActiviteButton.gameObject.SetActive(!current);

            EventSystem.Instance.Publish(self.Root(), new JingLingButton());
        }

        public static void OnInitUI(this Scroll_Item_ChengJiuJinglingItem self, int jid, JingLingInfo jingLingInfo)
        {
            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jid);
            self.JingLingId = jid;
            self.E_ChengHaoNameText.text = jingLingConfig.Name;
            bool active = jingLingInfo.Progess >= jingLingConfig.NeedPoint;
            
            GameObject gameObject = self.ES_ModelShow.EG_RootRectTransform.gameObject;
            // self.ES_ModelShow.ShowOtherModel("JingLing/" + jingLingConfig.Assets).Coroutine();
            // 测试 70001001
            self.ES_ModelShow.ShowOtherModel("JingLing/70001001", canDrag: false).Coroutine();

            gameObject.transform.Find("Camera").localPosition = new Vector3(0f, 40f, 200f);
            gameObject.transform.localPosition = new Vector2(jingLingConfig.Id % 10 * 1000, 0);
            gameObject.transform.Find("ModelParent").localRotation = Quaternion.Euler(0f, -45f, 0f);

            self.E_Text_valueText.text = jingLingConfig.Des;
            self.E_ObjGetTextText.text = jingLingConfig.GetDes;
            self.E_JingLingDesText.text = jingLingConfig.ProDes;
            CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, !active);

            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            bool current = chengJiuComponent.JingLingId == jid;
            self.E_ButtonShouHuiButton.gameObject.SetActive(current);
            self.E_ButtonActiviteButton.gameObject.SetActive(!current);

            self.E_ButtonActiviteButton.AddListenerAsync(self.OnButtonActivite);
            self.E_ButtonShouHuiButton.AddListenerAsync(self.OnButtonActivite);
        }

        public static void OnUpdateUI(this Scroll_Item_ChengJiuJinglingItem self)
        {
        }
    }
}