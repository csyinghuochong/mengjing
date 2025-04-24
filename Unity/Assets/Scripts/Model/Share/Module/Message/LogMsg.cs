using System.Collections.Generic;

namespace ET
{
    public class LogMsg: Singleton<LogMsg>, ISingletonAwake
    {
        private readonly HashSet<ushort> ignore = new()
        {
            OuterMessage.C2R_Ping,
            OuterMessage.R2C_Ping,
            OuterMessage.C2G_Ping, 
            OuterMessage.G2C_Ping, 
            OuterMessage.C2G_Benchmark, 
            OuterMessage.G2C_Benchmark,
            //OuterMessage.C2M_PathfindingRequest,
            //OuterMessage.C2M_PathfindingResult,
            //OuterMessage.M2C_PathfindingResult,
            //OuterMessage.M2C_Stop,
            OuterMessage.M2C_UnitNumericUpdate,
            OuterMessage.M2C_UnitNumericListUpdate,
            OuterMessage.M2C_UnitBuffRemove,
            OuterMessage.M2C_UnitBuffStatus,
            OuterMessage.M2C_UnitBuffUpdate,
            //OuterMessage.C2M_SkillCmd,
            //OuterMessage.M2C_SkillCmd,
            //OuterMessage.M2C_UnitUseSkill,
            OuterMessage.M2C_HorseNoticeInfo,
        };

        public void Awake()
        {
        }

        public void Debug(Fiber fiber, object msg)
        {
            ushort opcode = OpcodeType.Instance.GetOpcode(msg.GetType());
            if (this.ignore.Contains(opcode))
            {
                return;
            }
            fiber.Log.Debug(msg.ToString() );
        }
    }
}