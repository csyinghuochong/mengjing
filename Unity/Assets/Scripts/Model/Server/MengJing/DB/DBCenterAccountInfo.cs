using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    public enum AccountType
    {
        Normal = 0,
        BlackList = 1,  //黑名单
    }

    public enum RoleInfoState
    {
        Normal = 0,
        Freeze = 1,    //冻结
    }

    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBCenterAccountInfo : Entity, IAwake
    {
        //用户名
        public string Account { get; set; }

        //密码
        public string Password { get; set; }

        //UserList列表
        public List<CreateRoleInfo> RoleList  { get; set; }= new List<CreateRoleInfo>();

        public PlayerInfo PlayerInfo { get; set; }

        public int AccountType{ get; set; } //账号类型

        
        public long CreateTime { get; set; } //创建时间
        
    }
}
