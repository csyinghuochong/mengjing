namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView: AEvent<Scene, AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterUnitCreate args)
        {

            args.Unit.AddComponent<GameObjectComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}