using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{

    public class RoleBuff_Base : BuffHandlerC
    {
        public override void OnInit(BuffC buffc, BuffData buffData, Unit theUnitBelongto)
        {
            buffc.BaseOnBuffInit(buffData,  theUnitBelongto);
            this.OnExecute(buffc);

            if (buffc.mSkillBuffConf.IfShowIconTips == 0 || buffc.BuffState == BuffState.Finished)
            {
                return;
            }
            
            if (buffc.TheUnitBelongto.MainHero || buffc.TheUnitBelongto.IsBoss())
            {
                EventSystem.Instance.Publish( buffc.Root(), new BuffUpdate()
                {
                    Unit = buffc.TheUnitBelongto,
                    ZoneScene = buffc.Root(),
                    ABuffHandler = buffc,
                    OperateType = 1,
                });
            }
        }

        public override void OnExecute(BuffC buffc)
        {
            buffc.EffectInstanceId = buffc.PlayBuffEffects();
            buffc.BuffState = BuffState.Running;
        }

        public override void OnReset(BuffC buffc, long endTime)
        {
            buffc.PassTime = 0f;
            buffc.BuffBeginTime = TimeHelper.ClientNow();
            buffc.BuffEndTime = endTime;
            EventSystem.Instance.Publish( buffc.Root(), new SkillEffectReset()
            {
                Unit = buffc.TheUnitBelongto,
                EffectInstanceId = buffc.EffectInstanceId
            });

            if (buffc.mSkillBuffConf.IfShowIconTips == 0)
            {
                return;
            }
            if (buffc.TheUnitBelongto.MainHero || buffc.TheUnitBelongto.IsBoss())
            {
                EventSystem.Instance.Publish( buffc.Root(), new  BuffUpdate()
                {
                    Unit = buffc.TheUnitBelongto,
                    ZoneScene = buffc.TheUnitBelongto.Root(),
                    ABuffHandler = buffc,
                    OperateType = 3
                });
            }
        }

        public override void OnUpdate(BuffC buffC)
        {
            buffC.BaseOnUpdate();
            if (TimeHelper.ServerNow() >= buffC.BuffEndTime)
            {
                buffC.BuffState = BuffState.Finished;
            }
        }

        public override void OnFinished(BuffC buffC)
        {
            EventSystem.Instance.Publish( buffC.Root(), new SkillEffectFinish()
            {
                EffectInstanceId = buffC.EffectInstanceId,
                Unit = buffC.TheUnitBelongto,
            });

            if (buffC.mSkillBuffConf.IfShowIconTips == 0)
            {
                return;
            }
            if (buffC.TheUnitBelongto.MainHero || buffC.TheUnitBelongto.IsBoss())
            {
                EventSystem.Instance.Publish( buffC.Root(), new BuffUpdate()
                {
                    Unit = buffC.TheUnitBelongto,
                    ZoneScene = buffC.TheUnitBelongto.Root(),
                    ABuffHandler = buffC,
                    OperateType = 2,
                });
            }
        }
    }
}
