
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_SkillSocketItem))]
	[EntitySystemOf(typeof(Scroll_Item_SkillSocketItem))]
	public static partial class Scroll_Item_SkillSocketItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SkillSocketItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SkillSocketItem self )
		{
			self.SkillSocketInfo = null;
			self.ClickHandler = null;
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_SkillSocketItem self, SkillSocketInfo skillSocketInfo)
		{
			self.SkillSocketInfo = skillSocketInfo;
			self.E_ClickButton.AddListener(self.OnClick);

			SkillConfig skillConfig = SkillConfigCategory.Instance.GetOrDefault(skillSocketInfo.BaseSkillId);
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
			self.SetAugmentIcon(self.E_SkillIcon_1Image, skillSocketInfo, 0);
			self.SetAugmentIcon(self.E_SkillIcon_2Image, skillSocketInfo, 1);
			self.SetAugmentIcon(self.E_SkillIcon_3Image, skillSocketInfo, 2);
		}

		public static void SetClickHandler(this Scroll_Item_SkillSocketItem self, Action<SkillSocketInfo> clickHandler)
		{
			self.ClickHandler = clickHandler;
		}

		public static void OnSetSelected(this Scroll_Item_SkillSocketItem self, int baseSkillId)
		{
			self.E_HighlightImage.gameObject.SetActive(self.SkillSocketInfo != null && self.SkillSocketInfo.BaseSkillId == baseSkillId);
		}

		private static void OnClick(this Scroll_Item_SkillSocketItem self)
		{
			self.ClickHandler?.Invoke(self.SkillSocketInfo);
		}

		private static void SetAugmentIcon(this Scroll_Item_SkillSocketItem self, Image image, SkillSocketInfo skillSocketInfo, int index)
		{
			if (skillSocketInfo.AugmentIds == null || index >= skillSocketInfo.AugmentIds.Count)
			{
				image.gameObject.SetActive(false);
				return;
			}

			int augmentId = skillSocketInfo.AugmentIds[index];
			SkillAugmentConfig augmentConfig = SkillAugmentConfigCategory.Instance.GetOrDefault(augmentId);
			if (augmentId == 0 || augmentConfig == null || string.IsNullOrEmpty(augmentConfig.Icon))
			{
				image.gameObject.SetActive(false);
				return;
			}

			self.SetSkillIcon(image, augmentConfig.Icon);
		}

		private static void SetSkillIcon(this Scroll_Item_SkillSocketItem self, Image image, string icon)
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
