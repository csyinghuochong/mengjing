
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetFormation))]
	[EnableMethod]
	public  class DlgPetFormationViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_PetFormationItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetFormationItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetFormationItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetFormationItems");
     			}
     			return this.m_E_PetFormationItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonConfirmButton == null )
     			{
		    		this.m_E_ButtonConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonConfirmImage == null )
     			{
		    		this.m_E_ButtonConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonChallengeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonChallengeButton == null )
     			{
		    		this.m_E_ButtonChallengeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonChallenge");
     			}
     			return this.m_E_ButtonChallengeButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonChallengeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonChallengeImage == null )
     			{
		    		this.m_E_ButtonChallengeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonChallenge");
     			}
     			return this.m_E_ButtonChallengeImage;
     		}
     	}

		public UnityEngine.UI.Image E_IconItemDragImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconItemDragImage == null )
     			{
		    		this.m_E_IconItemDragImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_IconItemDrag");
     			}
     			return this.m_E_IconItemDragImage;
     		}
     	}

		public UnityEngine.RectTransform EG_FormationNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FormationNodeRectTransform == null )
     			{
		    		this.m_EG_FormationNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_FormationNode");
     			}
     			return this.m_EG_FormationNodeRectTransform;
     		}
     	}

		public ES_PetFormationSet ES_PetFormationSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_petformationset ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_FormationNode/ES_PetFormationSet");
		    	   this.m_es_petformationset = this.AddChild<ES_PetFormationSet,Transform>(subTrans);
     			}
     			return this.m_es_petformationset;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonButton == null )
     			{
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonImage == null )
     			{
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNumberText == null )
     			{
		    		this.m_E_TextNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextNumber");
     			}
     			return this.m_E_TextNumberText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PetFormationItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonConfirmButton = null;
			this.m_E_ButtonConfirmImage = null;
			this.m_E_ButtonChallengeButton = null;
			this.m_E_ButtonChallengeImage = null;
			this.m_E_IconItemDragImage = null;
			this.m_EG_FormationNodeRectTransform = null;
			this.m_es_petformationset = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_TextNumberText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetFormationItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonConfirmButton = null;
		private UnityEngine.UI.Image m_E_ButtonConfirmImage = null;
		private UnityEngine.UI.Button m_E_ButtonChallengeButton = null;
		private UnityEngine.UI.Image m_E_ButtonChallengeImage = null;
		private UnityEngine.UI.Image m_E_IconItemDragImage = null;
		private UnityEngine.RectTransform m_EG_FormationNodeRectTransform = null;
		private EntityRef<ES_PetFormationSet> m_es_petformationset = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.Text m_E_TextNumberText = null;
		public Transform uiTransform = null;
	}
}
