﻿using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(PlayerComponent))]
    public static partial class PlayerComponentSystem
    {
        public static void Add(this PlayerComponent self, Player player)
        {
            self.dictionary.Add(player.Account, player);
        }
        
        public static void Remove(this PlayerComponent self, Player player)
        {
            self.dictionary.Remove(player.Account);
            player.Dispose();
        }
        
        public static EntityRef<Player> GetByAccount(this PlayerComponent self,  string account)
        {
            self.dictionary.TryGetValue(account, out EntityRef<Player> player);
            return player;
        }
        
        public static EntityRef<Player>[] GetAll(this PlayerComponent self)
        {
            return self.dictionary.Values.ToArray();
        }
        
        public static Player GetByUserId(this PlayerComponent self, long id)
        {
            foreach (var item in self.dictionary.Values)
            {
                Player player = item;
                if (player.UnitId == id)
                {
                    return player;
                }
            }
            return null;
        }
    }
}