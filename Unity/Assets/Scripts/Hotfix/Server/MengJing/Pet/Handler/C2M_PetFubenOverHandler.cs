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
            if (mapComponent.SceneType == SceneTypeEnum.PetDungeon)
            {
                domainScene.GetComponent<PetDungeonComponent>().OnGameOver();
            }
            if (mapComponent.SceneType == SceneTypeEnum.PetTianTi)
            {
                int result = domainScene.GetComponent<PetTianTiDungeonComponent>().GetCombatResult();
                result = result == CombatResultEnum.None ? CombatResultEnum.Fail : result;
                domainScene.GetComponent<PetTianTiDungeonComponent>().OnGameOver(result).Coroutine();
            }
            if (mapComponent.SceneType == SceneTypeEnum.PetMing)
            {
                int result = domainScene.GetComponent<PetMingDungeonComponent>().GetCombatResult();
                result = result == CombatResultEnum.None ? CombatResultEnum.Fail : result;
                domainScene.GetComponent<PetMingDungeonComponent>().OnGameOver(result).Coroutine();
            }
        }
    }
}
