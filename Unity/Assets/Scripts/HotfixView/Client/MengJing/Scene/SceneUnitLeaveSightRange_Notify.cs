namespace ET.Client
{
    // 离开视野
    [Event(SceneType.Demo)]
    public class SceneUnitLeaveSightRange_Notify: AEvent<Scene, SceneUnitLeaveSightRange>
    {
        protected override async ETTask Run(Scene scene, SceneUnitLeaveSightRange args)
        {
            await ETTask.CompletedTask;

            SceneAOIEntity a = args.A;
            SceneAOIEntity b = args.B;
            if (!a.IsPlayer())
            {
                return;
            }

            //SceneUnitLeaveSightRange_Notify:  False   95  True  1218242235335389
            //SceneUnitLeaveSightRange_Notify:  True   1218242235335389  False  978
            //Log.Debug($"SceneUnitLeaveSightRange_Notify:  {a.MainHero}   {a.Id}  {b.MainHero}  {b.Id}");
            b.GetParent<SceneUnit>().RecoverGameObject();
        }
    }
}