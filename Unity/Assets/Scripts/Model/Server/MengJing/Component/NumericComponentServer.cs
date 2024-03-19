using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [FriendOf(typeof (NumericComponentServer))]
    public static class NumericComponentServerSystem
    {

        public static void Reset(this NumericComponentServer self)
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

        public static float GetAsFloat(this NumericComponentServer self, int numericType)
        {
            return (float)self.GetByKey(numericType) / 10000;
        }

        public static int GetAsInt(this NumericComponentServer self, int numericType)
        {
            return (int)self.GetByKey(numericType);
        }

        public static long GetAsLong(this NumericComponentServer self, int numericType)
        {
            return self.GetByKey(numericType);
        }

        public static void Set(this NumericComponentServer self, int nt, float value)
        {
            self[nt] = (long)(value * 10000);
        }

        public static void Set(this NumericComponentServer self, int nt, int value)
        {
            self[nt] = value;
        }

        public static void Set(this NumericComponentServer self, int nt, long value)
        {
            self[nt] = value;
        }

        public static void SetNoEvent(this NumericComponentServer self, int numericType, long value)
        {
            self.Insert(numericType, value, false);
        }
        
        public static void SetEvent(this NumericComponentServer self, int numericType, long value, bool notice)
        {
            self.Insert(numericType, value, notice);
        }

        public static void SetEvent(this NumericComponentServer self, int numericType, double value, bool notice)
        {
            self.Insert(numericType, (long)(value * 10000), notice);
        }
        
        public static void Insert(this NumericComponentServer self, int numericType, long value, bool isPublicEvent = true)
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

        public static long GetByKey(this NumericComponentServer self, int key)
        {
            long value = 0;
            self.NumericDic.TryGetValue(key, out value);
            return value;
        }

        public static void Update(this NumericComponentServer self, int numericType, bool isPublicEvent)
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
    }
    
    [ComponentOf(typeof (Unit))]
    public class NumericComponentServer: Entity, IAwake, ITransfer, IUnitCache
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