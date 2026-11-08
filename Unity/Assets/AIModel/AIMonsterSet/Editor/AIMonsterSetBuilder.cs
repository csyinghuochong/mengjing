using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
public static class AIMonsterSetBuilder {
 public const string Root="Assets/AIModel/AIMonsterSet";
 [MenuItem("Tools/AI Monster Set/Generate")]
 public static void Generate(){
 ConfigureMaterials();
 foreach(var pair in new[]{new[]{"Dragon","LavaDragon"},new[]{"Troll","FrostArmoredTroll"}}){
 string path=Root+"/"+pair[1]+".prefab";
 // Existing variants retain their bone attachments and prefab identity.
 if(AssetDatabase.LoadAssetAtPath<GameObject>(path))continue;
 string source="Assets/Res/Model/Monster/Fantasy animated characters pack/"+pair[0]+" animated character/Prefab/"+pair[0]+".prefab";
 var go=(GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>(source));
 try{go.name=pair[1];var mat=AssetDatabase.LoadAssetAtPath<Material>(Root+"/Materials/"+pair[1]+"Skin.mat");foreach(var r in go.GetComponentsInChildren<Renderer>(true))r.sharedMaterials=r.sharedMaterials.Select(m=>mat).ToArray();PrefabUtility.SaveAsPrefabAsset(go,path);}finally{Object.DestroyImmediate(go);}
 }
 AssetDatabase.SaveAssets();
 }
 public static void ConfigureMaterials(){
 var shader=Shader.Find("Universal Render Pipeline/Lit");if(!shader)throw new System.Exception("URP Lit shader missing");
 foreach(var name in new[]{"LavaDragon","FrostArmoredTroll"}){
 string texPath=Root+"/Textures/"+name+"_BaseColor.png";
 var tex=AssetDatabase.LoadAssetAtPath<Texture2D>(texPath);if(!tex)continue;
 var importer=AssetImporter.GetAtPath(texPath) as TextureImporter;if(importer && (importer.maxTextureSize<2048 || !importer.sRGBTexture)){importer.maxTextureSize=2048;importer.sRGBTexture=true;importer.SaveAndReimport();}
 foreach(string kind in new[]{"Skin","Armor"}){
 string path=Root+"/Materials/"+name+kind+".mat";var mat=AssetDatabase.LoadAssetAtPath<Material>(path);if(!mat){Directory.CreateDirectory(Root+"/Materials");mat=new Material(shader);AssetDatabase.CreateAsset(mat,path);}
 mat.shader=shader;mat.SetFloat("_Surface",0);mat.SetFloat("_Metallic",0);mat.SetFloat("_Smoothness",.22f);mat.SetFloat("_Cull",2);mat.SetColor("_BaseColor",kind=="Skin"?Color.white:(name=="LavaDragon"?new Color(.16f,.12f,.1f):new Color(.38f,.5f,.55f)));mat.SetTexture("_BaseMap",kind=="Skin"?tex:null);mat.SetColor("_EmissionColor",Color.black);mat.DisableKeyword("_EMISSION");EditorUtility.SetDirty(mat);
 }
 }
 AssetDatabase.SaveAssets();
 }
}
