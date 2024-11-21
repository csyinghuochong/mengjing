using UnityEngine;

namespace ET
{
    public static class FsmStateEnum
    {
        public const int FsmNullState = 0;
        public const int FsmIdleState = 1;
        public const int FsmRunState = 2;
        public const int FsmDeathState = 3;
        public const int FsmSkillState = 4;
        public const int FsmComboState = 5;
        public const int FsmShiQuItem = 6;
        public const int FsmNpcSpeak = 7;
        public const int FsmSinging = 8;
        public const int FsmOpenBox = 9;
        public const int FsmHui = 10;
        public const int FsmHorse = 11;
    }
}
//
//     public class FsmStateUI: MonoBehaviour
//     {
//         public long SkillRigibTime;
//         public long SkillSingTime;
//         public long SkillMoveTime; //1旋风斩之类的技能
//         public Animator[] Animator;
//         public int CurrentFsm;
//
//         void Awake()
//         {
//         }
//
//         // Start is called before the first frame update
//         void Start()
//         {
//         }
//
//         // Update is called once per frame
//         void Update()
//         {
//             switch (this.CurrentFsm)
//             {
//                 case FsmStateEnum.FsmRunState:
//                     if (TimeHelper.ClientNow() >= this.SkillMoveTime && this.SkillMoveTime != 0)
//                     {
//                         this.SetRunState();
//                     }
//
//                     break;
//                 case FsmStateEnum.FsmSkillState:
//                     if (this.SkillSingTime > 0 && TimeHelper.ClientNow() >= this.SkillSingTime)
//                     {
//                         this.SetBoolValue("Idle", true);
//                     }
//
//                     if (this.SkillSingTime == 0 && TimeHelper.ClientNow() >= this.SkillRigibTime)
//                     {
//                         this.SetBoolValue("Idle", true);
//                     }
//
//                     break;
//             }
//         }
//
//         private void SetBoolValue(string idie, bool value)
//         {
//             for (int i = 0; i < this.Animator.Length; i++)
//             {
//                 this.Animator[i].SetBool(idie, value);
//             }
//         }
//         
//         private void PlayAnimator(string animator)
//         {
//             for (int i = 0; i < this.Animator.Length; i++)
//             {
//                 this.Animator[i].Play(animator);
//             }
//         }
//
//         public void OnInitUI(Animator[] animator)
//         {
//             this.Animator = animator;
//         }
//
//         public void ChangeState(int targetFSmState, string parasmss, int unitType)
//         {
//             if (this.Animator == null)
//             {
//                 return;
//             }
//
//             switch (this.CurrentFsm)
//             {
//                 case FsmStateEnum.FsmComboState:
//                     if (targetFSmState == FsmStateEnum.FsmComboState)
//                     {
//                         this.OnEnterFsmComboState(parasmss);
//                         return;
//                     }
//
//                     break;
//                 case FsmStateEnum.FsmDeathState:
//                     this.SetBoolValue("Death", false);
//                     break;
//                 case FsmStateEnum.FsmNpcSpeak:
//                     this.SetBoolValue("Idle", true);
//                     break;
//                 case FsmStateEnum.FsmSinging:
//                     //this.ClearnAnimator();
//                     this.SetBoolValue("Run", false);
//                     this.SetBoolValue("Idle", true);
//                     break;
//                 case FsmStateEnum.FsmSkillState:
//                     //this.ClearnAnimator();
//                     this.SetBoolValue("Run", false);
//                     this.SetBoolValue("Idle", true);
//                     break;
//                 default:
//                     break;
//             }
//
//             switch (targetFSmState)
//             {
//                 case FsmStateEnum.FsmComboState:
//                     //this.ClearnAnimator();
//                     this.SetBoolValue("Idle", false);
//                     this.SetBoolValue("Run", false);
//                     this.OnEnterFsmComboState(parasmss);
//                     break;
//                 case FsmStateEnum.FsmDeathState:
//                     this.SetBoolValue("Idle", false);
//                     this.SetBoolValue("Death", true);
//                     this.PlayAnimator("Death");
//                     break;
//                 case FsmStateEnum.FsmHui:
//                     this.SetBoolValue("Idle", false);
//                     this.PlayAnimator("Hui");
//                     break;
//                 case FsmStateEnum.FsmIdleState:
//                     this.SetIdleState();
//                     break;
//                 case FsmStateEnum.FsmNpcSpeak:
//                     //this.ClearnAnimator();
//                     this.SetBoolValue("Idle", false);
//                     this.SetBoolValue("Run", false);
//                     this.PlayAnimator("Speak");
//                     break;
//                 case FsmStateEnum.FsmRunState:
//                     this.OnEnterFsmFsmRunState(parasmss);
//                     break;
//                 case FsmStateEnum.FsmShiQuItem:
//                     //this.ClearnAnimator();
//                     this.SetBoolValue("Idle", false);
//                     this.SetBoolValue("Run", false);
//                     this.PlayAnimator("ShiQu");
//                     break;
//                 case FsmStateEnum.FsmSinging:
//                     //this.ClearnAnimator();
//                     this.SetBoolValue("Idle", false);
//                     this.SetBoolValue("Run", false);
//                     if (double.Parse(parasmss) > 0)
//                     {
//                         this.PlayAnimator("YinChang");
//                     }
//
//                     break;
//                 case FsmStateEnum.FsmSkillState:
//                     this.OnEnterFsmSkillState(parasmss);
//                     break;
//                 case FsmStateEnum.FsmHorse:
//                     this.SetBoolValue("Idle", false);
//                     this.SetBoolValue("Run", false);
//                     this.PlayAnimator("Horse");
//                     break;
//                 default:
//                     break;
//             }
//
//             this.CurrentFsm = targetFSmState;
//         }
//
//         public void OnEnterFsmSkillState(string paramss = "")
//         {
//             string[] animationinfos = paramss.Split('@');
//             this.SkillMoveTime = long.Parse(animationinfos[0]);
//             this.PlayAnimator(animationinfos[1]);
//
//             float singTime = float.Parse(animationinfos[2]);
//             if (singTime > 0f)
//             {
//                 this.SkillSingTime = TimeHelper.ClientNow() + (int)(1000f * singTime);
//             }
//             else
//             {
//                 this.SkillSingTime = 0;
//             }
//
//             float rigibTime = float.Parse(animationinfos[3]);
//             this.SkillRigibTime = TimeHelper.ClientNow() + (int)(1000f * rigibTime);
//         }
//
//         public void OnEnterFsmFsmRunState(string paramss = "")
//         {
//             if (TimeHelper.ClientNow() > this.SkillMoveTime)
//             {
//                 this.SetRunState();
//             }
//         }
//
//         public void SetIdleState()
//         {
//             this.SetBoolValue("Run", false);
//             this.SetBoolValue("Idle", true);
//             this.PlayAnimator("Idle");
//
//             Log.Debug("SetIdleState");
//         }
//
//         public void SetRunState()
//         {
//             this.SkillMoveTime = 0;
//             this.SetBoolValue("Idle", false);
//             this.SetBoolValue("Run", true);
//             this.PlayAnimator("Run");
//
//             Log.Debug("SetRunState");
//         }
//
//         public void OnEnterFsmComboState(string paramss = "")
//         {
//             string[] animations = paramss.Split('@');
//             string animation = animations[0];
//             int EquipType = int.Parse(animations[1]);
//             if (EquipType != 2)
//             {
//                 if (animation == "Act_1")
//                 {
//                     animation = "Act_11";
//                 }
//
//                 if (animation == "Act_2")
//                 {
//                     animation = "Act_12";
//                 }
//
//                 if (animation == "Act_3")
//                 {
//                     animation = "Act_13";
//                 }
//             }
//
//             this.PlayAnimator(animation);
//         }
//
//         public void ClearnAnimator()
//         {
//             //重置参数
//             this.SetBoolValue("Idle", false);
//             this.SetBoolValue("Run", false);
//             this.SetBoolValue("Death", false);
//             this.SetBoolValue("CriAct", false);
//             this.SetBoolValue("Act_1", false);
//             this.SetBoolValue("Act_2", false);
//             this.SetBoolValue("Act_3", false);
//         }
//     }
// }