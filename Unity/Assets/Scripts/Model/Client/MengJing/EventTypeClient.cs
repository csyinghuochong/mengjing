using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public struct ShowItemTips
    {
        public BagInfo BagInfo;
        public ItemOperateEnum ItemOperateEnum;
        public float3 InputPoint;
        public List<BagInfo> EquipList;
        public int Occ;
    }

    public struct BagItemUpdate
    {
    }

    public struct BagItemItemAdd
    {
    }

    public struct ShowFlyTip
    {
        public int Type;
        public string Str;
    }

    public struct TaskTypeItemClick
    {
        public TaskPro TaskPro;
    }

    public struct UserDataTypeUpdate_Gold
    {
    }

    public struct UserDataTypeUpdate_Diamond
    {
    }

    public struct DataUpdate_FriendChat
    {
    }

    public struct DataUpdate_OnRecvChat
    {
    }

    public struct DataUpdate_FriendUpdate
    {
    }

    public struct DataUpdate_TaskGet
    {
    }

    public struct DataUpdate_TaskGiveUp
    {
    }

    public struct DataUpdate_TaskTrace
    {
    }

    public struct DataUpdate_TaskComplete
    {
    }

    public struct DataUpdate_BeforeMove
    {
        public string DataParamString;
    }

    public struct DataUpdate_EquipWear
    {
    }

    public struct DataUpdate_HuiShouSelect
    {
        public string DataParamString;
    }

    public struct DataUpdate_EquipHuiShow
    {
    }

    public struct DataUpdate_UpdateRoleProper
    {
        
    }

    public struct TaskNpcDialog
    {
        public int NpcId;
        public int ErrorCode;
    }

    public struct RolePetAdd
    {
        public List<KeyValuePair> OldPetSkin;
        public RolePetInfo RolePetInfo;
    }
}