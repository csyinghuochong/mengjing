using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTeam))]
	[EnableMethod]
	public  class DlgTeamViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ButtonApplyListButton
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
		    		this.m_E_ButtonApplyListButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListButton;
     		}
     	}

		public Image E_ButtonApplyListImage
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
		    		this.m_E_ButtonApplyListImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListImage;
     		}
     	}

		public Button E_ButtonLeaveButton
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
		    		this.m_E_ButtonLeaveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveButton;
     		}
     	}

		public Image E_ButtonLeaveImage
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
		    		this.m_E_ButtonLeaveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveImage;
     		}
     	}

		public ES_TeamItem ES_TeamItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TeamItem es = this.m_es_teamitem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TeamItem");
		    	   this.m_es_teamitem = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem;
     		}
     	}

		public ES_TeamItem ES_TeamItem2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TeamItem es = this.m_es_teamitem2;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TeamItem2");
		    	   this.m_es_teamitem2 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem2;
     		}
     	}

		public ES_TeamItem ES_TeamItem3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TeamItem es = this.m_es_teamitem3;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TeamItem3");
		    	   this.m_es_teamitem3 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem3;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonApplyListButton = null;
			this.m_E_ButtonApplyListImage = null;
			this.m_E_ButtonLeaveButton = null;
			this.m_E_ButtonLeaveImage = null;
			this.m_es_teamitem = null;
			this.m_es_teamitem2 = null;
			this.m_es_teamitem3 = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonApplyListButton = null;
		private Image m_E_ButtonApplyListImage = null;
		private Button m_E_ButtonLeaveButton = null;
		private Image m_E_ButtonLeaveImage = null;
		private EntityRef<ES_TeamItem> m_es_teamitem = null;
		private EntityRef<ES_TeamItem> m_es_teamitem2 = null;
		private EntityRef<ES_TeamItem> m_es_teamitem3 = null;
		public Transform uiTransform = null;
	}
}
