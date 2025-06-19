using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_RealNameHandler : MessageSessionHandler<C2R_RealNameRequest, R2C_RealNameResponse>
    {
        protected override async ETTask Run(Session session, C2R_RealNameRequest request, R2C_RealNameResponse response)
        {
            //session.RemoveComponent<SessionAcceptTimeoutComponent>();  5秒后自动销毁
            int zone = session.Root().Zone();
            if (request.AccountId == 0 ||  string.IsNullOrEmpty(request.IdCardNO) || string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RealNameFail;
                return;
            }

            long instanceid = session.InstanceId;
            using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount, request.AccountId))
            {
                if (instanceid != session.InstanceId)
                {
                    response.Error = ErrorCode.ERR_RealNameFail;
                    return;
                }

                DBCenterAccountInfo dbCenterAccountInfo =
                        (DBCenterAccountInfo)await UnitCacheHelper.GetComponent<DBCenterAccountInfo>(session.Root(), request.AccountId);
                if (dbCenterAccountInfo == null)
                {
                    response.Error = ErrorCode.ERR_RealNameFail;
                    return;
                }

                RealNameCode result_check = new RealNameCode();
                result_check.data = new RealNameData();
                result_check.data.result = new RealNameResult();
                using ListComponent<string> testCard = new ListComponent<string>();
                for (int i = 0; i < 34; i++)
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
                    await  UnitCacheHelper.SaveComponent(session.Root(), dbCenterAccountInfo.Id, dbCenterAccountInfo);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}