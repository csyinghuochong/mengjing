using System;

namespace ET.Client
{
    public class BagClientHelper
    {

        public static async ETTask<int> RequestBagInit(Scene root)
        {
            C2M_BagInitRequest reuqeust = new C2M_BagInitRequest();
            M2C_BagInitResponse initResponse = (M2C_BagInitResponse) await root.GetComponent<ClientSenderCompnent>().Call(reuqeust);
            
        }

    }
}



