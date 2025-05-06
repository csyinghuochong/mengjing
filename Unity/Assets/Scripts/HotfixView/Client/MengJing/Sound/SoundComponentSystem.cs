using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(SoundComponent))]
    [EntitySystemOf(typeof(SoundComponent))]
    public static partial class SoundComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SoundComponent self)
        {
            SoundComponent.Instance = self;

            self.root = self.Root().GetComponent<GlobalComponent>().PoolRoot;
            self.m_soundclips.Clear();
            self.m_musciclips.Clear();
            self.m_loadinglist.Clear();

            self.InitMusicVolume();
        }

        public static void InitMusicVolume(this SoundComponent self)
        {
            string music = PlayerPrefsHelp.GetString(PlayerPrefsHelp.MusicVolume);
            string sound = PlayerPrefsHelp.GetString(PlayerPrefsHelp.SoundVolume);
            if (string.IsNullOrEmpty(music))
            {
                self.MusicVolume = 1f;
            }
            else
            {
                self.MusicVolume = float.Parse(music);
            }

            if (string.IsNullOrEmpty(sound))
            {
                self.SoundVolume = 1f;
            }
            else
            {
                self.SoundVolume = float.Parse(sound);
            }
        }

        public static string GetAudioOggPath(this SoundComponent self, string fileName)
        {
            return $"Assets/Bundles/Audio/{fileName}.ogg";
        }

        public static string GetAudioPath(this SoundComponent self, string fileName)
        {
            return $"Assets/Bundles/Audio/{fileName}.mp3";
        }

        /// <summary>
        /// 短暂的声音和特效
        /// 无法暂停
        /// 异步加载音效
        /// </summary>
        public static async ETTask PlayClip(this SoundComponent self, string clipName, string musicType, float volume = 0.5f)
        {
            if (!SettingData.PlaySound || self.SoundVolume <= 0f)
            {
                return;
            }

            GameObject gameObject = null;
            for (int i = 0; i < self.m_soundclips.Count; i++)
            {
                if (self.m_soundclips[i].name != clipName)
                {
                    continue;
                }

                bool isplaying = self.m_soundclips[i].GetComponent<AudioSource>().isPlaying;
                if (isplaying)
                {
                    return;
                }
                else
                {
                    gameObject = self.m_soundclips[i];
                    break;
                }
            }

            if (gameObject != null)
            {
                gameObject.GetComponent<AudioSource>().volume = volume * self.SoundVolume;
                gameObject.GetComponent<AudioSource>().Play();
                return;
            }

            if (!self.m_loadinglist.Contains(clipName))
            {
                self.m_loadinglist.Add(clipName);
                gameObject = new GameObject(clipName);
                AudioClip audioClip;
                string assetpath = string.Empty;
                if (musicType == "ogg")
                {
                    assetpath = self.GetAudioOggPath(clipName); //ogg
                }
                else
                {
                    assetpath = self.GetAudioPath(clipName); //mp3
                }

                audioClip = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<AudioClip>(assetpath);
                if (gameObject == null)
                {
                    return;
                }

                self.m_assetlist.Add(assetpath);
                self.m_loadinglist.Remove(clipName);
                AudioSource audio = gameObject.AddComponent<AudioSource>();
                gameObject.transform.SetParent(self.root);
                self.m_soundclips.Add(gameObject);
                audio.clip = audioClip;
                gameObject.GetComponent<AudioSource>().volume = volume * self.SoundVolume;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }

        /// <summary>
        /// 背景音效
        /// </summary>
        /// <param name="volume"></param>
        public static void ChangeSoundVolume(this SoundComponent self, float volume)
        {
            self.SoundVolume = volume;
            for (int i = 0; i < self.m_soundclips.Count; i++)
            {
                self.m_soundclips[i].GetComponent<AudioSource>().volume = volume;
            }

            PlayerPrefsHelp.SetString(PlayerPrefsHelp.SoundVolume, volume.ToString());
        }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <param name="volume"></param>
        public static void ChangeMusicVolume(this SoundComponent self, float volume)
        {
            self.MusicVolume = volume;
            for (int i = 0; i < self.m_musciclips.Count; i++)
            {
                self.m_musciclips[i].audio.volume = volume;
            }

            PlayerPrefsHelp.SetString(PlayerPrefsHelp.MusicVolume, volume.ToString());
        }

        /// <summary>
        /// 先释放所有的音效
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="sceneTypeEnum"></param>
        public static void PlayBgmSound(this SoundComponent self, int sceneTypeEnum, int sceneId, int sonsceneid)
        {
            self.DisposeAll();

            string music = "MainCity";
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.LoginScene:
                    music = "LoginBack";
                    break;
                case MapTypeEnum.MainCityScene:
                    music = "MainCity";
                    break;
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.JiaYuan:
                    music = SceneConfigCategory.Instance.Get(sceneId).Music;
                    break;
                case MapTypeEnum.CellDungeon:
                case MapTypeEnum.DragonDungeon:  
                    music = CellGenerateConfigCategory.Instance.Get(sceneId).Music;
                    CellDungeonConfig chapterSonConfig = CellDungeonConfigCategory.Instance.Get(sonsceneid);
                    // string[] monsters = chapterSonConfig.CreateMonster.Split('@');
                    //
                    // for (int i = 0; i < monsters.Length; i++)
                    // {
                    //     if (monsters[i] == "0")
                    //     {
                    //         continue;
                    //     }
                    //
                    //     string[] mondels = monsters[i].Split(';');
                    //     string[] monsterid = mondels[2].Split(',');
                    //     MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(int.Parse(monsterid[0]));
                    //     if (monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss)
                    //     {
                    //         music = "Boss";
                    //         break;
                    //     }
                    // }
                    break;
                case MapTypeEnum.LocalDungeon:
                    music =DungeonConfigCategory.Instance.Get(sceneId).Music;
                    break;
                default:
                    music = "Fight_1";
                    break;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if(SceneConfigHelper.UseSceneConfig(sceneTypeEnum))
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
                music = sceneConfig.Music;
            }
            
            if (music != "")
            {
                self.PlayMusic(music).Coroutine();
            }
        }

        //播放SoundData
        public static async ETTask PlayMusic(this SoundComponent self, string clipName, float volume = 0.5f)
        {
            if (!SettingData.PlaySound || self.SoundVolume <= 0f)
            {
                return;
            }

            string assetpath = ABPathHelper.GetSoundPath(clipName);
            self.m_assetlist.Add(assetpath);
            GameObject bundleGameObject = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetpath);
            GameObject prefab = UnityEngine.Object.Instantiate(bundleGameObject);
            SoundData soundData = prefab.GetComponent<SoundData>();
            prefab.transform.SetParent(self.root);

            self.m_musciclips.Add(soundData);
            soundData.audio.volume = volume * self.MusicVolume;
            soundData.audio.loop = true;
            soundData.audio.Play();
        }

        /// <summary>
        /// 停止并销毁音乐
        /// </summary>
        /// <param name="clipName"></param>
        public static void Stop(this SoundComponent self, string clipName)
        {
        }

        /// <summary>
        /// 销毁所有声音
        /// </summary>
        public static void DisposeAll(this SoundComponent self)
        {
            self.m_loadinglist.Clear();

            for (int i = 0; i < self.m_soundclips.Count; i++)
            {
                GameObject.DestroyImmediate(self.m_soundclips[i]);
            }

            self.m_soundclips.Clear();

            for (int i = 0; i < self.m_musciclips.Count; i++)
            {
                self.m_musciclips[i].Dispose();
            }

            self.m_musciclips.Clear();

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.m_assetlist.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.m_assetlist[i]);
            }

            self.m_assetlist.Clear();
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.SoundComponent self)
        {
            self.DisposeAll();
        }
    }
}