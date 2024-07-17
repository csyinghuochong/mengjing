using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_OpenBox : Entity,IAwake<Transform>,IDestroy 
	{
		public long TotalTime = 3000;
		public long EndTime = 0;
		public long BoxUnitId;
		public long Timer;
		
		public Image E_Img_Di2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Di2Image == null )
     			{
		    		this.m_E_Img_Di2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Di2");
     			}
     			return this.m_E_Img_Di2Image;
     		}
     	}

		public Image E_Img_ProgressImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ProgressImage == null )
     			{
		    		this.m_E_Img_ProgressImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Progress");
     			}
     			return this.m_E_Img_ProgressImage;
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
			this.m_E_Img_Di2Image = null;
			this.m_E_Img_ProgressImage = null;
			this.uiTransform = null;
		}

		private Image m_E_Img_Di2Image = null;
		private Image m_E_Img_ProgressImage = null;
		public Transform uiTransform = null;
	}
}
