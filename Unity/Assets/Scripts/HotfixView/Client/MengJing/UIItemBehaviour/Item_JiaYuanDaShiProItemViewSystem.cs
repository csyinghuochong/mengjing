using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanDaShiProItem))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanDaShiProItem))]
    public static partial class Scroll_Item_JiaYuanDaShiProItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanDaShiProItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanDaShiProItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanDaShiProItem self, KeyValuePair keyValuePair, string promax)
        {
            self.jiayuanDaShi.Clear();
            //血
            self.jiayuanDaShi.Add(100203, "PetPro_1");
            self.jiayuanDaShi.Add(105503, "PetPro_1");

            //攻击
            self.jiayuanDaShi.Add(100403, "PetPro_2");
            self.jiayuanDaShi.Add(119303, "PetPro_2");
            self.jiayuanDaShi.Add(119103, "PetPro_2");
            self.jiayuanDaShi.Add(105103, "PetPro_2");
            self.jiayuanDaShi.Add(105203, "PetPro_2");
            self.jiayuanDaShi.Add(119503, "PetPro_2");
            self.jiayuanDaShi.Add(110203, "PetPro_2");
            self.jiayuanDaShi.Add(120603, "PetPro_2");

            //魔法
            self.jiayuanDaShi.Add(105303, "PetPro_3");
            self.jiayuanDaShi.Add(120703, "PetPro_3");

            //物防
            self.jiayuanDaShi.Add(100603, "PetPro_4");
            self.jiayuanDaShi.Add(119403, "PetPro_4");
            self.jiayuanDaShi.Add(119203, "PetPro_4");
            self.jiayuanDaShi.Add(105403, "PetPro_4");

            //魔防
            self.jiayuanDaShi.Add(100803, "PetPro_5");
            self.jiayuanDaShi.Add(110103, "PetPro_5");

            string[] proinfo = promax.Split(',');

            string atrname = ItemViewHelp.GetAttributeName(int.Parse(proinfo[0]));
            self.E_Text_NameText.text = atrname;
            string curvalue = keyValuePair != null ? keyValuePair.Value : "0";
            using (zstring.Block())
            {
                self.E_Text_ProgessText.text = zstring.Format("{0}/{1}", curvalue, proinfo[1]);
            }

            self.E_ImageTo_1ValueImage.fillAmount = float.Parse(curvalue) / float.Parse(proinfo[1]);

            self.E_ImageToLockImage.gameObject.SetActive(false);

            //显示图标
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PropertyIcon, self.jiayuanDaShi[int.Parse(proinfo[0])]);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageProIconImage.sprite = sp;
        }
    }
}