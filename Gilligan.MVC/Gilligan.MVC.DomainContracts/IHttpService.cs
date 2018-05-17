using System;
using System.Net;
using System.Threading.Tasks;

namespace Gilligan.MVC.DomainContracts
{
    public interface IHttpService 
    {
        Task<T> GetEntityAsync<T>(Guid entityId);
        Task<HttpStatusCode> DeleteEntityAsync<T>(Guid entityId);
        Task<HttpStatusCode> CreateEntityAsync<T>(T entity);
        Task<HttpStatusCode> UpdateEntityAsync<T>(T entity);
    }
}
