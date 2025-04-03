using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UnitNowHP_ONUpdate : AEvent<Scene, Now_Hp_Update>
    {
        protected override async ETTask Run(Scene scene, Now_Hp_Update args)
        {
            Unit unitDefend = args.Defend;
            Unit unitAttack = unitDefend.GetParent<UnitComponent>().Get(args.AttackId);
            if (unitDefend.IsDisposed)
            {
                return;
            }

            if (args.DamgeType == 101) //复活特效
            {
                FunctionEffect.PlaySelfEffect(unitDefend, 30000004);
                return;
            }

            Scene root = unitDefend.Root();
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            long myunitid = root.GetComponent<PlayerInfoComponent>().CurrentRoleId;

            bool mainattack = unitAttack != null && unitAttack.MainHero;
            if (args.ChangeHpValue < 0 && mainattack)
            {
                unitDefend.GetComponent<GameObjectComponent>()?.OnHighLight();
            }

            bool isnotattackSelf = unitAttack != null && unitAttack != unitDefend;
            bool defendisPlayerorBoss = unitDefend.Type == UnitType.Player || unitDefend.IsBoss();
            bool attackisPlayerorBoss = unitAttack != null && (unitAttack.Type == UnitType.Player || unitAttack.IsBoss());

            //攻击英雄或者Boss不能骑马
            if (args.ChangeHpValue < 0 && mainattack && isnotattackSelf && defendisPlayerorBoss)
            {
                root.GetComponent<BattleMessageComponent>().SetRideTargetUnit(unitDefend.Id);
            }

            if (args.ChangeHpValue < 0 && unitDefend.MainHero && isnotattackSelf && attackisPlayerorBoss)
            {
                root.GetComponent<BattleMessageComponent>().SetRideTargetUnit(unitAttack.Id);
            }

            //更新当前血量
            GameObject HpGameObject = null;
            switch (unitDefend.Type)
            {
                case UnitType.Player:
                    UIPlayerHpComponent uiPlayerHpComponent = unitDefend.GetComponent<UIPlayerHpComponent>();
                    if (uiPlayerHpComponent != null)
                    {
                        HpGameObject = uiPlayerHpComponent.GameObject;
                        uiPlayerHpComponent.UpdateBlood();
                    }
                    UIPetHpComponent uiPetHpComponent = unitDefend.GetComponent<UIPetHpComponent>();
                    if (uiPetHpComponent != null)
                    {
                        HpGameObject = uiPetHpComponent.GameObject;
                        uiPetHpComponent.UpdateBlood();
                    }

                    break;
                case UnitType.Monster:
                    UIMonsterHpComponent monsterHpComponent = unitDefend.GetComponent<UIMonsterHpComponent>();
                    if (monsterHpComponent != null)
                    {
                        HpGameObject = monsterHpComponent.GameObject;
                        monsterHpComponent.UpdateBlood();
                    }

                    break;
                case UnitType.Pet:
                    UIPetHpComponent petHpComponent = unitDefend.GetComponent<UIPetHpComponent>();
                    if (petHpComponent != null)
                    {
                        HpGameObject = petHpComponent.GameObject;
                        petHpComponent.UpdateBlood();
                    }
                    break;
                default:
                    break;
            }

            bool showfloattext = unitAttack != null && UnitHelper.GetMasterId(unitAttack) == myunitid;
            if (mapComponent.MapType == MapTypeEnum.PetMelee || mapComponent.MapType == MapTypeEnum.PetMatch)
            {
                showfloattext = true;   
            }

            if (HpGameObject != null && (unitDefend.MainHero || UnitHelper.GetMasterId(unitDefend) == myunitid || showfloattext))
            {
                FallingFontComponent fallingFontComponent = unitDefend.Root().GetComponent<FallingFontComponent>();
                //触发飘字
                (string, FallingFontType, Vector3) showText = GetBattleShowText(args.ChangeHpValue, unitDefend, args.DamgeType);
                fallingFontComponent.Play(HpGameObject, unitDefend, showText.Item1, showText.Item2, showText.Item3, BloodTextLayer.Layer_0,
                    FallingFontExecuteType.Type_0);

                //触发受击特效
                FunctionEffect.PlayHitEffect(unitAttack, unitDefend, args.SkillID);
            }

            //主界面血條
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnUpdateHP(mapComponent.MapType, unitDefend, unitAttack, args.ChangeHpValue);

            if (mapComponent.MapType == MapTypeEnum.PetDungeon
                || mapComponent.MapType == MapTypeEnum.PetTianTi
                || mapComponent.MapType == MapTypeEnum.PetMing)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgPetMain>()?.OnUnitHpUpdate(unitDefend, unitAttack, args.ChangeHpValue);
            }

            if (mapComponent.MapType == MapTypeEnum.PetMelee || mapComponent.MapType == MapTypeEnum.PetMatch)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>()?.OnUnitHpUpdate(unitDefend);
            }

            if (mapComponent.MapType == MapTypeEnum.BaoZang
                && unitDefend.Type == UnitType.Player && unitDefend.MainHero
                && unitAttack != null && unitAttack.Type == UnitType.Player)
            {
                int attackMode = unitDefend.GetAttackMode();
                if (attackMode == 3 && !root.GetComponent<BattleMessageComponent>().AttackSelfPlayer.Contains(unitAttack.Id))
                {
                    root.GetComponent<BattleMessageComponent>().AttackSelfPlayer.Add(unitAttack.Id);
                    FlyTipComponent.Instance.ShowFlyTip($"{unitAttack.GetComponent<UnitInfoComponent>().UnitName} 攻击了你");
                }
            }

            
            // 改为服务器通知
            // if (mapComponent.SceneType == SceneTypeEnum.TrialDungeon   
            //     && unitDefend.Type == UnitType.Monster)
            // {
            //     root.GetComponent<UIComponent>().GetDlgLogic<DlgTrialMain>()?.OnUpdateHurt(args.ChangeHpValue);
            // }

            await ETTask.CompletedTask;
        }

        private static (string, FallingFontType, Vector3) GetBattleShowText(long targetValue, Unit unit, int type)
        {
            FallingFontType fallingFontType = FallingFontType.Target;
            string showText = string.Empty;

            //根据目标Unit设定飘字字体
            string selfNull = "";
            if (unit.MainHero)
            {
                fallingFontType = FallingFontType.Self;
                selfNull = " ";
            }

            //恢复血量
            if (type == 2 || type == 11 || type == 12 || targetValue > 0)
            {
                fallingFontType = FallingFontType.Add;
            }

            //恢复暴击/重击
            if (unit.MainHero == false && type == 1 || type == 3)
            {
                fallingFontType = FallingFontType.Special;
            }

            string addStr = "";

            Vector3 startScale = Vector3.one;

            if (targetValue >= 0 && type == 2)
            {
                addStr = "+";
            }

            if (type == 1)
            {
                addStr = "暴击";
                startScale = new Vector3(1.4f, 1.4f, 1.4f);
            }

            if (type != 2 && type != 11 && type != 12 && targetValue == 0)
            {
                showText = "闪避";
            }
            else if (type == 11)
            {
                showText = "抵抗";
            }
            else if (type == 12)
            {
                showText = "免疫";
            }
            else
            {
                showText = StringBuilderHelper.GetFallText(addStr + selfNull, targetValue);
            }

            return (showText, fallingFontType, startScale);
        }
    }
}