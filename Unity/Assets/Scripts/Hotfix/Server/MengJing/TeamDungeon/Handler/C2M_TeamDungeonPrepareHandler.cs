using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TeamDungeonPrepareHandler : MessageLocationHandler<Unit, C2M_TeamDungeonPrepareRequest, M2C_TeamDungeonPrepareResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamDungeonPrepareRequest request, M2C_TeamDungeonPrepareResponse response)
        {
	        Console.WriteLine($"C2M_TeamDungeonPrepareRequest : {unit.Id}  {request.Prepare} {request.TeamInfo.SceneType}");
			int sceneid = request.TeamInfo.SceneId;
			if (sceneid == 0)
			{
				return;
			}

			UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
			switch (request.TeamInfo.SceneType)
			{
				case MapTypeEnum.TeamDungeon:
					SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
					if (sceneConfig.DayEnterNum > 0 && sceneConfig.DayEnterNum <= userInfoComponent.GetSceneFubenTimes(sceneid))
					{
						response.Error = ErrorCode.ERR_TimesIsNot;
						return;
					}
					break;
				case MapTypeEnum.DragonDungeon:
					break;
				default:
					break;
			}
			

			int errorcode = ErrorCode.ERR_Success;
			//判断队长是否有深渊票
			Unit leader = unit.GetParent<UnitComponent>().Get(request.TeamInfo.TeamId);
			if (leader != null)
			{
				BagComponentS bagComponent = leader.GetComponent<BagComponentS>();
				if (request.TeamInfo.FubenType == TeamFubenType.ShenYuan && bagComponent.GetItemNumber(ConfigData.ShenYuanCostId) < 1)
				{
					errorcode = ErrorCode.Err_ShenYuanItemError;
				}
                //if (request.FubenType == TeamFubenType.Normal)
                //{
                //    float value = RandomHelper.RandFloat01();
                //    if (value <= 0.05f)
                //    {
                //        request.FubenType = TeamFubenType.ShenYuan;
                //    }
                //}
            }

			//判断副本次数
			ActorId teamServerId = UnitCacheHelper.GetTeamServerId(unit.Zone());
			M2T_TeamDungeonPrepareRequest M2T_TeamDungeonPrepareRequest = M2T_TeamDungeonPrepareRequest.Create();
			M2T_TeamDungeonPrepareRequest.TeamId = request.TeamInfo.TeamId;
			M2T_TeamDungeonPrepareRequest.UnitID = unit.Id;
			M2T_TeamDungeonPrepareRequest.Prepare = request.Prepare;
			M2T_TeamDungeonPrepareRequest.ErrorCode = errorcode;
			T2M_TeamDungeonPrepareResponse createResponse = (T2M_TeamDungeonPrepareResponse)await unit.Root().GetComponent<MessageSender>().Call(teamServerId, M2T_TeamDungeonPrepareRequest);

			await ETTask.CompletedTask;
        }
    }
}
