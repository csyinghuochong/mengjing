﻿namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class PetMingDungeonComponent: Entity, IAwake, IDestroy
    {
        public int MineType;
        public int Position;

        /// <summary>
        /// 挑战者的队伍
        /// </summary>
        public int TeamId;

        public Unit MainUnit { get; set; }
        public long Timer;

        public int CombatResultEnum;

        public long EnemyId;
    }
}

