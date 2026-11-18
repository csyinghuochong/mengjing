
using System;
using UnityEngine;

namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_StoryChoiceItem))]
	[FriendOf(typeof(Scroll_Item_CommonItem))]
	[EntitySystemOf(typeof(Scroll_Item_StoryChoiceItem))]
	public static partial class Scroll_Item_StoryChoiceItemSystem 
	{
		private const string CommonItemPrefabPath = "Assets/Bundles/UI/Item/Item_CommonItem.prefab";
		private const float MaxRewardScale = 0.7f;

		[EntitySystem]
		private static void Awake(this Scroll_Item_StoryChoiceItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_StoryChoiceItem self )
		{
			self.StoryChoiceConfig = null;
			self.ClickHandler = null;
			self.RewardItems.Clear();
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this Scroll_Item_StoryChoiceItem self, StoryChoiceConfig storyChoiceConfig,
		Action<int> clickHandler)
		{
			self.StoryChoiceConfig = storyChoiceConfig;
			self.ClickHandler = clickHandler;

			self.E_NameText.text = storyChoiceConfig.ChoiceText;
			self.E_AddAffinityText.text = GetAddText("亲和", storyChoiceConfig.Affinity);
			self.E_AddFunText.text = GetAddText("趣味", storyChoiceConfig.Fun);
			self.E_AddViolenceText.text = GetAddText("暴力", storyChoiceConfig.Violence);
			self.RefreshRewards(storyChoiceConfig.Reward);
			self.E_ClickButton.AddListener(self.OnClick);
			self.E_CompleteButton.enabled = false;
		}

		public static void SetChoiceState(this Scroll_Item_StoryChoiceItem self, int choiceId, bool confirmed)
		{
			bool matches = self.StoryChoiceConfig != null && self.StoryChoiceConfig.Id == choiceId;
			self.E_SelectImage.gameObject.SetActive(matches && !confirmed);
			self.E_CompleteImage.gameObject.SetActive(matches && confirmed);
		}

		private static void OnClick(this Scroll_Item_StoryChoiceItem self)
		{
			if (self.StoryChoiceConfig == null)
			{
				return;
			}

			self.ClickHandler?.Invoke(self.StoryChoiceConfig.Id);
		}

		private static string GetAddText(string label, int value)
		{
			return $"{label} {value:+0;-0;+0}";
		}

		private static void RefreshRewards(this Scroll_Item_StoryChoiceItem self, string reward)
		{
			RectTransform rewardList = self.EG_RewardListRectTransform;
			GameObject prefab = null;
			int visibleCount = 0;
			foreach (string entry in (reward ?? string.Empty).Split('@', StringSplitOptions.RemoveEmptyEntries))
			{
				string[] itemInfo = entry.Split(';');
				if (itemInfo.Length < 2 || !int.TryParse(itemInfo[0], out int itemId) ||
					!int.TryParse(itemInfo[1], out int itemNum) || itemNum <= 0 || !ItemConfigCategory.Instance.Contain(itemId))
				{
					continue;
				}

				if (visibleCount == self.RewardItems.Count)
				{
					prefab ??= self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(CommonItemPrefabPath);
					Scroll_Item_CommonItem newItem = self.AddChild<Scroll_Item_CommonItem>();
					newItem.BindTrans(UnityEngine.Object.Instantiate(prefab, rewardList).transform);
					newItem.SetCacheMode(true);
					self.RewardItems.Add(newItem);
				}

				Scroll_Item_CommonItem item = self.RewardItems[visibleCount++];
				item.Refresh(new ItemInfo { ItemID = itemId, ItemNum = itemNum }, ItemOperateEnum.None);
				item.HideItemName();
				item.uiTransform.gameObject.SetActive(true);
			}

			for (int i = visibleCount; i < self.RewardItems.Count; i++)
			{
				Scroll_Item_CommonItem item = self.RewardItems[i];
				item.uiTransform.gameObject.SetActive(false);
			}

			rewardList.gameObject.SetActive(visibleCount > 0);
			if (visibleCount == 0)
			{
				return;
			}

			// 预制体的奖励区没有布局组件，按可用空间把道具图标横向居中。
			Scroll_Item_CommonItem firstItem = self.RewardItems[0];
			Vector2 itemSize = ((RectTransform)firstItem.uiTransform).rect.size;
			Rect rewardArea = rewardList.rect;
			float scale = Mathf.Min(MaxRewardScale, rewardArea.width / (itemSize.x * visibleCount), rewardArea.height / itemSize.y);
			float spacing = itemSize.x * scale;
			for (int i = 0; i < visibleCount; i++)
			{
				Scroll_Item_CommonItem item = self.RewardItems[i];
				RectTransform itemRect = (RectTransform)item.uiTransform;
				itemRect.localScale = Vector3.one * scale;
				itemRect.anchoredPosition = new Vector2((i - (visibleCount - 1) * 0.5f) * spacing, 0f);
			}
		}
	}
}
