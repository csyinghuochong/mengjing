
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_RuneBagItem))]
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
		/// 选中状态（普通模式，升级面板用）
		/// </summary>
		public static void SetSelected(this Scroll_Item_RuneBagItem self, bool selected)
		{
			self.E_SelectImage.gameObject.SetActive(selected);
		}

		/// <summary>
		/// 勾选状态（分解模式，多选）
		/// </summary>
		public static void SetCheck(this Scroll_Item_RuneBagItem self, bool isChecked)
		{
			self.E_GouXuanBGImage.gameObject.SetActive(isChecked);
			self.E_GouXuanImage.gameObject.SetActive(isChecked);
		}

		private static void OnClick(this Scroll_Item_RuneBagItem self)
		{
			self.GetParent<ES_RuneBag>().OnClickRuneItem(self.DataId);
		}
	}
}
