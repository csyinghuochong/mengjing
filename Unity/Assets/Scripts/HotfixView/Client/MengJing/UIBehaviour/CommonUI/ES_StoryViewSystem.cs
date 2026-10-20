using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_Story))]
    [FriendOf(typeof(ES_Story))]
    [FriendOf(typeof(Scroll_Item_StoryChapterItem))]
    [FriendOf(typeof(Scroll_Item_StoryItem))]
    [FriendOf(typeof(Scroll_Item_StoryChoiceItem))]
    public static partial class ES_StorySystem
    {
        private const string StoryChapterItemPrefabPath = "Assets/Bundles/UI/Item/Item_StoryChapterItem.prefab";
        private const string StoryItemPrefabPath = "Assets/Bundles/UI/Item/Item_StoryItem.prefab";
        private const string StoryChoiceItemPrefabPath = "Assets/Bundles/UI/Item/Item_StoryChoiceItem.prefab";

        [EntitySystem]
        private static void Awake(this ES_Story self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_PageTypeSetToggleGroup.AddListener(self.OnPageTypeSet);
            self.E_ConfirmChoiceButton.AddListenerAsync(self.OnConfirmChoice);

            self.InitializeStoryView();
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
            self.ShowStoryChapterConfigs.Clear();
            self.ShowStoryConfigs.Clear();
            self.ShowStoryChoiceConfigs.Clear();
            self.ScrollItemStoryChapterItems.Clear();
            self.ScrollItemStoryItems.Clear();
            self.ScrollItemStoryChoiceItems.Clear();
            self.DestroyWidget();
        }

        private static void OnPageTypeSet(this ES_Story self, int index)
        {
            self.EG_MainRectTransform.gameObject.SetActive(index == 0);
            self.EG_StoryRectTransform.gameObject.SetActive(index == 1);
        }

        private static void InitializeStoryView(this ES_Story self)
        {
            self.ShowStoryChapterConfigs.Clear();
            foreach (StoryChapterConfig config in StoryChapterConfigCategory.Instance.DataList)
            {
                self.ShowStoryChapterConfigs.Add(config);
            }

            self.RefreshChapterItems();

            for (int i = 0; i < self.ShowStoryChapterConfigs.Count; i++)
            {
                StoryChapterConfig config = self.ShowStoryChapterConfigs[i];
                if (!self.IsChapterUnlocked(config))
                {
                    continue;
                }

                self.OnSelectChapter(config.Id);
                return;
            }

            self.ClearStoryDetails();
        }

        private static void RefreshChapterItems(this ES_Story self)
        {
            Transform content = self.E_StoryChapterItemsScrollRect.content;
            GameObject prefab = self.LoadItemPrefab(StoryChapterItemPrefabPath);

            for (int i = 0; i < self.ShowStoryChapterConfigs.Count; i++)
            {
                if (!self.ScrollItemStoryChapterItems.TryGetValue(i, out EntityRef<Scroll_Item_StoryChapterItem> itemRef))
                {
                    Scroll_Item_StoryChapterItem newItem = self.AddChild<Scroll_Item_StoryChapterItem>();
                    GameObject itemGameObject = UnityEngine.Object.Instantiate(prefab, content);
                    newItem.BindTrans(itemGameObject.transform);
                    self.ScrollItemStoryChapterItems.Add(i, newItem);
                    itemRef = newItem;
                }

                Scroll_Item_StoryChapterItem item = itemRef;
                StoryChapterConfig config = self.ShowStoryChapterConfigs[i];
                item.OnUpdateUI(config, self.IsChapterUnlocked(config), self.OnSelectChapter);
                item.SetSelected(self.SelectedChapterId);
                item.uiTransform.gameObject.SetActive(true);
            }

            for (int i = self.ShowStoryChapterConfigs.Count; i < self.ScrollItemStoryChapterItems.Count; i++)
            {
                Scroll_Item_StoryChapterItem item = self.ScrollItemStoryChapterItems[i];
                item.uiTransform.gameObject.SetActive(false);
            }
        }

        private static void OnSelectChapter(this ES_Story self, int chapterId)
        {
            StoryChapterConfig chapterConfig = StoryChapterConfigCategory.Instance.GetOrDefault(chapterId);
            if (chapterConfig == null || !self.IsChapterUnlocked(chapterConfig))
            {
                return;
            }

            self.SelectedChapterId = chapterId;
            foreach (EntityRef<Scroll_Item_StoryChapterItem> itemRef in self.ScrollItemStoryChapterItems.Values)
            {
                Scroll_Item_StoryChapterItem item = itemRef;
                if (item?.uiTransform != null && item.uiTransform.gameObject.activeSelf)
                {
                    item.SetSelected(chapterId);
                }
            }

            self.ShowStoryConfigs.Clear();
            if (chapterConfig.Stories != null)
            {
                for (int i = 0; i < chapterConfig.Stories.Length; i++)
                {
                    StoryConfig storyConfig = StoryConfigCategory.Instance.GetOrDefault(chapterConfig.Stories[i]);
                    if (storyConfig != null)
                    {
                        self.ShowStoryConfigs.Add(storyConfig);
                    }
                }
            }

            self.RefreshStoryItems();
            if (self.ShowStoryConfigs.Count > 0)
            {
                self.OnSelectStory(self.ShowStoryConfigs[0].Id);
            }
            else
            {
                self.ClearStoryDetails();
            }
        }

        private static void RefreshStoryItems(this ES_Story self)
        {
            Transform content = self.E_StoryItemsScrollRect.content;
            GameObject prefab = self.LoadItemPrefab(StoryItemPrefabPath);

            for (int i = 0; i < self.ShowStoryConfigs.Count; i++)
            {
                if (!self.ScrollItemStoryItems.TryGetValue(i, out EntityRef<Scroll_Item_StoryItem> itemRef))
                {
                    Scroll_Item_StoryItem newItem = self.AddChild<Scroll_Item_StoryItem>();
                    GameObject itemGameObject = UnityEngine.Object.Instantiate(prefab, content);
                    newItem.BindTrans(itemGameObject.transform);
                    self.ScrollItemStoryItems.Add(i, newItem);
                    itemRef = newItem;
                }

                Scroll_Item_StoryItem item = itemRef;
                StoryConfig config = self.ShowStoryConfigs[i];
                item.OnUpdateUI(config, self.GetStoryInfo(config.Id) != null, self.OnSelectStory);
                item.SetSelected(self.SelectedStoryId);
                item.uiTransform.gameObject.SetActive(true);
            }

            for (int i = self.ShowStoryConfigs.Count; i < self.ScrollItemStoryItems.Count; i++)
            {
                Scroll_Item_StoryItem item = self.ScrollItemStoryItems[i];
                item.uiTransform.gameObject.SetActive(false);
            }
        }

        private static void OnSelectStory(this ES_Story self, int storyId)
        {
            StoryConfig storyConfig = StoryConfigCategory.Instance.GetOrDefault(storyId);
            if (storyConfig == null || !self.ContainsCurrentStory(storyId))
            {
                return;
            }

            self.SelectedStoryId = storyId;
            foreach (EntityRef<Scroll_Item_StoryItem> itemRef in self.ScrollItemStoryItems.Values)
            {
                Scroll_Item_StoryItem item = itemRef;
                if (item?.uiTransform != null && item.uiTransform.gameObject.activeSelf)
                {
                    item.SetSelected(storyId);
                }
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

            StoryInfo storyInfo = self.GetStoryInfo(storyId);
            self.SelectedChoiceId = storyInfo?.ChoiceId ?? 0;
            self.RefreshChoiceItems();
            self.RefreshStoryReply(storyInfo);
            self.E_ConfirmChoiceButton.interactable = storyInfo == null && self.SelectedChoiceId != 0;
        }

        private static void RefreshChoiceItems(this ES_Story self)
        {
            Transform content = self.E_StoryChoiceListScrollRect.content;
            GameObject prefab = self.LoadItemPrefab(StoryChoiceItemPrefabPath);

            for (int i = 0; i < self.ShowStoryChoiceConfigs.Count; i++)
            {
                if (!self.ScrollItemStoryChoiceItems.TryGetValue(i, out EntityRef<Scroll_Item_StoryChoiceItem> itemRef))
                {
                    Scroll_Item_StoryChoiceItem newItem = self.AddChild<Scroll_Item_StoryChoiceItem>();
                    GameObject itemGameObject = UnityEngine.Object.Instantiate(prefab, content);
                    newItem.BindTrans(itemGameObject.transform);
                    self.ScrollItemStoryChoiceItems.Add(i, newItem);
                    itemRef = newItem;
                }

                Scroll_Item_StoryChoiceItem item = itemRef;
                item.OnUpdateUI(self.ShowStoryChoiceConfigs[i], self.OnSelectChoice);
                item.SetSelected(self.SelectedChoiceId);
                item.uiTransform.gameObject.SetActive(true);
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
            foreach (EntityRef<Scroll_Item_StoryChoiceItem> itemRef in self.ScrollItemStoryChoiceItems.Values)
            {
                Scroll_Item_StoryChoiceItem item = itemRef;
                if (item?.uiTransform != null)
                {
                    item.SetSelected(choiceId);
                }
            }

            self.E_ConfirmChoiceButton.interactable = true;
        }

        private static async ETTask OnConfirmChoice(this ES_Story self)
        {
            if (self.SelectedStoryId == 0 || self.SelectedChoiceId == 0 ||
                self.GetStoryInfo(self.SelectedStoryId) != null || !self.ContainsCurrentChoice(self.SelectedChoiceId))
            {
                return;
            }

            int errorCode = await TaskClientNetHelper.StoryChoiceRequest(self.Root(), self.SelectedStoryId, self.SelectedChoiceId);
            if (self.IsDisposed)
            {
                return;
            }
            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
                return;
            }

            StoryInfo storyInfo = self.GetStoryInfo(self.SelectedStoryId);
            if (storyInfo != null)
            {
                self.SelectedChoiceId = storyInfo.ChoiceId;
            }
            self.RefreshStoryItems();
            self.RefreshStoryReply(storyInfo);
        }

        private static void RefreshStoryReply(this ES_Story self, StoryInfo storyInfo)
        {
            StoryChoiceConfig choiceConfig = storyInfo == null ? null : StoryChoiceConfigCategory.Instance.GetOrDefault(storyInfo.ChoiceId);
            bool showReply = choiceConfig != null && !string.IsNullOrEmpty(choiceConfig.ReplyText);

            self.E_StoryReplyText.text = showReply ? choiceConfig.ReplyText : string.Empty;
            self.E_StoryReplyText.gameObject.SetActive(showReply);
            self.E_StoryChoiceListScrollRect.gameObject.SetActive(!showReply);
        }

        private static bool IsChapterUnlocked(this ES_Story self, StoryChapterConfig config)
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
            self.ShowStoryConfigs.Clear();
            self.ShowStoryChoiceConfigs.Clear();
            self.E_StoryNameText.text = string.Empty;
            self.E_StoryDesText.text = string.Empty;
            self.E_StoryReplyText.text = string.Empty;
            self.E_StoryReplyText.gameObject.SetActive(false);
            self.E_StoryItemsScrollRect.gameObject.SetActive(true);
            self.RefreshStoryItems();
            self.RefreshChoiceItems();
            self.E_ConfirmChoiceButton.interactable = false;
        }
    }
}
