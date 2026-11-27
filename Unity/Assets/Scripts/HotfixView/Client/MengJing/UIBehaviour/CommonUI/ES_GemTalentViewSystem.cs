
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOfAttribute(typeof(ES_GemTalentItem))]
	[EntitySystemOf(typeof(ES_GemTalent))]
	[FriendOfAttribute(typeof(ES_GemTalent))]
	public static partial class ES_GemTalentSystem 
	{
		/// <summary>
		/// 配置 AddPropreType 的取值：0=属性效果，1=技能效果
		/// </summary>
		private const int AddPropreTypeSkill = 1;

		private const string PropertyEffectName = "属性效果";
		private const string SkillEffectName = "技能效果";

		[EntitySystem]
		private static void Awake(this ES_GemTalent self,Transform transform)
		{
			self.uiTransform = transform;

			self.E_ReturnButton.AddListener(self.OnReturnButton);
			self.E_ActiveGemTalentButton.AddListenerAsync(self.OnActiveGemTalentButton);
			self.E_ReSetButton.AddListener(self.OnReSetButton);
			self.SetActivationVisibility(false, false);

			self.AreaLockRectTransforms[0] = self.EG_AreaLock_1RectTransform;
			self.AreaLockRectTransforms[1] = self.EG_AreaLock_2RectTransform;
			self.AreaLockRectTransforms[2] = self.EG_AreaLock_3RectTransform;
			for (int i = 0; i < self.AreaLockRectTransforms.Length; i++)
			{
				//遮罩上的解锁条件文本没有E_前缀，生成代码不会绑定，这里手动取
				self.AreaLockNameTexts[i] = UIFindHelper.FindDeepChild<Text>(self.AreaLockRectTransforms[i].gameObject, "Name");
			}

			self.AddGemTalentItem(11001, self.EG_GemTalentItem_11001RectTransform);
			self.AddGemTalentItem(11002, self.EG_GemTalentItem_11002RectTransform);
			self.AddGemTalentItem(11003, self.EG_GemTalentItem_11003RectTransform);
			self.AddGemTalentItem(11004, self.EG_GemTalentItem_11004RectTransform);
			self.AddGemTalentItem(11005, self.EG_GemTalentItem_11005RectTransform);

			self.AddGemTalentItem(12001, self.EG_GemTalentItem_12001RectTransform);
			self.AddGemTalentItem(12002, self.EG_GemTalentItem_12002RectTransform);
			self.AddGemTalentItem(12003, self.EG_GemTalentItem_12003RectTransform);
			self.AddGemTalentItem(12004, self.EG_GemTalentItem_12004RectTransform);
			self.AddGemTalentItem(12005, self.EG_GemTalentItem_12005RectTransform);

			self.AddGemTalentItem(13001, self.EG_GemTalentItem_13001RectTransform);
			self.AddGemTalentItem(13002, self.EG_GemTalentItem_13002RectTransform);
			self.AddGemTalentItem(13003, self.EG_GemTalentItem_13003RectTransform);
			self.AddGemTalentItem(13004, self.EG_GemTalentItem_13004RectTransform);
			self.AddGemTalentItem(13005, self.EG_GemTalentItem_13005RectTransform);
		}

		[EntitySystem]
		private static void Destroy(this ES_GemTalent self)
		{
			self.GemTalentItems.Clear();
			self.DestroyWidget();
		}

		private static void OnReturnButton(this ES_GemTalent self)
		{
			self.uiTransform.gameObject.SetActive(false);
		}

		private static void AddGemTalentItem(this ES_GemTalent self, int gemTalentId, Transform itemTransform)
		{
			if (itemTransform == null)
			{
				Log.Error($"ES_GemTalent 预制体缺少天赋节点：{gemTalentId}");
				return;
			}

			ES_GemTalentItem item = self.AddChild<ES_GemTalentItem, Transform>(itemTransform);
			item.Init(gemTalentId);
			self.GemTalentItems.Add(item);
		}

		/// <summary>
		/// 刷新总点数、可用点数、区域遮罩、节点状态和右侧详情
		/// </summary>
		public static void OnUpdateUI(this ES_GemTalent self)
		{
			GemTalentComponentC gemTalentComponent = self.Root().GetComponent<GemTalentComponentC>();
			if (gemTalentComponent == null)
			{
				return;
			}

			//总宝石点数由服务端算好下发，客户端不再统计装备上的宝石
			int maxPoint = gemTalentComponent.GetMaxPoint();

			self.E_AllPointText.text = $"总宝石点数：{maxPoint}";
			self.E_LeftPointText.text = $"可用宝石点数：{gemTalentComponent.GetLeftPoint()}";

			//区域解锁后整块遮罩直接隐藏，未解锁时显示该区域的解锁条件
			for (int i = 0; i < self.AreaLockRectTransforms.Length; i++)
			{
				int area = i + 1;
				GemTalentAreaConfig areaConfig = GemTalentAreaConfigCategory.Instance.GetOrDefault(area);

				Text lockNameText = self.AreaLockNameTexts[i];
				if (lockNameText != null)
				{
					lockNameText.text = $"累计{(areaConfig == null ? 0 : areaConfig.NeedTotalPoint)}宝石点数解锁";
				}

				self.AreaLockRectTransforms[i].gameObject.SetActive(!GemTalentHelper.IsAreaUnlocked(area, maxPoint));
			}

			//区域始终按总宝石点数判断，这里只防御配置变动导致的无效选中
			if (self.SelectGemTalentId != 0)
			{
				GemTalentConfig selectConfig = GemTalentConfigCategory.Instance.GetOrDefault(self.SelectGemTalentId);
				if (selectConfig == null || !GemTalentHelper.IsAreaUnlocked(selectConfig.Area, maxPoint))
				{
					self.SelectGemTalentId = 0;
				}
			}

			//没有选中节点时默认选中第一个已解锁的节点
			if (self.SelectGemTalentId == 0)
			{
				self.SelectGemTalentId = self.GetDefaultSelectGemTalentId(maxPoint);
			}

			GemTalentConfig displayConfig = null;
			Sprite displayIcon = null;
			for (int i = 0; i < self.GemTalentItems.Count; i++)
			{
				ES_GemTalentItem item = self.GemTalentItems[i];
				GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(item.GemTalentId);
				if (gemTalentConfig == null)
				{
					item.OnUpdateUI(false, false, false);
					continue;
				}

				bool unlocked = GemTalentHelper.IsAreaUnlocked(gemTalentConfig.Area, maxPoint);
				bool active = gemTalentComponent.HaveGemTalent(item.GemTalentId);
				bool selected = self.SelectGemTalentId == item.GemTalentId;
				item.OnUpdateUI(unlocked, active, selected);
				if (selected || (self.SelectGemTalentId == 0 && displayConfig == null))
				{
					displayConfig = gemTalentConfig;
					displayIcon = item.E_ImageIconImage.sprite;
				}
			}

			self.RefreshGemTalentInfo(displayConfig, displayIcon);
		}

		private static int GetDefaultSelectGemTalentId(this ES_GemTalent self, int maxPoint)
		{
			for (int i = 0; i < self.GemTalentItems.Count; i++)
			{
				ES_GemTalentItem item = self.GemTalentItems[i];
				GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(item.GemTalentId);
				if (gemTalentConfig == null)
				{
					continue;
				}

				if (GemTalentHelper.IsAreaUnlocked(gemTalentConfig.Area, maxPoint))
				{
					return gemTalentConfig.Id;
				}
			}

			return 0;
		}

		/// <summary>
		/// 点击天赋节点：未解锁时提示区域所需点数
		/// </summary>
		public static void OnClickGemTalentItem(this ES_GemTalent self, int gemTalentId)
		{
			GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(gemTalentId);
			GemTalentComponentC gemTalentComponent = self.Root().GetComponent<GemTalentComponentC>();
			if (gemTalentConfig == null || gemTalentComponent == null)
			{
				return;
			}

			if (!GemTalentHelper.IsAreaUnlocked(gemTalentConfig.Area, gemTalentComponent.GetMaxPoint()))
			{
				GemTalentAreaConfig areaConfig = GemTalentAreaConfigCategory.Instance.GetOrDefault(gemTalentConfig.Area);
				if (areaConfig != null)
				{
					FlyTipComponent.Instance.ShowFlyTip($"累计{areaConfig.NeedTotalPoint}宝石点数解锁此区域");
				}

				return;
			}

			self.SelectGemTalentId = gemTalentId;
			self.OnUpdateUI();
		}

		/// <summary>
		/// 刷新右侧天赋详情，预览未激活的天赋时也显示激活按钮
		/// </summary>
		private static void RefreshGemTalentInfo(this ES_GemTalent self, GemTalentConfig gemTalentConfig, Sprite displayIcon)
		{
			self.DisplayGemTalentId = gemTalentConfig?.Id ?? 0;
			self.E_GemTalentIconImage.sprite = displayIcon;
			self.E_GemTalentIconImage.enabled = displayIcon != null;

			if (gemTalentConfig == null)
			{
				self.SetActivationVisibility(false, false);
				return;
			}

			self.E_GemTalentNameText.text = gemTalentConfig.Name;
			self.E_AddPropreTypeText.text = gemTalentConfig.AddPropreType == AddPropreTypeSkill ? SkillEffectName : PropertyEffectName;
			self.E_GemTalentDescText.text = gemTalentConfig.Des;
			self.E_CostPointText.text = $"消耗宝石点数：{gemTalentConfig.CostPoint}";

			Scene root = self.Root();
			GemTalentComponentC gemTalentComponent = root.GetComponent<GemTalentComponentC>();
			bool activated = gemTalentComponent.HaveGemTalent(gemTalentConfig.Id);
			self.SetActivationVisibility(activated, !activated);
			if (!activated)
			{
				bool notEnoughPoints = gemTalentComponent.GetLeftPoint() < gemTalentConfig.CostPoint;
				CommonViewHelper.SetImageGray(root, self.E_ActiveGemTalentButton.gameObject, notEnoughPoints);
			}
		}

		private static void SetActivationVisibility(this ES_GemTalent self, bool activated, bool showActiveInfo)
		{
			self.EG_ActiveInfoRectTransform.gameObject.SetActive(showActiveInfo);
			self.E_ActivatedText.gameObject.SetActive(activated);
		}

		private static async ETTask OnActiveGemTalentButton(this ES_GemTalent self)
		{
			Scene root = self.Root();
			GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(self.DisplayGemTalentId);
			GemTalentComponentC gemTalentComponent = root.GetComponent<GemTalentComponentC>();
			if (gemTalentConfig == null || gemTalentComponent == null)
			{
				return;
			}

			if (!GemTalentHelper.IsAreaUnlocked(gemTalentConfig.Area, gemTalentComponent.GetMaxPoint()))
			{
				HintHelp.ShowErrorHint(root, ErrorCode.ERR_GemTalentAreaLock, 0);
				return;
			}

			if (gemTalentComponent.GetLeftPoint() < gemTalentConfig.CostPoint)
			{
				HintHelp.ShowErrorHint(root, ErrorCode.ERR_GemTalentPointNotEnough, 0);
				return;
			}

			int error = await GemTalentNetHelper.ActiveGemTalent(root, gemTalentConfig.Id);
			if (error != ErrorCode.ERR_Success)
			{
				HintHelp.ShowErrorHint(root, error);
				return;
			}

			FlyTipComponent.Instance.ShowFlyTip("激活成功");
			self.OnUpdateUI();
		}

		private static void OnReSetButton(this ES_GemTalent self)
		{
			int costDiamond = GlobalValueConfigCategory.Instance.GemTalentResetCostDiamond;
			string tip = $"重置会清空所有已激活的宝石天赋，返还全部宝石点数\n需要消耗{costDiamond}钻石";
			PopupTipHelp.OpenPopupTip(self.Root(), "重置宝石天赋", tip, () => { self.ReSetGemTalent().Coroutine(); }).Coroutine();
		}

		private static async ETTask ReSetGemTalent(this ES_GemTalent self)
		{
			int error = await GemTalentNetHelper.ResetGemTalent(self.Root());
			if (error != ErrorCode.ERR_Success)
			{
				HintHelp.ShowErrorHint(self.Root(), error);
				return;
			}

			FlyTipComponent.Instance.ShowFlyTip("重置成功");
			self.SelectGemTalentId = 0;
			self.OnUpdateUI();
		}
	}
}
