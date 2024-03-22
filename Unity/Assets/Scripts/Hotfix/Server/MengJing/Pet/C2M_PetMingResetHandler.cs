using System;


namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMingResetHandler : MessageLocationHandler<Unit, C2M_PetMingResetRequest, M2C_PetMingResetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMingResetRequest request, M2C_PetMingResetResponse response)
        {
            NumericComponent_S numericComponent = unit.GetComponent<NumericComponent_S>();
            if (numericComponent.GetAsInt(NumericType.PetMineReset) >= 3)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            UserInfoComponent_S userInfoComponent = unit.GetComponent<UserInfoComponent_S>();   
            if (userInfoComponent.UserInfo.Diamond < 350)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }
            int sceneid = BattleHelper.GetSceneIdByType( SceneTypeEnum.PetMing );
            numericComponent.ApplyChange( null, NumericType.PetMineReset, 1, 0 );
            userInfoComponent.UpdateRoleData( UserDataType.Diamond,  "-350");
            userInfoComponent.AddFubenTimes(sceneid, 5);
            
            await ETTask.CompletedTask;
        }
    }
}
