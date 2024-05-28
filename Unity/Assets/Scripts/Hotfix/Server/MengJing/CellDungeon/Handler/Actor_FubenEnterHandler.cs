﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Server
{
	[MessageHandler(SceneType.Map)]
    public class Actor_FubenEnterHandler : MessageLocationHandler<Unit, Actor_EnterFubenRequest, Actor_EnterFubenResponse>
    {
        protected override async ETTask Run(Unit unit, Actor_EnterFubenRequest request, Actor_EnterFubenResponse response)
        {
			CellDungeonInfo curCell = null;
			CellDungeonComponent fubenComponent = null;
			unit.GetComponent<MoveComponent>().Stop(false);
			unit.GetComponent<UserInfoComponentS>().UpdateRoleData(  UserDataType.PiLao, "-1");

			//首次进入
			if (request.RepeatEnter == 0)
			{
				//动态创建副本
				long fubenid = IdGenerater.Instance.GenerateId();
				long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
				Scene fubnescene = GateMapFactory.Create(unit.Scene(), fubenid, fubenInstanceId,  "Fuben" + fubenid.ToString());
				fubenComponent = fubnescene.AddComponent<CellDungeonComponent>();
				fubenComponent.MainUnit = unit;
				fubenComponent.FubenDifficulty = request.Difficulty;
				fubenComponent.InitFubenCell(request.ChapterId);
				curCell = fubenComponent.CurrentFubenCell;
				fubenComponent.EnergySkills = new List<int>() { 64000001, 64000002, 64000003, 64000004, 64000005, 64000006, 64000007, 64000008 };
				MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
				mapComponent.SetMapInfo((int)SceneTypeEnum.CellDungeon, request.ChapterId, curCell.sonid);
				mapComponent.NavMeshId = ChapterSonConfigCategory.Instance.Get(curCell.sonid).MapID;

				TransferHelper.BeforeTransfer(unit);
				await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.CellDungeon, request.ChapterId, request.Difficulty, curCell.sonid.ToString());
			}
			else
			{
				fubenComponent = unit.Scene<>().GetComponent<CellDungeonComponent>();
				fubenComponent.MainUnit = unit;
				CellDungeonComponentSystem.RemoveAllNoSelf(unit);
				fubenComponent.InitFubenCell(request.ChapterId);
				curCell = fubenComponent.CurrentFubenCell;
				ChapterSonConfig chapterSon = ChapterSonConfigCategory.Instance.Get(curCell.sonid);
				MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
				mapComponent.SonSceneId = (curCell.sonid);
				mapComponent.NavMeshId = ChapterSonConfigCategory.Instance.Get(curCell.sonid).MapID;

				unit.Position = new Vector3(chapterSon.BornPosLeft[0] * 0.01f, chapterSon.BornPosLeft[1] * 0.01f, chapterSon.BornPosLeft[2] * 0.01f);
				unit.Rotation = Quaternion.identity;
				fubenComponent.GenerateFubenScene( false);
				RolePetInfo fightId = unit.GetComponent<PetComponentS>().GetFightPet();
				if (fightId != null)
				{
					UnitFactory.CreatePet(unit, fightId);
				}
				//UnitHelper.BroadcastCreateUnit(unit.DomainScene(), unit);
			}

			fubenComponent.HurtValue = 0;
			fubenComponent.EnterTime = TimeHelper.ServerNow();

			fubenComponent.SonFubenInfo.SonSceneId = curCell.sonid;
			fubenComponent.SonFubenInfo.CurrentCell = fubenComponent.FubenInfo.StartCell;
			fubenComponent.SonFubenInfo.PassableFlag = fubenComponent.GetPassableFlag();
			response.FubenInfo = fubenComponent.FubenInfo;
			response.SonFubenInfo = fubenComponent.SonFubenInfo;
			await ETTask.CompletedTask;
        }
    }
}
