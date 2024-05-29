namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class RolePetAdd_Refresh: AEvent<Scene, RolePetAdd>
    {
        protected override async ETTask Run(Scene scene, RolePetAdd args)
        {
            RunAnsyc(scene, args).Coroutine();
        }

        private async ETTask RunAnsyc(Scene root, RolePetAdd args)
        {
            if (root.GetComponent<BattleMessageComponent>().ShowPetChouKaGet)
            {
                root.GetComponent<BattleMessageComponent>().RolePetAdds.Add(args);
            }
            else
            {
                root.GetComponent<BattleMessageComponent>().ShowPetChouKaGet = true;
                await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetChouKaGet);
                DlgPetChouKaGet dlgPetChouKaGet = root.GetComponent<UIComponent>().GetDlgLogic<DlgPetChouKaGet>();
                dlgPetChouKaGet.OnInitUI(args.RolePetInfo, args.OldPetSkin);
            }
        }
    }
}