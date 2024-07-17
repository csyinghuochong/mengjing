using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMJLobby))]
	[EnableMethod]
	public  class DlgMJLobbyViewComponent : Entity,IAwake,IDestroy 
	{
		public LoopVerticalScrollRect E_CreateRoleItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CreateRoleItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CreateRoleItems");
     			}
     			return this.m_E_CreateRoleItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_PrevButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PrevButton == null )
     			{
		    		this.m_E_PrevButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"RightSet/E_Prev");
     			}
     			return this.m_E_PrevButton;
     		}
     	}

		public Image E_PrevImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PrevImage == null )
     			{
		    		this.m_E_PrevImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"RightSet/E_Prev");
     			}
     			return this.m_E_PrevImage;
     		}
     	}

		public Button E_NextButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextButton == null )
     			{
		    		this.m_E_NextButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"RightSet/E_Next");
     			}
     			return this.m_E_NextButton;
     		}
     	}

		public Image E_NextImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextImage == null )
     			{
		    		this.m_E_NextImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"RightSet/E_Next");
     			}
     			return this.m_E_NextImage;
     		}
     	}

		public Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public Button E_DeleteRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteRoleButton == null )
     			{
		    		this.m_E_DeleteRoleButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_DeleteRole");
     			}
     			return this.m_E_DeleteRoleButton;
     		}
     	}

		public Image E_DeleteRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteRoleImage == null )
     			{
		    		this.m_E_DeleteRoleImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_DeleteRole");
     			}
     			return this.m_E_DeleteRoleImage;
     		}
     	}

		public Text E_LvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LvText == null )
     			{
		    		this.m_E_LvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lv");
     			}
     			return this.m_E_LvText;
     		}
     	}

		public Text E_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameText == null )
     			{
		    		this.m_E_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Name");
     			}
     			return this.m_E_NameText;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ModelShow es = this.m_es_modelshow;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CreateRoleItemsLoopVerticalScrollRect = null;
			this.m_E_PrevButton = null;
			this.m_E_PrevImage = null;
			this.m_E_NextButton = null;
			this.m_E_NextImage = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_E_DeleteRoleButton = null;
			this.m_E_DeleteRoleImage = null;
			this.m_E_LvText = null;
			this.m_E_NameText = null;
			this.m_es_modelshow = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_CreateRoleItemsLoopVerticalScrollRect = null;
		private Button m_E_PrevButton = null;
		private Image m_E_PrevImage = null;
		private Button m_E_NextButton = null;
		private Image m_E_NextImage = null;
		private Button m_E_EnterMapButton = null;
		private Image m_E_EnterMapImage = null;
		private Button m_E_DeleteRoleButton = null;
		private Image m_E_DeleteRoleImage = null;
		private Text m_E_LvText = null;
		private Text m_E_NameText = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		public Transform uiTransform = null;
	}
}
