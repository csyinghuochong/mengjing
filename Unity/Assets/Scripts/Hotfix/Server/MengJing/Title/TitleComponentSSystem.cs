using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (TitleComponentS))]
    [FriendOf(typeof (TitleComponentS))]
    public static partial class TitleComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this TitleComponentS self)
        {
            self.TitleList.Clear();
        }

        [EntitySystem]
        private static void Destroy(this TitleComponentS self)
        {
        }

        public static List<PropertyValue> GetTitlePro(this TitleComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();

            for (int i = self.TitleList.Count - 1; i >= 0; i--)
            {
                TitleConfig titleConfig = TitleConfigCategory.Instance.Get(self.TitleList[i].KeyId);
                string[] attributeInfoList = titleConfig.AddProperty.Split('@');
                for (int a = 0; a < attributeInfoList.Length; a++)
                {
                    string[] attributeInfo = attributeInfoList[a].Split(';');
                    int numericType = int.Parse(attributeInfo[0]);

                    if (NumericHelp.GetNumericValueType(numericType) == 2)
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
                            Log.Debug(ex.ToString() + $"报错称号: {self.TitleList[i].KeyId}");
                        }

                        proList.Add(new PropertyValue() { HideID = numericType, HideValue = lvalue });
                    }
                }
            }

            return proList;
        }

        /// <summary>
        /// 移除过期称号
        /// </summary>
        /// <param name="self"></param>
        public static void OnCheckTitle(this TitleComponentS self, bool notice)
        {
            bool update = false;
            long serverTime = TimeHelper.ServerNow();
            for (int i = self.TitleList.Count - 1; i >= 0; i--)
            {
                if (self.TitleList[i].Value == -1) //永久称号
                {
                    continue;
                }

                if (self.TitleList[i].Value < serverTime)
                {
                    update = true;
                    self.TitleList.RemoveAt(i);
                }
            }

            if (update && notice)
            {
                Unit unit = self.GetParent<Unit>();
                self.TitleUpdateResult.TitleList = self.TitleList;
                MapMessageHelper.SendToClient(unit, self.TitleUpdateResult);
            }

            if (update)
            {
                Unit unit = self.GetParent<Unit>();
                int title = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TitleID);
                if (title > 0 && !self.IsHaveTitle(title))
                {
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TitleID, 0, notice);
                }
            }
        }

        public static bool IsHaveTitle(this TitleComponentS self, int titleId)
        {
            for (int i = 0; i < self.TitleList.Count; i++)
            {
                if (self.TitleList[i].KeyId == titleId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 返回-1为永久称号
        /// </summary>
        /// <param name="self"></param>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public static long GetTitlLeftTime(this TitleComponentS self, int titleId)
        {
            for (int i = 0; i < self.TitleList.Count; i++)
            {
                if (self.TitleList[i].KeyId != titleId)
                {
                    continue;
                }

                if (self.TitleList[i].Value == -1)
                {
                    return -1;
                }

                long leftTime = self.TitleList[i].Value - TimeHelper.ServerNow();
                leftTime = Math.Max(leftTime, 0);
                return leftTime;
            }

            return 0;
        }

        public static void OnGmGaoJi(this TitleComponentS self)
        {
            Dictionary<int, TitleConfig> allTitle = TitleConfigCategory.Instance.GetAll();
            foreach (var key in allTitle.Keys)
            {
                self.OnActiveTile(key);
            }
        }

        public static void OnActiveTile(this TitleComponentS self, int titleId)
        {
            for (int i = self.TitleList.Count - 1; i >= 0; i--)
            {
                if (self.TitleList[i].KeyId == titleId)
                {
                    self.TitleList.RemoveAt(i);
                }
            }

            TitleConfig titleConfig = TitleConfigCategory.Instance.Get(titleId);
            long endTime = titleConfig.ValidityTime == -1? -1 : TimeHelper.ServerNow() + titleConfig.ValidityTime * 1000;
            self.TitleList.Add(new KeyValuePairInt() { KeyId = titleId, Value = endTime });
        }
    }
}