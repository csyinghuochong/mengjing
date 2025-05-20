using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

	public static class FubenHelp
	{

		public static void OnDragonSettlement(List<Unit> players, int chapterId, int fubenDifficulty,int starNumber)
		{
			
			CellGenerateConfig chapterConfig = CellGenerateConfigCategory.Instance.Get(chapterId);
			for (int pp = 0; pp < players.Count; pp++)
			{
				Unit players_pp = players[pp];
				UserInfo userInfo = players_pp.GetComponent<UserInfoComponentS>().UserInfo;
				List<FubenPassInfo> fubenPassInfos = userInfo.FubenPassList;
				FubenPassInfo fubenPassInfo = null;
				for (int i = 0; i < fubenPassInfos.Count; i++)
				{
					if (fubenPassInfos[i].FubenId == chapterId)
					{
						fubenPassInfo = fubenPassInfos[i];
						break;
					}
				}

				if (fubenPassInfo == null)
				{
					fubenPassInfo = FubenPassInfo.Create();
					fubenPassInfo.FubenId = chapterId;
					userInfo.FubenPassList.Add(fubenPassInfo);
				}

				fubenPassInfo.Difficulty =
						((int)fubenDifficulty > fubenPassInfo.Difficulty) ? (int)fubenDifficulty : fubenPassInfo.Difficulty;

				players_pp.GetComponent<UserInfoComponentS>()
						.UpdateRoleMoneyAdd(UserDataType.Exp, chapterConfig.RewardExp.ToString(), true, ItemGetWay.FubenGetReward);
				players_pp.GetComponent<UserInfoComponentS>()
						.UpdateRoleMoneyAdd(UserDataType.Gold, chapterConfig.RewardGold.ToString(), true, ItemGetWay.FubenGetReward);

				players_pp.GetComponent<TaskComponentS>().OnPassFuben(fubenDifficulty, chapterId, starNumber);
				players_pp.GetComponent<ChengJiuComponentS>().OnPassFuben(fubenDifficulty, chapterId, starNumber);
			}
		}

		public static List<Unit> GetUnitList(Scene scene, int unitType)
		{
			List<Unit> list = new List<Unit>();
			List<EntityRef<Unit>> allunits = scene.GetComponent<UnitComponent>().GetAll();
			for (int i = 0; i < allunits.Count; i++)
			{
				Unit unit = allunits[i];
				if (unit.Type == unitType)
				{
					list.Add(allunits[i]);
				}
			}

			return list;
		}

		/// <summary>
		/// 触发BUFF
		/// </summary>
		/// <param name="self"></param>
		/// <param name="sceneType"></param>
		public static void TriggerTeamBuff(this Unit self, int sceneType)
		{
			if (sceneType == MapTypeEnum.MainCityScene)
			{
				return;
			}

			List<EntityRef<Unit>> entities = self.Scene().GetComponent<UnitComponent>().GetAll();
			for (int i = entities.Count - 1; i >= 0; i--)
			{
				Unit unit = entities[i];
				if (unit.Type != UnitType.Player)
				{
					continue;
				}

				if (self.IsSameTeam(entities[i]))
				{
					unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.TeamerEnter_12);
					//entities[i].GetComponent<SkillManagerComponent>().TriggerTeamBuff();
				}
			}
		}

		/// <summary>
		/// 寻找一个可通行的随机位置
		/// </summary>
		/// <param name="unit"></param>
		/// <param name="from"></param>
		/// <param name="target"></param>
		/// <returns></returns>
		public static bool GetCanReachPath(Scene scene, int navMeshId, float3 from, float3 target)
		{
			using var list = ListComponent<float3>.Create();
			//scene.GetComponent<PathfindingComponent>().Find(from, target, list);
			List<float3> path = list;
			if (path.Count >= 2)
				return true;

			return false;
		}

		public static void CreateMonsterList(Scene scene, int[] monsterPos)
		{
			if (monsterPos == null || monsterPos.Length == 0)
			{
				return;
			}

			for (int i = 0; i < monsterPos.Length; i++)
			{
				int monsterId = monsterPos[i];

				int whileNumber = 0;

				while (monsterId != 0)
				{
					whileNumber++;
					if (whileNumber >= 100)
					{
						Log.Error("whileNumber >= 100");
						break;
					}

					try
					{
						monsterId = CreateMonsterByPos(scene, monsterId);
					}
					catch (Exception ex)
					{
						Log.Error(ex.ToString());
					}
				}
			}
		}
		
		public static void CreateMonsterList(Scene scene, int monsterId)
		{
			int whileNumber = 0;

			while (monsterId != 0)
			{
				whileNumber++;
				if (whileNumber >= 100)
				{
					Log.Error("whileNumber >= 100");
					break;
				}

				try
				{
					monsterId = CreateMonsterByPos(scene, monsterId);
				}
				catch (Exception ex)
				{
					Log.Error(ex.ToString());
				}
			}
		}

		private static void CreateMonsterById(Scene scene, MonsterPositionConfig monsterPosition, int MonsterID, int CreateNum)
		{
			if (CreateNum > 100)
			{
				Log.Error($"monsterPosition.CreateNum:  {CreateNum}");
				return;
			}
			
			int mtype = monsterPosition.Type;
			string[] position = monsterPosition.Position.Split(',');

			switch (mtype)
			{
				case 0: //随机位置刷怪
					break;
				case 1: //固定位置刷怪
					for (int c = 0; c < CreateNum; c++)
					{
						MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(MonsterID);
						float3 vector3 = new float3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
					
						if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_52)
						{
							CellDungeonComponentS cellDungeonComponent = scene.GetComponent<CellDungeonComponentS>();
							if (cellDungeonComponent!=null)
							{
								List<int> EnergySkills = cellDungeonComponent.EnergySkills;
								int skillId = EnergySkills[RandomHelper.RandomNumber(0, EnergySkills.Count)];
								EnergySkills.Remove(skillId);
								UnitFactory.CreateMonster(scene, monsterConfig.Id, vector3, new CreateMonsterInfo()
								{
									SkillId = skillId,
									Camp = monsterConfig.MonsterCamp
								});
							}
						}
						else
						{
							UnitFactory.CreateMonster(scene, monsterConfig.Id, vector3,
								new CreateMonsterInfo() { Camp = monsterConfig.MonsterCamp, Rotation = monsterPosition.Create, });
						}
					}
					break;
				case 2:
					for (int c = 0; c < CreateNum; c++)
					{
						float range = (float) monsterPosition.CreateRange;
						MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(MonsterID);
						float3 vector3 = new float3(float.Parse(position[0]) + RandomHelper.RandomNumberFloat(-1 * range, range),
							float.Parse(position[1]), float.Parse(position[2]) + RandomHelper.RandomNumberFloat(-1 * range, range));
						UnitFactory.CreateMonster(scene, MonsterID, vector3,
							new CreateMonsterInfo() { Camp = monsterConfig.MonsterCamp, Rotation = monsterPosition.Create, });
					}
					break;
				case 3:
					//定时刷新  YeWaiRefreshComponent
					scene.GetComponent<YeWaiRefreshComponent>().CreateMonsterByPos(monsterPosition.Id);
					break;
				case 4:
					//4; 0,0,0; 71020001; 2,2; 2, 2
					int playerLv = 1;
					if (scene.GetComponent<MapComponent>().MapType == MapTypeEnum.Tower)
					{
						//Unit mainUnit = scene.GetComponent<TowerComponent>().MainUnit;
						//playerLv = mainUnit.GetComponent<UserInfoComponentServer>().GetLv();
					}

					if (CreateNum > 100)
					{
						Log.Error($"monsterPosition.CreateNum:  {CreateNum}");
						return ;
					}

					for (int c = 0; c < CreateNum; c++)
					{
						float range = (float) monsterPosition.CreateRange;
						MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(MonsterID);
						float3 vector3 = new float3(float.Parse(position[0]) + RandomHelper.RandomNumberFloat(-1 * range, range),
							float.Parse(position[1]), float.Parse(position[2]) + RandomHelper.RandomNumberFloat(-1 * range, range));
						UnitFactory.CreateMonster(scene, MonsterID, vector3, new CreateMonsterInfo()
						{
							PlayerLevel = playerLv,
							AttributeParams = monsterPosition.Par,
							Camp = monsterConfig.MonsterCamp,
							Rotation = monsterPosition.Create,
						});
					}
					break;
				case 5:
				case 6:
					//固定时间刷新  YeWaiRefreshComponent
					scene.GetComponent<YeWaiRefreshComponent>().CreateMonsterByPos_2(monsterPosition.Id);
					break;
				case 7:
					// 类型3：  30,60 30s后开始刷新     每60s刷一轮
					// 类型7    10,2@20,2             10s 刷新一波 20刷新2波  后面跟的是怪物数量,怪物ID从前面随机获取
					//定时刷新  YeWaiRefreshComponent
                    				scene.GetComponent<YeWaiRefreshComponent>().CreateMonsterByRandom(monsterPosition);
					break;
				default:
					break;	
			}
		}

		private static int CreateMonsterByPos(Scene scene, int monsterPos)
		{
			if (monsterPos == 0)
			{
				return 0;
			}

			if (!MonsterPositionConfigCategory.Instance.Contain(monsterPos))
			{
				Log.Error($"monsterPos: {monsterPos}");
				return 0;
			}

			//Id      NextID  Type Position             MonsterID CreateRange CreateNum Create    Par(3代表刷新时间)
			//10001   10002   2    - 71.46,0.34,-5.35   81000002       0           1       90    30,60
			MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.Get(monsterPos);
			for (int i = 0; i < monsterPosition.MonsterID.Length; i++)
			{
				CreateMonsterById( scene,  monsterPosition, monsterPosition.MonsterID[i], monsterPosition.CreateNum[0] );
			}
			return monsterPosition.NextID;
		}

		public static List<KeyValuePairInt> GetLocalDungeonRandomMonster(Scene scene,int sceneType , string createMonster)
		{
			List<KeyValuePairInt> randomMonsterList = new List<KeyValuePairInt>();

			if (sceneType != MapTypeEnum.LocalDungeon)
			{
				return randomMonsterList;
			}

			MapComponent mapComponent = scene.GetComponent<MapComponent>();
			LocalDungeonComponent localDungeonComponent = scene.GetComponent<LocalDungeonComponent>();
			Unit mainUnit = localDungeonComponent.MainUnit;

			UserInfoComponentS userInfoComponent = mainUnit.GetComponent<UserInfoComponentS>();
			NumericComponentS numericComponent = mainUnit.GetComponent<NumericComponentS>();
			
			TaskPro taskPro = mainUnit.GetComponent<TaskComponentS>().GetTreasureMonster(mapComponent.SceneId);
			if (taskPro != null)
			{
				TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
				KeyValuePairInt keyValuePairInt = new KeyValuePairInt();
				keyValuePairInt.KeyId = taskPro.WaveId;
				keyValuePairInt.Value = taskConfig.Target[0];
				randomMonsterList.Add(keyValuePairInt);
			}

			string[] monsters = createMonster.Split('@');
			if (SeasonHelper.GetOpenSeason(userInfoComponent.GetUserLv())!=null)
			{
				//赛季boss
				long serverNow = TimeHelper.ServerNow();
				long seasonBossTime = numericComponent.GetAsLong(NumericType.SeasonBossRefreshTime);
				int sessonBossFuben = numericComponent.GetAsInt(NumericType.SeasonBossFuben);
				int bossId = ConfigData.SeasonBossId;
				if (seasonBossTime > 0 && serverNow > seasonBossTime && mapComponent.SceneId == sessonBossFuben)
				{
					KeyValuePairInt keyValuePairInt = new KeyValuePairInt();
					keyValuePairInt.KeyId = RandomHelper.RandomNumber(0, monsters.Length);
					keyValuePairInt.Value = bossId;
					randomMonsterList.Add(keyValuePairInt);
				}
			}

            for (int i = 0; i < monsters.Length; i++)
			{
				if (CommonHelp.IfNull(monsters[i]))
				{
					continue;
				}

				string[] mondels = monsters[i].Split(';');
				int monsterid = int.Parse(mondels[2]);
				MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);

                if (monsterConfig.MonsterType == MonsterTypeEnum.Boss)
                {
                    continue;
                }
                if (monsterConfig.MonsterType == MonsterTypeEnum.SceneItem && monsterConfig.MonsterSonType == 55)
				{
                    continue;
                }
                //if (monsterConfig.MonsterType != MonsterTypeEnum.Normal && monsterConfig.MonsterSonType != 55)
                //{
                //	continue;
                //}

                if (numericComponent.GetAsInt(NumericType.JingLingRefreshTime) >= 30)
				{
					break;
				}

				int randomid = userInfoComponent.GetRandomMonsterId();
				if (randomid > 0)
				{
					KeyValuePairInt keyValuePairInt = new KeyValuePairInt();
					keyValuePairInt.KeyId = i;
					keyValuePairInt.Value = randomid;

					randomMonsterList.Add(keyValuePairInt);
					break;
				}

				randomid = userInfoComponent.GetRandomJingLingId();
				if (randomid > 0)
				{
					KeyValuePairInt keyValuePairInt = new KeyValuePairInt();
					keyValuePairInt.KeyId = i;
					keyValuePairInt.Value = randomid;

					randomMonsterList.Add(keyValuePairInt);
					break;
				}
			}

			
			numericComponent.ApplyChange( NumericType.JingLingRefreshTime, 1, false);
			return randomMonsterList;
		}

		/// <summary>
		/// 宝宝类型  0普通 1  宝宝  2 变异宝宝  3普通怪物[生成宠物的时候用到]
		/// </summary>
		/// <param name="monsterId"></param>
		/// <returns></returns>
		public static int GetBabyType(int sceneType, int babyNumber, MonsterConfig monsterConfig)
		{
			if (babyNumber >= GlobalValueConfigCategory.Instance.BabyRefreshMaxNum)
			{
				return 0;	
			}

			if (sceneType != MapTypeEnum.LocalDungeon)
			{
				return 0;	
			}

			if (monsterConfig.MonsterType != MonsterTypeEnum.Normal)
			{
				return 0;
			}

			float rvalue = RandomHelper.RandFloat01();
			if (rvalue< GlobalValueConfigCategory.Instance.BabyBianYiRefreshChance)
			{
				return 2;
			}
			if (rvalue < GlobalValueConfigCategory.Instance.BabyRefreshChance)
			{
				return 1;
			}

			return 0;
		}

		public static void CreateMonsterList(Scene scene, string createMonster)
		{
			if (CommonHelp.IfNull(createMonster))
			{
				return;
			}

			MapComponent mapComponent = scene.GetComponent<MapComponent>();
			int sceneType = mapComponent.MapType;
			string[] monsters = createMonster.Split('@');
			//1;37.65,0,3.2;70005005;1@138.43,0,0.06;70005010;1

			int babyNumber = 0;
			if (sceneType == MapTypeEnum.LocalDungeon)
			{
				LocalDungeonComponent localDungeonComponent = scene.GetComponent<LocalDungeonComponent>();
				NumericComponentS numericComponent = localDungeonComponent.MainUnit.GetComponent<NumericComponentS>();
				babyNumber = numericComponent.GetAsInt(NumericType.BabyRefreshTime);
			}
			List<KeyValuePairInt> randomMonsterList = GetLocalDungeonRandomMonster(scene, sceneType, createMonster);

			for (int i = 0; i < monsters.Length; i++)
			{
				if (CommonHelp.IfNull(monsters[i]))
				{
					continue;
				}

				//2;37.65,0,3.2;70005005;1,2
				string[] mondels = monsters[i].Split(';');
				string[] mtype = mondels[0].Split(',');
				string[] position = mondels[1].Split(',');
				int monsterid = int.Parse(mondels[2]);
				string[] mcount = mondels[3].Split(',');
				if (!MonsterConfigCategory.Instance.Contain(monsterid))
				{
					Log.Error($"monsterid==null {monsterid}");
					continue;
				}

				bool haveotherMonster = false;
				MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);
				for (int kk = 0; kk < randomMonsterList.Count; kk++)
				{
					if (position.Length < 3)
					{
						Log.Warning($"生成随机怪错误： {mapComponent.SceneId} {i} {(int) randomMonsterList[kk].Value}  {position}");
					}

					if (randomMonsterList[kk].KeyId == i && (int) randomMonsterList[kk].Value > 0 && position.Length >= 3)
					{
						int tempmonsterid = (int) randomMonsterList[kk].Value;
						MonsterConfig tempmonsterConfig = MonsterConfigCategory.Instance.Get(tempmonsterid);
						
						float3 vector3 = new float3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
						Unit unitmonster = UnitFactory.CreateMonster(scene, tempmonsterid, vector3,
							new CreateMonsterInfo() { Camp = tempmonsterConfig.MonsterCamp, SkinId = 0 });

						haveotherMonster = true;
					}
				}

				if (haveotherMonster)
				{
					//continue;
				}
				
				
				
				//剧情副本一次性宝箱
				if (sceneType == MapTypeEnum.LocalDungeon && monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_55)
				{
					LocalDungeonComponent localDungeonComponent = scene.GetComponent<LocalDungeonComponent>();
					UserInfoComponentS userInfoComponent = localDungeonComponent.MainUnit.GetComponent<UserInfoComponentS>();
					TaskComponentS taskComponent = localDungeonComponent.MainUnit.GetComponent<TaskComponentS>();
					if (userInfoComponent.IsCheskOpen(mapComponent.SceneId, monsterid)
					    && !taskComponent.IsItemTask(monsterid))
					{
						continue;
					}
				}
				
				if (mtype[0] == "1") //固定位置刷怪
				{
					int cmcount = int.Parse(mcount[0]);
					if (cmcount > 100)
					{
						Log.Error($"int.Parse(mcount[0]) > 100； {createMonster}");
						return;
					}

					for (int c = 0; c < cmcount; c++)
					{
						float3 vector3 = new float3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
						
						if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_52)
						{
							CellDungeonComponentS cellDungeonComponent = scene.GetComponent<CellDungeonComponentS>();
							if (cellDungeonComponent!=null)
							{
								List<int> EnergySkills = cellDungeonComponent.EnergySkills;
								int skillId = EnergySkills[RandomHelper.RandomNumber(0, EnergySkills.Count)];
								EnergySkills.Remove(skillId);
								UnitFactory.CreateMonster(scene, monsterConfig.Id, vector3, new CreateMonsterInfo()
								{
									SkillId = skillId,
									Camp = monsterConfig.MonsterCamp
								});
							}
						}
						else
						{
							int babyType  = GetBabyType(sceneType, babyNumber, monsterConfig);
							if (babyType > 0)
							{
								babyNumber++;
							}

							UnitFactory.CreateMonster(scene, monsterid, vector3, new CreateMonsterInfo() { Camp = monsterConfig.MonsterCamp ,BaByType = babyType});
						}
					}
				}

				if (mtype[0] == "2") //随机位置
				{
					int cmcount = int.Parse(mcount[0]);
					if (cmcount > 100)
					{
						Log.Error($"int.Parse(mcount[0]) > 100； {createMonster}");
						return;
					}

					for (int c = 0; c < cmcount; c++)
					{
						float range = float.Parse(mcount[1]);
						float3 vector3 = new float3(float.Parse(position[0]) + RandomHelper.RandomNumberFloat(-1 * range, range),
							float.Parse(position[1]), float.Parse(position[2]) + RandomHelper.RandomNumberFloat(-1 * range, range));
						
						int babyType  = GetBabyType(sceneType, babyNumber, monsterConfig);
						if (babyType > 0)
						{
							babyNumber++;
						}
						UnitFactory.CreateMonster(scene, monsterid, vector3, new CreateMonsterInfo() { Camp = monsterConfig.MonsterCamp, BaByType = babyType});
					}
				}

				if (mtype[0] == "3")
				{
					//野外场景定时刷新
					//scene.GetComponent<YeWaiRefreshComponent>().CreateMonsterList(monsters[i]);
				}

				if (mtype[0] == "4")
				{
					//4; 0,0,0; 71020001; 2,2; 2, 2  //是随机塔附加属性
					int playerLv = 1;
					if (scene.GetComponent<MapComponent>().MapType == MapTypeEnum.Tower)
					{
						//Unit mainUnit = scene.GetComponent<TowerComponent>().MainUnit;
						//playerLv = mainUnit.GetComponent<UserInfoComponent>().UserInfo.Lv;
					}

					int cmcount = int.Parse(mcount[0]);
					if (cmcount > 100)
					{
						Log.Error($"int.Parse(mcount[0]) > 100； {createMonster}");
						return;
					}

					for (int c = 0; c < cmcount; c++)
					{
						float range = float.Parse(mcount[1]);
						float3 vector3 = new float3(float.Parse(position[0]) + RandomHelper.RandomNumberFloat(-1 * range, range),
							float.Parse(position[1]), float.Parse(position[2]) + RandomHelper.RandomNumberFloat(-1 * range, range));
						UnitFactory.CreateMonster(scene, monsterid, vector3,
							new CreateMonsterInfo()
							{
								PlayerLevel = playerLv, AttributeParams = mondels[4] + ";" + mondels[5], Camp = monsterConfig.MonsterCamp
							});
					}
				}

				//固定时间刷新
				if (mtype[0] == "5" || mtype[0] == "6")
				{
					//scene.GetComponent<YeWaiRefreshComponent>().CreateMonsterList_2(monsters[i]);
				}
			}
			
			if (sceneType == MapTypeEnum.LocalDungeon)
			{
				LocalDungeonComponent localDungeonComponent = scene.GetComponent<LocalDungeonComponent>();
				NumericComponentS numericComponent = localDungeonComponent.MainUnit.GetComponent<NumericComponentS>();
				numericComponent.ApplyValue( NumericType.BabyRefreshTime, babyNumber, false);
			}
		}

		public static void CreateNpc(Scene scene, int sceneId)
		{
			SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
			int[] npcs = sceneConfig.NpcList;
			if (npcs == null)
			{
				return;
			}

			for (int i = 0; i < npcs.Length; i++)
			{
				if (npcs[i] == 0)
				{
					continue;
				}

				UnitFactory.CreateNpc(scene, npcs[i]);
			}
		}

		public static bool IsAllMonsterDead(Scene scene, Unit main)
		{
			List<EntityRef<Unit>> units = scene.GetComponent<UnitComponent>().GetAll();
			for (int i = 0; i < units.Count; i++)
			{
				Unit unititem = units[i];
				if (unititem.Type == UnitType.Monster && main.IsCanAttackUnit(units[i]))
				{
					return false;
				}
			}

			return true;
		}

		public static int GetAlivePetNumber(Scene scene)
		{
			int petNumber = 0;
			List<EntityRef<Unit>> units = scene.GetComponent<UnitComponent>().GetAll();
			for (int i = 0; i < units.Count; i++)
			{
				Unit unititem = units[i];
				if (unititem.Type == UnitType.Pet && unititem.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) == 0)
				{
					petNumber++;
				}
			}

			return petNumber;
		}

		public static void SendTeamPickMessage(Unit unit, UnitInfo dropInfo, List<long> ids, List<int> points)
		{
			// m2C_SyncChatInfo.ChatInfo = new ChatInfo();
			// m2C_SyncChatInfo.ChatInfo.PlayerLevel = unit.GetComponent<UserInfoComponent>().UserInfo.Lv;
			// m2C_SyncChatInfo.ChatInfo.Occ = unit.GetComponent<UserInfoComponent>().UserInfo.Occ;
			// m2C_SyncChatInfo.ChatInfo.ChannelId = (int)ChannelEnum.Pick;
			//
			// ItemConfig itemConfig = ItemConfigCategory.Instance.Get(dropInfo.ItemID);
			// string numShow = "";
			// if (itemConfig.Id == 1)
			// {
			// 	numShow = dropInfo.ItemNum.ToString();
			// }
			// string colorValue = ComHelp.QualityReturnColor(itemConfig.ItemQuality);
			// m2C_SyncChatInfo.ChatInfo.ChatMsg = $"<color=#FDD376>{unit.GetComponent<UserInfoComponent>().UserInfo.Name}</color>拾取<color=#{colorValue}>{numShow}{itemConfig.ItemName}</color>";
			//
			// for (int p = 0; p < points.Count; p++)
			// {
			// 	Unit player = unit.GetParent<UnitComponent>().Get(ids[p]);
			// 	if (player == null)
			// 	{
			// 		continue;
			// 	}
			// 	
			// 	m2C_SyncChatInfo.ChatInfo.ChatMsg += $"{player.GetComponent<UserInfoComponent>().UserInfo.Name}:{points[p]}点";
			// 	m2C_SyncChatInfo.ChatInfo.ChatMsg += (p == points.Count - 1 ? "" : "  ");
			// }
			//
			// MessageHelper.SendToClient(UnitHelper.GetUnitList(unit.DomainScene(), UnitType.Player), m2C_SyncChatInfo);
		}

		public static void SendFubenPickMessage(Unit unit, UnitInfo dropInfo)
		{
			// UserInfoComponent userInfoComponent = unit.GetComponent<UserInfoComponent>();
			// m2C_SyncChatInfo.ChatInfo = new ChatInfo();
			// m2C_SyncChatInfo.ChatInfo.PlayerLevel = userInfoComponent.UserInfo.Lv;
			// m2C_SyncChatInfo.ChatInfo.Occ = userInfoComponent.UserInfo.Occ;
			// m2C_SyncChatInfo.ChatInfo.ChannelId = (int)ChannelEnum.Pick;
			//
			// ItemConfig itemConfig = ItemConfigCategory.Instance.Get(dropInfo.ItemID);
			// string numShow = "";
			// if (itemConfig.Id == 1)
			// {
			// 	numShow = dropInfo.ItemNum.ToString();
			// }
			// string colorValue = ComHelp.QualityReturnColor(itemConfig.ItemQuality);
			// m2C_SyncChatInfo.ChatInfo.ChatMsg = $"<color=#FDD376>{unit.GetComponent<UserInfoComponent>().UserInfo.Name}</color>拾取<color=#{colorValue}>{numShow}{itemConfig.ItemName}</color>";
			// //MessageHelper.SendToClient(GetUnitList(unit.DomainScene(), UnitType.Player), m2C_SyncChatInfo);
			// //Log.Warning($"SendFubenPickMessage: {unit.Id} {dropInfo.ItemID}");
			// MessageHelper.SendToClient(unit, m2C_SyncChatInfo);
		}
	}
}