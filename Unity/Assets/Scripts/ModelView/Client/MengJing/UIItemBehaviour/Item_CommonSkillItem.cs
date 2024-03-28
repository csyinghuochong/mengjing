
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CommonSkillItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public string SkillAtlas;
		public int SkillId;
		public string addTip;
		public bool UnActive;
		public int HaveSkillNum = 0;
		public Action<int> SelectAction;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CommonSkillItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_ImageKuangImage
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
     				if( this.m_E_ImageKuangImage == null )
     				{
		    			this.m_E_ImageKuangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageKuang");
     				}
     				return this.m_E_ImageKuangImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageKuang");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageIconImage
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
     				if( this.m_E_ImageIconImage == null )
     				{
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ImageIconEventTrigger
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
     				if( this.m_E_ImageIconEventTrigger == null )
     				{
		    			this.m_E_ImageIconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     				}
     				return this.m_E_ImageIconEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_NewSkillHintImage
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
     				if( this.m_E_NewSkillHintImage == null )
     				{
		    			this.m_E_NewSkillHintImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     				}
     				return this.m_E_NewSkillHintImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_NewSkillHintEventTrigger
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
     				if( this.m_E_NewSkillHintEventTrigger == null )
     				{
		    			this.m_E_NewSkillHintEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     				}
     				return this.m_E_NewSkillHintEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextSkillNameText
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
     				if( this.m_E_TextSkillNameText == null )
     				{
		    			this.m_E_TextSkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextSkillName");
     				}
     				return this.m_E_TextSkillNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextSkillName");
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
		    			this.m_E_BorderImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BorderImg");
     				}
     				return this.m_E_BorderImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BorderImg");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_LockImage
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
     				if( this.m_E_Image_LockImage == null )
     				{
		    			this.m_E_Image_LockImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_Lock");
     				}
     				return this.m_E_Image_LockImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Image_Lock");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageKuangImage = null;
			this.m_E_ImageIconImage = null;
			this.m_E_ImageIconEventTrigger = null;
			this.m_E_NewSkillHintImage = null;
			this.m_E_NewSkillHintEventTrigger = null;
			this.m_E_TextSkillNameText = null;
			this.m_E_BorderImgImage = null;
			this.m_E_Image_LockImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_ImageKuangImage = null;
		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ImageIconEventTrigger = null;
		private UnityEngine.UI.Image m_E_NewSkillHintImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_NewSkillHintEventTrigger = null;
		private UnityEngine.UI.Text m_E_TextSkillNameText = null;
		private UnityEngine.UI.Image m_E_BorderImgImage = null;
		private UnityEngine.UI.Image m_E_Image_LockImage = null;
		public Transform uiTransform = null;
	}
}
