using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 符文面板上的一个孔位，对应 ES_Rune 下 Left/RuneSlotItem_xx 这一类静态节点
    /// </summary>
    [ChildOf]
    public class ES_RuneSlotItem : Entity, IAwake<Transform>, IDestroy
    {
        /// <summary>
        /// 孔位配置 id（RuneSlotConfig.Id），由节点名 RuneSlotItem_xx 解析得到
        /// </summary>
        public int SlotId;

        public Transform uiTransform;

        /// <summary>
        /// 未解锁时显示的锁
        /// </summary>
        public Image E_ImageLockImage;

        /// <summary>
        /// 已解锁但空着时显示的加号
        /// </summary>
        public Image E_ImageAddImage;

        /// <summary>
        /// 已镶嵌符文的图标
        /// </summary>
        public Image E_ImageIconImage;

        /// <summary>
        /// 选中框
        /// </summary>
        public Image E_ImageSelectImage;

        /// <summary>
        /// 整个孔位的点击区域
        /// </summary>
        public Button E_ImageClickButton;
    }
}
