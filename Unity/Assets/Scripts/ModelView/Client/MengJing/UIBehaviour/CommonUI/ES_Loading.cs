
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Loading : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUpdate
	{
		public bool Start { get; set; }
		public int Speed { get; set; } = 90;
		public float PassTime { get; set; }

		public UnityEngine.UI.Image E_Img_LoadingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LoadingImage == null )
     			{
		    		this.m_E_Img_LoadingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_Loading");
     			}
     			return this.m_E_Img_LoadingImage;
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
			this.m_E_Img_LoadingImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_Img_LoadingImage = null;
		public Transform uiTransform = null;
	}
}
