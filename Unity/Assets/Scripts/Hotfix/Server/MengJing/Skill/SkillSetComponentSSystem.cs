using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(SkillSetComponentS))]
    [FriendOf(typeof(SkillSetComponentS))]
    public static partial class SkillSetComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this SkillSetComponentS self)
        {
            self.TianFuPlan = 0;
            self.TianFuList1.Clear();
            self.TianFuList2.Clear();

            if (self.SkillList.Count == 0)
            {
                int[] SkillList = OccupationConfigCategory.Instance.Get(self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetOcc()).InitSkillID;
                for (int i = 0; i < SkillList.Length; i++)
                {
                    if (i == 0)
                    {
                       self.InitSkillPro(SkillList[i], 1,SkillSetEnum.Skill,SkillSourceEnum.Skill  );
                    }
                    else
                    {
                        self.InitSkillPro(SkillList[i], 0,SkillSetEnum.Skill,SkillSourceEnum.Skill  );
                    }
                }

                string initItem = GlobalValueConfigCategory.Instance.Get(9).Value;
                string[] needList = initItem.Split('@');
                self.InitSkillPro(int.Parse(needList[0].Split(';')[0]), 9, SkillSetEnum.Item, SkillSourceEnum.Skill);

                self.InitSkillPro(int.Parse(needList[1].Split(';')[0]), 10, SkillSetEnum.Item, SkillSourceEnum.Skill);
            }

            int robotId = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetRobotId();
            if (robotId != 0)
            {
                RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
                self.OnChangeOccTwoRequest(robotConfig.OccTwo);
            }
        }
        
        [EntitySystem]
        private static void Destroy(this SkillSetComponentS self)
        {

        }
        [EntitySystem]
        private static void Deserialize(this SkillSetComponentS self)
        {

        }


        public static bool IfJuexXingSkill(this SkillSetComponentS self)
        {
            int juexingid = 0;
            Unit unit = self.GetParent<Unit>();
            int occtwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
            if (occtwo == 0)
            {
                return false;
            }

            OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtwo);
            juexingid = occupationConfig.JueXingSkill[7];
            return self.GetBySkillID(juexingid) != null;
        }

        public static List<KeyValuePairInt> TianFuList(this SkillSetComponentS self)
        {
            return self.TianFuPlan == 0 ? self.TianFuList1 : self.TianFuList2;
        }

        public static void TianFuReSet(this SkillSetComponentS self)
        {
            List<KeyValuePairInt> tianfus = self.TianFuList();
            foreach (KeyValuePairInt keyValuePairInt in tianfus)
            {
                self.AddTianFuAttribute(keyValuePairInt.KeyId, false, (int)keyValuePairInt.Value);
            }

            if (self.TianFuPlan == 0)
            {
                self.TianFuList1.Clear();
            }
            else
            {
                self.TianFuList2.Clear();
            }

            self.GetParent<Unit>().GetComponent<SkillPassiveComponent>().UpdatePassiveSkill();
            self.UpdateSkillSet();
        }

        public static List<KeyValuePairInt> TianFuListAll(this SkillSetComponentS self)
        {
            List<KeyValuePairInt> list = new List<KeyValuePairInt>();

            List<KeyValuePairInt> tianfulist = self.TianFuPlan == 0 ? self.TianFuList1 : self.TianFuList2;
            for (int i = 0; i < tianfulist.Count; i++)
            {
                list.Add(tianfulist[i]);
            }

            list.AddRange(self.TianFuAddition);
            return list;
        }

        public static int HaveSameTianFu(this SkillSetComponentS self, int tianfuId)
        {
            int tifuId = 0;
            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(tianfuId);
            int learnLv = talentConfig.LearnRoseLv;
            List<KeyValuePairInt> tianfuList = self.TianFuList();

            for (int i = 0; i < tianfuList.Count; i++)
            {
                TalentConfig talentConfig2 = TalentConfigCategory.Instance.Get(tianfuList[i].KeyId);
                if (talentConfig2.LearnRoseLv == learnLv)
                {
                    tifuId = tianfuList[i].KeyId;
                    break;
                }
            }
            return tifuId;
        }

        public static void TianFuRemove(this SkillSetComponentS self, int tianFuid)
        {
            List<KeyValuePairInt> tianfuIds = self.TianFuList1;
            foreach (KeyValuePairInt keyValuePairInt in tianfuIds)
            {
                if (tianFuid > 0 && keyValuePairInt.KeyId == tianFuid)
                {
                    tianfuIds.Remove(keyValuePairInt);
                    self.AddTianFuAttribute(keyValuePairInt.KeyId, false, (int)keyValuePairInt.Value);
                    break;
                }
            }

            tianfuIds = self.TianFuList2;
            foreach (KeyValuePairInt keyValuePairInt in tianfuIds)
            {
                if (tianFuid > 0 && keyValuePairInt.KeyId == tianFuid)
                {
                    tianfuIds.Remove(keyValuePairInt);
                    self.AddTianFuAttribute(keyValuePairInt.KeyId, false, (int)keyValuePairInt.Value);
                    break;
                }
            }
        }

        public static void TianFuAdd(this SkillSetComponentS self, int tianFuid)
        {
            List<KeyValuePairInt> tianfuIds = self.TianFuList();
            bool exist = tianfuIds.Any(keyValuePairInt => keyValuePairInt.KeyId == tianFuid);

            if (tianFuid > 0 && !exist)
            {
                KeyValuePairInt keyValuePairInt = new KeyValuePairInt() { KeyId = tianFuid, Value = 1 };
                tianfuIds.Add(keyValuePairInt);
                self.AddTianFuAttribute(keyValuePairInt.KeyId, true, (int)keyValuePairInt.Value);
            }
        }

        public static void AddiontTianFu(this SkillSetComponentS self, int tianFuid, bool active)
        {
            KeyValuePairInt tianFu = null;
            foreach (KeyValuePairInt keyValuePairInt in self.TianFuAddition)
            {
                if (keyValuePairInt.KeyId == tianFuid)
                {
                    tianFu = keyValuePairInt;
                }
            }

            if (tianFu != null && !active)
            {
                self.TianFuAddition.Remove(tianFu);
                self.AddTianFuAttribute(tianFu.KeyId, true, (int)tianFu.Value);
            }

            if (tianFu == null && active)
            {
                tianFu = new KeyValuePairInt() { KeyId = tianFuid, Value = 1 };
                self.TianFuAddition.Add(tianFu);
                self.AddTianFuAttribute(tianFu.KeyId, false, (int)tianFu.Value);
            }
        }


        public static void UpdateTianFuPlan(this SkillSetComponentS self, int plan)
        {
            self.TianFuPlan = plan;

            List<KeyValuePairInt> oldtianfus = plan == 0 ? self.TianFuList2 : self.TianFuList1;
            foreach (KeyValuePairInt keyValuePairInt in oldtianfus)
            {
                self.AddTianFuAttribute(keyValuePairInt.KeyId, false, (int)keyValuePairInt.Value);
            }

            List<KeyValuePairInt> newtianfus = plan == 0 ? self.TianFuList1 : self.TianFuList2;
            foreach (KeyValuePairInt keyValuePairInt in newtianfus)
            {
                self.AddTianFuAttribute(keyValuePairInt.KeyId, true, (int)keyValuePairInt.Value);
            }


            self.GetParent<Unit>().GetComponent<SkillPassiveComponent>().UpdatePassiveSkill();
            self.UpdateSkillSet();
        }

        /// <summary>
        /// �����츳����
        /// </summary>
        /// <param name="self"></param>
        /// <param name="tianfuId"></param>
        public static void AddTianFuAttribute(this SkillSetComponentS self, int tianfuId, bool add, int lv)
        {
            if (tianfuId == 0)
            {
                return;
            }

            if (lv <= 0)
            {
                return;
            }

            string[] propreByLv = TalentConfigCategory.Instance.Get(tianfuId).AddPropreListStr.Split("#");
            if (propreByLv.Length < lv)
            {
                return;
            }

            string[] addPropreListStr = propreByLv[lv - 1].Split("@");

            for (int k = 0; k < addPropreListStr.Length; k++)
            {
                string[] properInfo = addPropreListStr[k].Split(";");

                switch (properInfo[0])
                {
                    case TianFuProEnum.SkillIdAdd:
                        self.OnSkillIdAdd(properInfo, add);
                        break;
                    case TianFuProEnum.SkillPropertyAdd:
                        break;
                    case TianFuProEnum.BuffIdAdd:
                        break;
                    case TianFuProEnum.BuffInitIdAdd:
                        break;
                    case TianFuProEnum.RolePropertyAdd:
                        self.OnRolePropertyAdd(properInfo, add ? 1 : -1);
                        break;
                    case TianFuProEnum.ReplaceSkillId:
                        break;
                    case TianFuProEnum.BuffPropertyAdd:
                        break;
                }
            }
        }

        public static void OnSkillIdAdd(this SkillSetComponentS self, string[] properInfo, bool add)
        {
            int skillId = int.Parse(properInfo[1]);

            int index = -1;
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillID == skillId)
                {
                    index = i;
                }
            }
            if (add && index == -1)
            {
                self.InitSkillPro(skillId, 0,  SkillSetEnum.Skill,SkillSourceEnum.TianFu );
            }
            if (!add && index >= 0)
            {
                self.SkillList.RemoveAt(index);
            }
        }

        public static void OnRolePropertyAdd(this SkillSetComponentS self, string[] properInfo, int rate)
        {
            int numericKey = int.Parse(properInfo[1]);
            int valueType = NumericHelp.GetNumericValueType(numericKey);
            if (valueType == 1)
            {
                self.GetParent<Unit>().GetComponent<HeroDataComponentS>().BuffPropertyUpdate_Long(numericKey, long.Parse(properInfo[2]) * rate);
            }
            else
            {
                self.GetParent<Unit>().GetComponent<HeroDataComponentS>().BuffPropertyUpdate_Float(numericKey, float.Parse(properInfo[2]) * rate);
            }
        }

        public static List<PropertyValue> GetTianfuRoleProLists(this SkillSetComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            List<KeyValuePairInt> tianfuids = self.TianFuListAll();
            foreach (var keyValuePairInt in tianfuids)
            {
                TalentConfig talentConfig = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId);
                if (!string.IsNullOrEmpty(talentConfig.AddPropreListStr))
                {
                    string[] propreByLv = talentConfig.AddPropreListStr.Split("#");
                    if (propreByLv.Length < keyValuePairInt.Value)
                    {
                        continue;
                    }

                    string[] addPropreListStr = propreByLv[(int)keyValuePairInt.Value - 1].Split("@");

                    for (int k = 0; k < addPropreListStr.Length; k++)
                    {
                        string[] properInfo = addPropreListStr[k].Split(";");

                        if (!properInfo[0].Equals(TianFuProEnum.RolePropertyAdd))
                        {
                            continue;
                        }

                        if (NumericHelp.GetNumericValueType(int.Parse(properInfo[1])) == 1)
                        {
                            proList.Add(new PropertyValue() { HideID = int.Parse(properInfo[1]), HideValue = long.Parse(properInfo[2]) });
                        }
                        else
                        {
                            proList.Add(new PropertyValue() { HideID = int.Parse(properInfo[1]), HideValue = (int)(float.Parse(properInfo[2]) * 10000) });
                        }
                    }
                }
            }

            return proList;
        }

        public static List<PropertyValue> GetSkillRoleProLists(this SkillSetComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            for (int i = 0; i < self.SkillList.Count; i++)
            {
                if (self.SkillList[i].SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }
                if (!SkillConfigCategory.Instance.Contain(self.SkillList[i].SkillID))
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillList[i].SkillID);

                if (skillConfig.SkillType != (int)SkillTypeEnum.PassiveAddProSkill)
                {
                    continue;
                }

                string GameObjectParameter = skillConfig.GameObjectParameter;
                if (CommonHelp.IfNull(GameObjectParameter))
                {
                    continue;
                }

                string[] addProList = GameObjectParameter.Split(";");
                for (int p = 0; p < addProList.Length; p++)
                {
                    string[] addPro = addProList[p].Split(",");
                    if (addPro.Length < 2)
                    {
                        break;
                    }
                    int key = int.Parse(addPro[0]);
                    try
                    {
                        if (NumericHelp.GetNumericValueType(key) == 1)
                        {
                            proList.Add(new PropertyValue() { HideID = key, HideValue = long.Parse(addPro[1]) });
                        }
                        else
                        {
                            proList.Add(new PropertyValue() { HideID = key, HideValue = (int)(float.Parse(addPro[1]) * 10000) });
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"{ex.ToString()} {GameObjectParameter}");
                    }
                }
            }
            return proList;
        }
        
        public static List<PropertyValue> GetSkillRoleProLists_8(this SkillSetComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            for (int i = 0; i < self.SkillList.Count; i++)
            {
                if (self.SkillList[i].SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillList[i].SkillID);

                if (skillConfig.SkillType != (int)SkillTypeEnum.PassiveAddProSkillNoFight)
                {
                    continue;
                }

                string GameObjectParameter = skillConfig.GameObjectParameter;
                if (CommonHelp.IfNull(GameObjectParameter))
                {
                    continue;
                }

                string[] addProList = GameObjectParameter.Split(";");
                for (int p = 0; p < addProList.Length; p++)
                {
                    string[] addPro = addProList[p].Split(",");
                    if (addPro.Length < 2)
                    {
                        break;
                    }
                    int key = int.Parse(addPro[0]);
                    try
                    {
                        if (NumericHelp.GetNumericValueType(key) == 1)
                        {
                            proList.Add(new PropertyValue() { HideID = key, HideValue = long.Parse(addPro[1]) });
                        }
                        else
                        {
                            proList.Add(new PropertyValue() { HideID = key, HideValue = (int)(float.Parse(addPro[1]) * 10000) });
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"{ex.ToString()} {GameObjectParameter}");
                    }
                }
            }
            return proList;
        }

        public static List<KeyValuePairInt> GetTianFuIdsByType(this SkillSetComponentS self, string proType)
        {
            List<KeyValuePairInt> typeTianfus = new List<KeyValuePairInt>();
            List<KeyValuePairInt> tianfuIds = self.TianFuListAll();

            foreach (KeyValuePairInt keyValuePairInt in tianfuIds)
            {
                string[] propreByLv = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId).AddPropreListStr.Split("#");
                if (propreByLv.Length < keyValuePairInt.Value)
                {
                    continue;
                }

                string[] addPropreListStr = propreByLv[(int)keyValuePairInt.Value - 1].Split("@");
                
                for (int k = 0; k < addPropreListStr.Length; k++)
                {
                    string[] properInfo = addPropreListStr[k].Split(";");

                    if (properInfo[0] != proType)
                    {
                        continue;
                    }

                    if (!typeTianfus.Contains(keyValuePairInt))
                    {
                        typeTianfus.Add(keyValuePairInt);
                    }
                }
            }

            return typeTianfus;
        }

        public static Dictionary<int, float> GetSkillPropertyAdd(this SkillSetComponentS self, int skillId)
        {
            List<KeyValuePairInt> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.SkillPropertyAdd);
            if (tianfuids.Count == 0)
                return null;

            Dictionary<int, float> HideProList = new Dictionary<int, float>();

            foreach (KeyValuePairInt keyValuePairInt in tianfuids)
            {
                string[] propreByLv = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId).AddPropreListStr.Split("#");
                if (propreByLv.Length < keyValuePairInt.Value)
                {
                    continue;
                }

                string[] addPropreListStr = propreByLv[(int)keyValuePairInt.Value - 1].Split("@");
                
                for (int k = 0; k < addPropreListStr.Length; k++)
                {
                    string[] properInfo = addPropreListStr[k].Split(";");
                    if (!properInfo[0].Equals(TianFuProEnum.SkillPropertyAdd))
                    {
                        continue;
                    }

                    if (!properInfo[1].Contains(skillId.ToString()))
                    {
                        continue;
                    }

                    int key = int.Parse(properInfo[2]);
                    float value = float.Parse(properInfo[3]);
                    if (HideProList.ContainsKey(key))
                    {
                        HideProList[key] += value;
                    }
                    else
                    {
                        HideProList.Add(key, value);
                    }
                }
            }

            return HideProList;
        }

        public static bool IsSkillSingingCancel(this SkillSetComponentS self, int skillId)
        {
            List<KeyValuePairInt> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.SkillSingingCancel);
            if (tianfuids.Count == 0)
                return false;

            foreach (KeyValuePairInt keyValuePairInt in tianfuids)
            {
                string[] propreByLv = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId).AddPropreListStr.Split("#");
                if (propreByLv.Length < keyValuePairInt.Value)
                {
                    continue;
                }

                string[] addPropreListStr = propreByLv[(int)keyValuePairInt.Value - 1].Split("@");
                
                for (int k = 0; k < addPropreListStr.Length; k++)
                {
                    string[] properInfo = addPropreListStr[k].Split(";");

                    if (!properInfo[1].Contains(skillId.ToString()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static List<int> GetBuffIdAdd(this SkillSetComponentS self, int skillId)
        {
            List<KeyValuePairInt> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.BuffIdAdd);
            if (tianfuids.Count == 0)
                return null;

            List<int> addBuffs = new List<int>();
            foreach (KeyValuePairInt keyValuePairInt in tianfuids)
            {
                string[] propreByLv = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId).AddPropreListStr.Split("#");
                if (propreByLv.Length < keyValuePairInt.Value)
                {
                    continue;
                }

                string[] addPropreListStr = propreByLv[(int)keyValuePairInt.Value - 1].Split("@");
                
                for (int k = 0; k < addPropreListStr.Length; k++)
                {
                    string[] properInfo = addPropreListStr[k].Split(";");
                    if (!properInfo[0].Equals(TianFuProEnum.BuffIdAdd))
                    {
                        continue;
                    }

                    if (!properInfo[1].Contains(skillId.ToString()))
                    {
                        continue;
                    }

                    addBuffs.Add(int.Parse(properInfo[2]));
                }
            }

            return addBuffs;
        }

        public static List<int> GetBuffInitIdAdd(this SkillSetComponentS self, int skillId)
        {
            List<KeyValuePairInt> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.BuffInitIdAdd);
            if (tianfuids.Count == 0)
                return null;

            List<int> addBuffs = new List<int>();
            foreach (KeyValuePairInt keyValuePairInt in tianfuids)
            {
                string[] propreByLv = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId).AddPropreListStr.Split("#");
                if (propreByLv.Length < keyValuePairInt.Value)
                {
                    continue;
                }

                string[] addPropreListStr = propreByLv[(int)keyValuePairInt.Value - 1].Split("@");
                
                for (int k = 0; k < addPropreListStr.Length; k++)
                {
                    string[] properInfo = addPropreListStr[k].Split(";");
                    if (!properInfo[0].Equals(TianFuProEnum.BuffInitIdAdd))
                    {
                        continue;
                    }

                    if (!properInfo[1].Contains(skillId.ToString()))
                    {
                        continue;
                    }

                    addBuffs.Add(int.Parse(properInfo[2]));
                }
            }

            return addBuffs;
        }

        public static int GetReplaceSkillId(this SkillSetComponentS self, int skillId)
        {
            List<KeyValuePairInt> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.ReplaceSkillId);
            if (tianfuids.Count == 0)
                return 0;

            foreach (KeyValuePairInt keyValuePairInt in tianfuids)
            {
                string[] propreByLv = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId).AddPropreListStr.Split("#");
                if (propreByLv.Length < keyValuePairInt.Value)
                {
                    continue;
                }

                string[] addPropreListStr = propreByLv[(int)keyValuePairInt.Value - 1].Split("@");
                
                for (int k = 0; k < addPropreListStr.Length; k++)
                {
                    string[] properInfo = addPropreListStr[k].Split(";");
                    if (!properInfo[0].Equals(TianFuProEnum.ReplaceSkillId))
                    {
                        continue;
                    }

                    if (properInfo[1] != skillId.ToString())
                    {
                        continue;
                    }

                    return int.Parse(properInfo[2]);
                }
            }

            return 0;
        }

        public static Dictionary<int, float> GetBuffPropertyAdd(this SkillSetComponentS self, int buffId)
        {
            List<KeyValuePairInt> tianfuids = self.GetTianFuIdsByType(TianFuProEnum.BuffPropertyAdd);
            if (tianfuids.Count == 0)
                return null;

            Dictionary<int, float> HideProList = new Dictionary<int, float>();

            foreach (KeyValuePairInt keyValuePairInt in tianfuids)
            {
                string[] addPropreListStr =
                        TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId).AddPropreListStr.Split("#")[keyValuePairInt.Value - 1].Split("@");
                for (int k = 0; k < addPropreListStr.Length; k++)
                {
                    string[] properInfo = addPropreListStr[k].Split(";");
                    if (!properInfo[0].Equals(TianFuProEnum.BuffPropertyAdd))
                    {
                        continue;
                    }

                    if (!properInfo[1].Contains(buffId.ToString()))
                    {
                        continue;
                    }

                    try
                    {
                        int key = int.Parse(properInfo[2]);
                        float value = float.Parse(properInfo[3]);
                        if (HideProList.ContainsKey(key))
                        {
                            HideProList[key] += value;
                        }
                        else
                        {
                            HideProList.Add(key, value);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"GetBuffPropertyAdd: {keyValuePairInt.KeyId}: " + ex.ToString());
                    }
                }
            }

            return HideProList;
        }

        public static SkillPro InitSkillPro(this SkillSetComponentS self, int skillid, int position, int skillsetenum, int skillsource)
        {
            SkillPro skillPro = SkillPro.Create();
            skillPro.SkillID = skillid;
            skillPro.SkillPosition = position;
            skillPro.SkillSetType = skillsetenum;
            skillPro.SkillSource = skillsource;
            self.SkillList.Add(skillPro);
            return skillPro;
        }

        public static void OnChangeOccTwoRequest(this SkillSetComponentS self, int occTwo)
        {
            if (occTwo == 0)
            {
                return;
            }
            Unit unit = self.GetParent<Unit>();
         
            unit.GetComponent<UserInfoComponentS>().UserInfo.OccTwo = occTwo;
            OccupationTwoConfig occupationTwoConfig = OccupationTwoConfigCategory.Instance.Get(occTwo);
            int[] addSkills = occupationTwoConfig.SkillID;
            for (int i = 0; i < addSkills.Length; i++)
            {
                self.InitSkillPro( addSkills[i], 0, SkillSetEnum.Skill,  SkillSourceEnum.Skill );
            }

            if (!unit.GetComponent<UserInfoComponentS>().IsRobot())
            {
                self.UpdateSkillSet();
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                unit.GetComponent<SkillPassiveComponent>().UpdatePassiveSkill();
            }
        }


        public static List<int> GetJueSkillIds(this SkillSetComponentS self)
        {
            List<int> ids = new List<int>();

            int occtweo = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetOccTwo();
            if (occtweo == 0)
            {
                return ids;
            }

            OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtweo);
            int[] juexingids = occupationConfig.JueXingSkill;

            for (int i = 0; i < juexingids.Length; i++)
            {
                if (self.GetBySkillID(juexingids[i]) != null)
                {
                    ids.Add(juexingids[i]);
                }
            }

            return ids;
        }

        public static void OnAddkillId(this SkillSetComponentS self, int skillId, int position, int skillsetenum, int skillsource, bool notice)  
        {
            if (self.GetBySkillID(skillId) != null)
            {
                return;
            }
            
            Unit unit = self.GetParent<Unit>();
            self.InitSkillPro(skillId, position, skillsetenum, skillsource);
            unit.GetComponent<SkillPassiveComponent>().AddPassiveSkill(skillId);
            self.CheckSkillTianFu(skillId, true);

            if (notice)
            {
                self.UpdateSkillSet();
            }
        }
        
        public static void OnRemoveSkillId(this SkillSetComponentS self, int skillId, int source, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            SkillPassiveComponent skillPassiveComponent = unit.GetComponent<SkillPassiveComponent>();
            for (int k = self.SkillList.Count - 1; k >= 0; k--)
            {
                
                if (self.SkillList[k].SkillID == skillId && (source == -1 || source ==  self.SkillList[k].SkillSource))
                {
                    skillPassiveComponent.RemovePassiveSkill(skillId);
                    self.CheckSkillTianFu(skillId, false);
                    self.SkillList.RemoveAt(k);
                    break;
                }
            }

            if (notice)
            {
                self.UpdateSkillSet();
            }
        }
        
        public static void OnAddEquipSkill(this SkillSetComponentS self, List<int> itemSkills)
        {
            for (int i = 0; i < itemSkills.Count; i++)
            {
                int skillId = itemSkills[i];
                if (skillId == 0)
                {
                    continue;
                }

                self.OnAddkillId(skillId, 0, SkillSetEnum.Skill, SkillSourceEnum.Equip, false);
            }
            
            self.UpdateSkillSet();
        }

        public static void OnRemoveEquipSkill(this SkillSetComponentS self, List<int> itemSkills, long baginfoid)
        {
            Unit unit = self.GetParent<Unit>();
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            SkillPassiveComponent skillPassiveComponent = unit.GetComponent<SkillPassiveComponent>();
            for (int i = 0; i < itemSkills.Count; i++)
            {
                int skillId = itemSkills[i];
                if (skillId == 0)
                {
                    continue;
                }
                
                if (bagComponent.IsHaveEquipSkill(skillId, baginfoid))
                {
                    continue;
                }
   
                self.OnRemoveSkillId(skillId, SkillSourceEnum.Equip, false);
            }
            
            self.UpdateSkillSet();
        }

        
        public static void CheckSkillTianFu(this SkillSetComponentS self, int skillId, bool active)
        {
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            if (skillConfig.SkillType == 1 || !SkillHelp.havePassiveSkillType(skillConfig.PassiveSkillType, 11))
            {
                return;
            }
            int tianfuid = int.Parse(skillConfig.ComObjParameter);
            self.AddiontTianFu(tianfuid, active);
        }
        
        public static void OnActiveTianfu(this SkillSetComponentS self, int tianfuId)
        {
            bool exist = false;
            List<KeyValuePairInt> tianfuList = self.TianFuList();
            foreach (KeyValuePairInt keyValuePairInt in tianfuList)
            {
                if (tianfuId == keyValuePairInt.KeyId)
                {
                    TalentConfig talentConfig = TalentConfigCategory.Instance.Get(tianfuId);
                    if (keyValuePairInt.Value >= talentConfig.Lv)
                    {
                        // 已经达到最大等级
                        return;
                    }

                    exist = true;
                    self.AddTianFuAttribute(keyValuePairInt.KeyId, false, (int)keyValuePairInt.Value);
                    keyValuePairInt.Value++;
                    self.AddTianFuAttribute(keyValuePairInt.KeyId, true, (int)keyValuePairInt.Value);
                    break;
                }
            }

            if (!exist)
            {
                KeyValuePairInt keyValuePairInt = new KeyValuePairInt() { KeyId = tianfuId, Value = 1 };
                tianfuList.Add(keyValuePairInt);
                self.AddTianFuAttribute(keyValuePairInt.KeyId, true, (int)keyValuePairInt.Value);
            }

            self.UpdateSkillSet();
            self.GetParent<Unit>().GetComponent<SkillPassiveComponent>().UpdatePassiveSkill();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillid"></param>
        public static void OnJueXing(this SkillSetComponentS self, int skillid)
        {
            self.OnAddEquipSkill(new List<int>() { skillid });
        }

        public static void CheckInitSkill(this SkillSetComponentS self, int occ)
        {
            int[] SkillList = OccupationConfigCategory.Instance.Get(occ).InitSkillID;
            for (int i = SkillList.Length - 1; i >= 0 ; i--)
            {
                if (!SkillConfigCategory.Instance.Contain(SkillList[i]))
                {
                    Console.WriteLine($"技能未配置：ID{SkillList[i]}");
                    continue;
                }

                if (self.GetBySkillID(SkillList[i])  == null)
                {
                     self.InitSkillPro(SkillList[i], 0,SkillSetEnum.Skill,SkillSourceEnum.Skill  );
                }
            }            
        }

        public static void OnLogin(this SkillSetComponentS self, int occ)
        {
            for (int k = self.SkillList.Count - 1; k >= 0; k--)
            {
                switch (self.SkillList[k].SkillSetType)
                {
                    case SkillSetEnum.None:
                    case SkillSetEnum.Skill:
                        {
                            if (!SkillConfigCategory.Instance.Contain(self.SkillList[k].SkillID))
                            {
                                self.SkillList.RemoveAt(k);
                            }
                            break;
                        }
                    case SkillSetEnum.Item:
                        {
                            if (!ItemConfigCategory.Instance.Contain(self.SkillList[k].SkillID))
                            {
                                self.SkillList.RemoveAt(k);
                            }
                            break;
                        }
                }
            }

            if (occ == 3)
            {
                for (int k = self.SkillList.Count - 1; k >= 0; k--)
                {
                    int skillId = self.SkillList[k].SkillID;
                    if (ConfigData.HunterFarSkill.Contains(skillId)
                        || ConfigData.HunterNearSkill.Contains(skillId))
                    {
                        self.SkillList.RemoveAt(k);
                    }
                }

                int equipIndex = 0;
                List<int> addskills = equipIndex == 0 ? ConfigData.HunterFarSkill: ConfigData.HunterNearSkill;
                for (int i = 0; i < addskills.Count; i++)
                {
                     self.InitSkillPro(addskills[i], 0, (int)SkillSetEnum.Skill, (int)SkillSourceEnum.Equip);
                }
            }
        }

        public static void OnChangeEquipIndex(this SkillSetComponentS self, int equipIndex)
        {
            self.OnRemoveEquipSkill(ConfigData.HunterFarSkill, 0);
            self.OnRemoveEquipSkill(ConfigData.HunterNearSkill, 0);
            self.OnAddEquipSkill(equipIndex == 0 ? ConfigData.HunterFarSkill: ConfigData.HunterNearSkill   );
        }

        /// <summary>
        /// ����װ��
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bagInfo"></param>
        public static void OnTakeOffEquip(this SkillSetComponentS self, int ItemLocBag, ItemInfo bagInfo, long baginfoid = 0)
        {
            if (ItemLocBag != ItemLocType.ItemLocEquip
                && ItemLocBag != ItemLocType.ItemLocEquip_2
                && ItemLocBag != ItemLocType.SeasonJingHe)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            List<int> itemSkills = ItemHelper.GetItemSkill(itemConfig.SkillID);

            itemSkills.AddRange(bagInfo.HideSkillLists);
            itemSkills.AddRange(bagInfo.InheritSkills);
            self.OnRemoveEquipSkill(itemSkills, baginfoid);

            EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID);
            self.TianFuRemove(equipConfig.TianFuId);
        }

        /// <summary>
        /// ����װ��
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bagInfo"></param>
        public static void OnWearEquip(this SkillSetComponentS self, ItemInfo bagInfo)
        {
            if (bagInfo.Loc != (int)ItemLocType.ItemLocEquip
                && bagInfo.Loc != (int)ItemLocType.ItemLocEquip_2
                && bagInfo.Loc != (int)ItemLocType.SeasonJingHe)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            List<int> itemSkills = ItemHelper.GetItemSkill(itemConfig.SkillID);

            itemSkills.AddRange(bagInfo.HideSkillLists);
            itemSkills.AddRange(bagInfo.InheritSkills);
            self.OnAddEquipSkill(itemSkills);

            EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID);
            self.TianFuAdd(equipConfig.TianFuId);
        }

        public static int SetSkillIdByPosition(this SkillSetComponentS self, C2M_SkillSet request)
        {
            SkillPro newSkill = null;
            if (request.SkillType == 1) //
            {
                SkillPro oldSkill = self.GetByPosition(request.Position);
                if (oldSkill != null)
                {
                    oldSkill.SkillPosition = 0;
                }
                newSkill = self.GetBySkillID(request.SkillID);

                if (newSkill == null)
                {
                    Log.Warning($"newSkill == null:  {request.SkillID}");
                    return ErrorCode.ERR_ModifyData;
                }
            }
            else    
            {
                SkillPro oldSkill = self.GetByPosition(request.Position);
                if (oldSkill != null)
                {
                    oldSkill.SkillID = 0;
                    oldSkill.SkillPosition = 0;
                }
                newSkill = self.GetBySkillID(request.SkillID);
                if (newSkill == null)
                {
                    newSkill = SkillPro.Create();
                    self.SkillList.Add(newSkill);
                    Console.WriteLine($"SetSkillIdByPosition== null:  {request.SkillID}");
                }
            }
            newSkill.SkillID = request.SkillID;
            newSkill.SkillPosition = request.Position;
            newSkill.SkillSetType = request.SkillType;

            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillID == 0)
                {
                    self.SkillList.RemoveAt(i);
                }
            }
            return ErrorCode.ERR_Success;
        }

        public static SkillPro GetBySkillID(this SkillSetComponentS self, int skillid)
        {
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillID == skillid)
                {
                    return self.SkillList[i];
                }
            }
            return null;
        }

        public static SkillPro GetByPosition(this SkillSetComponentS self, int pos)
        {
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillPosition == pos)
                {
                    return self.SkillList[i];
                }
            }
            return null;
        }
        
        /// <summary>
        /// ���õڶ�ְҵ
        /// </summary>
        /// <param name="self"></param>
        public static int OnOccReset(this SkillSetComponentS self)
        {
            int sp = 0;
            List<int> skilllist = new List<int>();
            UserInfoComponentS userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentS>();
            if (userInfoComponent.GetOccTwo() != 0)
            {
                int[] twoskill = OccupationTwoConfigCategory.Instance.Get(userInfoComponent.GetOccTwo()).SkillID;
                skilllist.AddRange(twoskill);
            }

            for (int i = 0; i < skilllist.Count; i++)
            {
                int skillId = skilllist[i];
                int whileNumber = 0;

                while (skillId != 0)
                {
                    whileNumber++;
                    if (whileNumber >= 100)
                    {
                        Log.Error("whileNumber >= 100");
                        break;
                    }

                    try
                    {

                        SkillPro skillPro = self.GetBySkillID(skillId);
                        if (skillPro != null)
                        {
                            self.SkillList.Remove(skillPro);
                            break;
                        }
                        SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
                        int nextId = skillConfig.NextSkillID;
                        if (nextId != 0)
                        {
                            sp += skillConfig.CostSPValue;
                        }
                        skillId = nextId;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                    }
                }
            }
            userInfoComponent.SetOccTwo(0);

            self.UpdateSkillSet();
            return sp;
        }

        public static List<PropertyValue> GetShieldProLists(this SkillSetComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            for (int i = 0; i < self.LifeShieldList.Count; i++)
            {
                if (self.LifeShieldList[i].Level == 0)
                {
                    continue;
                }

                int lifeShiledid = LifeShieldConfigCategory.Instance.GetShieldId(self.LifeShieldList[i].ShieldType, self.LifeShieldList[i].Level);
                if (lifeShiledid == 0)
                {
                    continue;
                }

                LifeShieldConfig lifeShieldConfig = LifeShieldConfigCategory.Instance.Get(lifeShiledid);
                string[] attributeInfoList = lifeShieldConfig.AddProperty.Split('@');
                for (int a = 0; a < attributeInfoList.Length; a++)
                {
                    string[] attributeInfo = attributeInfoList[a].Split(';');
                    if (attributeInfo.Length != 2)
                    {
                        continue;
                    }
                    try
                    {
                        int numericType = int.Parse(attributeInfo[0]);
                        if (NumericHelp.GetNumericValueType(numericType) == 2)
                        {
                            float fvalue = float.Parse(attributeInfo[1]);
                            proList.Add(new PropertyValue() { HideID = numericType, HideValue = (long)(fvalue * 10000) });
                        }
                        else
                        {
                            long lvalue = 0;
                            try
                            {
                                lvalue = long.Parse(attributeInfo[1]);
                            }
                            catch (Exception ex)
                            {
                                Log.Debug(ex.ToString() + $"����LifeShield: {lifeShiledid}");
                            }

                            proList.Add(new PropertyValue() { HideID = numericType, HideValue = lvalue });
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                    }
                }
            }
            return proList;
        }

        public static List<LifeShieldInfo> GetLifeShieldList(this SkillSetComponentS self)
        {
            return self.LifeShieldList;
        }

        public static void OnShieldAddExp(this SkillSetComponentS self, int shieldType, int addExp)
        {
            LifeShieldInfo keyValuePair = null;
            for (int i = 0; i < self.LifeShieldList.Count; i++)
            {
                if ((int)self.LifeShieldList[i].ShieldType == shieldType)
                {
                    keyValuePair = self.LifeShieldList[i];
                }
            }
            if (keyValuePair == null)
            {
                keyValuePair = LifeShieldInfo.Create();
                keyValuePair.ShieldType = shieldType;
                keyValuePair.Level = 0;
                keyValuePair.Exp = 0;
                self.LifeShieldList.Add(keyValuePair);
            }

            int curLv = keyValuePair.Level;
            int curExp = keyValuePair.Exp;
            int maxLv = LifeShieldConfigCategory.Instance.LifeShieldList[shieldType].Count;
            if (curLv == maxLv)
            {
                curExp += addExp;
                keyValuePair.Exp = curExp;
                return;
            }

            int nextlifeId = LifeShieldConfigCategory.Instance.LifeShieldList[shieldType][curLv + 1];
            LifeShieldConfig lifeShieldConfig = LifeShieldConfigCategory.Instance.Get(nextlifeId);
            if (curExp + addExp < lifeShieldConfig.ShieldExp)
            {
                curExp += addExp;
                keyValuePair.Exp = curExp;
                return;
            }
            
            keyValuePair.Level = (curLv + 1);
            keyValuePair.Exp = (curExp + addExp - lifeShieldConfig.ShieldExp);
        }

        /// <summary>
        /// ����֮��֮���������С�ȼ�
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetOtherMinLevel(this SkillSetComponentS self)
        {
            int minLevel = 0;
            for (int i = 0; i < self.LifeShieldList.Count; i++)
            {
                if ((int)self.LifeShieldList[i].ShieldType == 6)
                {
                    continue;
                }
                if (minLevel == 0 || self.LifeShieldList[i].Level < minLevel)
                {
                    minLevel = self.LifeShieldList[i].Level;
                }
            }
            return minLevel;
        }

        public static int GetLifeShieldLevel(this SkillSetComponentS self, int sType)
        {
            for (int i = 0; i < self.LifeShieldList.Count; i++)
            {
                if ((int)self.LifeShieldList[i].ShieldType == sType)
                {
                    return self.LifeShieldList[i].Level;
                }
            }
            return 0;
        }

        /// <summary>
        /// ���ü��ܵ�
        /// </summary>
        /// <param name="self"></param>
        public static void OnSkillReset(this SkillSetComponentS self)
        {
            List<int> skilllist = new List<int>();
            UserInfoComponentS userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentS>();
            int[] initskill = OccupationConfigCategory.Instance.Get(userInfoComponent.GetOcc()).InitSkillID;
            int[] baseSkill = OccupationConfigCategory.Instance.Get(userInfoComponent.GetOcc()).BaseSkill;
            skilllist.AddRange(initskill);
            skilllist.AddRange(baseSkill);
            if (userInfoComponent.GetOccTwo() != 0)
            {
                int[] twoskill = OccupationTwoConfigCategory.Instance.Get(userInfoComponent.GetOccTwo()).ShowTalentSkill;
                skilllist.AddRange(twoskill);
            }

            for (int i = 0; i < skilllist.Count; i++)
            {
                int skillId = skilllist[i];
                int whileNumber = 0;

                while (skillId != 0)
                {
                    whileNumber++;
                    if (whileNumber >= 100)
                    {
                        Log.Error("whileNumber >= 100");
                        break;
                    }

                    try
                    {
                        SkillPro skillPro = self.GetBySkillID(skillId);
                        if (skillPro != null)
                        {
                            skillPro.SkillID = skilllist[i];
                            skillPro.SkillPosition = 0;
                            break;
                        }
                        skillId = SkillConfigCategory.Instance.Get(skillId).NextSkillID;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                    }
                }
            }

            self.UpdateSkillSet();
        }

        public static void UpdatePetEchoSkill(this SkillSetComponentS self, int totalcombat)
        {
            List<int> openlist = new List<int>();
            for (int i = 0; i < ConfigData.PetEchoSkill.Count; i++)
            {
                if (ConfigData.PetEchoSkill[i].KeyId <= totalcombat)
                {
                    openlist.Add((int)ConfigData.PetEchoSkill[i].Value);
                }
            }
            
            List<int> remlist = new List<int>();    
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                SkillPro skillPro = self.SkillList[i];
                if (skillPro.SkillSource != SkillSourceEnum.PetEcho)
                {
                    continue;
                }

                if (!openlist.Contains(skillPro.SkillID))
                {
                    remlist.Add(skillPro.SkillID);
                }

                if (openlist.Contains(skillPro.SkillID))
                {
                    openlist.Remove(skillPro.SkillID);  
                }
            }

            foreach (int skillid in remlist)
            {
                self.OnRemoveSkillId(skillid, SkillSourceEnum.PetEcho, false );
            }
            foreach (int skillid in openlist)
            {
                self.InitSkillPro(skillid, 0, SkillSetEnum.Skill, SkillSourceEnum.PetEcho);
            }
            self.UpdateSkillSet();
        }

        public static void UpdateSkillSet(this SkillSetComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            M2C_SkillSetMessage M2C_SkillSetMessage = M2C_SkillSetMessage.Create();
            M2C_SkillSetMessage.SkillSetInfo = ET.SkillSetInfo.Create();

            SkillSetInfo SkillSetInfo = M2C_SkillSetMessage.SkillSetInfo;
            SkillSetInfo.TianFuPlan = self.TianFuPlan;
            SkillSetInfo.TianFuList1 = self.TianFuList1;
            SkillSetInfo.TianFuList2 = self.TianFuList2;
            SkillSetInfo.SkillList = self.SkillList;
            SkillSetInfo.LifeShieldList = self.LifeShieldList;
            MapMessageHelper.SendToClient(unit, M2C_SkillSetMessage);
        }
        
        public static List<SkillPro> GetSkillList(this SkillSetComponentS self)
        {
            return self.SkillList;
        }
    }

}