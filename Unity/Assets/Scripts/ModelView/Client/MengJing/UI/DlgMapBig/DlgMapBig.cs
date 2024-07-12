using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgMapBig : Entity, IAwake, IUILogic
    {
        public DlgMapBigViewComponent View
        {
            get => this.GetComponent<DlgMapBigViewComponent>();
        }

        public long Timer;

        public int SceneId = 1;
        public float ScaleRateX = 1f;
        public float ScaleRateY = 1f;
        public Vector2 localPoint;

        public List<GameObject> PathPointList = new();
        public Dictionary<int, GameObject> NpcGameObject = new();
        public Dictionary<int, Vector3> BossList = new();
        public List<GameObject> TeamerPointList = new();
        public List<GameObject> MonsterPointList = new();
        public GameObject MapCamera;
        public Vector3 InvisiblePosition = new(-3000f, -3000f, 0f);

        public MoveComponent MoveComponent { get; set; }

        public List<int> ShowNpc = new();
        public List<int> ShowBoss = new();
        public Dictionary<int, EntityRef<Scroll_Item_MapBigNpcItem>> ScrollItemMapBigNpcItems;
    }
}