using System.Collections.Generic;

namespace ET.Server
{

    /// <summary>
    /// 给主人(宠物)加Buff
    /// </summary>
    public class Skill_Pet_AddBuff : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public Unit GetPetOrMaster(SkillS skillS)
        {
            if (skillS.TheUnitFrom.Type == UnitType.Pet)
            {
                long unitid = skillS.TheUnitFrom.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
                return skillS.TheUnitFrom.GetParent<UnitComponent>().Get(unitid);
            }
            else if (skillS.TheUnitFrom.Type == UnitType.Player)
            {
                RolePetInfo rolePetInfo = skillS.TheUnitFrom.GetComponent<PetComponentS>().GetFightPet();
                return rolePetInfo == null ? null : skillS.TheUnitFrom.GetParent<UnitComponent>().Get(rolePetInfo.Id);
            }
            return null;
        }

        public override void OnExecute(SkillS skillS)
        {
            Unit other = GetPetOrMaster(skillS);

            //触发初始化BUFF
            if (skillS.SkillConf.InitBuffID[0] != 0)
            {
                for (int y = 0; y < skillS.SkillConf.InitBuffID.Length; y++)
                {
                    skillS.SkillBuff(skillS.SkillConf.InitBuffID[y], skillS.TheUnitFrom);
                    skillS.SkillBuff(skillS.SkillConf.InitBuffID[y], other);
                }
            }

            SkillSetComponentS skillSetComponent = skillS.TheUnitFrom.GetComponent<SkillSetComponentS>();
            List<int> buffInitAdd = skillSetComponent != null ? skillSetComponent.GetBuffInitIdAdd(skillS.SkillConf.Id) : null;
            if (buffInitAdd != null)
            {
                for (int i = 0; i < buffInitAdd.Count; i++)
                {
                    skillS.SkillBuff(buffInitAdd[i], skillS.TheUnitFrom);
                    skillS.SkillBuff(buffInitAdd[i], other);
                }
            }

            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS,int updateMod3)
        {
            skillS.BaseOnUpdate();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }

    }
}
