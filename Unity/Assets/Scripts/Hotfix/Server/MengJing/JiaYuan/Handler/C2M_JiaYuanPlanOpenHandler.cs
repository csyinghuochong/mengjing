using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPlanOpenHandler : MessageLocationHandler<Unit, C2M_JiaYuanPlanOpenRequest, M2C_JiaYuanPlanOpenResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPlanOpenRequest request, M2C_JiaYuanPlanOpenResponse response)
        {
            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            List<int> PlanOpenList_2 = jiaYuanComponent.PlanOpenList_7;
            if (PlanOpenList_2.Contains(request.CellIndex))
            {
                response.PlanOpenList .AddRange(PlanOpenList_2); ;
                return;
            }
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfoComponent.UserInfo.JiaYuanLv);
            if (jiaYuanComponent.GetOpenPlanNumber() >= jiaYuanConfig.FarmNumMax)
            {
                response.Error = ErrorCode.ERR_JiaYuanLevel;
                return;
            }

            int costNumber = ConfigData.JiaYuanFarmOpen[request.CellIndex];
            if (!unit.GetComponent<BagComponentS>().CheckCostItem($"13;{costNumber}"))
            {
                response.PlanOpenList .AddRange(PlanOpenList_2); 
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            PlanOpenList_2.Add(request.CellIndex);
            response.PlanOpenList .AddRange(PlanOpenList_2); 
            unit.GetComponent<BagComponentS>().OnCostItemData($"13;{costNumber}");
            UnitCacheHelper.SaveComponentCache(unit.Root(), unit.GetComponent<JiaYuanComponentS>()).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
