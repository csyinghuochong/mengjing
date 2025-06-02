using UnityEngine;
using System.Collections;

namespace GrassMobileShader.Demo
{
    [HelpURL("https://assetstore.unity.com/packages/slug/265141")]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 7f, rotationSpeed = 1.8f, acceleration = 2.5f, smoothnessSpeed = 12f, minPosY = 0.15f;

        private float maxRotationX = 75f, minRotationX = -85f;

        private Vector3 targetPos;

        /// <summary>
        /// Initializing the controller
        /// </summary>
        /// <returns></returns>
        private IEnumerator Start()
        {
            targetPos = transform.position;
            if (Application.isMobilePlatform)
            {
                Application.targetFrameRate = 60;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            yield return null;
            transform.eulerAngles = Vector3.zero;
        }

        /// <summary>
        /// Camera free flight control
        /// </summary>
        private void Update()
        {
            bool W = Input.GetKey(KeyCode.W) || MobileCanvas.W;
            bool D = Input.GetKey(KeyCode.D) || MobileCanvas.D;
            bool S = Input.GetKey(KeyCode.S) || MobileCanvas.S;
            bool A = Input.GetKey(KeyCode.A) || MobileCanvas.A;
            bool E = Input.GetKey(KeyCode.E) || MobileCanvas.E;
            bool Q = Input.GetKey(KeyCode.Q) || MobileCanvas.Q;
            bool boostActive = Input.GetKey(KeyCode.LeftShift) || MobileCanvas.BoostActive;
            targetPos += (transform.forward * (W ? 1f : (S ? -1f : 0f)) +
                          transform.right * (D ? 1f : (A ? -1f : 0f)) +
                          transform.up * 0.5f * (Q ? 1f : (E ? -1f : 0f))) * moveSpeed * (boostActive ? acceleration : 1f) * Time.deltaTime;
            if (targetPos.y < minPosY)
            {
                targetPos = new Vector3(targetPos.x, minPosY, targetPos.z);
            }
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothnessSpeed * Time.deltaTime);
            if (!Application.isMobilePlatform)
            {
                transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * rotationSpeed;
            }
            float rotationX = Mathf.Clamp((transform.eulerAngles.x > 180f) ? transform.eulerAngles.x - 360f : transform.eulerAngles.x, minRotationX, maxRotationX);
            transform.eulerAngles = new Vector3((rotationX < 0f) ? rotationX + 360f : rotationX, transform.eulerAngles.y, 0f);
        }
    }
}
