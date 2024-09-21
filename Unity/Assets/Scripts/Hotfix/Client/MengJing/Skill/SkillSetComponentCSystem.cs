using System.Collections.Generic;

namespace ET.Client
{

    [EntitySystemOf(typeof(SkillSetComponentC))]
    [FriendOf(typeof(SkillSetComponentC))]
    public static partial class SkillSetComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this SkillSetComponentC self)
        {

        }
        [EntitySystem]
        private static void Destroy(this SkillSetComponentC self)
        {

        }

		public static void UpdateSkillSet(this SkillSetComponentC self, SkillSetInfo skillSetInfo)
		{
			self.SkillList = skillSetInfo.SkillList;
			self.TianFuList1 = skillSetInfo.TianFuList1;
			self.LifeShieldList = skillSetInfo.LifeShieldList;
			self.TianFuList2 = skillSetInfo.TianFuList2;
			self.TianFuPlan = skillSetInfo.TianFuPlan;
		}

		public static List<int> TianFuList(this SkillSetComponentC self)
		{
			return self.TianFuPlan == 0 ? self.TianFuList1 : self.TianFuList2;
		}

		public static int HaveSameTianFu(this SkillSetComponentC self, int tianfuId)
		{
			TalentConfig talentConfig = TalentConfigCategory.Instance.Get(tianfuId);
			int learnLv = talentConfig.LearnRoseLv;
			int sameId = 0;
			List<int> tianfulist = self.TianFuList();
			for (int i = 0; i < tianfulist.Count; i++)
			{
				TalentConfig talentConfig2 = TalentConfigCategory.Instance.Get(tianfulist[i]);
				if (talentConfig2.LearnRoseLv == learnLv)
				{
					sameId = tianfulist[i];
					break;
				}
			}
			return sameId;
		}

		public static void OnActiveSkillID(this SkillSetComponentC self, int skillId, int newSkillId)
		{
			//升级替换技能
			for (int i = self.SkillList.Count - 1; i >= 0; i--)
			{
				if (self.SkillList[i].SkillID == skillId)
				{
					self.SkillList[i].SkillID = newSkillId;
					break;
				}
			}
		}

		public static void TianFuRemove(this SkillSetComponentC self, int tianFuid)
		{
			//可以判断一下装备是否还有此天赋
			List<int> tianfuIds = self.TianFuList1;
			if (tianFuid > 0 && tianfuIds.Contains(tianFuid))
			{
				tianfuIds.Remove(tianFuid);
				self.AddTianFuAttribute(tianFuid, false);
			}
			tianfuIds = self.TianFuList2;
			if (tianFuid > 0 && tianfuIds.Contains(tianFuid))
			{
				tianfuIds.Remove(tianFuid);
				self.AddTianFuAttribute(tianFuid, false);
			}
		}

		public static void TianFuAdd(this SkillSetComponentC self, int tianFuid)
		{
			if (tianFuid > 0 && !self.TianFuList().Contains(tianFuid))
			{
				self.TianFuList().Add(tianFuid);
				self.AddTianFuAttribute(tianFuid, true);
			}
		}

		public static void UpdateTianFuPlan(this SkillSetComponentC self, int plan)
		{
			self.TianFuPlan = plan;

			List<int> oldtianfus = plan == 0 ? self.TianFuList2 : self.TianFuList1;
			for (int i = 0; i < oldtianfus.Count; i++)
			{
				self.AddTianFuAttribute(oldtianfus[i], false);
			}
			List<int> newtianfus = plan == 0 ? self.TianFuList1 : self.TianFuList2;
			for (int i = 0; i < newtianfus.Count; i++)
			{
				self.AddTianFuAttribute(newtianfus[i], true);
			}
		}

		/// <summary>
		/// 增加天赋属性
		/// </summary>
		/// <param name="self"></param>
		/// <param name="tianfuId"></param>
		public static void AddTianFuAttribute(this SkillSetComponentC self, int tianfuId, bool add)
		{
			string[] addPropreListStr = TalentConfigCategory.Instance.Get(tianfuId).AddPropreListStr.Split('@');

			for (int k = 0; k < addPropreListStr.Length; k++)
			{
				string[] properInfo = addPropreListStr[k].Split(';');

				switch (properInfo[0])
				{
					case TianFuProEnum.SkillIdAdd:
						self.OnSkillIdAdd(properInfo, add);
						break;
					case TianFuProEnum.SkillPropertyAdd:
						break;
					case TianFuProEnum.BuffIdAdd:
						break;
					case TianFuProEnum.BuffInitIdAdd:
						break;
					case TianFuProEnum.RolePropertyAdd:
						break;
					case TianFuProEnum.ReplaceSkillId:
						break;
					case TianFuProEnum.BuffPropertyAdd:
						break;
				}
			}
		}

		public static void OnSkillIdAdd(this SkillSetComponentC self, string[] properInfo, bool add)
		{
			int skillId = int.Parse(properInfo[1]);

			int index = -1;
			for (int i = self.SkillList.Count - 1; i >= 0; i--)
			{
				if (self.SkillList[i].SkillID == skillId)
				{
					index = i;
				}
			}
			if (add && index == -1)
			{
				SkillPro SkillPro = SkillPro.Create();
				SkillPro.SkillID = skillId;
				SkillPro.SkillSource = (int)SkillSourceEnum.TianFu;
				self.SkillList.Add(SkillPro);
			}
			if (!add && index >= 0)
			{
				self.SkillList.RemoveAt(index);
			}
		}

		public static List<int> GetTianFuIdsByType(this SkillSetComponentC self, string proType)
		{
			List<int> tianfuids = self.TianFuList();
			List<int> typetianfus = new List<int>();

			for (int i = 0; i < tianfuids.Count; i++)
			{
				string[] addPropreListStr = TalentConfigCategory.Instance.Get(tianfuids[i]).AddPropreListStr.Split('@');
				for (int k = 0; k < addPropreListStr.Length; k++)
				{
					string[] properInfo = addPropreListStr[k].Split(';');

					if (properInfo[0] != proType)
					{
						continue;
					}
					typetianfus.Add(tianfuids[i]);
				}
			}
			return typetianfus;
		}

		public static bool IsSkillSingingCancel(this SkillSetComponentC self, int skillId)
		{
			List<int> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.SkillSingingCancel);
			if (tianfuids.Count == 0)
				return false;

			for (int i = 0; i < tianfuids.Count; i++)
			{
				string[] addPropreListStr = TalentConfigCategory.Instance.Get(tianfuids[i]).AddPropreListStr.Split('@');
				for (int k = 0; k < addPropreListStr.Length; k++)
				{
					string[] properInfo = addPropreListStr[k].Split(';');

					if (!properInfo[1].Contains(skillId.ToString()))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static Dictionary<int, float> GetSkillPropertyAdd(this SkillSetComponentC self, int skillId)
		{
			List<int> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.SkillPropertyAdd);
			if (tianfuids.Count == 0)
				return null;

			Dictionary<int, float> HideProList = new Dictionary<int, float>();
			for (int i = 0; i < tianfuids.Count; i++)
			{
				string[] addPropreListStr = TalentConfigCategory.Instance.Get(tianfuids[i]).AddPropreListStr.Split('@');
				for (int k = 0; k < addPropreListStr.Length; k++)
				{
					string[] properInfo = addPropreListStr[k].Split(';');
					if (!properInfo[0].Equals( TianFuProEnum.SkillPropertyAdd))
					{
						continue;
					}
					if (properInfo[1].Contains(skillId.ToString()))
					{
						continue;
					}
					int key = int.Parse(properInfo[2]);
					float value = float.Parse(properInfo[3]);
					if (HideProList.ContainsKey(key))
					{
						HideProList[key] += value;
					}
					else
					{
						HideProList.Add(key, value);
					}
				}
			}
			return HideProList;
		}

		/// <summary>
		/// 可升級的技能列表
		/// </summary>
		/// <param name="self"></param>
		/// <param name="skillpoint"></param>
		/// <returns></returns>
		public static List<int> GetCanUpSkill(this SkillSetComponentC self, int skillpoint)
		{
			List<int> skillids = new List<int>();
			UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
			for (int i = 0; i < self.SkillList.Count; i++)
			{
				if (self.SkillList[i].SkillSetType == (int)SkillSetEnum.Item)
				{
					continue;
				}

				SkillConfig skillConfig_base = SkillConfigCategory.Instance.Get(self.SkillList[i].SkillID);

				if (skillConfig_base.SkillType != 1 && skillConfig_base.SkillType != 6 && skillConfig_base.SkillType != 8)
				{
					continue;
				}

				if (skillConfig_base.NextSkillID == 0)
				{
					continue;
				}

				if (userInfo.Sp < skillConfig_base.CostSPValue)
				{
					continue;
				}
				if (userInfo.Lv < skillConfig_base.LearnRoseLv)
				{
					continue;
				}
				if (userInfo.Gold < skillConfig_base.CostGoldValue)
				{
					continue;
				}

				skillids.Add(self.SkillList[i].SkillID);
			}

			return skillids;
		}

		public static SkillPro GetSkillPro(this SkillSetComponentC self, int skillId)
		{
			for (int i = 0; i < self.SkillList.Count; i++)
			{
				if (self.SkillList[i].SkillID == skillId)
					return self.SkillList[i];
			}
			return null;
		}
		
		/// <summary>
		/// 技能设置
		/// </summary>
		/// <param name="self"></param>
		/// <param name="skillId"></param>
		/// <param name="skillType">1技能 2物品</param>
		/// <param name="pos"></param>
		public static  void OnSetSkillIdByPosition(this SkillSetComponentC self, int skillId, int skillType, int pos)
		{
			//清除之前该位置的技能

			SkillPro newSkill = null;
			if (skillType == 1)
			{
				SkillPro oldSkill = self.GetByPosition(pos);
				if (oldSkill != null)
				{
					oldSkill.SkillPosition = 0;
				}
				newSkill = self.GetBySkillID(skillId);
			}
			else
			{
				SkillPro oldSkill = self.GetByPosition(pos);
				if (oldSkill != null)
				{
					oldSkill.SkillID = 0;
					oldSkill.SkillPosition = 0;
				}
				newSkill = self.GetBySkillID(skillId);
				if (newSkill == null)
				{
					newSkill = SkillPro.Create();
					self.SkillList.Add(newSkill);
				}
			}

			newSkill.SkillID = skillId;
			newSkill.SkillPosition = pos;
			newSkill.SkillSetType = skillType;
			
		}

		public static bool IfEquipMainSkill(this SkillSetComponentC self, int skillId)
		{
			for (int i = self.SkillList.Count - 1; i >= 0; i--)
			{
				if (self.SkillList[i].SkillID == skillId)
				{
					return true;
				}
			}
			return false;
		}

		public static SkillPro GetBySkillID(this SkillSetComponentC self, int skillid)
		{
			for (int i = 0; i < self.SkillList.Count; i++)
			{
				if (self.SkillList[i].SkillID == skillid)
				{
					return self.SkillList[i];
				}
			}
			return null;
		}

		public static SkillPro GetByPosition(this SkillSetComponentC self, int pos)
		{
			for (int i = 0; i < self.SkillList.Count; i++)
			{
				if (self.SkillList[i].SkillPosition == pos)
				{
					return self.SkillList[i];
				}
			}
			return null;
		}

	
		public static SkillPro GetCanUseSkill(this SkillSetComponentC self)
		{
			SkillPro skillPro = self.SkillList[RandomHelper.RandomNumber(0, self.SkillList.Count)];
			return skillPro;
		}

		public static int GetLifeShieldShowId(this SkillSetComponentC self, int shieldType)
		{
			int curLv = self.GetLifeShieldLevel(shieldType);
			int maxLv = LifeShieldConfigCategory.Instance.LifeShieldList[shieldType].Count;
			int nextlifeId = 0;
			if (curLv == maxLv)
			{
				nextlifeId = LifeShieldConfigCategory.Instance.LifeShieldList[shieldType][curLv];
			}
			else
			{
				nextlifeId = LifeShieldConfigCategory.Instance.LifeShieldList[shieldType][curLv + 1];
			}
			return nextlifeId;
		}

		public static LifeShieldInfo GetLifeShieldByType(this SkillSetComponentC self, int sType)
		{
			for (int i = 0; i < self.LifeShieldList.Count; i++)
			{
				if ((int)self.LifeShieldList[i].ShieldType == sType)
				{
					return self.LifeShieldList[i];
				}
			}

			return null;
		}

		/// <summary>
		/// 生命之盾之外的其他最小等级
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static int GetOtherMinLevel(this SkillSetComponentC self)
		{
			int minLevel = 0;
			for (int i = 0; i < self.LifeShieldList.Count; i++)
			{
				if ((int)self.LifeShieldList[i].ShieldType == 6)
				{
					continue;
				}
				if (minLevel == 0 || self.LifeShieldList[i].Level < minLevel)
				{
					minLevel = self.LifeShieldList[i].Level;
				}
			}
			return minLevel;
		}

		public static int GetLifeShieldLevel(this SkillSetComponentC self, int sType)
		{
			for (int i = 0; i < self.LifeShieldList.Count; i++)
			{
				if ((int)self.LifeShieldList[i].ShieldType == sType)
				{
					return self.LifeShieldList[i].Level;
				}
			}

			return 0;
		}

		//和GetSkillRoleProLists方法一致 主要是获取类型为8的被动技能,8的被动技能不加战斗力
		public static List<PropertyValue> GetSkillRoleProLists_8(this SkillSetComponentC self)
		{
			List<PropertyValue> proList = new List<PropertyValue>();
			for (int i = 0; i < self.SkillList.Count; i++)
			{
				if (self.SkillList[i].SkillSetType == (int)SkillSetEnum.Item)
				{
					continue;
				}

				if(!SkillConfigCategory.Instance.Contain(self.SkillList[i].SkillID))
				{
					continue;
				}
				
				SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillList[i].SkillID);

				if (skillConfig.SkillType != (int)SkillTypeEnum.PassiveAddProSkillNoFight)
				{
					continue;
				}

				string GameObjectParameter = skillConfig.GameObjectParameter;
				if (CommonHelp.IfNull(GameObjectParameter))
				{
					continue;
				}

				string[] addProList = GameObjectParameter.Split(';');
				for (int p = 0; p < addProList.Length; p++)
				{
					string[] addPro = addProList[p].Split(',');
					if (addPro.Length < 2)
					{
						break;
					}
					int key = int.Parse(addPro[0]);

					if (NumericHelp.GetNumericValueType(key) == 1)
					{
						proList.Add(new PropertyValue() { HideID = key, HideValue = long.Parse(addPro[1]) });
					}
					else
					{
						proList.Add(new PropertyValue() { HideID = key, HideValue = (int)(float.Parse(addPro[1]) * 10000) });
					}
					
				}
			}
			return proList;
		}
    }
}