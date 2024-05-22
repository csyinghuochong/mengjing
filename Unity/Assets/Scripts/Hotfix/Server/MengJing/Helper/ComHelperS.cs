namespace ET.Server
{
    
    public static class ComHelperS
    {
    
        public static bool IsInnerNet()
        {
            if (StartMachineConfigCategory.Instance.Get(1).OuterIP.Contains("127.0.0.1")
                || StartMachineConfigCategory.Instance.Get(1).OuterIP.Contains("192.168"))
            {
                return true;
            }
            return false;
        }

        public static bool IsBanHaoZone()
        {
            //////20201是版号区的
            if (StartMachineConfigCategory.Instance.Get(1).WatcherPort.Equals("20201") )
            {
                return true;
            }
            return false;
        }

    }
    
}