# 组件绑定

- 需要绑定的UI组件（Image、Button等）以E_开头
- 需要绑定的空组件（没有添加任何UI组件）以EG_开头

# 窗口UI

- 以Dlg为开头，放入Assets/Bundles/UI/Dlg目录
- 需添加Canvas、GraphicRaycaster、UILayerScript组件
- 拼好UI预设物，选择UI物体右键点击SpawnEUICode选项生成UI绑定代码

图例：

![屏幕截图 2024-08-14 135301](Images\屏幕截图 2024-08-14 135301.png)

```C#
   // 假设UI名为DlgXXX
    
   // 打开窗口UI
   await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_XXX);
   
   // 关闭窗口UI
   self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_XXX);
   
   // 获取窗口UI
   DlgXXX dlg =  self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgXXX>();
   
   // 代码结构
   // DlgXXX.cs 中定义字段
   
   // DlgXXXSystem.cs 中写逻辑
   // ！！！引用绑定的物体 self.View！！！
   // 如：
   public static void RegisterUIEvent(this DlgXXX self)
   {
       // 注册
       self.View.E_TestButton.AddListener(self.OnTestButton);
   }

   public static void ShowWindow(this DlgXXX self, Entity contextData = null)
   {
       // 打开UI时执行的
       self.View.E_TestButton.gameObject.SetActive(true);
   }
   
   public static void OnTestButton(this DlgXXX self)
   {
       Log.Debug("111");
   }
```

# 公共UI

- 以ES_为开头，放入Assets/Bundles/UI/Common目录
- 拼好UI预设物，选择UI物体右键点击SpawnEUICode选项生成UI绑定代码

图例：
![屏幕截图 2024-08-14 142238](Images\屏幕截图 2024-08-14 142238.png)

```C#
   // 假设UI名为ES_XXX
    
   // 代码结构
   // ES_XXX.cs 中定义字段
   
   // ES_XXXSystem.cs 中写逻辑
   // 如：
   public static void Awake(this ES_XXX self, Transform transform)
   {
       self.E_TestButton.AddListener(self.OnTestButton);
       self.E_TestButton.gameObject.SetActive(true);
   }

   public static void OnTestButton(this ES_XXX self)
   {
       Log.Debug("111");
   }
```

# 循环列表

- Item以Item_为开头，放入Assets/Bundles/UI/Item目录
- 拼好UI预设物，选择UI物体右键点击SpawnEUICode选项生成UI绑定代码
