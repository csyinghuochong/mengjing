using System;
using System.Collections.Generic;

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
                domainScene.GetComponent<PetFubenComponent>().OnGameOver();
            }
            if (mapComponent.SceneType == SceneTypeEnum.PetTianTi)
            {
                int result = domainScene.GetComponent<PetTianTiComponent>().GetCombatResult();
                result = result == CombatResultEnum.None ? CombatResultEnum.Fail : result;
                domainScene.GetComponent<PetTianTiComponent>().OnGameOver(result);
            }
            if (mapComponent.SceneTypeEnum == SceneTypeEnum.PetMing)
            {
                int result = domainScene.GetComponent<PetMingDungeonComponent>().GetCombatResult();
                result = result == CombatResultEnum.None ? CombatResultEnum.Fail : result;
                domainScene.GetComponent<PetMingDungeonComponent>().OnGameOver(result).Coroutine();
            }
        }
    }
}
