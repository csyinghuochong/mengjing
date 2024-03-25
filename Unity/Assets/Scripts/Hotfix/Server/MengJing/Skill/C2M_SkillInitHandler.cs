using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(SkillSetComponentS))]
    public class C2M_SkillInitHandler : MessageLocationHandler<Unit, C2M_SkillInitRequest, M2C_SkillInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillInitRequest request, M2C_SkillInitResponse response)
        {

            await ETTask.CompletedTask;
            
             int occ = unit.GetComponent<UserInfoComponentS>().GetOcc();
            int occTwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
             SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();
             response.SkillSetInfo = new SkillSetInfo();


             //强化技能可以激活
             bool haveqianghuaskill = false;
             for (int i = 0; i < skillSetComponent.SkillList.Count; i++)
             {
                 if (SkillHelp.IsQiangHuaSkill(occ, skillSetComponent.SkillList[i].SkillID))
                 {
                     haveqianghuaskill = true;
                     break;
                 }
             }

             if (!haveqianghuaskill)
             {
                 int[] baseSkilllist = OccupationConfigCategory.Instance.Get(occ).BaseSkill;
                 for (int i = 0; i < baseSkilllist.Length; i++)
                 {
                     if (skillSetComponent.GetBySkillID(baseSkilllist[i]) != null)
                     {
                         continue;
                     }
                     skillSetComponent.SkillList.Add(new SkillPro() { SkillID = baseSkilllist[i] });
                 }
             }

             //刷新转职技能
             if (occTwo != 0)
             {
                 ///移除重复的转职技能

                 OccupationTwoConfig occupationTwo = OccupationTwoConfigCategory.Instance.Get(occTwo);

                 List<int> occTwoSkillList = new List<int>(occupationTwo.SkillID) { };
                 List<int> selfoccTwoSkill = new List<int>() { };

                 int removeSkillIndex = 0;
                 for (int i = 0; i < skillSetComponent.SkillList.Count; i++)
                 {
                     int initskillid = SkillConfigCategory.Instance.GetInitSkill(skillSetComponent.SkillList[i].SkillID);
                     if (initskillid == 0)
                     {
                         continue;
                     }
                     if (!occTwoSkillList.Contains(initskillid))
                     {
                         continue;
                     }

                     if (selfoccTwoSkill.Contains(initskillid))
                     {
                         removeSkillIndex = (i);
                     }
                     else
                     {
                         selfoccTwoSkill.Add(initskillid);
                     }
                 }

                 if (removeSkillIndex != 0)
                 {
                     skillSetComponent.SkillList.RemoveAt(removeSkillIndex);
                 }

                 for (int i = 0; i < occTwoSkillList.Count; i++)
                 {
                     if (selfoccTwoSkill.Contains(occTwoSkillList[i]))
                     {
                         continue;
                     }

                     skillSetComponent.SkillList.Add(new SkillPro() { SkillID = occTwoSkillList[i] });
                 }
             }

             response.SkillSetInfo.SkillList = skillSetComponent.SkillList;
             response.SkillSetInfo.LifeShieldList = skillSetComponent.LifeShieldList;
             response.SkillSetInfo.TianFuPlan = skillSetComponent.TianFuPlan;

             List<int> allskill = new List<int>();
             for (int i = 0; i < skillSetComponent.SkillList.Count; i++)
             {
                 if (allskill.Contains(skillSetComponent.SkillList[i].SkillID))
                 {
                     Console.WriteLine($"重复技能ID: {skillSetComponent.SkillList[i].SkillID}");
                 }
                 else
                 {
                     allskill.Add(skillSetComponent.SkillList[i].SkillID);
                 }
             }

             List<int> tianfulist = new List<int>();
             for (int i = 0; i < skillSetComponent.TianFuList.Count; i++)
             {
                 if (!tianfulist.Contains(skillSetComponent.TianFuList[i]))
                 {
                     tianfulist.Add(skillSetComponent.TianFuList[i]);
                 }
             }
             response.SkillSetInfo.TianFuList = tianfulist;
             skillSetComponent.TianFuList = tianfulist;

             List<int> tianfulist1 = new List<int>();
             for (int i = 0; i < skillSetComponent.TianFuList1.Count; i++)
             {
                 if (!tianfulist1.Contains(skillSetComponent.TianFuList1[i]))
                 {
                     tianfulist1.Add(skillSetComponent.TianFuList1[i]);
                 }
             }
             response.SkillSetInfo.TianFuList1 = tianfulist1;
             skillSetComponent.TianFuList1 = tianfulist1;

        }
    }
}