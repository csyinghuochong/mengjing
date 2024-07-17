using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WelfareDraw2 : Entity,IAwake<Transform>,IDestroy
	{
		public List<GameObject> Draws = new();
		public List<GameObject> OutLines = new();
		
		public Button E_DrawBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DrawBtnButton == null )
     			{
		    		this.m_E_DrawBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_DrawBtn");
     			}
     			return this.m_E_DrawBtnButton;
     		}
     	}

		public Image E_DrawBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DrawBtnImage == null )
     			{
		    		this.m_E_DrawBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_DrawBtn");
     			}
     			return this.m_E_DrawBtnImage;
     		}
     	}

		public RectTransform EG_DrawListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DrawListRectTransform == null )
     			{
		    		this.m_EG_DrawListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_DrawList");
     			}
     			return this.m_EG_DrawListRectTransform;
     		}
     	}

		public ES_RewardList ES_RewardList_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem1/ES_RewardList_1");
		    	   this.m_es_rewardlist_1 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_1;
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
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem2/ES_RewardList_2");
		    	   this.m_es_rewardlist_2 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_2;
     		}
     	}

		public ES_RewardList ES_RewardList_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist_3;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem3/ES_RewardList_3");
		    	   this.m_es_rewardlist_3 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_3;
     		}
     	}

		public ES_RewardList ES_RewardList_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist_4;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem4/ES_RewardList_4");
		    	   this.m_es_rewardlist_4 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_4;
     		}
     	}

		public ES_RewardList ES_RewardList_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist_5;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem5/ES_RewardList_5");
		    	   this.m_es_rewardlist_5 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_5;
     		}
     	}

		public ES_RewardList ES_RewardList_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist_6;
     			if( es==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem6/ES_RewardList_6");
		    	   this.m_es_rewardlist_6 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_6;
     		}
     	}

		public ES_RewardList ES_RewardList_7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist_7;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem7/ES_RewardList_7");
		    	   this.m_es_rewardlist_7 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_7;
     		}
     	}

		public ES_RewardList ES_RewardList_8
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist_8;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_DrawList/DrawItem8/ES_RewardList_8");
		    	   this.m_es_rewardlist_8 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_8;
     		}
     	}

		public Text E_NumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NumTextText == null )
     			{
		    		this.m_E_NumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NumText");
     			}
     			return this.m_E_NumTextText;
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
			this.m_E_DrawBtnButton = null;
			this.m_E_DrawBtnImage = null;
			this.m_EG_DrawListRectTransform = null;
			this.m_es_rewardlist_1 = null;
			this.m_es_rewardlist_2 = null;
			this.m_es_rewardlist_3 = null;
			this.m_es_rewardlist_4 = null;
			this.m_es_rewardlist_5 = null;
			this.m_es_rewardlist_6 = null;
			this.m_es_rewardlist_7 = null;
			this.m_es_rewardlist_8 = null;
			this.m_E_NumTextText = null;
			this.uiTransform = null;
		}

		private Button m_E_DrawBtnButton = null;
		private Image m_E_DrawBtnImage = null;
		private RectTransform m_EG_DrawListRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_1 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_2 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_3 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_4 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_5 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_6 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_7 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_8 = null;
		private Text m_E_NumTextText = null;
		public Transform uiTransform = null;
	}
}
