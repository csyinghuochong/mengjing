using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_FubenTimesResetHandler : MessageLocationHandler<Unit, C2M_FubenTimesResetRequest, M2C_FubenTimesResetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FubenTimesResetRequest request, M2C_FubenTimesResetResponse response)
        {
            if (request.SceneType != SceneTypeEnum.PetTianTi)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.FubenTimesReset) >= 3)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (!bagComponent.OnCostItemData($"3;200"))
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }
            int sceneId = BattleHelper.GetSceneIdByType(request.SceneType);
            numericComponent.ApplyChange(null, NumericType.FubenTimesReset, 1, 0);
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            userInfoComponent.ClearFubenTimes(sceneId);
            
            await ETTask.CompletedTask;
        }
    }
}
