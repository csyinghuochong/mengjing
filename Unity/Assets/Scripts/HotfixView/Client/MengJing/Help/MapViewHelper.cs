using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static class MapViewHelper
    {

        public static void EnterHide(this Unit self)
        {
            switch(self.Type)
            {
                case UnitType.Player:
                    self.GetComponent<UIPlayerHpComponent>()?.EnterHide();
                    break;
                case UnitType.Monster:
                    self.GetComponent<UIMonsterHpComponent>()?.EnterHide();
                    break;
                case UnitType.Pet:
                    self.GetComponent<UIPetHpComponent>()?.EnterHide();
                    break;
                default:
                    break;
            }
        }

        public static void ExitHide(this Unit self)
        {
            switch (self.Type)
            {
                case UnitType.Player:
                    self.GetComponent<UIPlayerHpComponent>()?.ExitHide();
                    break;
                case UnitType.Monster:
                    self.GetComponent<UIMonsterHpComponent>()?.ExitHide();
                    break;
                case UnitType.Pet:
                    self.GetComponent<UIPetHpComponent>()?.ExitHide();
                    break;
                default:
                    break;
            }

        }

        public static void ShowOtherUnit(Scene root, bool show)
        {
            List<EntityRef<Unit>> units = root.CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uu = units[i];
               

                if (uu.MainHero)
                {
                    continue;
                }

                if (show)
                {
                    uu.GetComponent<GameObjectComponent>().ExitHide();
                }
                else
                {
                    uu.GetComponent<GameObjectComponent>().EnterHide();
                }
            }
         }

        public static void OnMainHeroInit(Scene root, Transform topTf, Transform mainTf, int sceneTypeEnum)
        {

            GlobalComponent globalComponent = root.GetComponent<GlobalComponent>();
            Camera maincamera = globalComponent.MainCamera.GetComponent<Camera>();
            Camera uicamera = globalComponent.UICamera.GetComponent<Camera>();
            GameObject bloodnode = globalComponent.BloodMonster;
  
            maincamera.GetComponent<MyCamera_1>().enabled = false;
            maincamera.GetComponent<MyCamera_1>().Target = topTf;

            GameObject shiBingSet = GameObject.Find("ShiBingSet");
            if (shiBingSet != null)
            {
                string path_2 = ABPathHelper.GetUGUIPath("Blood/UINpcLocal");
                GameObject npc_go = root.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path_2);
                for (int i = 0; i < shiBingSet.transform.childCount; i++)
                {
                    GameObject shiBingItem = shiBingSet.transform.GetChild(i).gameObject;
                    NpcLocal npcLocal = shiBingItem.GetComponent<NpcLocal>();
                    if (npcLocal == null)
                    {
                        continue;
                    }

                    NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcLocal.NpcId);
                    npcLocal.MainCamera = maincamera;
                    npcLocal.UiCamera = uicamera;
                    npcLocal.Blood = bloodnode;
                    npcLocal.Target = mainTf;
                    npcLocal.NpcName = npcConfig.Name;
                    npcLocal.NpcSpeak = npcConfig.SpeakText;
                    npcLocal.AssetBundle = npc_go;
                }
            }
        }

        public static void OnMainHeroMove(Unit self)
        {
            long curTime = TimeInfo.Instance.ServerNow();
            List<EntityRef<Unit>> units = self.Scene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (curTime <= unit.UpdateUITime)
                {
                     continue;
                }
                if (unit.Type == UnitType.Npc)
                {
                    unit.UpdateUITime = curTime;
                    UINpcHpComponent npcHeadBarComponent = unit.GetComponent<UINpcHpComponent>();
                    npcHeadBarComponent?.OnUpdateNpcTalk(self);
                    continue;
                }

                if (unit.Type == UnitType.Pasture)
                {
                    unit.UpdateUITime = curTime;
                    UIJiaYuanPastureComponent npcHeadBarComponent = unit.GetComponent<UIJiaYuanPastureComponent>();
                    npcHeadBarComponent?.OnUpdateNpcTalk(self);
                    continue;
                }

                if (unit.Type == UnitType.Transfers)
                {
                    unit.UpdateUITime = curTime;
                    unit.GetComponent<UITransferHpComponent>()?.OnCheckChuanSong(self);
                    continue;
                }

                if (unit.Type == UnitType.CellTransfers)
                {
                    unit.UpdateUITime = curTime;
                    unit.GetComponent<UICellTransferHpComponent>()?.OnCheckChuanSong(self);
                    continue;
                }
            }
        }
    }
}