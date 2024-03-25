﻿using System.Collections.Generic;


namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class PlayerComponent: Entity, IAwake
    {
        public long MyId { get; set; }
        
        public List<ServerItem> AllServerList = new List<ServerItem>();         //服务器列表存内容

        //当前角色列表数据
        public List<CreateRoleInfo> CreateRoleList = new List<CreateRoleInfo>();

        public PlayerInfo PlayerInfo;

        public int Age_Type = -1;	

        public long AccountId = 0;

        public string Token;

        public string RealmKey;
        public string RealmAddress;

        //当前登录角色
        public int ServerId;
        public string ServerIp;
        public string Account { get; set; }
        public string Password;
        public string LoginType;
        public long CurrentRoleId { get; set; }

        public long LastTime = 0;

        public string TianQiValue = "1";

        public string NoticeVersion = string.Empty;
        public string NoticeText = string.Empty;

        public int SerialErrorTime = 0;

        public int IsPopUp = 0;
        public string PopUpInfo = string.Empty;
    }
}