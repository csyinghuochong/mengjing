
using System;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_SkillSocketItem))]
	[EntitySystemOf(typeof(ES_SkillSocket))]
	[FriendOfAttribute(typeof(ES_SkillSocket))]
	public static partial class ES_SkillSocketSystem 
	{
		private const float WheelSnapTargetAngle = -45f;
		private const float WheelSnapDuration = 0.2f;
		private const string SkillSocketItemPrefabPath = "Assets/Bundles/UI/Item/Item_SkillSocketItem.prefab";

		[EntitySystem]
		private static void Awake(this ES_SkillSocket self,Transform transform)
		{
			self.uiTransform = transform;

			self.GenerateSkillAugmentItems(self.EG_RotatingRoot_2RectTransform, self.EG_SkillAugmentItem_2RectTransform, 2, -15f, 60f, 164f);
			self.GenerateSkillAugmentItems(self.EG_RotatingRoot_3RectTransform, self.EG_SkillAugmentItem_3RectTransform, 3, 0f, 30f, 348f);

			// 两个点击区的圆心重合，外圈尺寸更大。让内圈处于外圈上方，
			// 否则外圈会拦截内圈范围内的所有射线事件。
			Transform innerHitArea = self.E_WheelHitArea_2Image.transform;
			Transform outerHitArea = self.E_WheelHitArea_3Image.transform;
			if (outerHitArea.GetSiblingIndex() > innerHitArea.GetSiblingIndex())
			{
				outerHitArea.SetSiblingIndex(innerHitArea.GetSiblingIndex());
			}

			self.RegisterWheelDrag(self.E_WheelHitArea_2EventTrigger, self.EG_RotatingRoot_2RectTransform, 1);
			self.RegisterWheelDrag(self.E_WheelHitArea_3EventTrigger, self.EG_RotatingRoot_3RectTransform, 2);
			self.RefreshSkillSocketItems();
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillSocket self)
		{
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < self.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
			}

			self.AssetList.Clear();
			self.ScrollItemSkillSocketItems.Clear();

			self.EG_RotatingRoot_2RectTransform.DOKill();
			self.EG_RotatingRoot_3RectTransform.DOKill();
			self.E_WheelHitArea_2EventTrigger.triggers.Clear();
			self.E_WheelHitArea_3EventTrigger.triggers.Clear();
			self.DestroyWidget();
		}

		public static void RefreshSkillSocketItems(this ES_SkillSocket self)
		{
			List<SkillSocketInfo> skillSocketList = self.Root().GetComponent<SkillSetComponentC>().SkillSocketList;
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			Transform content = self.E_SkillSocketItemsScrollRect.content;

			for (int i = 0; i < skillSocketList.Count; i++)
			{
				if (!self.ScrollItemSkillSocketItems.ContainsKey(i))
				{
					Scroll_Item_SkillSocketItem item = self.AddChild<Scroll_Item_SkillSocketItem>();
					if (!self.AssetList.Contains(SkillSocketItemPrefabPath))
					{
						self.AssetList.Add(SkillSocketItemPrefabPath);
					}

					GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(SkillSocketItemPrefabPath);
					GameObject itemGameObject = UnityEngine.Object.Instantiate(prefab, content);
					item.BindTrans(itemGameObject.transform);
					self.ScrollItemSkillSocketItems.Add(i, item);
				}

				Scroll_Item_SkillSocketItem scrollItem = self.ScrollItemSkillSocketItems[i];
				scrollItem.SetClickHandler(self.OnSelectSkillSocket);
				scrollItem.OnUpdateUI(skillSocketList[i]);
				scrollItem.uiTransform.gameObject.SetActive(true);
			}

			for (int i = skillSocketList.Count; i < self.ScrollItemSkillSocketItems.Count; i++)
			{
				Scroll_Item_SkillSocketItem scrollItem = self.ScrollItemSkillSocketItems[i];
				if (scrollItem.uiTransform != null)
				{
					scrollItem.uiTransform.gameObject.SetActive(false);
				}
			}

			if (skillSocketList.Count == 0)
			{
				self.SelectedBaseSkillId = 0;
				self.ClearWheelSkills();
				return;
			}

			SkillSocketInfo selectedSkillSocket = skillSocketList.Find(info => info.BaseSkillId == self.SelectedBaseSkillId);
			self.OnSelectSkillSocket(selectedSkillSocket ?? skillSocketList[0]);
		}

		private static void OnSelectSkillSocket(this ES_SkillSocket self, SkillSocketInfo skillSocketInfo)
		{
			if (skillSocketInfo == null)
			{
				return;
			}

			self.SelectedBaseSkillId = skillSocketInfo.BaseSkillId;
			foreach (EntityRef<Scroll_Item_SkillSocketItem> itemRef in self.ScrollItemSkillSocketItems.Values)
			{
				Scroll_Item_SkillSocketItem item = itemRef;
				if (item?.uiTransform != null && item.uiTransform.gameObject.activeSelf)
				{
					item.OnSetSelected(self.SelectedBaseSkillId);
				}
			}

			self.SyncWheelSkills(skillSocketInfo);
			self.SubmitFixedSkillAugment(skillSocketInfo).Coroutine();
		}

		private static void SyncWheelSkills(this ES_SkillSocket self, SkillSocketInfo skillSocketInfo)
		{
			SkillSocketConfig socketConfig = SkillSocketConfigCategory.Instance.GetOrDefault(skillSocketInfo.BaseSkillId);
			if (socketConfig == null)
			{
				self.ClearWheelSkills();
				return;
			}

			self.SetWheelAugmentItem(self.EG_SkillAugmentItem_1RectTransform,
				socketConfig.SkillAugmentIds1 != null && socketConfig.SkillAugmentIds1.Length > 0 ? socketConfig.SkillAugmentIds1[0] : 0);

			int selectedAugment2 = self.GetSelectedAugmentId(skillSocketInfo, 1);
			int selectedAugment3 = self.GetSelectedAugmentId(skillSocketInfo, 2);
			self.SetWheelAugmentItems(self.EG_RotatingRoot_2RectTransform, socketConfig.SkillAugmentIds2, selectedAugment2);
			self.SetWheelAugmentItems(self.EG_RotatingRoot_3RectTransform, socketConfig.SkillAugmentIds3, selectedAugment3);
		}

		private static int GetSelectedAugmentId(this ES_SkillSocket self, SkillSocketInfo skillSocketInfo, int index)
		{
			return skillSocketInfo.AugmentIds != null && index < skillSocketInfo.AugmentIds.Count ? skillSocketInfo.AugmentIds[index] : 0;
		}

		private static async ETTask SubmitFixedSkillAugment(this ES_SkillSocket self, SkillSocketInfo skillSocketInfo)
		{
			SkillSocketConfig socketConfig = SkillSocketConfigCategory.Instance.GetOrDefault(skillSocketInfo.BaseSkillId);
			if (socketConfig?.SkillAugmentIds1 == null || socketConfig.SkillAugmentIds1.Length == 0)
			{
				return;
			}

			int augmentId = socketConfig.SkillAugmentIds1[0];
			if (augmentId == 0 || self.GetSelectedAugmentId(skillSocketInfo, 0) == augmentId)
			{
				return;
			}

			await SkillNetHelper.SetSkillAugment(self.Root(), skillSocketInfo.BaseSkillId, 0, augmentId);
		}

		private static void SetWheelAugmentItems(this ES_SkillSocket self, RectTransform rotatingRoot, int[] augmentIds, int selectedAugmentId)
		{
			int selectedIndex = -1;
			for (int i = 0; i < rotatingRoot.childCount; i++)
			{
				RectTransform item = rotatingRoot.GetChild(i) as RectTransform;
				int augmentId = augmentIds != null && i < augmentIds.Length ? augmentIds[i] : 0;
				self.SetWheelAugmentItem(item, augmentId);

				if (augmentId != 0 && augmentId == selectedAugmentId)
				{
					selectedIndex = i;
				}
			}

			if (selectedIndex < 0 && augmentIds != null && augmentIds.Length > 0)
			{
				selectedIndex = 0;
			}

			self.AlignWheelToItem(rotatingRoot, selectedIndex);
		}

		private static void SetWheelAugmentItem(this ES_SkillSocket self, RectTransform item, int augmentId)
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
			item.gameObject.SetActive(true);
		}

		private static void AlignWheelToItem(this ES_SkillSocket self, RectTransform rotatingRoot, int itemIndex)
		{
			rotatingRoot.DOKill();
			if (itemIndex < 0 || itemIndex >= rotatingRoot.childCount || !(rotatingRoot.GetChild(itemIndex) is RectTransform item) ||
			    !item.gameObject.activeSelf)
			{
				return;
			}

			Vector2 itemPosition = item.anchoredPosition;
			float itemLocalAngle = Mathf.Atan2(itemPosition.y, itemPosition.x) * Mathf.Rad2Deg;
			Vector3 localEulerAngles = rotatingRoot.localEulerAngles;
			localEulerAngles.z = WheelSnapTargetAngle - itemLocalAngle;
			rotatingRoot.localEulerAngles = localEulerAngles;
		}

		private static void ClearWheelSkills(this ES_SkillSocket self)
		{
			self.EG_SkillAugmentItem_1RectTransform.gameObject.SetActive(false);
			for (int i = 0; i < self.EG_RotatingRoot_2RectTransform.childCount; i++)
			{
				self.EG_RotatingRoot_2RectTransform.GetChild(i).gameObject.SetActive(false);
			}

			for (int i = 0; i < self.EG_RotatingRoot_3RectTransform.childCount; i++)
			{
				self.EG_RotatingRoot_3RectTransform.GetChild(i).gameObject.SetActive(false);
			}
		}

		private static void GenerateSkillAugmentItems(this ES_SkillSocket self, RectTransform rotatingRoot, RectTransform itemTemplate, int itemCount,float angleStart, float angleInterval, float radius)
		{
			if (rotatingRoot == null || itemTemplate == null || itemCount <= 0 || radius < 0f)
			{
				return;
			}

			for (int i = 0; i < itemCount; i++)
			{
				RectTransform item = i == 0 ? itemTemplate : UnityEngine.Object.Instantiate(itemTemplate, rotatingRoot);

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

		private static void RegisterWheelDrag(this ES_SkillSocket self, EventTrigger eventTrigger, RectTransform rotatingRoot, int socketIndex)
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
				snapTween = self.SnapWheelToClosestItem(rotatingRoot,
					itemIndex => self.OnWheelSnapCompleted(socketIndex, itemIndex).Coroutine());
			}

			eventTrigger.RegisterEvent(EventTriggerType.EndDrag, _ => FinishDrag());
			eventTrigger.RegisterEvent(EventTriggerType.PointerUp, _ => FinishDrag());

			// 打开界面且未拖动时，也让最近的 Item 自动对准目标角度。
			snapTween = self.SnapWheelToClosestItem(rotatingRoot);
		}

		private static Tween SnapWheelToClosestItem(this ES_SkillSocket self, RectTransform rotatingRoot, Action<int> onComplete = null)
		{
			if (rotatingRoot == null || rotatingRoot.childCount == 0)
			{
				return null;
			}

			float rootAngle = rotatingRoot.localEulerAngles.z;
			float closestDeltaAngle = 0f;
			float closestDistance = float.MaxValue;
			int closestItemIndex = -1;

			for (int i = 0; i < rotatingRoot.childCount; i++)
			{
				if (!(rotatingRoot.GetChild(i) is RectTransform item) || !item.gameObject.activeSelf)
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
			Tween tween = rotatingRoot.DOLocalRotate(targetEulerAngles, WheelSnapDuration, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
			if (onComplete != null)
			{
				tween.OnComplete(() => onComplete(closestItemIndex));
			}
			return tween;
		}

		private static async ETTask OnWheelSnapCompleted(this ES_SkillSocket self, int socketIndex, int itemIndex)
		{
			SkillSocketConfig socketConfig = SkillSocketConfigCategory.Instance.GetOrDefault(self.SelectedBaseSkillId);
			int[] augmentIds = socketIndex switch
			{
				1 => socketConfig?.SkillAugmentIds2,
				2 => socketConfig?.SkillAugmentIds3,
				_ => null,
			};

			if (augmentIds == null || itemIndex < 0 || itemIndex >= augmentIds.Length)
			{
				return;
			}

			int augmentId = augmentIds[itemIndex];
			SkillSocketInfo socketInfo = self.Root().GetComponent<SkillSetComponentC>().SkillSocketList
				.Find(info => info.BaseSkillId == self.SelectedBaseSkillId);
			if (augmentId == 0 || socketInfo == null || self.GetSelectedAugmentId(socketInfo, socketIndex) == augmentId)
			{
				return;
			}

			await SkillNetHelper.SetSkillAugment(self.Root(), self.SelectedBaseSkillId, socketIndex, augmentId);
		}

		private static bool TryGetPointerAngle(this ES_SkillSocket self, RectTransform hitArea, PointerEventData pointerEventData,
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
