using System;
using System.Collections.Generic;

namespace ET.Client
{
    public class UIPageViewComponent : Entity, IAwake
    {
        public int LastIndex;
        public UI[] UISubViewList;
        public string[] UISubViewPath;
        public Type[] UISubViewType;

        public List<string> AssetList = new List<string>();
    }
}
