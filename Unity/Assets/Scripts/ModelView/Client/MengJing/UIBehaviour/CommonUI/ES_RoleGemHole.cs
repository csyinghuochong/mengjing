
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleGemHole : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
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
     			if( this.m_es_commonitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Image E_BackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BackImage == null )
     			{
		    		this.m_E_BackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back");
     			}
     			return this.m_E_BackImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SelectButton = null;
			this.m_E_SelectImage = null;
			this.m_E_HoleNameText = null;
			this.m_es_commonitem = null;
			this.m_E_BackImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_SelectButton = null;
		private UnityEngine.UI.Image m_E_SelectImage = null;
		private UnityEngine.UI.Text m_E_HoleNameText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Image m_E_BackImage = null;
		public Transform uiTransform = null;
	}
}
