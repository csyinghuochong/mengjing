using Unity.Mathematics;

namespace ET
{
    public static class MathHelper
    {
        public static bool Equal(float3 lhs, float3 rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
        }

        public static float QuaternionToEulerAngle_Y(quaternion q)
        {
            // 标准化四元数
            q = math.normalize(q);
            // 回旋角的计算

            float y = math.atan2(2f * q.value.w * q.value.y + 2 * q.value.x * q.value.z, 1 - 2 * q.value.x * q.value.x - 2 * q.value.y * q.value.y);

            return math.degrees(y); // 转换为度
        }

        public static float3 ToEulerAngles(this quaternion q)
        {
            return math.degrees(ToEulerRad(q));
        }

        private static float3 ToEulerRad(quaternion q)
        {
            // 计算旋转矩阵的各个元素
            float sinr_cosp = 2 * (q.value.w * q.value.x + q.value.y * q.value.z);
            float cosr_cosp = 1 - 2 * (q.value.x * q.value.x + q.value.y * q.value.y);
            float roll = math.atan2(sinr_cosp, cosr_cosp);

            float sinp = 2 * (q.value.w * q.value.y - q.value.z * q.value.x);
            float pitch;
            if (math.abs(sinp) >= 1)
                pitch = math.PI / 2 * math.sign(sinp); // 使用90度，如果超出范围
            else
                pitch = math.asin(sinp);

            float siny_cosp = 2 * (q.value.w * q.value.z + q.value.x * q.value.y);
            float cosy_cosp = 1 - 2 * (q.value.y * q.value.y + q.value.z * q.value.z);
            float yaw = math.atan2(siny_cosp, cosy_cosp);

            return new float3(roll, pitch, yaw);
        }
    }
}