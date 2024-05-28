

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_CampRankSelectHandler : MessageLocationHandler<Unit, C2M_CampRankSelectRequest, M2C_CampRankSelectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_CampRankSelectRequest request, M2C_CampRankSelectResponse response)
        {
            unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.AcvitiyCamp, request.CampId );
            unit.GetComponent<UserInfoComponentS>().UpdateRankInfo();

            await ETTask.CompletedTask;
        }
    }
}