
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
		/// 预制体里天赋节点的名字前缀，完整名字形如 GemTalentItem_11001
		/// </summary>
		private const string GemTalentItemPrefix = "GemTalentItem_";

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
			self.E_ActiveGemTalentButton.gameObject.SetActive(false);

			self.AreaLockRectTransforms[0] = self.EG_AreaLock_1RectTransform;
			self.AreaLockRectTransforms[1] = self.EG_AreaLock_2RectTransform;
			self.AreaLockRectTransforms[2] = self.EG_AreaLock_3RectTransform;
			for (int i = 0; i < self.AreaLockRectTransforms.Length; i++)
			{
				//遮罩上的解锁条件文本没有E_前缀，生成代码不会绑定，这里手动取
				self.AreaLockNameTexts[i] = UIFindHelper.FindDeepChild<Text>(self.AreaLockRectTransforms[i].gameObject, "Name");
			}

			self.RefreshGemTalentItems();
		}

		[EntitySystem]
		private static void Destroy(this ES_GemTalent self)
		{
			self.DestroyWidget();
		}

		private static void OnReturnButton(this ES_GemTalent self)
		{
			self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.CloseGemTalent();
		}

		/// <summary>
		/// 天赋节点是美术在预制体里摆好的静态节点，这里按节点名里的id创建实体，只创建一次
		/// </summary>
		private static void RefreshGemTalentItems(this ES_GemTalent self)
		{
			if (self.GemTalentItems.Count > 0)
			{
				return;
			}

			Transform leftTrans = self.uiTransform.Find("Left");
			if (leftTrans == null)
			{
				Log.Error("ES_GemTalent 预制体缺少 Left 节点");
				return;
			}

			for (int i = 0; i < leftTrans.childCount; i++)
			{
				Transform child = leftTrans.GetChild(i);
				if (!child.name.StartsWith(GemTalentItemPrefix))
				{
					continue;
				}

				if (!int.TryParse(child.name.Substring(GemTalentItemPrefix.Length), out int gemTalentId))
				{
					Log.Error($"宝石天赋节点名无法解析出天赋id：{child.name}");
					continue;
				}

				ES_GemTalentItem item = self.AddChild<ES_GemTalentItem, Transform>(child);
				item.Init(gemTalentId);
				self.GemTalentItems.Add(item);
			}
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
				item.OnUpdateUI(unlocked, active, self.SelectGemTalentId == item.GemTalentId);
			}

			self.RefreshGemTalentInfo();
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
		/// 点击天赋节点：未解锁区域内的天赋不能选中
		/// </summary>
		public static void OnClickGemTalentItem(this ES_GemTalent self, int gemTalentId)
		{
			GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(gemTalentId);
			if (gemTalentConfig == null)
			{
				return;
			}

			GemTalentComponentC gemTalentComponent = self.Root().GetComponent<GemTalentComponentC>();
			if (!GemTalentHelper.IsAreaUnlocked(gemTalentConfig.Area, gemTalentComponent.GetMaxPoint()))
			{
				return;
			}

			self.SelectGemTalentId = gemTalentId;
			self.OnUpdateUI();
		}

		/// <summary>
		/// 刷新右侧天赋详情：已激活不显示激活按钮，点数不足按钮置灰
		/// </summary>
		private static void RefreshGemTalentInfo(this ES_GemTalent self)
		{
			GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(self.SelectGemTalentId);
			if (gemTalentConfig == null)
			{
				self.E_ActiveGemTalentButton.gameObject.SetActive(false);
				return;
			}

			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, gemTalentConfig.Icon.ToString());
			self.E_GemTalentIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
			self.E_GemTalentNameText.text = gemTalentConfig.Name;
			self.E_AddPropreTypeText.text = gemTalentConfig.AddPropreType == AddPropreTypeSkill ? SkillEffectName : PropertyEffectName;
			self.E_GemTalentDescText.text = gemTalentConfig.Des;
			self.E_CostPointText.text = $"消耗宝石点数：{gemTalentConfig.CostPoint}";

			GemTalentComponentC gemTalentComponent = self.Root().GetComponent<GemTalentComponentC>();
			if (gemTalentComponent.HaveGemTalent(gemTalentConfig.Id))
			{
				self.E_ActiveGemTalentButton.gameObject.SetActive(false);
				return;
			}

			self.E_ActiveGemTalentButton.gameObject.SetActive(true);

			int leftPoint = gemTalentComponent.GetLeftPoint();
			bool canActive = leftPoint >= gemTalentConfig.CostPoint;
			self.E_ActiveGemTalentButton.interactable = canActive;
			CommonViewHelper.SetImageGray(self.Root(), self.E_ActiveGemTalentButton.gameObject, !canActive);
		}

		private static async ETTask OnActiveGemTalentButton(this ES_GemTalent self)
		{
			if (self.SelectGemTalentId == 0)
			{
				return;
			}

			int error = await GemTalentNetHelper.ActiveGemTalent(self.Root(), self.SelectGemTalentId);
			if (error != ErrorCode.ERR_Success)
			{
				HintHelp.ShowErrorHint(self.Root(), error);
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
