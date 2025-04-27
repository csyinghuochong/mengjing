using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillMake : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int MakeId;
		public long Timer;
		public int Plan = -1;

		public List<(int, int)> ShowMakeNeed = new();
		public Dictionary<int, EntityRef<Scroll_Item_MakeNeedItem>> ScrollItemMakeNeedItems;
		public List<int> ShowMake = new();
		public Dictionary<int, EntityRef<Scroll_Item_MakeItem>> ScrollItemMakeItems;
		
		public ItemInfo[] HuiShouInfos { get; set; } = new ItemInfo[5];
		public EntityRef<ES_CommonItem>[] HuiShouUIList = new EntityRef<ES_CommonItem>[5];
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public bool IsHoldDown = false;
		public int PlanMelt = 1;
		
		public RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public Text E_Text_CurrentText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CurrentText == null )
     			{
		    		this.m_E_Text_CurrentText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Text_Current");
     			}
     			return this.m_E_Text_CurrentText;
     		}
     	}

		public Text E_Lab_HuoLiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_HuoLiText == null )
     			{
		    		this.m_E_Lab_HuoLiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Lab_HuoLi");
     			}
     			return this.m_E_Lab_HuoLiText;
     		}
     	}

		public Image E_HuoLiImage
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_HuoLiImage == null )
				{
					this.m_E_HuoLiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_HuoLi");
				}
				return this.m_E_HuoLiImage;
			}
		}
		
		public RectTransform EG_MakeINeedNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MakeINeedNodeRectTransform == null )
     			{
		    		this.m_EG_MakeINeedNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode");
     			}
     			return this.m_EG_MakeINeedNodeRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_MakeNeedItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MakeNeedItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MakeNeedItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_MakeNeedItems");
     			}
     			return this.m_E_MakeNeedItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_MakeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MakeButton == null )
     			{
		    		this.m_E_Btn_MakeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Btn_Make");
     			}
     			return this.m_E_Btn_MakeButton;
     		}
     	}

		public Image E_Btn_MakeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MakeImage == null )
     			{
		    		this.m_E_Btn_MakeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Btn_Make");
     			}
     			return this.m_E_Btn_MakeImage;
     		}
     	}
		
		public Image E_MakeItemIconImage
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_MakeItemIconImage == null )
				{
					this.m_E_MakeItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_MakeItemIcon");
				}
				return this.m_E_MakeItemIconImage;
			}
		}

		public Text E_Lab_MakeNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MakeNameText == null )
     			{
		    		this.m_E_Lab_MakeNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_MakeName");
     			}
     			return this.m_E_Lab_MakeNameText;
     		}
     	}

		public Text E_Lab_MakeNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MakeNumText == null )
     			{
		    		this.m_E_Lab_MakeNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_MakeNum");
     			}
     			return this.m_E_Lab_MakeNumText;
     		}
     	}

		public Text E_Lab_MakeCDTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MakeCDTimeText == null )
     			{
		    		this.m_E_Lab_MakeCDTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_MakeCDTime");
     			}
     			return this.m_E_Lab_MakeCDTimeText;
     		}
     	}

		public Text E_Lab_ShuLianShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ShuLianShowText == null )
     			{
		    		this.m_E_Lab_ShuLianShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_ShuLianShow");
     			}
     			return this.m_E_Lab_ShuLianShowText;
     		}
     	}

		public RectTransform EG_LeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftRectTransform == null )
     			{
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public Button E_Btn_ResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ResetButton == null )
     			{
		    		this.m_E_Btn_ResetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Left/E_Btn_Reset");
     			}
     			return this.m_E_Btn_ResetButton;
     		}
     	}

		public Image E_Btn_ResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ResetImage == null )
     			{
		    		this.m_E_Btn_ResetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Left/E_Btn_Reset");
     			}
     			return this.m_E_Btn_ResetImage;
     		}
     	}

		public LoopVerticalScrollRect E_MakeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MakeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MakeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left/E_MakeItems");
     			}
     			return this.m_E_MakeItemsLoopVerticalScrollRect;
     		}
     	}

		public Image E_Img_ShuLianProImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ShuLianProImage == null )
     			{
		    		this.m_E_Img_ShuLianProImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Left/Img_ProSet/E_Img_ShuLianPro");
     			}
     			return this.m_E_Img_ShuLianProImage;
     		}
     	}

		public Text E_Lab_ShuLianDuText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ShuLianDuText == null )
     			{
		    		this.m_E_Lab_ShuLianDuText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Left/Img_ProSet/E_Lab_ShuLianDu");
     			}
     			return this.m_E_Lab_ShuLianDuText;
     		}
     	}

		public Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Left/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public Button E_Btn_MeltButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MeltButton == null )
     			{
		    		this.m_E_Btn_MeltButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Left/E_Btn_Melt");
     			}
     			return this.m_E_Btn_MeltButton;
     		}
     	}

		public Image E_Btn_MeltImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MeltImage == null )
     			{
		    		this.m_E_Btn_MeltImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Left/E_Btn_Melt");
     			}
     			return this.m_E_Btn_MeltImage;
     		}
     	}

		public Button E_Btn_LearnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_LearnButton == null )
     			{
		    		this.m_E_Btn_LearnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Left/E_Btn_Learn");
     			}
     			return this.m_E_Btn_LearnButton;
     		}
     	}

		public Image E_Btn_LearnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_LearnImage == null )
     			{
		    		this.m_E_Btn_LearnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Left/E_Btn_Learn");
     			}
     			return this.m_E_Btn_LearnImage;
     		}
     	}

		public RectTransform EG_SelectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectRectTransform == null )
     			{
		    		this.m_EG_SelectRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Select");
     			}
     			return this.m_EG_SelectRectTransform;
     		}
     	}

		public Image E_Select_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Select_1Image == null )
     			{
		    		this.m_E_Select_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_1");
     			}
     			return this.m_E_Select_1Image;
     		}
     	}

		public Image E_Select_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Select_2Image == null )
     			{
		    		this.m_E_Select_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_2");
     			}
     			return this.m_E_Select_2Image;
     		}
     	}

		public Image E_Select_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Select_3Image == null )
     			{
		    		this.m_E_Select_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_3");
     			}
     			return this.m_E_Select_3Image;
     		}
     	}

		public Image E_Select_6Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Select_6Image == null )
     			{
		    		this.m_E_Select_6Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_6");
     			}
     			return this.m_E_Select_6Image;
     		}
     	}

		public RectTransform EG_MeltRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MeltRectTransform == null )
     			{
		    		this.m_EG_MeltRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Melt");
     			}
     			return this.m_EG_MeltRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_CommonItemLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonItemLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonItemLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Melt/E_CommonItem");
     			}
     			return this.m_E_CommonItemLoopVerticalScrollRect;
     		}
     	}

		public ES_CommonItem ES_CommonItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_0;
     			if( es==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Melt/ES_CommonItem_0");
		    	   this.m_es_commonitem_0 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_0;
     		}
     	}

		public ES_CommonItem ES_CommonItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_1;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Melt/ES_CommonItem_1");
		    	   this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_1;
     		}
     	}

		public ES_CommonItem ES_CommonItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_2;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Melt/ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public ES_CommonItem ES_CommonItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_3;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Melt/ES_CommonItem_3");
		    	   this.m_es_commonitem_3 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_3;
     		}
     	}

		public ES_CommonItem ES_CommonItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_4;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Melt/ES_CommonItem_4");
		    	   this.m_es_commonitem_4 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_4;
     		}
     	}

		public ES_CommonItem ES_CommonItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_5;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Melt/ES_CommonItem_5");
		    	   this.m_es_commonitem_5 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_5;
     		}
     	}

		public Button E_Btn_MeltBeginButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MeltBeginButton == null )
     			{
		    		this.m_E_Btn_MeltBeginButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Melt/E_Btn_MeltBegin");
     			}
     			return this.m_E_Btn_MeltBeginButton;
     		}
     	}

		public Image E_Btn_MeltBeginImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MeltBeginImage == null )
     			{
		    		this.m_E_Btn_MeltBeginImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Melt/E_Btn_MeltBegin");
     			}
     			return this.m_E_Btn_MeltBeginImage;
     		}
     	}

		public RectTransform EG_TitleSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TitleSetRectTransform == null )
     			{
		    		this.m_EG_TitleSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_TitleSet");
     			}
     			return this.m_EG_TitleSetRectTransform;
     		}
     	}

		public Button E_Btn_TianFu_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Button == null )
     			{
		    		this.m_E_Btn_TianFu_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Button;
     		}
     	}

		public Image E_Btn_TianFu_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Image == null )
     			{
		    		this.m_E_Btn_TianFu_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Image;
     		}
     	}

		public Button E_Btn_TianFu_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Button == null )
     			{
		    		this.m_E_Btn_TianFu_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Button;
     		}
     	}

		public Image E_Btn_TianFu_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Image == null )
     			{
		    		this.m_E_Btn_TianFu_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Image;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_EG_RightRectTransform = null;
			this.m_E_Text_CurrentText = null;
			this.m_E_Lab_HuoLiText = null;
			this.m_E_HuoLiImage = null;
			this.m_EG_MakeINeedNodeRectTransform = null;
			this.m_E_MakeNeedItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_MakeButton = null;
			this.m_E_Btn_MakeImage = null;
			this.m_E_MakeItemIconImage = null;
			this.m_E_Lab_MakeNameText = null;
			this.m_E_Lab_MakeNumText = null;
			this.m_E_Lab_MakeCDTimeText = null;
			this.m_E_Lab_ShuLianShowText = null;
			this.m_EG_LeftRectTransform = null;
			this.m_E_Btn_ResetButton = null;
			this.m_E_Btn_ResetImage = null;
			this.m_E_MakeItemsLoopVerticalScrollRect = null;
			this.m_E_Img_ShuLianProImage = null;
			this.m_E_Lab_ShuLianDuText = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_Btn_MeltButton = null;
			this.m_E_Btn_MeltImage = null;
			this.m_E_Btn_LearnButton = null;
			this.m_E_Btn_LearnImage = null;
			this.m_EG_SelectRectTransform = null;
			this.m_E_Select_1Image = null;
			this.m_E_Select_2Image = null;
			this.m_E_Select_3Image = null;
			this.m_E_Select_6Image = null;
			this.m_EG_MeltRectTransform = null;
			this.m_E_CommonItemLoopVerticalScrollRect = null;
			this.m_es_commonitem_0 = null;
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_es_commonitem_3 = null;
			this.m_es_commonitem_4 = null;
			this.m_es_commonitem_5 = null;
			this.m_E_Btn_MeltBeginButton = null;
			this.m_E_Btn_MeltBeginImage = null;
			this.m_EG_TitleSetRectTransform = null;
			this.m_E_Btn_TianFu_1Button = null;
			this.m_E_Btn_TianFu_1Image = null;
			this.m_E_Btn_TianFu_2Button = null;
			this.m_E_Btn_TianFu_2Image = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_RightRectTransform = null;
		private Text m_E_Text_CurrentText = null;
		private Text m_E_Lab_HuoLiText = null;
		private Image m_E_HuoLiImage = null;
		private RectTransform m_EG_MakeINeedNodeRectTransform = null;
		private LoopVerticalScrollRect m_E_MakeNeedItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_MakeButton = null;
		private Image m_E_Btn_MakeImage = null;
		private Image m_E_MakeItemIconImage = null;
		private Text m_E_Lab_MakeNameText = null;
		private Text m_E_Lab_MakeNumText = null;
		private Text m_E_Lab_MakeCDTimeText = null;
		private Text m_E_Lab_ShuLianShowText = null;
		private RectTransform m_EG_LeftRectTransform = null;
		private Button m_E_Btn_ResetButton = null;
		private Image m_E_Btn_ResetImage = null;
		private LoopVerticalScrollRect m_E_MakeItemsLoopVerticalScrollRect = null;
		private Image m_E_Img_ShuLianProImage = null;
		private Text m_E_Lab_ShuLianDuText = null;
		private Image m_E_ImageSelectImage = null;
		private Button m_E_Btn_MeltButton = null;
		private Image m_E_Btn_MeltImage = null;
		private Button m_E_Btn_LearnButton = null;
		private Image m_E_Btn_LearnImage = null;
		private RectTransform m_EG_SelectRectTransform = null;
		private Image m_E_Select_1Image = null;
		private Image m_E_Select_2Image = null;
		private Image m_E_Select_3Image = null;
		private Image m_E_Select_6Image = null;
		private RectTransform m_EG_MeltRectTransform = null;
		private LoopVerticalScrollRect m_E_CommonItemLoopVerticalScrollRect = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_0 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_3 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_4 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_5 = null;
		private Button m_E_Btn_MeltBeginButton = null;
		private Image m_E_Btn_MeltBeginImage = null;
		private RectTransform m_EG_TitleSetRectTransform = null;
		private Button m_E_Btn_TianFu_1Button = null;
		private Image m_E_Btn_TianFu_1Image = null;
		private Button m_E_Btn_TianFu_2Button = null;
		private Image m_E_Btn_TianFu_2Image = null;
		public Transform uiTransform = null;
	}
}
