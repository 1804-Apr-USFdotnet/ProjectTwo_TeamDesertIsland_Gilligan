using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Gilligan.MVC.DomainContracts;

namespace Gilligan.MVC.DomainServices
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient {BaseAddress = new Uri("/http://fixthis:12345")};
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TO> GetEntityAsync<T, TO>(T input, TO output, string uri)
        {
            var reponse = await _httpClient.GetAsync(uri);

            if (!reponse.IsSuccessStatusCode) return default(TO);

            return await reponse.Content.ReadAsAsync<TO>();
        }

        public async Task<HttpStatusCode> DeleteEntityAsync<T>(T entity, string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> CreateEntityAsync<T>(T entity, string uri)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, entity);

            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateEntityAsync<T>(T entity, string uri)
        {
            var response = await _httpClient.PutAsJsonAsync(uri, entity);

            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }
    }
}
