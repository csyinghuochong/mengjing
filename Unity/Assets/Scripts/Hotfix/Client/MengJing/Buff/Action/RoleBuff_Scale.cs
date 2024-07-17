namespace ET.Client
{
    
    public class RoleBuff_Scale : RoleBuff_Base
    {
        public override void OnInit(BuffC buffC, BuffData buffData, Unit theUnitBelongto)
        {
            base.OnInit(buffC, buffData, theUnitBelongto);
            EventSystem.Instance.Publish( buffC.Root(), new  BuffScale()
            {
                Unit = buffC.TheUnitBelongto,
                ZoneScene = buffC.TheUnitBelongto.Root(),
                ABuffHandler = buffC,
                OperateType = 1,
            });
        }

        public override void OnFinished(BuffC buffC)
        {
            EventSystem.Instance.Publish( buffC.Root(), new  BuffScale()
            {
                Unit = buffC.TheUnitBelongto,
                ZoneScene = buffC.TheUnitBelongto.Root(),
                ABuffHandler = buffC,
                OperateType = 2,
            });

            base.OnFinished(buffC);
        }
    }
}
