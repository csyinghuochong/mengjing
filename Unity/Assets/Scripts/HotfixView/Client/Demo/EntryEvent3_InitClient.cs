using System;
using System.Collections.Generic;
using System.IO;

namespace ET.Client
{
    [Event(SceneType.Main)]
    public class EntryEvent3_InitClient: AEvent<Scene, EntryEvent3>
    {
        protected override async ETTask Run(Scene root, EntryEvent3 args)
        {
            Log.Debug("EntryEvent3_InitClient");
            GlobalComponent globalComponent = root.AddComponent<GlobalComponent>();
            root.AddComponent<UIPathComponent>();
            root.AddComponent<UIEventComponent>();
            root.AddComponent<UIComponent>();
            
            root.AddComponent<ResourcesLoaderComponent>();
            root.AddComponent<GameObjectPoolComponent>();
            root.AddComponent<PlayerComponent>();
            root.AddComponent<CurrentScenesComponent>();
            root.AddComponent<BagComponent_C>();
            root.AddComponent<FlyTipComponent>();
            root.AddComponent<UserInfoComponent_C>();
            root.AddComponent<FriendComponent>();
            root.AddComponent<ChatComponent>();
            root.AddComponent<TaskComponent_C>();
            root.AddComponent<BattleMessageComponent>();
            root.AddComponent<MapComponent>();
            root.AddComponent<PetComponent_C>();

            // 根据配置修改掉Main Fiber的SceneType
            SceneType sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
            root.SceneType = sceneType;
            
            await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
        }
    }
}