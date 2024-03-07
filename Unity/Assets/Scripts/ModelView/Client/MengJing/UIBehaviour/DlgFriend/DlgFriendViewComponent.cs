
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFriend))]
	[EnableMethod]
	public  class DlgFriendViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_Button_0Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_0Toggle == null )
     			{
		    		this.m_E_Button_0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Button_0");
     			}
     			return this.m_E_Button_0Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Button_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1Toggle == null )
     			{
		    		this.m_E_Button_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Button_1");
     			}
     			return this.m_E_Button_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Button_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2Toggle == null )
     			{
		    		this.m_E_Button_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Button_2");
     			}
     			return this.m_E_Button_2Toggle;
     		}
     	}

		public UnityEngine.RectTransform EG_SubViewNodeRectTransform
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
		    		this.m_EG_SubViewNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubViewNode");
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
     			if( this.m_es_friendlist == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_FriendList");
		    	   this.m_es_friendlist = this.AddChild<ES_FriendList,Transform>(subTrans);
     			}
     			return this.m_es_friendlist;
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
     			if( this.m_es_friendblack == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_FriendBlack");
		    	   this.m_es_friendblack = this.AddChild<ES_FriendBlack,Transform>(subTrans);
     			}
     			return this.m_es_friendblack;
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
     			if( this.m_es_friendapply == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubViewNode/ES_FriendApply");
		    	   this.m_es_friendapply = this.AddChild<ES_FriendApply,Transform>(subTrans);
     			}
     			return this.m_es_friendapply;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Button_0Toggle = null;
			this.m_E_Button_1Toggle = null;
			this.m_E_Button_2Toggle = null;
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_es_friendlist = null;
			this.m_es_friendblack = null;
			this.m_es_friendapply = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Button_0Toggle = null;
		private UnityEngine.UI.Toggle m_E_Button_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_Button_2Toggle = null;
		private UnityEngine.RectTransform m_EG_SubViewNodeRectTransform = null;
		private EntityRef<ES_FriendList> m_es_friendlist = null;
		private EntityRef<ES_FriendBlack> m_es_friendblack = null;
		private EntityRef<ES_FriendApply> m_es_friendapply = null;
		public Transform uiTransform = null;
	}
}
