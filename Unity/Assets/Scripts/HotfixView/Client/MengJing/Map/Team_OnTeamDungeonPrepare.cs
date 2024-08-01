using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Team_OnTeamDungeonPrepare : AEvent<Scene, RecvTeamDungeonPrepare>
    {
        protected override async ETTask Run(Scene scene, RecvTeamDungeonPrepare args)
        {
            bool blackroom = UnitHelper.IsBackRoom(scene);
            if (blackroom)
            {
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("未创建 UITeamDungeonPrepare");
            // UI uI = UIHelper.GetUI(args.ZoneScene, UIType.UITeamDungeonPrepare);
            // if (uI == null)
            // {
            //     return;
            // }
            //
            // uI.GetComponent<UITeamDungeonPrepareComponent>().OnUpdateUI(args.PrepareResult.TeamInfo, args.PrepareResult.ErrorCode);
            await ETTask.CompletedTask;
        }
    }
}