namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentS))]
    public class C2M_FashionActiveHandler: MessageLocationHandler<Unit, C2M_FashionActiveRequest, M2C_FashionActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FashionActiveRequest request, M2C_FashionActiveResponse response)
        {
            if (request.FashionId == 0 || !FashionConfigCategory.Instance.Contain(request.FashionId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent.FashionActiveIds.Contains(request.FashionId))
            {
                response.Error = ErrorCode.ERR_AlreadyLearn;
                return;
            }

            FashionConfig fashionConfig = FashionConfigCategory.Instance.Get(request.FashionId);
            if (!bagComponent.CheckCostItem(fashionConfig.ActiveCost))
            {
                response.Error = ErrorCode.ERR_HouBiNotEnough;
                return;
            }

            bagComponent.OnCostItemData(fashionConfig.ActiveCost);
            bagComponent.FashionActiveIds.Add(request.FashionId);
            await ETTask.CompletedTask;
        }
    }
    
}

