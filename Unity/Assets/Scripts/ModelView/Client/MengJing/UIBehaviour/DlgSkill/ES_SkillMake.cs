
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillMake : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int MakeId;
		public long Timer;
		public int Plan = -1;

		public List<(int, int)> ShowMakeNeed = new();
		public Dictionary<int, EntityRef<Scroll_Item_MakeNeedItem>> ScrollItemMakeNeedItems;
		public List<int> ShowMake = new();
		public Dictionary<int, EntityRef<Scroll_Item_MakeItem>> ScrollItemMakeItems;
		
		public BagInfo[] HuiShouInfos = new BagInfo[5];
		public EntityRef<ES_CommonItem>[] HuiShouUIList = new EntityRef<ES_CommonItem>[5];
		public List<BagInfo> ShowBagInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public bool IsHoldDown = false;
		public int PlanMelt = 1;
		
		public UnityEngine.RectTransform EG_RightRectTransform
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
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CurrentText
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
		    		this.m_E_Text_CurrentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_Current");
     			}
     			return this.m_E_Text_CurrentText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_HuoLiText
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
		    		this.m_E_Lab_HuoLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Lab_HuoLi");
     			}
     			return this.m_E_Lab_HuoLiText;
     		}
     	}

		public UnityEngine.RectTransform EG_MakeINeedNodeRectTransform
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
		    		this.m_EG_MakeINeedNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode");
     			}
     			return this.m_EG_MakeINeedNodeRectTransform;
     		}
     	}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem;
     			if( es == null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MakeNeedItemsLoopVerticalScrollRect
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
		    		this.m_E_MakeNeedItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_MakeNeedItems");
     			}
     			return this.m_E_MakeNeedItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_MakeButton
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
		    		this.m_E_Btn_MakeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Btn_Make");
     			}
     			return this.m_E_Btn_MakeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_MakeImage
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
		    		this.m_E_Btn_MakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Btn_Make");
     			}
     			return this.m_E_Btn_MakeImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_MakeNameText
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
		    		this.m_E_Lab_MakeNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_MakeName");
     			}
     			return this.m_E_Lab_MakeNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_MakeNumText
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
		    		this.m_E_Lab_MakeNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_MakeNum");
     			}
     			return this.m_E_Lab_MakeNumText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_MakeCDTimeText
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
		    		this.m_E_Lab_MakeCDTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_MakeCDTime");
     			}
     			return this.m_E_Lab_MakeCDTimeText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ShuLianShowText
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
		    		this.m_E_Lab_ShuLianShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_MakeINeedNode/E_Lab_ShuLianShow");
     			}
     			return this.m_E_Lab_ShuLianShowText;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftRectTransform
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
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ResetButton
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
		    		this.m_E_Btn_ResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/E_Btn_Reset");
     			}
     			return this.m_E_Btn_ResetButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ResetImage
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
		    		this.m_E_Btn_ResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/E_Btn_Reset");
     			}
     			return this.m_E_Btn_ResetImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_MakeItemsLoopVerticalScrollRect
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
		    		this.m_E_MakeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left/E_MakeItems");
     			}
     			return this.m_E_MakeItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ShuLianProImage
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
		    		this.m_E_Img_ShuLianProImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/Img_ProSet/E_Img_ShuLianPro");
     			}
     			return this.m_E_Img_ShuLianProImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ShuLianDuText
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
		    		this.m_E_Lab_ShuLianDuText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/Img_ProSet/E_Lab_ShuLianDu");
     			}
     			return this.m_E_Lab_ShuLianDuText;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelectImage
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_MeltButton
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
		    		this.m_E_Btn_MeltButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/E_Btn_Melt");
     			}
     			return this.m_E_Btn_MeltButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_MeltImage
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
		    		this.m_E_Btn_MeltImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/E_Btn_Melt");
     			}
     			return this.m_E_Btn_MeltImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_LearnButton
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
		    		this.m_E_Btn_LearnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/E_Btn_Learn");
     			}
     			return this.m_E_Btn_LearnButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_LearnImage
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
		    		this.m_E_Btn_LearnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/E_Btn_Learn");
     			}
     			return this.m_E_Btn_LearnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectRectTransform
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
		    		this.m_EG_SelectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Select");
     			}
     			return this.m_EG_SelectRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Select_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_1Button == null )
     			{
		    		this.m_E_Button_Select_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/Select_1/E_Button_Select_1");
     			}
     			return this.m_E_Button_Select_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Select_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_1Image == null )
     			{
		    		this.m_E_Button_Select_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/Select_1/E_Button_Select_1");
     			}
     			return this.m_E_Button_Select_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Select_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_2Button == null )
     			{
		    		this.m_E_Button_Select_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/Select_2/E_Button_Select_2");
     			}
     			return this.m_E_Button_Select_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Select_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_2Image == null )
     			{
		    		this.m_E_Button_Select_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/Select_2/E_Button_Select_2");
     			}
     			return this.m_E_Button_Select_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Select_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_3Button == null )
     			{
		    		this.m_E_Button_Select_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/Select_3/E_Button_Select_3");
     			}
     			return this.m_E_Button_Select_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Select_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_3Image == null )
     			{
		    		this.m_E_Button_Select_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/Select_3/E_Button_Select_3");
     			}
     			return this.m_E_Button_Select_3Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Select_4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_4Button == null )
     			{
		    		this.m_E_Button_Select_4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/Select_4/E_Button_Select_4");
     			}
     			return this.m_E_Button_Select_4Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Select_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_4Image == null )
     			{
		    		this.m_E_Button_Select_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/Select_4/E_Button_Select_4");
     			}
     			return this.m_E_Button_Select_4Image;
     		}
     	}

		public UnityEngine.RectTransform EG_MeltRectTransform
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
		    		this.m_EG_MeltRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Melt");
     			}
     			return this.m_EG_MeltRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonItemLoopVerticalScrollRect
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
		    		this.m_E_CommonItemLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Melt/E_CommonItem");
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

		public UnityEngine.UI.Button E_Btn_MeltBeginButton
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
		    		this.m_E_Btn_MeltBeginButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Melt/E_Btn_MeltBegin");
     			}
     			return this.m_E_Btn_MeltBeginButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_MeltBeginImage
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
		    		this.m_E_Btn_MeltBeginImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Melt/E_Btn_MeltBegin");
     			}
     			return this.m_E_Btn_MeltBeginImage;
     		}
     	}

		public UnityEngine.RectTransform EG_TitleSetRectTransform
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
		    		this.m_EG_TitleSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_TitleSet");
     			}
     			return this.m_EG_TitleSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_TianFu_1Button
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
		    		this.m_E_Btn_TianFu_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_TianFu_1Image
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
		    		this.m_E_Btn_TianFu_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_TianFu_2Button
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
		    		this.m_E_Btn_TianFu_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_TianFu_2Image
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
		    		this.m_E_Btn_TianFu_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_TitleSet/E_Btn_TianFu_2");
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
			this.m_EG_MakeINeedNodeRectTransform = null;
			this.m_es_commonitem = null;
			this.m_E_MakeNeedItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_MakeButton = null;
			this.m_E_Btn_MakeImage = null;
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
			this.m_E_Button_Select_1Button = null;
			this.m_E_Button_Select_1Image = null;
			this.m_E_Button_Select_2Button = null;
			this.m_E_Button_Select_2Image = null;
			this.m_E_Button_Select_3Button = null;
			this.m_E_Button_Select_3Image = null;
			this.m_E_Button_Select_4Button = null;
			this.m_E_Button_Select_4Image = null;
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

		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_CurrentText = null;
		private UnityEngine.UI.Text m_E_Lab_HuoLiText = null;
		private UnityEngine.RectTransform m_EG_MakeINeedNodeRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MakeNeedItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_MakeButton = null;
		private UnityEngine.UI.Image m_E_Btn_MakeImage = null;
		private UnityEngine.UI.Text m_E_Lab_MakeNameText = null;
		private UnityEngine.UI.Text m_E_Lab_MakeNumText = null;
		private UnityEngine.UI.Text m_E_Lab_MakeCDTimeText = null;
		private UnityEngine.UI.Text m_E_Lab_ShuLianShowText = null;
		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_ResetButton = null;
		private UnityEngine.UI.Image m_E_Btn_ResetImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MakeItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_Img_ShuLianProImage = null;
		private UnityEngine.UI.Text m_E_Lab_ShuLianDuText = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Button m_E_Btn_MeltButton = null;
		private UnityEngine.UI.Image m_E_Btn_MeltImage = null;
		private UnityEngine.UI.Button m_E_Btn_LearnButton = null;
		private UnityEngine.UI.Image m_E_Btn_LearnImage = null;
		private UnityEngine.RectTransform m_EG_SelectRectTransform = null;
		private UnityEngine.UI.Button m_E_Button_Select_1Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_1Image = null;
		private UnityEngine.UI.Button m_E_Button_Select_2Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_2Image = null;
		private UnityEngine.UI.Button m_E_Button_Select_3Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_3Image = null;
		private UnityEngine.UI.Button m_E_Button_Select_4Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_4Image = null;
		private UnityEngine.RectTransform m_EG_MeltRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonItemLoopVerticalScrollRect = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_0 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_3 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_4 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_5 = null;
		private UnityEngine.UI.Button m_E_Btn_MeltBeginButton = null;
		private UnityEngine.UI.Image m_E_Btn_MeltBeginImage = null;
		private UnityEngine.RectTransform m_EG_TitleSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_TianFu_1Button = null;
		private UnityEngine.UI.Image m_E_Btn_TianFu_1Image = null;
		private UnityEngine.UI.Button m_E_Btn_TianFu_2Button = null;
		private UnityEngine.UI.Image m_E_Btn_TianFu_2Image = null;
		public Transform uiTransform = null;
	}
}
