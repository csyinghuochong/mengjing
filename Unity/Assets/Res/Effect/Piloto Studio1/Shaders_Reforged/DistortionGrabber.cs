using UnityEngine;
using UnityEngine.Rendering;

namespace PilotoStudio
{
    [RequireComponent(typeof(ParticleSystem))]
    public class DistortionGrabber : MonoBehaviour
    {
        private static readonly int OpaqueTexID = Shader.PropertyToID("_CameraOpaqueTexture");
        private static readonly int TempTexID = Shader.PropertyToID("_DistortionTempRT");

        private Camera _camera;
        private CommandBuffer _buffer;
        private ParticleSystem _fx;
        private bool _active;
#if !USING_URP && !USING_HDRP
        void Awake()
        {
            if (GraphicsSettings.currentRenderPipeline != null)
            {
                enabled = false;
                return;
            }

            _camera = Camera.main;
            _fx = GetComponent<ParticleSystem>();
        }

        void LateUpdate()
        {
            bool shouldActivate = _fx.IsAlive(true) && _fx.GetComponent<Renderer>().isVisible;

            if (shouldActivate && !_active)
                EnableEffect();
            else if (!shouldActivate && _active)
                DisableEffect();
        }

        void EnableEffect()
        {
            _buffer = new CommandBuffer { name = "Distortion Grab" };
            _buffer.GetTemporaryRT(TempTexID, Screen.width, Screen.height, 0, FilterMode.Bilinear);
            _buffer.Blit(BuiltinRenderTextureType.CurrentActive, TempTexID);
            _buffer.SetGlobalTexture(OpaqueTexID, TempTexID);

            _camera.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, _buffer);
            _camera.depthTextureMode |= DepthTextureMode.Depth;

            _active = true;
        }

        void DisableEffect()
        {
            if (_buffer != null)
            {
                _camera.RemoveCommandBuffer(CameraEvent.BeforeForwardAlpha, _buffer);
                _buffer.Release();
                _buffer = null;
            }

            _active = false;
        }

        void OnDisable() => DisableEffect();
    }
}
# endif