using System.Collections.Generic;

namespace ET.Client
{
	[MessageHandler(SceneType.Demo)]
	public class M2C_CreateUnitsHandler: MessageHandler<Scene, M2C_CreateUnits>
	{
		protected override async ETTask Run(Scene root, M2C_CreateUnits message)
		{
			Scene currentScene = root.CurrentScene();
			UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
			
			foreach (UnitInfo unitInfo in message.Units)
			{
				if (unitComponent.Get(unitInfo.UnitId) != null)
				{
					continue;
				}
				UnitFactory.CreateUnit(currentScene, unitInfo);
			}
			// foreach (SpilingInfo unitInfo in message.Spilings)
			// {
			// 	allunitids.Add(unitInfo.UnitId);
			//
			// 	if (CheckUnitExist(unitComponent, unitInfo.UnitId, unitInfo.X, unitInfo.Y, unitInfo.Z))
			// 	{
			// 		continue;
			// 	}
			// 	UnitFactory.CreateSpiling(currentScene, unitInfo);
			// }
			// foreach (DropInfo unitInfo in message.Drops)
			// {
			// 	allunitids.Add(unitInfo.UnitId);
			//
			// 	if (CheckUnitExist(unitComponent, unitInfo.UnitId, unitInfo.X, unitInfo.Y, unitInfo.Z))
			// 	{
			// 		continue;
			// 	}
			// 	UnitFactory.CreateDropItem(currentScene, unitInfo);
			// }
			// foreach (TransferInfo unitInfo in message.Transfers)
			// {
			// 	allunitids.Add(unitInfo.UnitId);
			//
			// 	if (CheckUnitExist(unitComponent, unitInfo.UnitId, unitInfo.X, unitInfo.Y, unitInfo.Z))
			// 	{
			// 		continue;
			// 	}
			// 	UnitFactory.CreateTransferItem(currentScene, unitInfo);
			// }
			//
			//
			// if (message.UpdateAll == 1)
			// {
			// 	//移除不存在的unit. 只检测玩家 。怪物和掉落
			// 	List<Unit> allunits = unitComponent.GetAll();
			// 	for (int i = allunits.Count - 1; i >= 0; i--)
			// 	{
			// 		int unitType = allunits[i].Type;
			// 		if (unitType != UnitType.Player && unitType != UnitType.Monster && unitType != UnitType.DropItem)
			// 		{
			// 			continue;
			// 		}
			// 		if (allunits[i].MainHero)
			// 		{
			// 			continue;
			// 		}
			//
			// 		if (!allunitids.Contains(allunits[i].Id))
			// 		{
			// 			unitComponent.Remove(allunits[i].Id);
			// 			continue;
			// 		}
			// 	}
			// }
			await ETTask.CompletedTask;
		}
	}
}
