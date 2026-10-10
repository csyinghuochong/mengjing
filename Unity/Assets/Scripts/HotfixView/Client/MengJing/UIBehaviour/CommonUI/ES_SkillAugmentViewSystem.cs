
using System;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_SkillAugmentItem))]
	[EntitySystemOf(typeof(ES_SkillAugment))]
	[FriendOfAttribute(typeof(ES_SkillAugment))]
	public static partial class ES_SkillAugmentSystem 
	{
		private const float WheelSnapTargetAngle = -45f;
		private const float WheelSnapDuration = 0.2f;
		private const float WheelLineFadeAngle = 15f;
		private const string SkillAugmentItemPrefabPath = "Assets/Bundles/UI/Item/Item_SkillAugmentItem.prefab";

		[EntitySystem]
		private static void Awake(this ES_SkillAugment self,Transform transform)
		{
			self.uiTransform = transform;

			self.GenerateSkillAugmentItems(self.EG_ItemList_1RectTransform, self.EG_SkillAugmentItem_1RectTransform, 2, -15f, 60f, 164f);
			self.GenerateSkillAugmentItems(self.EG_ItemList_2RectTransform, self.EG_SkillAugmentItem_2RectTransform, 3, 0f, 30f, 348f);

			// 两个点击区的圆心重合，外圈尺寸更大。让内圈处于外圈上方，
			// 否则外圈会拦截内圈范围内的所有射线事件。
			Transform innerHitArea = self.E_WheelHitArea_1Image.transform;
			Transform outerHitArea = self.E_WheelHitArea_2Image.transform;
			if (outerHitArea.GetSiblingIndex() > innerHitArea.GetSiblingIndex())
			{
				outerHitArea.SetSiblingIndex(innerHitArea.GetSiblingIndex());
			}

			self.SetWheelLineAlpha(self.EG_Line_2RectTransform, 0f);
			self.SetWheelLineAlpha(self.EG_Line_3RectTransform, 0f);
			self.RegisterWheelDrag(self.E_WheelHitArea_1EventTrigger, self.EG_RotatingRoot_1RectTransform, self.EG_ItemList_1RectTransform, self.EG_Line_2RectTransform, 0);
			self.RegisterWheelDrag(self.E_WheelHitArea_2EventTrigger, self.EG_RotatingRoot_2RectTransform, self.EG_ItemList_2RectTransform, self.EG_Line_3RectTransform, 1);
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillAugment self)
		{
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < self.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
			}

			self.AssetList.Clear();
			self.ScrollItemSkillAugmentItems.Clear();

			self.EG_RotatingRoot_1RectTransform.DOKill();
			self.EG_RotatingRoot_2RectTransform.DOKill();
			self.E_WheelHitArea_1EventTrigger.triggers.Clear();
			self.E_WheelHitArea_2EventTrigger.triggers.Clear();
			self.DestroyWidget();
		}

		public static void RefreshSkillAugmentItems(this ES_SkillAugment self)
		{
			List<SkillAugmentInfo> skillAugmentList = self.Root().GetComponent<SkillSetComponentC>().SkillAugmentList;
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			Transform content = self.E_SkillAugmentItemsScrollRect.content;

			for (int i = 0; i < skillAugmentList.Count; i++)
			{
				if (!self.ScrollItemSkillAugmentItems.ContainsKey(i))
				{
					Scroll_Item_SkillAugmentItem item = self.AddChild<Scroll_Item_SkillAugmentItem>();
					if (!self.AssetList.Contains(SkillAugmentItemPrefabPath))
					{
						self.AssetList.Add(SkillAugmentItemPrefabPath);
					}

					GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(SkillAugmentItemPrefabPath);
					GameObject itemGameObject = UnityEngine.Object.Instantiate(prefab, content);
					item.BindTrans(itemGameObject.transform);
					self.ScrollItemSkillAugmentItems.Add(i, item);
				}

				Scroll_Item_SkillAugmentItem scrollItem = self.ScrollItemSkillAugmentItems[i];
				scrollItem.SetClickHandler(self.OnSelectSkillAugment);
				scrollItem.OnUpdateUI(skillAugmentList[i]);
				scrollItem.uiTransform.gameObject.SetActive(true);
			}

			for (int i = skillAugmentList.Count; i < self.ScrollItemSkillAugmentItems.Count; i++)
			{
				Scroll_Item_SkillAugmentItem scrollItem = self.ScrollItemSkillAugmentItems[i];
				if (scrollItem.uiTransform != null)
				{
					scrollItem.uiTransform.gameObject.SetActive(false);
				}
			}

			if (skillAugmentList.Count == 0)
			{
				self.SelectedBaseSkillId = 0;
				self.ClearWheelSkills();
				return;
			}

			SkillAugmentInfo selectedSkillAugment = skillAugmentList.Find(info => info.BaseSkillId == self.SelectedBaseSkillId);
			self.OnSelectSkillAugment(selectedSkillAugment ?? skillAugmentList[0]);
		}

		private static void OnSelectSkillAugment(this ES_SkillAugment self, SkillAugmentInfo skillAugmentInfo)
		{
			if (skillAugmentInfo == null)
			{
				return;
			}

			self.SelectedBaseSkillId = skillAugmentInfo.BaseSkillId;
			foreach (EntityRef<Scroll_Item_SkillAugmentItem> itemRef in self.ScrollItemSkillAugmentItems.Values)
			{
				Scroll_Item_SkillAugmentItem item = itemRef;
				if (item?.uiTransform != null && item.uiTransform.gameObject.activeSelf)
				{
					item.OnSetSelected(self.SelectedBaseSkillId);
				}
			}

			self.SetSkillAugmentDescription(0);
			self.SyncWheelSkills(skillAugmentInfo);
		}

		private static void SyncWheelSkills(this ES_SkillAugment self, SkillAugmentInfo skillAugmentInfo)
		{
			SkillAugmentOptionsConfig augmentOptions = SkillAugmentOptionsConfigCategory.Instance.GetOrDefault(skillAugmentInfo.BaseSkillId);
			if (augmentOptions == null)
			{
				self.ClearWheelSkills();
				return;
			}

			self.SetBaseSkillIcon(skillAugmentInfo.BaseSkillId);

			int selectedAugment1 = self.GetSelectedAugmentId(skillAugmentInfo, 0);
			int selectedAugment2 = self.GetSelectedAugmentId(skillAugmentInfo, 1);
			bool slot1Unlocked = self.IsAugmentSlotUnlocked(0);
			bool slot2Unlocked = self.IsAugmentSlotUnlocked(1);
			self.SetWheelAugmentItems(self.EG_RotatingRoot_1RectTransform, self.EG_ItemList_1RectTransform, augmentOptions.SkillAugmentIds1, selectedAugment1, 0, slot1Unlocked);
			self.SetWheelAugmentItems(self.EG_RotatingRoot_2RectTransform, self.EG_ItemList_2RectTransform, augmentOptions.SkillAugmentIds2, selectedAugment2, 1, slot2Unlocked);
		}

		private static bool IsAugmentSlotUnlocked(this ES_SkillAugment self, int tierIndex)
		{
			return self.GetLearnedSkillLevel(self.SelectedBaseSkillId) >= tierIndex + 2;
		}

		private static int GetLearnedSkillLevel(this ES_SkillAugment self, int baseSkillId)
		{
			if (baseSkillId == 0)
			{
				return 0;
			}

			int skillLevel = 0;
			List<SkillPro> skillList = self.Root().GetComponent<SkillSetComponentC>().SkillList;
			for (int i = 0; i < skillList.Count; i++)
			{
				SkillConfig skillConfig = SkillConfigCategory.Instance.GetOrDefault(skillList[i].SkillID);
				if (skillConfig != null && SkillConfigCategory.Instance.GetInitSkill(skillConfig.Id) == baseSkillId)
				{
					skillLevel = Mathf.Max(skillLevel, skillConfig.SkillLv);
				}
			}

			return skillLevel;
		}

		private static int GetSelectedAugmentId(this ES_SkillAugment self, SkillAugmentInfo skillAugmentInfo, int tierIndex)
		{
			return skillAugmentInfo.ActiveAugmentIds != null && tierIndex < skillAugmentInfo.ActiveAugmentIds.Count ? skillAugmentInfo.ActiveAugmentIds[tierIndex] : 0;
		}

		private static void SetBaseSkillIcon(this ES_SkillAugment self, int baseSkillId)
		{
			Image iconImage = self.EG_BaseSkilRectTransform.Find("Mask/SkillIcon")?.GetComponent<Image>();
			SkillConfig skillConfig = SkillConfigCategory.Instance.GetOrDefault(baseSkillId);
			if (iconImage == null)
			{
				return;
			}

			if (skillConfig == null || string.IsNullOrEmpty(skillConfig.SkillIcon))
			{
				iconImage.gameObject.SetActive(false);
				return;
			}

			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
			iconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
			iconImage.gameObject.SetActive(true);
		}

		private static void SetWheelAugmentItems(this ES_SkillAugment self, RectTransform rotatingRoot, RectTransform itemList, int[] augmentIds, int selectedAugmentId, int tierIndex, bool isUnlocked)
		{
			int selectedIndex = -1;
			for (int i = 0; i < itemList.childCount; i++)
			{
				RectTransform item = itemList.GetChild(i) as RectTransform;
				int augmentId = augmentIds != null && i < augmentIds.Length ? augmentIds[i] : 0;
				self.SetWheelAugmentItem(item, augmentId, isUnlocked);

				if (augmentId != 0 && augmentId == selectedAugmentId)
				{
					selectedIndex = i;
				}
			}

			if (selectedIndex < 0 && augmentIds != null && augmentIds.Length > 0)
			{
				selectedIndex = 0;
			}

			self.AlignWheelToItem(rotatingRoot, itemList, selectedIndex);
			if (isUnlocked && selectedIndex >= 0)
			{
				self.OnWheelSnapCompleted(tierIndex, selectedIndex).Coroutine();
			}
			else if (!isUnlocked)
			{
				RectTransform wheelLine = tierIndex == 0 ? self.EG_Line_2RectTransform : self.EG_Line_3RectTransform;
				self.SetWheelLineAlpha(wheelLine, 0f);
			}
		}

		private static void SetWheelAugmentItem(this ES_SkillAugment self, RectTransform item, int augmentId, bool isUnlocked)
		{
			if (item == null || augmentId == 0)
			{
				if (item != null)
				{
					item.gameObject.SetActive(false);
				}
				return;
			}

			SkillAugmentConfig augmentConfig = SkillAugmentConfigCategory.Instance.GetOrDefault(augmentId);
			if (augmentConfig == null || string.IsNullOrEmpty(augmentConfig.Icon))
			{
				item.gameObject.SetActive(false);
				return;
			}

			Image iconImage = item.Find("Mask/SkillIcon")?.GetComponent<Image>();
			if (iconImage == null)
			{
				item.gameObject.SetActive(false);
				return;
			}

			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, augmentConfig.Icon);
			iconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
			CommonViewHelper.SetImageGray(self.Root(), iconImage.gameObject, !isUnlocked);
			self.RegisterSkillAugmentItemClick(item, augmentId);
			item.gameObject.SetActive(true);
		}

		private static void RegisterSkillAugmentItemClick(this ES_SkillAugment self, RectTransform item, int augmentId)
		{
			Transform clickTarget = item.Find("Mask");
			if (clickTarget == null)
			{
				return;
			}

			Button button = clickTarget.GetComponent<Button>();
			button.AddListener(() => self.SetSkillAugmentDescription(augmentId));
		}

		private static void SetSkillAugmentDescription(this ES_SkillAugment self, int augmentId)
		{
			SkillAugmentConfig augmentConfig = SkillAugmentConfigCategory.Instance.GetOrDefault(augmentId);
			string description = augmentConfig == null || string.IsNullOrEmpty(augmentConfig.Des) ? string.Empty : augmentConfig.Des.Replace("\\n", "\n");
			
			self.E_SkillDesText.text = description;
		}

		private static void AlignWheelToItem(this ES_SkillAugment self, RectTransform rotatingRoot, RectTransform itemList, int itemIndex)
		{
			rotatingRoot.DOKill();
			if (itemIndex < 0 || itemIndex >= itemList.childCount || !(itemList.GetChild(itemIndex) is RectTransform item) ||
			    !item.gameObject.activeSelf)
			{
				self.RefreshWheelLineAlpha(rotatingRoot, itemList);
				return;
			}

			Vector2 itemPosition = item.anchoredPosition;
			float itemLocalAngle = Mathf.Atan2(itemPosition.y, itemPosition.x) * Mathf.Rad2Deg;
			Vector3 localEulerAngles = rotatingRoot.localEulerAngles;
			localEulerAngles.z = WheelSnapTargetAngle - itemLocalAngle;
			rotatingRoot.localEulerAngles = localEulerAngles;
			self.RefreshWheelLineAlpha(rotatingRoot, itemList);
		}

		private static void ClearWheelSkills(this ES_SkillAugment self)
		{
			self.SetSkillAugmentDescription(0);
			self.SetWheelLineAlpha(self.EG_Line_2RectTransform, 0f);
			self.SetWheelLineAlpha(self.EG_Line_3RectTransform, 0f);
			Image baseSkillIcon = self.EG_BaseSkilRectTransform.Find("Mask/SkillIcon")?.GetComponent<Image>();
			if (baseSkillIcon != null)
			{
				baseSkillIcon.gameObject.SetActive(false);
			}

			for (int i = 0; i < self.EG_ItemList_1RectTransform.childCount; i++)
			{
				self.EG_ItemList_1RectTransform.GetChild(i).gameObject.SetActive(false);
			}

			for (int i = 0; i < self.EG_ItemList_2RectTransform.childCount; i++)
			{
				self.EG_ItemList_2RectTransform.GetChild(i).gameObject.SetActive(false);
			}
		}

		private static void GenerateSkillAugmentItems(this ES_SkillAugment self, RectTransform itemList, RectTransform itemTemplate,
			int itemCount, float angleStart, float angleInterval, float radius)
		{
			if (itemList == null || itemTemplate == null || itemCount <= 0 || radius < 0f)
			{
				return;
			}

			for (int i = 0; i < itemCount; i++)
			{
				RectTransform item = i == 0 ? itemTemplate : UnityEngine.Object.Instantiate(itemTemplate, itemList);

				if (i > 0)
				{
					item.name = $"{itemTemplate.name}_{i}";
				}

				float angle = (angleStart + -1 * i * angleInterval) * Mathf.Deg2Rad;
				item.anchoredPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
				item.localRotation = Quaternion.identity;
				item.gameObject.SetActive(true);
			}
		}

		private static void RegisterWheelDrag(this ES_SkillAugment self, EventTrigger eventTrigger, RectTransform rotatingRoot, RectTransform itemList, RectTransform wheelLine, int tierIndex)
		{
			RectTransform hitArea = eventTrigger.transform as RectTransform;

			float lastPointerAngle = 0f;
			bool isDragging = false;
			bool hasLastPointerAngle = false;
			Tween snapTween = null;

			eventTrigger.triggers.Clear();

			eventTrigger.RegisterEvent(EventTriggerType.PointerDown, baseEventData =>
			{
				snapTween?.Kill();
				snapTween = null;

				PointerEventData pointerEventData = baseEventData as PointerEventData;
				isDragging = self.TryGetPointerAngle(hitArea, pointerEventData, out lastPointerAngle);
				hasLastPointerAngle = isDragging;
			});

			// BeginDrag 时重新记录角度，避免按下到触发拖拽之间的位移造成首次跳动。
			eventTrigger.RegisterEvent(EventTriggerType.BeginDrag, baseEventData =>
			{
				PointerEventData pointerEventData = baseEventData as PointerEventData;
				isDragging = self.TryGetPointerAngle(hitArea, pointerEventData, out lastPointerAngle);
				hasLastPointerAngle = isDragging;
			});

			eventTrigger.RegisterEvent(EventTriggerType.Drag, baseEventData =>
			{
				if (!isDragging)
				{
					return;
				}

				PointerEventData pointerEventData = baseEventData as PointerEventData;
				if (!self.TryGetPointerAngle(hitArea, pointerEventData, out float currentPointerAngle))
				{
					hasLastPointerAngle = false;
					return;
				}

				// 指针移出圆形范围后再进入时，以当前位置重新开始，避免轮盘跳动。
				if (!hasLastPointerAngle)
				{
					lastPointerAngle = currentPointerAngle;
					hasLastPointerAngle = true;
					return;
				}

				float deltaAngle = Mathf.DeltaAngle(lastPointerAngle, currentPointerAngle);
				Vector3 localEulerAngles = rotatingRoot.localEulerAngles;
				localEulerAngles.z += deltaAngle;
				rotatingRoot.localEulerAngles = localEulerAngles;
				self.RefreshWheelLineAlpha(rotatingRoot, itemList, wheelLine);
				lastPointerAngle = currentPointerAngle;
			});

			void FinishDrag()
			{
				if (!isDragging)
				{
					return;
				}

				isDragging = false;
				hasLastPointerAngle = false;
				snapTween = self.SnapWheelToClosestItem(rotatingRoot, itemList, wheelLine,
					itemIndex => self.OnWheelSnapCompleted(tierIndex, itemIndex).Coroutine());
			}

			eventTrigger.RegisterEvent(EventTriggerType.EndDrag, _ => FinishDrag());
			eventTrigger.RegisterEvent(EventTriggerType.PointerUp, _ => FinishDrag());

			// 打开界面且未拖动时，也让最近的 Item 自动对准目标角度。
			snapTween = self.SnapWheelToClosestItem(rotatingRoot, itemList, wheelLine);
		}

		private static Tween SnapWheelToClosestItem(this ES_SkillAugment self, RectTransform rotatingRoot, RectTransform itemList,
			RectTransform wheelLine, Action<int> onComplete = null)
		{
			if (rotatingRoot == null || itemList == null || itemList.childCount == 0)
			{
				return null;
			}

			float rootAngle = rotatingRoot.localEulerAngles.z;
			float closestDeltaAngle = 0f;
			float closestDistance = float.MaxValue;
			int closestItemIndex = -1;

			for (int i = 0; i < itemList.childCount; i++)
			{
				if (!(itemList.GetChild(i) is RectTransform item) || !item.gameObject.activeSelf)
				{
					continue;
				}

				Vector2 itemPosition = item.anchoredPosition;
				if (itemPosition.sqrMagnitude < 1f)
				{
					continue;
				}

				float itemLocalAngle = Mathf.Atan2(itemPosition.y, itemPosition.x) * Mathf.Rad2Deg;
				float deltaAngle = Mathf.DeltaAngle(itemLocalAngle + rootAngle, WheelSnapTargetAngle);
				float distance = Mathf.Abs(deltaAngle);
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestDeltaAngle = deltaAngle;
					closestItemIndex = i;
				}
			}

			if (closestDistance == float.MaxValue)
			{
				return null;
			}

			Vector3 targetEulerAngles = rotatingRoot.localEulerAngles;
			targetEulerAngles.z = rootAngle + closestDeltaAngle;
			Tween tween = rotatingRoot.DOLocalRotate(targetEulerAngles, WheelSnapDuration, RotateMode.FastBeyond360)
				.SetEase(Ease.OutCubic)
				.OnUpdate(() => self.RefreshWheelLineAlpha(rotatingRoot, itemList, wheelLine));
			tween.OnComplete(() =>
			{
				self.RefreshWheelLineAlpha(rotatingRoot, itemList, wheelLine);
				onComplete?.Invoke(closestItemIndex);
			});
			return tween;
		}

		private static void RefreshWheelLineAlpha(this ES_SkillAugment self, RectTransform rotatingRoot, RectTransform itemList, RectTransform wheelLine = null)
		{
			int tierIndex = rotatingRoot == self.EG_RotatingRoot_1RectTransform ? 0 : 1;
			wheelLine ??= tierIndex == 0 ? self.EG_Line_2RectTransform : self.EG_Line_3RectTransform;
			if (!self.IsAugmentSlotUnlocked(tierIndex))
			{
				self.SetWheelLineAlpha(wheelLine, 0f);
				return;
			}

			float closestDistance = float.MaxValue;
			float rootAngle = rotatingRoot.localEulerAngles.z;
			for (int i = 0; i < itemList.childCount; i++)
			{
				if (!(itemList.GetChild(i) is RectTransform item) || !item.gameObject.activeSelf)
				{
					continue;
				}

				Vector2 itemPosition = item.anchoredPosition;
				if (itemPosition.sqrMagnitude < 1f)
				{
					continue;
				}

				float itemLocalAngle = Mathf.Atan2(itemPosition.y, itemPosition.x) * Mathf.Rad2Deg;
				float distance = Mathf.Abs(Mathf.DeltaAngle(itemLocalAngle + rootAngle, WheelSnapTargetAngle));
				closestDistance = Mathf.Min(closestDistance, distance);
			}

			float alpha = closestDistance == float.MaxValue
				? 0f
				: Mathf.SmoothStep(0f, 1f, 1f - Mathf.Clamp01(closestDistance / WheelLineFadeAngle));
			self.SetWheelLineAlpha(wheelLine, alpha);
		}

		private static void SetWheelLineAlpha(this ES_SkillAugment self, RectTransform wheelLine, float alpha)
		{
			Image lineImage = wheelLine != null ? wheelLine.GetComponent<Image>() : null;
			if (lineImage == null)
			{
				return;
			}

			Color color = lineImage.color;
			color.a = Mathf.Clamp01(alpha);
			lineImage.color = color;
		}

		private static async ETTask OnWheelSnapCompleted(this ES_SkillAugment self, int tierIndex, int itemIndex)
		{
			if (!self.IsAugmentSlotUnlocked(tierIndex))
			{
				return;
			}

			SkillAugmentOptionsConfig augmentOptions = SkillAugmentOptionsConfigCategory.Instance.GetOrDefault(self.SelectedBaseSkillId);
			int[] augmentIds = tierIndex switch
			{
				0 => augmentOptions?.SkillAugmentIds1,
				1 => augmentOptions?.SkillAugmentIds2,
				_ => null,
			};

			if (augmentIds == null || itemIndex < 0 || itemIndex >= augmentIds.Length)
			{
				return;
			}

			int augmentId = augmentIds[itemIndex];
			SkillAugmentInfo augmentInfo = self.Root().GetComponent<SkillSetComponentC>().SkillAugmentList
				.Find(info => info.BaseSkillId == self.SelectedBaseSkillId);
			if (augmentId == 0 || augmentInfo == null || self.GetSelectedAugmentId(augmentInfo, tierIndex) == augmentId)
			{
				return;
			}

			await SkillNetHelper.SetSkillAugment(self.Root(), self.SelectedBaseSkillId, tierIndex, augmentId);
		}

		private static bool TryGetPointerAngle(this ES_SkillAugment self, RectTransform hitArea, PointerEventData pointerEventData,
			out float pointerAngle)
		{
			pointerAngle = 0f;
			if (pointerEventData == null ||
			    !RectTransformUtility.ScreenPointToLocalPointInRectangle(hitArea, pointerEventData.position,
				    pointerEventData.pressEventCamera, out Vector2 localPoint) || localPoint.sqrMagnitude < 1f ||
			    !ET.CircularRaycastFilter.IsLocalPointInside(hitArea, localPoint))
			{
				return false;
			}

			pointerAngle = Mathf.Atan2(localPoint.y, localPoint.x) * Mathf.Rad2Deg;
			return true;
		}
	}
}
