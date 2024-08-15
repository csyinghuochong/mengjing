
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_DigTreasure : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public BagInfo BagInfo;
		public float PassTime = 0f;
		public float MoveSpeed = 50f;
		public long Timer;
		
		public UnityEngine.RectTransform EG_Img_NodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Img_NodeRectTransform == null )
     			{
		    		this.m_EG_Img_NodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Img_Node");
     			}
     			return this.m_EG_Img_NodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ChanZiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ChanZiImage == null )
     			{
		    		this.m_E_Img_ChanZiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Img_Node/E_Img_ChanZi");
     			}
     			return this.m_E_Img_ChanZiImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_PosImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_PosImage == null )
     			{
		    		this.m_E_Img_PosImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Img_Node/E_Img_Pos");
     			}
     			return this.m_E_Img_PosImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonDigButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDigButton == null )
     			{
		    		this.m_E_ButtonDigButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonDig");
     			}
     			return this.m_E_ButtonDigButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonDigImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDigImage == null )
     			{
		    		this.m_E_ButtonDigImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonDig");
     			}
     			return this.m_E_ButtonDigImage;
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
			this.m_EG_Img_NodeRectTransform = null;
			this.m_E_Img_ChanZiImage = null;
			this.m_E_Img_PosImage = null;
			this.m_E_ButtonDigButton = null;
			this.m_E_ButtonDigImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_Img_NodeRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_ChanZiImage = null;
		private UnityEngine.UI.Image m_E_Img_PosImage = null;
		private UnityEngine.UI.Button m_E_ButtonDigButton = null;
		private UnityEngine.UI.Image m_E_ButtonDigImage = null;
		public Transform uiTransform = null;
	}
}
