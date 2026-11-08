using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
[InitializeOnLoad] public static class AIMonsterVisualRepair {
 static AIMonsterVisualRepair(){EditorApplication.delayCall+=Repair;}
 [MenuItem("Tools/AI Monster Set/Repair Appearance")]
 public static void Repair(){
 var report=new StringBuilder();bool ok=true;
 foreach(var name in new[]{"LavaDragon","FrostArmoredTroll"}){
 var path=AIMonsterSetBuilder.Root+"/Textures/"+name+"_BaseColor.png";
 AssetDatabase.ImportAsset(path,ImportAssetOptions.ForceUpdate|ImportAssetOptions.ForceSynchronousImport);
 var importer=AssetImporter.GetAtPath(path) as TextureImporter;
 if(importer){importer.textureType=TextureImporterType.Default;importer.sRGBTexture=true;importer.maxTextureSize=2048;importer.mipmapEnabled=true;importer.SaveAndReimport();}
 var tex=AssetDatabase.LoadAssetAtPath<Texture2D>(path);
 report.AppendLine(name+": importer="+AssetImporter.GetAtPath(path)?.GetType().Name+" texture="+(tex?tex.width+"x"+tex.height:"NULL"));
 if(!tex)ok=false;
 }
 AIMonsterSetBuilder.ConfigureMaterials();
 foreach(var name in new[]{"LavaDragon","FrostArmoredTroll"}){
 var mat=AssetDatabase.LoadAssetAtPath<Material>(AIMonsterSetBuilder.Root+"/Materials/"+name+"Skin.mat");
 var texture=mat?mat.GetTexture("_BaseMap"):null;
 report.AppendLine(name+": shader="+(mat?mat.shader.name:"NULL")+" BaseMap="+(texture?AssetDatabase.GetAssetPath(texture):"NULL"));
 if(!texture)ok=false;
 }
 report.AppendLine("RESULT="+(ok?"PASS":"FAIL"));
 Directory.CreateDirectory(AIMonsterSetBuilder.Root+"/Backup~");
 File.WriteAllText(AIMonsterSetBuilder.Root+"/Backup~/TextureValidation.txt",report.ToString());
 if(!ok)Debug.LogError(report.ToString());else Debug.Log(report.ToString());
 UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
 }
}
