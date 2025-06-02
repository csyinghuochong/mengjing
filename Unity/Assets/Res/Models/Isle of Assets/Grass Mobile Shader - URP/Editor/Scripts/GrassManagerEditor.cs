using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
namespace GrassMobileShader
{
    [CustomEditor(typeof(GrassManager))]
    public class GrassManagerEditor : Editor
    {
        private SerializedProperty count;
        private SerializedProperty size;
        private SerializedProperty drawDistance;
        private SerializedProperty sizeHorizontal;
        private SerializedProperty autoSizeVertical;
        private SerializedProperty sizeVertical;
        private SerializedProperty cellSize;
        private SerializedProperty targetCamera;
        private SerializedProperty cameraViewLeftOffset;
        private SerializedProperty cameraViewRightOffset;
        private SerializedProperty cameraViewBottomOffset;
        private SerializedProperty cameraViewTopOffset;
        private SerializedProperty material;
        private SerializedProperty cullingComputeShader;
        private SerializedProperty meshType;
        private SerializedProperty bottomWidthTriangle;
        private SerializedProperty topWidthQuadrilateral;
        private SerializedProperty bottomWidthQuadrilateral;
        private SerializedProperty grassMesh;
        private SerializedProperty heightMapType;
        private SerializedProperty terrainData;
        private SerializedProperty heightMap;
        private SerializedProperty heightMapTiling;
        private SerializedProperty heightMapOffset;
        private SerializedProperty height;
        private SerializedProperty heightOffset;
        private SerializedProperty mask;
        private SerializedProperty maskTiling;
        private SerializedProperty maskOffset;
        private SerializedProperty invertTexture;
        private SerializedProperty maskCutOff;
        private SerializedProperty useSeed;
        private SerializedProperty seed;
        private SerializedProperty cutbackMemoryOffset;
        private SerializedProperty useDefaultEditorColors;
        private SerializedProperty colorWireCube;
        private SerializedProperty showOnlyInPlayingMode;
        private SerializedProperty autoUpdateOnValidateInEditor;

        /// <summary>
        /// Implementation of the interface in the editor
        /// </summary>
        public override void OnInspectorGUI()
        {
            GrassManager grassManager = (GrassManager)target;
            EditorGUILayout.PropertyField(count, new GUIContent("Count"));
            EditorGUILayout.PropertyField(size, new GUIContent("Size"));
            EditorGUILayout.PropertyField(drawDistance, new GUIContent("Draw Distance"));
            EditorGUILayout.PropertyField(sizeHorizontal, new GUIContent("Size Horizontal"));
            EditorGUILayout.PropertyField(autoSizeVertical, new GUIContent("Auto Size Vertical"));
            if (!grassManager.autoSizeVertical)
            {
                EditorGUILayout.PropertyField(sizeVertical, new GUIContent("Size Vertical"));
            }
            EditorGUILayout.PropertyField(cellSize, new GUIContent("Cell Size"));
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(targetCamera, new GUIContent("Target Camera"));
            EditorGUILayout.PropertyField(cameraViewLeftOffset, new GUIContent("Camera View Left Offset"));
            EditorGUILayout.PropertyField(cameraViewRightOffset, new GUIContent("Camera View Right Offset"));
            EditorGUILayout.PropertyField(cameraViewBottomOffset, new GUIContent("Camera View Bottom Offset"));
            EditorGUILayout.PropertyField(cameraViewTopOffset, new GUIContent("Camera View Top Offset"));
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(material, new GUIContent("Material"));
            EditorGUILayout.PropertyField(cullingComputeShader, new GUIContent("Culling Compute Shader"));
            EditorGUILayout.PropertyField(meshType, new GUIContent("Mesh Type"));
            if (grassManager.meshType == GrassManager.MeshTypeEnum.Triangle)
            {
                EditorGUILayout.PropertyField(bottomWidthTriangle, new GUIContent("Bottom Width"));
            }
            else if (grassManager.meshType == GrassManager.MeshTypeEnum.Quadrilateral)
            {
                EditorGUILayout.PropertyField(topWidthQuadrilateral, new GUIContent("Top Width"));
                EditorGUILayout.PropertyField(bottomWidthQuadrilateral, new GUIContent("Bottom Width"));
            }
            else if (grassManager.meshType == GrassManager.MeshTypeEnum.Mesh)
            {
                EditorGUILayout.PropertyField(grassMesh, new GUIContent("Grass Mesh"));
            }
            EditorGUILayout.PropertyField(heightMapType, new GUIContent("Height Map Type"));
            if (grassManager.heightMapType == GrassManager.HeightMapTypeEnum.Terrain)
            {
                EditorGUILayout.PropertyField(terrainData, new GUIContent("Terrain Data"));
            }
            else if (grassManager.heightMapType == GrassManager.HeightMapTypeEnum.Texture)
            {
                EditorGUILayout.PropertyField(heightMap, new GUIContent("Height Map"));
            }
            if (grassManager.heightMapType != GrassManager.HeightMapTypeEnum.None && (grassManager.terrainData != null || grassManager.heightMap != null))
            {
                EditorGUILayout.PropertyField(heightMapTiling, new GUIContent("Height Map Tiling"));
                EditorGUILayout.PropertyField(heightMapOffset, new GUIContent("Height Map Offset"));
                EditorGUILayout.PropertyField(height, new GUIContent("Height"));
            }
            EditorGUILayout.PropertyField(heightOffset, new GUIContent("Height Offset"));
            EditorGUILayout.PropertyField(mask, new GUIContent("Mask"));
            if (grassManager.mask != null)
            {
                EditorGUILayout.PropertyField(maskTiling, new GUIContent("Mask Tiling"));
                EditorGUILayout.PropertyField(maskOffset, new GUIContent("Mask Offset"));
                EditorGUILayout.PropertyField(invertTexture, new GUIContent("Invert Texture"));
                EditorGUILayout.PropertyField(maskCutOff, new GUIContent("Mask Cut Off"));
            }
            EditorGUILayout.PropertyField(useSeed, new GUIContent("Use Seed"));
            if (grassManager.useSeed)
            {
                EditorGUILayout.PropertyField(seed, new GUIContent("Seed"));
            }
            EditorGUILayout.PropertyField(cutbackMemoryOffset, new GUIContent("Cutback Memory Offset"));
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Editor", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(useDefaultEditorColors, new GUIContent("Use Default Editor Colors"));
            if (!grassManager.useDefaultEditorColors)
            {
                EditorGUILayout.PropertyField(colorWireCube, new GUIContent("Color Wire Cube"));
            }
            EditorGUILayout.Space();
            EditorGUI.BeginDisabledGroup(Application.isPlaying);
            EditorGUILayout.PropertyField(showOnlyInPlayingMode, new GUIContent("Show Only In Playing Mode"));
            EditorGUI.EndDisabledGroup();
            if (Application.isPlaying || !grassManager.showOnlyInPlayingMode)
            {
                EditorGUILayout.PropertyField(autoUpdateOnValidateInEditor, new GUIContent("Auto Update On Validate In Editor"));
                EditorGUILayout.Space();
                if (!grassManager.autoUpdateOnValidateInEditor && GUILayout.Button("Update Grass", GUILayout.Height(25f)))
                {
                    grassManager.UpdateGrassPoses();
                    grassManager.UpdateGrassMesh();
                }
            }
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Fetch the object from the GameObject script to display in the inspector
        /// </summary>
        private void OnEnable()
        {
            count = serializedObject.FindProperty("count");
            size = serializedObject.FindProperty("size");
            drawDistance = serializedObject.FindProperty("drawDistance");
            sizeHorizontal = serializedObject.FindProperty("sizeHorizontal");
            autoSizeVertical = serializedObject.FindProperty("autoSizeVertical");
            sizeVertical = serializedObject.FindProperty("sizeVertical");
            cellSize = serializedObject.FindProperty("cellSize");
            targetCamera = serializedObject.FindProperty("targetCamera");
            cameraViewLeftOffset = serializedObject.FindProperty("cameraViewLeftOffset");
            cameraViewRightOffset = serializedObject.FindProperty("cameraViewRightOffset");
            cameraViewBottomOffset = serializedObject.FindProperty("cameraViewBottomOffset");
            cameraViewTopOffset = serializedObject.FindProperty("cameraViewTopOffset");
            material = serializedObject.FindProperty("material");
            cullingComputeShader = serializedObject.FindProperty("cullingComputeShader");
            meshType = serializedObject.FindProperty("meshType");
            bottomWidthTriangle = serializedObject.FindProperty("bottomWidthTriangle");
            topWidthQuadrilateral = serializedObject.FindProperty("topWidthQuadrilateral");
            bottomWidthQuadrilateral = serializedObject.FindProperty("bottomWidthQuadrilateral");
            grassMesh = serializedObject.FindProperty("grassMesh");
            heightMapType = serializedObject.FindProperty("heightMapType");
            terrainData = serializedObject.FindProperty("terrainData");
            heightMap = serializedObject.FindProperty("heightMap");
            heightMapTiling = serializedObject.FindProperty("heightMapTiling");
            heightMapOffset = serializedObject.FindProperty("heightMapOffset");
            height = serializedObject.FindProperty("height");
            heightOffset = serializedObject.FindProperty("heightOffset");
            mask = serializedObject.FindProperty("mask");
            maskTiling = serializedObject.FindProperty("maskTiling");
            maskOffset = serializedObject.FindProperty("maskOffset");
            invertTexture = serializedObject.FindProperty("invertTexture");
            maskCutOff = serializedObject.FindProperty("maskCutOff");
            useSeed = serializedObject.FindProperty("useSeed");
            seed = serializedObject.FindProperty("seed");
            cutbackMemoryOffset = serializedObject.FindProperty("cutbackMemoryOffset");
            useDefaultEditorColors = serializedObject.FindProperty("useDefaultEditorColors");
            colorWireCube = serializedObject.FindProperty("colorWireCube");
            showOnlyInPlayingMode = serializedObject.FindProperty("showOnlyInPlayingMode");
            autoUpdateOnValidateInEditor = serializedObject.FindProperty("autoUpdateOnValidateInEditor");
        }
    }
}
#endif
