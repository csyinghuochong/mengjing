using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanDaShiShowItem))]
    public static partial class Scroll_Item_JiaYuanDaShiShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanDaShiShowItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanDaShiShowItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanDaShiShowItem self, int index, long dashiTime)
        {
            KeyValuePair keyValuePair_0 = ConfigData.JiaYuanDaShiPro[index * 3 + 0];
            KeyValuePair keyValuePair_1 = ConfigData.JiaYuanDaShiPro[index * 3 + 1];
            KeyValuePair keyValuePair_2 = ConfigData.JiaYuanDaShiPro[index * 3 + 2];

            int need_time_0 = int.Parse(keyValuePair_0.Value2.Split('@')[0]);
            int need_time_1 = int.Parse(keyValuePair_1.Value2.Split('@')[0]);
            int need_time_2 = int.Parse(keyValuePair_2.Value2.Split('@')[0]);
            string[] attriinfo_0 = keyValuePair_0.Value2.Split('@')[1].Split(',');
            string[] attriinfo_1 = keyValuePair_1.Value2.Split('@')[1].Split(',');
            string[] attriinfo_2 = keyValuePair_2.Value2.Split('@')[1].Split(',');

            string attriname_0 = ItemViewHelp.GetAttributeName(int.Parse(attriinfo_0[0]));
            string attriname_1 = ItemViewHelp.GetAttributeName(int.Parse(attriinfo_1[0]));
            string attriname_2 = ItemViewHelp.GetAttributeName(int.Parse(attriinfo_2[0]));

            self.EG_Item_0RectTransform.Find("Text_Name").GetComponent<Text>().text = keyValuePair_0.Value;
            self.EG_Item_1RectTransform.Find("Text_Name").GetComponent<Text>().text = keyValuePair_1.Value;
            self.EG_Item_2RectTransform.Find("Text_Name").GetComponent<Text>().text = keyValuePair_2.Value;

            using (zstring.Block())
            {
                self.EG_Item_0RectTransform.Find("Text_Attri").GetComponent<Text>().text = zstring.Format("{0} +{1}", attriname_0, attriinfo_0[1]);
                self.EG_Item_1RectTransform.Find("Text_Attri").GetComponent<Text>().text = zstring.Format("{0} +{1}", attriname_1, attriinfo_1[1]);
                self.EG_Item_2RectTransform.Find("Text_Attri").GetComponent<Text>().text = zstring.Format("{0} +{1}", attriname_2, attriinfo_2[1]);

                self.EG_Item_0RectTransform.Find("Text_Tip").GetComponent<Text>().text = zstring.Format("品尝{0}次开启", need_time_0);
                self.EG_Item_1RectTransform.Find("Text_Tip").GetComponent<Text>().text = zstring.Format("品尝{0}次开启", need_time_1);
                self.EG_Item_2RectTransform.Find("Text_Tip").GetComponent<Text>().text = zstring.Format("品尝{0}次开启", need_time_2);
            }

            CommonViewHelper.SetImageGray(self.Root(), self.EG_Item_0RectTransform.Find("ImageIcon").gameObject, dashiTime < need_time_0);
            CommonViewHelper.SetImageGray(self.Root(), self.EG_Item_1RectTransform.Find("ImageIcon").gameObject, dashiTime < need_time_1);
            CommonViewHelper.SetImageGray(self.Root(), self.EG_Item_2RectTransform.Find("ImageIcon").gameObject, dashiTime < need_time_2);
        }
    }
}