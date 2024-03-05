using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    [FriendOf(typeof (BagComponentClient))]
    public static class BagClientNetHelper
    {
        public static async ETTask<int> RequestBagInit(Scene root)
        {
            Log.Debug($"C2M_BagInitHandler: client0");
            M2C_BagInitResponse response = (M2C_BagInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_BagInitRequest());

            BagComponentClient bagComponentClient = root.GetComponent<BagComponentClient>();
            for (int i = 0; i < response.BagInfos.Count; i++)
            {
                int Loc = response.BagInfos[i].Loc;
                List<BagInfo> bagList = bagComponentClient.AllItemList[Loc];
                bagList.Add(response.BagInfos[i]);
            }

            Log.Debug($"C2M_BagInitHandler: client1");
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestSellItem(Scene root, BagInfo bagInfo, string parinfo)
        {
            if (bagInfo.IsProtect)
            {
                return ErrorCode.ERR_Error;
            }

            C2M_ItemOperateRequest request = new() { OperateType = 2, OperateBagID = bagInfo.BagInfoID, OperatePar = $"{bagInfo.ItemID}_{parinfo}" };
            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestUseItem(Scene root, BagInfo bagInfo, string parinfo)
        {
            UserInfoComponentClient infoComponent = root.GetComponent<UserInfoComponentClient>();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int occ = infoComponent.UserInfo.Occ;
            if (itemConfig.UseOcc != 0 && itemConfig.UseOcc != occ)
            {
                return ErrorCode.ERR_ItemOnlyUseOcc;
            }

            C2M_ItemOperateRequest request = new() { OperateType = 1, OperateBagID = bagInfo.BagInfoID, OperatePar = parinfo };
            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            // if (itemConfig.ItemSubType == 2)
            // {
            //     flyTipComponent.SpawnFlyTip($"恭喜你获得{itemConfig.ItemUsePar}经验!");
            // }
            //
            // if (itemConfig.ItemSubType == 16)
            // {
            //     EquipMakeConfig equipMake = EquipMakeConfigCategory.Instance.Get(int.Parse(itemConfig.ItemUsePar));
            //     flyTipComponent.SpawnFlyTip($"恭喜你学习 {ItemConfigCategory.Instance.Get(equipMake.MakeItemID).ItemName}!");
            //     infoComponent.UserInfo.MakeList.Add(int.Parse(itemConfig.ItemUsePar));
            // }
            //
            // if (itemConfig.ItemSubType == 112)
            // {
            //     flyTipComponent.SpawnFlyTip($"恭喜你获得{response.OperatePar}经验!");
            // }

            // if (itemConfig.ItemSubType == 115)
            // {
            //     self.ZoneScene().GetComponent<PetComponent>().OnUnlockSkin(itemConfig.ItemUsePar);
            // }
            //
            // if (itemConfig.ItemSubType == 125)
            // {
            //     self.ZoneScene().GetComponent<UserInfoComponent>().OnHorseActive(int.Parse(itemConfig.ItemUsePar), true);
            // }
            //
            // if (itemConfig.ItemSubType == 128)
            // {
            //     self.ZoneScene().GetComponent<TitleComponent>().OnActiveTile(int.Parse(itemConfig.ItemUsePar));
            // }
            //
            // if (itemConfig.ItemSubType == 129)
            // {
            //     self.ZoneScene().GetComponent<ChengJiuComponent>().OnActiveJingLing(int.Parse(itemConfig.ItemUsePar));
            // }
            //
            // if (itemConfig.ItemSubType == 139)
            // {
            //     self.AdditionalCellNum[0]++;
            //     HintHelp.GetInstance().DataUpdate(DataType.BagItemUpdate);
            // }
            //
            // if (itemConfig.ItemSubType == 140)
            // {
            //     self.AdditionalCellNum[5]++;
            //     self.AdditionalCellNum[6]++;
            //     self.AdditionalCellNum[7]++;
            //     self.AdditionalCellNum[8]++;
            //     HintHelp.GetInstance().DataUpdate(DataType.BagItemUpdate);
            // }

            if (itemConfig.DayUseNum > 0)
            {
                infoComponent.OnDayItemUse(itemConfig.Id);
            }

            return response.Error;
        }

        public static async ETTask RequestWearEquip(Scene root, BagInfo bagInfo)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            // if (self.GetEquipByItemId(bagInfo.ItemID)!=null && itemCof.ItemSubType == 5)
            // {
            //     HintHelp.GetInstance().ShowHint("已佩戴该装备！");
            //     return;
            // }
            // if (itemCof.ItemType == 4)
            // {
            //     HintHelp.GetInstance().ShowHint("请到装备界面穿戴宝石！");
            //     return;
            // }

            //猎人单独处理
            int occ = root.GetComponent<UserInfoComponentClient>().UserInfo.Occ;
            if (occ == 3 && itemCof.ItemSubType == (int)ItemSubTypeEnum.Wuqi)
            {
                C2M_ItemOperateWearRequest c2M_ItemOperate = new C2M_ItemOperateWearRequest() { OperateType = 3, OperateBagID = bagInfo.BagInfoID };
                M2C_ItemOperateWearResponse m2C_ItemOperate =
                        (M2C_ItemOperateWearResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2M_ItemOperate);
            }
            else
            {
                C2M_ItemOperateRequest m_ItemOperateWear = new C2M_ItemOperateRequest() { OperateType = 3, OperateBagID = bagInfo.BagInfoID };
                M2C_ItemOperateResponse r2c_roleEquip =
                        (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(m_ItemOperateWear);
            }

            string ItemModelID = "";
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemSubType == (int)ItemSubTypeEnum.Wuqi)
            {
                ItemModelID = itemConfig.ItemModelID;
            }

            // self.ZoneScene().GetComponent<AttackComponent>().UpdateComboTime();
            // HintHelp.GetInstance().DataUpdate(DataType.EquipWear, ItemModelID);
        }

        public static async ETTask RequestTakeoffEquip(Scene root, BagInfo bagInfo)
        {
            //猎人单独处理
            int occ = root.GetComponent<UserInfoComponentClient>().UserInfo.Occ;
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (occ == 3 && itemCof.ItemSubType == (int)ItemSubTypeEnum.Wuqi)
            {
                C2M_ItemOperateWearRequest c2M_ItemOperate = new C2M_ItemOperateWearRequest() { OperateType = 4, OperateBagID = bagInfo.BagInfoID };
                M2C_ItemOperateWearResponse m2C_ItemOperate =
                        (M2C_ItemOperateWearResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2M_ItemOperate);
            }
            else
            {
                C2M_ItemOperateRequest m_ItemOperateWear = new C2M_ItemOperateRequest() { OperateType = 4, OperateBagID = bagInfo.BagInfoID };
                M2C_ItemOperateResponse r2c_roleEquip =
                        (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(m_ItemOperateWear);
                if (r2c_roleEquip.Error != 0)
                {
                    return;
                }
            }

            // self.ZoneScene().GetComponent<AttackComponent>().UpdateComboTime();
            // HintHelp.GetInstance().DataUpdate(DataType.EquipWear);
        }
    }
}