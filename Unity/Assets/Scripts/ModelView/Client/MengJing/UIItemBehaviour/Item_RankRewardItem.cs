using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RankRewardItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_RankRewardItem>
	{

		public long LastRewardPlayerId {get;set;}= 0;
        
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RankRewardItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_Text_RankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_RankText == null )
     				{
		    			this.m_E_Text_RankText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Rank");
     				}
     				return this.m_E_Text_RankText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Rank");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( es ==null  )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if( es!=null  )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			es = this.m_es_rewardlist;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_rewardlist = null;
		    				this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     		}
     	}

		public RectTransform EG_RankShowSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EG_RankShowSetRectTransform == null )
     				{
		    			this.m_EG_RankShowSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RankShowSet");
     				}
     				return this.m_EG_RankShowSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RankShowSet");
     			}
     		}
     	}

		public Image E_Rank_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Rank_1Image == null )
     				{
		    			this.m_E_Rank_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_1");
     				}
     				return this.m_E_Rank_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_1");
     			}
     		}
     	}

		public Image E_Rank_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Rank_2Image == null )
     				{
		    			this.m_E_Rank_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_2");
     				}
     				return this.m_E_Rank_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_2");
     			}
     		}
     	}

		public Image E_Rank_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Rank_3Image == null )
     				{
		    			this.m_E_Rank_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_3");
     				}
     				return this.m_E_Rank_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_3");
     			}
     		}
     	}

		public Transform EG_PlayerInfo
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if (this.isCacheNode)
				{
					if( this.m_EG_PlayerInfo == null )
					{
						this.m_EG_PlayerInfo = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PlayerInfo");
					}
					return this.m_EG_PlayerInfo;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PlayerInfo");
				}
			}
		}

		public Image E_PlayerIcon
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if (this.isCacheNode)
				{
					if( this.m_E_PlayerIcon == null )
					{
						this.m_E_PlayerIcon = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PlayerInfo/E_PlayerIcon");
					}
					return this.m_E_PlayerIcon;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PlayerInfo/E_PlayerIcon");
				}
			}
		}
		
		public Text E_PlayerName
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if (this.isCacheNode)
				{
					if( this.m_E_PlayerName == null )
					{
						this.m_E_PlayerName = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PlayerInfo/E_PlayerName");
					}
					return this.m_E_PlayerName;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PlayerInfo/E_PlayerName");
				}
			}
		}
		

		public Transform EG_LastNo
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if (this.isCacheNode)
				{
					if( this.m_EG_LastNo == null )
					{
						this.m_EG_LastNo = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_LastNo");
					}
					return this.m_EG_LastNo;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_LastNo");
				}
			}
		}

		public void DestroyWidget()
		{
			this.m_E_Text_RankText = null;
			this.m_es_rewardlist = null;
			this.m_EG_RankShowSetRectTransform = null;
			this.m_E_Rank_1Image = null;
			this.m_E_Rank_2Image = null;
			this.m_E_Rank_3Image = null;
			this.m_EG_PlayerInfo = null;
			this.m_E_PlayerIcon = null;
			this.m_E_PlayerName = null;
			this.m_EG_LastNo = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_Text_RankText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private RectTransform m_EG_RankShowSetRectTransform = null;
		private Image m_E_Rank_1Image = null;
		private Image m_E_Rank_2Image = null;
		private Image m_E_Rank_3Image = null;
		private Transform m_EG_PlayerInfo = null;
		private Image m_E_PlayerIcon = null;
		private Text m_E_PlayerName = null;
		private Transform m_EG_LastNo = null;
		public Transform uiTransform = null;
	}
}
