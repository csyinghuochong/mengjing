using System.Diagnostics;
using ET.Client;
using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET
{
    [ChildOf(typeof(UnitComponent))]
    [DebuggerDisplay("ViewName,nq")]
    public partial class Unit: Entity, IAwake<int>
    {

        public int AI{ get; set; }
        
        public int Type { get; set; }

        public int ConfigId { get; set; } //配置表id
        
        public bool MainHero { get; set; }

        public long MasterId {get; set; }
        
        public int SceneType {get; set; }

        [BsonElement]
        private float3 position; //坐标

        [BsonIgnore]
        public float3 Position
        {
            get => this.position;
            set
            {
                float3 oldPos = this.position;
                this.position = value;

                if (SettingData.ShowFindPath && this.MainHero)
                {
                    Log.Debug($"新坐标:{value}   旧坐标:{oldPos}   移动距离:{math.distance(oldPos, value)}   当前时间:{TimeHelper.ServerNow()}");
                }
                EventSystem.Instance.Publish(this.Scene(), new ChangePosition() { Unit = this, OldPos = oldPos });
            }
        }

        [BsonIgnore]
        public float3 Position_2
        {
            get => this.position;
            set
            {
                float3 oldPos = this.position;
                this.position = value;
                EventSystem.Instance.Publish(this.Scene(), new ChangePosition() { Unit = this, OldPos = oldPos });
            }
        }
        
        [BsonIgnore]
        public float3 Forward
        {
            get => math.mul(this.Rotation, math.forward());
            set => this.Rotation = quaternion.LookRotation(value, math.up());
        }
        
        [BsonElement]
        private quaternion rotation;
        
        [BsonIgnore]
        public quaternion Rotation
        {
            get => this.rotation;
            set
            {
                this.rotation = value;
                EventSystem.Instance.Publish(this.Scene(), new ChangeRotation() { Unit = this });
            }
        }

        protected override string ViewName
        {
            get
            {
                return $"{this.GetType().FullName} ({this.Id})";
            }
        }
        
        
        public long UpdateUITime{ get; set; }
    }
}