
namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Unit_OnUnitHpUpdate: AEvent<Scene, UnitHpUpdate>
    {
        protected override async ETTask Run(Scene scene, UnitHpUpdate args)
        {
            Log.Debug($"UnitHpUpdate:   {args.Defend.Id} {args.ChangeHpValue} ");
            await ETTask.CompletedTask;
        }
    }
}

