using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    
    [EntitySystemOf(typeof(UIComponent))]
    [FriendOf(typeof(ShowWindowData))]
    [FriendOf(typeof(UIPathComponent))]
    [FriendOf(typeof(UIBaseWindow))]
    [FriendOf(typeof(UIComponent))]
    public  static partial class UIComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIComponent self)
        {
            self.IsPopStackWndStatus = false;
            self.AllWindowsDic?.Clear();
            self.VisibleWindowsDic?.Clear();
            self.StackWindowsQueue?.Clear();
            self.UIBaseWindowlistCached?.Clear();
        }
        
        [EntitySystem]
        private static void Destroy(this UIComponent self)
        {
            self.CloseAllWindow();
        }

        
        
        /// <summary>
        /// 窗口是否是正在显示的 
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        /// <returns></returns>
        public static bool IsWindowVisible(this UIComponent self,WindowID id)
        {
            return self.VisibleWindowsDic.ContainsKey((int)id);
        }
        
        /// <summary>
        /// 根据泛型获得UI窗口逻辑组件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="isNeedShowState"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDlgLogic<T>(this UIComponent self,bool isNeedShowState = false) where  T : Entity,IUILogic
        {
            WindowID windowsId = self.GetWindowIdByGeneric<T>();
            UIBaseWindow baseWindow = self.GetUIBaseWindow(windowsId);
            if ( null == baseWindow )
            {
                // Log.Warning($"{windowsId} is not created!");
                return null;
            }
            if ( !baseWindow.IsPreLoad )
            {
                Log.Warning($"{windowsId} is not loaded!");
                return null;
            }
       
            if (isNeedShowState )
            {
                if ( !self.IsWindowVisible(windowsId) )
                {
                    Log.Warning($"{windowsId} is need show state!");
                    return null;
                }
            }
            
            return baseWindow.GetComponent<T>();
        }
        
        /// <summary>
        /// 根据泛型类型获取窗口Id
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static WindowID GetWindowIdByGeneric<T>(this UIComponent self) where  T : Entity
        {
            if (self.Root().GetComponent<UIPathComponent>().WindowTypeIdDict.TryGetValue(typeof(T).Name,out int windowsId) )
            {
                return (WindowID)windowsId;
            }
            Log.Error($"{typeof(T).FullName} is not have any windowId!" );
            return  WindowID.WindowID_Invaild;
        }
        
        
        /// <summary>
        /// 压入一个进栈队列界面
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShowStackWindow<T>(this UIComponent self) where T : Entity, IUILogic
        {
            WindowID id = self.GetWindowIdByGeneric<T>();
            self.ShowStackWindow(id);
        }
        
        /// <summary>
        /// 压入一个进栈队列界面
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        public static void ShowStackWindow(this UIComponent self,WindowID id) 
        {
           self.StackWindowsQueue.Enqueue(id);

           if (self.IsPopStackWndStatus)
           {
               return;
           }
           self.IsPopStackWndStatus = true;
           self.PopStackUIBaseWindow();
        }

        /// <summary>
        /// 弹出并显示一个栈队列中的界面
        /// </summary>
        /// <param name="self"></param>
        private static void PopStackUIBaseWindow(this UIComponent self)
        {
            if (self.StackWindowsQueue.Count > 0)
            {
                WindowID windowID = self.StackWindowsQueue.Dequeue();
                self.ShowWindow(windowID);
                UIBaseWindow uiBaseWindow = self.GetUIBaseWindow(windowID);
                uiBaseWindow.IsInStackQueue = true;
            }
            else
            {
                self.IsPopStackWndStatus = false;
            }
        }
        
        /// <summary>
        /// 弹出并显示下一个栈队列中的界面
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        private static void PopNextStackUIBaseWindow(this UIComponent self,WindowID id)
        {
            UIBaseWindow uiBaseWindow = self.GetUIBaseWindow(id);
            if (uiBaseWindow != null && !uiBaseWindow.IsDisposed && self.IsPopStackWndStatus && uiBaseWindow.IsInStackQueue)
            {
                uiBaseWindow.IsInStackQueue = false;
                self.PopStackUIBaseWindow();
            }
        }
        
        /// <summary>
        /// 根据指定Id的显示UI窗口
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        /// <OtherParam name="showData"></OtherParam>
        public static void ShowWindow(this UIComponent self,WindowID id, ShowWindowData showData = null)
        {
            UIBaseWindow baseWindow = self.ReadyToShowBaseWindow(id, showData);
            if (null != baseWindow)
            {
                self.RealShowWindow(baseWindow, id, showData);
            }
        }
        
        /// <summary>
        /// 根据泛型类型显示UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="showData"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShowWindow<T>(this UIComponent self, ShowWindowData showData = null) where T : Entity,IUILogic
        {
            WindowID windowsId = self.GetWindowIdByGeneric<T>();
            self.ShowWindow(windowsId,showData);
        }
        
        /// <summary>
        /// 根据指定Id的异步加载显示UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        /// <param name="showData"></param>
        public static async ETTask ShowWindowAsync(this UIComponent self,WindowID id, ShowWindowData showData = null)
        {
            UIBaseWindow baseWindow = self.GetUIBaseWindow(id);
            try
            {
                baseWindow = await self.ShowBaseWindowAsync(id, showData);
                if (null != baseWindow)
                {
                    self.RealShowWindow(baseWindow, id, showData);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        
        /// <summary>
        /// 根据泛型类型异步加载显示UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="showData"></param>
        /// <typeparam name="T"></typeparam>
        public static async ETTask ShowWindowAsync<T>(this UIComponent self, ShowWindowData showData = null) where T : Entity,IUILogic
        {
            WindowID windowsId = self.GetWindowIdByGeneric<T>();
           await self.ShowWindowAsync(windowsId,showData);
        }
        
        
        /// <summary>
        /// 隐藏ID指定的UI窗口
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        /// <OtherParam name="onComplete"></OtherParam>
        public static void HideWindow(this UIComponent self,WindowID id)
        {
            if (!self.VisibleWindowsDic.ContainsKey((int)id))
            {
                Log.Warning($"检测关闭 WindowsID: {id} 失败！");
                return;
            }

            UIBaseWindow baseWindow = self.VisibleWindowsDic[(int)id];
            if ( baseWindow == null || baseWindow.IsDisposed )
            {
                Log.Error($"UIBaseWindow is null  or isDisposed ，  WindowsID: {id} 失败！");
                return;
            }
            
            baseWindow.UIPrefabGameObject?.SetActive(false);
            UIEventComponent.Instance.GetUIEventHandler(id).OnHideWindow(baseWindow);
            
            self.VisibleWindowsDic.Remove((int)id);
            
            self.PopNextStackUIBaseWindow(id);
        }
        
        /// <summary>
        /// 根据泛型类型隐藏UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void  HideWindow<T>(this UIComponent self) where T : Entity 
        {
            WindowID hideWindowId = self.GetWindowIdByGeneric<T>();
            self.HideWindow(hideWindowId);
        }
        
        
        /// <summary>
        /// 卸载指定的UI窗口实例
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        public static void UnLoadWindow(this UIComponent self,WindowID id,bool isDispose = true)
        {
            UIBaseWindow baseWindow = self.GetUIBaseWindow(id);
            if (null == baseWindow)
            {
              Log.Error($"UIBaseWindow WindowId {id} is null!!!");
              return;
            }
            UIEventComponent.Instance.GetUIEventHandler(id).BeforeUnload(baseWindow);
            if(baseWindow.IsPreLoad)
            {
                self.Scene().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(baseWindow.UIPrefabGameObject.name.StringToAB());
                UnityEngine.Object.Destroy( baseWindow.UIPrefabGameObject);
                baseWindow.UIPrefabGameObject = null;
            }
            if (isDispose)
            {
                self.AllWindowsDic.Remove((int) id);
                self.VisibleWindowsDic.Remove((int) id);
                baseWindow?.Dispose();
            }
        }

        /// <summary>
        /// 根据泛型类型卸载UI窗口实例
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void  UnLoadWindow<T>(this UIComponent self) where T : Entity,IUILogic
        {
            WindowID hideWindowId = self.GetWindowIdByGeneric<T>();
            self.UnLoadWindow(hideWindowId);
        }

        private static  UIBaseWindow  ReadyToShowBaseWindow(this UIComponent self,WindowID id, ShowWindowData showData = null)
        {
            UIBaseWindow baseWindow = self.GetUIBaseWindow(id);
            // 如果UI不存在开始实例化新的窗口
            if (null == baseWindow)
            {
                baseWindow = self.AddChild<UIBaseWindow>();
                baseWindow.WindowID = id;
                self.LoadBaseWindows(baseWindow);
            }
            
            if (!baseWindow.IsPreLoad)
            {
                self.LoadBaseWindows(baseWindow);
            }
            return baseWindow;
        }

        private static async ETTask<UIBaseWindow> ShowBaseWindowAsync(this UIComponent self,WindowID id, ShowWindowData showData = null)
        {
            CoroutineLock coroutineLock = null;
            try
            {
                coroutineLock = await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoadUIBaseWindows, (int)id);
                UIBaseWindow baseWindow = self.GetUIBaseWindow(id);
                if (null == baseWindow)
                {
                    if (self.Root().GetComponent<UIPathComponent>().WindowPrefabPath.ContainsKey((int)id))
                    {
                        baseWindow = self.AddChild<UIBaseWindow>();
                        baseWindow.WindowID = id;
                        await self.LoadBaseWindowsAsync(baseWindow);
                    }
                }

                if (!baseWindow.IsPreLoad)
                {
                    await self.LoadBaseWindowsAsync(baseWindow);
                }
                return baseWindow;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                coroutineLock?.Dispose();
            }
        }

        private static async ETTask ChangeUniversalBlurFeature(this UIComponent self)
        {
            GameObject.Find("Global").GetComponent<RenderScaleController>().ChangeUniversalBlurFeature(true);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            GameObject.Find("Global").GetComponent<RenderScaleController>().ChangeUniversalBlurFeature(false);
        }

        private static void ChangeUniversalBlurFeature(this UIComponent self, bool value)
        {
            GameObject.Find("Global").GetComponent<RenderScaleController>().ChangeUniversalBlurFeature(value);
        }

        private static  bool HaveUniversalBlurFeature(this UIComponent self, WindowID id)
        {
            if (id == WindowID.WindowID_CellDungeonCell
                || id == WindowID.WindowID_Function
                || id == WindowID.WindowID_MapBig
                || id == WindowID.WindowID_PetBar
                || id == WindowID.WindowID_PetMelee
                || id == WindowID.WindowID_PetMeleeLevel
                || id == WindowID.WindowID_Role
                || id == WindowID.WindowID_MJLobby
                || id == WindowID.WindowID_Chat)
            {
                return true;
            }
            return false;
        }

        private static void RealShowWindow(this UIComponent self, UIBaseWindow baseWindow, WindowID id, Entity showData = null)
        {
            Entity contextData = showData == null? null : showData;
            baseWindow.UIPrefabGameObject?.SetActive(true);

            UIEventComponent.Instance.GetUIEventHandler(id).OnShowWindow(baseWindow, contextData);

            UILayerScript uILayerScript = baseWindow.UIPrefabGameObject.GetComponent<UILayerScript>();
            if (uILayerScript.ShowHuoBi)
            {
                if (self.OpenUIList.Contains(id))
                {
                    Log.Debug($"UI {id} 已经打开 OpenUIList");
                }
                else
                {
                    self.OpenUIList.Insert(0, id);
                }

                DlgHuoBiSet dlgHuoBiSet = self.GetDlgLogic<DlgHuoBiSet>();
                if (dlgHuoBiSet != null)
                {
                    dlgHuoBiSet.OnUpdateTitle(self.OpenUIList[0]);
                }
                else
                {
                    self.ShowWindowAsync(WindowID.WindowID_HuoBiSet).Coroutine();
                }
            }

            if (self.HaveUniversalBlurFeature(id))
            {
                //self.ChangeUniversalBlurFeature().Coroutine();
                self.ChangeUniversalBlurFeature(true);
            }

            if (uILayerScript.HideMainUI)
            {
                DlgMain dlgMain = self.GetDlgLogic<DlgMain>();
                dlgMain?.ShowMainUI(false);
            }

            self.VisibleWindowsDic[(int)id] = baseWindow;
            Debug.Log("<color=magenta>### current Navigation window </color>" + baseWindow.WindowID.ToString());
        }


        /// <summary>
        /// 根据窗口Id获取UIBaseWindow
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UIBaseWindow GetUIBaseWindow(this UIComponent self,WindowID id)
        {
            if (self.AllWindowsDic.ContainsKey((int)id))
            {
                return self.AllWindowsDic[(int)id];
            }
            return null;
        }
        

        /// <summary>
        /// 根据窗口Id隐藏并完全关闭卸载UI窗口实例
        /// </summary>
        /// <param name="self"></param>
        /// <param name="windowId"></param>
        public static void CloseWindow(this UIComponent self,WindowID windowId, bool showUnit = true)
        {
            if (!self.VisibleWindowsDic.ContainsKey((int)windowId))
            {
                return;
            }

            if (self.CurrentNpcUI == windowId && showUnit)
            {
                 self.Root().CurrentScene().GetComponent<MJCameraComponent>().SetBuildExit(); 
            }

            if (self.CurrentNpcUI == windowId)
            {
                self.CurrentNpcId = 0;
                self.CurrentNpcUI = 0;
            }

            UIBaseWindow baseWindow = self.VisibleWindowsDic[(int)windowId];
            UILayerScript uILayerScript = baseWindow.UIPrefabGameObject.GetComponent<UILayerScript>();
            if (uILayerScript.ShowHuoBi)
            {
                self.OpenUIList.Remove(windowId);
                bool haveView = self.OpenUIList.Count > 0;
                DlgHuoBiSet dlgHuoBiSet = self.GetDlgLogic<DlgHuoBiSet>();
                if (dlgHuoBiSet != null && haveView)
                {
                    dlgHuoBiSet.OnUpdateTitle(self.OpenUIList[0]);
                }

                if (dlgHuoBiSet != null && !haveView)
                {
                    self.CloseWindow(WindowID.WindowID_HuoBiSet);
                }
            }

            if (uILayerScript.HideMainUI)
            {
                DlgMain dlgMain = self.GetDlgLogic<DlgMain>();
                dlgMain?.ShowMainUI(true);
            }
            
            if (self.GuideUISet.Equals(windowId))
            {
                self.CloseWindow(WindowID.WindowID_Guide);
                self.GuideUISet = WindowID.WindowID_Invaild;
            }

            if (self.HaveUniversalBlurFeature(windowId))
            {
                //self.ChangeUniversalBlurFeature().Coroutine();
                

               self.ChangeUniversalBlurFeature(false);
            }

            self.HideWindow(windowId);
            self.UnLoadWindow(windowId);
            Debug.Log("<color=magenta>## close window without PopNavigationWindow() ##</color>");
        }
        
        /// <summary>
        /// 根据窗口泛型类型隐藏并完全关闭卸载UI窗口实例
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void  CloseWindow<T>(this UIComponent self) where T : Entity,IUILogic
        {
            WindowID hideWindowId = self.GetWindowIdByGeneric<T>();
            self.CloseWindow(hideWindowId);
        }
        
        /// <summary>
        /// 关闭并卸载所有的窗口实例
        /// </summary>
        /// <param name="self"></param>
        public static void CloseAllWindow(this UIComponent self)
        {
            self.IsPopStackWndStatus = false;
            if (self.AllWindowsDic == null)
            {
                return;
            }
            foreach (KeyValuePair<int, EntityRef<UIBaseWindow>> window in self.AllWindowsDic)
            {
                UIBaseWindow baseWindow = window.Value;
                if (baseWindow == null|| baseWindow.IsDisposed)
                {
                    continue;
                }
                self.HideWindow(baseWindow.WindowID);
                self.UnLoadWindow(baseWindow.WindowID,false);
                baseWindow?.Dispose();
            }
            self.AllWindowsDic.Clear();
            self.VisibleWindowsDic.Clear();
            self.StackWindowsQueue.Clear();
            self.UIBaseWindowlistCached.Clear();
            self.CurrentNpcId = 0;
            self.CurrentNpcUI = WindowID.WindowID_Invaild;
            self.GuideUISet = WindowID.WindowID_Invaild;
            self.OpenUIList.Clear();
        }
        
        /// <summary>
        /// 隐藏所有已显示的窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="includeFixed"></param>
        public static void HideAllShownWindow(this UIComponent self,bool includeFixed = false)
        {
            self.IsPopStackWndStatus = false;
            self.UIBaseWindowlistCached.Clear();
            foreach (KeyValuePair<int, EntityRef<UIBaseWindow>> refwindow in self.VisibleWindowsDic)
            {
                KeyValuePair<int, UIBaseWindow> window = new KeyValuePair<int, UIBaseWindow>(refwindow.Key, refwindow.Value);
                if (window.Value.windowType == UIWindowType.Fixed && !includeFixed)
                    continue;
                if (window.Value.IsDisposed)
                {
                    continue;
                }
                
                self.UIBaseWindowlistCached.Add((WindowID)window.Key);
                window.Value.UIPrefabGameObject?.SetActive(false);
                UIEventComponent.Instance.GetUIEventHandler(window.Value.WindowID).OnHideWindow(window.Value);
            }
            if (self.UIBaseWindowlistCached.Count > 0)
            {
                for (int i = 0; i < self.UIBaseWindowlistCached.Count; i++)
                {
                    self.VisibleWindowsDic.Remove((int)self.UIBaseWindowlistCached[i]);
                }
            }
            self.StackWindowsQueue.Clear();
        }
        
        
        /// <summary>
        /// 同步加载UI窗口实例
        /// </summary>
        private static void LoadBaseWindows(this UIComponent self,  UIBaseWindow baseWindow)
        {
            if ( !self.Root().GetComponent<UIPathComponent>().WindowPrefabPath.TryGetValue((int)baseWindow.WindowID,out string value) )
            {
                Log.Error($"{baseWindow.WindowID} uiPath is not Exist!");
                return;
            }

            GameObject go  = null;

            if (self.IScene is Room)
            {
                go = self.Scene<Room>().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(value.StringToAB());
            }
            else
            {
                go = self.Scene<Scene>().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(value.StringToAB());
            }
            baseWindow.UIPrefabGameObject      = UnityEngine.Object.Instantiate(go);
            baseWindow.UIPrefabGameObject.name = go.name;
            
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitWindowCoreData(baseWindow);
            
            baseWindow?.SetRoot(EUIRootHelper.GetTargetRoot(self.Root(), baseWindow.windowType));
            baseWindow.uiTransform.SetAsLastSibling();
            
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitComponent(baseWindow);
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnRegisterUIEvent(baseWindow);
            
            self.AllWindowsDic[(int)baseWindow.WindowID] = baseWindow;
        }

        /// <summary>
        /// 异步加载UI窗口实例
        /// </summary>
        private static async ETTask LoadBaseWindowsAsync(this UIComponent self,  UIBaseWindow baseWindow)
        {
            
            if ( !self.Root().GetComponent<UIPathComponent>().WindowPrefabPath.TryGetValue((int)baseWindow.WindowID,out string value) )
            {
                Log.Error($"{baseWindow.WindowID} is not Exist!");
                return;
            }
            
            GameObject go  = null;

            if (self.IScene is Room)
            {
                go = await self.Scene<Room>().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(value.StringToAB());
            }
            else
            {
                go = await self.Scene<Scene>().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(value.StringToAB());
            }
            baseWindow.UIPrefabGameObject      = UnityEngine.Object.Instantiate(go);
            baseWindow.UIPrefabGameObject.name = go.name;
            
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitWindowCoreData(baseWindow);
            
            baseWindow?.SetRoot(EUIRootHelper.GetTargetRoot(self.Root(),baseWindow.windowType));
            baseWindow.uiTransform.SetAsLastSibling();
            
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitComponent(baseWindow);
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnRegisterUIEvent(baseWindow);
            
            self.AllWindowsDic[(int)baseWindow.WindowID] = baseWindow;
        }
       

    }
}
