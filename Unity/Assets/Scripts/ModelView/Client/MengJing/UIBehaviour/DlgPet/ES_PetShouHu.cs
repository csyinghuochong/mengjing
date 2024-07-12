
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetShouHu : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int SelectIndex;
		public List<ES_ShouhuInfo> ShouhuInfos = new();
		public List<RolePetInfo> ShowRolePetInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_PetShouHuItem>> ScrollItemPetShouHuItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_PetShouHuItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetShouHuItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetShouHuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetShouHuItems");
     			}
     			return this.m_E_PetShouHuItemsLoopVerticalScrollRect;
     		}
     	}

		public ES_ShouhuInfo ES_ShouhuInfo2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ShouhuInfo es = this.m_es_shouhuinfo2;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_ShouhuInfo2");
		    	   this.m_es_shouhuinfo2 = this.AddChild<ES_ShouhuInfo,Transform>(subTrans);
     			}
     			return this.m_es_shouhuinfo2;
     		}
     	}

		public ES_ShouhuInfo ES_ShouhuInfo3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ShouhuInfo es = this.m_es_shouhuinfo3;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_ShouhuInfo3");
		    	   this.m_es_shouhuinfo3 = this.AddChild<ES_ShouhuInfo,Transform>(subTrans);
     			}
     			return this.m_es_shouhuinfo3;
     		}
     	}

		public ES_ShouhuInfo ES_ShouhuInfo1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ShouhuInfo es = this.m_es_shouhuinfo1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_ShouhuInfo1");
		    	   this.m_es_shouhuinfo1 = this.AddChild<ES_ShouhuInfo,Transform>(subTrans);
     			}
     			return this.m_es_shouhuinfo1;
     		}
     	}

		public ES_ShouhuInfo ES_ShouhuInfo0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ShouhuInfo es = this.m_es_shouhuinfo0;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_ShouhuInfo0");
		    	   this.m_es_shouhuinfo0 = this.AddChild<ES_ShouhuInfo,Transform>(subTrans);
     			}
     			return this.m_es_shouhuinfo0;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSetButton == null )
     			{
		    		this.m_E_ButtonSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonSet");
     			}
     			return this.m_E_ButtonSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSetImage == null )
     			{
		    		this.m_E_ButtonSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonSet");
     			}
     			return this.m_E_ButtonSetImage;
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
			this.m_E_PetShouHuItemsLoopVerticalScrollRect = null;
			this.m_es_shouhuinfo2 = null;
			this.m_es_shouhuinfo3 = null;
			this.m_es_shouhuinfo1 = null;
			this.m_es_shouhuinfo0 = null;
			this.m_E_ButtonSetButton = null;
			this.m_E_ButtonSetImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetShouHuItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_ShouhuInfo> m_es_shouhuinfo2 = null;
		private EntityRef<ES_ShouhuInfo> m_es_shouhuinfo3 = null;
		private EntityRef<ES_ShouhuInfo> m_es_shouhuinfo1 = null;
		private EntityRef<ES_ShouhuInfo> m_es_shouhuinfo0 = null;
		private UnityEngine.UI.Button m_E_ButtonSetButton = null;
		private UnityEngine.UI.Image m_E_ButtonSetImage = null;
		public Transform uiTransform = null;
	}
}
