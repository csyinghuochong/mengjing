namespace ET.Client
{

    [EntitySystemOf(typeof(BattleMessageComponent))]
    [FriendOf(typeof(BattleMessageComponent))]
    public static partial class BattleMessageComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.BattleMessageComponent self)
        {

        }

        public static void SetLastDungeonId(this ET.BattleMessageComponent self, int dungeonId)
        {
            self.LastDungeonId = dungeonId;
        }
    }
}
