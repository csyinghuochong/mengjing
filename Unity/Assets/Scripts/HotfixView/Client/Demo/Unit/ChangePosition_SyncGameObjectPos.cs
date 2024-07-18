namespace ET.Client
{
    [FriendOf(typeof (GameObjectComponent))]
    [Event(SceneType.Current)]
    public class ChangePosition_SyncGameObjectPos: AEvent<Scene, ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ChangePosition args)
        {
            Unit unit = args.Unit;
            GameObjectComponent gameObjectComponent = unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }

            //Transform transform = gameObjectComponent.GameObject.transform;
            //transform.position = unit.Position;
            unit.GetComponent<GameObjectComponent>()?.UpdatePositon(unit.Position);
            unit.GetComponent<EffectViewComponent>()?.UpdatePositon();

            //主角
            if (unit.MainHero)
            {
                EventSystem.Instance.Publish(scene.Root(), new MainHeroMove());

                MapViewHelper.OnMainHeroMove(unit);
            }

            await ETTask.CompletedTask;
        }
    }
}