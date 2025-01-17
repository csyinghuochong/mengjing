using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    [EntitySystemOf(typeof(SkillS))]
    [FriendOf(typeof(SkillS))]
    public static partial class SkillSSytem
    {
        
        [EntitySystem]
        private static void Awake(this SkillS self)
        {

        }
        [EntitySystem]
        private static void Destroy(this SkillS self)
        {

        }
        
         public static void BaseOnInit(this SkillS self, SkillInfo skillcmd, Unit theUnitFrom)
         {
             self.SkillInfo = skillcmd;
             self.HurtIds.Clear();
             self.LastHurtTimes.Clear();
             self.SkillConf = SkillConfigCategory.Instance.Get(skillcmd.WeaponSkillID);
             self.TheUnitFrom = theUnitFrom;
             SkillSetComponentS skillSetComponent = theUnitFrom.GetComponent<SkillSetComponentS>();
             self.TianfuProAdd = skillSetComponent!=null ? skillSetComponent.GetSkillPropertyAdd(skillcmd.WeaponSkillID):null;

             self.IsExcuteHurt = false;
             self.SkillFirstHurtTime = 0;
             self.SkillTriggerInvelTime = 0;
             self.SkillTriggerLastTime = 0;
             self.OnlyOnceBuffUnitID.Clear();
             self.SkillState = SkillState.Running;
             self.SkillBeginTime = TimeHelper.ServerNow();
             self.DamgeChiXuLastTime = TimeHelper.ServerNow();
             self.SkillExcuteHurtTime = self.SkillBeginTime + (long)(1000 * self.SkillConf.SkillDelayTime);
             self.SkillEndTime = self.SkillBeginTime + self.SkillConf.SkillLiveTime + (long)(1000* self.GetTianfuProAdd((int)SkillAttributeEnum.AddSkillLiveTime));
             self.TargetPosition = new float3(skillcmd.PosX, skillcmd.PosY, skillcmd.PosZ); //获取起始坐标
             self.ICheckShape = new List<Shape>() { self.CreateCheckShape(self.SkillInfo.TargetAngle) };
             self.NowPosition = self.TargetPosition;              //获取技能起始的坐标点
             self.SkillParValueHpUpAct.Clear();
             self.ActTargetAddPro = 0f;
             self.HurtAddPro = 0f;   

             //获取通用脚本参数
             if (CommonHelp.IfNull(self.SkillConf.ComObjParameter) == false)
             {
                 string[] skillParList = self.SkillConf.ComObjParameter.Split('@');
                 for (int i = 0; i < skillParList.Length; i++)
                 {
                     string[] parList = self.SkillConf.ComObjParameter.Split(';');
                     switch (parList[0])
                     {
                         //目标血量低伤害类型
                         case "1":
                             SkillParValue_HpUpAct hpUpAct = new SkillParValue_HpUpAct();
                             hpUpAct.type = 1;
                             hpUpAct.hpNeedPro = float.Parse(parList[1]);
                             hpUpAct.actAddPro = float.Parse(parList[2]);
                             self.SkillParValueHpUpAct.Add(hpUpAct);
                             break;
                         //目标血量低伤害类型
                         case "2":
                             hpUpAct = new SkillParValue_HpUpAct();
                             hpUpAct.type = 2;
                             hpUpAct.hpNeedPro = float.Parse(parList[1]);
                             hpUpAct.actAddPro = float.Parse(parList[2]);
                             self.SkillParValueHpUpAct.Add(hpUpAct);
                             break;
                         //自身血量低攻击提升
                         case "3":
                             float defendUnitHpPro = (float)theUnitFrom.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Hp) / (float)theUnitFrom.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_MaxHp);
                             if (defendUnitHpPro <= float.Parse(parList[1]))
                                 self.ActTargetAddPro= float.Parse(parList[2]);
                             break;
                     }
                 }
             }
         }

         public static float GetTianfuProAdd(this SkillS self, int key)
         {
             float value = 0f;
             if (self.TianfuProAdd == null)
                 return value;
             self.TianfuProAdd.TryGetValue(key, out value);
             return value;
         }

         //初始化
         public static void InitSelfBuff(this SkillS self)
         {
             //触发初始化BUFF
             if (self.SkillConf == null)
             {
                 Log.Error($"self.SkillConf == null {self.SkillInfo.WeaponSkillID}");
             }
             if (self.TheUnitFrom.IsDisposed)
             {
                 Log.Debug($"self.TheUnitFrom.IsDisposed {self.TheUnitFrom.Id}");
                 return;
             }

             if (self.SkillConf.InitBuffID!= null &&self.SkillConf.InitBuffID[0] != 0)
             {
                 for (int y = 0; y < self.SkillConf.InitBuffID.Length; y++)
                 {
                     self.SkillBuff(self.SkillConf.InitBuffID[y], self.TheUnitFrom);
                 }
             }
             SkillSetComponentS skillSetComponent = self.TheUnitFrom.GetComponent<SkillSetComponentS>();
             List<int> buffInitAdd = skillSetComponent!=null ? skillSetComponent.GetBuffInitIdAdd(self.SkillConf.Id):null;
             if (buffInitAdd != null)
             {
                 for (int i = 0; i < buffInitAdd.Count; i++)
                 {
                     self.SkillBuff(buffInitAdd[i], self.TheUnitFrom);
                 }
             }
         }
         
         //每帧检测
         public static void BaseOnUpdate(this SkillS self)
         {
             long serverNow = TimeHelper.ServerNow();

             //根据技能效果延迟触发伤害
             if (serverNow < self.SkillExcuteHurtTime)
             {
                 return;
             }
             //只触发一次，需要多次触发的重写
             if (!self.IsExcuteHurt)
             {
                 self.IsExcuteHurt = true;
                 if (self.SkillConf.SkillTargetType == (int)SkillTargetType.TargetOnly)
                 {
                     Unit targetUnit = self.TheUnitFrom.GetParent<UnitComponent>().Get(self.SkillInfo.TargetID);
                     if (targetUnit != null && self.SkillConf.SkillActType == 1)
                     {
                         self.OnCollisionUnit(targetUnit);
                     }
                     if (targetUnit != null && self.SkillConf.SkillActType ==  0 && self.CheckShape(targetUnit.Position))
                     {
                         self.OnCollisionUnit(targetUnit);
                     }
                 }
                 else if (self.SkillConf.SkillTargetType == (int)SkillTargetType.SelfOnly)
                 {
                     self.OnCollisionUnit(self.TheUnitFrom);
                 }   
                 else
                 {
                     self.ExcuteSkillAction();
                 }
             }

             //根据技能存在时间设置其结束状态
             if (serverNow > self.SkillEndTime)
             {
                 self.SetSkillState(SkillState.Finished);
             }
         }

         public static void ExcuteSkillAction(this SkillS self)
         {
             if (self.TheUnitFrom.IsDisposed)
             {
                 Log.Debug($"self.TheUnitFrom.IsDisposed {self.TheUnitFrom.Id}");
                 return;
             }

             //ListComponent<Unit> entities = ListComponent<Unit>.Create();
             //entities.AddRange(  self.TheUnitFrom.DomainScene().GetComponent<UnitComponent>().GetAll() );
             List<EntityRef<Unit>> entities = self.TheUnitFrom.Scene().GetComponent<UnitComponent>().GetAll();
             for (int i = entities.Count - 1; i >= 0; i--)
             {
                 Unit uu = entities[i];
                 if (self.IfHaveHurtId(uu.Id))
                 {
                     continue;
                 }

                 if (uu.Type == UnitType.Npc || uu.Type == UnitType.Transfers)
                 {
                     continue;
                 }

                 //检测目标是否在技能范围
                 if (!self.CheckShape(uu.Position))
                 {
                     continue;
                 }

                 self.OnAddHurtIds(uu.Id);
                 self.OnCollisionUnit(uu);
             }
         }

         public static bool IfHaveHurtId(this SkillS self, long unitid)
         {
             return self.HurtIds.Contains(unitid);
         }

         public static void OnAddHurtIds(this SkillS self, long unitid)
         {
             self.HurtIds.Add(unitid);
         }
        
         public static bool CheckMaxAttackNumber(this SkillS self, long unitid)
         {
             //MaxAttackNumber ==0 || -1不限制
             int MaxAttackNumber = self.SkillConf.MaxAttackNumber;
             if (MaxAttackNumber > 0 && self.HurtIds.Count >= MaxAttackNumber && !self.HurtIds.Contains(unitid))
             {
                 return true;
             }
             return false;    
         }
        
         public static void OnCollisionUnit(this SkillS self, Unit uu)
         {
             if (!self.SkillCanAttackUnit(uu))
             {
                 return;
             }

             //触发伤害
             bool ishit = self.TriggeSkillHurt(uu, 0);

             //触发Buff
             if (ishit)
             {
                 self.TriggerSkillBuff(uu);
             }
         }

         public static void CheckChiXuHurt(this SkillS self)
         {
             if (self.SkillConf.DamgeChiXuValue == 0 || self.TheUnitFrom.IsDisposed)
             {
                 return;
             }

             long servernow = TimeHelper.ServerNow();
             long interval = self.SkillConf.DamgeChiXuInterval;
             if (servernow - self.DamgeChiXuLastTime < interval)
             {
                 return;
             }
             self.DamgeChiXuLastTime = servernow;
             List<EntityRef<Unit>> entities = self.TheUnitFrom.GetParent<UnitComponent>().GetAll();
             for (int i = entities.Count - 1; i >= 0; i--)
             {
                 Unit uu = entities[i];
                 //检测目标是否在技能范围
                 if (!self.CheckShape(uu.Position))
                 {
                     continue;
                 }
                 self.OnChiXuHurtCollision(uu);
             }
         }

         public static bool SkillCanAttackUnit(this SkillS self, Unit uu)
         {
             //鞭炮打年兽 鞭炮道具10030002 技能76001001年兽 72009001
             if (self.SkillConf.Id == 76001001 && uu.ConfigId != 72009001)
             {
                 return false;
             }
             if (self.SkillConf.Id != 76001001 && uu.ConfigId == 72009001)
             {
                 return false;
             }
             return true;
         }

         public static void OnChiXuHurtCollision(this SkillS self, Unit uu)
         {
             if (!self.SkillCanAttackUnit(uu))
             {
                 return;
             }

             //触发伤害
             bool ishit = self.TriggeSkillHurt(uu, 1);

             //触发Buff
             if (ishit && self.SkillConf.DamgeChiXuTrigerBuff == 1)
             {
                 self.TriggerSkillBuff(uu);
             }
         }

         //目标附加Buff
         public static void TriggerSkillBuff(this SkillS self, Unit uu)
         {
             //触发Buff
             if (self.SkillConf.BuffID!=null && self.SkillConf.BuffID[0] != 0)
             {
                 for (int y = 0; y < self.SkillConf.BuffID.Length; y++)
                 {
                     self.SkillBuff(self.SkillConf.BuffID[y], uu);
                 }
             }
             if (!self.OnlyOnceBuffUnitID.Contains(uu.Id) )
             {
                 self.OnlyOnceBuffUnitID.Add(uu.Id);
                 for (int y = 0; y < self.SkillConf.OnlyOnceBuffID.Length; y++) //int[]  AT
                 {
                     self.SkillBuff(self.SkillConf.OnlyOnceBuffID[y], uu);
                 }
             }

             SkillSetComponentS skillSetComponent = self.TheUnitFrom.GetComponent<SkillSetComponentS>();
             List<int> buffInitAdd = skillSetComponent != null ? skillSetComponent.GetBuffIdAdd(self.SkillConf.Id) : null;
             if (buffInitAdd != null && buffInitAdd.Count > 0)
             {
                 for (int k = 0; k < buffInitAdd.Count; k++)
                 {
                     self.SkillBuff(buffInitAdd[k], uu);
                 }
             }
         }

         
         public static void SetSkillState(this SkillS self,SkillState state)
         {
             self.SkillState = state;
         }

         
         public static bool CheckShape(this SkillS self, float3 t_positon)
         {
             for (int i = 0; i < self.ICheckShape.Count; i++)
             {
                 if (self.ICheckShape[i].Contains(t_positon))
                 {
                     return true;
                 }
             }
             return false;
         }

         public static bool  TriggeSkillHurt(this SkillS self,  Unit uu, int hurtMode = 0)
         {
             //技能伤害为0不执行
             if (hurtMode == 0 && self.SkillConf.ActDamge == 0 && self.SkillConf.DamgeValue == 0) 
             {
                 return true;
             }
             if (hurtMode == 1 && self.SkillConf.DamgeChiXuValue == 0)
             {
                 return true;
             }
             if (!self.TheUnitFrom.IsCanAttackUnit(uu))
             {
                 return true;
             }

             bool clearnTemporary = false;
             if (self.SkillParValueHpUpAct!=null)
             {
                 foreach (SkillParValue_HpUpAct now in self.SkillParValueHpUpAct)
                 {
                     float defendUnitHpPro = (float)uu.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Hp) / (float)uu.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_MaxHp);
                     //血量低于
                     if (now.type == 1) 
                     {
                         if (defendUnitHpPro <= now.hpNeedPro) 
                         {
                             self.ActTargetTemporaryAddPro = now.actAddPro;
                             clearnTemporary = true;
                         }
                     }

                     //血量高于
                     if (now.type == 2)
                     {
                         if (defendUnitHpPro <= now.hpNeedPro)
                         {
                             self.ActTargetTemporaryAddPro = now.actAddPro;
                             clearnTemporary = true;
                         }
                     }
                 }
             }

             if (uu.GetComponent<BuffManagerComponentS>().IsSkillImmune(self.SkillConf.Id))
             {
                 return false;
             }

             bool ishit =  Function_Fight.Fight(self.TheUnitFrom, uu, self, hurtMode);
             if (clearnTemporary)
             {
                 self.ActTargetTemporaryAddPro = 0;      //清空
             }
             if (ishit) 
             {
                 self.SkillFirstHurtTime = TimeHelper.ServerNow();
                 self.TheUnitFrom.GetComponent<SkillManagerComponentS>().CheckSkillSecond(self, uu.Id);
             }
             return ishit;
         }

         public static Shape CreateCheckShape(this SkillS self,  int targetAngle)
         {
             Shape ishape = null;
             float addRange = self.GetTianfuProAdd((int)SkillAttributeEnum.AddDamageRange);

             switch (self.SkillConf.DamgeRangeType)
             {
                 case 0:
                     ishape = new Circle();
                     (ishape as Circle).s_position = self.TargetPosition;
                     (ishape as Circle).range = (float)(self.SkillConf.DamgeRange[0]) + addRange;
                     break;
                 case 1:
                     ishape = new Circle();
                     (ishape as Circle).s_position = self.TargetPosition;
                     (ishape as Circle).range = (float)(self.SkillConf.DamgeRange[0]) + addRange;
                     break;
                 case 2:
                     ishape = new Rectangle();
                     (ishape as Rectangle).s_position = self.TargetPosition;
                     quaternion forward = quaternion.Euler(0, math.radians(targetAngle), 0);
                     (ishape as Rectangle).s_forward = math.mul(forward, math.forward());
                     (ishape as Rectangle).x_range = (float)(self.SkillConf.DamgeRange[0] ) * 0.5f;
                     (ishape as Rectangle).z_range = (float)(self.SkillConf.DamgeRange[1]  + addRange);
                     break;
                 case 3:
                     ishape = new Fan();
                     (ishape as Fan).s_position = self.TargetPosition;
                     (ishape as Fan).s_rotation = quaternion.Euler(0, math.radians(targetAngle), 0);
                     (ishape as Fan).skill_distance = (float)(self.SkillConf.DamgeRange[0]) + addRange;
                     (ishape as Fan).skill_angle = (float)(self.SkillConf.DamgeRange[1]);
                     break;
             }
             return ishape;
         }

         public static void UpdateCheckRotation(this SkillS self, float anglea_1)
         {
             if (self.ICheckShape == null || self.ICheckShape.Count == 0)
             {
                 //Log.Debug($"self.ICheckShape == null: {self.SkillConf.SkillName}");
                 self.SetSkillState( SkillState.Finished );
                 return;
             }

             switch (self.SkillConf.DamgeRangeType)
             {
                 case 0:
                 case 1:
                     break;
                 case 2:
                     //.s_forward = math.mul(quaternion.Euler(0, math.radians(anglea_1), 0), math.forward());
                     (self.ICheckShape[0] as Rectangle).s_forward = math.mul(quaternion.Euler(0, math.radians(anglea_1), 0), new float3(0, 0, 1));
                     break;
                 case 3:
                     (self.ICheckShape[0] as Fan).s_rotation = quaternion.Euler(0, math.radians(anglea_1), 0);
                     break;
             }
         }

         //目前只有冲锋技能用到。 
         public static void UpdateCheckPoint(this SkillS self,  float3 vector3)
         {
             if (self.ICheckShape == null || self.ICheckShape.Count == 0)
             {
                 //Log.Debug($"self.ICheckShape == null: {self.SkillConf.SkillName}");
                 self.SetSkillState( SkillState.Finished );
                 return;
             }

             switch (self.SkillConf.DamgeRangeType)
             {
                 case 0:
                 case 1:
                     (self.ICheckShape[0] as Circle).s_position = vector3;
                     break;
                 case 2:
                     (self.ICheckShape[0] as Rectangle).s_position = vector3;
                     break;
                 case 3:
                     (self.ICheckShape[0] as Fan).s_position = vector3;
                     break;
             }
         }

         public static SkillState GetSkillState(this SkillS self)
         {
             return self.SkillState;
         }

         
         public static bool IsFinished(this SkillS self)
         {
             return self.SkillState == SkillState.Finished;
         }

         
         public static void Clear(this SkillS self)
         {
             self.ICheckShape.Clear();
             self.SkillInfo = null;
         }

         //1：自身
         //2：队友
         //3：己方【同阵营】
         //4: 敌方
         //5：全部
         public static void SkillBuff(this SkillS self, int buffID, Unit uu)
         {
             if (uu == null || uu.IsDisposed)
             {
                 return;
             }
             if (!SkillBuffConfigCategory.Instance.Contain(buffID))
             {
                 Log.Warning($"config==null： buffid{buffID}");
                 return;
             }
             SkillBuffConfig skillBuffConfig = SkillBuffConfigCategory.Instance.Get(buffID);
             bool teshui = uu.Type == UnitType.JingLing && skillBuffConfig.TargetType == 1;
             if (!uu.IsCanBeAttack() && !teshui)
             {
                 return;
             }

             //检测类型
             //if (skillBuffConfig.BuffTargetType != 0 && skillBuffConfig.BuffTargetType != uu.Type)
             //{
             //    return;
             //}
             bool triggerbuff = false;
             int[] buffTargetTypes = skillBuffConfig.BuffTargetType;
             if (buffTargetTypes != null)
             {
                 for (int i = 0; i < buffTargetTypes.Length;i++)
                 {
                     if (buffTargetTypes[i] == 0 || buffTargetTypes[i] == uu.Type)
                     { 
                         triggerbuff = true; 
                     }
                 }
             }
             if (!triggerbuff)
             {
                 return;
             }
             //1：自身
             //2：队友
             //3：己方【同阵营】
             //4: 敌方
             //5：全部
             //6: 己方召唤兽，不包含宠物
             //7: 己方召唤兽，包含宠物
             bool canBuff = false;
             switch (skillBuffConfig.TargetType)
             {
                 //对自己释放
                 case 1:
                     canBuff = uu.Id == self.TheUnitFrom.Id;
                     if (uu.Type == UnitType.JingLing)
                     {
                         long masterid = uu.GetMasterId();
                         uu = uu.GetParent<UnitComponent>().Get(masterid);
                         if (uu == null || uu.IsDisposed)
                         {
                             return;
                         }
                     }
                     break;
                 case 2:
                     PetComponentS petComponent = self.TheUnitFrom.GetComponent<PetComponentS>();  
                     canBuff = self.TheUnitFrom.IsSameTeam(uu) || self.TheUnitFrom.IsMasterOrPet(uu, petComponent);
                     //if (canBuff && skillBuffConfig.Id == 92000032 && uu.Type == UnitType.Monster)
                     //{
                     //    Log.Console("怪物攻速！！！！");
                     //}
                     break;
                 case 3:
                     canBuff = self.TheUnitFrom.GetBattleCamp() == uu.GetBattleCamp();
                     break;
                 //敌方
                 case 4:
                     canBuff = self.TheUnitFrom.IsCanAttackUnit(uu);
                     break;
                 //全部
                 case 5:
                     canBuff = true;
                     break;
                 case 6:////6: 己方召唤兽，不包含宠物
                     canBuff = uu.Type == UnitType.Monster && uu.GetMasterId() == self.TheUnitFrom.Id;
                     break;
                 case 7://// 7: 己方召唤兽，包含宠物
                     canBuff = uu.GetMasterId() == self.TheUnitFrom.Id;
                     break;
                     default
                     : break;    
             }

             if (!canBuff)
             {
                 return;
             }
             
             BuffData buffData = new BuffData();
             buffData.SkillId = self.SkillConf.Id;
             buffData.BuffId = skillBuffConfig.Id;
             uu.GetComponent<BuffManagerComponentS>().BuffFactory(buffData, self.TheUnitFrom, self);
             //Log.Info("结束释放buff" + buffID);
         }
         
         public static void Check_Map(this SkillS self)
         {
             SkillHandlerS aaiHandler = SkillDispatcherComponentS.Instance.Get(self.SkillConf.GameObjectName);
             if (aaiHandler != null)
             {
                 aaiHandler.OnUpdate(self, 1);
             }
         }
    }

}
