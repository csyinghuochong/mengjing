namespace ET
{
    /// <summary>
    /// AB实用函数集，主要是路径拼接
    /// </summary>
    public class ABPathHelper
    {
        public static string GetAnimFbxPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Animation/{0}.fbx", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetMaterialPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Material/{0}.mat", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetTexturePath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Altas/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetUGUIPath(string name)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/UI/{0}.prefab", name).Intern();
            }

            return prefabPath;
        }

        public static string GetConfigPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Config/{0}.bytes", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetMapConfigPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/MapConfig/{0}.bytes", fileName).Intern();
            }

            return prefabPath;
        }
        
        public static string GetNormalConfigPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Independent/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetAudioPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Audio/{0}.mp3", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetAudioOggPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Audio/{0}.ogg", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetSoundPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Sound/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetUnitPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Unit/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }
        
        public static string GetSceneUnitPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Unit/Scene/{0}.prefab", fileName).Intern();
            }
        
            return prefabPath;
        }

        public static string GetItemPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Unit/ItemModel/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetScenePath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Scenes/{0}.unity", fileName).Intern();
            }

            return prefabPath;
        }

        public static string GetEffetPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Effect/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }

        //技能特效
        public static string GetSkillEffetPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Effect/SkillEffect/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }

        //技能受击特效
        public static string GetSkillHitEffetPath(string fileName)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Effect/SkillHitEffect/{0}.prefab", fileName).Intern();
            }

            return prefabPath;
        }

        //图集2
        public static string GetAtlasPath_2(string path, string name)
        {

            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Icon/{0}/{1}.png", path, name).Intern();
            }

            return prefabPath;
        }

        //图集
        public static string GetAtlasPath(string path)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Atlas/{0}.prefab", path).Intern();
            }

            return prefabPath;
        }

        //Png
        public static string GetJpgPath(string path)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Jpg/{0}.jpg", path).Intern();
            }

            return prefabPath;
        }

        //文本
        public static string GetTextPath(string text)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Text/{0}.txt", text).Intern();
            }

            return prefabPath;
        }
        
        public static string GetRecastPath(int text)
        {
            string prefabPath;
            using (zstring.Block())
            {
                prefabPath = zstring.Format("Assets/Bundles/Recast/{0}.bytes", text).Intern();
            }

            return prefabPath;
        }
    }
}