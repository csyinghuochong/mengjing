namespace ET
{


    public enum ChengJiuTypeEnum : int
    {
        None = 0,
        GuanKa = 1,
        TanSuo = 2,
        ShouJi = 3,
        Number = 4,
    }

    public enum SpiritTypeEnum : int
    {
        None = 0,
        GuanKa = 1,
        TanSuo = 2,
        ShouJi = 3,
        Number = 4,
    }

    //1.ÿ����������� ����:����ID
    //2.ʰȡ���ϵĽ��
    //3.ʰȡ���ϵĽ�Һ͵���
    //4.�������� ����:����ID(ȡ����ǰ����Ҫȡ����Ӧ�ļ���Buff)
    //5.������������ ����: ����
    //6.ÿ�λ��ܹ�����⸽��һ������ID ����: ����ID
    //7.�򿪶�Ӧϵͳ���� ����: ����ID
    public static class JingLingFunctionType
    {
        public const int RandomDrop = 1;
        public const int PickGold = 2;

        public const int AddSkill = 4;
        public const int AddProperty = 5;
        public const int ExtraDrop = 6;
        public const int OpenFunction = 7;
    }

    //1.击杀指定怪物ID的数量
    //2.击杀任意怪物数量
    //3.击杀任意BOSS
    //4.击杀普通难度BOSS
    //5.击杀挑战难度BOSS
    //6.击杀地狱难度BOSS

    //11.通关普通难度ID副本N次
    //12.通关挑战难度ID副本N次
    //13.通关地狱难度ID副本N次
    //14.完美(三星)通关地狱难度ID副本N次
    //20 通关组队副本次数
    //21 挑战通关组队深渊副本次数

    //201 累计获得金币
    //202 累计十连抽
    //203 累计装备洗练
    //204 累计复活
    //205 玩家等级
    //206 累计回收装备(未添加)
    //207 累计消耗钻石(未添加)
    //208 生活技能熟练度达到X点(未添加)
    //209 挑战并击败其他玩家数量
    //210 使用藏宝图数量
    //211 战力达到指定值
    //212 使用鉴定符鉴定装备数量（参数：鉴定符品质）
    //213 使用附魔道具数量
    //214 战斗中使用炼金合剂数量（普通药水不算,固定ID）
    //215 穿戴生肖数量
    //216 制造装备/道具数量
    //217 拍卖行售卖道具获利金币数量
    //218 拍卖行出售装备数量
    //219 累计消耗金币
    //220 游戏分享累计次数
    //221 活跃任务领取100活跃度宝箱的次数
    //222 获得装备时激活某个隐藏技能（ID,次数）

    //301 获取ID宠物
    //302 累计宠物总数量
    //303 累计合成宠物
    //304 累计宠物洗练
    //305 拥有N技能宠物一只
    //306 开启珍贵宠物蛋数量
    //307 宠物评分达到指定值
    //308 宠物上阵单位评分达到指定值
    //309 宠物天梯达到第X名
    //310 宠物天梯挑战次数
    //311 指定资质达到某个值   （1 生命  2攻击 3 物防 4 魔防 5 魔法）
    //312 指定资质超过某个值
    //家园新的类型
    //401 农场收货次数
    //402 牧场收货次数
    //403 烹饪制造次数
    //404 家园等级

    public enum ChengJiuTargetEnum : int
    {
        None,
        KillIDMonster_1 = 1,
        KillTotalMonster_2 = 2,
        KillTotalBoss_3 = 3,
        KillNormalBoss_4 = 4,
        KillChallengeBoss_5 = 5,
        KillInfernalBoss_6 = 6,

        PassNormalFubenID_11 = 11,
        PassChallengeFubenID_12 = 12,
        PassInfernalFubenID_13 = 13,
        PerfectPassInfernalFubenID_14 = 14,
        PassTeamFubenNumber_20 = 20,
        PassTeamShenYuanNumber_21 = 21,

        TotalCoinGet_201 = 201,
        TotalChouKaTen_202 = 202,
        TotalEquipXiLian_203 = 203,
        TotalRevive_204 = 204,
        PlayerLevel_205 = 205,
        TotalEquipHuiShou_206 = 206,
        TotalDiamondCost_207 = 207,
        SkillShuLianDu_208 = 208,
        KillPlayerNumber_209 = 209,
        TreasureMapNumber_210 = 210,
        CombatToValue_211 = 211,
        JianDingEqipNumber_212 = 212,
        FoMoNumber_213 = 213,
        BattleUseItem_214 = 214,
        ZodiacEquipNumber_215 = 215,
        MakeNumber_216 = 216,
        PaiMaiGetGoldNumber_217 = 217,
        PaiMaiSellNumber_218 = 218,
        TotalCostGold_219 = 219,
        ShareTotalNumber_220 = 220,
        HuoYue100Reward_221 = 221,
        EquipActiveSkillId_222 = 222,

        PetIdNumber_301 = 301,
        TotalPetNumber_302 = 302,
        TotalPetHeCheng_303 = 303,
        TotalPetXiLian_304 = 304,
        PetNSkill_305 = 305,
        OpenZGPetEggNumber_306 = 306,
        PegScoreToValue_307 = 307,
        PetArrayScoreToValue_308 = 308,
        PetTianTiRank_309 = 309,
        PetTianTiNumber_310 = 310,
        ZiZhiToValue_311 = 311,
        ZiZhiUpValue_312 = 312,

        //401 ũ���ջ�����
        //402 �����ջ�����
        //403 ����������
        //404 ��԰�ȼ�
        JiaYuanGatherPlant_401 = 401,
        JiaYuanGatherPasture_402 = 402,
        JiaYuanCooking_403 = 403,
        JiaYuanLevel_404 = 404,
    }

}