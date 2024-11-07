namespace ET.Client
{
    
    // 进入视野通知
    [Event(SceneType.Demo)]
    public class SceneUnitEnterSightRange_Notify: AEvent<Scene, SceneUnitEnterSightRange>
    {
        protected override async ETTask Run(Scene scene, SceneUnitEnterSightRange args)
        {
            SceneAOIEntity a = args.A;
            SceneAOIEntity b = args.B;
            if (a.Id == b.Id)
            {
                return;
            }

            SceneUnit ua = a.GetParent<SceneUnit>();
            SceneUnit ub = b.GetParent<SceneUnit>();
            //MapMessageHelper.NoticeUnitAdd(ua, ub);
            Log.Debug($"SceneUnitEnterSightRange_Notify:  {a.GetParent<SceneUnit>().Position}   {b.GetParent<SceneUnit>().Position}");
            await ETTask.CompletedTask;
        }
    }
}