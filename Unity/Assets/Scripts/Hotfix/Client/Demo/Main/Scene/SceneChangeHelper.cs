namespace ET.Client
{
    public static partial class SceneChangeHelper
    {
        
        // 场景切换协程
        //message.SceneType, message.SceneId, message.Difficulty, message.ParamInfo);
        public static async ETTask SceneChangeTo(Scene root,  long sceneInstanceId, int sceneType, int sceneId, int difficulty, string pagramInfo)
        {
            //root.RemoveComponent<AIComponent>();
            
            CurrentScenesComponent currentScenesComponent = root.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = CurrentSceneFactory.Create(sceneInstanceId, sceneId.ToString(), currentScenesComponent);
            UnitComponent unitComponent = currentScene.AddComponent<UnitComponent>();

            MapComponent mapComponent = root.GetComponent<MapComponent>();
            int lastSceneType = mapComponent.MapType;
            int lastChapterid = mapComponent.SceneId;
            // if (sceneType == SceneTypeEnum.PetMing)
            // {
            //     mapComponent.SetMapInfo(sceneType, sceneId, 0);
            // }
            // else
            // {
            //     
            // }
            mapComponent.SetMapInfo(sceneType, sceneId, int.Parse(pagramInfo));
            
            // 可以订阅这个事件中创建Loading界面
            EventSystem.Instance.Publish(root, new SceneChangeStart()
            {
                RootScene = root,
                LastSceneType = lastSceneType,
                LastChapterId = lastChapterid,
                SceneType = sceneType,
                ChapterId = sceneId,
            });
            // 等待CreateMyUnit的消息
            Wait_CreateMyUnit waitCreateMyUnit = await root.GetComponent<ObjectWait>().Wait<Wait_CreateMyUnit>();
            M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            Unit unit = UnitFactory.CreateUnit(currentScene, m2CCreateMyUnit.Unit, true);
            unitComponent.Add(unit);

            EventSystem.Instance.Publish(currentScene, new SceneChangeFinish() { SceneType = sceneType} );
            // 通知等待场景切换的协程
            root.GetComponent<ObjectWait>().Notify(new Wait_SceneChangeFinish());
        }
    }
}