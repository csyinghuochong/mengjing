namespace ET.Client
{
    public static partial class RankNetHelper
    {
        public static async ETTask<R2C_RankPetListResponse> RankPetList(Scene root, long userId)
        {
            C2R_RankPetListRequest request = new() { UserId = userId };
            R2C_RankPetListResponse response = (R2C_RankPetListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_FubenTimesResetResponse> FubenTimesReset(Scene root, int sceneType)
        {
            C2M_FubenTimesResetRequest request = new() { SceneType = SceneTypeEnum.PetTianTi };
            M2C_FubenTimesResetResponse response = (M2C_FubenTimesResetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<R2C_RankListResponse> RankList(Scene root)
        {
            C2R_RankListRequest request = new();
            R2C_RankListResponse response = (R2C_RankListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<R2C_RankTrialListResponse> RankTrialList(Scene root)
        {
            C2R_RankTrialListRequest request = new();
            R2C_RankTrialListResponse response = (R2C_RankTrialListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}