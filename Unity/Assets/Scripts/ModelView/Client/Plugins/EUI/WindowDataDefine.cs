using System;

namespace ET.Client
{
    
    public enum UIWindowType
    {
        Normal,    // 普通主界面
        Mid,       // 中间窗口
        Fixed,     // 固定窗口
        PopUp,     // 弹出窗口
        Other,      //其他窗口
    }
    
    public class ShowWindowData : Entity
    {
        public int ParamInfoInt { get; set; } = 0;
    }
}