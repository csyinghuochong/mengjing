namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ChengJiu_OnChengJiuActive : AEvent<Scene, ChengJiuActive>
    {
        protected override async ETTask Run(Scene scene, ChengJiuActive args)
        {
            DlgChengJiuActivite dlgChengJiuActivite = scene.GetComponent<UIComponent>().GetDlgLogic<DlgChengJiuActivite>();
            if (dlgChengJiuActivite == null)
            {
                await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ChengJiuActivite);
                dlgChengJiuActivite = scene.GetComponent<UIComponent>().GetDlgLogic<DlgChengJiuActivite>();
            }

            dlgChengJiuActivite.OnInitUI(args.m2C_ChengJiu.ChengJiuId).Coroutine();
        }
    }
}