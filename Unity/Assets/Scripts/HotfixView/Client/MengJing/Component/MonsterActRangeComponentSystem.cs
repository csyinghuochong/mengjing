using UnityEngine;

namespace ET.Client
{


    [EntitySystemOf(typeof(MonsterActRangeComponent))]
    [FriendOf(typeof(MonsterActRangeComponent))]
    public static partial class MonsterActRangeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MonsterActRangeComponent self, int args2)
        {
            self.IsInAck = false;
            self.MonsterActRange = null;
            self.AckRange = (float)MonsterConfigCategory.Instance.Get(args2).ChaseRange;
            
            self.BornPositon = self.GetParent<Unit>().GetBornPostion();
        }
        [EntitySystem]
        private static void Destroy(this MonsterActRangeComponent self)
        {
            string path = ABPathHelper.GetEffetPath("MonsterActRange");
            self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(path, self.MonsterActRange);
            self.MonsterActRange = null;
        }
        
        public static void OnDead(this MonsterActRangeComponent self)
        {
            self.MonsterActRange?.SetActive(false);
        }

        public static void OnBossInCombat(this MonsterActRangeComponent self, int combat)
        {
            Scene zoneScene = self.Root();
            MapComponent mapComponent = zoneScene.GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.PetDungeon
                || mapComponent.MapType == MapTypeEnum.PetTianTi
                || mapComponent.MapType == MapTypeEnum.PetMing)
            {
                return;
            }

            if (combat == 0)
            {
                self.MonsterActRange?.SetActive(false);
            }
            else
            {
                if (self.MonsterActRange != null)
                {
                    self.MonsterActRange.SetActive(true);
                }
                else
                {
                    self.LoadEffect();
                }
            }
        }

        public static void OnLoadGameObject(this MonsterActRangeComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.Destroy(gameObject);
                return;
            }
            self.MonsterActRange = gameObject;
            self.MonsterActRange.SetActive(true);
            self.MonsterActRange.Get<GameObject>("MonsterActRange").GetComponent<Projector>().orthographicSize = self.AckRange * 1.2f;
            self.MonsterActRange.transform.position = self.BornPositon;
            self.MonsterActRange.transform.localScale = self.AckRange * Vector3.one;
        }

        public static  void LoadEffect(this MonsterActRangeComponent self)
        {
            string path = ABPathHelper.GetEffetPath("MonsterActRange");
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(path, self.InstanceId, true,self.OnLoadGameObject);
        }
    }

}