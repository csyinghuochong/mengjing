namespace ET
{
    [UniqueId(100, 10000)]
    public static class TimerInvokeType
    {
        // 框架层100-200，逻辑层的timer type从200起
        public const int WaitTimer = 100;
        public const int SessionIdleChecker = 101;
        public const int MessageLocationSenderChecker = 102;
        public const int MessageSenderChecker = 103;
        
        // 框架层100-200，逻辑层的timer type 200-300
        public const int MoveTimer = 201;
        public const int AITimer = 202;
        public const int SessionAcceptTimeout = 203;
        public const int ActivityTipTimer = 204;
        public const int ActivityServerTimer = 205;
        public const int SkillPassive = 206;
        public const int MonsterSingingTimer = 207;
        public const int DBSaveTimer = 208;
        public const int SkillTimerS = 209;
        public const int BuffTimerS = 210;
        public const int SkillTimerC = 211;
        public const int BuffTimerC = 212;
        public const int PlayerSingingTimer = 213;
        public const int AutoAttackGridTimer = 214;
        public const int RoleBullet1Timer = 215;
        
        public const int RoomUpdate = 301;
        public const int JoystickTimer = 302;
        public const int MapMiniTimer = 303;
        public const int ChatSceneTimer = 304;
        public const int FsmTimer = 305;
        public const int HighLightTimer = 306;
        public const int DelayShowTimer = 307;
        public const int GameObjectPoolTimer = 308;
        public const int YujingTimer = 309;
        public const int UIUnitReviveTime = 310;
        public const int DialogTimer = 311;
        public const int UIDungenBossRefreshTimer = 312;
        public const int MakeCDTimer = 313;
        public const int ChainLightningTimer = 314;
        public const int Effectimer = 315;
        public const int UnionJingXuanTimer = 316;
        public const int FallingFont = 317;
        public const int SkillInfoShowTimer = 318;
    }
}