using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetEquipHandler: MessageLocationHandler<Unit, C2M_PetEquipRequest, M2C_PetEquipResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetEquipRequest request, M2C_PetEquipResponse response)
        {
             PetComponentS petComponent = unit.GetComponent<PetComponentS>();
             BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
             RolePetInfo rolePetInfo = petComponent.GetPetInfo(request.PetInfoId);
             if (rolePetInfo == null)
             {
                 response.Error = ErrorCode.ERR_Pet_NoExist;
                 return;
             }

             //通知客户端背包刷新
             M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
             //通知客户端背包道具发生改变
             m2c_bagUpdate.BagInfoUpdate = new List<ItemInfoProto>();

             long takeOffId = 0;
             if (request.OperateType == 1) //穿戴
             {
                 ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoId);
                 if (bagInfo == null)
                 {
                     response.Error = ErrorCode.ERR_ItemNotExist;
                     return;
                 }

                 int itemSubType = ItemConfigCategory.Instance.Get(bagInfo.ItemID).ItemSubType;
                 for (int i = rolePetInfo.PetEquipList.Count - 1; i >= 0; i--)
                 { 
                     ItemInfo petequipInfo = bagComponent.GetItemByLoc(ItemLocType.PetLocEquip, rolePetInfo.PetEquipList[i]);
                     if (petequipInfo == null)
                     {
                         rolePetInfo.PetEquipList.RemoveAt(i);   
                     }
                     if(ItemConfigCategory.Instance.Get(petequipInfo.ItemID).ItemSubType == itemSubType)
                     {
                         takeOffId = rolePetInfo.PetEquipList[i];
                         break;
                     }
                 }
             }
             if (request.OperateType == 2)
             {
                 takeOffId = request.BagInfoId;
             }

             //先卸下
             if (takeOffId != 0)
             {
                 ItemInfo oldBagInfo = bagComponent.GetItemByLoc(ItemLocType.PetLocEquip, takeOffId);
                 if (oldBagInfo != null)
                 {
                     bagComponent.OnChangeItemLoc(oldBagInfo, ItemLocType.ItemLocBag, ItemLocType.PetLocEquip);
                     m2c_bagUpdate.BagInfoUpdate.Add(oldBagInfo.ToMessage());
                     rolePetInfo.PetEquipList.Remove(takeOffId);
                 }

                 petComponent.RemoveEquipSkill(rolePetInfo, oldBagInfo);
             }

             if (request.OperateType == 1) //穿戴
             {
                 ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoId);

                 //新的装备给宠物
                 bagComponent.OnChangeItemLoc(bagInfo, ItemLocType.PetLocEquip, ItemLocType.ItemLocBag);
                 m2c_bagUpdate.BagInfoUpdate.Add(bagInfo.ToMessage());
                 rolePetInfo.PetEquipList.Add(request.BagInfoId);
             }
             petComponent.UpdatePetAttribute(rolePetInfo, false);
             MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
             response.RolePetInfo = rolePetInfo;

            await ETTask.CompletedTask;
        }
    }
}

