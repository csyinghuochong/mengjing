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

    public struct DlgMJLobby_UpdateSelect
    {
        public CreateRoleInfo CreateRoleInfo;
    }

    public struct ES_RoleBag_UpdateSelect
    {
        public BagInfo BagInfo;
    }
}