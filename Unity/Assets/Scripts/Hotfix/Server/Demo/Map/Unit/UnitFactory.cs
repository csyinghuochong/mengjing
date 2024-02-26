using System;
using Unity.Mathematics;
using System.Collections.Generic;

namespace ET.Server
{
    
    [FriendOf(typeof(UserInfoComponentServer))]
    public static partial class UnitFactory
    {
        public static Unit Create(Scene scene, long id, int unitType,CreateRoleInfo createRoleInfo, string account, long accountId)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);
                    unit.Type = UnitType.Player;
                    if (unit.GetComponent<NumericComponentServer>() ==  null)
                    {
                        NumericComponentServer numericComponentServer = unit.AddComponent<NumericComponentServer>();
                        numericComponentServer.Set(NumericType.Speed, 6f); // 速度是6米每秒
                        numericComponentServer.Set(NumericType.AOI, 15000); // 视野15米
                    }

                    if (unit.GetComponent<UserInfoComponentServer>() == null)
                    {
                        
                        UserInfoComponentServer userInfoComponent = unit.AddComponent<UserInfoComponentServer>();
                        userInfoComponent.Account = account;
                        UserInfo userInfo = userInfoComponent.UserInfo;
                        userInfo.Sp = 1;
                        userInfo.UserId = id;
                        userInfo.BaoShiDu = 100;
                        userInfo.JiaYuanLv = 10001;
                        userInfo.JiaYuanFund = 10000;
                        userInfo.AccInfoID = accountId;
                        userInfo.Name = "";
                        userInfo.ServerMailIdCur = -1;
                        userInfo.PiLao = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);        //初始化疲劳
                        userInfo.Vitality = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);
                        userInfo.MakeList.AddRange(ComHelp.StringArrToIntList(GlobalValueConfigCategory.Instance.Get(18).Value.Split(';')));
                        userInfo.CreateTime = TimeHelper.ServerNow();

                        if (createRoleInfo.RobotId > 0)
                        {
                            int robotId = createRoleInfo.RobotId;
                            RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
                            userInfo.Lv = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(10, 19) : robotConfig.Level;
                            userInfo.Occ = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(1, 3) : robotConfig.Occ;
                            userInfo.Gold = 100000;
                            userInfo.RobotId = robotId;
                            //userInfo.OccTwo = robotConfig.OccTwo;
                        }
                        else
                        {
                            userInfo.Lv = 1;
                            userInfo.Gold = 0;
                            userInfo.SeasonLevel = 1;
                            userInfo.Occ = createRoleInfo.PlayerOcc;
                        }
                    }

                    if (unit.GetComponent<BagComponentServer>() == null)
                    {
                        unit.AddComponent<BagComponentServer>();
                    }
                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}