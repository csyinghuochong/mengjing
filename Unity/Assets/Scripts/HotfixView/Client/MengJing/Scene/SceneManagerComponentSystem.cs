using UnityEngine.SceneManagement;

namespace ET.Client
{
    [FriendOf(typeof (SceneManagerComponent))]
    [EntitySystemOf(typeof (SceneManagerComponent))]
    public static partial class SceneManagerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SceneManagerComponent self)
        {
        }

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
                // CellDungeonComponent fubenComponent = self.Root().GetComponent<CellDungeonComponent>();
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

        public static async ETTask ChangeSonScene(this SceneManagerComponent self, int sceneTypeEnum, string paramss)
        {
            self.Root().GetComponent<SkillIndicatorComponent>().BeginEnterScene();
            self.Root().GetComponent<LockTargetComponent>().BeginEnterScene();

            var path = ABPathHelper.GetScenePath(paramss);
            await self.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Single);

            self.UpdateChuanSong(sceneTypeEnum);
            //刷新主界面
            DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            dlgMain.AfterEnterScene(sceneTypeEnum);
        }

        public static async ETTask ChangeScene(this SceneManagerComponent self, int sceneTypeEnum, int lastScene, int chapterId)
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
                    string scenepath = chapterId.ToString();
                    paramss = scenepath;
                    break;
                case (int)SceneTypeEnum.CellDungeon:
                    paramss = ChapterSonConfigCategory.Instance.Get(self.Root().GetComponent<MapComponent>().SonSceneId).MapID.ToString();
                    break;
                case (int)SceneTypeEnum.LocalDungeon:
                    paramss = DungeonConfigCategory.Instance.Get(chapterId).MapID.ToString();

                    playerComponent = self.Root().GetComponent<PlayerComponent>();
                    if (!SettingData.ShowTerrain)
                    {
                        paramss = "10001_test";
                    }
                    break;
                default:
                    paramss = SceneConfigCategory.Instance.Get(chapterId).MapID.ToString();
                    break;
            }

            int sousceneid = self.Root().GetComponent<MapComponent>().SonSceneId;
            GameObjectLoadHelper.DisposeAll();

            // 不太明白这俩行的目的
            // await self.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(ABPathHelper.GetScenePath("Empty"), LoadSceneMode.Single);
            // await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            
            var path = ABPathHelper.GetScenePath(paramss);
            await self.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Single);
            Log.Warning("切换场景" + path);

            if (sceneTypeEnum!= SceneTypeEnum.LoginScene)
            {
                EventSystem.Instance.Publish(self.Root(), new LoadSceneFinished());
            }

            self.UpdateChuanSong(sceneTypeEnum);

            self.Root().GetComponent<SoundComponent>().PlayBgmSound(sceneTypeEnum, chapterId, sousceneid);
        }
    }
}