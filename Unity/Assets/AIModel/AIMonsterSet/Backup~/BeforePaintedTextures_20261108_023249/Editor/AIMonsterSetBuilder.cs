using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;
public static class AIMonsterSetBuilder {
 const string Root="Assets/AIModel/AIMonsterSet";
 [MenuItem("Tools/AI Monster Set/Generate")]
 public static void Generate(){
 Directory.CreateDirectory(Root+"/Materials");
 Build("Dragon","LavaDragon",true); Build("Troll","FrostArmoredTroll",false);
 AssetDatabase.SaveAssets(); AssetDatabase.Refresh();
 }
 static void Build(string source,string name,bool lava){
 string path="Assets/Res/Model/Monster/Fantasy animated characters pack/"+source+" animated character/Prefab/"+source+".prefab";
 var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(path); if(!prefab)throw new System.Exception(path);
 var go=(GameObject)PrefabUtility.InstantiatePrefab(prefab); go.name=name;
 try{
 var shader=Shader.Find("AIMonsterSet/MineralSkin"); if(!shader)throw new System.Exception("MineralSkin shader missing");
 var skin=new Material(shader); skin.SetColor("_Rock",lava?new Color(.07f,.025f,.015f):new Color(.09f,.19f,.25f)); skin.SetColor("_Glow",lava?new Color(3, .48f,.015f):new Color(.12f,1.2f,2));
 AssetDatabase.CreateAsset(skin,Root+"/Materials/"+name+"Skin.mat");
 foreach(var r in go.GetComponentsInChildren<Renderer>(true)) r.sharedMaterials=r.sharedMaterials.Select(m=>skin).ToArray();
 var armor=new Material(shader); armor.SetColor("_Rock",lava?new Color(.12f,.055f,.035f):new Color(.4f,.75f,.85f)); armor.SetColor("_Glow",Color.black); armor.SetFloat("_Metallic",.35f); AssetDatabase.CreateAsset(armor,Root+"/Materials/"+name+"Armor.mat");
 var render=go.GetComponentsInChildren<SkinnedMeshRenderer>().First(); var bones=render.bones;
 float scale=render.bounds.size.magnitude*.055f;
 var head=bones.FirstOrDefault(t=>t.name.ToLower().Contains("head"));
 if(!head)head=bones.Last();
 for(int i=0;i<3;i++)Spike(head,new Vector3((i-1)*scale*.8f,scale*.3f,0),scale*(i==1?1.5f:1),armor,"Crown_"+i);
 var back=bones.Where(t=>t.name.ToLower().Contains("spine")).ToArray(); if(back.Length==0)back=bones.Where(t=>t.name.ToLower().Contains("body")).Take(3).ToArray();
 foreach(var b in back)for(int i=-1;i<=1;i++)Spike(b,new Vector3(i*scale*.8f,0,-scale*.5f),scale,armor,"BackPlate_"+i);
 PrefabUtility.SaveAsPrefabAsset(go,Root+"/"+name+".prefab");
 }finally{Object.DestroyImmediate(go);}
 }
 static void Spike(Transform bone,Vector3 pos,float size,Material mat,string name){
 var o=GameObject.CreatePrimitive(PrimitiveType.Sphere);o.name=name;Object.DestroyImmediate(o.GetComponent<Collider>());o.transform.SetParent(bone,false);o.transform.localPosition=pos;o.transform.localScale=new Vector3(size*.45f,size*1.8f,size*.6f);o.GetComponent<Renderer>().sharedMaterial=mat;
 }
}

