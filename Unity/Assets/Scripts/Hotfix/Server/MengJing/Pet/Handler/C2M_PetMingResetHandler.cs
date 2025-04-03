namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMingResetHandler : MessageLocationHandler<Unit, C2M_PetMingResetRequest, M2C_PetMingResetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMingResetRequest request, M2C_PetMingResetResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.PetMineReset) >= 3)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();   
            if (userInfoComponent.UserInfo.Diamond < 350)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }
            int sceneid = BattleHelper.GetSceneIdByType( MapTypeEnum.PetMing );
            numericComponent.ApplyChange( NumericType.PetMineReset, 1);
            userInfoComponent.UpdateRoleData( UserDataType.Diamond,  "-350");
            userInfoComponent.AddFubenTimes(sceneid, 5);
            
            await ETTask.CompletedTask;
        }
    }
}
