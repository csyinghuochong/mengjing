using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_ChengJiuShowItem))]
    public static partial class Scroll_Item_ChengJiuShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChengJiuShowItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChengJiuShowItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_ChengJiuShowItem self, int id)
        {
            ChengJiuConfig chengJiuConfig = ChengJiuConfigCategory.Instance.Get(id);
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();

            bool complete = chengJiuComponent.ChengJiuCompleteList.Contains(id);
            ChengJiuInfo chengJiuInfo = null;
            chengJiuComponent.ChengJiuProgessList.TryGetValue(id, out chengJiuInfo);

            self.E_Lab_TaskNameText.text = chengJiuConfig.Name;
            if (complete)
            {
                using (zstring.Block())
                {
                    self.E_Lab_ProValueText.text = zstring.Format("进度:{0}/{1}", chengJiuConfig.TargetValue, chengJiuConfig.TargetValue);
                }
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_Lab_ProValueText.text = zstring.Format("进度:{0}/{1}", chengJiuInfo?.ChengJiuProgess ?? 0, chengJiuConfig.TargetValue);
                }
            }

            self.E_Ima_CompleteTaskImage.gameObject.SetActive(complete);

            self.E_Lab_TaskDesText.text = chengJiuConfig.Des;

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ChengJiuIcon, chengJiuConfig.Icon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Ima_IconImage.sprite = sp;

            using (zstring.Block())
            {
                self.E_Lab_ChengJiuNumText.text = zstring.Format("{0}", chengJiuConfig.RewardNum);
            }
        }
    }
}