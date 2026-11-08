using UnityEditor;using UnityEngine;using System.IO;using System.Text;using System.Linq;
[InitializeOnLoad] public static class TrollEquipmentInspect {
 static TrollEquipmentInspect(){EditorApplication.delayCall+=Run;}
 static void Run(){if(File.Exists("Assets/AIModel/AIMonsterSet/Backup~/TrollRig.txt"))return;
 var g=PrefabUtility.LoadPrefabContents("Assets/AIModel/AIMonsterSet/FrostArmoredTroll.prefab");var s=new StringBuilder();try{
 foreach(var t in g.GetComponentsInChildren<Transform>(true).Where(t=>t.name.StartsWith("bip_")))s.AppendLine(t.name+" pos="+g.transform.InverseTransformPoint(t.position).ToString("F4")+" up="+g.transform.InverseTransformDirection(t.up).ToString("F3"));
 foreach(var r in g.GetComponentsInChildren<SkinnedMeshRenderer>(true)){
 var m=new Mesh();r.BakeMesh(m);var v=m.vertices.Select(x=>g.transform.InverseTransformPoint(r.transform.TransformPoint(x))).ToArray();var b=new Bounds(v[0],Vector3.zero);foreach(var p in v)b.Encapsulate(p);s.AppendLine("MESH "+r.name+" bounds="+b.ToString("F4")+" bones="+string.Join(",",r.bones.Select(t=>t.name)));
 if(r.name=="Club"){foreach(var p in v.Where((x,i)=>i%20==0))s.AppendLine("clubVertex "+p.ToString("F3"));}
 else if(r.name=="Troll") {var w=r.sharedMesh.boneWeights;for(int j=0;j<r.bones.Length;j++){var pts=v.Where((p,i)=>w[i].boneIndex0==j&&w[i].weight0>.4f).ToArray();if(pts.Length==0)continue;var bb=new Bounds(pts[0],Vector3.zero);foreach(var p in pts)bb.Encapsulate(p);s.AppendLine("REGION "+r.bones[j].name+" "+bb.ToString("F4"));}}
 Object.DestroyImmediate(m);
 }
 File.WriteAllText("Assets/AIModel/AIMonsterSet/Backup~/TrollRig.txt",s.ToString());
 }finally{PrefabUtility.UnloadPrefabContents(g);}}
}
