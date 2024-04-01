using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (DlgPetHeXinHeChengViewComponent))]
    [FriendOf(typeof (DlgPetHeXinHeChengViewComponent))]
    public static partial class DlgPetHeXinHeChengViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this DlgPetHeXinHeChengViewComponent self)
        {
            self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
        }

        [EntitySystem]
        private static void Destroy(this DlgPetHeXinHeChengViewComponent self)
        {
            self.DestroyWidget();
        }
    }
}