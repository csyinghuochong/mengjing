using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainSkill : Entity,IAwake<Transform>,IDestroy 
	{
		public List<ES_SkillGrid> UISkillGirdList { get; set; } = new();
		public SkillManagerComponentC SkillManagerComponent { get; set; }
		public float LastLockTime;
		public float LastPickTime;
		public long SwitchCDEndTime;
		public int JueXingSkillId;
		
		public RectTransform EG_NormalRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_NormalRectTransform == null )
     			{
		    		this.m_EG_NormalRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Normal");
     			}
     			return this.m_EG_NormalRectTransform;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_0;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_0");
		    	   this.m_es_skillgrid_normal_0 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_0;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_1");
		    	   this.m_es_skillgrid_normal_1 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_1;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_2
     	{
     		get
     		{
     			if (this.uiTransform==null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_2;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_2");
		    	   this.m_es_skillgrid_normal_2 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_2;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_3;
     			if( es==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_3");
		    	   this.m_es_skillgrid_normal_3 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_3;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_4;
     			if( es==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_4");
		    	   this.m_es_skillgrid_normal_4 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_4;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_5;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_5");
		    	   this.m_es_skillgrid_normal_5 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_5;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_6;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_6");
		    	   this.m_es_skillgrid_normal_6 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_6;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_7;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_7");
		    	   this.m_es_skillgrid_normal_7 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_7;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_8
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_8;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_8");
		    	   this.m_es_skillgrid_normal_8 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_8;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_9
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_9;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_9");
		    	   this.m_es_skillgrid_normal_9 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_9;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Normal_juexing
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_normal_juexing;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_SkillGrid_Normal_juexing");
		    	   this.m_es_skillgrid_normal_juexing = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_normal_juexing;
     		}
     	}

		public ES_FangunSkill ES_FangunSkill
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_FangunSkill es = this.m_es_fangunskill;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_FangunSkill");
		    	   this.m_es_fangunskill = this.AddChild<ES_FangunSkill,Transform>(subTrans);
     			}
     			return this.m_es_fangunskill;
     		}
     	}

		public RectTransform EG_TransformsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TransformsRectTransform == null )
     			{
		    		this.m_EG_TransformsRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Transforms");
     			}
     			return this.m_EG_TransformsRectTransform;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Transforms_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_transforms_0;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Transforms/ES_SkillGrid_Transforms_0");
		    	   this.m_es_skillgrid_transforms_0 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_transforms_0;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Transforms_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_transforms_1;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Transforms/ES_SkillGrid_Transforms_1");
		    	   this.m_es_skillgrid_transforms_1 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_transforms_1;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_Transforms_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SkillGrid es = this.m_es_skillgrid_transforms_2;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Transforms/ES_SkillGrid_Transforms_2");
		    	   this.m_es_skillgrid_transforms_2 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_transforms_2;
     		}
     	}

		public ES_AttackGrid ES_AttackGrid
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_AttackGrid es = this.m_es_attackgrid;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_AttackGrid");
		    	   this.m_es_attackgrid = this.AddChild<ES_AttackGrid,Transform>(subTrans);
     			}
     			return this.m_es_attackgrid;
     		}
     	}

		public Button E_Btn_CancleSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CancleSkillButton == null )
     			{
		    		this.m_E_Btn_CancleSkillButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_CancleSkill");
     			}
     			return this.m_E_Btn_CancleSkillButton;
     		}
     	}

		public Image E_Btn_CancleSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CancleSkillImage == null )
     			{
		    		this.m_E_Btn_CancleSkillImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_CancleSkill");
     			}
     			return this.m_E_Btn_CancleSkillImage;
     		}
     	}

		public EventTrigger E_Btn_CancleSkillEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CancleSkillEventTrigger == null )
     			{
		    		this.m_E_Btn_CancleSkillEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Btn_CancleSkill");
     			}
     			return this.m_E_Btn_CancleSkillEventTrigger;
     		}
     	}

		public Button E_Btn_NpcDuiHuaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_NpcDuiHuaButton == null )
     			{
		    		this.m_E_Btn_NpcDuiHuaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList/E_Btn_NpcDuiHua");
     			}
     			return this.m_E_Btn_NpcDuiHuaButton;
     		}
     	}

		public Image E_Btn_NpcDuiHuaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_NpcDuiHuaImage == null )
     			{
		    		this.m_E_Btn_NpcDuiHuaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList/E_Btn_NpcDuiHua");
     			}
     			return this.m_E_Btn_NpcDuiHuaImage;
     		}
     	}

		public Button E_Btn_JingLingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_JingLingButton == null )
     			{
		    		this.m_E_Btn_JingLingButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList/E_Btn_JingLing");
     			}
     			return this.m_E_Btn_JingLingButton;
     		}
     	}

		public Image E_Btn_JingLingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_JingLingImage == null )
     			{
		    		this.m_E_Btn_JingLingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList/E_Btn_JingLing");
     			}
     			return this.m_E_Btn_JingLingImage;
     		}
     	}

		public Button E_Button_HorseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HorseButton == null )
     			{
		    		this.m_E_Button_HorseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList/E_Button_Horse");
     			}
     			return this.m_E_Button_HorseButton;
     		}
     	}

		public Image E_Button_HorseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_HorseImage == null )
     			{
		    		this.m_E_Button_HorseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList/E_Button_Horse");
     			}
     			return this.m_E_Button_HorseImage;
     		}
     	}

		public Button E_Button_Switch_0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Switch_0Button == null )
     			{
		    		this.m_E_Button_Switch_0Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList/E_Button_Switch_0");
     			}
     			return this.m_E_Button_Switch_0Button;
     		}
     	}

		public Image E_Button_Switch_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Switch_0Image == null )
     			{
		    		this.m_E_Button_Switch_0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList/E_Button_Switch_0");
     			}
     			return this.m_E_Button_Switch_0Image;
     		}
     	}

		public Image E_Button_Switch_CDImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Switch_CDImage == null )
     			{
		    		this.m_E_Button_Switch_CDImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList/E_Button_Switch_0/E_Button_Switch_CD");
     			}
     			return this.m_E_Button_Switch_CDImage;
     		}
     	}

		public Button E_Btn_ShiQuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShiQuButton == null )
     			{
		    		this.m_E_Btn_ShiQuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList2/E_Btn_ShiQu");
     			}
     			return this.m_E_Btn_ShiQuButton;
     		}
     	}

		public Image E_Btn_ShiQuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShiQuImage == null )
     			{
		    		this.m_E_Btn_ShiQuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList2/E_Btn_ShiQu");
     			}
     			return this.m_E_Btn_ShiQuImage;
     		}
     	}

		public Button E_Button_ZhuaPuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhuaPuButton == null )
     			{
		    		this.m_E_Button_ZhuaPuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList2/E_Button_ZhuaPu");
     			}
     			return this.m_E_Button_ZhuaPuButton;
     		}
     	}

		public Image E_Button_ZhuaPuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ZhuaPuImage == null )
     			{
		    		this.m_E_Button_ZhuaPuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList2/E_Button_ZhuaPu");
     			}
     			return this.m_E_Button_ZhuaPuImage;
     		}
     	}

		public Button E_Btn_TargetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TargetButton == null )
     			{
		    		this.m_E_Btn_TargetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList2/E_Btn_Target");
     			}
     			return this.m_E_Btn_TargetButton;
     		}
     	}

		public Image E_Btn_TargetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TargetImage == null )
     			{
		    		this.m_E_Btn_TargetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList2/E_Btn_Target");
     			}
     			return this.m_E_Btn_TargetImage;
     		}
     	}

		public Button E_Btn_PetTargetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PetTargetButton == null )
     			{
		    		this.m_E_Btn_PetTargetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonList2/E_Btn_PetTarget");
     			}
     			return this.m_E_Btn_PetTargetButton;
     		}
     	}

		public Image E_Btn_PetTargetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PetTargetImage == null )
     			{
		    		this.m_E_Btn_PetTargetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ButtonList2/E_Btn_PetTarget");
     			}
     			return this.m_E_Btn_PetTargetImage;
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
			this.m_EG_NormalRectTransform = null;
			this.m_es_skillgrid_normal_0 = null;
			this.m_es_skillgrid_normal_1 = null;
			this.m_es_skillgrid_normal_2 = null;
			this.m_es_skillgrid_normal_3 = null;
			this.m_es_skillgrid_normal_4 = null;
			this.m_es_skillgrid_normal_5 = null;
			this.m_es_skillgrid_normal_6 = null;
			this.m_es_skillgrid_normal_7 = null;
			this.m_es_skillgrid_normal_8 = null;
			this.m_es_skillgrid_normal_9 = null;
			this.m_es_skillgrid_normal_juexing = null;
			this.m_es_fangunskill = null;
			this.m_EG_TransformsRectTransform = null;
			this.m_es_skillgrid_transforms_0 = null;
			this.m_es_skillgrid_transforms_1 = null;
			this.m_es_skillgrid_transforms_2 = null;
			this.m_es_attackgrid = null;
			this.m_E_Btn_CancleSkillButton = null;
			this.m_E_Btn_CancleSkillImage = null;
			this.m_E_Btn_CancleSkillEventTrigger = null;
			this.m_E_Btn_NpcDuiHuaButton = null;
			this.m_E_Btn_NpcDuiHuaImage = null;
			this.m_E_Btn_JingLingButton = null;
			this.m_E_Btn_JingLingImage = null;
			this.m_E_Button_HorseButton = null;
			this.m_E_Button_HorseImage = null;
			this.m_E_Button_Switch_0Button = null;
			this.m_E_Button_Switch_0Image = null;
			this.m_E_Button_Switch_CDImage = null;
			this.m_E_Btn_ShiQuButton = null;
			this.m_E_Btn_ShiQuImage = null;
			this.m_E_Button_ZhuaPuButton = null;
			this.m_E_Button_ZhuaPuImage = null;
			this.m_E_Btn_TargetButton = null;
			this.m_E_Btn_TargetImage = null;
			this.m_E_Btn_PetTargetButton = null;
			this.m_E_Btn_PetTargetImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_NormalRectTransform = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_0 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_1 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_2 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_3 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_4 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_5 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_6 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_7 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_8 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_9 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_normal_juexing = null;
		private EntityRef<ES_FangunSkill> m_es_fangunskill = null;
		private RectTransform m_EG_TransformsRectTransform = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_transforms_0 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_transforms_1 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_transforms_2 = null;
		private EntityRef<ES_AttackGrid> m_es_attackgrid = null;
		private Button m_E_Btn_CancleSkillButton = null;
		private Image m_E_Btn_CancleSkillImage = null;
		private EventTrigger m_E_Btn_CancleSkillEventTrigger = null;
		private Button m_E_Btn_NpcDuiHuaButton = null;
		private Image m_E_Btn_NpcDuiHuaImage = null;
		private Button m_E_Btn_JingLingButton = null;
		private Image m_E_Btn_JingLingImage = null;
		private Button m_E_Button_HorseButton = null;
		private Image m_E_Button_HorseImage = null;
		private Button m_E_Button_Switch_0Button = null;
		private Image m_E_Button_Switch_0Image = null;
		private Image m_E_Button_Switch_CDImage = null;
		private Button m_E_Btn_ShiQuButton = null;
		private Image m_E_Btn_ShiQuImage = null;
		private Button m_E_Button_ZhuaPuButton = null;
		private Image m_E_Button_ZhuaPuImage = null;
		private Button m_E_Btn_TargetButton = null;
		private Image m_E_Btn_TargetImage = null;
		private Button m_E_Btn_PetTargetButton = null;
		private Image m_E_Btn_PetTargetImage = null;
		public Transform uiTransform = null;
	}
}
