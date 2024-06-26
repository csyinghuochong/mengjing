using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public struct ShowItemTips
    {
        public BagInfo BagInfo;
        public ItemOperateEnum ItemOperateEnum;
        public float3 InputPoint;
        public List<BagInfo> EquipList;
        public int Occ;
    }

    public struct ShowFlyTip
    {
        public int Type;
        public string Str;
    }

    public struct TaskTypeItemClick
    {
        public TaskPro TaskPro;
    }

    public struct ReddotChange
    {
        public int ReddotType;
        public int Number;
    }

    public struct DataUpdate_UpdateUserData
    {
        public string DataParamString;
    }

    public struct UserDataTypeUpdate_Gold
    {
    }

    public struct UserDataTypeUpdate_Diamond
    {
    }

    public struct UserDataTypeUpdate_HorseNotice
    {
        public M2C_HorseNoticeInfo M2C_HorseNoticeInfo;
    }

    public struct DataUpdate_BagItemUpdate
    {
    }

    public struct DataUpdate_BagItemItemAdd
    {
    }

    public struct DataUpdate_FriendChat
    {
    }

    public struct DataUpdate_OnRecvChat
    {
    }

    public struct DataUpdate_FriendUpdate
    {
    }

    public struct DataUpdate_TaskUpdate
    {
    }

    public struct DataUpdate_TaskTrace
    {
    }

    public struct DataUpdate_TaskGet
    {
    }

    public struct DataUpdate_TaskComplete
    {
    }

    public struct DataUpdate_TaskGiveUp
    {
    }

    public struct DataUpdate_BeforeMove
    {
        public string DataParamString;
    }

    public struct DataUpdate_EquipWear
    {
    }

    public struct DataUpdate_HuiShouSelect
    {
        public string DataParamString;
    }

    public struct DataUpdate_PetItemSelect
    {
        public string DataParamString;
    }

    public struct DataUpdate_EquipHuiShow
    {
    }

    public struct DataUpdate_UpdateRoleProper
    {
    }

    public struct DataUpdate_PetHeChengUpdate
    {
    }

    public struct DataUpdate_PetXiLianUpdate
    {
    }

    public struct DataUpdate_JingLingButton
    {
    }

    public struct DataUpdate_SkillReset
    {
    }

    public struct DataUpdate_SkillUpgrade
    {
        public string DataParamString;
    }

    public struct DataUpdate_SkillSetting
    {
    }

    public struct DataUpdate_OnActiveTianFu
    {
    }

    public struct DataUpdate_MainHeroMove
    {
    }

    public struct DataUpdate_BuyBagCell
    {
    }

    public struct DataUpdate_TeamUpdate
    {
    }

    public struct DataUpdate_OnAccountWarehous
    {
        public string DataParamString;
        public long baginfoId;
    }

    public struct DataUpdate_OnMailUpdate
    {
        public string DataParamString;
        public long baginfoId;
    }

    public struct DataUpdate_ChouKaWarehouseAddItem
    {
    }

    public struct DataUpdate_SettingUpdate
    {
    }

    public struct DataUpdate_OnPetFightSet
    {
    }

    public struct ReturnLogin
    {
        public int ErrorCode;
    }

    public struct TaskNpcDialog
    {
        public int NpcId;
        public int ErrorCode;
    }

    public struct RolePetAdd
    {
        public List<KeyValuePair> OldPetSkin;
        public RolePetInfo RolePetInfo;
    }

    public struct RolePetUpdate
    {
        public long PetId;
        public int UpdateType;
        public string UpdateValue;
    }

    public struct SkillSound
    {
        public string Asset;
    }

    //技能特效
    public struct SkillEffect
    {
        public EffectData EffectData;
        public Unit Unit;
    }

    //技能预警
    public struct SkillYuJing
    {
        public SkillConfig SkillConfig;
        public SkillInfo SkillInfo;
        public Unit Unit;
    }

    public struct SkillEffectFinish
    {
        public long EffectInstanceId;
        public Unit Unit;
    }

    public struct SkillCDUpdate
    {
    }

    //吟唱
    public struct SingingUpdate
    {
        public Scene ZoneScene;
        public long PassTime;
        public long TotalTime;
        public int Type;
    }

    public struct ChangeCameraMoveType
    {
        public int CameraType;
    }

    public struct OnSkillUse
    {
        public int SkillId;
    }

    //动画
    public struct PlayAnimator
    {
        public string Animator;
        public Unit Unit;
    }

    //状态机
    public struct FsmChange
    {
        public int FsmHandlerType;
        public int SkillId;
        public Unit Unit;
    }

    public struct SkillBeging
    {
        public int SkillId;
    }

    public struct SkillFinish
    {
        public int SkillId;
    }

    public struct SkillEffectMove
    {
        public long EffectInstanceId;
        public float3 Postion;
        public float Angle;
        public Unit Unit;
    }

    public struct BuffUpdate
    {
        public BuffC ABuffHandler;
        public int OperateType;

        public Scene ZoneScene;
        public Unit Unit;
    }

    public struct SkillEffectReset
    {
        public long EffectInstanceId;
        public Unit Unit;
    }

    public struct BuffScale
    {
        public BuffC ABuffHandler;
        public int OperateType; //0开始 1结束
        public Scene ZoneScene;
        public Unit Unit;
    }

    //更新血量
    public struct Now_Hp_Update
    {
        public Unit Attack;
        public Unit Defend;
        public int SkillID;
        public int DamgeType;
        public long ChangeHpValue;
    }

    public struct BeforeSkill
    {
    }

    public struct RoleDataBroadcase
    {
        public int UserDataType;
        public string UserDataValue;
        public Unit Unit;
    }

    //副本结算
    public struct FubenSettlement
    {
        public M2C_FubenSettlement m2C_FubenSettlement;
    }

    public struct RunRaceBattleInfo
    {
        public M2C_RunRaceBattleInfo M2C_RunRaceBattleInfo;
    }
}