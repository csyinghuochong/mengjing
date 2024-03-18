using UnityEngine;

namespace ET.Client
{
    //动画状态机组件
    [ComponentOf(typeof (Unit))]

public class FsmComponent : Entity, IAwake, IDestroy
    {
        public int CurrentFsm;


        public long Timer;

        public long WaitIdleTime;

        private EntityRef<AnimatorComponent> animatorComponent;

        public AnimatorComponent AnimatorComponent
        {
            get => this.animatorComponent;
            set => this.AnimatorComponent = value;
        }
        public string LastAnimator; 
    }
}
