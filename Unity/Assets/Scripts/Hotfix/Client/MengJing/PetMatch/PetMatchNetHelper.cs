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
        
        
        public static async ETTask<PetMatch2C_RankListResponse> RequestPetMatchRankList(Scene root)
        {
            C2PetMatch_RankListRequest c2mPetEchoOperate = C2PetMatch_RankListRequest.Create();
           
            PetMatch2C_RankListResponse m2CPetEchoOperateResponse =
                    (PetMatch2C_RankListResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2mPetEchoOperate);
            return m2CPetEchoOperateResponse;
        }
    }
}