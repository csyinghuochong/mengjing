
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillSocket))]
	[FriendOfAttribute(typeof(ES_SkillSocket))]
	public static partial class ES_SkillSocketSystem 
	{
		private const float WheelSnapTargetAngle = -45f;
		private const float WheelSnapDuration = 0.2f;

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

			self.RegisterWheelDrag(self.E_WheelHitArea_2EventTrigger, self.EG_RotatingRoot_2RectTransform);
			self.RegisterWheelDrag(self.E_WheelHitArea_3EventTrigger, self.EG_RotatingRoot_3RectTransform);
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillSocket self)
		{
			self.EG_RotatingRoot_2RectTransform.DOKill();
			self.EG_RotatingRoot_3RectTransform.DOKill();
			self.E_WheelHitArea_2EventTrigger.triggers.Clear();
			self.E_WheelHitArea_3EventTrigger.triggers.Clear();
			self.DestroyWidget();
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

		private static void RegisterWheelDrag(this ES_SkillSocket self, EventTrigger eventTrigger, RectTransform rotatingRoot)
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
				snapTween = self.SnapWheelToClosestItem(rotatingRoot);
			}

			eventTrigger.RegisterEvent(EventTriggerType.EndDrag, _ => FinishDrag());
			eventTrigger.RegisterEvent(EventTriggerType.PointerUp, _ => FinishDrag());

			// 打开界面且未拖动时，也让最近的 Item 自动对准目标角度。
			snapTween = self.SnapWheelToClosestItem(rotatingRoot);
		}

		private static Tween SnapWheelToClosestItem(this ES_SkillSocket self, RectTransform rotatingRoot)
		{
			if (rotatingRoot == null || rotatingRoot.childCount == 0)
			{
				return null;
			}

			float rootAngle = rotatingRoot.localEulerAngles.z;
			float closestDeltaAngle = 0f;
			float closestDistance = float.MaxValue;

			for (int i = 0; i < rotatingRoot.childCount; i++)
			{
				if (!(rotatingRoot.GetChild(i) is RectTransform item))
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
				}
			}

			if (closestDistance == float.MaxValue)
			{
				return null;
			}

			Vector3 targetEulerAngles = rotatingRoot.localEulerAngles;
			targetEulerAngles.z = rootAngle + closestDeltaAngle;
			return rotatingRoot.DOLocalRotate(targetEulerAngles, WheelSnapDuration, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
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
