using UnityEngine;

namespace FantasyRPG
{

    public class CtrBase : MonoBehaviour
    {
        private void Awake()
        {
            PlayManager.Instance.CurrentCtr = this;
        }
    }
}
