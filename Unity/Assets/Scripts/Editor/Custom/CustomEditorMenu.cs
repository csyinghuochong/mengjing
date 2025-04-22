using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ET;
using MongoDB.Bson;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

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
    static string sBundleCheckPath = "Assets/Bundles";
    static string sBundleUICheckPath = "Assets/Bundles/UI";
    static string sSceneCheckPath = "Assets/Bundles/Scenes";
    
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

    [MenuItem("Custom/生成连接坡体 距离最近的边")]
    static void GenerateConnectSlope_3()
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
            GenerateConnectSlope_3(gameObject_1, gameObject_2);
        }
        else
        {
            GenerateConnectSlope_1(gameObject_1, gameObject_2);
        }
    }

    [MenuItem("Custom/生成连接坡体 相对方向需要和朝向一致")]
    static void GenerateConnectSlope_2()
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

    private static void GenerateConnectSlope_3(GameObject gameObject_1, GameObject gameObject_2)
    {
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

        Vector3 position_top_1 = new Vector3(gameObject_1.transform.localPosition.x,
            gameObject_1.transform.localPosition.y + scale_1.y * 0.5f,
            gameObject_1.transform.localPosition.z);
        Vector3 position_top_1_a = position_top_1
                + gameObject_1.transform.forward * scale_1.z * 0.5f
                + gameObject_1.transform.right * scale_1.x * -0.5f;
        Vector3 position_top_1_b = position_top_1
                + gameObject_1.transform.forward * scale_1.z * 0.5f
                + gameObject_1.transform.right * scale_1.x * 0.5f;
        Vector3 position_top_1_c = position_top_1
                + gameObject_1.transform.forward * scale_1.z * -0.5f
                + gameObject_1.transform.right * scale_1.x * 0.5f;
        Vector3 position_top_1_d = position_top_1
                + gameObject_1.transform.forward * scale_1.z * -0.5f
                + gameObject_1.transform.right * scale_1.x * -0.5f;

        Vector3 position_top_2 = new Vector3(gameObject_2.transform.localPosition.x,
            gameObject_2.transform.localPosition.y + scale_2.y * 0.5f,
            gameObject_2.transform.localPosition.z);
        Vector3 position_top_2_a = position_top_2
                + gameObject_2.transform.forward * scale_2.z * 0.5f
                + gameObject_2.transform.right * scale_2.x * -0.5f;
        Vector3 position_top_2_b = position_top_2
                + gameObject_2.transform.forward * scale_2.z * 0.5f
                + gameObject_2.transform.right * scale_2.x * 0.5f;
        Vector3 position_top_2_c = position_top_2
                + gameObject_2.transform.forward * scale_2.z * -0.5f
                + gameObject_2.transform.right * scale_2.x * 0.5f;
        Vector3 position_top_2_d = position_top_2
                + gameObject_2.transform.forward * scale_2.z * -0.5f
                + gameObject_2.transform.right * scale_2.x * -0.5f;

        //找出距离最短的两条边
        float distance_1_ab_2_ab = DistanceToLineSegment(position_top_1_a, position_top_2_a, position_top_2_b);
        float distance_1_ab_2_cd = DistanceToLineSegment(position_top_1_a, position_top_2_c, position_top_2_d);
        float distance_1_bc_2_ad = DistanceToLineSegment(position_top_1_b, position_top_2_a, position_top_2_d);
        float distance_1_bc_2_bc = DistanceToLineSegment(position_top_1_b, position_top_2_b, position_top_2_c);
        float distance_1_cd_2_ab = DistanceToLineSegment(position_top_1_c, position_top_2_a, position_top_2_b);
        float distance_1_cd_2_cd = DistanceToLineSegment(position_top_1_c, position_top_2_c, position_top_2_d);
        float distance_1_da_2_da = DistanceToLineSegment(position_top_1_d, position_top_2_d, position_top_2_a);
        float distance_1_da_2_bc = DistanceToLineSegment(position_top_1_d, position_top_2_b, position_top_2_c);
        List<float> distancelist = new List<float>();
        distancelist.Add(distance_1_ab_2_ab);
        distancelist.Add(distance_1_ab_2_cd);
        distancelist.Add(distance_1_bc_2_ad);
        distancelist.Add(distance_1_bc_2_bc);
        distancelist.Add(distance_1_cd_2_ab);
        distancelist.Add(distance_1_cd_2_cd);
        distancelist.Add(distance_1_da_2_da);
        distancelist.Add(distance_1_da_2_bc);

        int miniIndex = -1;
        float distancemini = -1;
        for (int i = 0; i < distancelist.Count; i++)
        {
            if (distancelist[i] < distancemini || distancemini < 0)
            {
                distancemini = distancelist[i];
                miniIndex = i;
            }
        }

        Vector3 postion_init = Vector3.zero;
        Vector3 postion_end1 = Vector3.zero;
        Vector3 postion_end2 = Vector3.zero;
        switch (miniIndex)
        {
            case 0: //distance_1_ab_2_ab
                postion_init = (position_top_1_a + position_top_1_b) * 0.5f;
                postion_end1 = position_top_2_a;
                postion_end2 = position_top_2_b;
                break;
            case 1: //distance_1_ab_2_cd
                postion_init = (position_top_1_a + position_top_1_b) * 0.5f;
                postion_end1 = position_top_2_c;
                postion_end2 = position_top_2_d;
                break;
            case 2: //distance_1_bc_2_ad
                postion_init = (position_top_1_b + position_top_1_c) * 0.5f;
                postion_end1 = position_top_2_a;
                postion_end2 = position_top_2_d;
                break;
            case 3: //distance_1_bc_2_bc
                postion_init = (position_top_1_b + position_top_1_c) * 0.5f;
                postion_end1 = position_top_2_b;
                postion_end2 = position_top_2_c;
                break;
            case 4: //distance_1_cd_2_ab
                postion_init = (position_top_1_c + position_top_1_d) * 0.5f;
                postion_end1 = position_top_2_a;
                postion_end2 = position_top_2_b;
                break;
            case 5: //distance_1_cd_2_cd
                postion_init = (position_top_1_c + position_top_1_d) * 0.5f;
                postion_end1 = position_top_2_c;
                postion_end2 = position_top_2_d;
                break;
            case 6: //distance_1_da_2_da
                postion_init = (position_top_1_d + position_top_1_a) * 0.5f;
                postion_end1 = position_top_2_d;
                postion_end2 = position_top_2_a;
                break;
            case 7: //distance_1_da_2_bc
                postion_init = (position_top_1_d + position_top_1_a) * 0.5f;
                postion_end1 = position_top_2_b;
                postion_end2 = position_top_2_c;
                break;
            default:
                break;
        }

        Vector3 position_top_1_ac = GetVerticalProjectionOnLineSegment(postion_init, postion_end1, postion_end2);
        cube.transform.localPosition = (postion_init + position_top_1_ac) * 0.5f;
        cube.transform.localScale = new Vector3(Vector3.Distance(postion_init, position_top_1_ac), 0.1f,
            Vector3.Distance(postion_init, position_top_1_ac));
        cube.transform.LookAt(position_top_1_ac);
    }

    private static float DistanceToLineSegment(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
    {
        // Vector3 dir = lineEnd - lineStart;
        // Vector3 dir_normalized = dir.normalized;
        // Vector3 v = Vector3.Cross(dir_normalized, point - lineStart).normalized;
        // Vector3 point_to_start = point - lineStart;
        //
        // if (Vector3.Dot(point_to_start, dir_normalized) < 0)
        //     return point_to_start.magnitude;
        // else if (Vector3.Dot(point_to_start, dir_normalized) > dir.magnitude)
        //     return (point_to_start - dir_normalized).magnitude;
        // else
        //     return Mathf.Abs(Vector3.Distance(point, lineStart) - Vector3.Distance(point, lineEnd));

        Vector3 lineDir = (lineEnd - lineStart).normalized;
        Vector3 pointDir = point - lineStart;

        float dotProduct = Vector3.Dot(pointDir, lineDir);
        Vector3 pointOnLine = lineDir * dotProduct;

        // Vector3 projectionDir = pointOnLine - pointDir;
        // return lineStart + projectionDir;

        Vector3 point2 = lineStart + lineDir * dotProduct;
        return Vector3.Distance(point, point2);
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
        int direction = GetDirection(angle);

        float eulerAngles_1_y = eulerAngles_1.y;
        eulerAngles_1_y = (eulerAngles_1_y + 360) % 360;
        int eulerAngles_1_y_direction = GetEulerDirection(eulerAngles_1_y);

        int generatetype = 0;
        //左右可以绕YZ   [y必须是一样  z可以不一样 x必须为0]
        if (direction == 2 || direction == 4)
        {
            if (Math.Abs(eulerAngles_1.x) > 0.01f || Math.Abs(eulerAngles_2.x) > 0.01f)
            {
                Log.Error("X方向有旋转 无法生成！");
                return;
            }

            if (eulerAngles_1_y_direction == 1 || eulerAngles_1_y_direction == 3)
            {
                generatetype = 1;
            }

            if (eulerAngles_1_y_direction == 2 || eulerAngles_1_y_direction == 4)
            {
                generatetype = 2;
            }
        }

        //上下可以绕XZ  [y必须是一样  x可以不一样 z必须为0]
        if (direction == 1 || direction == 3)
        {
            if (Math.Abs(eulerAngles_1.z) > 0.01f || Math.Abs(eulerAngles_2.z) > 0.01f)
            {
                Log.Error("Z方向有旋转 无法生成！");
                return;
            }

            if (eulerAngles_1_y_direction == 1 || eulerAngles_1_y_direction == 3)
            {
                generatetype = 2;
            }

            if (eulerAngles_1_y_direction == 2 || eulerAngles_1_y_direction == 4)
            {
                generatetype = 1;
            }
        }

        if (generatetype == 1)
        {
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

            float distance_1 = Vector3.Distance(position_top_1_a, position_top_2_b);
            float distance_2 = Vector3.Distance(position_top_1_b, position_top_2_a);
            if (distance_1 < distance_2)
            {
                Vector3 position_top_1_aa = position_top_1_a + gameObject_1.transform.forward * 1;
                Vector3 position_top_1_ac = GetVerticalProjectionOnLineSegment(position_top_2_b, position_top_1_a, position_top_1_aa);
                cube.transform.localPosition = (position_top_2_b + position_top_1_ac) * 0.5f;
                cube.transform.localScale = new Vector3(Vector3.Distance(position_top_2_b, position_top_1_ac), 0.1f,
                    Vector3.Distance(position_top_2_b, position_top_1_ac));
                cube.transform.LookAt(position_top_1_ac);
            }
            else
            {
                Vector3 position_top_2_aa = position_top_2_a + gameObject_2.transform.forward * 1;
                Vector3 position_top_2_ac = GetVerticalProjectionOnLineSegment(position_top_1_b, position_top_2_a, position_top_2_aa);

                cube.transform.localPosition = (position_top_1_b + position_top_2_ac) * 0.5f;
                cube.transform.localScale = new Vector3(Vector3.Distance(position_top_1_b, position_top_2_ac), 0.1f,
                    Vector3.Distance(position_top_1_b, position_top_2_ac));
                cube.transform.LookAt(position_top_2_ac);
            }
        }
        else
        {
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

            float distance_1 = Vector3.Distance(position_top_1_a, position_top_2_b);
            float distance_2 = Vector3.Distance(position_top_1_b, position_top_2_a);
            if (distance_1 < distance_2)
            {
                Vector3 position_top_1_aa = position_top_1_a + gameObject_1.transform.right * 1;
                Vector3 position_top_1_ac = GetVerticalProjectionOnLineSegment(position_top_2_b, position_top_1_a, position_top_1_aa);
                cube.transform.localPosition = (position_top_2_b + position_top_1_ac) * 0.5f;
                cube.transform.localScale = new Vector3(Vector3.Distance(position_top_2_b, position_top_1_ac), 0.1f,
                    Vector3.Distance(position_top_2_b, position_top_1_ac));
                cube.transform.LookAt(position_top_1_ac);
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

    private static int GetDirection(float angle)
    {
        if (angle > 45 && angle <= 135)
        {
            Log.Debug("Up = true");
            return 1;
        }
        else if (angle > 135 && angle <= 225)
        {
            Log.Debug("left = true");
            return 2;
        }
        else if (angle > 225 && angle <= 315)
        {
            Log.Debug("down = true");
            return 3;
        }
        else
        {
            Log.Debug("right = true");
            return 4;
        }
    }

    private static int GetEulerDirection(float angle)
    {
        if (angle > 0 && angle <= 45)
        {
            return 1;
        }
        else if (angle > 45 && angle <= 135)
        {
            return 2;
        }
        else if (angle > 135 && angle <= 225)
        {
            return 3;
        }
        else if (angle > 225 && angle <= 315)
        {
            return 4;
        }
        else
        {
            return 1;
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

    [MenuItem("Custom/修改关卡路径点方向")]
    static void CorrectLevelPathPoints()
    {
          if (Selection.gameObjects.Length < 2)
                    return;

          int number = Selection.gameObjects.Length;
          for ( int i = 0; i < number - 1; i++ )
          {
              GameObject gameObject = Selection.gameObjects[i];
              GameObject lookatobje = Selection.gameObjects[i + 1];
              
              
              float2 direction = new float2(lookatobje.transform.position.x, lookatobje.transform.position.y) 
                      - new float2( gameObject.transform.position.x, gameObject.transform.position.y);
              
              int angel_1 = (int)(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
              
              Log.Debug($"angel_1:  {angel_1}");

              gameObject.transform.rotation = Quaternion.Euler(0, 0, angel_1);

              //gameObject.transform.LookAt( Selection.gameObjects[i - 1].transform );
          }
    }

    [MenuItem("Custom/移除所有子对象刚体和音效组件")]
    static void RemoveChildRigidboy()
    {
        if (Selection.gameObjects.Length != 1)
            return;

        GameObject gameObject = Selection.gameObjects[0];
        
        Component[] components = gameObject.GetComponentsInChildren<Component>();
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] == gameObject || components[i] == null)
                continue;
 
            // 打印非this的组件类型
            string comname =   components[i].GetType().Name;

            if (comname.Contains("PhysicsObject"))
            {
                GameObject.DestroyImmediate(components[i]);
            }
        }
        
        Rigidbody[] rigidbodies =   gameObject.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            GameObject.DestroyImmediate(rigidbodies[i]);
        }
       
        AudioSource[] audioSources =  gameObject.GetComponentsInChildren<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            GameObject.DestroyImmediate(audioSources[i]);
        }

        
        AssetDatabase.SaveAssets();
    }
    
    private static void RemoveChildComponent(GameObject go)
    {
        // Transform t = go.transform;
        //
        //
        // for (int i = 0; i < t.childCount; i++)
        // {
        //     RemoveChildComponent(t.GetChild(i).gameObject);
        // }
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

            SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
            if (sphereCollider != null)
            {
                 float radiusss = sphereCollider.radius;
                 postionList += gameObject.name + "|" + vector3.x.ToString("F2") + "," + vector3.y.ToString("F2") + "," + vector3.z.ToString("F2") +
                                    "|" + sceleV.x.ToString("F2") + "," + sceleV.y.ToString("F2") + "," + sceleV.z.ToString("F2")+ "|" + radiusss;
            }
            else
            {
                postionList += gameObject.name + "|" + vector3.x.ToString("F2") + "," + vector3.y.ToString("F2") + "," + vector3.z.ToString("F2") +
                        "|" + sceleV.x.ToString("F2") + "," + sceleV.y.ToString("F2") + "," + sceleV.z.ToString("F2");
            }

           
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
        var objs = Resources.FindObjectsOfTypeAll(typeof (GameObject)) as GameObject[];
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

    /// <summary>
    /// prefab文件尽量放在AdditiveHide/pool节点下面，不要嵌套。。
    /// </summary>
    //[MenuItem("ET/NavMesh/导出场景生成配置文件")]
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
            // if (prefabname.Equals(parentname))
            // {
            //     parentname = gameObject.transform.parent.parent.name;
            // }

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

        string destinationPath = $"H:\\GitMengJing\\Unity\\Assets\\Bundles\\MapConfig\\{EditorSceneManager.GetActiveScene().name}.bytes";
        // 将二进制数据写入.bytes文件
        File.WriteAllBytes(destinationPath, mapObjectConfig.ToBson());

        GameObject.DestroyImmediate(gameObjectpool);

        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());

        Log.Debug("allobjectinfo:  " + allobjectinfo);
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

    //[MenuItem("ET/NavMesh/导入场景修改后要导出")]
    static void ImportScene()
    {
        //TextAsset v = Resources.Load<GlobalConfig><TextAsset>($"Assets/Bundles/MapConfig/1.bytes");
        //H:\GitMengJing\Unity\Assets\Bundles\MapConfig
        byte[] bytes = File.ReadAllBytes($"H:/GitMengJing/Unity/Assets/Bundles/MapConfig/{EditorSceneManager.GetActiveScene().name}.bytes");

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

            UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath($"Assets/Res/Scene/Unit/{mapinfo.AssetPath}.prefab", typeof (GameObject));
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

    static double FormatDecimal(float value)
    {
        //string formattedNumber = value.ToString("F2");
        //return formattedNumber;
        double roundedValue = Math.Round(value, 2);
        return roundedValue;
    }

    static bool PrefabMoveToBundle(string prefabpath)
    {
        string projectPath = Application.dataPath.Substring(0, Application.dataPath.Length - "/Assets".Length);
        //Application.dataPath = H:/GitMengJing/Unity/Assets    projectPath = H:/GitMengJing/Unity
        prefabpath = projectPath + "/" + prefabpath;

        if (prefabpath.Contains("Res/Scene/Unit"))
        {
            return true;
        }

        //.meta
        string[] pathlist = prefabpath.Split('/');
        string destinationFile = Application.dataPath + "/Res/Scene/Unit/" + pathlist[pathlist.Length - 1];

        bool moveret = FileHelper.MoveFile(prefabpath, destinationFile);
        FileHelper.MoveFile(prefabpath + ".meta", destinationFile + ".meta");

        Debug.Log($"{prefabpath}   to    {destinationFile}");

        return moveret;
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
    
    [MenuItem("Tools/拷贝并修改寻路数据为.bytes[客户端]")]
    public static void RenamePathFilesInFolder1()
    {
        string dataPath = Application.dataPath; //"H:/GitMengJing/Unity/Assets"
        string sourceFolder = dataPath.Remove(dataPath.Length - 12, 12) + $"Config/Recast";
        if (string.IsNullOrEmpty(sourceFolder))
        {
            UnityEngine.Debug.Log("Folder selection canceled.");
            return;
        }
        
        string destinationFolder = Application.dataPath + "/Bundles/Recast";
        if (string.IsNullOrEmpty(destinationFolder))
        {
            UnityEngine.Debug.Log("Folder selection canceled.");
            return;
        }

        FileHelper.CleanDirectory(destinationFolder);

        FileHelper.CopyFolderContents(sourceFolder, destinationFolder);
        
        UnityEngine.Debug.Log("检测开始");

        string[] files = Directory.GetFiles(destinationFolder, "*.*", SearchOption.AllDirectories)
                .Where(file => file.EndsWith(string.Empty, System.StringComparison.OrdinalIgnoreCase)
                        && !file.EndsWith(".bytes")&& !file.EndsWith(".meta"))
                .ToArray();

        foreach (string file in files)
        {
            string newFilePath = file + ".bytes";
                    //Path.Combine(Path.GetDirectoryName(file) ?? string.Empty, Path.GetFileNameWithoutExtension(file));
            File.Move(file, newFilePath);
            UnityEngine.Debug.Log($"Renamed: {file} -> {newFilePath}");
        }

        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("检测结束");
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
    [MenuItem("Assets/Custom/Check Dependencies", false, 1)] //路径
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

    // [MenuItem("Asset / ), false, 1]
    [MenuItem("Assets/Custom/Check References Bundler", false, 1)] //路径
    public static void KCheckBundleReferences()
    {
        string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

        string[] assetPath = fontPath.Split('/');
        string fontAssetName = assetPath[assetPath.Length - 1];
        if (fontAssetName.Contains("."))
        {
            fontAssetName = fontAssetName.Split('.')[0];
        }

        UnityEngine.Debug.Log("KCheckFontReferences: Begin");

        List<string> fileList = new List<string>();
        fileList.AddRange(GetFile(sBundleCheckPath, fileList));

        string dataPath = Application.dataPath;
        int pathLength = dataPath.Length - 6;
        for (int i = 0; i < fileList.Count; i++)
        {
            string itemPath = fileList[i];
            if (itemPath.Contains(".meta"))
            {
                continue;
            }
            
            itemPath = itemPath.Remove(0, pathLength);
            string[] dependPathList = AssetDatabase.GetDependencies(new string[] { itemPath });
            foreach (string path in dependPathList)
            {
                // string[] assetPath = path.Split('/');
                //if (assetPath[assetPath.Length-1] == fongPath)

                if (!path.Equals(fontPath))
                {
                    continue;
                }
                
                if (itemPath.Contains(".unity"))
                {
                    Debug.Log($"以下场景有引用： {itemPath} ");
                    continue;
                }

               
                Debug.Log($"以下文件有引用： {itemPath} ");

                GameObject tmpObj = AssetDatabase.LoadAssetAtPath(itemPath, typeof (GameObject)) as GameObject;
                if (tmpObj == null)
                {
                    Debug.Log($"tmpObj == null： {itemPath} ");
                    continue;
                }
                //tmpObj = GameObject.Instantiate(tmpObj) as GameObject;
                Text[] tmpAr = tmpObj.GetComponentsInChildren<Text>();
                for (int t = 0; t < tmpAr.Length; t++)
                {
                    Text textTemp = tmpAr[t];
                    Font fontTemp = textTemp.font;
                    if (fontTemp == null)
                    {
                        continue;
                    }

                    string assetName = fontTemp.name;
                    if (fontAssetName == assetName)
                    {
                        UnityEngine.Debug.Log($" {textTemp.name}");
                    }
                }

                // TextMeshPro[] tmpProAr = tmpObj.GetComponentsInChildren<TextMeshPro>();
                // for (int t = 0; t < tmpProAr.Length; t++)
                // {
                //     TextMeshPro textTemp = tmpProAr[t];
                //     TMP_FontAsset fontTemp = textTemp.font;
                //     if (fontTemp == null)
                //     {
                //         continue;
                //     }
                //
                //     string assetName = fontTemp.name;
                //     if (fontAssetName == assetName)
                //     {
                //         UnityEngine.Debug.Log($" {textTemp.name}");
                //     }
                // }
            }
        }

        UnityEngine.Debug.Log("KCheckFontReferences: End");
    }

    [MenuItem("Assets/Custom/Check References Bundler UI", false, 1)] //路径
    public static void KCheckBundleUIReferences()
    {
        string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

        string[] assetPath = fontPath.Split('/');
        string fontAssetName = assetPath[assetPath.Length - 1];
        if (fontAssetName.Contains("."))
        {
            fontAssetName = fontAssetName.Split('.')[0];
        }

        UnityEngine.Debug.Log("KCheckFontReferences: Begin");

        List<string> fileList = new List<string>();
        fileList.AddRange(GetFile(sBundleUICheckPath, fileList));

        string dataPath = Application.dataPath;
        int pathLength = dataPath.Length - 6;
        for (int i = 0; i < fileList.Count; i++)
        {
            string itemPath = fileList[i];
            if (itemPath.Contains(".meta"))
            {
                continue;
            }

            itemPath = itemPath.Remove(0, pathLength);
            string[] dependPathList = AssetDatabase.GetDependencies(new string[] { itemPath });
            foreach (string path in dependPathList)
            {
                // string[] assetPath = path.Split('/');
                //if (assetPath[assetPath.Length-1] == fongPath)
                if (path == fontPath)
                {
                    UnityEngine.Debug.Log($"以下文件有引用： {itemPath} ");

                    //GameObject tmpObj = AssetDatabase.LoadAssetAtPath(itemPath, typeof(GameObject)) as GameObject;
                    ////tmpObj = GameObject.Instantiate(tmpObj) as GameObject;
                    //Text[] tmpAr = tmpObj.GetComponentsInChildren<Text>();
                    //for (int t = 0; t < tmpAr.Length; t++)
                    //{
                    //    Text textTemp = tmpAr[t];
                    //    Font fontTemp = textTemp.font;
                    //    if (fontTemp == null)
                    //    {
                    //        continue;
                    //    }
                    //    string assetName = fontTemp.name;
                    //    if (fontAssetName == assetName)
                    //    {
                    //        UnityEngine.Debug.Log($" {textTemp.name}");
                    //    }
                    //}

                    //TextMeshPro[] tmpProAr = tmpObj.GetComponentsInChildren<TextMeshPro>();
                    //for (int t = 0; t < tmpProAr.Length; t++)
                    //{
                    //    TextMeshPro textTemp = tmpProAr[t];
                    //    TMP_FontAsset fontTemp = textTemp.font;
                    //    if (fontTemp == null)
                    //    {
                    //        continue;
                    //    }
                    //    string assetName = fontTemp.name;
                    //    if (fontAssetName == assetName)
                    //    {
                    //        UnityEngine.Debug.Log($" {textTemp.name}");
                    //    }
                    //}
                }
            }
        }

        UnityEngine.Debug.Log("KCheckFontReferences: End");
    }
    
    /// <summary>
    /// 获取路径下所有文件以及子文件夹中文件
    /// </summary>
    /// <param name="path">全路径根目录</param>
    /// <param name="FileList">存放所有文件的全路径</param>
    /// <returns></returns>
    public static List<string> GetFile(string path, List<string> FileList)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] fil = dir.GetFiles();
        DirectoryInfo[] dii = dir.GetDirectories();
        foreach (FileInfo f in fil)
        {
            //int size = Convert.ToInt32(f.Length);
            long size = f.Length;
            FileList.Add(f.FullName);//添加文件路径到列表中
        }
        //获取子文件夹内的文件列表，递归遍历
        foreach (DirectoryInfo d in dii)
        {
            GetFile(d.FullName, FileList);
        }
        return FileList;
    }

    // [MenuItem("Asset / ), false, 1]
    [MenuItem("Assets/Custom/Check References Scene", false, 1)] //路径
    public static void KCheckSceneReferences()
    {
        string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

        string[] assetPath = fontPath.Split('/');
        string fontAssetName = assetPath[assetPath.Length - 1];
        if (fontAssetName.Contains("."))
        {
            fontAssetName = fontAssetName.Split('.')[0];
        }

        UnityEngine.Debug.Log("KCheckFontReferences: Begin");

        List<string> fileList = new List<string>();
        fileList.AddRange(GetFile(sSceneCheckPath, fileList));

        string dataPath = Application.dataPath;
        int pathLength = dataPath.Length - 6;
        for (int i = 0; i < fileList.Count; i++)
        {
            string itemPath = fileList[i];
            if (itemPath.Contains(".meta"))
            {
                continue;
            }

            itemPath = itemPath.Remove(0, pathLength);
            string[] dependPathList = AssetDatabase.GetDependencies(new string[] { itemPath });
            foreach (string path in dependPathList)
            {
                if (path == fontPath)
                {
                    UnityEngine.Debug.Log($"以下文件有引用： {itemPath} ");
                }
            }
        }

        UnityEngine.Debug.Log("KCheckFontReferences: End");
    }
}