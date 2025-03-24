using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_ZhuBuType2Handler : MessageLocationHandler<Unit, C2M_ZhuBuType2Request, M2C_ZhuBuType2Response>
    {
        protected override async ETTask Run(Unit unit, C2M_ZhuBuType2Request request, M2C_ZhuBuType2Response response)
        {
            Unit zhupuUnit = unit.GetParent<UnitComponent>().Get(request.JingLingId);
            if (zhupuUnit == null)
            {
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(zhupuUnit.ConfigId);
            if(monsterConfig.QiYuPetId == 0)
            {
                return;
            }

            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (request.ItemId != 0)
            {
                bool costresult =  unit.GetComponent<BagComponentS>().OnCostItemData($"{request.ItemId};1");
                if (costresult == false)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
            }

            // 捕捉有3种情况，
            // 捕捉成功，
            // 捕捉失败怪物死亡（就是隐藏 并播放特效）
            // 捕捉失败怪物逃跑（怪物随机出现在当前地图的任意一个位置）
            int gailv = CommonHelp.GetZhuPuType2_GaiLv(zhupuUnit.ConfigId, request.ItemId, int.Parse(request.OperateType));
            if (RandomHelper.RandFloat01() <= gailv * 0.0001f)
            {
                response.Message = String.Empty;
                
                int babyType = zhupuUnit.GetComponent<NumericComponentS>().GetAsInt(NumericType.BaByType);
                unit.GetComponent<PetComponentS>().OnAddPet(ItemGetWay.PickItem, monsterConfig.QiYuPetId, 0, 0, babyType, monsterConfig.Lv);
                unit.GetParent<UnitComponent>().Remove(request.JingLingId);
            }
            else
            {
                int failType = RandomHelper.RandomNumber(1, 3);
                if (failType == 1)
                {
                    
                }
                else
                {
                    
                }
                response.Message = failType.ToString();
            }

            await ETTask.CompletedTask;
        }
    }
}