
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SkillSetItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public GameObject Img_SkillIconDi_Copy;
		public Vector2 localPoint;
		public SkillPro SkillPro;
		public bool canDrag = true;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SkillSetItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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

		public UnityEngine.UI.Button E_Img_SkillIconButton
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
     				if( this.m_E_Img_SkillIconButton == null )
     				{
		    			this.m_E_Img_SkillIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Img_SkillIcon");
     				}
     				return this.m_E_Img_SkillIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Img_SkillIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_SkillIconImage
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
     				if( this.m_E_Img_SkillIconImage == null )
     				{
		    			this.m_E_Img_SkillIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Img_SkillIcon");
     				}
     				return this.m_E_Img_SkillIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Img_SkillIcon");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Img_SkillIconEventTrigger
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
     				if( this.m_E_Img_SkillIconEventTrigger == null )
     				{
		    			this.m_E_Img_SkillIconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Img_SkillIcon");
     				}
     				return this.m_E_Img_SkillIconEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Img_SkillIconDi/E_Img_SkillIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillNameText
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
     				if( this.m_E_Lab_SkillNameText == null )
     				{
		    			this.m_E_Lab_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_SkillName");
     				}
     				return this.m_E_Lab_SkillNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_SkillName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SkillLvText
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
     				if( this.m_E_Lab_SkillLvText == null )
     				{
		    			this.m_E_Lab_SkillLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_SkillLv");
     				}
     				return this.m_E_Lab_SkillLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_SkillLv");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Img_SkillIconDiImage = null;
			this.m_E_Img_SkillIconButton = null;
			this.m_E_Img_SkillIconImage = null;
			this.m_E_Img_SkillIconEventTrigger = null;
			this.m_E_Lab_SkillNameText = null;
			this.m_E_Lab_SkillLvText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_Img_SkillIconDiImage = null;
		private UnityEngine.UI.Button m_E_Img_SkillIconButton = null;
		private UnityEngine.UI.Image m_E_Img_SkillIconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Img_SkillIconEventTrigger = null;
		private UnityEngine.UI.Text m_E_Lab_SkillNameText = null;
		private UnityEngine.UI.Text m_E_Lab_SkillLvText = null;
		public Transform uiTransform = null;
	}
}
