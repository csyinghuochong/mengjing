using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_LunTan : Entity,IAwake<Transform>,IDestroy 
	{
		public Button E_ButtonGetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetButton == null )
     			{
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public Image E_ButtonGetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetImage == null )
     			{
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
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
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonGetButton = null;
		private Image m_E_ButtonGetImage = null;
		public Transform uiTransform = null;
	}
}
