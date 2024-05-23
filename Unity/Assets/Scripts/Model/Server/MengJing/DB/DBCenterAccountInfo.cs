﻿using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET.Server
{
    public enum AccountType
    {
        General = 0,

        BlackList = 1,  //黑名单

        Delete = 2,
    }


    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBCenterAccountInfo : Entity, IAwake
    {
        //用户名
        public string Account { get; set; }

        //密码
        public string Password { get; set; }

        public PlayerInfo PlayerInfo { get; set; }

        public int AccountType; //账号类型

        public long CreateTime; //创建时间
    }
}
