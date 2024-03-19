using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentServer))]
    public class C2M_SkillCmdHandler : MessageLocationHandler<Unit, C2M_SkillCmd, M2C_SkillCmd>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillCmd request, M2C_SkillCmd response)
        {
            await ETTask.CompletedTask;
            
             int juexingid = 0;
             int occtwo = unit.GetComponent<UserInfoComponentServer>().GetOccTwo();
             if (occtwo != 0)
             {
                 OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtwo);
                 juexingid = occupationConfig.JueXingSkill[7];
             }
             if (juexingid == request.SkillID)
             {
                 if (unit.GetComponent<NumericComponentServer>().GetAsLong(NumericType.JueXingAnger) < 500)
                 {
                     response.Error = ErrorCode.Error_AngleNotEnough;
                     return;
                 }
             }

             unit.GetComponent<DBSaveComponent>().NoFindPath = 0;
             unit.GetComponent<NumericComponentServer>().SetEvent(NumericType.HorseRide, 0, true);
             SkillComponentServer skillManagerComponent = unit.GetComponent<SkillComponentServer>();   
             M2C_SkillCmd m2C_SkillCmd = skillManagerComponent.OnUseSkill(request, true);

             if (skillManagerComponent.IsSkillSecond(request.SkillID))
             {
                 int buffId = (int)SkillConfigCategory.Instance.BuffSecondSkill[skillManagerComponent.SkillSecondBuffId(request.SkillID)].KeyId;

                 List<Unit> allDefend = unit.GetParent<UnitComponent>().GetAll();
                 for (int defend = 0; defend < allDefend.Count; defend++)
                 {
                     BuffComponentServer buffManagerComponent = allDefend[defend].GetComponent<BuffComponentServer>();
                     if (buffManagerComponent == null || allDefend[defend].Id == request.TargetID || allDefend[defend].Id == unit.Id)
                     {
                         continue;
                     }
                     int buffNum = buffManagerComponent.GetBuffSourceNumber(unit.Id, buffId);
                     if (buffNum <= 0)
                     {
                         continue;
                     }
                     request.TargetID = allDefend[defend].Id;
                     buffManagerComponent.BuffRemoveByUnit(0, buffId);
                     unit.GetComponent<SkillComponentServer>().OnUseSkill(request, false);
                 }
             }

             if (m2C_SkillCmd.Error == ErrorCode.ERR_Success)
             {
                 if (request.ItemId > 0)
                 {
                     unit.GetComponent<BagComponentServer>().OnCostItemData($"{request.ItemId};1");

                     if (ConfigData.ChengJiuLianJin.Contains(request.ItemId))
                     {
                         unit.GetComponent<ChengJiuComponentServer>().TriggerEvent(ChengJiuTargetEnum.BattleUseItem_214, 0, 1);
                         unit.GetComponent<TaskComponentServer>().TriggerTaskEvent(TaskTargetType.BattleUseItem_30, 0, 1);
                         unit.GetComponent<TaskComponentServer>().TriggerTaskCountryEvent(TaskTargetType.BattleUseItem_30, 0, 1);
                     }
                 }
                 if (juexingid == request.SkillID)
                 {
                     unit.GetComponent<NumericComponentServer>().Set(NumericType.JueXingAnger, 0);
                 }
             }
             
             response.Error = m2C_SkillCmd.Error;
             response.Message = m2C_SkillCmd.Message;
        }
    }
}