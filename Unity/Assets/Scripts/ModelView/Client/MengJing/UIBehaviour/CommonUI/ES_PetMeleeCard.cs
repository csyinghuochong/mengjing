
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMeleeCard : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Text E_CostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostText == null )
     			{
		    		this.m_E_CostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Cost");
     			}
     			return this.m_E_CostText;
     		}
     	}

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     			return this.m_E_IconImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_IconEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconEventTrigger == null )
     			{
		    		this.m_E_IconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Icon");
     			}
     			return this.m_E_IconEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_DesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DesText == null )
     			{
		    		this.m_E_DesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Des");
     			}
     			return this.m_E_DesText;
     		}
     	}

		public UnityEngine.UI.Image E_TouchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchImage == null )
     			{
		    		this.m_E_TouchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_TouchEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchEventTrigger == null )
     			{
		    		this.m_E_TouchEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchEventTrigger;
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
			this.m_E_CostText = null;
			this.m_E_IconImage = null;
			this.m_E_IconEventTrigger = null;
			this.m_E_DesText = null;
			this.m_E_TouchImage = null;
			this.m_E_TouchEventTrigger = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_CostText = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_IconEventTrigger = null;
		private UnityEngine.UI.Text m_E_DesText = null;
		private UnityEngine.UI.Image m_E_TouchImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TouchEventTrigger = null;
		public Transform uiTransform = null;
	}
}
