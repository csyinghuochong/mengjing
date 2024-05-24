﻿using System;
using System.Collections.Generic;

namespace ET
{
    //游戏设置
    [ActorMessageHandler]
    public class C2M_GameSettingHandler : AMActorLocationRpcHandler<Unit, C2M_GameSettingRequest, M2C_GameSettingResponse>
    {
		protected override async ETTask Run(Unit unit, C2M_GameSettingRequest request, M2C_GameSettingResponse response, Action reply)
		{
			//读取数据库
			UserInfo userInfo = unit.GetComponent<UserInfoComponent>().GetUserInfo();

			for (int i = 0; i < request.GameSettingInfos.Count; i++)
			{
				bool exist = false;

				if (request.GameSettingInfos[i].KeyId == (int)GameSettingEnum.AttackMode)
				{
					unit.GetComponent<NumericComponent>().ApplyValue(NumericType.AttackMode, int.Parse(request.GameSettingInfos[i].Value));

					List<Unit> unitlist = unit.GetParent<UnitComponent>().GetAll();
                    for (int u = 0; u < unitlist.Count; u++)
					{
						if (unitlist[u].MasterId == unit.Id)
						{
                            unitlist[u].GetComponent<NumericComponent>().ApplyValue(NumericType.AttackMode, int.Parse(request.GameSettingInfos[i].Value));
                        }
					}
				}
				if (request.GameSettingInfos[i].KeyId == (int)GameSettingEnum.FirstUnionName)
				{
					//1显示家族称号 2其他称号
                    unit.GetComponent<NumericComponent>().ApplyValue(NumericType.FirstUnionName, int.Parse(request.GameSettingInfos[i].Value));
                }

                for (int k = 0; k < userInfo.GameSettingInfos.Count; k++)
				{
					if (userInfo.GameSettingInfos[k].KeyId == request.GameSettingInfos[i].KeyId)
					{
						exist = true;
						userInfo.GameSettingInfos[k].Value = request.GameSettingInfos[i].Value;
						break;
					}
				}
				if (!exist)
				{
					userInfo.GameSettingInfos.Add(request.GameSettingInfos[i]);
				}
			}
			reply();
			await ETTask.CompletedTask;
		}
	}
}
