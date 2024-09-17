using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Skill_OnSkillChainLight : AEvent<Scene, SkillChainLight>
    {
        protected override async ETTask Run(Scene scene, SkillChainLight args)
        {
            UnitComponent unitComponent = scene.CurrentScene().GetComponent<UnitComponent>();
            Unit start = unitComponent.Get(args.M2C_ChainLightning.UnitId);
            if (start == null)
            {
                return;
            }

            Unit target = unitComponent.Get(args.M2C_ChainLightning.TargetID);
            if (target == null)
            {
                return;
            }

            switch (args.M2C_ChainLightning.Type)
            {
                case 0:
                {
                    EffectData playEffectBuffData = new EffectData();
                    playEffectBuffData.TargetID = args.M2C_ChainLightning.TargetID;
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(args.M2C_ChainLightning.SkillID);
                    playEffectBuffData.EffectId = skillConfig.SkillEffectID[0]; //特效相关配置
                    playEffectBuffData.EffectPosition =
                            new Vector3(args.M2C_ChainLightning.PosX, args.M2C_ChainLightning.PosY, args.M2C_ChainLightning.PosZ); //技能目标点
                    playEffectBuffData.TargetAngle = 0; //技能角度
                    playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect; //特效类型
                    playEffectBuffData.InstanceId = target.InstanceId;
                    start.GetComponent<EffectViewComponent>()?.EffectFactory(playEffectBuffData);
                    break;
                }
                case 3:
                {
                    Unit myUnit = UnitHelper.GetMyUnitFromClientScene(scene);
                    EffectViewComponent effectViewComponent = myUnit.GetComponent<EffectViewComponent>();
                    if (effectViewComponent == null)
                    {
                        return;
                    }

                    Effect effect = effectViewComponent.GetEffect(args.M2C_ChainLightning.InstanceId);

                    if (effect == null)
                    {
                        EffectData playEffectBuffData = new EffectData();
                        playEffectBuffData.TargetID = args.M2C_ChainLightning.TargetID;
                        SkillConfig skillConfig = SkillConfigCategory.Instance.Get(args.M2C_ChainLightning.SkillID);
                        playEffectBuffData.EffectId = skillConfig.SkillEffectID[0]; //特效相关配置
                        playEffectBuffData.EffectPosition =
                                new Vector3(args.M2C_ChainLightning.PosX, args.M2C_ChainLightning.PosY,
                                    args.M2C_ChainLightning.PosZ); //技能目标点
                        playEffectBuffData.TargetAngle = 0; //技能角度
                        playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect; //特效类型
                        playEffectBuffData.InstanceId = args.M2C_ChainLightning.InstanceId;
                        myUnit.GetComponent<EffectViewComponent>()?.EffectFactory(playEffectBuffData);
                    }
                    else
                    {
                        effect.GetComponent<ChainLightningComponent>().Start =
                                start.GetComponent<HeroTransformComponent>().GetTranform(PosType.Center);
                        effect.GetComponent<ChainLightningComponent>().End =
                                target.GetComponent<HeroTransformComponent>().GetTranform(PosType.Center);
                    }

                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}