using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Hovl
{
    public class HS_CameraHolder : MonoBehaviour
    {
        public Transform Holder;
        public Vector3 cameraPos = new Vector3(0, 0, 0);
        public float currDistance = 5.0f;
        public float xRotate = 250.0f;
        public float yRotate = 120.0f;
        public float yMinLimit = -20f;
        public float yMaxLimit = 80f;
        public float prevDistance;
        private float x = 0.0f;
        private float y = 0.0f;

        [Header("Camera Height")]
        public float cameraHeightStep = 0.5f;

        [Header("GUI")]
        private float windowDpi;
        public GameObject[] Prefabs;
        private int Prefab;
        private GameObject Instance;
        private float StartColor;
        private float HueColor;
        public Texture HueTexture;
        public bool disableHue = false;

        // GUI visibility toggle
        private bool showGUI = true;

        void Start()
        {
            if (Screen.dpi < 1) windowDpi = 1;
            if (Screen.dpi < 200) windowDpi = 1;
            else windowDpi = Screen.dpi / 200f;
            var angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
            Counter(0);
        }

        void Update()
        {
            // Toggle GUI visibility with H key (supports both input systems)
            bool hPressed = false;
#if ENABLE_INPUT_SYSTEM
            if (Keyboard.current != null)
                hPressed = Keyboard.current.hKey.wasPressedThisFrame;
#endif
#if ENABLE_LEGACY_INPUT_MANAGER
            if (!hPressed)
                hPressed = Input.GetKeyDown(KeyCode.H);
#endif
            if (hPressed)
                showGUI = !showGUI;
        }

        private void OnGUI()
        {
            if (!showGUI)
                return;

            if (GUI.Button(new Rect(5 * windowDpi, 5 * windowDpi, 110 * windowDpi, 35 * windowDpi), "Previous effect"))
            {
                Counter(-1);
            }
            if (GUI.Button(new Rect(120 * windowDpi, 5 * windowDpi, 110 * windowDpi, 35 * windowDpi), "Play again"))
            {
                Counter(0);
            }
            if (GUI.Button(new Rect(235 * windowDpi, 5 * windowDpi, 110 * windowDpi, 35 * windowDpi), "Next effect"))
            {
                Counter(+1);
            }
            if (!disableHue)
            {
                StartColor = HueColor;
                HueColor = GUI.HorizontalSlider(new Rect(5 * windowDpi, 45 * windowDpi, 340 * windowDpi, 35 * windowDpi), HueColor, 0, 1);
                GUI.DrawTexture(new Rect(5 * windowDpi, 65 * windowDpi, 340 * windowDpi, 15 * windowDpi), HueTexture, ScaleMode.StretchToFill, false, 0);
                if (HueColor != StartColor)
                {
                    int i = 0;
                    foreach (var ps in particleSystems)
                    {
                        var main = ps.main;
                        Color colorHSV = Color.HSVToRGB(HueColor + H * 0, svList[i].S, svList[i].V);
                        main.startColor = new Color(colorHSV.r, colorHSV.g, colorHSV.b, svList[i].A);
                        i++;
                    }
                }
            }
        }

        private ParticleSystem[] particleSystems = new ParticleSystem[0];
        private List<SVA> svList = new List<SVA>();
        private float H;

        public struct SVA
        {
            public float S;
            public float V;
            public float A;
        }

        void Counter(int count)
        {
            Prefab += count;
            if (Prefab > Prefabs.Length - 1)
            {
                Prefab = 0;
            }
            else if (Prefab < 0)
            {
                Prefab = Prefabs.Length - 1;
            }
            if (Instance != null)
            {
                Destroy(Instance);
            }
            Instance = Instantiate(Prefabs[Prefab]);
            particleSystems = Instance.GetComponentsInChildren<ParticleSystem>();
            svList.Clear();
            foreach (var ps in particleSystems)
            {
                Color baseColor = ps.main.startColor.color;
                SVA baseSVA = new SVA();
                Color.RGBToHSV(baseColor, out H, out baseSVA.S, out baseSVA.V);
                baseSVA.A = baseColor.a;
                svList.Add(baseSVA);
            }
        }

        void LateUpdate()
        {
            if (currDistance < 2)
            {
                currDistance = 2;
            }

            if (GetUpArrowDown())
            {
                cameraPos.y += cameraHeightStep;
                prevDistance = -1;
            }

            if (GetDownArrowDown())
            {
                cameraPos.y -= cameraHeightStep;
                prevDistance = -1;
            }

            currDistance -= GetMouseScrollWheel() * 2;

            if (Holder && (GetMouseButton(0) || GetMouseButton(1)))
            {
                var pos = GetMousePosition();
                float dpiScale = 1;
                if (Screen.dpi < 1) dpiScale = 1;
                if (Screen.dpi < 200) dpiScale = 1;
                else dpiScale = Screen.dpi / 200f;
                if (pos.x < 380 * dpiScale && Screen.height - pos.y < 250 * dpiScale) return;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                x += (float)(GetMouseX() * xRotate * 0.02);
                y -= (float)(GetMouseY() * yRotate * 0.02);
                y = ClampAngle(y, yMinLimit, yMaxLimit);
                var rotation = Quaternion.Euler(y, x, 0);
                var position = rotation * new Vector3(0, 0, -currDistance) + Holder.position + cameraPos;
                transform.rotation = rotation;
                transform.position = position;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if (prevDistance != currDistance)
            {
                prevDistance = currDistance;
                var rot = Quaternion.Euler(y, x, 0);
                var po = rot * new Vector3(0, 0, -currDistance) + Holder.position + cameraPos;
                transform.rotation = rot;
                transform.position = po;
            }
        }

        private bool GetMouseButton(int button)
        {
#if ENABLE_INPUT_SYSTEM
            if (Mouse.current != null)
            {
                if (button == 0) return Mouse.current.leftButton.isPressed;
                if (button == 1) return Mouse.current.rightButton.isPressed;
            }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetMouseButton(button);
#else
            return false;
#endif
        }

        private Vector2 GetMousePosition()
        {
#if ENABLE_INPUT_SYSTEM
            if (Mouse.current != null)
                return Mouse.current.position.ReadValue();
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.mousePosition;
#else
            return Vector2.zero;
#endif
        }

        private float GetMouseX()
        {
#if ENABLE_INPUT_SYSTEM
            if (Mouse.current != null)
                return Mouse.current.delta.ReadValue().x * 0.05f;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetAxis("Mouse X") * 0.05f;
#else
            return 0f;
#endif
        }

        private float GetMouseY()
        {
#if ENABLE_INPUT_SYSTEM
            if (Mouse.current != null)
                return Mouse.current.delta.ReadValue().y * 0.05f;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetAxis("Mouse Y") * 0.05f;
#else
            return 0f;
#endif
        }

        private float GetMouseScrollWheel()
        {
#if ENABLE_INPUT_SYSTEM
            if (Mouse.current != null)
                return Mouse.current.scroll.ReadValue().y / 12f;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetAxis("Mouse ScrollWheel") * 10f;
#else
            return 0f;
#endif
        }

        private bool GetUpArrowDown()
        {
#if ENABLE_INPUT_SYSTEM
            if (Keyboard.current != null && Keyboard.current.upArrowKey.wasPressedThisFrame)
                return true;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetKeyDown(KeyCode.UpArrow);
#else
            return false;
#endif
        }

        private bool GetDownArrowDown()
        {
#if ENABLE_INPUT_SYSTEM
            if (Keyboard.current != null && Keyboard.current.downArrowKey.wasPressedThisFrame)
                return true;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetKeyDown(KeyCode.DownArrow);
#else
            return false;
#endif
        }

        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
            {
                angle += 360;
            }
            if (angle > 360)
            {
                angle -= 360;
            }
            return Mathf.Clamp(angle, min, max);
        }
    }
}