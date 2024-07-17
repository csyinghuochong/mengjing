using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMakeLearn))]
	[EnableMethod]
	public  class DlgMakeLearnViewComponent : Entity,IAwake,IDestroy 
	{
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

		public LoopVerticalScrollRect E_MakeLearnItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MakeLearnItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_MakeLearnItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left/E_MakeLearnItems");
     			}
     			return this.m_E_MakeLearnItemsLoopVerticalScrollRect;
     		}
     	}

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

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Right/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Button E_ButtonLearnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLearnButton == null )
     			{
		    		this.m_E_ButtonLearnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_ButtonLearn");
     			}
     			return this.m_E_ButtonLearnButton;
     		}
     	}

		public Image E_ButtonLearnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLearnImage == null )
     			{
		    		this.m_E_ButtonLearnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_ButtonLearn");
     			}
     			return this.m_E_ButtonLearnImage;
     		}
     	}

		public Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public Text E_Lab_LearnItemCostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_LearnItemCostText == null )
     			{
		    		this.m_E_Lab_LearnItemCostText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Lab_LearnItemCost");
     			}
     			return this.m_E_Lab_LearnItemCostText;
     		}
     	}

		public Text E_LabNeedShuLianText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LabNeedShuLianText == null )
     			{
		    		this.m_E_LabNeedShuLianText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_LabNeedShuLian");
     			}
     			return this.m_E_LabNeedShuLianText;
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

		public Button E_Button_Select_1Button
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
		    		this.m_E_Button_Select_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Select/E_Select_1/E_Button_Select_1");
     			}
     			return this.m_E_Button_Select_1Button;
     		}
     	}

		public Image E_Button_Select_1Image
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
		    		this.m_E_Button_Select_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_1/E_Button_Select_1");
     			}
     			return this.m_E_Button_Select_1Image;
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

		public Button E_Button_Select_2Button
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
		    		this.m_E_Button_Select_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Select/E_Select_2/E_Button_Select_2");
     			}
     			return this.m_E_Button_Select_2Button;
     		}
     	}

		public Image E_Button_Select_2Image
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
		    		this.m_E_Button_Select_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_2/E_Button_Select_2");
     			}
     			return this.m_E_Button_Select_2Image;
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

		public Button E_Button_Select_3Button
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
		    		this.m_E_Button_Select_3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Select/E_Select_3/E_Button_Select_3");
     			}
     			return this.m_E_Button_Select_3Button;
     		}
     	}

		public Image E_Button_Select_3Image
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
		    		this.m_E_Button_Select_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_3/E_Button_Select_3");
     			}
     			return this.m_E_Button_Select_3Image;
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

		public Button E_Button_Select_6Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_6Button == null )
     			{
		    		this.m_E_Button_Select_6Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Select/E_Select_6/E_Button_Select_6");
     			}
     			return this.m_E_Button_Select_6Button;
     		}
     	}

		public Image E_Button_Select_6Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Select_6Image == null )
     			{
		    		this.m_E_Button_Select_6Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Select/E_Select_6/E_Button_Select_6");
     			}
     			return this.m_E_Button_Select_6Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_LeftRectTransform = null;
			this.m_E_Img_ShuLianProImage = null;
			this.m_E_Lab_ShuLianDuText = null;
			this.m_E_MakeLearnItemsLoopVerticalScrollRect = null;
			this.m_EG_RightRectTransform = null;
			this.m_es_rewardlist = null;
			this.m_es_commonitem = null;
			this.m_E_ButtonLearnButton = null;
			this.m_E_ButtonLearnImage = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Lab_LearnItemCostText = null;
			this.m_E_LabNeedShuLianText = null;
			this.m_EG_SelectRectTransform = null;
			this.m_E_Select_1Image = null;
			this.m_E_Button_Select_1Button = null;
			this.m_E_Button_Select_1Image = null;
			this.m_E_Select_2Image = null;
			this.m_E_Button_Select_2Button = null;
			this.m_E_Button_Select_2Image = null;
			this.m_E_Select_3Image = null;
			this.m_E_Button_Select_3Button = null;
			this.m_E_Button_Select_3Image = null;
			this.m_E_Select_6Image = null;
			this.m_E_Button_Select_6Button = null;
			this.m_E_Button_Select_6Image = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_LeftRectTransform = null;
		private Image m_E_Img_ShuLianProImage = null;
		private Text m_E_Lab_ShuLianDuText = null;
		private LoopVerticalScrollRect m_E_MakeLearnItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_RightRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_ButtonLearnButton = null;
		private Image m_E_ButtonLearnImage = null;
		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Text m_E_Lab_LearnItemCostText = null;
		private Text m_E_LabNeedShuLianText = null;
		private RectTransform m_EG_SelectRectTransform = null;
		private Image m_E_Select_1Image = null;
		private Button m_E_Button_Select_1Button = null;
		private Image m_E_Button_Select_1Image = null;
		private Image m_E_Select_2Image = null;
		private Button m_E_Button_Select_2Button = null;
		private Image m_E_Button_Select_2Image = null;
		private Image m_E_Select_3Image = null;
		private Button m_E_Button_Select_3Button = null;
		private Image m_E_Button_Select_3Image = null;
		private Image m_E_Select_6Image = null;
		private Button m_E_Button_Select_6Button = null;
		private Image m_E_Button_Select_6Image = null;
		public Transform uiTransform = null;
	}
}
