using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [EntitySystemOf(typeof(PetComponentC))]
    [FriendOf(typeof(PetComponentC))]
    public static partial class PetComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this PetComponentC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this PetComponentC self)
        {
        }

        public static void RequestAllPets(this PetComponentC self, M2C_RolePetList m2C_RolePetList)
        {
            self.RolePetInfos = m2C_RolePetList.RolePetInfos;
            self.TeamPetList = m2C_RolePetList.TeamPetList;
            self.RolePetEggs = m2C_RolePetList.RolePetEggs;
            self.PetFormations = m2C_RolePetList.PetFormations;
            self.PetFubenInfos = m2C_RolePetList.PetFubenInfos;
            self.PetFubeRewardId = m2C_RolePetList.PetFubeRewardId;
            self.PetSkinList = m2C_RolePetList.PetSkinList;
            self.PetShouHuList = m2C_RolePetList.PetShouHuList;
            self.PetShouHuActive = m2C_RolePetList.PetShouHuActive;
            self.PetCangKuOpen = m2C_RolePetList.PetCangKuOpen;
            self.PetMingList = m2C_RolePetList.PetMingList;
            self.PetMingPosition = m2C_RolePetList.PetMingPosition;
            self.RolePetBag = m2C_RolePetList.RolePetBag;
            self.PetFightPlan = m2C_RolePetList.PetFightPlan;
            self.PetFightList_1 = m2C_RolePetList.PetFightList_1;
            self.PetFightList_2 = m2C_RolePetList.PetFightList_2;
            self.PetFightList_3 = m2C_RolePetList.PetFightList_3;
            self.PetBarConfigList = m2C_RolePetList.PetBarConfigList;
            self.PetMeleePlan = m2C_RolePetList.PetMeleePlan;
            self.PetMeleeInfoList = m2C_RolePetList.PetMeleeInfoList;
            self.PetMeleeFubenInfos = m2C_RolePetList.PetMeleeFubenInfos;
            self.PetMeleeRewardIds = m2C_RolePetList.PetMeleeRewardIds;
            self.PetMeleeFubeRewardIds = m2C_RolePetList.PetMeleeFubeRewardIds;
            self.PetEchoList = m2C_RolePetList.PetEchoList;
            self.PetZhuangJiaList = m2C_RolePetList.PetZhuangJiaList;
        }

        public static void OnPetEchoOperate(this PetComponentC self, M2C_PetEchoOperateResponse m2C_RolePetList)
        {
            self.PetEchoList = m2C_RolePetList.PetEchoList;
        }

        public static void OnRecvRolePetUpdate(this PetComponentC self, M2C_RolePetUpdate m2C_RolePetUpdate)
        {
            RolePetInfo rolePetInfo = m2C_RolePetUpdate.PetInfoAdd[0];
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            self.OnUnlockSkin($"{rolePetInfo.ConfigId};{rolePetInfo.SkinId}");
            //self.OnUnlockSkin($"{rolePetInfo.ConfigId};{petConfig.Skin[0]}");

            self.RolePetInfos.AddRange(m2C_RolePetUpdate.PetInfoAdd);
        }

        public static int GetShenShouNumber(this PetComponentC self)
        {
            int shenshouNumber = 0;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (PetHelper.IsShenShou(self.RolePetInfos[i].ConfigId))
                {
                    shenshouNumber++;
                }
            }

            return shenshouNumber;
        }

        public static RolePetInfo GetPetInfoByID(this PetComponentC self, long petid)
        {
            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                if (self.RolePetInfos[i].Id == petid)
                {
                    return self.RolePetInfos[i];
                }
            }

            return null;
        }

        public static long GetFightPetId(this PetComponentC self)
        {
            RolePetInfo rolePetInfo = self.GetFightPet();
            return rolePetInfo != null ? rolePetInfo.Id : 0;
        }

        public static RolePetInfo GetFightPet(this PetComponentC self)
        {
            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                if (self.RolePetInfos[i].PetStatus == 1)
                {
                    return self.RolePetInfos[i];
                }
            }

            return null;
        }

        public static List<long> GetCanFightPetList(this PetComponentC self)
        {
            List<long> fightlist = new List<long>();
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].PetStatus == 0)
                {
                    fightlist.Add(self.RolePetInfos[i].Id);
                }

                if (fightlist.Count >= 3)
                {
                    break;
                }
            }

            return fightlist;
        }

        public static List<PetBarInfo> GetNowPetFightList(this PetComponentC self)
        {
            return self.PetFightPlan switch
            {
                0 => self.PetFightList_1,
                1 => self.PetFightList_2,
                2 => self.PetFightList_3,
                _ => null
            };
        }
        
        public static List<PetBarInfo> GetCanFightPetList2(this PetComponentC self)
        {
            List<PetBarInfo> fightlist = new List<PetBarInfo>();

            fightlist = self.GetNowPetFightList();

            // if (self.RolePetInfos.Count > 0)
            // {
            //     fightlist[0].PetId = self.RolePetInfos[0].Id;
            // }

            for (int i = 0; i < fightlist.Count; i++)
            {
                if (self.RolePetInfos.Count > i)
                {
                    fightlist[i].PetId = self.RolePetInfos[i].Id;
                }
            }

            return fightlist;
        }

        public static void RequestPetFormationSet(this PetComponentC self, int sceneType, List<long> petList, List<long> positionList)
        {
            switch (sceneType)
            {
                case MapTypeEnum.PetDungeon:
                    self.PetFormations = petList;
                    break;
                case MapTypeEnum.PetTianTi:
                    self.TeamPetList = petList;
                    break;
                case MapTypeEnum.PetMing:
                    self.PetMingList = petList;
                    self.PetMingPosition = positionList;
                    break;
                case MapTypeEnum.MainCityScene:
                    break;
            }
        }

        /// <summary>
        /// PetStatus = 0休息  1出战 2散步 3仓库
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetFightNumber(this PetComponentC self)
        {
            int fightnumber = 0;
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].PetStatus == 1)
                {
                    fightnumber += 1;
                }
            }

            return fightnumber;
        }

        public static void RequestPetFight(this PetComponentC self, long petId, int fight)
        {
            //出战要清掉之前的
            if (fight == 1)
            {
                RolePetInfo fightpet = self.GetFightPet();
                if (fightpet != null)
                {
                    fightpet.PetStatus = 0;
                }
            }

            RolePetInfo rolePetInfo = self.GetPetInfoByID(petId);
            rolePetInfo.PetStatus = fight;
        }

        public static void RequestUpStar(this PetComponentC self, long mainId, List<long> costIds, RolePetInfo rolePetInfo)
        {
            for (int i = 0; i < costIds.Count; i++)
            {
                self.RemovePet(costIds[i]);
            }

            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                if (self.RolePetInfos[i].Id == mainId)
                {
                    self.RolePetInfos[i] = rolePetInfo;
                }
            }
            //HintHelp.GetInstance().DataUpdate(DataType.PetUpStarUpdate, mainId.ToString());
        }

        public static void RemovePet(this PetComponentC self, long petId)
        {
            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                if (self.RolePetInfos[i].Id == petId)
                {
                    self.RolePetInfos.RemoveAt(i);
                    break;
                }
            }

            self.ResetFormation(self.PetFormations, petId);
            self.ResetFormation(self.TeamPetList, petId);
            self.ResetFormation(self.PetMingList, petId);
        }

        public static void ResetFormation(this PetComponentC self, List<long> formation, long petId)
        {
            for (int i = 0; i < formation.Count; i++)
            {
                if (formation[i] == petId)
                {
                    formation[i] = 0;
                }
            }
        }

        public static void RequestXiLian(this PetComponentC self, long itemId, long petId, RolePetInfo rolePetInfo)
        {
            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                if (self.RolePetInfos[i].Id == rolePetInfo.Id)
                {
                    self.RolePetInfos[i] = rolePetInfo;
                }
            }
        }

        public static void OnPetProtect(this PetComponentC self, long rolePetInfoId, bool isprotect)
        {
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                if (self.RolePetInfos[i].Id == rolePetInfoId)
                {
                    self.RolePetInfos[i].IsProtect = isprotect;
                }
            }
        }

        /// <summary>
        /// operateType 1上阵  2替换  3下阵 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rolePetInfoId"></param>
        /// <param name="index"></param>
        /// <param name="operateType"></param>
        public static void OnFormationSet(this PetComponentC self, long rolePetInfoId, int index, int operateType)
        {
            //index == -1 下阵
            if (operateType == 1)
            {
                for (int i = 0; i < self.PetFormations.Count; i++)
                {
                    if (self.PetFormations[i] == rolePetInfoId && i != index)
                    {
                        self.PetFormations[i] = 0;
                    }
                }

                self.PetFormations[index] = rolePetInfoId;
            }

            if (operateType == 2)
            {
                int oldIndex = -1;
                for (int i = 0; i < self.PetFormations.Count; i++)
                {
                    if (self.PetFormations[i] == rolePetInfoId)
                    {
                        oldIndex = i;
                    }
                }

                self.PetFormations[oldIndex] = self.PetFormations[index];
                self.PetFormations[index] = rolePetInfoId;
            }

            if (operateType == 3)
            {
                for (int i = 0; i < self.PetFormations.Count; i++)
                {
                    if (self.PetFormations[i] == rolePetInfoId)
                    {
                        self.PetFormations[i] = 0;
                    }
                }
            }
        }

        public static int GetPetFuben(this PetComponentC self)
        {
            int petfubenId = 0;
            for (int i = 0; i < self.PetFubenInfos.Count; i++)
            {
                if (self.PetFubenInfos[i].PetFubenId > petfubenId)
                {
                    petfubenId = self.PetFubenInfos[i].PetFubenId;
                }
            }

            return petfubenId;
        }

        public static int GetTotalStar(this PetComponentC self)
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
        public static int GetCanRewardId(this PetComponentC self)
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

        public static int GetFubenStar(this PetComponentC self, int petfubenId)
        {
            for (int i = 0; i < self.PetFubenInfos.Count; i++)
            {
                if (self.PetFubenInfos[i].PetFubenId == petfubenId)
                {
                    return self.PetFubenInfos[i].Star;
                }
            }

            return 0;
        }
        
        public static int GetPetMeleeTotalStar(this PetComponentC self)
        {
            int star = 0;
            for (int i = 0; i < self.PetMeleeFubenInfos.Count; i++)
            {
                star += self.PetMeleeFubenInfos[i].Star;
            }

            return star;
        }
        
        public static void OnRolePetUpdate(this PetComponentC self, RolePetInfo rolePetInfo)
        {
            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                if (self.RolePetInfos[i].Id == rolePetInfo.Id)
                {
                    self.RolePetInfos[i] = rolePetInfo;
                    break;
                }
            }
        }

        public static void OnPassPetFuben(this PetComponentC self, int petfubenId, int star)
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
            self.PetFubenInfos.Add(PetFubenInfo);
        }

        public static void OnPassPetMeleeFuben(this PetComponentC self, int petfubenId, int star)
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

        public static bool HavePetSkin(this PetComponentC self, int petId, int skinId)
        {
            for (int p = 0; p < self.PetSkinList.Count; p++)
            {
                if (self.PetSkinList[p].KeyId != petId)
                {
                    continue;
                }

                return self.PetSkinList[p].Value.Contains(skinId.ToString());
            }

            return false;
        }

        public static void OnUnlockSkin(this PetComponentC self, string skininfo)
        {
            string[] petskininfo = skininfo.Split(';');
            int petId = int.Parse(petskininfo[0]);
            int skinId = int.Parse(petskininfo[1]);

            for (int p = 0; p < self.PetSkinList.Count; p++)
            {
                if (self.PetSkinList[p].KeyId != petId)
                {
                    continue;
                }

                if (!self.PetSkinList[p].Value.Contains(skinId.ToString()))
                {
                    self.PetSkinList[p].Value += ("_" + skinId.ToString());
                }
            }
        }

        public static List<long> GetPetFormatList(this PetComponentC self, int sceneType)
        {
            if (sceneType == MapTypeEnum.PetDungeon)
            {
                return self.PetFormations;
            }

            if (sceneType == MapTypeEnum.PetTianTi)
            {
                return self.TeamPetList;
            }

            if (sceneType == MapTypeEnum.PetMing)
            {
                return self.PetMingList;
            }
            
            return null;
        }

        public static List<KeyValuePair> GetPetSkinCopy(this PetComponentC self)
        {
            List<KeyValuePair> keyValuePairs = new List<KeyValuePair>();
            for (int i = 0; i < self.RolePetInfos.Count; i++)
            {
                //keyValuePairs.Add(ComHelp.DeepCopy<KeyValuePair>(self.PetSkinList[i])) ;
                keyValuePairs.Add(new KeyValuePair() { KeyId = self.RolePetInfos[i].ConfigId, Value = self.RolePetInfos[i].SkinId.ToString() });
            }

            return keyValuePairs;
        }

        /// <summary>
        /// 宠物合成
        /// </summary>
        /// <param name="self"></param>c
        /// <returns></returns>
        public static void OnRecvHeCheng(this PetComponentC self, M2C_RolePetHeCheng m2C_RolePetHeCheng)
        {
            self.RemovePet(m2C_RolePetHeCheng.DeletePetInfoId);
            for (int i = self.RolePetInfos.Count - 1; i >= 0; i--)
            {
                if (self.RolePetInfos[i].Id == m2C_RolePetHeCheng.rolePetInfo.Id)
                {
                    self.RolePetInfos[i] = m2C_RolePetHeCheng.rolePetInfo;
                }
            }

            EventSystem.Instance.Publish(self.Root(), new PetHeChengUpdate());
        }
    }
}