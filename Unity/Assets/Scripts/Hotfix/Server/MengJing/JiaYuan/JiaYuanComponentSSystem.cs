using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{


    [EntitySystemOf(typeof(JiaYuanComponentS))]
    [FriendOf(typeof(JiaYuanComponentS))]
    public static partial class JiaYuanComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanComponentS self)
        {
            self.InitOpenList();
        }
        [EntitySystem]
        private static void Destroy(this JiaYuanComponentS self)
        {

        }
        
                /// <summary>
        /// int32 Statu = 3;    //0停止散步 1开始散步
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitid"></param>
        /// <param name="status"></param>
        public static void OnJiaYuanPetWalk(this JiaYuanComponentS self, RolePetInfo rolePetInfo, int status, int position)
        {

            for (int i = self.JiaYuanPetList_2.Count - 1; i >= 0; i--)
            {
                if (self.JiaYuanPetList_2[i].unitId == rolePetInfo.Id)
                {
                    self.JiaYuanPetList_2.RemoveAt(i);
                }
            }

            if (status == 2)
            {
                JiaYuanPet JiaYuanPet = JiaYuanPet.Create();
                JiaYuanPet.LastExpTime = TimeHelper.ServerNow();
                JiaYuanPet.unitId = rolePetInfo.Id;
                JiaYuanPet.ConfigId = rolePetInfo.ConfigId;
                JiaYuanPet.PetLv = rolePetInfo.PetLv;
                JiaYuanPet.PlayerName = rolePetInfo.PlayerName;
                JiaYuanPet.PetName = rolePetInfo.PetName;
                JiaYuanPet.Position = position;
                JiaYuanPet.CurExp = 0;
                JiaYuanPet.MoodValue = 0;
                self.JiaYuanPetList_2.Add(JiaYuanPet);
            }
        }

        public static void AddJiaYuanRecord(this JiaYuanComponentS self, JiaYuanRecord jiaYuanRecord)
        {
            self.JiaYuanRecordList_1.Add(jiaYuanRecord);

            if (self.JiaYuanRecordList_1.Count >= 100)
            {
                self.JiaYuanRecordList_1.RemoveAt(0);   
            }
        }

        public static JiaYuanPet GetJiaYuanPet(this JiaYuanComponentS self, long unitid)
        {
            for (int i = 0; i < self.JiaYuanPetList_2.Count; i++)
            {
                if (self.JiaYuanPetList_2[i].unitId == unitid)
                {
                    return self.JiaYuanPetList_2[i];
                }
            }
            return null;
        }

        public static JiaYuanPet GetJiaYuanPetGetPosition(this JiaYuanComponentS self, int position)
        {
            for (int i = 0; i < self.JiaYuanPetList_2.Count; i++)
            {
                if (self.JiaYuanPetList_2[i].Position == position)
                {
                    return self.JiaYuanPetList_2[i];
                }
            }
            return null;
        }

        public static void CheckDaShiPro(this JiaYuanComponentS self)
        {
            UserInfo userInfo = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo;
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfo.JiaYuanLv);

            string proMax = jiaYuanConfig.ProMax;
            string[] prolist = proMax.Split(';');
            Dictionary<int, int> promaxvalue = new Dictionary<int, int>();
            for (int i = 0; i < prolist.Length; i++)
            {
                if (CommonHelp.IfNull(prolist[i]))
                {
                    continue;
                }
                string[] proinfo = prolist[i].Split(',');
                promaxvalue.Add(int.Parse(proinfo[0]), int.Parse(proinfo[1]));
            }

            for (int i = self.JiaYuanProList_7.Count - 1; i >= 0; i--)
            {
                int numericType = self.JiaYuanProList_7[i].KeyId;
                int lvalue = int.Parse(self.JiaYuanProList_7[i].Value);
                int maxvlue = 0;
                promaxvalue.TryGetValue(numericType, out maxvlue);
                int oldmaxvlue = maxvlue;
                maxvlue = (int)(maxvlue * 0.8f);
                
                //超过80%会下降
                if (lvalue >= maxvlue)
                {
                    lvalue -= RandomHelper.NextInt(1,3);
                    if (lvalue < maxvlue) {
                        lvalue = maxvlue;
                    }
                }

                //超过100%会下降更多
                if (lvalue >= oldmaxvlue)
                {
                    lvalue -= RandomHelper.NextInt(10, 20);
                    if (lvalue < maxvlue)
                    {
                        lvalue = maxvlue;
                    }
                }

                lvalue = math.max(lvalue, 0);
                self.JiaYuanProList_7[i].Value = lvalue.ToString();
            }
        }

        public static List<PropertyValue> GetJianYuanPro(this JiaYuanComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();

            for (int i = self.JiaYuanProList_7.Count - 1; i >= 0; i--)
            {
                int numericType = self.JiaYuanProList_7[i].KeyId;
                long lvalue = long.Parse(self.JiaYuanProList_7[i].Value );
                proList.Add(new PropertyValue() { HideID = numericType, HideValue = lvalue });
            }

            List<KeyValuePair> jiayuandashi = ConfigData.JiaYuanDaShiPro;
            for (int i = 0; i < jiayuandashi.Count; i++)
            {
                string[] infolist = jiayuandashi[i].Value2.Split('@');
                int need_time = int.Parse(infolist[0]);
                string[] attriInfo = infolist[1].Split(',');

                int lvalue = 0;
                if (self.JiaYuanDaShiTime_1 >= need_time)
                {
                    lvalue = int.Parse(attriInfo[1]);
                }
                if (lvalue > 0)
                {
                    proList.Add(new PropertyValue() { HideID = int.Parse(attriInfo[0]), HideValue = lvalue });
                }
            }
            return proList;
        }

        public static void UpdateDaShiProInfo(this JiaYuanComponentS self, int keyid, int addvalue)
        {
            for (int i = 0; i < self.JiaYuanProList_7.Count; i++)
            {
                if (self.JiaYuanProList_7[i].KeyId == keyid)
                {
                    int oldvalue = int.Parse(self.JiaYuanProList_7[i].Value);
                    oldvalue += addvalue;
                    self.JiaYuanProList_7[i].Value = oldvalue.ToString();
                    return;
                }
            }
            self.JiaYuanProList_7.Add( new KeyValuePair() { KeyId = keyid, Value = addvalue.ToString() } );
        }

        public static KeyValuePair GetDaShiProInfo(this JiaYuanComponentS self, int keyid)
        {
            for (int i = 0; i < self.JiaYuanProList_7.Count; i++)
            {
                if (self.JiaYuanProList_7[i].KeyId == keyid)
                {
                    return self.JiaYuanProList_7[i];
                }
            }
            return null;
        }

        public static bool IsMyJiaYuan(this JiaYuanComponentS self, long selfId)
        {
            return false;

        }

        /// <summary>
        /// 老的农场作物 过了24个小时自动去掉
        /// </summary>
        /// <param name="self"></param>
        public static void CheckOvertime(this JiaYuanComponentS self)
        {
            long serverTime = TimeHelper.ServerNow();
            //植物
            for (int i = self.JianYuanPlantList_7.Count- 1; i >= 0; i--)
            {
                JiaYuanPlant jiaYuanPlant = self.JianYuanPlantList_7[i];
                int state = JiaYuanHelper.GetPlanStage(jiaYuanPlant.ItemId, jiaYuanPlant.StartTime, jiaYuanPlant.GatherNumber);

                if (state != 4)
                {
                    continue;
                }
                if (serverTime - jiaYuanPlant.GatherLastTime <= TimeHelper.OneDay)
                {
                    continue;
                }

                self.JianYuanPlantList_7.RemoveAt (i);
            }

            //动物
            for (int i = self.JiaYuanPastureList_7.Count - 1; i>= 0; i--)
            {
                JiaYuanPastures jiaYuanPlant = self.JiaYuanPastureList_7[i];
                int state = JiaYuanHelper.GetPastureState(jiaYuanPlant.ConfigId, jiaYuanPlant.StartTime, jiaYuanPlant.GatherNumber);

                if (state != 4)
                {
                    continue;
                }
                if (serverTime - jiaYuanPlant.GatherLastTime <= TimeHelper.OneDay)
                {
                    continue;
                }

                self.JiaYuanPastureList_7.RemoveAt(i);
            }
        }

        public static List<int> InitOpenList(this JiaYuanComponentS self)
        {
            List<int> inits = new List<int>() { 0, 1, 2, 3 };
            for (int i = 0; i < inits.Count; i++)
            {
                if (!self.PlanOpenList_7.Contains(inits[i]))
                {
                    self.PlanOpenList_7.Add(inits[i]);
                }
            }
            return self.PlanOpenList_7;
        }


        public static void OnLogin(this JiaYuanComponentS self)
        {
            self.CheckPetExp();
            
            //检测宠物
            PetComponentS petComponent = self.GetParent<Unit>().GetComponent<PetComponentS>();
            for(int i = self.JiaYuanPetList_2.Count - 1; i >= 0; i--)
            {
                RolePetInfo rolePetInfo = petComponent.GetPetInfo(self.JiaYuanPetList_2[i].unitId);
                if (rolePetInfo == null || rolePetInfo.PetStatus != 2)
                {
                    self.JiaYuanPetList_2.RemoveAt(i);
                }
            }
            for (int i = 0; i < petComponent.RolePetInfos.Count; i++)
            {
                if (petComponent.RolePetInfos[i].PetStatus != 2)
                {
                    continue;
                }

                if (null == self.GetJiaYuanPet(petComponent.RolePetInfos[i].Id))
                {
                    petComponent.RolePetInfos[i].PetStatus = 0;
                }
            }

            if (self.RefreshMonsterTime_2 == 0)
            {
                self.RefreshMonsterTime_2 = TimeHelper.ServerNow() - TimeHelper.Hour * 5;
            }

            if (self.PurchaseItemList_7.Count == 0)
            {
                self.UpdatePurchaseItemList(false);
            }
        }

        public static void OnBeforEnter(this JiaYuanComponentS self)
        {
            self.CheckOvertime();
            self.CheckRefreshMonster();
            self.CheckPetExp();
        }

        public static void UpdatePetMood(this JiaYuanComponentS self, long unitid, int addvalue)
        {
            for (int i = 0; i < self.JiaYuanPetList_2.Count; i++)
            {
                JiaYuanPet jiaYuanPet = self.JiaYuanPetList_2[i];
                if (jiaYuanPet.unitId != unitid)
                {
                    continue;
                }

                jiaYuanPet.MoodValue += addvalue;
            }
        }

        public static void CheckPetExp(this JiaYuanComponentS self)
        {
            long serverTime = TimeHelper.ServerNow();
            PetComponentS petComponent = self.GetParent<Unit>().GetComponent<PetComponentS>();
            for ( int i = self.JiaYuanPetList_2.Count - 1; i >= 0; i--)
            {
                JiaYuanPet jiaYuanPet = self.JiaYuanPetList_2[i];
                if (petComponent.GetPetInfo(jiaYuanPet.unitId) == null)
                {
                    self.JiaYuanPetList_2.RemoveAt(i);
                    continue;
                }
                if (petComponent.GetFightPetId() == jiaYuanPet.unitId)
                {
                    self.JiaYuanPetList_2.RemoveAt(i);
                    continue;
                }

                long passTime = serverTime - jiaYuanPet.LastExpTime;
                if (passTime < TimeHelper.Hour)
                {
                    continue;
                }

                int passHour = (int)(1f * passTime / TimeHelper.Hour);
                passHour = math.min(12, passHour);
                jiaYuanPet.CurExp +=(passHour * CommonHelp.GetJiaYuanPetExp(jiaYuanPet.PetLv, jiaYuanPet.MoodValue) );
                jiaYuanPet.LastExpTime = TimeHelper.ServerNow();
            }

        }

        public static void OnRemoveUnit(this JiaYuanComponentS self, long unitid)
        {
            for (int i = self.JiaYuanMonster_2.Count - 1; i >= 0; i--)
            {
                JiaYuanMonster keyValuePair = self.JiaYuanMonster_2[i];
                if (keyValuePair.unitId == unitid)
                {
                    self.JiaYuanMonster_2.RemoveAt(i);
                }
            }
        }

        public static void CheckRefreshMonster(this JiaYuanComponentS self)
        {
            //keyValuePair.KeyId    怪物id
            //keyValuePair.Value    怪物出生时间戳
            //keyValuePair.Value2   怪物坐标
            long serverNow =  TimeHelper.ServerNow();
            for (int i = self.JiaYuanMonster_2.Count -1; i >= 0; i--)
            {
                JiaYuanMonster keyValuePair = self.JiaYuanMonster_2[i];
                if (!MonsterConfigCategory.Instance.Contain(keyValuePair.ConfigId))
                {
                    self.JiaYuanMonster_2.RemoveAt(i);
                    continue;
                }
                
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(keyValuePair.ConfigId);
                long deathTime = monsterConfig.DeathTime * 1000;
                if (serverNow - keyValuePair.BornTime >= deathTime)
                {
                    self.JiaYuanMonster_2.RemoveAt(i);
                }
            }
           
            while (serverNow - self.RefreshMonsterTime_2 >= TimeHelper.Hour)
            {
                if (self.JiaYuanMonster_2.Count >= 6)
                {
                    break;
                }

                self.RefreshMonsterTime_2 += TimeHelper.Hour;
                JiaYuanMonster keyValuePair = JiaYuanMonster.Create();
                keyValuePair.ConfigId = JiaYuanHelper.GetRandomMonster();
                keyValuePair.BornTime = self.RefreshMonsterTime_2;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(keyValuePair.ConfigId);
                long deathTime = monsterConfig.DeathTime * 1000;
                if (serverNow - keyValuePair.BornTime >= deathTime)
                {
                    continue;
                }

                //每小时40%概率刷新
                if (RandomHelper.RandFloat01() <= 0.6f)
                {
                    break;
                }

                float3 vector3 = JiaYuanHelper.GetMonsterPostion();
                keyValuePair.x = vector3.x;
                keyValuePair.y = vector3.y;
                keyValuePair.z = vector3.z;
                keyValuePair.unitId = IdGenerater.Instance.GenerateId();
                self.JiaYuanMonster_2.Add(keyValuePair);
            }
        }

        public static int OnPastureBuyRequest(this JiaYuanComponentS self, int ProductId)
        {
            for (int i = 0; i < self.PastureGoods_7.Count; i++)
            {
                MysteryItemInfo mysteryItemInfo1 = self.PastureGoods_7[i];

                if (mysteryItemInfo1.ProductId != ProductId)
                {
                    continue;
                }
                if (mysteryItemInfo1.ItemNumber < 1)
                {
                    return ErrorCode.ERR_ItemNotEnoughError;
                }

                self.PastureGoods_7.RemoveAt(i);
                return ErrorCode.ERR_Success;
            }
            return ErrorCode.ERR_ItemNotEnoughError;
        }

        public static int OnMysteryBuyRequest(this JiaYuanComponentS self, int ProductId, List<MysteryItemInfo> jiayuanMysterylist)
        {

            for (int i = 0; i < jiayuanMysterylist.Count; i++)
            {
                MysteryItemInfo mysteryItemInfo1 = jiayuanMysterylist[i];

                if (mysteryItemInfo1.ProductId != ProductId)
                {
                    continue;
                }
                if (mysteryItemInfo1.ItemNumber < 1)
                {
                    return ErrorCode.ERR_ItemNotEnoughError;
                }

                jiayuanMysterylist.RemoveAt(i);    
                return ErrorCode.ERR_Success;
            }
            return ErrorCode.ERR_ItemNotEnoughError;
        }

        public static void SaveDB(this JiaYuanComponentS self)
        { 
            
        }

        /// <summary>
        /// 零点刷新
        /// </summary>
        /// <param name="self"></param>
        public static void OnZeroClockUpdate(this JiaYuanComponentS self, bool notice)
        {
            self.UpdatePlanGoodList();
            self.UpdatePurchaseItemList(notice);
            self.CheckDaShiPro();
        }

        /// <summary>
        /// 12点刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="hour_1"></param>
        /// <param name="hour_2"></param>
        public static void OnLoginCheck(this JiaYuanComponentS self, int hour_1, int hour_2)
        {
           
            ///收购12点刷新
            if ((hour_1 < 12 && hour_2 >= 12)
            || (hour_1 > hour_2))
            {
                self.UpdatePurchaseItemList(false);
            }

            if ((hour_1 < 6 && hour_2 >= 6)
             || (hour_1 < 12 && hour_2 >= 12)
             || (hour_1 < 18 && hour_2 >= 18)
             || (hour_1 > hour_2))
            {
                self.UpdatePlanGoodList();
            }
        }

        public static void UpdatePlanGoodList(this JiaYuanComponentS self)
        {
            int openday = ServerHelper.GetServeOpenDay( self.Zone());
            UserInfo userInfo = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo;
            int jiayuanlv = JiaYuanConfigCategory.Instance.Get(userInfo.JiaYuanLv).Lv;

            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(87);

            self.PlantGoods_7 = MysteryShopHelper.InitJiaYuanPlanItemInfos(openday, jiayuanlv, globalValueConfig.Value);
            self.PastureGoods_7 = JiaYuanHelper.InitJiaYuanPastureList(jiayuanlv);

            self.JiaYuanStore = MysteryShopHelper.InitJiaYuanPlanItemInfos(openday, jiayuanlv, "400001;8");
            
        }

        /// <summary>
        /// 整点刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="hour_1"></param>
        /// <param name="hour_2"></param>
        public static void OnHourUpdate(this JiaYuanComponentS self, int hour_1, bool notice)
        {
            ///收购12点刷新
            if (hour_1 == 12)
            {
                self.UpdatePurchaseItemList(true);
            }
            if (hour_1 == 6 || hour_1 == 12 || hour_1 == 18)
            {
                self.UpdatePlanGoodList();
            }
        }

        public static void UpdatePurchaseItemList_2(this JiaYuanComponentS self)
        {
            self.PurchaseItemList_7.Clear();

            UserInfo userInfo = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo;
            JiaYuanHelper.InitPurchaseItemList(userInfo.JiaYuanLv, self.PurchaseItemList_7);
        }

        public static void UpdatePurchaseItemList(this JiaYuanComponentS self, bool notice)
        {
            long serverTime = TimeHelper.ServerNow();
            for (int i = 0; i < self.PurchaseItemList_7.Count; i++)
            {
                if (self.PurchaseItemList_7[i].EndTime < serverTime)
                {
                    self.PurchaseItemList_7.RemoveAt(i);
                }
            }

            UserInfo userInfo = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo;
            JiaYuanHelper.InitPurchaseItemList(userInfo.JiaYuanLv, self.PurchaseItemList_7);
            if (notice)
            {
                M2C_JiaYuanUpdate  m2C_JiaYuan = M2C_JiaYuanUpdate.Create();
                m2C_JiaYuan.PurchaseItemList = self.PurchaseItemList_7;
                MapMessageHelper.SendToClient( self.GetParent<Unit>(), m2C_JiaYuan);
            }
        }

        public static void UprootPasture(this JiaYuanComponentS self, long unitid)
        {
            for (int i = self.JiaYuanPastureList_7.Count - 1; i >= 0; i--)
            {
                if (self.JiaYuanPastureList_7[i].UnitId == unitid)
                {
                    self.JiaYuanPastureList_7.RemoveAt(i);
                }
            }
        }

        public static JiaYuanPastures GetJiaYuanPastures(this JiaYuanComponentS self, long unitid)
        {
            for (int i = 0; i < self.JiaYuanPastureList_7.Count; i++)
            {
                if (self.JiaYuanPastureList_7[i].UnitId == unitid)
                {
                    return self.JiaYuanPastureList_7[i];
                }
            }
            return null;
        }

        public static int GetRubbishNumber(this JiaYuanComponentS self)
        {
            int number = 0;
            long serverNow = TimeHelper.ServerNow();
            for (int i = self.JiaYuanMonster_2.Count - 1; i >= 0; i--)
            {
                JiaYuanMonster keyValuePair = self.JiaYuanMonster_2[i];
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(keyValuePair.ConfigId);
                long deathTime = monsterConfig.DeathTime * 1000;
                if (serverNow - keyValuePair.BornTime < deathTime)
                {
                    number++;
                }
            }

            return number;
        }

        public static int GetCanGatherNumber(this JiaYuanComponentS self)
        {
            int number = 0;
            for (int i = 0; i < self.JianYuanPlantList_7.Count; i++)
            {
                JiaYuanPlant jiaYuanPlan = self.JianYuanPlantList_7[i];
                int errorcode = JiaYuanHelper.GetPlanShouHuoItem(jiaYuanPlan.ItemId, jiaYuanPlan.StartTime, jiaYuanPlan.GatherNumber, jiaYuanPlan.GatherLastTime);
                if (errorcode == ErrorCode.ERR_Success)
                {
                    number++;
                }
            }
            for (int i = 0; i < self.JiaYuanPastureList_7.Count; i++)
            {
                JiaYuanPastures jiaYuanPasture = self.JiaYuanPastureList_7[i];
                int errorcode = JiaYuanHelper.GetPastureShouHuoItem(jiaYuanPasture.ConfigId, jiaYuanPasture.StartTime, jiaYuanPasture.GatherNumber, jiaYuanPasture.GatherLastTime);
                if (errorcode == ErrorCode.ERR_Success)
                {
                    number++;
                }
            }
            return number;
        }

        public static JiaYuanPlant GetJiaYuanPlant(this JiaYuanComponentS self, long unitid)
        {
            for (int i = 0; i < self.JianYuanPlantList_7.Count; i++)
            {
                if (self.JianYuanPlantList_7[i].UnitId == unitid)
                {
                    return self.JianYuanPlantList_7[i];
                }
            }
            return null;
        }

        public static JiaYuanPlant GetCellPlant(this JiaYuanComponentS self, int cell)
        {
            for (int i = 0; i < self.JianYuanPlantList_7.Count; i++)
            {
                if (self.JianYuanPlantList_7[i].CellIndex == cell)
                { 
                    return self.JianYuanPlantList_7[i];
                }
            }

            return null;
        }

        public static void UprootPlant(this JiaYuanComponentS self, int cellIndex)
        {
            for (int i = self.JianYuanPlantList_7.Count - 1; i >= 0; i--)
            {
                if (self.JianYuanPlantList_7[i].CellIndex == cellIndex)
                {
                    self.JianYuanPlantList_7.RemoveAt(i);
                }
            }
        }

        public static int GetPeopleNumber(this JiaYuanComponentS self)
        {
            int number = 0;
            for (int i = 0; i < self.JiaYuanPastureList_7.Count; i++)
            {
                JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(self.JiaYuanPastureList_7[i].ConfigId);
                number += jiaYuanPastureConfig.PeopleNum;
            }
            return number;
        }

        public static int GetOpenPlanNumber(this JiaYuanComponentS self)
        {
            return self.PlanOpenList_7.Count;
        }
    }
}
