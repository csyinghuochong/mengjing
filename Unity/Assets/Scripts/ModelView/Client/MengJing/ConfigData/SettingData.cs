namespace ET.Client
{
    public class SettingData
    {
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
        public static bool UsePool = true;

        [StaticField]
        public static bool ShowNoMoving = false; 
    }
}

