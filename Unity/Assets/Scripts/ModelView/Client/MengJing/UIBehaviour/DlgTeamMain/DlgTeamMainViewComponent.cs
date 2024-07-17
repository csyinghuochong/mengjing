using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamMain))]
	[EnableMethod]
	public  class DlgTeamMainViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_BottomNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BottomNodeRectTransform == null )
     			{
		    		this.m_EG_BottomNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_BottomNode");
     			}
     			return this.m_EG_BottomNodeRectTransform;
     		}
     	}

		public RectTransform EG_TeamDropItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TeamDropItemRectTransform == null )
     			{
		    		this.m_EG_TeamDropItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_BottomNode/EG_TeamDropItem");
     			}
     			return this.m_EG_TeamDropItemRectTransform;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_BottomNode/EG_TeamDropItem/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Button E_Btn_NeedButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_NeedButton == null )
     			{
		    		this.m_E_Btn_NeedButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_BottomNode/EG_TeamDropItem/E_Btn_Need");
     			}
     			return this.m_E_Btn_NeedButton;
     		}
     	}

		public Image E_Btn_NeedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_NeedImage == null )
     			{
		    		this.m_E_Btn_NeedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_BottomNode/EG_TeamDropItem/E_Btn_Need");
     			}
     			return this.m_E_Btn_NeedImage;
     		}
     	}

		public Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_BottomNode/EG_TeamDropItem/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_BottomNode/EG_TeamDropItem/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public Text E_Label_LeftTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_LeftTimeText == null )
     			{
		    		this.m_E_Label_LeftTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_BottomNode/EG_TeamDropItem/E_Label_LeftTime");
     			}
     			return this.m_E_Label_LeftTimeText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_BottomNodeRectTransform = null;
			this.m_EG_TeamDropItemRectTransform = null;
			this.m_es_commonitem = null;
			this.m_E_Btn_NeedButton = null;
			this.m_E_Btn_NeedImage = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_Label_LeftTimeText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_BottomNodeRectTransform = null;
		private RectTransform m_EG_TeamDropItemRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_Btn_NeedButton = null;
		private Image m_E_Btn_NeedImage = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		private Text m_E_Label_LeftTimeText = null;
		public Transform uiTransform = null;
	}
}
