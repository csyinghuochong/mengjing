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
    
    public interface ITeamActorRequest: IRequest
    {
        
    }
    
    public interface ITeamActorResponse: IResponse
    {
        
    }
    
    public interface ISoloActorRequest: IRequest
    {
        
    }
    
    public interface ISoloActorResponse: IResponse
    {
        
    }
    
    public interface IPopularizeActorRequest: IRequest
    {

    }
    
    public interface IPopularizeActorResponse: IResponse
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
    
    public interface IRankActorRequest : IRequest
    {
    }

    public interface IRankActorResponse : IResponse
    {

    }
    
    public interface IPaiMaiListRequest : IRequest
    {
    }

    public interface IPaiMaiListResponse : IResponse
    {

    }
    
    public interface IChatActorRequest: ILocationRequest
    {
        
    }
    
    public interface IChatActorResponse: ILocationResponse
    {
        
    }

    public interface IPetMatchActorRequest: IRequest
    {
        
    }
    
    public interface IPetMatchActorResponse: IResponse
    {
        
    }
}