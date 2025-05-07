using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIBaseWindow))]
    [Event(SceneType.Demo)]
    public class Guide_OnShowGuide : AEvent<Scene, ShowGuide>
    {
        protected override async ETTask Run(Scene scene, ShowGuide args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();

            if (uiComponent.GetDlgLogic<DlgGuide>() != null)
            {
                return;
            }

            GuideConfig guideConfig = GuideConfigCategory.Instance.Get(args.GuideId);
            switch (guideConfig.ActionType)
            {
                case GuideActionType.Button:

                    //AdventureBtn
                    //ChapterContent;0@ButtonEnter
                    //UIMainTask@TaskShowList;0@ButtonTask

                    GameObject gameObject = uiComponent.GetUIBaseWindow(FunctionUI.GetUIPath(guideConfig.ActionTarget)).UIPrefabGameObject;
                    ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
                    string[] childPaths = guideConfig.ActionParams.Split('@');
                    for (int i = 0; i < childPaths.Length; i++)
                    {
                        // ChapterContent; 0
                        string[] pathinfos = childPaths[i].Split(';');

                        if (pathinfos.Length == 1)
                        {
                            gameObject = rc.Get<GameObject>(pathinfos[0]);
                            rc = gameObject.GetComponent<ReferenceCollector>();
                        }

                        if (pathinfos.Length == 2)
                        {
                            gameObject = rc.Get<GameObject>(pathinfos[0]);
                            if (gameObject == null)
                            {
                                break;
                            }

                            Transform tf = gameObject.transform.GetChild(int.Parse(pathinfos[1]));
                            if (tf == null)
                            {
                                break;
                            }

                            gameObject = tf.gameObject;
                            rc = gameObject.GetComponent<ReferenceCollector>();
                        }

                        if (rc == null)
                        {
                            break;
                        }
                    }

                    if (gameObject == null)
                    {
                        return;
                    }

                    await uiComponent.ShowWindowAsync(WindowID.WindowID_Guide);
                    DlgGuide dlgGuide = uiComponent.GetDlgLogic<DlgGuide>();
                    dlgGuide.SetPosition(gameObject, guideConfig);
                    uiComponent.GuideUISet = FunctionUI.GetUIPath(guideConfig.ActionTarget);

                    void OnButtonClickGuide()
                    {
                        uiComponent.CloseWindow(WindowID.WindowID_Guide);
                        gameObject.GetComponent<Button>().onClick.RemoveListener(OnButtonClickGuide);
                        scene.GetComponent<GuideComponent>().OnNext(args.GroupId);

                        UserInfo userInfo = scene.GetComponent<UserInfoComponentC>().UserInfo;
                        PlayerPrefsHelp.SetInt($"{PlayerPrefsHelp.LastGuide}_{userInfo.UserId}", args.GuideId);
                    }

                    if (gameObject.GetComponent<Button>() != null)
                    {
                        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClickGuide);
                    }

                    
                    void OnToggleClickGuide(bool isOn)
                    {
                        if (isOn)
                        {
                            uiComponent.CloseWindow(WindowID.WindowID_Guide);
                            gameObject.GetComponent<Toggle>().onValueChanged.RemoveListener(OnToggleClickGuide);
                            scene.GetComponent<GuideComponent>().OnNext(args.GroupId);

                            UserInfo userInfo = scene.GetComponent<UserInfoComponentC>().UserInfo;
                            PlayerPrefsHelp.SetInt($"{PlayerPrefsHelp.LastGuide}_{userInfo.UserId}", args.GuideId);
                        }
                    }
                    
                    if (gameObject.GetComponent<Toggle>() != null)
                    {
                        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(OnToggleClickGuide);
                    }
                    
                    break;
                case GuideActionType.NpcTalk:

                    scene.CurrentScene().GetComponent<OperaComponent>().OnClickNpc(int.Parse(guideConfig.ActionTarget)).Coroutine();
                    scene.GetComponent<GuideComponent>().OnNext(args.GroupId);

                    UserInfo userInfo = scene.GetComponent<UserInfoComponentC>().UserInfo;
                    using (zstring.Block())
                    {
                        PlayerPrefsHelp.SetInt(zstring.Format("{0}_{1}", PlayerPrefsHelp.LastGuide, userInfo.UserId), args.GuideId);
                    }

                    break;
            }
        }
    }
}