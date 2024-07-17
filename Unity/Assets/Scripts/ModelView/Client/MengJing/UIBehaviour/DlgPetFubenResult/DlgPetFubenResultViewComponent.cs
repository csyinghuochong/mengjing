using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetFubenResult))]
	[EnableMethod]
	public  class DlgPetFubenResultViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_Img_Star_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Star_1Image == null )
     			{
		    		this.m_E_Img_Star_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Star_1");
     			}
     			return this.m_E_Img_Star_1Image;
     		}
     	}

		public Image E_Img_Star_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Star_2Image == null )
     			{
		    		this.m_E_Img_Star_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Star_2");
     			}
     			return this.m_E_Img_Star_2Image;
     		}
     	}

		public Image E_Img_Star_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Star_3Image == null )
     			{
		    		this.m_E_Img_Star_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_Star_3");
     			}
     			return this.m_E_Img_Star_3Image;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_Button_exitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_exitButton == null )
     			{
		    		this.m_E_Button_exitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"buttonlistnode/E_Button_exit");
     			}
     			return this.m_E_Button_exitButton;
     		}
     	}

		public Image E_Button_exitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_exitImage == null )
     			{
		    		this.m_E_Button_exitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"buttonlistnode/E_Button_exit");
     			}
     			return this.m_E_Button_exitImage;
     		}
     	}

		public Button E_Button_continueButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_continueButton == null )
     			{
		    		this.m_E_Button_continueButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"buttonlistnode/E_Button_continue");
     			}
     			return this.m_E_Button_continueButton;
     		}
     	}

		public Image E_Button_continueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_continueImage == null )
     			{
		    		this.m_E_Button_continueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"buttonlistnode/E_Button_continue");
     			}
     			return this.m_E_Button_continueImage;
     		}
     	}

		public Button E_Button_nextButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_nextButton == null )
     			{
		    		this.m_E_Button_nextButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"buttonlistnode/E_Button_next");
     			}
     			return this.m_E_Button_nextButton;
     		}
     	}

		public Image E_Button_nextImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_nextImage == null )
     			{
		    		this.m_E_Button_nextImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"buttonlistnode/E_Button_next");
     			}
     			return this.m_E_Button_nextImage;
     		}
     	}

		public Text E_TextResultText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextResultText == null )
     			{
		    		this.m_E_TextResultText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextResult");
     			}
     			return this.m_E_TextResultText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_Star_1Image = null;
			this.m_E_Img_Star_2Image = null;
			this.m_E_Img_Star_3Image = null;
			this.m_es_rewardlist = null;
			this.m_E_Button_exitButton = null;
			this.m_E_Button_exitImage = null;
			this.m_E_Button_continueButton = null;
			this.m_E_Button_continueImage = null;
			this.m_E_Button_nextButton = null;
			this.m_E_Button_nextImage = null;
			this.m_E_TextResultText = null;
			this.uiTransform = null;
		}

		private Image m_E_Img_Star_1Image = null;
		private Image m_E_Img_Star_2Image = null;
		private Image m_E_Img_Star_3Image = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_Button_exitButton = null;
		private Image m_E_Button_exitImage = null;
		private Button m_E_Button_continueButton = null;
		private Image m_E_Button_continueImage = null;
		private Button m_E_Button_nextButton = null;
		private Image m_E_Button_nextImage = null;
		private Text m_E_TextResultText = null;
		public Transform uiTransform = null;
	}
}
