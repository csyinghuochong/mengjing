using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_OneChallengeHandler : MessageLocationHandler<Unit, C2M_OneChallengeRequest, M2C_OneChallengeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_OneChallengeRequest request, M2C_OneChallengeResponse response)
        {
            Unit other = unit.GetParent<UnitComponent>().Get(request.OtherId);
            if (other == null)
            {
                response.Error = ErrorCode.ERR_OtherNotExist;

                return;
            }
            if (unit.Scene().GetComponent<MapComponent>().MapType != MapTypeEnum.MainCityScene)
            {
                response.Error = ErrorCode.ERR_OtherNotExist;
                return;
            }

            if (request.Operatate == 1)  //发起挑战
            {
                M2C_OneChallenge m2CCreateUnits = M2C_OneChallenge.Create();
                m2CCreateUnits.Operatate = 1;
                m2CCreateUnits.OtherId = unit.Id;
                m2CCreateUnits.OtherName = unit.GetComponent<UserInfoComponentS>().UserName;
                MapMessageHelper.SendToClient(other, m2CCreateUnits);
            }
            if (request.Operatate == 2) //迎接挑战
            {
                long fubenid = IdGenerater.Instance.GenerateInstanceId();
                List<Unit> allUnits = new List<Unit> { unit, other };
                M2C_OneChallenge m2CCreateUnits = M2C_OneChallenge.Create();
                m2CCreateUnits.Operatate = 2;
                m2CCreateUnits.OtherId = fubenid;
                MapMessageHelper.SendToClient(allUnits, m2CCreateUnits);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
