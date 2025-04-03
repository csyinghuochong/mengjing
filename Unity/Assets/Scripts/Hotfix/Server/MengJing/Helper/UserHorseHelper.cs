using System;
using System.Collections.Generic;

namespace ET.Server
{
    public static class UserHorseHelper
    {
        public static void OnUpdateHorseRide(this Unit self, int oldHorse)
        {
            if (oldHorse > 0)
            {
                ZuoQiShowConfig zuoqiCof = ZuoQiShowConfigCategory.Instance.Get(oldHorse);
                self.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, zuoqiCof.MoveBuffID);
            }

            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            if (SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
            {
                int sceneid = mapComponent.SceneId;
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
                if (sceneConfig.IfMount == 1)
                {
                    return;
                }
            }

            int horseRide = self.GetComponent<NumericComponentS>().GetAsInt(NumericType.HorseRide);
            if (horseRide > 1)
            {
                ZuoQiShowConfig zuoqiCof = ZuoQiShowConfigCategory.Instance.Get(horseRide);
                BuffData buffData_2 = new BuffData();
                buffData_2.SkillId = 67000278;
                buffData_2.BuffId = zuoqiCof.MoveBuffID;
                self.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_2, self, null);
            }
        }

        public static List<PropertyValue> GetZuoQiPro(this UserInfoComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();

            for (int i = self.UserInfo.HorseIds.Count - 1; i >= 0; i--)
            {
                ZuoQiShowConfig titleConfig = ZuoQiShowConfigCategory.Instance.Get(self.UserInfo.HorseIds[i]);
                string[] attributeInfoList = titleConfig.AddProperty.Split('@');
                for (int a = 0; a < attributeInfoList.Length; a++)
                {
                    if (CommonHelp.IfNull(attributeInfoList[a]))
                    {
                        continue;
                    }

                    string[] attributeInfo = attributeInfoList[a].Split(',');
                    if (attributeInfo.Length < 2)
                    {
                        continue;
                    }

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
                            Log.Debug(ex.ToString() + $"坐骑称号: {self.UserInfo.HorseIds[i]}");
                        }

                        proList.Add(new PropertyValue() { HideID = numericType, HideValue = lvalue });
                    }
                }
            }

            return proList;
        }
    }
}