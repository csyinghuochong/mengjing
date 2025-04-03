using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPastureBuyHandler : MessageLocationHandler<Unit, C2M_JiaYuanPastureBuyRequest, M2C_JiaYuanPastureBuyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPastureBuyRequest request, M2C_JiaYuanPastureBuyResponse response)
        {
            int mysteryId = request.MysteryId;
            JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(mysteryId);
            if (jiaYuanPastureConfig == null)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }
            MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.JiaYuan)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }

            if (!unit.GetComponent<BagComponentS>().CheckCostItem($"13;{(int)(jiaYuanPastureConfig.BuyGold * 1.5f)}"))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfoComponent.UserInfo.JiaYuanLv);

            if (jiaYuanPastureConfig.BuyJiaYuanLv > jiaYuanConfig.Lv)
            {
                response.Error = ErrorCode.ERR_LvNoHigh;
                return;
            }
            
            if (jiaYuanComponent.GetPeopleNumber() >= jiaYuanConfig.PeopleNumMax)
            {
                response.Error = ErrorCode.ERR_PeopleNumber;
                return;
            }
            if (jiaYuanComponent.GetPeopleNumber() + jiaYuanPastureConfig.PeopleNum > jiaYuanConfig.PeopleNumMax)
            {
                response.Error = ErrorCode.ERR_PeopleNoEnough;
                return;
            }

            if (request.ProductId != -1)
            {
                int errorCode = jiaYuanComponent.OnPastureBuyRequest(request.ProductId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    response.Error = errorCode;
                    return;
                }
            }
            
            unit.GetComponent<UserInfoComponentS>().OnMysteryBuy(mysteryId);
            unit.GetComponent<BagComponentS>().OnCostItemData($"13;{(int)(jiaYuanPastureConfig.BuyGold * 1.5f)}");
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JiaYuanPastureNumber_94, 0, 1);

            JiaYuanPastures jiaYuanPastures = JiaYuanPastures.Create();
            jiaYuanPastures.ConfigId = jiaYuanPastureConfig.Id;
            jiaYuanPastures.StartTime = TimeHelper.ServerNow();
            jiaYuanPastures.UnitId = IdGenerater.Instance.GenerateId();

            UnitFactory.CreatePasture(unit.Scene(), jiaYuanPastures, unit.Id);
            List<JiaYuanPastures> JiaYuanPastureList_3 = unit.GetComponent<JiaYuanComponentS>().JiaYuanPastureList_7;
            JiaYuanPastureList_3.Add(jiaYuanPastures);
            UnitCacheHelper.SaveComponentCache( unit.Root(),  jiaYuanComponent ).Coroutine();
            
            response.JiaYuanPastureList .AddRange(JiaYuanPastureList_3); 
            await ETTask.CompletedTask;
        }
    }
}
