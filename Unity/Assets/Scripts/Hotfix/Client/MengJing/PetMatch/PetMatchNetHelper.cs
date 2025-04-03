using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public static class PetMatchNetHelper
    {
        
        public static async ETTask<int> RequestPetMatch(Scene root)
        {
            C2M_PetMatchRequest c2mPetEchoOperate = C2M_PetMatchRequest.Create();
           
            M2C_PetMatchResponse m2CPetEchoOperateResponse =
                    (M2C_PetMatchResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2mPetEchoOperate);
            return m2CPetEchoOperateResponse.Error;
        }
    }
}