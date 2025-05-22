using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_DragonDungeonMy : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public GameObject[] UITeamNodeList = new GameObject[3];
		public List<ES_TeamItem> TeamUIList { get; set; } = new();
		
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

		public UnityEngine.UI.Button E_Button_EnterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_EnterButton == null )
     			{
		    		this.m_E_Button_EnterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Enter");
     			}
     			return this.m_E_Button_EnterButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_EnterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_EnterImage == null )
     			{
		    		this.m_E_Button_EnterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Enter");
     			}
     			return this.m_E_Button_EnterImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_CallButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CallButton == null )
     			{
		    		this.m_E_Button_CallButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Call");
     			}
     			return this.m_E_Button_CallButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_CallImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CallImage == null )
     			{
		    		this.m_E_Button_CallImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Call");
     			}
     			return this.m_E_Button_CallImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_LeaveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_LeaveButton == null )
     			{
		    		this.m_E_Button_LeaveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Leave");
     			}
     			return this.m_E_Button_LeaveButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_LeaveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_LeaveImage == null )
     			{
		    		this.m_E_Button_LeaveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Leave");
     			}
     			return this.m_E_Button_LeaveImage;
     		}
     	}

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

		public UnityEngine.UI.Button E_Button_RobotButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RobotButton == null )
     			{
		    		this.m_E_Button_RobotButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Robot");
     			}
     			return this.m_E_Button_RobotButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RobotImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RobotImage == null )
     			{
		    		this.m_E_Button_RobotImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Robot");
     			}
     			return this.m_E_Button_RobotImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_FuBenNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_FuBenNameText == null )
     			{
		    		this.m_E_Lab_FuBenNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Lab_FuBenName");
     			}
     			return this.m_E_Lab_FuBenNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_FuBenLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_FuBenLvText == null )
     			{
		    		this.m_E_Lab_FuBenLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Lab_FuBenLv");
     			}
     			return this.m_E_Lab_FuBenLvText;
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
			this.m_es_teamitem_1 = null;
			this.m_es_teamitem_2 = null;
			this.m_es_teamitem_3 = null;
			this.m_E_Button_EnterButton = null;
			this.m_E_Button_EnterImage = null;
			this.m_E_Button_CallButton = null;
			this.m_E_Button_CallImage = null;
			this.m_E_Button_LeaveButton = null;
			this.m_E_Button_LeaveImage = null;
			this.m_E_ButtonApplyListButton = null;
			this.m_E_ButtonApplyListImage = null;
			this.m_E_Button_RobotButton = null;
			this.m_E_Button_RobotImage = null;
			this.m_E_Lab_FuBenNameText = null;
			this.m_E_Lab_FuBenLvText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_TeamItem> m_es_teamitem_1 = null;
		private EntityRef<ES_TeamItem> m_es_teamitem_2 = null;
		private EntityRef<ES_TeamItem> m_es_teamitem_3 = null;
		private UnityEngine.UI.Button m_E_Button_EnterButton = null;
		private UnityEngine.UI.Image m_E_Button_EnterImage = null;
		private UnityEngine.UI.Button m_E_Button_CallButton = null;
		private UnityEngine.UI.Image m_E_Button_CallImage = null;
		private UnityEngine.UI.Button m_E_Button_LeaveButton = null;
		private UnityEngine.UI.Image m_E_Button_LeaveImage = null;
		private UnityEngine.UI.Button m_E_ButtonApplyListButton = null;
		private UnityEngine.UI.Image m_E_ButtonApplyListImage = null;
		private UnityEngine.UI.Button m_E_Button_RobotButton = null;
		private UnityEngine.UI.Image m_E_Button_RobotImage = null;
		private UnityEngine.UI.Text m_E_Lab_FuBenNameText = null;
		private UnityEngine.UI.Text m_E_Lab_FuBenLvText = null;
		public Transform uiTransform = null;
	}
}
