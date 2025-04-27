using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class PlayerInfoComponent: Entity, IAwake
    {

        public ServerItem ServerItem { get; set; }

        public List<ServerItem> AllServerList { get; set; } = new(); //服务器列表存内容

        //当前角色列表数据
        public List<CreateRoleInfo> CreateRoleList{ get; set; }  = new();

        public PlayerInfo PlayerInfo { get; set; }

        public int Age_Type { get; set; } = -1;

        public long AccountId { get; set; } = 0;
        
        public string Token;
        public string RealmKey;
        public string RealmAddress;
        
        public string Account { get; set; }
        
        public string Password { get; set; }
        
        public string LoginType;

        public int VersionMode { get; set; }
        
        public long CurrentRoleId { get; set; }

        public long LastTime = 0;

        public string TianQiValue = "1";

        public string NoticeVersion = string.Empty;
        public string NoticeText = string.Empty;

        public int SerialErrorTime { get; set; } = 0;

        public int IsPopUp = 0;
        public string PopUpInfo = string.Empty;

        public int DisconnectType { get; set; }= 0;

        public bool CheckRealName { get; set; } = true;
    }
}