using System;

namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_TransferMapHandler : MessageLocationHandler<Unit, C2M_TransferMap, M2C_TransferMap>
	{
		protected override async ETTask Run(Unit unit, C2M_TransferMap request, M2C_TransferMap response)
		{
			await ETTask.CompletedTask;

			try
			{
				response.Error = await TransferHelper.TransferUnit(unit, request);
				await ETTask.CompletedTask;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
			}
		}
	}
}