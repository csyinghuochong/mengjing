using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionXiuLianHandler : MessageLocationHandler<Unit, C2M_UnionXiuLianRequest, M2C_UnionXiuLianResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionXiuLianRequest request, M2C_UnionXiuLianResponse response)
        {
            int numerType = UnionHelper.GetXiuLianId(request.Position, request.Type);
            if (numerType == 0)
            {
                return;
            }

            long unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
            if (unionid == 0)
            {
                return;
            }

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            int xiulianid = numericComponent.GetAsInt(numerType);

            int position = request.Position;
            if (request.Type == 1)
            {
                position += 4;
            }

            if (xiulianid >= UnionQiangHuaConfigCategory.Instance.GetMaxId(position))
            {
                response.Error = ErrorCode.ERR_UnionXiuLianMax;
                return;
            }

            UnionQiangHuaConfig unionQiangHuaConfig = UnionQiangHuaConfigCategory.Instance.Get(xiulianid);
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.UnionZiJin < unionQiangHuaConfig.CostGold)
            {
                response.Error = ErrorCode.ERR_HouBiNotEnough;
                return;
            }
            
            if (!unit.GetComponent<BagComponentS>().OnCostItemData(unionQiangHuaConfig.CostItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }


            long selfgold = unit.GetComponent<UserInfoComponentS>().UserInfo.Gold;
            U2M_UnionOperationResponse responseUnionEnter = (U2M_UnionOperationResponse)await unit.Root().GetComponent<MessageSender>().Call(
                       UnitCacheHelper.GetUnionServerId(unit.Zone()),
                       new M2U_UnionOperationRequest() { OperateType = 3, UnitId = unit.Id, UnionId = unionid, Par = selfgold.ToString() });
            int unionLevel = int.Parse(responseUnionEnter.Par);
            UnionConfig unionConfig = UnionConfigCategory.Instance.Get(unionLevel);

            //Console.WriteLine($"unionConfig:  {unionLevel}  {unionConfig.XiuLianLevel} {unionQiangHuaConfig.QiangHuaLv}");
            if (unionQiangHuaConfig.QiangHuaLv >= unionConfig.XiuLianLevel)
            {
                return; 
            }

            unit.GetComponent<NumericComponentS>().ApplyValue( numerType, xiulianid+1);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub( UserDataType.UnionContri,(unionQiangHuaConfig.CostGold * -1).ToString(), true, ItemGetWay.UnionXiuLian);

            //刷新角色属性
            Function_Fight.UnitUpdateProperty_Base(unit,true,true);
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();  
            for (int i = petComponent.RolePetInfos.Count - 1; i >= 0; i--)
            {
                petComponent.UpdatePetAttribute(petComponent.RolePetInfos[i], false);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
