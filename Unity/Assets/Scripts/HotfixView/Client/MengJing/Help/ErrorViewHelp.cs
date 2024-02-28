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

        public static void ShowErrorHint(Scene root, int code)
        {
            if (code == 0)
            {
                return;
            }

            string hintStr = code.ToString();
            ErrorViewData.ErrorHints.TryGetValue(code, out hintStr);
            root.GetComponent<FlyTipComponent>().SpawnFlyTipDi(string.IsNullOrEmpty(hintStr)? code.ToString() : hintStr);
        }
    }
}