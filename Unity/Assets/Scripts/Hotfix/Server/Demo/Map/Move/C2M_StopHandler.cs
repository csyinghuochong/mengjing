namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_StopHandler: MessageLocationHandler<Unit, C2M_Stop>
    {
        protected override async ETTask Run(Unit unit, C2M_Stop message)
        {
            if (unit.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.Transfer))
            {
                return;
            }
            unit.Stop(0);
            
            await ETTask.CompletedTask;
        }
    }
}