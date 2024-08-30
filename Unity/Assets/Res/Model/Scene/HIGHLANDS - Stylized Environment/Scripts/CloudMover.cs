using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Highlands
{

    public class CloudMover : MonoBehaviour
    {
        [SerializeField] private float speed = 0.1f;

        void Update()
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
