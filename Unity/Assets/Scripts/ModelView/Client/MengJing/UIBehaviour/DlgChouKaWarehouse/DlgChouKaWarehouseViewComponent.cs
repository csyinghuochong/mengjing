
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgChouKaWarehouse))]
	[EnableMethod]
	public  class DlgChouKaWarehouseViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_BagItems2LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItems2LoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItems2LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems2");
     			}
     			return this.m_E_BagItems2LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItems1LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItems1LoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItems1LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_BagItems1");
     			}
     			return this.m_E_BagItems1LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonTakeOutAllButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTakeOutAllButton == null )
     			{
		    		this.m_E_ButtonTakeOutAllButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonTakeOutAll");
     			}
     			return this.m_E_ButtonTakeOutAllButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonTakeOutAllImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTakeOutAllImage == null )
     			{
		    		this.m_E_ButtonTakeOutAllImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonTakeOutAll");
     			}
     			return this.m_E_ButtonTakeOutAllImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSellButton == null )
     			{
		    		this.m_E_ButtonSellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonSell");
     			}
     			return this.m_E_ButtonSellButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSellImage == null )
     			{
		    		this.m_E_ButtonSellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonSell");
     			}
     			return this.m_E_ButtonSellImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonZhengLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonZhengLiButton == null )
     			{
		    		this.m_E_ButtonZhengLiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonZhengLi");
     			}
     			return this.m_E_ButtonZhengLiButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonZhengLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonZhengLiImage == null )
     			{
		    		this.m_E_ButtonZhengLiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonZhengLi");
     			}
     			return this.m_E_ButtonZhengLiImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BagItems2LoopVerticalScrollRect = null;
			this.m_E_BagItems1LoopVerticalScrollRect = null;
			this.m_E_ButtonTakeOutAllButton = null;
			this.m_E_ButtonTakeOutAllImage = null;
			this.m_E_ButtonSellButton = null;
			this.m_E_ButtonSellImage = null;
			this.m_E_ButtonZhengLiButton = null;
			this.m_E_ButtonZhengLiImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItems2LoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItems1LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonTakeOutAllButton = null;
		private UnityEngine.UI.Image m_E_ButtonTakeOutAllImage = null;
		private UnityEngine.UI.Button m_E_ButtonSellButton = null;
		private UnityEngine.UI.Image m_E_ButtonSellImage = null;
		private UnityEngine.UI.Button m_E_ButtonZhengLiButton = null;
		private UnityEngine.UI.Image m_E_ButtonZhengLiImage = null;
		public Transform uiTransform = null;
	}
}
