using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_Story))]
    [FriendOf(typeof(ES_Story))]
    [FriendOf(typeof(Scroll_Item_StoryChoiceItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    public static partial class ES_StorySystem
    {
        private const string StoryChoiceItemPrefabPath = "Assets/Bundles/UI/Item/Item_StoryChoiceItem.prefab";

        [EntitySystem]
        private static void Awake(this ES_Story self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_PageTypeSetToggleGroup.AddListener(self.OnPageTypeSet);
            self.E_ConfirmChoiceButton.AddListenerAsync(self.OnConfirmChoice);
            self.E_StoryEndingReceiveButton.AddListenerAsync(self.OnStoryEndingReceive);

            self.InitializeStoryView();
            self.RefreshStoryValueBars();
            self.E_PageTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_Story self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.ShowStoryConfigs.Clear();
            self.ShowStoryChoiceConfigs.Clear();
            self.ShowEndingRewardItems.Clear();
            self.ChapterHeaders.Clear();
            self.StoryItems.Clear();
            self.ChapterStoryList = null;
            self.StoryItemTemplate = null;
            self.ScrollItemStoryChoiceItems.Clear();
            self.ScrollItemEndingRewardItems.Clear();
            self.DestroyWidget();
        }

        private static void OnPageTypeSet(this ES_Story self, int index)
        {
            self.EG_MainRectTransform.gameObject.SetActive(index == 0);
            self.EG_StoryRectTransform.gameObject.SetActive(index == 1);
            if (index == 1)
            {
                self.RefreshChapterItems();
                self.RefreshExpandedChapter();
            }
        }

        private static void InitializeStoryView(this ES_Story self)
        {
            RectTransform content = self.E_StoryItemsScrollRect.content;
            Transform chapterTemplate = content.Find("UIStoryChapterType");
            self.ChapterStoryList = (RectTransform)content.Find("UIStoryChapterItemListNode");
            self.StoryItemTemplate = self.ChapterStoryList.Find("UIStoryItem");
            chapterTemplate.gameObject.SetActive(false);
            self.StoryItemTemplate.gameObject.SetActive(false);
            self.ChapterStoryList.gameObject.SetActive(false);

            int firstUnlockedChapterId = 0;
            foreach (StoryChapterConfig config in StoryChapterConfigCategory.Instance.DataList)
            {
                Transform header = UnityEngine.Object.Instantiate(chapterTemplate, content);
                header.name = $"StoryChapter_{config.Id}";
                header.Find("Text_Name_Active").GetComponent<Text>().text = config.Name;
                header.Find("Text_Name_NoActive").GetComponent<Text>().text = config.Name;
                header.Find("Button_Click").GetComponent<Button>().AddListenerWithId(self.OnSelectChapter, config.Id);
                self.ChapterHeaders.Add(config.Id, header);
                header.gameObject.SetActive(true);

                if (firstUnlockedChapterId == 0 && self.IsChapterUnlocked(config))
                {
                    firstUnlockedChapterId = config.Id;
                }
            }

            self.SetExpandedChapter(firstUnlockedChapterId);
        }

        private static void RefreshChapterItems(this ES_Story self)
        {
            foreach (StoryChapterConfig config in StoryChapterConfigCategory.Instance.DataList)
            {
                Transform header = self.ChapterHeaders[config.Id];
                bool unlocked = self.IsChapterUnlocked(config);
                bool expanded = unlocked && self.ExpandedChapterId == config.Id;
                header.Find("Button_Click").GetComponent<Button>().interactable = unlocked;
                header.Find("Image_Select").gameObject.SetActive(expanded);
                header.Find("Text_Name_Active").gameObject.SetActive(unlocked);
                header.Find("Text_Name_NoActive").gameObject.SetActive(!unlocked);
                header.Find("Image_Lock").gameObject.SetActive(!unlocked);

                Transform arrow = header.Find("Image_ShouSuo");
                arrow.gameObject.SetActive(unlocked);
                arrow.localRotation = expanded ? Quaternion.Euler(0f, 0f, -90f) : Quaternion.identity;
            }
        }

        private static void OnSelectChapter(this ES_Story self, int chapterId)
        {
            StoryChapterConfig chapterConfig = StoryChapterConfigCategory.Instance.GetOrDefault(chapterId);
            if (chapterConfig == null || !self.IsChapterUnlocked(chapterConfig))
            {
                return;
            }

            self.SetExpandedChapter(self.ExpandedChapterId == chapterId ? 0 : chapterId);
        }

        private static void SetExpandedChapter(this ES_Story self, int chapterId)
        {
            self.ExpandedChapterId = chapterId;
            if (chapterId != 0)
            {
                // 先把共用列表移到末尾，再插到展开的章节标题之后。
                self.ChapterStoryList.SetAsLastSibling();
                self.ChapterStoryList.SetSiblingIndex(self.ChapterHeaders[chapterId].GetSiblingIndex() + 1);
            }

            self.RefreshChapterItems();
            self.RefreshExpandedChapter();
        }

        private static void RefreshExpandedChapter(this ES_Story self)
        {
            self.RefreshShowStoryConfigs();
            self.RefreshStoryItems();
            bool hasStories = self.ShowStoryConfigs.Count > 0;
            self.ChapterStoryList.gameObject.SetActive(hasStories);
            if (!hasStories)
            {
                self.ClearStoryDetails();
            }
            else if (!self.ContainsCurrentStory(self.SelectedStoryId))
            {
                self.OnSelectStory(self.ShowStoryConfigs[0]);
            }
            else
            {
                self.RefreshSelectedStoryChoice();
            }

            if (hasStories)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(self.ChapterStoryList);
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.E_StoryItemsScrollRect.content);
        }

        /// <summary>
        /// 只显示 EntryTaskId 已接取，且前面全部剧情都已完成选择的剧情。
        /// </summary>
        private static void RefreshShowStoryConfigs(this ES_Story self)
        {
            self.ShowStoryConfigs.Clear();
            StoryChapterConfig chapterConfig = StoryChapterConfigCategory.Instance.GetOrDefault(self.ExpandedChapterId);
            if (chapterConfig == null || chapterConfig.Stories == null)
            {
                return;
            }

            for (int i = 0; i < chapterConfig.Stories.Length; i++)
            {
                StoryConfig storyConfig = StoryConfigCategory.Instance.GetOrDefault(chapterConfig.Stories[i]);
                if (storyConfig != null && self.IsStoryEntryTaskAccepted(storyConfig) && self.IsPreviousStoriesChosen(storyConfig.Id))
                {
                    self.ShowStoryConfigs.Add(storyConfig);
                }
            }
        }

        private static void RefreshStoryItems(this ES_Story self)
        {
            for (int i = 0; i < self.ShowStoryConfigs.Count; i++)
            {
                if (i == self.StoryItems.Count)
                {
                    Transform newItem = UnityEngine.Object.Instantiate(self.StoryItemTemplate, self.ChapterStoryList);
                    newItem.Find("Button_Click").GetComponent<Button>().AddListenerWithId(self.OnStoryItemClicked, i);
                    self.StoryItems.Add(newItem);
                }

                Transform item = self.StoryItems[i];
                StoryConfig config = self.ShowStoryConfigs[i];
                item.Find("Text_Name").GetComponent<Text>().text = config.Name;
                item.Find("Image_Complete").gameObject.SetActive(self.GetStoryInfo(config.Id) != null);
                item.Find("Image_Select").gameObject.SetActive(config.Id == self.SelectedStoryId);
                item.gameObject.SetActive(true);
            }

            for (int i = self.ShowStoryConfigs.Count; i < self.StoryItems.Count; i++)
            {
                self.StoryItems[i].gameObject.SetActive(false);
            }
        }

        private static void OnStoryItemClicked(this ES_Story self, int index)
        {
            if (index < self.ShowStoryConfigs.Count && self.ShowStoryConfigs[index].Id != self.SelectedStoryId)
            {
                self.OnSelectStory(self.ShowStoryConfigs[index]);
            }
        }

        private static void OnSelectStory(this ES_Story self, StoryConfig storyConfig)
        {
            self.SelectedStoryId = storyConfig.Id;
            self.SelectedChoiceId = 0;
            for (int i = 0; i < self.ShowStoryConfigs.Count; i++)
            {
                self.StoryItems[i].Find("Image_Select").gameObject.SetActive(self.ShowStoryConfigs[i].Id == storyConfig.Id);
            }

            self.E_StoryNameText.text = storyConfig.Name;
            self.E_StoryDesText.text = storyConfig.Des;

            self.ShowStoryChoiceConfigs.Clear();
            if (storyConfig.Choice != null)
            {
                for (int i = 0; i < storyConfig.Choice.Length; i++)
                {
                    StoryChoiceConfig choiceConfig = StoryChoiceConfigCategory.Instance.GetOrDefault(storyConfig.Choice[i]);
                    if (choiceConfig != null)
                    {
                        self.ShowStoryChoiceConfigs.Add(choiceConfig);
                    }
                }
            }

            self.RefreshSelectedStoryChoice();
        }

        private static void RefreshSelectedStoryChoice(this ES_Story self)
        {
            StoryInfo storyInfo = self.GetStoryInfo(self.SelectedStoryId);
            if (storyInfo != null)
            {
                self.SelectedChoiceId = storyInfo.ChoiceId;
            }
            self.RefreshChoiceItems();
            self.RefreshStoryReply(storyInfo);
        }

        private static void RefreshChoiceItems(this ES_Story self)
        {
            Transform content = self.E_StoryChoiceListScrollRect.content;
            GameObject prefab = null;

            StoryInfo storyInfo = self.SelectedStoryId == 0 ? null : self.GetStoryInfo(self.SelectedStoryId);
            int chosenChoiceId = storyInfo?.ChoiceId ?? 0;
            bool hasChosen = chosenChoiceId != 0;

            for (int i = 0; i < self.ShowStoryChoiceConfigs.Count; i++)
            {
                if (!self.ScrollItemStoryChoiceItems.TryGetValue(i, out EntityRef<Scroll_Item_StoryChoiceItem> itemRef))
                {
                    prefab ??= self.LoadItemPrefab(StoryChoiceItemPrefabPath);
                    Scroll_Item_StoryChoiceItem newItem = self.AddChild<Scroll_Item_StoryChoiceItem>();
                    GameObject itemGameObject = UnityEngine.Object.Instantiate(prefab, content);
                    newItem.BindTrans(itemGameObject.transform);
                    self.ScrollItemStoryChoiceItems.Add(i, newItem);
                    itemRef = newItem;
                }

                Scroll_Item_StoryChoiceItem item = itemRef;
                StoryChoiceConfig choiceConfig = self.ShowStoryChoiceConfigs[i];
                item.OnUpdateUI(choiceConfig, self.OnSelectChoice);
                item.SetChoiceState(hasChosen ? chosenChoiceId : self.SelectedChoiceId, hasChosen);

                // 确认后只显示已确认的选项。
                item.uiTransform.gameObject.SetActive(!hasChosen || choiceConfig.Id == chosenChoiceId);
            }

            for (int i = self.ShowStoryChoiceConfigs.Count; i < self.ScrollItemStoryChoiceItems.Count; i++)
            {
                Scroll_Item_StoryChoiceItem item = self.ScrollItemStoryChoiceItems[i];
                item.uiTransform.gameObject.SetActive(false);
            }

            self.E_StoryChoiceListScrollRect.gameObject.SetActive(self.ShowStoryChoiceConfigs.Count > 0);
        }

        private static void OnSelectChoice(this ES_Story self, int choiceId)
        {
            if (self.GetStoryInfo(self.SelectedStoryId) != null || !self.ContainsCurrentChoice(choiceId))
            {
                return;
            }

            self.SelectedChoiceId = choiceId;
            self.E_ConfirmChoiceButton.interactable = !self.IsConfirmingChoice;
            foreach (EntityRef<Scroll_Item_StoryChoiceItem> itemRef in self.ScrollItemStoryChoiceItems.Values)
            {
                Scroll_Item_StoryChoiceItem item = itemRef;
                if (item?.uiTransform != null)
                {
                    item.SetChoiceState(choiceId, false);
                }
            }
        }

        private static async ETTask OnConfirmChoice(this ES_Story self)
        {
            int storyId = self.SelectedStoryId;
            int choiceId = self.SelectedChoiceId;
            if (self.IsConfirmingChoice || storyId == 0 || choiceId == 0 ||
                self.GetStoryInfo(storyId) != null || !self.ContainsCurrentChoice(choiceId))
            {
                return;
            }

            self.IsConfirmingChoice = true;
            self.E_ConfirmChoiceButton.interactable = false;
            try
            {
                int errorCode = await TaskClientNetHelper.StoryChoiceRequest(self.Root(), storyId, choiceId);
                if (self.IsDisposed)
                {
                    return;
                }
                if (errorCode != ErrorCode.ERR_Success)
                {
                    HintHelp.ShowErrorHint(self.Root(), errorCode);
                    return;
                }

                self.RefreshChapterItems();
                self.RefreshExpandedChapter();
                self.RefreshStoryValueBars();
            }
            finally
            {
                if (!self.IsDisposed)
                {
                    self.IsConfirmingChoice = false;
                    self.E_ConfirmChoiceButton.interactable = self.SelectedChoiceId != 0;
                }
            }
        }

        private static void RefreshStoryValueBars(this ES_Story self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            StoryHelper.GetStoryValues(taskComponent.StoryInfoList, out int affinity, out int fun, out int violence);

            GlobalValueConfigCategory globalValueConfig = GlobalValueConfigCategory.Instance;
            self.E_LodingValue_AffinityImage.fillAmount = GetValueProgress(affinity, globalValueConfig.AffinityMax);
            self.E_LodingValue_FunImage.fillAmount = GetValueProgress(fun, globalValueConfig.Fun);
            self.E_LodingValue_ViolenceImage.fillAmount = GetValueProgress(violence, globalValueConfig.Violence);

            self.RefreshStoryEnding(affinity, fun, violence);
        }

        private static float GetValueProgress(int value, int max)
        {
            if (max <= 0)
            {
                return 0f;
            }

            return Mathf.Clamp01((float)value / max);
        }

        /// <summary>
        /// 所有剧情都选择完成后才显示右侧结局，并根据当前属性值匹配结局。
        /// </summary>
        private static void RefreshStoryEnding(this ES_Story self, int affinity, int fun, int violence)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            bool showEnding = StoryHelper.IsAllStoryChosen(taskComponent.StoryInfoList);
            self.EG_MainRightRectTransform.gameObject.SetActive(showEnding);
            if (!showEnding)
            {
                return;
            }

            self.RefreshStoryEndingButton();

            StoryEndingConfig endingConfig = StoryHelper.GetStoryEndingConfig(affinity, fun, violence);
            if (endingConfig == null)
            {
                self.E_StoryEndingText.text = string.Empty;
                self.E_StoryEndingRewardListLoopVerticalScrollRect.SetVisible(false, 0);
                return;
            }

            self.E_StoryEndingText.text = $"{endingConfig.Name}\n{endingConfig.Des}";
            self.RefreshEndingRewards(endingConfig.Reward);
        }

        private static void RefreshStoryEndingButton(this ES_Story self)
        {
            bool rewarded = self.Root().GetComponent<TaskComponentC>().StoryEndingRewardId != 0;
            self.E_StoryEndingReceiveButton.interactable = !rewarded;

            UnityEngine.UI.Text label = self.E_StoryEndingReceiveButton.GetComponentInChildren<UnityEngine.UI.Text>(true);
            if (label != null)
            {
                label.text = rewarded ? "已领取" : "领取奖励";
            }
        }

        private static void RefreshEndingRewards(this ES_Story self, string reward)
        {
            self.ShowEndingRewardItems.Clear();
            if (!CommonHelp.IfNull(reward))
            {
                string[] rewards = reward.Split('@');
                for (int i = 0; i < rewards.Length; i++)
                {
                    if (CommonHelp.IfNull(rewards[i]))
                    {
                        continue;
                    }

                    string[] itemInfo = rewards[i].Split(';');
                    if (itemInfo.Length < 2 || !int.TryParse(itemInfo[0], out int itemId) || !int.TryParse(itemInfo[1], out int itemNum))
                    {
                        continue;
                    }
                    if (!ItemConfigCategory.Instance.Contain(itemId))
                    {
                        continue;
                    }

                    self.ShowEndingRewardItems.Add(new ItemInfo { ItemID = itemId, ItemNum = itemNum });
                }
            }

            self.E_StoryEndingRewardListLoopVerticalScrollRect.AddItemRefreshListener(self.OnEndingRewardItemRefresh);
            self.AddEndingRewardItems(self.ShowEndingRewardItems.Count);
            self.E_StoryEndingRewardListLoopVerticalScrollRect.SetVisible(self.ShowEndingRewardItems.Count > 0, self.ShowEndingRewardItems.Count);
        }

        private static void AddEndingRewardItems(this ES_Story self, int count)
        {
            foreach (EntityRef<Scroll_Item_CommonItem> itemRef in self.ScrollItemEndingRewardItems.Values)
            {
                Scroll_Item_CommonItem item = itemRef;
                item?.Dispose();
            }
            self.ScrollItemEndingRewardItems.Clear();

            for (int i = 0; i < count; i++)
            {
                Scroll_Item_CommonItem item = self.AddChild<Scroll_Item_CommonItem>(true);
                self.ScrollItemEndingRewardItems.Add(i, item);
            }
        }

        private static void OnEndingRewardItemRefresh(this ES_Story self, Transform transform, int index)
        {
            if (index < 0 || index >= self.ShowEndingRewardItems.Count)
            {
                return;
            }

            foreach (EntityRef<Scroll_Item_CommonItem> itemRef in self.ScrollItemEndingRewardItems.Values)
            {
                Scroll_Item_CommonItem item = itemRef;
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_CommonItem rewardItem = self.ScrollItemEndingRewardItems[index].BindTrans(transform);
            rewardItem.Refresh(self.ShowEndingRewardItems[index], ItemOperateEnum.None);
        }

        private static async ETTask OnStoryEndingReceive(this ES_Story self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            if (taskComponent.StoryEndingRewardId != 0)
            {
                return;
            }

            int errorCode = await TaskClientNetHelper.StoryEndingRewardRequest(self.Root());
            if (self.IsDisposed)
            {
                return;
            }
            if (errorCode == ErrorCode.ERR_AlreadyReceived)
            {
                self.RefreshStoryEndingButton();
                return;
            }
            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
                return;
            }

            self.RefreshStoryEndingButton();
            HintHelp.ShowHint(self.Root(), "领取成功");
        }

        private static void RefreshStoryReply(this ES_Story self, StoryInfo storyInfo)
        {
            StoryChoiceConfig choiceConfig = storyInfo == null ? null : StoryChoiceConfigCategory.Instance.GetOrDefault(storyInfo.ChoiceId);
            bool showReply = choiceConfig != null && !string.IsNullOrEmpty(choiceConfig.ReplyText);

            self.E_StoryReplyText.text = showReply ? choiceConfig.ReplyText : string.Empty;
            self.E_StoryReplyText.gameObject.SetActive(showReply);
            self.E_ConfirmChoiceButton.gameObject.SetActive(storyInfo == null && self.ShowStoryChoiceConfigs.Count > 0);
            self.E_ConfirmChoiceButton.interactable = !self.IsConfirmingChoice && self.SelectedChoiceId != 0;
        }

        /// <summary>
        /// 章节是否解锁：章节中第一个剧情的 EntryTaskId 已接取，且它前面的全部剧情都已完成选择。
        /// </summary>
        private static bool IsChapterUnlocked(this ES_Story self, StoryChapterConfig config)
        {
            if (config.Stories == null || config.Stories.Length == 0)
            {
                return false;
            }

            StoryConfig firstStoryConfig = StoryConfigCategory.Instance.GetOrDefault(config.Stories[0]);
            return firstStoryConfig != null
                   && self.IsStoryEntryTaskAccepted(firstStoryConfig)
                   && self.IsPreviousStoriesChosen(firstStoryConfig.Id);
        }

        /// <summary>
        /// 当前剧情之前的全部剧情是否都已完成选择。
        /// </summary>
        private static bool IsPreviousStoriesChosen(this ES_Story self, int storyId)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            List<StoryConfig> storyConfigs = StoryConfigCategory.Instance.DataList;
            for (int i = 0; i < storyConfigs.Count; i++)
            {
                if (storyConfigs[i].Id == storyId)
                {
                    return true;
                }

                if (!StoryHelper.ContainsStory(taskComponent.StoryInfoList, storyConfigs[i].Id))
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// 剧情的 EntryTaskId 是否已接取（EntryTaskId 为 0 表示无需接取）。
        /// </summary>
        private static bool IsStoryEntryTaskAccepted(this ES_Story self, StoryConfig config)
        {
            if (config.EntryTaskId == 0)
            {
                return true;
            }

            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            return taskComponent.IsTaskFinished(config.EntryTaskId) || taskComponent.GetTaskById(config.EntryTaskId) != null;
        }

        private static StoryInfo GetStoryInfo(this ES_Story self, int storyId)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            for (int i = 0; i < taskComponent.StoryInfoList.Count; i++)
            {
                if (taskComponent.StoryInfoList[i].StroryId == storyId)
                {
                    return taskComponent.StoryInfoList[i];
                }
            }

            return null;
        }

        private static bool ContainsCurrentStory(this ES_Story self, int storyId)
        {
            for (int i = 0; i < self.ShowStoryConfigs.Count; i++)
            {
                if (self.ShowStoryConfigs[i].Id == storyId)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsCurrentChoice(this ES_Story self, int choiceId)
        {
            for (int i = 0; i < self.ShowStoryChoiceConfigs.Count; i++)
            {
                if (self.ShowStoryChoiceConfigs[i].Id == choiceId)
                {
                    return true;
                }
            }

            return false;
        }

        private static GameObject LoadItemPrefab(this ES_Story self, string path)
        {
            if (!self.AssetList.Contains(path))
            {
                self.AssetList.Add(path);
            }

            return self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
        }

        private static void ClearStoryDetails(this ES_Story self)
        {
            self.SelectedStoryId = 0;
            self.SelectedChoiceId = 0;
            self.ShowStoryChoiceConfigs.Clear();
            self.E_StoryNameText.text = string.Empty;
            self.E_StoryDesText.text = string.Empty;
            self.RefreshChoiceItems();
            self.RefreshStoryReply(null);
        }
    }
}
