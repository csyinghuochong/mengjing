using System.Collections.Generic;

#if DOTNETusing ET.Server;using MongoDB.Bson.Serialization.Attributes;
#endif
namespace ET{

#if DOTNET    public class BagComponent : Entity, IAwake, IDestroy, IDeserialize, ITransfer, IUnitCache
#else    public class BagComponent : Entity, IAwake, IDestroy
#endif               {    }}