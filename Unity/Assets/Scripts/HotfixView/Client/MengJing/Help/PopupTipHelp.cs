using System;

namespace ET.Client
{
    public static class PopupTipHelp
    {
        public static async ETTask OpenPopupTip(Scene root, string title, string content, Action okhandle, Action cancelHandle = null)
        {
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PopupTip);
            root.GetComponent<UIComponent>().GetDlgLogic<DlgPopupTip>().InitData(title, content, okhandle, cancelHandle, string.Empty, string.Empty);
        }

        public static async ETTask OpenPopupTipWithButtonText(Scene root, string title, string content, Action okhandle,
        Action cancelHandle = null, string okbuttonText = "", string cancelButtonText = "")
        {
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PopupTip);

            root.GetComponent<UIComponent>().GetDlgLogic<DlgPopupTip>()
                    .InitData(title, content, okhandle, cancelHandle, okbuttonText, cancelButtonText);
        }
    }
}