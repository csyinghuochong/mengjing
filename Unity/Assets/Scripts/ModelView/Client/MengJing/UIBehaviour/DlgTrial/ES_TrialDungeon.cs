
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TrialDungeon : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int TowerId;
		public Dictionary<int, Scroll_Item_TrialDungeonItem> ScrollItemTrialDungeonItems;
		public List<TowerConfig> ShowTowerConfigs = new();
		
		public UnityEngine.UI.Button E_Btn_EnterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnterButton == null )
     			{
		    		this.m_E_Btn_EnterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_EnterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnterImage == null )
     			{
		    		this.m_E_Btn_EnterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ReceiveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReceiveButton == null )
     			{
		    		this.m_E_Btn_ReceiveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Receive");
     			}
     			return this.m_E_Btn_ReceiveButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ReceiveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReceiveImage == null )
     			{
		    		this.m_E_Btn_ReceiveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Receive");
     			}
     			return this.m_E_Btn_ReceiveImage;
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
     			if( this.m_es_rewardlist.Equals(null) )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_TrialDungeonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TrialDungeonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TrialDungeonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_TrialDungeonItems");
     			}
     			return this.m_E_TrialDungeonItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SubButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SubButton == null )
     			{
		    		this.m_E_Btn_SubButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_Sub");
     			}
     			return this.m_E_Btn_SubButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SubImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SubImage == null )
     			{
		    		this.m_E_Btn_SubImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_Sub");
     			}
     			return this.m_E_Btn_SubImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddButton == null )
     			{
		    		this.m_E_Btn_AddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddImage == null )
     			{
		    		this.m_E_Btn_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextLayerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLayerText == null )
     			{
		    		this.m_E_TextLayerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_TextLayer");
     			}
     			return this.m_E_TextLayerText;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_Btn_EnterButton = null;
			this.m_E_Btn_EnterImage = null;
			this.m_E_Btn_ReceiveButton = null;
			this.m_E_Btn_ReceiveImage = null;
			this.m_es_rewardlist = null;
			this.m_E_TrialDungeonItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_SubButton = null;
			this.m_E_Btn_SubImage = null;
			this.m_E_Btn_AddButton = null;
			this.m_E_Btn_AddImage = null;
			this.m_E_TextLayerText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_EnterButton = null;
		private UnityEngine.UI.Image m_E_Btn_EnterImage = null;
		private UnityEngine.UI.Button m_E_Btn_ReceiveButton = null;
		private UnityEngine.UI.Image m_E_Btn_ReceiveImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_TrialDungeonItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_SubButton = null;
		private UnityEngine.UI.Image m_E_Btn_SubImage = null;
		private UnityEngine.UI.Button m_E_Btn_AddButton = null;
		private UnityEngine.UI.Image m_E_Btn_AddImage = null;
		private UnityEngine.UI.Text m_E_TextLayerText = null;
		public Transform uiTransform = null;
	}
}
