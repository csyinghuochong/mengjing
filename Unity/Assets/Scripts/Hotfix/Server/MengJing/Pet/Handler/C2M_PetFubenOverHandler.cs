namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFubenOverHandler : MessageLocationHandler<Unit, C2M_PetFubenOverRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFubenOverRequest request)
        {
            await ETTask.CompletedTask;
            Scene domainScene = unit.Root();
            MapComponent mapComponent = domainScene.GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.PetDungeon)
            {
                domainScene.GetComponent<PetDungeonComponent>().OnGameOver();
            }
            if (mapComponent.MapType == MapTypeEnum.PetTianTi)
            {
                int result = domainScene.GetComponent<PetTianTiDungeonComponent>().GetCombatResult();
                result = result == CombatResultEnum.None ? CombatResultEnum.Fail : result;
                domainScene.GetComponent<PetTianTiDungeonComponent>().OnGameOver(result).Coroutine();
            }
            if (mapComponent.MapType == MapTypeEnum.PetMing)
            {
                int result = domainScene.GetComponent<PetMingDungeonComponent>().GetCombatResult();
                result = result == CombatResultEnum.None ? CombatResultEnum.Fail : result;
                domainScene.GetComponent<PetMingDungeonComponent>().OnGameOver(result).Coroutine();
            }
        }
    }
}
