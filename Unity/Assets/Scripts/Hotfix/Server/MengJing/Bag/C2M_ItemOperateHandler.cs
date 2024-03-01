namespace ET.Server
{
    [FriendOf(typeof (UserInfoComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOperateHandler: MessageLocationHandler<Unit, C2M_ItemOperateRequest, M2C_ItemOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateRequest request, M2C_ItemOperateResponse response)
        {
            UserInfoComponentServer userInfoComponentServer = unit.GetComponent<UserInfoComponentServer>();
            UserInfo userInfo = userInfoComponentServer.UserInfo;
            BagComponentServer bagComponentServer = unit.GetComponent<BagComponentServer>();
            long bagInfoID = request.OperateBagID;

            ItemLocType locType = ItemLocType.ItemLocBag;
            if (request.OperateType == 2)
            {
                ItemConfig config = ItemConfigCategory.Instance.Get(int.Parse(request.OperatePar.Split('_')[0]));
                locType = config.ItemType == (int)ItemTypeEnum.PetHeXin? ItemLocType.ItemPetHeXinBag : locType;
            }

            if (request.OperateType == 4)
            {
                locType = ItemLocType.ItemLocEquip;
            }

            if (request.OperateType == 7)
            {
                locType = (ItemLocType)(int.Parse(request.OperatePar));
            }

            int weizhi = -1;
            ItemConfig itemConfig = null;
            BagInfo useBagInfo = bagComponentServer.GetItemByLoc(locType, bagInfoID);
            if (useBagInfo == null && request.OperateType != 8)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            if (useBagInfo != null)
            {
                itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);
                weizhi = itemConfig.ItemSubType;
            }

            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();

            // 使用道具
            if (request.OperateType == 1 && itemConfig != null)
            {
                int costNumber = 1;
                bagComponentServer.OnCostItemData(useBagInfo, ItemLocType.ItemLocBag, costNumber);
                if (useBagInfo.ItemNum <= 0)
                {
                    m2c_bagUpdate.BagInfoDelete.Add(useBagInfo);
                }
                else
                {
                    m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo);
                }
            }

            // 出售道具
            if (request.OperateType == 2 && locType == ItemLocType.ItemLocBag)
            {
                string[] sellinfo = request.OperatePar.Split('_');
                if (sellinfo.Length < 2)
                {
                    response.Error = ErrorCode.ERR_VersionNoMatch;
                    return;
                }

                if (ComHelp.IfNull(sellinfo[1]))
                {
                    response.Error = ErrorCode.ERR_VersionNoMatch;
                    return;
                }

                int sellNum = int.Parse(sellinfo[1]);
                if (sellNum <= 0 || sellNum > useBagInfo.ItemNum)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                string[] gemids = useBagInfo.GemIDNew.Split('_');
                ItemConfig itemConf = null;
                for (int i = 0; i < gemids.Length; i++)
                {
                    if (gemids[i] == "0")
                    {
                        continue;
                    }

                    itemConf = ItemConfigCategory.Instance.Get(int.Parse(gemids[i]));
                    userInfoComponentServer.UpdateRoleData((int)itemConf.SellMoneyType, (itemConf.SellMoneyValue).ToString());
                }

                //珍宝属性价格提升
                int sellValue = itemConfig.SellMoneyValue;
                if (useBagInfo.HideSkillLists.Contains(68000102))
                {
                    sellValue = itemConfig.SellMoneyValue * 20;
                }

                itemConf = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);
                userInfoComponentServer.UpdateRoleMoneyAdd((int)itemConf.SellMoneyType, (sellNum * sellValue).ToString(), true, ItemGetWay.Sell);
                bagComponentServer.OnCostItemData(useBagInfo, locType, sellNum);
                if (useBagInfo.ItemNum <= 0)
                {
                    m2c_bagUpdate.BagInfoDelete.Add(useBagInfo);
                }
                else
                {
                    m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo);
                }
            }

            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}