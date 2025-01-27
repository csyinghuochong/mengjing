﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivitySingIn : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int CurDay;
		public bool IsSign;
		public int ActivityId;
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivitySingInItem>> ScrollItemActivitySingInItems;
		
		public LoopVerticalScrollRect E_ActivitySingInItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingInItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ActivitySingInItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ActivitySingInItems");
     			}
     			return this.m_E_ActivitySingInItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_ComButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ComButton == null )
     			{
		    		this.m_E_Btn_ComButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Com");
     			}
     			return this.m_E_Btn_ComButton;
     		}
     	}

		public Image E_Btn_ComImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ComImage == null )
     			{
		    		this.m_E_Btn_ComImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Com");
     			}
     			return this.m_E_Btn_ComImage;
     		}
     	}

		public Image E_Img_lingQuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_lingQuImage == null )
     			{
		    		this.m_E_Img_lingQuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_lingQu");
     			}
     			return this.m_E_Img_lingQuImage;
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
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public ES_RewardList ES_RewardList_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RewardList es = this.m_es_rewardlist_2;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList_2");
		    	   this.m_es_rewardlist_2 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_2;
     		}
     	}

		public Button E_Btn_Com2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Com2Button == null )
     			{
		    		this.m_E_Btn_Com2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Com2");
     			}
     			return this.m_E_Btn_Com2Button;
     		}
     	}

		public Image E_Btn_Com2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Com2Image == null )
     			{
		    		this.m_E_Btn_Com2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Com2");
     			}
     			return this.m_E_Btn_Com2Image;
     		}
     	}

		public Image E_Img_lingQu2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_lingQu2Image == null )
     			{
		    		this.m_E_Img_lingQu2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_lingQu2");
     			}
     			return this.m_E_Img_lingQu2Image;
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
			this.m_E_ActivitySingInItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_ComButton = null;
			this.m_E_Btn_ComImage = null;
			this.m_E_Img_lingQuImage = null;
			this.m_es_rewardlist = null;
			this.m_es_rewardlist_2 = null;
			this.m_E_Btn_Com2Button = null;
			this.m_E_Btn_Com2Image = null;
			this.m_E_Img_lingQu2Image = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_ActivitySingInItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_ComButton = null;
		private Image m_E_Btn_ComImage = null;
		private Image m_E_Img_lingQuImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_2 = null;
		private Button m_E_Btn_Com2Button = null;
		private Image m_E_Btn_Com2Image = null;
		private Image m_E_Img_lingQu2Image = null;
		public Transform uiTransform = null;
	}
}
