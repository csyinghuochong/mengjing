using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 符文面板：Left 下 RuneSlotItem_xx 是 20 个符文孔位，
    /// EG_UnlockSlot 是孔位没解锁时显示的开启条件面板
    /// </summary>
    [ChildOf]
    [EnableMethod]
    public class ES_Rune : Entity, IAwake<Transform>, IDestroy
    {
        /// <summary>
        /// 孔位节点，按 Left 下的 RuneSlotItem_xx 静态节点创建
        /// </summary>
        public List<EntityRef<ES_RuneSlotItem>> SlotItems = new();

        /// <summary>
        /// 当前选中的孔位id（RuneSlotConfig.Id），0 表示没选中
        /// </summary>
        public int SelectSlotId;

        /// <summary>
        /// 孔位开启条件面板，节点名没有 E_ 前缀，生成代码不会绑定，这里手动取
        /// </summary>
        public RectTransform EG_UnlockSlotRectTransform;

        /// <summary>
        /// 孔位类型（技能孔/攻击孔/防御孔）
        /// </summary>
        public Text E_RuneSlotType_UnlockSlotText;

        /// <summary>
        /// 玩家等级条件：当前/要求
        /// </summary>
        public Text E_PlayerLvText;

        /// <summary>
        /// 玩家等级条件是否已达成
        /// </summary>
        public Text E_PlayerLvTargetText;

        /// <summary>
        /// 玩家等级条件的进度条
        /// </summary>
        public Image E_LodingValue_PlayerLvImage;

        /// <summary>
        /// 符文总等级条件：当前/要求
        /// </summary>
        public Text E_RuneLvText;

        /// <summary>
        /// 符文总等级条件是否已达成
        /// </summary>
        public Text E_RuneLvTargetText;

        /// <summary>
        /// 符文总等级条件的进度条
        /// </summary>
        public Image E_LodingValue_RuneLvImage;

        /// <summary>
        /// 孔位说明
        /// </summary>
        public Text E_RuneSlotDesText;

        /// <summary>
        /// 开启孔位按钮
        /// </summary>
        public Button E_UnlockSlotButton;

        public Transform uiTransform;

        public void DestroyWidget()
        {
            this.SlotItems.Clear();
            this.SelectSlotId = 0;
            this.EG_UnlockSlotRectTransform = null;
            this.E_RuneSlotType_UnlockSlotText = null;
            this.E_PlayerLvText = null;
            this.E_PlayerLvTargetText = null;
            this.E_LodingValue_PlayerLvImage = null;
            this.E_RuneLvText = null;
            this.E_RuneLvTargetText = null;
            this.E_LodingValue_RuneLvImage = null;
            this.E_RuneSlotDesText = null;
            this.E_UnlockSlotButton = null;
            this.uiTransform = null;
        }
    }
}
