
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CountryTaskItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_CountryTaskItem> 
	{
		public TaskPro TaskPro;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CountryTaskItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextTaskNameText
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
     				if( this.m_E_TextTaskNameText == null )
     				{
		    			this.m_E_TextTaskNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTaskName");
     				}
     				return this.m_E_TextTaskNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTaskName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextTaskDescText
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
     				if( this.m_E_TextTaskDescText == null )
     				{
		    			this.m_E_TextTaskDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTaskDesc");
     				}
     				return this.m_E_TextTaskDescText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTaskDesc");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextHuoyueValueText
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
     				if( this.m_E_TextHuoyueValueText == null )
     				{
		    			this.m_E_TextHuoyueValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextHuoyueValue");
     				}
     				return this.m_E_TextHuoyueValueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextHuoyueValue");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonReceiveButton
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
     				if( this.m_E_ButtonReceiveButton == null )
     				{
		    			this.m_E_ButtonReceiveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonReceive");
     				}
     				return this.m_E_ButtonReceiveButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonReceive");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonReceiveImage
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
     				if( this.m_E_ButtonReceiveImage == null )
     				{
		    			this.m_E_ButtonReceiveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonReceive");
     				}
     				return this.m_E_ButtonReceiveImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonReceive");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextTaskProgressText
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
     				if( this.m_E_TextTaskProgressText == null )
     				{
		    			this.m_E_TextTaskProgressText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ButtonReceive/E_TextTaskProgress");
     				}
     				return this.m_E_TextTaskProgressText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ButtonReceive/E_TextTaskProgress");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCompleteButton
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
     				if( this.m_E_ButtonCompleteButton == null )
     				{
		    			this.m_E_ButtonCompleteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonComplete");
     				}
     				return this.m_E_ButtonCompleteButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonComplete");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCompleteImage
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
     				if( this.m_E_ButtonCompleteImage == null )
     				{
		    			this.m_E_ButtonCompleteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonComplete");
     				}
     				return this.m_E_ButtonCompleteImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonComplete");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ItemNumberText
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
     				if( this.m_E_ItemNumberText == null )
     				{
		    			this.m_E_ItemNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ItemInfo_1/E_ItemNumber");
     				}
     				return this.m_E_ItemNumberText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ItemInfo_1/E_ItemNumber");
     			}
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		    	ES_RewardList es = this.m_es_rewardlist;
     			if (this.isCacheNode)
     			{
     				if( es == null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if( es != null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			es = this.m_es_rewardlist;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_rewardlist = null;
		    				this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageIconImage = null;
			this.m_E_TextTaskNameText = null;
			this.m_E_TextTaskDescText = null;
			this.m_E_TextHuoyueValueText = null;
			this.m_E_ButtonReceiveButton = null;
			this.m_E_ButtonReceiveImage = null;
			this.m_E_TextTaskProgressText = null;
			this.m_E_ButtonCompleteButton = null;
			this.m_E_ButtonCompleteImage = null;
			this.m_E_ItemNumberText = null;
			this.m_es_rewardlist = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.UI.Text m_E_TextTaskNameText = null;
		private UnityEngine.UI.Text m_E_TextTaskDescText = null;
		private UnityEngine.UI.Text m_E_TextHuoyueValueText = null;
		private UnityEngine.UI.Button m_E_ButtonReceiveButton = null;
		private UnityEngine.UI.Image m_E_ButtonReceiveImage = null;
		private UnityEngine.UI.Text m_E_TextTaskProgressText = null;
		private UnityEngine.UI.Button m_E_ButtonCompleteButton = null;
		private UnityEngine.UI.Image m_E_ButtonCompleteImage = null;
		private UnityEngine.UI.Text m_E_ItemNumberText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
