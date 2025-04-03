using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgGemMake))]
	[EnableMethod]
	public  class DlgGemMakeViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_Text_CurrentText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Current");
     			}
     			return this.m_E_Text_CurrentText;
     		}
     	}

		public Text E_TextVitalityText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextVitalityText == null )
     			{
		    		this.m_E_TextVitalityText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_TextVitality");
     			}
     			return this.m_E_TextVitalityText;
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
		    		this.m_EG_MakeINeedNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode");
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/ES_CostList");
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
		    		this.m_E_Btn_MakeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Btn_Make");
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
		    		this.m_E_Btn_MakeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Btn_Make");
     			}
     			return this.m_E_Btn_MakeImage;
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
		    		this.m_E_Lab_MakeNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Lab_MakeName");
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
		    		this.m_E_Lab_MakeNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Lab_MakeNum");
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
		    		this.m_E_Lab_MakeCDTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Lab_MakeCDTime");
     			}
     			return this.m_E_Lab_MakeCDTimeText;
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public RectTransform EG_MakeListNodeRectTransform
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_EG_MakeListNodeRectTransform == null )
				{
					this.m_EG_MakeListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/MakeScrollView/Viewport/EG_MakeListNode");
				}
				return this.m_EG_MakeListNodeRectTransform;
			}
		}

		public void DestroyWidget()
		{
			this.m_E_Text_CurrentText = null;
			this.m_E_TextVitalityText = null;
			this.m_EG_MakeINeedNodeRectTransform = null;
			this.m_es_commonitem = null;
			this.m_es_costlist = null;
			this.m_E_Btn_MakeButton = null;
			this.m_E_Btn_MakeImage = null;
			this.m_E_Lab_MakeNameText = null;
			this.m_E_Lab_MakeNumText = null;
			this.m_E_Lab_MakeCDTimeText = null;
			this.m_E_ImageSelectImage = null;
			this.m_EG_MakeListNodeRectTransform = null;
			this.uiTransform = null;
		}

		private Text m_E_Text_CurrentText = null;
		private Text m_E_TextVitalityText = null;
		private RectTransform m_EG_MakeINeedNodeRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private Button m_E_Btn_MakeButton = null;
		private Image m_E_Btn_MakeImage = null;
		private Text m_E_Lab_MakeNameText = null;
		private Text m_E_Lab_MakeNumText = null;
		private Text m_E_Lab_MakeCDTimeText = null;
		private Image m_E_ImageSelectImage = null;
		private RectTransform m_EG_MakeListNodeRectTransform = null;
		public Transform uiTransform = null;
	}
}
