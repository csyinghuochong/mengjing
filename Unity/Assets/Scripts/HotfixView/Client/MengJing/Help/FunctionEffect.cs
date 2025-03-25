using Unity.Mathematics;

namespace ET.Client
{
    
    
    public static class FunctionEffect
    {
        
        public static void PlayHitEffect(Unit attack, Unit unit,int skillID) 
          {
              //Log.Info("播放受击特效PlayHitEffect:" + skillID);
              //播放受击特效
              if (skillID == 0)
              {
                  return;
              }
              
              SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
              if (skillCof.SkillHitEffectID == 0)
              {
                  return;
              }

              if(!EffectConfigCategory.Instance.Contain(skillCof.SkillHitEffectID))
              {
                  return;
              }

              int angle = 0;
              EffectConfig effectConfig = EffectConfigCategory.Instance.Get(skillCof.SkillHitEffectID);
              if (attack!=null && effectConfig.PlayType == 1)
              {
                  float3 direction = attack.Position - unit.Position;
                  angle = (int)math.floor((math.atan2(direction.x, direction.z)) * 3.14f);
              }
              EffectData playEffectBuffData = new EffectData();
              playEffectBuffData.EffectId = skillCof.SkillHitEffectID;                  //特效相关配置
              playEffectBuffData.EffectPosition = float3.zero;
              playEffectBuffData.TargetAngle = angle;
              playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;
              playEffectBuffData.InstanceId = 1;
              unit.GetComponent<EffectViewComponent>()?.EffectFactory(playEffectBuffData);
          }

          public static void PlaySelfEffect(Unit unit, int effectID)
          {
              EffectData playEffectBuffData = new EffectData();
              playEffectBuffData.EffectId = effectID;                  //特效相关配置
              playEffectBuffData.EffectPosition = float3.zero;
              playEffectBuffData.TargetAngle = 0;
              playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;
              playEffectBuffData.InstanceId = 1;
              unit.GetComponent<EffectViewComponent>()?.EffectFactory(playEffectBuffData);
          }

          public static void PlayEffectPosition(Unit unit, int effectID, float3 position)
          {
              EffectData playEffectBuffData = new EffectData();
              playEffectBuffData.EffectId = effectID;                  //特效相关配置
              playEffectBuffData.EffectPosition = position;
              playEffectBuffData.TargetAngle = 0;
              playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;
              playEffectBuffData.InstanceId = 1;
              unit.GetComponent<EffectViewComponent>()?.EffectFactory(playEffectBuffData);
          }
          
          public  static void PlayDropEffect(Unit unit, int effectID)
          {
              EffectData playEffectBuffData = new EffectData();
              playEffectBuffData.EffectId = effectID;                  //特效相关配置
              playEffectBuffData.EffectPosition = float3.zero;
              playEffectBuffData.TargetAngle = 0;
              playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;
              playEffectBuffData.InstanceId = 1;
              unit.GetComponent<EffectViewComponent>()?.EffectFactory(playEffectBuffData);
          }
    }
    
}