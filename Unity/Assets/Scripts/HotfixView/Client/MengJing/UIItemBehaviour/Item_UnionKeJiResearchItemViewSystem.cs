using System.Text.RegularExpressions;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionKeJiResearchItem))]
    [EntitySystemOf(typeof(Scroll_Item_UnionKeJiResearchItem))]
    public static partial class Scroll_Item_UnionKeJiResearchItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_UnionKeJiResearchItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_UnionKeJiResearchItem self)
        {
            self.DestroyWidget();
        }

        public static void UpdateInfo(this Scroll_Item_UnionKeJiResearchItem self, int position, int configId)
        {
            self.E_ClickBtnButton.AddListener(self.OnClickBtn);
            self.Position = position;

            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(configId);
            Match match = Regex.Match(unionKeJiConfig.EquipSpaceName, @"\d");
            self.E_NameTextText.text = unionKeJiConfig.EquipSpaceName.Substring(0, match.Index);
            using (zstring.Block())
            {
                self.E_LvTextText.text = unionKeJiConfig.QiangHuaLv == 0 ? "未研究" : zstring.Format("等级：{0}", unionKeJiConfig.QiangHuaLv.ToString());
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, unionKeJiConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImgImage.sprite = sp;

            CommonViewHelper.SetImageGray(self.Root(), self.E_IconImgImage.gameObject, unionKeJiConfig.QiangHuaLv == 0);
        }

        public static void OnClickBtn(this Scroll_Item_UnionKeJiResearchItem self)
        {
            self.ClickAction?.Invoke(self.Position);
        }
    }
}