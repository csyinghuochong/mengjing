using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    [FriendOf(typeof(BuffC))]
    public class BuffScale_ChangeModel : AEvent<Scene, BuffScale>
    {
        protected override async ETTask Run(Scene scene, BuffScale args)
        {
            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed ||
                unit.Type != UnitType.Monster)
            {
                return;
            }

            GameObject model =
                    unit.GetComponent<GameObjectComponent>()?.GameObject;

            if (model == null || args.ABuffHandler == null)
            {
                return;
            }

            float factor = (float)args.ABuffHandler
                    .mSkillBuffConf.buffParameterValue;

            if (factor <= 0f)
            {
                return;
            }

            // 现有 RoleBuff_Scale：1 为添加，2 为移除。
            if (args.OperateType == 1)
            {
                model.transform.localScale *= factor;
            }
            else if (args.OperateType == 2)
            {
                model.transform.localScale /= factor;
            }

            await ETTask.CompletedTask;
        }
    }
}