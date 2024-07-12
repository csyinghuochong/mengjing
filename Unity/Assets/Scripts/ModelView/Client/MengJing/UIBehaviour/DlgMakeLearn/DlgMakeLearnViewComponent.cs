
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMakeLearn))]
	[EnableMethod]
	public  class DlgMakeLearnViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.UI.LoopVerticalScrollRect E_MakeLearnItemsLoopVerticalScrollRect
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
		    		this.m_E_MakeLearnItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left/E_MakeLearnItems");
     			}
     			return this.m_E_MakeLearnItemsLoopVerticalScrollRect;
     		}
     	}

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

		public UnityEngine.UI.Button E_ButtonLearnButton
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
		    		this.m_E_ButtonLearnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/E_ButtonLearn");
     			}
     			return this.m_E_ButtonLearnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonLearnImage
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
		    		this.m_E_ButtonLearnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ButtonLearn");
     			}
     			return this.m_E_ButtonLearnImage;
     		}
     	}

		public UnityEngine.UI.Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_LearnItemCostText
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
		    		this.m_E_Lab_LearnItemCostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Lab_LearnItemCost");
     			}
     			return this.m_E_Lab_LearnItemCostText;
     		}
     	}

		public UnityEngine.UI.Text E_LabNeedShuLianText
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
		    		this.m_E_LabNeedShuLianText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_LabNeedShuLian");
     			}
     			return this.m_E_LabNeedShuLianText;
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

		public UnityEngine.UI.Image E_Select_1Image
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
		    		this.m_E_Select_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_1");
     			}
     			return this.m_E_Select_1Image;
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
		    		this.m_E_Button_Select_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/E_Select_1/E_Button_Select_1");
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
		    		this.m_E_Button_Select_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_1/E_Button_Select_1");
     			}
     			return this.m_E_Button_Select_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_Select_2Image
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
		    		this.m_E_Select_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_2");
     			}
     			return this.m_E_Select_2Image;
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
		    		this.m_E_Button_Select_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/E_Select_2/E_Button_Select_2");
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
		    		this.m_E_Button_Select_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_2/E_Button_Select_2");
     			}
     			return this.m_E_Button_Select_2Image;
     		}
     	}

		public UnityEngine.UI.Image E_Select_3Image
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
		    		this.m_E_Select_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_3");
     			}
     			return this.m_E_Select_3Image;
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
		    		this.m_E_Button_Select_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/E_Select_3/E_Button_Select_3");
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
		    		this.m_E_Button_Select_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_3/E_Button_Select_3");
     			}
     			return this.m_E_Button_Select_3Image;
     		}
     	}

		public UnityEngine.UI.Image E_Select_6Image
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
		    		this.m_E_Select_6Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_6");
     			}
     			return this.m_E_Select_6Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Select_6Button
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
		    		this.m_E_Button_Select_6Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Select/E_Select_6/E_Button_Select_6");
     			}
     			return this.m_E_Button_Select_6Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Select_6Image
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
		    		this.m_E_Button_Select_6Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Select/E_Select_6/E_Button_Select_6");
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

		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_ShuLianProImage = null;
		private UnityEngine.UI.Text m_E_Lab_ShuLianDuText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_MakeLearnItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Button m_E_ButtonLearnButton = null;
		private UnityEngine.UI.Image m_E_ButtonLearnImage = null;
		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Text m_E_Lab_LearnItemCostText = null;
		private UnityEngine.UI.Text m_E_LabNeedShuLianText = null;
		private UnityEngine.RectTransform m_EG_SelectRectTransform = null;
		private UnityEngine.UI.Image m_E_Select_1Image = null;
		private UnityEngine.UI.Button m_E_Button_Select_1Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_1Image = null;
		private UnityEngine.UI.Image m_E_Select_2Image = null;
		private UnityEngine.UI.Button m_E_Button_Select_2Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_2Image = null;
		private UnityEngine.UI.Image m_E_Select_3Image = null;
		private UnityEngine.UI.Button m_E_Button_Select_3Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_3Image = null;
		private UnityEngine.UI.Image m_E_Select_6Image = null;
		private UnityEngine.UI.Button m_E_Button_Select_6Button = null;
		private UnityEngine.UI.Image m_E_Button_Select_6Image = null;
		public Transform uiTransform = null;
	}
}
