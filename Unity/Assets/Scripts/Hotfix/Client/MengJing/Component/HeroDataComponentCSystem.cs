namespace ET.Client
{
    [FriendOf(typeof (HeroDataComponentC))]
    [EntitySystemOf(typeof (HeroDataComponentC))]
    public static partial class HeroDataComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this HeroDataComponentC self)
        {
        }
        
        public static void OnDead(this HeroDataComponentC self)
        {
            Unit unit = self.GetParent<Unit>();
            unit.GetComponent<StateComponentC>().Reset();
            unit.GetComponent<MoveComponent>()?.Stop(false);
            unit.GetComponent<SkillManagerComponentC>()?.OnFinish();
            unit.GetComponent<BuffManagerComponentC>()?.OnDead();
            int sceneTypeEnum = unit.Root().GetComponent<MapComponent>().MapType;
            if (sceneTypeEnum == (int)MapTypeEnum.CellDungeon
                || sceneTypeEnum == (int)MapTypeEnum.DragonDungeon)
            {
                unit.Root().GetComponent<CellDungeonComponentC>().CheckChuansongOpen();
            }
        }
    }
}