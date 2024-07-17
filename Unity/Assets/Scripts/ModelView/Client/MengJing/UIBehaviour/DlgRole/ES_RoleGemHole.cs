using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleGemHole : Entity,IAwake<Transform>,IDestroy 
	{
		public int Index;
		public Action<int> ClickHandler;
		
		public Button E_SelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectButton == null )
     			{
		    		this.m_E_SelectButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectButton;
     		}
     	}

		public Image E_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectImage == null )
     			{
		    		this.m_E_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectImage;
     		}
     	}

		public Image E_HoleBackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HoleBackImage == null )
     			{
		    		this.m_E_HoleBackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HoleBack");
     			}
     			return this.m_E_HoleBackImage;
     		}
     	}

		public Text E_HoleNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HoleNameText == null )
     			{
		    		this.m_E_HoleNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_HoleName");
     			}
     			return this.m_E_HoleNameText;
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
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Image E_HighlightImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HighlightImage == null )
     			{
		    		this.m_E_HighlightImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Highlight");
     			}
     			return this.m_E_HighlightImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SelectButton = null;
			this.m_E_SelectImage = null;
			this.m_E_HoleBackImage = null;
			this.m_E_HoleNameText = null;
			this.m_es_commonitem = null;
			this.m_E_HighlightImage = null;
			this.uiTransform = null;
		}

		private Button m_E_SelectButton = null;
		private Image m_E_SelectImage = null;
		private Image m_E_HoleBackImage = null;
		private Text m_E_HoleNameText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Image m_E_HighlightImage = null;
		public Transform uiTransform = null;
	}
}
