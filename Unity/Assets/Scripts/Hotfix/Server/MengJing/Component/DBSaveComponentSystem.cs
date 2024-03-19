namespace ET.Server
{

    [EntitySystemOf((typeof(DBSaveComponent)))]
    [FriendOf((typeof(DBSaveComponent)))]
    public static partial class DBSaveComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DBSaveComponent self)
        {

        }

        public static void SetNoFindPath(this ET.Server.DBSaveComponent self)
        {
            
            
        }


    }

}