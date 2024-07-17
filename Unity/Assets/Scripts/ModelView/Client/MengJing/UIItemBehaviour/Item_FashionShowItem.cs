using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_FashionShowItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_FashionShowItem>
	{
		public Action<int> PreviewHandler;
		public Action FashionWearHandler;
		public int FashionId;
		public int Status;
		public int Position;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_FashionShowItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ImageDiButton
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
     				if( this.m_E_ImageDiButton == null )
     				{
		    			this.m_E_ImageDiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageDi");
     				}
     				return this.m_E_ImageDiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     		}
     	}

		public Image E_ImageDiImage
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
     				if( this.m_E_ImageDiImage == null )
     				{
		    			this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi");
     				}
     				return this.m_E_ImageDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi");
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
     				if( es ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    			this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     				}
     				return this.m_es_modelshow;
     			}
     			else
     			{
     				if( es !=null )
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

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CommonItem es = this.m_es_commonitem;
     			if (this.isCacheNode)
     			{
     				if( es ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( es !=null)
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			es = this.m_es_commonitem;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem = null;
		    				this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     		}
     	}

		public Image E_EquipingedImage
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
     				if( this.m_E_EquipingedImage == null )
     				{
		    			this.m_E_EquipingedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Equipinged");
     				}
     				return this.m_E_EquipingedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Equipinged");
     			}
     		}
     	}

		public Button E_Btn_ActiveButton
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
     				if( this.m_E_Btn_ActiveButton == null )
     				{
		    			this.m_E_Btn_ActiveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Active");
     				}
     				return this.m_E_Btn_ActiveButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Active");
     			}
     		}
     	}

		public Image E_Btn_ActiveImage
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
     				if( this.m_E_Btn_ActiveImage == null )
     				{
		    			this.m_E_Btn_ActiveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Active");
     				}
     				return this.m_E_Btn_ActiveImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Active");
     			}
     		}
     	}

		public Button E_Btn_DescButton
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
     				if( this.m_E_Btn_DescButton == null )
     				{
		    			this.m_E_Btn_DescButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Desc");
     				}
     				return this.m_E_Btn_DescButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Desc");
     			}
     		}
     	}

		public Image E_Btn_DescImage
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
     				if( this.m_E_Btn_DescImage == null )
     				{
		    			this.m_E_Btn_DescImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Desc");
     				}
     				return this.m_E_Btn_DescImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Desc");
     			}
     		}
     	}

		public Text E_Text_111Text
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
     				if( this.m_E_Text_111Text == null )
     				{
		    			this.m_E_Text_111Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_111");
     				}
     				return this.m_E_Text_111Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_111");
     			}
     		}
     	}

		public Text E_Text_222Text
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
     				if( this.m_E_Text_222Text == null )
     				{
		    			this.m_E_Text_222Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_222");
     				}
     				return this.m_E_Text_222Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_222");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageDiButton = null;
			this.m_E_ImageDiImage = null;
			this.m_es_modelshow = null;
			this.m_es_commonitem = null;
			this.m_E_EquipingedImage = null;
			this.m_E_Btn_ActiveButton = null;
			this.m_E_Btn_ActiveImage = null;
			this.m_E_Btn_DescButton = null;
			this.m_E_Btn_DescImage = null;
			this.m_E_Text_111Text = null;
			this.m_E_Text_222Text = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ImageDiButton = null;
		private Image m_E_ImageDiImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Image m_E_EquipingedImage = null;
		private Button m_E_Btn_ActiveButton = null;
		private Image m_E_Btn_ActiveImage = null;
		private Button m_E_Btn_DescButton = null;
		private Image m_E_Btn_DescImage = null;
		private Text m_E_Text_111Text = null;
		private Text m_E_Text_222Text = null;
		public Transform uiTransform = null;
	}
}
