using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UIMapBigTimer)]
    public class UIMapBigTimer : ATimer<DlgMapBig>
    {
        protected override void Run(DlgMapBig self)
        {
            try
            {
                self.OnMainHeroMove();
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

    [FriendOf(typeof(Scroll_Item_MapBigNpcItem))]
    [FriendOf(typeof(MoveComponent))]
    [FriendOf(typeof(DlgMapBig))]
    public static class DlgMapBigSystem
    {
        public static void RegisterUIEvent(this DlgMapBig self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.View.E_Btn_ShowMonsterButton.AddListener(self.OnBtn_ShowMonsterButton);

            self.View.E_RawImageEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.View.E_MapBigNpcItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMapBigNpcItemsRefresh);
            self.View.E_RawImageButton.AddListener(self.OnRawImageButton);
            
            self.View.E_TextStallText.gameObject.SetActive(false);
            self.View.EG_chuansongRectTransform.gameObject.SetActive(false);
            self.View.EG_bossIconRectTransform.gameObject.SetActive(false);
            self.View.EG_jinglingIconRectTransform.gameObject.SetActive(false);
            self.View.EG_monsterPostionRectTransform.gameObject.SetActive(false);
            self.View.EG_jiayuanPetRectTransform.gameObject.SetActive(false);
            self.View.EG_jiayuanRubshRectTransform.gameObject.SetActive(false);
            self.View.EG_ImageSelectRectTransform.gameObject.SetActive(false);
            self.View.EG_teamerPostionRectTransform.gameObject.SetActive(false);

            self.MoveComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<MoveComponent>();

            self.OnAwake().Coroutine();
            self.InitNpcList();
        }

        public static void ShowWindow(this DlgMapBig self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgMapBig self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static async ETTask OnAwake(this DlgMapBig self)
        {
            GameObject mapCamera = GameObject.Find("MapCamera");
            if (mapCamera == null)
            {
                var path = ABPathHelper.GetUnitPath("Component/MapCamera");
                GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                mapCamera = UnityEngine.Object.Instantiate(prefab);
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

            if (mapComponent.MapType == (int)MapTypeEnum.MainCityScene
                || mapComponent.MapType == (int)MapTypeEnum.TeamDungeon)
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
                mapCamera.transform.position =
                        new Vector3((float)sceneConfig.CameraPos[0], (float)sceneConfig.CameraPos[1], (float)sceneConfig.CameraPos[2]);
                mapCamera.transform.eulerAngles = new Vector3(90, 0, (float)sceneConfig.CameraPos[3]);
                camera.orthographicSize = (float)sceneConfig.CameraPos[4];
            }

            self.MapCamera = mapCamera;

            self.SceneId = self.Root().GetComponent<MapComponent>().SceneId;
            self.ScaleRateX = self.View.E_RawImageEventTrigger.transform.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);
            self.ScaleRateY = self.View.E_RawImageEventTrigger.transform.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);

            self.OnMainHeroMove();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.UIMapBigTimer, self);
            self.View.E_TextText.text = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Name;

            await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            if (self.IsDisposed)
            {
                return;
            }

            camera.enabled = false;
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIMapBig");
        }

        public static void ShowStallArea(this DlgMapBig self)
        {
            int[] stallArea = SceneConfigCategory.Instance.Get(self.SceneId).StallArea;
            if (stallArea != null && stallArea.Length == 4 && self.View.EG_npcPostionRectTransform.gameObject != null)
            {
                /*
                Vector3 stallPosition = new Vector3(stallArea[0] * 0.01f * self.ScaleRateX, stallArea[2] * 0.01f * self.ScaleRateY, 0);
                self.TextStall.SetActive(true);
                self.TextStall.transform.SetParent(self.NpcPostion.transform.parent);
                self.TextStall.transform.localPosition = stallPosition;
                */
            }
        }

        public static void ShowChuansong(this DlgMapBig self)
        {
            int[] transfers = DungeonConfigCategory.Instance.Get(self.SceneId).TransmitPos;
            if (transfers == null || transfers.Length == 0)
            {
                return;
            }

            for (int i = 0; i < transfers.Length; i++)
            {
                if (transfers[i] == 0)
                {
                    continue;
                }

                DungeonTransferConfig dungeonTransferConfig = DungeonTransferConfigCategory.Instance.Get(transfers[i]);
                self.InstantiateIcon(self.View.EG_chuansongRectTransform.gameObject,
                    new Vector3(dungeonTransferConfig.Position[0] * 0.01f, dungeonTransferConfig.Position[2] * 0.01f, 0), dungeonTransferConfig.Name);
            }
        }

        public static void ShowLocalBossList(this DlgMapBig self)
        {
            self.CreateMonsterList(SceneConfigHelper.GetLocalDungeonMonsters_2(self.SceneId));
        }

        public static async ETTask RequestJiaYuanInfo(this DlgMapBig self)
        {
            JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
            M2C_JiaYuanPetPositionResponse response = await JiaYuanNetHelper.JiaYuanPetPositionRequest(self.Root(), jiaYuanComponent.MasterId);

            if (self.IsDisposed)
            {
                return;
            }

            for (int i = 0; i < response.PetList.Count; i++)
            {
                UnitInfo unitInfo = response.PetList[i];
                string name = string.Empty;
                if (unitInfo.Type == UnitType.Pet)
                {
                    PetConfig petConfig = PetConfigCategory.Instance.Get(unitInfo.ConfigId);
                    name = petConfig.PetName;
                }

                if (unitInfo.Type == UnitType.Monster)
                {
                    MonsterConfig petConfig = MonsterConfigCategory.Instance.Get(unitInfo.ConfigId);
                    name = petConfig.MonsterName;
                }

                self.InstantiateIcon(unitInfo.Type == UnitType.Pet ? self.View.EG_jiayuanPetRectTransform.gameObject
                        : self.View.EG_jiayuanRubshRectTransform.gameObject, new Vector3(unitInfo.Position.x, unitInfo.Position.z, 0), name);
            }
        }

        public static GameObject InstantiateIcon(this DlgMapBig self, GameObject go, Vector3 position, string name)
        {
            position = self.GetWordToUIPositon(position);
            GameObject gameObject = UnityEngine.Object.Instantiate(go, go.transform.parent, true);
            gameObject.SetActive(true);
            gameObject.transform.localScale = Vector3.one;
            gameObject.transform.localPosition = position;
            gameObject.transform.Find("Text").GetComponent<Text>().text = name;
            return gameObject;
        }

        public static async ETTask RequestLocalUnitPosition(this DlgMapBig self)
        {
            long instanceid = self.InstanceId;

            M2C_TeamerPositionResponse response = await TeamNetHelper.TeamerPositionRequest(self.Root());

            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (response.UnitList.Count == 0)
            {
                return;
            }

            foreach (UnitInfo unitInfo in response.UnitList)
            {
                Vector3 vector3 = new Vector3(unitInfo.Position.x, unitInfo.Position.z, 0);
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitInfo.ConfigId);

                // 赛季boss
                if ( CommonHelp.IsSeasonBoss(unitInfo.ConfigId))
                {
                    self.InstantiateIcon(self.View.EG_bossIconRectTransform.gameObject, vector3, monsterConfig.MonsterName);
                }

                // 野生精灵
                int sonType = MonsterConfigCategory.Instance.Get(unitInfo.ConfigId).MonsterSonType;
                if (unitInfo.Type == UnitType.Monster && (sonType == 58 || sonType == 59))
                {
                    self.InstantiateIcon(self.View.EG_jinglingIconRectTransform.gameObject, vector3, monsterConfig.MonsterName);
                }
            }
        }

        public static async ETTask RequestTeamerPosition(this DlgMapBig self)
        {
            long instanceid = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (true)
            {
                M2C_TeamerPositionResponse response = await TeamNetHelper.TeamerPositionRequest(self.Root());
                if (instanceid != self.InstanceId)
                {
                    break;
                }

                self.OnUpdateTeamerList(response.UnitList);

                await timerComponent.WaitAsync(TimeHelper.Second * 2);
                if (instanceid != self.InstanceId)
                {
                    break;
                }
            }
        }

        public static void OnUpdateTeamerList(this DlgMapBig self, List<UnitInfo> unitInfos)
        {
            for (int i = 0; i < unitInfos.Count; i++)
            {
                UnitInfo unitInfo = unitInfos[i];
                Vector3 vector3 = new Vector3(unitInfo.Position.x, unitInfo.Position.z, 0);
                Vector3 vector31 = self.GetWordToUIPositon(vector3);

                GameObject go = null;
                if (i < self.TeamerPointList.Count)
                {
                    go = self.TeamerPointList[i];
                }
                else
                {
                    go = UnityEngine.Object.Instantiate(self.View.EG_teamerPostionRectTransform.gameObject,
                        self.View.EG_teamerPostionRectTransform.transform.parent, true);
                    go.SetActive(true);
                    go.transform.localScale = Vector3.one;
                    self.TeamerPointList.Add(go);
                }

                go.transform.localPosition = vector31;
                go.transform.Find("Text").GetComponent<Text>().text = unitInfo.UnitName;
            }

            for (int i = unitInfos.Count; i < self.TeamerPointList.Count; i++)
            {
                self.TeamerPointList[i].transform.localPosition = self.InvisiblePosition;
            }
        }

        public static void ShowTeamBossList(this DlgMapBig self)
        {
            SceneConfig chapterSonConfig = SceneConfigCategory.Instance.Get(self.SceneId);
            if (chapterSonConfig.CreateMonsterPosi != null)
            {
                for (int i = 0; i < chapterSonConfig.CreateMonsterPosi.Length; i++)
                {
                    int monsterId = chapterSonConfig.CreateMonsterPosi[i];
                    while (monsterId != 0)
                    {
                        monsterId = self.CreateMonsterByPos(monsterId);
                    }
                }
            }
        }

        public static int CreateMonsterByPos(this DlgMapBig self, int monsterPositionId)
        {
            MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.Get(monsterPositionId);

            for (int i = 0; i < monsterPosition.MonsterID.Length; i++)
            {
                int monsterid = monsterPosition.MonsterID[i];
                string[] position = monsterPosition.Position.Split(',');
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);
                if (monsterConfig.MonsterType != (int)MonsterTypeEnum.Boss)
                {
                    return monsterPosition.NextID;
                }

                Vector3 vector3 = new Vector3(float.Parse(position[0]), float.Parse(position[2]), 0);
                self.InstantiateIcon(self.View.EG_bossIconRectTransform.gameObject, vector3, monsterConfig.MonsterName);

                self.BossList.Add(monsterConfig.Id, new Vector3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2])));

            }

            return monsterPosition.NextID;
        }

        public static void CreateMonsterList(this DlgMapBig self, string createMonster)
        {
            string[] monsters = createMonster.Split('@');
            for (int i = 0; i < monsters.Length; i++)
            {
                if (CommonHelp.IfNull(monsters[i]))
                {
                    continue;
                }

                try
                {
                    //1;37.65,0,3.2;70005005;1
                    string[] mondels = monsters[i].Split(';');
                    string[] mtype = mondels[0].Split(',');
                    string[] position = mondels[1].Split(',');
                    string[] monsterid = mondels[2].Split(',');

                    if (mtype[0] != "1" && mtype[0] != "2")
                    {
                        continue;
                    }

                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(int.Parse(monsterid[0]));
                    if (monsterConfig.MonsterType != (int)MonsterTypeEnum.Boss)
                    {
                        continue;
                    }

                    Vector3 vector3 = new Vector3(float.Parse(position[0]), float.Parse(position[2]), 0);
                    self.InstantiateIcon(self.View.EG_bossIconRectTransform.gameObject, vector3, monsterConfig.MonsterName);

                    self.BossList.Add(monsterConfig.Id, new Vector3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2])));
                }
                catch (Exception ex)
                {
                    Log.Debug(monsters[i] + "  " + ex.ToString());
                }
            }
        }

        public static void InitNpcList(this DlgMapBig self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            int[] npcList = null;

            if (SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
            {
                npcList = SceneConfigCategory.Instance.Get(self.SceneId).NpcList;
                self.View.E_MapNameText.text = SceneConfigCategory.Instance.Get(self.SceneId).Name;
                self.ShowStallArea();
            }

            if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon)
            {
                npcList = DungeonConfigCategory.Instance.Get(self.SceneId).NpcList;
                self.View.E_MapNameText.text = DungeonConfigCategory.Instance.Get(self.SceneId).ChapterName;
                self.ShowChuansong();
                self.ShowLocalBossList();
                self.RequestLocalUnitPosition().Coroutine();
            }

            if (mapComponent.MapType == MapTypeEnum.JiaYuan)
            {
                self.RequestJiaYuanInfo().Coroutine();
            }

            if (mapComponent.MapType == MapTypeEnum.TeamDungeon)
            {
                self.RequestTeamerPosition().Coroutine();
                self.ShowTeamBossList();
            }

            GameObject mapCamera = self.MapCamera;
            self.ShowNpc.Clear();
            if (npcList != null)
            {
                for (int i = 0; i < npcList.Length; i++)
                {
                    if (!NpcConfigCategory.Instance.Contain(npcList[i]))
                    {
                        continue;
                    }

                    if (npcList[i] == 20000040)
                    {
                        PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
                        if (!PetHelper.IsShenShouFull(petComponent.RolePetInfos))
                        {
                            continue;
                        }
                    }

                    NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcList[i]);

                    self.InstantiateIcon(self.View.EG_npcPostionRectTransform.gameObject,
                        new Vector3(npcConfig.Position[0] * 0.01f, npcConfig.Position[2] * 0.01f, 0),
                        npcConfig.Name);

                    self.ShowNpc.Add(npcList[i]);
                }
            }

            self.ShowBoss.Clear();
            foreach (var item in self.BossList)
            {
                self.ShowBoss.Add(item.Key);
            }

            self.AddUIScrollItems(ref self.ScrollItemMapBigNpcItems, self.ShowNpc.Count + self.ShowBoss.Count);
            self.View.E_MapBigNpcItemsLoopVerticalScrollRect.SetVisible(true, self.ShowNpc.Count + self.ShowBoss.Count);
        }

        private static void OnMapBigNpcItemsRefresh(this DlgMapBig self, Transform transform, int index)
        {
            foreach (Scroll_Item_MapBigNpcItem item in self.ScrollItemMapBigNpcItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_MapBigNpcItem scrollItemMapBigNpcItem = self.ScrollItemMapBigNpcItems[index].BindTrans(transform);
            if (index < self.ShowNpc.Count)
            {
                scrollItemMapBigNpcItem.SetClickHandler(UnitType.Npc, self.ShowNpc[index],
                    (int unitype, int npcid) => { self.OnClickNpcItem(unitype, npcid); });
                scrollItemMapBigNpcItem.SetFlyToHandler(
                    (int unitype, int npcid) => { self.OnFlyTo(unitype, npcid).Coroutine(); });
            }
            else
            {
                scrollItemMapBigNpcItem.SetClickHandler(UnitType.Monster, self.ShowBoss[index-self.ShowNpc.Count],
                    (int unitype, int npcid) => { self.OnClickNpcItem(unitype, npcid); });
                scrollItemMapBigNpcItem.SetFlyToHandler(
                    (int unitype, int npcid) => { self.OnFlyTo(unitype, npcid).Coroutine(); });
            }
        }

        public static async ETTask OnFlyTo(this DlgMapBig self, int unitype, int configid)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            if (bagComponentC.GetItemNumber(ConfigData.FlyToItem) < 1)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(ConfigData.FlyToItem);
                FlyTipComponent.Instance.ShowFlyTip($"缺少道具:{itemConfig.ItemName}");  
                return; 
            }

            // float3 target;
            // if (unitype == UnitType.Npc)
            // {
            //     NpcConfig npcConfig = NpcConfigCategory.Instance.Get(configid);
            //     target = new(npcConfig.Position[0] * 0.01f, npcConfig.Position[1] * 0.01f, npcConfig.Position[2] * 0.01f);
            //     quaternion rotation = quaternion.Euler(0, math.radians(npcConfig.Rotation), 0); 
            //     target =  target + math.mul(rotation, math.forward()) * 1f;
            // }
            // else
            // {
            //     target = (self.BossList[configid]);
            // }
            
            EnterMapHelper.RequestFlyToPosition(self.Root(), unitype, configid).Coroutine();
            await ETTask.CompletedTask; 
        }
        
        public static void OnClickNpcItem(this DlgMapBig self, int unitype, int configid)
        {
            self.View.EG_ImageSelectRectTransform.gameObject.SetActive(true);
            for (int i = 0; i < self.ScrollItemMapBigNpcItems.Count; i++)
            {
                Scroll_Item_MapBigNpcItem scrollItemMapBigNpcItem = self.ScrollItemMapBigNpcItems[i];
                if (scrollItemMapBigNpcItem.uiTransform == null)
                {
                    continue;
                }

                if (scrollItemMapBigNpcItem.ConfigId == configid)
                {
                    CommonViewHelper.SetParent(self.View.EG_ImageSelectRectTransform.gameObject, scrollItemMapBigNpcItem.uiTransform.gameObject);
                    break;
                }
            }

            self.View.EG_ImageSelectRectTransform.transform.SetSiblingIndex(0);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
                return;

            if (unitype == UnitType.Npc)
            {
                self.Root().CurrentScene().GetComponent<OperaComponent>().OnClickNpc(configid, "1").Coroutine();
            }
            else
            {
                EventSystem.Instance.Publish(self.Root(), new BeforeMove() { DataParamString = "1" });
                unit.MoveToAsync(self.BossList[configid], null, true).Coroutine();
            }
        }

        public static void PointerDown(this DlgMapBig self, PointerEventData pdata)
        {
            Scene curScene = self.Root().CurrentScene();
            if (curScene == null)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(curScene);
            if (unit == null)
            {
                return;
            }

            GameObject mapCamera = self.MapCamera;
            RectTransform canvas = self.View.E_RawImageRawImage.transform.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out self.localPoint);

            Quaternion rotation = Quaternion.Euler(0, mapCamera.transform.eulerAngles.y, 0);

            Vector3 wordpos = new Vector3(self.localPoint.x / self.ScaleRateX, 100f, self.localPoint.y / self.ScaleRateY);
            wordpos = rotation * wordpos;

            Vector3 position = mapCamera.transform.position;
            wordpos.x += (position.x);
            wordpos.z += (position.z);

            RaycastHit hit;
            int mapMask = (1 << LayerMask.NameToLayer(LayerEnum.Map.ToString()));
            Physics.Raycast(wordpos, Vector3.down, out hit, 1000, mapMask);

            if (hit.collider != null)
            {
                EventSystem.Instance.Publish(self.Root(), new BeforeMove() { DataParamString = "1" });
                unit.MoveToAsync(hit.point, null, true).Coroutine();
            }
        }

        public static Vector3 GetWordToUIPositon(this DlgMapBig self, Vector3 vector3)
        {
            GameObject mapCamera = self.MapCamera;
            Vector3 position = mapCamera.transform.position;
            vector3.x -= position.x;
            vector3.y -= position.z;

            Quaternion rotation = Quaternion.Euler(0, 0, 1 * mapCamera.transform.eulerAngles.y);
            vector3 = rotation * vector3;

            vector3.x *= self.ScaleRateX;
            vector3.y *= self.ScaleRateY;
            return vector3;
        }

        public static void OnBtn_CloseButton(this DlgMapBig self)
        {
            DlgGuide dlgGuide = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGuide>();
            if (dlgGuide != null)
            {
                self.Root().GetComponent<GuideComponent>().OnNext(dlgGuide.GuideConfig.GroupId);
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MapBig);
        }

        public static void OnBtn_ShowMonsterButton(this DlgMapBig self)
        {
            if (self.MonsterPointList.Count > 0)
            {
                bool isShow = false;
                isShow = !self.MonsterPointList[0].activeSelf;
                foreach (GameObject gameObject in self.MonsterPointList)
                {
                    gameObject.SetActive(isShow);
                }

                return;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType != (int)MapTypeEnum.LocalDungeon)
            {
                return;
            }

            string[] monsters = SceneConfigHelper.GetLocalDungeonMonsters_2(self.SceneId).Split('@');
            for (int i = 0; i < monsters.Length; i++)
            {
                if (CommonHelp.IfNull(monsters[i]))
                {
                    continue;
                }

                try
                {
                    //1;37.65,0,3.2;70005005;1
                    string[] mondels = monsters[i].Split(';');
                    string[] mtype = mondels[0].Split(',');
                    string[] position = mondels[1].Split(',');
                    string[] monsterid = mondels[2].Split(',');

                    if (mtype[0] != "1" && mtype[0] != "2")
                    {
                        continue;
                    }

                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(int.Parse(monsterid[0]));

                    Vector3 vector3 = new Vector3(float.Parse(position[0]), float.Parse(position[2]), 0);
                    self.MonsterPointList.Add(self.InstantiateIcon(self.View.EG_monsterPostionRectTransform.gameObject, vector3,
                        $"({float.Parse(position[0])},{float.Parse(position[1])},{float.Parse(position[2])})"));
                }
                catch (Exception ex)
                {
                    Log.Debug(monsters[i] + "  " + ex.ToString());
                }
            }
        }

        public static void OnMainHeroMove(this DlgMapBig self)
        {
            Vector3 vector3 = UnitHelper.GetMyUnitFromClientScene(self.Root()).Position;
            Vector3 vector31 = new Vector3(vector3.x, vector3.z, 0f);
            self.View.EG_mainPostionRectTransform.transform.localPosition = self.GetWordToUIPositon(vector31);

            self.UpdatePathPoint();
        }

        public static GameObject GetPathPointObj(this DlgMapBig self, int index)
        {
            if (self.PathPointList.Count > index)
            {
                return self.PathPointList[index];
            }

            GameObject go = UnityEngine.Object.Instantiate(self.View.EG_pathPointRectTransform.gameObject,
                self.View.EG_pathPointRectTransform.transform.parent, true);
            go.SetActive(true);
            go.transform.localScale = Vector3.one;
            self.PathPointList.Add(go);
            return go;
        }

        private static List<Vector3> GeneratePointsAtInterval(this DlgMapBig self, List<Vector3> originalPath, float intervalDistance)
        {
            List<Vector3> newPath = new List<Vector3>();

            if (originalPath == null || originalPath.Count < 2 || intervalDistance <= 0)
            {
                return newPath;
            }

            newPath.Add(originalPath[0]);

            for (int i = 1; i < originalPath.Count; i++)
            {
                Vector3 startPoint = originalPath[i - 1];
                Vector3 endPoint = originalPath[i];

                float distanceBetweenPoints = Vector3.Distance(startPoint, endPoint);

                Vector3 direction = (endPoint - startPoint).normalized;
                float currentDistance = 0;

                while (currentDistance + intervalDistance <= distanceBetweenPoints)
                {
                    currentDistance += intervalDistance;
                    Vector3 newPoint = startPoint + direction * currentDistance;
                    newPath.Add(newPoint);
                }

                newPath.Add(endPoint);
            }

            return newPath;
        }

        public static void UpdatePathPoint(this DlgMapBig self)
        {
            int N = self.MoveComponent.N;
            List<Vector3> target = new List<Vector3>();
            target.Add(UnitHelper.GetMyUnitFromClientScene(self.Root()).Position);
            for (int i = N; i < self.MoveComponent.Targets.Count; i++)
            {
                target.Add(self.MoveComponent.Targets[i]);
            }

            target = self.GeneratePointsAtInterval(target, 1f);// 点的间距

            Vector3 lastVector = new Vector3(-1000, -1000, 0);
            int showNumber = 0;
            for (int i = target.Count - 1; i >= 0; i--)
            {
                Vector3 temp = target[i];
                Vector3 vector31 = new Vector3(temp.x, temp.z, 0f);
                vector31 = self.GetWordToUIPositon(vector31);

                if (Vector3.Distance(vector31, lastVector) > 20f)
                {
                    GameObject go = self.GetPathPointObj(showNumber);
                    showNumber++;
                    go.transform.localPosition = vector31;
                    go.transform.localScale = Vector3.one * 2f;
                    lastVector = vector31;
                }
            }

            for (int i = showNumber; i < self.PathPointList.Count; i++)
            {
                self.PathPointList[i].transform.localPosition = self.InvisiblePosition;
            }
        }

        public static void OnRawImageButton(this DlgMapBig self)
        {
        }
    }
}