
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_SkillAugmentItem))]
	[EntitySystemOf(typeof(Scroll_Item_SkillAugmentItem))]
	public static partial class Scroll_Item_SkillAugmentItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SkillAugmentItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SkillAugmentItem self )
		{
			self.SkillAugmentInfo = null;
			self.ClickHandler = null;
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_SkillAugmentItem self, SkillAugmentInfo skillAugmentInfo)
		{
			self.SkillAugmentInfo = skillAugmentInfo;
			self.E_ClickButton.AddListener(self.OnClick);

			SkillConfig skillConfig = SkillConfigCategory.Instance.GetOrDefault(skillAugmentInfo.BaseSkillId);
			if (skillConfig == null)
			{
				self.E_SkillIconImage.gameObject.SetActive(false);
				self.E_NullImage.gameObject.SetActive(true);
				self.E_SkillNameText.text = string.Empty;
			}
			else
			{
				self.E_NullImage.gameObject.SetActive(false);
				self.E_SkillNameText.text = skillConfig.SkillName;
				self.SetSkillIcon(self.E_SkillIconImage, skillConfig.SkillIcon);
			}

			self.E_HighlightImage.gameObject.SetActive(false);
			self.SetAugmentIcon(self.EG_SkillAugment_1RectTransform.Find("Mask/Icon").transform.GetComponent<Image>(), skillAugmentInfo, 0);
			self.SetAugmentIcon(self.EG_SkillAugment_2RectTransform.Find("Mask/Icon").transform.GetComponent<Image>(), skillAugmentInfo, 1);
			self.SetAugmentIcon(self.EG_SkillAugment_3RectTransform.Find("Mask/Icon").transform.GetComponent<Image>(), skillAugmentInfo, 2);
		}

		public static void SetClickHandler(this Scroll_Item_SkillAugmentItem self, Action<SkillAugmentInfo> clickHandler)
		{
			self.ClickHandler = clickHandler;
		}

		public static void OnSetSelected(this Scroll_Item_SkillAugmentItem self, int baseSkillId)
		{
			self.E_HighlightImage.gameObject.SetActive(self.SkillAugmentInfo != null && self.SkillAugmentInfo.BaseSkillId == baseSkillId);
		}

		private static void OnClick(this Scroll_Item_SkillAugmentItem self)
		{
			self.ClickHandler?.Invoke(self.SkillAugmentInfo);
		}

		private static void SetAugmentIcon(this Scroll_Item_SkillAugmentItem self, Image image, SkillAugmentInfo skillAugmentInfo, int tierIndex)
		{
			if (skillAugmentInfo.ActiveAugmentIds == null || tierIndex >= skillAugmentInfo.ActiveAugmentIds.Count)
			{
				image.gameObject.SetActive(false);
				return;
			}

			int augmentId = skillAugmentInfo.ActiveAugmentIds[tierIndex];
			SkillAugmentConfig augmentConfig = SkillAugmentConfigCategory.Instance.GetOrDefault(augmentId);
			if (augmentId == 0 || augmentConfig == null || string.IsNullOrEmpty(augmentConfig.Icon))
			{
				image.gameObject.SetActive(false);
				return;
			}

			self.SetSkillIcon(image, augmentConfig.Icon);
		}

		private static void SetSkillIcon(this Scroll_Item_SkillAugmentItem self, Image image, string icon)
		{
			if (string.IsNullOrEmpty(icon))
			{
				image.gameObject.SetActive(false);
				return;
			}

			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, icon);
			image.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
			image.gameObject.SetActive(true);
		}
	}
}
