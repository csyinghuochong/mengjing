namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_JingLingUseHandler : MessageLocationHandler<Unit, C2M_JingLingUseRequest, M2C_JingLingUseResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingLingUseRequest request, M2C_JingLingUseResponse response)
        {
            ChengJiuComponentS chengJiuComponent = unit.GetComponent<ChengJiuComponentS>();
            if (unit.GetParent<UnitComponent>().Get(chengJiuComponent.JingLingUnitId) != null)
            {
                unit.GetParent<UnitComponent>().Remove(chengJiuComponent.JingLingUnitId);
            }

            JingLingInfo jingLingInfo = chengJiuComponent.GetFightJingLing();
            if (jingLingInfo != null)
            {
                JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jingLingInfo.JingLingID);
                if (jingLingConfig.FunctionType == JingLingFunctionType.AddSkill)
                {
                    int skillid = int.Parse(jingLingConfig.FunctionValue);
                    BuffManagerComponentS buffManagerManagerComponent = unit.GetComponent<BuffManagerComponentS>();
                    buffManagerManagerComponent.BuffRemoveBySkillid(skillid);
                }
            }

            if (jingLingInfo!=null && jingLingInfo.JingLingID == request.JingLingId)
            {
                chengJiuComponent.OnFightJingLing(0);
                chengJiuComponent.JingLingUnitId = 0;
            }
            else
            {
                chengJiuComponent.OnFightJingLing(request.JingLingId);
                chengJiuComponent.JingLingUnitId = UnitFactory.CreateJingLing(unit, request.JingLingId).Id;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
