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
}