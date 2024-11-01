using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgLoading: Entity, IAwake, IUILogic
    {
        public DlgLoadingViewComponent View
        {
            get => this.GetComponent<DlgLoadingViewComponent>();
        }

        public int ChapterId;
        public float PassTime;
        public bool ShowMainUI;

        public bool StartLoadAssets = false;
        public List<string> PreLoadAssets = new();
        public List<string> ReleaseAssets = new();

        public long Timer;
        public string AssetPath = string.Empty;

        public float Program;

    }
}