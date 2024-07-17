using System.Collections.Generic;

namespace ET.Server
{
    //修改名字
    [MessageHandler(SceneType.Map)]
    public class C2M_ModifyNameHandler : MessageLocationHandler<Unit, C2M_ModifyNameRequest, M2C_ModifyNameResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ModifyNameRequest request, M2C_ModifyNameResponse response)
        {
            Log.Warning($"C2M_ModifyNameRequest:  {unit.Zone()} {unit.Id}");
            if (!StringHelper.IsSafeSqlString(request.NewName))
            {
                response.Error = ErrorCode.ERR_UnSafeSqlString;
                return;
            }
            
            if (string.IsNullOrEmpty(request.NewName))
            {
                response.Error = ErrorCode.ERR_CreateRoleName;
                response.Message = "角色名字过短!";
                return;
            }

            if (request.NewName.Contains(" "))
            {
                Log.Error($"C2M_ModifyNameRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            request.NewName = request.NewName.Trim();   

            if (request.NewName.Length >= 8)
            {
                response.Error = ErrorCode.ERR_CreateRoleName;
                response.Message = "角色名字过长!";
                return;
            }

            DBManagerComponent dbManagerComponent = unit.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(unit.Zone());
            List<UserInfoComponentS> result = await dbComponent.Query<UserInfoComponentS>(unit.Zone(), _account => _account.UserName == request.NewName);
            if (result.Count > 0)
            {
                response.Error = ErrorCode.ERR_RoleNameRepeat;
                return;
            }

            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(70);
            if (unit.GetComponent<BagComponentS>().OnCostItemData(globalValueConfig.Value))
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Name, request.NewName);
                M2C_RoleDataBroadcast m2C_BroadcastRoleData = M2C_RoleDataBroadcast.Create();
                m2C_BroadcastRoleData.UnitId = unit.Id;
                m2C_BroadcastRoleData.UpdateType = (int)UserDataType.Name;
                m2C_BroadcastRoleData.UpdateTypeValue = request.NewName;
                MapMessageHelper.Broadcast(unit, m2C_BroadcastRoleData);
            }
            else
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
