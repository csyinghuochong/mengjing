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

        public static void Set(this NumericComponentS self, int nt, float value)
        {
            self.Update(nt, (long)(value * 10000));
        }

        public static void Set(this NumericComponentS self, int nt, int value)
        {
            self.Update(nt, value);
        }

        public static void Set(this NumericComponentS self, int nt, long value)
        {
            self.Update(nt, value);
        }

        public static void SetNoEvent(this NumericComponentS self, int numericType, long value)
        {
            self.Update(numericType, value, false);
        }

        public static void SetNoEvent(this NumericComponentS self, int numericType, double value)
        {
            self.Update(numericType, (long)(value * 10000), false);
        }

        private static void Update(this NumericComponentS self, int numericType, long value, bool isPublicEvent = true)
        {
            self.NumericDic[numericType] = value;
            
            if (numericType < (int)NumericType.Max)
            {
                return;
            }

            int nowValue = (int)numericType / 100;

            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;
            int buffAdd = nowValue * 100 + 11;
            int buffMul = nowValue * 100 + 12;
            long old = self.GetByKey(nowValue);
            long nowPropertyValue =
                    (long)((self.GetByKey(add) * (1 + self.GetAsFloat(mul)) + self.GetByKey(finalAdd)) * (1 + self.GetAsFloat(buffMul)) +
                        self.GetByKey(buffAdd));
            self.NumericDic[nowValue] = nowPropertyValue;

            if (isPublicEvent && old != nowPropertyValue)
            {
                //发送改变属性的相关消息
                NumbericChange args = new();
                args.Defend = self.Parent as Unit;
                args.NumericType = nowValue;
                args.OldValue = old;
                args.NewValue = nowPropertyValue;
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

        public static void ApplyValue(this NumericComponentS self, int numericType, long value, bool notice = true, bool check = false)
        {
            long old = self.GetByKey(numericType);
            self.NumericDic[numericType] = value;

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
                args.NewValue = self.GetByKey(numericType);
                args.SkillId = 0;
                args.DamgeType = 0;
                EventSystem.Instance.Publish(self.Scene(), args);
            }
        }

        /// <summary>
        /// 传入改变值,设置当前的属性值, 不走公式，一定会广播给客户端
        /// </summary>
        /// <param name="self"></param>
        /// <param name="attack"></param>
        /// <param name="numericType"></param>
        /// <param name="value"></param>
        /// <param name="skillID"></param>
        /// <param name="notice"></param>
        /// <param name="DamgeType"></param>
        public static void ApplyValue(this NumericComponentS self, Unit attack, int numericType, long value, int skillID, bool notice = true,
        int DamgeType = 0)
        {
            //是否超过指定上限值
            long old = self.GetByKey(numericType);
            self.NumericDic[numericType] = value;

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
                args.NewValue = self.GetByKey(numericType);
                args.SkillId = skillID;
                args.DamgeType = DamgeType;
                EventSystem.Instance.Publish(self.Scene(), args);
            }
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
        public static void ApplyChange(this NumericComponentS self, Unit attack, int numericType, long changedValue, int skillID, bool notice = true,
        int DamgeType = 0)
        {
            //改变值为0不做任何处理
            if (changedValue == 0)
            {
                return;
            }

            //是否超过指定上限值
            if (numericType == NumericType.Now_Hp)
            {
                long nowCostHp = self.GetAsLong(NumericType.Now_MaxHp) - self.GetAsLong(NumericType.Now_Hp);
                if (changedValue >= nowCostHp)
                {
                    changedValue = nowCostHp;
                }
            }

            if (numericType == NumericType.SkillUseMP)
            {
                long nowCostHp = self.GetAsLong(NumericType.Max_SkillUseMP) - self.GetAsLong(NumericType.SkillUseMP);
                if (changedValue >= nowCostHp)
                {
                    changedValue = nowCostHp;
                }
            }

            long old = self.GetByKey(numericType);
            long newvalue = self.GetAsLong(numericType) + changedValue;
            self.NumericDic[numericType] = newvalue;

            if (notice)
            {
                //发送改变属性的相关消息
                NumbericChange args = new();
                args.Defend = self.Parent as Unit;
                args.Attack = attack;
                args.NumericType = numericType;
                args.OldValue = old;
                args.NewValue = self.GetByKey(numericType);
                args.SkillId = skillID;
                args.DamgeType = DamgeType;
                EventSystem.Instance.Publish(self.Scene(), args);
            }
        }
    }

    [ComponentOf(typeof(Unit))]
    public class NumericComponentS : Entity, IAwake, ITransfer, IUnitCache
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> NumericDic = new();
    }
}