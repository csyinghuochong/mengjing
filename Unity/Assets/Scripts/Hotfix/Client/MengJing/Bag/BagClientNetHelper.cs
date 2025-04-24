using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(BagComponentC))]
    public static class BagClientNetHelper
    {
        public static async ETTask<int> RequestBagInit(Scene root)
        {
            M2C_BagInitResponse response = (M2C_BagInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_BagInitRequest.Create());

            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            for (int i = 0; i < response.BagInfos.Count; i++)
            {
                int Loc = response.BagInfos[i].Loc;

                ItemInfo itemInfo = bagComponentC.AddChild<ItemInfo>();
                itemInfo.FromMessage(response.BagInfos[i]);

                List<ItemInfo> bagList = bagComponentC.AllItemList[Loc];
                bagList.Add(itemInfo);
            }

            bagComponentC.QiangHuaLevel = response.QiangHuaLevel;
            bagComponentC.QiangHuaFails = response.QiangHuaFails;
            bagComponentC.BagBuyCellNumber = response.WarehouseAddedCell;
            bagComponentC.FashionActiveIds = response.FashionActiveIds;
            bagComponentC.FashionEquipList = response.FashionEquipList;
            bagComponentC.SeasonJingHePlan = response.SeasonJingHePlan;
            bagComponentC.BagAddCellNumber = response.AdditionalCellNum;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestSellItem(Scene root, ItemInfo bagInfo, string parinfo)
        {
            if (bagInfo.IsProtect)
            {
                return ErrorCode.ERR_Error;
            }

            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 2;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = $"{bagInfo.ItemID}_{parinfo}";

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_ItemOperateResponse> RequestUseItem(Scene root, ItemInfo bagInfo, string parinfo = "")
        {
            UserInfoComponentC infoComponent = root.GetComponent<UserInfoComponentC>();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int occ = infoComponent.UserInfo.Occ;
            if (itemConfig.UseOcc != 0 && itemConfig.UseOcc != occ)
            {
                M2C_ItemOperateResponse response_0 = M2C_ItemOperateResponse.Create();
                response_0.Error = ErrorCode.ERR_ItemOnlyUseOcc;
                return response_0;
            }

            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 1;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = parinfo;

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response;
            }

            if (itemConfig.ItemSubType == 2)
            {
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = $"恭喜你获得{itemConfig.ItemUsePar}经验!" });
            }
            
            if (itemConfig.ItemSubType == 16)
            {
                EquipMakeConfig equipMake = EquipMakeConfigCategory.Instance.Get(int.Parse(itemConfig.ItemUsePar));
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = $"恭喜你学习 {ItemConfigCategory.Instance.Get(equipMake.MakeItemID).ItemName}!" });
                infoComponent.UserInfo.MakeList.Add(int.Parse(itemConfig.ItemUsePar));
            }
            
            if (itemConfig.ItemSubType == 112)
            {
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = $"恭喜你获得{response.OperatePar}经验!" });
            }

            if (itemConfig.ItemSubType == 115)
            {
                root.GetComponent<PetComponentC>().OnUnlockSkin(itemConfig.ItemUsePar);
            }
            
            if (itemConfig.ItemSubType == 125)
            {
                root.GetComponent<UserInfoComponentC>().OnHorseActive(int.Parse(itemConfig.ItemUsePar), true);
            }
            
            if (itemConfig.ItemSubType == 128)
            {
                root.GetComponent<TitleComponentC>().OnActiveTile(int.Parse(itemConfig.ItemUsePar));
            }
            
            if (itemConfig.ItemSubType == 129)
            {
                root.GetComponent<ChengJiuComponentC>().OnActiveJingLing(int.Parse(itemConfig.ItemUsePar));
            }
            
            // if (itemConfig.ItemSubType == 139)
            // {
            //     
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

            return response;
        }

        public static async ETTask RequestWearEquip(Scene root, ItemInfo bagInfo)
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

            //猎人装备武器单独协议处理
            int occ = root.GetComponent<UserInfoComponentC>().UserInfo.Occ;
            if (occ == 3 && itemCof.ItemSubType == (int)ItemSubTypeEnum.Wuqi)
            {
                C2M_ItemOperateWearRequest request = C2M_ItemOperateWearRequest.Create();
                request.OperateType = 3;
                request.OperateBagID = bagInfo.BagInfoID;

                M2C_ItemOperateWearResponse response = (M2C_ItemOperateWearResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            }
            else
            {
                C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
                request.OperateType = 3;
                request.OperateBagID = bagInfo.BagInfoID;

                M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            }

            string ItemModelID = "";
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemSubType == (int)ItemSubTypeEnum.Wuqi)
            {
                ItemModelID = itemConfig.ItemModelID;
            }

            // self.ZoneScene().GetComponent<AttackComponent>().UpdateComboTime();
            EventSystem.Instance.Publish(root, new EquipWear());
        }

        public static async ETTask RequestTakeoffEquip(Scene root, ItemInfo bagInfo)
        {
            //猎人单独处理
            int occ = root.GetComponent<UserInfoComponentC>().UserInfo.Occ;
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (occ == 3 && itemCof.ItemSubType == (int)ItemSubTypeEnum.Wuqi)
            {
                C2M_ItemOperateWearRequest request = C2M_ItemOperateWearRequest.Create();
                request.OperateType = 4;
                request.OperateBagID = bagInfo.BagInfoID;

                M2C_ItemOperateWearResponse response = (M2C_ItemOperateWearResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            }
            else
            {
                C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
                request.OperateType = 4;
                request.OperateBagID = bagInfo.BagInfoID;

                M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
                if (response.Error != 0)
                {
                    return;
                }
            }

            root.GetComponent<AttackComponent>().UpdateComboTime();

            EventSystem.Instance.Publish(root, new EquipWear());
        }

        public static async ETTask<int> RequestSplitItem(Scene root, ItemInfo bagInfo, int splitnumber)
        {
            C2M_ItemSplitRequest request = C2M_ItemSplitRequest.Create();
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = splitnumber.ToString();

            M2C_ItemSplitResponse response = (M2C_ItemSplitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestSortByLoc(Scene root, int loc)
        {
            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            bagComponentC.RealAddItem--;
            int loctype = (int)loc;

            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 8;
            request.OperateBagID = 0;
            request.OperatePar = loctype.ToString();

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            bagComponentC.RealAddItem++;
            bagComponentC.OnRecvItemSort(loc);

            return response.Error;
        }

        // 鉴定
        public static async ETTask<int> RequestAppraisalItem(Scene root, ItemInfo bagInfo, long appID = 0)
        {
            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 5;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = appID.ToString();

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestHuiShou(Scene root, List<long> huishouList)
        {
            C2M_ItemHuiShouRequest request = C2M_ItemHuiShouRequest.Create();
            request.OperateBagID = huishouList;

            M2C_ItemHuiShouResponse response = (M2C_ItemHuiShouResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            EventSystem.Instance.Publish(root, new EquipHuiShow());
            return response.Error;
        }

        public static async ETTask<int> RequestXiangQianGem(Scene root, ItemInfo bagInfo, string par = "")
        {
            C2M_ItemOperateGemRequest request = C2M_ItemOperateGemRequest.Create();
            request.OperateType = 9;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = par;

            M2C_ItemOperateGemResponse response = (M2C_ItemOperateGemResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                EventSystem.Instance.Publish(root, new ItemOperateGem());
            }

            return response.Error;
        }

        public static async ETTask<int> RequestXieXiaGem(Scene root, ItemInfo bagInfo, string par = "")
        {
            C2M_ItemOperateGemRequest request = C2M_ItemOperateGemRequest.Create();
            request.OperateType = 10;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = par;

            M2C_ItemOperateGemResponse response = (M2C_ItemOperateGemResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                EventSystem.Instance.Publish(root, new ItemOperateGem());
            }
            
            return response.Error;
        }

        public static async ETTask<(int, int)> RequestItemQiangHua(Scene root, int itemSubType, bool useLucky)
        {
            C2M_ItemQiangHuaRequest request = C2M_ItemQiangHuaRequest.Create();
            request.WeiZhi = itemSubType;
            request.UseLucky = useLucky;
            M2C_ItemQiangHuaResponse response = (M2C_ItemQiangHuaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return (response.Error, response.QiangHuaLevel);
        }

        public static async ETTask<int> RequestBuyBagCell(Scene root, int itemlocktype)
        {
            C2M_ItemBuyCellRequest request = C2M_ItemBuyCellRequest.Create();
            request.OperateType = itemlocktype;

            M2C_ItemBuyCellResponse response = (M2C_ItemBuyCellResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestOneSell(Scene root, int itemLocType)
        {
            List<long> baginfoids = new List<long>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponent.GetItemsByLoc(itemLocType);

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

            C2M_ItemOneSellRequest request = C2M_ItemOneSellRequest.Create();
            request.BagInfoIds = baginfoids;
            request.OperateType = (int)itemLocType;

            M2C_ItemOneSellResponse response = (M2C_ItemOneSellResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestOneSell2(Scene root, int itemLocType)
        {
            List<long> baginfoids = new List<long>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponent.GetItemsByLoc(itemLocType);

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            string[] set2Values = userInfoComponent.GetGameSettingValue(GameSettingEnum.OneSellSet2).Split('@'); // 低级、中级、高级
            if (set2Values.Length < 6)
            {
                Array.Resize(ref set2Values, set2Values.Length + 1);
                set2Values[set2Values.Length - 1] = "0";
            }

            for (int i = 0; i < bagInfos.Count; i++)
            {
                //锁定装备不能一键出售
                if (bagInfos[i].IsProtect)
                {
                    continue;
                }

                // 一键出售 低级、中级、高级、超级、神级、终级
                for (int j = 0; j < 6; j++)
                {
                    if (set2Values[j] == "1")
                    {
                        if (ConfigData.OneSellList[j].Contains(bagInfos[i].ItemID))
                        {
                            baginfoids.Add(bagInfos[i].BagInfoID);
                            break;
                        }
                    }
                }
            }

            C2M_ItemOneSellRequest request = C2M_ItemOneSellRequest.Create();
            request.BagInfoIds = baginfoids;
            request.OperateType = (int)itemLocType;

            M2C_ItemOneSellResponse response = (M2C_ItemOneSellResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RquestGemHeCheng(Scene root, int locType)
        {
            C2M_GemHeChengQuickRequest request = C2M_GemHeChengQuickRequest.Create();
            request.LocType = locType;

            M2C_GemHeChengQuickResponse response = (M2C_GemHeChengQuickResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestPutStoreHouse(Scene root, ItemInfo bagInfo, int houseId)
        {
            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 6;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = houseId.ToString();

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            CheckSameId(root);
            return response.Error;
        }

        public static async ETTask<int> RquestPutBag(Scene root, ItemInfo bagInfo)
        {
            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 7;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = bagInfo.Loc.ToString();

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            CheckSameId(root);
            return response.Error;
        }

        public static void CheckSameId(Scene root)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            List<long> idlist = new List<long>();

            for (int i = 0; i < bagComponent.AllItemList.Count; i++)
            {
                List<ItemInfo> baglist = bagComponent.AllItemList[i];
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
            C2M_ItemQuickPutRequest request = C2M_ItemQuickPutRequest.Create();
            request.HorseId = hourseId;

            M2C_ItemQuickPutResponse response = (M2C_ItemQuickPutResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestAccountWarehousOperate(Scene root, int operateType, long operateId)
        {
            C2M_AccountWarehousOperateRequest request = C2M_AccountWarehousOperateRequest.Create();
            request.OperatateType = operateType;
            request.OperateBagID = operateId;

            M2C_AccountWarehousOperateResponse response =
                    (M2C_AccountWarehousOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == ErrorCode.ERR_Success)
            {
                EventSystem.Instance.Publish(root,
                    new OnAccountWarehous() { DataParamString = operateType.ToString(), baginfoId = operateId });
            }

            return response.Error;
        }

        public static async ETTask<E2C_AccountWarehousInfoResponse> RequestAccountWarehousInfo(Scene root)
        {
            long accountId = root.GetComponent<PlayerInfoComponent>().AccountId;
            C2E_AccountWarehousInfoRequest reuqest = C2E_AccountWarehousInfoRequest.Create();
            reuqest.AccInfoID = accountId;

            E2C_AccountWarehousInfoResponse response = (E2C_AccountWarehousInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            return response;
        }

        public static async ETTask<int> RquestOpenCangKu(Scene root)
        {
            C2M_RoleOpenCangKuRequest request = C2M_RoleOpenCangKuRequest.Create();
            M2C_RoleOpenCangKuResponse response = (M2C_RoleOpenCangKuResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_ItemXiLianResponse> RquestItemXiLian(Scene root, long bagInfoID, int times)
        {
            C2M_ItemXiLianRequest request = C2M_ItemXiLianRequest.Create();
            request.OperateBagID = bagInfoID;
            request.Times = times;

            M2C_ItemXiLianResponse response = (M2C_ItemXiLianResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RquestItemXiLianSelect(Scene root, long bagInfoID, ItemXiLianResult itemXiLianResult)
        {
            C2M_ItemXiLianSelectRequest request = C2M_ItemXiLianSelectRequest.Create();
            request.OperateBagID = bagInfoID;
            request.ItemXiLianResult = itemXiLianResult;

            M2C_ItemXiLianSelectResponse response = (M2C_ItemXiLianSelectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestItemXiLianNumReward(Scene root, int rewardId)
        {
            C2M_ItemXiLianNumReward request = C2M_ItemXiLianNumReward.Create();
            request.RewardId = rewardId;

            M2C_ItemXiLianNumReward response = (M2C_ItemXiLianNumReward)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestPetExploreReward(Scene root, int rewardId)
        {
            C2M_PetExploreReward request = C2M_PetExploreReward.Create();
            request.RewardId = rewardId;

            M2C_PetExploreReward response = (M2C_PetExploreReward)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RquestItemXiLianReward(Scene root, int xiLianId)
        {
            C2M_ItemXiLianRewardRequest request = C2M_ItemXiLianRewardRequest.Create();
            request.XiLianId = xiLianId;

            M2C_ItemXiLianRewardResponse response = (M2C_ItemXiLianRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask RquestStoreBuy(Scene root, int sellId, int buyNum)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(sellId);
            int needCell = ItemHelper.GetNeedCell($"{storeSellConfig.SellItemID};{storeSellConfig.SellItemNum * buyNum}");
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < needCell)
            {
                HintHelp.ShowHint(root, "背包已经满");
                return;
            }

            int costType = storeSellConfig.SellType;
            if (costType == 1 && userInfo.Gold < storeSellConfig.SellValue)
            {
                HintHelp.ShowHint(root, "金币不足");
                return;
            }

            if (costType == 3 && userInfo.Diamond < storeSellConfig.SellValue)
            {
                HintHelp.ShowHint(root, "钻石不足");
                return;
            }

            if (bagComponent.GetItemNumber(costType) < storeSellConfig.SellValue)
            {
                HintHelp.ShowHint(root, "道具不足");
                return;
            }

            C2M_StoreBuyRequest request = C2M_StoreBuyRequest.Create();
            request.SellItemID = sellId;
            request.SellItemNum = buyNum;

            M2C_StoreBuyResponse response = (M2C_StoreBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().OnStoreBuy(storeSellConfig.Id);
            }
        }

        public static async ETTask<int> RquestMysteryBuy(Scene root, MysteryItemInfo mysteryItemInfo, int npdId)
        {
            C2M_MysteryBuyRequest request = C2M_MysteryBuyRequest.Create();
            request.MysteryItemInfo = mysteryItemInfo;
            request.NpcId = npdId;

            M2C_MysteryBuyResponse response = (M2C_MysteryBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

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
            Actor_FubenMoNengRequest request = Actor_FubenMoNengRequest.Create();

            Actor_FubenMoNengResponse response = (Actor_FubenMoNengResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RquestTakeOutAll(Scene root, int horseId)
        {
            C2M_TakeOutAllRequest request = C2M_TakeOutAllRequest.Create();
            request.HorseId = horseId;

            M2C_TakeOutAllResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_TakeOutAllResponse;

            return response.Error;
        }

        public static async ETTask<int> RequestEquipMake(Scene root, long baginfoId, int makeId, int plan)
        {
            C2M_MakeEquipRequest request = C2M_MakeEquipRequest.Create();
            request.BagInfoID = baginfoId;
            request.MakeId = makeId;
            request.Plan = plan;

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
            C2M_ChouKaRequest request = C2M_ChouKaRequest.Create();
            request.ChapterId = chapterId;
            request.ChouKaType = chouKaType;

            M2C_ChouKaResponse response = (M2C_ChouKaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemXiLianTransferResponse> ItemXiLianTransfer(Scene root, long operateBagID_1, long operateBagID_2)
        {
            C2M_ItemXiLianTransferRequest request = C2M_ItemXiLianTransferRequest.Create();
            request.OperateBagID_1 = operateBagID_1;
            request.OperateBagID_2 = operateBagID_2;

            M2C_ItemXiLianTransferResponse response = (M2C_ItemXiLianTransferResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ChouKaRewardResponse> ChouKaReward(Scene root, int rewardId)
        {
            C2M_ChouKaRewardRequest request = C2M_ChouKaRewardRequest.Create();
            request.RewardId = rewardId;

            M2C_ChouKaRewardResponse response = (M2C_ChouKaRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.ChouKaRewardIds.Add(rewardId);
            }

            return response;
        }

        public static async ETTask<M2C_RoleAddPointResponse> RoleAddPoint(Scene root, List<int> pointList)
        {
            C2M_RoleAddPointRequest request = C2M_RoleAddPointRequest.Create();
            request.PointList = pointList;

            M2C_RoleAddPointResponse response = (M2C_RoleAddPointResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemInheritResponse> ItemInherit(Scene root, long operateBagID)
        {
            C2M_ItemInheritRequest request = C2M_ItemInheritRequest.Create();
            request.OperateBagID = operateBagID;

            M2C_ItemInheritResponse response = (M2C_ItemInheritResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemInheritSelectResponse> ItemInheritSelect(Scene root, long operateBagID, List<int> inheritSkills)
        {
            C2M_ItemInheritSelectRequest request = C2M_ItemInheritSelectRequest.Create();
            request.OperateBagID = operateBagID;
            request.InheritSkills = inheritSkills;

            M2C_ItemInheritSelectResponse response = (M2C_ItemInheritSelectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_PetTargetLockResponse> PetTargetLock(Scene root, long targetId)
        {
            C2M_PetTargetLockRequest request = C2M_PetTargetLockRequest.Create();
            request.TargetId = targetId;

            M2C_PetTargetLockResponse response = (M2C_PetTargetLockResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemEquipIndexResponse> ItemEquipIndex(Scene root, int equipIndex)
        {
            C2M_ItemEquipIndexRequest request = C2M_ItemEquipIndexRequest.Create();
            request.EquipIndex = equipIndex;

            M2C_ItemEquipIndexResponse response = (M2C_ItemEquipIndexResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JingLingDropResponse> JingLingDrop(Scene root)
        {
            C2M_JingLingDropRequest request = C2M_JingLingDropRequest.Create();

            M2C_JingLingDropResponse response = (M2C_JingLingDropResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_HorseFightResponse> HorseFight(Scene root, int horseId)
        {
            C2M_HorseFightRequest request = C2M_HorseFightRequest.Create();
            request.HorseId = horseId;

            M2C_HorseFightResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_HorseFightResponse;
            return response;
        }

        public static async ETTask<M2C_GameSettingResponse> GameSetting(Scene root, List<KeyValuePair> gameSettingInfos)
        {
            root.GetComponent<UserInfoComponentC>().UpdateGameSetting(gameSettingInfos);
            EventSystem.Instance.Publish(root, new SettingUpdate());

            C2M_GameSettingRequest request = C2M_GameSettingRequest.Create();
            request.GameSettingInfos = gameSettingInfos;

            M2C_GameSettingResponse response = (M2C_GameSettingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<Popularize2C_UploadResponse> Upload(Scene root, string memoryInfo)
        {
            C2Popularize_UploadRequest request = C2Popularize_UploadRequest.Create();
            request.MemoryInfo = memoryInfo;

            Popularize2C_UploadResponse response = (Popularize2C_UploadResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ModifyNameResponse> ModifyName(Scene root, string newName)
        {
            C2M_ModifyNameRequest request = C2M_ModifyNameRequest.Create();
            request.NewName = newName;

            M2C_ModifyNameResponse response = (M2C_ModifyNameResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_TitleUseResponse> TitleUse(Scene root, int titleId)
        {
            C2M_TitleUseRequest request = C2M_TitleUseRequest.Create();
            request.TitleId = titleId;

            M2C_TitleUseResponse response = (M2C_TitleUseResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_FashionActiveResponse> FashionActive(Scene root, int fashionId)
        {
            C2M_FashionActiveRequest request = C2M_FashionActiveRequest.Create();
            request.FashionId = fashionId;

            M2C_FashionActiveResponse response = (M2C_FashionActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_FashionWearResponse> FashionWear(Scene root, int fashionId, int operatateType)
        {
            C2M_FashionWearRequest request = C2M_FashionWearRequest.Create();
            request.FashionId = fashionId;
            request.OperatateType = operatateType;

            M2C_FashionWearResponse response = (M2C_FashionWearResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ItemProtectResponse> ItemProtect(Scene root, long operateBagID, bool isProtect)
        {
            C2M_ItemProtectRequest request = C2M_ItemProtectRequest.Create();
            request.OperateBagID = operateBagID;
            request.IsProtect = isProtect;

            M2C_ItemProtectResponse response = (M2C_ItemProtectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JingHePlanResponse> JingHePlan(Scene root, int jingHePlan)
        {
            C2M_JingHePlanRequest request = C2M_JingHePlanRequest.Create();
            request.JingHePlan = jingHePlan;

            M2C_JingHePlanResponse response = (M2C_JingHePlanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_SeasonOpenJingHeResponse> SeasonOpenJingHe(Scene root, int jingHeId)
        {
            C2M_SeasonOpenJingHeRequest request = C2M_SeasonOpenJingHeRequest.Create();
            request.JingHeId = jingHeId;

            M2C_SeasonOpenJingHeResponse response = (M2C_SeasonOpenJingHeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JingHeWearResponse> JingHeWear(Scene root, long operateBagID, int operateType, string operatePar)
        {
            C2M_JingHeWearRequest request = C2M_JingHeWearRequest.Create();
            request.OperateBagID = operateBagID;
            request.OperateType = operateType;
            request.OperatePar = operatePar;

            M2C_JingHeWearResponse response = (M2C_JingHeWearResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JingHeActivateResponse> JingHeActivate(Scene root, long bagInfoId)
        {
            C2M_JingHeActivateRequest request = C2M_JingHeActivateRequest.Create();
            request.BagInfoId = bagInfoId;

            M2C_JingHeActivateResponse response = (M2C_JingHeActivateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JingHeZhuruResponse> JingHeZhuru(Scene root, long bagInfoId, List<long> operateBagID)
        {
            C2M_JingHeZhuruRequest request = C2M_JingHeZhuruRequest.Create();
            request.BagInfoId = bagInfoId;
            request.OperateBagID = operateBagID;

            M2C_JingHeZhuruResponse response = (M2C_JingHeZhuruResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> SendFumoUse(Scene root, ItemInfo bagInfo, List<HideProList> hideProLists)
        {
            C2M_ItemFumoUseRequest request = C2M_ItemFumoUseRequest.Create();
            request.OperateBagID = bagInfo.BagInfoID;
            request.FuMoProList = hideProLists;

            M2C_ItemFumoUseResponse response = (M2C_ItemFumoUseResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> SendFumoPro(Scene root, int index)
        {
            C2M_ItemFumoProRequest request = C2M_ItemFumoProRequest.Create();
            request.Index = index;

            M2C_ItemFumoProResponse response = (M2C_ItemFumoProResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> SendEquipmentIncrease(Scene root, ItemInfo equipmentBagInfo, ItemInfo reelBagInfo)
        {
            C2M_EquipmentIncreaseRequest request = C2M_EquipmentIncreaseRequest.Create();
            request.EquipmentBagInfo = equipmentBagInfo.ToMessage();
            request.ReelBagInfo = reelBagInfo.ToMessage();

            M2C_EquipmentIncreaseResponse response = (M2C_EquipmentIncreaseResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> ItemIncreaseTransferRequest(Scene root, ItemInfo equipmentBagInfo, ItemInfo reelBagInfo)
        {
            C2M_ItemIncreaseTransferRequest request = C2M_ItemIncreaseTransferRequest.Create();
            request.OperateBagID_1 = equipmentBagInfo.BagInfoID;
            request.OperateBagID_2 = reelBagInfo.BagInfoID;

            M2C_ItemIncreaseTransferResponse response =
                    (M2C_ItemIncreaseTransferResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }
    }
}