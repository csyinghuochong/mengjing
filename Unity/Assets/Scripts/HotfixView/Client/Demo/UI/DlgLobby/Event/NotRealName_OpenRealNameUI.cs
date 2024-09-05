namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class NotRealName_OpenRealNameUI : AEvent<Scene, NotRealName>
    {
        protected override async ETTask Run(Scene scene, NotRealName args)
        {
            //弹出实名认证窗口。
            string name = "余传建";
            string idcard = "41152419930913205X";

            await scene.GetComponent<TimerComponent>().WaitAsync(2000);
            int errorCode = await LoginHelper.RealName(scene, name, idcard);
            
            //实名认证成功再登陆。
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
            await LoginHelper.Login(scene.Root(), playerComponent.Account, playerComponent.Password, 0,playerComponent.VersionMode);
            
            await ETTask.CompletedTask;
        }
    }
}