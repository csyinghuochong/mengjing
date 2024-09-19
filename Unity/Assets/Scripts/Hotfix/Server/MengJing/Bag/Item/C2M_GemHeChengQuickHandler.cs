using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentS))]
    [FriendOf(typeof(UserInfoComponentS))]
    public class C2M_GemHeChengQuickHandler: MessageLocationHandler<Unit, C2M_GemHeChengQuickRequest, M2C_GemHeChengQuickResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemHeChengQuickRequest request, M2C_GemHeChengQuickResponse response)
        {
            // request加个仓库。  0是ItemLocType.BagItemList     19ItemLocType.GemWareHouse1
            if (request.LocType != 0 && request.LocType != 19)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            int leftCell = unit.GetComponent<BagComponentS>().GetBagLeftCell(request.LocType);

            List<ItemInfo> bagItemList = unit.GetComponent<BagComponentS>().GetItemByLoc(request.LocType);

            List<ItemInfo> gemList = new List<ItemInfo>();
            for (int i = 0; i < bagItemList.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagItemList[i].ItemID);
                if (itemConfig.ItemType != ItemTypeEnum.Gemstone)
                {
                    continue;
                }

                if (!EquipMakeConfigCategory.Instance.GetHeChengList.ContainsKey(itemConfig.Id))
                {
                    continue;
                }
                gemList.Add(bagItemList[i]);
            }

            Dictionary<int, int> addIds = new Dictionary<int, int>();
            Dictionary<int, int> removeids = new Dictionary<int, int>();
            long costgold = 0;
            long costvitality = 0;
            for (int i = gemList.Count - 1; i >= 0; i--)
            {
                KeyValuePairInt keyValuePair = EquipMakeConfigCategory.Instance.GetHeChengList[gemList[i].ItemID];
                int neednumber = (int)keyValuePair.Value;
                int newmakeid = keyValuePair.KeyId;
                int newnumber = gemList[i].ItemNum / neednumber;
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(newmakeid);
                costgold += (equipMakeConfig.MakeNeedGold * newnumber);
                costvitality += (equipMakeConfig.CostVitality * newnumber);

                //新增宝石
                if (!addIds.ContainsKey(equipMakeConfig.MakeItemID))
                {
                    addIds.Add(equipMakeConfig.MakeItemID, 0);
                }
                addIds[equipMakeConfig.MakeItemID] += newnumber;

                //更新旧的
                if (!removeids.ContainsKey(gemList[i].ItemID))
                {
                    removeids.Add(gemList[i].ItemID, 0);
                }
                removeids[gemList[i].ItemID] += (neednumber * newnumber);
            }

            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            if (userInfo.Gold < costgold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }
            if (userInfo.Vitality < costvitality)
            {
                response.Error = ErrorCode.ERR_VitalityNotEnoughError;
                return;
            }

            string removeItems = string.Empty;
            foreach ((int itemid, int number) in removeids)
            {
                if (number == 0)
                {
                    continue;
                }

                if (removeItems != string.Empty)
                {
                    removeItems += "@";
                }

                removeItems += $"{itemid};{number}";
            }
            if (removeItems != string.Empty)
            {
                unit.GetComponent<BagComponentS>().OnCostItemData(removeItems, request.LocType);
            }

            List<RewardItem> rewardItems = new List<RewardItem>();
            foreach ((int itemid, int number) in addIds)
            {
                if (number == 0)
                {
                    continue;
                }

                rewardItems.Add(new RewardItem() { ItemID = itemid, ItemNum = number });
            }
            
            int needCell = unit.GetComponent<BagComponentS>().GetNeedCell(rewardItems,request.LocType);
            if (needCell < 1)
            {
                needCell = 1;
            }
            if (leftCell < needCell)
            {
                response.Error = request.LocType == 0 ? ErrorCode.ERR_BagIsFull :  ErrorCode.ERR_WarehouseIsFull;
                return;
            }
            
            unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.GemHeCheng}_{TimeHelper.ServerNow()}",
                UseLocType: request.LocType);

            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, (costgold * -1).ToString(), true, ItemGetWay.SkillMake);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Vitality, (costvitality * -1).ToString());
            await ETTask.CompletedTask;
        }
    }
    
}