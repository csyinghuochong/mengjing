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
			//E_Click 上没有挂 Graphic，补一个透明 Image，不然按钮收不到点击事件
			self.EnsureClickGraphic();

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
			//列表里不显示描述，描述留给拆卸面板
			self.E_DesText.text = string.Empty;
		}

		/// <summary>
		/// 选中状态：选中时显示 E_Select
		/// </summary>
		public static void SetSelected(this Scroll_Item_SockeRunetItem self, bool selected)
		{
			self.E_SelectImage.gameObject.SetActive(selected);
		}

		/// <summary>
		/// E_Click 只有 Button 没有 Graphic，点击不会命中，这里补一个全透明可点击的 Image
		/// </summary>
		private static void EnsureClickGraphic(this Scroll_Item_SockeRunetItem self)
		{
			if (self.E_ClickButton.targetGraphic != null)
			{
				return;
			}

			Image clickImage = self.E_ClickButton.gameObject.GetComponent<Image>();
			if (clickImage == null)
			{
				clickImage = self.E_ClickButton.gameObject.AddComponent<Image>();
			}

			clickImage.color = Color.clear;
			self.E_ClickButton.targetGraphic = clickImage;
		}

		private static void OnClick(this Scroll_Item_SockeRunetItem self)
		{
			self.GetParent<ES_Rune>().OnClickSocketRune(self.DataId);
		}
	}
}
