using System;

namespace ET.Server
{

    [MessageHandler(SceneType.PaiMai)]
    public class C2M_ChangeOccTwoHandler : MessageLocationHandler<Unit, C2M_ChangeOccTwoRequest, M2C_ChangeOccTwoResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ChangeOccTwoRequest request, M2C_ChangeOccTwoResponse response)
        {
            //判断当前角色等级是否达到
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv < 18) 
            {
                response.Error = ErrorCode.ERR_Occ_Hint_1;
                return;
            }

            int OccTwo = unit.GetComponent<UserInfoComponentS>().UserInfo.OccTwo;
            ////判断当前角色是否已经进行转职
            if (OccTwo != 0 )
            {
                response.Error = ErrorCode.ERR_Occ_Hint_2;
                return;
            }

            if (!OccupationTwoConfigCategory.Instance.Contain(request.OccTwoID))
            {
                Log.Error($"C2M_ChangeOccTwoRequest.1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            unit.GetComponent<SkillSetComponentS>().OnChangeOccTwoRequest(request.OccTwoID);
            unit.GetComponent<TaskComponentS>().OnChangeOccTwo();

            //if (OccTwo == 0 && !GMHelp.GmAccount.Contains(unit.GetComponent<UserInfoComponent>().Account))
            if (OccTwo == 0)
            {
                string userName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                string noticeContent = $"{userName} 在主城转职大师处成功转职:<color=#C4FF00>{OccupationTwoConfigCategory.Instance.Get(request.OccTwoID).OccupationName}</color>";
                BroadMessageHelper.SendBroadMessage(unit.Root(), NoticeType.Notice, noticeContent);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
