using UnityEngine;

/*Script to disable lighting and shadows 
when moving away at a set distance*/
namespace Highlands
{
    public class LightCulling : MonoBehaviour
    {
        [SerializeField] private GameObject playerCamera;
        [SerializeField] private float shadowCullingDistance = 15f;
        [SerializeField] private float lightCullingDistance = 30f;
        private Light _light;
        private bool shadowsOn = false;

        private void Awake() 
        {
            _light = GetComponent<Light>();
            if (_light.shadows == LightShadows.Soft || _light.shadows == LightShadows.Hard)
            {
                shadowsOn = true;
            }
        }

        private void Update()
        {
            //Calculate the distance between a given object and the light source
            float cameraDistance = Vector3.Distance(playerCamera.transform.position, gameObject.transform.position);

            if (cameraDistance <= shadowCullingDistance && shadowsOn)
            {
                _light.shadows = LightShadows.Soft;
            }
            else
            {
                _light.shadows = LightShadows.None;
            }

            if (cameraDistance <= lightCullingDistance)
            {
                _light.enabled = true;
            }
            else
            {
                _light.enabled = false;
            }
        }
    }
}