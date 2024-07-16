namespace ET.Server
{
    
    
    [FriendOf(typeof(DBCenterAccountInfo))]
    public static partial class DBCenterAccountInfoSystem
    {
        
        public static CreateRoleInfo GetRoleInfo(this DBCenterAccountInfo self, int zone, long unitid)
        {
            for (int i = 0; i < self.RoleList.Count; i++)
            {
                if (self.RoleList[i].UnitId == unitid && zone ==self.RoleList[i].ServerId )
                {
                    return self.RoleList[i];
                }
            }

            return null;
        }
    }
}