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

        public static float3 QuaternionToEuler(quaternion quat)
        {
            float3x3 matrix = QuaternionToMatrix(quat);

            float3 euler = MatrixToEuler(matrix);

            return math.degrees(euler);
        }

        private static float3x3 QuaternionToMatrix(quaternion q)
        {
            float x = q.value.x * 2.0f;
            float y = q.value.y * 2.0f;
            float z = q.value.z * 2.0f;
            float xx = q.value.x * x;
            float yy = q.value.y * y;
            float zz = q.value.z * z;
            float xy = q.value.x * y;
            float xz = q.value.x * z;
            float yz = q.value.y * z;
            float wx = q.value.w * x;
            float wy = q.value.w * y;
            float wz = q.value.w * z;

            float3x3 m = new float3x3
            {
                c0 = new float3(1.0f - (yy + zz), xy + wz, xz - wy),
                c1 = new float3(xy - wz, 1.0f - (xx + zz), yz + wx),
                c2 = new float3(xz + wy, yz - wx, 1.0f - (xx + yy))
            };

            return m;
        }

        private static float3 MatrixToEuler(float3x3 matrix)
        {
            float3 v = float3.zero;
            if (matrix.c2.y < 0.999f)
            {
                if (matrix.c2.y > -0.999f)
                {
                    v.x = math.asin(-matrix.c2.y);
                    v.y = math.atan2(matrix.c2.x, matrix.c2.z);
                    v.z = math.atan2(matrix.c0.y, matrix.c1.y);
                }
                else
                {
                    v.x = math.PI / 2f;
                    v.y = math.atan2(matrix.c0.z, matrix.c0.x);
                    v.z = 0.0f;
                }
            }
            else
            {
                v.x = -math.PI / 2f;
                v.y = math.atan2(-matrix.c0.z, matrix.c0.x);
                v.z = 0.0f;
            }

            return v;
        }
    }
}