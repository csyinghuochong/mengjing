using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Hovl
{
    public class HS_RaycastInstance : MonoBehaviour
    {
        public Camera Cam;
        public GameObject[] Prefabs;
        public float destroyTimer = 1.5f;
        public bool useHitNormal = false;
        public bool prefabAddLocation = false;
        private int Prefab;
        private Ray RayMouse;
        private GameObject Instance;
        private float windowDpi;

        //Double-click protection
        private float buttonSaver = 0f;

        // GUI visibility toggle
        private bool showGUI = true;

        void Start()
        {
            if (Screen.dpi < 1) windowDpi = 1;
            if (Screen.dpi < 200) windowDpi = 1;
            else windowDpi = Screen.dpi / 200f;
            Counter(0);
        }

        void Update()
        {
            bool firePressed = false;

#if ENABLE_INPUT_SYSTEM
            if (Mouse.current != null)
                firePressed = Mouse.current.leftButton.wasPressedThisFrame;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            if (!firePressed)
                firePressed = Input.GetButtonDown("Fire1");
#endif

            if (firePressed)
            {
                if (Cam != null)
                {
                    RaycastHit hit;
                    Vector3 mousePos = Vector3.zero;

#if ENABLE_INPUT_SYSTEM
                    if (Mouse.current != null)
                        mousePos = Mouse.current.position.ReadValue();
                    else
#endif
#if ENABLE_LEGACY_INPUT_MANAGER
                        mousePos = Input.mousePosition;
#else
                    mousePos = Vector3.zero;
#endif

                    RayMouse = Cam.ScreenPointToRay(mousePos);
                    if (Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit, 40))
                    {
                        Instance = Instantiate(Prefabs[Prefab]);

                        // base spawn position on hit point
                        Vector3 spawnPos = hit.point + hit.normal * 0.01f;

                        // if requested, add the prefab's configured position offset
                        if (prefabAddLocation && Prefabs.Length > 0 && Prefabs[Prefab] != null)
                        {
                            spawnPos += Prefabs[Prefab].transform.position;
                        }

                        Instance.transform.position = spawnPos;
                        if (useHitNormal)
                            Instance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                        
                        // Determine destroy time: prefer particle system duration if present, otherwise use destroyTimer
                        float destroyDelay = destroyTimer;
                        var particleSystem = Instance.GetComponent<ParticleSystem>();
                        if (particleSystem != null)
                        {
                            var main = particleSystem.main;
                            float duration = main.duration;
                            if (duration > 0f)
                                destroyDelay = duration;
                        }

                        Destroy(Instance, destroyDelay);
                    }
                }
                else
                {
                    Debug.Log("No camera");
                }
            }

            bool leftPressed = false;
            bool rightPressed = false;

#if ENABLE_INPUT_SYSTEM
            // keyboard
            if (Keyboard.current != null)
            {
                leftPressed = Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed;
                rightPressed = Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed;
            }
            // gamepad horizontal axis fallback
            if (!leftPressed && !rightPressed && Gamepad.current != null)
            {
                float horiz = Gamepad.current.leftStick.x.ReadValue();
                leftPressed = horiz < 0f;
                rightPressed = horiz > 0f;
            }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            if (!leftPressed)
                leftPressed = Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0;
            if (!rightPressed)
                rightPressed = Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0;
#endif

            if (leftPressed && buttonSaver >= 0.4f)// left button
            {
                buttonSaver = 0f;
                Counter(-1);
            }
            if (rightPressed && buttonSaver >= 0.4f)// right button
            {
                buttonSaver = 0f;
                Counter(+1);
            }
            buttonSaver += Time.deltaTime;

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

        void OnGUI()
        {
            if (!showGUI)
                return;

            GUI.Label(new Rect(10 * windowDpi, 5 * windowDpi, 400 * windowDpi, 20 * windowDpi), "Use the keyboard buttons A/<- and D/-> to change prefabs!");
            GUI.Label(new Rect(10 * windowDpi, 20 * windowDpi, 400 * windowDpi, 20 * windowDpi), "Use left mouse button for instancing!");
            GUI.Label(new Rect(10 * windowDpi, 35 * windowDpi, 400 * windowDpi, 20 * windowDpi), "Use H button to hide GUI");
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
        }
    }
}