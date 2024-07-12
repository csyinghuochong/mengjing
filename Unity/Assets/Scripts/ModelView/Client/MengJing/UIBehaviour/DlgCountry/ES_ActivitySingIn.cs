
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivitySingIn : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int CurDay;
		public bool IsSign;
		public int ActivityId;
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivitySingInItem>> ScrollItemActivitySingInItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_ActivitySingInItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingInItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ActivitySingInItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ActivitySingInItems");
     			}
     			return this.m_E_ActivitySingInItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ComButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ComButton == null )
     			{
		    		this.m_E_Btn_ComButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Com");
     			}
     			return this.m_E_Btn_ComButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ComImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ComImage == null )
     			{
		    		this.m_E_Btn_ComImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Com");
     			}
     			return this.m_E_Btn_ComImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_lingQuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_lingQuImage == null )
     			{
		    		this.m_E_Img_lingQuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_lingQu");
     			}
     			return this.m_E_Img_lingQuImage;
     		}
     	}

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

		public ES_RewardList ES_RewardList_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RewardList es = this.m_es_rewardlist_2;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList_2");
		    	   this.m_es_rewardlist_2 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_2;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_Com2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Com2Button == null )
     			{
		    		this.m_E_Btn_Com2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Com2");
     			}
     			return this.m_E_Btn_Com2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_Com2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Com2Image == null )
     			{
		    		this.m_E_Btn_Com2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Com2");
     			}
     			return this.m_E_Btn_Com2Image;
     		}
     	}

		public UnityEngine.UI.Image E_Img_lingQu2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_lingQu2Image == null )
     			{
		    		this.m_E_Img_lingQu2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_lingQu2");
     			}
     			return this.m_E_Img_lingQu2Image;
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
			this.m_E_ActivitySingInItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_ComButton = null;
			this.m_E_Btn_ComImage = null;
			this.m_E_Img_lingQuImage = null;
			this.m_es_rewardlist = null;
			this.m_es_rewardlist_2 = null;
			this.m_E_Btn_Com2Button = null;
			this.m_E_Btn_Com2Image = null;
			this.m_E_Img_lingQu2Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_ActivitySingInItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_ComButton = null;
		private UnityEngine.UI.Image m_E_Btn_ComImage = null;
		private UnityEngine.UI.Image m_E_Img_lingQuImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_2 = null;
		private UnityEngine.UI.Button m_E_Btn_Com2Button = null;
		private UnityEngine.UI.Image m_E_Btn_Com2Image = null;
		private UnityEngine.UI.Image m_E_Img_lingQu2Image = null;
		public Transform uiTransform = null;
	}
}
