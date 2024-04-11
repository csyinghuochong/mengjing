using Unity.Mathematics;

namespace ET
{
    public static class MathHelper
    {

        public static float3 QuatationToEulerAngles_2(quaternion quat)
        {
            float sqw = quat.value.w * quat.value.w;
            float sqx = quat.value.x * quat.value.x;
            float sqy = quat.value.y * quat.value.y;
            float sqz = quat.value.z * quat.value.z; 
           
            Log.Debug($"quaternion: w  {quat.value.w}  x  {quat.value.x} y  {quat.value.y}  z  {quat.value.z}");

            float pitch = math.atan2( 2f * ( quat.value.y * quat.value.z + quat.value.w * quat.value.x ), sqw - sqx - sqy + sqz );

            float yaw = math.asin(-2f * (quat.value.x * quat.value.z - quat.value.w * quat.value.y));

            float roll = math.atan2(2f * (quat.value.x * quat.value.y + quat.value.w * quat.value.z), sqw + sqx - sqy - sqz);
            Log.Debug($"quaternion: angele { math.degrees(yaw)}");
            return new float3(  math.degrees(pitch), math.degrees(yaw), math.degrees(roll) ) ;
        }

        
        public static  float3 QuatationToEulerAngle_3(quaternion q)
        {
            // 标准化四元数

            float sqw = q.value.w * q.value.w;
            float sqx = q.value.x * q.value.x;
            float sqy = q.value.y * q.value.y;
            float sqz = q.value.z * q.value.z;
 
            // 回旋角的计算
            float pitch = math.atan2(2 * q.value.y * q.value.w - 2 * q.value.x * q.value.z, sqw - sqx - sqy + sqz);
            float yaw = math.atan2(2 * q.value.x * q.value.w - 2 * q.value.y * q.value.z, sqw + sqx - sqy - sqz);
            float roll = math.asin(2 * q.value.x * q.value.y + 2 * q.value.z * q.value.w);
 
            return new float3(pitch, yaw, roll) * 57.29578f; // 转换为度
        }
        
        public static  float3 QuatationToEulerAngle(quaternion q)
        {
            // 标准化四元数

            float sqw = q.value.w * q.value.w;
            float sqx = q.value.x * q.value.x;
            float sqy = q.value.y * q.value.y;
            float sqz = q.value.z * q.value.z;
 
            // 回旋角的计算
            float y = math.atan2(2f * q.value.w * q.value.y + 2 * q.value.x * q.value.z, 1 - 2 * q.value.x * q.value.x - 2 * q.value.y * q.value.y);
 
            return new float3(0, y, 0) * 57.29578f; // 转换为度
        }
    }
}

