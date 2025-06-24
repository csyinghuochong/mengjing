using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ET.Client
{
    public class SceneChecker5 : EditorWindow
    {
        
        static double FormatDecimal(float value)
        {
            //string formattedNumber = value.ToString("F2");
            //return formattedNumber;
            double roundedValue = Math.Round(value, 2);
            return roundedValue;
        }
            
        
        //判断是否为预制体的根节点
        static int IsPrefabRoot(GameObject obj)
        {
            if (PrefabUtility.IsAnyPrefabInstanceRoot(obj))
            {
                return 1; //根perfab
            }

            if (PrefabStageUtility.GetCurrentPrefabStage()?.prefabContentsRoot == obj)
            {
                return 2;
            }

            if (PrefabUtility.GetOutermostPrefabInstanceRoot(obj) == obj)
            {
                return 3;
            }

            if (PrefabUtility.IsPartOfAnyPrefab(obj))
            {
                return 4;
            }

            return 0;
        }

        
        static bool PrefabMoveToBundle(string prefabpath)
            {
                string projectPath = Application.dataPath.Substring(0, Application.dataPath.Length - "/Assets".Length);
                //Application.dataPath = H:/GitMengJing/Unity/Assets    projectPath = H:/GitMengJing/Unity
                prefabpath = projectPath + "/" + prefabpath;
        
                if (prefabpath.Contains("Bundles/Unit/Scene"))
                {
                    return true;
                }
        
                //.meta
                string[] pathlist = prefabpath.Split('/');
                string destinationFile = Application.dataPath + "/Bundles/Unit/Scene/" + pathlist[pathlist.Length - 1];
        
                bool moveret = FileHelper.MoveFile(prefabpath, destinationFile);
                FileHelper.MoveFile(prefabpath + ".meta", destinationFile + ".meta");
        
                Debug.Log($"{prefabpath}   to    {destinationFile}");
        
                return moveret;
            }
            
        
         /// <summary>
        /// prefab文件尽量放在AdditiveHide/pool节点下面，不要嵌套。。
        /// </summary>
       // [MenuItem("ET/NavMesh/导出场景生成配置文件")]
        static void ExportScene()
    {

        string rootname = "pool";
        GameObject gameObjectpool = GameObject.Find($"AdditiveHide/{rootname}"); // 获取当前GameObject的Transform
        if (gameObjectpool == null)
        {
            Log.Error($"AdditiveHide/{rootname}节点不存在");
            return;
        }

        Transform parentTransform = gameObjectpool.transform;
        Transform[] allchildren = parentTransform.GetComponentsInChildren<Transform>(); // 创建一个GameObject数组

        // 打印出所有子GameObject的名字
        // export节点下面必须全部是perfab 并且 不能有嵌套frefab
        bool sceneerror = false;
        Dictionary<string, string> validobjectlist = new Dictionary<string, string>();
        foreach (var gameObject in allchildren)
        {
            //Debug.Log(gameObject.name);
            if (gameObject.name.Equals(rootname))
            {
                continue;
            }

            if (IsEmptyNode(gameObject.gameObject))
            {
                continue;
            }

            if (IsPrefabRoot(gameObject.gameObject) != 1)
            {
                continue;
            }

            string prefabname = GetPrefabName(gameObject.gameObject);

            if (string.IsNullOrEmpty(prefabname))
            {
                Log.Error($"{gameObject.name}:  找不到Prefab资源！");
                sceneerror = true;
                break;
            }

            string parentname = gameObject.transform.parent.name;
            if (prefabname.Equals(parentname))
            {
                parentname = gameObject.transform.parent.parent.name;
            }

            if (!parentname.Equals(rootname) && !parentname.Equals(prefabname))
            {
                Log.Warning($"{gameObject.name}:  未处理，可能是嵌套Prefab");
                continue;
            }

            // 确保传入的GameObject是一个Prefab实例
            string prefabpath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(gameObject);
            bool moveret = PrefabMoveToBundle(prefabpath);
            if (!moveret)
            {
                sceneerror = true;
                break;
            }

            if (!validobjectlist.ContainsKey(prefabname))
            {
                validobjectlist.Add(prefabname, string.Empty);
            }
            else
            {
                validobjectlist[prefabname] += "|";
            }

            string objectinfo =
                    $"{FormatDecimal(gameObject.position.x)}:{FormatDecimal(gameObject.position.y)}:{FormatDecimal(gameObject.position.z)}" +
                    $":{FormatDecimal(gameObject.localScale.x)}:{FormatDecimal(gameObject.localScale.y)}:{FormatDecimal(gameObject.localScale.z)}" +
                    $":{FormatDecimal(gameObject.rotation.eulerAngles.x)}:{FormatDecimal(gameObject.rotation.eulerAngles.y)}:{FormatDecimal(gameObject.rotation.eulerAngles.z)}" +
                    $":{gameObject.tag}:{gameObject.gameObject.layer}";
            validobjectlist[prefabname] += (objectinfo);
        }

        if (sceneerror)
        {
            return;
        }

        if (validobjectlist.Count < 2)
        {
            Log.Error("场景过于简单！！！");
            return;
        }

        string allobjectinfo = string.Empty;

        foreach (var VARIABLE in validobjectlist)
        {
            allobjectinfo += $"{VARIABLE.Key}&{VARIABLE.Value}@";
        }

        ClipBoard.Copy(allobjectinfo);

        MapObjectConfig mapObjectConfig = new MapObjectConfig();
        mapObjectConfig.Id = 1;
        mapObjectConfig.MapConfig = allobjectinfo;

        string destinationPath = $"{Application.dataPath}\\Bundles\\MapConfig\\{EditorSceneManager.GetActiveScene().name}.bytes";
        // 将二进制数据写入.bytes文件
        File.WriteAllBytes(destinationPath, mapObjectConfig.ToBson());

        GameObject.DestroyImmediate(gameObjectpool);

        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());

        Log.Debug("allobjectinfo:  " + allobjectinfo);
    }

        static bool IsEmptyNode(GameObject gameObject)
    {
        // 检查GameObject是否有组件
        if (gameObject.GetComponents<Component>().Length > 1)
        {
            return false;
        }

        // 检查GameObject是否有子节点
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!GetPrefabName(gameObject.transform.GetChild(i).gameObject).Equals(gameObject.name))
            {
                return false;
            }
        }

        return true;
    }
         
        static string GetPrefabName(GameObject gameObject)
    {
        string prefabname = string.Empty;

        // if (StringHelper.IsSpecialChar(gameObject.name))
        // {
        //     Log.Error($"{gameObject.name}:  含有特殊字符！");
        //     return prefabname;
        // }

        var type = PrefabUtility.GetPrefabAssetType(gameObject);
        var status = PrefabUtility.GetPrefabInstanceStatus(gameObject);

        // 是否为预制体实例判断
        if (type == PrefabAssetType.NotAPrefab || status == PrefabInstanceStatus.NotAPrefab)
        {
            Log.Error($"{gameObject.name}:  不是Prefab");
            return prefabname;
        }

        if (IsPrefabRoot(gameObject.gameObject) != 1)
        {
            return prefabname;
        }

        // 确保传入的GameObject是一个Prefab实例
        string prefabpath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(gameObject);
        if (string.IsNullOrEmpty(prefabpath))
        {
            Log.Error($"{gameObject.name}:  找不到Prefab资源！");
            return prefabname;
        }

        string[] pathlist = prefabpath.Split('/');

        prefabname = pathlist[pathlist.Length - 1];
        prefabname = prefabname.Substring(0, prefabname.Length - 7);

        return prefabname;
    }

        
        //[MenuItem("ET/NavMesh/导入场景修改后要导出")]
        static void ImportScene()
    {
        //TextAsset v = Resources.Load<GlobalConfig><TextAsset>($"Assets/Bundles/MapConfig/1.bytes");
        //H:\GitMengJing\Unity\Assets\Bundles\MapConfig
        byte[] bytes = File.ReadAllBytes($"{Application.dataPath}/Bundles/MapConfig/{EditorSceneManager.GetActiveScene().name}.bytes");

        if (bytes == null)
        {
            Log.Error("该场景没有生成二进制文件！！");
            return;
        }

        if (GameObject.Find("AdditiveHide") == null)
        {
            Log.Error("该场景没有AdditiveHide节点！！");
            return;
        }

        GameObject gameObjectpool = GameObject.Find("AdditiveHide/pool"); // 获取当前GameObject的Transform
        if (gameObjectpool != null)
        {
            GameObject.DestroyImmediate(gameObjectpool);
            return;
        }

        gameObjectpool = new GameObject("pool");
        gameObjectpool.transform.SetParent(GameObject.Find("AdditiveHide").transform);
        gameObjectpool.transform.SetAsFirstSibling();
        gameObjectpool.transform.localScale = Vector3.one;
        gameObjectpool.transform.localPosition = Vector3.zero;

        object category = MongoHelper.Deserialize(typeof (MapObjectConfig), bytes, 0, bytes.Length);
        MapObjectConfig singleton = category as MapObjectConfig;

        List<MapObjectItem> mapObjectItem = MapObjectItem.ToMapObjectItem(singleton.MapConfig);

        ImportMapObject(gameObjectpool, mapObjectItem);

        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        Log.Debug("ImportMapObject");
    }

        static void ImportMapObject(GameObject pool, List<MapObjectItem> mapObjectItems)
    {
        if (pool == null)
        {
            return;
        }

        foreach (var mapinfo in mapObjectItems)
        {
            // if (pool.transform.Find(mapinfo.AssetPath)!=null && pool.transform.Find(mapinfo.AssetPath).childCount > 0)
            // {
            //     GameObject.DestroyImmediate(pool.transform.Find(mapinfo.AssetPath).gameObject);
            // }

            UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath($"Assets/Bundles/Unit/Scene/{mapinfo.AssetPath}.prefab", typeof (GameObject));
            if (prefab == null)
            {
                Log.Error($"prefab == null:  {mapinfo.AssetPath}");
                continue;
            }

            GameObject gameitem = (GameObject)GameObject.Instantiate(prefab);

            GameObject gamenode = new GameObject(mapinfo.AssetPath);
            gamenode.transform.SetParent(pool.transform);
            ;
            gamenode.transform.localScale = Vector3.one;
            gamenode.transform.localPosition = Vector3.zero;

            for (int i = 0; i < mapinfo.PositionList.Count; i++)
            {
                // 将实例转换为Prefab实例
                GameObject prefabAsset = PrefabUtility.GetCorrespondingObjectFromSource(gameitem);
                if (prefabAsset != null)
                {
                    // 实例已经是Prefab的一部分，可以在这里添加你的处理逻辑
                    Debug.Log("GameObject is already a prefab instance.");
                }
                else
                {
                    // 创建一个新的Prefab实例
                    prefabAsset = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                    // 替换原始实例为Prefab实例
                    // PrefabUtility.ReplacePrefabInstanceWithPrefab(gamenode, ReplacePrefabOptions.ConnectToPrefab);
                    prefabAsset.transform.SetParent(gamenode.transform);
                    prefabAsset.transform.localPosition = mapinfo.PositionList[i];
                    prefabAsset.transform.localScale = mapinfo.ScaleList[i];
                    prefabAsset.transform.rotation = mapinfo.RotationList[i];
                    prefabAsset.name = mapinfo.AssetPath;
                }
            }

            GameObject.DestroyImmediate(gameitem);
        }
    }

    }
}