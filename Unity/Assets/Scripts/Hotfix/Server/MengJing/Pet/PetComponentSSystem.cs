using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(PetComponentS))]
    [FriendOf(typeof(PetComponentS))]
    public static partial class PetComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this PetComponentS self)
        {

        }
        
        public static List<PropertyValue> GetPetShouHuPro(this PetComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            if (self.PetShouHuActive == 0)
            {
                return proList;
            }

            int fightNum = 0;       //评分
            int nowNum = 0;
            for (int i = 0; i < 4; i++)
            {
                if (self.PetShouHuList.Count == 0)
                {
                    break;
                }

                RolePetInfo rolePetInfoNow = self.GetPetInfo(self.PetShouHuList[i]);
                if (rolePetInfoNow == null)
                {
                    continue;
                }
                fightNum = fightNum + rolePetInfoNow.PetPingFen;
                if (i == (self.PetShouHuActive -1)) 
                {
                    //获取当前守护
                    nowNum = rolePetInfoNow.PetPingFen;
                }
            }

            //增加属性
            float addFloat = CommonHelp.GetPetShouHuPro(nowNum,fightNum);
            PropertyValue hide = new PropertyValue();
            hide.HideID = int.Parse(ConfigData.PetShouHuAttri[self.PetShouHuActive - 1].Value2);
            hide.HideValue = (long)(addFloat * 10000);
            proList.Add(hide);

            return proList;
        }

        public static void CheckPetList(this PetComponentS self, List<long> petList)
        {
            List <long> ids = new List<long>();

            for (int i = petList.Count - 1; i >= 0; i--)
            {
                if (petList[i]!= 0 && (self.GetPetInfo(petList[i]) == null) || ids.Contains(petList[i]))
                {
                    petList[i] = 0;
                }
                
                if (petList[i] != 0 && ids.Contains(petList[i]))
                {
                    ids.Add(petList[i]);
                }
            }
        }

        public static void CheckPetList(this PetComponentS self, List<KeyValuePairInt> petList)
        {
            List <long> ids = new List<long>();

            for (int i = petList.Count - 1; i >= 0; i--)
            {
                if (petList[i].Value != 0 && (self.GetPetInfo(petList[i].Value) == null) || ids.Contains(petList[i].Value))
                {
                    petList[i].Value = 0;
                }
                
                if (petList[i].Value != 0 && ids.Contains(petList[i].Value))
                {
                    ids.Add(petList[i].Value);
                }
            }
        }
        
        public static void CheckPetList(this PetComponentS self, List<PetBarInfo> petList)
        {
            List <long> ids = new List<long>();

            for (int i = petList.Count - 1; i >= 0; i--)
            {
                if (petList[i].PetId != 0 && (self.GetPetInfo(petList[i].PetId) == null) || ids.Contains(petList[i].PetId))
                {
                    petList[i].PetId = 0;
                }
                
                if (petList[i].PetId != 0 && ids.Contains(petList[i].PetId))
                {
                    ids.Add(petList[i].PetId);
                }
            }
        }
        
        public static void InitPetInfo(this PetComponentS self)
        {
            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                RolePetInfo rolePetInfo = self.RolePetInfos[i];
                if (!PetConfigCategory.Instance.Contain(rolePetInfo.ConfigId))
                {
                    self.RolePetInfos.RemoveAt(i);  
                }
            }
            
            if (!self.PetCangKuOpen.Contains(0))
            {
                self.PetCangKuOpen.Add(0);  
            }

            if (self.RolePetEggs.Count < 4)
            {
                for (int i = self.RolePetEggs.Count; i < 4; i++)
                {
                    self.RolePetEggs.Add(new KeyValuePairLong4());
                }
            }
            self.RolePetEggs[0].Value3 = 1;// 默认开启一个

            if (self.PetFormations.Count != 9)
            {
                self.PetFormations.Clear();
                for (int i = 0; i < 9; i++)
                {
                    self.PetFormations.Add(0);
                }
            }
            if (self.TeamPetList.Count != 9)
            {
                self.TeamPetList.Clear();
                for (int i = 0; i < 9; i++)
                {
                    self.TeamPetList.Add(0);
                }
            }

            if (self.PetFightList_1.Count != 3)
            {
                self.PetFightList_1.Clear();
                self.PetFightList_1.Add(PetBarInfo.Create());
                self.PetFightList_1.Add(PetBarInfo.Create());
                self.PetFightList_1.Add(PetBarInfo.Create());
            }
            
            if (self.PetFightList_2.Count != 3)
            {
                self.PetFightList_2.Clear();
                self.PetFightList_2.Add(PetBarInfo.Create());
                self.PetFightList_2.Add(PetBarInfo.Create());
                self.PetFightList_2.Add(PetBarInfo.Create());
            }
            
            if (self.PetFightList_3.Count != 3)
            {
                self.PetFightList_3.Clear();
                self.PetFightList_3.Add(PetBarInfo.Create());
                self.PetFightList_3.Add(PetBarInfo.Create());
                self.PetFightList_3.Add(PetBarInfo.Create());
            }

            if (self.PetBarConfigList.Count != 3)
            {
                self.PetBarConfigList.Clear();
                self.PetBarConfigList.Add(100001);
                self.PetBarConfigList.Add(200001);
                self.PetBarConfigList.Add(300001);
            }

            if (self.PetMeleeInfoList.Count != 3)
            {
                self.PetMeleeInfoList.Clear();
                self.PetMeleeInfoList.Add(PetMeleeInfo.Create());
                self.PetMeleeInfoList.Add(PetMeleeInfo.Create());
                self.PetMeleeInfoList.Add(PetMeleeInfo.Create());
            }
            
            if ( self.PetShouHuList.Count != 4)
            {
                self.PetShouHuList.Clear();
                for (int i = 0; i < 4; i++)
                {
                    self.PetShouHuList.Add(0);
                }
            }
            if (self.PetMingList.Count != 15)
            {
                self.PetMingList.Clear();
                for (int i = 0; i < 15; i++)
                {
                    self.PetMingList.Add(0);
                }
            }
            if (self.PetMingPosition.Count != 27)
            {
                self.PetMingPosition.Clear();

                for (int i = 0; i < 27; i++)
                {
                    int index = i % 9;
                    int teamid = i / 9;
                    if (index < 5)
                    {
                        long petId = self.PetMingList[teamid * 5 + index];
                        self.PetMingPosition.Add(petId);
                    }
                    else
                    {
                        self.PetMingPosition.Add(0);
                    }
                }
            }

            if (self.PetEchoList.Count != ConfigData.PetEchoAttri.Count)
            {
                for (int i = self.PetEchoList.Count; i < ConfigData.PetEchoAttri.Count; i++)
                {
                    self.PetEchoList.Add( new KeyValuePairInt() );
                }
            }

            if (self.PetZhuangJiaList.Count != PetZhuangJiaConfigCategory.Instance.PetZhuangJiaList.Count)
            {
                for (int i = self.PetZhuangJiaList.Count; i < PetZhuangJiaConfigCategory.Instance.PetZhuangJiaList.Count; i++)
                {
                    self.PetZhuangJiaList.Add(PetZhuangJiaConfigCategory.Instance.PetZhuangJiaList[i][0].Id);
                }
            }

            self.CheckPetList(self.PetFormations);
            self.CheckPetList(self.TeamPetList);
            self.CheckPetList(self.PetFightList_1);
            self.CheckPetList(self.PetFightList_2);
            self.CheckPetList(self.PetFightList_3);
            self.CheckPetList(self.PetShouHuList);
            self.CheckPetList(self.PetMingList);
            self.CheckPetList(self.PetMingPosition);
            self.CheckPetList(self.PetEchoList);

            if (self.PetShouHuActive == 0)
            {
                self.PetShouHuActive = 1;
            }
            List<PetConfig> petConfigs = PetConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < petConfigs.Count; i++)
            {
                bool havepet = false;
                for (int p = 0; p < self.PetSkinList.Count; p++)
                {
                    if (self.PetSkinList[p].KeyId == petConfigs[i].Id)
                    {
                        havepet = true;
                        break;
                    }
                }
                if (!havepet)
                {
                    self.PetSkinList.Add(new KeyValuePair() { KeyId = petConfigs[i].Id, Value = String.Empty });
                }
            }

            Unit unit = self.GetParent<Unit>();
            string userName = unit.GetComponent<UserInfoComponentS>().GetName();
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                RolePetInfo rolePetInfo = self.RolePetInfos[i];
                rolePetInfo.PlayerName = userName;
                if (rolePetInfo.PetHeXinList.Count == 0)
                {
                    rolePetInfo.PetHeXinList = new List<long>() { 0, 0, 0 };
                }
                if (rolePetInfo.ShouHuPos == 0)
                {
                    rolePetInfo.ShouHuPos = RandomHelper.RandomNumber(1, 5);
                }
                if (PetHelper.IsShenShou(rolePetInfo.ConfigId))
                {
                    for (int skill = rolePetInfo.PetSkill.Count - 1; skill >= 0; skill--)
                    {
                        int skillid = rolePetInfo.PetSkill[skill];
                        if (skillid >= 80001001 && skillid <= 80001028)
                        {
                            rolePetInfo.PetSkill.RemoveAt(skill);
                        }
                    }
                    rolePetInfo.ShouHuPos = 5;
                }
                PetHelper.CheckPropretyPoint(rolePetInfo);
            }

            if (self.UpdateNumber == 0)
            {
                self.UpdateNumber = 1;

                int skill8Number = 0;
                for (int i = 0; i < self.RolePetInfos.Count; i++)
                {
                    RolePetInfo rolePetInfo = self.RolePetInfos[i];
                    rolePetInfo.SkinId = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId).Skin[0];
                    skill8Number += (rolePetInfo.PetSkill.Count >= 8 ? 1 : 0);

                    if (PetHelper.IsShenShou(rolePetInfo.ConfigId))
                    {
                        self.PetXiLian(rolePetInfo ,2, 0, 0);
                    }
                    self.UpdatePetAttribute(rolePetInfo, false);
                }

                skill8Number = Math.Min(5, skill8Number);
                if (skill8Number > 0)
                {
                    //unit.GetComponent<BagComponentServer>().OnAddItemData($"10010097;{skill8Number}",$"{ItemGetWay.PetFenjie}_{TimeHelper.ServerNow()}");
                }
            }

        }

        //获取新宠物
        public static RolePetInfo GenerateNewPet(this PetComponentS self, int petId, int skinId, int babytype, int lv)
        {
            Unit unit = self.GetParent<Unit>();
            PetConfig petConfig = PetConfigCategory.Instance.Get(petId);
            RolePetInfo newpet = RolePetInfo.Create();
            newpet.Id = IdGenerater.Instance.GenerateId() + RandomHelper.RandomNumber(0, 100);
            newpet.PetStatus = 0;
            newpet.ConfigId = petConfig.Id;
            newpet.PetExp = 0;
            newpet.PetName = petConfig.PetName;
            newpet.BabyType = babytype;  //1 
            newpet.SkinId = skinId != 0 ? skinId : petConfig.Skin[0];
            newpet.PetHeXinList = new List<long>() { 0, 0, 0 };

            // 当目标是宝宝或者变异宝宝时,捕捉过来为1级。
            // 如果目标是普通怪物,抓过来的宠物对应变成对应等级，最低为15级。并且总的加点属性为随机分配，总属性点少30点。
            if (babytype == 3)
            { 
                newpet.AddPropretyNum = 0;
                newpet.PetLv = Math.Max(lv, 15);
                int addnum = (newpet.PetLv - 1) * 5 - 30;
                List<int> randoms = RandomHelper.SplitIntegerRandomly(addnum, 4);   
                newpet.AddPropretyValue = $"{randoms[0]}_{randoms[1]}_{randoms[2]}_{randoms[3]}";
            }
            else
            {
                newpet.AddPropretyNum = 0;
                newpet.PetLv =petConfig.PetLv;
                newpet.AddPropretyValue = "0_0_0_0";
            }

            newpet.ShouHuPos = RandomHelper.RandomNumber(1, 5);
            newpet.PetName = PetSkinConfigCategory.Instance.Get(newpet.SkinId).Name;
            newpet.PlayerName = unit.GetComponent<UserInfoComponentS>().GetName();
            return newpet;
        }
        
        public static RolePetInfo GenerateNewPetByPetTuJianConfigId(this PetComponentS self, int petTuJianConfigId)
        {
            Unit unit = self.GetParent<Unit>();
            PetConfig petConfig = PetConfigCategory.Instance.Get(petTuJianConfigId);
            RolePetInfo newpet = RolePetInfo.Create();
            newpet.Id = IdGenerater.Instance.GenerateId() + RandomHelper.RandomNumber(0, 100);
            newpet.PetStatus = 0;
            newpet.ConfigId = petConfig.Id;
            newpet.PetLv = 1;
            newpet.PetExp = 0;
            newpet.PetName = petConfig.PetName;
            newpet.BabyType = 0;
            newpet.SkinId = 0;
            newpet.PetHeXinList = new List<long>() { 0, 0, 0 };
            newpet.AddPropretyNum = 0;
            newpet.AddPropretyValue = "0_0_0_0";
            newpet.ShouHuPos = RandomHelper.RandomNumber(1, 5);
            newpet.PlayerName = unit.GetComponent<UserInfoComponentS>().GetName();
            self.PetXiLian(newpet, 2, 0, 0 );
            self.UpdatePetAttribute(newpet, false);
            return newpet;
        }

        //取随机值 保留两位
        public static float RandomNumberFloatKeep2(this PetComponentS self, float lower, float upper)
        {
            float value = lower + ((upper - lower) * RandomHelper.RandFloat());
            return (float)Math.Round(value, 2);
        }

        public static void CheckSkin(this PetComponentS self)
        {
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                RolePetInfo rolePetInfo = self.RolePetInfos[i];
                if (!PetSkinConfigCategory.Instance.Contain(rolePetInfo.SkinId))
                {
                    PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                    rolePetInfo.SkinId = petConfig.Skin.Length >= 2 ? petConfig.Skin[1] : petConfig.Skin[0];
                }
            }
            for (int i = 0; i < self.RolePetBag.Count; i++)
            {
                RolePetInfo rolePetInfo = self.RolePetBag[i];
                if (!PetSkinConfigCategory.Instance.Contain(rolePetInfo.SkinId))
                {
                    PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                    rolePetInfo.SkinId = petConfig.Skin.Length >= 2 ? petConfig.Skin[1] : petConfig.Skin[0];
                }
            }

        }

        public static void OnLogin(this PetComponentS self)
        {
            self.InitPetInfo();
            self.CheckSkin();
            self.CheckPetPingFen();
            self.CheckPetZiZhi();
        }

        public static void InitRobotPet(this PetComponentS self)
        {
            PetMeleeInfo petMeleeInfo_0 = PetMeleeInfo.Create();
            if (self.RolePetInfos.Count <= 6)
            {
                List<PetConfig> petlist = PetConfigCategory.Instance.GetAll().Values.ToList();

                self.OnAddPet(ItemGetWay.PetEggDuiHuan, petlist[0].Id);
                self.OnAddPet(ItemGetWay.PetEggDuiHuan, petlist[1].Id);
                self.OnAddPet(ItemGetWay.PetEggDuiHuan, petlist[2].Id);
                self.OnAddPet(ItemGetWay.PetEggDuiHuan, petlist[3].Id);
                self.OnAddPet(ItemGetWay.PetEggDuiHuan, petlist[4].Id);
                self.OnAddPet(ItemGetWay.PetEggDuiHuan, petlist[5].Id);
            }

            petMeleeInfo_0.MainPetList.Add( self.RolePetInfos[0].Id );
            petMeleeInfo_0.MainPetList.Add( self.RolePetInfos[1].Id );
            petMeleeInfo_0.MainPetList.Add( self.RolePetInfos[2].Id );
            petMeleeInfo_0.MainPetList.Add( self.RolePetInfos[3].Id );
            petMeleeInfo_0.MainPetList.Add( self.RolePetInfos[4].Id );
            petMeleeInfo_0.MainPetList.Add( self.RolePetInfos[5].Id );

            Unit unit = self.GetParent<Unit>();
            petMeleeInfo_0.AssistPetList.AddRange( unit.GetComponent<ChengJiuComponentS>().PetTuJianActives );

            List<PetMagicCardConfig>  allmageic = PetMagicCardConfigCategory.Instance.GetAll().Values.ToList();
            petMeleeInfo_0.MagicList.Add(allmageic[0].Id);
            petMeleeInfo_0.MagicList.Add(allmageic[1].Id);
            petMeleeInfo_0.MagicList.Add(allmageic[2].Id);
            petMeleeInfo_0.MagicList.Add(allmageic[3].Id);
            petMeleeInfo_0.MagicList.Add(allmageic[4].Id);
            petMeleeInfo_0.MagicList.Add(allmageic[5].Id);
            self.PetMeleeInfoList[0] = (petMeleeInfo_0);
            
            PetMeleeInfo petMeleeInfo_1 = PetMeleeInfo.Create();
            self.PetMeleeInfoList[1] = (petMeleeInfo_1);
            PetMeleeInfo petMeleeInfo_2 = PetMeleeInfo.Create();
            self.PetMeleeInfoList[2] = (petMeleeInfo_2);
        }

        public static void CheckPetPingFen(this PetComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            int maxping = self.GetPetMaxPingFen();

            //unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.PegScoreToValue_307, 0, maxping);

            int arrayping = self.GetPetArrayPingFen();
            //unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.PetArrayScoreToValue_308, 0, arrayping);
        }

        public static void CheckPetZiZhi(this PetComponentS self)
        {
            // Unit unit = self.GetParent<Unit>();
            // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.ZiZhiToValue_311, 1, self.GetPetMaxZiZhi(1));
            // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.ZiZhiToValue_311, 2, self.GetPetMaxZiZhi(2));
            // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.ZiZhiToValue_311, 3, self.GetPetMaxZiZhi(3));
            // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.ZiZhiToValue_311, 4, self.GetPetMaxZiZhi(4));
            // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.ZiZhiToValue_311, 5, self.GetPetMaxZiZhi(5));
        }

        public static int GetPetMaxZiZhi(this PetComponentS self, int zizhiType)
        {
            int maxPing = 0;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                int zishi = 0;
                switch (zizhiType)
                {
                   
                    case 1: //="获得宠物生命资质超过"&K386&"点"
                        zishi = self.RolePetInfos[i].ZiZhi_Hp;
                        break;
                    case 2: //="获得宠物攻击资质超过"&K387&"点"
                        zishi = self.RolePetInfos[i].ZiZhi_Act;
                        break;
                    case 3: //="获得宠物物防资质超过"&K388&"点"
                        zishi = self.RolePetInfos[i].ZiZhi_Def;
                        break;
                    case 4: //="获得宠物魔防资质超过"&K389&"点"
                        zishi = self.RolePetInfos[i].ZiZhi_Adf;
                        break;
                    case 5: //="获得宠物魔法资质超过"&K390&"点"
                        zishi = self.RolePetInfos[i].ZiZhi_MageAct;
                        break;
                }

                if (zishi >= maxPing)
                {
                    maxPing = zishi;
                }
            }
            return maxPing;
        }

        public static string GetPingfenList(this PetComponentS self)
        {
            string pingFen = string.Empty;

            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                RolePetInfo rolePetInfo = self.RolePetInfos[i];
                int intFen = rolePetInfo.PetPingFen;
                if (intFen == 0)
                {
                    intFen = rolePetInfo.PetPingFen;
                }
                string strFen = $"{rolePetInfo.ConfigId},{intFen};";
                pingFen += strFen;
            }

            return pingFen;
        }


        public static int GetPetMaxPingFen(this PetComponentS self)
        {
            int maxPing = 0;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].PetPingFen >= maxPing)
                {
                    maxPing = self.RolePetInfos[i].PetPingFen;
                }
            }
            return maxPing;
        }

        public static int GetPetArrayPingFen(this PetComponentS self)
        {
            int pingfen_1 = 0;
            int pingfen_2 = 0;
            for (int i = 0; i < self.TeamPetList.Count; i++)
            {
                RolePetInfo rolePetInfo = self.GetPetInfo(self.TeamPetList[i]);
                if (rolePetInfo!= null)
                {
                    pingfen_1 += rolePetInfo.PetPingFen;
                }
            }
            for (int i = 0; i < self.PetFormations.Count; i++)
            {
                RolePetInfo rolePetInfo = self.GetPetInfo(self.PetFormations[i]);
                if (rolePetInfo != null)
                {
                    pingfen_2 += rolePetInfo.PetPingFen;
                }
            }
            return Math.Max(pingfen_1, pingfen_2);
        }

        /// <summary>
        /// 宠物洗炼
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rolePetInfo"></param>
        /// <param name="XiLianType"> 1 表示出生  2 表示洗炼 </param>
        /// <param name="XiLianType"> itemId 可能为0 </param>
        /// <returns></returns>
        public static RolePetInfo PetXiLian(this PetComponentS self, RolePetInfo rolePetInfo,int XiLianType, int itemId, int fuling)
        {
            Unit unit = self.GetParent<Unit>();
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);

            int addValue = 0;

            //超级宠之晶
            if (itemId == 10010096)
            {
                addValue = 50;
            }

            bool fulingStatus = false;
            if (XiLianType == 1 && fuling == 1)
            {
                //Log.Console("已附灵！！！！！");
                addValue = 75;
                fulingStatus = true;
            }

            rolePetInfo.PetPingFen = int.Parse(petConfig.Base_PingFen);
            rolePetInfo.ZiZhi_Hp = RandomHelper.RandomNumber(petConfig.ZiZhi_Hp_Min, petConfig.ZiZhi_Hp_Max + addValue);
            rolePetInfo.ZiZhi_Act = RandomHelper.RandomNumber(petConfig.ZiZhi_Act_Min, petConfig.ZiZhi_Act_Max + addValue);
            rolePetInfo.ZiZhi_MageAct = RandomHelper.RandomNumber(petConfig.ZiZhi_MageAct_Min, petConfig.ZiZhi_MageAct_Max + addValue);
            rolePetInfo.ZiZhi_Def = RandomHelper.RandomNumber(petConfig.ZiZhi_Def_Min, petConfig.ZiZhi_Def_Max + addValue);
            rolePetInfo.ZiZhi_Adf = RandomHelper.RandomNumber(petConfig.ZiZhi_Adf_Min, petConfig.ZiZhi_Adf_Max + addValue);
            rolePetInfo.ZiZhi_ActSpeed = RandomHelper.RandomNumber(petConfig.ZiZhi_ActSpeed_Min, petConfig.ZiZhi_ActSpeed_Max+ addValue);
            rolePetInfo.ZiZhi_ChengZhang = self.RandomNumberFloatKeep2((float)petConfig.ZiZhi_ChengZhang_Min, (float)petConfig.ZiZhi_ChengZhang_Max);

            //表示出生创建
            if (XiLianType == 1)    
            {
                int minStart = petConfig.InitStartNum[0];
                int maxStart = petConfig.InitStartNum[1];
                rolePetInfo.Star = RandomHelper.RandomNumber(minStart, maxStart);
            }
            
            //运气值100 百分变异
            // if (XiLianType == 1 && petluckly >= 100 && petConfig.Skin.Length >= 2)
            // {
            //     //Log.Console("幸运值100！！！！！");
            //     int skinId = petConfig.Skin[RandomHelper.RandomNumber(1, petConfig.Skin.Length)];
            //     rolePetInfo.SkinId = skinId;
            //     rolePetInfo.PetName = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId).Name;
            //     //unit.GetComponent<NumericComponentServer>().ApplyValue(NumericType.PetExploreLuckly, 0);
            // }

            rolePetInfo.Luckly = 0;   //1为运气加倍 

            string[] skilll = petConfig.BaseSkillID.Split(';');
            rolePetInfo.PetSkill = new List<int>();
            for (int i = 0; i < skilll.Length; i++)
            {
                if (skilll[i] == "0")
                {
                    continue;
                }
                rolePetInfo.PetSkill.Add(int.Parse(skilll[i]));
            }

            //增加宠物专注技能
            skilll = petConfig.ZhuanZhuSkillID.Split(';');
            for (int i = 0; i < skilll.Length; i++)
            {
                if (skilll[i] == "0")
                {
                    continue;
                }
                rolePetInfo.PetSkill.Add(int.Parse(skilll[i]));
            }

            //增加宠物随机技能
            string randomSkillID = petConfig.RandomSkillID;
            float randomAddPro = 1;
            if (fulingStatus) {
                randomAddPro = 2.5f;
            }
            //80001010,01;80001014,0.1;80001015.1

            if (!CommonHelp.IfNull(randomSkillID))
            {
                string[] randomSkillList = randomSkillID.Split(';');
                for (int i = 0; i < randomSkillList.Length; i++)
                {
                    string[] skillInfo = randomSkillList[i].Split(",");

                    int skillID = int.Parse(skillInfo[0]);

                    if (RandomHelper.RandFloat() <= float.Parse(skillInfo[1]) * randomAddPro)
                    {
                        rolePetInfo.PetSkill.Add(skillID);
                    }
                }
            }

            return rolePetInfo;
        }

        //第一次获得宠物的时候调用
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="getWay">-1</param>
        /// <param name="petId"></param>
        /// <param name="skinId"></param>
        /// <param name="fuling"></param>
        /// <returns></returns>
        public static RolePetInfo OnAddPet(this PetComponentS self, int getWay, int petId, int skinId = 0, int fuling = 0, int babyType = 0, int monsterLv = 1)
        {
            Unit unit = self.GetParent<Unit>();
            PetConfig petConfig = PetConfigCategory.Instance.Get(petId);
            List<int> weight = new List<int>(petConfig.SkinPro);

            if (skinId == 0)
            {
                int index = RandomHelper.RandomByWeight(weight);
                skinId = petConfig.Skin[index];
            }

            self.OnUnlockSkin(petConfig.Id + ";" + skinId.ToString());

            RolePetInfo newpet = self.GenerateNewPet(petId, skinId, babyType, monsterLv);
            newpet = self.PetXiLian(newpet, 1, 0, fuling);
            self.UpdatePetAttribute(newpet, false);
            self.CheckPetPingFen();
            self.CheckPetZiZhi();
            
            if (ItemGetWay.PetExplore == getWay)
            {
                self.RolePetBag.Add(newpet);
                M2C_RolePetBagUpdate m2C_RolePetBag = M2C_RolePetBagUpdate.Create();
                m2C_RolePetBag.RolePetBag = self.RolePetBag;
                m2C_RolePetBag.UpdateMode = 1;
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_RolePetBag);
            }
            else
            {
                self.RolePetInfos.Add(newpet);
                M2C_RolePetUpdate m2C_RolePetUpdate = M2C_RolePetUpdate.Create();
                m2C_RolePetUpdate.PetInfoAdd = new List<RolePetInfo>();
                m2C_RolePetUpdate.PetInfoAdd.Add(newpet);
                m2C_RolePetUpdate.GetWay = getWay;
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_RolePetUpdate);
            }

            if (babyType == 0)
            {
                unit.GetComponent<ChengJiuComponentS>().OnPetTuJianActive(newpet.ConfigId, true);
            }
            
            unit.GetComponent<ChengJiuComponentS>().OnGetPet(newpet);
            unit.GetComponent<TaskComponentS>().OnGetPet(newpet);
            
            //如果有皮肤的话更新一次角色属性
            Function_Fight.UnitUpdateProperty_Base(self.GetParent<Unit>(), true, true);
            return newpet;
        }

        //击杀怪物,增加经验等
        public static void OnKillUnit(this PetComponentS self, Unit beKill)
        {
            RolePetInfo rolePetInfo = self.GetFightPet();
            if (rolePetInfo == null)
            {
                return;
            }
            if (beKill.Type != UnitType.Monster)
            {
                return;
            }
            MonsterConfig mCof = MonsterConfigCategory.Instance.Get(beKill.ConfigId);
            int playerLv = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetUserLv();

            //超过5级不能获得经验
            if (rolePetInfo.PetLv >= playerLv + 5)
            {
                return;
            }

            self.PetAddExp(rolePetInfo, mCof.Exp);
        }

        public static void UpdatePetZiZhi(this PetComponentS self, RolePetInfo rolePetInfo, int itemId)
        {
            //10,30;10,30;10,30;10,30;10,30
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            string[] zishiList = itemConfig.ItemUsePar.Split(';');

            string[] ZiZhi_Hp = zishiList[0].Split(',');
            string[] ZiZhi_Act = zishiList[1].Split(',');
            string[] ZiZhi_Def = zishiList[2].Split(',');
            string[] ZiZhi_Adf = zishiList[3].Split(',');
            string[] ZiZhi_MageAct = zishiList[4].Split(',');

            if (rolePetInfo.ZiZhi_Hp < petConfig.ZiZhi_Hp_Max)
            {
                rolePetInfo.ZiZhi_Hp +=  RandomHelper.RandomNumber(int.Parse(ZiZhi_Hp[0]), int.Parse(ZiZhi_Hp[1]));
                rolePetInfo.ZiZhi_Hp = Math.Min(rolePetInfo.ZiZhi_Hp, petConfig.ZiZhi_Hp_Max);
            }

            if (rolePetInfo.ZiZhi_Act < petConfig.ZiZhi_Act_Max)
            {
                rolePetInfo.ZiZhi_Act += RandomHelper.RandomNumber(int.Parse(ZiZhi_Act[0]), int.Parse(ZiZhi_Act[1]));
                rolePetInfo.ZiZhi_Act = Math.Min(rolePetInfo.ZiZhi_Act, petConfig.ZiZhi_Act_Max);
            }

            if (rolePetInfo.ZiZhi_Def < petConfig.ZiZhi_Def_Max)
            {
                rolePetInfo.ZiZhi_Def += RandomHelper.RandomNumber(int.Parse(ZiZhi_Def[0]), int.Parse(ZiZhi_Def[1]));
                rolePetInfo.ZiZhi_Def = Math.Min(rolePetInfo.ZiZhi_Def, petConfig.ZiZhi_Def_Max);
            }

            if (rolePetInfo.ZiZhi_Adf < petConfig.ZiZhi_Adf_Max)
            {
                rolePetInfo.ZiZhi_Adf += RandomHelper.RandomNumber(int.Parse(ZiZhi_Adf[0]), int.Parse(ZiZhi_Adf[1]));
                rolePetInfo.ZiZhi_Adf = Math.Min(rolePetInfo.ZiZhi_Adf, petConfig.ZiZhi_Adf_Max);
            }

            if (rolePetInfo.ZiZhi_MageAct < petConfig.ZiZhi_MageAct_Max)
            {
                rolePetInfo.ZiZhi_MageAct += RandomHelper.RandomNumber(int.Parse(ZiZhi_MageAct[0]), int.Parse(ZiZhi_MageAct[1]));
                rolePetInfo.ZiZhi_MageAct = Math.Min(rolePetInfo.ZiZhi_MageAct,petConfig.ZiZhi_MageAct_Max);
            }
        }

        //宠物进化
        public static void UpdatePetStage(this PetComponentS self, RolePetInfo rolePetInfo,int pingfen)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);

            int maxZiZhi = 20;
            int minZiZhi = 10;

            float floatPro = (float)(pingfen / 7500);
            minZiZhi = (int)((float)minZiZhi * floatPro);
            maxZiZhi = (int)((float)maxZiZhi * floatPro);

            if (minZiZhi < 5) 
            {
                minZiZhi = 5;
            }

            if (minZiZhi > 10)
            {
                minZiZhi = 10;
            }

            if (maxZiZhi < 20)
            {
                maxZiZhi = 20;
            }

            if (maxZiZhi > 30) 
            {
                maxZiZhi = 30;
            }

            string[] ZiZhi_Hp = new string[] { (minZiZhi * 2).ToString(), (maxZiZhi * 2f).ToString() };
            string[] ZiZhi_Act = new string[] { minZiZhi.ToString(), maxZiZhi.ToString() };
            string[] ZiZhi_Def = new string[] { minZiZhi.ToString(), maxZiZhi.ToString() };
            string[] ZiZhi_Adf = new string[] { minZiZhi.ToString(), maxZiZhi.ToString() };
            string[] ZiZhi_MageAct = new string[] { minZiZhi.ToString(), maxZiZhi.ToString() };

            int oldZiZhiHp = rolePetInfo.ZiZhi_Hp;
            int oldZiZhiAct = rolePetInfo.ZiZhi_Act;
            int oldZiZhiDef = rolePetInfo.ZiZhi_Def;
            int oldZiZhiAdf = rolePetInfo.ZiZhi_Adf;
            int oldZiZhiMageAct = rolePetInfo.ZiZhi_MageAct;

            rolePetInfo.ZiZhi_Hp += RandomHelper.RandomNumber(int.Parse(ZiZhi_Hp[0]), int.Parse(ZiZhi_Hp[1]) + 1);
            rolePetInfo.ZiZhi_Act += RandomHelper.RandomNumber(int.Parse(ZiZhi_Act[0]), int.Parse(ZiZhi_Act[1])+1);
            rolePetInfo.ZiZhi_Def += RandomHelper.RandomNumber(int.Parse(ZiZhi_Def[0]), int.Parse(ZiZhi_Def[1])+1);
            rolePetInfo.ZiZhi_Adf += RandomHelper.RandomNumber(int.Parse(ZiZhi_Adf[0]), int.Parse(ZiZhi_Adf[1])+1);
            rolePetInfo.ZiZhi_MageAct += RandomHelper.RandomNumber(int.Parse(ZiZhi_MageAct[0]), int.Parse(ZiZhi_MageAct[1])+1);

            rolePetInfo.ZiZhi_Hp = Math.Min(rolePetInfo.ZiZhi_Hp, petConfig.ZiZhi_Hp_Max);
            rolePetInfo.ZiZhi_Act = Math.Min(rolePetInfo.ZiZhi_Act, petConfig.ZiZhi_Act_Max);
            rolePetInfo.ZiZhi_Def = Math.Min(rolePetInfo.ZiZhi_Def, petConfig.ZiZhi_Def_Max);
            rolePetInfo.ZiZhi_Adf = Math.Min(rolePetInfo.ZiZhi_Adf, petConfig.ZiZhi_Adf_Max);
            rolePetInfo.ZiZhi_MageAct = Math.Min(rolePetInfo.ZiZhi_MageAct, petConfig.ZiZhi_MageAct_Max);

            //有些宠物突破上线需要在这里做处理
            rolePetInfo.ZiZhi_Hp = Math.Max(rolePetInfo.ZiZhi_Hp, oldZiZhiHp);
            rolePetInfo.ZiZhi_Act = Math.Max(rolePetInfo.ZiZhi_Act, oldZiZhiAct);
            rolePetInfo.ZiZhi_Def = Math.Max(rolePetInfo.ZiZhi_Def, oldZiZhiDef);
            rolePetInfo.ZiZhi_Adf = Math.Max(rolePetInfo.ZiZhi_Adf, oldZiZhiAdf);
            rolePetInfo.ZiZhi_MageAct = Math.Max(rolePetInfo.ZiZhi_MageAct, oldZiZhiMageAct);

            //概率增加1个技能    1-2  100%   3 50%   4 20%    5 10%  
            int addSkillID = 0;

            //获取原始宠物技能数量
            float addSkillPro = 0;
            if (rolePetInfo.PetSkill.Count <= 2)
            {
                addSkillPro = 1;
            }

            if (rolePetInfo.PetSkill.Count == 3)
            {
                addSkillPro = 0.5f;
            }

            if (rolePetInfo.PetSkill.Count == 4)
            {
                addSkillPro = 0.2f;
            }

            if (rolePetInfo.PetSkill.Count == 5)
            {
                addSkillPro = 0.1f;
            }

            if (RandomHelper.RandFloat01() < addSkillPro)
            {
                if (RandomHelper.RandFloat01() <= 0.7f) {
                    //低级技能概率70%
                    int add = RandomHelper.RandomNumber(1, 28);
                    addSkillID = 80001000 + add;
                }
                else
                {
                    //高级技能30%
                    int add = RandomHelper.RandomNumber(1, 28);
                    addSkillID = 80002000 + add;
                }
            }

            //如果当前技能有了那么就忽略掉此次技能附加。
            if (rolePetInfo.PetSkill.Contains(addSkillID))
            {
                addSkillID = 0;
            }

            //检查互斥ID
            if (addSkillID != 0) {

                int jianchaSkillID = 0;
                if (addSkillID >= 80002000) {
                    jianchaSkillID = addSkillID - 1000;
                }
                else {
                    jianchaSkillID = addSkillID - 1000;
                }

                if (rolePetInfo.PetSkill.Contains(jianchaSkillID))
                {
                    addSkillID = 0;
                }
            }

            if (addSkillID != 0)
            {
                rolePetInfo.PetSkill.Add(addSkillID);
            }

            //设置成已进化
            rolePetInfo.UpStageStatus = 2;

            //刷新一下宠物属性
            self.UpdatePetAttribute(rolePetInfo, true);
        }

        public static void UpdatePetChengZhang(this PetComponentS self, RolePetInfo rolePetInfo, int itemId)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            string[] addinfo = itemConfig.ItemUsePar.Split(',');
            float addChengZhang = RandomHelper.RandomNumberFloat(float.Parse(addinfo[0]), float.Parse(addinfo[1]));
            rolePetInfo.ZiZhi_ChengZhang += addChengZhang;
            rolePetInfo.ZiZhi_ChengZhang = Math.Min(rolePetInfo.ZiZhi_ChengZhang, (float)petConfig.ZiZhi_ChengZhang_Max);
        }

        //重置属性点
        public static void OnResetPoint(this PetComponentS self, RolePetInfo rolePetInfo)
        {
            rolePetInfo.AddPropretyNum = PetHelper.GetAddPropretyNum(rolePetInfo);
            rolePetInfo.AddPropretyValue = "0_0_0_0";
            self.UpdatePetAttribute(rolePetInfo, false);
        }

        //增加经验
        public static void PetAddLv(this PetComponentS self, RolePetInfo rolePetInfo, int lv)
        {
            if (rolePetInfo == null)
            {
                return;
            }
            Unit unit = self.GetParent<Unit>();
            int playerLv = unit.GetComponent<UserInfoComponentS>().GetUserLv();
            int newLevel = rolePetInfo.PetLv + lv;
            newLevel = Math.Min(Math.Max(0, newLevel), playerLv + 5);
            rolePetInfo.AddPropretyNum += (newLevel - rolePetInfo.PetLv) * 5;
            rolePetInfo.PetLv = newLevel;

            // 非神宠每次升级有概率进化状态
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            if (petConfig.PetType != 2)
            {
                if (RandomHelper.RandFloat01() <= 0.02f && rolePetInfo.UpStageStatus == 0)
                {
                    rolePetInfo.UpStageStatus = 1;
                    //unit.GetComponent<UserInfoComponentServer>().UpdateRoleData(UserDataType.Message, "恭喜你，你的宠物在升级时金光一闪，领悟进化！");
                }
                else
                {
                    //70级必定进化
                    if (rolePetInfo.PetLv >= 70 && rolePetInfo.UpStageStatus == 0)
                    {
                        rolePetInfo.UpStageStatus = 1;
                        //unit.GetComponent<UserInfoComponentServer>().UpdateRoleData(UserDataType.Message, "恭喜你，你的宠物在升级时金光一闪，领悟进化！");
                    }
                }
            }

            //刷新属性
            self.UpdatePetAttribute(rolePetInfo, true);

            //通知客户端
            M2C_PetDataUpdate M2C_PetDataUpdate = M2C_PetDataUpdate.Create();
            M2C_PetDataUpdate.UpdateType = (int)UserDataType.Lv;
            M2C_PetDataUpdate.PetId = rolePetInfo.Id;
            M2C_PetDataUpdate.UpdateTypeValue = rolePetInfo.PetLv.ToString();
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), M2C_PetDataUpdate);

            M2C_PetDataBroadcast M2C_PetDataBroadcast = M2C_PetDataBroadcast.Create();
            M2C_PetDataBroadcast.UnitId = self.GetParent<Unit>().Id;
            M2C_PetDataBroadcast.UpdateType = (int)UserDataType.Lv;
            M2C_PetDataBroadcast.PetId = rolePetInfo.Id;
            M2C_PetDataBroadcast.UpdateTypeValue =rolePetInfo.PetLv.ToString();
            MapMessageHelper.Broadcast(self.GetParent<Unit>(), M2C_PetDataBroadcast);

        }

        public static void OnPetDead(this PetComponentS self, long petId)
        {
            RolePetInfo petinfo = self.GetPetInfo(petId);
            petinfo.PetStatus = 0;
            M2C_PetDataUpdate M2C_PetDataUpdate = M2C_PetDataUpdate.Create();
            M2C_PetDataUpdate.UpdateType = (int)UserDataType.PetStatus;
            M2C_PetDataUpdate.PetId = petId; 
            M2C_PetDataUpdate.UpdateTypeValue = "0";
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), M2C_PetDataUpdate);
        }

        public static void OnPetWalk(this PetComponentS self, long petId, int petstatu)
        {
            RolePetInfo petinfo = self.GetPetInfo(petId);
            petinfo.PetStatus = petstatu;
            M2C_PetDataUpdate M2C_PetDataUpdate = M2C_PetDataUpdate.Create();
            M2C_PetDataUpdate.UpdateType = (int)UserDataType.PetStatus;
            M2C_PetDataUpdate. PetId = petId;
            M2C_PetDataUpdate.UpdateTypeValue = petstatu.ToString();
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), M2C_PetDataUpdate);
        }

        //增加等级
        public static void PetAddExp(this PetComponentS self, RolePetInfo rolePetInfo, int exp)
        {
            if (rolePetInfo == null)
            {
                return;
            }

            int newExp = rolePetInfo.PetExp + exp;
            ExpConfig xiulianconf1 = ExpConfigCategory.Instance.Get(rolePetInfo.PetLv);
            if (newExp >= xiulianconf1.PetUpExp)
            {
                self.PetAddLv(rolePetInfo, 1);
                newExp -= xiulianconf1.PetUpExp;
            }

            rolePetInfo.PetExp = newExp;

            //通知客户端
            M2C_PetDataUpdate M2C_PetDataUpdate = M2C_PetDataUpdate.Create();
            M2C_PetDataUpdate.UpdateType = (int)UserDataType.Exp;
            M2C_PetDataUpdate.PetId = rolePetInfo.Id;
            M2C_PetDataUpdate.UpdateTypeValue = rolePetInfo.PetExp.ToString();
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), M2C_PetDataUpdate);
        }

        public static long GetByKey(this PetComponentS self, RolePetInfo rolePetInfo, int numericType)
        {
            for (int i = 0; i < rolePetInfo.Ks.Count; i++)
            {
                if (rolePetInfo.Ks[i] == numericType)
                {
                    return rolePetInfo.Vs[i];
                }
            }
            return 0;
        }

        public static float GetAsFloat(this PetComponentS self, RolePetInfo rolePetInfo, int numericType)
        {
            return (float)self.GetByKey(rolePetInfo, numericType) / 10000;
        }

        public static void OnPetQiangHua(this PetComponentS self,int addtype, int addpoint)
        {
            switch (addtype)
            {
                case 0:
                    for (int i = 0; i < self.RolePetInfos.Count; i++)
                    {
                        self.RolePetInfos[i].AddPropretyValue = $"{addpoint}_{addpoint}_{addpoint}_{addpoint}";
                    }
                    break;
                case 1:
                    for (int i = 0; i < self.RolePetInfos.Count; i++)
                    {
                        self.RolePetInfos[i].AddPropretyValue = $"{addpoint}_0_0_0";
                    }
                    break;
                case 2:
                    for (int i = 0; i < self.RolePetInfos.Count; i++)
                    {
                        self.RolePetInfos[i].AddPropretyValue = $"0_{addpoint}_0_0";
                    }
                    break;
                case 3:
                    for (int i = 0; i < self.RolePetInfos.Count; i++)
                    {
                        self.RolePetInfos[i].AddPropretyValue = $"0_0_{addpoint}_0";
                    }
                    break;
                case 4:
                    for (int i = 0; i < self.RolePetInfos.Count; i++)
                    {
                        self.RolePetInfos[i].AddPropretyValue = $"0_0_0_{addpoint}";
                    }
                    break;
                case 5:
                    for (int i = 0; i < self.RolePetInfos.Count; i++)
                    {
                        self.RolePetInfos[i].AddPropretyValue = $"{addpoint}_{addpoint}_0_0";
                    }
                    break;
                case 6:
                    for (int i = 0; i < self.RolePetInfos.Count; i++)
                    {
                        self.RolePetInfos[i].AddPropretyValue = $"{addpoint}_{addpoint}_{addpoint}_0";
                    }
                    break;
                default:
                    break;
            }
           
        }

        public static void UpdatePetAttributeWithData(this PetComponentS self, BagComponentS bagComponent, NumericComponentS numericComponent, RolePetInfo rolePetInfo, bool updateUnit = false)
        {
            rolePetInfo.PetPingFen = PetHelper.GetPetCombat(rolePetInfo);
            //获取宠物资质
            float actPro = self.GetZiZhiAddPro(1, rolePetInfo.ZiZhi_Act);
            float magePro = self.GetZiZhiAddPro(1, rolePetInfo.ZiZhi_MageAct);
            float defPro = self.GetZiZhiAddPro(1, rolePetInfo.ZiZhi_Def);
            float adfPro = self.GetZiZhiAddPro(1, rolePetInfo.ZiZhi_Def);
            float hpPro = self.GetZiZhiAddPro(2, rolePetInfo.ZiZhi_Hp);

            //属性加点对应属性 力量-攻击 智力-魔法 体质-血量 耐力就是物防和魔防
            PetConfig petCof = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            PetHelper.CheckPropretyPoint(rolePetInfo);

            //获取加点属性
            string[] attributeinfos = rolePetInfo.AddPropretyValue.Split('_');
            int pro_LiLiang = int.Parse(attributeinfos[0]);          //力量
            int pro_ZhiLi = int.Parse(attributeinfos[1]);            //智力
            int pro_TiZhi = int.Parse(attributeinfos[2]);            //体制
            int pro_NaiLi = int.Parse(attributeinfos[3]);            //耐力

            int act_Now = (int)((petCof.Base_Act + rolePetInfo.PetLv * petCof.Lv_Act + pro_LiLiang * 10) * actPro * rolePetInfo.ZiZhi_ChengZhang);
            int mage_Now = (int)((petCof.Base_MageAct + rolePetInfo.PetLv * petCof.Lv_MageAct + pro_ZhiLi * 10) * magePro * rolePetInfo.ZiZhi_ChengZhang);
            int hp_Now = (int)((petCof.Base_Hp + rolePetInfo.PetLv * petCof.Lv_Hp + pro_TiZhi * 100 + pro_NaiLi * 30) * hpPro * rolePetInfo.ZiZhi_ChengZhang);      //给额外血宠的属性
            int def_Now = (int)((petCof.Base_Def + rolePetInfo.PetLv * petCof.Lv_Def + pro_NaiLi * 8) * defPro * rolePetInfo.ZiZhi_ChengZhang);
            int adf_Now = (int)((petCof.Base_Adf + rolePetInfo.PetLv * petCof.Lv_Adf + pro_NaiLi * 8) * adfPro * rolePetInfo.ZiZhi_ChengZhang);

            float speed = petCof.Base_MoveSpeed;
            //float speed = self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsFloat(NumericType.Now_Speed);

            //存储数据
            rolePetInfo.Ks.Clear();
            rolePetInfo.Vs.Clear();

            rolePetInfo.Ks.Add((int)NumericType.Now_Hp);
            rolePetInfo.Vs.Add(hp_Now);

            rolePetInfo.Ks.Add((int)NumericType.PetSkin);
            rolePetInfo.Vs.Add(rolePetInfo.SkinId);

            rolePetInfo.Ks.Add((int)NumericType.Base_Speed_Base);
            rolePetInfo.Vs.Add((long)speed * 10000);

            rolePetInfo.Ks.Add((int)NumericType.Base_MaxHp_Base);
            rolePetInfo.Vs.Add(hp_Now);

            rolePetInfo.Ks.Add((int)NumericType.Base_MaxAct_Base);
            rolePetInfo.Vs.Add(act_Now);

            rolePetInfo.Ks.Add((int)NumericType.Base_Mage_Base);
            rolePetInfo.Vs.Add(mage_Now);

            rolePetInfo.Ks.Add((int)NumericType.Base_MaxDef_Base);
            rolePetInfo.Vs.Add(def_Now);

            rolePetInfo.Ks.Add((int)NumericType.Base_MaxAdf_Base);
            rolePetInfo.Vs.Add(adf_Now);

            rolePetInfo.Ks.Add((int)NumericType.Base_Cri_Base);
            rolePetInfo.Vs.Add(0);

            rolePetInfo.Ks.Add((int)NumericType.Base_Res_Base);
            rolePetInfo.Vs.Add(0);

            rolePetInfo.Ks.Add((int)NumericType.Base_Hit_Base);
            rolePetInfo.Vs.Add(0);

            rolePetInfo.Ks.Add((int)NumericType.Base_Dodge_Base);
            rolePetInfo.Vs.Add(0);

            //宠物之核
            List<int> petheXinLv = new List<int>();
            Dictionary<int, long> attriDic = new Dictionary<int, long>();

            for (int i = 0; i < rolePetInfo.PetHeXinList.Count; i++)
            {
                long baginfoId = rolePetInfo.PetHeXinList[i];
                if (baginfoId == 0)
                {
                    continue;
                }

                BagInfo bagInfo = null;//bagComponent.GetItemByLoc(ItemLocType.ItemPetHeXinEquip, baginfoId);
                if (bagInfo == null || !ItemConfigCategory.Instance.Contain(bagInfo.ItemID))
                {
                    continue;
                }
               
                //100203;790
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                petheXinLv.Add(itemConfig.UseLv);

                string attriStr = itemConfig.ItemUsePar;
                string[] attriList = attriStr.Split('@');
                for (int a = 0; a < attriList.Length; a++)
                {
                    try
                    {
                        string[] attriItem = attriList[a].Split(';');
                        int typeId = int.Parse(attriItem[0]);
                        //Function_Fight.AddUpdateProDicList(typeId, NumericHelp.GetNumericValueType(typeId) == 2 ? (long)(10000 * float.Parse(attriItem[1])) : long.Parse(attriItem[1]), attriDic);
                    }
                    catch (Exception ex)
                    {
                        Log.Info($"attriStrexc Eption： {attriStr} {ex.ToString()}");
                    }
                }
            }

            //宠物装备(三个一个的属性激活新技能  添加到rolePetInfo.PetSkill, 防止技能重复添加，脱装备的时候直接C2M_PetEquipRequest去掉装备技能 )
            Dictionary<int, int> hideSkillId = new Dictionary<int, int>();
            for (int i = 0; i < rolePetInfo.PetEquipList.Count; i++)
            {
                long baginfoId = rolePetInfo.PetEquipList[i];
                if (baginfoId == 0)
                {
                    continue;
                }

                BagInfo bagInfo = null;//bagComponent.GetItemByLoc(ItemLocType.PetLocEquip, baginfoId);
                if (bagInfo == null || !ItemConfigCategory.Instance.Contain(bagInfo.ItemID))
                {
                    continue;
                }

                for (int skill = 0; skill < bagInfo.HideSkillLists.Count; skill++)
                { 
                    int skillId = bagInfo.HideSkillLists[skill];
                    if (!hideSkillId.ContainsKey(skillId))
                    {
                        hideSkillId.Add(skillId, 0);
                    }
                    hideSkillId[skillId]++;
                }

                ///宠物装备属性
            }
        
            foreach ( (int skillId, int skillNum) in hideSkillId)
            {
                int hideId = HideProListConfigCategory.Instance.PetSkillToHideProId[skillId];
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hideId);
                if (skillNum >= hideProListConfig.NeedNumber)
                {
                    rolePetInfo.PetSkill.Add ( hideProListConfig.PropertyType );
                }
            }

            //宠物之核套装属性
            string petheXinPro = ConfigHelper.GetPetSuitProperty(petheXinLv);
            if (!CommonHelp.IfNull(petheXinPro))
            {
                string[] attriList = petheXinPro.Split(';');
                for (int a = 0; a < attriList.Length; a++)
                {
                    try
                    {
                        string[] attriItem = attriList[a].Split(',');
                        int typeId = int.Parse(attriItem[0]);
                        //Function_Fight.AddUpdateProDicList(typeId, NumericHelp.GetNumericValueType(typeId) == 2 ? (long)(10000 * float.Parse(attriItem[1])) : long.Parse(attriItem[1]), attriDic);
                    }
                    catch (Exception ex)
                    {
                        Log.Info($"petheXinPro Exption： {petheXinPro} {ex.ToString()}");
                    }
                }
            }

            //宠物修炼属性。 宠物数值
            if (numericComponent != null)
            {
                int xiuLian_0 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_0);
                int xiuLian_1 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_1);
                int xiuLian_2 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_2);
                int xiuLian_3 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_3);
                List<int> unionXiuLianids = new List<int>() { xiuLian_0, xiuLian_1, xiuLian_2, xiuLian_3 };
                for (int i = 0; i < unionXiuLianids.Count; i++)
                {
                    if (unionXiuLianids[i] == 0)
                    {
                        continue;
                    }
                    UnionQiangHuaConfig unionQiangHuaCof = UnionQiangHuaConfigCategory.Instance.Get(unionXiuLianids[i]);
                    List<PropertyValue> jiazuProList = new List<PropertyValue>();
                    //NumericHelp.GetProList(unionQiangHuaCof.EquipPropreAdd, jiazuProList);
                    for (int pro = 0; pro < jiazuProList.Count; pro++)
                    {
                        //Function_Fight.AddUpdateProDicList(jiazuProList[pro].HideID, jiazuProList[pro].HideValue, attriDic);
                    }
                }
            }

            if (!PetSkinConfigCategory.Instance.Contain(rolePetInfo.SkinId))
            {
                rolePetInfo.SkinId = petCof.Skin.Length>=2 ? petCof.Skin[1] : petCof.Skin[0];
                Log.Warning($"rolePetInfo.SkinId:  {rolePetInfo.SkinId}");
            }
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            if (!CommonHelp.IfNull(petSkinConfig.PripertySet))
            {
                string[] attriList = petSkinConfig.PripertySet.Split(';');
                for (int a = 0; a < attriList.Length; a++)
                {
                    try
                    {
                        string[] attriItem = attriList[a].Split(',');
                        int typeId = int.Parse(attriItem[0]);
                        //Function_Fight.AddUpdateProDicList(typeId, NumericHelp.GetNumericValueType(typeId) == 2 ? (long)(10000 * float.Parse(attriItem[1])) : long.Parse(attriItem[1]), attriDic);
                    }
                    catch (Exception ex)
                    {
                        Log.Warning($"attriStrexc Eption： {petSkinConfig.PripertySet} {ex.ToString()}");
                    }
                }
            }


            //互斥技能处理
            List<int> huchiList = new List<int>();
            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                SkillConfig skillCof = SkillConfigCategory.Instance.Get(rolePetInfo.PetSkill[i]);
                if (rolePetInfo.PetSkill.Contains(skillCof.HuChiID))
                {
                    huchiList.Add(rolePetInfo.PetSkill[i]);
                }
            }

            //宠物技能
            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                SkillConfig skillCof = SkillConfigCategory.Instance.Get(rolePetInfo.PetSkill[i]);
                if (CommonHelp.IfNull(skillCof.GameObjectParameter))
                {
                    continue;
                }

                //判定是否为附加属性
                if (skillCof.SkillType != 5)
                {
                    continue;
                }

                //判断是否为互斥技能
                if (huchiList.Contains(rolePetInfo.PetSkill[i]))
                {
                    continue;
                }

                string[] skillStrList = skillCof.GameObjectParameter.Split(';');
                if (skillStrList.Length == 0)
                {
                    continue;
                }

                for (int y = 0; y < skillStrList.Length; y++)
                {
                    try
                    {
                        string[] attriItem = skillStrList[y].Split(',');
                        if (attriItem.Length == 0)
                        {
                            continue;
                        }
                        int typeId = int.Parse(attriItem[0]);
                        //long typevalue = NumericHelp.GetNumericValueType(typeId) == 2 ? (long)(10000 * float.Parse(attriItem[1])) : long.Parse(attriItem[1]);
                        //Function_Fight.AddUpdateProDicList(typeId, typevalue, attriDic);
                    }
                    catch (Exception ex)
                    {
                        Log.Info($"attri Eption：{rolePetInfo.PetSkill[i]} {ex.ToString()}");
                    }
                }
            }
            
            foreach (var item in attriDic)
            {
                int numericType = item.Key;
                int attriIndex = rolePetInfo.Ks.IndexOf(numericType);
                if (attriIndex == -1 )
                {
                    rolePetInfo.Ks.Add(numericType);
                    rolePetInfo.Vs.Add(item.Value);
                    continue;
                }
                rolePetInfo.Vs[attriIndex] += item.Value;
            }

            int pingfenIndex = rolePetInfo.Ks.IndexOf(NumericType.PetPinFen);
            if (pingfenIndex != -1)
            {
                rolePetInfo.Ks.RemoveAt(pingfenIndex);
                rolePetInfo.Vs.RemoveAt(pingfenIndex);
            }

            int pingfen = PetHelper.GetPetCombat(rolePetInfo);
            rolePetInfo.Ks.Add((int)NumericType.PetPinFen);
            rolePetInfo.Vs.Add(pingfen);
            PetHelper.UpdatePetNumeric( rolePetInfo );
        }

        public static void RemoveEquipSkill(this PetComponentS self, RolePetInfo rolePetInfom, ItemInfo bagInfo)
        {
            for (int i = rolePetInfom.PetSkill.Count - 1; i >= 0; i--)
            {
                if (bagInfo.HideSkillLists.Contains(rolePetInfom.PetSkill[i]))
                {
                    rolePetInfom.PetSkill.RemoveAt(i);
                }
            }
        }

        public static void UpdatePetAttribute(this PetComponentS self,  RolePetInfo rolePetInfo, bool updateUnit)
        {
            BagComponentS bagComponent = self.GetParent<Unit>().GetComponent<BagComponentS>();
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            self.UpdatePetAttributeWithData( bagComponent, numericComponent, rolePetInfo, updateUnit );

            //如果是出战的宠物。再广播一下属性
            if (updateUnit == false)
            {
                return;
            }
            Unit petUnit = self.GetParent<Unit>().GetParent<UnitComponent>().Get(rolePetInfo.Id);
            if (petUnit == null)
            {
                return;
            }
            petUnit.GetComponent<HeroDataComponentS>().InitPet(rolePetInfo, true);
        }

        //根据资质换算出当前系数
        private static float GetZiZhiAddPro(this PetComponentS self, int type ,int value) {

            float pro = 0.8f;

            if (type == 1) {
                if (value >= 1200)
                {
                    //超出算法
                    pro = 0.8f + ((value-1200) / 600.0f);
                }
                else {
                    //低出算法
                    pro = (float)value/1500.0f;
                }
            }

            if (type == 2)
            {
                if (value >= 2400)
                {
                    //超出算法
                    pro = 0.8f + ((value - 2400) / 1200.0f);
                }
                else
                {
                    //低出算法
                    pro = (float)value / 3000.0f;
                }
            }

            return pro;
        }

        public static void RemovePet(this PetComponentS self, long petId)
        {
            Unit unit = self.GetParent<Unit>();
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            for (int i = self.RolePetInfos.Count - 1; i>= 0; i--)
            {
                if (self.RolePetInfos[i].Id == petId)
                {
                    //移除宠物之核
                    //bagComponent.OnCostItemData(self.RolePetInfos[i].PetHeXinList, ItemLocType.ItemPetHeXinEquip);
                    //bagComponent.OnCostItemData(self.RolePetInfos[i].PetEquipList, ItemLocType.PetLocEquip);

                    self.RolePetInfos.RemoveAt(i);
                    break;
                }
            }

            self.ResetFormation(self.PetFormations, petId);
            self.ResetFormation(self.TeamPetList, petId);
            self.ResetFormation(self.PetMingList, petId);
            self.ResetFormation(self.PetMingPosition, petId);
        }

        public static List<RolePetInfo> GetAllPets(this PetComponentS self)
        {
            return self.RolePetInfos;
        }

        public static void SetNowPetFightList(this PetComponentS self, List<PetBarInfo> petBarInfos)
        {
            if (self.PetFightPlan == 0)
            {
                foreach (PetBarInfo petBarInfo in self.PetFightList_1)
                {
                    petBarInfo.Dispose();
                }

                self.PetFightList_1.Clear();
                self.PetFightList_1 = petBarInfos;
            }

            if (self.PetFightPlan == 1)
            {
                foreach (PetBarInfo petBarInfo in self.PetFightList_2)
                {
                    petBarInfo.Dispose();
                }

                self.PetFightList_2.Clear();
                self.PetFightList_2 = petBarInfos;
            }

            if (self.PetFightPlan == 2)
            {
                foreach (PetBarInfo petBarInfo in self.PetFightList_3)
                {
                    petBarInfo.Dispose();
                }

                self.PetFightList_3.Clear();
                self.PetFightList_3 = petBarInfos;
            }
        }

        public static List<PetBarInfo> GetNowPetFightList(this PetComponentS self)
        {
            return self.PetFightPlan switch
            {
                0 => self.PetFightList_1,
                1 => self.PetFightList_2,
                2 => self.PetFightList_3,
                _ => null
            };
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="petfightindex">0玩家 123</param>
        /// <returns></returns>
        public static Unit GetFightPetByIndex(this PetComponentS self,  int petfightindex)
        {
            //petfightindex 123
            List<PetBarInfo> petFightList = self.GetNowPetFightList();
            if (petfightindex <= 0 || petfightindex > petFightList.Count)
            {
                return null;
            }

            RolePetInfo rolePetInfo = self.GetPetInfo(petFightList[petfightindex - 1].PetId);
            Unit petunit = self.GetParent<Unit>().GetParent<UnitComponent>().Get(rolePetInfo.Id);
            return petunit;
        }

        public static bool HavePetByConfigId(this PetComponentS self, int configId)
        {
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].ConfigId == configId)
                {
                    return true;
                }
            }
            
            
            for (int i = 0; i < self.RolePetBag.Count; i++)
            {
                if (self.RolePetBag[i].ConfigId == configId)
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Get可以取缓存数据，不用读缓存数据库
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static RolePetInfo GetPetInfo(this PetComponentS self, long PetId)
        {
            RolePetInfo petInfo = null;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].Id == PetId)
                {
                    return self.RolePetInfos[i];
                }
            }
            return petInfo;
        }

        /// <summary>
        /// Get可以取缓存数据，不用读缓存数据库
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static RolePetInfo GetPetInfoByBag(this PetComponentS self, long PetId)
        {
            RolePetInfo petInfo = null;
            for (int i = 0; i < self.RolePetBag.Count; i++)
            {
                if (self.RolePetBag[i].Id == PetId)
                {
                    return self.RolePetBag[i];
                }
            }
            return petInfo;
        }

        public static long GetFightPetId(this PetComponentS self)
        {
            RolePetInfo rolePetInfo = self.GetFightPet();
            return rolePetInfo != null ? rolePetInfo.Id : 0;
        }

        public static RolePetInfo GetFightPet(this PetComponentS self)
        {
            RolePetInfo petId = null;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].PetStatus == 1)
                {
                    petId = self.RolePetInfos[i];
                }
            }
            return petId;
        }

        public static void TakeOutBag(this PetComponentS self, long petId)
        {
            RolePetInfo rolePetInfo = self.GetPetInfoByBag(petId);
            if (rolePetInfo == null)
            {
                return;
            }

            self.RemovePetBag(petId);

            self.RolePetInfos.Add(rolePetInfo);
            M2C_RolePetUpdate m2C_RolePetUpdate = M2C_RolePetUpdate.Create();
            m2C_RolePetUpdate.PetInfoAdd = new List<RolePetInfo>();
            m2C_RolePetUpdate.PetInfoAdd.Add(rolePetInfo);
            m2C_RolePetUpdate.GetWay = ItemGetWay.TakeOutBag;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_RolePetUpdate);
        }

        public static void RemovePetBag(this PetComponentS self, long petId)
        {
            for (int i = self.RolePetBag.Count - 1; i >= 0; i--)
            {
                if (self.RolePetBag[i].Id == petId)
                {
                    self.RolePetBag.RemoveAt(i);
                    break;
                }
            }

            M2C_RolePetBagUpdate m2C_RolePetBag = M2C_RolePetBagUpdate.Create();
            m2C_RolePetBag.RolePetBag = self.RolePetBag;
            m2C_RolePetBag.UpdateMode = 2;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_RolePetBag);
        }



        public static void OnRolePetFenjie(this PetComponentS self, long petId)
        {
            self.RemovePet(petId);

            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                self.UpdatePetAttribute(self.RolePetInfos[i], false);
            }

            M2C_PetListMessage m2C_PetListMessage = M2C_PetListMessage.Create();
            m2C_PetListMessage.PetList = self.RolePetInfos;
            m2C_PetListMessage.RemovePetId = petId;
            MapMessageHelper.SendToClient( self.GetParent<Unit>(), m2C_PetListMessage );
        }

        public static int GetMaxSkillNumber(this PetComponentS self)
        {
            int skillNumber = 0;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].PetSkill.Count > skillNumber)
                {
                    skillNumber = self.RolePetInfos[i].PetSkill.Count;
                }
            }
            return skillNumber;
        }
        
        public static int GetShenShouNumber(this PetComponentS self)
        {
            int shenshouNumber = 0;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (PetHelper.IsShenShou(self.RolePetInfos[i].ConfigId) )
                {
                    shenshouNumber++;
                }
            }
            return shenshouNumber;
        }

        public static int GetTotalStar(this PetComponentS self)
        {
            int star = 0;
            for (int i = 0; i < self.PetFubenInfos.Count; i++)
            {
                star += self.PetFubenInfos[i].Star;
            }

            return star;
        }

        /// <summary>
        /// 获取可以领取的最小星级奖励
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetCanRewardId(this PetComponentS self)
        {
            int rewardId = 0;
            int totalStar = self.GetTotalStar();
            List<PetFubenRewardConfig> rewardConfigs = PetFubenRewardConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < rewardConfigs.Count; i++)
            {
                if (rewardConfigs[i].NeedStar <= totalStar
                    && rewardConfigs[i].Id > self.PetFubeRewardId)
                {
                    rewardId = rewardConfigs[i].Id;
                    break;
                }
            }

            return rewardId;
        }

        public static int GetPetMeleeTotalStar(this PetComponentS self)
        {
            int star = 0;
            for (int i = 0; i < self.PetMeleeFubenInfos.Count; i++)
            {
                star += self.PetMeleeFubenInfos[i].Star;
            }

            return star;
        }

        public static void OnUnlockSkin(this PetComponentS self, string skininfo)
        {
            string[] petskininfo = skininfo.Split(';');
            int petId = int.Parse(petskininfo[0]);
            int skinId = int.Parse(petskininfo[1]);
        
            for (int p = 0; p < self.PetSkinList.Count; p++)
            {
                if (self.PetSkinList[p].KeyId != petId)
                {
                    //重复激活
                    continue;
                }
                if (!self.PetSkinList[p].Value.Contains(skinId.ToString()))
                {
                    self.PetSkinList[p].Value += ("_" + skinId.ToString());
                }
            }
        }

        public static void ResetFormation(this PetComponentS self, List<long> formation, long petId)
        {
            for (int i = 0; i < formation.Count; i++)
            {
                if (formation[i] == petId)
                {
                    formation[i] = 0;
                }
            }
        }

        /// <summary>
        /// 通关副本ID
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetPassMaxFubenId(this PetComponentS self)
        {
            int maxid = 0;
            for (int i = 0; i < self.PetFubenInfos.Count; i++)
            {
                if (self.PetFubenInfos[i].PetFubenId > maxid)
                {
                    maxid = self.PetFubenInfos[i].PetFubenId;
                }
            }

            return maxid;   
        }

        public static void OnPassPetFuben(this PetComponentS self, int petfubenId, int star)
        {
            for (int i = 0; i < self.PetFubenInfos.Count; i++)
            {
                if (self.PetFubenInfos[i].PetFubenId == petfubenId)
                {
                    self.PetFubenInfos[i].Star = star > self.PetFubenInfos[i].Star ? star : self.PetFubenInfos[i].Star;
                    return;
                }
            }

            PetFubenInfo PetFubenInfo = PetFubenInfo.Create();
            PetFubenInfo.PetFubenId = petfubenId;
            PetFubenInfo.Star = star;
            PetFubenInfo.Reward = 0;
            self.PetFubenInfos.Add( PetFubenInfo);
        }

        public static void OnPassPetMeleeFuben(this PetComponentS self, int petfubenId, int star)
        {
            for (int i = 0; i < self.PetMeleeFubenInfos.Count; i++)
            {
                if (self.PetMeleeFubenInfos[i].PetFubenId == petfubenId)
                {
                    self.PetMeleeFubenInfos[i].Star = star > self.PetMeleeFubenInfos[i].Star ? star : self.PetMeleeFubenInfos[i].Star;
                    return;
                }
            }

            PetMeleeFubenInfo petMeleeFubenInfo = PetMeleeFubenInfo.Create();
            petMeleeFubenInfo.PetFubenId = petfubenId;
            petMeleeFubenInfo.Star = star;
            petMeleeFubenInfo.Reward = 0;
            self.PetMeleeFubenInfos.Add(petMeleeFubenInfo);
        }

        public static void OnPetMingRecord(this PetComponentS self, PetMingRecord record)
        {
            if (self.PetMingRecordList.Count >= 10)
            {
                self.PetMingRecordList.RemoveAt(0);
            }
            self.PetMingRecordList.Add( record );
        }
        
        //判断当前宠物是否已满
        public static bool PetIsFull(this PetComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            int userLv = unit.GetComponent<UserInfoComponentS>().GetUserLv();
            int petextend = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetExtendNumber);
            if (PetHelper.GetBagPetNum(self.RolePetInfos) >= PetHelper.GetPetMaxNumber( userLv,petextend))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
