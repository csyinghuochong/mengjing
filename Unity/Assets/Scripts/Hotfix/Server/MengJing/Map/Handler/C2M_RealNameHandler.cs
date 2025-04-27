using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RealNameHandler: MessageLocationHandler<Unit, C2M_RealNameRequest, M2C_RealNameResponse>
    {
        protected override async ETTask Run(Unit unit,  C2M_RealNameRequest request, M2C_RealNameResponse response)
        {
            
            if (request.AccountId == 0 ||  string.IsNullOrEmpty(request.IdCardNO) || string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RealNameFail;
                return;
            }

            int dbzone = 1000;
              DBCenterAccountInfo dbCenterAccountInfo =
                        (DBCenterAccountInfo)await UnitCacheHelper.GetComponent<DBCenterAccountInfo>(unit.Root(), request.AccountId, dbzone);
                if (dbCenterAccountInfo == null)
                {
                    response.Error = ErrorCode.ERR_RealNameFail;
                    return;
                }

                RealNameCode result_check = new RealNameCode();
                result_check.data = new RealNameData();
                result_check.data.result = new RealNameResult();
                using ListComponent<string> testCard = new ListComponent<string>();
                for (int i = 0; i < 30; i++)
                {
                    testCard.Add($"400001{1990 + i}01012996");
                }
                testCard.Add("500233200809108742");
                if (testCard.Contains(request.IdCardNO))
                {
                    result_check.errcode = 0;
                    result_check.data.result.status = 0;
                }
                else
                {
                    string ai = request.AccountId + "_";
                    if (ai.Length < 32)
                    {
                        for (int i = ai.Length; i < 32; i++)
                        {
                            ai += "a";
                        }
                    }
       
                    result_check = await FangchenmiHelper.OnDoFangchenmi_2(request.IdCardNO, request.Name );
                }
                
                if (result_check == null || result_check.data == null || result_check.data.result == null)
                {
                    response.Error = ErrorCode.ERR_RealNameFail;
                    return;
                }
                
                Console.WriteLine($"result_check: {result_check.ToString()}");
                if (result_check.errcode == 0 && result_check.data.result.status == 0) //认证成功
                {
                    dbCenterAccountInfo.PlayerInfo.Name = request.Name;
                    dbCenterAccountInfo.PlayerInfo.IdCardNo = request.IdCardNO;
                    dbCenterAccountInfo.PlayerInfo.RealName = 1;
                    response.PlayerInfo = dbCenterAccountInfo.PlayerInfo;
                    await  UnitCacheHelper.SaveComponent(unit.Root(), dbCenterAccountInfo.Id, dbCenterAccountInfo, dbzone);
                }
                
            await ETTask.CompletedTask;
        }
    }
}

