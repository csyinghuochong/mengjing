using System.Collections.Generic;

namespace ET.Server
{
    //游戏设置
    [MessageHandler(SceneType.Map)]
    public class C2M_GameSettingHandler : MessageLocationHandler<Unit, C2M_GameSettingRequest, M2C_GameSettingResponse>
    {
		protected override async ETTask Run(Unit unit, C2M_GameSettingRequest request, M2C_GameSettingResponse response)
		{
			//读取数据库
			UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;

			for (int i = 0; i < request.GameSettingInfos.Count; i++)
			{
				bool exist = false;

				if (request.GameSettingInfos[i].KeyId == (int)GameSettingEnum.AttackMode)
				{
					unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.AttackMode, int.Parse(request.GameSettingInfos[i].Value));

					List<EntityRef<Unit>> unitlist = unit.GetParent<UnitComponent>().GetAll();
                    for (int u = 0; u < unitlist.Count; u++)
                    {
	                    Unit unititem = unitlist[i];
						if (unititem.GetMasterId() == unit.Id)
						{
							unititem.GetComponent<NumericComponentS>().ApplyValue(NumericType.AttackMode, int.Parse(request.GameSettingInfos[i].Value));
                        }
					}
				}
				if (request.GameSettingInfos[i].KeyId == (int)GameSettingEnum.FirstUnionName)
				{
					//1显示公会称号 2其他称号
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.FirstUnionName, int.Parse(request.GameSettingInfos[i].Value));
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

			await ETTask.CompletedTask;
		}
	}
}
