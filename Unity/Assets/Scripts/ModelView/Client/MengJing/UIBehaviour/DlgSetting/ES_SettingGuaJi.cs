using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SettingGuaJi : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<int> SkillSet = new();
		public List<GameObject> SkillSetIconRightList = new();
		
		public UnityEngine.UI.Button E_Btn_Click_0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Click_0Button == null )
     			{
		    		this.m_E_Btn_Click_0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/ShiQuSet/E_Btn_Click_0");
     			}
     			return this.m_E_Btn_Click_0Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_Click_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Click_0Image == null )
     			{
		    		this.m_E_Btn_Click_0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/ShiQuSet/E_Btn_Click_0");
     			}
     			return this.m_E_Btn_Click_0Image;
     		}
     	}

		public UnityEngine.UI.Image E_Image_Click_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_Click_0Image == null )
     			{
		    		this.m_E_Image_Click_0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/ShiQuSet/E_Image_Click_0");
     			}
     			return this.m_E_Image_Click_0Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_StartGuajIButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StartGuajIButton == null )
     			{
		    		this.m_E_Btn_StartGuajIButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_StartGuajI");
     			}
     			return this.m_E_Btn_StartGuajIButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_StartGuajIImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StartGuajIImage == null )
     			{
		    		this.m_E_Btn_StartGuajIImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_StartGuajI");
     			}
     			return this.m_E_Btn_StartGuajIImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_StopGuaJiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StopGuaJiButton == null )
     			{
		    		this.m_E_Btn_StopGuaJiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_StopGuaJiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StopGuaJiImage == null )
     			{
		    		this.m_E_Btn_StopGuaJiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GuaJiRangeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiRangeButton == null )
     			{
		    		this.m_E_Btn_GuaJiRangeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/GuaJiRangSetting/E_Btn_GuaJiRange");
     			}
     			return this.m_E_Btn_GuaJiRangeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GuaJiRangeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiRangeImage == null )
     			{
		    		this.m_E_Btn_GuaJiRangeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/GuaJiRangSetting/E_Btn_GuaJiRange");
     			}
     			return this.m_E_Btn_GuaJiRangeImage;
     		}
     	}

		public UnityEngine.UI.Image E_Click_GuaJiRangeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Click_GuaJiRangeImage == null )
     			{
		    		this.m_E_Click_GuaJiRangeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/GuaJiRangSetting/E_Click_GuaJiRange");
     			}
     			return this.m_E_Click_GuaJiRangeImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GuaJiAutoUseItemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiAutoUseItemButton == null )
     			{
		    		this.m_E_Btn_GuaJiAutoUseItemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/AutoUseItemSetting/E_Btn_GuaJiAutoUseItem");
     			}
     			return this.m_E_Btn_GuaJiAutoUseItemButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GuaJiAutoUseItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiAutoUseItemImage == null )
     			{
		    		this.m_E_Btn_GuaJiAutoUseItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/AutoUseItemSetting/E_Btn_GuaJiAutoUseItem");
     			}
     			return this.m_E_Btn_GuaJiAutoUseItemImage;
     		}
     	}

		public UnityEngine.UI.Image E_Click_GuaJiAutoUseItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Click_GuaJiAutoUseItemImage == null )
     			{
		    		this.m_E_Click_GuaJiAutoUseItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/AutoUseItemSetting/E_Click_GuaJiAutoUseItem");
     			}
     			return this.m_E_Click_GuaJiAutoUseItemImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIconItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIconItemRectTransform == null )
     			{
		    		this.m_EG_SkillIconItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/AutoUseSkillSetting/EG_SkillIconItem");
     			}
     			return this.m_EG_SkillIconItemRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIPositionSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIPositionSetRectTransform == null )
     			{
		    		this.m_EG_SkillIPositionSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/AutoUseSkillSetting/EG_SkillIPositionSet");
     			}
     			return this.m_EG_SkillIPositionSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_EditSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EditSkillButton == null )
     			{
		    		this.m_E_Btn_EditSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/AutoUseSkillSetting/E_Btn_EditSkill");
     			}
     			return this.m_E_Btn_EditSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_EditSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EditSkillImage == null )
     			{
		    		this.m_E_Btn_EditSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/AutoUseSkillSetting/E_Btn_EditSkill");
     			}
     			return this.m_E_Btn_EditSkillImage;
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
			this.m_E_Btn_Click_0Button = null;
			this.m_E_Btn_Click_0Image = null;
			this.m_E_Image_Click_0Image = null;
			this.m_E_Btn_StartGuajIButton = null;
			this.m_E_Btn_StartGuajIImage = null;
			this.m_E_Btn_StopGuaJiButton = null;
			this.m_E_Btn_StopGuaJiImage = null;
			this.m_E_Btn_GuaJiRangeButton = null;
			this.m_E_Btn_GuaJiRangeImage = null;
			this.m_E_Click_GuaJiRangeImage = null;
			this.m_E_Btn_GuaJiAutoUseItemButton = null;
			this.m_E_Btn_GuaJiAutoUseItemImage = null;
			this.m_E_Click_GuaJiAutoUseItemImage = null;
			this.m_EG_SkillIconItemRectTransform = null;
			this.m_EG_SkillIPositionSetRectTransform = null;
			this.m_E_Btn_EditSkillButton = null;
			this.m_E_Btn_EditSkillImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_Click_0Button = null;
		private UnityEngine.UI.Image m_E_Btn_Click_0Image = null;
		private UnityEngine.UI.Image m_E_Image_Click_0Image = null;
		private UnityEngine.UI.Button m_E_Btn_StartGuajIButton = null;
		private UnityEngine.UI.Image m_E_Btn_StartGuajIImage = null;
		private UnityEngine.UI.Button m_E_Btn_StopGuaJiButton = null;
		private UnityEngine.UI.Image m_E_Btn_StopGuaJiImage = null;
		private UnityEngine.UI.Button m_E_Btn_GuaJiRangeButton = null;
		private UnityEngine.UI.Image m_E_Btn_GuaJiRangeImage = null;
		private UnityEngine.UI.Image m_E_Click_GuaJiRangeImage = null;
		private UnityEngine.UI.Button m_E_Btn_GuaJiAutoUseItemButton = null;
		private UnityEngine.UI.Image m_E_Btn_GuaJiAutoUseItemImage = null;
		private UnityEngine.UI.Image m_E_Click_GuaJiAutoUseItemImage = null;
		private UnityEngine.RectTransform m_EG_SkillIconItemRectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillIPositionSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_EditSkillButton = null;
		private UnityEngine.UI.Image m_E_Btn_EditSkillImage = null;
		public Transform uiTransform = null;
	}
}
