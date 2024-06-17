
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleGemHole : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int Index;
		public Action<int> ClickHandler;
		
		public UnityEngine.UI.Button E_SelectButton
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
		    		this.m_E_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectImage
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
		    		this.m_E_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectImage;
     		}
     	}

		public UnityEngine.UI.Image E_HoleBackImage
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
		    		this.m_E_HoleBackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_HoleBack");
     			}
     			return this.m_E_HoleBackImage;
     		}
     	}

		public UnityEngine.UI.Text E_HoleNameText
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
		    		this.m_E_HoleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_HoleName");
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
     			if( this.m_es_commonitem .Equals(null)  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Image E_HighlightImage
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
		    		this.m_E_HighlightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Highlight");
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

		private UnityEngine.UI.Button m_E_SelectButton = null;
		private UnityEngine.UI.Image m_E_SelectImage = null;
		private UnityEngine.UI.Image m_E_HoleBackImage = null;
		private UnityEngine.UI.Text m_E_HoleNameText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Image m_E_HighlightImage = null;
		public Transform uiTransform = null;
	}
}
