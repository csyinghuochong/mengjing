using System;


namespace ET.Server
{
	[MessageHandler(SceneType.Gate)]
	public class R2G_GetLoginKeyHandler : MessageHandler<Scene, R2G_GetLoginKey, G2R_GetLoginKey>
	{
		protected override async ETTask Run(Scene scene, R2G_GetLoginKey request, G2R_GetLoginKey response)
		{
			string key =  RandomGenerator.RandInt64().ToString() + TimeInfo.Instance.ServerNow().ToString();
			scene.GetComponent<GateSessionKeyComponent>().Add(key.GetLongHashCode(), request.Account);
			response.Key = key.GetLongHashCode();
			response.GateId = scene.Id;
			await ETTask.CompletedTask;
		}
	}
}