namespace ET.Client
{
    public static partial class RankNetHelper
    {
        public static async ETTask<R2C_RankPetListResponse> RankPetList(Scene root, long userId)
        {
            C2R_RankPetListRequest request = C2R_RankPetListRequest.Create();
            request.UserId = userId;

            R2C_RankPetListResponse response = (R2C_RankPetListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_FubenTimesResetResponse> FubenTimesReset(Scene root, int sceneType)
        {
            C2M_FubenTimesResetRequest request = C2M_FubenTimesResetRequest.Create();
            request.SceneType = MapTypeEnum.PetTianTi;

            M2C_FubenTimesResetResponse response = (M2C_FubenTimesResetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<R2C_RankListResponse> RankList(Scene root)
        {
            C2R_RankListRequest request = C2R_RankListRequest.Create();

            R2C_RankListResponse response = (R2C_RankListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<R2C_RankTrialListResponse> RankTrialList(Scene root)
        {
            C2R_RankTrialListRequest request = C2R_RankTrialListRequest.Create();

            R2C_RankTrialListResponse response = (R2C_RankTrialListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<R2C_RankShowLieResponse> RankShowLie(Scene root)
        {
            C2R_RankShowLieRequest request = C2R_RankShowLieRequest.Create();

            R2C_RankShowLieResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_RankShowLieResponse;

            return response;
        }

        public static async ETTask<R2C_RankUnionRaceResponse> RankUnionRaceRequest(Scene root)
        {
            C2R_RankUnionRaceRequest request = C2R_RankUnionRaceRequest.Create();

            R2C_RankUnionRaceResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_RankUnionRaceResponse;

            return response;
        }
    }
}