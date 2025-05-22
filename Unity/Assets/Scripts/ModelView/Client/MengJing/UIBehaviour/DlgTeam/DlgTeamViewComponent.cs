
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTeam))]
	[EnableMethod]
	public  class DlgTeamViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonApplyListButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonApplyListButton == null )
     			{
		    		this.m_E_ButtonApplyListButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonApplyListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonApplyListImage == null )
     			{
		    		this.m_E_ButtonApplyListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonLeaveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLeaveButton == null )
     			{
		    		this.m_E_ButtonLeaveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonLeaveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLeaveImage == null )
     			{
		    		this.m_E_ButtonLeaveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveImage;
     		}
     	}

		public ES_TeamItem ES_TeamItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_TeamItem es = this.m_es_teamitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_TeamItem_1");
		    	   this.m_es_teamitem_1 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem_1;
     		}
     	}

		public ES_TeamItem ES_TeamItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_TeamItem es = this.m_es_teamitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_TeamItem_2");
		    	   this.m_es_teamitem_2 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem_2;
     		}
     	}

		public ES_TeamItem ES_TeamItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_TeamItem es = this.m_es_teamitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_TeamItem_3");
		    	   this.m_es_teamitem_3 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem_3;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonApplyListButton = null;
			this.m_E_ButtonApplyListImage = null;
			this.m_E_ButtonLeaveButton = null;
			this.m_E_ButtonLeaveImage = null;
			this.m_es_teamitem_1 = null;
			this.m_es_teamitem_2 = null;
			this.m_es_teamitem_3 = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonApplyListButton = null;
		private UnityEngine.UI.Image m_E_ButtonApplyListImage = null;
		private UnityEngine.UI.Button m_E_ButtonLeaveButton = null;
		private UnityEngine.UI.Image m_E_ButtonLeaveImage = null;
		private EntityRef<ES_TeamItem> m_es_teamitem_1 = null;
		private EntityRef<ES_TeamItem> m_es_teamitem_2 = null;
		private EntityRef<ES_TeamItem> m_es_teamitem_3 = null;
		public Transform uiTransform = null;
	}
}
