using System.Collections.Generic;

namespace ET.Client
{
    public static class RobotHelper
    {
        public static async ETTask JianDing(Scene root)
        {
            //可以鉴定的装备
            List<BagInfo> bagInfos = root.GetComponent<BagComponentC>().GetCanJianDing();

            //鉴定装备
            foreach (BagInfo bagInfo in bagInfos)
            {
                await BagClientNetHelper.RequestAppraisalItem(root, bagInfo);
            }
        }

        public static async ETTask WearEquip(Scene root)
        {
            //可以穿戴的装备
            List<BagInfo> bagInfos = root.GetComponent<BagComponentC>().GetCanEquipList();

            //穿戴装备
            foreach (BagInfo bagInfo in bagInfos)
            {
                await BagClientNetHelper.RequestTakeoffEquip(root, bagInfo);
            }
        }

        public static async ETTask XiangQianGem(Scene root)
        {
            List<BagInfo> gemstones = root.GetComponent<BagComponentC>().GetItemsByType((int)ItemTypeEnum.Gemstone);
            List<BagInfo> equips = root.GetComponent<BagComponentC>().GetEquipList();

            foreach (BagInfo equip in equips)
            {
                string[] gemHoles = equip.GemHole.Split('_');
                string[] gemIDNews = equip.GemIDNew.Split('_');

                for (int j = 0; j < gemHoles.Length; j++)
                {
                    string gemHole = gemHoles[j];
                    string gemIDNew = gemIDNews[j];

                    for (int i = gemstones.Count - 1; i >= 0; i--)
                    {
                        BagInfo gemstone = gemstones[i];
                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(gemstone.ItemID);
                        if (gemHole != itemConfig.ItemSubType.ToString() && itemConfig.ItemSubType != 110 && itemConfig.ItemSubType != 111)
                        {
                            // 宝石与孔位不符！
                            continue;
                        }

                        if (gemIDNew != "0")
                        {
                            // 该孔位存在宝石
                            ItemConfig beforeItemConfig = ItemConfigCategory.Instance.Get(int.Parse(gemIDNew));

                            if (itemConfig.SellMoneyValue <= beforeItemConfig.SellMoneyValue)
                            {
                                continue;
                            }
                        }

                        string usrPar = string.Format("{0}_{1}", equip.BagInfoID, j);

                        await BagClientNetHelper.RequestXiangQianGem(root, gemstone, usrPar);

                        gemstones.RemoveAt(i);
                    }
                }
            }
        }

        public static async ETTask AddPoint(Scene root)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            int occ = userInfoComponent.UserInfo.Occ;
            int occTwo = userInfoComponent.UserInfo.OccTwo;

            // 按比例推荐加点
            string recommendAddPoint = string.Empty;
            if (ConfigData.RecommendAddPoint.ContainsKey(occTwo))
            {
                recommendAddPoint = ConfigData.RecommendAddPoint[occTwo];
            }
            else if (ConfigData.RecommendAddPoint.ContainsKey(occ))
            {
                recommendAddPoint = ConfigData.RecommendAddPoint[occ];
            }
            else
            {
                return;
            }

            string[] str = recommendAddPoint.Split('@');
            int all = 0;
            List<int> points = new List<int>();
            foreach (string s in str)
            {
                all += int.Parse(s);
                points.Add(int.Parse(s));
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            List<int> PointList = new List<int>();
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointLiLiang));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointZhiLi));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointTiZhi));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointNaiLi));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointMinJie));

            int PointRemain = numericComponentC.GetAsInt(NumericType.PointRemain);

            int red = 0;
            for (int i = 0; i < 5; i++)
            {
                int add = PointRemain / all * points[i];
                red += add;
                PointList[i] += add;
            }

            PointRemain -= red;

            await BagClientNetHelper.RoleAddPoint(root, PointList);
        }

        public static async ETTask GemHeCheng(Scene root)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < 1)
            {
                // 请至少预留一个格子
                return;
            }

            List<BagInfo> bagItemList = bagComponent.GetBagList();
            List<BagInfo> gemList = new List<BagInfo>();
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
            }

            if (costgold <= 0)
            {
                // 当前背包暂无可合成宝石
                return;
            }

            await BagClientNetHelper.RquestGemHeCheng(root, 0);
        }
    }
}