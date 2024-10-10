using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Unit_ChuanSongOpen : AEvent<Scene, ChuanSongOpen>
    {
        protected override async ETTask Run(Scene scene, ChuanSongOpen args)
        {
            CellDungeonComponentC fubenComponent = scene.GetComponent<CellDungeonComponentC>();
            CellDungeonInfo fubenCellInfo = fubenComponent.GetFubenCell(fubenComponent.SonFubenInfo.CurrentCell);

            if (fubenCellInfo.ctype != (int)CellDungeonStatu.End)
            {
                List<EntityRef<Unit>> allunits = scene.CurrentScene().GetComponent<UnitComponent>().GetAll();
                for (int i = 0; i < allunits.Count; i++)
                {
                    Unit unit = allunits[i];
                    if (unit.Type != UnitType.Transfers)
                    {
                        continue;
                    }

                    GameObject gameObject = unit.GetComponent<GameObjectComponent>().GameObject;
                    gameObject.transform.Find("CanWalkEffect").gameObject.SetActive(true);
                }

                DlgMain dlgMain = scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
                dlgMain?.OnChapterOpen();
            }

            await ETTask.CompletedTask;
        }
    }
}