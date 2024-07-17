namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_LingDiUpHandler : MessageLocationHandler<Unit, C2M_LingDiUpRequest, M2C_LingDiUpResponse>
    {
        
        public static void OnAddLingDiExp(Unit unit, int addExp, bool notice)
        {
            int lingdiLv = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Ling_DiLv);
            int lingdiExp = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Ling_DiExp);
            LingDiConfig lingDiConfig = LingDiConfigCategory.Instance.Get(lingdiLv);
    
            int maxLevel = LingDiConfigCategory.Instance.GetAll().Values.Count;
            if (lingdiLv >= maxLevel && lingdiExp >= lingDiConfig.UpExp)
            {
                return;
            }

            int needCoin = lingDiConfig.GoldUp;
            if (addExp + lingdiExp >= lingDiConfig.UpExp && lingdiLv < maxLevel)
            {
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Ling_DiLv, lingdiLv + 1, notice);
                addExp = addExp + lingdiExp - lingDiConfig.UpExp;
            }
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Ling_DiExp, addExp + lingdiExp, notice);
        }

        
        protected override async ETTask Run(Unit unit, C2M_LingDiUpRequest request, M2C_LingDiUpResponse response)
        {
            int lingdiLv = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Ling_DiLv);
            int lingdiExp = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Ling_DiExp);
            LingDiConfig lingDiConfig = LingDiConfigCategory.Instance.Get(lingdiLv);
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Gold < lingDiConfig.GoldUp)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;    
            }
            int mapLevel = LingDiConfigCategory.Instance.GetAll().Values.Count;
            if (lingdiLv >= mapLevel && lingdiExp >= lingDiConfig.UpExp)
            {
                return;
            }

            int addExp = lingDiConfig.AddExp;
            int needCoin = lingDiConfig.GoldUp;
            //if (addExp + lingdiExp >= lingDiConfig.UpExp && lingdiLv < mapLevel)
            //{
            //    unit.GetComponent<NumericComponent>().ApplyValue(NumericType.Ling_DiLv, lingdiLv + 1);
            //    addExp = addExp + lingdiExp - lingDiConfig.UpExp;
            //}
            //unit.GetComponent<NumericComponent>().ApplyValue(NumericType.Ling_DiExp, addExp + lingdiExp);
            OnAddLingDiExp(unit, addExp, true);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData( UserDataType.Gold, (needCoin * -1).ToString());
            
            await ETTask.CompletedTask;
        }
    }
}
