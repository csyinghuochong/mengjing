using ET.Server;

namespace ET
{

    // 所有属性都会进来这个事件
    // 发送客户端数值更新消息   EventType.NumericApplyChangeValue
    public static class NumbericChangeBroadcastHelper
    {
        public static  void Broadcast(NumbericChange args)
        {
            if (args.Defend == null || args.Defend.IsDisposed)
            {
                return;
            }

            //主城不广播任何血量相关数值
			if (args.Defend.SceneType == MapTypeEnum.MainCityScene)
            {
                if (args.NumericType == NumericType.Now_MaxHp || args.NumericType == NumericType.Now_Hp)
                {
                    return;
                }
            }

            M2C_UnitNumericUpdate m2C_UnitNumericUpdate = M2C_UnitNumericUpdate.Create();
            m2C_UnitNumericUpdate.UnitId = args.Defend.Id;
            m2C_UnitNumericUpdate.NumericType = args.NumericType;
            m2C_UnitNumericUpdate.NewValue = args.NewValue;
            m2C_UnitNumericUpdate.OldValue = args.OldValue;
            m2C_UnitNumericUpdate.SkillId = args.SkillId;
            m2C_UnitNumericUpdate.DamgeType = args.DamgeType;
            m2C_UnitNumericUpdate.AttackId = args.AttackId;
            MapMessageHelper.Broadcast(args.Defend, m2C_UnitNumericUpdate);
        }

        public static void SendToClient(NumbericChange args)
        {
            if (args.Defend == null)
            {
                Log.Debug("NumericChangeEvent args.Parent == null");
                return;
            }
            if (args.Defend.IsDisposed)
            {
                Log.Debug($"NumericChangeEvent args.Parent.IsDisposed {args.Defend.Id}");
                return;
            }

            if (args.Defend.Type != UnitType.Player)
            {
                return;
            }

            M2C_UnitNumericUpdate m2C_UnitNumericUpdate = M2C_UnitNumericUpdate.Create();
            m2C_UnitNumericUpdate.UnitId = args.Defend.Id;
            m2C_UnitNumericUpdate.NumericType = args.NumericType;
            m2C_UnitNumericUpdate.NewValue = args.NewValue;
            m2C_UnitNumericUpdate.OldValue = args.OldValue;
            m2C_UnitNumericUpdate.SkillId = args.SkillId;
            m2C_UnitNumericUpdate.DamgeType = args.DamgeType;
            m2C_UnitNumericUpdate.AttackId = 0;
            MapMessageHelper.SendToClient(args.Defend, m2C_UnitNumericUpdate);
        }
    }
    
}