namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Solo_SoloEnterEvent : AEvent<Scene, UISoloEnter>
    {
        protected override async ETTask Run(Scene scene, UISoloEnter args)
        {
            string tipStr = "竞技场匹配完成，请尽快进入!";
            bool removeStatus = false;

            PopupTipHelp.OpenPopupTip(scene, "", LanguageComponent.Instance.LoadLocalization(tipStr),
                () =>
                {
                    EnterMapHelper.RequestTransfer(scene, MapTypeEnum.Solo, 2000010, 0, args.m2C_SoloMatch.FubenId.ToString()).Coroutine();
                    removeStatus = true;
                },
                () =>
                {
                    //关闭界面
                    removeStatus = true;
                }).Coroutine();

            //10秒后将自动关闭竞技场
            await scene.GetComponent<TimerComponent>().WaitAsync(10000);
            if (removeStatus == false)
            {
                scene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PopupTip);
            }
        }
    }
}
