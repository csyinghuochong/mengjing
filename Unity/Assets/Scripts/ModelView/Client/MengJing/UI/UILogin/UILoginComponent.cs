using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UI))]
    public class UILoginComponent: Entity, IAwake
    {
        public GameObject UIAgeTip;
        public GameObject AccountInF;
        public GameObject PasswordInF;
        public GameObject EnterBtn;
    }
}