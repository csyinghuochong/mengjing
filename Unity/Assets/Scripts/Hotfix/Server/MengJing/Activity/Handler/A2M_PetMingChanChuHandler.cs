namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class A2M_PetMingChanChuHandler : MessageHandler<Unit, A2M_PetMingChanChuRequest, M2A_PetMingChanChuResponse>
    {
        protected override async ETTask Run(Unit unit, A2M_PetMingChanChuRequest request, M2A_PetMingChanChuResponse response)
        {
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Gold, request.ChanChu.ToString());
  
            await ETTask.CompletedTask;
        }
    }
}
