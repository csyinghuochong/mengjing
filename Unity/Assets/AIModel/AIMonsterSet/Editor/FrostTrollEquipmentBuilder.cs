using UnityEngine;
using UnityEditor;
using System;using System.IO;using System.Linq;using System.Collections.Generic;using System.Text;
[InitializeOnLoad] public static class FrostTrollEquipmentBuilder {
 const string R="Assets/AIModel/AIMonsterSet";
 const string Version="ArmoredCleaver_v7";
 static FrostTrollEquipmentBuilder(){EditorApplication.delayCall+=()=>{if(!File.Exists(R+"/Backup~/"+Version+".txt"))Build();};}
 [MenuItem("Tools/AI Monster Set/Equip Frost Troll")]
 public static void Build(){
 if(EditorApplication.isCompiling||EditorApplication.isPlayingOrWillChangePlaymode)return;
 Directory.CreateDirectory(R+"/Equipment");Directory.CreateDirectory(R+"/Backup~");
 string path=R+"/FrostArmoredTroll.prefab";
 if(!File.Exists(R+"/Backup~/FrostArmoredTroll_beforeEquipment.prefab"))File.Copy(path,R+"/Backup~/FrostArmoredTroll_beforeEquipment.prefab");
 var g=PrefabUtility.LoadPrefabContents(path);var log=new StringBuilder();
 try{
 var body=g.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(r=>r.name=="Troll");
 var club=g.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(r=>r.name=="Club");
 foreach(var t in g.GetComponentsInChildren<Transform>(true).Where(t=>t.name.StartsWith("Crown_")||t.name.StartsWith("BackPlate_")||t.name.StartsWith("FrostEquipment_")).ToArray())if(t)UnityEngine.Object.DestroyImmediate(t.gameObject);
 Material iron=Mat("FrostForgedIron",new Color(.32f,.43f,.5f),.12f,.3f),edge=Mat("FrostSilverEdge",new Color(.55f,.7f,.76f),.75f,.5f),leather=Mat("SwordGripLeather",new Color(.055f,.035f,.025f),0,.2f),ice=Mat("IceInlay",new Color(.18f,.65f,.85f),.3f,.6f);
 var baked=new Mesh();body.BakeMesh(baked);var points=baked.vertices.Select(v=>g.transform.InverseTransformPoint(body.transform.TransformPoint(v))).ToArray();UnityEngine.Object.DestroyImmediate(baked);
 var main=body.sharedMesh;var bw=main.boneWeights;var names=body.bones.Select(b=>b.name).ToArray();
 Func<int,string> boneName=i=>{var w=bw[i];int b=w.boneIndex0;float m=w.weight0;if(w.weight1>m){b=w.boneIndex1;m=w.weight1;}if(w.weight2>m){b=w.boneIndex2;m=w.weight2;}if(w.weight3>m)b=w.boneIndex3;return names[b];};
 Func<int,bool> helmet=i=>{var p=points[i];return (boneName(i)=="bip_head"||boneName(i)=="bip_neck1")&&((p.y>1.005f&&p.z<.53f)||(p.y>.9f&&Mathf.Abs(p.x-.116f)>.133f&&p.z<.49f));};
 Func<int,bool> torso=i=>{var p=points[i];var b=boneName(i);return (b=="bip_spine_2"||b=="bip_spine_0")&&p.y>.69f&&p.y<1.19f;};
 Func<int,bool> shoulders=i=>{var b=boneName(i);var p=points[i];return (b.Contains("upperArm")||b.Contains("Arm_Rotate"))&&!b.Contains("Hand")&&p.y>(b.EndsWith("_L")?.83f:1.00f);};
 Func<int,bool> bracers=i=>{var b=boneName(i);return b.Contains("lowerArm")||b.Contains("Hand_Rotate1");};
 var selections=new Dictionary<string,int[]>{
 {"Helmet",Select(main,helmet)},{"Breastplate",Select(main,torso)},{"Pauldrons",Select(main,shoulders)},{"Bracers",Select(main,bracers)}};
 foreach(var kv in selections){AddArmor(body,kv.Key,kv.Value,null,iron,edge);log.AppendLine(kv.Key+" triangles="+kv.Value.Length/3);}
 var death=g.GetComponentsInChildren<SkinnedMeshRenderer>(true).FirstOrDefault(r=>r.name=="Troll_death");
 if(death){var map=UVMap(main,death.sharedMesh);if(map!=null){foreach(var kv in selections)AddArmor(death,kv.Key,kv.Value,map,iron,edge);log.AppendLine("Death armor UV correspondence PASS");}else throw new Exception("Cannot map death armor UVs safely");}
 CleanArmor(g,body,death,points,iron,edge);
 // Replace Club's mesh directly. Original animation visibility and weapon bone remain intact.
 var weaponBone=club.bones.Single();
 var original=AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Res/Model/Monster/Fantasy animated characters pack/Troll animated character/Prefab/Troll.prefab").GetComponentsInChildren<SkinnedMeshRenderer>(true).First(r=>r.name=="Club");
 var bm=new Mesh();var current=club.sharedMesh;club.sharedMesh=original.sharedMesh;club.BakeMesh(bm);club.sharedMesh=current;var cp=bm.vertices.Select(p=>g.transform.InverseTransformPoint(club.transform.TransformPoint(p))).ToArray();UnityEngine.Object.DestroyImmediate(bm);
 Vector3 grip=g.transform.InverseTransformPoint(weaponBone.position);Vector3 center=cp.Aggregate(Vector3.zero,(a,b)=>a+b)/cp.Length;
 Vector3 axis=(center-grip).normalized;Vector3 width=Vector3.ProjectOnPlane(Vector3.up,axis).normalized;Vector3 thick=Vector3.Cross(width,axis).normalized;
 var weapon=new Parts();
 // Broad single-edged cleaver, swept point, beveled silver cutting edge.
 Vector2[] outline={new Vector2(-.115f,.18f),new Vector2(.15f,.18f),new Vector2(.205f,.85f),new Vector2(.12f,1.16f),new Vector2(-.11f,1.05f)};
 weapon.Prism(outline,.045f,0);
 weapon.Prism(new[]{new Vector2(.11f,.23f),new Vector2(.15f,.18f),new Vector2(.205f,.85f),new Vector2(.12f,1.16f),new Vector2(.105f,.96f),new Vector2(.15f,.82f)},.047f,1);
 weapon.Box(new Vector3(0,.15f,0),new Vector3(.41f,.065f,.10f),1);
 weapon.Box(new Vector3(0,-.05f,0),new Vector3(.075f,.34f,.075f),2);
 for(int j=0;j<6;j++)weapon.Box(new Vector3(0,-.19f+j*.051f,0),new Vector3(.081f,.013f,.081f),0);
 weapon.Box(new Vector3(0,-.235f,0),new Vector3(.12f,.07f,.11f),1);
 weapon.Prism(new[]{new Vector2(-.03f,.4f),new Vector2(0,.47f),new Vector2(.03f,.4f),new Vector2(0,.33f)},.052f,3);
 var sword=weapon.ToMesh("FrostCleaver",p=>club.transform.InverseTransformPoint(g.transform.TransformPoint(grip+width*p.x+axis*p.y+thick*p.z)),4);
 sword.boneWeights=Enumerable.Repeat(new BoneWeight{boneIndex0=0,weight0=1},sword.vertexCount).ToArray();sword.bindposes=new[]{weaponBone.worldToLocalMatrix*club.transform.localToWorldMatrix};
 club.sharedMesh=SaveMesh(sword,"FrostCleaver");club.sharedMaterials=new[]{iron,edge,leather,ice};club.localBounds=club.sharedMesh.bounds;club.updateWhenOffscreen=true;
 log.AppendLine("Weapon=FrostCleaver bone="+weaponBone.name+" vertices="+club.sharedMesh.vertexCount);
 foreach(var src in g.GetComponentsInChildren<SkinnedMeshRenderer>(true).Where(r=>r==body||r==death)){
 var sync=src.GetComponent<FrostTrollEquipmentVisibility>();if(!sync)sync=src.gameObject.AddComponent<FrostTrollEquipmentVisibility>();sync.source=src;sync.armor=src.GetComponentsInChildren<SkinnedMeshRenderer>(true).Where(r=>r!=src).Cast<Renderer>().ToArray();
 }
 PrefabUtility.SaveAsPrefabAsset(g,path);AssetDatabase.SaveAssets();
 log.AppendLine("Prefab saved. Animator controller="+g.GetComponentInChildren<Animator>(true)?.runtimeAnimatorController?.name);
 Preview(g,"Idle",log);Preview(g,"Attack",log);
 log.AppendLine("RESULT=PASS");File.WriteAllText(R+"/Backup~/"+Version+".txt",log.ToString());Debug.Log(log.ToString());
 }catch(Exception ex){File.WriteAllText(R+"/Backup~/EquipmentError.txt",ex.ToString());Debug.LogException(ex);}finally{PrefabUtility.UnloadPrefabContents(g);}
 }
 // Build clean continuous armor silhouettes rather than exposing the body's triangle cuts.
 static List<Vector3> Dome(Vector3 c,Vector3 radius,float maxTheta){var p=new List<Vector3>();for(int r=0;r<=5;r++)for(int j=0;j<=16;j++){float theta=.025f+(maxTheta-.025f)*r/5f,a=j*Mathf.PI*2/16;p.Add(c+Vector3.Scale(radius,new Vector3(Mathf.Sin(theta)*Mathf.Cos(a),Mathf.Cos(theta),Mathf.Sin(theta)*Mathf.Sin(a))));}return p;}
 static int[] GridTris(int rows,int cols){var t=new List<int>();for(int r=0;r<rows-1;r++)for(int j=0;j<cols-1;j++){int a=r*cols+j,b=a+cols;t.AddRange(new[]{a,a+1,b,a+1,b+1,b});}return t.ToArray();}
 static void CleanArmor(GameObject root,SkinnedMeshRenderer src,SkinnedMeshRenderer death,Vector3[] posed,Material iron,Material edge){
 foreach(var renderer in new[]{src,death}.Where(x=>x))foreach(var t in renderer.GetComponentsInChildren<Transform>(true).Where(t=>t!=renderer.transform&&t.name.StartsWith("FrostEquipment_")).ToArray())UnityEngine.Object.DestroyImmediate(t.gameObject);
 var sets=new Dictionary<string,List<Vector3>>();
 sets["Helmet"]=Dome(new Vector3(.116f,.975f,.432f),new Vector3(.205f,.195f,.175f),Mathf.PI*.51f);
 var torso=new List<Vector3>();for(int r=0;r<6;r++){float u=r/5f;float y=Mathf.Lerp(1.18f,.68f,u);float cx=Mathf.Lerp(-.015f,-.04f,u),cz=Mathf.Lerp(-.095f,-.19f,u);float rx=Mathf.Lerp(.425f,.405f,u),rz=Mathf.Lerp(.425f,.40f,u);if(r==0){rx=.34f;rz=.35f;}for(int j=0;j<=16;j++){float a=j*Mathf.PI*2/16;torso.Add(new Vector3(cx+rx*Mathf.Cos(a),y,cz+rz*Mathf.Sin(a)));}}
 sets["Breastplate"]=torso;
 sets["LeftPauldron"]=Dome(new Vector3(-.32f,.94f,.25f),new Vector3(.245f,.205f,.235f),Mathf.PI*.56f);
 sets["RightPauldron"]=Dome(new Vector3(.43f,1.08f,-.15f),new Vector3(.245f,.205f,.235f),Mathf.PI*.56f);
 foreach(string side in new[]{"L","R"}){
 var elbow=root.GetComponentsInChildren<Transform>(true).First(t=>t.name=="bip_lowerArm_"+side);var hand=root.GetComponentsInChildren<Transform>(true).First(t=>t.name=="bip_hand_"+side);
 Vector3 a=root.transform.InverseTransformPoint(elbow.position),b=root.transform.InverseTransformPoint(hand.position),axis=(b-a).normalized,right=Vector3.Cross(axis,Vector3.forward).normalized,front=Vector3.Cross(right,axis).normalized;var p=new List<Vector3>();
 for(int r=0;r<6;r++){float u=r/5f;Vector3 c=Vector3.Lerp(a,b,Mathf.Lerp(.22f,.78f,u));float rad=Mathf.Lerp(.25f,.225f,u);for(int j=0;j<=16;j++){float angle=j*Mathf.PI*2/16;p.Add(c+rad*(right*Mathf.Cos(angle)+front*Mathf.Sin(angle)));}}
 sets[side+"Bracer"]=p;
 }
 var main=src.sharedMesh;var dv=death?death.sharedMesh.vertices:null;var dn=death?death.sharedMesh.normals:null;var map=death?UVMap(main,death.sharedMesh):null;var mv=main.vertices;var mn=main.normals;var weights=main.boneWeights;var bind=main.bindposes;
 foreach(var pair in sets){
 var vertices=new List<Vector3>();var ws=new List<BoneWeight>();var dvertices=new List<Vector3>();var dws=new List<BoneWeight>();
 foreach(var p in pair.Value){int nearest=0;float best=float.MaxValue;for(int i=0;i<posed.Length;i++){float dist=(posed[i]-p).sqrMagnitude;if(dist<best){best=dist;nearest=i;}}
 var w=weights[nearest];var indices=new[]{w.boneIndex0,w.boneIndex1,w.boneIndex2,w.boneIndex3};var values=new[]{w.weight0,w.weight1,w.weight2,w.weight3};var matrix=new Matrix4x4();
 for(int j=0;j<4;j++){if(values[j]<=0)continue;var bm=src.transform.worldToLocalMatrix*src.bones[indices[j]].localToWorldMatrix*bind[indices[j]];for(int k=0;k<16;k++)matrix[k]+=bm[k]*values[j];}
 Vector3 vertex=matrix.inverse.MultiplyPoint3x4(src.transform.InverseTransformPoint(root.transform.TransformPoint(p)));vertices.Add(vertex);ws.Add(w);
 if(death&&map!=null){int di=map[nearest];dvertices.Add(dv[di]+Quaternion.FromToRotation(mn[nearest],dn[di])*(vertex-mv[nearest]));dws.Add(death.sharedMesh.boneWeights[di]);}
 }
 MakeClean(src,pair.Key,vertices,ws,iron,edge);if(death&&map!=null)MakeClean(death,pair.Key,dvertices,dws,iron,edge);
 }
 }
 static void MakeClean(SkinnedMeshRenderer src,string name,List<Vector3> vertices,List<BoneWeight> weights,Material iron,Material edge){
 var mesh=new Mesh();mesh.name=name+"_"+src.name;mesh.SetVertices(vertices);mesh.boneWeights=weights.ToArray();mesh.bindposes=src.sharedMesh.bindposes;mesh.subMeshCount=2;mesh.SetTriangles(GridTris(5,17),0);
 var trim=new List<int>();for(int j=0;j<16;j++){int a=4*17+j,b=a+17;trim.AddRange(new[]{a,a+1,b,a+1,b+1,b});}mesh.SetTriangles(trim,1);mesh.RecalculateNormals();mesh.RecalculateBounds();
 var go=new GameObject("FrostEquipment_"+name);go.transform.SetParent(src.transform,false);var renderer=go.AddComponent<SkinnedMeshRenderer>();renderer.sharedMesh=SaveMesh(mesh,"Clean"+name+"_"+src.name);renderer.sharedMaterials=new[]{iron,edge};renderer.bones=src.bones;renderer.rootBone=src.rootBone;renderer.localBounds=src.localBounds;renderer.updateWhenOffscreen=true;renderer.enabled=src.enabled;
 }

 static Material Mat(string name,Color c,float metal,float smooth){string p=R+"/Equipment/"+name+".mat";var m=AssetDatabase.LoadAssetAtPath<Material>(p);if(!m){m=new Material(Shader.Find("Universal Render Pipeline/Lit"));AssetDatabase.CreateAsset(m,p);}m.color=c;m.SetColor("_BaseColor",c);m.SetFloat("_Cull",0);m.SetFloat("_Metallic",metal);m.SetFloat("_Smoothness",smooth);EditorUtility.SetDirty(m);return m;}
 static int[] Select(Mesh m,Func<int,bool> f){var t=m.triangles;var result=new List<int>();for(int i=0;i<t.Length;i+=3)if((f(t[i])?1:0)+(f(t[i+1])?1:0)+(f(t[i+2])?1:0)>=2){result.Add(t[i]);result.Add(t[i+1]);result.Add(t[i+2]);}return result.ToArray();}
 static int[] UVMap(Mesh a,Mesh b){var ua=a.uv;var ub=b.uv;var dict=new Dictionary<Vector2Int,int>();for(int i=0;i<ub.Length;i++)dict[new Vector2Int(Mathf.RoundToInt(ub[i].x*10000),Mathf.RoundToInt(ub[i].y*10000))]=i;var map=new int[ua.Length];for(int i=0;i<ua.Length;i++)if(!dict.TryGetValue(new Vector2Int(Mathf.RoundToInt(ua[i].x*10000),Mathf.RoundToInt(ua[i].y*10000)),out map[i]))return null;return map;}
 static void AddArmor(SkinnedMeshRenderer src,string name,int[] selected,int[] map,Material iron,Material edge){
 var m=src.sharedMesh;var verts=m.vertices;var normals=m.normals;var weights=m.boneWeights;var uv=m.uv;
 var vs=new List<Vector3>();var ws=new List<BoneWeight>();var uvs=new List<Vector2>();var triangles=new List<int>();var sides=new List<int>();var ids=new Dictionary<int,int>();var edges=new Dictionary<string,int[]>();
 Func<int,int> put=original=>{int idx=map==null?original:map[original];if(ids.TryGetValue(idx,out int result))return result;int start=vs.Count;ids[idx]=start;vs.Add(verts[idx]+normals[idx]*.055f);vs.Add(verts[idx]+normals[idx]*.035f);ws.Add(weights[idx]);ws.Add(weights[idx]);uvs.Add(uv[idx]);uvs.Add(uv[idx]);return start;};
 for(int i=0;i<selected.Length;i+=3){int a=put(selected[i]),b=put(selected[i+1]),c=put(selected[i+2]);triangles.AddRange(new[]{a,b,c,a+1,c+1,b+1});foreach(var e in new[]{new[]{a,b},new[]{b,c},new[]{c,a}}){string key=Mathf.Min(e[0],e[1])+"_"+Mathf.Max(e[0],e[1]);if(edges.ContainsKey(key))edges.Remove(key);else edges[key]=e;}}
 foreach(var e in edges.Values)sides.AddRange(new[]{e[0],e[0]+1,e[1],e[1],e[0]+1,e[1]+1});
 var shell=new Mesh();shell.name=name+"_"+src.name;shell.SetVertices(vs);shell.SetUVs(0,uvs);shell.boneWeights=ws.ToArray();shell.bindposes=m.bindposes;shell.subMeshCount=2;shell.SetTriangles(triangles,0);shell.SetTriangles(sides,1);shell.RecalculateNormals();shell.RecalculateBounds();
 var go=new GameObject("FrostEquipment_"+name);go.transform.SetParent(src.transform,false);var r=go.AddComponent<SkinnedMeshRenderer>();r.sharedMesh=SaveMesh(shell,name+"_"+src.name);r.bones=src.bones;r.rootBone=src.rootBone;r.sharedMaterials=new[]{iron,edge};r.localBounds=src.localBounds;r.updateWhenOffscreen=true;r.enabled=src.enabled;
 }
 static Mesh SaveMesh(Mesh mesh,string name){string p=R+"/Equipment/"+name+".asset";var old=AssetDatabase.LoadAssetAtPath<Mesh>(p);if(old){EditorUtility.CopySerialized(mesh,old);UnityEngine.Object.DestroyImmediate(mesh);return old;}AssetDatabase.CreateAsset(mesh,p);return mesh;}
 class Parts {
 List<Vector3> v=new List<Vector3>();List<int>[] t=Enumerable.Range(0,4).Select(_=>new List<int>()).ToArray();
 void Tri(Vector3 a,Vector3 b,Vector3 c,int mat){int n=v.Count;v.Add(a);v.Add(b);v.Add(c);t[mat].AddRange(new[]{n,n+1,n+2});}
 public void Prism(Vector2[] poly,float depth,int mat){Vector3[] a=poly.Select(p=>new Vector3(p.x,p.y,-depth/2)).ToArray(),b=poly.Select(p=>new Vector3(p.x,p.y,depth/2)).ToArray();for(int i=1;i<poly.Length-1;i++){Tri(a[0],a[i+1],a[i],mat);Tri(b[0],b[i],b[i+1],mat);}for(int i=0;i<poly.Length;i++){int j=(i+1)%poly.Length;Tri(a[i],a[j],b[j],mat);Tri(a[i],b[j],b[i],mat);}}
 public void Box(Vector3 c,Vector3 s,int mat){Prism(new[]{new Vector2(c.x-s.x/2,c.y-s.y/2),new Vector2(c.x+s.x/2,c.y-s.y/2),new Vector2(c.x+s.x/2,c.y+s.y/2),new Vector2(c.x-s.x/2,c.y+s.y/2)},s.z,mat);}
 public Mesh ToMesh(string name,Func<Vector3,Vector3> transform,int mats){var m=new Mesh();m.name=name;m.vertices=v.Select(transform).ToArray();m.subMeshCount=mats;for(int i=0;i<mats;i++)m.SetTriangles(t[i],i);m.RecalculateNormals();m.RecalculateBounds();return m;}
 }
 static void Preview(GameObject g,string pose,StringBuilder log){
 var animator=g.GetComponentInChildren<Animator>(true);var clips=animator&&animator.runtimeAnimatorController?animator.runtimeAnimatorController.animationClips:new AnimationClip[0];var clip=clips.FirstOrDefault(c=>c.name.IndexOf(pose,StringComparison.OrdinalIgnoreCase)>=0);
 var render=new PreviewRenderUtility();var copy=UnityEngine.Object.Instantiate(g);try{
 render.AddSingleGO(copy);if(clip){clip.SampleAnimation(copy,clip.length*.35f);log.AppendLine("Sampled "+clip.name);}foreach(var sync in copy.GetComponentsInChildren<FrostTrollEquipmentVisibility>(true))foreach(var a in sync.armor)if(a)a.enabled=sync.source.enabled;
 render.camera.transform.position=new Vector3(-2.7f,1.8f,3.5f);render.camera.transform.LookAt(new Vector3(0,.85f,0));render.camera.nearClipPlane=.01f;render.camera.farClipPlane=100;render.camera.fieldOfView=33;render.camera.clearFlags=CameraClearFlags.SolidColor;render.camera.backgroundColor=new Color(.11f,.13f,.16f);render.lights[0].intensity=2.5f;render.lights[0].transform.rotation=Quaternion.Euler(45,30,0);render.lights[1].intensity=1.5f;render.ambientColor=new Color(.35f,.35f,.35f);
 foreach(var rr in copy.GetComponentsInChildren<SkinnedMeshRenderer>(true))log.AppendLine(pose+" RENDER "+rr.name+" mesh="+rr.sharedMesh.name+" enabled="+rr.enabled+" active="+rr.gameObject.activeInHierarchy+" bounds="+rr.bounds.ToString("F3"));
 render.BeginPreview(new Rect(0,0,1000,1000),GUIStyle.none);render.Render(true);var tex=render.EndPreview();var rt=RenderTexture.GetTemporary(1000,1000,0);Graphics.Blit(tex,rt);var old=RenderTexture.active;RenderTexture.active=rt;var image=new Texture2D(1000,1000,TextureFormat.RGB24,false);image.ReadPixels(new Rect(0,0,1000,1000),0,0);image.Apply();File.WriteAllBytes(R+"/Backup~/FrostTroll_"+pose+".png",image.EncodeToPNG());RenderTexture.active=old;RenderTexture.ReleaseTemporary(rt);UnityEngine.Object.DestroyImmediate(image);
 }finally{render.Cleanup();}
 }
}








