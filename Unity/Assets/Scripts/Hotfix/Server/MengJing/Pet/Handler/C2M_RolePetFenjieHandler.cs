namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetFenjieHandler : MessageLocationHandler<Unit, C2M_RolePetFenjie, M2C_RolePetFenjie>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetFenjie request, M2C_RolePetFenjie response)
		{
			//判断背包是否满
			if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) <= 1)
			{
				response.Error = ErrorCode.ERR_BagIsFull;       //提示背包已满
				return;
			}


			int petType = 1;
			RolePetInfo rolePetInfo = unit.GetComponent<PetComponentS>().GetPetInfo(request.PetInfoId);

			if (rolePetInfo == null)
			{
				petType = 2;
                rolePetInfo = unit.GetComponent<PetComponentS>().GetPetInfoByBag(request.PetInfoId);
            }

			if (rolePetInfo == null)
			{
				response.Error = ErrorCode.ERR_Pet_NoExist;
				return;
			}
            if (rolePetInfo.PetStatus != 0)
			{
                response.Error = ErrorCode.ERR_Pet_Hint_4;
                return;
            }

            //获取宠物碎片
            PetConfig petCof = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
			if (petCof.ReleaseReward != null && petCof.ReleaseReward.Length == 2)
			{
				unit.GetComponent<BagComponentS>().OnAddItemData($"{petCof.ReleaseReward[0]};{petCof.ReleaseReward[1]}", $"{ItemGetWay.PetFenjie}_{TimeHelper.ServerNow()}");
			}

			if (petType == 1)
			{
                unit.GetComponent<PetComponentS>().OnRolePetFenjie(request.PetInfoId);
            }
			else
			{
                unit.GetComponent<PetComponentS>().RemovePetBag(request.PetInfoId);
            }

			
			unit.GetComponent<JiaYuanComponentS>().OnJiaYuanPetWalk(rolePetInfo, 0, -1);

			if (unit.GetParent<UnitComponent>().Get(rolePetInfo.Id) != null)
			{
				Log.Warning($"宠物还在出战中！！");
				unit.GetParent<UnitComponent>().Remove(rolePetInfo.Id);
			}

			Function_Fight.UnitUpdateProperty_Base( unit, true, true );
			
			await ETTask.CompletedTask;
		}
	}
}