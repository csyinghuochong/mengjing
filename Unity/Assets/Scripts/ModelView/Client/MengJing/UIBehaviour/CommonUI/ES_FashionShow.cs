
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FashionShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Dictionary<int, GameObject> ButtonList = new();
		public Dictionary<int, Scroll_Item_FashionShowItem> ScrollItemFashionShowItems;
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
     			if( this.m_es_modelshow == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Button E_Button_1001Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1001Button == null )
     			{
		    		this.m_E_Button_1001Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1001");
     			}
     			return this.m_E_Button_1001Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_1001Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1001Image == null )
     			{
		    		this.m_E_Button_1001Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1001");
     			}
     			return this.m_E_Button_1001Image;
     		}
     	}

		public UnityEngine.UI.Image E_Image_SelectImage
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
		    		this.m_E_Image_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1001/E_Image_Select");
     			}
     			return this.m_E_Image_SelectImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_1002Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1002Button == null )
     			{
		    		this.m_E_Button_1002Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1002");
     			}
     			return this.m_E_Button_1002Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_1002Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1002Image == null )
     			{
		    		this.m_E_Button_1002Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1002");
     			}
     			return this.m_E_Button_1002Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_1003Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1003Button == null )
     			{
		    		this.m_E_Button_1003Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1003");
     			}
     			return this.m_E_Button_1003Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_1003Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1003Image == null )
     			{
		    		this.m_E_Button_1003Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1003");
     			}
     			return this.m_E_Button_1003Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_1004Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1004Button == null )
     			{
		    		this.m_E_Button_1004Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1004");
     			}
     			return this.m_E_Button_1004Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_1004Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_1004Image == null )
     			{
		    		this.m_E_Button_1004Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/TouBuList/E_Button_1004");
     			}
     			return this.m_E_Button_1004Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_2003Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2003Button == null )
     			{
		    		this.m_E_Button_2003Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/ShangShenList/E_Button_2003");
     			}
     			return this.m_E_Button_2003Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_2003Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2003Image == null )
     			{
		    		this.m_E_Button_2003Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/ShangShenList/E_Button_2003");
     			}
     			return this.m_E_Button_2003Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_2001Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2001Button == null )
     			{
		    		this.m_E_Button_2001Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/ShangShenList/E_Button_2001");
     			}
     			return this.m_E_Button_2001Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_2001Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2001Image == null )
     			{
		    		this.m_E_Button_2001Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/ShangShenList/E_Button_2001");
     			}
     			return this.m_E_Button_2001Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_2002Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2002Button == null )
     			{
		    		this.m_E_Button_2002Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/ShangShenList/E_Button_2002");
     			}
     			return this.m_E_Button_2002Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_2002Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_2002Image == null )
     			{
		    		this.m_E_Button_2002Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/ShangShenList/E_Button_2002");
     			}
     			return this.m_E_Button_2002Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_3001Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_3001Button == null )
     			{
		    		this.m_E_Button_3001Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/XiaShenList/E_Button_3001");
     			}
     			return this.m_E_Button_3001Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_3001Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_3001Image == null )
     			{
		    		this.m_E_Button_3001Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/XiaShenList/E_Button_3001");
     			}
     			return this.m_E_Button_3001Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_3002Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_3002Button == null )
     			{
		    		this.m_E_Button_3002Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/XiaShenList/E_Button_3002");
     			}
     			return this.m_E_Button_3002Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_3002Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_3002Image == null )
     			{
		    		this.m_E_Button_3002Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/XiaShenList/E_Button_3002");
     			}
     			return this.m_E_Button_3002Image;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_FashionShowItemsLoopVerticalScrollRect
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
		    		this.m_E_FashionShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_FashionShowItems");
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
			this.m_E_Button_1001Button = null;
			this.m_E_Button_1001Image = null;
			this.m_E_Image_SelectImage = null;
			this.m_E_Button_1002Button = null;
			this.m_E_Button_1002Image = null;
			this.m_E_Button_1003Button = null;
			this.m_E_Button_1003Image = null;
			this.m_E_Button_1004Button = null;
			this.m_E_Button_1004Image = null;
			this.m_E_Button_2003Button = null;
			this.m_E_Button_2003Image = null;
			this.m_E_Button_2001Button = null;
			this.m_E_Button_2001Image = null;
			this.m_E_Button_2002Button = null;
			this.m_E_Button_2002Image = null;
			this.m_E_Button_3001Button = null;
			this.m_E_Button_3001Image = null;
			this.m_E_Button_3002Button = null;
			this.m_E_Button_3002Image = null;
			this.m_E_FashionShowItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Button m_E_Button_1001Button = null;
		private UnityEngine.UI.Image m_E_Button_1001Image = null;
		private UnityEngine.UI.Image m_E_Image_SelectImage = null;
		private UnityEngine.UI.Button m_E_Button_1002Button = null;
		private UnityEngine.UI.Image m_E_Button_1002Image = null;
		private UnityEngine.UI.Button m_E_Button_1003Button = null;
		private UnityEngine.UI.Image m_E_Button_1003Image = null;
		private UnityEngine.UI.Button m_E_Button_1004Button = null;
		private UnityEngine.UI.Image m_E_Button_1004Image = null;
		private UnityEngine.UI.Button m_E_Button_2003Button = null;
		private UnityEngine.UI.Image m_E_Button_2003Image = null;
		private UnityEngine.UI.Button m_E_Button_2001Button = null;
		private UnityEngine.UI.Image m_E_Button_2001Image = null;
		private UnityEngine.UI.Button m_E_Button_2002Button = null;
		private UnityEngine.UI.Image m_E_Button_2002Image = null;
		private UnityEngine.UI.Button m_E_Button_3001Button = null;
		private UnityEngine.UI.Image m_E_Button_3001Image = null;
		private UnityEngine.UI.Button m_E_Button_3002Button = null;
		private UnityEngine.UI.Image m_E_Button_3002Image = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_FashionShowItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
