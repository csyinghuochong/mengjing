// using Unity.Mathematics;
//
// namespace ET.Server
// {
//     [MessageHandler(SceneType.Map)]
//     public class Actor_FubenEnterSonHandler : MessageLocationHandler<Unit, Actor_EnterSonFubenRequest, Actor_EnterSonFubenResponse>
//     {
//         protected override async ETTask Run(Unit unit, Actor_EnterSonFubenRequest request, Actor_EnterSonFubenResponse response)
//         {
//             unit.GetComponent<MoveComponent>().Stop(false);
//             unit.GetComponent<SkillManagerComponentS>().OnDispose();
//             CellDungeonComponentS fubenComponentS = unit.Scene().GetComponent<CellDungeonComponentS>();
//             CellDungeonInfo fubenCellInfoCurt = fubenComponentS.GetByCellIndex(request.CurrentCell);
//             fubenCellInfoCurt.pass = true;
//             CellDungeonInfo fubenCellInfoNext = fubenComponentS.GetNextSonCell(request.CurrentCell, request.DirectionType);
//             fubenComponentS.CurrentFubenCell = fubenCellInfoNext;
//             if (!fubenCellInfoNext.pass)
//             {
//                 unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.PiLao, "-1");
//             }
//
//             SonFubenInfo enterFubenInfo = SonFubenInfo.Create();
//             enterFubenInfo.SonSceneId = fubenCellInfoNext.sonid;
//             enterFubenInfo.PassableFlag = fubenComponentS.GetPassableFlag();
//             enterFubenInfo.CurrentCell = fubenComponentS.GetCellIndex(fubenCellInfoNext.row, fubenCellInfoNext.line);
//             
//             int sonid = fubenCellInfoNext.sonid;
//             CellDungeonConfig chapterSon = CellDungeonConfigCategory.Instance.Get(sonid);
//             unit.Scene().GetComponent<MapComponent>().SonSceneId = (sonid);
//             unit.Scene().GetComponent<MapComponent>().NavMeshId = chapterSon.MapID;
//
//             //更新unit出生点坐标
//             int[] borpos;
//             if (request.DirectionType == 1)
//                 borpos = chapterSon.BornPosDwon;
//             else if (request.DirectionType == 2)
//                 borpos = chapterSon.BornPosRight;
//             else if (request.DirectionType == 3)
//                 borpos = chapterSon.BornPosUp;
//             else
//                 borpos = chapterSon.BornPosLeft;
//
//             unit.Position = new float3(borpos[0] * 0.01f, borpos[1] * 0.01f, borpos[2] * 0.01f);
//             unit.Rotation = quaternion.identity;
//
//             CellDungeonComponentSSystem.RemoveAllNoSelf(unit);
//             
//             //创建副本内的各种Unit
//             fubenComponentS.GenerateFubenScene( fubenCellInfoNext.pass);
//
//             //自己通知给周围人
//             //UnitHelper.BroadcastCreateUnit(unit.DomainScene(), unit);
//             
//             response.SonFubenInfo = enterFubenInfo;
//             await ETTask.CompletedTask;
//         }
//
//     }
// }
