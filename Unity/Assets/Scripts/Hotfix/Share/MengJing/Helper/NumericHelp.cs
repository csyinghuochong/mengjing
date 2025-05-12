using System;
using System.Collections.Generic;

namespace ET
{
    public static class NumericHelp
    {


        /// <summary>
        /// 1 标识整数  2表示浮点数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetNumericValueType(int key)
        {
            if (key == 1009)
            {
                return 2;
            }

            if (key == 3001)
            {
                return 1;
            }

            //增加
            if (key >= 200001 && key < 300000)
            {
                return 2;
            }

            if (key >= 2001 && key < 3000 || key >= 200001 && key < 300000)
                    //if (key >= 1001 && key < 3000)
            {
                return 2;
            }
            else
            {
                if (key >= 100000 && key < 200000)
                {
                    string str = key.ToString().Substring(key.ToString().Length - 1, 1);
                    if (str == "2")
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }

                //最后排除
                int value = 1;
                NumericData.NumericValueType.TryGetValue(key, out value);
                if (value == 0)
                    return 1;
                return value;

                //return 0;
            }
        }

        public static void GetProList(string prolist, List<PropertyValue> proList)
        {
            string[] attributeInfoList = prolist.Split('@');
            for (int a = 0; a < attributeInfoList.Length; a++)
            {
                if (CommonHelp.IfNull(attributeInfoList[a]))
                {
                    continue;
                }

                string[] attributeInfo = attributeInfoList[a].Split(';');
                int numericType = int.Parse(attributeInfo[0]);

                if (GetNumericValueType(numericType) == 2)
                {
                    float fvalue = float.Parse(attributeInfo[1]);
                    proList.Add(new PropertyValue() { HideID = numericType, HideValue = (long)(fvalue * 10000) });
                }
                else
                {
                    long lvalue = 0;
                    try
                    {
                        lvalue = long.Parse(attributeInfo[1]);
                    }
                    catch (Exception ex)
                    {
                        Log.Debug(ex.ToString() + $"报错 {prolist}");
                    }

                    proList.Add(new PropertyValue() { HideID = numericType, HideValue = lvalue });
                }
            }
        }

        //传入值和类型返回对应值
        public static int NumericValueSaveType(int key, float value)
        {
            if (GetNumericValueType(key) == 2)
            {
                return (int)(value * 10000);
            }
            else
            {
                return (int)(value);
            }
        }

        /// <summary>
        /// 活力上限。 零点恢复活力
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillNumber"></param>
        /// <returns></returns>
        public static int GetMaxHuoLi(this Unit self, int skillNumber)
        {
            //开启双职业活力恢复增强
            if (skillNumber >= 2)
            {
                return (int)(GlobalValueConfigCategory.Instance.MaxHuoLi * 1.5f);
            }

            return GlobalValueConfigCategory.Instance.MaxHuoLi;
        }

        public static long GetAttributeValue(RolePetInfo rolePetInfo, int numericType)
        {
            for (int i = 0; i < rolePetInfo.Ks.Count; i++)
            {
                if (rolePetInfo.Ks[i] == numericType)
                {
                    return rolePetInfo.Vs[i];
                }
            }

            //从其他字段寻找
            //if (numericType == )
            return 0;
        }

        //传入子值返回母值
        public static int ReturnNumParValue(int sonValue)
        {
            return (int)(sonValue / 100);
        }
    }
}