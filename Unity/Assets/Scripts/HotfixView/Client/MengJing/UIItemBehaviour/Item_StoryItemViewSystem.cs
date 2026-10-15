
using System;
using UnityEngine;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_StoryItem))]
	[EntitySystemOf(typeof(Scroll_Item_StoryItem))]
	public static partial class Scroll_Item_StoryItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_StoryItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_StoryItem self )
		{
			self.StoryConfig = null;
			self.ClickHandler = null;
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_StoryItem self, StoryConfig storyConfig, bool isCompleted,
		Action<int> clickHandler)
		{
			self.StoryConfig = storyConfig;
			self.ClickHandler = clickHandler;

			self.E_NameText.text = storyConfig.Name;
			self.E_CompleteText.gameObject.SetActive(isCompleted);
			self.E_HighlightImage.gameObject.SetActive(false);
			self.E_ClickButton.AddListener(self.OnClick);
		}

		public static void SetSelected(this Scroll_Item_StoryItem self, int storyId)
		{
			self.E_HighlightImage.gameObject.SetActive(self.StoryConfig != null && self.StoryConfig.Id == storyId);
		}

		private static void OnClick(this Scroll_Item_StoryItem self)
		{
			if (self.StoryConfig == null)
			{
				return;
			}

			self.ClickHandler?.Invoke(self.StoryConfig.Id);
		}
	}
}
