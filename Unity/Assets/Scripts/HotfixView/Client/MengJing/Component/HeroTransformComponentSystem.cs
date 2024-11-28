using UnityEngine;

namespace ET.Client
{


    [EntitySystemOf(typeof(HeroTransformComponent))]
    [FriendOf(typeof(HeroTransformComponent))]
    public static partial class HeroTransformComponentSystem
    {
        [EntitySystem]
        private static void Awake(this HeroTransformComponent self)
        {
            Unit MyHero = self.GetParent<Unit>();
            Transform transform = MyHero.GetComponent<GameObjectComponent>().GameObject.transform;
            Transform roleBoneSetTra = transform.Find("RoleBoneSet");
            self.middleBuffPos = transform;
            if (roleBoneSetTra != null)
            {
                self.namePos = transform.Find("NamePoint");
                self.pos_di = roleBoneSetTra.Find("Di");
                self.pos_center = roleBoneSetTra.Find("Center");
                self.pos_Head = roleBoneSetTra.Find("Head");
                self.pos_Hand = roleBoneSetTra.Find("pos_Hand");
            }
            else
            {
                self.namePos = transform;
                self.pos_di = transform;
                self.pos_center = transform;
                self.pos_Head = transform;
                self.pos_Hand = transform;
            }

            //获取自身的绑点
            if (MyHero.Type == UnitType.Player)
            {
                Transform runtr = MyHero.GetComponent<GameObjectComponent>().GameObject.transform.Find("RoseRunEffect");
                self.RunEffect = runtr != null ? runtr.gameObject : null;
            }
        }

        public static void ShowRunEffect(this HeroTransformComponent self)
        {
            if (self.RunEffect == null)
            {
                return;
            }
            self.RunEffect.SetActive(true);
            self.RunEffect.GetComponent<ParticleSystem>().Play();
        }

        /// <summary>
        /// 获取目标位置
        /// </summary>
        /// <param name="posType"></param>
        /// <returns></returns>
        public static Transform GetTranform(this HeroTransformComponent self, string posType)
        {
            switch (posType)
            {
                case PosType.Name:
                    return self.namePos;
                case PosType.MiddleBuff:
                    return self.middleBuffPos;

                case PosType.Di:
                    return self.pos_di;
                //break;

                case PosType.Center:
                    return self.pos_center;
                //break;

                case PosType.Head:
                    return self.pos_Head;
                //break;

                case PosType.Hand:
                    return self.pos_Hand;
                //break;
            }
            return null;
        }
    }

}