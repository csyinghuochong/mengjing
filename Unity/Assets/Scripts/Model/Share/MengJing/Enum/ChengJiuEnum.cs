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

    //1.��ɱָ������ID������
    //2.��ɱ�����������
    //3.��ɱ����BOSS
    //4.��ɱ��ͨ�Ѷ�BOSS
    //5.��ɱ��ս�Ѷ�BOSS
    //6.��ɱ�����Ѷ�BOSS

    //11.ͨ����ͨ�Ѷ�ID����N��
    //12.ͨ����ս�Ѷ�ID����N��
    //13.ͨ�ص����Ѷ�ID����N��
    //14.����(����)ͨ�ص����Ѷ�ID����N��
    //20 ͨ����Ӹ�������
    //21 ��սͨ�������Ԩ��������

    //201 �ۼƻ�ý��
    //202 �ۼ�ʮ����
    //203 �ۼ�װ��ϴ��
    //204 �ۼƸ���
    //205 ��ҵȼ�
    //206 �ۼƻ���װ��(δ����)
    //207 �ۼ�������ʯ(δ����)
    //208 ����������ȴﵽX��(δ����)
    //209 ��ս�����������������
    //210 ʹ�òر�ͼ����
    //211 ս���ﵽָ��ֵ
    //212 ʹ�ü���������װ��������������������Ʒ�ʣ�
    //213 ʹ�ø�ħ��������
    //214 ս����ʹ������ϼ���������ͨҩˮ����,�̶�ID��
    //215 ������Ф����
    //216 ����װ��/��������
    //217 �������������߻����������
    //218 �����г���װ������
    //219 �ۼ����Ľ��
    //220 ��Ϸ�����ۼƴ���
    //221 ��Ծ������ȡ100��Ծ�ȱ���Ĵ���
    //222 ���װ��ʱ����ĳ�����ؼ��ܣ�ID,������

    //301 ��ȡID����
    //302 �ۼƳ���������
    //303 �ۼƺϳɳ���
    //304 �ۼƳ���ϴ��
    //305 ӵ��N���ܳ���һֻ
    //306 ���������ﵰ����
    //307 �������ִﵽָ��ֵ
    //308 ��������λ���ִﵽָ��ֵ
    //309 �������ݴﵽ��X��
    //310 ����������ս����
    //311 ָ�����ʴﵽĳ��ֵ   ��1 ����  2���� 3 ��� 4 ħ�� 5 ħ����
    //312 ָ�����ʳ���ĳ��ֵ
    //��԰�µ�����
    //401 ũ���ջ�����
    //402 �����ջ�����
    //403 ����������
    //404 ��԰�ȼ�

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