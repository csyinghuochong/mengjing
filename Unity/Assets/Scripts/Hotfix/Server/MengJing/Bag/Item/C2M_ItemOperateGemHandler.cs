using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOperateGemHandler: MessageLocationHandler<Unit, C2M_ItemOperateGemRequest, M2C_ItemOperateGemResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateGemRequest request, M2C_ItemOperateGemResponse response)
        {
            long bagInfoID = request.OperateBagID;
            ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocEquip, bagInfoID);
            }
            if (useBagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemUseError;
                return;
            }

            // 通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            //通知客户端背包道具发生改变
            m2c_bagUpdate.BagInfoUpdate = new List<ItemInfoProto>();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

            //镶嵌宝石
            if (request.OperateType == 9)
            {
                //宝石镶嵌
                string[] geminfos = request.OperatePar.Split('_');
                long equipid = long.Parse(geminfos[0]);
                int gemIndex = int.Parse(geminfos[1]);

                ItemInfo equipInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocEquip, equipid);

                //获取装备baginfo
                if (equipInfo == null)
                {
                    equipInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, equipid);
                }
                if (equipInfo == null)
                {
                    Log.Warning($"equipInfo == null {equipid}");
                    return;
                }

                //判断孔位是否相符
                string[] equipGeminfos = equipInfo.GemHole.Split('_');

                if (equipGeminfos[gemIndex] != itemConfig.ItemSubType.ToString() && itemConfig.ItemSubType != 110 && itemConfig.ItemSubType != 111)
                {
                    response.Error = ErrorCode.ERR_ItemUseError;
                    return;
                }

                //史诗宝石最多镶嵌4个
                if (itemConfig.ItemSubType == 110)
                {
                    int equipShiShiGemNum = 0;
                    bool isTihuan = false;
                    List<ItemInfo> EquipList = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocEquip);
                    for (int i = 0; i < EquipList.Count; i++)
                    {
                        string[] gemList = EquipList[i].GemIDNew.Split('_');
                        for (int y = 0; y < gemList.Length; y++)
                        {
                            if (CommonHelp.IfNull(gemList[y]) == false)
                            {
                                ItemConfig gemItemCof = ItemConfigCategory.Instance.Get(int.Parse(gemList[y]));
                                if (gemItemCof.ItemSubType == 110)
                                {
                                    equipShiShiGemNum += 1;
                                }
                            }
                            if (EquipList[i].BagInfoID == equipid && gemIndex == y)
                            {
                                isTihuan = true;
                                break;
                            }
                        }
                    }

                    if (!isTihuan && equipShiShiGemNum >= 4)
                    {
                        response.Error = ErrorCode.ERR_GemShiShiNumFull;
                        return;
                    }
                }


                string[] gemIdList = equipInfo.GemIDNew.Split('_');
                gemIdList[gemIndex] = useBagInfo.ItemID.ToString();
                string gemIDNew = "";
                for (int i = 0; i < gemIdList.Length; i++)
                {
                    gemIDNew = gemIDNew + gemIdList[i] + "_";
                }
                equipInfo.GemIDNew = gemIDNew.Substring(0, gemIDNew.Length - 1);
                equipInfo.isBinging = true;
                m2c_bagUpdate.BagInfoUpdate.Add(equipInfo.ToMessage());
                //消耗宝石
                unit.GetComponent<BagComponentS>().OnCostItemData(useBagInfo.BagInfoID, 1);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            }

            //卸下宝石
            if (request.OperateType == 10)
            {
                if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                int gemIndex = int.Parse(request.OperatePar);
                string[] gemIdList = useBagInfo.GemIDNew.Split('_');
                int gemItemId = int.Parse(gemIdList[gemIndex]);

                //类型110的不能卸
                if (!ItemConfigCategory.Instance.Contain(gemItemId))
                {
                    response.Error = ErrorCode.ERR_GemNoError;
                    return;
                }
                ItemConfig gemItemConfig = ItemConfigCategory.Instance.Get(gemItemId);
                if (gemItemConfig.ItemSubType == 110)
                {
                    response.Error = ErrorCode.ERR_GemNoError;
                    return;
                }

                gemIdList[gemIndex] = "0";
                string gemIDNew = "";
                for (int i = 0; i < gemIdList.Length; i++)
                {
                    gemIDNew = gemIDNew + gemIdList[i] + "_";
                }
                useBagInfo.GemIDNew = gemIDNew.Substring(0, gemIDNew.Length - 1);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());

                //回收宝石
                if (gemItemId != 0)
                {
                    unit.GetComponent<BagComponentS    >().OnAddItemData($"{gemItemId};1", $"{ItemGetWay.GemHuiShou}_{TimeHelper.ServerNow()}");
                    Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                }
            }
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}