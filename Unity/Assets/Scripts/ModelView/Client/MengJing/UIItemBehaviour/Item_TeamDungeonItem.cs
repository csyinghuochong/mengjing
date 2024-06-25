
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_TeamDungeonItem : Entity,IAwake,IDestroy,IUIScrollItem
	{
		public GameObject[] ImagePlayerList;
		public GameObject[] ImagePlayerNullList;
		public TeamInfo TeamInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_TeamDungeonItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_Button_ApplyButton
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
     				if( this.m_E_Button_ApplyButton == null )
     				{
		    			this.m_E_Button_ApplyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Apply");
     				}
     				return this.m_E_Button_ApplyButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Apply");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Button_ApplyImage
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
     				if( this.m_E_Button_ApplyImage == null )
     				{
		    			this.m_E_Button_ApplyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Apply");
     				}
     				return this.m_E_Button_ApplyImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Apply");
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

		public UnityEngine.UI.Text E_Text_ConditionText
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
     				if( this.m_E_Text_ConditionText == null )
     				{
		    			this.m_E_Text_ConditionText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Condition");
     				}
     				return this.m_E_Text_ConditionText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Condition");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_TuijianText
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
     				if( this.m_E_Text_TuijianText == null )
     				{
		    			this.m_E_Text_TuijianText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Tuijian");
     				}
     				return this.m_E_Text_TuijianText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Tuijian");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ImagePlayerNull_1RectTransform
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
     				if( this.m_EG_ImagePlayerNull_1RectTransform == null )
     				{
		    			this.m_EG_ImagePlayerNull_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayerNull_1");
     				}
     				return this.m_EG_ImagePlayerNull_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayerNull_1");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ImagePlayerNull_2RectTransform
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
     				if( this.m_EG_ImagePlayerNull_2RectTransform == null )
     				{
		    			this.m_EG_ImagePlayerNull_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayerNull_2");
     				}
     				return this.m_EG_ImagePlayerNull_2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayerNull_2");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ImagePlayerNull_3RectTransform
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
     				if( this.m_EG_ImagePlayerNull_3RectTransform == null )
     				{
		    			this.m_EG_ImagePlayerNull_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayerNull_3");
     				}
     				return this.m_EG_ImagePlayerNull_3RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayerNull_3");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ImagePlayer1RectTransform
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
     				if( this.m_EG_ImagePlayer1RectTransform == null )
     				{
		    			this.m_EG_ImagePlayer1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayer1");
     				}
     				return this.m_EG_ImagePlayer1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayer1");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ImagePlayer2RectTransform
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
     				if( this.m_EG_ImagePlayer2RectTransform == null )
     				{
		    			this.m_EG_ImagePlayer2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayer2");
     				}
     				return this.m_EG_ImagePlayer2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayer2");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_ImagePlayer3RectTransform
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
     				if( this.m_EG_ImagePlayer3RectTransform == null )
     				{
		    			this.m_EG_ImagePlayer3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayer3");
     				}
     				return this.m_EG_ImagePlayer3RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"PlayerIconShow/EG_ImagePlayer3");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Button_ApplyButton = null;
			this.m_E_Button_ApplyImage = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_ConditionText = null;
			this.m_E_Text_TuijianText = null;
			this.m_EG_ImagePlayerNull_1RectTransform = null;
			this.m_EG_ImagePlayerNull_2RectTransform = null;
			this.m_EG_ImagePlayerNull_3RectTransform = null;
			this.m_EG_ImagePlayer1RectTransform = null;
			this.m_EG_ImagePlayer2RectTransform = null;
			this.m_EG_ImagePlayer3RectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_Button_ApplyButton = null;
		private UnityEngine.UI.Image m_E_Button_ApplyImage = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_ConditionText = null;
		private UnityEngine.UI.Text m_E_Text_TuijianText = null;
		private UnityEngine.RectTransform m_EG_ImagePlayerNull_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_ImagePlayerNull_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_ImagePlayerNull_3RectTransform = null;
		private UnityEngine.RectTransform m_EG_ImagePlayer1RectTransform = null;
		private UnityEngine.RectTransform m_EG_ImagePlayer2RectTransform = null;
		private UnityEngine.RectTransform m_EG_ImagePlayer3RectTransform = null;
		public Transform uiTransform = null;
	}
}
