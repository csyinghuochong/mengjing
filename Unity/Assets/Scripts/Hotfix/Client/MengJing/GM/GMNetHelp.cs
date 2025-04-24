using System.Collections.Generic;

namespace ET.Client
{
    public static partial class GMNetHelp
    {
        public static void ExcurteGmList(Scene scene, List<string> gms)
        {
            for (int i = 0; i < gms.Count; i++)
            {
                SendGmCommand(scene, gms[i]);
            }
        }

        public static void SendGmCommand(Scene scene, string gm)
        {
            C2M_GMCommand request = new() { GMMsg = gm, Account = scene.GetComponent<PlayerInfoComponent>().Account };
            scene.GetComponent<ClientSenderCompnent>().Send(request);
        }

        public static void SendGmCommands(Scene scene, string gmlist)
        {
            if (gmlist.Contains("chuji"))
            {
                ExcurteGmList(scene, ET.GMHelp.GetChuJi());
                return;
            }

            if (gmlist.Contains("zhongji"))
            {
                ExcurteGmList(scene, ET.GMHelp.GetZhongJi());
                return;
            }

            if (gmlist.Contains("gaoji"))
            {
                ExcurteGmList(scene, ET.GMHelp.GetGaopJi());
                return;
            }
        }
    }
}