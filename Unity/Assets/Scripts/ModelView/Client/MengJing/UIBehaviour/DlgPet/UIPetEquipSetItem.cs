using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    public class UIPetEquipSetItem : Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject Img_EquipBack { get; set; }
        public GameObject Img_EquipIcon { get; set; }
        public GameObject Img_EquipQuality { get; set; }
        public GameObject Btn_Equip { get; set; }
        public GameObject Img_EquipBangDing { get; set; }
        public List<BagInfo> EquipIdList = new List<BagInfo>();
        public GameObject GameObject { get; set; }
        public ItemInfo BagInfo { get; set; }
        public long PointDownTime;
        public bool ShowEquiTip;

        public Action<int> OnClickAction;

        public ItemOperateEnum itemOperateEnum = ItemOperateEnum.None;
        public List<string> AssetPath = new List<string>();
    }
}