#if UNITY_EDITOR
using UnityEngine;using UnityEditor;using UnityEditor.SceneManagement;using UnityEngine.SceneManagement;using System;using System.IO;using System.Linq;
[InitializeOnLoad] public static class Inspect01aExtension{
static string W=@"C:\Users\Administrator.DESKTOP-0DOPE9C\Documents\Codex\2026-11-02\10005a-10001-10001-boss";
static Inspect01aExtension(){EditorApplication.delayCall+=Run;}
static void Run(){if(!File.Exists(W+"/work/inspect.flag"))return;File.Delete(W+"/work/inspect.flag");try{var lines=new System.Collections.Generic.List<string>();foreach(var id in new[]{"10001a","10005a"}){string p="Assets/Bundles/Scenes/"+id+".unity";var s=SceneManager.GetSceneByPath(p);bool opened=!s.IsValid()||!s.isLoaded;if(opened)s=EditorSceneManager.OpenScene(p,OpenSceneMode.Additive);foreach(var t in s.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<Transform>(true))){if(id=="10001a"&&!System.Text.RegularExpressions.Regex.IsMatch(t.name,"Cliff|Grass|Stone|Rock|Terrain|Mountain"))continue;var rr=t.GetComponentsInChildren<Renderer>();var b=new Bounds(t.position,Vector3.zero);if(rr.Length>0){b=rr[0].bounds;foreach(var r in rr)b.Encapsulate(r.bounds);}lines.Add(id+"|"+t.name+"|"+t.position+"|"+b.size+"|"+t.gameObject.activeInHierarchy+"|"+PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(t.gameObject));}if(opened)EditorSceneManager.CloseScene(s,true);}File.WriteAllLines(W+"/work/inspection01a.txt",lines);}catch(Exception e){File.WriteAllText(W+"/work/error.txt",e.ToString());}}
}
#endif

