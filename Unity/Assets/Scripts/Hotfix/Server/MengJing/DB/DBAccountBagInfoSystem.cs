

namespace ET.Server
{

    [FriendOf(typeof(DBAccountBagInfo))]
    public static partial class DBAccountBagInfoSystem
    {

        public static int HaveItemById( this DBAccountBagInfo self, long bagInfoId)
        {
            for (int i = 0; i < self.BagInfoList.Count; i++)
            {
                if (self.BagInfoList[i].BagInfoID == bagInfoId)
                {
                    return i;
                }
            }
            return -1;
        }

    }

}