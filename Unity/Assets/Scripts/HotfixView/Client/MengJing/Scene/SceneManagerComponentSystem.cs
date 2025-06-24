using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [FriendOf(typeof(SceneManagerComponent))]
    [EntitySystemOf(typeof(SceneManagerComponent))]
    public static partial class SceneManagerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SceneManagerComponent self)
        {
        }

        // 好像已经弃用了
        public static void UpdateChuanSong(this SceneManagerComponent self, int sceneTypeEnum)
        {
            AdditiveHide[] additiveHides = (AdditiveHide[])UnityEngine.Object.FindObjectsOfType(typeof (AdditiveHide));
            for (int i = 0; i < additiveHides.Length; i++)
            {
                additiveHides[i].ToggleShow();
            }

            if (sceneTypeEnum == (int)MapTypeEnum.CellDungeon
                || sceneTypeEnum == (int)MapTypeEnum.DragonDungeon)
            {
                //显示传送 
                GameObject ChuanSongPosiSet = GameObject.Find("AdditiveHide/ChuanSongPosiSet");
                if (ChuanSongPosiSet == null)
                    return;
                ChuanSongPosiSet.SetActive(true);
                CellDungeonComponentC fubenComponent = self.Root().GetComponent<CellDungeonComponentC>();
                bool isEnd = fubenComponent.IsEndCell();
                if (isEnd)
                {
                    ChuanSongPosiSet.SetActive(false);
                    return;
                }
                
                for (int i = 0; i < fubenComponent.SonFubenInfo.PassableFlag.Count; i++)
                {
                    string path = $"NoChuanSong_{i + 1}";
                    GameObject obj = ChuanSongPosiSet.transform.Find(path).gameObject;
                    if (obj != null)
                    {
                        obj.SetActive(fubenComponent.SonFubenInfo.PassableFlag[i] == 0);
                    }
                }
            }
        }

        public static async ETTask ChangeCellSonScene(this SceneManagerComponent self, int sceneTypeEnum, int lastScene, int sceneid)
        {
            self.Root().GetComponent<SkillIndicatorComponent>().BeforeEnterScene();
            self.Root().GetComponent<LockTargetComponent>().BeforeEnterScene();

            string paramss = CellDungeonConfigCategory.Instance.Get(sceneid).MapID.ToString();

            var path = ABPathHelper.GetScenePath(paramss);
            await self.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Additive);
            Log.Warning("切换场景" + path);

            self.UpdateChuanSong(sceneTypeEnum);
            //刷新主界面
            DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            dlgMain.AfterEnterScene(sceneTypeEnum);
        }

        public static void UnLoadAsset(this SceneManagerComponent self)
        {
            self.Root().GetComponent<GameObjectLoadComponent>().DisposeUnUse(); 
            
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            
            // 释放前一个场景的所有资源
            resourcesLoaderComponent.UnLoadAllAsset();
            
            Resources.UnloadUnusedAssets();
            GC.Collect();
        }

        public static async ETTask ChangeScene(this SceneManagerComponent self, int sceneTypeEnum, int lastScene, int sceneid)
        {
            string paramss = "";
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.InitScene:
                    paramss = "Init";
                    break;
                case MapTypeEnum.LoginScene:
                    paramss = "Login";
                    break;
                case MapTypeEnum.MainCityScene:
                    PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
                    string scenepath = sceneid.ToString();
                    paramss = scenepath;
                    break;
                case MapTypeEnum.CellDungeon:
                    paramss = CellDungeonConfigCategory.Instance.Get(self.Root().GetComponent<MapComponent>().SonSceneId).MapID.ToString();
                    break;
                case MapTypeEnum.DragonDungeon:
                    paramss = CellDungeonConfigCategory.Instance.Get(self.Root().GetComponent<MapComponent>().SonSceneId).MapID.ToString();
                    break;
                case MapTypeEnum.LocalDungeon:
                    paramss = DungeonConfigCategory.Instance.Get(sceneid).MapID.ToString();
                    playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
                    break;
                default:
                    paramss = SceneConfigCategory.Instance.Get(sceneid).MapID.ToString();
                    break;
            }

            self.Root().GetComponent<GameObjectLoadComponent>().DisposeAll(); 
            
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            
            // 释放前一个场景的所有资源
            resourcesLoaderComponent.UnLoadAllAsset();
            
            await Resources.UnloadUnusedAssets();
            GC.Collect();
            
            string path = ABPathHelper.GetScenePath("Empty");
                
            await resourcesLoaderComponent.LoadSceneAsync(path, LoadSceneMode.Single);
                
            self.Root().GetComponent<GameObjectLoadComponent>().DisposeAll();

            // 释放前一个场景的所有资源
            resourcesLoaderComponent.UnLoadAllAsset();

            await Resources.UnloadUnusedAssets();
            GC.Collect();
                
            path = ABPathHelper.GetScenePath(paramss);

            await resourcesLoaderComponent.LoadSceneAsync(path, LoadSceneMode.Single);

            Debug.Log("切换场景" + path);

            // 获取当前场景

            string scenename = SceneManager.GetActiveScene().name;
            // 打印当前场景的名称
            
            Debug.Log("当前场景的名称是: " + scenename);

            //动态生成场景
            if (SettingData.UseSceneAOI)
            {
                TextAsset mapconfig = await resourcesLoaderComponent.LoadAssetAsync<TextAsset>(ABPathHelper.GetMapConfigPath(paramss));
                if (mapconfig!=null && mapconfig.bytes!=null)
                {
                    Debug.Log("mapconfig!=null" + path);
                    self.Root().GetComponent<SceneUnitManagerComponent>().InitMapObject(mapconfig.bytes, paramss  );
                }
                else
                {
                    Debug.Log("mapconfig==null" + path);
                    self.Root().GetComponent<SceneUnitManagerComponent>().InitMapObject(null, paramss  );
                }
            }
            if (sceneTypeEnum != MapTypeEnum.LoginScene)
            {
                ConfigData.LoadSceneFinished = true;
            }

            self.UpdateChuanSong(sceneTypeEnum);

            int sousceneid = self.Root().GetComponent<MapComponent>().SonSceneId;
            self.Root().GetComponent<SoundComponent>().PlayBgmSound(sceneTypeEnum, sceneid, sousceneid);
        }

        public static void BeforeChangeScene(this SceneManagerComponent self)
        {
            ConfigData.LoadSceneFinished = false;
        }
    }
}