using System;
using System.Collections.Generic;

namespace ET
{
    public static class NumericHelp
    {
        //1 整数  2 浮点数
        [StaticField]
        public static Dictionary<int, int> NumericValueType = new Dictionary<int, int> { { NumericType.Base_MaxHp_Base, 1 } };

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

            if (key >= 2001 && key < 3000)
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
                NumericValueType.TryGetValue(key, out value);
                if (value == 0)
                    return 1;
                return value;
            }
        }
    }
}