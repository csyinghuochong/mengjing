using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public partial class UICodeSpawner
{
	public static void SpawnUICode(GameObject gameObject)
	{
		if (null == gameObject)
		{
			Debug.LogError("UICode Select GameObject is null!");
			return;
		}

		try
		{
			string folderPath = string.Empty;
			string uiName = gameObject.name;
			string csName = string.Empty;
			string startStr = string.Empty;
			string view = string.Empty;
			string scroll = string.Empty;
			if (uiName.StartsWith(UIPanelPrefix))
			{
				Debug.LogWarning($"----------开始生成Dlg{uiName} 相关代码 ----------");

				folderPath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UI/";
				csName = $"{gameObject.name}System.cs";
				startStr = "public static void RegisterUIEvent";
				view = "View.";

				Debug.LogWarning($"生成Dlg{uiName} 完毕!!!");
			}
			else if (uiName.StartsWith(CommonUIPrefix))
			{
				Debug.LogWarning($"-------- 开始生成子UI: {uiName} 相关代码 -------------");

				folderPath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIBehaviour/";
				csName = $"{gameObject.name}ViewSystem.cs";
				startStr = "private static void Awake";

				Debug.LogWarning($"生成子UI: {uiName} 完毕!!!");
			}
			else if (uiName.StartsWith(UIItemPrefix))
			{
				Debug.LogWarning($"-------- 开始生成滚动列表项: {uiName} 相关代码 -------------");

				folderPath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIItemBehaviour/";
				csName = $"{gameObject.name}ViewSystem.cs";
				startStr = "private static void Awake";
				scroll = "Scroll_";

				Debug.LogWarning($" 开始生成滚动列表项: {uiName} 完毕！！！");
			}
			else
			{
				Debug.LogError($"选择的预设物不属于 Dlg, 子UI，滚动列表项，请检查 {uiName}！！！！！！");
				return;
			}

			string[] files = Directory.GetFiles(folderPath, csName, SearchOption.AllDirectories);

			if (files.Length == 0)
			{
				Debug.LogError($"{folderPath} 中不存在 {csName} ！！！！！！");
				return;
			}

			Path2WidgetCachedDict?.Clear();
			Path2WidgetCachedDict = new Dictionary<string, List<Component>>();

			FindAllWidgets(gameObject.transform, "");


			Dictionary<string, string> reNameMap = new();

			string[] lines = File.ReadAllLines(files[0]);
			bool registerStart = false;
			using (StreamWriter writer = new StreamWriter(files[0]))
			{
				for (int i = 0; i < lines.Length; i++)
				{
					string trimmedLine = lines[i].TrimStart();

					if (!registerStart && trimmedLine.StartsWith(startStr))
					{
						registerStart = true;
					}

					if (registerStart)
					{
						foreach (var key in Path2WidgetCachedDict.Keys.ToList())
						{
							foreach (var info in Path2WidgetCachedDict[key])
							{
								Component widget = info;
								string strClassType = widget.GetType().ToString();
								string widgetName = widget.name + strClassType.Split('.').ToList().Last();

								if (strClassType != "UnityEngine.UI.Button")
								{
									continue;
								}

								if (lines[i].Contains($"self.{view}{widgetName}.AddListener"))
								{
									Path2WidgetCachedDict.Remove(key);

									string pattern = @"AddListener(?:Async)?\(([^;]+)\);?";

									Match match = Regex.Match(lines[i], pattern);

									if (match.Success)
									{
										// 获取括号内的内容
										string innerContent = match.Groups[1].Value.Trim();
										string methodName = null;
										string arguments = null;

										// 检查是否为直接传递方法名的形式 self.OnButtonActivty
										if (Regex.IsMatch(innerContent, @"^self\.\w+$"))
										{
											methodName = Regex.Match(innerContent, @"self\.(\w+)").Groups[1].Value;
										}
										else
										{
											// 匹配带有 lambda 表达式的情况
											Match methodMatch = Regex.Match(innerContent, @"self\.(\w+)\(([^)]*)\)");

											if (methodMatch.Success)
											{
												// 提取参数部分
												arguments = methodMatch.Groups[2].Value;

												// 检查方法是否后面有其他链式调用
												bool hasChainedCall = innerContent.Contains(").");

												if (string.IsNullOrWhiteSpace(arguments))
												{
													// 如果没有参数提取方法名
													methodName = methodMatch.Groups[1].Value;
												}
												else
												{
													break;
												}
											}
											else
											{
												break;
											}
										}

										if (string.IsNullOrWhiteSpace(arguments))
										{
											if (!reNameMap.ContainsKey(methodName) && methodName != $"On{key.Substring(2)}Button")
											{
												reNameMap.Add(methodName, $"On{key.Substring(2)}Button");

												string replace = lines[i].Replace(methodName, $"On{key.Substring(2)}Button");
												lines[i] = replace;
											}
										}
									}

									break;
								}
							}
						}

						if (trimmedLine == "}")
						{
							if (scroll != string.Empty)
							{
								writer.WriteLine($"            注意item的初始化放在Awake无效中，请放在刷新的方法中！！！");
							}

							foreach (var key in Path2WidgetCachedDict.Keys.ToList())
							{
								foreach (var info in Path2WidgetCachedDict[key])
								{
									Component widget = info;
									string strClassType = widget.GetType().ToString();
									string widgetName = widget.name + strClassType.Split('.').ToList().Last();

									if (strClassType != "UnityEngine.UI.Button")
									{
										continue;
									}

									writer.WriteLine($"            self.{view}{widgetName}.AddListener(self.On{key.Substring(2)}Button);");
									break;
								}
							}

							registerStart = false;
						}
					}

					foreach (var key in reNameMap.Keys.ToList())
					{
						if (lines[i].Contains($"{key}(this"))
						{
							string replace = lines[i].Replace(key, reNameMap[key]);
							lines[i] = replace;

							reNameMap.Remove(key);
						}
					}

					if (i == lines.Length - 2)
					{
						foreach (var key in Path2WidgetCachedDict.Keys.ToList())
						{
							foreach (var info in Path2WidgetCachedDict[key])
							{
								Component widget = info;
								string strClassType = widget.GetType().ToString();
								string widgetName = widget.name + strClassType.Split('.').ToList().Last();

								if (strClassType != "UnityEngine.UI.Button")
								{
									continue;
								}

								writer.WriteLine($"        public static void On{key.Substring(2)}Button(this {scroll}{gameObject.name} self)");
								writer.WriteLine("        {");
								writer.WriteLine("        }");
								break;
							}
						}
					}

					writer.WriteLine(lines[i]);
				}
			}

		}
		catch
		{
			Debug.LogError($"生成 {gameObject.name} 错误");
		}
		finally
		{
			Path2WidgetCachedDict?.Clear();
			Path2WidgetCachedDict = null;
		}
	}

	static public void SpawnEUICode(GameObject gameObject)
	{
		if (null == gameObject)
		{
			Debug.LogError("UICode Select GameObject is null!");
			return;
		}

		try
		{
			string uiName = gameObject.name;
			if (uiName.StartsWith(UIPanelPrefix))
			{
				Debug.LogWarning($"----------开始生成Dlg{uiName} 相关代码 ----------");
				SpawnDlgCode(gameObject);
				Debug.LogWarning($"生成Dlg{uiName} 完毕!!!");
				return;
			}
			else if(uiName.StartsWith(CommonUIPrefix))
			{
				Debug.LogWarning($"-------- 开始生成子UI: {uiName} 相关代码 -------------");
				SpawnSubUICode(gameObject);
				Debug.LogWarning($"生成子UI: {uiName} 完毕!!!");
				return;
			}
			else if (uiName.StartsWith(UIItemPrefix))
			{
				Debug.LogWarning($"-------- 开始生成滚动列表项: {uiName} 相关代码 -------------");
				SpawnLoopItemCode(gameObject);
				Debug.LogWarning($" 开始生成滚动列表项: {uiName} 完毕！！！");
				return;
			}
			Debug.LogError($"选择的预设物不属于 Dlg, 子UI，滚动列表项，请检查 {uiName}！！！！！！");
		}
		finally
		{
			Path2WidgetCachedDict?.Clear();
			Path2WidgetCachedDict = null;
		}
	}
	
	
    static public void SpawnDlgCode(GameObject gameObject)
    {
	    Path2WidgetCachedDict?.Clear();
        Path2WidgetCachedDict = new Dictionary<string, List<Component>>();
        
		FindAllWidgets(gameObject.transform, "");
		
        SpawnCodeForDlg(gameObject);
        SpawnCodeForDlgEventHandle(gameObject);
        SpawnCodeForDlgModel(gameObject);
        
        SpawnCodeForDlgBehaviour(gameObject);
        SpawnCodeForDlgComponentBehaviour(gameObject);
        
        AssetDatabase.Refresh();
    }
    
    static void SpawnCodeForDlg(GameObject gameObject)
    {
        string strDlgName  = gameObject.name;
        string strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UI/" + strDlgName ;
        
        
        if ( !Directory.Exists(strFilePath) )
        {
	        Directory.CreateDirectory(strFilePath);
        }
        
	    strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UI/" + strDlgName + "/" + strDlgName + "System.cs";
        if(File.Exists(strFilePath))
        {
            Debug.LogError("已存在 " + strDlgName + "System.cs,将不会再次生成。");
            return;
        }

        StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine("using System.Collections;")
                  .AppendLine("using System.Collections.Generic;")
                  .AppendLine("using System;")
                  .AppendLine("using UnityEngine;")
                  .AppendLine("using UnityEngine.UI;\r\n");

        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
        
        strBuilder.AppendFormat("\t[FriendOf(typeof({0}))]\r\n", strDlgName);
       
        strBuilder.AppendFormat("\tpublic static  class {0}\r\n", strDlgName + "System");
          strBuilder.AppendLine("\t{");
          strBuilder.AppendLine("");


        strBuilder.AppendFormat("\t\tpublic static void RegisterUIEvent(this {0} self)\n",strDlgName)
               .AppendLine("\t\t{")
               .AppendLine("\t\t ")
               .AppendLine("\t\t}")
               .AppendLine();


        strBuilder.AppendFormat("\t\tpublic static void ShowWindow(this {0} self, Entity contextData = null)\n", strDlgName);
        strBuilder.AppendLine("\t\t{");
          
        strBuilder.AppendLine("\t\t}")
	        .AppendLine();
        
        strBuilder.AppendLine("\t\t \r\n");
        
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");

        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }
    
    /// <summary>
    /// 自动生成WindowId代码
    /// </summary>
    /// <param name="gameObject"></param>
    static void SpawnWindowIdCode(GameObject gameObject)
    {
	    string strDlgName = gameObject.name;
	    string strFilePath = Application.dataPath + "/Scripts/ModelView/Client/Plugins/EUI/WindowId.cs";
	 
	    
	    if(!File.Exists(strFilePath))
	    {
		    Debug.LogError(" 当前不存在WindowId.cs!!!");
		    return;
	    }
	    
	    string originWindowIdContent = File.ReadAllText(strFilePath);
	    if (originWindowIdContent.Contains(strDlgName.Substring(3)))
	    {
		    return;
	    }
	    int windowIdEndIndex   = GetWindowIdEndIndex(originWindowIdContent);
	    originWindowIdContent  = originWindowIdContent.Insert(windowIdEndIndex, "\tWindowID_"+strDlgName.Substring(3) + ",\n\t");
	    File.WriteAllText(strFilePath, originWindowIdContent);
    }
    
    public static int GetWindowIdEndIndex(string content)
    {
	    Regex regex = new Regex("WindowID");
	    Match match = regex.Match(content);
	    Regex regex1 = new Regex("}");
	    MatchCollection matchCollection = regex1.Matches(content);
	    for (int i = 0; i < matchCollection.Count; i++)
	    {
		    if (matchCollection[i].Index > match.Index)
		    {
			    return matchCollection[i].Index;
		    }
	    }
	    return -1;
    }
    
	static void SpawnCodeForDlgEventHandle(GameObject gameObject)
    {
        string strDlgName = gameObject.name;
        string strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UI/" + strDlgName + "/Event" ;
        
        
        if ( !Directory.Exists(strFilePath) )
        {
	        Directory.CreateDirectory(strFilePath);
        }
        
	    strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UI/" + strDlgName + "/Event/" + strDlgName + "EventHandler.cs";
        if(File.Exists(strFilePath))
        {
	        Debug.LogError("已存在 " + strDlgName + ".cs,将不会再次生成。");
            return;
        }
        SpawnWindowIdCode(gameObject);
        StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
        StringBuilder strBuilder = new StringBuilder();
        
        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
        strBuilder.AppendLine("\t[FriendOf(typeof(UIBaseWindow))]");
        strBuilder.AppendFormat("\t[AUIEvent(WindowID.WindowID_{0})]\n",strDlgName.Substring(3));
        strBuilder.AppendFormat("\tpublic  class {0}EventHandler : IAUIEventHandler\r\n", strDlgName);
          strBuilder.AppendLine("\t{");
          strBuilder.AppendLine("");
          
          
          strBuilder.AppendLine("\t\tpublic void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)")
	          .AppendLine("\t\t{");

          strBuilder.AppendFormat("\t\t  uiBaseWindow.windowType = UIWindowType.Normal; \r\n");
          
          strBuilder.AppendLine("\t\t}")
	          .AppendLine();
          
          strBuilder.AppendLine("\t\tpublic void OnInitComponent(UIBaseWindow uiBaseWindow)")
            		.AppendLine("\t\t{");
          
          strBuilder.AppendFormat("\t\t  uiBaseWindow.AddComponent<{0}>().AddComponent<{1}ViewComponent>();\r\n",strDlgName,strDlgName);
          
          strBuilder.AppendLine("\t\t}")
            .AppendLine();
          
          strBuilder.AppendLine("\t\tpublic void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)")
	          .AppendLine("\t\t{");

          strBuilder.AppendFormat("\t\t  uiBaseWindow.GetComponent<{0}>().RegisterUIEvent(); \r\n",strDlgName);
          
          strBuilder.AppendLine("\t\t}")
	          .AppendLine();
          
          
          strBuilder.AppendLine("\t\tpublic void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)")
	          .AppendLine("\t\t{");
          strBuilder.AppendFormat("\t\t  uiBaseWindow.GetComponent<{0}>().ShowWindow(contextData); \r\n",strDlgName);
          strBuilder.AppendLine("\t\t}")
	          .AppendLine();

            
          strBuilder.AppendLine("\t\tpublic void OnHideWindow(UIBaseWindow uiBaseWindow)")
	          .AppendLine("\t\t{");
          
          strBuilder.AppendLine("\t\t}")
	          .AppendLine();
          
          
          strBuilder.AppendLine("\t\tpublic void BeforeUnload(UIBaseWindow uiBaseWindow)")
	          .AppendLine("\t\t{");
          
          strBuilder.AppendLine("\t\t}")
	          .AppendLine();
          
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");

        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }
    
	
	static void SpawnCodeForDlgModel(GameObject gameObject)
    {
        string strDlgName = gameObject.name;
        string strFilePath = Application.dataPath + "/Scripts/ModelView/Client/MengJing/UI/" + strDlgName  ;
        
        
        if ( !Directory.Exists(strFilePath) )
        {
	        Directory.CreateDirectory(strFilePath);
        }
        
	    strFilePath = Application.dataPath + "/Scripts/ModelView/Client/MengJing/UI/" + strDlgName  + "/" + strDlgName  + ".cs";
        if(File.Exists(strFilePath))
        {
	        Debug.LogError("已存在 " + strDlgName + ".cs,将不会再次生成。");
            return;
        }

        StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
        StringBuilder strBuilder = new StringBuilder();
        
        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
        strBuilder.AppendLine("\t [ComponentOf(typeof(UIBaseWindow))]");
       
        strBuilder.AppendFormat("\tpublic  class {0} :Entity,IAwake,IUILogic\r\n", strDlgName);
          strBuilder.AppendLine("\t{");
          strBuilder.AppendLine("");
          
	    strBuilder.AppendLine("\t\tpublic "+strDlgName+"ViewComponent View { get => this.GetComponent<"+ strDlgName +"ViewComponent>();} \r\n");
	    
        strBuilder.AppendLine("\t\t \r\n");
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");

        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }
    

    static void SpawnCodeForDlgBehaviour(GameObject gameObject)
    {
        if (null == gameObject)
        {
            return;
        }
        string strDlgName = gameObject.name ;
        string strDlgComponentName =  gameObject.name + "ViewComponent";

        string strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIBehaviour/" + strDlgName;

        if ( !Directory.Exists(strFilePath) )
        {
	        Directory.CreateDirectory(strFilePath);
        }
	    strFilePath = Application.dataPath + "/Scripts/HotfixView/Client/MengJing/UIBehaviour/" + strDlgName + "/" + strDlgComponentName + "System.cs";
	    
        StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

        
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine()
	        .AppendLine("using UnityEngine;");
        strBuilder.AppendLine("using UnityEngine.UI;");
        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
        
        strBuilder.AppendFormat("\t[EntitySystemOf(typeof({0}))]\r\n", strDlgComponentName);
        strBuilder.AppendFormat("\t[FriendOfAttribute(typeof(ET.Client.{0}))]\r\n", strDlgComponentName);
        strBuilder.AppendFormat("\tpublic static partial class {0}System\r\n", strDlgComponentName);
        strBuilder.AppendLine("\t{");
        strBuilder.AppendLine("\t\t[EntitySystem]");
        strBuilder.AppendFormat("\t\tprivate static void Awake(this {0} self)\n",strDlgComponentName);
        strBuilder.AppendLine("\t\t{");
        strBuilder.AppendLine("\t\t\tself.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;");
        strBuilder.AppendLine("\t\t}");
        strBuilder.AppendLine("\n");
        
        strBuilder.AppendLine("\t\t[EntitySystem]");
        strBuilder.AppendFormat("\t\tprivate static void Destroy(this {0} self)\n",strDlgComponentName);
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

    static void SpawnCodeForDlgComponentBehaviour(GameObject gameObject)
    {
	    if (null == gameObject)
	    {
		    return;
	    }
	    string strDlgName = gameObject.name ;
	    string strDlgComponentName =  gameObject.name + "ViewComponent";


	    string strFilePath = Application.dataPath + "/Scripts/ModelView/Client/MengJing/UIBehaviour/" + strDlgName;
	    if ( !Directory.Exists(strFilePath) )
	    {
		    Directory.CreateDirectory(strFilePath);
	    }
	    strFilePath = Application.dataPath + "/Scripts/ModelView/Client/MengJing/UIBehaviour/" + strDlgName + "/" + strDlgComponentName + ".cs";
	    StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
	    StringBuilder strBuilder = new StringBuilder();
	    strBuilder.AppendLine()
		    .AppendLine("using UnityEngine;");
	    strBuilder.AppendLine("using UnityEngine.UI;");
	    strBuilder.AppendLine("namespace ET.Client");
	    strBuilder.AppendLine("{");
	    strBuilder.AppendLine($"\t[ComponentOf(typeof({strDlgName}))]");
	    strBuilder.AppendLine("\t[EnableMethod]");
	    strBuilder.AppendFormat("\tpublic  class {0} : Entity,IAwake,IDestroy \r\n", strDlgComponentName)
		    .AppendLine("\t{");
     
	    CreateWidgetBindCode(ref strBuilder, gameObject.transform);

	    CreateDestroyWidgetCode(ref strBuilder);
	    
	    CreateDeclareCode(ref strBuilder);
	    strBuilder.AppendFormat("\t\tpublic Transform uiTransform = null;\r\n");
	    strBuilder.AppendLine("\t}");
	    strBuilder.AppendLine("}");
        
	    sw.Write(strBuilder);
	    sw.Flush();
	    sw.Close();
    }


    public static void CreateDestroyWidgetCode( ref StringBuilder strBuilder,bool isScrollItem = false)
    {
	    strBuilder.AppendFormat("\t\tpublic void DestroyWidget()");
	    strBuilder.AppendLine("\n\t\t{");
	    CreateDlgWidgetDisposeCode(ref strBuilder);
	    strBuilder.AppendFormat("\t\t\tthis.uiTransform = null;\r\n");
	    if (isScrollItem)
	    {
		    strBuilder.AppendLine("\t\t\tthis.DataId = 0;");
	    }
	    strBuilder.AppendLine("\t\t}\n");
    }
    
    
    public static void CreateDlgWidgetDisposeCode(ref StringBuilder strBuilder,bool isSelf = false)
    {
	    string pointStr = isSelf ? "self" : "this";
	    foreach (KeyValuePair<string, List<Component>> pair in Path2WidgetCachedDict)
	    {
		    foreach (var info in pair.Value)
		    {
			    Component widget = info;
			    string strClassType = widget.GetType().ToString();
		   
			    if (pair.Key.StartsWith(CommonUIPrefix))
			    {
				    strBuilder.AppendFormat("\t\t	{0}.m_{1} = null;\r\n", pointStr,pair.Key.ToLower());
				    continue;
			    }
			    
			    string widgetName = widget.name + strClassType.Split('.').ToList().Last();
			    strBuilder.AppendFormat("\t\t	{0}.m_{1} = null;\r\n", pointStr,widgetName);
		    }
		 
	    }

	 
    }

    public static void CreateWidgetBindCode(ref StringBuilder strBuilder, Transform transRoot)
    {
        foreach (KeyValuePair<string, List<Component>> pair in Path2WidgetCachedDict)
        {
	        foreach (var info in pair.Value)
	        {
		        Component widget = info;
				string strPath = GetWidgetPath(widget.transform, transRoot);
				string strClassType = widget.GetType().ToString();
				string strInterfaceType = strClassType;
				
				if (pair.Key.StartsWith(CommonUIPrefix) && transRoot.gameObject.name.StartsWith(UIItemPrefix))
				{
					var subUIClassPrefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource(widget);
					if (subUIClassPrefab==null)
					{
						Debug.LogError($"公共UI找不到所属的Prefab! {pair.Key}");
						return;
					}
					GetSubUIBaseWindowCode_2(ref strBuilder, pair.Key,strPath,subUIClassPrefab.name);
					continue;
				}
				
				if (pair.Key.StartsWith(CommonUIPrefix))
				{
					var subUIClassPrefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource(widget);
					if (subUIClassPrefab == null)
					{
						// Debug.LogError($"公共UI找不到所属的Prefab! {pair.Key}");
						// return;
						string[] parts = pair.Key.Split('_');
						string type = "";
						if (parts.Length >= 2)
						{
							type = parts[0] + "_" + parts[1];
						}
						else
						{
							type = pair.Key;
						}
						GetSubUIBaseWindowCode(ref strBuilder, pair.Key, strPath, type);
					}
					else
					{
						GetSubUIBaseWindowCode(ref strBuilder, pair.Key, strPath, subUIClassPrefab.name);
					}
					
					continue;
				}
				string widgetName = widget.name + strClassType.Split('.').ToList().Last();
				
				
				strBuilder.AppendFormat("		public {0} {1}\r\n", strInterfaceType, widgetName);
				strBuilder.AppendLine("     	{");
				strBuilder.AppendLine("     		get");
				strBuilder.AppendLine("     		{");
				
				strBuilder.AppendLine("     			if (this.uiTransform == null)");
				strBuilder.AppendLine("     			{");
				strBuilder.AppendLine("     				Log.Error(\"uiTransform is null.\");");
				strBuilder.AppendLine("     				return null;");
				strBuilder.AppendLine("     			}");

				if (transRoot.gameObject.name.StartsWith(UIItemPrefix))
				{
					strBuilder.AppendLine("     			if (this.isCacheNode)");
					strBuilder.AppendLine("     			{");
					strBuilder.AppendFormat("     				if( this.m_{0} == null )\n" , widgetName);
					strBuilder.AppendLine("     				{");
					strBuilder.AppendFormat("		    			this.m_{0} = UIFindHelper.FindDeepChild<{2}>(this.uiTransform.gameObject,\"{1}\");\r\n", widgetName, strPath, strInterfaceType);
					strBuilder.AppendLine("     				}");
					strBuilder.AppendFormat("     				return this.m_{0};\n" , widgetName);
					strBuilder.AppendLine("     			}");
					strBuilder.AppendLine("     			else");
					strBuilder.AppendLine("     			{");
					strBuilder.AppendFormat("		    		return UIFindHelper.FindDeepChild<{2}>(this.uiTransform.gameObject,\"{1}\");\r\n", widgetName, strPath, strInterfaceType);
					strBuilder.AppendLine("     			}");
				}
				else
				{
					strBuilder.AppendFormat("     			if( this.m_{0} == null )\n" , widgetName);
					strBuilder.AppendLine("     			{");
					strBuilder.AppendFormat("		    		this.m_{0} = UIFindHelper.FindDeepChild<{2}>(this.uiTransform.gameObject,\"{1}\");\r\n", widgetName, strPath, strInterfaceType);
					strBuilder.AppendLine("     			}");
					strBuilder.AppendFormat("     			return this.m_{0};\n" , widgetName);
				}
				
	            strBuilder.AppendLine("     		}");
	            strBuilder.AppendLine("     	}\n");
	        }
        }
    }
    
    public static void CreateDeclareCode(ref StringBuilder strBuilder)
    {
	    foreach (KeyValuePair<string,List<Component> > pair in Path2WidgetCachedDict)
	    {
		    foreach (var info in pair.Value)
		    {
			    Component widget = info;
			    string strClassType = widget.GetType().ToString();

			    if (pair.Key.StartsWith(CommonUIPrefix))
			    {
				    var subUIClassPrefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource(widget);
				    if (subUIClassPrefab == null)
				    {
					    // Debug.LogError($"公共UI找不到所属的Prefab! {pair.Key}");
					    // return;
					    string[] parts = pair.Key.Split('_');
					    string type = "";
					    if (parts.Length >= 2)
					    {
						    type = parts[0] + "_" + parts[1];
					    }
					    else
					    {
						    type = pair.Key;
					    }
					    strBuilder.AppendFormat("\t\tprivate EntityRef<{0}> m_{1} = null;\r\n", type, pair.Key.ToLower());
				    }
				    else
				    {
					    strBuilder.AppendFormat("\t\tprivate EntityRef<{0}> m_{1} = null;\r\n", subUIClassPrefab.name, pair.Key.ToLower());
				    }
				    
				    continue;
			    }

			     string widgetName = widget.name + strClassType.Split('.').ToList().Last();
			    strBuilder.AppendFormat("\t\tprivate {0} m_{1} = null;\r\n", strClassType, widgetName);
		    }
		    
	    }
    }

    public static void FindAllWidgets(Transform trans, string strPath)
	{
		if (null == trans)
		{
			return;
		}
		for (int nIndex= 0; nIndex < trans.childCount; ++nIndex)
		{
			Transform child = trans.GetChild(nIndex);
			string strTemp = strPath+"/"+child.name;
			
		
			bool isSubUI = child.name.StartsWith(CommonUIPrefix);
			if (isSubUI || child.name.StartsWith(UIGameObjectPrefix))
			{
				List<Component> rectTransfomrComponents = new List<Component>(); 
				rectTransfomrComponents.Add(child.GetComponent<RectTransform>());
				Path2WidgetCachedDict.Add(child.name,rectTransfomrComponents);
			}
			else if (child.name.StartsWith(UIWidgetPrefix))
			{
				foreach (var uiComponent in WidgetInterfaceList)
				{
					Component component = child.GetComponent(uiComponent);
					if (null == component)
					{
						continue;
					}
					
					if ( Path2WidgetCachedDict.ContainsKey(child.name)  )
					{
						Path2WidgetCachedDict[child.name].Add(component);
						continue;
					}
					
					List<Component> componentsList = new List<Component>(); 
					componentsList.Add(component);
					Path2WidgetCachedDict.Add(child.name, componentsList);
				}
			}
		
			if (isSubUI)
			{
				Debug.Log($"遇到子UI：{child.name},不生成子UI项代码");
				continue;
			}
			FindAllWidgets(child, strTemp);
		}
	}

    static string GetWidgetPath(Transform obj, Transform root)
    {
        string path = obj.name;

        while (obj.parent != null && obj.parent != root)
        {
            obj = obj.transform.parent;
            path = obj.name + "/" + path;
        }
        return path;
    }


    static void GetSubUIBaseWindowCode(ref StringBuilder strBuilder,string widget,string strPath, string subUIClassType)
    {
	    
	    strBuilder.AppendFormat("		public {0} {1}\r\n", subUIClassType, widget );
	    strBuilder.AppendLine("     	{");
	    strBuilder.AppendLine("     		get");
	    strBuilder.AppendLine("     		{");
			
	    strBuilder.AppendLine("     			if (this.uiTransform == null)");
	    strBuilder.AppendLine("     			{");
	    strBuilder.AppendLine("     				Log.Error(\"uiTransform is null.\");");
	    strBuilder.AppendLine("     				return null;");
	    strBuilder.AppendLine("     			}");

	    strBuilder.AppendFormat("     			{0} es = this.m_{1};\n", subUIClassType, widget.ToLower());
	    strBuilder.AppendLine("     			if( es == null )\n");
	    strBuilder.AppendLine("     			{");
	    strBuilder.AppendFormat("		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,\"{0}\");\r\n",  strPath);
	    strBuilder.AppendFormat("		    	   this.m_{0} = this.AddChild<{1},Transform>(subTrans);\r\n", widget.ToLower(),subUIClassType);
	    strBuilder.AppendLine("     			}");
	    strBuilder.AppendFormat("     			return this.m_{0};\n" , widget.ToLower());
	    strBuilder.AppendLine("     		}");
	    
	    
	    
	    strBuilder.AppendLine("     	}\n");
    }
    
    static void GetSubUIBaseWindowCode_2(ref StringBuilder strBuilder,string widget,string strPath, string subUIClassType)
    {
	    
	    strBuilder.AppendFormat("		public {0} {1}\r\n", subUIClassType, widget );
	    strBuilder.AppendLine("     	{");
	    strBuilder.AppendLine("     		get");
	    strBuilder.AppendLine("     		{");
			
	    strBuilder.AppendLine("     			if (this.uiTransform == null)");
	    strBuilder.AppendLine("     			{");
	    strBuilder.AppendLine("     				Log.Error(\"uiTransform is null.\");");
	    strBuilder.AppendLine("     				return null;");
	    strBuilder.AppendLine("     			}");
	    
	    strBuilder.AppendFormat("		    	{0} es = this.m_{1};\r\n", subUIClassType, widget.ToLower());
	    strBuilder.AppendLine("     			if (this.isCacheNode)");
	    strBuilder.AppendLine("     			{");
	    strBuilder.AppendLine("     				if( es == null )\n");
	    strBuilder.AppendLine("     				{");
	    strBuilder.AppendFormat("		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,\"{0}\");\r\n",  strPath);
	    strBuilder.AppendFormat("		    			this.m_{0} = this.AddChild<{1},Transform>(subTrans);\r\n", widget.ToLower(),subUIClassType);
	    strBuilder.AppendLine("     				}");
	    strBuilder.AppendFormat("     				return this.m_{0};\n" , widget.ToLower());
	    strBuilder.AppendLine("     			}");
	    strBuilder.AppendLine("     			else");
	    strBuilder.AppendLine("     			{");
	    strBuilder.AppendLine("     				if( es != null )\n");
	    strBuilder.AppendLine("     				{");
	    strBuilder.AppendFormat("		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,\"{0}\");\r\n",  strPath);
	    strBuilder.AppendFormat("		    			es = this.m_{0};\r\n", widget.ToLower());
	    strBuilder.AppendLine("     					if( es.UITransform != subTrans )");
	    strBuilder.AppendLine("     					{");
	    strBuilder.AppendLine("     						es.Dispose();");
	    strBuilder.AppendFormat("		    				this.m_{0} = null;\r\n", widget.ToLower());
	    strBuilder.AppendFormat("		    				this.m_{0} = this.AddChild<{1},Transform>(subTrans);\r\n", widget.ToLower(),subUIClassType);
	    strBuilder.AppendLine("     					}");
	    strBuilder.AppendLine("     				}");
	    strBuilder.AppendLine("     				else");
	    strBuilder.AppendLine("     				{");
	    strBuilder.AppendFormat("		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,\"{0}\");\r\n",  strPath);
	    strBuilder.AppendFormat("		    			this.m_{0} = this.AddChild<{1},Transform>(subTrans);\r\n", widget.ToLower(),subUIClassType);
	    strBuilder.AppendLine("     				}");
	    strBuilder.AppendFormat("     				return this.m_{0};\n" , widget.ToLower());
	    strBuilder.AppendLine("     			}");
	    strBuilder.AppendLine("     		}");
	    strBuilder.AppendLine("     	}\n");
    }
    

    static UICodeSpawner()
    {
        WidgetInterfaceList = new List<string>();        
        WidgetInterfaceList.Add("Button");
        WidgetInterfaceList.Add( "Text");
        WidgetInterfaceList.Add("TMPro.TextMeshProUGUI");
        WidgetInterfaceList.Add("Input");
        WidgetInterfaceList.Add("InputField");
        WidgetInterfaceList.Add( "Scrollbar");
        WidgetInterfaceList.Add("ToggleGroup");
        WidgetInterfaceList.Add("Toggle");
        WidgetInterfaceList.Add("Dropdown");
        WidgetInterfaceList.Add("Slider");
        WidgetInterfaceList.Add("ScrollRect");
        WidgetInterfaceList.Add( "Image");
        WidgetInterfaceList.Add("RawImage");
        WidgetInterfaceList.Add("Canvas");
        WidgetInterfaceList.Add("UIWarpContent");
        WidgetInterfaceList.Add("LoopVerticalScrollRect");
        WidgetInterfaceList.Add("LoopHorizontalScrollRect");
        WidgetInterfaceList.Add("UnityEngine.EventSystems.EventTrigger");
    }

    private static Dictionary<string, List<Component> > Path2WidgetCachedDict =null;
    private static List<string> WidgetInterfaceList = null;
    private const string CommonUIPrefix = "ES";
    private const string UIPanelPrefix  = "Dlg";
    private const string UIWidgetPrefix = "E";
    private const string UIGameObjectPrefix = "EG";
    private const string UIItemPrefix = "Item";
}

