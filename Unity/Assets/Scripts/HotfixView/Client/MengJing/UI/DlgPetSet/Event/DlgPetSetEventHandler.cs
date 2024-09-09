namespace ET.Client
{
    
    [FriendOf(typeof(UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_PetSet)]
    public class DlgPetSetEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.windowType = UIWindowType.Normal; 
        }

        public void OnInitComponent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.AddComponent<DlgPetSet>().AddComponent<DlgPetSetViewComponent>();
        }

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgPetSet>().RegisterUIEvent(); 
        }

        public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
        {
            uiBaseWindow.GetComponent<DlgPetSet>().ShowWindow(contextData); 
        }

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgPetSet>().BeforeUnload(); 
        }
    }
    
}
