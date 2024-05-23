using System;
using ET;

namespace ET.Server
{

    [EntitySystemOf(typeof(FangChenMiComponentS))]
    [FriendOf(typeof(FangChenMiComponentS))]
    public static partial class FangChenMiComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.FangChenMiComponentS self)
        {

        }
        
        public static async ETTask CheckHoliday(this FangChenMiComponentS self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            self.IsHoliday = await HttpHelper.IsHolidayByDate(dateTime);
        }
    }

}