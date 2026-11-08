using UnityEngine;
using UnityEditor;
using System.Linq;
[InitializeOnLoad] public static class AIMonsterVisualRepair {
 const string R="Assets/AIModel/AIMonsterSet/";
 static AIMonsterVisualRepair(){EditorApplication.delayCall+=()=>{if(!SessionState.GetBool("AIMonsterVisualRepair2",false)){Repair();SessionState.SetBool("AIMonsterVisualRepair2",true);}};}
 [MenuItem("Tools/AI Monster Set/Repair Appearance")]
 public static void Repair(){foreach(var pair in new[]{new[]{"LavaDragon","Dragon"},new[]{"FrostArmoredTroll","Troll"}}){
 var mat=AssetDatabase.LoadAssetAtPath<Material>(R+"Materials/"+pair[0]+"Skin.mat");
 if(mat){mat.SetTexture("_BaseMap",AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Res/Model/Monster/Fantasy animated characters pack/"+pair[1]+" animated character/Texture/"+pair[1]+".png")); mat.SetColor("_Rock",pair[1]=="Dragon"?new Color(.23f,.12f,.075f):new Color(.23f,.36f,.43f));EditorUtility.SetDirty(mat);}
 string path=R+pair[0]+".prefab";if(!AssetDatabase.LoadAssetAtPath<GameObject>(path))continue;
 var root=PrefabUtility.LoadPrefabContents(path);try{foreach(var t in root.GetComponentsInChildren<Transform>(true).Where(t=>t.name.StartsWith("Crown_")||t.name.StartsWith("BackPlate_"))){
 if(t.GetComponent<MeshFilter>()?.sharedMesh?.name=="Sphere"){
 var mesh=new Mesh();mesh.name="ObsidianSpike";var v=new Vector3[7];v[0]=new Vector3(0,.6f,0);v[6]=new Vector3(0,-.5f,0);for(int j=0;j<5;j++){float a=j*Mathf.PI*2/5;v[j+1]=new Vector3(Mathf.Cos(a)*.5f,-.5f,Mathf.Sin(a)*.5f);}var tris=new int[30];for(int j=0;j<5;j++){int k=(j+1)%5+1;int o=j*6;tris[o]=0;tris[o+1]=k;tris[o+2]=j+1;tris[o+3]=6;tris[o+4]=j+1;tris[o+5]=k;}mesh.vertices=v;mesh.triangles=tris;mesh.RecalculateNormals();string mp=R+pair[0]+t.name+t.GetInstanceID()+".asset";AssetDatabase.CreateAsset(mesh,mp);t.GetComponent<MeshFilter>().sharedMesh=mesh;t.localScale*=.28f;
 }}PrefabUtility.SaveAsPrefabAsset(root,path);}finally{PrefabUtility.UnloadPrefabContents(root);}
 }AssetDatabase.SaveAssets();}
}
