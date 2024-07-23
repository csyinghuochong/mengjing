using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIChengJiuShowChapterItem))]
    [EntitySystemOf(typeof(UIChengJiuShowChapterItem))]
    public static partial class UIChengJiuShowChapterItemSystem
    {
        [EntitySystem]
        private static void Awake(this UIChengJiuShowChapterItem self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            self.E_Ima_Di = rc.Get<GameObject>("E_Ima_Di");
            self.E_Ima_SelectStatus = rc.Get<GameObject>("E_Ima_SelectStatus");
            self.E_Ima_ItemIcon = rc.Get<GameObject>("E_Ima_ItemIcon");
            self.E_Ima_Progress = rc.Get<GameObject>("E_Ima_Progress");
            self.E_Ima_CompleteTask = rc.Get<GameObject>("E_Ima_CompleteTask");
            self.E_Lab_TaskNum = rc.Get<GameObject>("E_Lab_TaskNum");
            self.E_Lab_TaskName = rc.Get<GameObject>("E_Lab_TaskName");
            self.E_Ima_Di.GetComponent<Button>().AddListener(self.OnIma_Di);
        }

        public static void Init(this UIChengJiuShowChapterItem self, int type, int chapter, Action<int, int> onChapterAction)
        {
            self.Type = type;
            self.Chapter = chapter;
            self.OnChapterAction = onChapterAction;

            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            List<int> ids = chengJiuComponent.GetTasksByChapter(type, chapter);
            int number = 0;
            for (int i = 0; i < ids.Count; i++)
            {
                number += chengJiuComponent.ChengJiuCompleteList.Contains(ids[i]) ? 1 : 0;
            }

            using (zstring.Block())
            {
                self.E_Lab_TaskNum.GetComponent<Text>().text = zstring.Format(" ({0}/{1})", number, ids.Count);
            }

            self.E_Lab_TaskName.GetComponent<Text>().text = ChengJiuData.ChapterIndexText[chapter];
            self.E_Ima_Progress.transform.localScale = new Vector3(number * 1f / ids.Count, 1f, 1f);
            self.E_Ima_CompleteTask.gameObject.SetActive(number >= ids.Count);
        }

        public static void OnIma_Di(this UIChengJiuShowChapterItem self)
        {
            self.OnChapterAction?.Invoke(self.Type, self.Chapter);
        }

        public static void SetSelected(this UIChengJiuShowChapterItem self, int chapter)
        {
            self.E_Ima_SelectStatus.gameObject.SetActive(chapter == self.Chapter);
        }
    }
}