
using System;
using ET.Server;
namespace ET.Client;

[Event(SceneType.Demo)]
public class Robot_OnPetMatchResult : AEvent<Scene, PetMatchResult>
{
    protected override async ETTask Run(Scene scene, PetMatchResult args)
    {
       
        EnterMapHelper.RequestTransfer(scene, MapTypeEnum.PetMatch, 2900001, 0, args.m2C_SoloMatch.FubenId.ToString()).Coroutine();
        
        await ETTask.CompletedTask;
    }
}