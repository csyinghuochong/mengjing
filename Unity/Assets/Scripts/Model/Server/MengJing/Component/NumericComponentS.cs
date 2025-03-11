using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [FriendOf(typeof(NumericComponentS))]
    public static class NumericComponentSSystem
    {
        //重置所有属性
        public static void ResetProperty(this NumericComponentS self)
        {
            long max = NumericType.Max;

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
            long max = NumericType.Max;
            List<int> keys = self.NumericDic.Keys.ToList();
            foreach (int key in keys)
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

        private static void Update(this NumericComponentS self, int numericType, long value, bool notice = true, bool check = false, long attackid = 0, int skillId = 0, int damgeType = 0)
        {
            long old = 0;
            int nowValue = 0;
            long nowPropertyValue = 0;

            if (numericType > NumericType.Max)
            {
                ///注意下 客户端应该是不需要这个逻辑的。
                self.NumericDic[numericType] = value;
                nowValue = numericType / 100;
                int add = nowValue * 100 + 1;
                int mul = nowValue * 100 + 2;
                int finalAdd = nowValue * 100 + 3;
                int buffAdd = nowValue * 100 + 11;
                int buffMul = nowValue * 100 + 12;

                old = self.GetByKey(nowValue);
                nowPropertyValue =
                        (long)((self.GetByKey(add) * (1 + self.GetAsFloat(mul)) + self.GetByKey(finalAdd)) * (1 + self.GetAsFloat(buffMul)) +
                            self.GetByKey(buffAdd));

                self.NumericDic[nowValue] = nowPropertyValue;
            }
            else
            {
                old = self.GetAsLong(numericType);
                nowValue = numericType;
                self.NumericDic[numericType] = value;
                nowPropertyValue = value;
            }

            if (check && old == nowPropertyValue)
            {
                return;
            }

            if (notice)
            {
                //发送改变属性的相关消息
                NumbericChange args = new();
                args.Defend = self.Parent as Unit;
                args.NumericType = nowValue;
                args.OldValue = old;
                args.NewValue = nowPropertyValue;
                args.AttackId = attackid;
                args.DamgeType = damgeType;
                args.SkillId = skillId;
                EventSystem.Instance.Publish(self.Scene(), args);
            }
        }

        private static long GetByKey(this NumericComponentS self, int key)
        {
            long value = 0;
            self.NumericDic.TryGetValue(key, out value);
            return value;
        }

        public static long ReturnGetFightNumLong(this NumericComponentS self, int numericType, bool notice = true)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long nowPropertyValue = (long)(self.GetByKey(add) * (1 + self.GetAsFloat(mul)) + self.GetByKey(finalAdd));

            return nowPropertyValue;
        }

        public static float ReturnGetFightNumfloat(this NumericComponentS self, int numericType, bool notice = true)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long nowPropertyValue = (long)(self.GetByKey(add) * (1 + self.GetAsFloat(mul)) + self.GetByKey(finalAdd));

            return nowPropertyValue / 10000f;
        }

        public static void ApplyValue(this NumericComponentS self, int numericType, double value, bool notice = true)
        {
            self.ApplyValue(numericType, (long)(value * 10000), notice);
        }

        public static void ApplyValue(this NumericComponentS self, int numericType, long value, bool notice = true, bool check = true, long attackid = 0, int skillId = 0, int damgeType = 0)
        {
            long old = self.GetByKey(numericType);
           
            if (numericType != NumericType.Now_Hp && numericType != NumericType.RingTaskId &&
                numericType != NumericType.UnionTaskId && numericType != NumericType.DailyTaskID)
            {
                check = false;
            }
            
            if (check && old == value)
            {
                return;
            }
            
            self.Update(numericType, value, notice, check, attackid, skillId, damgeType);
        }
        
        /// <summary>
        /// 传入改变值,设置当前的属性值, 不走公式，一定会广播给客户端
        /// </summary>
        /// <param name="self"></param>
        /// <param name="attack"></param>
        /// <param name="numericType"></param>
        /// <param name="changedValue">变化值</param>
        /// <param name="skillID"></param>
        /// <param name="notice"></param>
        /// <param name="DamgeType"></param>
        public static void ApplyChange(this NumericComponentS self, int numericType, long changedValue, bool notice = true, bool check = false, long attackid = 0, int skillId = 0, int damgeType = 0)
        {
            //改变值为0不做任何处理
            if (changedValue == 0)
            {
                return;
            }

             //是否超过指定上限值
            switch (numericType)
            {
                case NumericType.Now_Hp:
                    long nowCostHp = self.GetAsLong(NumericType.Now_MaxHp) - self.GetAsLong(NumericType.Now_Hp);
                    if (changedValue >= nowCostHp)
                    {
                        changedValue = nowCostHp;
                    }
                    break;
                
                case NumericType.SkillUseMP:
                    nowCostHp = self.GetAsLong(NumericType.Max_SkillUseMP) - self.GetAsLong(NumericType.SkillUseMP);
                    if (changedValue >= nowCostHp)
                    {
                        changedValue = nowCostHp;
                    }
                    break;
                
                case NumericType.PetMeleeMoLi:
                    nowCostHp = ConfigData.PetMeleeMoLiMax - self.GetAsLong(NumericType.PetMeleeMoLi);
                    if (changedValue >= nowCostHp)
                    {
                        changedValue = nowCostHp;
                    }
                    break;      
            }

            long newvalue = self.GetAsLong(numericType) + changedValue;
            self.ApplyValue( numericType, newvalue, notice,  true, attackid, skillId, damgeType);
        }
    }

    [ComponentOf(typeof(Unit))]
    public class NumericComponentS : Entity, IAwake, ITransfer, IUnitCache
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> NumericDic = new();
    }
}