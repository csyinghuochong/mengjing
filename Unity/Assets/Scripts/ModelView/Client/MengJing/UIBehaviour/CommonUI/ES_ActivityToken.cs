
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityToken : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Text E_ZanZhuHint_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZanZhuHint_1Text == null )
     			{
		    		this.m_E_ZanZhuHint_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ZanZhuHint_1");
     			}
     			return this.m_E_ZanZhuHint_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_ZanZhuHint_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZanZhuHint_2Text == null )
     			{
		    		this.m_E_ZanZhuHint_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ZanZhuHint_2");
     			}
     			return this.m_E_ZanZhuHint_2Text;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GoPayButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GoPayButton == null )
     			{
		    		this.m_E_Btn_GoPayButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GoPayImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GoPayImage == null )
     			{
		    		this.m_E_Btn_GoPayImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextRechargeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextRechargeText == null )
     			{
		    		this.m_E_TextRechargeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextRecharge");
     			}
     			return this.m_E_TextRechargeText;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect E_ActivityTokenItemsLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivityTokenItemsLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_ActivityTokenItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_ActivityTokenItems");
     			}
     			return this.m_E_ActivityTokenItemsLoopHorizontalScrollRect;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_ZanZhuHint_1Text = null;
			this.m_E_ZanZhuHint_2Text = null;
			this.m_E_Btn_GoPayButton = null;
			this.m_E_Btn_GoPayImage = null;
			this.m_E_TextRechargeText = null;
			this.m_E_ActivityTokenItemsLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_ZanZhuHint_1Text = null;
		private UnityEngine.UI.Text m_E_ZanZhuHint_2Text = null;
		private UnityEngine.UI.Button m_E_Btn_GoPayButton = null;
		private UnityEngine.UI.Image m_E_Btn_GoPayImage = null;
		private UnityEngine.UI.Text m_E_TextRechargeText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_ActivityTokenItemsLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
