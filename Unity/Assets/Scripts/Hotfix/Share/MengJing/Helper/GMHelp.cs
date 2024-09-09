using System.Collections.Generic;

namespace ET
{
    public static class GMHelp
    {

        //qqUID_84E70C11CC937F72EE508CD43D7DD4DA һֱ��ͷ��
        public static bool IsGmAccount(string account)
        {
            return GMData.GmAccount.Contains(account);
        }

        public static bool BanChatPlayer (string account)
        {
            return false;
        }

        public static string GetPopUpPlayer(long unitId)
        {
            if (unitId == 2103768474428964866)
            {
                return "9@提示1@�提示2";
            }
            return string.Empty;
        }

        public static List<string> GetChuJi()
        {
            List<string> vs = new List<string>();
            vs.Add("1#1#1000000");
            vs.Add("1#3#1000000");
            vs.Add("6#20");
            vs.Add("8#10");
            vs.Add("1#10030301#1");
            vs.Add("1#10030303#1");
            vs.Add("1#10030305#1");
            vs.Add("1#10030307#1");
            vs.Add("1#10030309#1");
            vs.Add("1#10030311#1");
            vs.Add("1#10030313#1");
            vs.Add("1#10030315#1");
            vs.Add("1#10030316#1");
            vs.Add("1#10030317#1");
            vs.Add("1#10030320#1");
            vs.Add("1#10010083#999");
            vs.Add("1#10010026#99");


            return vs;
        }

        public static List<string> GetZhongJi()
        {
            List<string> vs = new List<string>();
            vs.Add("6#35");
            vs.Add("1#1#9999999");
            vs.Add("1#3#9999999");
            vs.Add("1#6#9999999");
            vs.Add("8#15");
            vs.Add("1#10030401#1");
            vs.Add("1#10030403#1");
            vs.Add("1#10030405#1");
            vs.Add("1#10030407#1");
            vs.Add("1#10030409#1");
            vs.Add("1#10030411#1");
            vs.Add("1#10030413#1");
            vs.Add("1#10030415#1");
            vs.Add("1#10030416#1");
            vs.Add("1#10030418#1");
            vs.Add("1#10030420#1");
            vs.Add("1#10020212#10");
            vs.Add("1#10020056#99");
            vs.Add("1#10011002#10");
            vs.Add("1#10010083#999");
            vs.Add("1#10010026#99");
            vs.Add("1#10020015#10");

            return vs;
        }

        public static List<string> GetGaopJi()
        {
            List<string> vs = new List<string>();
            vs.Add("6#50");
            vs.Add("6#60");
            vs.Add("1#1#9999999");
            vs.Add("1#3#9999999");
            vs.Add("1#6#9999999");
            vs.Add("8#25");
            vs.Add("1#10030630#1");
            vs.Add("1#10030631#1");
            vs.Add("1#10030632#1");
            vs.Add("1#10030633#1");
            vs.Add("1#10030634#1");
            vs.Add("1#10030635#1");
            vs.Add("1#10030636#1");
            vs.Add("1#10030637#1");
            vs.Add("1#10030638#1");
            vs.Add("1#10030639#1");
            vs.Add("1#10030640#1");
            vs.Add("1#10020212#10");
            vs.Add("1#10020056#99");
            vs.Add("1#10011004#10");
            vs.Add("1#10010083#999");
            vs.Add("1#10010026#99");
            vs.Add("1#10020015#10");
            vs.Add("1#10020063#50");
            vs.Add("1#10020110#50");
            vs.Add("1#10020161#50");
            vs.Add("1#10020215#50");
            vs.Add("1#10020216#50");
            vs.Add("1#10010532#1");
            vs.Add("1#10020209#50");
            vs.Add("1#10020210#50");
            vs.Add("1#10020211#50");

            return vs;
        }

        public static int GetRandomNumber()
        {
            return 2;
        }
    }
}
