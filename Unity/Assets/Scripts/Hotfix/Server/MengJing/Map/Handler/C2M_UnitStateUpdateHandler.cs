namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
    public class C2M_UnitStateUpdateHandler : MessageLocationHandler<Unit, C2M_UnitStateUpdate>
    {
		protected override async ETTask Run(Unit unit, C2M_UnitStateUpdate message)
		{
			//驭剑的光能击吟唱前可以给自己加buff
			if (message.StateOperateType == 1 &&  message.StateType == StateTypeEnum.Singing)
			{
                //"StateValue":"61022102_0
                int buffid = 0;
                int skillid = int.Parse(message.StateValue.Split('_')[0]);
			
				ConfigData.SingingBuffList.TryGetValue(skillid, out buffid);
				if (buffid != 0)
				{
                    BuffData buffData_1 = new BuffData();
                    buffData_1.SkillId = 67000278;
                    buffData_1.BuffId = buffid;
                    unit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_1, unit, null);
                }
            }

            if (message.StateOperateType == 1)
			{
				//增加
				unit.GetComponent<StateComponentS>().StateTypeAdd(message.StateType, message.StateValue);
			}
			else
			{
				//移除
				unit.GetComponent<StateComponentS>().StateTypeRemove(message.StateType);
			}
			
			await ETTask.CompletedTask;
		}
	}
}
