namespace ET.Client
{
    public static class TeamNetHelper
    {
        public static async ETTask<int> RequestTeamDungeonList(Scene root)
        {
            C2T_TeamDungeonInfoRequest request = new() { UserId = root.GetComponent<UserInfoComponentC>().UserInfo.UserId };
            T2C_TeamDungeonInfoResponse response = (T2C_TeamDungeonInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            root.GetComponent<TeamComponentC>().TeamList = response.TeamList;
            return response.Error;
        }
    }
}