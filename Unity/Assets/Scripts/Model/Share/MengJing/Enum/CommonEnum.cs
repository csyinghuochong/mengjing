using System.Collections.Generic;

namespace ET
{


    public class CertificateDomainInfo : Entity
    {
        public string CommonName { get; set; }
        public List<string> SubjectAlternativeNames { get; } = new List<string>();
    }

    public static class CellDungeonNpc
    {
        public const int HuiFuItem = 1;
        public const int ShenMiNpc = 2;
        public const int ChestList = 3;
        public const int MoLengRoom = 4;
    }

    public enum CellDungeonStatu : byte
    {
        None = 0,
        Start,          //起点                
        End,            //终点
        Passable,       //可以通行
        Impassable      //不可通行
    }

    public enum DirectionType : byte
    {
        None,
        Up,
        Left,
        Down,
        Right
    }

    [EnableClass]
    public class CellDungeonInfo
    {
        public int row;         //行
        public int line;        //列
        public int sonid;       //随机地块
        public byte ctype;      //格子属性
        public bool pass;       //是否通关
    }

    
    [EnableClass]
    public sealed class TikTokCode
    {
        public int code;        //返回码
        public string message;  //说明
        public string log_id;   //调用链id

        public TikTokData data;
    }

    
    [EnableClass]
    public sealed class TikTokData
    {
        public string sdk_open_id;      //用户唯一标识
        public int age_type;        //实名年龄段
    }

    
    [EnableClass]
    public sealed class TikTokPay
    {
        public int code;        //返回码
        public string message;  //说明
        public string sdk_param;   //调用链id
    }

    public struct ActivityTimer
    {
        public long BeginTime;
        public int FunctionId;
        public int FunctionType; //1开始 2结束
    }

    [EnableClass]
    public sealed class SMSSVerifyResult
    {
        //认证结果
        public int status;
        
        public string error;
    }

    public struct PropertyValue
    {
        public int HideID;
        public long HideValue;
    }
    
    [EnableClass]
    public class BossDevelopment
    {
        public string Name;
        public int Level;
        public float AttributeAdd;    //属性加成
        public float ReviveTimeAdd;     //复活时间
        public float DropAdd;           //掉落加成
        public int KillNumber;          //击杀次数
        public float ExpAdd;
    }

    public struct JianDingDate
    {
        public int MaxNum;
        public int MinNum;
    }

    public struct ActivityTipConfig
    {
        public long OpenTime;
        public long CloseTime;
        public string Conent;
        public int UIType;
        public List<int> OpenDay;
    }

    //技能ID 随机权重
    public struct EquipChuanChengList
    {
        public int SkillID;
        public int RandPro;
    }
    
    public struct WorldSayConfig
    {
        public int Time;
        public string Conent;
        public long ServerTime;
        public List<int> OpenDay;
    }

    public struct BuyCellCost
    {
        public string Cost;
        public string Get;
    }

    //家园收购
    public struct JiaYuanPurchase
    {
        public int ItemID;
        public int ItemNum;
        public int BuyMinZiJin;
        public int BuyMaxZiJin;
    }

    public struct PetMiningItem
    {
        public float X;
        public float Y;
    }

    public struct CollectionWord
    {
        public string Words;
        public string Reward;
    }

    public static class CombatResultEnum
    {
        public const int None = 0;
        public const int Win = 1;
        public const int Fail = 2;
    }

    public static class CampEnum
    {
        public const int CampMonster1 = 0;
        public const int CampPlayer_1 = 1;
        public const int CampPlayer_2 = 2;
    }

    public static class LoginTypeEnum
    {
        public const int RegisterLogin = 0;     //注册账号登录
        public const int WeixLogin = 1;         //微信登录
        public const int QQLogin = 2;           //QQ登录
        public const int PhoneCodeLogin = 3;         //短信验证吗登录
        public const int PhoneNumLogin = 4;        //手机号登录
        public const int TapTap = 5;                //taptap登录
        public const int TikTok = 6;                //抖音登录
    }

    public static class PayTypeEnum
    {
        public const int WeiXinPay = 1;
        public const int AliPay = 2;
        public const int QuDaoPay = 3;
        public const int IOSPay = 4;
        public const int TikTok = 5;
    }

    public static class ReddotType
    {
        public const int Friend = 100;
        public const int FriendApply = 101;
        public const int FriendChat = 102;
        public const int UnionMy = 110;
        public const int UnionApply = 111;


        public const int Team = 200;
        public const int TeamApply = 201;

        public const int Email = 300;

        /// <summary>
        /// 角色属性点
        /// </summary>
        public const int RolePoint = 400;

        /// <summary>
        /// 技能点
        /// </summary>
        public const int SkillUp = 500;

        /// <summary>
        /// 宠物战斗
        /// </summary>
        public const int PetSet = 600;
        public const int PetMine = 601;

        public const int Welfare = 700;
        public const int WelfareLogin = 701;
        public const int WelfareTask = 702;
        public const int WelfareDraw = 703;

        //活动
        public const int Activity = 800;
        public const int SingleRecharge = 801;

        public const int Chat = 901;
        public const int WordChat = 902;
        public const int TeamChat = 903;
        public const int UnionChat = 904;
        public const int SystemChat = 905;
        public const int PaiMaiChat = 906;
    }

    public enum GameSettingEnum
    {
        None = 0,
        Music,
        Sound,
        YanGan,         //1移动 2固定
        MusicVolume,    //音乐大小
        SoundVolume,    //音效大小
        FenBianlLv = 6,     //分辨率[1流暢 2一般]
        HighFps = 7,         //0 30帧 1 60帧
        Click = 8,
        Shadow = 9,
        RandomHorese = 10,  //随机坐骑
        OneSellSet = 11,    //一键出售
        AttackMode = 12,
        AttackTarget = 13,
        Smooth = 14,         //流畅模式
        NoShowOther = 15,          //显示其他玩家
        AutoAttack = 16,         //自动攻击
        OneSellSet2 = 17,    // 一键出售 低级、中级、。。。
        HideLeftBottom = 18, //进入野外和个人副本 组队副本 左下角的功能图标自动隐藏 回到主城自动显示
        FirstUnionName = 19,         //优先显示公会称号
        SkillAttackPlayerFirst = 20, //技能优先攻击玩家
        PickSet = 21,               // 自动拾取过滤
      
        //挂机相关设置
        GuaJiSell = 201,      //一键出售  
        GuaJiRang = 202,      //挂机范围
        GuaJiAutoUseItem = 203,     //自动使用药剂
        GuaJiAutoUseSkill = 204, // 按照设置顺序自动使用技能
    }

    //1：普通
    //2：精英
    //3：BOSS
    //4：怪物召唤
    //5：场景物【场景怪 能量台子 传送门】

    public static class MonsterTypeEnum
    {
        public const int None = 0;
        public const int Normal = 1;
        public const int Elite = 2;
        public const int Boss = 3;
        public const int ZhaoHuan = 4;
        public const int SceneItem = 5;
    }

    public static class MonsterSonTypeEnum
    {
        public const int Type_1 = 1;//1 密境怪物
        public const int Type_2 = 2;//2 副本怪物
        public const int Type_3 = 3;//3 任务怪物
        public const int Type_51 = 51;//51 场景怪 有AI 不显示名称
        public const int Type_52 = 52;//52 能量台子 无AI
        public const int Type_53 = 53;//53 传送门
        public const int Type_54 = 54;//54 场景怪 有AI 显示名称
        public const int Type_55 = 55;//55 宝箱类(一次) 无AI
        public const int Type_56 = 56;//56 宝箱类(无限) 无AI 刷新地图后即可刷新
        public const int Type_57 = 57;//57 宠物蛋 直接掉落进背包
        public const int Type_58 = 58;//58 宠物实体
        public const int Type_59 = 59;//59 精灵实体
        public const int Type_60 = 60;//60 家园物品
        public const int Type_61 = 61;//61 小龟
        public const int Type_62 = 62;//62 基地
        public const int Type_101 = 101;//101 猎魔
        public const int Type_102 = 102;//102 曙光
    }

    public enum PetMeleeCarType
    {
        MainPet = 1,
        AssistPet = 2,
        Magic = 3,
    }
}
