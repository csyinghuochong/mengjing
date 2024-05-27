
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleXiLianNumReward))]
	[EnableMethod]
	public  class DlgRoleXiLianNumRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_TextTitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTitleText == null )
     			{
		    		this.m_E_TextTitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTitle");
     			}
     			return this.m_E_TextTitleText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ChouKaRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChouKaRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChouKaRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ChouKaRewardItems");
     			}
     			return this.m_E_ChouKaRewardItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RewardButton == null )
     			{
		    		this.m_E_Btn_RewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ChouKaRewardItems/Content/Item_ChouKaRewardItem/E_Btn_Reward");
     			}
     			return this.m_E_Btn_RewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RewardImage == null )
     			{
		    		this.m_E_Btn_RewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ChouKaRewardItems/Content/Item_ChouKaRewardItem/E_Btn_Reward");
     			}
     			return this.m_E_Btn_RewardImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextNeedTimesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNeedTimesText == null )
     			{
		    		this.m_E_TextNeedTimesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ChouKaRewardItems/Content/Item_ChouKaRewardItem/E_TextNeedTimes");
     			}
     			return this.m_E_TextNeedTimesText;
     		}
     	}

		public UnityEngine.UI.Text E_TextZuanshiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextZuanshiText == null )
     			{
		    		this.m_E_TextZuanshiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ChouKaRewardItems/Content/Item_ChouKaRewardItem/E_TextZuanshi");
     			}
     			return this.m_E_TextZuanshiText;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_ChouKaRewardItems/Content/Item_ChouKaRewardItem/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextTitleText = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_ChouKaRewardItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_RewardButton = null;
			this.m_E_Btn_RewardImage = null;
			this.m_E_TextNeedTimesText = null;
			this.m_E_TextZuanshiText = null;
			this.m_es_rewardlist = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_TextTitleText = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChouKaRewardItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_RewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_RewardImage = null;
		private UnityEngine.UI.Text m_E_TextNeedTimesText = null;
		private UnityEngine.UI.Text m_E_TextZuanshiText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
