namespace ET
{
    public static class LongYinHelper
    {
        /// <summary>
        /// 龙印节点在预制体中的编号(如1001)转配置id
        /// </summary>
        public static int GetLongYinId(int occ, int index)
        {
            return occ * 10000 + index;
        }
    }
}
