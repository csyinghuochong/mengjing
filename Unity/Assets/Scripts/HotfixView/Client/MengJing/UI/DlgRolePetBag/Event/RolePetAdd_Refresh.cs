namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class RolePetAdd_Refresh: AEvent<Scene, RolePetAdd>
    {
        protected override async ETTask Run(Scene scene, RolePetAdd args)
        {
            if (scene.GetComponent<BattleMessageComponent>().ShowPetChouKaGet)
            {
                scene.GetComponent<BattleMessageComponent>().RolePetAdds.Add(args);
            }
            else
            {
                scene.GetComponent<BattleMessageComponent>().ShowPetChouKaGet = true;
                await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetChouKaGet);
                DlgPetChouKaGet dlgPetChouKaGet = scene.GetComponent<UIComponent>().GetDlgLogic<DlgPetChouKaGet>();
                dlgPetChouKaGet.OnInitUI(args.RolePetInfo, args.OldPetSkin);
            }
        }
    }
}