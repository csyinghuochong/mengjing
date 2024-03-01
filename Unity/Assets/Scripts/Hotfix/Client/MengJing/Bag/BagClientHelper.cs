using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    [FriendOf(typeof (BagComponentClient))]
    public static class BagClientHelper
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

        public static async ETTask<int> RequestUseItem(Scene root, BagInfo bagInfo, string par)
        {
            UserInfoComponentClient infoComponent = root.GetComponent<UserInfoComponentClient>();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int occ = infoComponent.UserInfo.Occ;
            if (itemConfig.UseOcc != 0 && itemConfig.UseOcc != occ)
            {
                return ErrorCode.ERR_ItemOnlyUseOcc;
            }

            C2M_ItemOperateRequest request = new() { OperateType = 1, OperateBagID = bagInfo.BagInfoID, OperatePar = par };
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
    }
}