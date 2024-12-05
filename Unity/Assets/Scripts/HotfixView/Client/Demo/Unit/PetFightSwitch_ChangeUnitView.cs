using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class PetFightSwitch_ChangeUnitView : AEvent<Scene, PetFightSwitch>
    {
        protected override async ETTask Run(Scene scene, PetFightSwitch args)
        {
            M2C_PetFightSwitchMessage message = args.Message;
            Unit unit = scene.GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            string path = "";
            if (message.PetConfigId == 0)
            {
                // 模型切换成主角
                path = ABPathHelper.GetUnitPath($"Player/{OccupationConfigCategory.Instance.Get(unit.ConfigId).ModelAsset}");
            }
            else
            {
                // 模型切换成宠物
                PetConfig petConfig = PetConfigCategory.Instance.Get(message.PetConfigId);
                PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(petConfig.Skin[0]);
                path = ABPathHelper.GetUnitPath("Pet/" + petSkinConfig.SkinID);
            }

            unit.GetComponent<GameObjectComponent>().RecoverGameObject();

            GameObject go = null;
            if (GameObjectPoolHelper.HaveObject(path))
            {
                go = GameObjectPoolHelper.GetObjectFromPool(path);
            }
            else
            {
                go = scene.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            }

            unit.GetComponent<GameObjectComponent>().UnitAssetsPath = path;
            unit.GetComponent<GameObjectComponent>().GameObject = go;
            CommonViewHelper.SetParent(go, GlobalComponent.Instance.Unit.gameObject);
            go.transform.localPosition = unit.Position;
            go.transform.rotation = unit.Rotation;
            go.transform.name = unit.Id.ToString();
            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
                            unitInfoComponent.DemonName = message.DemonName;
            if (SettingData.AnimController == 0)
            {
                unit.RemoveComponent<AnimatorComponent>();
                unit.AddComponent<AnimatorComponent>();
            }
            else
            {
                unit.RemoveComponent<AnimationComponent>();
                unit.AddComponent<AnimationComponent>();
            }

            // unit.GetComponent<FsmComponent>();
            unit.RemoveComponent<HeroTransformComponent>();
            unit.AddComponent<HeroTransformComponent>();
            // unit.GetComponent<EffectViewComponent>();

            // 改变UI
            unit.RemoveComponent<UIPetHpComponent>();
            unit.RemoveComponent<UIPlayerHpComponent>();
            if (message.PetConfigId == 0)
            {
                unit.AddComponent<UIPlayerHpComponent>();
            }
            else
            {
                unit.AddComponent<UIPetHpComponent>();
            }

            // unit.GetComponent<UIPlayerHpComponent>().UIPlayerHpText.GetComponent<HeadBarUI>().HeadPos =
            //         unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
            // unit.GetComponent<UIPlayerHpComponent>().GameObject.GetComponent<HeadBarUI>().HeadPos =
            //         unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);

            await ETTask.CompletedTask;
        }
    }
}