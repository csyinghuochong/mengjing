using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public static class SettingData
    {

        [StaticField]
        public static int MoveMode = 1;
        
        [StaticField]
        public static List<string> FindPathLog = new List<string>();
        
        [StaticField]
        public static Dictionary<long, M2C_PathfindingResult> FindPathList = new Dictionary<long, M2C_PathfindingResult>();

        [StaticField]
        public static float3 FindPathInit;
        [StaticField]
        public static float3 FindPathEnd;


        /// <summary>
        /// 模型展示方式 0 渲染RenderTexture；1 直接对着场景中的模型
        /// </summary>
        [StaticField]
        public static int ModelShow = 1;
        
        /// <summary>
        /// 动画控制方式 0 Animator；1 Animancer
        /// </summary>
        [StaticField]
        public static int AnimController = 0;

        /// <summary>
        /// 主城周围超过50个人不再进行显示
        /// </summary>
        [StaticField]
        public static int NoShowPlayer = 50;

        /// <summary>
        /// 称号周围同屏超过50个人不再进行显示
        /// </summary>
        [StaticField]
        public static int NoShowTitle = 50;

        /// <summary>
        /// 同屏超过50个人不显示光环特效(特效名称关键字: GuangHuan)
        /// </summary>
        [StaticField]
        public static int NotGuangHuan = 50;

        [StaticField]
        public static bool NoShowOther = false;

        /// <summary>
        /// 称号
        /// </summary>
        [StaticField]
        public static bool ShowTitle = true;    

        /// <summary>
        /// 血条
        /// </summary>
        [StaticField]
        public static bool ShowBlood = true;
        
        /// <summary>
        /// 光环
        /// </summary>
        [StaticField]
        public static bool ShowGuangHuan = true;

        /// <summary>
        /// 特效
        /// </summary>
        [StaticField]
        public static bool ShowEffect = true;
        
        /// <summary>
        /// 动画
        /// </summary>
        [StaticField]
        public static bool ShowAnimation = true;
        
        /// <summary>
        /// 音效
        /// </summary>
        [StaticField]
        public static bool PlaySound = true;
        
        [StaticField]
        public static bool HideNoMoving = true; 
        
        
        [StaticField]
        public static bool ShowMonster = true; 
        
        
        [StaticField]
        public static bool UseSceneAOI = false;   //true需要清除场景的pool节点。。

        [StaticField]
        public static bool ShowSceneUnit = true;   //true需要清除场景的pool节点。。
    }
}

