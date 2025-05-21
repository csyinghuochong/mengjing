
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgItemFumoSelect))]
	[EnableMethod]
	public  class DlgItemFumoSelectViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_BtnCloseButton
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
		    		this.m_E_BtnCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_BtnClose");
     			}
     			return this.m_E_BtnCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_BtnCloseImage
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
		    		this.m_E_BtnCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_BtnClose");
     			}
     			return this.m_E_BtnCloseImage;
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem_0");
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem_1");
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemFumo_0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_ItemFumo_0Text == null )
     			{
		    		this.m_E_Label_ItemFumo_0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Label_ItemFumo_0");
     			}
     			return this.m_E_Label_ItemFumo_0Text;
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemFumo_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_ItemFumo_1Text == null )
     			{
		    		this.m_E_Label_ItemFumo_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Label_ItemFumo_1");
     			}
     			return this.m_E_Label_ItemFumo_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemFumo_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_ItemFumo_2Text == null )
     			{
		    		this.m_E_Label_ItemFumo_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Label_ItemFumo_2");
     			}
     			return this.m_E_Label_ItemFumo_2Text;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BtnCloseButton = null;
			this.m_E_BtnCloseImage = null;
			this.m_es_commonitem_0 = null;
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_E_Label_ItemFumo_0Text = null;
			this.m_E_Label_ItemFumo_1Text = null;
			this.m_E_Label_ItemFumo_2Text = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_BtnCloseButton = null;
		private UnityEngine.UI.Image m_E_BtnCloseImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_0 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private UnityEngine.UI.Text m_E_Label_ItemFumo_0Text = null;
		private UnityEngine.UI.Text m_E_Label_ItemFumo_1Text = null;
		private UnityEngine.UI.Text m_E_Label_ItemFumo_2Text = null;
		public Transform uiTransform = null;
	}
}
