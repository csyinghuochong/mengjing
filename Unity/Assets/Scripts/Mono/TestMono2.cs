using TMPro;
using UnityEngine;

namespace ET
{
    public class TestMono2: MonoBehaviour
    {
        public void Test(string info)
        {
            this.GetComponentInChildren<TMP_Text>().SetText($"测试Unity.Mono2 {info}");
        }
    }
}