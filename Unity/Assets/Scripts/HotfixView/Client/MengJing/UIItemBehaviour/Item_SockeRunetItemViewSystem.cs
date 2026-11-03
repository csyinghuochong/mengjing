using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_SockeRunetItem))]
	[EntitySystemOf(typeof(Scroll_Item_SockeRunetItem))]
	public static partial class Scroll_Item_SockeRunetItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SockeRunetItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SockeRunetItem self )
		{
			self.DestroyWidget();
		}

		/// <summary>
		/// 绑定一枚可镶嵌的符文，点一下选中，真正的镶嵌由父面板的确认按钮发
		/// </summary>
		public static void OnInitUI(this Scroll_Item_SockeRunetItem self, RuneData rune)
		{
			self.DataId = rune.Id;
			self.E_ClickButton.AddListener(self.OnClick);
			self.E_SelectImage.gameObject.SetActive(false);

			RuneConfig runeConfig = RuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
			if (runeConfig == null)
			{
				self.uiTransform.gameObject.SetActive(false);
				return;
			}

			Sprite iconSprite = self.GetParent<ES_Rune>().LoadRuneIcon(runeConfig.Icon);
			if (iconSprite != null)
			{
				self.E_IconImage.sprite = iconSprite;
			}

			self.E_NameText.text = runeConfig.Name;
			self.E_LvText.text = $"Lv.{runeConfig.Lv}";
			self.E_DesText.text = runeConfig.Des;
		}

		/// <summary>
		/// 选中状态：选中时显示 E_Select
		/// </summary>
		public static void SetSelected(this Scroll_Item_SockeRunetItem self, bool selected)
		{
			self.E_SelectImage.gameObject.SetActive(selected);
		}

		private static void OnClick(this Scroll_Item_SockeRunetItem self)
		{
			self.GetParent<ES_Rune>().OnClickSocketRune(self.DataId);
		}
	}
}
