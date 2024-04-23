using UnityEngine;

namespace ET.Client
{

    [EntitySystemOf(typeof(ES_MainSkill))]
    [FriendOfAttribute(typeof(ES_MainSkill))]
    public static partial class ES_MainSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_MainSkill self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;

            self.OnInitUI();
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_MainSkill self)
        {
            self.DestroyWidget();
        }

        private static void OnInitUI(this ET.Client.ES_MainSkill self)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject go = rc.Get<GameObject>($"UI_MainRoseSkill_item_{i}");
                UISkillGridComponent skillgrid = self.AddChild<UISkillGridComponent, GameObject>(go);
                skillgrid.SkillCancelHandler = self.ShowCancelButton;
                self.UISkillGirdList.Add(skillgrid);
            }
        }

        public static void ResetUI(this ET.Client.ES_MainSkill self)
        {
            Log.Debug("ES_MainSkill.ResetUI");
        }

        private static void OnSkillSetUpdate(this ET.Client.ES_MainSkill self)
        {
            Log.Debug("ES_MainSkill.OnSkillSetUpdate");
        }
    }

}