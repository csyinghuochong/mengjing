using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentC))]
    [FriendOf(typeof (BagComponentC))]
    public static class BagClientNetHelper
    {
        public static async ETTask<int> RequestBagInit(Scene root)
        {
            Log.Debug($"C2M_BagInitHandler: client0");
            M2C_BagInitResponse response = (M2C_BagInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_BagInitRequest());

            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            for (int i = 0; i < response.BagInfos.Count; i++)
            {
                int Loc = response.BagInfos[i].Loc;
                List<BagInfo> bagList = bagComponentC.AllItemList[Loc];
                bagList.Add(response.BagInfos[i]);
            }

            bagComponentC.QiangHuaLevel = response.QiangHuaLevel;
            bagComponentC.QiangHuaFails = response.QiangHuaFails;
            bagComponentC.WarehouseAddedCell = response.WarehouseAddedCell;
            bagComponentC.FashionActiveIds = response.FashionActiveIds;
            bagComponentC.FashionEquipList = response.FashionEquipList;
            bagComponentC.SeasonJingHePlan = response.SeasonJingHePlan;
            bagComponentC.AdditionalCellNum = response.AdditionalCellNum;

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
            UserInfoComponentC infoComponent = root.GetComponent<UserInfoComponentC>();

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
            int occ = root.GetComponent<UserInfoComponentC>().UserInfo.Occ;
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
            EventSystem.Instance.Publish(root, new DataUpdate_EquipWear());
        }

        public static async ETTask RequestTakeoffEquip(Scene root, BagInfo bagInfo)
        {
            //猎人单独处理
            int occ = root.GetComponent<UserInfoComponentC>().UserInfo.Occ;
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
            EventSystem.Instance.Publish(root, new DataUpdate_EquipWear());
        }

        public static async ETTask<int> RequestSplitItem(Scene root, BagInfo bagInfo, int splitnumber)
        {
            C2M_ItemSplitRequest request = new() { OperateBagID = bagInfo.BagInfoID, OperatePar = splitnumber.ToString() };
            M2C_ItemSplitResponse response = (M2C_ItemSplitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestSortByLoc(Scene root, ItemLocType loc)
        {
            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            bagComponentC.RealAddItem = false;
            int loctype = (int)loc;
            C2M_ItemOperateRequest request = new() { OperateType = 8, OperateBagID = 0, OperatePar = loctype.ToString() };
            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            bagComponentC.RealAddItem = true;
            bagComponentC.OnRecvItemSort(loc);

            return response.Error;
        }

        public static async ETTask<int> RequestAppraisalItem(Scene root, BagInfo bagInfo, long appID = 0)
        {
            C2M_ItemOperateRequest request = new() { OperateType = 5, OperateBagID = bagInfo.BagInfoID, OperatePar = appID.ToString() };
            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestHuiShou(Scene root, List<long> huishouList)
        {
            C2M_ItemHuiShouRequest request = new() { OperateBagID = huishouList };
            M2C_ItemHuiShouResponse response = (M2C_ItemHuiShouResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            EventSystem.Instance.Publish(root, new DataUpdate_EquipHuiShow());
            return response.Error;
        }

        public static async ETTask<int> RequestXiangQianGem(Scene root, BagInfo bagInfo, string par = "")
        {
            C2M_ItemOperateGemRequest request = new() { OperateType = 9, OperateBagID = bagInfo.BagInfoID, OperatePar = par };
            M2C_ItemOperateGemResponse response = (M2C_ItemOperateGemResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestXieXiaGem(Scene root, BagInfo bagInfo, string par = "")
        {
            C2M_ItemOperateGemRequest request = new() { OperateType = 10, OperateBagID = bagInfo.BagInfoID, OperatePar = par };
            M2C_ItemOperateGemResponse response = (M2C_ItemOperateGemResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<(int, int)> RequestItemQiangHua(Scene root, int itemSubType)
        {
            C2M_ItemQiangHuaRequest request = new() { WeiZhi = itemSubType };
            M2C_ItemQiangHuaResponse response = (M2C_ItemQiangHuaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return (response.Error, response.QiangHuaLevel);
        }

        public static async ETTask<int> RequestBuyBagCell(Scene root, int itemlocktype)
        {
            C2M_ItemBuyCellRequest request = new() { OperateType = itemlocktype };
            M2C_ItemBuyCellResponse response = (M2C_ItemBuyCellResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestOneSell(Scene root, ItemLocType itemLocType)
        {
            List<long> baginfoids = new List<long>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            List<BagInfo> bagInfos = bagComponent.GetItemsByLoc(itemLocType);

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.OneSellSet);
            string[] setvalues = value.Split('@'); //绿色 蓝色 宝石 材料

            for (int i = 0; i < bagInfos.Count; i++)
            {
                //锁定装备不能一键出售
                if (bagInfos[i].IsProtect)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);

                if (itemConfig.ItemType == ItemTypeEnum.Gemstone)
                {
                    if (setvalues[2] == "1" && itemConfig.ItemQuality <= 3)
                    {
                        baginfoids.Add(bagInfos[i].BagInfoID);
                        continue;
                    }
                }

                if (itemConfig.ItemType == ItemTypeEnum.Equipment)
                {
                    if (setvalues[0] == "1" && itemConfig.ItemQuality <= 2)
                    {
                        // 绿色品质的生肖不出售
                        if (itemConfig.EquipType == 101)
                        {
                            continue;
                        }

                        baginfoids.Add(bagInfos[i].BagInfoID);
                        continue;
                    }

                    if (setvalues[1] == "1" && itemConfig.ItemQuality <= 3)
                    {
                        // 蓝色品质的生肖不出售
                        if (itemConfig.EquipType == 101)
                        {
                            continue;
                        }

                        baginfoids.Add(bagInfos[i].BagInfoID);
                        continue;
                    }
                }

                if (itemConfig.ItemType == ItemTypeEnum.Material)
                {
                    if (setvalues.Length > 3 && setvalues[3] == "1" && ConfigData.OneSellMaterialList.Contains(bagInfos[i].ItemID))
                    {
                        baginfoids.Add(bagInfos[i].BagInfoID);
                        continue;
                    }
                }
            }

            C2M_ItemOneSellRequest request = new() { BagInfoIds = baginfoids, OperateType = (int)itemLocType };
            M2C_ItemOneSellResponse response = (M2C_ItemOneSellResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestGemHeCheng(Scene root, int locType)
        {
            C2M_GemHeChengQuickRequest request = new() { LocType = locType };
            M2C_GemHeChengQuickResponse response =
                    (M2C_GemHeChengQuickResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestPutStoreHouse(Scene root, BagInfo bagInfo)
        {
            int houseId = root.GetComponent<BagComponentC>().CurrentHouse;
            C2M_ItemOperateRequest request = new() { OperateType = 6, OperateBagID = bagInfo.BagInfoID, OperatePar = houseId.ToString() };
            M2C_ItemOperateResponse response =
                    (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            CheckSameId(root);
            return response.Error;
        }

        public static async ETTask<int> RquestPutBag(Scene root, BagInfo bagInfo)
        {
            C2M_ItemOperateRequest request = new() { OperateType = 7, OperateBagID = bagInfo.BagInfoID, OperatePar = bagInfo.Loc.ToString() };
            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            CheckSameId(root);
            return response.Error;
        }

        public static void CheckSameId(Scene root)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            List<long> idlist = new List<long>();

            for (int i = 0; i < bagComponent.AllItemList.Length; i++)
            {
                List<BagInfo> baglist = bagComponent.AllItemList[i];
                for (int k = 0; k < baglist.Count; k++)
                {
                    if (idlist.Contains(baglist[k].BagInfoID))
                    {
                        // EventType.ReturnLogin.Instance.ZoneScene = self.DomainScene();
                        // EventType.ReturnLogin.Instance.ErrorCode = ErrorCode.ERR_ModifyData;
                        // Game.EventSystem.PublishClass(EventType.ReturnLogin.Instance);
                        return;
                    }

                    idlist.Add(baglist[k].BagInfoID);
                }
            }
        }

        public static async ETTask<int> RquestQuickPut(Scene root, int hourseId)
        {
            C2M_ItemQuickPutRequest request = new() { HorseId = hourseId };
            M2C_ItemQuickPutResponse response =
                    (M2C_ItemQuickPutResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestAccountWarehousOperate(Scene root, int operateType, long operateId)
        {
            C2M_AccountWarehousOperateRequest request = new() { OperatateType = operateType, OperateBagID = operateId };
            M2C_AccountWarehousOperateResponse response =
                    (M2C_AccountWarehousOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == ErrorCode.ERR_Success)
            {
                EventSystem.Instance.Publish(root,
                    new DataUpdate_OnAccountWarehous() { DataParamString = operateType.ToString(), baginfoId = operateId });
            }

            return response.Error;
        }

        public static async ETTask<int> RequestAccountWarehousInfo(Scene root)
        {
            long accountId = root.GetComponent<PlayerComponent>().AccountId;
            C2E_AccountWarehousInfoRequest reuqest = new() { AccInfoID = accountId };
            E2C_AccountWarehousInfoResponse response =
                    (E2C_AccountWarehousInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            return response.Error;
        }

        public static async ETTask<int> RquestOpenCangKu(Scene root)
        {
            C2M_RoleOpenCangKuRequest request = new();
            M2C_RoleOpenCangKuResponse response =
                    (M2C_RoleOpenCangKuResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_ItemXiLianResponse> RquestItemXiLian(Scene root, long bagInfoID, int times)
        {
            C2M_ItemXiLianRequest request = new() { OperateBagID = bagInfoID, Times = times };
            M2C_ItemXiLianResponse response = (M2C_ItemXiLianResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RquestItemXiLianSelect(Scene root, long bagInfoID, ItemXiLianResult itemXiLianResult)
        {
            C2M_ItemXiLianSelectRequest request = new() { OperateBagID = bagInfoID, ItemXiLianResult = itemXiLianResult };
            M2C_ItemXiLianSelectResponse response =
                    (M2C_ItemXiLianSelectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestItemXiLianNumReward(Scene root, int rewardId)
        {
            C2M_ItemXiLianNumReward request = new() { RewardId = rewardId };
            M2C_ItemXiLianNumReward response =
                    (M2C_ItemXiLianNumReward)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestPetExploreReward(Scene root, int rewardId)
        {
            C2M_PetExploreReward request = new() { RewardId = rewardId };
            M2C_PetExploreReward response =
                    (M2C_PetExploreReward)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestItemXiLianReward(Scene root, int xiLianId)
        {
            C2M_ItemXiLianRewardRequest request = new() { XiLianId = xiLianId };
            M2C_ItemXiLianRewardResponse response =
                    (M2C_ItemXiLianRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask RquestStoreBuy(Scene root, int sellId, int buyNum)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(sellId);
            int needCell = ItemHelper.GetNeedCell($"{storeSellConfig.SellItemID};{storeSellConfig.SellItemNum * buyNum}");
            if (bagComponent.GetBagLeftCell() < needCell)
            {
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = "背包已经满" });
                return;
            }

            int costType = storeSellConfig.SellType;
            if (costType == 1 && userInfo.Gold < storeSellConfig.SellValue)
            {
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = "金币不足" });
                return;
            }

            if (costType == 3 && userInfo.Diamond < storeSellConfig.SellValue)
            {
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = "钻石不足" });
                return;
            }

            if (bagComponent.GetItemNumber(costType) < storeSellConfig.SellValue)
            {
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = "道具不足" });
                return;
            }

            C2M_StoreBuyRequest request = new() { SellItemID = sellId, SellItemNum = buyNum };
            M2C_StoreBuyResponse response = (M2C_StoreBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().OnStoreBuy(storeSellConfig.Id);
            }
        }

        public static async ETTask<int> RquestMysteryBuy(Scene root, MysteryItemInfo mysteryItemInfo, int npdId)
        {
            C2M_MysteryBuyRequest request = new() { MysteryItemInfo = mysteryItemInfo, NpcId = npdId };
            M2C_MysteryBuyResponse response =
                    (M2C_MysteryBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<A2C_MysteryListResponse> RquestMysteryList(Scene root, long userId)
        {
            C2A_MysteryListRequest request = C2A_MysteryListRequest.Create();
            request.UserId = userId;
            A2C_MysteryListResponse response = (A2C_MysteryListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<Actor_FubenMoNengResponse> RquestFubenMoNeng(Scene root)
        {
            Actor_FubenMoNengRequest request = new();
            Actor_FubenMoNengResponse response = (Actor_FubenMoNengResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RquestTakeOutAll(Scene root, int horseId)
        {
            C2M_TakeOutAllRequest request = new() { HorseId = horseId };
            M2C_TakeOutAllResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_TakeOutAllResponse;

            return response.Error;
        }

        public static async ETTask<int> RequestEquipMake(Scene root, long baginfoId, int makeId, int plan)
        {
            C2M_MakeEquipRequest request = new() { BagInfoID = baginfoId, MakeId = makeId, Plan = plan };
            M2C_MakeEquipResponse response = (M2C_MakeEquipResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.ItemId == 0)
            {
                HintHelp.ShowHint(root, "制作失败!");
            }

            if (response.NewMakeId != 0)
            {
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(response.NewMakeId);
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID);
                HintHelp.ShowHint(root, $"恭喜你领悟到新的制作技能 {itemConfig.ItemName}");
                root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Add(response.NewMakeId);
            }

            if (baginfoId == 0)
            {
                root.GetComponent<UserInfoComponentC>().OnMakeItem(makeId);
            }

            return response.Error;
        }

        public static async ETTask<M2C_ChouKaResponse> ChouKa(Scene root, int chapterId, int chouKaType)
        {
            C2M_ChouKaRequest request = new() { ChapterId = chapterId, ChouKaType = chouKaType };
            M2C_ChouKaResponse response = (M2C_ChouKaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemXiLianTransferResponse> ItemXiLianTransfer(Scene root, long operateBagID_1, long operateBagID_2)
        {
            C2M_ItemXiLianTransferRequest request = new() { OperateBagID_1 = operateBagID_1, OperateBagID_2 = operateBagID_2 };
            M2C_ItemXiLianTransferResponse response =
                    (M2C_ItemXiLianTransferResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ChouKaRewardResponse> ChouKaReward(Scene root, int rewardId)
        {
            C2M_ChouKaRewardRequest request = new() { RewardId = rewardId };
            M2C_ChouKaRewardResponse response =
                    (M2C_ChouKaRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.ChouKaRewardIds.Add(rewardId);
            }

            return response;
        }

        public static async ETTask<M2C_RoleAddPointResponse> RoleAddPoint(Scene root, List<int> pointList)
        {
            C2M_RoleAddPointRequest request = new() { PointList = pointList };
            M2C_RoleAddPointResponse response = (M2C_RoleAddPointResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemInheritResponse> ItemInherit(Scene root, long operateBagID)
        {
            C2M_ItemInheritRequest request = new() { OperateBagID = operateBagID };
            M2C_ItemInheritResponse response = (M2C_ItemInheritResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemInheritSelectResponse> ItemInheritSelect(Scene root, long operateBagID, List<int> inheritSkills)
        {
            C2M_ItemInheritSelectRequest request = new() { OperateBagID = operateBagID, InheritSkills = inheritSkills };
            M2C_ItemInheritSelectResponse response = (M2C_ItemInheritSelectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_PetTargetLockResponse> PetTargetLock(Scene root, long targetId)
        {
            C2M_PetTargetLockRequest request = new() { TargetId = targetId };
            M2C_PetTargetLockResponse response = (M2C_PetTargetLockResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemEquipIndexResponse> ItemEquipIndex(Scene root, int equipIndex)
        {
            C2M_ItemEquipIndexRequest request = new() { EquipIndex = equipIndex };
            M2C_ItemEquipIndexResponse response = (M2C_ItemEquipIndexResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JingLingDropResponse> JingLingDrop(Scene root)
        {
            C2M_JingLingDropRequest request = new();
            M2C_JingLingDropResponse response = (M2C_JingLingDropResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_HorseFightResponse> HorseFight(Scene root, int horseId)
        {
            C2M_HorseFightRequest request = new() { HorseId = horseId };
            M2C_HorseFightResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_HorseFightResponse;
            return response;
        }

        public static async ETTask<M2C_GameSettingResponse> GameSetting(Scene root, List<KeyValuePair> gameSettingInfos)
        {
            root.GetComponent<UserInfoComponentC>().UpdateGameSetting(gameSettingInfos);
            EventSystem.Instance.Publish(root, new DataUpdate_SettingUpdate());
            C2M_GameSettingRequest request = new() { GameSettingInfos = gameSettingInfos };
            M2C_GameSettingResponse response = (M2C_GameSettingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<Popularize2C_UploadResponse> Upload(Scene root, string memoryInfo)
        {
            C2Popularize_UploadRequest request = new() { MemoryInfo = memoryInfo };
            Popularize2C_UploadResponse response = (Popularize2C_UploadResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ModifyNameResponse> ModifyName(Scene root, string newName)
        {
            C2M_ModifyNameRequest request = new() { NewName = newName };
            M2C_ModifyNameResponse response = (M2C_ModifyNameResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
    }
}