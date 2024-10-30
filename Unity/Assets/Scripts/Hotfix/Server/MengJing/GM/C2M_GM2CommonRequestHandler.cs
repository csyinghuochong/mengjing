using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GM2CommonRequestHandler : MessageLocationHandler<Unit, C2M_GM2CommonRequest, M2C_GM2CommonResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GM2CommonRequest request, M2C_GM2CommonResponse response)
        {
            string account = unit.GetComponent<UserInfoComponentS>().Account;
            if (!GMData.GmAccount.Contains(account))
            {
                response.Error = ErrorCode.ERR_GMError;
                return;
            }
            string[] infoList = request.Context.Split(" ");
            
            if (infoList[0] == ConsoleMode.ReloadDll)  //R 0 0    R 1 0 /  R 1 ActivityConfig
            {
                ConsoleHelper.ReloadDllConsoleHandler(unit.Root(), request.Context).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}