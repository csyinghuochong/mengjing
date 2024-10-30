using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    
    public static class ConsoleHelper
    {
    
        public static async ETTask<int> ReloadDllConsoleHandler(Scene root,  string content)
        {
            await ETTask.CompletedTask;
            string[] ss = content.Split(" ");

            //R 0 0    R 1 0 /  R 1 ActivityConfig
            if (ss.Length != 3)
            {
                return ErrorCode.ERR_Parameter;
            }

            //Game.EventSystem.Add(DllHelper.GetHotfixAssembly());
            //Game.EventSystem.Load();

            A2A_BroadcastProcessRequest A2A_BroadcastRequest = A2A_BroadcastProcessRequest.Create();
            A2A_BroadcastRequest.LoadType = 3;
            A2A_BroadcastRequest.LoadValue = content;
            BroadCastHelper.BroadcastProcess(root, A2A_BroadcastRequest ).Coroutine();

            return ErrorCode.ERR_Success;
        }
        
    }
}
