using System;
using System.Collections.Generic;

namespace ET.Client
{
    public class UIType
    {
        public const string Root = "Root";
        public const string UIRegister = "Login/UIRegister";
        public const string UILogin = "Login/UILogin";
        public const string UIMain = "Main/UIMain";
        public const string UICommonHuoBiSet = "Main/UICommonHuoBiSet";
        public const string UIGuide = "Main/UIGuide";

        [StaticField]
        public static Dictionary<string, string> keyValuePairs = new Dictionary<string, string>() { { "Root", Root } };
    }
}