
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTaskGet))]
	[EnableMethod]
	public  class DlgTaskGetViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Img_buttonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_buttonButton == null )
     			{
		    		this.m_E_Img_buttonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Img_buttonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_buttonImage == null )
     			{
		    		this.m_E_Img_buttonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NpcNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NpcNameText == null )
     			{
		    		this.m_E_Lab_NpcNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_NpcName");
     			}
     			return this.m_E_Lab_NpcNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NpcSpeakText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NpcSpeakText == null )
     			{
		    		this.m_E_Lab_NpcSpeakText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_NpcSpeak");
     			}
     			return this.m_E_Lab_NpcSpeakText;
     		}
     	}

		public UnityEngine.UI.Image E_TaskGetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGetItemsImage == null )
     			{
		    		this.m_E_TaskGetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems");
     			}
     			return this.m_E_TaskGetItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_TaskGetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskGetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TaskGetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_TaskGetItems");
     			}
     			return this.m_E_TaskGetItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_TaskGetItems/Content/Item_TaskGetItem/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/Content/Item_TaskGetItem/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
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
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/Content/Item_TaskGetItem/E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/Content/Item_TaskGetItem/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageCompleteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCompleteImage == null )
     			{
		    		this.m_E_ImageCompleteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/Content/Item_TaskGetItem/E_ImageComplete");
     			}
     			return this.m_E_ImageCompleteImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageNotRecvImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageNotRecvImage == null )
     			{
		    		this.m_E_ImageNotRecvImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/Content/Item_TaskGetItem/E_ImageNotRecv");
     			}
     			return this.m_E_ImageNotRecvImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextTaskNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTaskNameText == null )
     			{
		    		this.m_E_TextTaskNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TaskGetItems/Content/Item_TaskGetItem/E_TextTaskName");
     			}
     			return this.m_E_TextTaskNameText;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetButton == null )
     			{
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_TaskGetItems/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetImage == null )
     			{
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public UnityEngine.UI.Button E_BtnCommitTask1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCommitTask1Button == null )
     			{
		    		this.m_E_BtnCommitTask1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_TaskGetItems/E_BtnCommitTask1");
     			}
     			return this.m_E_BtnCommitTask1Button;
     		}
     	}

		public UnityEngine.UI.Image E_BtnCommitTask1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCommitTask1Image == null )
     			{
		    		this.m_E_BtnCommitTask1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/E_BtnCommitTask1");
     			}
     			return this.m_E_BtnCommitTask1Image;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGiveTaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGiveTaskButton == null )
     			{
		    		this.m_E_ButtonGiveTaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_TaskGetItems/E_ButtonGiveTask");
     			}
     			return this.m_E_ButtonGiveTaskButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGiveTaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGiveTaskImage == null )
     			{
		    		this.m_E_ButtonGiveTaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_TaskGetItems/E_ButtonGiveTask");
     			}
     			return this.m_E_ButtonGiveTaskImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonJieRiRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJieRiRewardButton == null )
     			{
		    		this.m_E_ButtonJieRiRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonJieRiReward");
     			}
     			return this.m_E_ButtonJieRiRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonJieRiRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJieRiRewardImage == null )
     			{
		    		this.m_E_ButtonJieRiRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonJieRiReward");
     			}
     			return this.m_E_ButtonJieRiRewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonExpDuiHuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonExpDuiHuanButton == null )
     			{
		    		this.m_E_ButtonExpDuiHuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonExpDuiHuan");
     			}
     			return this.m_E_ButtonExpDuiHuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonExpDuiHuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonExpDuiHuanImage == null )
     			{
		    		this.m_E_ButtonExpDuiHuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonExpDuiHuan");
     			}
     			return this.m_E_ButtonExpDuiHuanImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonPetFragmentButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPetFragmentButton == null )
     			{
		    		this.m_E_ButtonPetFragmentButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonPetFragment");
     			}
     			return this.m_E_ButtonPetFragmentButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonPetFragmentImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPetFragmentImage == null )
     			{
		    		this.m_E_ButtonPetFragmentImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonPetFragment");
     			}
     			return this.m_E_ButtonPetFragmentImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonMysteryButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMysteryButton == null )
     			{
		    		this.m_E_ButtonMysteryButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonMystery");
     			}
     			return this.m_E_ButtonMysteryButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMysteryImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMysteryImage == null )
     			{
		    		this.m_E_ButtonMysteryImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonMystery");
     			}
     			return this.m_E_ButtonMysteryImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_buttonButton = null;
			this.m_E_Img_buttonImage = null;
			this.m_E_Lab_NpcNameText = null;
			this.m_E_Lab_NpcSpeakText = null;
			this.m_E_TaskGetItemsImage = null;
			this.m_E_TaskGetItemsLoopVerticalScrollRect = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_ImageDiImage = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_ImageCompleteImage = null;
			this.m_E_ImageNotRecvImage = null;
			this.m_E_TextTaskNameText = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.m_E_BtnCommitTask1Button = null;
			this.m_E_BtnCommitTask1Image = null;
			this.m_E_ButtonGiveTaskButton = null;
			this.m_E_ButtonGiveTaskImage = null;
			this.m_E_ButtonJieRiRewardButton = null;
			this.m_E_ButtonJieRiRewardImage = null;
			this.m_E_ButtonExpDuiHuanButton = null;
			this.m_E_ButtonExpDuiHuanImage = null;
			this.m_E_ButtonPetFragmentButton = null;
			this.m_E_ButtonPetFragmentImage = null;
			this.m_E_ButtonMysteryButton = null;
			this.m_E_ButtonMysteryImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Img_buttonButton = null;
		private UnityEngine.UI.Image m_E_Img_buttonImage = null;
		private UnityEngine.UI.Text m_E_Lab_NpcNameText = null;
		private UnityEngine.UI.Text m_E_Lab_NpcSpeakText = null;
		private UnityEngine.UI.Image m_E_TaskGetItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_TaskGetItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Image m_E_ImageDiImage = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Image m_E_ImageCompleteImage = null;
		private UnityEngine.UI.Image m_E_ImageNotRecvImage = null;
		private UnityEngine.UI.Text m_E_TextTaskNameText = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		private UnityEngine.UI.Button m_E_BtnCommitTask1Button = null;
		private UnityEngine.UI.Image m_E_BtnCommitTask1Image = null;
		private UnityEngine.UI.Button m_E_ButtonGiveTaskButton = null;
		private UnityEngine.UI.Image m_E_ButtonGiveTaskImage = null;
		private UnityEngine.UI.Button m_E_ButtonJieRiRewardButton = null;
		private UnityEngine.UI.Image m_E_ButtonJieRiRewardImage = null;
		private UnityEngine.UI.Button m_E_ButtonExpDuiHuanButton = null;
		private UnityEngine.UI.Image m_E_ButtonExpDuiHuanImage = null;
		private UnityEngine.UI.Button m_E_ButtonPetFragmentButton = null;
		private UnityEngine.UI.Image m_E_ButtonPetFragmentImage = null;
		private UnityEngine.UI.Button m_E_ButtonMysteryButton = null;
		private UnityEngine.UI.Image m_E_ButtonMysteryImage = null;
		public Transform uiTransform = null;
	}
}
