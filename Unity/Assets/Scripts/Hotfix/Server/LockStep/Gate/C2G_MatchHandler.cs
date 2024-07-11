namespace ET.Server
{
	[MessageSessionHandler(SceneType.Gate)]
	public class C2G_MatchHandler : MessageSessionHandler<C2G_Match, G2C_Match>
	{
		protected override async ETTask Run(Session session, C2G_Match request, G2C_Match response)
		{
			Player player = session.GetComponent<SessionPlayerComponent>().Player;

			StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Match;
			G2Match_Match G2Match_Match = G2Match_Match.Create();
			G2Match_Match.Id = player.Id;
			await session.Root().GetComponent<MessageSender>().Call(startSceneConfig.ActorId,G2Match_Match);
		}
	}
}