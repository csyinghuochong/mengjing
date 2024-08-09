using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public partial class UICodeSpawner
{
    static public void SpawnSubUICode(GameObject gameObject)
    {
      
        Path2WidgetCachedDict?.Clear();
        Path2WidgetCachedDict = new Dictionary<string, List<Component>>();
        FindAllWidgets(gameObject.transform, "");
        SpawnCodeForSubUI(gameObject);
        SpawnCodeForSubUIBehaviour(gameObject);
        AssetDatabase.Refresh();
    }
    
    static void SpawnCodeForSubUI(GameObject objPanel)
    {
        if (null == objPanel)
        {
            return;
        }
        string strDlgName = objPanel.name;
        
        string strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIBehaviour/CommonUI";
        if (!Directory.Exists(strFilePath))
        {
            Directory.CreateDirectory(strFilePath);
        }
        
        // 有些ES移动到对应的Dlg下了，所以不一定在CommonUI文件夹下
        string[] files = Directory.GetFiles(Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIBehaviour", strDlgName + "ViewSystem.cs", SearchOption.AllDirectories);
        if ( files.Length  != 0)
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
        strBuilder.AppendFormat("\t[EntitySystemOf(typeof({0}))]\n",strDlgName);
        strBuilder.AppendFormat("\t[FriendOfAttribute(typeof({0}))]\n",strDlgName);
        strBuilder.AppendFormat("\tpublic static partial class {0}System \r\n", strDlgName, strDlgName);
        strBuilder.AppendLine("\t{");
        strBuilder.AppendLine("\t\t[EntitySystem]");
        strBuilder.AppendFormat("\t\tprivate static void Awake(this {0} self,Transform transform)\n",strDlgName);
        strBuilder.AppendLine("\t\t{");
        strBuilder.AppendLine("\t\t\tself.uiTransform = transform;");
        strBuilder.AppendLine("\t\t}\n");
        
        
        strBuilder.AppendLine("\t\t[EntitySystem]");
        strBuilder.AppendFormat("\t\tprivate static void Destroy(this {0} self)\n",strDlgName);
        strBuilder.AppendLine("\t\t{");
        strBuilder.AppendLine("\t\t\tself.DestroyWidget();");
        strBuilder.AppendLine("\t\t}");
        
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("\n");
        strBuilder.AppendLine("}");
        
        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }
    
    static void SpawnCodeForSubUIBehaviour(GameObject objPanel)
    {
        if (null == objPanel)
        {
            return;
        }
        string strDlgName = objPanel.name;

        string strFilePath = Application.dataPath + "/Scripts/ModelView/Client/MengJing/UIBehaviour/CommonUI";

        if (!Directory.Exists(strFilePath))
        {
            Directory.CreateDirectory(strFilePath);
        }

        // 有些ES移动到对应的Dlg下了，所以不一定在CommonUI文件夹下
        string[] files = Directory.GetFiles(Application.dataPath + "/Scripts/ModelView/Client/MengJing/UIBehaviour", strDlgName + ".cs", SearchOption.AllDirectories);
        if ( files.Length  != 0)
        {
            strFilePath = files[0];
        }
        else
        {
            strFilePath = strFilePath + "/" + strDlgName + ".cs";
        }
	    
        StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine()
            .AppendLine("using UnityEngine;");
        strBuilder.AppendLine("using UnityEngine.UI;");
        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
	strBuilder.AppendLine("\t[ChildOf]");
        strBuilder.AppendLine("\t[EnableMethod]");
        strBuilder.AppendFormat("\tpublic  class {0} : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy \r\n", strDlgName)
            .AppendLine("\t{");
        
        
        CreateWidgetBindCode(ref strBuilder, objPanel.transform);
        strBuilder.AppendLine("		    public Transform UITransform");
        strBuilder.AppendLine("         {");
        strBuilder.AppendLine("     	    get");
        strBuilder.AppendLine("     	    {");
        strBuilder.AppendLine("     		    return this.uiTransform;");
        strBuilder.AppendLine("     	    }");
        strBuilder.AppendLine("     	    set");
        strBuilder.AppendLine("     	    {");
        strBuilder.AppendLine("     		    this.uiTransform = value;");
        strBuilder.AppendLine("     	    }");
        strBuilder.AppendLine("         }");
        strBuilder.AppendLine();
        
        CreateDestroyWidgetCode(ref strBuilder);
        CreateDeclareCode(ref strBuilder);
        strBuilder.AppendLine("\t\tpublic Transform uiTransform = null;");
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");
        
        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }
}
