using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CommonSkillItem : Entity,IAwake<Transform>,IDestroy 
	{
		public string SkillAtlas;
		public int SkillId;
		public string addTip;
		public bool UnActive;
		public int HaveSkillNum = 0;
		public Action<int> SelectAction;
        		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		
		public Image E_ImageKuangImage
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
		    			this.m_E_ImageKuangImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageKuang");
     				}
     				return this.m_E_ImageKuangImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageKuang");
     			}
     		}
     	}

		public Image E_ImageIconImage
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
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     			}
     		}
     	}

		public EventTrigger E_ImageIconEventTrigger
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
		    			this.m_E_ImageIconEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     				}
     				return this.m_E_ImageIconEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_ImageIcon");
     			}
     		}
     	}

		public Image E_NewSkillHintImage
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
		    			this.m_E_NewSkillHintImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     				}
     				return this.m_E_NewSkillHintImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     			}
     		}
     	}

		public EventTrigger E_NewSkillHintEventTrigger
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
		    			this.m_E_NewSkillHintEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     				}
     				return this.m_E_NewSkillHintEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"ImageIconmask/E_NewSkillHint");
     			}
     		}
     	}

		public Text E_TextSkillNameText
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
		    			this.m_E_TextSkillNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextSkillName");
     				}
     				return this.m_E_TextSkillNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextSkillName");
     			}
     		}
     	}

		public Image E_BorderImgImage
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
		    			this.m_E_BorderImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BorderImg");
     				}
     				return this.m_E_BorderImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BorderImg");
     			}
     		}
     	}

		public Image E_Image_LockImage
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
		    			this.m_E_Image_LockImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Lock");
     				}
     				return this.m_E_Image_LockImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Lock");
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

		private Image m_E_ImageKuangImage = null;
		private Image m_E_ImageIconImage = null;
		private EventTrigger m_E_ImageIconEventTrigger = null;
		private Image m_E_NewSkillHintImage = null;
		private EventTrigger m_E_NewSkillHintEventTrigger = null;
		private Text m_E_TextSkillNameText = null;
		private Image m_E_BorderImgImage = null;
		private Image m_E_Image_LockImage = null;
		public Transform uiTransform = null;
	}
}
