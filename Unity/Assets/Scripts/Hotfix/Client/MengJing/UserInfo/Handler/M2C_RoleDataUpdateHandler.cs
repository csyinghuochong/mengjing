﻿namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponent_C))]
    [MessageHandler(SceneType.Demo)]
    public class M2C_RoleDataUpdateHandler: MessageHandler<Scene, M2C_RoleDataUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_RoleDataUpdate message)
        {
            UserInfo userInfo = root.GetComponent<UserInfoComponent_C>().UserInfo;
            string updateValue = "0";
            long longValue = 0;

            switch (message.UpdateType)
            {
                //更新角色名称
                case (int)UserDataType.Name:
                    userInfo.Name = message.UpdateTypeValue;
                    updateValue = message.UpdateTypeValue;
                    break;
                //一次性技能
                case UserDataType.BuffSkill:
                    // HintHelp.GetInstance().DataUpdate(DataType.UpdateUserBuffSkill, "", message.UpdateValueLong);
                    updateValue = string.Empty;
                    break;
                //更新经验值
                case (int)UserDataType.Exp:
                    //updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.Exp).ToString();
                    long curExp = message.UpdateValueLong;
                    longValue = curExp - userInfo.Exp;
                    userInfo.Exp = curExp;
                    // HintHelp.GetInstance().DataUpdate(DataType.UpdateUserDataExp, "", longValue);
                    updateValue = string.Empty;
                    break;
                //更新疲劳
                case (int)UserDataType.PiLao:
                    //updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.PiLao).ToString();
                    long curpilao = long.Parse(message.UpdateTypeValue);
                    longValue = curpilao - userInfo.PiLao;
                    userInfo.PiLao = curpilao;

                    // HintHelp.GetInstance().DataUpdate(DataType.UpdateUserDataPiLao, "", longValue);
                    updateValue = string.Empty;
                    break;
                case (int)UserDataType.SeasonLevel:
                    userInfo.SeasonLevel = int.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.SeasonExp:
                    userInfo.SeasonExp = int.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.SeasonCoin:
                    userInfo.SeasonCoin = int.Parse(message.UpdateTypeValue);
                    break;
                //更新等级
                case (int)UserDataType.Lv:
                    userInfo.Lv = int.Parse(message.UpdateTypeValue);
                    break;
                //更新金币
                case (int)UserDataType.Gold:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.Gold).ToString();
                    userInfo.Gold = long.Parse(message.UpdateTypeValue);

                    EventSystem.Instance.Publish(root, new UserDataTypeUpdate_Gold());
                    break;
                case (int)UserDataType.RongYu:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.RongYu).ToString();
                    userInfo.RongYu = long.Parse(message.UpdateTypeValue);
                    break;
                //更新钻石
                case (int)UserDataType.Diamond:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.Diamond).ToString();
                    userInfo.Diamond = long.Parse(message.UpdateTypeValue);

                    EventSystem.Instance.Publish(root, new UserDataTypeUpdate_Diamond());
                    break;
                case (int)UserDataType.DungeonTimes:
                    userInfo.DayFubenTimes.Clear();
                    break;
                case (int)UserDataType.HuoYue:
                    break;
                case (int)UserDataType.Sp:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.Sp).ToString();
                    userInfo.Sp = int.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.UnionName:
                    userInfo.UnionName = message.UpdateTypeValue;
                    break;
                case (int)UserDataType.DemonName:
                    userInfo.DemonName = message.UpdateTypeValue;
                    break;
                case (int)UserDataType.StallName:
                    userInfo.StallName = message.UpdateTypeValue;
                    break;
                case (int)UserDataType.Combat:
                    userInfo.Combat = int.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.Vitality:
                    updateValue = (int.Parse(message.UpdateTypeValue) - userInfo.Vitality).ToString();
                    userInfo.Vitality = int.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.BaoShiDu:
                    updateValue = (int.Parse(message.UpdateTypeValue) - userInfo.BaoShiDu).ToString();
                    userInfo.BaoShiDu = int.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.JiaYuanFund:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.JiaYuanFund).ToString();
                    userInfo.JiaYuanFund = long.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.UnionContri:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.UnionZiJin).ToString();
                    userInfo.UnionZiJin = long.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.JiaYuanExp:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.JiaYuanExp).ToString();
                    userInfo.JiaYuanExp = long.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.JiaYuanLv:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.JiaYuanLv).ToString();
                    userInfo.JiaYuanLv = int.Parse(message.UpdateTypeValue);
                    break;
                default:
                    updateValue = message.UpdateTypeValue;
                    break;
            }

            //发送监听,更新当前信息显示...
            //更新比较频繁的单独处理
            if (!string.IsNullOrEmpty(updateValue))
            {
                // HintHelp.GetInstance().DataUpdate(DataType.UpdateUserData, $"{message.UpdateType}_{updateValue}");
            }

            await ETTask.CompletedTask;
        }
    }
}