using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public static class MapViewHelper
    {

        /// <summary>
        /// 阵营改变，其他玩家的血条颜色做相应调整
        /// </summary>
        /// <param name="self"></param>
        public static void UpdateBattleCamp( Unit mainUnit, long unitId)
        {
            if (mainUnit == null)
            {
                Log.Error("UpdateBattleCamp/mainUnit == null");
            }

            List<Unit> unitlist = UnitHelper.GetUnitsByTypes(mainUnit.Root(), new List<int>(){ UnitType.Player, UnitType.Pet, UnitType.Monster });
            for (int i = 0; i < unitlist.Count; i++)
            {
                bool update = false;
                if (unitlist[i].Id == mainUnit.Id || unitlist[i].Id == unitId || unitId == mainUnit.Id)
                {
                    update = true;
                }

                if (!update)
                {
                    continue;
                }

                bool canAttack = mainUnit.IsCanAttackUnit(unitlist[i]);

                switch (unitlist[i].Type)
                {
                    case UnitType.Player:
                        UIPlayerHpComponent uIUnitHpComponent = unitlist[i].GetComponent<UIPlayerHpComponent>();
                        uIUnitHpComponent?.UpdateCampToMain(canAttack);
                        break;
                    case UnitType.Monster:
                        UIMonsterHpComponent uiMonsterHpComponent = unitlist[i].GetComponent<UIMonsterHpComponent>();
                        uiMonsterHpComponent?.UpdateCampToMain(canAttack);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void OnUnitStallUpdate(this Unit self, long stallType)
        {
            if (stallType > 0)
            {
                self.EnterHide();
            }
            else
            {
                self.ExitHide();
            }
        }
        
        public static void EnterHide(this Unit self)
        {
            self.GetComponent<GameObjectComponent>().EnterHide();
            
            switch(self.Type)
            {
                case UnitType.Player:
                    self.GetComponent<UIPlayerHpComponent>()?.EnterHide();
                    break;
                case UnitType.Monster:
                    self.GetComponent<UIMonsterHpComponent>()?.EnterHide();
                    break;
                case UnitType.Pet:
                    self.GetComponent<UIPetHpComponent>()?.EnterHide();
                    break;
                case UnitType.Npc:
                    self.GetComponent<UINpcHpComponent>()?.EnterHide();
                    break;
                default:
                    break;
            }
        }

        public static void ExitHide(this Unit self)
        {
            self.GetComponent<GameObjectComponent>()?.ExitHide();
            
            switch (self.Type)
            {
                case UnitType.Player:
                    self.GetComponent<UIPlayerHpComponent>()?.ExitHide();
                    break;
                case UnitType.Monster:
                    self.GetComponent<UIMonsterHpComponent>()?.ExitHide();
                    break;
                case UnitType.Pet:
                    self.GetComponent<UIPetHpComponent>()?.ExitHide();
                    break;
                case UnitType.Npc:
                    self.GetComponent<UINpcHpComponent>()?.ExitHide();
                    break;
                default:
                    break;
            }

        }

        public static void ShowOtherUnit(Scene root, bool show, List<long> nohideids)
        {
            List<EntityRef<Unit>> units = root.CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uu = units[i];

                if (uu.MainHero)
                {
                    continue;
                }

                if (show)
                {
                    uu.ExitHide();
                }
                else
                {
                    if (nohideids.Contains(uu.Id))
                    {
                        continue;
                    }

                    uu.EnterHide();
                }
            }
         }

        public static void OnMainHeroPath(this Unit self, MapComponent mapComponent)
        {
            if (!self.MainHero)
            {
                return;
            }

            int navmesh = 0;
            int sceneType = mapComponent.MapType;
           
            if (SceneConfigHelper.UseSceneConfig(sceneType))
            {
                navmesh = SceneConfigCategory.Instance.Get(mapComponent.SceneId).MapID;
            }
            else
            {
                switch (sceneType)
                {
                    case MapTypeEnum.LocalDungeon:
                        navmesh = DungeonConfigCategory.Instance.Get(mapComponent.SceneId).MapID;
                        break;
                    case MapTypeEnum.CellDungeon:
                    case MapTypeEnum.DragonDungeon:
                        CellDungeonConfig chapterSon = CellDungeonConfigCategory.Instance.Get(mapComponent.SonSceneId);
                        navmesh = chapterSon.MapID;
                        break;
                    default:
                        break;
                }
            }
            
            self.AddComponent<ClientPathfindingComponent, int>(navmesh);
            //self.AddComponent<ET6PathfindingComponent, int>(navmesh);
            //self.AddComponent<ClientPathfinding2Component>();
        }
        
        public static void UpdateMainHeroPath(this Unit self, MapComponent mapComponent)
        {
            if (!self.MainHero)
            {
                return;
            }
            
            self.RemoveComponent<ClientPathfindingComponent>();
            self.OnMainHeroPath(mapComponent);
        }

        public static void OnMainHeroInit(Scene root, Transform topTf, Transform mainTf, int sceneTypeEnum)
        {

            GlobalComponent globalComponent = root.GetComponent<GlobalComponent>();
            Camera maincamera = globalComponent.MainCamera.GetComponent<Camera>();
            Camera uicamera = globalComponent.UICamera.GetComponent<Camera>();
            GameObject bloodnode = globalComponent.BloodMonster;
  
            maincamera.GetComponent<MyCamera_1>().enabled = false;
            maincamera.GetComponent<MyCamera_1>().Target = topTf;

            GameObject shiBingSet = GameObject.Find("ShiBingSet");
            if (shiBingSet != null)
            {
                string path_2 = ABPathHelper.GetUGUIPath("Blood/UINpcLocal");
                GameObject npc_go = root.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path_2);
                for (int i = 0; i < shiBingSet.transform.childCount; i++)
                {
                    GameObject shiBingItem = shiBingSet.transform.GetChild(i).gameObject;
                    NpcLocal npcLocal = shiBingItem.GetComponent<NpcLocal>();
                    if (npcLocal == null)
                    {
                        continue;
                    }

                    NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcLocal.NpcId);
                    npcLocal.MainCamera = maincamera;
                    npcLocal.UiCamera = uicamera;
                    npcLocal.Blood = bloodnode;
                    npcLocal.Target = mainTf;
                    npcLocal.NpcName = npcConfig.Name;
                    npcLocal.NpcSpeak = npcConfig.SpeakText;
                    npcLocal.AssetBundle = npc_go;
                }
            }
        }

        public static List<int> GetSceneShowMonsters(int sceneId)
        {
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            List<int> monsterIds = new List<int>();     
            foreach (int posi in sceneConfig.CreateMonsterPosi)
            {
                MonsterPositionConfig monsterPositionConfig = MonsterPositionConfigCategory.Instance.Get(posi);
                foreach (int monsterId in monsterPositionConfig.MonsterID)
                {
                    if (!MonsterConfigCategory.Instance.Contain(monsterId))
                    {
                        Log.Error($"monsterId {monsterId} not exists   sceneId {sceneId}   monsterpositionid {posi}    ");
                    }

                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);

                    if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_62)
                    {
                        continue;
                    }

                    if (monsterIds.Contains(monsterId))
                    {
                        continue;
                    }

                    monsterIds.Add(monsterId);
                }
            }
            return monsterIds;  
        }
        
        public static void OnMainHeroMove(Unit self)
        {
            long curTime = TimeInfo.Instance.ServerNow();
            List<EntityRef<Unit>> units = self.Scene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (curTime <= unit.UpdateUITime)
                {
                     continue;
                }
                if (unit.Type == UnitType.Npc)
                {
                    unit.UpdateUITime = curTime;
                    UINpcHpComponent npcHeadBarComponent = unit.GetComponent<UINpcHpComponent>();
                    npcHeadBarComponent?.OnUpdateNpcTalk(self);
                    continue;
                }

                if (unit.Type == UnitType.Pasture)
                {
                    unit.UpdateUITime = curTime;
                    UIJiaYuanPastureComponent npcHeadBarComponent = unit.GetComponent<UIJiaYuanPastureComponent>();
                    npcHeadBarComponent?.OnUpdateNpcTalk(self);
                    continue;
                }

                if (unit.Type == UnitType.Transfers)
                {
                    unit.UpdateUITime = curTime;
                    unit.GetComponent<UITransferHpComponent>()?.OnCheckChuanSong(self);
                    continue;
                }

                if (unit.Type == UnitType.CellTransfers)
                {
                    unit.UpdateUITime = curTime;
                    unit.GetComponent<UICellTransferHpComponent>()?.OnCheckChuanSong(self);
                    continue;
                }
            }
        }
    }
}