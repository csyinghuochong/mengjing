#if UNITY_EDITOR
using System;using System.IO;using System.Linq;using UnityEngine;using UnityEditor;using UnityEditor.SceneManagement;
public static partial class Extension05Tools{
static void RuinAuditFinal(){var s=Load("10005a");var all=All(s);ground=all.Select(t=>t.GetComponent<Terrain>()).First(t=>t&&t.gameObject.activeInHierarchy);var root=all.First(t=>t.name=="10005a_Ruin_Identity_Pass");var lines=new System.Collections.Generic.List<string>();foreach(var t in root.GetComponentsInChildren<Transform>().Where(t=>t.parent!=root&&t.GetComponentsInChildren<Renderer>().Length>0)){if(!t.parent||t.parent.parent!=root)continue;lines.Add(t.name+" pos="+t.position+" bounds="+B(t.gameObject));}foreach(var v in new[]{new Vector2(17.6f,27.2f),new Vector2(74.4f,85.2f),new Vector2(88.9f,87.6f),new Vector2(23.1f,50)}){lines.Add("AREA "+v);for(float z=v.y-5;z<=v.y+5;z+=2)for(float x=v.x-5;x<=v.x+5;x+=2){var p=G(x,z);if(p.y<6)lines.Add(" Lowground="+p);}}File.WriteAllLines(W+"/work/ruin-audit.txt",lines);Shot(s,"Ruins_Top",new Vector3(50,150,49),new Vector3(50,3,50),54);}

}
#endif


