namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class MiJing_SyncMiJingDamage: AEvent<Scene, SyncMiJingDamage>
    {
        protected override async ETTask Run(Scene scene, SyncMiJingDamage args)
        {
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.MiJing)
            {
                scene.GetComponent<UIComponent>().GetDlgLogic<DlgMiJingMain>()?.OnUpdateDamage(args.M2C_SyncMiJingDamage);
            }

            if (mapComponent.MapType == MapTypeEnum.TeamDungeon)
            {
                scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnUpdateTeamDamage(args.M2C_SyncMiJingDamage);
            }

            await ETTask.CompletedTask;
        }
    }
}