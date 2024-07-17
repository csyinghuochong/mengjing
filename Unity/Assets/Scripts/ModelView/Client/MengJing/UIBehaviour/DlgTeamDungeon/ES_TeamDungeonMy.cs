using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TeamDungeonMy : Entity,IAwake<Transform>,IDestroy 
	{
		public GameObject[] UITeamNodeList = new GameObject[3];
		public List<ES_TeamItem> TeamUIList { get; set; } = new();
		
		public ES_TeamItem ES_TeamItem1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TeamItem es = this.m_es_teamitem1;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_TeamItem1");
		    	   this.m_es_teamitem1 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem1;
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

		public Button E_Button_CallButton
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
		    		this.m_E_Button_CallButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Call");
     			}
     			return this.m_E_Button_CallButton;
     		}
     	}

		public Image E_Button_CallImage
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
		    		this.m_E_Button_CallImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Call");
     			}
     			return this.m_E_Button_CallImage;
     		}
     	}

		public Button E_Button_EnterButton
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
		    		this.m_E_Button_EnterButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Enter");
     			}
     			return this.m_E_Button_EnterButton;
     		}
     	}

		public Image E_Button_EnterImage
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
		    		this.m_E_Button_EnterImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Enter");
     			}
     			return this.m_E_Button_EnterImage;
     		}
     	}

		public Button E_Button_LeaveButton
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
		    		this.m_E_Button_LeaveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Leave");
     			}
     			return this.m_E_Button_LeaveButton;
     		}
     	}

		public Image E_Button_LeaveImage
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
		    		this.m_E_Button_LeaveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Leave");
     			}
     			return this.m_E_Button_LeaveImage;
     		}
     	}

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

		public Button E_Button_RobotButton
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
		    		this.m_E_Button_RobotButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Robot");
     			}
     			return this.m_E_Button_RobotButton;
     		}
     	}

		public Image E_Button_RobotImage
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
		    		this.m_E_Button_RobotImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Robot");
     			}
     			return this.m_E_Button_RobotImage;
     		}
     	}

		public Text E_Lab_FuBenNameText
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
		    		this.m_E_Lab_FuBenNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_FuBenName");
     			}
     			return this.m_E_Lab_FuBenNameText;
     		}
     	}

		public Text E_Lab_FuBenLvText
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
		    		this.m_E_Lab_FuBenLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_FuBenLv");
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
			this.m_es_teamitem1 = null;
			this.m_es_teamitem2 = null;
			this.m_es_teamitem3 = null;
			this.m_E_Button_CallButton = null;
			this.m_E_Button_CallImage = null;
			this.m_E_Button_EnterButton = null;
			this.m_E_Button_EnterImage = null;
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

		private EntityRef<ES_TeamItem> m_es_teamitem1 = null;
		private EntityRef<ES_TeamItem> m_es_teamitem2 = null;
		private EntityRef<ES_TeamItem> m_es_teamitem3 = null;
		private Button m_E_Button_CallButton = null;
		private Image m_E_Button_CallImage = null;
		private Button m_E_Button_EnterButton = null;
		private Image m_E_Button_EnterImage = null;
		private Button m_E_Button_LeaveButton = null;
		private Image m_E_Button_LeaveImage = null;
		private Button m_E_ButtonApplyListButton = null;
		private Image m_E_ButtonApplyListImage = null;
		private Button m_E_Button_RobotButton = null;
		private Image m_E_Button_RobotImage = null;
		private Text m_E_Lab_FuBenNameText = null;
		private Text m_E_Lab_FuBenLvText = null;
		public Transform uiTransform = null;
	}
}
