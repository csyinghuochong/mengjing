
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanBag))]
	[EnableMethod]
	public  class DlgJiaYuanBagViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_PlanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PlanButton == null )
     			{
		    		this.m_E_Btn_PlanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Plan");
     			}
     			return this.m_E_Btn_PlanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_PlanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PlanImage == null )
     			{
		    		this.m_E_Btn_PlanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Plan");
     			}
     			return this.m_E_Btn_PlanImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_PlanButton = null;
			this.m_E_Btn_PlanImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_PlanButton = null;
		private UnityEngine.UI.Image m_E_Btn_PlanImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
