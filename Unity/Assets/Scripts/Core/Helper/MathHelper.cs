using Unity.Mathematics;

namespace ET
{
    public static class MathHelper
    {

       
        
        public static  float QuatationToEulerAngle_Y(quaternion q)
        {
            // 标准化四元数
            q = math.normalize(q);
            // 回旋角的计算
            
            float y = math.atan2(2f * q.value.w * q.value.y + 2 * q.value.x * q.value.z, 1 - 2 * q.value.x * q.value.x - 2 * q.value.y * q.value.y);

            return math.degrees(y); // 转换为度
        }
    }
}

