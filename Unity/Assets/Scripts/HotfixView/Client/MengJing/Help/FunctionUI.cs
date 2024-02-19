namespace ET.Client
{
    public static class FunctionUI
    {
        /// <summary>
        /// 根据品质返回品质字符串
        /// 根据道具品质返回对应的品质框
        /// ItemQuality  道具品质
        /// </summary>
        /// <param name="ItemQuality"></param>
        /// <returns></returns>
        public static string ItemQualiytoPath(int ItemQuality)
        {
            string path = "";
            switch (ItemQuality)
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
    }
}