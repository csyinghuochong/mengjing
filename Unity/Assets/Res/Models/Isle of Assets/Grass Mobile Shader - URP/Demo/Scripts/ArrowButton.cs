using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace GrassMobileShader.Demo
{
    [HelpURL("https://assetstore.unity.com/packages/slug/265141")]
    public class ArrowButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private ArrowType arrowType = ArrowType.Backward;

        [SerializeField]
        private float secondClickWaitDuration = 0.5f;

        private Coroutine waitForSecondClickCoroutine;

        private enum ArrowType { Left, Right, Forward, Backward, Up, Down };

        /// <summary>
        /// Waiting for the second click to accelerate
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitForSecondClick()
        {
            yield return new WaitForSeconds(secondClickWaitDuration);
            waitForSecondClickCoroutine = null;
        }

        /// <summary>
        /// Perform player movement on the map
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (waitForSecondClickCoroutine != null)
            {
                waitForSecondClickCoroutine = null;
                MobileCanvas.BoostActive = true;
            }
            else
            {
                waitForSecondClickCoroutine = StartCoroutine(WaitForSecondClick());
            }
            SetState(true);
        }

        /// <summary>
        /// Stop the player's movement on the map
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            SetState(false);
            MobileCanvas.BoostActive = false;
        }

        /// <summary>
        /// Set an actively pressed button depending on its type
        /// </summary>
        /// <param name="state"></param>
        private void SetState(bool state)
        {
            switch (arrowType)
            {
                case ArrowType.Left:
                    {
                        MobileCanvas.A = state;
                        break;
                    }
                case ArrowType.Right:
                    {
                        MobileCanvas.D = state;
                        break;
                    }
                case ArrowType.Forward:
                    {
                        MobileCanvas.W = state;
                        break;
                    }
                case ArrowType.Backward:
                    {
                        MobileCanvas.S = state;
                        break;
                    }
                case ArrowType.Up:
                    {
                        MobileCanvas.Q = state;
                        break;
                    }
                case ArrowType.Down:
                    {
                        MobileCanvas.E = state;
                        break;
                    }
            }
        }
    }
}
