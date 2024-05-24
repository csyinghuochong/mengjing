namespace ET
{
    public interface ILocationMessage: ILocationRequest
    {
    }

    public interface ILocationRequest: IRequest
    {
    }

    public interface ILocationResponse: IResponse
    {
    }
    
    public interface IActivityActorRequest : IRequest
    {
    }

    public interface IActivityActorResponse : IResponse
    {
    }

    public interface IFriendActorRequest: IRequest
    {
        
    }
    
    public interface IFriendActorResponse: IResponse
    {
        
    }
    
    public interface IUnionActorRequest : IRequest
    {
    }

    public interface IUnionActorResponse : IResponse
    {

    }
    
    public interface IMailActorRequest : IRequest
    {
    }

    public interface IMailActorResponse : IResponse
    {

    }
    
    public interface IChatActorRequest: ILocationRequest
    {
        
    }
    
    public interface IChatActorResponse: ILocationResponse
    {
        
    }
}