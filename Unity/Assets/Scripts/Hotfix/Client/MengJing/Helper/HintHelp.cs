namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class CommonHintErrorEvent : AEvent<Scene, CommonHintError>
    {
        protected override async ETTask Run(Scene root, CommonHintError args)
        {
            if (args.ErrorValue == ErrorCode.ERR_ModifyData)
            {
                // root.GetComponent<RelinkComponent>()?.OnModifyData();
            }

            HintHelp.ShowErrorHint(root, args.ErrorValue);

            await ETTask.CompletedTask;
        }
    }

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
            EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = string.IsNullOrEmpty(hintStr) ? code.ToString() : hintStr });
        }

        public static void ShowHint(Scene root, string str)
        {
            EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = str });
        }
    }
}