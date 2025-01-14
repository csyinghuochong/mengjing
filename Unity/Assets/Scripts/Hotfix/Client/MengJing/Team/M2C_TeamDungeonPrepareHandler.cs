using System;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonPrepareHandler : MessageHandler<Scene, M2C_TeamDungeonPrepareResult>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonPrepareResult message)
        {
            //刷新ui
            EventSystem.Instance.Publish(root, new RecvTeamDungeonPrepare() { m2CTeamDungeonPrepareResult = message });
            
            if (message.ErrorCode != ErrorCode.ERR_Success)
            {
               return;
            }
    
            //所有人都准备好了
            await root.GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(0, 1000));
            
            //组队副本sceneid = 0;
            EnterMapHelper.RequestTransfer(root, (int)message.TeamInfo.SceneType, 0).Coroutine();
        }
    }
}