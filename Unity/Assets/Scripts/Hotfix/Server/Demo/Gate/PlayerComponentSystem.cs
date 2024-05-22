using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(PlayerComponent))]
    public static partial class PlayerComponentSystem
    {
        public static void Add(this PlayerComponent self, Player player)
        {
            self.dictionary.Add(player.Account, player);
            self.idPlayers.Add(player.AccountId, player);
        }
        
        public static void Remove(this PlayerComponent self, Player player)
        {
            self.dictionary.Remove(player.Account);
            self.idPlayers.Remove(player.AccountId);
            player.Dispose();
        }
        
        public static Player GetByAccount(this PlayerComponent self,  string account)
        {
            self.dictionary.TryGetValue(account, out Player player);
            return player;
        }
        
        public static Player[] GetAll(this PlayerComponent self)
        {
            return self.idPlayers.Values.ToArray();
        }
        
        public static Player GetByUserId(this PlayerComponent self, long id)
        {
            foreach (var player in self.idPlayers.Values)
            {
                if (player.UnitId == id)
                {
                    return player;
                }
            }
            return null;
        }
    }
}