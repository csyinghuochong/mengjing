using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

namespace ET
{
    public static class RandomEx
    {
        public static ulong RandUInt64(this Random random)
        {
            byte[] byte8 = new byte[8];
            random.NextBytes(byte8);
            return BitConverter.ToUInt64(byte8, 0);
        }

        public static int RandInt32(this Random random)
        {
            return random.Next();
        }

        public static uint RandUInt32(this Random random)
        {
            return (uint)random.Next();
        }

        public static long RandInt64(this Random random)
        {
            byte[] byte8 = new byte[8];
            random.NextBytes(byte8);
            return BitConverter.ToInt64(byte8, 0);
        }
    }

    public static class RandomHelper
    {
        [StaticField]
        public static Random random = new Random(Guid.NewGuid().GetHashCode());

        public static ulong RandUInt64()
        {
            byte[] byte8 = new byte[8];
            random.NextBytes(byte8);
            return BitConverter.ToUInt64(byte8, 0);
        }

        public static int RandInt32()
        {
            return random.Next();
        }

        public static uint RandUInt32()
        {
            return (uint)random.Next();
        }

        public static long RandInt64()
        {
            byte[] byte8 = new byte[8];
            random.NextBytes(byte8);
            return BitConverter.ToInt64(byte8, 0);
        }

        /// <summary>
        /// ��ȡlower��Upper֮��������,�������ޣ�����������
        /// </summary>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static int RandomNumber(int lower, int upper)
        {
            int value = random.Next(lower, upper);
            return value;
        }

        /// <summary>
        /// ��ȡlower��Upper֮��������,�������޺�����
        /// </summary>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        //public static int RandomNumber2(int lower, int upper)
        //{
        //    int value = random.Next(lower, upper+1);
        //    return value;
        //}

        public static long NextLong(long minValue, long maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue is great than maxValue", "minValue");
            }

            long num = maxValue - minValue;
            return minValue + (long)(random.NextDouble() * num);
        }

        public static int NextInt(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue is great than maxValue", "minValue");
            }

            int num = maxValue - minValue;
            return minValue + (int)(random.NextDouble() * num);
        }

        public static bool RandomBool()
        {
            return random.Next(2) == 0;
        }

        public static T RandomArray<T>(this T[] array)
        {
            return array[RandomNumber(0, array.Length)];
        }

        public static int RandomArray_Len2(this int[] array)
        {
            return RandomHelper.RandomNumber(array[0], array[1]);
        }

        public static T RandomArray<T>(this List<T> array)
        {
            return array[RandomNumber(0, array.Count)];
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">Ҫ���ҵ�����</param>
        public static void BreakRank<T>(this List<T> arr)
        {
            if (arr == null || arr.Count < 2)
            {
                return;
            }

            for (int i = 0; i < arr.Count; i++)
            {
                int index = random.Next(0, arr.Count);
                T temp = arr[index];
                arr[index] = arr[i];
                arr[i] = temp;
            }
        }

        public static int[] GetRandoms(int sum, int min, int max)
        {
            int[] arr = new int[sum];
            int j = 0;
            //��ʾ����ֵ�Եļ��ϡ�
            Hashtable hashtable = new Hashtable();
            Random rm = random;
            while (hashtable.Count < sum)
            {
                //����һ��min��max֮��������
                int nValue = rm.Next(min, max);
                // �Ƿ�����ض�ֵ
                if (!hashtable.ContainsValue(nValue))
                {
                    //�Ѽ���ֵ��ӵ�hashtable
                    hashtable.Add(nValue, nValue);
                    arr[j] = nValue;
                    j++;
                }
            }

            return arr;
        }

        /// <summary>
        /// �����������ȡ���ɸ����ظ���Ԫ�أ�
        /// Ϊ�˽����㷨���Ӷȣ�������α����������Ҫ���Ƿǳ��ߵ��߼�������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="destList"></param>
        /// <param name="randCount"></param>
        public static bool GetRandListByCount<T>(List<T> sourceList, List<T> destList, int randCount)
        {
            if (sourceList == null || destList == null || randCount < 0)
            {
                return false;
            }

            destList.Clear();

            if (randCount >= sourceList.Count)
            {
                foreach (var val in sourceList)
                {
                    destList.Add(val);
                }

                return true;
            }

            if (randCount == 0)
            {
                return true;
            }
            int beginIndex = random.Next(0, sourceList.Count - 1);
            for (int i = beginIndex; i < beginIndex + randCount; i++)
            {
                destList.Add(sourceList[i % sourceList.Count]);
            }

            return true;
        }

        public static float RandFloat01()
        {
            int a = RandomNumber(0, 1000000);
            return (float)a / 1000000f;
        }

        //ȡ���ֵ ������λ
        public static float RandFloatKeep2()
        {
            return (float)Math.Round(random.NextDouble(), 2);
        }

        //ȡ���ֵ ������λ
        public static float RandomNumberFloatKeep2(float lower, float upper)
        {

            float value = lower + ((upper - lower) * RandFloat());
            return (float)Math.Round(value, 2);
        }


        private static int Rand(int n)
        {
            // ע�⣬����ֵ������ҿ�������maxValueҪ��1
            return random.Next(1, n + 1);
        }

        /// <summary>
        /// ͨ��Ȩ�����
        /// </summary>
        /// <param name="weights"></param>
        /// <returns></returns>
        public static int RandomByWeight(int[] weights)
        {
            int sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                sum += weights[i];
            }

            int number_rand = Rand(sum);

            int sum_temp = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                sum_temp += weights[i];
                if (number_rand <= sum_temp)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int RandomByWeight(List<int> weights)
        {
            if (weights.Count == 0)
            {
                return -1;
            }

            if (weights.Count == 1)
            {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                sum += weights[i];
            }

            int number_rand = Rand(sum);

            int sum_temp = 0;

            for (int i = 0; i < weights.Count; i++)
            {
                sum_temp += weights[i];
                if (number_rand <= sum_temp)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int RandomByWeight(List<int> weights, int weightRandomMinVal)
        {
            if (weights.Count == 0)
            {
                return -1;
            }

            if (weights.Count == 1)
            {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                sum += weights[i];
            }

            int number_rand = Rand(Math.Max(sum, weightRandomMinVal));

            int sum_temp = 0;

            for (int i = 0; i < weights.Count; i++)
            {
                sum_temp += weights[i];
                if (number_rand <= sum_temp)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int RandomByWeight(List<long> weights)
        {
            if (weights.Count == 0)
            {
                return -1;
            }

            if (weights.Count == 1)
            {
                return 0;
            }

            long sum = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                sum += weights[i];
            }

            long number_rand = NextLong(1, sum + 1);

            long sum_temp = 0;

            for (int i = 0; i < weights.Count; i++)
            {
                sum_temp += weights[i];
                if (number_rand <= sum_temp)
                {
                    return i;
                }
            }

            return -1;
        }

        public static float RandFloat()
        {
            return (float)random.NextDouble();
        }

        public static float RandomNumberFloat(float lower, float upper)
        {

            float value = lower + ((upper - lower) * RandFloat());
            return value;
        }
    }
}