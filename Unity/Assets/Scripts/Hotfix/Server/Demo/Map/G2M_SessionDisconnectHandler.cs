

namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
	public class G2M_SessionDisconnectHandler : MessageLocationHandler<Unit, G2M_SessionDisconnect>
	{
		protected override async ETTask Run(Unit unit, G2M_SessionDisconnect message)
		{
			unit.GetComponent<DBSaveComponent>().OnOffLine();
			await ETTask.CompletedTask;
		}
	}
}