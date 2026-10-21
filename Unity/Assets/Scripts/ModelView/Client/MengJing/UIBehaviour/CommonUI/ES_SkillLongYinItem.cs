using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    public class ES_SkillLongYinItem : Entity, IAwake<Transform>, IDestroy
    {
        public Transform uiTransform;

        /// <summary>
        /// 预制体节点编号(如1001)
        /// </summary>
        public int Index;

        /// <summary>
        /// 配置id = 职业*10000 + Index
        /// </summary>
        public int LongYinId;

        public bool Visible;

        public GameObject ImageActive;
        public GameObject ImageSelect;
        public Image ImageIcon;
        public Button Button;
    }
}
