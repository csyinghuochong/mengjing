using Unity.Mathematics;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SkillXuanZhuanHandler : MessageLocationHandler<Unit, C2M_SkillXuanZhuanRequest, M2C_SkillXuanZhuanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillXuanZhuanRequest request, M2C_SkillXuanZhuanResponse response)
        {
	        Unit rotationUnit = null;
            int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);
            
            if (petfightindex == 0)
            {
                rotationUnit = unit;
            }
            else
            {
                PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
                Unit petunit = petComponentS.GetFightPetByIndex(petfightindex);
                if (petunit == null)
                {
                    return;
                }

                rotationUnit = petunit;
            }
            
            rotationUnit.Rotation =   quaternion.Euler(0, math.radians(request.Angle), 0);
            
            M2C_SkillXuanZhuanMessage m2C_SkillXuanZhuan = M2C_SkillXuanZhuanMessage.Create();
            m2C_SkillXuanZhuan.UnitID = rotationUnit.Id;
            m2C_SkillXuanZhuan.Angle = request.Angle;
            MapMessageHelper.Broadcast(unit, m2C_SkillXuanZhuan);
            await ETTask.CompletedTask;
        }
    }
}