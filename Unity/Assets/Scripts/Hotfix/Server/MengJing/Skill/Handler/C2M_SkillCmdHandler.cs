using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_SkillCmdHandler : MessageLocationHandler<Unit, C2M_SkillCmd, M2C_SkillCmd>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillCmd request, M2C_SkillCmd response)
        {
            await ETTask.CompletedTask;

            // if (request.PetId > 0)//宠物释放技能 ===>>>> 全部改成由玩家释放。
            // {
            //     Unit unitpet = unit.GetParent<UnitComponent>().Get(request.PetId);
            //     if (unitpet == null)
            //     {
            //         response.Error = ErrorCode.ERR_Pet_NoExist;
            //         return;
            //     }
            //
            //     unitpet.GetComponent<SkillManagerComponentS>().OnUseSkill(request);
            // }
            // else
            {
                int juexingid = 0;
                int occtwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
                if (occtwo != 0)
                {
                    OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtwo);
                    juexingid = occupationConfig.JueXingSkill[7];
                }
                if (juexingid == request.SkillID)
                {
                    if (unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.JueXingAnger) < 500)
                    {
                        response.Error = ErrorCode.Error_AngleNotEnough;
                        return;
                    }
                }

                unit.GetComponent<DBSaveComponent>().NoFindPath = 0;
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HorseRide, 0, true);
                SkillManagerComponentS skillManagerManagerComponent = unit.GetComponent<SkillManagerComponentS>();   
                M2C_SkillCmd m2C_SkillCmd = skillManagerManagerComponent.OnUseSkill(request, true);
             
                if (m2C_SkillCmd.Error == ErrorCode.ERR_Success)
                {
                    if (request.ItemId > 0)
                    {
                        unit.GetComponent<BagComponentS>().OnCostItemData($"{request.ItemId};1");

                        if (ConfigData.ChengJiuLianJin.Contains(request.ItemId))
                        {
                            unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.BattleUseItem_214, 0, 1);
                            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.BattleUseItem_30, 0, 1);
                        }
                    }
                    if (juexingid == request.SkillID)
                    {
                        unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.JueXingAnger, 0);
                    }
                }
             
                response.Error = m2C_SkillCmd.Error;
                response.Message = m2C_SkillCmd.Message;
                
            }
        }
    }
}