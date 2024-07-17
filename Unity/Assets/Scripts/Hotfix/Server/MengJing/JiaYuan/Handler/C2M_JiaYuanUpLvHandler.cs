namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanUpLvHandler : MessageLocationHandler<Unit, C2M_JiaYuanUpLvRequest, M2C_JiaYuanUpLvResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanUpLvRequest request, M2C_JiaYuanUpLvResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            int lvid = userInfoComponent.UserInfo.JiaYuanLv;
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(lvid);
            if (jiaYuanConfig.NextID == 0)
            {
                return;
            }
            if (userInfoComponent.UserInfo.Lv < jiaYuanConfig.NeedRoseLv)
            {
                response.Error = ErrorCode.ERR_LevelIsNot;
                return;
            }
            if (userInfoComponent.UserInfo.JiaYuanExp < jiaYuanConfig.Exp)
            {
                response.Error = ErrorCode.ERR_ExpNoEnough;
                return;
            }

            userInfoComponent.UpdateRoleData(UserDataType.JiaYuanExp, (jiaYuanConfig.Exp * -1).ToString());
            userInfoComponent.UpdateRoleData(UserDataType.JiaYuanLv, "1");
            await ETTask.CompletedTask;
        }
    }
}
