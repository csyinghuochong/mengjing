namespace ET
{

    [EntitySystemOf(typeof(MapComponent))]
    [FriendOf(typeof(MapComponent))]
    public static partial class MapComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.MapComponent self)
        {

        }
        
        public static void SetMapInfo(this MapComponent self, int sceneTypeEnum, int mapid, int sonMapid)
        {
            self.SceneType = sceneTypeEnum;
            self.SceneId = mapid;
            self.SonSceneId = sonMapid;
        }
    }

}