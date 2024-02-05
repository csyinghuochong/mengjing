

namespace ET.Server
{

    [FriendOf(typeof(DBAccountInfo))]
    public static partial class DBAccountInfoSystem
    {

        public static int HaveItemById( this DBAccountInfo self, long bagInfoId)
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