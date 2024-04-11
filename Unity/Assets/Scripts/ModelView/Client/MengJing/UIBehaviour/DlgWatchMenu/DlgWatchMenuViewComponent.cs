
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgWatchMenu))]
	[EnableMethod]
	public  class DlgWatchMenuViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageBgButton
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
		    		this.m_E_ImageBgButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageBgImage
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
		    		this.m_E_ImageBgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageDiImage
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
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PositionSetRectTransform
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
		    		this.m_EG_PositionSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PositionSet");
     			}
     			return this.m_EG_PositionSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_WatchButton
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
		    		this.m_E_Button_WatchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Watch");
     			}
     			return this.m_E_Button_WatchButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_WatchImage
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
		    		this.m_E_Button_WatchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Watch");
     			}
     			return this.m_E_Button_WatchImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_InviteTeamButton
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
		    		this.m_E_Button_InviteTeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteTeam");
     			}
     			return this.m_E_Button_InviteTeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_InviteTeamImage
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
		    		this.m_E_Button_InviteTeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteTeam");
     			}
     			return this.m_E_Button_InviteTeamImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_AddFriendButton
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
		    		this.m_E_Button_AddFriendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_AddFriend");
     			}
     			return this.m_E_Button_AddFriendButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_AddFriendImage
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
		    		this.m_E_Button_AddFriendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_AddFriend");
     			}
     			return this.m_E_Button_AddFriendImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_KickTeamButton
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
		    		this.m_E_Button_KickTeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickTeam");
     			}
     			return this.m_E_Button_KickTeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_KickTeamImage
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
		    		this.m_E_Button_KickTeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickTeam");
     			}
     			return this.m_E_Button_KickTeamImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_LeaveTeamButton
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
		    		this.m_E_Button_LeaveTeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_LeaveTeam");
     			}
     			return this.m_E_Button_LeaveTeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_LeaveTeamImage
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
		    		this.m_E_Button_LeaveTeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_LeaveTeam");
     			}
     			return this.m_E_Button_LeaveTeamImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ApplyTeamButton
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
		    		this.m_E_Button_ApplyTeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ApplyTeam");
     			}
     			return this.m_E_Button_ApplyTeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ApplyTeamImage
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
		    		this.m_E_Button_ApplyTeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ApplyTeam");
     			}
     			return this.m_E_Button_ApplyTeamImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_InviteUnionButton
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
		    		this.m_E_Button_InviteUnionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteUnion");
     			}
     			return this.m_E_Button_InviteUnionButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_InviteUnionImage
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
		    		this.m_E_Button_InviteUnionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_InviteUnion");
     			}
     			return this.m_E_Button_InviteUnionImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_KickUnionButton
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
		    		this.m_E_Button_KickUnionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickUnion");
     			}
     			return this.m_E_Button_KickUnionButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_KickUnionImage
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
		    		this.m_E_Button_KickUnionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_KickUnion");
     			}
     			return this.m_E_Button_KickUnionImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_BlackAddButton
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
		    		this.m_E_Button_BlackAddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackAdd");
     			}
     			return this.m_E_Button_BlackAddButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_BlackAddImage
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
		    		this.m_E_Button_BlackAddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackAdd");
     			}
     			return this.m_E_Button_BlackAddImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_BlackRemoveButton
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
		    		this.m_E_Button_BlackRemoveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackRemove");
     			}
     			return this.m_E_Button_BlackRemoveButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_BlackRemoveImage
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
		    		this.m_E_Button_BlackRemoveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_BlackRemove");
     			}
     			return this.m_E_Button_BlackRemoveImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_UnionTransferButton
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
		    		this.m_E_Button_UnionTransferButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionTransfer");
     			}
     			return this.m_E_Button_UnionTransferButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_UnionTransferImage
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
		    		this.m_E_Button_UnionTransferImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionTransfer");
     			}
     			return this.m_E_Button_UnionTransferImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_UnionAiderButton
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
		    		this.m_E_Button_UnionAiderButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionAider");
     			}
     			return this.m_E_Button_UnionAiderButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_UnionAiderImage
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
		    		this.m_E_Button_UnionAiderImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionAider");
     			}
     			return this.m_E_Button_UnionAiderImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_UnionElderButton
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
		    		this.m_E_Button_UnionElderButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionElder");
     			}
     			return this.m_E_Button_UnionElderButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_UnionElderImage
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
		    		this.m_E_Button_UnionElderImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionElder");
     			}
     			return this.m_E_Button_UnionElderImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_UnionDismissButton
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
		    		this.m_E_Button_UnionDismissButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionDismiss");
     			}
     			return this.m_E_Button_UnionDismissButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_UnionDismissImage
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
		    		this.m_E_Button_UnionDismissImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_UnionDismiss");
     			}
     			return this.m_E_Button_UnionDismissImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_OneChallengeButton
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
		    		this.m_E_Button_OneChallengeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_OneChallenge");
     			}
     			return this.m_E_Button_OneChallengeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_OneChallengeImage
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
		    		this.m_E_Button_OneChallengeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_OneChallenge");
     			}
     			return this.m_E_Button_OneChallengeImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ServerBlackButton
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
		    		this.m_E_Button_ServerBlackButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ServerBlack");
     			}
     			return this.m_E_Button_ServerBlackButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ServerBlackImage
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
		    		this.m_E_Button_ServerBlackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_ServerBlack");
     			}
     			return this.m_E_Button_ServerBlackImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_JinYanButton
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
		    		this.m_E_Button_JinYanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_JinYan");
     			}
     			return this.m_E_Button_JinYanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_JinYanImage
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
		    		this.m_E_Button_JinYanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_JinYan");
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

		private UnityEngine.UI.Button m_E_ImageBgButton = null;
		private UnityEngine.UI.Image m_E_ImageBgImage = null;
		private UnityEngine.UI.Image m_E_ImageDiImage = null;
		private UnityEngine.RectTransform m_EG_PositionSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Button_WatchButton = null;
		private UnityEngine.UI.Image m_E_Button_WatchImage = null;
		private UnityEngine.UI.Button m_E_Button_InviteTeamButton = null;
		private UnityEngine.UI.Image m_E_Button_InviteTeamImage = null;
		private UnityEngine.UI.Button m_E_Button_AddFriendButton = null;
		private UnityEngine.UI.Image m_E_Button_AddFriendImage = null;
		private UnityEngine.UI.Button m_E_Button_KickTeamButton = null;
		private UnityEngine.UI.Image m_E_Button_KickTeamImage = null;
		private UnityEngine.UI.Button m_E_Button_LeaveTeamButton = null;
		private UnityEngine.UI.Image m_E_Button_LeaveTeamImage = null;
		private UnityEngine.UI.Button m_E_Button_ApplyTeamButton = null;
		private UnityEngine.UI.Image m_E_Button_ApplyTeamImage = null;
		private UnityEngine.UI.Button m_E_Button_InviteUnionButton = null;
		private UnityEngine.UI.Image m_E_Button_InviteUnionImage = null;
		private UnityEngine.UI.Button m_E_Button_KickUnionButton = null;
		private UnityEngine.UI.Image m_E_Button_KickUnionImage = null;
		private UnityEngine.UI.Button m_E_Button_BlackAddButton = null;
		private UnityEngine.UI.Image m_E_Button_BlackAddImage = null;
		private UnityEngine.UI.Button m_E_Button_BlackRemoveButton = null;
		private UnityEngine.UI.Image m_E_Button_BlackRemoveImage = null;
		private UnityEngine.UI.Button m_E_Button_UnionTransferButton = null;
		private UnityEngine.UI.Image m_E_Button_UnionTransferImage = null;
		private UnityEngine.UI.Button m_E_Button_UnionAiderButton = null;
		private UnityEngine.UI.Image m_E_Button_UnionAiderImage = null;
		private UnityEngine.UI.Button m_E_Button_UnionElderButton = null;
		private UnityEngine.UI.Image m_E_Button_UnionElderImage = null;
		private UnityEngine.UI.Button m_E_Button_UnionDismissButton = null;
		private UnityEngine.UI.Image m_E_Button_UnionDismissImage = null;
		private UnityEngine.UI.Button m_E_Button_OneChallengeButton = null;
		private UnityEngine.UI.Image m_E_Button_OneChallengeImage = null;
		private UnityEngine.UI.Button m_E_Button_ServerBlackButton = null;
		private UnityEngine.UI.Image m_E_Button_ServerBlackImage = null;
		private UnityEngine.UI.Button m_E_Button_JinYanButton = null;
		private UnityEngine.UI.Image m_E_Button_JinYanImage = null;
		public Transform uiTransform = null;
	}
}
