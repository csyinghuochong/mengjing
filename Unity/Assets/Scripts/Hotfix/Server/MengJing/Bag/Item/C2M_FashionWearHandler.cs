namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentS))]
    [FriendOf(typeof(UserInfoComponentS))]
    public class C2M_FashionWearHandler: MessageLocationHandler<Unit, C2M_FashionWearRequest, M2C_FashionWearResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FashionWearRequest request, M2C_FashionWearResponse response)
        {
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (!bagComponent.FashionActiveIds.Contains(request.FashionId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            int occ = unit.GetComponent<UserInfoComponentS>().UserInfo.Occ;
            FashionConfig fashionConfig = FashionConfigCategory.Instance.Get(request.FashionId);

            bool canwear = false;
            for (int i = 0; i < fashionConfig.Occ.Length; i++)
            {
                if (fashionConfig.Occ[i] == occ)
                {
                    canwear = true;
                    break;
                }
            }
            if (!canwear)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.OperatateType == 1)
            {
                if (bagComponent.FashionEquipList.Contains(request.FashionId))
                {
                    response.Error = ErrorCode.ERR_AlreadyLearn;
                    return;
                }
                bagComponent.FashionEquipList.Add(request.FashionId);
            }
            else
            {
                if (!bagComponent.FashionEquipList.Contains(request.FashionId))
                {
                    response.Error = ErrorCode.ERR_NetWorkError;
                    return;
                }
                bagComponent.FashionEquipList.Remove(request.FashionId);
            }

            M2C_FashionUpdate m2C_FashionUpdate = M2C_FashionUpdate.Create();
            m2C_FashionUpdate.UnitID = unit.Id;
            m2C_FashionUpdate.FashionEquipList = bagComponent.FashionEquipList;
            MapMessageHelper.Broadcast(unit, m2C_FashionUpdate);

            await ETTask.CompletedTask;
        }
    }
    
}