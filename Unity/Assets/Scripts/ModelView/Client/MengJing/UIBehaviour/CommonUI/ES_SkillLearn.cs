
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillLearn : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetButton == null )
     			{
		    		this.m_E_ButtonResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetImage == null )
     			{
		    		this.m_E_ButtonResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_ItemTypeAllSetToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeAllSetToggle == null )
     			{
		    		this.m_E_ItemTypeAllSetToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet/E_ItemTypeAllSet");
     			}
     			return this.m_E_ItemTypeAllSetToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ItemTypeEquipSetToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeEquipSetToggle == null )
     			{
		    		this.m_E_ItemTypeEquipSetToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet/E_ItemTypeEquipSet");
     			}
     			return this.m_E_ItemTypeEquipSetToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ItemTypeStrengthenSetToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeStrengthenSetToggle == null )
     			{
		    		this.m_E_ItemTypeStrengthenSetToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet/E_ItemTypeStrengthenSet");
     			}
     			return this.m_E_ItemTypeStrengthenSetToggle;
     		}
     	}

		public UnityEngine.UI.Image E_SkillLearnItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnItemsImage == null )
     			{
		    		this.m_E_SkillLearnItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SkillLearnItems");
     			}
     			return this.m_E_SkillLearnItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SkillLearnItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SkillLearnItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SkillLearnItems");
     			}
     			return this.m_E_SkillLearnItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_SkillLearnSkillItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnSkillItemsImage == null )
     			{
		    		this.m_E_SkillLearnSkillItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SkillLearnSkillItems");
     			}
     			return this.m_E_SkillLearnSkillItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SkillLearnSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SkillLearnSkillItems");
     			}
     			return this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect;
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
			this.m_E_ButtonResetButton = null;
			this.m_E_ButtonResetImage = null;
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_E_ItemTypeAllSetToggle = null;
			this.m_E_ItemTypeEquipSetToggle = null;
			this.m_E_ItemTypeStrengthenSetToggle = null;
			this.m_E_SkillLearnItemsImage = null;
			this.m_E_SkillLearnItemsLoopVerticalScrollRect = null;
			this.m_E_SkillLearnSkillItemsImage = null;
			this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonResetButton = null;
		private UnityEngine.UI.Image m_E_ButtonResetImage = null;
		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_ItemTypeAllSetToggle = null;
		private UnityEngine.UI.Toggle m_E_ItemTypeEquipSetToggle = null;
		private UnityEngine.UI.Toggle m_E_ItemTypeStrengthenSetToggle = null;
		private UnityEngine.UI.Image m_E_SkillLearnItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SkillLearnItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_SkillLearnSkillItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SkillLearnSkillItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
