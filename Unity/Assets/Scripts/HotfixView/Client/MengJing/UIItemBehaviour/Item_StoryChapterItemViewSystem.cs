
using System;
using UnityEngine;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_StoryChapterItem))]
	[EntitySystemOf(typeof(Scroll_Item_StoryChapterItem))]
	public static partial class Scroll_Item_StoryChapterItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_StoryChapterItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_StoryChapterItem self )
		{
			self.StoryChapterConfig = null;
			self.ClickHandler = null;
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_StoryChapterItem self, StoryChapterConfig storyChapterConfig,
		bool isUnlocked, Action<int> clickHandler)
		{
			self.StoryChapterConfig = storyChapterConfig;
			self.ClickHandler = clickHandler;
			self.IsUnlocked = isUnlocked;

			self.E_NameText.text = storyChapterConfig.Name;
			self.E_LockImage.gameObject.SetActive(!isUnlocked);
			self.E_HighlightImage.gameObject.SetActive(false);
			self.E_ClickButton.interactable = isUnlocked;
			self.E_ClickButton.AddListener(self.OnClick);
		}

		public static void SetSelected(this Scroll_Item_StoryChapterItem self, int chapterId)
		{
			self.E_HighlightImage.gameObject.SetActive(self.IsUnlocked &&
					self.StoryChapterConfig != null && self.StoryChapterConfig.Id == chapterId);
		}

		private static void OnClick(this Scroll_Item_StoryChapterItem self)
		{
			if (!self.IsUnlocked || self.StoryChapterConfig == null)
			{
				return;
			}

			self.ClickHandler?.Invoke(self.StoryChapterConfig.Id);
		}
	}
}
