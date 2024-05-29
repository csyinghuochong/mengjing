namespace ET.Server
{
    
    [Event(SceneType.Map)]
    public class UnitKillEvent_NotifyOther: AEvent<Scene, UnitKillEvent>
    {
        protected override  async ETTask Run(Scene scene, UnitKillEvent args)
        {
            
            
            await ETTask.CompletedTask;
        }
    }
    
}