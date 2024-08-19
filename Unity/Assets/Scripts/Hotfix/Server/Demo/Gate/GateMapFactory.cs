namespace ET.Server
{
    public static class GateMapFactory
    {
        public static  Scene Create(Entity parent, long id, long instanceId, string name)
        {

            Scene scene = EntitySceneFactory.CreateScene(parent, id, instanceId, SceneType.Map, name);

            scene.AddComponent<UnitComponent>();
            scene.AddComponent<AOIManagerComponent>();
            scene.AddComponent<RoomManagerComponent>();
            scene.AddComponent<MapComponent>();
            scene.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            
            return scene;
        }

    }
}