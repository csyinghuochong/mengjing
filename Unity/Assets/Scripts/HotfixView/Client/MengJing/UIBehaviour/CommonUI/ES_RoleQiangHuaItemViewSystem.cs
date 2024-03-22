using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EntitySystemOf(typeof (ES_RoleQiangHuaItem))]
	[FriendOfAttribute(typeof (ES_RoleQiangHuaItem))]
	public static partial class ES_RoleQiangHuaItemSystem
	{
		[EntitySystem]
		private static void Awake(this ES_RoleQiangHuaItem self, Transform transform)
		{
			self.uiTransform = transform;
			self.E_EquipButton.AddListener(self.OnBtn_Equip);
		}

		[EntitySystem]
		private static void Destroy(this ES_RoleQiangHuaItem self)
		{
			self.DestroyWidget();
		}

		public static void OnInitUI(this ES_RoleQiangHuaItem self, int index)
		{
			self.ItemSubType = index;
		}

		public static void OnBtn_Equip(this ES_RoleQiangHuaItem self)
		{
			self.ClickHandler(self.ItemSubType);
		}

		public static void SetClickHandler(this ES_RoleQiangHuaItem self, Action<int> action)
		{
			self.ClickHandler = action;
		}

		public static void OnUpateUI(this ES_RoleQiangHuaItem self, int qianghuaLevel)
		{
			self.E_QiangHuaText.text = $"强化+{qianghuaLevel}";
		}
	}
}
