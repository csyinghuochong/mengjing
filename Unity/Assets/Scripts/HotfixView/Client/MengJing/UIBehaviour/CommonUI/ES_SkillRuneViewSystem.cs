using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillRune))]
	[FriendOfAttribute(typeof(ES_SkillRune))]
	[FriendOf(typeof(Scroll_Item_SkillRuneItem))]
	public static partial class ES_SkillRuneSystem 
	{
		/// <summary>
		/// 符文列表条目的预制体
		/// </summary>
		private const string SkillRuneItemPrefabPath = "Assets/Bundles/UI/Item/Item_SkillRuneItem.prefab";

		[EntitySystem]
		private static void Awake(this ES_SkillRune self,Transform transform)
		{
			self.uiTransform = transform;

			self.InitCloseButton();
			self.E_EquipRuneButton.AddListener(self.OnEquipRuneButton);
			self.E_UnequipRuneButton.AddListener(self.OnUnequipRuneButton);

			//没选符文时不显示名字/等级/描述，Tip 也先藏起来
			self.HideRuneInfo();
			self.ShowTip(false);
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillRune self)
		{
			if (self.AssetList != null)
			{
				ResourcesLoaderComponent resourcesLoaderComponent = self.Root()?.GetComponent<ResourcesLoaderComponent>();
				if (resourcesLoaderComponent != null)
				{
					for (int i = 0; i < self.AssetList.Count; i++)
					{
						resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
					}
				}

				self.AssetList.Clear();
			}

			self.DestroyWidget();
		}

		/// <summary>
		/// E_Close 在预制体里只有一个全屏的半透明 Image，没有 Button，
		/// 这里运行时补一个透明的 Button，点空白处就关闭
		/// </summary>
		private static void InitCloseButton(this ES_SkillRune self)
		{
			Button closeButton = self.E_CloseImage.gameObject.GetComponent<Button>();
			if (closeButton == null)
			{
				closeButton = self.E_CloseImage.gameObject.AddComponent<Button>();
				closeButton.transition = Selectable.Transition.None;
			}

			closeButton.targetGraphic = self.E_CloseImage;
			closeButton.AddListener(self.OnCloseButton);
		}

		private static void OnCloseButton(this ES_SkillRune self)
		{
			self.GetParent<ES_SkillLearn>().CloseSkillRune();
		}

		/// <summary>
		/// 打开某个技能的某个孔位：技能id 用的是技能列表里当前等级的技能id，服务端会换算成基础技能id
		/// </summary>
		public static void OnOpen(this ES_SkillRune self, int skillId, int slotIndex)
		{
			self.SkillId = skillId;
			self.SlotIndex = slotIndex;
			self.SelectRuneId = 0;
			self.RefreshUI();

			//列表布局要等一帧才重建，那时再滚到顶部
			self.ResetScroll().Coroutine();
		}

		private static async ETTask ResetScroll(this ES_SkillRune self)
		{
			await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
			if (self.uiTransform == null || self.E_SkillRuneItemsScrollRect == null)
			{
				return;
			}

			self.E_SkillRuneItemsScrollRect.verticalNormalizedPosition = 1f;
		}

		public static void RefreshUI(this ES_SkillRune self)
		{
			SkillRuneComponentC skillRuneComponent = self.Root().GetComponent<SkillRuneComponentC>();
			if (skillRuneComponent == null)
			{
				return;
			}

			//选中的符文已经镶上或者被换走了，清掉选中，改成显示孔位上那枚
			if (self.SelectRuneId != 0)
			{
				SkillRuneInfo selectRune = skillRuneComponent.GetRune(self.SelectRuneId);
				if (selectRune == null || skillRuneComponent.IsRuneEquipped(self.SelectRuneId))
				{
					self.SelectRuneId = 0;
				}
			}

			self.RefreshRuneItems(skillRuneComponent);
			self.RefreshState(skillRuneComponent);
		}

		/// <summary>
		/// 只刷选中状态、右侧信息和按钮，不动列表（点列表里的符文时用，避免在点击回调里重建按钮监听）
		/// </summary>
		private static void RefreshState(this ES_SkillRune self, SkillRuneComponentC skillRuneComponent)
		{
			long equippedRuneId = skillRuneComponent.GetSlotRuneId(self.SkillId, self.SlotIndex);

			//空孔只显示装备，已装备的孔位再加上卸下，装备按钮的文字换成替换
			self.E_UnequipRuneButton.gameObject.SetActive(equippedRuneId != 0);
			Text equipText = UIFindHelper.FindDeepChild<Text>(self.E_EquipRuneButton.gameObject, "Text");
			if (equipText != null)
			{
				equipText.text = equippedRuneId != 0 ? "替换" : "装备";
			}

			for (int i = 0; i < self.RuneItems.Count; i++)
			{
				Scroll_Item_SkillRuneItem runeItem = self.RuneItems[i];
				if (!runeItem.uiTransform.gameObject.activeSelf)
				{
					continue;
				}

				runeItem.SetSelected(runeItem.DataId == self.SelectRuneId);
			}

			self.RefreshRuneInfo(skillRuneComponent, equippedRuneId);
			self.RefreshEquipButton(skillRuneComponent);
		}

		/// <summary>
		/// 符文列表：只列背包里（没镶在任何技能上）的符文，按等级从高到低排
		/// </summary>
		private static void RefreshRuneItems(this ES_SkillRune self, SkillRuneComponentC skillRuneComponent)
		{
			ScrollRect bagScrollRect = self.E_SkillRuneItemsScrollRect;
			Transform contentTrans = bagScrollRect == null ? null : bagScrollRect.transform.Find("Content");
			if (contentTrans == null)
			{
				Log.Error("ES_SkillRune 预制体缺少 Left/E_SkillRuneItems/Content");
				return;
			}

			//配置丢了的数据不显示，避免列表里出现空格子
			List<SkillRuneInfo> bagRuneList = new List<SkillRuneInfo>();
			List<SkillRuneInfo> allRuneList = skillRuneComponent.GetBagRuneList();
			for (int i = 0; i < allRuneList.Count; i++)
			{
				if (SkillRuneConfigCategory.Instance.GetOrDefault(allRuneList[i].ConfigId) == null)
				{
					continue;
				}

				bagRuneList.Add(allRuneList[i]);
			}

			bagRuneList.Sort(CompareByLevel);

			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < bagRuneList.Count; i++)
			{
				if (i >= self.RuneItems.Count)
				{
					if (!self.AssetList.Contains(SkillRuneItemPrefabPath))
					{
						self.AssetList.Add(SkillRuneItemPrefabPath);
					}

					GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(SkillRuneItemPrefabPath);
					if (prefab == null)
					{
						Log.Error($"技能符文条目预制体加载失败：{SkillRuneItemPrefabPath}");
						return;
					}

					GameObject go = UnityEngine.Object.Instantiate(prefab, contentTrans);
					Scroll_Item_SkillRuneItem item = self.AddChild<Scroll_Item_SkillRuneItem>();
					item.BindTrans(go.transform);
					self.RuneItems.Add(item);
				}

				Scroll_Item_SkillRuneItem runeItem = self.RuneItems[i];
				runeItem.uiTransform.gameObject.SetActive(true);
				runeItem.OnInitUI(bagRuneList[i], self.SelectRuneId);
			}

			//多出来的条目复用隐藏
			for (int i = bagRuneList.Count; i < self.RuneItems.Count; i++)
			{
				Scroll_Item_SkillRuneItem runeItem = self.RuneItems[i];
				runeItem.uiTransform.gameObject.SetActive(false);
			}
		}

		/// <summary>
		/// 右侧信息：优先显示选中的符文，没选中就显示孔位上已经镶的那枚
		/// </summary>
		private static void RefreshRuneInfo(this ES_SkillRune self, SkillRuneComponentC skillRuneComponent, long equippedRuneId)
		{
			long showRuneId = self.SelectRuneId != 0 ? self.SelectRuneId : equippedRuneId;
			SkillRuneConfig runeConfig = skillRuneComponent.GetRuneConfig(skillRuneComponent.GetRune(showRuneId));
			if (runeConfig == null)
			{
				self.HideRuneInfo();
				return;
			}

			self.E_RuneNameText.gameObject.SetActive(true);
			self.E_RuneLvText.gameObject.SetActive(true);
			self.E_RuneDesText.gameObject.SetActive(true);
			self.E_RuneNameText.text = runeConfig.Name;
			self.E_RuneLvText.text = CommonViewHelper.GetRomanLevel(runeConfig.Level);
			self.E_RuneDesText.text = runeConfig.Des.Replace("\\n", "\n");
		}

		private static void HideRuneInfo(this ES_SkillRune self)
		{
			self.E_RuneNameText.gameObject.SetActive(false);
			self.E_RuneLvText.gameObject.SetActive(false);
			self.E_RuneDesText.gameObject.SetActive(false);
		}

		/// <summary>
		/// 同一种符文一个技能上只能镶一枚：选中背包里的符文时检查这个技能其它孔位
		/// </summary>
		private static void RefreshEquipButton(this ES_SkillRune self, SkillRuneComponentC skillRuneComponent)
		{
			SkillRuneConfig selectConfig = skillRuneComponent.GetRuneConfig(skillRuneComponent.GetRune(self.SelectRuneId));

			bool sameRuneEquipped = false;
			if (selectConfig != null)
			{
				int slotCount = GlobalValueConfigCategory.Instance.SkillRuneSlotCount;
				for (int i = 0; i < slotCount; i++)
				{
					if (i == self.SlotIndex)
					{
						continue;
					}

					long runeId = skillRuneComponent.GetSlotRuneId(self.SkillId, i);
					SkillRuneConfig runeConfig = skillRuneComponent.GetRuneConfig(skillRuneComponent.GetRune(runeId));
					if (runeConfig != null && runeConfig.Id == selectConfig.Id)
					{
						sameRuneEquipped = true;
						break;
					}
				}
			}

			self.ShowTip(sameRuneEquipped);

			bool canEquip = self.SelectRuneId != 0 && !sameRuneEquipped;
			self.E_EquipRuneButton.interactable = canEquip;
			CommonViewHelper.SetImageGray(self.Root(), self.E_EquipRuneButton.gameObject, !canEquip);
		}

		private static void ShowTip(this ES_SkillRune self, bool show)
		{
			Transform tipTrans = self.uiTransform.Find("Left/Tip");
			if (tipTrans != null)
			{
				tipTrans.gameObject.SetActive(show);
			}
		}

		/// <summary>
		/// 点列表里的符文：记住选中，刷右侧信息和装备按钮
		/// </summary>
		public static void OnClickRuneItem(this ES_SkillRune self, long runeId)
		{
			self.SelectRuneId = runeId;

			SkillRuneComponentC skillRuneComponent = self.Root().GetComponent<SkillRuneComponentC>();
			if (skillRuneComponent == null)
			{
				return;
			}

			self.RefreshState(skillRuneComponent);
		}

		private static void OnEquipRuneButton(this ES_SkillRune self)
		{
			if (self.SelectRuneId == 0)
			{
				return;
			}

			self.EquipRune(self.SelectRuneId).Coroutine();
		}

		private static async ETTask EquipRune(this ES_SkillRune self, long runeId)
		{
			SkillRuneComponentC skillRuneComponent = self.Root().GetComponent<SkillRuneComponentC>();
			if (skillRuneComponent == null)
			{
				return;
			}

			//等回包期间先锁住按钮，避免连点重复发
			self.E_EquipRuneButton.interactable = false;

			bool isReplace = skillRuneComponent.GetSlotRuneId(self.SkillId, self.SlotIndex) != 0;
			int error = await SkillRuneNetHelper.EquipRune(self.Root(), self.SkillId, self.SlotIndex, runeId);
			if (error != ErrorCode.ERR_Success)
			{
				HintHelp.ShowErrorHint(self.Root(), error);
				self.RefreshUI();
				return;
			}

			FlyTipComponent.Instance.ShowFlyTip(isReplace ? "替换成功" : "镶嵌成功");
			self.SelectRuneId = 0;
			self.RefreshUI();
			self.GetParent<ES_SkillLearn>().RefreshSkillRuneItems();
		}

		private static void OnUnequipRuneButton(this ES_SkillRune self)
		{
			self.UnequipRune().Coroutine();
		}

		private static async ETTask UnequipRune(this ES_SkillRune self)
		{
			SkillRuneComponentC skillRuneComponent = self.Root().GetComponent<SkillRuneComponentC>();
			if (skillRuneComponent == null)
			{
				return;
			}

			long runeId = skillRuneComponent.GetSlotRuneId(self.SkillId, self.SlotIndex);
			if (runeId == 0)
			{
				return;
			}

			self.E_UnequipRuneButton.interactable = false;
			int error = await SkillRuneNetHelper.UnequipRune(self.Root(), self.SkillId, self.SlotIndex);
			self.E_UnequipRuneButton.interactable = true;

			if (error != ErrorCode.ERR_Success)
			{
				HintHelp.ShowErrorHint(self.Root(), error);
				return;
			}

			FlyTipComponent.Instance.ShowFlyTip("卸下成功");

			//卸下来的符文回到背包，直接选中它
			self.SelectRuneId = runeId;
			self.RefreshUI();
			self.GetParent<ES_SkillLearn>().RefreshSkillRuneItems();
		}

		/// <summary>
		/// 按符文等级从高到低排，同级的再按配置id排
		/// </summary>
		private static int CompareByLevel(SkillRuneInfo a, SkillRuneInfo b)
		{
			SkillRuneConfig configA = SkillRuneConfigCategory.Instance.GetOrDefault(a.ConfigId);
			SkillRuneConfig configB = SkillRuneConfigCategory.Instance.GetOrDefault(b.ConfigId);
			int lvA = configA == null ? 0 : configA.Level;
			int lvB = configB == null ? 0 : configB.Level;
			if (lvA != lvB)
			{
				return lvB.CompareTo(lvA);
			}

			return a.ConfigId.CompareTo(b.ConfigId);
		}

		/// <summary>
		/// 符文图标：SkillRuneConfig.Icon 就是 RoleSkillIcon 图集下的图标id，
		/// 资源由 ResourcesLoaderComponent 按路径缓存，不用自己卸载
		/// </summary>
		public static Sprite LoadRuneIcon(this ES_SkillRune self, string icon)
		{
			if (string.IsNullOrEmpty(icon))
			{
				return null;
			}

			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, icon);
			return self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
		}
	}


}
