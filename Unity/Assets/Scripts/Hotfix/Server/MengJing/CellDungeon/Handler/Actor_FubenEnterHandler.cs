// using System.Collections.Generic;
// using Unity.Mathematics;
//
// namespace ET.Server
// {
// 	[MessageHandler(SceneType.Map)]
//     public class Actor_FubenEnterHandler : MessageLocationHandler<Unit, Actor_EnterFubenRequest, Actor_EnterFubenResponse>
//     {
//         protected override async ETTask Run(Unit unit, Actor_EnterFubenRequest request, Actor_EnterFubenResponse response)
//         {
// 			CellDungeonInfo curCell = null;
// 			CellDungeonComponentS fubenComponentS = null;
// 			unit.GetComponent<MoveComponent>().Stop(false);
// 			unit.GetComponent<UserInfoComponentS>().UpdateRoleData(  UserDataType.PiLao, "-1");
//
// 			//首次进入
// 			if (request.RepeatEnter == 0)
// 			{
// 				//动态创建副本
// 				long fubenid = IdGenerater.Instance.GenerateId();
// 				long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
// 				Scene fubnescene = GateMapFactory.Create(unit.Scene(), fubenid, fubenInstanceId,  "Fuben" + fubenid.ToString());
// 				fubenComponentS = fubnescene.AddComponent<CellDungeonComponentS>();
// 				fubenComponentS.FubenDifficulty = request.Difficulty;
// 				fubenComponentS.InitFubenCell(request.ChapterId);
// 				curCell = fubenComponentS.CurrentFubenCell;
// 				fubenComponentS.EnergySkills.AddRange(ConfigData.EnergySkills);
// 				MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
// 				mapComponent.SetMapInfo((int)SceneTypeEnum.CellDungeon, request.ChapterId, curCell.sonid);
// 				mapComponent.NavMeshId = CellDungeonConfigCategory.Instance.Get(curCell.sonid).MapID;
//
// 				TransferHelper.BeforeTransfer(unit);
// 				await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.CellDungeon, request.ChapterId, request.Difficulty, curCell.sonid.ToString());
// 			}
// 			else
// 			{
// 				fubenComponentS = unit.Scene().GetComponent<CellDungeonComponentS>();
// 				CellDungeonComponentSSystem.RemoveAllNoSelf(unit);
// 				fubenComponentS.InitFubenCell(request.ChapterId);
// 				curCell = fubenComponentS.CurrentFubenCell;
// 				CellDungeonConfig chapterSon = CellDungeonConfigCategory.Instance.Get(curCell.sonid);
// 				MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
// 				mapComponent.SonSceneId = (curCell.sonid);
// 				mapComponent.NavMeshId = CellDungeonConfigCategory.Instance.Get(curCell.sonid).MapID;
//
// 				unit.Position = new float3(chapterSon.BornPosLeft[0] * 0.01f, chapterSon.BornPosLeft[1] * 0.01f, chapterSon.BornPosLeft[2] * 0.01f);
// 				unit.Rotation = quaternion.identity;
// 				fubenComponentS.GenerateFubenScene( false);
// 				
// 				//UnitHelper.BroadcastCreateUnit(unit.DomainScene(), unit);
// 			}
//
// 			fubenComponentS.HurtValue = 0;
// 			fubenComponentS.EnterTime = TimeHelper.ServerNow();
//
// 			fubenComponentS.SonFubenInfo.SonSceneId = curCell.sonid;
// 			fubenComponentS.SonFubenInfo.CurrentCell = fubenComponentS.FubenInfo.StartCell;
// 			fubenComponentS.SonFubenInfo.PassableFlag = fubenComponentS.GetPassableFlag();
// 			response.FubenInfo = fubenComponentS.FubenInfo;
// 			response.SonFubenInfo = fubenComponentS.SonFubenInfo;
// 			await ETTask.CompletedTask;
//         }
//     }
// }
