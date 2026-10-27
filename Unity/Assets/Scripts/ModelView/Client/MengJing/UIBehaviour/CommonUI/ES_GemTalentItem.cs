using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 宝石天赋树上的一个节点，对应 ES_GemTalent 下 Left/GemTalentItem_xxxxx 这一类静态节点
    /// </summary>
    [ChildOf]
    public class ES_GemTalentItem : Entity, IAwake<Transform>, IDestroy
    {
        /// <summary>
        /// 节点对应的天赋id（GemTalentConfig.Id），由节点名 GemTalentItem_xxxxx 解析得到
        /// </summary>
        public int GemTalentId;

        public Transform uiTransform;

        public Image E_ImageIconImage;
        public Button E_ImageIconButton;
        public Image E_ImageSelectImage;
    }
}
