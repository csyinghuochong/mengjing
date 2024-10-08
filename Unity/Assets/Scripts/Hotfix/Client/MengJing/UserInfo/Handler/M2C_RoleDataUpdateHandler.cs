namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [MessageHandler(SceneType.Demo)]
    public class M2C_RoleDataUpdateHandler : MessageHandler<Scene, M2C_RoleDataUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_RoleDataUpdate message)
        {
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            string updateValue = "0";
            long changeValue = 0;

            switch (message.UpdateType)
            {
                case (int)UserDataType.Name:
                    userInfo.Name = message.UpdateTypeValue;
                    updateValue = message.UpdateTypeValue;
                    break;
                case UserDataType.BuffSkill:
                    EventSystem.Instance.Publish(root, new UpdateUserBuffSkill() { UpdateValue = message.UpdateValueLong });
                    updateValue = string.Empty;
                    break;
                case (int)UserDataType.Exp:
                    long curExp = message.UpdateValueLong;
                    changeValue = curExp - userInfo.Exp;
                    userInfo.Exp = curExp;
                    EventSystem.Instance.Publish(root, new UpdateUserDataExp() { ChangeValue = changeValue, UpdateValue = message.UpdateValueLong });
                    updateValue = string.Empty;
                    break;
                case (int)UserDataType.PiLao:
                    long curpilao = long.Parse(message.UpdateTypeValue);
                    changeValue = curpilao - userInfo.PiLao;
                    userInfo.PiLao = curpilao;
                    EventSystem.Instance.Publish(root, new UpdateUserDataPiLao() { UpdateValue = message.UpdateValueLong });
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
                case (int)UserDataType.Lv:
                    userInfo.Lv = int.Parse(message.UpdateTypeValue);
                    EventSystem.Instance.Publish(root, new UpdateUserDataLv() { UpdateValue = userInfo.Lv });
                    break;
                case (int)UserDataType.Gold:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.Gold).ToString();
                    userInfo.Gold = long.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.RongYu:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.RongYu).ToString();
                    userInfo.RongYu = long.Parse(message.UpdateTypeValue);
                    break;
                case (int)UserDataType.Diamond:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.Diamond).ToString();
                    userInfo.Diamond = long.Parse(message.UpdateTypeValue);
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
                case (int)UserDataType.TalentPoints:
                    updateValue = (long.Parse(message.UpdateTypeValue) - userInfo.TalentPoints).ToString();
                    userInfo.TalentPoints = int.Parse(message.UpdateTypeValue);
                    break;
                default:
                    updateValue = message.UpdateTypeValue;
                    break;
            }

            //发送监听,更新当前信息显示...
            //更新比较频繁的单独处理
            if (!string.IsNullOrEmpty(updateValue))
            {
                EventSystem.Instance.Publish(root, new UpdateUserData() { DataParamString = $"{message.UpdateType}_{updateValue}" });
            }

            await ETTask.CompletedTask;
        }
    }
}