
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskGrowUp : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public TaskPro TaskPro;
		public int CompeletTaskId;
		public List<int> ShowTaskConfigIds = new();
		public Dictionary<int, Scroll_Item_TaskGrowUpItem> ScrollItemTaskGrowUpItems;
		public int DownIndex;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_TaskGrowUpItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGrowUpItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TaskGrowUpItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_TaskGrowUpItems");
     			}
     			return this.m_E_TaskGrowUpItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_TaskNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskNameTextText == null )
     			{
		    		this.m_E_TaskNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TaskNameText");
     			}
     			return this.m_E_TaskNameTextText;
     		}
     	}

		public UnityEngine.UI.Text E_ProgressTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressTextText == null )
     			{
		    		this.m_E_ProgressTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ProgressText");
     			}
     			return this.m_E_ProgressTextText;
     		}
     	}

		public UnityEngine.UI.Text E_TaskDescTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskDescTextText == null )
     			{
		    		this.m_E_TaskDescTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TaskDescText");
     			}
     			return this.m_E_TaskDescTextText;
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
     			if( this.m_es_rewardlist == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_GetBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GetBtnButton == null )
     			{
		    		this.m_E_GetBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_GetBtn");
     			}
     			return this.m_E_GetBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_GetBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GetBtnImage == null )
     			{
		    		this.m_E_GetBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GetBtn");
     			}
     			return this.m_E_GetBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_GiveBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveBtnButton == null )
     			{
		    		this.m_E_GiveBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_GiveBtn");
     			}
     			return this.m_E_GiveBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_GiveBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveBtnImage == null )
     			{
		    		this.m_E_GiveBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveBtn");
     			}
     			return this.m_E_GiveBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_AcvityedImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AcvityedImgImage == null )
     			{
		    		this.m_E_AcvityedImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_AcvityedImg");
     			}
     			return this.m_E_AcvityedImgImage;
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
			this.m_E_TaskGrowUpItemsLoopVerticalScrollRect = null;
			this.m_E_TaskNameTextText = null;
			this.m_E_ProgressTextText = null;
			this.m_E_TaskDescTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_GetBtnButton = null;
			this.m_E_GetBtnImage = null;
			this.m_E_GiveBtnButton = null;
			this.m_E_GiveBtnImage = null;
			this.m_E_AcvityedImgImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_TaskGrowUpItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_TaskNameTextText = null;
		private UnityEngine.UI.Text m_E_ProgressTextText = null;
		private UnityEngine.UI.Text m_E_TaskDescTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_GetBtnButton = null;
		private UnityEngine.UI.Image m_E_GetBtnImage = null;
		private UnityEngine.UI.Button m_E_GiveBtnButton = null;
		private UnityEngine.UI.Image m_E_GiveBtnImage = null;
		private UnityEngine.UI.Image m_E_AcvityedImgImage = null;
		public Transform uiTransform = null;
	}
}
