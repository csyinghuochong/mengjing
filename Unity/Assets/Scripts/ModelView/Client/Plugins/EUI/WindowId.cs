namespace ET.Client
{
    public enum WindowID
    {
        WindowID_Invaild = 0,
        WindowID_MessageBox,
        WindowID_Lobby,    //房间界面
        WindowID_Login,     //登录界面
        WindowID_RedDot,   //红点测试界面
        WindowID_Helper,   //提示界面
    	WindowID_LSLobby,
		WindowID_LSLogin,
		WindowID_LSRoom,

        WindowID_MJLogin,     //登录界面(所有和demo有冲突的都加上MJ作为前缀)
    	WindowID_MJLobby,
		WindowID_CreateRole,
		WindowID_Main,
		WindowID_Role,
		WindowID_RoleBag,
		WindowID_ItemTips,
		WindowID_HuoBiSet,
		WindowID_Chat,
		WindowID_RoleProperty,
	}
}