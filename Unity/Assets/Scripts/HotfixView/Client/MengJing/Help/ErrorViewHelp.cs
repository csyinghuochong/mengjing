namespace ET.Client
{
    public static class ErrorViewHelp
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

        public static void ShowErrorHint(int code)
        {
            if (code == 0)
            {
                return;
            }

            string hintStr = code.ToString();
            ErrorViewData.ErrorHints.TryGetValue(code, out hintStr);
            FlyTipComponent.Instance.SpawnFlyTipDi(string.IsNullOrEmpty(hintStr)? code.ToString() : hintStr);
        }
    }
}