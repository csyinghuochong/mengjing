using UnityEngine;

namespace ET
{
    /// <summary>
    /// 将 UGUI 默认的矩形射线范围限制为 RectTransform 内接椭圆。
    /// RectTransform 为正方形时，射线范围就是正圆。
    /// </summary>
    [DisallowMultipleComponent]
    public class CircularRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
    {
        public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
        {
            RectTransform rectTransform = transform as RectTransform;
            if (rectTransform == null ||
                !RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, eventCamera,
                    out Vector2 localPoint))
            {
                return false;
            }

            return IsLocalPointInside(rectTransform, localPoint);
        }

        public static bool IsLocalPointInside(RectTransform rectTransform, Vector2 localPoint)
        {
            Rect rect = rectTransform.rect;
            float halfWidth = rect.width * 0.5f;
            float halfHeight = rect.height * 0.5f;
            if (halfWidth <= 0f || halfHeight <= 0f)
            {
                return false;
            }

            Vector2 offset = localPoint - rect.center;
            float normalizedX = offset.x / halfWidth;
            float normalizedY = offset.y / halfHeight;
            return normalizedX * normalizedX + normalizedY * normalizedY <= 1f;
        }
    }
}