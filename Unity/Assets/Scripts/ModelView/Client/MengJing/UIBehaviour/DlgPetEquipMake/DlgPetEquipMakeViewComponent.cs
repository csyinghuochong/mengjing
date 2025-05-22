
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetEquipMake))]
	[EnableMethod]
	public  class DlgPetEquipMakeViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_Text_CurrentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Current");
     			}
     			return this.m_E_Text_CurrentText;
     		}
     	}

		public UnityEngine.UI.Text E_TextVitalityText
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
		    		this.m_E_TextVitalityText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextVitality");
     			}
     			return this.m_E_TextVitalityText;
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
		    		this.m_EG_MakeINeedNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode");
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
     			if( es == null )

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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
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
		    		this.m_E_Btn_MakeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Btn_Make");
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
		    		this.m_E_Btn_MakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Btn_Make");
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
		    		this.m_E_Lab_MakeNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Lab_MakeName");
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
		    		this.m_E_Lab_MakeNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Lab_MakeNum");
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
		    		this.m_E_Lab_MakeCDTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_MakeINeedNode/E_Lab_MakeCDTime");
     			}
     			return this.m_E_Lab_MakeCDTimeText;
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
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public UnityEngine.RectTransform EG_MakeListNodeRectTransform
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
		    		this.m_EG_MakeListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/MakeScrollView/Viewport/EG_MakeListNode");
     			}
     			return this.m_EG_MakeListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
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
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_Text_CurrentText = null;
		private UnityEngine.UI.Text m_E_TextVitalityText = null;
		private UnityEngine.RectTransform m_EG_MakeINeedNodeRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private UnityEngine.UI.Button m_E_Btn_MakeButton = null;
		private UnityEngine.UI.Image m_E_Btn_MakeImage = null;
		private UnityEngine.UI.Text m_E_Lab_MakeNameText = null;
		private UnityEngine.UI.Text m_E_Lab_MakeNumText = null;
		private UnityEngine.UI.Text m_E_Lab_MakeCDTimeText = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.RectTransform m_EG_MakeListNodeRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
