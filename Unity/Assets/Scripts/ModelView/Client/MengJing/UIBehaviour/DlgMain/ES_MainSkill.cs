
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainSkill : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		private EntityRef<Unit> unit;
		public Unit MainUnit { get => this.unit; set => this.unit = value; }
		public List<ES_SkillGrid> UISkillGirdList_Normal { get; set; } = new();
		public List<ES_SkillGrid> UISkillGirdList_PetFight { get; set; } = new();
		public EntityRef<SkillManagerComponentC> skillManagerComponent;
		public SkillManagerComponentC SkillManagerComponent { get => this.skillManagerComponent; set => this.skillManagerComponent = value; }
		
		public float LastLockTime;
		public float LastPickTime;
		public long SwitchCDEndTime;
		public int JueXingSkillId;
		
		public UnityEngine.RectTransform EG_NormalRectTransform
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
		    		this.m_EG_NormalRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Normal");
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
     			if( es == null )

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
     			if( es == null )

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
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_normal_2;
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Normal/ES_FangunSkill");
		    	   this.m_es_fangunskill = this.AddChild<ES_FangunSkill,Transform>(subTrans);
     			}
     			return this.m_es_fangunskill;
     		}
     	}

		public UnityEngine.RectTransform EG_TransformsRectTransform
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
		    		this.m_EG_TransformsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Transforms");
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
     			if( es == null )

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
     			if( es == null )

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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Transforms/ES_SkillGrid_Transforms_2");
		    	   this.m_es_skillgrid_transforms_2 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_transforms_2;
     		}
     	}

		public UnityEngine.RectTransform EG_PetFightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetFightRectTransform == null )
     			{
		    		this.m_EG_PetFightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetFight");
     			}
     			return this.m_EG_PetFightRectTransform;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_0");
		    	   this.m_es_skillgrid_petfight_0 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_0;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_1");
		    	   this.m_es_skillgrid_petfight_1 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_1;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_2");
		    	   this.m_es_skillgrid_petfight_2 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_2;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_3");
		    	   this.m_es_skillgrid_petfight_3 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_3;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_4;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_4");
		    	   this.m_es_skillgrid_petfight_4 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_4;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_5;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_5");
		    	   this.m_es_skillgrid_petfight_5 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_5;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_6;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_6");
		    	   this.m_es_skillgrid_petfight_6 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_6;
     		}
     	}

		public ES_SkillGrid ES_SkillGrid_PetFight_7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SkillGrid es = this.m_es_skillgrid_petfight_7;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetFight/ES_SkillGrid_PetFight_7");
		    	   this.m_es_skillgrid_petfight_7 = this.AddChild<ES_SkillGrid,Transform>(subTrans);
     			}
     			return this.m_es_skillgrid_petfight_7;
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_AttackGrid");
		    	   this.m_es_attackgrid = this.AddChild<ES_AttackGrid,Transform>(subTrans);
     			}
     			return this.m_es_attackgrid;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CancleSkillButton
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
		    		this.m_E_Btn_CancleSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_CancleSkill");
     			}
     			return this.m_E_Btn_CancleSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CancleSkillImage
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
		    		this.m_E_Btn_CancleSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_CancleSkill");
     			}
     			return this.m_E_Btn_CancleSkillImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_CancleSkillEventTrigger
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
		    		this.m_E_Btn_CancleSkillEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Btn_CancleSkill");
     			}
     			return this.m_E_Btn_CancleSkillEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_NpcDuiHuaButton
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
		    		this.m_E_Btn_NpcDuiHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_NpcDuiHua");
     			}
     			return this.m_E_Btn_NpcDuiHuaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_NpcDuiHuaImage
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
		    		this.m_E_Btn_NpcDuiHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList/E_Btn_NpcDuiHua");
     			}
     			return this.m_E_Btn_NpcDuiHuaImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_JingLingButton
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
		    		this.m_E_Btn_JingLingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList/E_Btn_JingLing");
     			}
     			return this.m_E_Btn_JingLingButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_JingLingImage
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
		    		this.m_E_Btn_JingLingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList/E_Btn_JingLing");
     			}
     			return this.m_E_Btn_JingLingImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_HorseButton
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
		    		this.m_E_Button_HorseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList/E_Button_Horse");
     			}
     			return this.m_E_Button_HorseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_HorseImage
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
		    		this.m_E_Button_HorseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList/E_Button_Horse");
     			}
     			return this.m_E_Button_HorseImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Switch_0Button
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
		    		this.m_E_Button_Switch_0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList/E_Button_Switch_0");
     			}
     			return this.m_E_Button_Switch_0Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Switch_0Image
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
		    		this.m_E_Button_Switch_0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList/E_Button_Switch_0");
     			}
     			return this.m_E_Button_Switch_0Image;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Switch_CDImage
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
		    		this.m_E_Button_Switch_CDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList/E_Button_Switch_0/E_Button_Switch_CD");
     			}
     			return this.m_E_Button_Switch_CDImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ShiQuButton
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
		    		this.m_E_Btn_ShiQuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/E_Btn_ShiQu");
     			}
     			return this.m_E_Btn_ShiQuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShiQuImage
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
		    		this.m_E_Btn_ShiQuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList2/E_Btn_ShiQu");
     			}
     			return this.m_E_Btn_ShiQuImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ZhuaPuButton
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
		    		this.m_E_Button_ZhuaPuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/E_Button_ZhuaPu");
     			}
     			return this.m_E_Button_ZhuaPuButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ZhuaPuImage
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
		    		this.m_E_Button_ZhuaPuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList2/E_Button_ZhuaPu");
     			}
     			return this.m_E_Button_ZhuaPuImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_TargetButton
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
		    		this.m_E_Btn_TargetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/E_Btn_Target");
     			}
     			return this.m_E_Btn_TargetButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_TargetImage
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
		    		this.m_E_Btn_TargetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList2/E_Btn_Target");
     			}
     			return this.m_E_Btn_TargetImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_PetTargetButton
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
		    		this.m_E_Btn_PetTargetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonList2/E_Btn_PetTarget");
     			}
     			return this.m_E_Btn_PetTargetButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_PetTargetImage
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
		    		this.m_E_Btn_PetTargetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonList2/E_Btn_PetTarget");
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
			this.m_EG_PetFightRectTransform = null;
			this.m_es_skillgrid_petfight_0 = null;
			this.m_es_skillgrid_petfight_1 = null;
			this.m_es_skillgrid_petfight_2 = null;
			this.m_es_skillgrid_petfight_3 = null;
			this.m_es_skillgrid_petfight_4 = null;
			this.m_es_skillgrid_petfight_5 = null;
			this.m_es_skillgrid_petfight_6 = null;
			this.m_es_skillgrid_petfight_7 = null;
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

		private UnityEngine.RectTransform m_EG_NormalRectTransform = null;
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
		private UnityEngine.RectTransform m_EG_TransformsRectTransform = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_transforms_0 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_transforms_1 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_transforms_2 = null;
		private UnityEngine.RectTransform m_EG_PetFightRectTransform = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_0 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_1 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_2 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_3 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_4 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_5 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_6 = null;
		private EntityRef<ES_SkillGrid> m_es_skillgrid_petfight_7 = null;
		private EntityRef<ES_AttackGrid> m_es_attackgrid = null;
		private UnityEngine.UI.Button m_E_Btn_CancleSkillButton = null;
		private UnityEngine.UI.Image m_E_Btn_CancleSkillImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_CancleSkillEventTrigger = null;
		private UnityEngine.UI.Button m_E_Btn_NpcDuiHuaButton = null;
		private UnityEngine.UI.Image m_E_Btn_NpcDuiHuaImage = null;
		private UnityEngine.UI.Button m_E_Btn_JingLingButton = null;
		private UnityEngine.UI.Image m_E_Btn_JingLingImage = null;
		private UnityEngine.UI.Button m_E_Button_HorseButton = null;
		private UnityEngine.UI.Image m_E_Button_HorseImage = null;
		private UnityEngine.UI.Button m_E_Button_Switch_0Button = null;
		private UnityEngine.UI.Image m_E_Button_Switch_0Image = null;
		private UnityEngine.UI.Image m_E_Button_Switch_CDImage = null;
		private UnityEngine.UI.Button m_E_Btn_ShiQuButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShiQuImage = null;
		private UnityEngine.UI.Button m_E_Button_ZhuaPuButton = null;
		private UnityEngine.UI.Image m_E_Button_ZhuaPuImage = null;
		private UnityEngine.UI.Button m_E_Btn_TargetButton = null;
		private UnityEngine.UI.Image m_E_Btn_TargetImage = null;
		private UnityEngine.UI.Button m_E_Btn_PetTargetButton = null;
		private UnityEngine.UI.Image m_E_Btn_PetTargetImage = null;
		public Transform uiTransform = null;
	}
}
