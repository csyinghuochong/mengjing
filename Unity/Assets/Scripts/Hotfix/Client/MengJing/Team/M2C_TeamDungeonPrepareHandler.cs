namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonPrepareHandler : MessageHandler<Scene, M2C_TeamDungeonPrepareResult>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonPrepareResult message)
        {
            EventSystem.Instance.Publish(root, new RecvTeamDungeonPrepare() { m2CTeamDungeonPrepareResult = message });

            if (message.ErrorCode == ErrorCode.ERR_Success)
            {
                Log.Debug("所有人都准好好了");
                await root.GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(0, 1000));
                EnterMapHelper.RequestTransfer(root, (int)SceneTypeEnum.TeamDungeon, 0).Coroutine();
            }
        }
    }
}