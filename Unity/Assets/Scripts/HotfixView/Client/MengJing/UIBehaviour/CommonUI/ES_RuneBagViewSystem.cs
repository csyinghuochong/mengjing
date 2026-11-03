using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EntitySystemOf(typeof(ES_RuneBag))]
	[FriendOfAttribute(typeof(ES_RuneBag))]
	[FriendOf(typeof(Scroll_Item_RuneBagItem))]
	public static partial class ES_RuneBagSystem 
	{
		/// <summary>
		/// 符文背包条目的预制体
		/// </summary>
		private const string RuneBagItemPrefabPath = "Assets/Bundles/UI/Item/Item_RuneBagItem.prefab";

		[EntitySystem]
		private static void Awake(this ES_RuneBag self,Transform transform)
		{
			self.uiTransform = transform;

			self.E_ReturnButton.AddListener(self.OnReturnButton);
			self.InitRuneTypeToggles();
			self.InitUpgradePanel();
			self.InitDecomposePanel();
		}

		[EntitySystem]
		private static void Destroy(this ES_RuneBag self)
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
		/// 点 E_Return：分解模式下先退出分解模式回列表，再点才回到符文主界面
		/// </summary>
		private static void OnReturnButton(this ES_RuneBag self)
		{
			if (self.IsDecomposeMode)
			{
				self.ExitDecomposeMode();
				return;
			}

			self.GetParent<ES_Rune>().CloseRuneBag();
		}

		/// <summary>
		/// 类型页签：用 EUIHelper 的 ToggleGroup.AddListener，切换时自动切 Background/XuanZhong 和 WeiXuanZhong；
		/// 下标 0 是全部，1~3 对应 RuneType.Skill/Attack/Defense
		/// </summary>
		private static void InitRuneTypeToggles(this ES_RuneBag self)
		{
			if (self.E_RuneTypeSetToggleGroup == null)
			{
				Log.Error("ES_RuneBag 预制体缺少 Left/E_RuneTypeSet");
				return;
			}

			self.E_RuneTypeSetToggleGroup.AddListener(self.OnClickRuneType);

			//默认选中全部
			self.E_RuneTypeSetToggleGroup.OnSelectIndex(0);
		}

		/// <summary>
		/// 切类型：0 表示全部，1/2/3 是技能/攻击/防御，重新刷列表
		/// </summary>
		private static void OnClickRuneType(this ES_RuneBag self, int typeIndex)
		{
			self.SelectRuneType = typeIndex;
			self.SelectRuneId = 0;
			self.OnUpdateUI();
		}

		/// <summary>
		/// 刷新背包：按当前选的类型过滤出拥有的符文，再刷新选中框
		/// </summary>
		public static void OnUpdateUI(this ES_RuneBag self)
		{
			self.RefreshRuneItems();
			self.RefreshSelect();
		}

		/// <summary>
		/// 每次打开背包时清掉上次的选中和分解模式，回到列表初始状态
		/// </summary>
		public static void OnOpenBag(this ES_RuneBag self)
		{
			self.IsDecomposeMode = false;
			self.SelectRuneId = 0;
			self.SelectRuneIds.Clear();
			self.EG_RuneDecomposeRectTransform.gameObject.SetActive(false);
			self.OnUpdateUI();
		}

		private static void RefreshRuneItems(this ES_RuneBag self)
		{
			RuneComponentC runeComponent = self.Root().GetComponent<RuneComponentC>();
			if (runeComponent == null)
			{
				return;
			}

			ScrollRect bagScrollRect = self.E_RuneBagItemsScrollRect;
			Transform contentTrans = bagScrollRect == null ? null : bagScrollRect.transform.Find("Content");
			if (contentTrans == null)
			{
				Log.Error("ES_RuneBag 预制体缺少 Left/E_RuneBagItems/Content");
				return;
			}

			List<RuneData> runeList = new List<RuneData>();
			for (int i = 0; i < runeComponent.RuneList.Count; i++)
			{
				RuneData rune = runeComponent.RuneList[i];
				RuneConfig runeConfig = RuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
				if (runeConfig == null)
				{
					continue;
				}

				//按类型筛选，0 表示全部
				if (self.SelectRuneType != 0 && (int)runeConfig.RuneType != self.SelectRuneType)
				{
					continue;
				}

				runeList.Add(rune);
			}

			//按配置id排，同一条成长线就是按等级从上往下
			runeList.Sort((a, b) => a.ConfigId.CompareTo(b.ConfigId));

			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < runeList.Count; i++)
			{
				if (i >= self.BagItems.Count)
				{
					if (!self.AssetList.Contains(RuneBagItemPrefabPath))
					{
						self.AssetList.Add(RuneBagItemPrefabPath);
					}

					GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(RuneBagItemPrefabPath);
					if (prefab == null)
					{
						Log.Error($"符文背包条目预制体加载失败：{RuneBagItemPrefabPath}");
						return;
					}

					GameObject go = UnityEngine.Object.Instantiate(prefab, contentTrans);
					Scroll_Item_RuneBagItem item = self.AddChild<Scroll_Item_RuneBagItem>();
					item.BindTrans(go.transform);
					self.BagItems.Add(item);
				}

				Scroll_Item_RuneBagItem bagItem = self.BagItems[i];
				bagItem.uiTransform.gameObject.SetActive(true);
				bagItem.OnInitUI(runeList[i]);
			}

			//多出来的条目复用隐藏
			for (int i = runeList.Count; i < self.BagItems.Count; i++)
			{
				Scroll_Item_RuneBagItem bagItem = self.BagItems[i];
				bagItem.uiTransform.gameObject.SetActive(false);
			}
		}

		private static void RefreshSelect(this ES_RuneBag self)
		{
			for (int i = 0; i < self.BagItems.Count; i++)
			{
				Scroll_Item_RuneBagItem bagItem = self.BagItems[i];
				if (!bagItem.uiTransform.gameObject.activeSelf)
				{
					continue;
				}

				bool isChecked = self.SelectRuneIds.Contains(bagItem.DataId);
				bagItem.SetSelected(!self.IsDecomposeMode && bagItem.DataId == self.SelectRuneId);
				bagItem.SetCheck(self.IsDecomposeMode, self.IsDecomposeMode && isChecked);
			}

			if (self.IsDecomposeMode)
			{
				self.RefreshDecomposePanel();
				return;
			}

			self.EG_RuneDecomposeRectTransform.gameObject.SetActive(false);
			self.RefreshUpgradePanel();
		}

		/// <summary>
		/// 点列表里的符文：普通模式选中看升级，分解模式勾选/取消勾选
		/// </summary>
		public static void OnClickRuneItem(this ES_RuneBag self, long runeId)
		{
			if (self.IsDecomposeMode)
			{
				//Remove 返回 true 说明本来选中了，再点就是取消
				if (!self.SelectRuneIds.Remove(runeId))
				{
					self.SelectRuneIds.Add(runeId);
				}

				self.RefreshSelect();
				return;
			}

			self.SelectRuneId = runeId;
			self.RefreshSelect();
		}

		#region 升级

		private static void InitUpgradePanel(this ES_RuneBag self)
		{
			self.E_UpgradeButton.AddListenerAsync(self.OnUpgradeButton);
			self.EG_RuneUpgradeRectTransform.gameObject.SetActive(false);
		}

		/// <summary>
		/// 升级面板：图标、名字、等级、类型，当前效果和下一级效果，以及消耗的符文碎片；
		/// 满级或者碎片不够时升级按钮置灰
		/// </summary>
		private static void RefreshUpgradePanel(this ES_RuneBag self)
		{
			RuneComponentC runeComponent = self.Root().GetComponent<RuneComponentC>();
			RuneData rune = runeComponent == null ? null : runeComponent.GetRune(self.SelectRuneId);
			RuneConfig runeConfig = runeComponent == null ? null : runeComponent.GetRuneConfig(rune);
			if (runeConfig == null)
			{
				self.EG_RuneUpgradeRectTransform.gameObject.SetActive(false);
				return;
			}

			self.EG_RuneUpgradeRectTransform.gameObject.SetActive(true);
			//升级和分解面板在同一个位置，同时只显示一个
			self.EG_RuneDecomposeRectTransform.gameObject.SetActive(false);

			Sprite iconSprite = self.LoadRuneIcon(runeConfig.Icon);
			if (iconSprite != null)
			{
				self.E_RuneIconImage.sprite = iconSprite;
			}

			self.E_RuneNameText.text = runeConfig.Name;
			self.E_RuneLvText.text = $"Lv.{runeConfig.Lv}";
			self.E_RuneTypeText.text = $"{GetRuneTypeDesc(runeConfig.RuneType)}符文";
			self.E_RuneDesc_CurrentText.text = runeConfig.Des;

			//NextId 为 0 表示已经是这条符文的最高级
			RuneConfig nextConfig = RuneConfigCategory.Instance.GetOrDefault(runeConfig.NextId);
			bool isMaxLv = nextConfig == null;
			self.E_RuneDesc_NextText.text = isMaxLv ? "已满级" : nextConfig.Des;

			int upgradeCost = isMaxLv ? 0 : runeConfig.UpgradeCost;
			self.E_ShardNumText.text = isMaxLv ? $"已满级  {runeComponent.Shard}" : $"{runeComponent.Shard}/{upgradeCost}";

			bool canUpgrade = !isMaxLv && runeComponent.Shard >= upgradeCost;
			self.E_UpgradeButton.interactable = canUpgrade;
			CommonViewHelper.SetImageGray(self.Root(), self.E_UpgradeButton.gameObject, !canUpgrade);
		}

		private static async ETTask OnUpgradeButton(this ES_RuneBag self)
		{
			if (self.SelectRuneId == 0)
			{
				return;
			}

			int error = await RuneNetHelper.UpgradeRune(self.Root(), self.SelectRuneId);
			if (error != ErrorCode.ERR_Success)
			{
				HintHelp.ShowErrorHint(self.Root(), error);
				return;
			}

			FlyTipComponent.Instance.ShowFlyTip("升级成功");
			self.OnUpdateUI();
		}

		private static string GetRuneTypeDesc(RuneType runeType)
		{
			switch (runeType)
			{
				case RuneType.Skill:
					return "技能";
				case RuneType.Attack:
					return "攻击";
				case RuneType.Defense:
					return "防御";
				default:
					return string.Empty;
			}
		}

		#endregion

		#region 分解

		private static void InitDecomposePanel(this ES_RuneBag self)
		{
			self.E_StartDecomposeButton.AddListener(self.OnStartDecomposeButton);
			self.EG_RuneDecomposeRectTransform.gameObject.SetActive(false);
		}

		/// <summary>
		/// 点批量分解：清掉之前的勾选，进入分解模式
		/// </summary>
		private static void OnStartDecomposeButton(this ES_RuneBag self)
		{
			self.EnterDecomposeMode();
		}

		/// <summary>
		/// 进入分解模式：主列表改成勾选，右侧换成分解面板
		/// </summary>
		public static void EnterDecomposeMode(this ES_RuneBag self)
		{
			self.IsDecomposeMode = true;
			self.SelectRuneId = 0;
			self.SelectRuneIds.Clear();
			self.OnUpdateUI();
		}

		/// <summary>
		/// 退出分解模式，勾选清掉回到普通列表
		/// </summary>
		public static void ExitDecomposeMode(this ES_RuneBag self)
		{
			self.IsDecomposeMode = false;
			self.SelectRuneIds.Clear();
			self.OnUpdateUI();
		}

		/// <summary>
		/// 分解面板：已选数量和返还碎片总数，以及已选符文列表
		/// </summary>
		private static void RefreshDecomposePanel(this ES_RuneBag self)
		{
			self.EG_RuneDecomposeRectTransform.gameObject.SetActive(true);
			self.EG_RuneUpgradeRectTransform.gameObject.SetActive(false);

			RuneComponentC runeComponent = self.Root().GetComponent<RuneComponentC>();
			List<RuneData> selectedList = new List<RuneData>();
			int totalShard = 0;
			for (int i = 0; i < self.SelectRuneIds.Count; i++)
			{
				RuneData rune = runeComponent == null ? null : runeComponent.GetRune(self.SelectRuneIds[i]);
				RuneConfig runeConfig = runeComponent == null ? null : runeComponent.GetRuneConfig(rune);
				if (runeConfig == null)
				{
					continue;
				}

				selectedList.Add(rune);
				totalShard += runeConfig.DecomposeShard;
			}

			self.E_DecomposeRuneNumText.text = $"已选择{selectedList.Count}枚符文";
			self.E_DecomposeShardNumText.text = $"x{totalShard}";

			self.RefreshSelectItems(selectedList);
		}

		/// <summary>
		/// 已选符文列表：和主列表一样按格子排，点一下就是取消勾选
		/// </summary>
		private static void RefreshSelectItems(this ES_RuneBag self, List<RuneData> selectedList)
		{
			ScrollRect selectScrollRect = self.E_RuneBagItems_SelectScrollRect;
			Transform contentTrans = selectScrollRect == null ? null : selectScrollRect.transform.Find("Content");
			if (contentTrans == null)
			{
				Log.Error("ES_RuneBag 预制体缺少 EG_RuneDecompose/E_RuneBagItems_Select/Content");
				return;
			}

			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < selectedList.Count; i++)
			{
				if (i >= self.SelectItems.Count)
				{
					if (!self.AssetList.Contains(RuneBagItemPrefabPath))
					{
						self.AssetList.Add(RuneBagItemPrefabPath);
					}

					GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(RuneBagItemPrefabPath);
					if (prefab == null)
					{
						Log.Error($"符文背包条目预制体加载失败：{RuneBagItemPrefabPath}");
						return;
					}

					GameObject go = UnityEngine.Object.Instantiate(prefab, contentTrans);
					Scroll_Item_RuneBagItem item = self.AddChild<Scroll_Item_RuneBagItem>();
					item.BindTrans(go.transform);
					self.SelectItems.Add(item);
				}

				Scroll_Item_RuneBagItem selectItem = self.SelectItems[i];
				selectItem.uiTransform.gameObject.SetActive(true);
				selectItem.OnInitUI(selectedList[i]);
				selectItem.SetCheck(true, true);
			}

			//多出来的条目复用隐藏
			for (int i = selectedList.Count; i < self.SelectItems.Count; i++)
			{
				Scroll_Item_RuneBagItem selectItem = self.SelectItems[i];
				selectItem.uiTransform.gameObject.SetActive(false);
			}
		}

		#endregion

		/// <summary>
		/// 符文图标：RuneConfig.Icon 就是 RoleSkillIcon 图集下的图标名
		/// </summary>
		public static Sprite LoadRuneIcon(this ES_RuneBag self, string icon)
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
