namespace ET.Client
{
    [Event(SceneType.Current)]
    public class ChangeRotation_SyncGameObjectRotation: AEvent<Scene, ChangeRotation>
    {
        protected override async ETTask Run(Scene scene, ChangeRotation args)
        {
            Unit unit = args.Unit;
            GameObjectComponent gameObjectComponent = unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }

            if (unit.SpeedRate >= 100)
            {
                gameObjectComponent.UpdateRotation(unit.Rotation);
            }

            await ETTask.CompletedTask;
        }
    }
}
