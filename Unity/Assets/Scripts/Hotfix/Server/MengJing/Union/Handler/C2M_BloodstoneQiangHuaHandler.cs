namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BloodstoneQiangHuaHandler: MessageLocationHandler<Unit, C2M_BloodstoneQiangHuaRequest, M2C_BloodstoneQiangHuaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BloodstoneQiangHuaRequest request, M2C_BloodstoneQiangHuaResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            PublicQiangHuaConfig publicQiangHuaConfig = PublicQiangHuaConfigCategory.Instance.Get(numericComponent.GetAsInt(NumericType.Bloodstone));

            if (publicQiangHuaConfig.NextID == 0)
            {
                response.Error = ErrorCode.ERR_UnionXiuLianMax;
                return;
            }

            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv < publicQiangHuaConfig.UpLvLimit)
            {
                response.Error = ErrorCode.ERR_LvNoHigh;
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            string costItems = publicQiangHuaConfig.CostItem;
            costItems += $"@1;{publicQiangHuaConfig.CostGold}";
            if (!bagComponent.OnCostItemData(costItems))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            int level = 0;
            double addPro = publicQiangHuaConfig.AdditionPro * numericComponent.GetAsInt(NumericType.BloodstoneFail);
            if ((float)publicQiangHuaConfig.SuccessPro + addPro >= RandomHelper.RandFloat01())
            {
                level = publicQiangHuaConfig.NextID;
                numericComponent.ApplyValue(NumericType.Bloodstone, level);
                numericComponent.ApplyValue(NumericType.BloodstoneFail, 0);
            }
            else
            {
                level = publicQiangHuaConfig.Id;
                numericComponent.ApplyChange(NumericType.BloodstoneFail, 1);
            }

            response.Level = level;
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            
            await ETTask.CompletedTask;
        }
    }
}