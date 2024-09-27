﻿using System;
using UnityEngine;

namespace ET.Client
{
    public static class IPHoneHelper
    {
        public static void SetPosition(GameObject gameObject, Vector2 newPosition)
        {
            if (IPHoneData.CheckValue == 0)
            {
                IPHoneData.CheckValue = CheckIphone() ? 1 : -1;    
            }
            if (IsHaveLiuHai())
            {
                IPHoneData.CheckValue = 1;
            }

            if (IPHoneData.CheckValue == -1)
            {
                return;
            }
            if (gameObject.GetComponent<DoTweeningMove>() != null)
            {
                gameObject.GetComponent<DoTweeningMove>().enabled = false;
                //gameObject.GetComponent<DoTweeningMove>().SetOldPosition(newPosition);  
            }
            //Vector3 vector3 = gameObject.GetComponent<RectTransform>().anchoredPosition;
            //vector3.x += 100f;
            gameObject.GetComponent<RectTransform>().anchoredPosition = newPosition;
        }

        // 检测当前是横屏还是竖屏
        // 理论上这样，但在Android上总可以返回true
        // 即使手机已经禁止屏幕翻转了
       public static  bool IsLandscape()
        {
            //设置手机屏幕显示布局、Screen.orientation
            //获取手机当前朝向、Input.deviceOrientation
            return Input.deviceOrientation == DeviceOrientation.LandscapeLeft ||
            Input.deviceOrientation == DeviceOrientation.LandscapeRight;
        }

        // 可以用下面这个方法进行检测
        // 当禁翻转时，若为竖屏，不会返回true
        public static bool IsLandscape_2()
        {
            return Screen.width > Screen.height;
        }

        //2796:1290
        public static bool IsHaveLiuHai()
        {
            return (Screen.width == 2796 && Screen.height == 1290)      //iphone15promax
                || (Screen.width == 2556 && Screen.height == 1179);     //iphone15
        }

        public static bool IsSimulator()
        {
            return IsSimulator_1() || IsSimulator_3();  
        }

        public static bool IsRoot()
        {
            bool isRoot = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) == "/";
            return isRoot;      
        }

        /// <summary>
        /// 判断是否运行在模拟器上
        /// 通过cpu类型来判断，电脑cpu一般是intel和amd，都是x86架构
        /// </summary>
        /// <returns>是否运行在模拟器上</returns>
        public static bool IsSimulator_1()
        {
#if UNITY_ANDROID
            string processorType = SystemInfo.processorType;    //模拟器上返回以x86开头的字符串
            if (string.IsNullOrEmpty(processorType))
                return false;
            else
                return processorType.StartsWith("x86", StringComparison.OrdinalIgnoreCase);
#else
            return false;
#endif
        }

        public static bool IsSimulator_2()
        {
#if UNITY_ANDROID
            return SystemInfo.graphicsDeviceID == 0 && SystemInfo.graphicsDeviceVendorID == 0;
#else
            return false;
#endif
        }

        public static bool IsSimulator_3()
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaClass buildClass = new AndroidJavaClass("android.os.Build");
                string radioVersion = buildClass.CallStatic<string>("getRadioVersion");
                return radioVersion == string.Empty || radioVersion == null;

            }
            return false;
#else
            return false;
#endif
        }

        public static bool CheckIphone()
        {
            //https://blog.csdn.net/qq_39162826/article/details/121654464
            //https://gitee.com/ldr123/HybridCLRXlua/blob/master/Assets/Scripts/Utils/Fps.cs
#if !UNITY_EDITOR && UNITY_IOS
        string modelStr = UnityEngine.SystemInfo.deviceModel;
     
        if (IsHaveLiuHai())
        { 
            return true;
        }
        if (modelStr == "iPhone10,3" || modelStr == "iPhone10,6" || modelStr == "iPhone11,2" || modelStr == "iPhone11,6" || modelStr == "iPhone11,8"
         || modelStr == "iPhone12,1"|| modelStr == "iPhone12,3"|| modelStr == "iPhone12,5"|| modelStr == "iPhone12,8" || modelStr == "iPhone15,2" || modelStr == "iPhone15,3" || modelStr == "iPhone15,4"
         || modelStr.Contains("iPhone12")||modelStr.Contains("iPhone13")||modelStr.Contains("iPhone14")||modelStr.Contains("iPhone15")||modelStr.Contains("iPhone16"))
        {
            //需要适配
            return true;
        }
        
        return false;
#else
            return false;
            //return true;
#endif
        }
    }

}
