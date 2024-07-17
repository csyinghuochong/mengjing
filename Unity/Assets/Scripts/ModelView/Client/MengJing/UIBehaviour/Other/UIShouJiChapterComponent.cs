using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIShouJiChapterComponent: Entity, IAwake<GameObject>
    {
        public GameObject GameObject;

        public GameObject ImageProgress;
        public GameObject ItemNode;
        public GameObject Text_Attribute3;
        public GameObject Text_Attribute2;
        public GameObject Text_Attribute1;
        public GameObject Text_Star3;
        public GameObject Text_Star2;
        public GameObject Text_Star1;

        public GameObject[] Button_Open;
        public GameObject[] Button_Close;

        public GameObject Text_StarNum;
        public GameObject Text_Name;

        public int ChapterId;
    }
}