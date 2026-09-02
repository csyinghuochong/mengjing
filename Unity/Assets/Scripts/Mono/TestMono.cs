using UnityEngine;
using TMPro;

namespace ET
{
    [RequireComponent(typeof(TMP_Text))]
    public class TestMono : MonoBehaviour
    {
        private void Start()
        {
            this.GetComponent<TMP_Text>().text = "测试Unity.Mono程序集222";
        }
    }
}