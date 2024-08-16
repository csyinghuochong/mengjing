# 组件绑定

- 需要绑定的UI组件（Image、Button等）以E_开头
- 需要绑定的空组件（没有添加任何UI组件）以EG_开头
- UI组件命名：E_ + 名字 + 后缀（Txt、Btn、Input、Img、Tgl、Panel等），如 E_EnterBtn、E_IconImg
- 回调方法命名：On + 组件名(不要前缀E_) + 行为(可加)，如 OnEnterBtn、OnIconImgBeginDrag、OnIconImgDrag

# ToggleGroup

- Toggle 的父物体要添加 ToggleGroup

![屏幕截图 2024-08-14 151602](Images\屏幕截图 2024-08-14 151602.png)

- Toggle 的子物体必须有 Background/XuanZhong 和 Background/WeiXuanZhong （选中时激活XuanZhong，未选中时激活WeiXuanZhong）

- Toggle 组件添加引用

![屏幕截图 2024-08-14 151717](Images\屏幕截图 2024-08-14 151717.png)

```C#

    public static void RegisterUIEvent(this DlgPet self)
    {
        // 注册点击回调
        self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
    }

    public static void ShowWindow(this DlgPet self, Entity contextData = null)
    {
        // 点击第一个Toggle
        self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
    }

    private static void OnFunctionSetBtn(this DlgPet self, int index)
    {
        // 隐藏所有子物体
        CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
        switch (index)
        {
            case 0:
                self.View.ES_PetList.uiTransform.gameObject.SetActive(true);
                self.View.ES_PetList.OnUpdateUI();
                break;
            case 1:
                self.View.ES_PetHeCheng.uiTransform.gameObject.SetActive(true);
                self.View.ES_PetHeCheng.OnUpdateUI();
                break;
        }
    }
```

# Button

```C#
    // 注册 区别：AddListenerAsync注册异步方法，方法没执行完的话所有注册了异步方法的按钮点击无效
    self.View.E_ShrinkButton.AddListener(self.OnShrinkButton);
    self.View.E_RoseEquipButton.AddListenerAsync(self.OnRoseEquipButton);
```

# EventTrigger

```C#
    // 注册
    self.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
```

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
- 非Grid的话要加上Layout Element组件，设置宽高
- 拼好UI预设物，选择UI物体右键点击SpawnEUICode选项生成UI绑定代码

图例：
![屏幕截图 2024-08-14 143423](Images\屏幕截图 2024-08-14 143423.png)

```C#
   // 假设UI名为Item_XXX
    
   // 代码结构
   // Scroll_Item_ItemXXX.cs 中定义字段
   
   // Scroll_Item_XXXSystem.cs 中写逻辑
   // ！！！ Item中的初始逻辑不要写在Awake中，Awake暂时用不到！！！
   // 如：
   private static void Awake(this Scroll_Item_XXXItem self)
   {
   }

   public static void Refresh(this Scroll_Item_XXXItem self)
   {
       self.E_TestButton.AddListener(self.OnTestButton);
       self.E_TestButton.gameObject.SetActive(true);
   }
   
   public static void OnTestButton(this Scroll_Item_XXXItem self)
   {
       Log.Debug("111");
   }
```

- 选择UI物体右键点击EUI/...ScrollRect选项生成滚动组件
- 在脚本 Loop ... Scroll Rect中PrefabName中填写Item的Prefab名字

图例：
![屏幕截图 2024-08-14 144618](Images\屏幕截图 2024-08-14 144618.png)

```C#
   // 假设
   // ScrollRect 名为 E_BagItems  注意！！！ES 的话要在ES_XXX.cs加上接口 IUILogic ！！！
   // Item 名为 Item_CommonItem
   private static void Awake(this ES_RoleBag self, Transform transform)
   {
        self.uiTransform = transform;

        // 注册刷新回调
        self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
   }
   
   private static void OnBagItemsRefresh(this ES_RoleBag self, Transform transform, int index)
   {
       // 刷新
       Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
       scrollItemCommonItem.Refresh(...)
   }
   
   public static void RefreshBagItems(this ES_RoleBag self)
   {
       BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

       self.ShowBagInfos.Clear();

       int itemTypeEnum = ItemTypeEnum.ALL;
       switch (self.CurrentItemType)
       {
            case 0:
                itemTypeEnum = ItemTypeEnum.ALL;
                break;
            case 1:
                itemTypeEnum = ItemTypeEnum.Equipment;
                break;
            case 2:
                itemTypeEnum = ItemTypeEnum.Material;
                break;
            case 3:
                itemTypeEnum = ItemTypeEnum.Consume;
                break;
       }

       int allNumber = bagComponentC.GetBagShowCell();
       self.ShowBagInfos.AddRange(bagComponentC.GetItemsByType(itemTypeEnum));
       // 生成
       self.AddUIScrollItems(ref self.ScrollItemCommonItems, allNumber);
       self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, allNumber);
       }
   }
   
```

# EUITool

1. Button自动注册工具：选中Dlg或ES物体，右键 SpawnEUICode-UI组件自动生成(为Button自动注册方法)
2. Button自动注册工具（批量）：选中文件夹，右键 EUITool/所有UI组件自动生成(为文件夹或Prefab中的所有Button自动注册方法)
