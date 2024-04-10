﻿using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{

    public class RoleBuff_Base : BuffHandlerC
    {
        public override void OnInit(BuffC buffc, BuffData buffData, Unit theUnitBelongto)
        {
            buffc.BaseOnBuffInit(buffData,  theUnitBelongto);
            this.OnExecute();

            if (buffc.mSkillBuffConf.IfShowIconTips == 0 || buffc.BuffState == BuffState.Finished)
            {
                return;
            }
            UnitHelper
            if (buffc.TheUnitBelongto.MainHero || buffc.TheUnitBelongto.IsBoss())
            {
                EventType.BuffUpdate.Instance.Unit = this.TheUnitBelongto;
                EventType.BuffUpdate.Instance.ZoneScene = this.TheUnitBelongto.ZoneScene();
                EventType.BuffUpdate.Instance.ABuffHandler = this;
                EventType.BuffUpdate.Instance.OperateType = 1;
                //EventType.DataUpdate.Instance.DataParams = $"{buffData.BuffConfig.Id}@1";
                EventSystem.Instance.PublishClass(EventType.BuffUpdate.Instance);
            }
        }

        public override void OnExecute()
        {
            this.EffectInstanceId = this.PlayBuffEffects();
            this.BuffState = BuffState.Running;
        }

        public override void OnReset(long endTime)
        {
            this.PassTime = 0f;
            this.BuffBeginTime = TimeHelper.ClientNow();
            this.BuffEndTime = endTime;
            EventType.SkillEffectReset.Instance.Unit = TheUnitBelongto;
            EventType.SkillEffectReset.Instance.EffectInstanceId = this.EffectInstanceId;
            EventSystem.Instance.PublishClass(EventType.SkillEffectReset.Instance);

            if (this.mSkillBuffConf.IfShowIconTips == 0)
            {
                return;
            }
            if (this.TheUnitBelongto.MainHero || this.TheUnitBelongto.IsBoss())
            {
                EventType.BuffUpdate.Instance.Unit = this.TheUnitBelongto;
                EventType.BuffUpdate.Instance.ZoneScene = this.TheUnitBelongto.ZoneScene();
                EventType.BuffUpdate.Instance.ABuffHandler = this;
                EventType.BuffUpdate.Instance.OperateType = 3;
                EventSystem.Instance.PublishClass(EventType.BuffUpdate.Instance);
            }
        }

        public override void OnUpdate()
        {
            this.BaseOnUpdate();
            if (TimeHelper.ServerNow() >= this.BuffEndTime)
            {
                this.BuffState = BuffState.Finished;
            }
        }

        public override void OnFinished()
        {
            EventType.SkillEffectFinish.Instance.EffectInstanceId = this.EffectInstanceId;
            EventType.SkillEffectFinish.Instance.Unit = this.TheUnitBelongto;
            EventSystem.Instance.PublishClass(EventType.SkillEffectFinish.Instance);

            if (this.mSkillBuffConf.IfShowIconTips == 0)
            {
                return;
            }
            if (this.TheUnitBelongto.MainHero || this.TheUnitBelongto.IsBoss())
            {
                EventType.BuffUpdate.Instance.Unit = this.TheUnitBelongto;
                EventType.BuffUpdate.Instance.ZoneScene = this.TheUnitBelongto.ZoneScene();
                EventType.BuffUpdate.Instance.ABuffHandler = this;
                EventType.BuffUpdate.Instance.OperateType = 2;
                EventSystem.Instance.PublishClass(EventType.BuffUpdate.Instance);
            }
        }
    }
}
