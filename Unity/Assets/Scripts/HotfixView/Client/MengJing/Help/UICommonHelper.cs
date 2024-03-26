using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public static class UICommonHelper
    {
        public static string ShowFloatValue(float value)
        {
            string svalue = value.ToString("0.##");
            return svalue;
        }

        public static string GetPetQualityName(int quality)
        {

            switch (quality)
            {

                case 1:
                    return "大众";
                //break;
                case 2:
                    return "优秀";
                //break;
                case 3:
                    return "百里挑一";
                //break;
                case 4:
                    return "千载难逢";
                //break;
                case 5:
                    return "万众瞩目";
                //break;
            }

            return "";

        }

        //数字转换万
        public static string NumToWString(long num) {

            //超过10万才显示
            if (num >= 100000)
            {
                if (num % 10000 == 0)
                {
                    return (num / 10000).ToString() + "万";
                }
                else {
                    return ((float)num / 10000f).ToString("F2") + "万";
                }
            }
            else {
                return num.ToString();
            }

        }
        
        // 根据品质返回一个Color
        public static Color QualityReturnColor(int ItenQuality)
        {
            Color color = new Color(1, 1, 1);
            switch (ItenQuality)
            {
                case 1:
                    color = new Color(1, 1, 1);
                    break;

                case 2:
                    color = new Color(0, 1, 0);
                    break;
                case 3:
                    color = new Color(0.047f, 0.76f, 0.847f);
                    break;

                case 4:
                    color = new Color(0.937f, 0.5f, 1.0f);
                    break;
                case 5:
                    color = new Color(1, 0.49f, 0);
                    break;
                case 6:
                    color = new Color(0.80f, 0.49f, 0.19f);
                    break;
            }
            return color;
        }
        public static void SetParent(GameObject son, GameObject parent)
        {
            if (son == null || parent == null)
                return;
            son.transform.SetParent(parent.transform);
            son.transform.localPosition = Vector3.zero;
            son.transform.localScale = Vector3.one;
        }

        public static void DestoryChild(GameObject go)
        {
            if (go == null)
                return;

            for (int i = go.transform.childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.Destroy(go.transform.GetChild(i).gameObject);
            }
        }

        public static void SetToggleShow(GameObject gameObject, bool isShow)
        {
            gameObject.transform.Find("Background/XuanZhong").gameObject.SetActive(isShow);
            gameObject.transform.Find("Background/WeiXuanZhong").gameObject.SetActive(!isShow);
        }

        public static void HideChildren(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        public static void SetImageGray(Scene root, GameObject obj, bool val)
        {
            if (val)
            {
                Material mat = root.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
                obj.GetComponent<Image>().material = mat;
            }
            else
            {
                obj.GetComponent<Image>().material = null;
            }
        }
    }
}