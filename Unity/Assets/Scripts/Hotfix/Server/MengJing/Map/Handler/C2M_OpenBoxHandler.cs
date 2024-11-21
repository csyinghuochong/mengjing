
namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(PetComponentS))]
    [FriendOf(typeof(BagComponentS))]
    public class C2M_OpenBoxHandler: MessageLocationHandler<Unit, C2M_OpenBoxRequest, M2C_OpenBoxResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_OpenBoxRequest request, M2C_OpenBoxResponse response)
        {
            Log.Debug($"C2M_OpenBoxHandler: server0");
            
            Unit boxUnit = unit.GetParent<UnitComponent>().Get(request.UnitId);
            if (boxUnit == null)
            {
                response.Error = ErrorCode.ERR_Success;
                return;
            }
            if (boxUnit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) == 1)
            {
                response.Error = ErrorCode.ERR_Success;
                return;
            }
            int monsterid = boxUnit.ConfigId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);
            string itemneeds = "";
            if (monsterConfig.Parameter != null && monsterConfig.Parameter.Length > 0
                && monsterConfig.Parameter[0]>0)
            {
                itemneeds = $"{monsterConfig.Parameter[0]};{monsterConfig.Parameter[1]}";
            }
            if (itemneeds.Length >2 && !unit.GetComponent<BagComponentS>().OnCostItemData(itemneeds))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_57) 
            {
                //背包是否满
                if (unit.GetComponent<BagComponentS>().IsBagFullByLoc(ItemLocType.ItemLocBag))
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                //宠物已满
                if (unit.GetComponent<PetComponentS>().PetIsFull())
                {
                    response.Error = ErrorCode.ERR_PetIsFull;
                    return;
                }
            }

            boxUnit.GetComponent<HeroDataComponentS>().OnDead(unit);
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.OpenBox_137, 0, 1);

            response.Error = ErrorCode.ERR_Success;
            await ETTask.CompletedTask;
        }
    }
}

