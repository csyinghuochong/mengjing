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
		/// 点 E_Return 回到符文主界面
		/// </summary>
		private static void OnReturnButton(this ES_RuneBag self)
		{
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

				bagItem.SetSelected(bagItem.DataId == self.SelectRuneId);
			}
		}

		/// <summary>
		/// 点列表里的符文：先只记下选中，右侧升级/分解面板后面再补
		/// </summary>
		public static void OnClickRuneItem(this ES_RuneBag self, long runeId)
		{
			self.SelectRuneId = runeId;
			self.RefreshSelect();
		}

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
