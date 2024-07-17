using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ShouJiList : Entity,IAwake<Transform>,IDestroy 
	{
		public ScrollRect E_ScrollViewScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollViewScrollRect == null )
     			{
		    		this.m_E_ScrollViewScrollRect = UIFindHelper.FindDeepChild<ScrollRect>(this.uiTransform.gameObject,"E_ScrollView");
     			}
     			return this.m_E_ScrollViewScrollRect;
     		}
     	}

		public Image E_ScrollViewImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ScrollViewImage == null )
     			{
		    		this.m_E_ScrollViewImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ScrollView");
     			}
     			return this.m_E_ScrollViewImage;
     		}
     	}

		public RectTransform EG_ShoujiContentRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ShoujiContentRectTransform == null )
     			{
		    		this.m_EG_ShoujiContentRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_ScrollView/Viewport/EG_ShoujiContent");
     			}
     			return this.m_EG_ShoujiContentRectTransform;
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
			this.m_E_ScrollViewScrollRect = null;
			this.m_E_ScrollViewImage = null;
			this.m_EG_ShoujiContentRectTransform = null;
			this.uiTransform = null;
		}

		private ScrollRect m_E_ScrollViewScrollRect = null;
		private Image m_E_ScrollViewImage = null;
		private RectTransform m_EG_ShoujiContentRectTransform = null;
		public Transform uiTransform = null;
	}
}
