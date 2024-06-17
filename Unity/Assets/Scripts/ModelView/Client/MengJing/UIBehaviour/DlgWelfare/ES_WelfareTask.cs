
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WelfareTask : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int Day;
		public List<TaskPro> ShowTaskPros = new();
		public Dictionary<int, Scroll_Item_WelfareTaskItem> ScrollItemWelfareTaskItems;
		
		public UnityEngine.UI.Image E_DayProgressImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DayProgressImgImage == null )
     			{
		    		this.m_E_DayProgressImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/ProgressBar/E_DayProgressImg");
     			}
     			return this.m_E_DayProgressImgImage;
     		}
     	}

		public UnityEngine.RectTransform EG_DayListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DayListNodeRectTransform == null )
     			{
		    		this.m_EG_DayListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/ProgressBar/EG_DayListNode");
     			}
     			return this.m_EG_DayListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_WelfareTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WelfareTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_WelfareTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_WelfareTaskItems");
     			}
     			return this.m_E_WelfareTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_CompletenessTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CompletenessTextText == null )
     			{
		    		this.m_E_CompletenessTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_CompletenessText");
     			}
     			return this.m_E_CompletenessTextText;
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
     			if( this.m_es_rewardlist .Equals(null) )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_ReceiveBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceiveBtnButton == null )
     			{
		    		this.m_E_ReceiveBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ReceiveBtn");
     			}
     			return this.m_E_ReceiveBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReceiveBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceiveBtnImage == null )
     			{
		    		this.m_E_ReceiveBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ReceiveBtn");
     			}
     			return this.m_E_ReceiveBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_ReceivedImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReceivedImgImage == null )
     			{
		    		this.m_E_ReceivedImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ReceivedImg");
     			}
     			return this.m_E_ReceivedImgImage;
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
			this.m_E_DayProgressImgImage = null;
			this.m_EG_DayListNodeRectTransform = null;
			this.m_E_WelfareTaskItemsLoopVerticalScrollRect = null;
			this.m_E_CompletenessTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_ReceiveBtnButton = null;
			this.m_E_ReceiveBtnImage = null;
			this.m_E_ReceivedImgImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_DayProgressImgImage = null;
		private UnityEngine.RectTransform m_EG_DayListNodeRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_WelfareTaskItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_CompletenessTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ReceiveBtnButton = null;
		private UnityEngine.UI.Image m_E_ReceiveBtnImage = null;
		private UnityEngine.UI.Image m_E_ReceivedImgImage = null;
		public Transform uiTransform = null;
	}
}
