using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Unit_Now_Hp_Update: AEvent<Scene, Now_Hp_Update>
    {
        protected override async ETTask Run(Scene scene, Now_Hp_Update args)
        {
            Log.Debug($"UnitHpUpdate:   {args.Defend.Id} {args.ChangeHpValue} ");

            Unit unitDefend = args.Defend;
            Unit unitAttack = args.Attack;
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
            long myunitid = root.GetComponent<PlayerComponent>().CurrentRoleId;

            bool mainattack = unitAttack != null && unitAttack.MainHero;
            if (args.ChangeHpValue < 0 && mainattack)
            {
                unitDefend.GetComponent<GameObjectComponent>()?.OnHighLight();
            }

            bool isnotattackSelf = unitAttack != null && unitAttack != unitDefend;
            bool defendisPlayerorBoss = unitDefend.Type == UnitType.Player || unitDefend.IsBoss();
            bool attackidPlayerorBoss = unitAttack != null && (unitAttack.Type == UnitType.Player || unitAttack.IsBoss());

            //攻击英雄或者Boss不能骑马
            if (args.ChangeHpValue < 0 && mainattack && isnotattackSelf && defendisPlayerorBoss)
            {
                root.GetComponent<BattleMessageComponent>().SetRideTargetUnit(unitDefend.Id);
            }

            if (args.ChangeHpValue < 0 && unitDefend.MainHero && isnotattackSelf && attackidPlayerorBoss)
            {
                root.GetComponent<BattleMessageComponent>().SetRideTargetUnit(unitAttack.Id);
            }

            //更新当前血量
            GameObject HpGameObject = null;
            switch (unitDefend.Type)
            {
                case UnitType.Player:
                    UIPlayerHpComponent heroHeadBarComponent = unitDefend.GetComponent<UIPlayerHpComponent>();
                    if (heroHeadBarComponent != null)
                    {
                        HpGameObject = heroHeadBarComponent.GameObject;
                        heroHeadBarComponent.UpdateBlood();
                    }
                    break;
            }
           
            bool showfloattext = unitAttack != null && UnitHelper.GetMasterId(unitAttack) == myunitid;
            if (HpGameObject!= null && ( unitDefend.MainHero || UnitHelper.GetMasterId(unitDefend) == myunitid || showfloattext) )
            {
                FallingFontComponent fallingFontComponent = unitDefend.Root().GetComponent<FallingFontComponent>();
                //触发飘字
                fallingFontComponent.Play(HpGameObject, args.ChangeHpValue, unitDefend, args.DamgeType);

                //触发受击特效
                FunctionEffect.PlayHitEffect(unitAttack, unitDefend, args.SkillID);
            }

            //主界面血條
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnUpdateHP(mapComponent.SceneType, unitDefend, unitAttack, args.ChangeHpValue);

            if (mapComponent.SceneType == SceneTypeEnum.PetDungeon
                || mapComponent.SceneType == SceneTypeEnum.PetTianTi
                || mapComponent.SceneType == SceneTypeEnum.PetMing)
            {
                //root.GetComponent<UIComponent>().GetDlgLogic<DlgPetMain>()?.OnUnitHpUpdate(unitDefend, unitAttack, args.ChangeHpValue);
            }

            if (mapComponent.SceneType == SceneTypeEnum.BaoZang
                && unitDefend.Type == UnitType.Player && unitDefend.MainHero
                && unitAttack != null && unitAttack.Type == UnitType.Player)
            {
                int attackMode = unitDefend.GetAttackMode();
                if (attackMode == 3 && !root.GetComponent<BattleMessageComponent>().AttackSelfPlayer.Contains(unitAttack.Id))
                {
                    root.GetComponent<BattleMessageComponent>().AttackSelfPlayer.Add(unitAttack.Id);
                    FlyTipComponent.Instance.SpawnFlyTip($"{unitAttack.GetComponent<UnitInfoComponent>().UnitName} 攻击了你");
                }
            }

            if (mapComponent.SceneType == SceneTypeEnum.TrialDungeon  
                && unitDefend.Type == UnitType.Monster)
            {
                //root.GetComponent<UIComponent>().GetDlgLogic<DlgTrialMain>().OnUpdateHurt(args.ChangeHpValue);
            }

            await ETTask.CompletedTask;
        }
    }
}