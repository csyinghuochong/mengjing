using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
        //伤害范围检测函数
    public interface Shape
    {
        bool Contains(float3 point);
    }

    public class Circle : Shape
    {
        public float3 s_position { get; set; }   //检测体坐标
        public float range { get; set; }       //检测范围

        /// <summary>
        /// 是否在一定范围内
        /// </summary>
        /// <param name="point">被检测体坐标</param>
        /// <returns></returns>
        public bool Contains(float3 t_point)
        {
            return true;
            //return float3.Distance(s_position, t_point) <= range;
        }
    }

    public class Rectangle : Shape
    {

        public float3 s_position { get; set; }     //检测体坐标
        public float3 s_forward { get; set; }      //检测体朝向

        public float x_range { get; set; }      //检测X范围[左右的方向]
        public float z_range { get; set; }      //检测Z范围[向前的方向]

        //public bool if333 = false;

        
        public bool Contains(float3 t_point)
        {
            return false;
            // Vector3 direction = t_point - s_position;
            // if (direction == Vector3.zero)
            // {
            //     return true;
            // }
            // //与玩家正前方做点积  或者一条向量在另外一条向量上的投影
            // //点乘结果 如果大于0表示目标在攻击者前方 90度=0 <90度 >0 >90度 <0
            // float dot = Vector3.Dot(direction, s_forward.normalized);
            //
            // //取绝对值与矩形宽度的一半进行比较
            // if (dot <= 0 || dot > z_range)
            // {
            //     return false;
            // }
            //
            // Vector3 newVec = Quaternion.Euler(0f, 90f, 0f) * s_forward;
            // float rightDistance = Vector3.Dot(direction, newVec.normalized);
            //
            // return Mathf.Abs(rightDistance) <= x_range;
        }
    }

    public class Fan : Shape
    {
        public float3 s_position { get; set; }     //检测体坐标

        public float3 s_rotation{ get; set; }     //检测体坐标

        public float3 skill_distance{ get; set; }     //检测体坐标

        public float3 skill_angle{ get; set; }     //检测体坐标

        //矩形计算
        public bool Contains(float3 t_point)
        {
            // float distance = Vector3.Distance(s_position, t_point);//距离
            // Vector3 norVec = s_rotation * Vector3.forward;
            // Vector3 temVec = t_point - s_position;
            // float dot_len = v.Dot(norVec.normalized, temVec.normalized);
            //
            // float jiajiao = Math.Rad2Deg(Math.Acos(dot_len));//计算两个向量间的夹角
            //
            // return distance < skill_distance && jiajiao <= skill_angle;
            return false;
        }
    }
    
    //技能通用处理 (当己方血量低于某个百分比,伤害提升X百分比)
    public struct SkillParValue_HpUpAct
    {
        public int type;            // 1 低于  2 高于
        public float hpNeedPro;     // 血量要求百分比
        public float actAddPro;     // 攻击要求百分比
    }
    
    public class SkillHandlerAttribute : BaseAttribute
    {

    }
    
    
    [SkillHandler]
    public abstract class SkillHandler: Entity
    {
        public List<long> HurtIds = new List<long>();
        public Dictionary<long, long> LastHurtTimes = new Dictionary<long, long>();
        public Dictionary<int, float> TianfuProAdd;

        //1 正在执行   2完成使命
        public SkillState SkillState;

        public SkillConfig SkillConf;

        public long SkillBeginTime;    
        public long SkillEndTime;
        /// <summary>
        /// 记录是否触发过技能伤害
        /// </summary>
        public bool IsExcuteHurt;
        public long SkillExcuteHurtTime;
        public long SkillTriggerInvelTime;      //技能伤害触发间隔时间
        public long SkillTriggerLastTime;
        public long SkillFirstHurtTime;

        /// <summary>
        /// 持续伤害
        /// </summary>
        public long DamgeChiXuLastTime;

        public int SkillExcuteNum;

        public float3 NowPosition;             //当前技能的坐标点
        public float3 TargetPosition;

        public List<SkillParValue_HpUpAct> SkillParValueHpUpAct = new List<SkillParValue_HpUpAct>();        //目标血量处理高或者低 提升自身伤害

        //攻击目标临时增加/降低伤害
        public float ActTargetTemporaryAddPro { get; set; }

        //自身增加/降低伤害
        public float ActTargetAddPro = 0f;

        /// <summary>
        /// 伤害增加系数
        /// </summary>
        public float HurtAddPro = 0f;

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get; set; }

        public Unit TheUnitTarget { get; set; }

        public List<Shape> ICheckShape;

        public SkillInfo SkillInfo{ get; set; }

        // public abstract void OnInit(SkillInfo skillId, Unit theUnitFrom);
        //
        // public abstract void OnExecute();
        //
        // public abstract void OnUpdate();
        //
        // public abstract void OnFinished();
    }
}
