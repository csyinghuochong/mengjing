using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTuZhiMake))]
	[EnableMethod]
	public  class DlgTuZhiMakeViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Btn_CloseUIButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseUIButton == null )
     			{
		    		this.m_E_Btn_CloseUIButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_CloseUI");
     			}
     			return this.m_E_Btn_CloseUIButton;
     		}
     	}

		public Image E_Btn_CloseUIImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseUIImage == null )
     			{
		    		this.m_E_Btn_CloseUIImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_CloseUI");
     			}
     			return this.m_E_Btn_CloseUIImage;
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
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
		    		this.m_EG_MakeINeedNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_MakeINeedNode");
     			}
     			return this.m_EG_MakeINeedNodeRectTransform;
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
		    		this.m_E_Lab_MakeNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MakeINeedNode/E_Lab_MakeName");
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
		    		this.m_E_Lab_MakeNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_MakeINeedNode/E_Lab_MakeNum");
     			}
     			return this.m_E_Lab_MakeNumText;
     		}
     	}

		public ES_CostList ES_CostList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostList es = this.m_es_costlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_MakeINeedNode/ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
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
		    		this.m_E_Btn_MakeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_MakeINeedNode/E_Btn_Make");
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
		    		this.m_E_Btn_MakeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_MakeINeedNode/E_Btn_Make");
     			}
     			return this.m_E_Btn_MakeImage;
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
		    		this.m_E_Text_CurrentText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Current");
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
		    		this.m_E_Lab_HuoLiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_HuoLi");
     			}
     			return this.m_E_Lab_HuoLiText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_CloseUIButton = null;
			this.m_E_Btn_CloseUIImage = null;
			this.m_es_commonitem = null;
			this.m_EG_MakeINeedNodeRectTransform = null;
			this.m_E_Lab_MakeNameText = null;
			this.m_E_Lab_MakeNumText = null;
			this.m_es_costlist = null;
			this.m_E_Btn_MakeButton = null;
			this.m_E_Btn_MakeImage = null;
			this.m_E_Text_CurrentText = null;
			this.m_E_Lab_HuoLiText = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseUIButton = null;
		private Image m_E_Btn_CloseUIImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private RectTransform m_EG_MakeINeedNodeRectTransform = null;
		private Text m_E_Lab_MakeNameText = null;
		private Text m_E_Lab_MakeNumText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private Button m_E_Btn_MakeButton = null;
		private Image m_E_Btn_MakeImage = null;
		private Text m_E_Text_CurrentText = null;
		private Text m_E_Lab_HuoLiText = null;
		public Transform uiTransform = null;
	}
}
