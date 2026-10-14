#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Object=UnityEngine.Object;

namespace RuinedMineEntranceAsset.Editor
{
    public static class RuinedMineEntranceBuilder
    {
        const string Root="Assets/RuinedMineEntrance";
        static readonly string Output=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"Codex/2026-10-13/unity/outputs/RuinedMineEntrance");
        [Serializable] class MaterialDef {public string name;public float[] color;public float metallic,roughness,emission;public bool wood;}
        [Serializable] class Manifest {public MaterialDef[] materials;}
        [Serializable] class Validation
        {
            public string status,unity,pipeline,error,scene;
            public string[] prefabs;
            public float[] dimensions;
            public long[] lodTriangles;
            public int renderers,materials,lodGroups,missingMaterials,missingScripts,clearPassageRays;
            public bool normalsPresent,uvsPresent,tangentsPresent,woodTextureAssigned,normalMapAssigned,centralPassageClear,framePostCollision;
        }
        static readonly Dictionary<string,Material> materials=new Dictionary<string,Material>();
        static Texture2D Texture(string suffix)=>AssetDatabase.LoadAssetAtPath<Texture2D>(Root+"/Textures/MineWood_"+suffix+".png");
        static Material SaveMaterial(Material material,string name)
        {
            string path=Root+"/Materials/"+name+".mat";var existing=AssetDatabase.LoadAssetAtPath<Material>(path);
            if(existing!=null){EditorUtility.CopySerialized(material,existing);Object.DestroyImmediate(material);}else AssetDatabase.CreateAsset(material,path);
            return AssetDatabase.LoadAssetAtPath<Material>(path);
        }
        static void ConfigureAssets()
        {
            foreach(string guid in AssetDatabase.FindAssets("t:Texture2D",new[]{Root+"/Textures"}))
            {
                string path=AssetDatabase.GUIDToAssetPath(guid);var importer=AssetImporter.GetAtPath(path) as TextureImporter;
                importer.maxTextureSize=2048;importer.npotScale=TextureImporterNPOTScale.None;importer.mipmapEnabled=true;importer.wrapMode=TextureWrapMode.Repeat;importer.anisoLevel=8;importer.textureCompression=TextureImporterCompression.CompressedHQ;
                importer.textureType=path.EndsWith("_Normal.png",StringComparison.Ordinal)?TextureImporterType.NormalMap:TextureImporterType.Default;
                importer.sRGBTexture=path.EndsWith("_BaseColor.png",StringComparison.Ordinal);importer.convertToNormalmap=false;importer.SaveAndReimport();
            }
            var shader=Shader.Find(GraphicsSettings.currentRenderPipeline==null?"Standard":"Universal Render Pipeline/Lit");if(shader==null)throw new InvalidOperationException("Lit shader is unavailable.");
            var manifest=JsonUtility.FromJson<Manifest>(File.ReadAllText(Root+"/MaterialManifest.json"));materials.Clear();
            foreach(var def in manifest.materials)
            {
                var m=new Material(shader){name=def.name,enableInstancing=true};var color=new Color(def.color[0],def.color[1],def.color[2],1);
                foreach(string key in new[]{"_BaseColor","_Color"})if(m.HasProperty(key))m.SetColor(key,color);
                m.SetFloat("_Metallic",def.metallic);m.SetFloat("_Smoothness",1-def.roughness);m.SetFloat("_Glossiness",1-def.roughness);
                if(def.wood)
                {
                    foreach(string key in new[]{"_BaseMap","_MainTex"})if(m.HasProperty(key))m.SetTexture(key,Texture("BaseColor"));
                    m.SetTexture("_BumpMap",Texture("Normal"));m.SetFloat("_BumpScale",.6f);m.EnableKeyword("_NORMALMAP");
                    m.SetTexture("_MetallicGlossMap",Texture("MetallicSmoothness"));m.SetFloat("_Smoothness",1);m.SetFloat("_GlossMapScale",1);m.EnableKeyword("_METALLICGLOSSMAP");m.EnableKeyword("_METALLICSPECGLOSSMAP");
                }
                if(def.emission>0){m.SetColor("_EmissionColor",color*def.emission);m.EnableKeyword("_EMISSION");m.globalIlluminationFlags=MaterialGlobalIlluminationFlags.RealtimeEmissive;}
                if(def.name=="Lantern_AmberGlass"){m.SetFloat("_SpecularHighlights",0);m.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");}
                materials[def.name]=SaveMaterial(m,def.name);
            }
            string asset=Root+"/Models/RuinedMineEntrance.fbx";var model=AssetImporter.GetAtPath(asset) as ModelImporter;
            model.globalScale=1;model.importCameras=false;model.importLights=false;model.importAnimation=false;model.bakeAxisConversion=true;model.importNormals=ModelImporterNormals.Import;model.importTangents=ModelImporterTangents.CalculateMikk;model.materialImportMode=ModelImporterMaterialImportMode.ImportStandard;model.materialLocation=ModelImporterMaterialLocation.InPrefab;model.meshCompression=ModelImporterMeshCompression.Off;model.isReadable=false;
            foreach(var key in model.GetExternalObjectMap().Keys.ToArray())model.RemoveRemap(key);
            foreach(var pair in materials)model.AddRemap(new AssetImporter.SourceAssetIdentifier(typeof(Material),pair.Key),pair.Value);
            model.SaveAndReimport();
        }
        static long Triangles(Mesh mesh)=>Enumerable.Range(0,mesh.subMeshCount).Sum(s=>(long)mesh.GetIndexCount(s)/3);
        static Bounds BoundsOf(GameObject root)
        {
            var rs=root.GetComponentsInChildren<Renderer>().Where(r=>r.name.Contains("LOD0")).ToArray();var b=rs[0].bounds;foreach(var r in rs.Skip(1))b.Encapsulate(r.bounds);return b;
        }
        static Camera CameraAndLighting()
        {
            RenderSettings.skybox=null;RenderSettings.fog=false;RenderSettings.ambientMode=AmbientMode.Trilight;RenderSettings.ambientSkyColor=new Color(.46f,.50f,.54f);RenderSettings.ambientEquatorColor=new Color(.29f,.32f,.34f);RenderSettings.ambientGroundColor=new Color(.17f,.14f,.10f);
            var reflection=new Cubemap(16,TextureFormat.RGBA32,false){name="Neutral_Studio_Reflection"};
            for(int face=0;face<6;face++){var pixels=new Color[256];for(int i=0;i<pixels.Length;i++){float value=face==2?.75f:face==3?.18f:.38f+(i/16)*.015f;pixels[i]=new Color(value*.93f,value*.97f,value,1);}reflection.SetPixels(pixels,(CubemapFace)face);}reflection.Apply();AssetDatabase.CreateAsset(reflection,Root+"/Demo/NeutralReflection.asset");RenderSettings.defaultReflectionMode=DefaultReflectionMode.Custom;RenderSettings.customReflection=reflection;RenderSettings.reflectionIntensity=.8f;
            var sun=new GameObject("Soft_Daylight").AddComponent<Light>();sun.type=LightType.Directional;sun.transform.rotation=Quaternion.Euler(48,-35,0);sun.color=new Color(1,.94f,.84f);sun.intensity=1.1f;sun.shadows=LightShadows.Soft;sun.shadowStrength=.8f;sun.shadowBias=.03f;sun.shadowNormalBias=.12f;RenderSettings.sun=sun;
            var fill=new GameObject("Cool_Fill").AddComponent<Light>();fill.type=LightType.Directional;fill.transform.rotation=Quaternion.Euler(65,150,0);fill.intensity=.32f;fill.color=new Color(.82f,.90f,1);
            var camera=new GameObject("RuinedMineEntrance_Showcase_Camera").AddComponent<Camera>();camera.tag="MainCamera";camera.clearFlags=CameraClearFlags.SolidColor;camera.backgroundColor=new Color(.10f,.14f,.17f);camera.nearClipPlane=.05f;camera.farClipPlane=100;camera.allowHDR=true;camera.allowMSAA=true;camera.orthographic=true;
            var data=camera.gameObject.AddComponent<UniversalAdditionalCameraData>();data.renderPostProcessing=false;data.antialiasing=AntialiasingMode.SubpixelMorphologicalAntiAliasing;data.antialiasingQuality=AntialiasingQuality.High;
            return camera;
        }
        static void Position(Camera camera,Vector3 position,Vector3 target,float size)
        {camera.transform.position=position;camera.transform.LookAt(target);camera.orthographicSize=size;}
        static void Capture(Camera camera,string filename,int width=1600,int height=1400)
        {
            bool oldAsync=ShaderUtil.allowAsyncCompilation;ShaderUtil.allowAsyncCompilation=false;camera.aspect=(float)width/height;
            var rt=RenderTexture.GetTemporary(width,height,24,RenderTextureFormat.ARGB32);var request=new UniversalRenderPipeline.SingleCameraRequest{destination=rt};RenderPipeline.SubmitRenderRequest(camera,request);
            var old=RenderTexture.active;RenderTexture.active=rt;var image=new Texture2D(width,height,TextureFormat.RGB24,false);image.ReadPixels(new Rect(0,0,width,height),0,0);image.Apply();File.WriteAllBytes(Path.Combine(Output,filename),image.EncodeToPNG());Object.DestroyImmediate(image);RenderTexture.active=old;RenderTexture.ReleaseTemporary(rt);ShaderUtil.allowAsyncCompilation=oldAsync;
        }
        static Material DemoMaterial(string name,Color color)
        {
            var material=new Material(materials["Stone_1"].shader){name=name};material.SetColor("_BaseColor",color);material.SetFloat("_Smoothness",.03f);return SaveMaterial(material,name);
        }
        static GameObject Primitive(string name,Vector3 position,Vector3 scale,Material material)
        {
            var go=GameObject.CreatePrimitive(PrimitiveType.Cube);go.name=name;go.transform.position=position;go.transform.localScale=scale;go.GetComponent<Renderer>().sharedMaterial=material;return go;
        }
        static Mesh MakeRock()
        {
            var vertices=new List<Vector3>();var triangles=new List<int>();var random=new System.Random(284);
            for(int row=0;row<3;row++)for(int i=0;i<8;i++)
            {
                float angle=i*Mathf.PI/4;float radius=(row==1?1:row==2?.69f:.84f)*(float)(.89+random.NextDouble()*.18);vertices.Add(new Vector3(Mathf.Cos(angle)*radius,row==0?0:row==1?.7f:1.6f,Mathf.Sin(angle)*radius));
            }
            for(int row=0;row<2;row++)for(int i=0;i<8;i++)
            {
                int a=row*8+i,b=row*8+(i+1)%8,c=b+8,d=a+8;triangles.AddRange(new[]{a,d,b,b,d,c});
            }
            for(int i=1;i<7;i++)triangles.AddRange(new[]{16,17+i,16+i});
            // Split triangle corners for the flat facets used by the reference cliffs.
            var flatVerts=triangles.Select(i=>vertices[i]).ToArray();var mesh=new Mesh{name="Context_Faceted_Rock"};mesh.vertices=flatVerts;mesh.triangles=Enumerable.Range(0,flatVerts.Length).ToArray();mesh.RecalculateNormals();mesh.RecalculateBounds();AssetDatabase.CreateAsset(mesh,Root+"/Demo/ContextRock.asset");return mesh;
        }
        static void Context(GameObject entrance)
        {
            var ground=DemoMaterial("Demo_Earth",new Color(.28f,.23f,.155f));Primitive("Demonstration_Path",new Vector3(0,-.075f,-1.5f),new Vector3(14,.14f,14),ground);
            var rockMesh=MakeRock();var wall=DemoMaterial("Demo_Cliff",new Color(.31f,.35f,.34f));var lighter=DemoMaterial("Demo_CliffLight",new Color(.39f,.40f,.35f));var paving=DemoMaterial("Demo_Paving",new Color(.40f,.34f,.24f));
            var random=new System.Random(391);var context=new GameObject("Context_Only_Cliff_And_Path");
            for(int side=-1;side<=1;side+=2)for(int j=0;j<5;j++)
            {
                var go=new GameObject("Grey_cliff_outcrop");go.transform.SetParent(context.transform);go.transform.position=new Vector3(side*(3.45f+(float)random.NextDouble()*.65f),-.06f,j*1.45f+.65f);go.transform.localScale=new Vector3(1.0f+(float)random.NextDouble()*.40f,2.3f+(float)random.NextDouble()*.75f,1.35f);go.transform.rotation=Quaternion.Euler(0,random.Next(0,70),0);go.AddComponent<MeshFilter>().sharedMesh=rockMesh;go.AddComponent<MeshRenderer>().sharedMaterial=j%2==0?wall:lighter;
            }
            var ceiling=new GameObject("Existing_Cliff_Overhang");ceiling.transform.SetParent(context.transform);ceiling.transform.position=new Vector3(0,4.03f,2.3f);ceiling.transform.localScale=new Vector3(4.0f,.56f,2.55f);ceiling.AddComponent<MeshFilter>().sharedMesh=rockMesh;ceiling.AddComponent<MeshRenderer>().sharedMaterial=lighter;
            var backdrop=DemoMaterial("Demo_TunnelDark",new Color(.035f,.055f,.064f));Primitive("Tunnel_Dark_Recess",new Vector3(0,1.72f,5.0f),new Vector3(5.7f,3.5f,.10f),backdrop).transform.SetParent(context.transform);
            for(int i=0;i<110;i++)
            {
                float x=(float)random.NextDouble()*3.9f-1.95f,z=-(float)random.NextDouble()*7.4f;
                var go=new GameObject("Path_slate");go.transform.SetParent(context.transform);go.transform.position=new Vector3(x,-.013f,z);go.transform.localScale=new Vector3(.12f+(float)random.NextDouble()*.22f,.025f,.12f+(float)random.NextDouble()*.25f);go.transform.rotation=Quaternion.Euler(0,random.Next(0,180),0);go.AddComponent<MeshFilter>().sharedMesh=rockMesh;go.AddComponent<MeshRenderer>().sharedMaterial=paving;
            }
            var grass=DemoMaterial("Demo_GoldGrass",new Color(.72f,.51f,.16f));grass.SetFloat("_Cull",0);
            var bladeMesh=new Mesh{name="Context_Grass_Blade"};bladeMesh.vertices=new[]{new Vector3(-.06f,0,0),new Vector3(.06f,0,0),new Vector3(.11f,.42f,.07f),new Vector3(0,0,-.06f),new Vector3(0,0,.06f),new Vector3(.04f,.37f,.10f)};bladeMesh.triangles=new[]{0,1,2,3,4,5};bladeMesh.RecalculateNormals();AssetDatabase.CreateAsset(bladeMesh,Root+"/Demo/GrassBlade.asset");
            for(int side=-1;side<=1;side+=2)for(int i=0;i<65;i++)
            {
                var go=new GameObject("Golden_pathside_grass");go.transform.SetParent(context.transform);go.transform.position=new Vector3(side*(2.12f+(float)random.NextDouble()*.54f),0,-(float)random.NextDouble()*6.5f);go.transform.localScale=Vector3.one*(.62f+(float)random.NextDouble()*.63f);go.transform.rotation=Quaternion.Euler(0,random.Next(0,360),0);go.AddComponent<MeshFilter>().sharedMesh=bladeMesh;go.AddComponent<MeshRenderer>().sharedMaterial=grass;
            }
        }
        static GameObject Entrance(string name,bool frameOnly=false)
        {
            var root=new GameObject(name);var asset=AssetDatabase.LoadAssetAtPath<GameObject>(Root+"/Models/RuinedMineEntrance.fbx");
            var model=(GameObject)PrefabUtility.InstantiatePrefab(asset);PrefabUtility.UnpackPrefabInstance(model,PrefabUnpackMode.Completely,InteractionMode.AutomatedAction);model.transform.SetParent(root.transform,false);
            foreach(var old in model.GetComponentsInChildren<LODGroup>(true))Object.DestroyImmediate(old);
            if(frameOnly)foreach(var part in model.GetComponentsInChildren<MeshRenderer>(true).Where(r=>r.name.StartsWith("Broken_Leaf",StringComparison.Ordinal)).ToArray())Object.DestroyImmediate(part.gameObject);
            var renderers=root.GetComponentsInChildren<MeshRenderer>(true);
            foreach(var r in renderers){r.enabled=true;if(r.sharedMaterials.Any(m=>m==null||!materials.ContainsKey(m.name)))throw new InvalidOperationException("Material mapping failed on "+r.name);}
            var group=root.AddComponent<LODGroup>();group.SetLODs(new[]{new LOD(.4f,renderers.Where(r=>r.name.Contains("LOD0")).Cast<Renderer>().ToArray()),new LOD(.15f,renderers.Where(r=>r.name.Contains("LOD1")).Cast<Renderer>().ToArray()),new LOD(.005f,renderers.Where(r=>r.name.Contains("LOD2")).Cast<Renderer>().ToArray())});group.RecalculateBounds();
            foreach(var filter in root.GetComponentsInChildren<MeshFilter>().Where(f=>f.name.Contains("LOD1")))filter.gameObject.AddComponent<MeshCollider>().sharedMesh=filter.sharedMesh;
            var lamp=new GameObject("Surviving_Mining_Lamp").AddComponent<Light>();lamp.transform.SetParent(root.transform,false);lamp.transform.localPosition=new Vector3(-1.88f,2.07f,-1.02f);lamp.type=LightType.Point;lamp.color=new Color(1,.64f,.25f);lamp.intensity=.65f;lamp.range=2.6f;lamp.shadows=LightShadows.None;
            return root;
        }
        [MenuItem("Tools/Ruined Mine Entrance/Build Prefabs and Showcase")]
        public static void Build()
        {
            Directory.CreateDirectory(Output);var report=new Validation{status="error",unity=Application.unityVersion};
            try
            {
                foreach(string dir in new[]{"Materials","Prefabs","Scenes","Demo"})Directory.CreateDirectory(Root+"/"+dir);AssetDatabase.Refresh();ConfigureAssets();
                var scene=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);var entrance=Entrance("RuinedMineEntrance_Ruined");
                var renderers=entrance.GetComponentsInChildren<MeshRenderer>();var meshes=renderers.Select(r=>r.GetComponent<MeshFilter>().sharedMesh).ToArray();var bounds=BoundsOf(entrance);
                report.dimensions=new[]{bounds.size.x,bounds.size.y,bounds.size.z};report.renderers=renderers.Length;report.materials=materials.Count;report.lodGroups=entrance.GetComponentsInChildren<LODGroup>().Length;
                report.lodTriangles=Enumerable.Range(0,3).Select(l=>renderers.Where(r=>r.name.Contains("LOD"+l)).Sum(r=>Triangles(r.GetComponent<MeshFilter>().sharedMesh))).ToArray();
                report.normalsPresent=meshes.All(m=>m.HasVertexAttribute(VertexAttribute.Normal));report.uvsPresent=meshes.All(m=>m.HasVertexAttribute(VertexAttribute.TexCoord0));report.tangentsPresent=meshes.All(m=>m.HasVertexAttribute(VertexAttribute.Tangent));
                report.woodTextureAssigned=materials["Oak_Frame"].GetTexture("_BaseMap")!=null;report.normalMapAssigned=materials["Oak_Frame"].GetTexture("_BumpMap")!=null;
                report.missingMaterials=renderers.Sum(r=>r.sharedMaterials.Count(m=>m==null||m.shader==null||!m.shader.isSupported));report.missingScripts=entrance.GetComponentsInChildren<Transform>().Sum(t=>GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(t.gameObject));report.pipeline=GraphicsSettings.currentRenderPipeline?.name;
                Physics.SyncTransforms();RaycastHit hit;report.centralPassageClear=true;
                foreach(float x in new[]{-.45f,-.20f,0,.20f,.45f})foreach(float y in new[]{.4f,1.0f,1.8f,2.5f}){report.clearPassageRays++;if(Physics.Raycast(new Vector3(x,y,-2),Vector3.forward,out hit,4,~0,QueryTriggerInteraction.Ignore))report.centralPassageClear=false;}
                report.framePostCollision=Physics.Raycast(new Vector3(-1.87f,1.6f,-2),Vector3.forward,out hit,4)&&hit.collider is MeshCollider;
                if(report.lodGroups!=1||!report.centralPassageClear||!report.framePostCollision||!report.normalsPresent||!report.uvsPresent||!report.tangentsPresent||!report.woodTextureAssigned||!report.normalMapAssigned||report.missingMaterials>0||report.missingScripts>0)throw new InvalidOperationException("Ruined entrance import or collision validation failed: "+JsonUtility.ToJson(report));
                string main=Root+"/Prefabs/RuinedMineEntrance_Ruined.prefab";PrefabUtility.SaveAsPrefabAsset(entrance,main);var frame=Entrance("RuinedMineEntrance_Ruined_FrameOnly",true);string framePath=Root+"/Prefabs/RuinedMineEntrance_Ruined_FrameOnly.prefab";PrefabUtility.SaveAsPrefabAsset(frame,framePath);Object.DestroyImmediate(frame);
                var camera=CameraAndLighting();var studio=Primitive("Preview_Studio_Floor",new Vector3(0,-.065f,0),new Vector3(100,.1f,100),DemoMaterial("Demo_StudioFloor",new Color(.14f,.18f,.19f)));entrance.GetComponent<LODGroup>().ForceLOD(0);
                Position(camera,new Vector3(5.3f,4.6f,-11),new Vector3(0,1.9f,.12f),3.05f);Capture(camera,"RuinedMineEntrance_Ruined_Unity_Preview.png",1600,1400);
                Position(camera,new Vector3(.2f,3.1f,-12),new Vector3(0,1.85f,0),2.85f);Capture(camera,"RuinedMineEntrance_Ruined_Unity_Front.png",1500,1400);
                entrance.GetComponent<LODGroup>().ForceLOD(-1);Object.DestroyImmediate(studio);Context(entrance);Position(camera,new Vector3(2.6f,4.6f,-10),new Vector3(0,1.85f,-1.5f),4.25f);Capture(camera,"RuinedMineEntrance_Ruined_Unity_Context.png",1700,1400);
                report.scene=Root+"/Scenes/RuinedMineEntrance_Ruined_Showcase.unity";AssetDatabase.SaveAssets();EditorSceneManager.SaveScene(scene,report.scene);report.prefabs=new[]{main,framePath};
                var files=AssetDatabase.GetAllAssetPaths().Where(p=>p.StartsWith(Root+"/",StringComparison.Ordinal)&&File.Exists(p)&&!p.Contains("/Editor/")).ToArray();AssetDatabase.ExportPackage(files,Path.Combine(Output,"RuinedMineEntrance_Ruined_Unity.unitypackage"),ExportPackageOptions.Default);
                report.status="complete";File.WriteAllText(Path.Combine(Output,"UnityValidation.json"),JsonUtility.ToJson(report,true));Debug.Log("RUINED_MINE_ENTRANCE_UNITY_COMPLETE");
            }
            catch(Exception e){report.error=e.ToString();File.WriteAllText(Path.Combine(Output,"UnityValidation.json"),JsonUtility.ToJson(report,true));Debug.LogException(e);if(Application.isBatchMode)EditorApplication.Exit(1);}
        }
    }
}
#endif
