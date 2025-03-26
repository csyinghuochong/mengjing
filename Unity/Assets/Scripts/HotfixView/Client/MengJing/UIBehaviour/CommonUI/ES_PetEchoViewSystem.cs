
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetEcho))]
	[FriendOfAttribute(typeof(ES_PetEcho))]
	[FriendOfAttribute(typeof(Scroll_Item_PetEchoItem))]
	
	public static partial class ES_PetEchoSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetEcho self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_PetEchoItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetEchoItemsRefresh);
			self.E_PetEchoSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetEchoSkillItemsRefresh);
			
			self.E_ButtonOpenButton.AddListenerAsync(self.OnClickOpenButton);
			self.E_ButtonChange.AddListenerAsync(self.OnClickChangeButton);
			
			self.EG_Left_1RectTransform.gameObject.SetActive(true);
			self.EG_Left_2RectTransform.gameObject.SetActive(false);
			self.E_ButtonActiveButton.AddListener(self.OnButtonActiveButton);

			self.UpdateActiveNumber();
		}

		private static void OnButtonActiveButton(this ES_PetEcho self)
		{
			self.EG_Left_1RectTransform.gameObject.SetActive(!self.EG_Left_1RectTransform.gameObject.activeSelf);
			self.EG_Left_2RectTransform.gameObject.SetActive(!self.EG_Left_2RectTransform.gameObject.activeSelf);
		}

		private static void UpdateActiveNumber(this ES_PetEcho self)
		{
			//PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
			SkillSetComponentC skillSetComponentC = self.Root().GetComponent<SkillSetComponentC>();
			int activeNumber = skillSetComponentC.GetPetEchoSkillList().Count;
			using (zstring.Block())
			{
				self.E_ActiveNumberText.text = zstring.Format("激活({0}/{1})", activeNumber, ConfigData.PetEchoSkill.Count);
			}
		}

		private static async ETTask OnClickOpenButton(this ES_PetEcho self)
		{
              string[] openlist = ConfigData.PetEchoAttri[self.Index].Value2.Split("&");
             
              int needlv = int.Parse(openlist[0]);

              if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv < needlv)
              {
	              FlyTipComponent.Instance.ShowFlyTip("等级不足");
	              return;
              }
              
              BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

              if (!bagComponent.CheckNeedItem(openlist[1]))
              {
	               FlyTipComponent.Instance.ShowFlyTip("道具不足");
                   return;
              }
              await PetNetHelper.RequestPetEchoOperate(self.Root(), 1, self.Index, 0);

              self.UpdatePetEchoItemOpenStatus();
		}

		private static async ETTask OnClickChangeButton(this ES_PetEcho self)
		{
			await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetSelect);
			self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetSelect>().OnSetType(PetOperationType.PetEcho);
		}

		public static async ETTask OnPetItemSelect(this ES_PetEcho self, RolePetInfo rolePetInfo)
		{
			await PetNetHelper.RequestPetEchoOperate(self.Root(), 2, self.Index, rolePetInfo.Id);
			
			self.UpdatePetEchoItemList();
		}

		private static void OnPetEchoItemsRefresh(this ES_PetEcho self, Transform transform, int index)
		{
			Scroll_Item_PetEchoItem scrollItemPetListItem = self.ScrollItemPetEchoItems[index].BindTrans(transform);
			scrollItemPetListItem.SetClickHandler(self.OnClickPetEchoItemHandler);
            scrollItemPetListItem.OnInitData(ConfigData.PetEchoAttri[index], index);

            if (index == 0)
            {
	            self.OnClickPetEchoItemHandler(index);
            }
		}

		private static void OnPetEchoSkillItemsRefresh(this ES_PetEcho self, Transform transform, int index)
		{
			Scroll_Item_PetEchoSkillItem scrollItemPetListItem = self.ScrollItemPetEchoSkillItems[index].BindTrans(transform);
			scrollItemPetListItem.OnInitData(ConfigData.PetEchoSkill[index]);
		}
        
		private static void OnClickPetEchoItemHandler(this ES_PetEcho self, int index)
		{
			self.Index = index;
           
			PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
			if (petComponentC.PetEchoList[self.Index].KeyId == 0)
			{
				//未开启
				self.EG_Opened.gameObject.SetActive(false);
				self.EG_NoOpen.gameObject.SetActive(true);	
				self.UpdateNoOpenStatus();
            }
			else
			{
				//已开启
				self.EG_Opened.gameObject.SetActive(true);
				self.EG_NoOpen.gameObject.SetActive(false);	
				self.UpdateOpenedStatus();
			}
			
			self.UpdatePetEchoItemSelect(index);	
        }

		private static void UpdatePetEchoItemOpenStatus(this ES_PetEcho self)
		{
			foreach (Scroll_Item_PetEchoItem echoitem in self.ScrollItemPetEchoItems.Values)
            {
                if (echoitem.uiTransform == null)
                {
                    continue;	
                }
                echoitem.UpdateOpenStatus();
            }
		}

		private static void UpdatePetEchoItemSelect(this ES_PetEcho self, int index)
		{
			foreach (Scroll_Item_PetEchoItem echoitem in self.ScrollItemPetEchoItems.Values)
			{
				if (echoitem.uiTransform == null)
				{
					continue;	
				}
				
				echoitem.OnSelectUI(index);
			}
		}

		// new KeyValuePair() { KeyId = 200101, Value = "力量之源1", Value2 = "10&1025008;1@1025009;1" }, //暴击
        private static void UpdateNoOpenStatus(this ES_PetEcho self)
        {
            KeyValuePair keyValuePair = ConfigData.PetEchoAttri[self.Index];

			string[] openlist = keyValuePair.Value2.Split("&");
            string pname = ItemViewHelp.GetAttributeName(ConfigData.PetEchoAttri[self.Index].KeyId);

            using (zstring.Block())
            {
	            self.E_Text_NeedLvText.text = zstring.Format("开启等级：{0}级", openlist[0]);
                			self.E_Text_AttributeText.text = zstring.Format("开启此位置可以提升{0}效果", pname);
            }
            
            self.ES_CostList.Refresh(openlist[1]);
            self.E_Text_NameText.text = keyValuePair.Value;
        }

        private static void UpdateOpenedStatus(this ES_PetEcho self)
        {
	        KeyValuePair keyValuePair = ConfigData.PetEchoAttri[self.Index];

	        string[] openlist = keyValuePair.Value2.Split("&");
	        string pname = ItemViewHelp.GetAttributeName(ConfigData.PetEchoAttri[self.Index].KeyId);
	        
	        PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
	        RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petComponent.PetEchoList[self.Index].Value);
	        if(rolePetInfo == null)
	        {
		        return;
	        }
	        
	        self.E_Text_Name_Opened.text = keyValuePair.Value;
	        self.E_Text_Name_Pet.text = rolePetInfo.PetName;
	       
	        int fightNum = 0;
	        for (int i = 0; i < ConfigData.PetEchoAttri.Count; i++)
	        {
		        RolePetInfo rolePetInfoNow = petComponent.GetPetInfoByID(petComponent.PetEchoList[i].Value);
		        if (rolePetInfoNow != null)
		        {
			        fightNum = fightNum + rolePetInfoNow.PetPingFen;
		        }
	        }
	        
	        GameObject gameObject = self.ES_ModelShow.EG_RootRectTransform.gameObject;
	        PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
	        using (zstring.Block())
	        {
		        self.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petConfig.PetModel)).Coroutine();
	        }

	        gameObject.transform.Find("Camera").localPosition = new Vector3(0f, 100f, 450f);
	        gameObject.transform.Find("Camera").GetComponent<Camera>().fieldOfView = 30;
	        gameObject.transform.localPosition = new Vector2(self.Index * 1000 + 10000, 0);
	        gameObject.transform.Find("ModelParent").localRotation = Quaternion.Euler(0f, -45f, 0f);
	        
	        using (zstring.Block())
	        {
		        self.E_Text_Name_Pet_Comabt.text = zstring.Format("战力：{0}", rolePetInfo.PetPingFen);
		        self.E_Text_Attribute_Opened.text = zstring.Format("{0}提升+{1}%",pname, (CommonHelp.GetPetShouHuPro(rolePetInfo.PetPingFen, fightNum) * 100).ToString("F2"));
	        }
        }

        [EntitySystem]
		private static void Destroy(this ES_PetEcho self)
		{
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this ES_PetEcho self)
		{
			self.InitPetEchoItemList();
			self.InitPetEchoSkillItemList();
		}

		private static void InitPetEchoItemList(this ES_PetEcho self)
		{
			self.AddUIScrollItems(ref self.ScrollItemPetEchoItems, ConfigData.PetEchoAttri.Count);
			self.E_PetEchoItemsLoopVerticalScrollRect.SetVisible(true, ConfigData.PetEchoAttri.Count);
		}
		private static void UpdatePetEchoItemList(this ES_PetEcho self)
		{
			foreach (Scroll_Item_PetEchoItem echoitem in self.ScrollItemPetEchoItems.Values)
			{
				if (echoitem.uiTransform == null)
				{
					continue;	
				}
				
				echoitem.UpdatePetSet();
			}
		}
		
		private static void InitPetEchoSkillItemList(this ES_PetEcho self)
		{
			self.AddUIScrollItems(ref self.ScrollItemPetEchoSkillItems, ConfigData.PetEchoSkill.Count);
			self.E_PetEchoSkillItemsLoopVerticalScrollRect.SetVisible(true, ConfigData.PetEchoSkill.Count);
		}
		
		private static void UpdatePetEchoSkillItemList(this ES_PetEcho self)
		{
        			
		}
	}


}
