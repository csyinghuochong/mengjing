
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_SkillRuneItem))]
	[EntitySystemOf(typeof(Scroll_Item_SkillRuneItem))]
	public static partial class Scroll_Item_SkillRuneItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SkillRuneItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SkillRuneItem self )
		{
			self.DestroyWidget();
		}

		/// <summary>
		/// 绑定背包里的一枚技能符文，selectRuneId 是当前选中的符文id
		/// </summary>
		public static void OnInitUI(this Scroll_Item_SkillRuneItem self, SkillRuneInfo rune, long selectRuneId)
		{
			self.DataId = rune.Id;

			SkillRuneConfig runeConfig = SkillRuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
			if (runeConfig == null)
			{
				self.uiTransform.gameObject.SetActive(false);
				return;
			}

			ES_SkillRune skillRune = self.GetParent<ES_SkillRune>();
			Sprite iconSprite = skillRune.LoadRuneIcon(runeConfig.Icon);
			if (iconSprite != null)
			{
				self.E_IconImage.sprite = iconSprite;
			}

			self.E_LvText.text = CommonViewHelper.GetRomanLevel(runeConfig.Level);
			self.E__ClickButton.AddListener(self.OnClick);
			self.SetSelected(selectRuneId == rune.Id);
		}

		/// <summary>
		/// 预制体里没有选中框，选中的图标保持原色，没选中的压暗
		/// </summary>
		public static void SetSelected(this Scroll_Item_SkillRuneItem self, bool selected)
		{
			self.E_IconImage.color = selected ? Color.white : new Color(0.55f, 0.55f, 0.55f, 1f);
		}

		private static void OnClick(this Scroll_Item_SkillRuneItem self)
		{
			self.GetParent<ES_SkillRune>().OnClickRuneItem(self.DataId);
		}
	}
}
