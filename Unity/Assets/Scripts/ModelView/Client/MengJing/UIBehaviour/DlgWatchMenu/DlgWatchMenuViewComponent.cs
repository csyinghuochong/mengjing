using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWatchMenu))]
	[EnableMethod]
	public  class DlgWatchMenuViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageBgButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBgButton == null )
     			{
		    		this.m_E_ImageBgButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgButton;
     		}
     	}

		public Image E_ImageBgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBgImage == null )
     			{
		    		this.m_E_ImageBgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgImage;
     		}
     	}

		public Image E_ImageDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageDiImage == null )
     			{
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public RectTransform EG_PositionSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PositionSetRectTransform == null )
     			{
		    		this.m_EG_PositionSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PositionSet");
     			}
     			return this.m_EG_PositionSetRectTransform;
     		}
     	}

		public Button E_Button_WatchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_WatchButton == null )
     			{
		    		this.m_E_Button_WatchButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Watch");
     			}
     			return this.m_E_Button_WatchButton;
     		}
     	}

		public Image E_Button_WatchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_WatchImage == null )
     			{
		    		this.m_E_Button_WatchImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Watch");
     			}
     			return this.m_E_Button_WatchImage;
     		}
     	}

		public Button E_Button_InviteTeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_InviteTeamButton == null )
     			{
		    		this.m_E_Button_InviteTeamButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteTeam");
     			}
     			return this.m_E_Button_InviteTeamButton;
     		}
     	}

		public Image E_Button_InviteTeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_InviteTeamImage == null )
     			{
		    		this.m_E_Button_InviteTeamImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteTeam");
     			}
     			return this.m_E_Button_InviteTeamImage;
     		}
     	}

		public Button E_Button_AddFriendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddFriendButton == null )
     			{
		    		this.m_E_Button_AddFriendButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_AddFriend");
     			}
     			return this.m_E_Button_AddFriendButton;
     		}
     	}

		public Image E_Button_AddFriendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddFriendImage == null )
     			{
		    		this.m_E_Button_AddFriendImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_AddFriend");
     			}
     			return this.m_E_Button_AddFriendImage;
     		}
     	}

		public Button E_Button_KickTeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_KickTeamButton == null )
     			{
		    		this.m_E_Button_KickTeamButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickTeam");
     			}
     			return this.m_E_Button_KickTeamButton;
     		}
     	}

		public Image E_Button_KickTeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_KickTeamImage == null )
     			{
		    		this.m_E_Button_KickTeamImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickTeam");
     			}
     			return this.m_E_Button_KickTeamImage;
     		}
     	}

		public Button E_Button_LeaveTeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_LeaveTeamButton == null )
     			{
		    		this.m_E_Button_LeaveTeamButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_LeaveTeam");
     			}
     			return this.m_E_Button_LeaveTeamButton;
     		}
     	}

		public Image E_Button_LeaveTeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_LeaveTeamImage == null )
     			{
		    		this.m_E_Button_LeaveTeamImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_LeaveTeam");
     			}
     			return this.m_E_Button_LeaveTeamImage;
     		}
     	}

		public Button E_Button_ApplyTeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ApplyTeamButton == null )
     			{
		    		this.m_E_Button_ApplyTeamButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ApplyTeam");
     			}
     			return this.m_E_Button_ApplyTeamButton;
     		}
     	}

		public Image E_Button_ApplyTeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ApplyTeamImage == null )
     			{
		    		this.m_E_Button_ApplyTeamImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ApplyTeam");
     			}
     			return this.m_E_Button_ApplyTeamImage;
     		}
     	}

		public Button E_Button_InviteUnionButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_InviteUnionButton == null )
     			{
		    		this.m_E_Button_InviteUnionButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteUnion");
     			}
     			return this.m_E_Button_InviteUnionButton;
     		}
     	}

		public Image E_Button_InviteUnionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_InviteUnionImage == null )
     			{
		    		this.m_E_Button_InviteUnionImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteUnion");
     			}
     			return this.m_E_Button_InviteUnionImage;
     		}
     	}

		public Button E_Button_KickUnionButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_KickUnionButton == null )
     			{
		    		this.m_E_Button_KickUnionButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickUnion");
     			}
     			return this.m_E_Button_KickUnionButton;
     		}
     	}

		public Image E_Button_KickUnionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_KickUnionImage == null )
     			{
		    		this.m_E_Button_KickUnionImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickUnion");
     			}
     			return this.m_E_Button_KickUnionImage;
     		}
     	}

		public Button E_Button_BlackAddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_BlackAddButton == null )
     			{
		    		this.m_E_Button_BlackAddButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackAdd");
     			}
     			return this.m_E_Button_BlackAddButton;
     		}
     	}

		public Image E_Button_BlackAddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_BlackAddImage == null )
     			{
		    		this.m_E_Button_BlackAddImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackAdd");
     			}
     			return this.m_E_Button_BlackAddImage;
     		}
     	}

		public Button E_Button_BlackRemoveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_BlackRemoveButton == null )
     			{
		    		this.m_E_Button_BlackRemoveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackRemove");
     			}
     			return this.m_E_Button_BlackRemoveButton;
     		}
     	}

		public Image E_Button_BlackRemoveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_BlackRemoveImage == null )
     			{
		    		this.m_E_Button_BlackRemoveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackRemove");
     			}
     			return this.m_E_Button_BlackRemoveImage;
     		}
     	}

		public Button E_Button_UnionTransferButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionTransferButton == null )
     			{
		    		this.m_E_Button_UnionTransferButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionTransfer");
     			}
     			return this.m_E_Button_UnionTransferButton;
     		}
     	}

		public Image E_Button_UnionTransferImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionTransferImage == null )
     			{
		    		this.m_E_Button_UnionTransferImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionTransfer");
     			}
     			return this.m_E_Button_UnionTransferImage;
     		}
     	}

		public Button E_Button_UnionAiderButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionAiderButton == null )
     			{
		    		this.m_E_Button_UnionAiderButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionAider");
     			}
     			return this.m_E_Button_UnionAiderButton;
     		}
     	}

		public Image E_Button_UnionAiderImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionAiderImage == null )
     			{
		    		this.m_E_Button_UnionAiderImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionAider");
     			}
     			return this.m_E_Button_UnionAiderImage;
     		}
     	}

		public Button E_Button_UnionElderButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionElderButton == null )
     			{
		    		this.m_E_Button_UnionElderButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionElder");
     			}
     			return this.m_E_Button_UnionElderButton;
     		}
     	}

		public Image E_Button_UnionElderImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionElderImage == null )
     			{
		    		this.m_E_Button_UnionElderImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionElder");
     			}
     			return this.m_E_Button_UnionElderImage;
     		}
     	}

		public Button E_Button_UnionDismissButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionDismissButton == null )
     			{
		    		this.m_E_Button_UnionDismissButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionDismiss");
     			}
     			return this.m_E_Button_UnionDismissButton;
     		}
     	}

		public Image E_Button_UnionDismissImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UnionDismissImage == null )
     			{
		    		this.m_E_Button_UnionDismissImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionDismiss");
     			}
     			return this.m_E_Button_UnionDismissImage;
     		}
     	}

		public Button E_Button_OneChallengeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OneChallengeButton == null )
     			{
		    		this.m_E_Button_OneChallengeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_OneChallenge");
     			}
     			return this.m_E_Button_OneChallengeButton;
     		}
     	}

		public Image E_Button_OneChallengeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OneChallengeImage == null )
     			{
		    		this.m_E_Button_OneChallengeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_OneChallenge");
     			}
     			return this.m_E_Button_OneChallengeImage;
     		}
     	}

		public Button E_Button_ServerBlackButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ServerBlackButton == null )
     			{
		    		this.m_E_Button_ServerBlackButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ServerBlack");
     			}
     			return this.m_E_Button_ServerBlackButton;
     		}
     	}

		public Image E_Button_ServerBlackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ServerBlackImage == null )
     			{
		    		this.m_E_Button_ServerBlackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ServerBlack");
     			}
     			return this.m_E_Button_ServerBlackImage;
     		}
     	}

		public Button E_Button_JinYanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_JinYanButton == null )
     			{
		    		this.m_E_Button_JinYanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_JinYan");
     			}
     			return this.m_E_Button_JinYanButton;
     		}
     	}

		public Image E_Button_JinYanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_JinYanImage == null )
     			{
		    		this.m_E_Button_JinYanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_JinYan");
     			}
     			return this.m_E_Button_JinYanImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageBgButton = null;
			this.m_E_ImageBgImage = null;
			this.m_E_ImageDiImage = null;
			this.m_EG_PositionSetRectTransform = null;
			this.m_E_Button_WatchButton = null;
			this.m_E_Button_WatchImage = null;
			this.m_E_Button_InviteTeamButton = null;
			this.m_E_Button_InviteTeamImage = null;
			this.m_E_Button_AddFriendButton = null;
			this.m_E_Button_AddFriendImage = null;
			this.m_E_Button_KickTeamButton = null;
			this.m_E_Button_KickTeamImage = null;
			this.m_E_Button_LeaveTeamButton = null;
			this.m_E_Button_LeaveTeamImage = null;
			this.m_E_Button_ApplyTeamButton = null;
			this.m_E_Button_ApplyTeamImage = null;
			this.m_E_Button_InviteUnionButton = null;
			this.m_E_Button_InviteUnionImage = null;
			this.m_E_Button_KickUnionButton = null;
			this.m_E_Button_KickUnionImage = null;
			this.m_E_Button_BlackAddButton = null;
			this.m_E_Button_BlackAddImage = null;
			this.m_E_Button_BlackRemoveButton = null;
			this.m_E_Button_BlackRemoveImage = null;
			this.m_E_Button_UnionTransferButton = null;
			this.m_E_Button_UnionTransferImage = null;
			this.m_E_Button_UnionAiderButton = null;
			this.m_E_Button_UnionAiderImage = null;
			this.m_E_Button_UnionElderButton = null;
			this.m_E_Button_UnionElderImage = null;
			this.m_E_Button_UnionDismissButton = null;
			this.m_E_Button_UnionDismissImage = null;
			this.m_E_Button_OneChallengeButton = null;
			this.m_E_Button_OneChallengeImage = null;
			this.m_E_Button_ServerBlackButton = null;
			this.m_E_Button_ServerBlackImage = null;
			this.m_E_Button_JinYanButton = null;
			this.m_E_Button_JinYanImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageBgButton = null;
		private Image m_E_ImageBgImage = null;
		private Image m_E_ImageDiImage = null;
		private RectTransform m_EG_PositionSetRectTransform = null;
		private Button m_E_Button_WatchButton = null;
		private Image m_E_Button_WatchImage = null;
		private Button m_E_Button_InviteTeamButton = null;
		private Image m_E_Button_InviteTeamImage = null;
		private Button m_E_Button_AddFriendButton = null;
		private Image m_E_Button_AddFriendImage = null;
		private Button m_E_Button_KickTeamButton = null;
		private Image m_E_Button_KickTeamImage = null;
		private Button m_E_Button_LeaveTeamButton = null;
		private Image m_E_Button_LeaveTeamImage = null;
		private Button m_E_Button_ApplyTeamButton = null;
		private Image m_E_Button_ApplyTeamImage = null;
		private Button m_E_Button_InviteUnionButton = null;
		private Image m_E_Button_InviteUnionImage = null;
		private Button m_E_Button_KickUnionButton = null;
		private Image m_E_Button_KickUnionImage = null;
		private Button m_E_Button_BlackAddButton = null;
		private Image m_E_Button_BlackAddImage = null;
		private Button m_E_Button_BlackRemoveButton = null;
		private Image m_E_Button_BlackRemoveImage = null;
		private Button m_E_Button_UnionTransferButton = null;
		private Image m_E_Button_UnionTransferImage = null;
		private Button m_E_Button_UnionAiderButton = null;
		private Image m_E_Button_UnionAiderImage = null;
		private Button m_E_Button_UnionElderButton = null;
		private Image m_E_Button_UnionElderImage = null;
		private Button m_E_Button_UnionDismissButton = null;
		private Image m_E_Button_UnionDismissImage = null;
		private Button m_E_Button_OneChallengeButton = null;
		private Image m_E_Button_OneChallengeImage = null;
		private Button m_E_Button_ServerBlackButton = null;
		private Image m_E_Button_ServerBlackImage = null;
		private Button m_E_Button_JinYanButton = null;
		private Image m_E_Button_JinYanImage = null;
		public Transform uiTransform = null;
	}
}
