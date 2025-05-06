
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgGuide))]
	[EnableMethod]
	public  class DlgGuideViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PositionSet/E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text1Text == null )
     			{
		    		this.m_E_Text1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PositionSet/E_Text1");
     			}
     			return this.m_E_Text1Text;
     		}
     	}

		public UnityEngine.RectTransform EG_TipRootRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TipRootRectTransform == null )
     			{
		    		this.m_EG_TipRootRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_TipRoot");
     			}
     			return this.m_EG_TipRootRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ShowLabSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowLabSetImage == null )
     			{
		    		this.m_E_ShowLabSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_TipRoot/E_ShowLabSet");
     			}
     			return this.m_E_ShowLabSetImage;
     		}
     	}

		public UnityEngine.UI.Text E_ShowLabText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowLabText == null )
     			{
		    		this.m_E_ShowLabText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_TipRoot/E_ShowLabSet/E_ShowLab");
     			}
     			return this.m_E_ShowLabText;
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_TipRoot/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PositionSetRectTransform = null;
			this.m_E_ImageDiImage = null;
			this.m_E_Text1Text = null;
			this.m_EG_TipRootRectTransform = null;
			this.m_E_ShowLabSetImage = null;
			this.m_E_ShowLabText = null;
			this.m_E_ImageButtonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PositionSetRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageDiImage = null;
		private UnityEngine.UI.Text m_E_Text1Text = null;
		private UnityEngine.RectTransform m_EG_TipRootRectTransform = null;
		private UnityEngine.UI.Image m_E_ShowLabSetImage = null;
		private UnityEngine.UI.Text m_E_ShowLabText = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		public Transform uiTransform = null;
	}
}
