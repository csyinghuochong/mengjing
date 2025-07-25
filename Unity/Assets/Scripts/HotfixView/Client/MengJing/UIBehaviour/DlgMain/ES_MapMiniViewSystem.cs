using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.MapMiniTimer)]
    public class MapMiniTimer : ATimer<ES_MapMini>
    {
        protected override void Run(ES_MapMini self)
        {
            try
            {
                self.OnUpdateMiniMapTime(); 
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }


    [EntitySystemOf(typeof(ES_MapMini))]
    [FriendOfAttribute(typeof(ES_MapMini))]
    public static partial class ES_MapMiniSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MapMini self, Transform transform)
        {
            self.uiTransform = transform;
            self.EG_HeadItemRectTransform.gameObject.SetActive(false);
            self.E_MiniMapButtonButton.AddListener(self.OnMiniMapButtonButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_MapMini self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.MapMiniTimer);
            self.DestroyWidget();
        }

        public static void OnMiniMapButtonButton(this ES_MapMini self)
        {
            int sceneType = self.Root().GetComponent<MapComponent>().MapType;
            int sceneId = self.Root().GetComponent<MapComponent>().SceneId;
            switch (sceneType)
            {
                case (int)MapTypeEnum.MainCityScene:
                case (int)MapTypeEnum.LocalDungeon:
                    self.OnOpenBigMap(); //打开主城
                    break;
                case (int)MapTypeEnum.CellDungeon:
                case (int)MapTypeEnum.DragonDungeon:
                    self.OnShowFubenIndex(); //打开副本小地图
                    break;
                default:
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
                    if (sceneConfig.ifShowMinMap == 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("当前场景不支持查看小地图"));
                    }
                    else
                    {
                        self.OnOpenBigMap(); //打开主城
                    }

                    break;
            }
        }

        public static void OnOpenBigMap(this ES_MapMini self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_MapBig).Coroutine();
        }
        
        public static void OnShowFubenIndex(this ES_MapMini self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CellDungeonCell).Coroutine();
        }

        private static void UpdateTianQi(this ES_MapMini self, string tianqi)
        {
            switch (tianqi)
            {
                case "1":
                    self.E_TianQiText.text = "晴天";
                    break;
                case "2":
                    self.E_TianQiText.text = "雨天";
                    break;
                default:
                    self.E_TianQiText.text = "晴天";
                    break;
            }
        }

        public static void OnMainHeroMove(this ES_MapMini self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null || self.MapCamera == null)
            {
                return;
            }

            Vector3 vector3 = unit.Position;
            Vector3 vector31 = new Vector3(vector3.x, vector3.z, 0f);
            Vector2 localPosition = self.GetWordToUIPositon(vector31);
            self.E_RawImageRawImage.transform.localPosition = new Vector2(localPosition.x * -1, localPosition.y * -1);
            self.EG_HeadListRectTransform.localPosition = new Vector2(localPosition.x * -1, localPosition.y * -1);
            
            self.OnUpdateMiniMapAllUnit();
        }
        
        public static void OnUpdateMiniMapOneUnit(this ES_MapMini self, Unit unit)
        {
            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());

            if (main == null)
            {
                return;
            }
            
            if (unit.Type != UnitType.Player && unit.Type != UnitType.Monster)
            {
                return;
            }
            
            Vector3 vector31 = new Vector3(unit.Position.x, unit.Position.z, 0f);
            Vector3 vector32 = self.GetWordToUIPositon(vector31);
            GameObject headItem = self.GetTeamPointObj(unit.Id);

            //1自己 2敌对 3队友  4主城
            string showType = "4";
            if (self.SceneTypeEnum != MapTypeEnum.MainCityScene && main.IsCanAttackUnit(unit))
            {
                showType = "2";
            }
            
            if (main.IsSameTeam(unit))
            {
                showType = "3";
            }
            
            if (unit.MainHero)
            {
                showType = "1";
            }

            if (unit.Type == UnitType.Monster)
            {
                if (unit.ConfigId > 0)
                {
                    MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                    if (monsterCof.MonsterType == 5)
                    {
                        //6 宝箱
                        if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_55)
                        {
                            showType = "6";
                        }

                        //5 精灵 宠物 宠灵书
                        if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_57 || monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_58 || monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_59)
                        {
                            showType = "5";
                        }
                    }
                }
            }
            
            for (int icontype = 0; icontype < GlobalData.ES_MapMiniType.Count; icontype++)
            {
                headItem.Get<GameObject>( GlobalData.ES_MapMiniType[icontype] ).transform.localPosition =  
                        GlobalData.ES_MapMiniType[icontype] == showType ?  Vector3.zero : GlobalData.ES_MapMiniNoVisie;
            }
            
            headItem.transform.localPosition = new Vector2(vector32.x, vector32.y);
                        
        }
        
        public static void OnUnitUnitRemove(this ES_MapMini self, List<long> removeIds)
        {
            foreach (long removeid in removeIds)
            {
                GameObject unitgo = null;
                self.AllPointList.TryGetValue(removeid, out unitgo);
                if (unitgo != null)
                {
                    self.AllPointList.Remove(removeid);
                    unitgo.transform.localPosition = self.NoVector3;
                    self.CachePointList.Add(unitgo);
                }
            }

            foreach (var cacheitem in self.CachePointList)
            {
                cacheitem.transform.localPosition = self.NoVector3;
            }
        }
        
        public static void OnUpdateMiniMapAllUnit(this ES_MapMini self)
        {
            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());

            if (main == null)
            {
                return;
            }

            List<long> allids = new List<long>();       
            List<EntityRef<Unit>> allUnit = main.GetParent<UnitComponent>().GetAll();
            
            // int selfCamp_1 = main.GetBattleCamp();
            for (int i = 0; i < allUnit.Count; i++)
            {
                Unit unit = allUnit[i];
                allids.Add(unit.Id);
                self.OnUpdateMiniMapOneUnit(unit);  
            }
           
            List<long> removeIds = new List<long>();
            foreach (var pGameObject in self.AllPointList)
            {
                if (!allids.Contains(pGameObject.Key))
                {
                    removeIds.Add(pGameObject.Key);
                }
            }

            self.OnUnitUnitRemove(removeIds);
        }

        public static void OnUpdateMiniMapTime(this ES_MapMini self)
        {
            DateTime serverTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
            using (zstring.Block())
            {
                self.E_TimeText.text = zstring.Format("{0}:{1}", serverTime.Hour, serverTime.Minute);
            }
        }

        private static GameObject GetTeamPointObj(this ES_MapMini self, long unitid)
        {
            GameObject unitgo = null;
            self.AllPointList.TryGetValue(unitid, out unitgo);
            if (unitgo!=null)
            {
                return unitgo;
            }

            if (self.CachePointList.Count > 0)
            {
                unitgo = self.CachePointList[0];
                
                self.CachePointList.RemoveAt(0);
                self.AllPointList.Add(unitid, unitgo);
                return unitgo;
            }

            GameObject go = UnityEngine.Object.Instantiate(self.EG_HeadItemRectTransform.gameObject, self.EG_HeadItemRectTransform.parent,
                true);
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
            self.AllPointList.Add(unitid, go);
            return go;
        }

        private static Vector3 GetWordToUIPositon(this ES_MapMini self, Vector3 vector3)
        {
            GameObject mapCamera = self.MapCamera;
            vector3.x -= mapCamera.transform.position.x;
            vector3.y -= mapCamera.transform.position.z;

            Quaternion rotation = Quaternion.Euler(0, 0, 1 * mapCamera.transform.eulerAngles.y);
            vector3 = rotation * vector3;

            vector3.x *= self.ScaleRateX;
            vector3.y *= self.ScaleRateY;
            return vector3;
        }

        private static async ETTask LoadMapCamera(this ES_MapMini self)
        {
            GameObject mapCamera = GameObject.Find("Global/MapCamera");
            if (mapCamera == null)
            {
                var path = ABPathHelper.GetUnitPath("Component/MapCamera");
                GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                mapCamera = UnityEngine.Object.Instantiate(prefab, GameObject.Find("Global").transform);
                mapCamera.name = "MapCamera";
            }

            Camera camera = mapCamera.GetComponent<Camera>();
            camera.enabled = true;

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon)
            {
                DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(mapComponent.SceneId);
                mapCamera.transform.position = new Vector3((float)dungeonConfig.CameraPos[0], (float)dungeonConfig.CameraPos[1],
                    (float)dungeonConfig.CameraPos[2]);
                mapCamera.transform.eulerAngles = new Vector3(90, 0, (float)dungeonConfig.CameraPos[3]);
                camera.orthographicSize = (float)dungeonConfig.CameraPos[4];
            }

            if (SceneConfigHelper.UseSceneConfig(mapComponent.MapType)
                && SceneConfigHelper.ShowMiniMap(mapComponent.MapType, mapComponent.SceneId))
            {
                SceneConfig dungeonConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
                mapCamera.transform.position = new Vector3((float)dungeonConfig.CameraPos[0], (float)dungeonConfig.CameraPos[1],
                    (float)dungeonConfig.CameraPos[2]);
                mapCamera.transform.eulerAngles = new Vector3(90, 0, (float)dungeonConfig.CameraPos[3]);
                camera.orthographicSize = (float)dungeonConfig.CameraPos[4];
            }

            self.MapCamera = mapCamera;

            self.SceneTypeEnum = self.Root().GetComponent<MapComponent>().MapType;
            self.ScaleRateX = self.E_RawImageRawImage.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);
            self.ScaleRateY = self.E_RawImageRawImage.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);
            self.E_RawImageRawImage.transform.localPosition = Vector2.zero;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            camera.enabled = false;

            self.OnMainHeroMove();
            await ETTask.CompletedTask;
        }

        public static void BeforeEnterScene(this ES_MapMini self, int lastScene)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.MapMiniTimer);
        }

        public static void ShowMapName(this ES_MapMini self, string mapname)
        {
            self.E_MapNameText.text = mapname;
        }

        public static void OnEnterScene(this ES_MapMini self)
        {
            self.LoadMapCamera().Coroutine();

            self.EG_MainCityShowRectTransform.gameObject.SetActive(true);

            self.UpdateMapName();

            self.EG_HeadListRectTransform.gameObject.SetActive(true);
            //self.Root().GetComponent<TimerComponent>().Remove(ref self.MapMiniTimer);
            //self.MapMiniTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.MapMiniTimer, self);

            DateTime serverTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
            using (zstring.Block())
            {
                self.E_TimeText.text = zstring.Format("{0}:{1}", serverTime.Hour, serverTime.Minute);
            }
        }

        public static void UpdateMapName(this ES_MapMini self)
        {
            int sceneTypeEnum = self.Root().GetComponent<MapComponent>().MapType;
            int difficulty = self.Root().GetComponent<MapComponent>().FubenDifficulty;
            int sceneId = self.Root().GetComponent<MapComponent>().SceneId;

            using (zstring.Block())
            {
                //显示地图名称
                switch (sceneTypeEnum)
                {
                    case MapTypeEnum.CellDungeon:
                        self.EG_MainCityShowRectTransform.gameObject.SetActive(false);
                        self.E_MapNameText.text = CellGenerateConfigCategory.Instance.Get(sceneId).ChapterName;
                        break;
                    case MapTypeEnum.DragonDungeon:
                        self.EG_MainCityShowRectTransform.gameObject.SetActive(false);
                        self.E_MapNameText.text = CellGenerateConfigCategory.Instance.Get(sceneId).ChapterName;
                        break;
                    case MapTypeEnum.LocalDungeon:
                        string str = string.Empty;
                        if (difficulty == FubenDifficulty.Normal)
                        {
                            str = "(普通)";
                        }

                        if (difficulty == FubenDifficulty.TiaoZhan)
                        {
                            str = "(挑战)";
                        }

                        if (difficulty == FubenDifficulty.DiYu)
                        {
                            str = "(地狱)";
                        }

                        if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(sceneId))
                        {
                            str = string.Empty;
                        }

                        self.E_MapNameText.text = zstring.Format("{0}{1}", DungeonConfigCategory.Instance.Get(sceneId).ChapterName, str);
                        break;
                    case MapTypeEnum.TeamDungeon:
                        str = "";
                        if (difficulty == TeamFubenType.XieZhu)
                        {
                            str = "(协助)";
                        }

                        if (difficulty == TeamFubenType.ShenYuan)
                        {
                            str = "(深渊)";
                        }

                        self.E_MapNameText.text = zstring.Format("{0}{1}", SceneConfigCategory.Instance.Get(sceneId).Name, str);
                        break;
                    case MapTypeEnum.Union:
                        UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                        self.E_MapNameText.text = zstring.Format("{0} 公会地图", userInfoComponent.UserInfo.UnionName);
                        break;
                    case MapTypeEnum.SealTower:
                        self.E_MapNameText.text = zstring.Format("{0}{1}", SceneConfigCategory.Instance.Get(sceneId).Name,
                            UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.SealTowerArrived));
                        break;
                    default:
                        //显示地图名称
                        self.E_MapNameText.text = SceneConfigCategory.Instance.Get(sceneId).Name;
                        break;
                }
            }
        }
    }
}
