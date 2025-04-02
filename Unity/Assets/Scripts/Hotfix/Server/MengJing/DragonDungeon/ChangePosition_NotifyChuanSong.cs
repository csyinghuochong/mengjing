using Unity.Mathematics;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class ChangePosition_NotifyChuanSong: AEvent<Scene, ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ChangePosition args)
        {
            Unit unit = args.Unit;
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            if(mapComponent.SceneType!=SceneTypeEnum.DragonDungeon)
            {
                return;
            }
            
            
            
            await ETTask.CompletedTask;
        }
    }
}