
using System;
using ET.Server;

namespace ET
{

    [MessageHandler(SceneType.Map)]
    public class G2M_ActivityUpdateHandler : MessageHandler<Unit, G2M_ActivityUpdate>
    {

        protected override async ETTask Run(Unit unit, G2M_ActivityUpdate message)
        {
            Console.WriteLine($"G2M_ActivityUpdateHandler:{unit.Id}   {message.ActivityType}");
            
            switch (message.ActivityType)
            {
                case 0:
                    Log.Debug($"OnZeroClockUpdate [零点刷新]: {unit.Id}");
                    UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
                    unit.GetComponent<UserInfoComponentS>().OnZeroClockUpdate(true);
                    unit.GetComponent<HeroDataComponentS>().OnZeroClockUpdate(true);
                    unit.GetComponent<EnergyComponentS>().OnZeroClockUpdate();
                    unit.GetComponent<UserInfoComponentS>().OnHourUpdate(0, true);
                    unit.GetComponent<TaskComponentS>().CheckWeeklyUpdate();
                    unit.GetComponent<TaskComponentS>().OnZeroClockUpdate(true);
                    unit.GetComponent<ActivityComponentS>().OnZeroClockUpdate(userInfo.Lv);
                    unit.GetComponent<ChengJiuComponentS>().OnZeroClockUpdate();
                    unit.GetComponent<JiaYuanComponentS>().OnZeroClockUpdate(true);
                    unit.GetComponent<DataCollationComponent>().OnZeroClockUpdate(true);
                    break;
                case -1:
                    Log.Debug($"OnZeroClockUpdate防止卡死 [-1]");
                    
                    break;
                default:
                    
                    unit.GetComponent<UserInfoComponentS>().OnHourUpdate(message.ActivityType, true);
                    break;
            }
   
            await ETTask.CompletedTask;
        }
    }
}
