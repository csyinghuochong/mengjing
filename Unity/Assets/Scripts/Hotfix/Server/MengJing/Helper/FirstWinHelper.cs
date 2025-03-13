using System.Collections.Generic;

namespace ET.Server
{
    public static class FirstWinHelper
    {
        
        public static int GetFirstWinID(int bossId, int difficulty = 1)
        {
            FirstWinConfigCategory.Instance.FirstWinList.TryGetValue(bossId, out List<int> firstWinConfigs);
            if (firstWinConfigs == null)
            {
                return 0;
            }
            return firstWinConfigs[0];
        }

        public static  void SendFirstWinInfo(Unit player, Unit boss, int difficulty = 1)
        {
            if (difficulty == 0)
            {
                Log.Info("SendFirstWinInfo:  difficulty == 0");
                difficulty = 1;
            }
            int firstwinid = GetFirstWinID(boss.ConfigId, difficulty);
            if (firstwinid == 0)
            {
                return;
            }
            UserInfoComponentS userInfo =  player.GetComponent<UserInfoComponentS>();
            FirstWinInfo firstWinInfo = FirstWinInfo.Create();
            firstWinInfo.FirstWinId = firstwinid;
            firstWinInfo.KillTime = TimeHelper.ServerNow();
            firstWinInfo.UserId = userInfo.Id;
            firstWinInfo.PlayerName = userInfo.GetName();
            firstWinInfo.Difficulty = difficulty;
            
            ActorId chargeServerId = UnitCacheHelper.GetActivityServerId(player.Zone());
            M2A_FirstWinInfoMessage message = M2A_FirstWinInfoMessage.Create();
            message.FirstWinInfo = firstWinInfo;
            player.Root().GetComponent<MessageSender>().Send(chargeServerId, message);
           
        }
    }
}