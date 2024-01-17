namespace ET.Client
{
    [FriendOf(typeof (UI))]
    [FriendOf(typeof (MJUIEventComponent))]
    public static class UIHelper
    {
        public static void Clear()
        {
            MJUIEventComponent.Instance.WaitUIList.Clear();
            MJUIEventComponent.Instance.OpenUIList.Clear();
        }

        public static async ETTask<UI> Create(Scene scene, string uiType)
        {
            UI uI = GetUI(scene, uiType);
            if (uI != null)
            {
                return uI;
            }

            if (!MJUIEventComponent.Instance.WaitUIList.Contains(uiType))
            {
                MJUIEventComponent.Instance.WaitUIList.Add(uiType);
                uI = await scene.GetComponent<MJUIComponent>().Create(uiType);
                MJUIEventComponent.Instance.WaitUIList.Remove(uiType);
                if (uI == null)
                {
                    return null;
                }

                UILayerScript uILayerScript = uI.GameObject.GetComponent<UILayerScript>();
                if (uILayerScript.ShowHuoBi)
                {
                    MJUIEventComponent.Instance.OpenUIList.Insert(0, uiType);
                    UI ui_huobi = GetUI(scene, UIType.UICommonHuoBiSet);
                    if (ui_huobi != null)
                    {
                        // ui_huobi.GetComponent<UICommonHuoBiSetComponent>().OnUpdateTitle(OpenUIList[0]);
                    }
                    else
                    {
                        // Create(scene, UIType.UICommonHuoBiSet).Coroutine();
                    }
                }

                if (uILayerScript.HideMainUI)
                {
                    // UI mainUi = scene.GetComponent<UIComponent>().Get(UIType.UIMain);
                    // mainUi?.GetComponent<UIMainComponent>().ShowMainUI(false);
                }

                // uI.OnShowUI?.Invoke();
            }

            return uI;
        }

        public static void Remove(Scene scene, string uiType)
        {
            UI uI = GetUI(scene, uiType);
            if (uI == null)
            {
                return;
            }

            if (MJUIEventComponent.Instance.CurrentNpcUI == uiType)
            {
                // scene.CurrentScene().GetComponent<CameraComponent>().SetBuildExit();
                // UIEventComponent.Instance.CurrentNpcId = 0;
                // UIEventComponent.Instance.CurrentNpcUI = "";
            }

            if (uI.GameObject != null)
            {
                UILayerScript uILayerScript = uI.GameObject.GetComponent<UILayerScript>();
                if (uILayerScript.ShowHuoBi)
                {
                    // UIEventComponent.Instance.OpenUIList.Remove(uiType);
                    // bool haveView = UIEventComponent.Instance.OpenUIList.Count > 0;
                    // UI ui_huobi = UIHelper.GetUI(scene, UIType.UICommonHuoBiSet);
                    // if (ui_huobi != null && haveView)
                    // {
                    //     ui_huobi.GetComponent<UICommonHuoBiSetComponent>().OnUpdateTitle(OpenUIList[0]);
                    // }
                    //
                    // if (ui_huobi != null && !haveView)
                    // {
                    //     scene.GetComponent<UIComponent>().Remove(UIType.UICommonHuoBiSet);
                    // }
                }

                bool hideMainUI = uILayerScript.HideMainUI;
                if (hideMainUI)
                {
                    // UI mainUi = scene.GetComponent<UIComponent>().Get(UIType.UIMain);
                    // mainUi?.GetComponent<UIMainComponent>().ShowMainUI(true);
                }
            }

            if (MJUIEventComponent.Instance.GuideUISet.Equals(uiType))
            {
                Remove(scene, UIType.UIGuide);
                MJUIEventComponent.Instance.GuideUISet = string.Empty;
            }

            scene.GetComponent<MJUIComponent>().Remove(uiType);
        }

        public static UI GetUI(Scene scene, string uiType)
        {
            return scene.GetComponent<MJUIComponent>().Get(uiType);
        }

        public static string ZhuaPuProToStr(int par)
        {
            float pro = (float)par / 10000f;
            string str = "抓捕难度:";
            if (pro <= 0.05f)
            {
                str += "万里挑一";
            }

            if (pro > 0.05f && pro <= 0.1f)
            {
                str += "千载难逢";
            }

            if (pro > 0.1f && pro <= 0.2f)
            {
                str += "百不一遇";
            }

            if (pro > 0.2f && pro <= 0.3f)
            {
                str += "一般";
            }

            if (pro > 0.3f)
            {
                str += "容易";
            }

            return str;
        }

        // 播放UI音效
        public static void PlayUIMusic(string music)
        {
            if (!string.IsNullOrEmpty(music))
            {
                // Game.Scene.GetComponent<SoundComponent>().PlayClip("UI/" + music, "mp3").Coroutine();
            }
        }
    }
}