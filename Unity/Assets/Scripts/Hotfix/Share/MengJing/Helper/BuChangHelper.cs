using System;

namespace ET
{
    public static class BuChangHelper
    {
      
        public static KeyValuePairInt GetBuChangRecharge(PlayerInfo playerInfo)
        {

            KeyValuePairInt keyValuePairInt = new KeyValuePairInt();
            for (int i = 0; i < playerInfo.RechargeInfos.Count; i++)
            {
                RechargeInfo rechargeInfo = playerInfo.RechargeInfos[i];
                int zone = rechargeInfo.PhysicsZone;
                if (zone >= ConfigData.BuChangZone)
                {
                    continue;
                }
                
                keyValuePairInt.KeyId += rechargeInfo.Amount;
                keyValuePairInt.Value += ConfigHelper.GetDiamondNumber(rechargeInfo.Amount);
            }
            return keyValuePairInt;  
        }

        public static int ShowNewBuChang(PlayerInfo playerInfo, long unitid, int zone)
        {
            if (zone != ConfigData.BuChangZone)
            {
                return 0;
            }
            if (playerInfo.BuChangZone.Contains(zone))
            {
                return 0;
            }

            DateTime dateTime = TimeHelper.DateTimeNow();
            int time = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;
            if (time >= ConfigData.BuChangEnd)
            {
                return 0;
            }

            return GetBuChangRecharge(playerInfo).KeyId;
        }
    }
}