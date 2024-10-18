using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_DigTreasure : Entity,IAwake<Transform>,IDestroy
	{
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public float PassTime = 0f;
		public float MoveSpeed = 50f;
		public long Timer;
		
		public RectTransform EG_Img_NodeRectTransform
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
		    		this.m_EG_Img_NodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Img_Node");
     			}
     			return this.m_EG_Img_NodeRectTransform;
     		}
     	}

		public Image E_Img_ChanZiImage
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
		    		this.m_E_Img_ChanZiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Img_Node/E_Img_ChanZi");
     			}
     			return this.m_E_Img_ChanZiImage;
     		}
     	}

		public Image E_Img_PosImage
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
		    		this.m_E_Img_PosImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Img_Node/E_Img_Pos");
     			}
     			return this.m_E_Img_PosImage;
     		}
     	}

		public Button E_ButtonDigButton
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
		    		this.m_E_ButtonDigButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonDig");
     			}
     			return this.m_E_ButtonDigButton;
     		}
     	}

		public Image E_ButtonDigImage
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
		    		this.m_E_ButtonDigImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonDig");
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

		private RectTransform m_EG_Img_NodeRectTransform = null;
		private Image m_E_Img_ChanZiImage = null;
		private Image m_E_Img_PosImage = null;
		private Button m_E_ButtonDigButton = null;
		private Image m_E_ButtonDigImage = null;
		public Transform uiTransform = null;
	}
}
