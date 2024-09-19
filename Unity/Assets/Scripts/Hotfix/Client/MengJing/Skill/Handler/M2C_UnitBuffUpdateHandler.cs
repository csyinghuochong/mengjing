using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitBuffUpdateHandler : MessageHandler<Scene, M2C_UnitBuffUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_UnitBuffUpdate message)
        {
            //抛出事件处理属性改变
            Unit msgUnitBelongTo = root.CurrentScene()?.GetComponent<UnitComponent>().Get(message.UnitIdBelongTo);
            if (msgUnitBelongTo == null)
            {
                //Log.Debug($"M2C_UnitBuffUpdate :{message.UnitIdBelongTo} == null");
                return;
            }

            switch (message.BuffOperateType)
            {
                case 1: //增加
                    BuffData buffData = new BuffData();
                    buffData.TargetAngle = 0;
                    buffData.BuffId = message.BuffID;
                    buffData.Spellcaster = message.Spellcaster;
                    buffData.BuffEndTime = message.BuffEndTime;
                    buffData.UnitType = message.UnitType;
                    buffData.UnitConfigId = message.UnitConfigId;
                    buffData.SkillId = message.SkillId;
                    buffData.UnitIdFrom = message.UnitIdFrom;
                    buffData.TargetPostion = new float3(message.TargetPostion[0], message.TargetPostion[1], message.TargetPostion[2]);
                    msgUnitBelongTo.GetComponent<BuffManagerComponentC>().BuffFactory(buffData);

                    EventSystem.Instance.Publish(root, new AddBuff() { Unit = msgUnitBelongTo, BuffId = message.BuffID });
                    break;
                case 2: //移除
                    msgUnitBelongTo.GetComponent<BuffManagerComponentC>().RemoveBuff(message.BuffID);
                    break;
                case 3: //重置
                    List<BuffC> buffList = msgUnitBelongTo.GetComponent<BuffManagerComponentC>().GetBuffByConfigId(message.BuffID);
                    for (int i = 0; i < buffList.Count; i++)
                    {
                        BuffHandlerC buffHandlerC = BuffDispatcherComponentC.Instance.Get(buffList[i].mSkillBuffConf.BuffScript);
                        buffHandlerC.OnReset(buffList[i], message.BuffEndTime);
                    }

                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}