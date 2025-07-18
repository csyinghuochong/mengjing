
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_PaiMaiSellItem))]
	[FriendOf(typeof(Scroll_Item_CommonItem))]
	[EntitySystemOf(typeof(ES_StallSell))]
	[FriendOfAttribute(typeof(ES_StallSell))]
	public static partial class ES_StallSellSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_StallSell self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
			self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
			self.E_PaiMaiSellItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPaiMaiSellItemsRefresh);

			self.E_Btn_XiaJiaButton.AddListenerAsync(self.OnBtn_XiaJia);
			self.E_Btn_ShangJiaButton.AddListenerAsync(self.OnBtn_ShangJia);
			self.E_Btn_StallButton.AddListener(self.OnBtn_Stall);
		}

		[EntitySystem]
		private static void Destroy(this ES_StallSell self)
		{
			self.DestroyWidget();
		}
		
		public static void CheckSensitiveWords(this ES_StallSell self)
		{
			string text_new = "";
			string text_old = self.E_Stall_NameInputField.GetComponent<InputField>().text;
			MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
			self.E_Stall_NameInputField.GetComponent<InputField>().text = text_old;
		}

		public static async ETTask OnBtn_ChangeName(this ES_StallSell self)
		{
			string name = self.E_Stall_NameInputField.GetComponent<InputField>().text;
			bool mask = MaskWordHelper.Instance.IsContainSensitiveWords(name);
			if (mask)
			{
				FlyTipComponent.Instance.ShowFlyTip("请重新输入！");
				return;
			}

			M2C_StallOperationResponse response =  await PaiMaiNetHelper.RequestStallOperation(self.Root(), 2, name);
			if (response.Error != ErrorCode.ERR_Success || self.IsDisposed)
			{
				return;
			}

			self.E_Stall_NameInputField.GetComponent<InputField>().text = name;
		}

		public static async ETTask RequestSelfPaiMaiList(this ES_StallSell self)
		{
			P2C_StallListResponse p2CStallListResponse =  await PaiMaiNetHelper.RequestStallList(self.Root(), UnitHelper.GetMyUnitId(self.Root()));
			if (p2CStallListResponse == null || self.IsDisposed)
			{
				return;
			}

			self.PaiMaiItemInfos = p2CStallListResponse.PaiMaiItemInfos;
			
			string name = self.Root().GetComponent<UserInfoComponentC>().UserInfo.StallName;
			if (string.IsNullOrEmpty(name))
			{
				name = "商品摊位";
			}

			self.E_Stall_NameInputField.GetComponent<InputField>().text = name;
			//self.UpdateSellItemUILIist( self.E_ItemTypeSetToggleGroup.GetCurrentIndex() );
			self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
		}
		
		public static void OnUpdateUI(this ES_StallSell self)
		{
			self.UpdateBagItemUIList().Coroutine();
			self.RequestSelfPaiMaiList().Coroutine();
			//self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
		}
		
		public static void OnClickPageButton(this ES_StallSell self, int page)
		{
			self.UpdateSellItemUILIist(page);
		}
        
		public static void OnBtn_Stall(this ES_StallSell self)
		{
			MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
			if (mapComponent.MapType != (int)MapTypeEnum.MainCityScene)
			{
				//弹出提示
				FlyTipComponent.Instance.ShowFlyTip("请前往主城摆摊!");
				return;
			}
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			if (UnitHelper.GetUnitListByDis(unit.Root().CurrentScene(), unit.Position, UnitType.Npc, 5f).Count > 0)
			{
				PopupTipHelp.OpenPopupTip_2(self.Root(), "摆摊提示", "系统角色附近不得摆摊， 是否前往摆摊区域进行摆摊?", () => { self.OnRun(); }).Coroutine();
				return;
			}

			Vector3 vector3 = unit.Position;
			int x = Mathf.FloorToInt(vector3.x * 100);
			int z = Mathf.FloorToInt(vector3.z * 100);
			SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
			int[] stallarea = sceneConfig.StallArea;

			float distance = stallarea[3] > 100 ? stallarea[3] : 300;

			if (Mathf.Abs(x - stallarea[0]) > distance || Mathf.Abs(z - stallarea[2]) > distance)
			{
				PopupTipHelp.OpenPopupTip_2(self.Root(), "摆摊提示", "是否前往摆摊区域进行摆摊?", () => { self.OnRun(); }).Coroutine();
				return;
			}

			PaiMaiNetHelper.RequestStallOperation(self.Root(), 1, String.Empty).Coroutine();
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMai);
		}
        
		public static void OnRun(this ES_StallSell self)
		{
			// ETTask.CompletedTask;
			//FloatTipManager.Instance.ShowFloatTip("请前往主城摆摊222!");
			MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
			SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
			int[] stallarea = sceneConfig.StallArea;

			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			unit.MoveToAsync(new float3(stallarea[0] * 0.01f, stallarea[1] * 0.01f, stallarea[2] * 0.01f)).Coroutine();

			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMai);
		}
		
		public static async ETTask OnBtn_XiaJia(this ES_StallSell self)
		{
			if (self.PaiMaiItemInfoId == 0)
			{
				FlyTipComponent.Instance.ShowFlyTip("请选中道具");
				return;
			}

			for (int i = self.PaiMaiItemInfos.Count - 1; i >= 0; i--)
			{
				if (self.PaiMaiItemInfos[i].Id == self.PaiMaiItemInfoId)
				{
					if (self.PaiMaiItemInfos[i].UserId != UnitHelper.GetMyUnitId(self.Root()))
					{
						FlyTipComponent.Instance.ShowFlyTip("数据错误!");
						return;
					}
				}
			}

			await PaiMaiNetHelper.RequestStallXiaJia(self.Root(), self.PaiMaiItemInfoId );
		 	if (self.IsDisposed)
			{
				return;
			}

			for (int i = self.PaiMaiItemInfos.Count - 1; i >= 0; i--)
			{
				if (self.PaiMaiItemInfos[i].Id == self.PaiMaiItemInfoId)
				{
					self.PaiMaiItemInfos.RemoveAt(i);
				}
			}

			self.PaiMaiItemInfoId = 0;

			self.UpdateBagItemUIList().Coroutine();
			self.UpdateSellItemUILIist( self.E_ItemTypeSetToggleGroup.GetCurrentIndex());
		}
        
		public static async ETTask OnBtn_ShangJia(this ES_StallSell self)
		{
			if (self.BagInfo == null)
			{
				FlyTipComponent.Instance.ShowFlyTip("请选中道具！");
				return;
			}

			ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
			if (itemConfig.IfStopPaiMai == 1)
			{
				FlyTipComponent.Instance.ShowFlyTip("此道具禁止上架！");
				return;
			}
			if (!CommonHelp.IsShowPaiMai(itemConfig.ItemType, itemConfig.ItemSubType))
			{
				FlyTipComponent.Instance.ShowFlyTip("此道具不能上架！");
				return;
			}
			if (self.PaiMaiItemInfos.Count >= GlobalValueConfigCategory.Instance.MaxAuctionQuantity)
			{
				FlyTipComponent.Instance.ShowFlyTip("已经达到最大上架数量！");
				return;
			}
			
			await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_StallSellPrice);
			DlgStallSellPrice dlgStallSellPrice = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgStallSellPrice>();
			dlgStallSellPrice.InitPriceUI(self.BagInfo);
		}
		
		public static async ETTask UpdateBagItemUIList(this ES_StallSell self)
		{
			List<ItemInfo> equipInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            self.ShowBagInfos.Clear();
            for (int i = 0; i < equipInfos.Count; i++)
            {
                if (equipInfos[i].isBinging || equipInfos[i].IsProtect)
                {
                    continue;
                }

                self.ShowBagInfos.Add(equipInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
            await ETTask.CompletedTask;
		}
		
		 public static void OnPaiBuyShangJia(this ES_StallSell self, PaiMaiItemInfo paiMaiItemInfo)
         {
             self.BagInfo = null; //选中置空
             self.PaiMaiItemInfos.Add(paiMaiItemInfo); //增加拍卖行出售的列表
        
             self.UpdateBagItemUIList().Coroutine();
             self.UpdateSellItemUILIist( self.E_ItemTypeSetToggleGroup.GetCurrentIndex());
         }
        
         public static void OnSelectItem(this ES_StallSell self, ItemInfo bagInfo)
         {
	         self.BagInfo = bagInfo;

	         if (self.ScrollItemCommonItems != null)
	         {
		         foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
		         {
			         if (item.uiTransform == null)
			         {
				         continue;
			         }

			         item.SetSelected(bagInfo);
		         }
	         }
         }

         public static void OnSelectSellItem(this ES_StallSell self, PaiMaiItemInfo paiMaiItemInfo)
         {
	         self.PaiMaiItemInfoId = paiMaiItemInfo.Id;

	         if (self.ScrollItemPaiMaiSellItems != null)
	         {
		         foreach (Scroll_Item_PaiMaiSellItem item in self.ScrollItemPaiMaiSellItems.Values)
		         {
			         if (item.uiTransform == null)
			         {
				         continue;
			         }

			         item.SetSelected(paiMaiItemInfo.Id);
		         }
	         }
         }
         
		/// <summary>
		/// 
		/// </summary>
		/// <param name="self"></param>
		/// <param name="subType">0 装备   1其他</param>
		/// <returns></returns>
		public static void UpdateSellItemUILIist(this ES_StallSell self, int subType)
		{
			if (self.PaiMaiItemInfos == null)
			{
				return;
			}

			self.ShowPaiMaiItemInfos.Clear();
			for (int i = 0; i < self.PaiMaiItemInfos.Count; i++)
			{
				PaiMaiItemInfo paiMaiItemInfo = self.PaiMaiItemInfos[i];
				ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
				if (subType == 1 && itemConfig.ItemType != ItemTypeEnum.Equipment)
				{
					continue;
				}

				if (subType == 2 && itemConfig.ItemType == ItemTypeEnum.Equipment)
				{
					continue;
				}

				self.ShowPaiMaiItemInfos.Add(paiMaiItemInfo);
			}
			
			self.AddUIScrollItems(ref self.ScrollItemPaiMaiSellItems, self.ShowPaiMaiItemInfos.Count);
			self.E_PaiMaiSellItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPaiMaiItemInfos.Count);
			int maxNum = GlobalValueConfigCategory.Instance.MaxAuctionQuantity;
			using (zstring.Block())
			{
				self.E_ShangJiaNumberText.text = zstring.Format("已上架:{0}/{1}", self.PaiMaiItemInfos.Count, maxNum);
			}
		}
		
		private static void OnItemTypeSet(this ES_StallSell self, int index)
		{
			self.UpdateSellItemUILIist(index);
		}
		
		private static void OnBagItemsRefresh(this ES_StallSell self, Transform transform, int index)
		{
			foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
			{
				if (item.uiTransform == transform)
				{
					item.uiTransform = null;
				}
			}
            
			Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
			scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.PaiMaiSell, self.OnSelectItem);
		}
		
		 private static void OnPaiMaiSellItemsRefresh(this ES_StallSell self, Transform transform, int index)
        {
            foreach (Scroll_Item_PaiMaiSellItem item in self.ScrollItemPaiMaiSellItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PaiMaiSellItem scrollItemPaiMaiSellItem = self.ScrollItemPaiMaiSellItems[index].BindTrans(transform);
            scrollItemPaiMaiSellItem.SetClickHandler((bagInfo) => { self.OnSelectSellItem(bagInfo); });
            scrollItemPaiMaiSellItem.OnUpdateUI(self.ShowPaiMaiItemInfos[index]);
        }
	}


}
