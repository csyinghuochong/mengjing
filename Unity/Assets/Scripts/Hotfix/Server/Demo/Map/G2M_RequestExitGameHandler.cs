using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class G2M_RequestExitGameHandler : MessageLocationHandler<Unit,G2M_RequestExitGame,M2G_RequestExitGame>
    {
        protected override async ETTask Run(Unit unit, G2M_RequestExitGame request, M2G_RequestExitGame response)
        {
            //Unit角色下线业务逻辑，然后保存Unit及组件数据至数据库
            Scene root = unit.Root();
            long untid = unit.Id;
            //正式释放Unit
            await RemoveUnit(unit);
            //await RemoveLocation(root, untid);
            await ETTask.CompletedTask;
        }

        private async ETTask RemoveLocation( Scene root,  long untid)
        {
            await root.GetComponent<TimerComponent>().WaitFrameAsync();
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Remove(untid);
        }

        private async ETTask RemoveUnit(Unit unit)
        {
            await unit.Fiber().WaitFrameFinish();
            
            await unit.RemoveLocation(LocationType.Unit);
            
            unit.GetComponent<DBSaveComponent>().OnDisconnect();
        }
        
    }
}