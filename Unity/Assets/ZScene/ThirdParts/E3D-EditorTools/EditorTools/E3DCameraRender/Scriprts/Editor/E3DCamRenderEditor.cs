//******************************************************
//
//	文件名 (File Name) 	: 		MyToolsEditor
//	
//	脚本创建者(Author) 	:		E3D

//	创建时间 (CreatTime):		2019/12/11/15/6/30
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using E3DCommonTools;

[CustomEditor(typeof(E3DCamRender))]
public class E3DCamRenderEditor : Editor
{
    private E3DCamRender _target;
    string[] m_toolBarStrs = { "Normal Camera", "Capture Image" };
    const string m_imageSaveRootFolder = "Assets/";
    private int GetCurrentWidth
    {
        get
        {
            return _target.outGamveSize == MyImageSize.Custom ? _target.customWidth : (int)_target.outGamveSize;
        }
    }
    private void OnEnable()
    {
        _target = (E3DCamRender)target;
    }

    private void OnDisable()
    {

    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginVertical(GUI.skin.box);

        //标签栏
        EditorGUILayout.BeginHorizontal();
        _target.toolIndex = GUILayout.Toolbar(_target.toolIndex, m_toolBarStrs);
        EditorGUILayout.EndHorizontal();

        //操作
        ToolType(_target.toolIndex);

        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(_target);
    }

    private void ToolType(int indexType)
    {
        if (indexType > 0)
        {
            ScreenShotImage();
        }
        else
        {
            CreatOrthographicCamera();
        }
    }

    private E3DCameraRenderCtr cameraRenderCtr;
    /// <summary>
    /// 依据平面创建正交相机
    /// </summary>
    private void CreatOrthographicCamera()
    {

        _target.cameraHeight = EditorGUILayout.IntField("Camera Height:", _target.cameraHeight);
        if (GUILayout.Button("Create"))
        {

            var parent = _target.gameObject;
            if (parent.transform.childCount > 0)
            {
                return;
            }
            var camobj = new GameObject().AddComponent<Camera>();
            _target.m_mainCamera = camobj;

            camobj.gameObject.name = "MainCamera";
            cameraRenderCtr = camobj.gameObject.AddComponent<E3DCameraRenderCtr>();
            camobj.gameObject.transform.SetParent(parent.transform);

            camobj.gameObject.transform.localPosition = new Vector3(0, _target.cameraHeight + camobj.nearClipPlane, 0);
            camobj.transform.localEulerAngles = new Vector3(90, 0, 0);
            camobj.transform.localScale = Vector3.one;

            camobj.gameObject.tag = "MainCamera";
            camobj.orthographic = true;

            camobj.farClipPlane = _target.cameraHeight + 6;

            int width = Mathf.FloorToInt(parent.transform.localScale.x);
            camobj.orthographicSize = 5 * width;
        }
    }

    /// <summary>
    /// 截取Game视图
    /// </summary>
    private void ScreenShotImage()
    {
        _target.outScreenType = (MyScreenShotImageType)EditorGUILayout.EnumPopup("Type:", _target.outScreenType);

        // if (_target.outScreenType == MyScreenShotImageType.Depth)
        // {
        //     EditorGUI.indentLevel += 1;
        //     _target.depthShader = EditorGUILayout.ObjectField("深度shader：", _target.depthShader, typeof(Shader), true) as Shader;
        //     EditorGUI.indentLevel -= 1;
        // }
        // else if (_target.outScreenType == MyScreenShotImageType.DepthNormal)
        // {
        //     EditorGUI.indentLevel += 1;
        //     _target.depthNormalShader = EditorGUILayout.ObjectField("深度法线shader", _target.depthNormalShader, typeof(Shader), true) as Shader;
        //     EditorGUI.indentLevel -= 1;
        // }

        _target.outImagType = (MyImageType_2018)EditorGUILayout.EnumPopup("Format:", _target.outImagType);
        _target.outGamveSize = (MyImageSize)EditorGUILayout.EnumPopup("Size:", _target.outGamveSize);

        if (_target.outGamveSize == MyImageSize.Custom)
        {
            EditorGUI.indentLevel += 1;
            EditorGUILayout.BeginVertical(GUI.skin.box);

            _target.customWidth = EditorGUILayout.IntField("Custom Size:", _target.customWidth);
            EditorGUI.indentLevel += 1;
            EditorGUILayout.LabelField("Tip：Weight is Equal to Height！");
            EditorGUI.indentLevel -= 1;

            EditorGUILayout.EndVertical();
            EditorGUI.indentLevel -= 1;
        }

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Set Resolution"))
        {
            if (_target.outGamveSize == MyImageSize.Custom)
                SetGameViewSize(_target.outGamveSize, _target.customWidth);
            else
                SetGameViewSize(_target.outGamveSize);
        }

        if (GUILayout.Button("Export Image"))
        {
            EditorApplication.isPlaying = true;
            string path = m_imageSaveRootFolder + _target.outScreenType.ToString() + "_" + GetCurrentWidth + "_" + _target.outImagType.ToString() + "." + _target.outImagType.ToString().ToLower();

            _target.CustomScreenShotTex(path, _target.outImagType);
        }
        EditorGUILayout.EndHorizontal();
    }

    private bool m_ModifiedResolution;
    private void SetGameViewSize(MyImageSize myImageSize, int customSize = 0)
    {
        int imageSize = 0;
        if (customSize == 0)
        {
            imageSize = (int)myImageSize;
        }
        else
        {
            imageSize = customSize;
        }

        var size = E3DGameViewSize.SetCustomSizwWEH(imageSize);
        if (size != null)
        {
            E3DGameViewSize.modifiedResolutionCount++;
            m_ModifiedResolution = true;
            E3DGameViewSize.SelectSize(size);
        }
    }
}


