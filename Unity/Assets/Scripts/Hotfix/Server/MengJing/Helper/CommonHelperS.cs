namespace ET.Server
{
    
    public static class CommonHelperS
    {

        public static bool IsStateBroadcastType(long nowStateType)
        {
            return nowStateType == StateTypeEnum.Singing
                    || nowStateType == StateTypeEnum.OpenBox
                    || nowStateType == StateTypeEnum.Stealth
                    || nowStateType == StateTypeEnum.Hide
                    || nowStateType == StateTypeEnum.BaTi;  
        }

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
        
        public static bool IsInnerNet()
        {
            if (StartMachineConfigCategory.Instance.Get(1).OuterIP.Contains("127.0.0.1")
                || StartMachineConfigCategory.Instance.Get(1).OuterIP.Contains("192.168"))
            {
                return true;
            }
            return false;
        }

       
        
        public static int GetWorldLv(int openserverDay)
        {
            int worldLv = 0;
            string[] lvlist = GlobalValueConfigCategory.Instance.Get(42).Value.Split('@');
            for (int i = 0; i < lvlist.Length; i++)
            {
                string[] levelinfo = lvlist[i].Split(';');
                worldLv = int.Parse(levelinfo[1]);
                if (openserverDay <= int.Parse(levelinfo[0]))
                {
                    return worldLv;
                }
            }
            return worldLv;
        }

    }
    
}