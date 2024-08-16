using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWearWeapon))]
	[EnableMethod]
	public  class DlgWearWeaponViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImgCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImgCloseButton == null )
     			{
		    		this.m_E_ImgCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImgClose");
     			}
     			return this.m_E_ImgCloseButton;
     		}
     	}

		public Image E_ImgCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImgCloseImage == null )
     			{
		    		this.m_E_ImgCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImgClose");
     			}
     			return this.m_E_ImgCloseImage;
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Text E_TextTip3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTip3Text == null )
     			{
		    		this.m_E_TextTip3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextTip3");
     			}
     			return this.m_E_TextTip3Text;
     		}
     	}

		public Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImgCloseButton = null;
			this.m_E_ImgCloseImage = null;
			this.m_es_modelshow = null;
			this.m_E_TextTip3Text = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImgCloseButton = null;
		private Image m_E_ImgCloseImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Text m_E_TextTip3Text = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
