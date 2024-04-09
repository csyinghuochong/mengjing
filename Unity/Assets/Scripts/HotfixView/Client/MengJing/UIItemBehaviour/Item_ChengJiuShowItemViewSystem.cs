using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (Scroll_Item_ChengJiuShowItem))]
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
                self.E_Lab_ProValueText.text = $"进度:{chengJiuConfig.TargetValue}/{chengJiuConfig.TargetValue}";
            }
            else
            {
                self.E_Lab_ProValueText.text = $"进度:{chengJiuInfo?.ChengJiuProgess ?? 0}/{chengJiuConfig.TargetValue}";
            }

            self.E_Ima_CompleteTaskImage.gameObject.SetActive(complete);

            self.E_Lab_TaskDesText.text = chengJiuConfig.Des;

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ChengJiuIcon, chengJiuConfig.Icon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Ima_IconImage.sprite = sp;

            self.E_Lab_ChengJiuNumText.text = $"成就点数:{chengJiuConfig.RewardNum}";
        }
    }
}