using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
	[FriendOf(typeof (NumericComponentS))]
	public static class NumericComponentServerSystem
	{

		//重置所有属性
		public static void ResetProperty(this NumericComponentS self)
		{
			long max = (int)NumericType.Max; 

			foreach (int key in self.NumericDic.Keys)
			{

				//这个范围内的属性为特殊属性不进行重置
				if (key >= NumericType.Now_Hp && key < max)
				{
					continue;
				}

				//buff属性不进行重置
				int yushu = key % 100;
				if (yushu == 11 || yushu == 12)
				{
					continue;
				}

				self.NumericDic[key] = 0;
			}
		}
		
		public static void Reset(this NumericComponentS self)
		{
			//重置所有属性
			long max = (int)NumericType.Max;
			foreach (int key in self.NumericDic.Keys)
			{
				//这个范围内的属性为特殊属性不进行重置
				if (key < max)
				{
					continue;
				}

				self.NumericDic[key] = 0;
			}
		}

		public static float GetAsFloat(this NumericComponentS self, int numericType)
		{
			return (float)self.GetByKey(numericType) / 10000;
		}

		public static int GetAsInt(this NumericComponentS self, int numericType)
		{
			return (int)self.GetByKey(numericType);
		}

		public static long GetAsLong(this NumericComponentS self, int numericType)
		{
			return self.GetByKey(numericType);
		}

		public static void Set(this NumericComponentS self, int nt, float value)
		{
			self[nt] = (long)(value * 10000);
		}

		public static void Set(this NumericComponentS self, int nt, int value)
		{
			self[nt] = value;
		}

		public static void Set(this NumericComponentS self, int nt, long value)
		{
			self[nt] = value;
		}

		public static void SetNoEvent(this NumericComponentS self, int numericType, long value)
		{
			self.Insert(numericType, value, false);
		}

		public static void SetNoEvent(this NumericComponentS self, int numericType, double value)
		{
			self.Insert(numericType,  (long)(value * 10000), false);
		}
		
		public static void Insert(this NumericComponentS self, int numericType, long value, bool isPublicEvent = true)
		{
			long oldValue = self.GetByKey(numericType);
			if (oldValue == value)
			{
				return;
			}

			self.NumericDic[numericType] = value;

			if (numericType >= NumericType.Max)
			{
				self.Update(numericType, isPublicEvent);
				return;
			}

			// if (isPublicEvent)
			// {
			// 	EventSystem.Instance.Publish(self.Scene(),
			// 		new NumbericChange() { Defend = self.GetParent<Unit>(), NewValue = value, OldValue = oldValue, NumericType = numericType });
			// }
		}

		public static long GetByKey(this NumericComponentS self, int key)
		{
			long value = 0;
			self.NumericDic.TryGetValue(key, out value);
			return value;
		}

		public static void Update(this NumericComponentS self, int numericType, bool isPublicEvent)
		{
			int final = (int)numericType / 100;
			int bas = final * 100 + 1;
			int add = final * 100 + 2;
			int pct = final * 100 + 3;
			int finalAdd = final * 100 + 4;
			int finalPct = final * 100 + 5;

			// 一个数值可能会多种情况影响，比如速度,加个buff可能增加速度绝对值100，也有些buff增加10%速度，所以一个值可以由5个值进行控制其最终结果
			// final = (((base + add) * (100 + pct) / 100) + finalAdd) * (100 + finalPct) / 100;
			long result = (long)(((self.GetByKey(bas) + self.GetByKey(add)) * (100 + self.GetAsFloat(pct)) / 100f + self.GetByKey(finalAdd)) *
				(100 + self.GetAsFloat(finalPct)) / 100f);
			self.Insert(final, result, isPublicEvent);
		}

		public static long ReturnGetFightNumLong(this NumericComponentS self, int numericType, bool notice = true)
		{
			if (numericType < (int)NumericType.Max)
			{
				numericType = numericType * 100;
			}

			int nowValue = (int)numericType / 100;
			int add = nowValue * 100 + 1;
			int mul = nowValue * 100 + 2;
			int finalAdd = nowValue * 100 + 3;

			long nowPropertyValue = (long)((self.GetByKey(add) * (1 + self.GetAsFloat(mul)) + self.GetByKey(finalAdd)));

			return nowPropertyValue;
		}

		public static float ReturnGetFightNumfloat(this NumericComponentS self, int numericType, bool notice = true)
		{
			if (numericType < (int)NumericType.Max)
			{
				numericType = numericType * 100;
			}

			int nowValue = (int)numericType / 100;
			int add = nowValue * 100 + 1;
			int mul = nowValue * 100 + 2;
			int finalAdd = nowValue * 100 + 3;

			long nowPropertyValue = (long)((self.GetByKey(add) * (1 + self.GetAsFloat(mul)) + self.GetByKey(finalAdd)));
			//return GetAsFloat((int)nowPropertyValue);
			return (float)nowPropertyValue / 10000f;
		}
		
		public static void ApplyValue(this NumericComponentS self, int numericType, double value, bool notice = true)
		{
			self.ApplyValue(numericType, (long)(value * 10000), notice);
		}

		public static void ApplyValue(this NumericComponentS self, int numericType, long value, bool notice = true, bool check = false)
		{
			long old = self.GetByKey(numericType);
			self[numericType] = value;

			if (check && old == value)
			{
				return;
			}

			if (notice)
			{
				//发送改变属性的相关消息
				NumbericChange args = new();
				args.Defend = self.Parent as Unit;
				args.NumericType = numericType;
				args.OldValue = old;
				args.NewValue = self[numericType];
				args.SkillId = 0;
				args.DamgeType = 0;
				EventSystem.Instance.Publish(self.Scene(), args);
			}
		}

		/// <summary>
		/// 传入改变值,设置当前的属性值, 不走公式，一定会广播给客户端
		/// </summary>
		/// <param name="attack"></param>
		/// <param name="numericType"></param>
		/// <param name="changedValue">变化值</param>
		/// <param name="skillID"></param>
		/// <param name="notice"></param>
		/// <param name="DamgeType"></param>
		/// <param name="compare">是否比较变化值</param>
		public static void ApplyValue(this NumericComponentS self, Unit attack, int numericType, long value, int skillID, bool notice = true,
		int DamgeType = 0)
		{
			//是否超过指定上限值
			long old = self.GetByKey(numericType);
			self[numericType] = value;

			//血量特殊处理
			if (old == value && numericType != NumericType.Now_Hp && numericType != NumericType.RingTaskId &&
			    numericType != NumericType.UnionTaskId && numericType != NumericType.DailyTaskID)
			{
				return;
			}

			if (notice)
			{
				//发送改变属性的相关消息
				NumbericChange args = new();
				args.Defend = self.Parent as Unit;
				args.Attack = attack;
				args.NumericType = numericType;
				args.OldValue = old;
				args.NewValue = self[numericType];
				args.SkillId = skillID;
				args.DamgeType = DamgeType;
				EventSystem.Instance.Publish(self.Scene(), args);
			}
		}

		/// <summary>
		/// 传入改变值,设置当前的属性值, 不走公式，一定会广播给客户端
		/// </summary>
		/// <param name="attack"></param>
		/// <param name="numericType"></param>
		/// <param name="changedValue">变化值</param>
		/// <param name="skillID"></param>
		/// <param name="notice"></param>
		/// <param name="DamgeType"></param>
		/// <param name="compare">是否比较变化值</param>
		public static void ApplyChange(this NumericComponentS self, Unit attack, int numericType, long changedValue, int skillID,
		bool notice = true, int DamgeType = 0)
		{
			//改变值为0不做任何处理
			if (changedValue == 0)
			{
				return;
			}

			//是否超过指定上限值
			if (numericType == (int)NumericType.Now_Hp)
			{
				long nowCostHp = self.GetAsLong((int)NumericType.Now_MaxHp) - self.GetAsLong((int)NumericType.Now_Hp);
				if (changedValue >= nowCostHp)
				{
					changedValue = nowCostHp;
				}
			}

			if (numericType == (int)NumericType.SkillUseMP)
			{
				long nowCostHp = self.GetAsLong((int)NumericType.Max_SkillUseMP) - self.GetAsLong((int)NumericType.SkillUseMP);
				if (changedValue >= nowCostHp)
				{
					changedValue = nowCostHp;
				}
			}

			long old = self.GetByKey((int)numericType);
			long newvalue = self.GetAsLong(numericType) + changedValue;
			self[(int)numericType] = newvalue;

			if (notice)
			{
				//发送改变属性的相关消息
				NumbericChange args = new();
				args.Defend = self.Parent as Unit;
				args.Attack = attack;
				args.NumericType = numericType;
				args.OldValue = old;
				args.NewValue = self[numericType];
				args.SkillId = skillID;
				args.DamgeType = DamgeType;
				EventSystem.Instance.Publish(self.Scene(), args);
			}
		}
	}

	[ComponentOf(typeof (Unit))]
	public class NumericComponentS: Entity, IAwake, ITransfer, IUnitCache
	{
		[BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
		public Dictionary<int, long> NumericDic = new Dictionary<int, long>();

		public long this[int numericType]
		{
			get
			{
				return this.GetByKey(numericType);
			}
			set
			{
				this.Insert(numericType, value);
			}
		}
	}
}