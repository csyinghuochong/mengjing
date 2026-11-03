using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ET.Server
{
    /// <summary>
    /// 旧版本 SkillAugmentList 存的是 SkillAugmentInfo 文档数组，新版本是 int 数组。
    /// 启动时把旧格式数据重置为空数组，避免老角色读档时 BSON 反序列化失败。
    /// </summary>
    [FriendOf(typeof(DBComponent))]
    public static class SkillAugmentLegacyCleaner
    {
        public static async ETTask Clear(DBManagerComponent dbManagerComponent, int zone)
        {
            try
            {
                DBComponent dbComponent = dbManagerComponent.GetZoneDB(zone);
                IMongoCollection<BsonDocument> collection = dbComponent.database.GetCollection<BsonDocument>(typeof(SkillSetComponentS).FullName);

                // 只匹配旧格式：数组元素是带 BaseSkillId 字段的文档；新格式的 int 数组不会命中。
                FilterDefinition<BsonDocument> filter = new JsonFilterDefinition<BsonDocument>(
                    "{ \"SkillAugmentList\": { \"$elemMatch\": { \"BaseSkillId\": { \"$exists\": true } } } }");
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("SkillAugmentList", new BsonArray());

                UpdateResult result = await collection.UpdateManyAsync(filter, update);
                Log.Info($"旧技能增幅数据清理完成，修改数量: {result.ModifiedCount}");
            }
            catch (Exception e)
            {
                // 清理失败不阻塞 DBCache 启动，登录时仍会报出具体的读档错误
                Log.Error($"旧技能增幅数据清理失败: {e}");
            }
        }
    }
}
