
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanMain))]
	[EnableMethod]
	public  class DlgJiaYuanMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_ShouSuoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouSuoButton == null )
     			{
		    		this.m_E_Btn_ShouSuoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/E_Btn_ShouSuo");
     			}
     			return this.m_E_Btn_ShouSuoButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShouSuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouSuoImage == null )
     			{
		    		this.m_E_Btn_ShouSuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/E_Btn_ShouSuo");
     			}
     			return this.m_E_Btn_ShouSuoImage;
     		}
     	}

		public ES_JiaYuaVisit ES_JiaYuaVisit
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JiaYuaVisit es = this.m_es_jiayuavisit;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right_2/ES_JiaYuaVisit");
		    	   this.m_es_jiayuavisit = this.AddChild<ES_JiaYuaVisit,Transform>(subTrans);
     			}
     			return this.m_es_jiayuavisit;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonMyJiaYuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMyJiaYuanButton == null )
     			{
		    		this.m_E_ButtonMyJiaYuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonMyJiaYuan");
     			}
     			return this.m_E_ButtonMyJiaYuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMyJiaYuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMyJiaYuanImage == null )
     			{
		    		this.m_E_ButtonMyJiaYuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonMyJiaYuan");
     			}
     			return this.m_E_ButtonMyJiaYuanImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOneKeyPlantButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOneKeyPlantButton == null )
     			{
		    		this.m_E_ButtonOneKeyPlantButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonOneKeyPlant");
     			}
     			return this.m_E_ButtonOneKeyPlantButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOneKeyPlantImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOneKeyPlantImage == null )
     			{
		    		this.m_E_ButtonOneKeyPlantImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonOneKeyPlant");
     			}
     			return this.m_E_ButtonOneKeyPlantImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonReturnButton == null )
     			{
		    		this.m_E_ButtonReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonReturn");
     			}
     			return this.m_E_ButtonReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonReturnImage == null )
     			{
		    		this.m_E_ButtonReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonReturn");
     			}
     			return this.m_E_ButtonReturnImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonWarehouseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonWarehouseButton == null )
     			{
		    		this.m_E_ButtonWarehouseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonWarehouse");
     			}
     			return this.m_E_ButtonWarehouseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonWarehouseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonWarehouseImage == null )
     			{
		    		this.m_E_ButtonWarehouseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonWarehouse");
     			}
     			return this.m_E_ButtonWarehouseImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGatherButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGatherButton == null )
     			{
		    		this.m_E_ButtonGatherButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonGather");
     			}
     			return this.m_E_ButtonGatherButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGatherImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGatherImage == null )
     			{
		    		this.m_E_ButtonGatherImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonGather");
     			}
     			return this.m_E_ButtonGatherImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonTargetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTargetButton == null )
     			{
		    		this.m_E_ButtonTargetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonTarget");
     			}
     			return this.m_E_ButtonTargetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonTargetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTargetImage == null )
     			{
		    		this.m_E_ButtonTargetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonTarget");
     			}
     			return this.m_E_ButtonTargetImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonTalkButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTalkButton == null )
     			{
		    		this.m_E_ButtonTalkButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonTalk");
     			}
     			return this.m_E_ButtonTalkButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonTalkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTalkImage == null )
     			{
		    		this.m_E_ButtonTalkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right_2/BottomRight/E_ButtonTalk");
     			}
     			return this.m_E_ButtonTalkImage;
     		}
     	}

		public UnityEngine.UI.Image E_PlanIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlanIconImage == null )
     			{
		    		this.m_E_PlanIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/GameObject/E_PlanIcon");
     			}
     			return this.m_E_PlanIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_GengDiTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GengDiTextText == null )
     			{
		    		this.m_E_GengDiTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/GameObject/E_GengDiText");
     			}
     			return this.m_E_GengDiTextText;
     		}
     	}

		public UnityEngine.UI.Text E_RenKouTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RenKouTextText == null )
     			{
		    		this.m_E_RenKouTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/GameObject (1)/E_RenKouText");
     			}
     			return this.m_E_RenKouTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_ShouSuoButton = null;
			this.m_E_Btn_ShouSuoImage = null;
			this.m_es_jiayuavisit = null;
			this.m_E_ButtonMyJiaYuanButton = null;
			this.m_E_ButtonMyJiaYuanImage = null;
			this.m_E_ButtonOneKeyPlantButton = null;
			this.m_E_ButtonOneKeyPlantImage = null;
			this.m_E_ButtonReturnButton = null;
			this.m_E_ButtonReturnImage = null;
			this.m_E_ButtonWarehouseButton = null;
			this.m_E_ButtonWarehouseImage = null;
			this.m_E_ButtonGatherButton = null;
			this.m_E_ButtonGatherImage = null;
			this.m_E_ButtonTargetButton = null;
			this.m_E_ButtonTargetImage = null;
			this.m_E_ButtonTalkButton = null;
			this.m_E_ButtonTalkImage = null;
			this.m_E_PlanIconImage = null;
			this.m_E_GengDiTextText = null;
			this.m_E_RenKouTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_ShouSuoButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShouSuoImage = null;
		private EntityRef<ES_JiaYuaVisit> m_es_jiayuavisit = null;
		private UnityEngine.UI.Button m_E_ButtonMyJiaYuanButton = null;
		private UnityEngine.UI.Image m_E_ButtonMyJiaYuanImage = null;
		private UnityEngine.UI.Button m_E_ButtonOneKeyPlantButton = null;
		private UnityEngine.UI.Image m_E_ButtonOneKeyPlantImage = null;
		private UnityEngine.UI.Button m_E_ButtonReturnButton = null;
		private UnityEngine.UI.Image m_E_ButtonReturnImage = null;
		private UnityEngine.UI.Button m_E_ButtonWarehouseButton = null;
		private UnityEngine.UI.Image m_E_ButtonWarehouseImage = null;
		private UnityEngine.UI.Button m_E_ButtonGatherButton = null;
		private UnityEngine.UI.Image m_E_ButtonGatherImage = null;
		private UnityEngine.UI.Button m_E_ButtonTargetButton = null;
		private UnityEngine.UI.Image m_E_ButtonTargetImage = null;
		private UnityEngine.UI.Button m_E_ButtonTalkButton = null;
		private UnityEngine.UI.Image m_E_ButtonTalkImage = null;
		private UnityEngine.UI.Image m_E_PlanIconImage = null;
		private UnityEngine.UI.Text m_E_GengDiTextText = null;
		private UnityEngine.UI.Text m_E_RenKouTextText = null;
		public Transform uiTransform = null;
	}
}
