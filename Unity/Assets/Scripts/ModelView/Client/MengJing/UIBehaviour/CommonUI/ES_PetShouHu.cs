
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetShouHu : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_PetShouHuItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetShouHuItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetShouHuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetShouHuItems");
     			}
     			return this.m_E_PetShouHuItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_shouhuInfo2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_shouhuInfo2RectTransform == null )
     			{
		    		this.m_EG_shouhuInfo2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_shouhuInfo2");
     			}
     			return this.m_EG_shouhuInfo2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_shouhuInfo3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_shouhuInfo3RectTransform == null )
     			{
		    		this.m_EG_shouhuInfo3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_shouhuInfo3");
     			}
     			return this.m_EG_shouhuInfo3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_shouhuInfo0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_shouhuInfo0RectTransform == null )
     			{
		    		this.m_EG_shouhuInfo0RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_shouhuInfo0");
     			}
     			return this.m_EG_shouhuInfo0RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_shouhuInfo1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_shouhuInfo1RectTransform == null )
     			{
		    		this.m_EG_shouhuInfo1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_shouhuInfo1");
     			}
     			return this.m_EG_shouhuInfo1RectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSetButton == null )
     			{
		    		this.m_E_ButtonSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonSet");
     			}
     			return this.m_E_ButtonSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSetImage == null )
     			{
		    		this.m_E_ButtonSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonSet");
     			}
     			return this.m_E_ButtonSetImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PetShouHuItemsLoopVerticalScrollRect = null;
			this.m_EG_shouhuInfo2RectTransform = null;
			this.m_EG_shouhuInfo3RectTransform = null;
			this.m_EG_shouhuInfo0RectTransform = null;
			this.m_EG_shouhuInfo1RectTransform = null;
			this.m_E_ButtonSetButton = null;
			this.m_E_ButtonSetImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetShouHuItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_shouhuInfo2RectTransform = null;
		private UnityEngine.RectTransform m_EG_shouhuInfo3RectTransform = null;
		private UnityEngine.RectTransform m_EG_shouhuInfo0RectTransform = null;
		private UnityEngine.RectTransform m_EG_shouhuInfo1RectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonSetButton = null;
		private UnityEngine.UI.Image m_E_ButtonSetImage = null;
		public Transform uiTransform = null;
	}
}
