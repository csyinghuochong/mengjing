﻿using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetHeChengHandler : MessageLocationHandler<Unit, C2M_RolePetHeCheng, M2C_RolePetHeCheng>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetHeCheng request, M2C_RolePetHeCheng response)
		{
			//读取数据库
			PetComponentS petComponent = unit.GetComponent<PetComponentS>();

			RolePetInfo petinfo_1 = petComponent.GetPetInfo(request.PetInfoId1);
			RolePetInfo petinfo_2 = petComponent.GetPetInfo(request.PetInfoId2);
			if (petinfo_1 == null || petinfo_2 == null)
			{
				response.Error = ErrorCode.ERR_Pet_NoExist;
				return;
			}
            if (petinfo_1.PetStatus == 1 || petinfo_2.PetStatus == 1)
            {
                response.Error = ErrorCode.ERR_Pet_Hint_4;
                return;
            }
			//错误码
			//判定是否出战
			//if (PetStatus_1 == 1 || PetStatus_2 == 2)
			//{
			//	response.Error = 1;
			//}
			//改变第一个宠物的数据	

			//宠物合成次数
			int petHeChengNumber = unit.GetComponent<DataCollationComponent>().PetHeCheng;

            int petLv_1 = petinfo_1.PetLv;
			int petLv_2 = petinfo_2.PetLv;
		
			int petID_1 = petinfo_1.ConfigId;
			int petID_2 = petinfo_2.ConfigId;

			////神兽无法合成
			PetConfig xiulianconf1 = PetConfigCategory.Instance.Get(petID_1);
			PetConfig xiulianconf2 = PetConfigCategory.Instance.Get(petID_2);
			int petType_1 = xiulianconf1.PetType;
			int petType_2 = xiulianconf2.PetType;
			
			// 获取宠物1
			string petName_1 = petinfo_1.PetName;
			//资质
			int zizhiNow_Hp_1 = petinfo_1.ZiZhi_Hp;
			int zizhiNow_Act_1 = petinfo_1.ZiZhi_Act;
			int zizhiNow_MageAct_1 = petinfo_1.ZiZhi_MageAct;
			int zizhiNow_Def_1 = petinfo_1.ZiZhi_Def;
			int zizhiNow_Adf_1 = petinfo_1.ZiZhi_Adf;
			int zizhiNow_ActSpeed_1 = petinfo_1.ZiZhi_ActSpeed;
			float zizhiNow_ChengZhang_1 = petinfo_1.ZiZhi_ChengZhang;
			//技能
			List<int> petSkillList_1 = petinfo_1.PetSkill;

			//获取宠物2
			string petName_2 = petinfo_2.PetName;
			//资质
			int zizhiNow_Hp_2 = petinfo_2.ZiZhi_Hp;
			int zizhiNow_Act_2 = petinfo_2.ZiZhi_Act;
			int zizhiNow_MageAct_2 = petinfo_2.ZiZhi_MageAct;
			int zizhiNow_Def_2 = petinfo_2.ZiZhi_Def;
			int zizhiNow_Adf_2 = petinfo_2.ZiZhi_Adf;
			int zizhiNow_ActSpeed_2 = petinfo_2.ZiZhi_ActSpeed;
			float zizhiNow_ChengZhang_2 = petinfo_2.ZiZhi_ChengZhang;
			//技能
			List<int> petSkillList_2 = petinfo_2.PetSkill;

			//设定每个技能的留下的概率
			float skillpro = 0.4f;
			int sumValue = petSkillList_1.Count + petSkillList_2.Count;

			//根据技能数量决定合成概率
			if (sumValue < 8)
			{
				skillpro = 0.5f;
			}

			if (sumValue < 6)
			{
				skillpro = 0.6f;
			}

			if (sumValue < 4)
			{
				skillpro = 0.7f;
			}

			//前期优化合成技能概率
			float addPro = 0;

			if (petHeChengNumber <= 10)
			{
				if (sumValue <= 6)
				{
					addPro = 0.05f;
				}
			}

			if (petHeChengNumber <= 5)
			{
				if (sumValue <= 6)
				{
					addPro = 0.1f;
				}
			}

			if (petHeChengNumber <= 1)
			{
				if (sumValue <= 6)
				{
					addPro = 0.15f;
				}
			}

			skillpro = skillpro + addPro;

			List<int> savePetSkillID = new List<int>();
			List<int> deletPetSkillID = new List<int>();

			for (int i = 0; i < petSkillList_1.Count; i++)
			{
				if (!savePetSkillID.Contains(petSkillList_1[i]))
				{
					if (savePetSkillID.Contains(petSkillList_1[i]) == false && RandomHelper.RandFloat01() <= skillpro && savePetSkillID.Count <= 12)
					{
						savePetSkillID.Add(petSkillList_1[i]);
					}
					else {
						deletPetSkillID.Add(petSkillList_1[i]);
					}
				}
			}

			try
			{
				for (int i = 0; i < petSkillList_2.Count; i++)
				{
					if (!savePetSkillID.Contains(petSkillList_2[i]))
					{
						if (savePetSkillID.Contains(petSkillList_2[i]) == false && RandomHelper.RandFloat01() <= skillpro && savePetSkillID.Count <= 12)
						{
							savePetSkillID.Add(petSkillList_2[i]);
						}
						else
						{
							deletPetSkillID.Add(petSkillList_2[i]);
						}
					}
				}

				//500次内如果合成技能较少额外多补1个技能
				//if (petHeChengNumber <= 500)
				//{
					if (sumValue <= 12) {
						if (savePetSkillID.Count < (int)((float)sumValue / 2f)) {
							//额外补一个技能
							if (deletPetSkillID.Count >= 1) {
								if (savePetSkillID.Contains(deletPetSkillID[0]) == false) {
									savePetSkillID.Add(deletPetSkillID[0]);
								}
							}
						}
					}
				//}
			}
			catch (Exception ex)
			{
				Log.Console("C2M_RolePetHeCheng: " +  ex.ToString());
			}

            int petID = 0;
			PetConfig itemConf1 = PetConfigCategory.Instance.Get(petID_1);
			PetConfig itemConf2 = PetConfigCategory.Instance.Get(petID_2);
			int fightLv_1 = itemConf1.FightLv;
			int fightLv_2 = itemConf2.FightLv;

			float number = RandomHelper.RandFloat();
            //合成形象,50%概率
            petID = petID_1;
            if (number <= 0.5f)
			{
                petID = petID_2;
            }
            else
            {
                petID = petID_1;
            }

            //填补必带技能
            PetConfig bidaiPet = PetConfigCategory.Instance.Get(petID);
			string[] baseSkillID = bidaiPet.BaseSkillID.Split(';');
			for (int i = 0; i < baseSkillID.Length;i++) {
				if (savePetSkillID.Contains(int.Parse(baseSkillID[i])) == false) {
					savePetSkillID.Add(int.Parse(baseSkillID[i]));
				}
			}

			int zizhiNow_Hp = (int)Pet_HeCheng_ZiZhi(zizhiNow_Hp_1, zizhiNow_Hp_2, 3000);
			int zizhiNow_Act = (int)Pet_HeCheng_ZiZhi(zizhiNow_Act_1, zizhiNow_Act_2, 1600);
			int zizhiNow_MageAct = (int)Pet_HeCheng_ZiZhi(zizhiNow_MageAct_1, zizhiNow_MageAct_2, 1600);
			int zizhiNow_Def = (int)Pet_HeCheng_ZiZhi(zizhiNow_Def_1, zizhiNow_Def_2, 1600);
			int zizhiNow_Adf = (int)Pet_HeCheng_ZiZhi(zizhiNow_Adf_1, zizhiNow_Adf_2, 1600);
			int zizhiNow_ActSpeed = (int)Pet_HeCheng_ZiZhi(zizhiNow_ActSpeed_1, zizhiNow_ActSpeed_2, 3000);
			float zizhiNow_ChengZhang = Pet_HeCheng_ZiZhi(zizhiNow_ChengZhang_1, zizhiNow_ChengZhang_2, 1.3f);
			//目前攻速不做调整,强制为3000
			zizhiNow_ActSpeed = 3000;

		
			//填补必带技能

			int pet_Lv = 1;

			int pet_exp = 0;
			int addPropertyNum = pet_Lv * 5 + 20;
			string addPropertyValue = ConfigData.DefaultGem;

			//合成等级
			pet_Lv = (int)(math.min(petLv_1, petLv_2) * 0.75f + (math.max(petLv_1, petLv_2) - math.min(petLv_1, petLv_2)) * GetRandomZeroTOne());
			pet_exp = 10000; // Config.Instance.GetConf<Exp>(pet_Lv).PetUpExp;
			pet_exp = (int)(pet_exp * GetRandomZeroTOne());
			if (pet_Lv < 1)
			{
				pet_Lv = 1;
			}


            /*
			bool baby_1 = petinfo_1.IfBaby;
			bool baby_2 = petinfo_2.IfBaby;
			//获取目标是否为宝宝,如果两个都为宝宝则本次必定变成宝宝
			if (baby_1 && baby_2)
			{
				baby = true;

			}
			else
			{

				//每次合野生有5%概率让起变成宝宝
				if (GetRandomZeroTOne() <= 0.05f)
				{
					baby_1 = true;
					pet_Lv = 1;
					pet_exp = 0;
					addPropertyNum = (pet_Lv - 1) * 5 + 20;
					int writeProValue = 15 + (pet_Lv - 1) * 1;
					addPropertyValue = writeProValue + "_" + writeProValue + "_" + writeProValue + "_" + writeProValue;
				}
				else
				{
					//每次合成有5%概率变成软泥怪
					if (GetRandomZeroTOne() <= 0.05f)
					{
						baby_1 = true;
						pet_Lv = 1;
						pet_exp = 0;
						addPropertyNum = (pet_Lv - 1) * 5 + 20;
						addPropertyValue = ItemHelper.DefaultGem;
						petID = 10001020;
						savePetSkillID = new List<int>();

						//读取必带技能
						PetConfig petConfig = PetConfigCategory.Instance.Get(petID);
						if (petConfig.BaseSkillID.Length != 0)
						{
							for (int i = 0; i < petConfig.BaseSkillID.Length; i++)
							{
								savePetSkillID.Add(petConfig.BaseSkillID[i]);
							}
						}

						//读取随机技能
						PetConfig petconfx = PetConfigCategory.Instance.Get(petID);
						string randomSkillID = petconfx.RandomSkillID;
						if (randomSkillID != "" && randomSkillID != "0")
						{
							string[] randomSkillList = randomSkillID.Split(';');
							for (int i = 0; i < randomSkillList.Length; i++)
							{
								float skillPro = float.Parse(randomSkillList[i].Split(',')[1]);
								string skillID = randomSkillList[i].Split(',')[0];
								if (GetRandomZeroTOne() <= skillPro && skillID != "" && skillID != null && skillID != "0")
								{
									savePetSkillID.Add(int.Parse(skillID));
								}
							}
						}

						//写入成就(大海龟)
						///////Game_PublicClassVar.Get_function_Task.ChengJiu_WriteValue("211", "0", "1");
					}
					else
					{
						//普通合成等级
						pet_Lv = (int)(Mathf.Min(petLv_1, petLv_2) * 0.75f + (Mathf.Max(petLv_1, petLv_2) - Mathf.Min(petLv_1, petLv_2)) * (GetRandomZeroTOne()));
						pet_exp = 10000; // Config.Instance.GetConf<Exp>(pet_Lv).PetUpExp;
						pet_exp = (int)(pet_exp * GetRandomZeroTOne());
						if (pet_Lv < 1)
						{
							pet_Lv = 1;
						}
						//随机点数
						int AddProretyNum = (pet_Lv - 1) * 5 + 20 + (pet_Lv - 1) * 4;
						//如果是宝宝属性点会上升
						if (baby == true)
						{
							AddProretyNum = 60;
							//addPropertyNum = 0;
							addPropertyNum = (pet_Lv - 1) * 5 + (pet_Lv - 1) * 4;
						}
						else
						{
							addPropertyNum = 0;
						}
						addPropertyValue = PetAddPropertyFenPei(AddProretyNum);
					}
				}
			}
			*/
            //重新写入宠物的数据
            RolePetInfo petinfo_update = null;
			RolePetInfo petinfo_delete = null;
			if (petID == petID_1)
			{
				petinfo_update = petinfo_1;
				petinfo_delete = petinfo_2;
			}
			else
			{
				petinfo_update = petinfo_2;
				petinfo_delete = petinfo_1;
			}
			petinfo_update.ConfigId = petID;
			petinfo_update.PetLv = pet_Lv;
			petinfo_update.PetExp = pet_exp;
			petinfo_update.BabyType = 0;
			petinfo_update.AddPropretyNum = addPropertyNum;
			petinfo_update.AddPropretyValue = addPropertyValue;
			petinfo_update.PetPingFen = 0;
			petinfo_update.ZiZhi_Hp = zizhiNow_Hp;
			petinfo_update.ZiZhi_Act = zizhiNow_Act;
			petinfo_update.ZiZhi_MageAct = zizhiNow_MageAct;
			petinfo_update.ZiZhi_Def = zizhiNow_Def;
			petinfo_update.ZiZhi_Adf = zizhiNow_Adf;
			petinfo_update.ZiZhi_ActSpeed = zizhiNow_ActSpeed;
			//petinfo_update.ZiZhi_ChengZhang = Mathf.FloorToInt(zizhiNow_ChengZhang * GetMultiple());
			petinfo_update.ZiZhi_ChengZhang = zizhiNow_ChengZhang;
			petinfo_update.PetSkill = savePetSkillID;
			PetConfig petconf = PetConfigCategory.Instance.Get(petID);
			petinfo_update.PetName = petconf.PetName;
            petinfo_update.LockSkill.Clear();
            petComponent.OnResetPoint(petinfo_update);
			petComponent.RemovePet(petinfo_delete.Id);
			unit.GetComponent<ChengJiuComponentS>().OnPetHeCheng(petinfo_update);
			unit.GetComponent<TaskComponentS>().OnPetHeCheng(petinfo_update);
			unit.GetComponent<DataCollationComponent>().PetHeCheng++;

            petComponent.CheckPetPingFen();
			petComponent.CheckPetZiZhi();
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            response.DeletePetInfoId = petinfo_delete.Id;
			response.rolePetInfo = petinfo_update;
			await ETTask.CompletedTask;
		}

		public int GetMultiple()
		{
			return 10000;
		}

		public float GetRandomZeroTOne()
		{
			return RandomHelper.RandomNumber(0, 10) * 0.1f;
		}

		//随机分配指定点数
		public string PetAddPropertyFenPei(int sumNum)
		{
			//取4个随机值
			float ran_1 = RandomHelper.RandomNumber(0, 5) * 0.1f;
			float ran_2 = RandomHelper.RandomNumber(0, 5) * 0.1f;
			int ran_ss = (int)math.floor((1 - ran_1 - ran_2) * 10);
			float ran_3 = RandomHelper.RandomNumber(0, ran_ss) * 0.1f;
			float ran_4 = 1 - ran_1 - ran_2 - ran_3;
			int add_1 = (int)(sumNum * ran_1);
			int add_2 = (int)(sumNum * ran_2);
			int add_3 = (int)(sumNum * ran_3);
			int add_4 = (int)(sumNum * ran_4);

			return add_1 + "_" + add_2 + "_" + add_3 + "_" + add_4;
		}

		public float Pet_HeCheng_ZiZhi(float zizhiValue_1, float zizhiValue_2, float maxZiZhi = 99999, string ziZhiType = "0")
		{
			/*
			float zizhi_1 = 0.04f;
			float zizhi_2 = 0.75f;
			float zizhi_3 = 0.25f;
			float zizhi_4 = 1.1f;

			if (ziZhiType == "1")
			{
				Random example = new Random();
				float number = example.Next(1, 10) * 0.1f;
				//5%概率满资质
				if (number <= zizhi_1)
				{
					return Mathf.Max(zizhiValue_1, zizhiValue_2);
				}
			}
			*/
			//获取随机资质
			/*
			Random example2 = new Random();
			float number2 = example2.Next(1, 10) * 0.1f;
			float zhizhiValue = Mathf.Min(zizhiValue_1, zizhiValue_2) * zizhi_2 + ((Mathf.Min(zizhiValue_1, zizhiValue_2) * zizhi_3 + Mathf.Max(zizhiValue_1, zizhiValue_2) - Mathf.Min(zizhiValue_1, zizhiValue_2))) * number2 * zizhi_4;
			*/

			float ZiZhimin = math.min(zizhiValue_1, zizhiValue_2);
			float ZiZhimax = math.max(zizhiValue_1, zizhiValue_2);

			ZiZhimin = ZiZhimin * 0.95f;
			ZiZhimax = ZiZhimax * 1.05f;

			float chaValuie = ZiZhimax - ZiZhimin;

			float zhizhiValue = ZiZhimin + chaValuie * RandomHelper.RandFloat01();

			//限制最高资质
			if (zhizhiValue > maxZiZhi)
			{
				zhizhiValue = maxZiZhi;
			}

            return (float)Math.Round(zhizhiValue, 2) ;
		}
	}
}