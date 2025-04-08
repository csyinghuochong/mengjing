using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityToken : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivityTokenItem>> ScrollItemActivityTokenItems;
		
		public Text E_ZanZhuHint_1Text
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
		    		this.m_E_ZanZhuHint_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ZanZhuHint_1");
     			}
     			return this.m_E_ZanZhuHint_1Text;
     		}
     	}

		public Text E_ZanZhuHint_2Text
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
		    		this.m_E_ZanZhuHint_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ZanZhuHint_2");
     			}
     			return this.m_E_ZanZhuHint_2Text;
     		}
     	}

		public Button E_Btn_GoPayButton
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
		    		this.m_E_Btn_GoPayButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayButton;
     		}
     	}

		public Image E_Btn_GoPayImage
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
		    		this.m_E_Btn_GoPayImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayImage;
     		}
     	}

		public Text E_TextRechargeText
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
		    		this.m_E_TextRechargeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextRecharge");
     			}
     			return this.m_E_TextRechargeText;
     		}
     	}
	
		public Transform E_Image98
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Image98 == null )
				{
					this.m_E_Image98 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_Image98");
				}
				return this.m_E_Image98;
			}
		}
		
		public Transform E_Image298
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Image298 == null )
				{
					this.m_E_Image298 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_Image298");
				}
				return this.m_E_Image298;
			}
		}

		public LoopHorizontalScrollRect E_ActivityTokenItemsLoopHorizontalScrollRect
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
		    		this.m_E_ActivityTokenItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_ActivityTokenItems");
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
			this.m_E_Image98 = null;
			this.m_E_Image298 = null;
			this.m_E_ActivityTokenItemsLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private Text m_E_ZanZhuHint_1Text = null;
		private Text m_E_ZanZhuHint_2Text = null;
		private Button m_E_Btn_GoPayButton = null;
		private Image m_E_Btn_GoPayImage = null;
		private Text m_E_TextRechargeText = null;
		private Transform m_E_Image98 = null;
		private Transform m_E_Image298 = null;
		private LoopHorizontalScrollRect m_E_ActivityTokenItemsLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
