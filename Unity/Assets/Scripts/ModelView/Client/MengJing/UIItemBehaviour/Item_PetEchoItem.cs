using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetEchoItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetEchoItem> 
	{

        public int Index;
        public Action<int> ClickPetEchoHandler;

        public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetEchoItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
                    if (this.m_E_ImageButtonButton == null)
                    {
                        this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "E_ImageButton");
                    }
                    return this.m_E_ImageButtonButton;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "E_ImageButton");
                }
            }
        }
 
        public UnityEngine.UI.Image E_ImageSelectImage
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
                    if (this.m_E_ImageSelectImage == null)
                    {
                        this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_ImageSelect");
                    }
                    return this.m_E_ImageSelectImage;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_ImageSelect");
                }
            }
        }

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
     			if (this.isCacheNode)
     			{
     				if( es == null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     			else
     			{
     				if( es != null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			es = this.m_es_modelshow;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_modelshow = null;
		    				this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
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

		public UnityEngine.UI.Text E_Text_ComabtText
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
     				if( this.m_E_Text_ComabtText == null )
     				{
		    			this.m_E_Text_ComabtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Comabt");
     				}
     				return this.m_E_Text_ComabtText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Comabt");
     			}
     		}
     	}
		
		public UnityEngine.Transform E_Image_Lock
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
					if( this.m_E_Image_Lock == null )
					{
						this.m_E_Image_Lock = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"E_Image_Lock");
					}
					return this.m_E_Image_Lock;
				}
				else
				{
					return UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"E_Image_Lock");
				}
			}
		}

		public UnityEngine.Transform E_Image_Add
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
					if( this.m_E_Image_Add == null )
					{
						this.m_E_Image_Add = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"E_Image_Add");
					}
					return this.m_E_Image_Add;
				}
				else
				{
					return UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"E_Image_Add");
				}
			}
		}
		public UnityEngine.UI.Text E_Text_AttriText
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
     				if( this.m_E_Text_AttriText == null )
     				{
		    			this.m_E_Text_AttriText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Attri");
     				}
     				return this.m_E_Text_AttriText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Attri");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonImage = null;
            this.m_E_ImageButtonButton = null;
            this.m_E_ImageSelectImage = null;
            this.m_es_modelshow = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_ComabtText = null;
			this.m_E_Text_AttriText = null;
			this.m_E_Image_Lock = null;
			this.m_E_Image_Add = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
        private UnityEngine.UI.Button m_E_ImageButtonButton = null;
        private UnityEngine.UI.Image m_E_ImageSelectImage = null;
        private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_ComabtText = null;
		private UnityEngine.UI.Text m_E_Text_AttriText = null;
		private UnityEngine.Transform m_E_Image_Lock = null;
		private UnityEngine.Transform m_E_Image_Add = null;
		public Transform uiTransform = null;
	}
}
