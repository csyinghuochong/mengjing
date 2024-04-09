using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_SkillCmdHandler : MessageLocationHandler<Unit, C2M_SkillCmd, M2C_SkillCmd>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillCmd request, M2C_SkillCmd response)
        {
            await ETTask.CompletedTask;
            
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
             unit.GetComponent<NumericComponentS>().SetEvent(NumericType.HorseRide, 0, true);
             SkillManagerComponentS skillManagerManagerComponent = unit.GetComponent<SkillManagerComponentS>();   
             M2C_SkillCmd m2C_SkillCmd = skillManagerManagerComponent.OnUseSkill(request, true);

             if (skillManagerManagerComponent.SkillSecond.ContainsKey(request.SkillID))
             {
                 int buffId = (int)SkillConfigCategory.Instance.BuffSecondSkill[skillManagerManagerComponent.SkillSecond[request.SkillID]].KeyId;

                 List<Unit> allDefend = unit.GetParent<UnitComponent>().GetAll();
                 for (int defend = 0; defend < allDefend.Count; defend++)
                 {
                     BuffManagerComponentS buffManagerManagerComponent = allDefend[defend].GetComponent<BuffManagerComponentS>();
                     if (buffManagerManagerComponent == null || allDefend[defend].Id == request.TargetID || allDefend[defend].Id == unit.Id)
                     {
                         continue;
                     }
                     int buffNum = buffManagerManagerComponent.GetBuffSourceNumber(unit.Id, buffId);
                     if (buffNum <= 0)
                     {
                         continue;
                     }
                     request.TargetID = allDefend[defend].Id;
                     buffManagerManagerComponent.BuffRemoveByUnit(0, buffId);
                     unit.GetComponent<SkillManagerComponentS>().OnUseSkill(request, false);
                 }
             }

             if (m2C_SkillCmd.Error == ErrorCode.ERR_Success)
             {
                 if (request.ItemId > 0)
                 {
                     unit.GetComponent<BagComponentS>().OnCostItemData($"{request.ItemId};1");

                     if (ConfigData.ChengJiuLianJin.Contains(request.ItemId))
                     {
                         unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.BattleUseItem_214, 0, 1);
                         unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.BattleUseItem_30, 0, 1);
                         unit.GetComponent<TaskComponentS>().TriggerTaskCountryEvent(TaskTargetType.BattleUseItem_30, 0, 1);
                     }
                 }
                 if (juexingid == request.SkillID)
                 {
                     unit.GetComponent<NumericComponentS>().Set(NumericType.JueXingAnger, 0);
                 }
             }
             
             response.Error = m2C_SkillCmd.Error;
             response.Message = m2C_SkillCmd.Message;
        }
    }
}