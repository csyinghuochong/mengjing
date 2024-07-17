namespace ET.Server
{

    [MessageHandler(SceneType.PaiMai)]
    public  class C2P_PaiMaiShopShowListHandler : MessageHandler<Scene, C2P_PaiMaiShopShowListRequest, P2C_PaiMaiShopShowListResponse>
    {
		//拍卖快捷列表购买道具
		protected override async ETTask Run(Scene scene, C2P_PaiMaiShopShowListRequest request, P2C_PaiMaiShopShowListResponse response)
		{
			PaiMaiSceneComponent paimaiCompontent = scene.GetComponent<PaiMaiSceneComponent>();
			response.PaiMaiShopItemInfos .AddRange(paimaiCompontent.dBPaiMainInfo_Shop.PaiMaiShopItemInfos); 

			await ETTask.CompletedTask;
		}

	}
}
