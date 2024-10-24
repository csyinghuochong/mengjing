﻿namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView: AEvent<Scene, AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterUnitCreate args)
        {
            Unit unit = args.Unit;

            // string assetsName = $"Assets/Bundles/Unit/Player/Hero_2.prefab";
            // switch (unit.Type )
            // {
            //     case UnitType.Player:
            //         assetsName = $"Assets/Bundles/Unit/Player/Hero_2.prefab";
            //         break;
            //     case UnitType.Monster:
            //         MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(unit.ConfigId);
            //         assetsName = StringBuilderHelper.GetMonsterUnitPath(monsterCof.MonsterModelID);
            //         break;
            //     case UnitType.Npc:
            //         NpcConfig npcConfig = NpcConfigCategory.Instance.Get(unit.ConfigId);
            //         assetsName = ABPathHelper.GetUnitPath("Npc/" + npcConfig.Asset);
            //         break;
            // }
            
            // Unit View层
            // GameObject bundleGameObject = await scene.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            // GlobalComponent globalComponent = scene.Root().GetComponent<GlobalComponent>();
            // GameObject go = UnityEngine.Object.Instantiate(bundleGameObject, globalComponent.Unit, true);
            // go.transform.position = unit.Position;
            // go.transform.name = unit.Id + "_" + unit.ConfigId;
            // unit.AddComponent<GameObjectComponent>().GameObject = go;
            // unit.AddComponent<AnimatorComponent>();
            
            unit.AddComponent<GameObjectComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}