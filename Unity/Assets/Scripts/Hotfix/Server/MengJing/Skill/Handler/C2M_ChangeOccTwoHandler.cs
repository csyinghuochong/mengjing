namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(SkillSetComponentS))]
    public class C2M_ChangeOccTwoHandler : MessageLocationHandler<Unit, C2M_ChangeOccTwoRequest, M2C_ChangeOccTwoResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ChangeOccTwoRequest request, M2C_ChangeOccTwoResponse response)
        {
            //判断当前角色等级是否达到
            if (unit.GetComponent<UserInfoComponentS>().GetUserLv() < 18) 
            {
                response.Error = ErrorCode.ERR_Occ_Hint_1;
                return;
            }

            int OccTwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
            //判断当前角色是否已经进行转职
            if (OccTwo != 0)
            {
                response.Error = ErrorCode.ERR_Occ_Hint_2;
                return;
            }

            unit.GetComponent<SkillSetComponentS>().OnChangeOccTwoRequest(request.OccTwoID);
            unit.GetComponent<TaskComponentS>().OnChangeOccTwo();
            await ETTask.CompletedTask;
        }
    }
}