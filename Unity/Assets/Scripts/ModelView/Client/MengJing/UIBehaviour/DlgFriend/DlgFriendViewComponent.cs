using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgFriend))]
	[EnableMethod]
	public  class DlgFriendViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_SubViewNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewNodeRectTransform == null )
     			{
		    		this.m_EG_SubViewNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SubViewNode");
     			}
     			return this.m_EG_SubViewNodeRectTransform;
     		}
     	}

		public ES_FriendList ES_FriendList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_FriendList es = this.m_es_friendlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_FriendList");
		    	   this.m_es_friendlist = this.AddChild<ES_FriendList,Transform>(subTrans);
     			}
     			return this.m_es_friendlist;
     		}
     	}

		public ES_FriendApply ES_FriendApply
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_FriendApply es = this.m_es_friendapply;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_FriendApply");
		    	   this.m_es_friendapply = this.AddChild<ES_FriendApply,Transform>(subTrans);
     			}
     			return this.m_es_friendapply;
     		}
     	}

		public ES_FriendBlack ES_FriendBlack
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_FriendBlack es = this.m_es_friendblack;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_FriendBlack");
		    	   this.m_es_friendblack = this.AddChild<ES_FriendBlack,Transform>(subTrans);
     			}
     			return this.m_es_friendblack;
     		}
     	}

		public ES_UnionShow ES_UnionShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_UnionShow es = this.m_es_unionshow;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_UnionShow");
		    	   this.m_es_unionshow = this.AddChild<ES_UnionShow,Transform>(subTrans);
     			}
     			return this.m_es_unionshow;
     		}
     	}

		public ES_UnionMy ES_UnionMy
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_UnionMy es = this.m_es_unionmy;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_UnionMy");
		    	   this.m_es_unionmy = this.AddChild<ES_UnionMy,Transform>(subTrans);
     			}
     			return this.m_es_unionmy;
     		}
     	}

		public ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_es_friendlist = null;
			this.m_es_friendapply = null;
			this.m_es_friendblack = null;
			this.m_es_unionshow = null;
			this.m_es_unionmy = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewNodeRectTransform = null;
		private EntityRef<ES_FriendList> m_es_friendlist = null;
		private EntityRef<ES_FriendApply> m_es_friendapply = null;
		private EntityRef<ES_FriendBlack> m_es_friendblack = null;
		private EntityRef<ES_UnionShow> m_es_unionshow = null;
		private EntityRef<ES_UnionMy> m_es_unionmy = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
