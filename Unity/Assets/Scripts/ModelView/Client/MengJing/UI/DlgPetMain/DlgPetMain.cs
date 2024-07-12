using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EnableClass]
    public class PetBattleInfo
    {
        public Image Image;
        public Text Text;
        public long hurt;
        public long receive;
    }

    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetMain: Entity, IAwake, IUILogic
    {
        public DlgPetMainViewComponent View
        {
            get => this.GetComponent<DlgPetMainViewComponent>();
        }

        //手指第一次触摸点的位置
        public Vector2 m_scenePos = new();

        //摄像机
        public Transform CameraTarget;

        public long Timer;
        public float BeginTime;

        public Dictionary<long, PetBattleInfo> PetBattleList = new();

        public M2C_FubenSettlement M2C_FubenSettlement;

        public int EnemyNumber = 0;
    }
}