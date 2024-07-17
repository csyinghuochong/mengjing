using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanPlanWatch))]
	[EnableMethod]
	public  class DlgJiaYuanPlanWatchViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Button E_BtnCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCloseButton == null )
     			{
		    		this.m_E_BtnCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_BtnClose");
     			}
     			return this.m_E_BtnCloseButton;
     		}
     	}

		public Image E_BtnCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCloseImage == null )
     			{
		    		this.m_E_BtnCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BtnClose");
     			}
     			return this.m_E_BtnCloseImage;
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

		public Text E_TextNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNameText == null )
     			{
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     			return this.m_E_TextNameText;
     		}
     	}

		public Text E_TextStageText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextStageText == null )
     			{
		    		this.m_E_TextStageText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextStage");
     			}
     			return this.m_E_TextStageText;
     		}
     	}

		public Text E_Text_Desc_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Desc_1Text == null )
     			{
		    		this.m_E_Text_Desc_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Desc_1");
     			}
     			return this.m_E_Text_Desc_1Text;
     		}
     	}

		public Text E_Text_Desc_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Desc_2Text == null )
     			{
		    		this.m_E_Text_Desc_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Desc_2");
     			}
     			return this.m_E_Text_Desc_2Text;
     		}
     	}

		public Text E_Text_Desc_3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Desc_3Text == null )
     			{
		    		this.m_E_Text_Desc_3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Desc_3");
     			}
     			return this.m_E_Text_Desc_3Text;
     		}
     	}

		public Text E_Text_RecordText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RecordText == null )
     			{
		    		this.m_E_Text_RecordText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Record");
     			}
     			return this.m_E_Text_RecordText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_E_BtnCloseButton = null;
			this.m_E_BtnCloseImage = null;
			this.m_es_commonitem = null;
			this.m_E_TextNameText = null;
			this.m_E_TextStageText = null;
			this.m_E_Text_Desc_1Text = null;
			this.m_E_Text_Desc_2Text = null;
			this.m_E_Text_Desc_3Text = null;
			this.m_E_Text_RecordText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Button m_E_BtnCloseButton = null;
		private Image m_E_BtnCloseImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Text m_E_TextNameText = null;
		private Text m_E_TextStageText = null;
		private Text m_E_Text_Desc_1Text = null;
		private Text m_E_Text_Desc_2Text = null;
		private Text m_E_Text_Desc_3Text = null;
		private Text m_E_Text_RecordText = null;
		public Transform uiTransform = null;
	}
}
