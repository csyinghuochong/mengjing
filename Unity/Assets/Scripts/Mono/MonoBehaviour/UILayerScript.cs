using UnityEngine;

namespace ET
{
    public enum UIEnum
    {
        FullScreen = 0,
        PopupUI = 1,
    }

    public class UILayerScript: MonoBehaviour
    {
        public UIEnum UIType;
        public bool HideMainUI;
        public bool ShowHuoBi;
    }
}