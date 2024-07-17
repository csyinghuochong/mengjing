namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TitleUseHandler : MessageLocationHandler<Unit, C2M_TitleUseRequest, M2C_TitleUseResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TitleUseRequest request, M2C_TitleUseResponse response)
        {
            if (!unit.GetComponent<TitleComponentS>().IsHaveTitle(request.TitleId))
            {
                response.Error = ErrorCode.ERR_TitleNoActived;
                return;
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TitleID, request.TitleId);
            Function_Fight.UnitUpdateProperty_Base(unit,true, true);
            
            await ETTask.CompletedTask;
        }
    }
}