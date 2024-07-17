using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainActivityTip : Entity,IAwake<Transform>,IDestroy
	{
		public List<ActivityTipConfig> ActivityShowList = new();
		public ActivityTipConfig ActivtyCur;   
		public int Index = 0;  //0 开始时间  1结束时间
		public long Timer;
		
		public Text E_TextNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNameText == null )
     			{
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     			return this.m_E_TextNameText;
     		}
     	}

		public Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
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
			this.m_E_TextNameText = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.uiTransform = null;
		}

		private Text m_E_TextNameText = null;
		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		public Transform uiTransform = null;
	}
}
