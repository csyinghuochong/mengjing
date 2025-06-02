using UnityEngine;
using UnityEngine.EventSystems;

namespace GrassMobileShader.Demo
{
    [HelpURL("https://assetstore.unity.com/packages/slug/265141")]
    public class CameraRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField]
        private Transform player = null;

        [SerializeField]
        private float sensitivity = 0f;

        private Vector2 lastPos, pos, savePos;

        /// <summary>
        /// Saving the touch position
        /// </summary>
        /// <param name="data"></param>
        public void OnPointerDown(PointerEventData data)
        {
            savePos = data.position;
        }

        /// <summary>
        /// Camera rotation
        /// </summary>
        /// <param name="data"></param>
        public void OnDrag(PointerEventData data)
        {
            pos = lastPos + (data.position - savePos) * sensitivity;
            Quaternion rotate = Quaternion.AngleAxis(pos.x, Vector3.up) *
                                Quaternion.AngleAxis(Mathf.Clamp(pos.y, -80, 80), -Vector3.right);
            player.eulerAngles = new Vector3(rotate.eulerAngles.x, rotate.eulerAngles.y, 0);
        }

        /// <summary>
        /// Saving the last touch position
        /// </summary>
        /// <param name="data"></param>
        public void OnPointerUp(PointerEventData data)
        {
            lastPos = pos;
        }
    }
}