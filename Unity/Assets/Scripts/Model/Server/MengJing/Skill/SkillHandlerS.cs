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
            float3 direction = t_point - s_position;
            if ( MathHelper.Equal( direction , float3.zero) )
            {
                return true;
            }
            
            //与玩家正前方做点积  或者一条向量在另外一条向量上的投影
            //点乘结果 如果大于0表示目标在攻击者前方 90度=0 <90度 >0 >90度 <0
            float dot = math.dot(direction, s_forward);
            //取绝对值与矩形宽度的一半进行比较
            if (dot <= 0 || dot > z_range)
            {
                return false;
            }
            
            float3 newVec = math.mul(quaternion.Euler(0f, 90f, 0f) , s_forward) ;
            float rightDistance = math.dot(direction, newVec);
            
            return math.abs(rightDistance) <= x_range;
        }
    }

    public class Fan : Shape
    {
        public float3 s_position { get; set; }     //检测体坐标

        public quaternion s_rotation{ get; set; }     //检测体坐标

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
    
    public class SkillHandlerSAttribute : BaseAttribute
    {

    }
    
    
    [SkillHandlerS]
    public abstract class SkillHandlerS
    {
        public abstract void OnInit(SkillS skillS,  Unit theUnitFrom);
        
        public abstract void OnExecute(SkillS skillS);
        
        public abstract void OnUpdate(SkillS skillS,  int updateMode);
        
        public abstract void OnFinished(SkillS skillS);
    }
}
