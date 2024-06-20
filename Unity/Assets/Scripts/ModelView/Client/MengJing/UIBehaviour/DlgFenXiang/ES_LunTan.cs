
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_LunTan : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonGetButton
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetImage
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonGet");
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

		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		public Transform uiTransform = null;
	}
}
