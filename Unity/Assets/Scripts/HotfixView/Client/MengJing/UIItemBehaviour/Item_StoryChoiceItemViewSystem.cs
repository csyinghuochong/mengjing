
using System;
using System.Collections.Generic;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_StoryChoiceItem))]
	[EntitySystemOf(typeof(Scroll_Item_StoryChoiceItem))]
	public static partial class Scroll_Item_StoryChoiceItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_StoryChoiceItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_StoryChoiceItem self )
		{
			self.StoryChoiceConfig = null;
			self.ClickHandler = null;
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_StoryChoiceItem self, StoryChoiceConfig storyChoiceConfig,
		Action<int> clickHandler)
		{
			self.StoryChoiceConfig = storyChoiceConfig;
			self.ClickHandler = clickHandler;

			self.E_NameText.text = storyChoiceConfig.ChoiceText;
			self.E_AddText.text = GetAddText(storyChoiceConfig);
			self.E_RewardText.text = GetRewardText(storyChoiceConfig.Reward);
			self.E_HighlightImage.gameObject.SetActive(false);
			self.E_ClickButton.AddListener(self.OnClick);
		}

		public static void SetSelected(this Scroll_Item_StoryChoiceItem self, int choiceId)
		{
			self.E_HighlightImage.gameObject.SetActive(self.StoryChoiceConfig != null && self.StoryChoiceConfig.Id == choiceId);
		}

		private static void OnClick(this Scroll_Item_StoryChoiceItem self)
		{
			if (self.StoryChoiceConfig == null)
			{
				return;
			}

			self.ClickHandler?.Invoke(self.StoryChoiceConfig.Id);
		}

		private static string GetAddText(StoryChoiceConfig config)
		{
			List<string> values = new();
			if (config.Affinity != 0)
			{
				values.Add($"亲和 {config.Affinity:+#;-#;0}");
			}
			if (config.Fun != 0)
			{
				values.Add($"趣味 {config.Fun:+#;-#;0}");
			}
			if (config.Violence != 0)
			{
				values.Add($"暴力 {config.Violence:+#;-#;0}");
			}

			return string.Join("  ", values);
		}

		private static string GetRewardText(string reward)
		{
			if (string.IsNullOrEmpty(reward))
			{
				return string.Empty;
			}

			string[] rewardInfo = reward.Split(';');
			if (rewardInfo.Length < 2 || !int.TryParse(rewardInfo[0], out int itemId))
			{
				return reward;
			}

			ItemConfig itemConfig = ItemConfigCategory.Instance.GetOrDefault(itemId);
			return itemConfig == null ? reward : $"{itemConfig.ItemName} x{rewardInfo[1]}";
		}
	}
}
