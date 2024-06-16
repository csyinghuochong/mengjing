using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_PetMiningItem: Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
    {
        public Transform UITransform
        {
            get
            {
                return this.uiTransform;
            }
            set
            {
                this.uiTransform = value;
            }
        }
        
        public void DestroyWidget()
        {
            this.uiTransform = null;
        }
        
        
        private GameObject TextChanChu;
        private GameObject ImHeXinShow;
        private GameObject PetList;
        private GameObject GameObject;
        private GameObject TextMine;
        private GameObject ImageIcon;
        private GameObject TextPlayer;
        private Image[] PetIconList = new Image[5];
        private GameObject[] PetDiList = new GameObject[5];

        public PetMingPlayerInfo PetMingPlayerInfo;
        public Transform uiTransform = null;
        
        public int MineType;
        public int Position;
    }
    
    
}