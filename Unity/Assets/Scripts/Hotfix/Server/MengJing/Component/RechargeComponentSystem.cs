namespace ET.Server
{

    [EntitySystemOf(typeof(RechargeComponent))]
    [FriendOf(typeof(RechargeComponent))]
    public static partial class RechargeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RechargeComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this RechargeComponent self)
        {

        }
        
        
        public static void OnLogin(this RechargeComponent self)
        {
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            int rechageBuchang = numericComponent.GetAsInt(NumericType.RechargeBuChang);
            numericComponent.ApplyValue(NumericType.RechargeBuChang, 0, false);
            RechargeHelp.OnRechage(self.GetParent<Unit>(), rechageBuchang, false);
        }
    }

}