using UnityEngine;

namespace ET.Client
{
    public static class FunctionUI
    {
        //传入值获取属性名称
        public static string ReturnEquipNeedPropertyName(string proprety)
        {
            string propertyName = "";
            switch (proprety)
            {
                case "1":
                    propertyName = "攻击";
                    break;

                case "2":
                    propertyName = "物防";
                    break;

                case "3":
                    propertyName = "魔防";
                    break;
            }

            return propertyName;
        }

        /// <summary>
        /// 根据品质返回品质字符串
        /// 根据道具品质返回对应的品质框
        /// ItemQuality  道具品质
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        public static string ItemQualiytoPath(int itemQuality)
        {
            string path = "";
            switch (itemQuality)
            {
                case 1:
                    path = "ItemQuality_1";
                    break;
                case 2:
                    path = "ItemQuality_2";
                    break;
                case 3:
                    path = "ItemQuality_3";
                    break;
                case 4:
                    path = "ItemQuality_4";
                    break;
                case 5:
                    path = "ItemQuality_5";
                    break;
                case 6:
                    path = "ItemQuality_6";
                    break;
            }

            return path;
        }

        public static string ItemQualityLine(int itemQuality)
        {
            return $"QuaDiline_{itemQuality}";
        }

        public static string ItemQualityBack(int ItemQuality)
        {
            return $"QuaDi_{ItemQuality}";
        }

        //根据品质返回一个Color
        public static Color QualityReturnColor(int ItenQuality)
        {
            Color color = new Color(1, 1, 1);
            switch (ItenQuality)
            {
                case 1:
                    color = new Color(1, 1, 1);
                    break;
                case 2:
                    color = new Color(0, 1, 0);
                    break;
                case 3:
                    color = new Color(0.047f, 0.76f, 0.847f);
                    break;

                case 4:
                    color = new Color(0.937f, 0.5f, 1.0f);
                    break;
                case 5:
                    color = new Color(1, 0.49f, 0);
                    break;
                case 6:
                    color = new Color(245f / 255f, 43f / 255f, 96f / 255f);
                    break;
            }

            return color;
        }

        //weizhi 0 -12
        public static int GetItemSubtypeByWeizhi(int weizhi)
        {
            if (weizhi < 4)
            {
                return weizhi + 1;
            }

            if (weizhi == 4 || weizhi == 5 || weizhi == 6)
            {
                return 5;
            }

            if (weizhi > 6)
            {
                return weizhi - 1;
            }

            return weizhi;
        }
    }
}