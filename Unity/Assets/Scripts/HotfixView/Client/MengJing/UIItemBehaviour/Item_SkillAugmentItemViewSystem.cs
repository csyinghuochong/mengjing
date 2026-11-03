
using System;
using System.Collections.Generic;
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
			self.BaseSkillId = 0;
			self.ClickHandler = null;
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_SkillAugmentItem self, int baseSkillId)
		{
			self.BaseSkillId = baseSkillId;
			self.E_ClickButton.AddListener(self.OnClick);

			SkillConfig skillConfig = SkillConfigCategory.Instance.GetOrDefault(baseSkillId);
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
			self.SetAugmentIcon(self.EG_SkillAugment_1RectTransform.Find("Mask/Icon").transform.GetComponent<Image>(), baseSkillId, 0);
			self.SetAugmentIcon(self.EG_SkillAugment_2RectTransform.Find("Mask/Icon").transform.GetComponent<Image>(), baseSkillId, 1);
		}

		public static void SetClickHandler(this Scroll_Item_SkillAugmentItem self, Action<int> clickHandler)
		{
			self.ClickHandler = clickHandler;
		}

		public static void OnSetSelected(this Scroll_Item_SkillAugmentItem self, int baseSkillId)
		{
			self.E_HighlightImage.gameObject.SetActive(self.BaseSkillId != 0 && self.BaseSkillId == baseSkillId);
		}

		private static void OnClick(this Scroll_Item_SkillAugmentItem self)
		{
			self.ClickHandler?.Invoke(self.BaseSkillId);
		}

		private static void SetAugmentIcon(this Scroll_Item_SkillAugmentItem self, Image image, int baseSkillId, int tierIndex)
		{
			List<int> augmentIds = self.Root().GetComponent<SkillSetComponentC>().SkillAugmentList;
			int augmentId = SkillAugmentHelper.GetSelectedAugmentId(augmentIds, baseSkillId, tierIndex + 2);
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
