using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.DropUITimer)]
    public class DropUITimer : ATimer<UIDropComponent>
    {
        protected override void Run(UIDropComponent self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [EntitySystemOf(typeof(UIDropComponent))]
    [FriendOf(typeof(UIDropComponent))]
    public static partial class UIDropComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIDropComponent self)
        {
            self.PositionIndex = 0;
            self.HeadBar = null;
            self.MyUnit = self.GetParent<Unit>();
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            self.CreatTime = TimeHelper.ClientNow();
        }

        [EntitySystem]
        private static void Destroy(this UIDropComponent self)
        {
            self.OnDestroy();

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            for (int i = 0; i < self.AssetPath.Count; i++)
            {
                if (!string.IsNullOrEmpty(self.AssetPath[i]))
                {
                    self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(self.AssetPath[i]);
                }
            }

            self.AssetPath = null;
        }

        public static void OnLoadGameObject(this UIDropComponent self, GameObject go, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.Destroy(go);
                return;
            }

            self.HeadBar = go;
            self.HeadBar.SetActive(true);
            self.HeadBar.transform.SetParent(GlobalComponent.Instance.BloodMonster.transform);
            self.HeadBar.transform.localScale = Vector3.one;
            if (self.HeadBar.GetComponent<HeadBarUI>() == null)
            {
                self.HeadBar.AddComponent<HeadBarUI>();
            }

            self.ShowDropInfo();
            
            self.Lab_DropName = go.transform.Find("Lab_DropName").gameObject;
            self.Lab_DropName.transform.SetParent(GlobalComponent.Instance.BloodText_Layer0.transform);
            self.Lab_DropName.transform.localScale = Vector3.one;
            HeadBarUI HeadBarUI_1 = self.Lab_DropName.GetComponent<HeadBarUI>();
            HeadBarUI_1.HeadPos = self.UIPosition;
            HeadBarUI_1.HeadBar = self.Lab_DropName;
            
            self.HeadBarUI = self.HeadBar.GetComponent<HeadBarUI>();
            self.HeadBarUI.HeadPos = self.UIPosition;
            self.HeadBarUI.HeadBar = self.HeadBar;
            Unit parent = self.MyUnit.GetParent<UnitComponent>().Get(self.MyUnit.GetComponent<NumericComponentC>().GetAsLong(NumericType.BeKillId));
            if (parent != null)
            {
                self.StartPoint = parent.Position;
                self.EndPoint = self.MyUnit.Position;
                
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.DropUITimer, self);
                self.GeneratePositions();
                self.LateUpdate();
            }
            else
            {
                self.StartPoint = self.MyUnit.Position;
                self.EndPoint = self.MyUnit.Position;
            }
            
            self.AutoPickItem().Coroutine();
        }

        public static void InitData(this UIDropComponent self)
        {
            GameObjectComponent gameObjectComponent = self.MyUnit.GetComponent<GameObjectComponent>();
            self.UIPosition = gameObjectComponent.GameObject.transform.Find("UIPosition");
            self.ModelMesh = gameObjectComponent.GameObject.transform.Find("DropModel").GetComponent<MeshRenderer>();

            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(StringBuilderData.UIDropUIPath, self.InstanceId,true, self.OnLoadGameObject);
        }

        public static void ShowDropInfo(this UIDropComponent self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId));
            Text textMeshProUGUI = self.HeadBar.transform.Find("Lab_DropName").gameObject.GetComponent<Text>();
            //显示名称
            if (self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemNum) == 1)
            {
                textMeshProUGUI.text = itemConfig.ItemName;
            }
            else
            {
                using (zstring.Block())
                {
                    textMeshProUGUI.text = zstring.Format("{0}{1}", self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemNum), itemConfig.ItemName);
                }
            }

            //显示品质
            textMeshProUGUI.color = FunctionUI.QualityReturnColor(itemConfig.ItemQuality);
            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId));
            //显示UI
            self.HeadBar.SetActive(true);

            Sprite sprite = null;
            long instanceid = self.InstanceId;
            if (self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId) != 1)
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
                sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                if (!self.AssetPath.Contains(path))
                {
                    self.AssetPath.Add(path);
                }
                self.ModelMesh.gameObject.SetActive(true);
            }
            else
            {
                self.ModelMesh.gameObject.SetActive(false);
            }

            if (sprite == null || instanceid != self.InstanceId)
            {
                return;
            }

            try
            {
                //对于多个模型使用共享材质，应用Renderer.shareMaterial 来保证修改的是和其他物体共享的材质，
                self.ModelMesh.material.mainTexture = sprite.texture;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static void GeneratePositions(this UIDropComponent self)
        {
            //height为高度
            float height = 8f;
            Vector3 bezierControlPoint = (self.StartPoint + self.EndPoint) * 0.5f + (Vector3.up * height);

            //resolution为int类型，表示要取得路径点数量，值越大，取得的路径点越多，曲线最后越平滑
            self.Resolution = 20;
            self.LinepointList = new Vector3[self.Resolution];
            for (int i = 0; i < self.Resolution; i++)
            {
                var t = (i + 1) / (float)self.Resolution; //归化到0~1范围
                self.LinepointList[i] = self.GetBezierPoint(t, self.StartPoint, bezierControlPoint, self.EndPoint); //使用贝塞尔曲线的公式取得t时的路径点
            }
        }

        /// <param name="t">0到1的值，0获取曲线的起点，1获得曲线的终点</param>
        /// <param name="start">曲线的起始位置</param>
        /// <param name="center">决定曲线形状的控制点</param>
        /// <param name="end">曲线的终点</param>
        public static Vector3 GetBezierPoint(this UIDropComponent self, float t, Vector3 start, Vector3 center, Vector3 end)
        {
            return (1 - t) * (1 - t) * start + 2 * t * (1 - t) * center + t * t * end;
        }

        public static bool CanShiQu(this UIDropComponent self)
        {
            return (self.PositionIndex >= self.Resolution);
        }

        public static void OnUpdate(this UIDropComponent self)
        {
            self.PositionIndex++;

            /*
            //快速下落处理  超过40%的进度掉落+快
            if (self.PositionIndex >= (int)(self.Resolution * 0.4f))
            {
                self.PositionIndex++;
            }

            //快速下落处理  超过60%的进度掉落+快
            if (self.PositionIndex >= (int)(self.Resolution * 0.6f))
            {
                self.PositionIndex++;
            }
            */

            if (self.PositionIndex >= self.Resolution)
            {
                self.MyUnit.Position = self.LinepointList[self.Resolution - 1];

                // if (Vector3.Distance(self.MyUnit.Position, new Vector3(self.DropInfo.X, self.DropInfo.Y, self.DropInfo.Z)) > 0.5f)
                // {
                //     Log.Error("DropUIComponent.Distance >  0.5f ");
                //     self.MyUnit.Position = new Vector3(self.DropInfo.X, self.DropInfo.Y, self.DropInfo.Z);
                // }

                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

                if (self.IfPlayEffect == false)
                {
                    self.IfPlayEffect = true;
                    //创建特效(排除基础货币)
                    if (self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId) >= 100)
                    {
                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId));
                        if (itemConfig.ItemQuality == 4)
                        {
                            FunctionEffect.PlayDropEffect(self.MyUnit, 200011);
                        }

                        if (itemConfig.ItemQuality == 5)
                        {
                            FunctionEffect.PlayDropEffect(self.MyUnit, 200012);
                        }
                    }
                }

                return;
            }

            self.MyUnit.Position = self.LinepointList[self.PositionIndex];
        }

        public static async ETTask AutoPickItem(this UIDropComponent self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.Happy || mapComponent.MapType == MapTypeEnum.SingleHappy)
            {
                return;
            }

            if (mapComponent.MapType == MapTypeEnum.LocalDungeon)
            {
                if (DungeonConfigCategory.Instance.Get(mapComponent.SceneId).MapType == SceneSubTypeEnum.LocalDungeon_1)
                {
                    return;
                }
            }

            float distance = PositionHelper.Distance2D(UnitHelper.GetMyUnitFromClientScene(self.Root()).Position, self.MyUnit.Position);
            if (distance < ConfigData.DefaultShiquRange)
            {
                self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.DropItem, "0");
            }

            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            if (chengJiuComponent.GetFightJingLing() == 0)
            {
                return;
            }

            bool sendpick = false;
            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(chengJiuComponent.GetFightJingLing());
            if (jingLingConfig.FunctionType == JingLingFunctionType.PickGold && self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId) == 1)
            {
                sendpick = true;
            }

            if (jingLingConfig.AutoPick == 1)
            {
                sendpick = true;
            }

            if (sendpick)
            {
                if (distance > 20)
                {
                    return;
                }

                long instanceid = self.InstanceId;
                await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
                if (instanceid != self.InstanceId)
                {
                    return;
                }

                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.MyUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId));

                if (userInfoComponent.PickSet[0] == "1" && itemConfig.ItemQuality == 2)
                {
                    return;
                }

                // 蓝色 金币除外
                if (userInfoComponent.PickSet[1] == "1" && itemConfig.ItemQuality == 3 && itemConfig.Id != 1)
                {
                    return;
                }

                MapHelper.SendPickItem(self.Root(), new() { self.MyUnit }).Coroutine();
            }
        }

        public static void LateUpdate(this UIDropComponent self)
        {
            if (self.HeadBar == null)
            {
                return;
            }

            if (Mathf.Approximately(self.LastTime, Time.time))
            {
                return;
            }

            self.LastTime = Time.time;
            self.LastTime = Time.time;
            Transform UIPosition = self.UIPosition;
            Vector2 OldPosition = WorldPosiToUIPos.WorldPosiToUIPosition(UIPosition.position, self.HeadBar, self.UICamera, self.MainCamera);

            Vector3 NewPosition = Vector3.zero;
            NewPosition.x = OldPosition.x;
            NewPosition.y = OldPosition.y;
            self.HeadBar.transform.localPosition = NewPosition;
        }

        public static void OnDestroy(this UIDropComponent self)
        {
            self.LinepointList = null;

            if (self.HeadBar != null)
            {
                if (self.Lab_DropName != null)
                {
                    self.Lab_DropName.transform.SetParent(self.HeadBar.transform);
                }
                
                self.HeadBar.SetActive(false);
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(StringBuilderData.UIDropUIPath, self.HeadBar);
                self.HeadBar = null;
            }

            self.PositionIndex = 0;
        }
    }
}