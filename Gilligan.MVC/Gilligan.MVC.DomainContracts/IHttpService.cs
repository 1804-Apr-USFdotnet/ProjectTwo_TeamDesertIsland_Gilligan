using System.Net;
using System.Threading.Tasks;

namespace Gilligan.MVC.DomainContracts
{
    public interface IHttpService 
    {
        Task<T> GetEntityAsync<T>(T entity, string uri);
        Task<HttpStatusCode> DeleteEntityAsync<T>(T entity, string uri);
        Task<HttpStatusCode> CreateEntityAsync<T>(T entity, string uri);
        Task<HttpStatusCode> UpdateEntityAsync<T>(T entity, string uri);
    }
}
