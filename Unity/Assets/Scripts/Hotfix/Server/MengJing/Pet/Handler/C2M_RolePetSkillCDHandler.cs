namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetSkillCDHandler : MessageLocationHandler<Unit, C2M_RolePetSkillCD, M2C_RolePetSkillCD>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetSkillCD request, M2C_RolePetSkillCD response)
        {
            SkillManagerComponentS skillManagerComponentS = null;
            
            if (request.PetId == 0)
            {
                skillManagerComponentS = unit.GetComponent<SkillManagerComponentS>();
            }
            else
            {
                Unit unitpet = unit.GetParent<UnitComponent>().Get(request.PetId);
                if (unitpet == null)
                {
                    response.Error = ErrorCode.ERR_Pet_NoExist;
                    return;
                }

                skillManagerComponentS = unitpet.GetComponent<SkillManagerComponentS>();
            }

            long serverTime = TimeHelper.ServerNow();
            foreach (var VARIABLE in  skillManagerComponentS.SkillCDs)
            {
                if (serverTime < VARIABLE.Value.CDEndTime )
                {
                    response.SkillCDs.Add( new KeyValuePairInt()
                    {
                        KeyId =  VARIABLE.Value.SkillID,
                        Value =  VARIABLE.Value.CDEndTime
                    });
                }
            }
            await ETTask.CompletedTask;
        }
    }
}