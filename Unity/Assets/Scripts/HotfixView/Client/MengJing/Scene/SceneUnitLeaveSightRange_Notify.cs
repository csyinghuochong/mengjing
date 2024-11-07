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
            
            Log.Debug($"SceneUnitLeaveSightRange_Notify:  {a.GetParent<SceneUnit>().Position}   {b.GetParent<SceneUnit>().Position}");
            //NoticeUnitRemove(a.GetParent<SceneUnit>(), b.GetParent<SceneUnit>());
        }
    }
}