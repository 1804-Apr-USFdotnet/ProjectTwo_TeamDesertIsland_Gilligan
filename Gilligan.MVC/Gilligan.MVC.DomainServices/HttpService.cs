using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Gilligan.MVC.DomainContracts;

namespace Gilligan.MVC.DomainServices
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetEntityAsync<T>(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> DeleteEntityAsync<T>(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> CreateEntityAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> UpdateEntityAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
