using System.Collections.Generic;
using System.Numerics;

namespace ET.Client
{
    /// <summary>
    /// 对应飘字的Prefab，如：UIBattleFly_Normal等
    /// </summary>
    public enum FallingFontType
    {
        Normal = 0,
        Self = 1,
        Target = 2,
        Add = 3,
        Special = 4,
        Yellow = 5,
        Purple = 6,
        Orange = 7,
    }

    /// <summary>
    /// 层级，数字越大，显示在上层
    /// </summary>
    public enum BloodTextLayer
    {
        Layer_0 = 0,
        Layer_1 = 1,
        Layer_2 = 2,
    }

    /// <summary>
    /// 飘字的逻辑
    /// </summary>
    public enum FallingFontExecuteType
    {
        /// <summary>
        /// 战斗飘字
        /// </summary>
        Type_0 = 0,

        /// <summary>
        /// 经验+金币+获取道具
        /// </summary>
        Type_1 = 1,

        /// <summary>
        /// 完成任务 升级
        /// </summary>
        Type_2 = 2,
    }

    [ComponentOf(typeof(Scene))]
    public class FallingFontComponent : Entity, IAwake, IDestroy
    {
        public long Timer;
        public List<EntityRef<FallingFontShowComponent>> FallingFontShows = new();
    }
}