﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class JingLingGet_CreateUI: AEvent<Scene, JingLingGet>
    {
        protected override async ETTask Run(Scene scene, JingLingGet args)
        {
            await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JingLingGet);
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgJingLingGet>().OnInitUI(args.JingLingId);

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (DlgJingLingGet))]
    public static class DlgJingLingGetSystem
    {
        public static void RegisterUIEvent(this DlgJingLingGet self)
        {
            self.View.E_Btn_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JingLingGet); });
        }

        public static void ShowWindow(this DlgJingLingGet self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgJingLingGet self, int jinglingid)
        {
            self.View.ES_ModelShow.Camera.localPosition = new Vector3(0f, 40, 250f);
            self.View.ES_ModelShow.Camera.GetComponent<Camera>().fieldOfView = 35;
            JingLingConfig petSkinConfig = JingLingConfigCategory.Instance.Get(jinglingid);
            // self.View.ES_ModelShow.ShowOtherModel("JingLing/" + petSkinConfig.Assets).Coroutine();
            self.View.ES_ModelShow.ShowOtherModel("JingLing/" + 70001001).Coroutine();
            self.View.E_TextSkinNameText.text = petSkinConfig.Name;
            self.View.E_TextDesText.text = petSkinConfig.Des;
        }
    }
}