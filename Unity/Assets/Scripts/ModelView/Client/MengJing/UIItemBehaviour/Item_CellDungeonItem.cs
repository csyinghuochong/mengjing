
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CellDungeonItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_CellDungeonItem>
	{
		public int LevelId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CellDungeonItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text E_Lab_ChapSonNameOutText
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
     				if( this.m_E_Lab_ChapSonNameOutText == null )
     				{
		    			this.m_E_Lab_ChapSonNameOutText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"PostionSet/E_Lab_ChapSonNameOut");
     				}
     				return this.m_E_Lab_ChapSonNameOutText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"PostionSet/E_Lab_ChapSonNameOut");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_EnterLevelText
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
     				if( this.m_E_Lab_EnterLevelText == null )
     				{
		    			this.m_E_Lab_EnterLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"PostionSet/E_Lab_EnterLevel");
     				}
     				return this.m_E_Lab_EnterLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"PostionSet/E_Lab_EnterLevel");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageBossIconImage
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
     				if( this.m_E_ImageBossIconImage == null )
     				{
		    			this.m_E_ImageBossIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"PostionSet/E_ImageBossIcon");
     				}
     				return this.m_E_ImageBossIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"PostionSet/E_ImageBossIcon");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageButtonButton == null )
     				{
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"PostionSet/E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"PostionSet/E_ImageButton");
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
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"PostionSet/E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"PostionSet/E_ImageButton");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Lab_ChapSonNameOutText = null;
			this.m_E_Lab_EnterLevelText = null;
			this.m_E_ImageBossIconImage = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_Lab_ChapSonNameOutText = null;
		private UnityEngine.UI.Text m_E_Lab_EnterLevelText = null;
		private UnityEngine.UI.Image m_E_ImageBossIconImage = null;
		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		public Transform uiTransform = null;
	}
}
