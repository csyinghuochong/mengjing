
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_UnionApplyListItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_UnionApplyListItem> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_UnionApplyListItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_ButtonRefuseButton
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
     				if( this.m_E_ButtonRefuseButton == null )
     				{
		    			this.m_E_ButtonRefuseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonRefuse");
     				}
     				return this.m_E_ButtonRefuseButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRefuseImage
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
     				if( this.m_E_ButtonRefuseImage == null )
     				{
		    			this.m_E_ButtonRefuseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonRefuse");
     				}
     				return this.m_E_ButtonRefuseImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonAgreeButton
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
     				if( this.m_E_ButtonAgreeButton == null )
     				{
		    			this.m_E_ButtonAgreeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonAgree");
     				}
     				return this.m_E_ButtonAgreeButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonAgreeImage
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
     				if( this.m_E_ButtonAgreeImage == null )
     				{
		    			this.m_E_ButtonAgreeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonAgree");
     				}
     				return this.m_E_ButtonAgreeImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_CombatText
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
     				if( this.m_E_Text_CombatText == null )
     				{
		    			this.m_E_Text_CombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Combat");
     				}
     				return this.m_E_Text_CombatText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Combat");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_LevelText
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
     				if( this.m_E_Text_LevelText == null )
     				{
		    			this.m_E_Text_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Level");
     				}
     				return this.m_E_Text_LevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Level");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_NameText
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
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_OccText
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
     				if( this.m_E_Text_OccText == null )
     				{
		    			this.m_E_Text_OccText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Occ");
     				}
     				return this.m_E_Text_OccText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Occ");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonRefuseButton = null;
			this.m_E_ButtonRefuseImage = null;
			this.m_E_ButtonAgreeButton = null;
			this.m_E_ButtonAgreeImage = null;
			this.m_E_Text_CombatText = null;
			this.m_E_Text_LevelText = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_OccText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ButtonRefuseButton = null;
		private UnityEngine.UI.Image m_E_ButtonRefuseImage = null;
		private UnityEngine.UI.Button m_E_ButtonAgreeButton = null;
		private UnityEngine.UI.Image m_E_ButtonAgreeImage = null;
		private UnityEngine.UI.Text m_E_Text_CombatText = null;
		private UnityEngine.UI.Text m_E_Text_LevelText = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_OccText = null;
		public Transform uiTransform = null;
	}
}
