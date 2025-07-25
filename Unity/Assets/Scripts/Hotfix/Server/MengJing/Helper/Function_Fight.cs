using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [FriendOf(typeof(SkillHandlerS))]
    [FriendOf(typeof(NumericComponentS))]
    [FriendOf(typeof(UserInfoComponentS))]
    [FriendOf(typeof(PetComponentS))]
    public static class Function_Fight
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attackUnit"></param>
        /// <param name="defendUnit"></param>
        /// <param name="skillHandlerS"></param>
        /// <param name="hurtMode">0 默认 1持续伤害</param>
        /// <returns></returns>
        public static bool Fight(Unit attackUnit, Unit defendUnit, SkillS skillHandlerS, int hurtMode)
        {
            if (defendUnit.IsDisposed)
            {
                return false;
            }

            SkillConfig skillconfig = skillHandlerS.SkillConf;
            //吟唱进度
            float singingvalue = 1;
            //蓄力技能计算伤害
            if (skillconfig.SkillType == 1 && SkillHelp.havePassiveSkillType(skillconfig.PassiveSkillType, 2))
            {
                singingvalue = skillHandlerS.SkillInfo.SingValue;
                if (singingvalue < 0.3f)
                {
                    singingvalue = 0.3f;
                }
            }
            
            float buffHurtValueAdd = 0f;
            // Buff层数触发技能  buffid 1 技能ID 触发间隔
            if (SkillConfigCategory.Instance.BuffTriggerSkill.ContainsKey(skillconfig.Id))
            {
                KeyValuePairLong4 keyValuePairLong = SkillConfigCategory.Instance.BuffTriggerSkill[skillconfig.Id];
                List<EntityRef<Unit>> allDefend = attackUnit.GetParent<UnitComponent>().GetAll();
                for ( int defend = 0; defend < allDefend.Count; defend++  )
                {
                    Unit dUnit = allDefend[defend];
                    BuffManagerComponentS buffManagerComponent = dUnit.GetComponent<BuffManagerComponentS>();
                    if (buffManagerComponent == null)
                    {
                        continue;
                    }
                    int buffNum = buffManagerComponent.GetBuffSourceNumber(attackUnit.Id, (int)keyValuePairLong.KeyId);
                    if (buffNum <= 0)
                    {
                        continue;
                    }

                    if (keyValuePairLong.Value3 == 0)
                    {
                        dUnit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, (int)keyValuePairLong.KeyId);
                    }
                    attackUnit.GetComponent<SkillManagerComponentS>().TriggerBuffSkill(keyValuePairLong, dUnit.Id, buffNum).Coroutine();
                }
            }

            // Buff层数叠加伤害  buffid 2 层数  附加伤害系数
            if (SkillConfigCategory.Instance.BuffAddHurt.ContainsKey(skillconfig.Id))
            {
                KeyValuePairLong4 keyValuePairLong = SkillConfigCategory.Instance.BuffAddHurt[skillconfig.Id];
                int buffId = (int)keyValuePairLong.KeyId;
                int buffNum = defendUnit.GetComponent<BuffManagerComponentS>().GetBuffSourceNumber(0, buffId);
                if(buffNum > 0)
                {
                    defendUnit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, (int)keyValuePairLong.KeyId);
                    buffHurtValueAdd = keyValuePairLong.Value2 * 0.001f * buffNum;
                
                    singingvalue += buffHurtValueAdd;
                }
                singingvalue += buffHurtValueAdd;
            }

            //闪电链增加的伤害
            float chainLightningAddValue = skillHandlerS.HurtAddPro;

            //设置PK状态
            bool playerPKStatus = false;
            if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Player)
            {
                playerPKStatus = true;
            }

            if (attackUnit.Type == UnitType.Monster && attackUnit.GetMasterId() > 0 && defendUnit.Type == UnitType.Player)
            {
                playerPKStatus = true;
            }
            
            //已死亡
            if (defendUnit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) == 1)
            {
                return false;
            }
            //无敌buff，不受伤害
          
            if (defendUnit.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.WuDi))
            {
                return false;
            }
            
            // 悬空buff，不受伤害
            if (defendUnit.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.Hung))
            {
                return false;
            }
            //对怪无敌
            if (defendUnit.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.WuDiMonster) && playerPKStatus == false)
            {
                return false;
            }
            
            //99002002 角斗场免伤状态
            int sceneType = defendUnit.Scene().GetComponent<MapComponent>().MapType;
            if (sceneType == MapTypeEnum.Arena && attackUnit.GetComponent<BuffManagerComponentS>().GetBuffSourceNumber(0, 99002002) > 0)
            {
                return false;
            }
            
            if (attackUnit.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.MiaoSha))
            {
                long hp = defendUnit.GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_Hp) + 1;
                defendUnit.GetComponent<NumericComponentS>().ApplyChange(NumericType.Now_Hp, hp * -1, skillId: skillconfig.Id, attackid: attackUnit.Id);
                return true;
            }

            int DamgeType = 0;      //伤害类型
            defendUnit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.BeHurt_3, attackUnit.Id);
            defendUnit.GetComponent<BuffManagerComponentS>()?.BuffRemoveType(2);
            
            //获取攻击方属性
            NumericComponentS numericComponentAttack = attackUnit.GetComponent<NumericComponentS>();
            long attack_Hp = numericComponentAttack.GetAsLong(NumericType.Now_Hp);
            long attack_MaxHp = numericComponentAttack.GetAsLong(NumericType.Now_MaxHp);
            long attack_MinAct = numericComponentAttack.GetAsLong(NumericType.Now_MinAct);
            long attack_MaxAct = numericComponentAttack.GetAsLong(NumericType.Now_MaxAct);
            long attack_MageAct = numericComponentAttack.GetAsLong(NumericType.Now_Mage);
            long attack_MinDef = numericComponentAttack.GetAsLong(NumericType.Now_MinDef);
            long attack_MaxDef = numericComponentAttack.GetAsLong(NumericType.Now_MaxDef);

            float attackPet_hit = 0;
            float attackPet_cri = 0;
            
            //当前幸运
            int nowluck = numericComponentAttack.GetAsInt(NumericType.Now_Luck);
            float luckPro = 0;
            switch (nowluck)
            {
                case 0:
                    luckPro = 0.01f;
                    break;
                case 1:
                    luckPro = 0.02f;
                    break;
                case 2:
                    luckPro = 0.04f;
                    break;
                case 3:
                    luckPro = 0.08f;
                    break;
                case 4:
                    luckPro = 0.12f;
                    break;
                case 5:
                    luckPro = 0.2f;
                    break;
                case 6:
                    luckPro = 0.3f;
                    break;
                case 7:
                    luckPro = 0.4f;
                    break;
                case 8:
                    luckPro = 0.5f;
                    break;
                case 9:
                    luckPro = 1f;
                    break;

                default:
                    luckPro = 1f;
                    break;
            }

            if (RandomHelper.RandFloat01() <= luckPro)
            {
                attack_MinAct = attack_MaxAct;
            }

            //最低攻击之换算
            long minActAttack = (long)((attack_MaxAct * 0.5f) + attack_MaxAct * ((float)attack_MinAct / (float)attack_MaxAct) / 2);
            if (minActAttack > attack_MaxAct)
            {
                minActAttack = attack_MaxAct;
            }

            //获取攻击值
            long attack_Act = (long)RandomHelper.RandomNumberFloat(minActAttack, attack_MaxAct);
            if (attackUnit.Type == UnitType.Player)
            {
                //攻击强度和法术强度
                switch (attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Occ)
                {
                    //战士
                    case 1:
                        attack_Act += numericComponentAttack.GetAsLong(NumericType.Now_ActQiangDuAdd);
                        break;
                    //法师
                    case 2:
                        attack_Act += numericComponentAttack.GetAsLong(NumericType.Now_MageQiangDuAdd);
                        break;
                    //猎人
                    case 3:
                        attack_Act += numericComponentAttack.GetAsLong(NumericType.Now_ActQiangDuAdd);
                        break;
                    case 4:
                        attack_Act += numericComponentAttack.GetAsLong(NumericType.Now_MageQiangDuAdd);
                        break;
                }
            }
            //long attack_def = (long)RandomHelper.RandomNumberFloat(attack_MinDef, attack_MaxDef);

            //获取受击方属性
            NumericComponentS numericComponentDefend = defendUnit.GetComponent<NumericComponentS>();
            //long defend_Hp = numericComponentDefend.GetAsLong(NumericType.Now_Hp);
            //long defend_MaxHp = numericComponentDefend.GetAsLong(NumericType.Now_MaxHp);
            long defend_MinAct = numericComponentDefend.GetAsLong(NumericType.Now_MinAct);
            long defend_MaxAct = numericComponentDefend.GetAsLong(NumericType.Now_MaxAct);
            long defend_MinDef = numericComponentDefend.GetAsLong(NumericType.Now_MinDef);
            long defend_MaxDef = numericComponentDefend.GetAsLong(NumericType.Now_MaxDef);
            long defend_MinAdf = numericComponentDefend.GetAsLong(NumericType.Now_MinAdf);
            long defend_MaxAdf = numericComponentDefend.GetAsLong(NumericType.Now_MaxAdf);

            //忽视防御
            defend_MinDef = (long)((float)defend_MinDef * (1.0f - numericComponentAttack.GetAsFloat(NumericType.Now_HuShiActPro)) - numericComponentAttack.GetAsLong(NumericType.Now_HuShiDef));
            defend_MaxDef = (long)((float)defend_MaxDef * (1.0f - numericComponentAttack.GetAsFloat(NumericType.Now_HuShiActPro)) - numericComponentAttack.GetAsLong(NumericType.Now_HuShiDef));
            defend_MinAdf = (long)((float)defend_MinAdf * (1.0f - numericComponentAttack.GetAsFloat(NumericType.Now_HuShiMagePro)) - numericComponentAttack.GetAsLong(NumericType.Now_HuShiAdf));
            defend_MaxAdf = (long)((float)defend_MaxAdf * (1.0f - numericComponentAttack.GetAsFloat(NumericType.Now_HuShiMagePro)) - numericComponentAttack.GetAsLong(NumericType.Now_HuShiAdf));

            //限制
            defend_MinDef = defend_MinDef < 0 ? 0 : defend_MinDef;
            defend_MaxDef = defend_MaxDef < 0 ? 0 : defend_MaxDef;
            defend_MinAdf = defend_MinAdf < 0 ? 0 : defend_MinAdf;
            defend_MaxAdf = defend_MaxAdf < 0 ? 0 : defend_MaxAdf;

            long defend_Act = (long)RandomHelper.RandomNumberFloat(defend_MinAct, defend_MaxAct);
            long defend_def = (long)RandomHelper.RandomNumberFloat(defend_MinDef, defend_MaxDef);
            long defend_adf = (long)RandomHelper.RandomNumberFloat(defend_MinAdf, defend_MaxAdf);

            float defendPet_dodge = 0;

            bool ifMonsterBoss_Act = false;
            bool ifMonsterBoss_Def = false;

            //当前是否在宠物副本
            bool petfuben = sceneType == MapTypeEnum.PetDungeon || sceneType == MapTypeEnum.PetTianTi;
            if (sceneType == MapTypeEnum.RunRace)
            {
                Log.Warning($"变身大赛触发技能伤害： sceneType == SceneTypeEnum.RunRace  {skillconfig.Id}");
                return false;
            }
            
            //计算是否闪避
            int defendUnitLv = 0;
            switch (defendUnit.Type)
            {
                //怪物
                case UnitType.Monster:
                    defendUnit.GetComponent<AIComponent>()?.BeAttacking(attackUnit);
                    MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(defendUnit.ConfigId);
                    defendUnitLv = monsterCof.Lv;
                    if (monsterCof.MonsterType == (int)MonsterTypeEnum.Boss)
                    {
                        ifMonsterBoss_Act = true;
                    }
                    break;
                //宠物
                case UnitType.Pet:
                    defendUnit.GetComponent<AIComponent>()?.BeAttacking(attackUnit);
                    PetConfig petCof = PetConfigCategory.Instance.Get(defendUnit.ConfigId);
                    defendUnitLv = petCof.PetLv;
                    defend_def += numericComponentDefend.GetAsLong(NumericType.Now_PetAllDef);
                    defend_adf += numericComponentDefend.GetAsLong(NumericType.Now_PetAllAdf);
                    defend_def += (int)(defend_def * numericComponentDefend.GetAsFloat(NumericType.Now_PetAllDefPro));
                    defend_adf += (int)(defend_adf * numericComponentDefend.GetAsFloat(NumericType.Now_PetAllAdfPro));
                    defendPet_dodge += numericComponentDefend.GetAsFloat(NumericType.Now_PetAllDodge);
                    break;
                //玩家
                case UnitType.Player:
                    defendUnitLv = defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                    //受击增加怒气值
                    if (defendUnit.GetComponent<SkillSetComponentS>().IfJuexXingSkill())
                    {
                        numericComponentDefend.ApplyChange(NumericType.JueXingAnger, 1);
                    }
                    break;
            }

            int attackUnitLv = 0;
            switch (attackUnit.Type)
            {
                //怪物
                case UnitType.Monster:
                    MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(attackUnit.ConfigId);
                    attackUnitLv = monsterCof.Lv;
                    if (monsterCof.MonsterType == (int)MonsterTypeEnum.Boss)
                        ifMonsterBoss_Def = true;
                    break;
                //宠物
                case UnitType.Pet:
                    PetConfig petCof = PetConfigCategory.Instance.Get(attackUnit.ConfigId);
                    attackUnitLv = petCof.PetLv;

                    //增加宠物属性
                    ///从主人身上取
                    attack_MaxAct += numericComponentAttack.GetAsLong(NumericType.Now_PetAllAct);
                    attack_MageAct += numericComponentAttack.GetAsLong(NumericType.Now_PetAllMageAct);
                    attackPet_hit += numericComponentAttack.GetAsFloat(NumericType.Now_PetAllHit);
                    attackPet_cri += numericComponentAttack.GetAsFloat(NumericType.Now_PetAllCri);

                    attack_MaxAct += (int)(attack_MaxAct * numericComponentAttack.GetAsFloat(NumericType.Now_PetAllActPro));
                    attack_MageAct += (int)(attack_MageAct * numericComponentAttack.GetAsFloat(NumericType.Now_PetAllMageActPro));

                    //宠物没有最低攻击
                    attack_MinAct = attack_MaxAct;

                    break;
                //玩家
                case UnitType.Player:
                    attackUnitLv = attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                   
                    //攻击者增加怒气值
                    if (attackUnit.GetComponent<SkillSetComponentS>().IfJuexXingSkill())
                    {
                        numericComponentAttack.ApplyChange(NumericType.JueXingAnger, 10);
                    }
                    break;
            }
            
            float addHitPro = numericComponentAttack.GetAsFloat(NumericType.Now_Hit);
            float addDodgePro = numericComponentDefend.GetAsFloat(NumericType.Now_Dodge);

            float addHitLvPro = LvProChange(numericComponentAttack.GetAsLong(NumericType.Now_HitLv), defendUnitLv);
            float addDodgeLvPro = LvProChange(numericComponentDefend.GetAsLong(NumericType.Now_DodgeLv), attackUnitLv);


            addHitPro += addHitLvPro;
            addDodgePro += addDodgeLvPro;

            //等级差命中
            float HitLvPro = (attackUnitLv - defendUnitLv) * 0.03f;
            if (HitLvPro <= -0.1f)
            {
                HitLvPro = -0.1f;
            }
            if (HitLvPro >= 0.2f)
            {
                HitLvPro = 0.2f;
            }

            //等级差闪避
            float DodgeLvPro = (attackUnitLv - defendUnitLv) * 0.03f;
            if (DodgeLvPro <= 0)
            {
                DodgeLvPro = 0;
            }
            if (DodgeLvPro >= 0.1f)
            {
                DodgeLvPro = 0.1f;
            }

            //初始化命中
            float initHitPro = 0.9f;
            float dodgeSum = addDodgePro + DodgeLvPro + defendPet_dodge;
            float hitAdd = HitLvPro + addHitPro + attackPet_hit - dodgeSum;     //附加部分的命中属性
            float HitPro = initHitPro + HitLvPro + addHitPro + attackPet_hit - dodgeSum;

            //pk命中
            if (playerPKStatus)
            {
                HitPro -= numericComponentDefend.GetAsFloat(NumericType.Now_PlayerHitSubPro);
            }

            //最低命中
            if (HitPro <= 0.6f)
            {
                HitPro = 0.6f;
            }
            
            //根据双方战力增加命中
            if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Player)
            {
                HitPro += GetFightValueActProValue(attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Combat, defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Combat) * 0.66f;
            }

            //百发百中(只有玩家对怪物有效)
            if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Monster && skillconfig.SkillActType == 0)
            {
                if (attackUnit.GetComponent<SkillSetComponentS>().GetBySkillID(68000009) != null)
                {
                    HitPro = 1;
                }
            }

            //闪避概率
            bool ifHit = true;

            if (skillconfig.IfMustAct != 1)
            {

                if (RandomHelper.RandFloat() >= HitPro)
                {
                    ifHit = false;
                }

                //技能闪避
                if (skillconfig.SkillActType == 1)
                {
                    float dodgeNowValue = numericComponentDefend.GetAsFloat(NumericType.Now_SkillDodgePro);

                    //玩家命中的20%抵消对应闪避
                    dodgeNowValue = dodgeNowValue - hitAdd * 0.2f;

                    //玩家闪避最多不超过60%
                    if (defendUnit.Type == UnitType.Player)
                    {
                        if (dodgeNowValue >= 0.5)
                        {
                            dodgeNowValue = 0.5f;
                        }
                    }

                    if (RandomHelper.RandFloat() <= dodgeNowValue)
                    {
                        ifHit = false;
                    }
                }

                //物理闪避
                if (skillconfig.DamgeType == 1)
                {
                    float dodgeNowValue = numericComponentDefend.GetAsFloat(NumericType.Now_ActDodgePro);

                    //玩家闪避最多不超过60%
                    if (defendUnit.Type == UnitType.Player)
                    {
                        if (dodgeNowValue >= 0.5)
                        {
                            dodgeNowValue = 0.5f;
                        }
                    }

                    if (RandomHelper.RandFloat() <= dodgeNowValue)
                    {
                        ifHit = false;
                    }
                }

                //魔法闪避
                if (skillconfig.DamgeType == 2)
                {
                    float dodgeNowValue = numericComponentDefend.GetAsFloat(NumericType.Now_MageDodgePro);

                    //玩家闪避最多不超过60%
                    if (defendUnit.Type == UnitType.Player)
                    {
                        if (dodgeNowValue >= 0.5)
                        {
                            dodgeNowValue = 0.5f;
                        }
                    }

                    if (RandomHelper.RandFloat() <= dodgeNowValue)
                    {
                        ifHit = false;
                    }
                }
            }

            if (ifHit)
            {
                //获取属性
                long actValue = attack_Act;
                //宠物普攻是魔法类型得用魔法值
                if (attackUnit.Type == UnitType.Pet && skillconfig.DamgeType == 2) {
                        actValue = attack_MageAct;
                }
                long defValue = defend_def;
                long adfValue = defend_adf;
                //获取重击等级  判定是否触发重击
                int zhongjiLvValue = numericComponentAttack.GetAsInt(NumericType.Now_ZhongJiLv);
                float zhongJiPro = numericComponentAttack.GetAsFloat(NumericType.Now_ZhongJiPro) + LvProChange(zhongjiLvValue, attackUnitLv);
                
                //重击阈值
                if (zhongJiPro > 0.75f) {
                    zhongJiPro = 0.75f;
                }
                
                if (RandomHelper.RandFloat() <= zhongJiPro)
                {
                    defValue = 0;
                    actValue += numericComponentAttack.GetAsLong(NumericType.Now_ZhongJi);
                    DamgeType = 3;
                    
                    //重击对于怪物会额外附加一些伤害
                    if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Monster) {
                        actValue =(long)(actValue * 1.2f);
                    }
                }

                //判定是否无视防御
                float wushiPro = numericComponentAttack.GetAsFloat(NumericType.Now_WuShiFangYuPro);
                if (RandomHelper.RandFloat() <= wushiPro)
                {
                    defValue = 0;
                    adfValue = 0;
                }

                //生命低于30%触发,防御提升X%
                float hptoDef = numericComponentDefend.GetAsFloat(NumericType.Now_HpToDef);
                if (hptoDef > 0)
                {
                    float nowDefHpPro = (float)numericComponentDefend.GetAsInt(NumericType.Now_Hp) / (float)numericComponentDefend.GetAsInt(NumericType.Now_MaxHp);
                    if (nowDefHpPro <= 0.3f)
                    {
                        defValue = (long)(defValue * (1 + hptoDef));
                    }
                }

                long nowdef = defValue;

                //伤害类型 物理/魔法
                if (skillconfig.DamgeType == 2)
                {
                    nowdef = adfValue;
                }

                //技能加成
                if (skillconfig.SkillActType == 1)
                {
                    actValue += attack_MageAct;
                }

                //宠物远程攻击用魔法
                if (attackUnit.Type == UnitType.Pet && skillconfig.SkillActType == 1)
                {
                    actValue = attack_MageAct;
                }

                //宠物打怪物无视对方防御 150%攻击伤害
                if (attackUnit.Type == UnitType.Pet && defendUnit.Type == UnitType.Monster)
                {
                    nowdef = 0;
                    actValue = (int)(actValue * 1.5f);
                }

                //宠物打玩家无视目标50%的防御属性,防止不破防 攻击提升150%
                if (attackUnit.Type == UnitType.Pet && defendUnit.Type == UnitType.Player)
                {
                    nowdef = (int)(nowdef * 0.5f);
                    actValue = (int)(actValue * 1.5f);
                    //actValue = (int)(actValue * 1.5f);
                }

                //宠物打宠物计算伤害
                if (attackUnit.Type == UnitType.Pet && defendUnit.Type == UnitType.Pet)
                {
                    int attackPingfen = numericComponentAttack.GetAsInt(NumericType.PetPinFen);
                    int defPingfen = numericComponentDefend.GetAsInt(NumericType.PetPinFen);

                    if (attackPingfen == 0)
                    {
                        attackPingfen = 200;
                    }
                    if (defPingfen == 0)
                    {
                        defPingfen = 200;
                    }
                    actValue = (int)(actValue * (1 + GetFightValueActProValue(attackPingfen, defPingfen)));

                    //判断对方是否有神佑技能
                    bool haveshenyou = defendUnit.GetComponent<AIComponent>().HaveSkillId(80001014) || defendUnit.GetComponent<SkillPassiveComponent>().HaveSkillId(80002014);
                    if (haveshenyou) {
                        //低级破咒
                        if (attackUnit.GetComponent<AIComponent>().HaveSkillId(80001015)) {
                            actValue = (long)((float)actValue * 1.1f);
                        }
                        else if (attackUnit.GetComponent<SkillPassiveComponent>().HaveSkillId(80002015))
                        {
                            //高级破咒
                            actValue = (long)((float)actValue * 1.2f);
                        }
                    }
                }

                //计算战斗公式
                long damge = (actValue - nowdef);

                //查看对应武器
                float weaponAddAct = 0;
                int equipType = 1;
                //switch (UnitHelper.GetEquipType(attackUnit))
                switch(equipType)
                {
                    //刀
                    case 1:
                        weaponAddAct = numericComponentAttack.GetAsFloat(NumericType.Now_DaoActAddPro);
                        break;
                    //剑
                    case 2:
                        weaponAddAct = numericComponentAttack.GetAsFloat(NumericType.Now_JianActAddPro);
                        break;
                    //法杖
                    case 3:
                        weaponAddAct = numericComponentAttack.GetAsFloat(NumericType.Now_FaZhangActAddPro);
                        break;
                    //魔法书
                    case 4:
                        weaponAddAct = numericComponentAttack.GetAsFloat(NumericType.Now_ShuActAddPro);
                        break;
                    //弓箭
                    case 5:
                        weaponAddAct = numericComponentAttack.GetAsFloat(NumericType.Now_GongActAddPro);
                        break;
                }

                if (weaponAddAct >= 1f)
                {
                    weaponAddAct = 1f;
                }

                //武器伤害加成
                if (weaponAddAct > 0)
                {
                    damge = (long)((float)damge * (1f + weaponAddAct));
                }

                //怪物打宠物降低 （如果有需要 后期需要加入判定是不是当前怪物的普通攻击来判断躲避技能）
                if (attackUnit.Type == UnitType.Monster && defendUnit.Type == UnitType.Pet && petfuben == false)
                {
                    //普攻受到10%伤害
                    if (skillconfig.SkillActType == 0)
                    {
                        damge = (int)((float)damge * 0.1f);
                    }
                    
                    //技能受到0%伤害
                    if (skillconfig.SkillActType == 1)
                    {
                        damge = (int)((float)damge * 0.02f);
                        //damge = 0;
                    }
                }

                //怪物打玩家
                if (attackUnit.Type == UnitType.Monster && defendUnit.Type == UnitType.Player)
                {
                    //战士降低受到怪物普攻20%的伤害
                    if (defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Occ == 1)
                    {

                        if (skillconfig.SkillActType == 0)
                        {
                            damge = (int)((float)damge * 0.7f);
                        }

                    }

                    if (attackUnit.MasterIsPlayer())
                    {
                        damge = (int)((float)damge * 0.4f);
                    }
                }

              
                //宠物打宠物只造成50%的伤害
                if (attackUnit.Type == UnitType.Pet && defendUnit.Type == UnitType.Pet)
                {
                    damge = (int)((float)damge * 0.5f);
                    
                    //最低造成10%的伤害
                    int baodiValue = (int)((float)actValue * 0.1f);
                    if (damge < baodiValue) {
                        damge = baodiValue;
                    }
                }


                //玩家打宠物只保留10%的伤害,技能伤害(因为技能大多是百分比的)
                if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Pet)
                {
                    //技能保留20%
                    if (skillconfig.SkillActType == 1)
                    {
                        damge = (int)((float)damge * 0.2f);
                    }

                    //普攻保留50%
                    if (skillconfig.SkillActType == 0)
                    {
                        //猎人保留40%普攻伤害
                        if (attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Occ == 3)
                        {
                            damge = (int)((float)damge * 0.4f);
                        }
                        else {
                            damge = (int)((float)damge * 0.5f);
                        }
                    }
                }

                //技能倍伤
                if (skillconfig.SkillActType == 1)
                {
                    nowdef = adfValue;
                }

                //魔法伤害无法被抵消是固定伤害,技能附带加成
                double skillProAdd = 0;
                if (skillconfig.SkillActType == 1)
                {
                    if (RandomHelper.RandFloat() <= numericComponentAttack.GetAsFloat(NumericType.Now_SkillMoreDamgePro))
                    {
                        skillProAdd = 0.5f;
                    }
                }

                //获取技能相关系数
                double actDamge = skillconfig.ActDamge * singingvalue;
                int actDamgeValue = skillconfig.DamgeValue;
                if (hurtMode == 1)  //持续伤害
                {
                    actDamge = skillconfig.DamgeChiXuPro;
                    actDamgeValue = skillconfig.DamgeChiXuValue;
                }

                //damge = (long)(damge * (actDamge + skillHandler.ActTargetTemporaryAddPro + skillHandler.ActTargetAddPro + skillHandler.GetTianfuProAdd((int)SkillAttributeEnum.AddDamageCoefficient) + skillProAdd)) + actDamgeValue;
                damge = (long)(damge * (actDamge + skillHandlerS.ActTargetTemporaryAddPro + skillHandlerS.ActTargetAddPro + skillProAdd)) + actDamgeValue;

                float damgePro = 1;
                //伤害加成
                damge = (long)((float)damge * (1 + numericComponentAttack.GetAsFloat(NumericType.Now_DamgeAddPro) - numericComponentDefend.GetAsFloat(NumericType.Now_DamgeSubPro)));

                //物理伤害
                if (skillconfig.DamgeType == 1)
                {
                    damgePro = damgePro + numericComponentAttack.GetAsFloat(NumericType.Now_ActDamgeAddPro) - numericComponentDefend.GetAsFloat(NumericType.Now_ActDamgeSubPro);
                    if (ifMonsterBoss_Act && petfuben ==  false)
                    {
                        damgePro += numericComponentAttack.GetAsFloat(NumericType.Now_ActBossPro);
                        damge += numericComponentAttack.GetAsInt(NumericType.Now_ActBossAddDamge);
                    }

                    if (ifMonsterBoss_Def)
                    {
                        damgePro -= numericComponentAttack.GetAsFloat(NumericType.Now_ActBossSubPro);
                    }

                    //物穿怪物加成
                    if (defendUnit.Type == UnitType.Monster)
                    {
                        damgePro += numericComponentAttack.GetAsFloat(NumericType.Now_HuShiActPro) * 0.5f;
                    }

                    //魔导师分身普攻伤害加成
                    if (attackUnit.Type == UnitType.Monster && attackUnit.ConfigId == 90000001)
                    {
                        damgePro += numericComponentAttack.GetAsFloat(NumericType.Now_HuShiMagePro);
                    }
                }

                //技能伤害
                if (skillconfig.DamgeType == 2)
                {

                    damgePro = damgePro + numericComponentAttack.GetAsFloat(NumericType.Now_MageDamgeAddPro) - numericComponentDefend.GetAsFloat(NumericType.Now_MageDamgeSubPro);

                    if (ifMonsterBoss_Act && petfuben == false)
                    {
                        damgePro += numericComponentAttack.GetAsFloat(NumericType.Now_MageBossPro);
                        damge += numericComponentAttack.GetAsInt(NumericType.Now_ActBossAddDamge);
                    }

                    if (ifMonsterBoss_Def)
                    {
                        damgePro -= numericComponentAttack.GetAsFloat(NumericType.Now_MageBossSubPro);
                    }

                    //魔穿怪物加成
                    if (defendUnit.Type == UnitType.Monster)
                    {
                        damgePro += numericComponentAttack.GetAsFloat(NumericType.Now_HuShiMagePro);
                    }
                }

                //是否触发斩杀
                float defHpPro = (float)numericComponentDefend.GetAsInt(NumericType.Now_Hp) / (float)numericComponentDefend.GetAsInt(NumericType.Now_MaxHp);
                if (defHpPro <= 0.3f)
                {
                    damgePro += numericComponentAttack.GetAsFloat(NumericType.Now_ZhanShaPro);
                }

            //技能附加伤害
                if (!CommonHelp.IfNull(skillconfig.SkillDamgeAddValue))
                {
                    string[] skillAddValue = skillconfig.SkillDamgeAddValue.Split(',');
                    if (skillAddValue.Length >= 1)
                    {
                        switch (skillAddValue[0])
                        {

                            //当目标血量低于多少,技能伤害额外提升
                            case "1":
                                if (defHpPro <= float.Parse(skillAddValue[1])) {
                                    damgePro += float.Parse(skillAddValue[2]);
                                }
                                break;

                            //当自身血量低于多少,技能伤害额外提升
                            case "2":

                                float acthpPro = (float)numericComponentAttack.GetAsInt(NumericType.Now_Hp) / (float)numericComponentAttack.GetAsInt(NumericType.Now_MaxHp);
                                if (acthpPro <= float.Parse(skillAddValue[1]))
                                {
                                    damgePro += float.Parse(skillAddValue[2]);
                                }
                                break;

                            //当血量高于多少,技能伤害额外提升
                            case "3":
                                if (defHpPro >= float.Parse(skillAddValue[1]))
                                {
                                    damgePro += float.Parse(skillAddValue[2]);
                                }
                                break;

                            //当自身血量高于多少,技能伤害额外提升
                            case "4":

                                acthpPro = (float)numericComponentAttack.GetAsInt(NumericType.Now_Hp) / (float)numericComponentAttack.GetAsInt(NumericType.Now_MaxHp);
                                if (acthpPro >= float.Parse(skillAddValue[1]))
                                {
                                    damgePro += float.Parse(skillAddValue[2]);
                                }
                                break;
                        }
                    }
                }

                //普攻加成
                if (skillconfig.SkillActType == 0)
                {
                    //普攻属性加成
                    damgePro += numericComponentAttack.GetAsFloat(NumericType.Now_PuGongAddPro);

                    //血量降低转换普攻伤害
                    float hpDamgePro = numericComponentAttack.GetAsFloat(NumericType.Now_HpToDamgeAddPro);
                    if (hpDamgePro > 0)
                    {
                        float acthpPro = (float)numericComponentAttack.GetAsInt(NumericType.Now_Hp) / (float)numericComponentAttack.GetAsInt(NumericType.Now_MaxHp);
                        if (acthpPro < 1 && acthpPro > 0)
                        {
                            if (acthpPro >= 0.6f)
                            {
                                //大于0.5
                                damgePro += (1f - acthpPro) / 4 * hpDamgePro;
                            }
                            else if (acthpPro >= 0.3f)
                            {
                                damgePro += (1f - acthpPro) / 2f * hpDamgePro;
                            }
                            else
                            {
                                damgePro += (1f - acthpPro) / 1.5f * hpDamgePro;
                            }
                        }
                    }
                }

                //血量转换加成  （每10%转化成一定攻击值）
                float hpToDamgeAddPro2 = numericComponentAttack.GetAsFloat(NumericType.Now_HpToDamgeAddPro2);
                if (hpToDamgeAddPro2 > 0)
                {
                    //血量降低转换普攻伤害
                    float acthpPro = (float)numericComponentAttack.GetAsInt(NumericType.Now_Hp) / (float)numericComponentAttack.GetAsInt(NumericType.Now_MaxHp);
                    int toValue = (int)((1f - acthpPro) * 10f);
                    if (toValue >= 1 && toValue <= 10)
                    {
                        damgePro += hpToDamgeAddPro2 * toValue;
                    }
                }

                //抗性
                switch (skillconfig.DamgeElementType)
                {
                    //光     神圣抗性
                    case 1:
                        damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_Resistance_Shine_Pro);
                        break;
                    //暗     暗影抗性
                    case 2:
                        damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_Resistance_Shadow_Pro);
                        break;
                    //火     火焰抗性
                    case 3:
                        damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_ResistIcece_Ice_Pro);
                        break;
                    //水     冰霜抗性
                    case 4:
                        damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_ResistFirece_Fire_Pro);
                        break;
                    //电     闪电抗性
                    case 5:
                        damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_ResistThunderce_Thunder_Pro);
                        break;
                }

                //种族抗性
                if (ifMonsterBoss_Act)
                {
                    switch (MonsterConfigCategory.Instance.Get(defendUnit.ConfigId).MonsterRace)
                    {
                        //通用
                        case 0:
                            break;
                        //野兽
                        case 1:
                            damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_Resistance_Beast_Pro);
                            break;
                        //人类
                        case 2:
                            damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_Resistance_Hum_Pro);
                            break;
                        //恶魔
                        case 3:
                            damgePro = damgePro - numericComponentDefend.GetAsFloat(NumericType.Now_Resistance_Demon_Pro);
                            break;
                    }
                }

                //种族伤害
                if (ifMonsterBoss_Def)
                {
                    switch (MonsterConfigCategory.Instance.Get(attackUnit.ConfigId).MonsterRace)
                    {
                        //通用
                        case 0:
                            break;
                        //野兽
                        case 1:
                            damgePro = damgePro + numericComponentAttack.GetAsFloat(NumericType.Now_Damge_Beast_Pro);
                            break;
                        //人类
                        case 2:
                            damgePro = damgePro + numericComponentAttack.GetAsFloat(NumericType.Now_Damge_Hum_Pro);
                            break;
                        //恶魔
                        case 3:
                            damgePro = damgePro + numericComponentAttack.GetAsFloat(NumericType.Now_Damge_Demon_Pro);
                            break;
                    }
                }

                //pk相关
                if (playerPKStatus)
                {

                    actDamgeValue -= (int)(actDamgeValue * 0.4f);
                    damgePro -= numericComponentDefend.GetAsFloat(NumericType.Now_PlayerAllDamgeSubPro);

                    //damgePro -= 0.5f;
                    //玩家之间PK伤害降低,普通攻击降低40%,技能伤害降低30%
                    //普通攻击
                    if (skillconfig.SkillActType == 0 && damgePro > 0)
                    {
                        damgePro = damgePro * 0.4f;
                    }

                    //技能攻击
                    if (skillconfig.SkillActType == 1 && damgePro > 0)
                    {
                        damgePro = damgePro * 0.3f;
                    }

                    bool jueXinSkill = false;
                    if (ConfigData.JueXingSkillIDList.Contains(skillHandlerS.SkillConf.Id))
                    {
                        jueXinSkill = true;
                    }
                    else
                    {
                        //获取觉醒ID
                        int juexingid = 0;
                        if (attackUnit.Type == UnitType.Player)
                        {
                            int occtwo = attackUnit.GetComponent<UserInfoComponentS>().UserInfo.OccTwo;
                            if (occtwo != 0)
                            {
                                OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtwo);
                                juexingid = occupationConfig.JueXingSkill[7];
                            }
                        }

                        jueXinSkill = juexingid != 0 && juexingid == skillHandlerS.SkillConf.Id;
                    }

                    //觉醒技能伤害减半
                    if (jueXinSkill)
                    {
                        damgePro = damgePro / 2;
                    }

                    //普通攻击降低
                    if (skillconfig.SkillActType == 0)
                    {
                        damgePro -= numericComponentDefend.GetAsFloat(NumericType.Now_PlayerActDamgeSubPro);
                    }
                    //技能伤害降低
                    if (skillconfig.SkillActType == 1)
                    {
                        damgePro -= numericComponentDefend.GetAsFloat(NumericType.Now_PlayerSkillDamgeSubPro);
                    }

                    //根据双方战力调整系数
                    if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Player)
                    {
                        damgePro += GetFightValueActProValue(attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Combat, 
                            defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Combat);
                    }
                }

                damgePro = damgePro < 0 ? 0 : damgePro;
                damge = (int)(damge * damgePro);

                //格挡值抵消
                damge = damge - numericComponentDefend.GetAsLong(NumericType.Now_GeDang);

                if (damge < 1)
                {
                    damge = 1;
                }

                //真实伤害
                damge += numericComponentAttack.GetAsLong(NumericType.Now_ZhenShi);

                damge += (long)skillHandlerS.GetTianfuProAdd((int)SkillAttributeEnum.AddDamageValue);

                //二次限定
                if (damge < 1)
                {
                    damge = 1;
                }
                
                //存储是为万为单位的
                //damge = (damge / 10000 * 10000);
                if (damge > 0)
                {
                    //等级换算最终属性
                    float addCriPro = numericComponentAttack.GetAsFloat(NumericType.Now_Cri);
                    float addResPro = numericComponentDefend.GetAsFloat(NumericType.Now_Res);

                    float addCriLvPro = LvProChange(numericComponentAttack.GetAsLong(NumericType.Now_CriLv), defendUnitLv);
                    float addResLvPro = LvProChange(numericComponentAttack.GetAsLong(NumericType.Now_ResLv), attackUnitLv);

                    addCriPro += addCriLvPro;
                    addResPro += addResLvPro;

                    float CriPro = addCriPro + attackPet_cri - addResPro;

                    //pk命中
                    if (playerPKStatus)
                    {
                        CriPro -= numericComponentDefend.GetAsFloat(NumericType.Now_PlayerCriSubPro);
                        HitPro += numericComponentAttack.GetAsFloat(NumericType.Now_PlayerHitAddPro);
                    }
                    
                    //根据双方战力调整暴击系数
                    if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Player)
                    {
                        CriPro += GetFightValueCriAndHitProValue(attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Combat, defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Combat);
                    }

                    if (CriPro <= 0f)
                    {
                        CriPro = 0;
                    }

                    //判断当前是否时暴击状态
                    if (attackUnit.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.CriStatus) == true)
                    {
                        CriPro = 1;

                        BuffManagerComponentS buffManagerComponent = attackUnit.GetComponent<BuffManagerComponentS>();

                        if (buffManagerComponent.GetCritBuffNumber() <= 1)
                        {
                            attackUnit.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.CriStatus);
                        }
                        buffManagerComponent.RemoveFirstCritBuff();
                    }

                    //暴击概率..
                    if (RandomHelper.RandFloat() <= CriPro)
                    {
                        DamgeType = 1;
                        float criDamge = 1.7f + numericComponentAttack.GetAsFloat(NumericType.Now_CriDamgeAdd_Pro) + numericComponentDefend.GetAsFloat(NumericType.Now_CriHitDamgeAdd_Pro);
                        damge = (long)((float)damge * criDamge);
                        
                        //闪避触发被动技能
                        attackUnit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.Critical_4, defendUnit.Id);
                        
                        // 普通攻击暴击触发19
                        if (skillconfig.SkillActType == 0)
                        {
                            attackUnit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.AckCritical_19, defendUnit.Id);
                        }
                    }
                    
                    //是否触发秒杀
                    if (defHpPro <= 0.2f)
                    {
                        float miaoshaPro = numericComponentAttack.GetAsFloat(NumericType.Now_MiaoSha_Pro);
                        if (RandomHelper.RandFloat01() < miaoshaPro)
                        {
                            damge += numericComponentDefend.GetAsInt(NumericType.Now_Hp);
                        }
                    }

                    int shield_Hp = numericComponentDefend.GetAsInt(NumericType.Now_Shield_HP);
                    float shield_pro = numericComponentDefend.GetAsFloat(NumericType.Now_Shield_DamgeCostPro);
                    if (shield_Hp > 0)
                    {
                        int dunDamge = (int)((float)damge * shield_pro);
                        damge -= dunDamge;
                        damge = Math.Max(0, damge);
                        numericComponentDefend.ApplyChange( NumericType.Now_Shield_HP, -1 * dunDamge, true, true, attackUnit.Id, skillconfig.Id,  DamgeType);
                    }

                    //吸血处理(普通攻击触发吸血)
                    if (skillconfig.SkillActType == 0)
                    {
                        float hushi = numericComponentAttack.GetAsFloat(NumericType.Now_XiXuePro);
                        if (hushi > 0f)
                        {
                            int addHp = (int)((float)damge * hushi);
                            numericComponentDefend.ApplyChange( NumericType.Now_Hp, addHp, true, true, attackUnit.Id, 0, 0);
                        }
                    }

                    //普攻和技能吸血
                    float xixueAll = numericComponentAttack.GetAsFloat(NumericType.Now_AllXiXuePro);
                    if (xixueAll > 0f)
                    {
                        int addHp = (int)((float)damge * xixueAll);
                        numericComponentAttack.ApplyChange(NumericType.Now_Hp, addHp, true, true, attackUnit.Id, 0, 0);
                    }

                    damge *= -1;
                }
                if (defendUnit.IsDisposed)
                {
                    return false;
                }
                if (defendUnit.Type == UnitType.Monster && ifMonsterBoss_Act)
                {
                    defendUnit.GetComponent<AttackRecordComponent>().BeAttacking(attackUnit, damge);
                }
                if (DamgeType == 0)
                {
                    //Log.Debug("1");
                }


                //即将死亡
                if (numericComponentDefend.GetAsInt(NumericType.Now_Hp) + damge <= 0)
                {
                    //判定是否复活
                    if (RandomHelper.RandFloat01() < numericComponentDefend.GetAsFloat(NumericType.Now_FuHuoPro))
                    {
                        //复活存在30%的血量
                        defendUnit.GetComponent<BuffManagerComponentS>().UpdateFuHuoStatus();
                        numericComponentDefend.ApplyChange( NumericType.Now_Hp, (int)(numericComponentAttack.GetAsInt(NumericType.Now_MaxHp) * 0.3f));
                    }
                    else if (RandomHelper.RandFloat01() < numericComponentDefend.GetAsFloat(NumericType.Now_ShenYouPro))
                    {
                        //神佑存在100%的血量
                        defendUnit.GetComponent<BuffManagerComponentS>().UpdateFuHuoStatus();
                        numericComponentDefend.ApplyChange( NumericType.Now_Hp, (int)(numericComponentAttack.GetAsInt(NumericType.Now_MaxHp) * 1f));
                    }
                    else
                    {
                        //死亡
                    }
                }
                //普通攻击反弹伤害
                if (numericComponentDefend.GetAsFloat(NumericType.Now_ActReboundDamgePro) > 0 && skillconfig.DamgeType == 1)
                {
                    int fantanValue = (int)((float)damge * numericComponentDefend.GetAsFloat(NumericType.Now_ActReboundDamgePro));
                    numericComponentAttack.ApplyChange( NumericType.Now_Hp, fantanValue, true, true, attackUnit.Id,  skillconfig.Id, DamgeType);
                }
                if (attackUnit.IsDisposed == false)
                {
                    //设置目标当前
                    numericComponentDefend.ApplyChange( NumericType.Now_Hp, damge, true, true, attackUnit.Id, skillconfig.Id, DamgeType);

                    //攻击方反弹即将死亡
                    if (numericComponentAttack.GetAsInt(NumericType.Now_Hp) <= 0)
                    {
                    }
                }
            }
            else
            {
                //设置伤害为0,用于伤害飘字
                long now_hp = numericComponentDefend.GetAsLong(NumericType.Now_Hp);
                numericComponentDefend.ApplyValue(NumericType.Now_Hp, now_hp, true, false, attackUnit.Id, skillconfig.Id );

                //闪避触发被动技能
                defendUnit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.ShanBi_5, attackUnit.Id);
            }
            return ifHit;
        }

        /// <summary>
        /// 根据双方战力比调整攻击系数，攻击者打弱势有额外的命中和攻击
        /// </summary>
        /// <param name="actFightValue"></param>
        /// <param name="defFightValue"></param>
        /// <returns></returns>
        private static float GetFightValueCriAndHitProValue(int actFightValue, int defFightValue)
        {

            float addPro = ((actFightValue / defFightValue) - 1) * 1.5f;

            //范围限制
            if (addPro < 0)
            {
                addPro = 0;
            }

            //addPro = addPro + 0.05f;
            if (addPro > 0.2f)
            {
                addPro = 0.2f;
            }

            return addPro;
        }

        //暴击等级等属性转换成实际暴击率的方法
        public static float LvProChange(long value, int lv)
        {
            float proValue = (float)value / (float)(7500 + lv * 250);
            if (proValue < 0)
            {
                proValue = 0;
            }
            if (proValue > 0.75f)
            {
                proValue = 0.75f;
            }
            return proValue;
        }

        //根据双方战力比调整攻击系数，攻击者打弱势有额外的攻击加成
        public static float GetFightValueActProValue(int actFightValue, int defFightValue)
        {

            float addPro = ((actFightValue / defFightValue) - 1) * 1.5f;

            //范围限制
            if (addPro < 0)
            {
                addPro = 0;
            }

            //addPro = addPro + 0.05f;
            if (addPro > 0.75f)
            {
                addPro = 0.75f;
            }

            return addPro;

        }

        //字典是引用,进来的值会发生改变
        public static void AddUpdateProDicList(int typeID, long typeValue, Dictionary<int, long> dic)
        {
            //缓存属性
            if (dic.ContainsKey(typeID))
            {
                dic[typeID] += typeValue;
            }
            else
            {
                dic[typeID] = typeValue;
            }

        }

        //是否是一级属性
        public static bool ifNumTypeOnePro(int numericType)
        {

            if (numericType < (int)NumericType.Max)
            {
                numericType = numericType * 100;
            }
            int nowValue = (int)numericType / 100;
            if (nowValue == NumericType.Now_Power || nowValue == NumericType.Now_Agility || nowValue == NumericType.Now_Intellect || nowValue == NumericType.Now_Stamina || nowValue == NumericType.Now_Constitution)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //字典是引用,进来的值会发生改变
        public static int GetOnePro(int typeID, Dictionary<int, long> dic)
        {

            if (ifNumTypeOnePro(typeID))
            {
                //缓存属性
                int baseType = typeID * 100 + 1;
                int mulType = typeID * 100 + 2;
                int addType = typeID * 100 + 3;
                long baseValue = 0;
                float mulValue = 0;
                long addValue = 0;
                if (dic.ContainsKey(baseType))
                {
                    baseValue = dic[baseType];
                }
                if (dic.ContainsKey(mulType))
                {
                    mulValue = (float)dic[mulType] / 10000f;
                }
                if (dic.ContainsKey(addType))
                {
                    addValue = dic[addType];
                }

                return (int)(baseValue * (1 + mulValue) + addValue);

            }

            return 0;
        }

        /// <summary>
        /// 大恶魔  ...血量提升30倍,攻击提升200%，移动速度变为10，自身会变成恶魔模型
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="notice"></param>
        public static void UnitUpdateProperty_DemonBig(Unit unit, bool notice)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

            numericComponent.ApplyValue(NumericType.Base_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, 100000, notice);
        }

        /// <summary>
        /// 小恶魔
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="notice"></param>
        public static void UnitUpdateProperty_DemonLittle(Unit unit, bool notice)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.Base_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, 80000, notice);
        }

        /// <summary>
        /// 幽灵
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="notice"></param>
        public static void UnitUpdateProperty_DemonGhost(Unit unit, bool notice)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.Base_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, 50000, notice);
        }

        /// <summary>
        /// 奔跑大赛属性
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="notice"></param>
        public static void UnitUpdateProperty_RunRace(Unit unit, bool notice)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            int monsterid = numericComponent.GetAsInt(NumericType.RunRaceTransform);
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);
            numericComponent.ApplyValue(NumericType.Base_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, (long)(10000 * monsterConfig.MoveSpeed), notice);
        }

        private static int GetPoint(int basic, int roleLv)
        {
            //每升一级属性+1所以这里有加成
            return basic + roleLv * 2;
        }

        /// <summary>
        /// 更新基础的属性
        /// ItemInfo itemInfo 不为空则只是用来模拟计算战力。。。。。 itemInfo.BagInfoID 用来返回战力
        /// </summary>
        /// <param name="unit"></param>
        public static void UnitUpdateProperty_Base(Unit unit, bool notice, bool rank, ItemInfo testItemInfo = null)
        {
            if (unit.SceneType == MapTypeEnum.RunRace)
            {
                return;
            }
           
            //基础职业属性
            UserInfoComponentS unitInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = unitInfoComponentS.UserInfo;
            int roleLv = userInfo.Lv;

            //初始化属性
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ResetProperty();

            //缓存列表
            Dictionary<int, long> UpdateProDicList = new Dictionary<int, long>();

            //属性点
            int PointLiLiang = GetPoint(numericComponent.GetAsInt(NumericType.PointLiLiang), roleLv);
            int PointZhiLi = GetPoint(numericComponent.GetAsInt(NumericType.PointZhiLi), roleLv);
            int PointTiZhi = GetPoint(numericComponent.GetAsInt(NumericType.PointTiZhi), roleLv);
            int PointNaiLi = GetPoint(numericComponent.GetAsInt(NumericType.PointNaiLi), roleLv);
            int PointMinJie = GetPoint(numericComponent.GetAsInt(NumericType.PointMinJie), roleLv);

            OccupationConfig mOccupationConfig = OccupationConfigCategory.Instance.Get(userInfo.Occ);
          
            long occBaseHp = mOccupationConfig.BaseHp + roleLv * mOccupationConfig.LvUpHp;
            long occBaseMinAct = mOccupationConfig.BaseMinAct + roleLv * mOccupationConfig.LvUpMinAct;
            long occBaseMaxAct = mOccupationConfig.BaseMaxAct + roleLv * mOccupationConfig.LvUpMaxAct;
            long occBaseMinMage = mOccupationConfig.LvUpMinMagAct + roleLv * mOccupationConfig.LvUpMinMagAct;
            long occBaseMaxMage = mOccupationConfig.LvUpMaxMagAct + roleLv * mOccupationConfig.LvUpMaxMagAct;
            long occBaseMinDef = mOccupationConfig.BaseMinDef + roleLv * mOccupationConfig.LvUpMinDef;
            long occBaseMaxDef = mOccupationConfig.BaseMaxDef + roleLv * mOccupationConfig.LvUpMaxAdf;
            long occBaseMinAdf = mOccupationConfig.BaseMinAdf + roleLv * mOccupationConfig.LvUpMinAdf;
            long occBaseMaxAdf = mOccupationConfig.BaseMaxAdf + roleLv * mOccupationConfig.LvUpMaxAdf;

            double occBaseMoveSpeed = mOccupationConfig.BaseMoveSpeed;
            double occBaseCri = mOccupationConfig.BaseCri;
            double occBaseHit = mOccupationConfig.BaseHit;
            double occBaseDodge = mOccupationConfig.BaseDodge;
            double occBaseDefSub = mOccupationConfig.BaseDefAdd;
            double occBaseAdfSub = mOccupationConfig.BaseAdfAdd;
            double occBaseDamgeSubAdd = mOccupationConfig.DamgeAdd;

            //装备属性
            List<int> equipIDList = new List<int>();
            List<int> equipSuitIDList = new List<int>();

            List<ItemInfo> equipList = new List<ItemInfo>();
            equipList.AddRange( unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocEquip));

            
            ///替换equipList
            if (testItemInfo != null)
            {
                int subtype = ItemConfigCategory.Instance.Get(testItemInfo.ItemID).ItemSubType;
                int havenum = 0;
                for (int i = equipList.Count - 1; i >= 0; i--)
                {
                    ItemInfo userBagInfo = equipList[i];
                    if (!ItemConfigCategory.Instance.Contain(userBagInfo.ItemID))
                    {
                        equipList.RemoveAt(i);
                        continue;
                    }

                    int ItemSubType = ItemConfigCategory.Instance.Get(userBagInfo.ItemID).ItemSubType;
                    if (ItemSubType == subtype && ( (subtype != 5 && havenum >= 0 || (subtype == 5 && havenum >= 2) ) ) )
                    {
                        havenum++;
                        equipList.RemoveAt(i);
                        break;
                    }
                }
                
                equipList.Add(testItemInfo);
            }


            for (int i = equipList.Count - 1; i >= 0; i--)
            {
                ItemInfo userBagInfo = equipList[i];
                if (!ItemConfigCategory.Instance.Contain(userBagInfo.ItemID))
                {
                    equipList.RemoveAt(i);
                    continue;
                }

                //存储装备ID
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(userBagInfo.ItemID);

                //生肖装备没激活直接跳出来
                if (itemCof.EquipType == 101 && ItemHelper.IfShengXiaoActive(itemCof.Id, equipList) == false)
                {
                    continue;
                }

                //赛季晶核装备
                if (itemCof.EquipType == 201)
                {

                }

                bool ifAddHidePro = true;
                int occTwoValue = unit.GetComponent<UserInfoComponentS>().UserInfo.OccTwo;
                if (occTwoValue != 0)
                {
                    if (itemCof.EquipType == 11 || itemCof.EquipType == 12 || itemCof.EquipType == 13 && equipList[i].Loc == (int)ItemLocType.ItemLocEquip)
                    {
                        int selfMastery = OccupationTwoConfigCategory.Instance.Get(occTwoValue).ArmorMastery;
                        if (selfMastery != itemCof.EquipType)
                        {
                            //护甲不匹配不添加专精数据
                            ifAddHidePro = false;
                        }
                    }
                }

                if (ifAddHidePro)
                {
                    //存储装备精炼数值
                    if (userBagInfo.HideProLists != null)
                    {
                        for (int y = 0; y < userBagInfo.HideProLists.Count; y++)
                        {
                            HideProList hidePro = userBagInfo.HideProLists[y];
                            AddUpdateProDicList(hidePro.HideID, hidePro.HideValue, UpdateProDicList);
                        }
                    }
                }

                //存储洗炼数值
                if (userBagInfo.XiLianHideProLists != null)
                {
                    for (int y = 0; y < userBagInfo.XiLianHideProLists.Count; y++)
                    {
                        HideProList hidePro = userBagInfo.XiLianHideProLists[y];
                        AddUpdateProDicList(hidePro.HideID, hidePro.HideValue, UpdateProDicList);
                    }
                }

                //存储洗炼数值
                if (userBagInfo.XiLianHideTeShuProLists != null)
                {
                    for (int y = 0; y < userBagInfo.XiLianHideTeShuProLists.Count; y++)
                    {

                        HideProList hidePro = userBagInfo.XiLianHideTeShuProLists[y];
                        HideProListConfig hideproCof = HideProListConfigCategory.Instance.Get(hidePro.HideID);
                        AddUpdateProDicList(hideproCof.PropertyType, hidePro.HideValue, UpdateProDicList);
                    }
                }

                //存储附魔属性
                if (userBagInfo.FumoProLists != null)
                {
                    for (int y = 0; y < userBagInfo.FumoProLists.Count; y++)
                    {
                        HideProList hidePro = userBagInfo.FumoProLists[y];
                        AddUpdateProDicList(hidePro.HideID, hidePro.HideValue, UpdateProDicList);
                    }
                }

                // 存储增幅属性
                if (userBagInfo.IncreaseProLists != null && userBagInfo.IncreaseProLists.Count > 0)
                {
                    for (int j = 0; j < userBagInfo.IncreaseProLists.Count; j++)
                    {
                        HideProList hideProList = userBagInfo.IncreaseProLists[j];
                        HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hideProList.HideID);
                        AddUpdateProDicList(hideProListConfig.PropertyType, hideProList.HideValue, UpdateProDicList);
                    }
                }
                //.InheritSkills //传承技能
                // 存储增幅技能属性
                if (userBagInfo.IncreaseSkillLists != null && userBagInfo.IncreaseSkillLists.Count > 0)
                {
                    for (int s = 0; s < userBagInfo.IncreaseSkillLists.Count; s++)
                    {
                        HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(userBagInfo.IncreaseSkillLists[s]);
                        SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideProListConfig.PropertyType);

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
                                    AddUpdateProDicList(key, long.Parse(addPro[1]), UpdateProDicList);
                                }
                                else
                                {
                                    AddUpdateProDicList(key, (int)(float.Parse(addPro[1]) * 10000), UpdateProDicList);
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error($"{ex.ToString()} {GameObjectParameter}");
                            }
                        }
                    }
                }

                //存储装备ID
                equipIDList.Add(itemCof.ItemEquipID);

                //存储装备套装
                if (EquipConfigCategory.Instance.Contain(itemCof.ItemEquipID))
                {
                    EquipConfig equipCnf = EquipConfigCategory.Instance.Get(itemCof.ItemEquipID);
                    if (equipCnf.EquipSuitID != 0)
                    {
                        if (equipSuitIDList.Contains(equipCnf.EquipSuitID) == false)
                        {
                            equipSuitIDList.Add(equipCnf.EquipSuitID);
                        }
                    }
                }
                else
                {
                    Log.Debug($"无效的装备: {itemCof.Id}");
                }
            }

            if (userInfo.SeasonLevel == 0)
            {
                userInfo.SeasonLevel = 1;
            }
            SeasonLevelConfig seasonLevelConfig = SeasonLevelConfigCategory.Instance.Get(userInfo.SeasonLevel);
            if (!CommonHelp.IfNull(seasonLevelConfig.PripertySet))
            {
                string[] addProList = seasonLevelConfig.PripertySet.Split("@");
                for (int p = 0; p < addProList.Length; p++)
                {
                    string[] addPro = addProList[p].Split(";");
                    if (addPro.Length < 2)
                    {
                        break;
                    }
                    int key = int.Parse(addPro[0]);
                    try
                    {
                        if (NumericHelp.GetNumericValueType(key) == 1)
                        {
                            AddUpdateProDicList(key, long.Parse(addPro[1]), UpdateProDicList);
                        }
                        else
                        {
                            AddUpdateProDicList(key, (int)(float.Parse(addPro[1]) * 10000), UpdateProDicList);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"赛季属性配置错误：{ex.ToString()} {seasonLevelConfig.PripertySet}");
                    }
                }
            }

            long BaseHp_EquipSuit = 0;
            long BaseMinAct_EquipSuit = 0;
            long BaseMaxAct_EquipSuit = 0;
            long BaseMinMage_EquipSuit = 0;
            long BaseMaxMage_EquipSuit = 0;
            long BaseMinDef_EquipSuit = 0;
            long BaseMaxDef_EquipSuit = 0;
            long BaseMinAdf_EquipSuit = 0;
            long BaseMaxAdf_EquipSuit = 0;

            double BaseMoveSpeed_EquipSuit = 0;
            double BaseCri_EquipSuit = 0;
            double BaseHit_EquipSuit = 0;
            double BaseDodge_EquipSuit = 0;

            //double BaseDefSub_EquipSuit = 0;
            //double BaseAdfSub_EquipSuit = 0;
            double BaseDamgeAdd_EquipSuit = 0;
            double BaseDamgeSub_EquipSuit = 0;


            ///职业套装
            equipSuitIDList.AddRange(EquipSuitConfigCategory.Instance.OccSuiList[userInfo.Occ]);

            //装备套装属性
            for (int i = 0; i < equipSuitIDList.Count; i++)
            {
                if (!EquipSuitConfigCategory.Instance.Contain(equipSuitIDList[i]))
                {
                    continue;
                }
                EquipSuitConfig equipSuitCof = EquipSuitConfigCategory.Instance.Get(equipSuitIDList[i]);
                int num = 0;
                if (equipSuitCof.SuitType == 0) //默认套装
                {
                    int[] needEquipList = equipSuitCof.NeedEquipID;
                    for (int y = 0; y < needEquipList.Length; y++)
                    {
                        int needEquipID = needEquipList[y];
                        if (equipIDList.Contains(needEquipID))
                        {
                            num = num + 1;
                        }
                    }
                }
                else  //时装套装
                {
                    int[] needEquipList = equipSuitCof.NeedEquipID;
                    for (int y = 0; y < needEquipList.Length; y++)
                    {
                        if (unit.GetComponent<BagComponentS>().FashionActiveIds.Contains(needEquipList[y]))
                        {
                            num++;
                        }
                    }
                }

                string[] equipSuitProList = equipSuitCof.SuitPropertyID.Split(';');

                for (int y = 0; y < equipSuitProList.Length; y++)
                {
                    int NeedNum = int.Parse(equipSuitProList[y].Split(',')[0]);
                    int NeedID = int.Parse(equipSuitProList[y].Split(',')[1]);
                    if (num >= NeedNum)
                    {
                        //激活对应套装属性
                        EquipSuitPropertyConfig equipSuitProCof = EquipSuitPropertyConfigCategory.Instance.Get(NeedID);
                        BaseHp_EquipSuit += equipSuitProCof.Equip_Hp;
                        BaseMinAct_EquipSuit += equipSuitProCof.Equip_MinAct;
                        BaseMaxAct_EquipSuit += equipSuitProCof.Equip_MaxAct;
                        BaseMinMage_EquipSuit += equipSuitProCof.Equip_MinMagAct;
                        BaseMaxMage_EquipSuit += equipSuitProCof.Equip_MaxMagAct;
                        BaseMinDef_EquipSuit += equipSuitProCof.Equip_MinDef;
                        BaseMaxDef_EquipSuit += equipSuitProCof.Equip_MaxDef;
                        BaseMinAdf_EquipSuit += equipSuitProCof.Equip_MinAdf;
                        BaseMaxAdf_EquipSuit += equipSuitProCof.Equip_MaxAdf;
                        BaseMoveSpeed_EquipSuit += equipSuitProCof.Equip_Speed;
                        BaseCri_EquipSuit += equipSuitProCof.Equip_Cri;
                        BaseHit_EquipSuit += equipSuitProCof.Equip_Hit;
                        BaseDodge_EquipSuit += equipSuitProCof.Equip_Dodge;
                        BaseDamgeAdd_EquipSuit += equipSuitProCof.Equip_DamgeAdd;
                        BaseDamgeSub_EquipSuit += equipSuitProCof.Equip_DamgeSub;
                        //BaseDamgeSubAdd_EquipSuit += equipSuitProCof.Equip_Hp;

                        if (equipSuitProCof.AddPropreListStr != "0")
                        {
                            string[] AddPropreList = equipSuitProCof.AddPropreListStr.Split(';');
                            for (int z = 0; z < AddPropreList.Length; z++)
                            {
                                int addProType = int.Parse(AddPropreList[z].Split(',')[0]);
                                int type = NumericHelp.GetNumericValueType(addProType);
                                int addProValue = 0;
                                if (type == 1)
                                {
                                    addProValue = int.Parse(AddPropreList[z].Split(',')[1]);
                                }
                                else
                                {
                                    addProValue = (int)(float.Parse(AddPropreList[z].Split(',')[1]) * 10000);
                                }

                                AddUpdateProDicList(addProType, addProValue, UpdateProDicList);
                            }
                        }
                    }
                }
            }
            
            int equipHpSum = 0;
            int equipMinActSum = 0;
            int equipMaxActSum = 0;
            int equipMinMageSum = 0;
            int equipMaxMageSum = 0;
            int equipMinDefSum = 0;
            int equipMaxDefSum = 0;
            int equipMinAdfSum = 0;
            int equipMaxAdfSum = 0;

            //史诗宝石数量
            int equipShiShiGemNum = 0;
            List<int> ShiShiGemID = new List<int>();

            for (int i = 0; i < equipList.Count; i++)
            {
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(equipList[i].ItemID);

                //生肖装备没激活直接跳出来
                if (itemCof.EquipType == 101 && ItemHelper.IfShengXiaoActive(itemCof.Id, equipList) == false)
                {
                    continue;
                }
                if (itemCof.ItemEquipID == 0)
                {
                    continue;
                }

                EquipConfig mEquipCon = EquipConfigCategory.Instance.Get(itemCof.ItemEquipID);

                //职业专精
                float occMastery = 0f;
                if (userInfo.Occ != 0)
                {
                    //if (OccupationTwoConfigCategory.Instance.Get(userInfo.OccTwo).ArmorMastery == ItemConfigCategory.Instance.Get(equipIDList[i]).EquipType)
                    //{
                    //    //occMastery = 0.2f;
                    //    occMastery = 0f;
                    //}
                }

                //极品属性
                float addPro = 0;

                if (equipList[i].HideSkillLists.Contains(68000104) || equipList[i].IncreaseSkillLists.Contains(3903))
                {
                    addPro = 0.2f;
                }

                //虚弱属性
                if (equipList[i].HideSkillLists.Contains(68000107))
                {
                    addPro = -0.1f;
                }

                //胜算属性
                if (equipList[i].HideSkillLists.Contains(68000105) || equipList[i].IncreaseSkillLists.Contains(3904))
                {
                    mEquipCon.Equip_MinAct = mEquipCon.Equip_MaxAct;
                }

                //强化登录（List长度13， 13个位置）
                int qianghuaLv = unit.GetComponent<BagComponentS>().GetQiangHuaLevel(itemCof.ItemSubType);

                EquipQiangHuaConfig equipQiangHuaConfig = null;/// QiangHuaHelper.GetQiangHuaConfig(itemCof.ItemSubType, qianghuaLv);
                if (equipQiangHuaConfig != null)
                {
                    addPro += float.Parse(equipQiangHuaConfig.EquipPropreAdd);
                    //addPro += float.Parse(EquipQiangHuaConfigCategory.Instance.Get(QiangHuaHelper.GetQiangHuaId(itemCof.ItemSubType, qianghuaLv[itemCof.ItemSubType])).EquipPropreAdd);
                }

                //存储基础属性
                equipHpSum = (int)(equipHpSum + mEquipCon.Equip_Hp * (1 + occMastery + addPro));
                equipMinActSum = (int)(equipMinActSum + mEquipCon.Equip_MinAct * (1 + occMastery + addPro));
                equipMaxActSum = (int)(equipMaxActSum + mEquipCon.Equip_MaxAct * (1 + occMastery + addPro));
                equipMinMageSum = (int)(equipMinMageSum + mEquipCon.Equip_MinMagAct * (1 + occMastery + addPro));
                equipMaxMageSum = (int)(equipMaxMageSum + mEquipCon.Equip_MaxMagAct * (1 + occMastery + addPro));
                equipMinDefSum = (int)(equipMinDefSum + mEquipCon.Equip_MinDef * (1 + occMastery + addPro));
                equipMaxDefSum = (int)(equipMaxDefSum + mEquipCon.Equip_MaxDef * (1 + occMastery + addPro));
                equipMinAdfSum = (int)(equipMinAdfSum + mEquipCon.Equip_MinAdf * (1 + occMastery + addPro));
                equipMaxAdfSum = (int)(equipMaxAdfSum + mEquipCon.Equip_MaxAdf * (1 + occMastery + addPro));

                /*
                equipHpSum = (int)(equipHpSum + mEquipCon.Equip_Hp * (1 + occMastery + addPro) + BaseHp_EquipSuit);
                equipMinActSum = (int)(equipMinActSum + mEquipCon.Equip_MinAct * (1 + occMastery + addPro) + BaseMinAct_EquipSuit);
                equipMaxActSum = (int)(equipMaxActSum + mEquipCon.Equip_MaxAct * (1 + occMastery + addPro) + BaseMaxAct_EquipSuit);
                equipMinMageSum = (int)(equipMinMageSum + mEquipCon.Equip_MinMagAct * (1 + occMastery + addPro) + BaseMinMage_EquipSuit);
                equipMaxMageSum = (int)(equipMaxMageSum + mEquipCon.Equip_MaxMagAct * (1 + occMastery + addPro) + BaseMaxMage_EquipSuit);
                equipMinDefSum = (int)(equipMinDefSum + mEquipCon.Equip_MinDef * (1 + occMastery + addPro) + BaseMinDef_EquipSuit);
                equipMaxDefSum = (int)(equipMaxDefSum + mEquipCon.Equip_MaxDef * (1 + occMastery + addPro) + BaseMaxDef_EquipSuit);
                equipMinAdfSum = (int)(equipMinAdfSum + mEquipCon.Equip_MinAdf * (1 + occMastery + addPro) + BaseMinAdf_EquipSuit);
                equipMaxAdfSum = (int)(equipMaxAdfSum + mEquipCon.Equip_MaxAdf * (1 + occMastery + addPro) + BaseMaxAdf_EquipSuit);
                */

                //存储特殊属性
                for (int y = 0; y < mEquipCon.AddPropreListType.Length; y++)
                {
                    if (mEquipCon.AddPropreListType[y] != 0 && mEquipCon.AddPropreListValue.Length > y)
                    {
                        //记录属性
                        AddUpdateProDicList(mEquipCon.AddPropreListType[y], (long)mEquipCon.AddPropreListValue[y], UpdateProDicList);
                    }
                }

                //获取宝石属性
                if (string.IsNullOrEmpty(equipList[i].GemIDNew))
                {
                    equipList[i].GemIDNew = ConfigData.DefaultGem;
                    //Log.Debug($"GemIDNew==null  unit.Id: {unit.Id} BagInfoID:{equipList[i].BagInfoID}");
                }

                string[] gemList = equipList[i].GemIDNew.Split('_');

                for (int z = 0; z < gemList.Length; z++)
                {

                    int gemID = int.Parse(gemList[z]);
                    if (gemID == 0)
                    {
                        continue;
                    }

                    //史诗宝石数量最多4个
                    ItemConfig itemGemCof = ItemConfigCategory.Instance.Get(gemID);
                    if (itemGemCof.ItemSubType == 110)
                    {
                        if (ShiShiGemID.Contains(itemGemCof.Id))
                        {
                            //重复宝石直接跳出
                            continue;
                        }
                        else
                        {
                            equipShiShiGemNum += 1;
                            ShiShiGemID.Add(itemGemCof.Id);
                        }
                    }

                    if (equipShiShiGemNum > 4 && itemGemCof.ItemSubType == 110)
                    {
                        continue;
                    }

                    // "100403;10@100203;60
                    ItemConfig gemitemCof = ItemConfigCategory.Instance.Get(gemID);
                    string[] attributeList = gemitemCof.ItemUsePar.Split('@');
                    for (int a = 0; a < attributeList.Length; a++)
                    {
                        //100203;113
                        string attributeItem = attributeList[a];
                        string[] attributeInfo = attributeItem.Split(';');
                        int gemPro = 0;
                        try
                        {
                            gemPro = int.Parse(attributeInfo[0]);
                        }
                        catch (Exception ex)
                        {
                            Log.Debug("attri: " + ex.ToString());
                            continue;
                        }

                        long gemValue = long.Parse(attributeInfo[1]);

                        //浮点数处理
                        if (NumericHelp.GetNumericValueType(gemPro) == 2)
                        {
                            //gemValue = gemValue * 10000;
                        }

                        //宝石专精
                        if (equipList[i].HideSkillLists.Contains(68000108) || equipList[i].IncreaseSkillLists.Contains(2108) || equipList[i].IncreaseSkillLists.Contains(3902))
                        {
                            gemValue = (long)((float)gemValue * 1.2f);
                        }

                        AddUpdateProDicList(gemPro, gemValue, UpdateProDicList);
                    }
                }
            }

            //生命护盾
             List<PropertyValue> lifeShieldList = unit.GetComponent<SkillSetComponentS>().GetShieldProLists();
             for (int i = 0; i < lifeShieldList.Count; i++)
             {
                 AddUpdateProDicList(lifeShieldList[i].HideID, lifeShieldList[i].HideValue, UpdateProDicList);
             }
            
             //称号属性
             List<PropertyValue> titlePros = unit.GetComponent<TitleComponentS>().GetTitlePro();
             for (int i = 0; i < titlePros.Count; i++)
             {
                 AddUpdateProDicList(titlePros[i].HideID, titlePros[i].HideValue, UpdateProDicList);
             }
            
             //家园属性
             List<PropertyValue> jiayuanPros = unit.GetComponent<JiaYuanComponentS>().GetJianYuanPro();
             for (int i = 0; i < jiayuanPros.Count; i++)
             {
                 AddUpdateProDicList(jiayuanPros[i].HideID, jiayuanPros[i].HideValue, UpdateProDicList);
             }
            
             //技能属性
             List<PropertyValue> skillProList = unit.GetComponent<SkillSetComponentS>().GetSkillRoleProLists();
             for (int i = 0; i < skillProList.Count; i++)
             {
                 //Log.Info("隐藏:" + skillProList[i].HideID + "skillProList[i].HideValue = " + skillProList[i].HideValue);
                 AddUpdateProDicList(skillProList[i].HideID, skillProList[i].HideValue, UpdateProDicList);
             }
            
             //坐骑属性
             List<PropertyValue> zuoqiPros = unit.GetComponent<UserInfoComponentS>().GetZuoQiPro();
             for (int i = 0; i < zuoqiPros.Count; i++)
             {
                 AddUpdateProDicList(zuoqiPros[i].HideID, zuoqiPros[i].HideValue, UpdateProDicList);
             }
            
             //收集属性
             List<PropertyValue> shoujiProList = unit.GetComponent<ShoujiComponentS>().GetProList();
             for (int i = 0; i < shoujiProList.Count; i++)
             {
                 AddUpdateProDicList(shoujiProList[i].HideID, shoujiProList[i].HideValue, UpdateProDicList);
             }
            
             //精灵属性
             List<PropertyValue> jinglingProList = unit.GetComponent<ChengJiuComponentS>().GetJingLingProLists();
             for (int i = 0; i < jinglingProList.Count; i++)
             {
                 AddUpdateProDicList(jinglingProList[i].HideID, jinglingProList[i].HideValue, UpdateProDicList);
             }
             
             //宠物图鉴属性
             List<PropertyValue> pettujianProList = unit.GetComponent<ChengJiuComponentS>().GetPetTuJianProLists();
             for (int i = 0; i < pettujianProList.Count; i++)
             {
                 AddUpdateProDicList(pettujianProList[i].HideID, pettujianProList[i].HideValue, UpdateProDicList);
             }

             //公会修炼属性
             int xiuLian_0 = numericComponent.GetAsInt(NumericType.UnionXiuLian_0);
             int xiuLian_1 = numericComponent.GetAsInt(NumericType.UnionXiuLian_1);
             int xiuLian_2 = numericComponent.GetAsInt(NumericType.UnionXiuLian_2);
             int xiuLian_3 = numericComponent.GetAsInt(NumericType.UnionXiuLian_3);
             List<int> unionXiuLianids = new List<int>() { xiuLian_0, xiuLian_1, xiuLian_2, xiuLian_3 };
             for (int i = 0; i < unionXiuLianids.Count; i++)
             {
                 if (unionXiuLianids[i] == 0)
                 {
                     continue;
                 }

                 UnionQiangHuaConfig unionQiangHuaCof = UnionQiangHuaConfigCategory.Instance.Get(unionXiuLianids[i]);
                 List<PropertyValue> jiazuProList = new List<PropertyValue>();
                 NumericHelp.GetProList(unionQiangHuaCof.EquipPropreAdd, jiazuProList);
                 for (int pro = 0; pro < jiazuProList.Count; pro++)
                 {
                     AddUpdateProDicList(jiazuProList[pro].HideID, jiazuProList[pro].HideValue, UpdateProDicList);
                 }
             }

             //宠物装甲
             List<int> petZhuangJiaList = unit.GetComponent<PetComponentS>().PetZhuangJiaList;
             for (int i = 0; i < petZhuangJiaList.Count; i++)
             {
                 PetZhuangJiaConfig petZhuangJiaConfig = PetZhuangJiaConfigCategory.Instance.Get(petZhuangJiaList[i]);
                 List<PropertyValue> proList = new List<PropertyValue>();
                 NumericHelp.GetProList(petZhuangJiaConfig.PropreAdd, proList);
                 for (int pro = 0; pro < proList.Count; pro++)
                 {
                     AddUpdateProDicList(proList[pro].HideID, proList[pro].HideValue, UpdateProDicList);
                 }
             }
             
             //血石
             int bloodstone = numericComponent.GetAsInt(NumericType.Bloodstone);
             if (bloodstone > 0)
             {
                 PublicQiangHuaConfig publicQiangHuaConfig = PublicQiangHuaConfigCategory.Instance.Get(bloodstone);
                 List<PropertyValue> publicqianghuaProList = new List<PropertyValue>();
                 NumericHelp.GetProList(publicQiangHuaConfig.EquipPropreAdd, publicqianghuaProList);
                 for (int pro = 0; pro < publicqianghuaProList.Count; pro++)
                 {
                     AddUpdateProDicList(publicqianghuaProList[pro].HideID, publicqianghuaProList[pro].HideValue, UpdateProDicList);
                 }
             }
             
             //公会属性
             List<int> unionAttributes = new List<int>() {  NumericType.UnionAttribute_1, NumericType.UnionAttribute_2 };
             for ( int unionattri = 0;  unionattri < unionAttributes.Count; unionattri++ )
             {
                 int unionattriid = numericComponent.GetAsInt(unionAttributes[unionattri]);
                 if (unionattriid == 0)
                 {
                     continue;
                 }

                 PublicQiangHuaConfig publicQiangHuaConfig_2 = PublicQiangHuaConfigCategory.Instance.Get(unionattriid);
                 List<PropertyValue>  publicqianghuaProList_2 = new List<PropertyValue>();
                 NumericHelp.GetProList(publicQiangHuaConfig_2.EquipPropreAdd, publicqianghuaProList_2);
                 for (int pro = 0; pro < publicqianghuaProList_2.Count; pro++)
                 {
                     AddUpdateProDicList(publicqianghuaProList_2[pro].HideID, publicqianghuaProList_2[pro].HideValue, UpdateProDicList);
                 }
             }

             //宠物修炼属性。 玩家数值
             int pet_xiuLian_0 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_0);
             int pet_xiuLian_1 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_1);
             int pet_xiuLian_2 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_2);
             int pet_xiuLian_3 = numericComponent.GetAsInt(NumericType.UnionPetXiuLian_3);
             List<int> petUnionXiuLianids = new List<int>() { pet_xiuLian_0, pet_xiuLian_1, pet_xiuLian_2, pet_xiuLian_3 };
             for (int i = 0; i < petUnionXiuLianids.Count; i++)
             {
                 if (petUnionXiuLianids[i] == 0)
                 {
                     continue;
                 }
                 UnionQiangHuaConfig unionQiangHuaCof = UnionQiangHuaConfigCategory.Instance.Get(petUnionXiuLianids[i]);
                 List<PropertyValue> jiazuProList = new List<PropertyValue>();
                 NumericHelp.GetProList(unionQiangHuaCof.EquipPropreAdd, jiazuProList);
                 for (int pro = 0; pro < jiazuProList.Count; pro++)
                 {
                     AddUpdateProDicList(jiazuProList[pro].HideID, jiazuProList[pro].HideValue, UpdateProDicList);
                 }
             }

             List<int> unionKejiIds = userInfo.UnionKeJiList;
             for (int i = 0; i < unionKejiIds.Count; i++)
             {
                 UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(unionKejiIds[i]);
                 List<PropertyValue> jiazuProList = new List<PropertyValue>();
                 NumericHelp.GetProList(unionKeJiConfig.EquipPropreAdd, jiazuProList);
                 for (int pro = 0; pro < jiazuProList.Count; pro++)
                 {
                     AddUpdateProDicList(jiazuProList[pro].HideID, jiazuProList[pro].HideValue, UpdateProDicList);
                 }
             }

             // 神兽羁绊属性
             int shenshouNumber = unit.GetComponent<PetComponentS>().GetShenShouNumber();
             List<PropertyValue> shenshoujiban = new List<PropertyValue>();
             foreach ((int petnumber, List<PropertyValue> prolist) in ConfigData.ShenShouJiBan)
             {
                 if (shenshouNumber >= petnumber)
                 {
                     shenshoujiban.AddRange(prolist);
                 }
             }
            
             for (int i = 0; i < shenshoujiban.Count; i++)
             {
                 AddUpdateProDicList(shenshoujiban[i].HideID, shenshoujiban[i].HideValue, UpdateProDicList);
             }

            
            //汇总属性
            long BaseHp = occBaseHp + equipHpSum + BaseHp_EquipSuit;
            long BaseMinAct = occBaseMinAct + equipMinActSum + BaseMinAct_EquipSuit;
            long BaseMaxAct = occBaseMaxAct + equipMaxActSum + BaseMaxAct_EquipSuit;
            long BaseMinMage = occBaseMinMage + equipMinMageSum + BaseMinMage_EquipSuit;
            long BaseMaxMage = occBaseMaxMage + equipMaxMageSum + BaseMaxMage_EquipSuit;
            long BaseMinDef = occBaseMinDef + equipMinDefSum + BaseMinDef_EquipSuit;
            long BaseMaxDef = occBaseMaxDef + equipMaxDefSum + BaseMaxDef_EquipSuit;
            long BaseMinAdf = occBaseMinAdf + equipMinAdfSum + BaseMinAdf_EquipSuit;
            long BaseMaxAdf = occBaseMaxAdf + equipMaxAdfSum + BaseMaxAdf_EquipSuit;
            double BaseMoveSpeed = occBaseMoveSpeed;
            double BaseCri = occBaseCri + BaseCri_EquipSuit;
            double BaseHit = occBaseHit + BaseHit_EquipSuit;
            double BaseDodge = occBaseDodge + BaseDodge_EquipSuit;
            double BaseDefSub = occBaseDefSub;
            double BaseAdfSub = occBaseAdfSub;
            double BaseDamgeAdd = BaseDamgeAdd_EquipSuit;
            double BaseDamgeSub = occBaseDamgeSubAdd + BaseDamgeSub_EquipSuit;

            //更新基础属性
            AddUpdateProDicList(NumericType.Base_MaxHp_Base, BaseHp, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinAct_Base, BaseMinAct, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxAct_Base, BaseMaxAct, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_Mage_Base, BaseMaxMage, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinDef_Base, BaseMinDef, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxDef_Base, BaseMaxDef, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinAdf_Base, BaseMinAdf, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxAdf_Base, BaseMaxAdf, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_Speed_Base, (int)(BaseMoveSpeed * 10000), UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_Cri_Base, (int)(BaseCri * 10000), UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_Hit_Base, (int)(BaseHit * 10000), UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_Dodge_Base, (int)(BaseDodge * 10000), UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_ActDamgeSubPro_Base, (int)(BaseDefSub * 10000), UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MageDamgeSubPro_Base, (int)(BaseAdfSub * 10000), UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_DamgeAddPro_Base, (int)(BaseDamgeAdd * 10000), UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_DamgeSubPro_Base, (int)(BaseDamgeSub * 10000), UpdateProDicList);

            //怒气
            if (userInfo.Occ == 3)
            {
                AddUpdateProDicList((int)NumericType.Max_SkillUseMP_Base, 100, UpdateProDicList);
            }

            //缓存一级属性
            long Power_value = GetOnePro(NumericType.Now_Power, UpdateProDicList);
            long Agility_value = GetOnePro(NumericType.Now_Agility, UpdateProDicList);
            long Intellect_value = GetOnePro(NumericType.Now_Intellect, UpdateProDicList);
            long Stamina_value = GetOnePro(NumericType.Now_Stamina, UpdateProDicList);
            long Constitution_value = GetOnePro(NumericType.Now_Constitution, UpdateProDicList);
            
            //--------------------新版属性加点------------------------

            long Power_value_add = 0;
            long Intellect_value_add = 0;
            long Agility_value_add = 0;
            long Stamina_value_add = 0;
            long Constitution_value_add = 0;


            //力量加物理穿透
            int wuliChuanTouLv = (PointLiLiang + (int)Power_value + (int)Power_value_add) * 5;
            float adddWuLiChuanTou = LvProChange(wuliChuanTouLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_HuShiActPro_Add, (int)(adddWuLiChuanTou * 10000), UpdateProDicList);

            //智力加魔法穿透
            int mageChuanTouLv = (PointZhiLi + (int)Intellect_value + (int)Intellect_value_add) * 5;
            float adddMageChuanTou = LvProChange(mageChuanTouLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_HuShiMagePro_Add, (int)(adddMageChuanTou * 10000), UpdateProDicList);

            //敏捷冷却时间
            int cdTimeLv = (PointMinJie + (int)Agility_value + (int)Agility_value_add) * 2;
            float addMinJie = LvProChange(cdTimeLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_SkillCDTimeCostPro_Add, (int)(addMinJie * 10000), UpdateProDicList);

            //耐力
            int huixueLv = (PointNaiLi + (int)Stamina_value + (int)Stamina_value_add);
            AddUpdateProDicList((int)NumericType.Base_HuiXue_Add, huixueLv, UpdateProDicList);

            //体力
            int damgeProCostLv = (PointTiZhi + (int)Constitution_value + (int)Constitution_value_add) * 2;
            float damgeProCost = LvProChange(damgeProCostLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_DamgeSubPro_Add, (int)(damgeProCost * 10000), UpdateProDicList);


            //属性点加成
            //二次计算暴击等属性
            long criLv = numericComponent.GetAsLong(NumericType.Now_CriLv);
            long hitLv = numericComponent.GetAsLong(NumericType.Now_HitLv);
            long dodgeLv = numericComponent.GetAsLong(NumericType.Now_DodgeLv);
            long resLv = numericComponent.GetAsLong(NumericType.Now_ResLv);
            long zhongjiLv = numericComponent.GetAsLong(NumericType.Now_ZhongJiLv);

            AddUpdateProDicList((int)NumericType.Base_CriLv_Add, criLv, UpdateProDicList);
            AddUpdateProDicList((int)NumericType.Base_HitLv_Add, hitLv, UpdateProDicList);
            AddUpdateProDicList((int)NumericType.Base_DodgeLv_Add, dodgeLv, UpdateProDicList);
            AddUpdateProDicList((int)NumericType.Base_ResLv_Add, resLv, UpdateProDicList);
            AddUpdateProDicList((int)NumericType.Base_ZhongJiPro_Add, zhongjiLv, UpdateProDicList);

            // 更新战力
            UnitUpdateCombat(unit, notice, rank, UpdateProDicList, equipList, testItemInfo);
            
            // --- 以下方法不加入战力计算 ---

            //晶核列表
            List<ItemInfo> jingHeList = unit.GetComponent<BagComponentS>().GetCurJingHeList();
            for (int i = 0; i < jingHeList.Count; i++)
            {
                //存储装备精炼数值
                if (jingHeList[i].XiLianHideProLists != null)
                {
                    for (int y = 0; y < jingHeList[i].XiLianHideProLists.Count; y++)
                    {
                        HideProList hidePro = jingHeList[i].XiLianHideProLists[y];
                        AddUpdateProDicList(hidePro.HideID, hidePro.HideValue, UpdateProDicList);
                    }
                }
            }

            //家园守护
            List<PropertyValue> shouhuPros = unit.GetComponent<PetComponentS>().GetPetShouHuPro();
            for (int i = 0; i < shouhuPros.Count; i++)
            {
                AddUpdateProDicList(shouhuPros[i].HideID, shouhuPros[i].HideValue, UpdateProDicList);
            }

            //天赋系统
            List<PropertyValue> tianfuProList = unit.GetComponent<SkillSetComponentS>().GetTianfuRoleProLists();
            for (int i = 0; i < tianfuProList.Count; i++)
            {
                AddUpdateProDicList(tianfuProList[i].HideID, tianfuProList[i].HideValue, UpdateProDicList);
            }

            List<PropertyValue> skillProList_8 = unit.GetComponent<SkillSetComponentS>().GetSkillRoleProLists_8();
            for (int i = 0; i < skillProList_8.Count; i++)
            {
                switch (skillProList_8[i].HideID)
                {
                    case NumericType.Base_Power_Add:
                        Power_value_add += skillProList_8[i].HideValue;
                        break;
                    case NumericType.Base_Intellect_Add:
                        Intellect_value_add += skillProList_8[i].HideValue;
                        break;
                    case NumericType.Base_Agility_Add:
                        Agility_value_add += skillProList_8[i].HideValue;
                        break;
                    case NumericType.Base_Stamina_Add:
                        Stamina_value_add += skillProList_8[i].HideValue;
                        break;
                    case NumericType.Base_Constitution_Add:
                        Constitution_value_add += skillProList_8[i].HideValue;
                        break;
                    default:
                        AddUpdateProDicList(skillProList_8[i].HideID, skillProList_8[i].HideValue, UpdateProDicList);
                        break;
                }
            }

            //缓存一级属性
            Power_value = GetOnePro(NumericType.Now_Power, UpdateProDicList);
            Agility_value = GetOnePro(NumericType.Now_Agility, UpdateProDicList);
            Intellect_value = GetOnePro(NumericType.Now_Intellect, UpdateProDicList);
            Stamina_value = GetOnePro(NumericType.Now_Stamina, UpdateProDicList);
            Constitution_value = GetOnePro(NumericType.Now_Constitution, UpdateProDicList);


            //---加点属性---  加点和1级属性战力做平均
            //力量换算
            if (Power_value > 0 || PointLiLiang > 0)
            {
                long value = Power_value + PointLiLiang + Power_value_add;
                AddUpdateProDicList((int)NumericType.Base_MaxAct_Base, value * 4, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MinAct_Base, value * 1, UpdateProDicList);

                AddUpdateProDicList((int)NumericType.Base_MaxDef_Base, value * 2, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MinDef_Base, value * 1, UpdateProDicList);
                //AddUpdateProDicList((int)NumericType.Base_HitLv_Base, Power_value * 3, UpdateProDicList);
            }

            //敏捷换算
            if (Agility_value > 0 || PointMinJie > 0)
            {
                long value = Agility_value + PointMinJie + Agility_value_add;
                AddUpdateProDicList((int)NumericType.Base_MaxAct_Base, value * 5, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MinAct_Base, value * 2, UpdateProDicList);

                //额外战力附加(因为冷却CD附加的战力少)
            }

            //智力换算
            if (Intellect_value > 0 || PointZhiLi > 0)
            {
                long value = Intellect_value + PointZhiLi + Intellect_value_add;
                AddUpdateProDicList((int)NumericType.Base_Mage_Base, value * 10, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MaxAdf_Base, value * 2, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MinAdf_Base, value * 1, UpdateProDicList);
            }

            //耐力换算
            if (Stamina_value > 0 || PointNaiLi > 0)
            {
                long value = Stamina_value + PointNaiLi + Stamina_value_add;
                AddUpdateProDicList((int)NumericType.Base_MaxDef_Base, value * 3, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MaxAdf_Base, value * 3, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MinDef_Base, value * 2, UpdateProDicList);
                AddUpdateProDicList((int)NumericType.Base_MinAdf_Base, value * 2, UpdateProDicList);
            }

            //体质换算
            if (Constitution_value > 0 || PointTiZhi > 0)
            {
                long value = Constitution_value + PointTiZhi + Constitution_value_add;
                AddUpdateProDicList((int)NumericType.Base_MaxHp_Base, value * 60, UpdateProDicList);
            }

            //更新属性的额外加点属性
            //力量加攻速
            int actSpeedTouLv = (PointLiLiang + (int)Power_value + (int)Power_value_add) * 2;
            float actSpeedChuanTou = LvProChange(actSpeedTouLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_ActSpeedPro_Add, (int)(actSpeedChuanTou * 10000), UpdateProDicList);

            //敏捷加攻速
            int actSpeedTouLv2 = (PointLiLiang + (int)Agility_value + (int)Agility_value_add) * 2;
            float actSpeedChuanTou2 = LvProChange(actSpeedTouLv2, roleLv);
            AddUpdateProDicList((int)NumericType.Base_ActSpeedPro_Add, (int)(actSpeedChuanTou2 * 10000), UpdateProDicList);

            //耐力加抗暴
            int kangbaoLv = (PointNaiLi + (int)Stamina_value + (int)Stamina_value_add) * 4;
            float kangbaoPro = LvProChange(kangbaoLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_Res_Add, (int)(kangbaoPro * 10000), UpdateProDicList);

            //体力加闪避
            int dodgeLv2 = (PointTiZhi + (int)Constitution_value + (int)Constitution_value_add) * 2;
            float dodgePro = LvProChange(dodgeLv2, roleLv);
            AddUpdateProDicList((int)NumericType.Base_Dodge_Add, (int)(dodgePro * 10000), UpdateProDicList);

            //更新基础强化属性
            //攻击加物理穿透
            wuliChuanTouLv = (int)Power_value_add * 5;
            adddWuLiChuanTou = LvProChange(wuliChuanTouLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_HuShiActPro_Add, (int)(adddWuLiChuanTou * 10000), UpdateProDicList);

            //智力加魔法穿透
            mageChuanTouLv = (int)Intellect_value_add * 5;
            adddMageChuanTou = LvProChange(mageChuanTouLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_HuShiMagePro_Add, (int)(adddMageChuanTou * 10000), UpdateProDicList);

            //敏捷冷却时间
            cdTimeLv = (int)Agility_value_add * 2;
            addMinJie = LvProChange(cdTimeLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_SkillCDTimeCostPro_Add, (int)(addMinJie * 10000), UpdateProDicList);

            //耐力
            huixueLv = (int)Stamina_value_add;
            AddUpdateProDicList((int)NumericType.Base_HuiXue_Add, huixueLv, UpdateProDicList);

            //体力
            damgeProCostLv = (int)Constitution_value_add * 2;
            damgeProCost = LvProChange(damgeProCostLv, roleLv);
            AddUpdateProDicList((int)NumericType.Base_DamgeSubPro_Add, (int)(damgeProCost * 10000), UpdateProDicList);

            // 移除鉴定技能后，因为在技能列表中不存在了，技能改变的属性不会触发通知客户端，所以在这重新触发下这些属性，通知一下客户端
            List<int> jianDingPro = new List<int>() { 200503, 200703, 200603, 200803, 203603, 100902, 105101, 105201, 105301, 105401, 105501 };

            for (int i = 0; i < jianDingPro.Count; i++)
            {
                if (!UpdateProDicList.ContainsKey(jianDingPro[i]))
                {
                    UpdateProDicList.Add(jianDingPro[i], 0);
                }
            }

            List<int> keys = new List<int>();

            //更新属性
            foreach (int key in UpdateProDicList.Keys)
            {
                if (jianDingPro.Contains(key))
                {
                    jianDingPro.Remove(key);
                }
                long setValue = numericComponent.GetAsLong(key) + UpdateProDicList[key];
                
                long numType = key;
                if (key > NumericType.Max)
                {
                    numType = key / 100;
                }

                if (!notice)
                {
                    numericComponent.ApplyValue(key, setValue, false);
                    continue;
                }
                if (NumericData.BroadcastType.Contains(key))
                {
                    numericComponent.ApplyValue(key, setValue, notice);
                }
                else
                {
                    numericComponent.ApplyValue(key, setValue, false);
                    keys.Add(key);
                }
            }
            
            if (notice)
            {
                List<int> ks = new List<int>();
                List<long> vs = new List<long>();

                for (int i = 0; i < keys.Count; i++)
                {
                    int nowValue = (int)keys[i] / 100;
                    if (!ks.Contains(nowValue))
                    {
                        ks.Add(nowValue);
                        vs.Add(numericComponent.GetAsLong(nowValue));
                    }
                }

                M2C_UnitNumericListUpdate m2C_UnitNumericListUpdate = M2C_UnitNumericListUpdate.Create();
                //通知自己
                m2C_UnitNumericListUpdate.UnitID = unit.Id;
                m2C_UnitNumericListUpdate.Vs = vs;
                m2C_UnitNumericListUpdate.Ks = ks;
                MapMessageHelper.SendToClient(unit, m2C_UnitNumericListUpdate);
            }
        }

        private static long ReturnGetFightNumLong(int numericType, Dictionary<int, long> dic)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long addValue = 0;
            dic.TryGetValue(add, out addValue);
            long mulValue = 0;
            dic.TryGetValue(mul, out mulValue);
            long finalAddValue = 0;
            dic.TryGetValue(finalAdd, out finalAddValue);

            long nowPropertyValue = (long)(addValue * (1 + (float)mulValue / 10000) + finalAddValue);

            return nowPropertyValue;
        }

        private static float ReturnGetFightNumfloat(int numericType, Dictionary<int, long> dic)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long addValue = 0;
            dic.TryGetValue(add, out addValue);
            long mulValue = 0;
            dic.TryGetValue(mul, out mulValue);
            long finalAddValue = 0;
            dic.TryGetValue(finalAdd, out finalAddValue);
            
            long nowPropertyValue = (long)(addValue * (1 + (float)mulValue / 10000) + finalAddValue);

            return nowPropertyValue / 10000f;
        }
        
        private static void UnitUpdateCombat(Unit unit, bool notice, bool rank, Dictionary<int, long> UpdateProDicList, List<ItemInfo> equipList , ItemInfo testItemInfo)
        {
            //基础职业属性
            UserInfoComponentS unitInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = unitInfoComponentS.UserInfo;
            int roleLv = userInfo.Lv;
            
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            
            //属性点
            int PointLiLiang = GetPoint(numericComponent.GetAsInt(NumericType.PointLiLiang), roleLv);
            int PointZhiLi = GetPoint(numericComponent.GetAsInt(NumericType.PointZhiLi), roleLv);
            int PointTiZhi = GetPoint(numericComponent.GetAsInt(NumericType.PointTiZhi), roleLv);
            int PointNaiLi = GetPoint(numericComponent.GetAsInt(NumericType.PointNaiLi), roleLv);
            int PointMinJie = GetPoint(numericComponent.GetAsInt(NumericType.PointMinJie), roleLv);
            
            long Power_value = GetOnePro(NumericType.Now_Power, UpdateProDicList);
            long Agility_value = GetOnePro(NumericType.Now_Agility, UpdateProDicList);
            long Intellect_value = GetOnePro(NumericType.Now_Intellect, UpdateProDicList);
            long Stamina_value = GetOnePro(NumericType.Now_Stamina, UpdateProDicList);
            long Constitution_value = GetOnePro(NumericType.Now_Constitution, UpdateProDicList);

            //战力计算
            long ShiLi_Act = 0;
            float ShiLi_ActPro = 0f;
            long ShiLi_Def = 0;
            float ShiLi_DefPro = 0f;
            long ShiLi_Hp = 0;
            float ShiLi_HpPro = 0f;
            //long proLvAdd = criLv + hitLv + dodgeLv + resLv + skillAddLv;
            long proLvAdd = 0;

            //传承鉴定特殊属性加成
            int chuanchengProAdd = 0;
            for (int i = equipList.Count - 1; i >= 0; i--)
            {
                if (equipList[i].InheritSkills.Count >= 1)
                {
                    chuanchengProAdd += 500;
                }
            }


            //攻击部分
            foreach (var Item in NumericData.ZhanLi_Act)
            {
                ShiLi_Act += (int)((float)ReturnGetFightNumLong(Item.Key, UpdateProDicList) * Item.Value);
            }

            //隐藏技能战力
            int skillFightValue = 0;

            for (int i = 0; i < equipList.Count; i++)
            {
                for (int z = 0; z < equipList[i].HideSkillLists.Count; z++)
                {

                    Dictionary<int, HideProListConfig> hideCof = new Dictionary<int, HideProListConfig>();
                    hideCof = HideProListConfigCategory.Instance.GetAll();

                    foreach (HideProListConfig hideProConfig in hideCof.Values)
                    {
                        if (hideProConfig.PropertyType == equipList[i].HideSkillLists[z])
                        {
                            skillFightValue += hideProConfig.AddFightValue;
                        }
                    }
                }
            }

            //隐藏技能算在攻击部分
            ShiLi_Act += skillFightValue;

            foreach (var Item in NumericData.ZhanLi_ActPro)
            {
                ShiLi_ActPro += ((float)ReturnGetFightNumfloat(Item.Key, UpdateProDicList) * Item.Value);
            }

            //幸运副本附加
            long luck = 0;
            UpdateProDicList.TryGetValue(NumericType.Now_Luck, out luck);
            switch (luck)
            {
                case 0:
                    ShiLi_ActPro += 0.01f;
                    break;
                case 1:
                    ShiLi_ActPro += 0.02f;
                    break;
                case 2:
                    ShiLi_ActPro += 0.04f;
                    break;
                case 3:
                    ShiLi_ActPro += 0.08f;
                    break;
                case 4:
                    ShiLi_ActPro += 0.12f;
                    break;
                case 5:
                    ShiLi_ActPro += 0.2f;
                    break;
                case 6:
                    ShiLi_ActPro += 0.3f;
                    break;
                case 7:
                    ShiLi_ActPro += 0.4f;
                    break;
                case 8:
                    ShiLi_ActPro += 0.5f;
                    break;
                case 9:
                    ShiLi_ActPro += 0.9f;
                    break;

                default:
                    ShiLi_ActPro += 1f;
                    break;
            }

            //防御部分
            foreach (var Item in NumericData.ZhanLi_Def)
            {
                ShiLi_Def += (int)((float)ReturnGetFightNumLong(Item.Key, UpdateProDicList) * Item.Value);
            }

            foreach (var Item in NumericData.ZhanLi_DefPro)
            {
                ShiLi_DefPro += ((float)ReturnGetFightNumfloat(Item.Key, UpdateProDicList) * Item.Value);
            }

            //血量部分
            foreach (var Item in NumericData.ZhanLi_Hp)
            {
                ShiLi_Hp += (int)((float)ReturnGetFightNumLong(Item.Key, UpdateProDicList) * Item.Value);
            }

            foreach (var Item in NumericData.ZhanLi_HpPro)
            {
                ShiLi_HpPro += ((float)ReturnGetFightNumfloat(Item.Key, UpdateProDicList) * Item.Value);
            }

            //宠物守护附加战力
            int fightNum = 0;
            PetComponentS petCom = unit.GetComponent<PetComponentS>();
            for (int i = 0; i < 4; i++)
            {
                if (petCom.PetShouHuList.Count < 4)
                {
                    break;
                }
            
                RolePetInfo rolePetInfoNow = petCom.GetPetInfo(petCom.PetShouHuList[i]);
                if (rolePetInfoNow == null)
                {
                    continue;
                }
                fightNum = fightNum + rolePetInfoNow.PetPingFen;
            }

            int addShouHuFight = (int)fightNum / 10;

            //其他战力附加
            int addZhanLi = numericComponent.GetAsInt(NumericType.Now_FightValue);

            //觉醒战力附加
            List<int> juexingSkillList = unit.GetComponent<SkillSetComponentS>().GetJueSkillIds();
            int addJueXingZhanLi = 0;
            if (juexingSkillList.Count >= 1)
            {
                addJueXingZhanLi = Math.Min(juexingSkillList.Count, 3) * 300;
            }
            if (juexingSkillList.Count >= 4)
            {
                addJueXingZhanLi += (Math.Min(juexingSkillList.Count, 7) - 3) * 400;
            }
            if (juexingSkillList.Count >= 8)
            {
                addJueXingZhanLi += 500;
            }

            addZhanLi += addJueXingZhanLi;

            //加点属性,每个1级属性6个战力
            // int OneProAddValue = 6;
            // long OneProvalueNaiLi = (long)((Stamina_value + PointNaiLi) * OneProAddValue * (1 + ShiLi_DefPro));
            // long OneProvalueZhiLi = (long)((Intellect_value + PointZhiLi) * OneProAddValue * (1 + ShiLi_ActPro * 0.5f));
            // long OneProvalueMinJie = (long)((Agility_value + PointMinJie) * OneProAddValue * (1 + ShiLi_ActPro * 0.5f));
            // long OneProvalueLiLiang = (long)((Power_value + PointLiLiang) * OneProAddValue * (1 + ShiLi_ActPro * 0.5f));
            // long OneProvalueTiZhi = (long)((Constitution_value + PointTiZhi) * OneProAddValue * (1 + ShiLi_HpPro));
            // addZhanLi += (int)(OneProvalueNaiLi + OneProvalueZhiLi + OneProvalueMinJie + OneProvalueLiLiang + OneProvalueTiZhi);
            
            int OneProAddValue = 10;
            long OneProvalueNaiLi = (long)((Stamina_value + PointNaiLi) * OneProAddValue );
            long OneProvalueZhiLi = (long)((Intellect_value + PointZhiLi) * OneProAddValue);
            long OneProvalueMinJie = (long)((Agility_value + PointMinJie) * OneProAddValue );
            long OneProvalueLiLiang = (long)((Power_value + PointLiLiang) * OneProAddValue );
            long OneProvalueTiZhi = (long)((Constitution_value + PointTiZhi) * OneProAddValue );
            addZhanLi = (int)((OneProvalueNaiLi + OneProvalueZhiLi + OneProvalueMinJie + OneProvalueLiLiang + OneProvalueTiZhi));   //属性点放大系数
            
            //技能属性点附加战力
            int skillPointFight = (roleLv - userInfo.Sp);  //剩余属性点

            skillPointFight = skillPointFight * 50;
            if (skillPointFight < 0)
            {
                skillPointFight = 0;
            }
            //理论不会超过此值
            if (skillPointFight >= 5000)
            {
                skillPointFight = 5000;
            }

            int zhanliValue = (int)(ShiLi_Act * (1 + ShiLi_ActPro) + ShiLi_Def * (1 + ShiLi_DefPro) + (ShiLi_Hp * 0.1f) * (1 + ShiLi_HpPro)) +
                    roleLv * 60 + (int)proLvAdd + addZhanLi + addShouHuFight + chuanchengProAdd + skillPointFight;

            long oneProSum = Stamina_value + PointNaiLi + Intellect_value + PointZhiLi + Agility_value + PointMinJie + Power_value + PointLiLiang +
                    Constitution_value + PointTiZhi;
            int addZhanliValue = (int)(zhanliValue * (oneProSum / 30000f));
            if (addZhanliValue > 0)
            {
                zhanliValue = zhanliValue + addZhanliValue;
            }

            //更新战力
            if (testItemInfo == null)
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Combat, zhanliValue.ToString(), notice);
            }
            else
            {
                testItemInfo.BagInfoID = zhanliValue;
            }


            //排行榜
            if (rank)
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRankInfo();
            }
        }
    }
}