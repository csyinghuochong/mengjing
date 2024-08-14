using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public interface IUILogic
    {
    }

    public interface IUIScrollItem<T> where T : Entity, IAwake
    {
        public T BindTrans(Transform trans);
    }

    [ComponentOf()]
    public class UIComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, EntityRef<UIBaseWindow>> AllWindowsDic = new();
        public List<WindowID> UIBaseWindowlistCached = new();
        public Dictionary<int, EntityRef<UIBaseWindow>> VisibleWindowsDic = new();
        public Queue<WindowID> StackWindowsQueue = new();
        public bool IsPopStackWndStatus = false;
        public int CurrentNpcId { get; set; }
        public WindowID CurrentNpcUI { get; set; }
        public WindowID GuideUISet { get; set; }
        public List<WindowID> OpenUIList { get; set; } = new();
        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }
    }
}