using System;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIChengJiuShowChapterItem: Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject E_Ima_Di;
        public GameObject E_Ima_SelectStatus;
        public GameObject E_Ima_ItemIcon;
        public GameObject E_Ima_Progress;
        public GameObject E_Ima_CompleteTask;
        public GameObject E_Lab_TaskNum;
        public GameObject E_Lab_TaskName;
        public int Type;
        public int Chapter;
        public Action<int, int> OnChapterAction;
    }
}