namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionWishGetHandler : MessageLocationHandler<Unit, C2M_UnionWishGetRequest, M2C_UnionWishGetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionWishGetRequest request, M2C_UnionWishGetResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();    
            if (numericComponent.GetAsInt(NumericType.UnionWishGet) > 0)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;    
                return;
            }

            if (!ConfigData.UnionWishRewardForType.ContainsKey(request.Type))
            {
                response.Error = ErrorCode.ERR_ModifyData;    
                return;
            }

            BagComponentS bagComponentS = unit.GetComponent<BagComponentS>();
            string rewardlist = ConfigData.UnionWishRewardForType[request.Type];
            string[] rewards = rewardlist.Split('@');
            if (bagComponentS.GetBagLeftCell(ItemLocType.ItemLocBag) < rewards.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;    
                return;
            }

            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();    
            
            switch (request.Type)
            {
                case 1:
                    if (!bagComponentS.OnAddItemData(rewardlist,$"{ItemGetWay.UnionWish}_{TimeHelper.ServerNow()}" ))
                    {
                        response.Error = ErrorCode.ERR_BagIsFull;   
                        return;
                    }
                    break;
                case 2:
                    if (userInfoComponentS.UserInfo.Gold < ConfigData.UnionWishGetGoldCost)
                    {
                        response.Error = ErrorCode.ERR_GoldNotEnoughError;
                        return;
                    }
                    if (!bagComponentS.OnAddItemData(rewardlist,$"{ItemGetWay.UnionWish}_{TimeHelper.ServerNow()}" ))
                    {
                        response.Error = ErrorCode.ERR_BagIsFull;   
                        return;
                    }
                    userInfoComponentS.UpdateRoleMoneySub( UserDataType.Gold, (ConfigData.UnionWishGetGoldCost * -1).ToString(), true, ItemGetWay.UnionWish  );
                    break;
                case 3:
                    if (!bagComponentS.OnAddItemData(rewardlist,$"{ItemGetWay.UnionWish}_{TimeHelper.ServerNow()}" ))
                    {
                        response.Error = ErrorCode.ERR_BagIsFull;   
                        return;
                    }
                    if (!bagComponentS.OnAddItemData(rewardlist,$"{TimeHelper.ServerNow()}_{ItemGetWay.UnionWish}" ))
                    {
                        response.Error = ErrorCode.ERR_BagIsFull;   
                        return;
                    }
                    
                    userInfoComponentS.UpdateRoleMoneySub( UserDataType.Diamond, (ConfigData.UnionWishGetDiamondCost * -1).ToString(), true, ItemGetWay.UnionWish  );
                    break;  
                default:
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
            }

            numericComponent.ApplyValue(NumericType.UnionWishGet, 1, true);
            
            await ETTask.CompletedTask;
        }
    }
}
