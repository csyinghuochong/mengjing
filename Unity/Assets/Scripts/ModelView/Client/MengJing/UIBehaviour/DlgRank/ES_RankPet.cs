
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankPet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		public List<ES_RankPetItem> PetUIList = new();
		
		public UnityEngine.UI.Text E_Text_RankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RankText == null )
     			{
		    		this.m_E_Text_RankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Rank");
     			}
     			return this.m_E_Text_RankText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeftTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LeftTimeText == null )
     			{
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_LeftTime");
     			}
     			return this.m_E_Text_LeftTimeText;
     		}
     	}

		public UnityEngine.UI.Button E_Button_TeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_TeamButton == null )
     			{
		    		this.m_E_Button_TeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Team");
     			}
     			return this.m_E_Button_TeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_TeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_TeamImage == null )
     			{
		    		this.m_E_Button_TeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Team");
     			}
     			return this.m_E_Button_TeamImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RewardButton == null )
     			{
		    		this.m_E_Button_RewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Reward");
     			}
     			return this.m_E_Button_RewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RewardImage == null )
     			{
		    		this.m_E_Button_RewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Reward");
     			}
     			return this.m_E_Button_RewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RefreshButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RefreshButton == null )
     			{
		    		this.m_E_Button_RefreshButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Refresh");
     			}
     			return this.m_E_Button_RefreshButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RefreshImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RefreshImage == null )
     			{
		    		this.m_E_Button_RefreshImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Refresh");
     			}
     			return this.m_E_Button_RefreshImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddButton == null )
     			{
		    		this.m_E_Button_AddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Add");
     			}
     			return this.m_E_Button_AddButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddImage == null )
     			{
		    		this.m_E_Button_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Add");
     			}
     			return this.m_E_Button_AddImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetListNodeRectTransform == null )
     			{
		    		this.m_EG_PetListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetListNode");
     			}
     			return this.m_EG_PetListNodeRectTransform;
     		}
     	}

		public ES_RankPetItem ES_RankPetItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RankPetItem es = this.m_es_rankpetitem_0;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetListNode/ES_RankPetItem_0");
		    	   this.m_es_rankpetitem_0 = this.AddChild<ES_RankPetItem,Transform>(subTrans);
     			}
     			return this.m_es_rankpetitem_0;
     		}
     	}

		public ES_RankPetItem ES_RankPetItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RankPetItem es = this.m_es_rankpetitem_1;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetListNode/ES_RankPetItem_1");
		    	   this.m_es_rankpetitem_1 = this.AddChild<ES_RankPetItem,Transform>(subTrans);
     			}
     			return this.m_es_rankpetitem_1;
     		}
     	}

		public ES_RankPetItem ES_RankPetItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RankPetItem es = this.m_es_rankpetitem_2;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetListNode/ES_RankPetItem_2");
		    	   this.m_es_rankpetitem_2 = this.AddChild<ES_RankPetItem,Transform>(subTrans);
     			}
     			return this.m_es_rankpetitem_2;
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
			this.m_E_Text_RankText = null;
			this.m_E_Text_LeftTimeText = null;
			this.m_E_Button_TeamButton = null;
			this.m_E_Button_TeamImage = null;
			this.m_E_Button_RewardButton = null;
			this.m_E_Button_RewardImage = null;
			this.m_E_Button_RefreshButton = null;
			this.m_E_Button_RefreshImage = null;
			this.m_E_Button_AddButton = null;
			this.m_E_Button_AddImage = null;
			this.m_EG_PetListNodeRectTransform = null;
			this.m_es_rankpetitem_0 = null;
			this.m_es_rankpetitem_1 = null;
			this.m_es_rankpetitem_2 = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_Text_RankText = null;
		private UnityEngine.UI.Text m_E_Text_LeftTimeText = null;
		private UnityEngine.UI.Button m_E_Button_TeamButton = null;
		private UnityEngine.UI.Image m_E_Button_TeamImage = null;
		private UnityEngine.UI.Button m_E_Button_RewardButton = null;
		private UnityEngine.UI.Image m_E_Button_RewardImage = null;
		private UnityEngine.UI.Button m_E_Button_RefreshButton = null;
		private UnityEngine.UI.Image m_E_Button_RefreshImage = null;
		private UnityEngine.UI.Button m_E_Button_AddButton = null;
		private UnityEngine.UI.Image m_E_Button_AddImage = null;
		private UnityEngine.RectTransform m_EG_PetListNodeRectTransform = null;
		private EntityRef<ES_RankPetItem> m_es_rankpetitem_0 = null;
		private EntityRef<ES_RankPetItem> m_es_rankpetitem_1 = null;
		private EntityRef<ES_RankPetItem> m_es_rankpetitem_2 = null;
		public Transform uiTransform = null;
	}
}
