using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Client
{
    [FriendOf(typeof (NumericComponentClient))]
    public static class NumericComponentClientSystem
    {
        public static float GetAsFloat(this NumericComponentClient self, int numericType)
        {
            return (float)self.GetByKey(numericType) / 10000;
        }

        public static int GetAsInt(this NumericComponentClient self, int numericType)
        {
            return (int)self.GetByKey(numericType);
        }

        public static long GetAsLong(this NumericComponentClient self, int numericType)
        {
            return self.GetByKey(numericType);
        }

        public static void Set(this NumericComponentClient self, int nt, float value)
        {
            self[nt] = (long)(value * 10000);
        }

        public static void Set(this NumericComponentClient self, int nt, int value)
        {
            self[nt] = value;
        }

        public static void Set(this NumericComponentClient self, int nt, long value)
        {
            self[nt] = value;
        }

        public static void SetNoEvent(this NumericComponentClient self, int numericType, long value)
        {
            self.Insert(numericType, value, false);
        }

        public static void Insert(this NumericComponentClient self, int numericType, long value, bool isPublicEvent = true)
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

            if (isPublicEvent)
            {
                EventSystem.Instance.Publish(self.Scene(),
                    new NumbericChange() { Defend = self.GetParent<Unit>(), NewValue = value, OldValue = oldValue, NumericType = numericType });
            }
        }

        public static long GetByKey(this NumericComponentClient self, int key)
        {
            long value = 0;
            self.NumericDic.TryGetValue(key, out value);
            return value;
        }

        public static void Update(this NumericComponentClient self, int numericType, bool isPublicEvent)
        {
            int final = (int)numericType / 10;
            int bas = final * 10 + 1;
            int add = final * 10 + 2;
            int pct = final * 10 + 3;
            int finalAdd = final * 10 + 4;
            int finalPct = final * 10 + 5;

            // 一个数值可能会多种情况影响，比如速度,加个buff可能增加速度绝对值100，也有些buff增加10%速度，所以一个值可以由5个值进行控制其最终结果
            // final = (((base + add) * (100 + pct) / 100) + finalAdd) * (100 + finalPct) / 100;
            long result = (long)(((self.GetByKey(bas) + self.GetByKey(add)) * (100 + self.GetAsFloat(pct)) / 100f + self.GetByKey(finalAdd)) *
                (100 + self.GetAsFloat(finalPct)) / 100f);
            self.Insert(final, result, isPublicEvent);
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
        public static void ApplyValue(this NumericComponentClient self, Unit attack, int numericType, long value, int skillID, bool notice = true, int DamgeType = 0)
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
                NumbericChange args = new NumbericChange();
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
    public class NumericComponentClient: Entity, IAwake, ITransfer
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