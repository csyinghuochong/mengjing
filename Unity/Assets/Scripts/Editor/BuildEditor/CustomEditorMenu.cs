using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ET;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 剪切板
/// </summary>
public class ClipBoard
{
    /// <summary>
    /// 将信息复制到剪切板当中
    /// </summary>
    public static void Copy(string format, params object[] args)
    {
        string result = string.Format(format, args);
        TextEditor editor = new TextEditor();
        editor.text = result; // new GUIContent(result);
        editor.OnFocus();
        editor.Copy();
    }
}

public class CustomEditorMenu
{
    [MenuItem("Custom/修改Tag 子对象的Tag同步为父对象")]
    static void ChangeChildTag()
    {
        if (Selection.gameObjects.Length == 0)
        {
            return;
        }

        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            GameObject go = Selection.gameObjects[i];
            SetChildTags(go.transform, go.tag);
        }
    }

    private static void SetChildTags(Transform target, string tag)
    {
        if (target == null)
        {
            return;
        }

        foreach (Transform item in target)
        {
            item.tag = tag;
            SetChildTags(item, tag);
        }
    }

    [MenuItem("Custom/清除Tag 场景的NavMesh会清除")]
    static void FindTagNavMesh()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("NavMesh");
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name.Equals("NavMesh") ||
                gameObject.transform.parent.name.Equals("NavMesh"))
            {
                continue;
            }

            gameObject.tag = "Untagged";
            Debug.Log(gameObject.name + "   set tag Untagged");
        }

        Debug.Log("查找完成！！");
    }

    [MenuItem("Custom/生成连接坡体")]
    static void GenerateConnectSlope()
    {
        if (Selection.gameObjects.Length != 2)
        {
            Debug.LogError("必须选择两个Cube");
            return;
        }

        GameObject gameObject_1 = Selection.gameObjects[0];
        GameObject gameObject_2 = Selection.gameObjects[1];

        if (!gameObject_1.name.Contains("Cube") || !gameObject_2.name.Contains("Cube"))
        {
            Debug.LogError("必须选择两个Cube");
            return;
        }

        Vector3 eulerAngles_1 = gameObject_1.transform.eulerAngles;
        Vector3 eulerAngles_2 = gameObject_2.transform.eulerAngles;

        if (!eulerAngles_1.Equals(Vector3.zero) || !eulerAngles_2.Equals(Vector3.zero))
        {
            Debug.LogError("Cube有旋转 ");
            GenerateConnectSlope_2(gameObject_1, gameObject_2);
        }
        else
        {
            GenerateConnectSlope_1(gameObject_1, gameObject_2);
        }
    }

    private static void GenerateConnectSlope_1(GameObject gameObject_1, GameObject gameObject_2)
    {
        Vector3 position_1 = gameObject_1.transform.localPosition;
        Vector3 position_2 = gameObject_2.transform.localPosition;

        Vector3 scale_1 = gameObject_1.transform.localScale;
        Vector3 scale_2 = gameObject_2.transform.localScale;

        // 获取Cube组件
        float obj1_y = position_1.y + scale_1.y * 0.5f;
        Vector3 obj1_postion_1 = new Vector3(position_1.x - scale_1.x * 0.5f, obj1_y, position_1.z - scale_1.z * 0.5f);
        Vector3 obj1_postion_2 = new Vector3(position_1.x + scale_1.x * 0.5f, obj1_y, position_1.z - scale_1.z * 0.5f);
        Vector3 obj1_postion_3 = new Vector3(position_1.x - scale_1.x * 0.5f, obj1_y, position_1.z + scale_1.z * 0.5f);
        Vector3 obj1_postion_4 = new Vector3(position_1.x + scale_1.x * 0.5f, obj1_y, position_1.z + scale_1.z * 0.5f);

        float obj2_y = position_2.y + scale_2.y * 0.5f;
        Vector3 obj2_postion_1 = new Vector3(position_2.x - scale_2.x * 0.5f, obj2_y, position_2.z - scale_2.z * 0.5f);
        Vector3 obj2_postion_2 = new Vector3(position_2.x + scale_2.x * 0.5f, obj2_y, position_2.z - scale_2.z * 0.5f);
        Vector3 obj2_postion_3 = new Vector3(position_2.x - scale_2.x * 0.5f, obj2_y, position_2.z + scale_2.z * 0.5f);
        Vector3 obj2_postion_4 = new Vector3(position_2.x + scale_2.x * 0.5f, obj2_y, position_2.z + scale_2.z * 0.5f);

        bool Up = false, down = false, left = false, right = false;
        if (obj2_postion_1.z > obj1_postion_1.z && obj2_postion_2.z > obj1_postion_2.z
            && obj2_postion_3.z > obj1_postion_3.z && obj2_postion_4.z > obj1_postion_4.z)
        {
            Up = true;
        }

        if (obj2_postion_1.z < obj1_postion_1.z && obj2_postion_2.z < obj1_postion_2.z
            && obj2_postion_3.z < obj1_postion_3.z && obj2_postion_4.z < obj1_postion_4.z)
        {
            down = true;
        }

        if (obj2_postion_1.x < obj1_postion_1.x && obj2_postion_2.x < obj1_postion_2.x
            && obj2_postion_3.x < obj1_postion_3.x && obj2_postion_4.x < obj1_postion_4.x)
        {
            left = true;
        }

        if (obj2_postion_1.x > obj1_postion_1.x && obj2_postion_2.x > obj1_postion_2.x
            && obj2_postion_3.x > obj1_postion_3.x && obj2_postion_4.x > obj1_postion_4.x)
        {
            right = true;
        }

        float distance = 0;
        Vector3 vector3_init = Vector3.zero;
        Vector3 vector3_dire = Vector3.zero;
        if (Up)
        {
            vector3_init = new Vector3(position_1.x, obj1_y, obj1_postion_3.z);
            Vector3 vector3_end = new Vector3(vector3_init.x, obj2_y, obj2_postion_1.z);
            vector3_dire = (vector3_end - vector3_init).normalized;
            distance = Vector3.Distance(vector3_init, vector3_end);
        }

        if (down)
        {
            vector3_init = new Vector3(position_1.x, obj1_y, obj1_postion_1.z);
            Vector3 vector3_end = new Vector3(vector3_init.x, obj2_y, obj2_postion_3.z);
            vector3_dire = (vector3_end - vector3_init).normalized;
            distance = Vector3.Distance(vector3_init, vector3_end);
        }

        if (left)
        {
            vector3_init = new Vector3(obj1_postion_1.x, obj1_y, position_1.z);
            Vector3 vector3_end = new Vector3(obj2_postion_4.x, obj2_y, vector3_init.z);
            vector3_dire = (vector3_end - vector3_init).normalized;
            distance = Vector3.Distance(vector3_init, vector3_end);
        }

        if (right)
        {
            vector3_init = new Vector3(obj1_postion_2.x, obj1_y, position_1.z);
            Vector3 vector3_end = new Vector3(obj2_postion_1.x, obj2_y, vector3_init.z);
            vector3_dire = (vector3_end - vector3_init).normalized;
            distance = Vector3.Distance(vector3_init, vector3_end);
        }

        if (distance == 0)
        {
            return;
        }

        string cube_name = gameObject_1.name + "_" + gameObject_2.gameObject;
        if (GameObject.Find($"NavMesh/{cube_name}") != null)
        {
            GameObject.DestroyImmediate(GameObject.Find($"NavMesh/{cube_name}").gameObject);
        }

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = cube_name;
        cube.gameObject.name = cube_name;
        cube.transform.SetParent(GameObject.Find("NavMesh").transform);
        cube.transform.localPosition = vector3_init + (vector3_dire * distance * 0.5f);
        cube.transform.localScale = new Vector3(distance, 0.01f, distance);
        cube.transform.LookAt(vector3_dire * 10 + cube.transform.localPosition);
        Log.Debug("生成完毕！！");
    }

    private static void GenerateConnectSlope_2(GameObject gameObject_1, GameObject gameObject_2)
    {
        Vector3 position_1 = gameObject_1.transform.localPosition;
        Vector3 position_2 = gameObject_2.transform.localPosition;

        Vector3 eulerAngles_1 = gameObject_1.transform.eulerAngles;
        Vector3 eulerAngles_2 = gameObject_2.transform.eulerAngles;
        Vector3 scale_1 = gameObject_1.transform.localScale;
        Vector3 scale_2 = gameObject_2.transform.localScale;

        if (Math.Abs(eulerAngles_1.y - eulerAngles_2.y) > 0.001f)
        {
            Log.Error("Y方向有旋转 无法生成！");
            return;
        }

        string cube_name = gameObject_1.name + "_" + gameObject_2.gameObject;
        if (GameObject.Find($"NavMesh/{cube_name}") != null)
        {
            GameObject.DestroyImmediate(GameObject.Find($"NavMesh/{cube_name}").gameObject);
        }

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = cube_name;
        cube.gameObject.name = cube_name;
        cube.transform.SetParent(GameObject.Find("NavMesh").transform);
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        float angle = math.degrees(math.atan2(position_2.z - position_1.z, position_2.x - position_1.x));
        angle = (angle + 360) % 360;

        bool Up = false, down = false, left = false, right = false;
        if (angle > 45 && angle <= 135)
        {
            Up = true;
        }
        else if (angle > 135 && angle <= 225)
        {
            left = true;
        }
        else if (angle > 225 && angle <= 315)
        {
            down = true;
        }
        else
        {
            right = true;
        }

        //左右可以绕YZ   [y必须是一样  z可以不一样 x必须为0]
        if (left || right)
        {
            if (Math.Abs(eulerAngles_1.x) > 0.01f || Math.Abs(eulerAngles_2.x) > 0.01f)
            {
                Log.Error("X方向有旋转 无法生成！");
                return;
            }

            Vector3 position_top_1_a = gameObject_1.transform.localPosition
                    + gameObject_1.transform.right * scale_1.x * 0.5f
                    + gameObject_1.transform.up * scale_1.y * 0.5f;
            Vector3 position_top_1_b = gameObject_1.transform.localPosition
                    + gameObject_1.transform.right * scale_1.x * -0.5f
                    + gameObject_1.transform.up * scale_1.y * 0.5f;

            Vector3 position_top_2_a = gameObject_2.transform.localPosition
                    + gameObject_2.transform.right * scale_2.x * 0.5f
                    + gameObject_2.transform.up * scale_2.y * 0.5f;
            Vector3 position_top_2_b = gameObject_2.transform.localPosition
                    + gameObject_2.transform.right * scale_2.x * -0.5f
                    + gameObject_2.transform.up * scale_2.y * 0.5f;

          
            if (left)
            {
                Vector3 position_top_2_aa = position_top_2_a + gameObject_2.transform.forward * 1;
                Vector3 position_top_2_ac = GetVerticalProjectionOnLineSegment(position_top_1_b, position_top_2_a, position_top_2_aa);
               
                cube.transform.localPosition = (position_top_1_b + position_top_2_ac) * 0.5f;
                cube.transform.localScale = new Vector3(Vector3.Distance(position_top_1_b, position_top_2_ac), 0.1f,
                    Vector3.Distance(position_top_1_b, position_top_2_ac));
                cube.transform.LookAt(position_top_2_ac);
            }
            else
            {
                Vector3 position_top_1_aa = position_top_1_a + gameObject_1.transform.forward * 1;
                Vector3 position_top_1_ac = GetVerticalProjectionOnLineSegment(position_top_2_b, position_top_1_a, position_top_1_aa);
                cube.transform.localPosition = (position_top_2_b + position_top_1_ac) * 0.5f;
                cube.transform.localScale = new Vector3(Vector3.Distance(position_top_2_b, position_top_1_ac), 0.1f,
                    Vector3.Distance(position_top_2_b, position_top_1_ac));
                cube.transform.LookAt(position_top_1_ac);
            }
        }
        //上下可以绕XZ  [y必须是一样  x可以不一样 z必须为0]
        if (Up || down)
        {
            if (Math.Abs(eulerAngles_1.z) > 0.01f || Math.Abs(eulerAngles_2.z) > 0.01f)
            {
                Log.Error("Z方向有旋转 无法生成！");
                return;
            }

            Vector3 position_top_1_a = gameObject_1.transform.localPosition
                    + gameObject_1.transform.forward * scale_1.z * 0.5f
                    + gameObject_1.transform.up * scale_1.y * 0.5f;
            Vector3 position_top_1_b = gameObject_1.transform.localPosition
                    + gameObject_1.transform.forward * scale_1.z * -0.5f
                    + gameObject_1.transform.up * scale_1.y * 0.5f;

            Vector3 position_top_2_a = gameObject_2.transform.localPosition
                    + gameObject_2.transform.forward * scale_2.z * 0.5f
                    + gameObject_2.transform.up * scale_2.y * 0.5f;
            Vector3 position_top_2_b = gameObject_2.transform.localPosition
                    + gameObject_2.transform.forward * scale_2.z * -0.5f
                    + gameObject_2.transform.up * scale_2.y * 0.5f;

         
            if (Up)
            {
                Vector3 position_top_2_bb = position_top_2_b + gameObject_2.transform.right * 1;
                Vector3 position_top_2_bc = GetVerticalProjectionOnLineSegment(position_top_1_a, position_top_2_b, position_top_2_bb);
               
                cube.transform.localPosition = (position_top_1_a + position_top_2_bc) * 0.5f;
                cube.transform.localScale = new Vector3(Vector3.Distance(position_top_1_a, position_top_2_bc), 0.1f,
                    Vector3.Distance(position_top_1_a, position_top_2_bc));
                cube.transform.LookAt(position_top_2_bc);
            }
            else
            {
                Vector3 position_top_2_aa = position_top_2_a + gameObject_2.transform.right * 1;
                Vector3 position_top_2_ac = GetVerticalProjectionOnLineSegment(position_top_1_b, position_top_2_a, position_top_2_aa);
               

                cube.transform.localPosition = (position_top_1_b + position_top_2_ac) * 0.5f;
                cube.transform.localScale = new Vector3(Vector3.Distance(position_top_1_b, position_top_2_ac), 0.1f,
                    Vector3.Distance(position_top_1_b, position_top_2_ac));
                cube.transform.LookAt(position_top_2_ac);
            }
        }
    }

    public static Vector3 GetVerticalProjectionOnLineSegment(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
    {
        Vector3 lineDir = (lineEnd - lineStart).normalized;
        Vector3 pointDir = point - lineStart;

        float dotProduct = Vector3.Dot(pointDir, lineDir);
        Vector3 pointOnLine = lineDir * dotProduct;

        // Vector3 projectionDir = pointOnLine - pointDir;
        // return lineStart + projectionDir;

        return lineStart + lineDir * dotProduct;
    }

    private static void ConnectCubes(Transform cube1, Transform cube2)
    {
        Mesh mesh1 = cube1.GetComponent<MeshFilter>().mesh;
        Mesh mesh2 = cube2.GetComponent<MeshFilter>().mesh;

        Vector3[] vertices1 = mesh1.vertices;
        Vector3[] vertices2 = mesh2.vertices;

        // 移动第二个立方体的顶点位置，使其与第一个立方体对齐
        for (int i = 0; i < vertices2.Length; i++)
        {
            vertices2[i] += cube1.position - cube2.position;
        }

        // 合并两个立方体的顶点数组
        Vector3[] combinedVertices = new Vector3[vertices1.Length + vertices2.Length];
        vertices1.CopyTo(combinedVertices, 0);
        vertices2.CopyTo(combinedVertices, vertices1.Length);

        // 创建新的三角形索引来连接两个立方体的面
        int[] triangles1 = mesh1.triangles;
        int[] triangles2 = mesh2.triangles;
        int[] combinedTriangles = new int[triangles1.Length + triangles2.Length];
        triangles1.CopyTo(combinedTriangles, 0);

        // 为第二个立方体的面添加偏移量，以匹配新的顶点数组
        for (int i = 0; i < triangles2.Length; i++)
        {
            combinedTriangles[triangles1.Length + i] = vertices2.Length + triangles2[i];
        }

        // 创建新的Mesh并应用到一个新的GameObject上
        Mesh combinedMesh = new Mesh();
        combinedMesh.vertices = combinedVertices;
        combinedMesh.triangles = combinedTriangles;
        combinedMesh.RecalculateNormals();

        GameObject combinedObject = new GameObject("ConnectedCubes");
        MeshFilter meshFilter = combinedObject.AddComponent<MeshFilter>();
        meshFilter.mesh = combinedMesh;
        MeshRenderer meshRenderer = combinedObject.AddComponent<MeshRenderer>();
        meshRenderer.material = cube1.GetComponent<MeshRenderer>().material; // 使用第一个立方体的材质
    }

    [MenuItem("Custom/生成坐标点XZ到文件")]
    static void ExportPositions()
    {
        string postionList = "";

        if (Selection.gameObjects.Length == 0)
            return;

        GameObject gameObject = Selection.gameObjects[0];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Vector3 vector3 = gameObject.transform.GetChild(i).transform.position;
            //int x = Mathf.RoundToInt(vector3.x * 100);
            //int y = Mathf.RoundToInt(vector3.y * 100);
            //int z = Mathf.RoundToInt(vector3.z * 100);

            postionList += $"{vector3.x.ToString("F2")},1.00f,{vector3.z.ToString("F2")}";
            postionList += "\r\n";
        }

        string dataPath = Application.dataPath;
        dataPath = dataPath.Substring(0, dataPath.Length - 6);
        dataPath = dataPath.Substring(0, dataPath.Length - 6);
        string filePath = dataPath + "/Release/MonsterPosition.txt";

        if (!File.Exists(filePath))
            File.Create(filePath);

        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
        StreamWriter sw = new StreamWriter(fs);
        fs.SetLength(0); //首先把文件清空了。
        sw.Write(postionList); //写你的字符串。
        sw.Close();

        UnityEngine.Debug.Log("生成坐标点成功！生成:" + gameObject.transform.childCount + "个");
    }

    [MenuItem("Custom/获取怪物ID和坐标")]
    static void ExportMonsterIdAndPositions()
    {
        string postionList = "";

        if (Selection.gameObjects.Length == 0)
            return;

        GameObject gameObject = Selection.gameObjects[0];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            string gamename = gameObject.transform.GetChild(i).gameObject.name;
            int index = -1;
            //空字符 或者 （
            index = gamename.IndexOf(" ");
            if (index == -1)
            {
                index = gamename.IndexOf("(");
            }

            if (index != -1)
            {
                gamename = gamename.Substring(0, index);
            }

            int monsterId = int.Parse(gamename);

            Vector3 vector3 = gameObject.transform.GetChild(i).position;

            postionList += $"1;{vector3.x.ToString("F2")},{vector3.y.ToString("F2")},{vector3.z.ToString("F2")};{monsterId};1";
            if (i != gameObject.transform.childCount - 1)
            {
                //postionList += "@";
                postionList += "\r\n";
            }
            //postionList += "\r\n";
        }

        ClipBoard.Copy(postionList);
        //string dataPath = Application.dataPath;
        //dataPath = dataPath.Substring(0, dataPath.Length - 6);
        //dataPath = dataPath.Substring(0, dataPath.Length - 6);
        //string filePath = dataPath + "/Release/MonsterIDAndPosition.txt";

        //if (!File.Exists(filePath))
        //	File.Create(filePath);

        //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
        //StreamWriter sw = new StreamWriter(fs);
        //fs.SetLength(0);//首先把文件清空了。
        //sw.Write(postionList);//写你的字符串。
        //sw.Close();

        UnityEngine.Debug.Log("导出坐标点成功！生成:" + gameObject.transform.childCount + "个");
    }

    [MenuItem("Custom/获取坐标点和缩放")]
    static void GetPositions()
    {
        string postionList = "";

        if (Selection.gameObjects.Length != 1)
            return;

        GameObject gameObjects = Selection.gameObjects[0];
        for (int i = 0; i < gameObjects.transform.childCount; i++)
        {
            GameObject gameObject = gameObjects.transform.GetChild(i).gameObject;
            Vector3 vector3 = gameObject.transform.position;
            Vector3 sceleV = gameObject.transform.localScale;

            postionList += gameObject.name + "|" + vector3.x.ToString("F2") + "," + vector3.y.ToString("F2") + "," + vector3.z.ToString("F2") +
                    "|" + sceleV.x.ToString("F2") + "," + sceleV.y.ToString("F2") + "," + sceleV.z.ToString("F2");
            postionList += "\r\n";
        }

        ClipBoard.Copy(postionList);
        UnityEngine.Debug.Log("导出坐标点成功！");
    }

    [MenuItem("Custom/拷贝GameObjectPath")]
    private static void CopyGameObjectPath()
    {
        UnityEngine.Object obj = Selection.activeObject;
        if (obj == null)
        {
            Debug.LogError("You must select Obj first!");
            return;
        }

        string result = AssetDatabase.GetAssetPath(obj);
        if (string.IsNullOrEmpty(result)) //如果不是资源则在场景中查找
        {
            Transform selectChild = Selection.activeTransform;
            if (selectChild != null)
            {
                result = selectChild.name;
                while (selectChild.parent != null)
                {
                    selectChild = selectChild.parent;
                    result = string.Format("{0}/{1}", selectChild.name, result);
                }
            }
        }

        ClipBoard.Copy(result);
        Debug.Log(string.Format("The gameobject:{0}'s path has been copied to the clipboard!", obj.name));
    }

    [MenuItem("Custom/获取喜从天降所有格子的坐标点")]
    static void GetAllBoxPositions()
    {
        var objs = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
        string postionList = "";
        foreach (GameObject obj in objs)
        {
            if (obj.name.StartsWith("Box"))
            {
                Vector3 vector3 = obj.transform.position;
                Vector3 scelev = obj.transform.localScale;
                postionList += "new Vector3(" + vector3.x.ToString("F2") + "f," + vector3.y.ToString("F2") + "f," + vector3.z.ToString("F2") +
                        "f),\n";
            }
        }

        ClipBoard.Copy(postionList.Remove(postionList.Length - 1));
        UnityEngine.Debug.Log("导出坐标点成功！");
    }

    [MenuItem("Custom/获取Shader路径")]
    static void FindAllShaders()
    {
        string shaderPaths = "";

        string projectPath = Application.dataPath.Replace("/Assets", "");

        string[] allFiles = Directory.GetFiles(projectPath, "*.*", SearchOption.AllDirectories);

        foreach (string file in allFiles)
        {
            if (file.EndsWith(".shader"))
            {
                shaderPaths += file + "\n";
            }
        }

        ClipBoard.Copy(shaderPaths);
    }

    // 修改选择的文件夹中Prefab引用的模型的fbx设置
    [MenuItem("Custom/Modify Prefab FBX Settings")]
    public static void ModifyPrefabFBXSettings()
    {
        string folderPath = EditorUtility.OpenFolderPanel("选中文件夹", "", "");
        if (string.IsNullOrEmpty(folderPath))
        {
            Debug.Log("选择文件夹操作无效");
            return;
        }

        string[] prefabPaths = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

        foreach (string prefabPath in prefabPaths)
        {
            string fullString = prefabPath;
            string prefix = "Assets";
            string subString = string.Empty;
            int startIndex = fullString.IndexOf(prefix);
            if (startIndex != -1)
            {
                subString = fullString.Substring(startIndex);
            }
            else
            {
                continue;
            }

            string[] dependencies = AssetDatabase.GetDependencies(new string[] { subString });
            foreach (string dependency in dependencies)
            {
                if (dependency.EndsWith(".fbx", System.StringComparison.OrdinalIgnoreCase))
                {
                    ModelImporter modelImporter = AssetImporter.GetAtPath(dependency) as ModelImporter;

                    if (modelImporter != null)
                    {
                        // 修改设置
                        modelImporter.bakeAxisConversion = false;
                        modelImporter.importBlendShapes = false;
                        modelImporter.importVisibility = false;
                        modelImporter.importCameras = false;
                        modelImporter.importLights = false;
                        modelImporter.preserveHierarchy = false;

                        modelImporter.meshCompression = ModelImporterMeshCompression.Medium;
                        modelImporter.isReadable = false;
                        // .....

                        modelImporter.materialImportMode = ModelImporterMaterialImportMode.None;

                        EditorUtility.SetDirty(modelImporter);
                        AssetDatabase.ImportAsset(dependency); // 保存设置
                    }
                }
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    // [MenuItem("Asset / ), false, 1]
    [MenuItem("Assets/Custom/Check  Dependencies", false, 1)] //路径
    public static void CheckDependencies()
    {
        string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
        UnityEngine.Debug.Log("fontPath: " + fontPath);
        UnityEngine.Debug.Log("KCheckDependencies: Begin");

        string[] dependPathList = AssetDatabase.GetDependencies(new string[] { fontPath });
        foreach (string path in dependPathList)
        {
            using (var stream = File.OpenRead(path))
            {
                long fileSize = stream.Length;
                UnityEngine.Debug.Log(fileSize + "   " + path);
            }
        }

        UnityEngine.Debug.Log("KCheckDependencies: End");
    }
}