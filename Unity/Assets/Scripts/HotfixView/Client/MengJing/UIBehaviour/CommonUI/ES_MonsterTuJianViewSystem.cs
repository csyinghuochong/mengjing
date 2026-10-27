using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_MonsterTuJian))]
    [FriendOfAttribute(typeof(ES_MonsterTuJian))]
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    public static partial class ES_MonsterTuJianSystem
    {
        private const string SkillItemPrefabPath = "Assets/Bundles/UI/Item/Item_CommonSkillItem.prefab";

        [EntitySystem]
        private static void Awake(this ES_MonsterTuJian self, Transform transform)
        {
            self.uiTransform = transform;
            self.LeftContent = UIFindHelper.FindDeepChild<Transform>(transform.gameObject, "Left/Scroll View/Viewport/LeftContent").gameObject;
            self.ChapterTemplate = UIFindHelper.FindDeepChild<Transform>(transform.gameObject, "Left/Scroll View/Viewport/LeftContent/UIMonsterTuJianType").gameObject;
            self.MonsterListTemplate = UIFindHelper.FindDeepChild<Transform>(transform.gameObject, "Left/Scroll View/Viewport/LeftContent/UIMonsterTuJianItemListNode").gameObject;

            self.ChapterTemplate.SetActive(false);
            self.MonsterListTemplate.SetActive(false);
            self.E_RewardListLoopVerticalScrollRect.AddItemRefreshListener(self.OnRewardItemRefresh);
            self.InitMonsterTuJian();
        }

        [EntitySystem]
        private static void Destroy(this ES_MonsterTuJian self)
        {
            self.E_RewardListLoopVerticalScrollRect.dataSource.scrollMoveEvent = null;
            self.ShowRewardItems.Clear();
            self.DestroyWidget();
        }

        private static void InitMonsterTuJian(this ES_MonsterTuJian self)
        {
            List<DungeonSectionConfig> chapters = DungeonSectionConfigCategory.Instance.GetAll().Values.OrderBy(config => config.Id).ToList();
            int firstChapterId = 0;
            int firstMonsterId = 0;

            foreach (DungeonSectionConfig chapter in chapters)
            {
                List<int> monsterIds = self.GetChapterMonsters(chapter);
                self.ChapterMonsters.Add(chapter.Id, monsterIds);

                GameObject chapterHeader = UnityEngine.Object.Instantiate(self.ChapterTemplate, self.LeftContent.transform);
                chapterHeader.name = $"MonsterChapter_{chapter.Id}";
                chapterHeader.SetActive(true);
                self.SetChapterTitle(chapterHeader, chapter);

                int chapterId = chapter.Id;
                Button chapterButton = chapterHeader.transform.Find("ImageButton").GetComponent<Button>();
                chapterButton.AddListener(() => self.OnChapterClicked(chapterId));

                GameObject monsterList = UnityEngine.Object.Instantiate(self.MonsterListTemplate, self.LeftContent.transform);
                monsterList.name = $"MonsterChapterList_{chapter.Id}";
                monsterList.SetActive(false);

                self.ChapterHeaders.Add(chapter.Id, chapterHeader);
                self.ChapterMonsterLists.Add(chapter.Id, monsterList);

                if (firstChapterId == 0 && monsterIds.Count > 0)
                {
                    firstChapterId = chapter.Id;
                    firstMonsterId = monsterIds[0];
                }
            }

            if (firstChapterId != 0)
            {
                self.SetChapterExpanded(firstChapterId, true);
                self.SelectMonster(firstMonsterId);
            }
            else
            {
                self.ClearMonsterDetail();
            }

            self.RebuildChapterLayout();
        }

        private static List<int> GetChapterMonsters(this ES_MonsterTuJian self, DungeonSectionConfig chapter)
        {
            List<int> result = new();
            HashSet<int> addedMonsters = new();

            if (chapter.RandomArea == null)
            {
                return result;
            }

            foreach (int dungeonId in chapter.RandomArea)
            {
                DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.GetOrDefault(dungeonId);
                if (dungeonConfig == null || dungeonConfig.MonsterPosition == 0)
                {
                    continue;
                }

                int monsterPositionId = dungeonConfig.MonsterPosition;
                HashSet<int> visitedPositions = new();
                while (monsterPositionId != 0 && visitedPositions.Add(monsterPositionId))
                {
                    MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.GetOrDefault(monsterPositionId);
                    if (monsterPosition == null)
                    {
                        break;
                    }

                    if (monsterPosition.MonsterID != null)
                    {
                        foreach (int monsterId in monsterPosition.MonsterID)
                        {
                            if (!MonsterConfigCategory.Instance.Contain(monsterId))
                            {
                                continue;
                            }

                            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
                            if (monsterConfig.MonsterType != MonsterTypeEnum.Normal &&
                                monsterConfig.MonsterType != MonsterTypeEnum.Elite &&
                                monsterConfig.MonsterType != MonsterTypeEnum.Boss)
                            {
                                continue;
                            }

                            if (addedMonsters.Add(monsterId))
                            {
                                result.Add(monsterId);
                            }

                        }
                    }

                    if (monsterPosition.NextID == monsterPositionId)
                    {
                        break;
                    }
                    monsterPositionId = monsterPosition.NextID;
                }
            }

            return result;
        }

        private static void SetChapterTitle(this ES_MonsterTuJian self, GameObject chapterHeader, DungeonSectionConfig chapter)
        {
            string title = string.IsNullOrEmpty(chapter.Name) ? chapter.ChapterName : $"{chapter.ChapterName} {chapter.Name}";
            Transform unselected = chapterHeader.transform.Find("ImageSelect_0/TaskTypeName_0");
            Transform selected = chapterHeader.transform.Find("ImageSelect_1/TaskTypeName_1");
            if (unselected != null)
            {
                unselected.GetComponent<Text>().text = title;
            }
            if (selected != null)
            {
                selected.GetComponent<Text>().text = title;
            }
        }

        private static void CreateMonsterItems(this ES_MonsterTuJian self, GameObject monsterList, List<int> monsterIds)
        {
            Transform itemTemplate = monsterList.transform.Find("UIMonsterTuJianItem");
            itemTemplate.gameObject.SetActive(false);
            ResourcesLoaderComponent resourcesLoader = self.Root().GetComponent<ResourcesLoaderComponent>();
            foreach (int monsterIdValue in monsterIds)
            {
                int monsterId = monsterIdValue;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
                GameObject item = UnityEngine.Object.Instantiate(itemTemplate.gameObject, monsterList.transform);
                item.name = $"Monster_{monsterId}";

                Transform iconTransform = item.transform.Find("Image_ItemIcon");
                if (iconTransform != null && !string.IsNullOrEmpty(monsterConfig.MonsterHeadIcon))
                {
                    string iconPath = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
                    iconTransform.GetComponent<Image>().sprite = resourcesLoader.LoadAssetSync<Sprite>(iconPath);
                }

                item.transform.Find("Text_Name").GetComponent<Text>().text = monsterConfig.MonsterName;
                
                Transform selected = item.transform.Find("Image_XuanZhong");
                if (selected != null)
                {
                    selected.gameObject.SetActive(false);
                }

                Button button = item.transform.Find("Image_ItemButton").GetComponent<Button>();
                button.AddListener(() => self.SelectMonster(monsterId));
                item.SetActive(true);
                if (!self.MonsterItems.TryGetValue(monsterId, out List<GameObject> monsterItems))
                {
                    monsterItems = new List<GameObject>();
                    self.MonsterItems.Add(monsterId, monsterItems);
                }
                monsterItems.Add(item);
            }
        }

        private static void EnsureChapterInitialized(this ES_MonsterTuJian self, int chapterId)
        {
            if (!self.InitializedChapters.Add(chapterId))
            {
                return;
            }

            if (self.ChapterMonsterLists.TryGetValue(chapterId, out GameObject monsterList) &&
                self.ChapterMonsters.TryGetValue(chapterId, out List<int> monsters))
            {
                self.CreateMonsterItems(monsterList, monsters);
            }
        }

        private static void OnChapterClicked(this ES_MonsterTuJian self, int chapterId)
        {
            bool expand = self.SelectedChapterId != chapterId || !self.ChapterMonsterLists[chapterId].activeSelf;
            self.SetChapterExpanded(chapterId, expand);

            if (expand && self.ChapterMonsters.TryGetValue(chapterId, out List<int> monsters) && monsters.Count > 0)
            {
                self.SelectMonster(monsters[0]);
            }
        }

        private static void SetChapterExpanded(this ES_MonsterTuJian self, int chapterId, bool expanded)
        {
            if (expanded)
            {
                self.EnsureChapterInitialized(chapterId);
            }

            foreach ((int id, GameObject list) in self.ChapterMonsterLists)
            {
                bool active = expanded && id == chapterId;
                list.SetActive(active);
                self.SetChapterVisual(self.ChapterHeaders[id], active);
            }

            self.SelectedChapterId = expanded ? chapterId : 0;
            self.RebuildChapterLayout();
        }

        private static void SetChapterVisual(this ES_MonsterTuJian self, GameObject header, bool selected)
        {
            Transform unselected = header.transform.Find("ImageSelect_0");
            Transform selectedImage = header.transform.Find("ImageSelect_1");
            if (unselected != null)
            {
                unselected.gameObject.SetActive(!selected);
            }
            if (selectedImage != null)
            {
                selectedImage.gameObject.SetActive(selected);
            }
        }

        private static void RebuildChapterLayout(this ES_MonsterTuJian self)
        {
            foreach (GameObject monsterList in self.ChapterMonsterLists.Values)
            {
                if (monsterList.activeSelf)
                {
                    LayoutRebuilder.ForceRebuildLayoutImmediate(monsterList.GetComponent<RectTransform>());
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(self.LeftContent.GetComponent<RectTransform>());
        }

        private static void SelectMonster(this ES_MonsterTuJian self, int monsterId)
        {
            if (!MonsterConfigCategory.Instance.Contain(monsterId))
            {
                return;
            }

            self.SelectedMonsterId = monsterId;
            foreach ((int id, List<GameObject> items) in self.MonsterItems)
            {
                foreach (GameObject item in items)
                {
                    Transform selected = item.transform.Find("Image_XuanZhong");
                    if (selected != null)
                    {
                        selected.gameObject.SetActive(id == monsterId);
                    }
                }
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            self.E_Text_NameText.text = monsterConfig.MonsterName;
            self.E_MonsterTypeText.text = GetMonsterTypeName(monsterConfig.MonsterType);
            self.E_BackstoryText.text = !string.IsNullOrEmpty(monsterConfig.Backstory)
                    ? monsterConfig.Backstory
                    : "暂无背景故事";

            self.ShowMonsterModel(monsterConfig);
            self.RefreshSkills(monsterConfig);
            self.RefreshRewards(monsterId);
        }

        private static string GetMonsterTypeName(int monsterType)
        {
            return monsterType switch
            {
                MonsterTypeEnum.Normal => "小怪",
                MonsterTypeEnum.Elite => "精英",
                MonsterTypeEnum.Boss => "首领",
                MonsterTypeEnum.ZhaoHuan => "召唤物",
                MonsterTypeEnum.SceneItem => "场景物",
                _ => "未知"
            };
        }

        private static void ShowMonsterModel(this ES_MonsterTuJian self, MonsterConfig monsterConfig)
        {
            string[] position = string.IsNullOrEmpty(monsterConfig.ModelShowPosi) ? null : monsterConfig.ModelShowPosi.Split(',');
            if (position != null && position.Length >= 5 &&
                float.TryParse(position[0], out float x) &&
                float.TryParse(position[1], out float y) &&
                float.TryParse(position[2], out float z) &&
                float.TryParse(position[3], out float fieldOfView) &&
                float.TryParse(position[4], out float rotationY))
            {
                self.ES_ModelShow.SetCameraPosition(new Vector3(x, y, z));
                self.ES_ModelShow.Camera.fieldOfView = fieldOfView;
                self.ES_ModelShow.RotationY = rotationY;
            }
            else
            {
                self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 170f, 400f));
                self.ES_ModelShow.Camera.fieldOfView = 60f;
                self.ES_ModelShow.RotationY = 0f;
            }

            self.ES_ModelShow.ShowOtherModel($"Monster/{monsterConfig.MonsterModelID}").Coroutine();
        }

        private static void RefreshSkills(this ES_MonsterTuJian self, MonsterConfig monsterConfig)
        {
            List<int> skillIds = new();
            if (monsterConfig.ActSkillID > 0 && SkillConfigCategory.Instance.Contain(monsterConfig.ActSkillID))
            {
                skillIds.Add(monsterConfig.ActSkillID);
            }

            if (monsterConfig.SkillID != null)
            {
                foreach (int skillId in monsterConfig.SkillID)
                {
                    if (skillId > 0 && SkillConfigCategory.Instance.Contain(skillId) && !skillIds.Contains(skillId))
                    {
                        skillIds.Add(skillId);
                    }
                }
            }

            if (self.SkillItems.Count < skillIds.Count)
            {
                GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(SkillItemPrefabPath);

                while (self.SkillItems.Count < skillIds.Count)
                {
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_CommonSkillItemsScrollRect.content);
                    go.SetActive(true);
                    Scroll_Item_CommonSkillItem item = self.AddChild<Scroll_Item_CommonSkillItem>();
                    item.BindTrans(go.transform);
                    self.SkillItems.Add(item);
                }
            }

            for (int i = 0; i < self.SkillItems.Count; i++)
            {
                Scroll_Item_CommonSkillItem item = self.SkillItems[i];
                bool show = i < skillIds.Count;
                item.uiTransform.gameObject.SetActive(show);
                if (show)
                {
                    item.OnUpdateUI(skillIds[i], ABAtlasTypes.RoleSkillIcon);
                    self.BindSkillItemScrollDrag(item);
                }
            }

            self.E_CommonSkillItemsScrollRect.verticalNormalizedPosition = 1f;
        }

        /// <summary>
        /// 技能图标上挂有 EventTrigger（点击弹出技能tips），它会拦截拖拽事件导致列表无法滑动。
        /// 这里把拖拽事件转发给父级 ScrollRect，使在技能图标上上下拖动也能滑动列表。
        /// </summary>
        private static void BindSkillItemScrollDrag(this ES_MonsterTuJian self, Scroll_Item_CommonSkillItem item)
        {
            ScrollRect scrollRect = self.E_CommonSkillItemsScrollRect;
            EventTrigger eventTrigger = item.E_ImageIconEventTrigger;

            // OnUpdateUI 可能因配置缺失提前返回而没有清空事件，先移除旧的拖拽事件避免重复注册。
            eventTrigger.triggers.RemoveAll(entry => entry.eventID == EventTriggerType.BeginDrag ||
                                                    entry.eventID == EventTriggerType.Drag ||
                                                    entry.eventID == EventTriggerType.EndDrag);
            eventTrigger.RegisterEvent(EventTriggerType.BeginDrag, pdata => scrollRect.OnBeginDrag(pdata as PointerEventData));
            eventTrigger.RegisterEvent(EventTriggerType.Drag, pdata => scrollRect.OnDrag(pdata as PointerEventData));
            eventTrigger.RegisterEvent(EventTriggerType.EndDrag, pdata => scrollRect.OnEndDrag(pdata as PointerEventData));
        }

        private static void RefreshRewards(this ES_MonsterTuJian self, int monsterId)
        {
            List<RewardItem> rewards = DropHelper.Show_MonsterDropNoRepeat(monsterId, 1f, true).Where(reward => ItemConfigCategory.Instance.Contain(reward.ItemID)).OrderByDescending(reward => ItemConfigCategory.Instance.Get(reward.ItemID).ItemQuality).ToList();

            self.ShowRewardItems.Clear();
            foreach (RewardItem reward in rewards)
            {
                self.ShowRewardItems.Add(new ItemInfo { ItemID = reward.ItemID, ItemNum = reward.ItemNum });
            }

            self.AddUIScrollItems(ref self.ScrollItemRewardItems, self.ShowRewardItems.Count);
            self.E_RewardListLoopVerticalScrollRect.SetVisible(true, self.ShowRewardItems.Count);
        }

        private static void OnRewardItemRefresh(this ES_MonsterTuJian self, Transform transform, int index)
        {
            if (index < 0 || index >= self.ShowRewardItems.Count)
            {
                return;
            }

            foreach (Scroll_Item_CommonItem item in self.ScrollItemRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_CommonItem rewardItem = self.ScrollItemRewardItems[index].BindTrans(transform);
            rewardItem.Refresh(self.ShowRewardItems[index], ItemOperateEnum.None);
        }

        private static void ClearMonsterDetail(this ES_MonsterTuJian self)
        {
            self.E_Text_NameText.text = "暂无怪物";
            self.E_MonsterTypeText.text = string.Empty;
            self.E_BackstoryText.text = "暂无背景故事";
        }
    }
}
