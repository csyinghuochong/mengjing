
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SeasonTowerRankItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SeasonTowerRankItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text E_NuTextText
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
     				if( this.m_E_NuTextText == null )
     				{
		    			this.m_E_NuTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NuText");
     				}
     				return this.m_E_NuTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NuText");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_RankShowSetRectTransform
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
     				if( this.m_EG_RankShowSetRectTransform == null )
     				{
		    			this.m_EG_RankShowSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RankShowSet");
     				}
     				return this.m_EG_RankShowSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RankShowSet");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Rank_1Image
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
     				if( this.m_E_Rank_1Image == null )
     				{
		    			this.m_E_Rank_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_1");
     				}
     				return this.m_E_Rank_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_1");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Rank_2Image
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
     				if( this.m_E_Rank_2Image == null )
     				{
		    			this.m_E_Rank_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_2");
     				}
     				return this.m_E_Rank_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_2");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Rank_3Image
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
     				if( this.m_E_Rank_3Image == null )
     				{
		    			this.m_E_Rank_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_3");
     				}
     				return this.m_E_Rank_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_RankShowSet/E_Rank_3");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_NameTextText
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
     				if( this.m_E_NameTextText == null )
     				{
		    			this.m_E_NameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameText");
     				}
     				return this.m_E_NameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_LayerTextText
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
     				if( this.m_E_LayerTextText == null )
     				{
		    			this.m_E_LayerTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LayerText");
     				}
     				return this.m_E_LayerTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LayerText");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TimeTextText
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
     				if( this.m_E_TimeTextText == null )
     				{
		    			this.m_E_TimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TimeText");
     				}
     				return this.m_E_TimeTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TimeText");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_NuTextText = null;
			this.m_EG_RankShowSetRectTransform = null;
			this.m_E_Rank_1Image = null;
			this.m_E_Rank_2Image = null;
			this.m_E_Rank_3Image = null;
			this.m_E_NameTextText = null;
			this.m_E_LayerTextText = null;
			this.m_E_TimeTextText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_NuTextText = null;
		private UnityEngine.RectTransform m_EG_RankShowSetRectTransform = null;
		private UnityEngine.UI.Image m_E_Rank_1Image = null;
		private UnityEngine.UI.Image m_E_Rank_2Image = null;
		private UnityEngine.UI.Image m_E_Rank_3Image = null;
		private UnityEngine.UI.Text m_E_NameTextText = null;
		private UnityEngine.UI.Text m_E_LayerTextText = null;
		private UnityEngine.UI.Text m_E_TimeTextText = null;
		public Transform uiTransform = null;
	}
}
