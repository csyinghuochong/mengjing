
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_UnionMyItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public UnionPlayerInfo CurPlayerInfo;
		public UnionInfo UnionInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_UnionMyItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageButtonButton == null )
     				{
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageButtonImage == null )
     				{
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_PositionText
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
     				if( this.m_E_Text_PositionText == null )
     				{
		    			this.m_E_Text_PositionText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Position");
     				}
     				return this.m_E_Text_PositionText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Position");
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

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Text_PositionText = null;
			this.m_E_Text_LevelText = null;
			this.m_E_Text_NameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Text m_E_Text_PositionText = null;
		private UnityEngine.UI.Text m_E_Text_LevelText = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		public Transform uiTransform = null;
	}
}
