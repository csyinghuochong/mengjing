using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class Actor_FubenEnergySkillHandler : MessageLocationHandler<Unit, Actor_FubenEnergySkillRequest, Actor_FubenEnergySkillResponse>
    {

        protected override async ETTask Run(Unit unit, Actor_FubenEnergySkillRequest request, Actor_FubenEnergySkillResponse response)
        {
            //扣除对应道具
            bool costStatus = unit.GetComponent<BagComponentS>().OnCostItemData(ConfigData.EnergySkillCost);

            if (costStatus)
            {
                List<int> skills = new List<int>();
                foreach ((long id, Entity value) in unit.GetParent<UnitComponent>().Children)
                {
                    Unit unititem = value as Unit;
                    int e_skillid = unititem.GetComponent<NumericComponentS>().GetAsInt(NumericType.EnergySkillId);
                    if (e_skillid != 0)
                    {
                        skills.Add(e_skillid);
                    }
                }

                C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                cmd.SkillID = skills[RandomHelper.RandomNumber(0, skills.Count)];
                cmd.TargetAngle = 0;
                cmd.TargetID = unit.Id;
                unit.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, true);
            }
            else
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
            }
            await ETTask.CompletedTask;
        }
    }
}
