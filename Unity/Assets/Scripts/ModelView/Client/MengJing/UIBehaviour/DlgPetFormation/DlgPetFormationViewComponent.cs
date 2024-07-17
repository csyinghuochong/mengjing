using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetFormation))]
	[EnableMethod]
	public  class DlgPetFormationViewComponent : Entity,IAwake,IDestroy 
	{
		public LoopVerticalScrollRect E_PetFormationItemsLoopVerticalScrollRect
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
		    		this.m_E_PetFormationItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetFormationItems");
     			}
     			return this.m_E_PetFormationItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonConfirmButton
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
		    		this.m_E_ButtonConfirmButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmButton;
     		}
     	}

		public Image E_ButtonConfirmImage
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
		    		this.m_E_ButtonConfirmImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmImage;
     		}
     	}

		public Button E_ButtonChallengeButton
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
		    		this.m_E_ButtonChallengeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonChallenge");
     			}
     			return this.m_E_ButtonChallengeButton;
     		}
     	}

		public Image E_ButtonChallengeImage
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
		    		this.m_E_ButtonChallengeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonChallenge");
     			}
     			return this.m_E_ButtonChallengeImage;
     		}
     	}

		public Image E_IconItemDragImage
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
		    		this.m_E_IconItemDragImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_IconItemDrag");
     			}
     			return this.m_E_IconItemDragImage;
     		}
     	}

		public RectTransform EG_FormationNodeRectTransform
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
		    		this.m_EG_FormationNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_FormationNode");
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

		        ES_PetFormationSet es = this.m_es_petformationset;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_FormationNode/ES_PetFormationSet");
		    	   this.m_es_petformationset = this.AddChild<ES_PetFormationSet,Transform>(subTrans);
     			}
     			return this.m_es_petformationset;
     		}
     	}

		public Button E_CloseButtonButton
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
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonButton;
     		}
     	}

		public Image E_CloseButtonImage
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
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public Text E_TextNumberText
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
		    		this.m_E_TextNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextNumber");
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

		private LoopVerticalScrollRect m_E_PetFormationItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonConfirmButton = null;
		private Image m_E_ButtonConfirmImage = null;
		private Button m_E_ButtonChallengeButton = null;
		private Image m_E_ButtonChallengeImage = null;
		private Image m_E_IconItemDragImage = null;
		private RectTransform m_EG_FormationNodeRectTransform = null;
		private EntityRef<ES_PetFormationSet> m_es_petformationset = null;
		private Button m_E_CloseButtonButton = null;
		private Image m_E_CloseButtonImage = null;
		private Text m_E_TextNumberText = null;
		public Transform uiTransform = null;
	}
}
