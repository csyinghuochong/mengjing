using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FashionShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, GameObject> ButtonList = new();
		public Dictionary<int, EntityRef<Scroll_Item_FashionShowItem>> ScrollItemFashionShowItems;
		public List<int> ShowFashion = new();

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ModelShow es = this.m_es_modelshow;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Image E_Image_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_SelectImage == null )
     			{
		    		this.m_E_Image_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/TouBuList/Button_1001/E_Image_Select");
     			}
     			return this.m_E_Image_SelectImage;
     		}
     	}

		public LoopVerticalScrollRect E_FashionShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FashionShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_FashionShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_FashionShowItems");
     			}
     			return this.m_E_FashionShowItemsLoopVerticalScrollRect;
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
			this.m_es_modelshow = null;
			this.m_E_Image_SelectImage = null;
			this.m_E_FashionShowItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Image m_E_Image_SelectImage = null;
		private LoopVerticalScrollRect m_E_FashionShowItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
