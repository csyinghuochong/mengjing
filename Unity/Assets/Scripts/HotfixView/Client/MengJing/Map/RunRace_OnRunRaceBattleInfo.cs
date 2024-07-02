namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class RunRace_OnRunRaceBattleInfo: AEvent<Scene, RunRaceBattleInfo>
    {
        protected override async ETTask Run(Scene scene, RunRaceBattleInfo args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRunRaceMain>()?.UpdateNextTransformTime(args.M2C_RunRaceBattleInfo);

            await ETTask.CompletedTask;
        }
    }
}