using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class Actor_FubenEnterSonHandler : MessageLocationHandler<Unit, Actor_EnterSonFubenRequest, Actor_EnterSonFubenResponse>
    {
        protected override async ETTask Run(Unit unit, Actor_EnterSonFubenRequest request, Actor_EnterSonFubenResponse response)
        {
            unit.GetComponent<MoveComponent>().Stop(false);
            unit.GetComponent<SkillManagerComponentS>().OnDispose();
            CellDungeonComponent fubenComponent = unit.Scene().GetComponent<CellDungeonComponent>();
            CellDungeonInfo fubenCellInfoCurt = fubenComponent.GetByCellIndex(request.CurrentCell);
            fubenCellInfoCurt.pass = true;
            CellDungeonInfo fubenCellInfoNext = fubenComponent.GetNextSonCell(request.CurrentCell, request.DirectionType);
            fubenComponent.CurrentFubenCell = fubenCellInfoNext;
            if (!fubenCellInfoNext.pass)
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.PiLao, "-1");
            }

            SonFubenInfo enterFubenInfo = SonFubenInfo.Create();
            enterFubenInfo.SonSceneId = fubenCellInfoNext.sonid;
            enterFubenInfo.PassableFlag = fubenComponent.GetPassableFlag();
            enterFubenInfo.CurrentCell = fubenComponent.GetCellIndex(fubenCellInfoNext.row, fubenCellInfoNext.line);
            
            int sonid = fubenCellInfoNext.sonid;
            unit.Scene().GetComponent<MapComponent>().SonSceneId = (sonid);
            unit.Scene().GetComponent<MapComponent>().NavMeshId = ChapterSonConfigCategory.Instance.Get(sonid).MapID;

            //unit.GetComponent<PathfindingComponent>().Update(ChapterSonConfigCategory.Instance.Get(sonid).MapID.ToString());
            //Game.Scene.GetComponent<RecastPathComponent>().Update(ChapterSonConfigCategory.Instance.Get(sonid).MapID);

            ChapterSonConfig chapterSon = ChapterSonConfigCategory.Instance.Get(sonid);

            //更新unit出生点坐标
            int[] borpos;
            if (request.DirectionType == 1)
                borpos = chapterSon.BornPosDwon;
            else if (request.DirectionType == 2)
                borpos = chapterSon.BornPosRight;
            else if (request.DirectionType == 3)
                borpos = chapterSon.BornPosUp;
            else
                borpos = chapterSon.BornPosLeft;

            unit.Position = new float3(borpos[0] * 0.01f, borpos[1] * 0.01f, borpos[2] * 0.01f);
            unit.Rotation = quaternion.identity;

            CellDungeonComponentSystem.RemoveAllNoSelf(unit);
            
            //创建副本内的各种Unit
            fubenComponent.GenerateFubenScene( fubenCellInfoNext.pass);

            //自己通知给周围人
            //UnitHelper.BroadcastCreateUnit(unit.DomainScene(), unit);
            
            response.SonFubenInfo = enterFubenInfo;
            await ETTask.CompletedTask;
        }

    }
}
