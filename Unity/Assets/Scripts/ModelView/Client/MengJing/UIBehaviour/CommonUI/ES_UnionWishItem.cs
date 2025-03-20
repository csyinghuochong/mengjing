
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionWishItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{

		public int WishType { get; set; }

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

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

		public UnityEngine.UI.Text E_Text_WishCost
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_WishCost == null )
				{
					this.m_E_Text_WishCost = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_WishCost");
				}
				return this.m_E_Text_WishCost;
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
			this.m_es_rewardlist = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.m_E_Text_WishCost = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		private Text m_E_Text_WishCost;
		public Transform uiTransform = null;
	}
}
