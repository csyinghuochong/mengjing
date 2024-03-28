
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetXiLian : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"DoMove/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiLianButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianButton == null )
     			{
		    		this.m_E_Btn_XiLianButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"DoMove/E_Btn_XiLian");
     			}
     			return this.m_E_Btn_XiLianButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiLianImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianImage == null )
     			{
		    		this.m_E_Btn_XiLianImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMove/E_Btn_XiLian");
     			}
     			return this.m_E_Btn_XiLianImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ItemQualityImage == null )
     			{
		    		this.m_E_Img_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMove/E_Img_ItemQuality");
     			}
     			return this.m_E_Img_ItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ItemIconImage == null )
     			{
		    		this.m_E_Img_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"DoMove/E_Img_ItemIcon");
     			}
     			return this.m_E_Img_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ItemNameText == null )
     			{
		    		this.m_E_Text_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"DoMove/E_Text_ItemName");
     			}
     			return this.m_E_Text_ItemNameText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_XiLianButton = null;
			this.m_E_Btn_XiLianImage = null;
			this.m_E_Img_ItemQualityImage = null;
			this.m_E_Img_ItemIconImage = null;
			this.m_E_Text_ItemNameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_XiLianButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiLianImage = null;
		private UnityEngine.UI.Image m_E_Img_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_Img_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_Text_ItemNameText = null;
		public Transform uiTransform = null;
	}
}
