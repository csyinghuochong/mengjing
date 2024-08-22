using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Client
{
    [FriendOf(typeof(NumericComponentC))]
    public static class NumericComponentClientSystem
    {
        public static float GetAsFloat(this NumericComponentC self, int numericType)
        {
            return (float)self.GetByKey(numericType) / 10000;
        }

        public static int GetAsInt(this NumericComponentC self, int numericType)
        {
            return (int)self.GetByKey(numericType);
        }

        public static long GetAsLong(this NumericComponentC self, int numericType)
        {
            return self.GetByKey(numericType);
        }

        public static long GetByKey(this NumericComponentC self, int key)
        {
            long value = 0;
            self.NumericDic.TryGetValue(key, out value);
            return value;
        }

        private static void Update(this NumericComponentC self, int numericType, long value, bool notice = true)
        {
            if (numericType < NumericType.Max)
            {
                return;
            }

            int nowValue = numericType / 100;

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

            if (notice && old != nowPropertyValue)
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

        public static void ApplyValue(this NumericComponentC self, int numericType, long value, bool notice = true, bool check = false)
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

            self.Update(numericType, value, notice);
        }

        /// <summary>
        /// 传入改变值,设置当前的属性值, 不走公式
        /// </summary>
        /// <param name="self"></param>
        /// <param name="attackId"></param>
        /// <param name="numericType"></param>
        /// <param name="value"></param>
        /// <param name="skillID"></param>
        /// <param name="notice"></param>
        /// <param name="DamgeType"></param>
        public static void ApplyValue(this NumericComponentC self, long attackId, int numericType, long value, int skillID, bool notice = true, int DamgeType = 0)
        public static void ApplyValue(this NumericComponentC self, Unit attack, int numericType, long value, int skillID, bool notice = true,
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

            if ((self.Parent as Unit).Type == UnitType.Player && numericType == NumericType.Now_Dead)
            {
                Console.WriteLine($"NumericComponentC.ApplyValue  NumericType.Now_Dead:{self.Parent.Id}");
            }

            if (notice)
            {
                //发送改变属性的相关消息
                NumbericChange args = new NumbericChange();
                args.Defend = self.Parent as Unit;
                args.AttackId = attackId;
                args.NumericType = numericType;
                args.OldValue = old;
                args.NewValue = self.NumericDic[numericType];
                args.SkillId = skillID;
                args.DamgeType = DamgeType;
                EventSystem.Instance.Publish(self.Scene(), args);
            }
        }
    }

    [ComponentOf(typeof(Unit))]
    public class NumericComponentC : Entity, IAwake, ITransfer
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> NumericDic = new();
    }
}