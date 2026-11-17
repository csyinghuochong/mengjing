using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class ES_RoleQiangHuaItem : Entity, IAwake<Transform>, IDestroy
    {
        public int ItemSubType;
        public Action<int> ClickHandler;
        public Image Image_EquipIconImage;
        public Image Image_SelectImage;
        public Text Text_QiangHuaText;
    }
}
