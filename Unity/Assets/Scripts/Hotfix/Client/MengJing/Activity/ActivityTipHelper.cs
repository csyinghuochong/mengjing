namespace ET.Client
{
    public static class ActivityTipHelper
    {
        //竞技场
        public static async ETTask<int> RequestEnterArena(Scene root)
        {
            int sceneId = 6000001;
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            int sceneType = sceneConfig.MapType;
            if (sceneType != MapTypeEnum.Arena)
            {
                return ErrorCode.ERR_Error;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            if (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.ArenaNumber) > 0)
            {
                HintHelp.ShowHint(root, "次数不足！");
                return ErrorCode.ERR_TimesIsNot;
            }

            if (!FunctionHelp.IsInTime(1031))
            {
                HintHelp.ShowHint(root, "不在活动时间内！");
                return ErrorCode.ERR_AlreadyFinish;
            }

            int errorCode = await EnterMapHelper.RequestTransfer(root, sceneType, sceneId);
            return errorCode;
        }
    }
}