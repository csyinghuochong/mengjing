
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_RuneBagItem))]
	public static partial class Scroll_Item_RuneBagItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_RuneBagItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_RuneBagItem self )
		{
			self.DestroyWidget();
		}

		/// <summary>
		/// 绑定背包里的一枚符文
		/// </summary>
		public static void OnInitUI(this Scroll_Item_RuneBagItem self, RuneData rune)
		{
			//E_Click 上没挂 Graphic，补一个透明 Image，不然按钮收不到点击
			self.EnsureClickGraphic();

			self.DataId = rune.Id;
			self.E_ClickButton.onClick.RemoveAllListeners();
			self.E_ClickButton.AddListener(self.OnClick);

			RuneConfig runeConfig = RuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
			if (runeConfig == null)
			{
				self.uiTransform.gameObject.SetActive(false);
				return;
			}

			//勾选框和选中框是分解/升级面板用的，列表里先都藏起来
			self.E_GouXuanBGImage.gameObject.SetActive(false);
			self.E_GouXuanImage.gameObject.SetActive(false);
			self.E_SelectImage.gameObject.SetActive(false);

			Sprite iconSprite = self.GetParent<ES_RuneBag>().LoadRuneIcon(runeConfig.Icon);
			if (iconSprite != null)
			{
				self.E_IconImage.sprite = iconSprite;
			}

			self.E_NameText.text = runeConfig.Name;
			self.E_LvText.text = $"Lv.{runeConfig.Lv}";
		}

		/// <summary>
		/// 选中状态
		/// </summary>
		public static void SetSelected(this Scroll_Item_RuneBagItem self, bool selected)
		{
			self.E_SelectImage.gameObject.SetActive(selected);
		}

		/// <summary>
		/// E_Click 只有 Button 没有 Graphic，点击不会命中，这里补一个全透明可点击的 Image
		/// </summary>
		private static void EnsureClickGraphic(this Scroll_Item_RuneBagItem self)
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

		private static void OnClick(this Scroll_Item_RuneBagItem self)
		{
			self.GetParent<ES_RuneBag>().OnClickRuneItem(self.DataId);
		}
	}
}
