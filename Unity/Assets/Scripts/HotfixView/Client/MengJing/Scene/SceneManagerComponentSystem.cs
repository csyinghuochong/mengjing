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
            // AdditiveHide[] additiveHides = (AdditiveHide[])UnityEngine.Object.FindObjectsOfType(typeof (AdditiveHide));
            // for (int i = 0; i < additiveHides.Length; i++)
            // {
            //     additiveHides[i].ToggleShow();
            // }

            if (sceneTypeEnum == (int)SceneTypeEnum.CellDungeon)
            {
                //显示传送 
                // GameObject ChuanSongPosiSet = GameObject.Find("AdditiveHide/ChuanSongPosiSet");
                // if (ChuanSongPosiSet == null)
                //     return;
                // ChuanSongPosiSet.SetActive(true);
                // CellDungeonComponentC fubenComponent = self.Root().GetComponent<CellDungeonComponentC>();
                // bool isEnd = fubenComponent.IsEndCell();
                // if (isEnd)
                // {
                //     ChuanSongPosiSet.SetActive(false);
                //     return;
                // }
                //
                // for (int i = 0; i < fubenComponent.SonFubenInfo.PassableFlag.Count; i++)
                // {
                //     string path = $"NoChuanSong_{i + 1}";
                //     GameObject obj = ChuanSongPosiSet.transform.Find(path).gameObject;
                //     if (obj != null)
                //     {
                //         obj.SetActive(fubenComponent.SonFubenInfo.PassableFlag[i] == 0);
                //     }
                // }
            }
        }

        public static async ETTask ChangeCellSonScene(this SceneManagerComponent self, int sceneTypeEnum, int lastScene, int sceneid)
        {
            self.Root().GetComponent<SkillIndicatorComponent>().BeginEnterScene();
            self.Root().GetComponent<LockTargetComponent>().BeginEnterScene();

            string paramss = CellDungeonConfigCategory.Instance.Get(sceneid).MapID.ToString();

            var path = ABPathHelper.GetScenePath(paramss);
            await self.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Additive);
            Log.Warning("切换场景" + path);

            self.UpdateChuanSong(sceneTypeEnum);
            //刷新主界面
            DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            dlgMain.AfterEnterScene(sceneTypeEnum);
        }

        public static async ETTask ChangeScene(this SceneManagerComponent self, int sceneTypeEnum, int lastScene, int sceneid)
        {
            string paramss = "";
            switch (sceneTypeEnum)
            {
                case (int)SceneTypeEnum.InitScene:
                    paramss = "Init";
                    break;
                case (int)SceneTypeEnum.LoginScene:
                    paramss = "Login";
                    break;
                case (int)SceneTypeEnum.MainCityScene:
                    PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
                    string scenepath = sceneid.ToString();
                    paramss = scenepath;
                    break;
                case (int)SceneTypeEnum.CellDungeon:
                    paramss = CellDungeonConfigCategory.Instance.Get(self.Root().GetComponent<MapComponent>().SonSceneId).MapID.ToString();
                    break;
                case (int)SceneTypeEnum.LocalDungeon:
                    paramss = DungeonConfigCategory.Instance.Get(sceneid).MapID.ToString();

                    playerComponent = self.Root().GetComponent<PlayerComponent>();
                    if (!SettingData.ShowTerrain)
                    {
                        paramss = "10001_test";
                    }

                    break;
                default:
                    paramss = SceneConfigCategory.Instance.Get(sceneid).MapID.ToString();
                    break;
            }

            GameObjectLoadHelper.DisposeAll(self.Root());

            // 释放前一个场景的所有资源
            self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAllAsset();
            
            string path = ABPathHelper.GetScenePath("Empty");
                
            await self.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Single);
                
            GameObjectLoadHelper.DisposeAll(self.Root());

            // 释放前一个场景的所有资源
            self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAllAsset();
                
            path = ABPathHelper.GetScenePath(paramss);

            await self.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Single);

            Log.Warning("切换场景" + path);

            ConfigData.LoadSceneFinished = true;

            self.UpdateChuanSong(sceneTypeEnum);

            int sousceneid = self.Root().GetComponent<MapComponent>().SonSceneId;
            self.Root().GetComponent<SoundComponent>().PlayBgmSound(sceneTypeEnum, sceneid, sousceneid);
        }
    }
}