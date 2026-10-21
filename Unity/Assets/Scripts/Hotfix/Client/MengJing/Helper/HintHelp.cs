namespace ET.Client
{
    public static class HintHelp
    {
        public static string GetErrorHint(int code)
        {
            if (code == 0)
            {
                return string.Empty;
            }

            //命中时零分配，只有未配置的错误码才回退成数字字符串
            if (!ErrorViewData.ErrorHints.TryGetValue(code, out string hintStr) || string.IsNullOrEmpty(hintStr))
            {
                hintStr = code.ToString();
            }

            return hintStr;
        }

        public static void ShowErrorHint(Scene root, int code)
        {
            if (code == 0)
            {
                return;
            }

            //移动相关错误不弹提示
            if (code == ErrorCode.ERR_CanNotMove_NetWait
                || code == ErrorCode.ERR_CanNotMove_Rigidity
                || code == ErrorCode.ERR_CanNotMove_Speed
                || code == ErrorCode.ERR_CanNotUseSkill_NetWait)
            {
                return;
            }

            ShowHint(root, GetErrorHint(code), 1);
        }

        public static void ShowHint(Scene root, string str, int type = 0)
        {
            EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = str, Type = type });
        }
    }
}
