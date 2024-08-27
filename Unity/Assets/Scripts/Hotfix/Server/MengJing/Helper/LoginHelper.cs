using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    public static class LoginHelper
    {
        public static void OnLogin(this Unit unit, string remoteIp, string deviceName)
        {
            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = userInfoComponentS.UserInfo;
            
            long currentTime = TimeHelper.ServerNow();

            DateTime dateTime = TimeInfo.Instance.ToDateTime(currentTime);
            long lastLoginTime = userInfoComponentS.LastLoginTime;
            if (lastLoginTime != 0)
            {
                DateTime lastdateTime = TimeInfo.Instance.ToDateTime(lastLoginTime);
                if (dateTime.Day != lastdateTime.Day)
                {
                    Log.Debug($"OnZeroClockUpdate [登录刷新]: {unit.Id}");
                    float passhour = ((currentTime - lastLoginTime) * 1f / TimeHelper.Hour);
                    if (passhour >= 24f)
                    {
                        userInfoComponentS.RecoverPiLao(120, false);
                    }
                    else
                    {
                        List<int> indexids_1 = userInfoComponentS.GetTiLiIndexsNew(lastdateTime.Hour, 23);
                        List<int> indexids_2 = userInfoComponentS.GetTiLiIndexsNew(0, dateTime.Hour);
                        List<int> indexids = new List<int>();
                        indexids.Add(0);
                        indexids.AddRange(indexids_1);
                        indexids.AddRange(indexids_2);
                        if (indexids.Count > 0)
                        {
                            int recoverTili = userInfoComponentS.GetTiliRecover(indexids);
                            userInfoComponentS.RecoverPiLao(recoverTili, false);
                            string indexstr = $"{unit.Id}  two day : hour_1: {lastdateTime.Hour}  hour_2:{dateTime.Hour}   indexs: ";
                            for (int index = 0; index < indexids.Count; index++)
                            {
                                indexstr = indexstr + indexids[index].ToString() + "   ";
                            }
                            indexstr = indexstr + $"recover: {recoverTili}";
                            Log.Debug(indexstr);
                        }
                    }

                    userInfoComponentS.OnZeroClockUpdate(false);
                    unit.GetComponent<TaskComponentS>().CheckWeeklyUpdate(lastLoginTime, currentTime);
                    unit.GetComponent<TaskComponentS>().OnZeroClockUpdate(false);
                    unit.GetComponent<EnergyComponentS>().OnResetEnergyInfo();
                    unit.GetComponent<HeroDataComponentS>().OnZeroClockUpdate(false);
                    unit.GetComponent<ActivityComponentS>().OnZeroClockUpdate(userInfo.Lv);
                    unit.GetComponent<ChengJiuComponentS>().OnZeroClockUpdate();
                    unit.GetComponent<JiaYuanComponentS>().OnZeroClockUpdate(false);
                    unit.GetComponent<DataCollationComponent>().OnZeroClockUpdate(false);
                }
                else
                {
                    int hour_1, hour_2 = 0;
                    hour_1 = lastdateTime.Hour;
                    hour_2 = dateTime.Hour;
                  
                    List<int> indexids = userInfoComponentS.GetTiLiIndexsNew(hour_1, hour_2);
                    if (indexids.Count > 0)
                    { 
                        int recoverTili = userInfoComponentS.GetTiliRecover(indexids);
                        userInfoComponentS.RecoverPiLao(recoverTili, false);
                        string indexstr = $"{unit.Id}  one day  hour_1: {hour_1}  hour_2:{hour_2}   indexs: ";
                        for (int index = 0; index < indexids.Count; index++)
                        {
                            indexstr = indexstr + indexids[index].ToString() + "   ";
                        }
                        indexstr = indexstr + $"recover: {recoverTili}";
                        Log.Debug(indexstr);
                    }
                    
                    unit.GetComponent<JiaYuanComponentS>().OnLoginCheck(hour_1, hour_2);
                }
            }
            else
            {
                Log.Debug($"OnZeroClockUpdate [数据初始化]: {unit.Id}");
                unit.GetComponent<TaskComponentS>().OnZeroClockUpdate(false);
            }
            userInfoComponentS.OnLogin( remoteIp,  deviceName);
            unit.GetComponent<BagComponentS>().OnLogin(userInfo.RobotId);
            unit.GetComponent<TaskComponentS>().OnLogin(userInfo.RobotId);
            unit.GetComponent<HeroDataComponentS>().OnLogin(userInfo.RobotId);
            unit.GetComponent<DBSaveComponent>().OnLogin();
            unit.GetComponent<RechargeComponent>().OnLogin();
            unit.GetComponent<PetComponentS>().OnLogin();
            unit.GetComponent<ActivityComponentS>().OnLogin(userInfo.Lv);
            unit.GetComponent<TitleComponentS>().OnCheckTitle(false);
            unit.GetComponent<ChengJiuComponentS>().OnLogin(userInfo.Lv);
            unit.GetComponent<JiaYuanComponentS>().OnLogin();
            unit.GetComponent<SkillSetComponentS>().OnLogin(userInfo.Occ);
        }
    }
}