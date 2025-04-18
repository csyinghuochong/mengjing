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
            
            self.ES_ModelShow.ShowOtherModel("JingLing/" + jingLingConfig.Assets).Coroutine();
            
            string[] strs = null;
            if (!CommonHelp.IfNull(jingLingConfig.ModelShowPosi))
            {
                strs = jingLingConfig.ModelShowPosi.Split(',');
            }
            if (strs != null && strs.Length >= 5)
            {
                self.ES_ModelShow.Camera.fieldOfView = float.Parse(strs[3]);
                self.ES_ModelShow.SetCameraPosition(new Vector3(float.Parse(strs[0]), float.Parse(strs[1]), float.Parse(strs[2])));
                self.ES_ModelShow.RotationY = float.Parse(strs[4]); 
            }
            else
            {
                self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 40f, 200f));
                self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));
            }
            //self.ES_ModelShow.SetRootPosition(new Vector2(jingLingConfig.Id % 10 * 1000, 0));
            
            bool active = jingLingInfo.IsActive == 1;
            self.E_ActivatedText.text = active ? "已激活" : "未激活";
            CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, !active);

            self.E_SelectedImage.gameObject.SetActive(false);
        }
    }
}