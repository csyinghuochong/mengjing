using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleZodiac))]
	[EnableMethod]
	public  class DlgRoleZodiacViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ButtonColseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonColseButton == null )
     			{
		    		this.m_E_ButtonColseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonColse");
     			}
     			return this.m_E_ButtonColseButton;
     		}
     	}

		public Image E_ButtonColseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonColseImage == null )
     			{
		    		this.m_E_ButtonColseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonColse");
     			}
     			return this.m_E_ButtonColseImage;
     		}
     	}

		public RectTransform EG_LinkShowSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LinkShowSetRectTransform == null )
     			{
		    		this.m_EG_LinkShowSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_LinkShowSet");
     			}
     			return this.m_EG_LinkShowSetRectTransform;
     		}
     	}

		public ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public RectTransform EG_ZodiacListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ZodiacListRectTransform == null )
     			{
		    		this.m_EG_ZodiacListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ZodiacList");
     			}
     			return this.m_EG_ZodiacListRectTransform;
     		}
     	}

		public ES_EquipItem ES_EquipItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_0;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_0");
		    	   this.m_es_equipitem_0 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_0;
     		}
     	}

		public ES_EquipItem ES_EquipItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_1;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_1");
		    	   this.m_es_equipitem_1 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_1;
     		}
     	}

		public ES_EquipItem ES_EquipItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_2;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_2");
		    	   this.m_es_equipitem_2 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_2;
     		}
     	}

		public ES_EquipItem ES_EquipItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_3;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_3");
		    	   this.m_es_equipitem_3 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_3;
     		}
     	}

		public ES_EquipItem ES_EquipItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_4;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_4");
		    	   this.m_es_equipitem_4 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_4;
     		}
     	}

		public ES_EquipItem ES_EquipItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_5;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_5");
		    	   this.m_es_equipitem_5 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_5;
     		}
     	}

		public ES_EquipItem ES_EquipItem_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_6;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_6");
		    	   this.m_es_equipitem_6 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_6;
     		}
     	}

		public ES_EquipItem ES_EquipItem_7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_7;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_7");
		    	   this.m_es_equipitem_7 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_7;
     		}
     	}

		public ES_EquipItem ES_EquipItem_8
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_8;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_8");
		    	   this.m_es_equipitem_8 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_8;
     		}
     	}

		public ES_EquipItem ES_EquipItem_9
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_9;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_9");
		    	   this.m_es_equipitem_9 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_9;
     		}
     	}

		public ES_EquipItem ES_EquipItem_10
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_10;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_10");
		    	   this.m_es_equipitem_10 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_10;
     		}
     	}

		public ES_EquipItem ES_EquipItem_11
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_EquipItem es = this.m_es_equipitem_11;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_ZodiacList/ES_EquipItem_11");
		    	   this.m_es_equipitem_11 = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem_11;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonColseButton = null;
			this.m_E_ButtonColseImage = null;
			this.m_EG_LinkShowSetRectTransform = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_EG_ZodiacListRectTransform = null;
			this.m_es_equipitem_0 = null;
			this.m_es_equipitem_1 = null;
			this.m_es_equipitem_2 = null;
			this.m_es_equipitem_3 = null;
			this.m_es_equipitem_4 = null;
			this.m_es_equipitem_5 = null;
			this.m_es_equipitem_6 = null;
			this.m_es_equipitem_7 = null;
			this.m_es_equipitem_8 = null;
			this.m_es_equipitem_9 = null;
			this.m_es_equipitem_10 = null;
			this.m_es_equipitem_11 = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonColseButton = null;
		private Image m_E_ButtonColseImage = null;
		private RectTransform m_EG_LinkShowSetRectTransform = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private RectTransform m_EG_ZodiacListRectTransform = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_0 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_1 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_2 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_3 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_4 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_5 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_6 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_7 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_8 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_9 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_10 = null;
		private EntityRef<ES_EquipItem> m_es_equipitem_11 = null;
		public Transform uiTransform = null;
	}
}
