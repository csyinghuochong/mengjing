using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public interface IUILogic
    {
        
    }

    public interface IUIScrollItem<T> where T : Entity,IAwake
    {
        public T BindTrans(Transform trans);
    }

    [ComponentOf()]
    public class UIComponent : Entity,IAwake,IDestroy
    {
        public Dictionary<int, UIBaseWindow> AllWindowsDic     = new Dictionary<int, UIBaseWindow>();
        public List<WindowID> UIBaseWindowlistCached           = new List<WindowID>();
        public Dictionary<int, UIBaseWindow> VisibleWindowsDic = new Dictionary<int, UIBaseWindow>();
        public Queue<WindowID> StackWindowsQueue               = new Queue<WindowID>();
        public bool IsPopStackWndStatus                        = false;
        public int CurrentNpcId { get; set; }
        public WindowID CurrentNpcUI { get; set; }
        public List<WindowID> OpenUIList { get; set; } = new();
        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }
    }
}