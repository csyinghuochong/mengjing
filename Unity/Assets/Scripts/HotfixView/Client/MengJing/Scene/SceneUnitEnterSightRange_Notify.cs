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
            
            if (!a.IsPlayer())
            {
                return;
            }

            SceneUnit ua = a.GetParent<SceneUnit>();
            SceneUnit ub = b.GetParent<SceneUnit>();
            
            //SceneUnitEnterSightRange_Notify:  False   3  True   1218242235335389
            //SceneUnitEnterSightRange_Notify:  True   1218242235335389  False   465
            //Log.Debug($"SceneUnitEnterSightRange_Notify:  {a.MainHero}   {a.Id}  {b.MainHero}   {b.Id}");
            ub.LoadGameObject();
            await ETTask.CompletedTask;
        }
    }
}