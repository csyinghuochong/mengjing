namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_RandomTowerBeginHandler : MessageLocationHandler<Unit, C2M_RandomTowerBeginRequest, M2C_RandomTowerBeginResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RandomTowerBeginRequest request, M2C_RandomTowerBeginResponse response)
        {
            int randomTowerid = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.RandomTowerId);
            if (randomTowerid == 0)
            {
                randomTowerid = TowerHelper.GetFirstTowerIdByScene(MapTypeEnum.RandomTower);
            }
            else
            {
                randomTowerid += request.RandomNumber;
            }
            if (randomTowerid > TowerHelper.GetLastTowerIdByScene(MapTypeEnum.RandomTower))
            {
                return;
            }
            if (unit.Scene().GetComponent<RandomTowerComponent>() == null)
            {
                return;
            }

            unit.Scene().GetComponent<RandomTowerComponent>().TowerId = randomTowerid;
            TowerConfig randowTowerConfig = TowerConfigCategory.Instance.Get(randomTowerid);
            FubenHelp.CreateMonsterList(unit.Scene(), randowTowerConfig.MonsterSet);
            
            await ETTask.CompletedTask;
        }
    }
}