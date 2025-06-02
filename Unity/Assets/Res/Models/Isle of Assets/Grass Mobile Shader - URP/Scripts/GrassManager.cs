using UnityEngine;
using System.Collections.Generic;

namespace GrassMobileShader
{
    [HelpURL("https://assetstore.unity.com/packages/slug/265141"), ExecuteAlways, DisallowMultipleComponent]
    public class GrassManager : MonoBehaviour
    {
        public static GrassManager Instance { get; private set; }

        public const int COUNT_MIN_VALUE = 100, COUNT_MAX_VALUE = 2_000_000;
        public const float SIZE_X_MIN_VALUE = 0.01f, SIZE_X_MAX_VALUE = float.MaxValue, SIZE_Y_MIN_VALUE = 0.01f, SIZE_Y_MAX_VALUE = float.MaxValue;
        public const float CELL_SIZE_X_MIN_VALUE = 1f, CELL_SIZE_X_MAX_VALUE = float.MaxValue, CELL_SIZE_Y_MIN_VALUE = 1f, CELL_SIZE_Y_MAX_VALUE = float.MaxValue;
        public const float DRAW_DISTANCE_MIN_VALUE = 0f, DRAW_DISTANCE_MAX_VALUE = 500f;
        public const float BOTTOM_WIDTH_TRIANGLE_MIN_VALUE = 0f, BOTTOM_WIDTH_TRIANGLE_MAX_VALUE = 1f;
        public const float TOP_WIDTH_QUADRILATERAL_MIN_VALUE = 0f, TOP_WIDTH_QUADRILATERAL_MAX_VALUE = 1f;
        public const float BOTTOM_WIDTH_QUADRILATERAL_MIN_VALUE = 0f, BOTTOM_WIDTH_QUADRILATERAL_MAX_VALUE = 1f;
        public const float MASK_CUT_OFF_MIN_VALUE = 0f, MASK_CUT_OFF_MAX_VALUE = 1f;

        public enum MeshTypeEnum { Triangle, Quadrilateral, Mesh }
        public enum HeightMapTypeEnum { None, Terrain, Texture }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = Mathf.Clamp(value, COUNT_MIN_VALUE, COUNT_MAX_VALUE);
                UpdateGrassPoses();
            }
        }

        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                UpdateGrassPoses();
            }
        }

        public float DrawDistance
        {
            get
            {
                return drawDistance;
            }
            set
            {
                drawDistance = Mathf.Clamp(value, DRAW_DISTANCE_MIN_VALUE, DRAW_DISTANCE_MAX_VALUE);
                saveDrawDistance = drawDistance;
            }
        }

        public Vector2 SizeHorizontal
        {
            get
            {
                return sizeHorizontal;
            }
            set
            {
                sizeHorizontal = new Vector2(Mathf.Clamp(value.x, SIZE_X_MIN_VALUE, SIZE_X_MAX_VALUE), Mathf.Clamp(value.y, SIZE_Y_MIN_VALUE, SIZE_Y_MAX_VALUE));
                UpdateGrassPoses();
            }
        }

        public bool AutoSizeVertical
        {
            get
            {
                return autoSizeVertical;
            }
            set
            {
                autoSizeVertical = value;
                UpdateGrassPoses(false);
            }
        }

        public Vector2 SizeVertical
        {
            get
            {
                return sizeVertical;
            }
            set
            {
                sizeVertical = new Vector2(Mathf.Clamp(value.x, float.MinValue, sizeVertical.y), Mathf.Clamp(value.y, sizeVertical.x, float.MaxValue));
                UpdateGrassPoses();
            }
        }

        public Vector2 CellSize
        {
            get
            {
                return cellSize;
            }
            set
            {
                cellSize = new Vector2(Mathf.Clamp(value.x, CELL_SIZE_X_MIN_VALUE, CELL_SIZE_X_MAX_VALUE), Mathf.Clamp(value.y, CELL_SIZE_Y_MIN_VALUE, CELL_SIZE_Y_MAX_VALUE));
                UpdateGrassPoses();
            }
        }

        public Camera TargetCamera
        {
            get
            {
                return targetCamera;
            }
            set
            {
                targetCamera = value;
            }
        }

        public float CameraViewLeftOffset
        {
            get
            {
                return cameraViewLeftOffset;
            }
            set
            {
                cameraViewLeftOffset = value;
            }
        }

        public float CameraViewRightOffset
        {
            get
            {
                return cameraViewRightOffset;
            }
            set
            {
                cameraViewRightOffset = value;
            }
        }

        public float CameraViewBottomOffset
        {
            get
            {
                return cameraViewBottomOffset;
            }
            set
            {
                cameraViewBottomOffset = value;
            }
        }

        public float CameraViewTopOffset
        {
            get
            {
                return cameraViewTopOffset;
            }
            set
            {
                cameraViewTopOffset = value;
            }
        }

        public Material Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
                visiblePosIDBuffer = null;
            }
        }

        public MeshTypeEnum MeshType
        {
            get
            {
                return meshType;
            }
            set
            {
                meshType = value;
                UpdateGrassMesh();
            }
        }

        public float BottomWidthTriangle
        {
            get
            {
                return bottomWidthTriangle;
            }
            set
            {
                bottomWidthTriangle = Mathf.Clamp(value, BOTTOM_WIDTH_TRIANGLE_MIN_VALUE, BOTTOM_WIDTH_TRIANGLE_MAX_VALUE);
                UpdateGrassMesh();
            }
        }

        public float TopWidthQuadrilateral
        {
            get
            {
                return topWidthQuadrilateral;
            }
            set
            {
                topWidthQuadrilateral = Mathf.Clamp(value, TOP_WIDTH_QUADRILATERAL_MIN_VALUE, TOP_WIDTH_QUADRILATERAL_MAX_VALUE);
                UpdateGrassMesh();
            }
        }

        public float BottomWidthQuadrilateral
        {
            get
            {
                return bottomWidthQuadrilateral;
            }
            set
            {
                bottomWidthQuadrilateral = Mathf.Clamp(value, BOTTOM_WIDTH_QUADRILATERAL_MIN_VALUE, BOTTOM_WIDTH_QUADRILATERAL_MAX_VALUE);
                UpdateGrassMesh();
            }
        }

        public Mesh GrassMesh
        {
            get
            {
                return grassMesh;
            }
            set
            {
                grassMesh = value;
                UpdateGrassMesh();
            }
        }

        public HeightMapTypeEnum HeightMapType
        {
            get
            {
                return heightMapType;
            }
            set
            {
                heightMapType = value;
                UpdateGrassPoses(false);
            }
        }

        public TerrainData TerrainData
        {
            get
            {
                return terrainData;
            }
            set
            {
                terrainData = value;
                UpdateGrassPoses(false);
            }
        }

        public Texture2D HeightMap
        {
            get
            {
                return heightMap;
            }
            set
            {
                heightMap = value;
                UpdateGrassPoses(false);
            }
        }

        public Vector2 HeightMapTiling
        {
            get
            {
                return heightMapTiling;
            }
            set
            {
                heightMapTiling = value;
                UpdateGrassPoses(false);
            }
        }

        public Vector2Int HeightMapOffset
        {
            get
            {
                return heightMapOffset;
            }
            set
            {
                heightMapOffset = value;
                UpdateGrassPoses(false);
            }
        }

        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                UpdateGrassPoses(false);
            }
        }

        public float HeightOffset
        {
            get
            {
                return heightOffset;
            }
            set
            {
                heightOffset = value;
                UpdateGrassPoses(false);
            }
        }

        public Texture2D Mask
        {
            get
            {
                return mask;
            }
            set
            {
                mask = value;
                UpdateGrassPoses(false);
            }
        }

        public Vector2 MaskTiling
        {
            get
            {
                return maskTiling;
            }
            set
            {
                maskTiling = value;
                UpdateGrassPoses(false);
            }
        }

        public Vector2Int MaskOffset
        {
            get
            {
                return maskOffset;
            }
            set
            {
                maskOffset = value;
                UpdateGrassPoses(false);
            }
        }

        public bool InvertTexture
        {
            get
            {
                return invertTexture;
            }
            set
            {
                invertTexture = value;
                UpdateGrassPoses(false);
            }
        }

        public float MaskCutOff
        {
            get
            {
                return maskCutOff;
            }
            set
            {
                maskCutOff = value;
                UpdateGrassPoses(false);
            }
        }

        public bool UseSeed
        {
            get
            {
                return useSeed;
            }
            set
            {
                useSeed = value;
                UpdateGrassPoses(false);
            }
        }

        public int Seed
        {
            get
            {
                return seed;
            }
            set
            {
                seed = value;
                UpdateGrassPoses(false);
            }
        }

        [Tooltip("The number of blades of grass displayed.")]
        [HideInInspector, Range(COUNT_MIN_VALUE, COUNT_MAX_VALUE)]
        public int count = 750_000;

        [Tooltip("The size of the grass.")]
        [HideInInspector]
        public Vector2 size = Vector3.one;

        [Tooltip("The distance after which the camera stops displaying grass.")]
        [HideInInspector, Range(DRAW_DISTANCE_MIN_VALUE, DRAW_DISTANCE_MAX_VALUE)]
        public float drawDistance = 300f;

        [Tooltip("The size of the field on which the grass will be drawn.")]
        [HideInInspector]
        public Vector2 sizeHorizontal = new Vector2(100f, 100f);

        [Tooltip("Automatically determine the vertical boundaries of the grass drawing. It is recommended to enable.")]
        [HideInInspector]
        public bool autoSizeVertical = true;

        [Tooltip("Vertical boundaries of the grass drawing.")]
        [HideInInspector]
        public Vector2 sizeVertical = new Vector2(0f, 1f);

        [Tooltip("The size of one cell with grass. To increase performance, increase this parameter.")]
        [HideInInspector]
        public Vector2 cellSize = new Vector2(20f, 20f);

        [Tooltip("The camera whose field of view will affect the rendering of grass.")]
        [HideInInspector]
        public Camera targetCamera;

        [Tooltip("Indicate how much you need to increase the field of view of the camera. Change this parameter if the grass begins to disappear at the edges of the camera's field of view.")]
        [HideInInspector]
        public float cameraViewLeftOffset;

        [Tooltip("Indicate how much you need to increase the field of view of the camera. Change this parameter if the grass begins to disappear at the edges of the camera's field of view.")]
        [HideInInspector]
        public float cameraViewRightOffset;

        [Tooltip("Indicate how much you need to increase the field of view of the camera. Change this parameter if the grass begins to disappear at the edges of the camera's field of view.")]
        [HideInInspector]
        public float cameraViewBottomOffset;

        [Tooltip("Indicate how much you need to increase the field of view of the camera. Change this parameter if the grass begins to disappear at the edges of the camera's field of view.")]
        [HideInInspector]
        public float cameraViewTopOffset;

        [Tooltip("Grass material.")]
        [HideInInspector]
        public Material material;

        [Tooltip("Compute shaders are programs that run on the GPU outside of the normal rendering pipeline.")]
        [HideInInspector]
        public ComputeShader cullingComputeShader;

        [Tooltip("Choose which mesh to display the blades of grass.")]
        [HideInInspector]
        public MeshTypeEnum meshType;

        [Tooltip("The width of the blade of grass at the bottom.")]
        [HideInInspector, Range(BOTTOM_WIDTH_TRIANGLE_MIN_VALUE, BOTTOM_WIDTH_TRIANGLE_MAX_VALUE)]
        public float bottomWidthTriangle = 0.25f;

        [Tooltip("The width of the blade of grass at the top.")]
        [HideInInspector, Range(TOP_WIDTH_QUADRILATERAL_MIN_VALUE, TOP_WIDTH_QUADRILATERAL_MAX_VALUE)]
        public float topWidthQuadrilateral = 0.15f;

        [Tooltip("The width of the blade of grass at the bottom.")]
        [HideInInspector, Range(BOTTOM_WIDTH_QUADRILATERAL_MIN_VALUE, BOTTOM_WIDTH_QUADRILATERAL_MAX_VALUE)]
        public float bottomWidthQuadrilateral = 0.25f;

        [Tooltip("Here you need to specify your own mesh, which will display the blades of grass.")]
        [HideInInspector]
        public Mesh grassMesh;

        [Tooltip("Choose the principle by which the position of the blade of grass on an uneven surface will be determined.")]
        [HideInInspector]
        public HeightMapTypeEnum heightMapType;

        [Tooltip("Insert here the terrain data from which to use the height map.")]
        [HideInInspector]
        public TerrainData terrainData;

        [Tooltip("Insert the texture of the height map here.")]
        [HideInInspector]
        public Texture2D heightMap;

        [Tooltip("Height map tiling.")]
        [HideInInspector]
        public Vector2 heightMapTiling = new Vector2(1f, 1f);

        [Tooltip("Height map offset.")]
        [HideInInspector]
        public Vector2Int heightMapOffset;

        [Tooltip("Height of the height map.")]
        [HideInInspector]
        public float height = 600f;

        [Tooltip("Height offset of the height map.")]
        [HideInInspector]
        public float heightOffset;

        [Tooltip("Grass mask.")]
        [HideInInspector]
        public Texture2D mask;

        [Tooltip("Grass mask tiling.")]
        [HideInInspector]
        public Vector2 maskTiling = new Vector2(1f, 1f);

        [Tooltip("Grass mask offset.")]
        [HideInInspector]
        public Vector2Int maskOffset;

        [Tooltip("Invert the mask texture.")]
        [HideInInspector]
        public bool invertTexture;

        [Tooltip("If the height map contains semitones that smoothly merge into each other, then use this parameter to set the degree of absorption of white color.")]
        [HideInInspector, Range(MASK_CUT_OFF_MIN_VALUE, MASK_CUT_OFF_MAX_VALUE)]
        public float maskCutOff = 0.5f;

        [Tooltip("Enable this option if you don't want to use seed to generate the arrangement of blades of grass.")]
        [HideInInspector]
        public bool useSeed;

        [Tooltip("Seed to generate the arrangement of blades of grass.")]
        [HideInInspector]
        public int seed;

        [Tooltip("If there is a bug when an extra blade of grass forms in the middle of the scene, then increase this parameter until the main grass begins to disappear.")]
        [HideInInspector]
        public int cutbackMemoryOffset = 100;

#if UNITY_EDITOR
        [Tooltip("Enable this option if you don't want to see grass while working in the editor. This will not affect the shader operation during the game in any way.")]
        [HideInInspector]
        public bool showOnlyInPlayingMode;

        [Tooltip("Disable this option if you want to update the grass shader yourself when any parameters change. If this option is enabled, all changes will be applied automatically. This will not affect the shader operation during the game in any way.")]
        [HideInInspector]
        public bool autoUpdateOnValidateInEditor = true;

        [Tooltip("Use the default editor colors.")]
        [HideInInspector]
        public bool useDefaultEditorColors;

        [Tooltip("The color of the wire cube in the Scene window.")]
        [HideInInspector]
        public Color colorWireCube = new Color(0.3f, 0.3f, 0.9f, 1f);
#endif

        private List<Vector3>[] cellPoses;
        private Bounds[] cellPosesBounds;
        private Vector3[] grassPoses;
        private ComputeBuffer grassPosBuffer, visiblePosIDBuffer, argsBuffer;
        private ComputeShader cullingComputeShaderClone;
        private Mesh mesh;
        private Bounds renderBound = new Bounds();
        private Vector3 savePos;
        private float saveDrawDistance;

        /// <summary>
        /// Updating the position of all blades of grass
        /// </summary>
        public void UpdateGrassPoses(bool updateCells = true)
        {
            saveDrawDistance = drawDistance;
            grassPoses = new Vector3[count];
            if (useSeed)
            {
                Random.InitState(seed);
            }
            float[,] heightMapPixels = new float[,] { };
            if (terrainData != null && heightMapType == HeightMapTypeEnum.Terrain)
            {
                heightMapPixels = terrainData.GetHeights(heightMapOffset.x, heightMapOffset.y, terrainData.heightmapResolution, terrainData.heightmapResolution);
            }
            if (heightMap != null && heightMapType == HeightMapTypeEnum.Texture)
            {
                heightMapPixels = new float[heightMap.width, heightMap.height];
                for (int x = 0; x < heightMap.width; x++)
                {
                    for (int y = 0; y < heightMap.height; y++)
                    {
                        heightMapPixels[x, y] = heightMap.GetPixel(x + heightMapOffset.x, y + heightMapOffset.y).r;
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                float posX = Random.Range(-sizeHorizontal.x, sizeHorizontal.x) * 0.5f;
                float posZ = Random.Range(-sizeHorizontal.y, sizeHorizontal.y) * 0.5f;
                if (mask != null)
                {
                    int x = (int)((posZ + sizeHorizontal.y * 0.5f) / sizeHorizontal.y * mask.width * maskTiling.y) % mask.width + maskOffset.x;
                    int y = (int)((posX + sizeHorizontal.x * 0.5f) / sizeHorizontal.x * mask.height * maskTiling.x) % mask.height + maskOffset.y;
                    if (mask.GetPixel(x, y).g < maskCutOff != invertTexture)
                    {
                        i--;
                        continue;
                    }
                }
                float posY = heightOffset;
                if (heightMapPixels.Length > 0)
                {
                    int x = (int)((posZ + sizeHorizontal.y * 0.5f) / sizeHorizontal.y * heightMapPixels.GetLength(0) * heightMapTiling.y) % heightMapPixels.GetLength(0);
                    int y = (int)((posX + sizeHorizontal.x * 0.5f) / sizeHorizontal.x * heightMapPixels.GetLength(1) * heightMapTiling.x) % heightMapPixels.GetLength(1);
                    posY += heightMapPixels[x, y] * height;
                }
                grassPoses[i] = new Vector3(posX, posY, posZ) + transform.position;
            }
            if (updateCells)
            {
                float minX = transform.position.x - sizeHorizontal.x * 0.5f;
                float minZ = transform.position.z - sizeHorizontal.y * 0.5f;
                float maxX = minX + sizeHorizontal.x;
                float maxZ = minZ + sizeHorizontal.y;
                Vector2Int cellCount = new Vector2Int(Mathf.CeilToInt(sizeHorizontal.x / cellSize.x), Mathf.CeilToInt(sizeHorizontal.y / cellSize.y));
                cellPoses = new List<Vector3>[cellCount.x * cellCount.y];
                for (int i = 0; i < cellPoses.Length; i++)
                {
                    cellPoses[i] = new List<Vector3>();
                }
                for (int i = 0; i < grassPoses.Length; i++)
                {
                    int cellX = Mathf.Min(cellCount.x - 1, Mathf.FloorToInt(Mathf.InverseLerp(minX, maxX, grassPoses[i].x) * cellCount.x));
                    int cellY = Mathf.Min(cellCount.y - 1, Mathf.FloorToInt(Mathf.InverseLerp(minZ, maxZ, grassPoses[i].z) * cellCount.y));
                    cellPoses[cellX + cellY * cellCount.x].Add(grassPoses[i]);
                }
                cellPosesBounds = new Bounds[cellPoses.Length];
                if (autoSizeVertical)
                {
                    sizeVertical = new Vector2(float.MaxValue, float.MinValue);
                }
                for (int i = 0; i < cellPoses.Length; i++)
                {
                    float heightSum = 0f, minY = float.MaxValue, maxY = float.MinValue;
                    foreach (var position in cellPoses[i])
                    {
                        heightSum += position.y;
                        minY = Mathf.Min(minY, position.y);
                        maxY = Mathf.Max(maxY, position.y);
                    }
                    float centerX = Mathf.Lerp(minX, maxX, (i % cellCount.x + 0.5f) / cellCount.x);
                    float centerY = heightSum / cellPoses[i].Count;
                    float centerZ = Mathf.Lerp(minZ, maxZ, (i / cellCount.x + 0.5f) / cellCount.y);
                    Vector3 center = new Vector3(centerX, centerY, centerZ);
                    Vector3 size = new Vector3(Mathf.Abs(maxX - minX) / cellCount.x, maxY - minY, Mathf.Abs(maxZ - minZ) / cellCount.y);
                    cellPosesBounds[i] = new Bounds(center, size);
                    if (autoSizeVertical)
                    {
                        float sizeVerticalX = Mathf.Min(sizeVertical.x, cellPosesBounds[i].center.y - cellPosesBounds[i].size.y * 0.5f);
                        float sizeVerticalY = Mathf.Max(sizeVertical.y, cellPosesBounds[i].center.y + cellPosesBounds[i].size.y * 0.5f);
                        sizeVertical = new Vector2(sizeVerticalX, sizeVerticalY);
                    }
                }
                Vector3 min = new Vector3(minX, sizeVertical.x, minZ);
                Vector3 max = new Vector3(maxX, sizeVertical.y, maxZ);
                renderBound.SetMinMax(min, max);
                visiblePosIDBuffer = null;
            }
        }

        /// <summary>
        /// Updating the mesh of all blades of grass
        /// </summary>
        public void UpdateGrassMesh()
        {
            mesh = new Mesh();
            Vector3[] vertices;
            int[] triangles;
            switch (meshType)
            {
                case MeshTypeEnum.Triangle:
                    vertices = new[] { new Vector3(-bottomWidthTriangle * size.x, 0f),
                                       new Vector3(bottomWidthTriangle * size.x, 0f),
                                       new Vector3(0f, size.y) };
                    triangles = new[] { 2, 1, 0, };
                    break;
                case MeshTypeEnum.Quadrilateral:
                    vertices = new[] { new Vector3(-bottomWidthQuadrilateral * size.x, 0f),
                                       new Vector3(bottomWidthQuadrilateral * size.x, 0f),
                                       new Vector3(-topWidthQuadrilateral, size.y),
                                       new Vector3(topWidthQuadrilateral, size.y) };
                    triangles = new[] { 0, 2, 1, 2, 3, 1 };
                    break;
                default:
                    mesh = grassMesh;
                    if (mesh == null)
                        return;
                    vertices = mesh.vertices;
                    for (int i = 0; i < vertices.Length; i++)
                    {
                        vertices[i] = new Vector3(vertices[i].x * size.x, vertices[i].y * size.y, 0f);
                    }
                    triangles = mesh.triangles;
                    break;
            }
            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles, 0);
        }

#if UNITY_EDITOR
        /// <summary>
        /// Applying the parmeters changed from the editor
        /// </summary>
        private void OnValidate()
        {
            if (showOnlyInPlayingMode && !Application.isPlaying)
            {
                return;
            }
            sizeHorizontal = new Vector2(Mathf.Clamp(sizeHorizontal.x, SIZE_X_MIN_VALUE, SIZE_X_MAX_VALUE), Mathf.Clamp(sizeHorizontal.y, SIZE_Y_MIN_VALUE, SIZE_Y_MAX_VALUE));
            cellSize = new Vector2(Mathf.Clamp(cellSize.x, CELL_SIZE_X_MIN_VALUE, CELL_SIZE_X_MAX_VALUE), Mathf.Clamp(cellSize.y, CELL_SIZE_Y_MIN_VALUE, CELL_SIZE_Y_MAX_VALUE));
            if (autoUpdateOnValidateInEditor)
            {
                UpdateGrassPoses();
                UpdateGrassMesh();
            }
        }
#endif

        /// <summary>
        /// Setting this GrassManager as the default grass
        /// </summary>
        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            if (targetCamera == null)
            {
                targetCamera = Camera.main;
            }
            if (!Application.isPlaying || AsyncGrassManagersLoader.Instance == null)
            {
                return;
            }
            if (AsyncGrassManagersLoader.Instance.GrassManagers.Contains(gameObject))
            {
                return;
            }
            AsyncGrassManagersLoader.Instance.GrassManagers.Add(gameObject);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Saving the initial default values
        /// </summary>
        private void Start()
        {
            saveDrawDistance = drawDistance;
            savePos = transform.position;
            cullingComputeShaderClone = Instantiate(cullingComputeShader);
#if UNITY_EDITOR
            if (showOnlyInPlayingMode && !Application.isPlaying)
            {
                return;
            }
#endif
            UpdateGrassPoses();
            UpdateGrassMesh();
        }

        /// <summary>
        /// Updating the grass position when changing its Transform
        /// </summary>
        private void Update()
        {
#if UNITY_EDITOR
            if (showOnlyInPlayingMode && !Application.isPlaying || !autoUpdateOnValidateInEditor)
            {
                return;
            }
#endif
            if (savePos == transform.position)
            {
                return;
            }
            savePos = transform.position;
            UpdateGrassPoses();
        }

        /// <summary>
        /// Updating the grass at the end of each frame
        /// </summary>
        private void LateUpdate()
        {
#if UNITY_EDITOR
            if (showOnlyInPlayingMode && !Application.isPlaying)
            {
                return;
            }
            if (cellPoses == null)
            {
                UpdateGrassPoses();
                return;
            }
#endif
            if (visiblePosIDBuffer == null)
            {
                if (mesh == null)
                {
                    Debug.LogWarning("No Mesh found");
                    return;
                }
                grassPosBuffer?.Release();
                grassPosBuffer = new ComputeBuffer(grassPoses.Length, 12);
                grassPosBuffer.SetData(grassPoses);
                visiblePosIDBuffer?.Release();
                visiblePosIDBuffer = new ComputeBuffer(grassPoses.Length, 4, ComputeBufferType.Append);
                material.SetBuffer("_InstancesBuffer", grassPosBuffer);
                material.SetBuffer("_InstanceIDBuffer", visiblePosIDBuffer);
                argsBuffer?.Release();
                argsBuffer = new ComputeBuffer(1, 20, ComputeBufferType.IndirectArguments);
                argsBuffer.SetData(new uint[] { mesh.GetIndexCount(0), (uint)grassPoses.Length, mesh.GetIndexStart(0), mesh.GetBaseVertex(0), 0 });
                cullingComputeShaderClone.SetBuffer(0, "_InstancesBuffer", grassPosBuffer);
                cullingComputeShaderClone.SetBuffer(0, "_InstanceIDBuffer", visiblePosIDBuffer);
                cullingComputeShaderClone.SetFloat("_DrawDistance", saveDrawDistance);
                cullingComputeShaderClone.SetFloat("_CameraViewLeftOffset", cameraViewLeftOffset);
                cullingComputeShaderClone.SetFloat("_CameraViewRightOffset", cameraViewRightOffset);
                cullingComputeShaderClone.SetFloat("_CameraViewBottomOffset", cameraViewBottomOffset);
                cullingComputeShaderClone.SetFloat("_CameraViewTopOffset", cameraViewTopOffset);
            }
            visiblePosIDBuffer.SetCounterValue(0);
            cullingComputeShaderClone.SetMatrix("_VPMatrix", targetCamera.projectionMatrix * targetCamera.worldToCameraMatrix);
            for (int i = 0; i < cellPoses.Length; i++)
            {
                int memoryOffset = 0;
                for (int j = 0; j < i; j++)
                {
                    memoryOffset +=cellPoses[j].Count;
                }
                if (i == cellPoses.Length - 1)
                {
                    memoryOffset -= cutbackMemoryOffset;
                }
                cullingComputeShaderClone.SetInt("_IDOffset", memoryOffset);
                int threadGroupsX = Mathf.CeilToInt(cellPoses[i].Count / 64f);
                if (threadGroupsX > 0)
                {
                    cullingComputeShaderClone.Dispatch(0, threadGroupsX, 1, 1);
                }
            }
            ComputeBuffer.CopyCount(visiblePosIDBuffer, argsBuffer, 4);
            Graphics.DrawMeshInstancedIndirect(mesh, 0, material, renderBound, argsBuffer);
        }

#if UNITY_EDITOR
        /// <summary>
        /// Drawing hints on the size of the field with grass in the Scene window
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = colorWireCube;
            Gizmos.DrawWireCube(transform.position + Vector3.up * ((sizeVertical.x + sizeVertical.y) * 0.5f), new Vector3(sizeHorizontal.x, sizeVertical.y - sizeVertical.x, sizeHorizontal.y));
            for (int i = 0; i < cellPosesBounds.Length; i++)
            {
                Gizmos.DrawWireCube(cellPosesBounds[i].center, cellPosesBounds[i].size * 0.995f);
            }
        }
#endif

        /// <summary>
        /// Freeing memory from grass before disabling
        /// </summary>
        private void OnDisable()
        {
            grassPosBuffer?.Release();
            visiblePosIDBuffer?.Release();
            argsBuffer?.Release();
            grassPosBuffer = null;
            visiblePosIDBuffer = null;
            argsBuffer = null;
            Instance = null;
        }
    }
}
