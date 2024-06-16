namespace ET
{

    public struct DropItemInfo
    {
        public int Weight;
        public int ItemID;
        public int MinNumber;
        public int MaxNumber;

        public DropItemInfo(int weight, int itemid, int min, int max)
        {
            this.Weight = weight;
            this.ItemID = itemid;
            this.MinNumber = min;
            this.MaxNumber = max;
        }
    }
}