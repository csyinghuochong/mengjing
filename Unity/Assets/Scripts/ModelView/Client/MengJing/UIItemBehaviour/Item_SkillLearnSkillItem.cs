
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SkillLearnSkillItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SkillLearnSkillItem>
	{
		public SkillPro SkillPro;
		public Action<SkillPro> ClickHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SkillLearnSkillItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text E_SkillNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_SkillNameTextText == null )
     				{
		    			this.m_E_SkillNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_SkillNameText");
     				}
     				return this.m_E_SkillNameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_SkillNameText");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_SkillIconDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Img_SkillIconDiImage == null )
     				{
		    			this.m_E_Img_SkillIconDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi");
     				}
     				return this.m_E_Img_SkillIconDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_SkillIconImgButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_SkillIconImgButton == null )
     				{
		    			this.m_E_SkillIconImgButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_SkillIconImg");
     				}
     				return this.m_E_SkillIconImgButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_SkillIconImg");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_SkillIconImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_SkillIconImgImage == null )
     				{
		    			this.m_E_SkillIconImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_SkillIconImg");
     				}
     				return this.m_E_SkillIconImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_SkillIconImg");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_BorderImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_BorderImgImage == null )
     				{
		    			this.m_E_BorderImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_BorderImg");
     				}
     				return this.m_E_BorderImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_BorderImg");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ReddotImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ReddotImage == null )
     				{
		    			this.m_E_ReddotImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Reddot");
     				}
     				return this.m_E_ReddotImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Reddot");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SkillNameTextText = null;
			this.m_E_Img_SkillIconDiImage = null;
			this.m_E_SkillIconImgButton = null;
			this.m_E_SkillIconImgImage = null;
			this.m_E_BorderImgImage = null;
			this.m_E_ReddotImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_SkillNameTextText = null;
		private UnityEngine.UI.Image m_E_Img_SkillIconDiImage = null;
		private UnityEngine.UI.Button m_E_SkillIconImgButton = null;
		private UnityEngine.UI.Image m_E_SkillIconImgImage = null;
		private UnityEngine.UI.Image m_E_BorderImgImage = null;
		private UnityEngine.UI.Image m_E_ReddotImage = null;
		public Transform uiTransform = null;
	}
}
