﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public partial class UICodeSpawner
{
    static public void SpawnLoopItemCode(GameObject gameObject)
    {
        Path2WidgetCachedDict?.Clear();
        Path2WidgetCachedDict = new Dictionary<string, List<Component>>();
        FindAllWidgets(gameObject.transform, "");
        SpawnCodeForScrollLoopItemBehaviour(gameObject);
        SpawnCodeForScrollLoopItemViewSystem(gameObject);
        AssetDatabase.Refresh();
    }
    
    static void SpawnCodeForScrollLoopItemViewSystem(GameObject gameObject)
    {
        if (null == gameObject)
        {
            return;
        }
        string strDlgName = gameObject.name;

        string strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIItemBehaviour";

        if (!Directory.Exists(strFilePath))
        {
            Directory.CreateDirectory(strFilePath);
        }
        
        string[] files = Directory.GetFiles(Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIItemBehaviour", strDlgName + "ViewSystem.cs", SearchOption.AllDirectories);
        if (files.Length != 0)
        {
            // 存在的话，就不用再从新生成
            return;
        }

        strFilePath = strFilePath + "/" + strDlgName + "ViewSystem.cs";
        StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine()
            .AppendLine("using UnityEngine;");
        strBuilder.AppendLine("using UnityEngine.UI;");
        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
        
        
        strBuilder.AppendFormat("\t[EntitySystemOf(typeof(Scroll_{0}))]\n",strDlgName);
        strBuilder.AppendFormat("\tpublic static partial class Scroll_{0}System \r\n", strDlgName);
        strBuilder.AppendLine("\t{");
        
        strBuilder.AppendLine("\t\t[EntitySystem]");
        strBuilder.AppendFormat("\t\tprivate static void Awake(this Scroll_{0} self )",strDlgName);
        strBuilder.AppendLine("\n\t\t{");
        
        strBuilder.AppendLine("\t\t}\n");
        
        
        strBuilder.AppendLine("\t\t[EntitySystem]");
        strBuilder.AppendFormat("\t\tprivate static void Destroy(this Scroll_{0} self )",strDlgName);
        strBuilder.AppendLine("\n\t\t{");
        
        strBuilder.AppendFormat("\t\t\tself.DestroyWidget();\r\n");

        strBuilder.AppendLine("\t\t}");
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");
        
        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }
    
    
    static void SpawnCodeForScrollLoopItemBehaviour(GameObject gameObject)
    {
        if (null == gameObject)
        {
            return;
        }
        string strDlgName = gameObject.name;

        string strFilePath = Application.dataPath + "/Scripts/ModelView/Client/MengJing/UIItemBehaviour";

        if ( !Directory.Exists(strFilePath) )
        {
            Directory.CreateDirectory(strFilePath);
        }
        strFilePath     = Application.dataPath + "/Scripts/ModelView/Client/MengJing/UIItemBehaviour/" + strDlgName + ".cs";
        StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine()
            .AppendLine("using UnityEngine;");
        strBuilder.AppendLine("using UnityEngine.UI;");
        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
        strBuilder.AppendLine("\t[EnableMethod]");
        strBuilder.AppendFormat("\tpublic  class Scroll_{0} : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_{0}> \r\n", strDlgName)
            .AppendLine("\t{");
        
        strBuilder.AppendLine("\t\tpublic long DataId {get;set;}");
        
        strBuilder.AppendLine("\t\tprivate bool isCacheNode = false;");
        strBuilder.AppendLine("\t\tpublic void SetCacheMode(bool isCache)");
        strBuilder.AppendLine("\t\t{");
        strBuilder.AppendLine("\t\t\tthis.isCacheNode = isCache;");
        strBuilder.AppendLine("\t\t}\n");
        strBuilder.AppendFormat("\t\tpublic Scroll_{0} BindTrans(Transform trans)\r\n",strDlgName);
        strBuilder.AppendLine("\t\t{");
        strBuilder.AppendLine("\t\t\tthis.uiTransform = trans;");
        strBuilder.AppendLine("\t\t\treturn this;");
        strBuilder.AppendLine("\t\t}\n");
        
        CreateWidgetBindCode(ref strBuilder, gameObject.transform);
        CreateDestroyWidgetCode(ref strBuilder,true);
        CreateDeclareCode(ref strBuilder);
        
        strBuilder.AppendLine("\t\tpublic Transform uiTransform = null;");
        
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");
        
        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }

}
