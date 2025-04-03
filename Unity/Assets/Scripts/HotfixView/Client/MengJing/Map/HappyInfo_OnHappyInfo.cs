namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class HappyInfo_OnHappyInfo: AEvent<Scene, HappyInfo>
    {
        protected override async ETTask Run(Scene scene, HappyInfo args)
        {
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.Happy)
            {
                DlgHappyMain dlgHappyMain = scene.GetComponent<UIComponent>().GetDlgLogic<DlgHappyMain>();
                if (dlgHappyMain == null)
                {
                    return;
                }

                dlgHappyMain.OnUpdateUI(args.M2CHappyInfoResult);
            }

            await ETTask.CompletedTask;
        }
    }
}