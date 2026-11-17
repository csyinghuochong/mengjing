using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 宝石天赋树上的一个节点，对应预制体中的 EG_GemTalentItem_xxxxx
    /// </summary>
    [ChildOf]
    public class ES_GemTalentItem : Entity, IAwake<Transform>, IDestroy
    {
        /// <summary>
        /// 节点对应的天赋id（GemTalentConfig.Id），在绑定节点时指定
        /// </summary>
        public int GemTalentId;

        public Transform uiTransform;

        public Button BGHuiButton;
        public GameObject BGOpen;
        public GameObject BGActivate;
        public Image E_ImageIconImage;
        public Image E_ImageSelectImage;
    }
}
