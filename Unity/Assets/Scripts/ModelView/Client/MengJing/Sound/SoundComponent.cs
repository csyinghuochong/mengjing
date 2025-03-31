using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class SoundComponent: Entity, IAwake, IDestroy
    {
        [StaticField]
        public static SoundComponent Instance;

        //根物体
        public Transform root;

        //所有音效
        public List<GameObject> m_soundclips = new();

        //所有音乐
        public List<SoundData> m_musciclips = new();

        public List<string> m_loadinglist = new();

        public List<string> m_assetlist = new();

        public float MusicVolume = 1f;
        public float SoundVolume = 1f;
    }
}