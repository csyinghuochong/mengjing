﻿namespace ET.Client
{
    public static class HintHelp
    {
        public static string GetErrorHint(int code)
        {
            if (code == 0)
            {
                return "";
            }

            string hintStr = code.ToString();
            ErrorViewData.ErrorHints.TryGetValue(code, out hintStr);
            return hintStr;
        }

        public static void ShowErrorHint(Scene root, int code)
        {
            if (code == 0)
            {
                return;
            }

            string hintStr = code.ToString();
            ErrorViewData.ErrorHints.TryGetValue(code, out hintStr);
            EventSystem.Instance.Publish(root, new ShowFlyTip() { Type = 1, Str = string.IsNullOrEmpty(hintStr) ? code.ToString() : hintStr });
        }

        public static void ShowHint(Scene root, string str, int type = 0)
        {
            EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = str, Type = type });
        }
    }
}