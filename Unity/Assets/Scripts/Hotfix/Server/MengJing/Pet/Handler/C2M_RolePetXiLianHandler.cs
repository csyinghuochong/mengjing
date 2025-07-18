using System.Collections.Generic;

namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetXiLianHandler : MessageLocationHandler<Unit, C2M_RolePetXiLian, M2C_RolePetXiLian>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetXiLian request, M2C_RolePetXiLian response)
		{
			//读取数据库
			RolePetInfo petInfo = unit.GetComponent<PetComponentS>().GetPetInfo(request.PetInfoId);
			ItemInfo bagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoID);

			//判断是否有足够的道具
			if (bagInfo == null || petInfo == null)
			{
				response.Error = ErrorCode.ERR_ItemNotEnoughError;
				return;
			}
			if (unit.GetComponent<BagComponentS>().GetItemNumber(bagInfo.ItemID) < request.CostItemNum)
			{
				response.Error = ErrorCode.ERR_ItemNotEnoughError;
				return;
			}

			ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
			int itemSubType = itemConfig.ItemSubType;
			bool ifCost = true;

			PetConfig petCof = PetConfigCategory.Instance.Get(petInfo.ConfigId);
			//神兽无法学习技能书
			if (petCof.PetType == 2)
			{
				if(itemSubType == 105 || itemSubType == 118 || itemSubType == 119 || itemSubType == 122)
                {
					response.Error = ErrorCode.ERR_Pet_NoUseItem;
					return;
				}
			}
			
			////没有对应子类型的新增一下。
			////新增的道具都要添加子类型
			switch (itemSubType)
			{
				//宠物洗练
				case 105:
					// 宠之晶 增加额外效果,洗炼5%的概率使普通宠物发生变异,变异的宠物不能使用此道具
					//if (PetHelper.IsBianYI(petInfo))
					//{
					//	response.Error = ErrorCode.ERR_Pet_NoUseItem;
					//	reply();
					//	return;
					//}

					if (!PetHelper.IsBianYI(petInfo) && RandomHelper.RandomNumber(0, 101) <= 5)
					{
						if (petCof.Skin.Length >= 2)
						{
							petInfo.SkinId = petCof.Skin[RandomHelper.RandomNumber(1, petCof.Skin.Length)];
						}
					}

					//重置资质系数
					petInfo = unit.GetComponent<PetComponentS>().PetXiLian(petInfo,2, bagInfo.ItemID, 0);
                    unit.GetComponent<PetComponentS>().UpdatePetAttribute(petInfo, true);
                    petInfo.LockSkill.Clear();
                    response.rolePetInfo = petInfo;
					break;
				//增加经验
				case 108:
					if (ExpConfigCategory.Instance.Contain(petInfo.PetLv))
					{
                        int addExp = ExpConfigCategory.Instance.Get(petInfo.PetLv).PetItemUpExp;
                        unit.GetComponent<PetComponentS>().PetAddExp(petInfo, addExp);
                        response.rolePetInfo = petInfo;
                    }
					break;
				//增加等级
				case 109:
					///////
					if ( !ExpConfigCategory.Instance.Contain(petInfo.PetLv + 1) )
					{
						return;
					}
					unit.GetComponent<PetComponentS>().PetAddLv(petInfo, 1);
					response.rolePetInfo = petInfo;
					break;
				case 117:	//洗点
					unit.GetComponent<PetComponentS>().OnResetPoint(petInfo);
                    petInfo.LockSkill.Clear();
                    response.rolePetInfo = petInfo;
					break;
				case 118: //资质
					unit.GetComponent<PetComponentS>().UpdatePetZiZhi(petInfo, bagInfo.ItemID);
					unit.GetComponent<PetComponentS>().UpdatePetAttribute(petInfo, true);
                    petInfo.LockSkill.Clear();
                    response.rolePetInfo = petInfo;
					break;
				case 119: //成长
					unit.GetComponent<PetComponentS>().UpdatePetChengZhang(petInfo, bagInfo.ItemID);
					unit.GetComponent<PetComponentS>().UpdatePetAttribute(petInfo, true);
					response.rolePetInfo = petInfo;
					break;
				//学习技能书
				case 122:
					bool ifok = Pet_AddSkill(unit, petInfo, int.Parse(itemConfig.ItemUsePar));
					if (ifok)
					{
                        unit.GetComponent<PetComponentS>().UpdatePetAttribute(petInfo, true);
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PetUseSkillBook_36, 0, 1);
                    }
					petInfo.LockSkill.Clear();
                    response.rolePetInfo = petInfo;
					ifCost = ifok;
					response.Error = ifok ? ErrorCode.ERR_Success : ErrorCode.ERR_Pet_AddSkillSame;
					break;
				case 133:
					// 超级宠之晶 只有变异宠物可以用,洗宠物属性,不会改变其皮肤,只改变技能和资质 
					//if (!PetHelper.IsBianYI(petInfo))
					//{
					//	response.Error = ErrorCode.ERR_Pet_NoUseItem;
					//	reply();
					//	return;
					//}

					//重置资质系数
					petInfo = unit.GetComponent<PetComponentS>().PetXiLian(petInfo, 2, bagInfo.ItemID, 0);
                    unit.GetComponent<PetComponentS>().UpdatePetAttribute(petInfo, true);
					response.rolePetInfo = petInfo;
					break;
				case 134:
					// 变异宠物果实 只有普通宠物可以用,使用后随机获得一个变异效果(随机一个皮肤不能是第一个),其他属性和技能不变
					if (PetHelper.IsBianYI(petInfo))
					{
						response.Error = ErrorCode.ERR_Pet_NoUseItem;
						return;
					}

					if (petCof.Skin.Length >= 2)
					{
						petInfo.SkinId = petCof.Skin[RandomHelper.RandomNumber(1, petCof.Skin.Length)];
					}
					response.rolePetInfo = petInfo;
					break;
				case 136:
					if (petInfo.PetSkill.Count < 2)
					{
                        response.Error = ErrorCode.ERR_Pet_CanNotLock;
                        return;
                    }

					int lockSkill = int.Parse(request.ParamInfo);
                    //只锁定一个技能， 用list方便以后做扩展。 锁定的技能在122这个Pet_AddSkill不会被顶掉
                    petInfo.LockSkill.Clear();
					petInfo.LockSkill.Add(lockSkill);	
                    response.rolePetInfo = petInfo;
                    break;
				default:
					break;
			}

			//扣除相关道具
			if (bagInfo != null && ifCost)
			{
				//扣除道具
				List<RewardItem> rewardItems = new List<RewardItem>();
				rewardItems.Add(new RewardItem() { ItemID = bagInfo.ItemID, ItemNum = 1 });
				unit.GetComponent<BagComponentS>().OnCostItemData(rewardItems);		
				unit.GetComponent<ChengJiuComponentS>().OnPetXiLian(petInfo);		//激活成就
				unit.GetComponent<TaskComponentS>().OnPetXiLian(petInfo);                    //激活任务

				if (itemSubType == 105 || itemSubType == 133)
                {
                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PetXiLian10010086_33, 0, 1);
                }
            }
            unit.GetComponent<PetComponentS>().CheckPetPingFen();
            unit.GetComponent<PetComponentS>().CheckPetZiZhi();
            
			await ETTask.CompletedTask;
		}

		//宠物打技能书
		private bool Pet_AddSkill( Unit unit, RolePetInfo petinfo, int addSkillID)
		{
			//判断当前技能是否有重复的
			if (petinfo.PetSkill.Contains(addSkillID))
			{
				return false; 
			}

			//学习规则是随机顶掉当前宠物的一个技能
			if (petinfo.PetSkill.Count > 1 )
			{
				bool delStatus = false;
				//2技能打3技能
				if (petinfo.PetSkill.Count < 3) 
				{
					if (RandomHelper.RandFloat01() < 0.4f) {
						//不删技能
						delStatus = true;
					}
				}

				//3技能打4技能
                if (petinfo.PetSkill.Count == 3)
                {
                    if (RandomHelper.RandFloat01() < 0.2f)
                    {
                        //不删技能
                        delStatus = true;
                    }
                }

                //随机获取替换的技能ID序号
                if (!delStatus)
				{
					//int tihuanNum = RandomHelper.RandomNumber(0, petinfo.PetSkill.Count);
                    //petinfo.PetSkill.RemoveAt(tihuanNum);
				    using	ListComponent<int> canRemoveSkil = ListComponent<int>.Create();
					for (int i = 0; i < petinfo.PetSkill.Count; i++)
					{
						if (!petinfo.LockSkill.Contains(petinfo.PetSkill[i]))
						{
                            canRemoveSkil.Add(petinfo.PetSkill[i]);
                        }
					}
					//从没有锁定的技能随机删除一个
					if (canRemoveSkil.Count > 0)
					{
                        int tihuanNum = RandomHelper.RandomNumber(0, canRemoveSkil.Count);
						petinfo.PetSkill.Remove(canRemoveSkil[tihuanNum]);
                    }
					else
					{
						Log.Error($"技能全锁定： {unit.Id} {petinfo.Id}");
					}
				}
			}

			petinfo.PetSkill.Add(addSkillID);


			return true;
		}

		//宠物自身洗炼
		private int Pet_XilianSelf(RolePetInfo petinfo)
		{
			
			int ErrorCore = -1;
			/*
			int petID = petinfo.ConfigId;
			PetConfig petConfig = PetConfigCategory.Instance.Get(petID);

			int petType = petConfig.PetType;
			if (petType != 0)
			{
				//Game_PublicClassVar.Get_function_UI.GameGirdHint_Front("洗练变异宠物请使用更强大的道具！");
				ErrorCore = 1;
			}

			
			if (petID != 30000001 && petID != 30000002)
			{
				//3%概率变成变异宠物
				if (RandomHelper.RandomNumber(0, 10) * 0.1f <= 0.03f)
				{
					int petBianYiID = 0; // petConfig.PetBianYiID;
					if (petBianYiID != 0)
					{
						petID = petBianYiID;
					}
					//获取玩家名称
					//string roseName = "";
					//广播【"恭喜玩家" + roseName + "洗练宠物时一不小心打翻了药坛子，宠物不小心变了一个颜色!"】
				}
			}
			*/
			//Function_AI.GetInstance().Pet_Create(petinfo, 1);

			return ErrorCore;
		}

		//成长提高
		private bool Pet_AddRandomChengZhang(RolePetInfo petinfo)
		{
			return false;
			//return Function_AI.GetInstance().Pet_AddRandomChengZhang(petinfo);
			//langStrHint = Game_PublicClassVar.Get_gameSettingLanguge.LoadLocalizationHint("hint_228");
			//Game_PublicClassVar.Get_function_UI.GameGirdHint_Front(langStrHint);
			////Game_PublicClassVar.Get_function_UI.GameGirdHint_Front("一股神秘的力量让你的宠物成长提高了！");
			//Obj_PetShow.GetComponent<UI_PetXiLianShow>().showPetProperty();
			////消耗当前的道具,刷新对应的栏位显示
			//if (Game_PublicClassVar.Get_function_Rose.CostBagItem(XiLianNeedItemID, int.Parse(XiLianNeedItemNum)))
			//{
			//	BagItemSkillBtnList();
			//	nowXiLianNum = nowXiLianNum + 1;
			//}
		}

		//宝宝属性点重置
		private bool Pet_AddProprety(RolePetInfo petinfo)
		{
			//判定目标是否为宝宝
			int ifBaby = petinfo.BabyType;
			if (ifBaby == 0)
			{
				//langStrHint = Game_PublicClassVar.Get_gameSettingLanguge.LoadLocalizationHint("hint_229");
				//Game_PublicClassVar.Get_function_UI.GameGirdHint_Front(langStrHint);
				return false;
			}

			//读取宠物技能点数
			string addPropretyValue = petinfo.AddPropretyValue;
			int addPropretyNum = petinfo.AddPropretyNum;
			int petLv = petinfo.PetLv;
			string[] addPropretyValueList = addPropretyValue.Split(';');
			int nowNum = 0;
			for (int i = 0; i < addPropretyValueList.Length; i++)
			{
				nowNum = nowNum + int.Parse(addPropretyValueList[i]);
			}

			int nowChongZhiNumOne = 15 + (petLv - 1) * 1;
			if (nowNum >= nowChongZhiNumOne * 4)
			{
				nowNum = nowNum - nowChongZhiNumOne * 4;
			}
			else
			{
				//宠物属性使用失败,当前加点总数必须大于一定值。
				//langStrHint = Game_PublicClassVar.Get_gameSettingLanguge.LoadLocalizationHint("hint_230");
				//Game_PublicClassVar.Get_function_UI.GameGirdHint_Front(langStrHint);
				//Game_PublicClassVar.Get_function_UI.GameGirdHint_Front("重置失败，点数不符！");
				return false;
			}

			//消耗当前的道具,刷新对应的栏位显示
			//销毁道具
			//if (Game_PublicClassVar.Get_function_Rose.CostBagItem(XiLianNeedItemID, int.Parse(XiLianNeedItemNum)))
			bool ifCostStatus = true; // await Function_Role.GetInstance().Bag_CostItem(player.UserId, (int)(request.OperateBagID), (int)(request.OperateBagNum));
			if (ifCostStatus)
			{
				nowNum = nowNum + addPropretyNum;
				petinfo.AddPropretyValue = nowChongZhiNumOne + "_" + nowChongZhiNumOne + "_" + nowChongZhiNumOne + "_" + nowChongZhiNumOne;
				petinfo.AddPropretyNum = nowNum;
				//Game_PublicClassVar.Get_function_DataSet.DataSet_WriteData("AddPropretyValue", nowChongZhiNumOne + ";" + nowChongZhiNumOne + ";" + nowChongZhiNumOne + ";" + nowChongZhiNumOne, "ID", petSpaceID, "RosePet");
				//Game_PublicClassVar.Get_function_DataSet.DataSet_WriteData("AddPropretyNum", nowNum.ToString(), "ID", petSpaceID, "RosePet");
				//Game_PublicClassVar.Get_function_DataSet.DataSet_SetXml("RosePet");
				//langStrHint = Game_PublicClassVar.Get_gameSettingLanguge.LoadLocalizationHint("hint_231");
				//Game_PublicClassVar.Get_function_UI.GameGirdHint_Front(langStrHint);
				//nowXiLianNum = nowXiLianNum + 1;
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
