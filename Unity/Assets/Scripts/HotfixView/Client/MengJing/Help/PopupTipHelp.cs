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

        /// <summary>
        /// 只显示确定按钮
        /// </summary>
        /// <param name="root"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="okhandle"></param>
        public static async ETTask OpenPopupTip_2(Scene root, string title, string content, Action okhandle)
        {
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PopupTip);
            DlgPopupTip dlgPopupTip = root.GetComponent<UIComponent>().GetDlgLogic<DlgPopupTip>();
            dlgPopupTip.InitData(title, content, okhandle, null, string.Empty, string.Empty);

            dlgPopupTip.View.E_CloseButton.gameObject.SetActive(false);
            dlgPopupTip.View.E_FalseButton.gameObject.SetActive(false);
            dlgPopupTip.View.E_TrueButton.transform.localPosition = new UnityEngine.Vector3(0f, -169f, 0f);
        }
        
        
    }
}