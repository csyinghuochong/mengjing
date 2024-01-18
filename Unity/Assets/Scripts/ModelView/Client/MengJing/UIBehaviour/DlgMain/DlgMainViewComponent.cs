
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMain))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ShrinkButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShrinkButton == null )
     			{
		    		this.m_E_ShrinkButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/E_Shrink");
     			}
     			return this.m_E_ShrinkButton;
     		}
     	}

		public UnityEngine.UI.Image E_ShrinkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShrinkImage == null )
     			{
		    		this.m_E_ShrinkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/E_Shrink");
     			}
     			return this.m_E_ShrinkImage;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftBottomBtnsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftBottomBtnsRectTransform == null )
     			{
		    		this.m_EG_LeftBottomBtnsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns");
     			}
     			return this.m_EG_LeftBottomBtnsRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_RoseEquipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseEquipButton == null )
     			{
		    		this.m_E_RoseEquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipButton;
     		}
     	}

		public UnityEngine.UI.Image E_RoseEquipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseEquipImage == null )
     			{
		    		this.m_E_RoseEquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseEquip");
     			}
     			return this.m_E_RoseEquipImage;
     		}
     	}

		public UnityEngine.UI.Button E_PetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetButton == null )
     			{
		    		this.m_E_PetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Pet");
     			}
     			return this.m_E_PetButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetImage == null )
     			{
		    		this.m_E_PetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Pet");
     			}
     			return this.m_E_PetImage;
     		}
     	}

		public UnityEngine.UI.Button E_RoseSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseSkillButton == null )
     			{
		    		this.m_E_RoseSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_RoseSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoseSkillImage == null )
     			{
		    		this.m_E_RoseSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_RoseSkill");
     			}
     			return this.m_E_RoseSkillImage;
     		}
     	}

		public UnityEngine.UI.Button E_TaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskButton == null )
     			{
		    		this.m_E_TaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Task");
     			}
     			return this.m_E_TaskButton;
     		}
     	}

		public UnityEngine.UI.Image E_TaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskImage == null )
     			{
		    		this.m_E_TaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Task");
     			}
     			return this.m_E_TaskImage;
     		}
     	}

		public UnityEngine.UI.Button E_FriendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendButton == null )
     			{
		    		this.m_E_FriendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Friend");
     			}
     			return this.m_E_FriendButton;
     		}
     	}

		public UnityEngine.UI.Image E_FriendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendImage == null )
     			{
		    		this.m_E_FriendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_Friend");
     			}
     			return this.m_E_FriendImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChengJiuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuButton == null )
     			{
		    		this.m_E_ChengJiuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChengJiuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuImage == null )
     			{
		    		this.m_E_ChengJiuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMoveBottom/EG_LeftBottomBtns/E_ChengJiu");
     			}
     			return this.m_E_ChengJiuImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ShrinkButton = null;
			this.m_E_ShrinkImage = null;
			this.m_EG_LeftBottomBtnsRectTransform = null;
			this.m_E_RoseEquipButton = null;
			this.m_E_RoseEquipImage = null;
			this.m_E_PetButton = null;
			this.m_E_PetImage = null;
			this.m_E_RoseSkillButton = null;
			this.m_E_RoseSkillImage = null;
			this.m_E_TaskButton = null;
			this.m_E_TaskImage = null;
			this.m_E_FriendButton = null;
			this.m_E_FriendImage = null;
			this.m_E_ChengJiuButton = null;
			this.m_E_ChengJiuImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ShrinkButton = null;
		private UnityEngine.UI.Image m_E_ShrinkImage = null;
		private UnityEngine.RectTransform m_EG_LeftBottomBtnsRectTransform = null;
		private UnityEngine.UI.Button m_E_RoseEquipButton = null;
		private UnityEngine.UI.Image m_E_RoseEquipImage = null;
		private UnityEngine.UI.Button m_E_PetButton = null;
		private UnityEngine.UI.Image m_E_PetImage = null;
		private UnityEngine.UI.Button m_E_RoseSkillButton = null;
		private UnityEngine.UI.Image m_E_RoseSkillImage = null;
		private UnityEngine.UI.Button m_E_TaskButton = null;
		private UnityEngine.UI.Image m_E_TaskImage = null;
		private UnityEngine.UI.Button m_E_FriendButton = null;
		private UnityEngine.UI.Image m_E_FriendImage = null;
		private UnityEngine.UI.Button m_E_ChengJiuButton = null;
		private UnityEngine.UI.Image m_E_ChengJiuImage = null;
		public Transform uiTransform = null;
	}
}
