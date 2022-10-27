using APISecflowTests.Constants;
using APISecflowTests.Managers;
using APISecflowTests.Models;
using APISecflowTests;
using System.Threading.Tasks;
using RestSharp;

namespace APISecflowTests.Controllers
{
    public class BaseController : ConfigManager
    {
        protected string BaseUrl => Config[ConfigConstants.BaseUrl];
        protected RestClient RestClient => new RestClient(this.BaseUrl);

        protected async Task<IRestResponse> GetAsync(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            return await this.RestClient.ExecuteAsync<IRestResponse>(request, Method.GET);
        }

        protected async Task<IRestResponse> PostAsync(string resource, NewEmployeeDataModel model)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(model);
            return await this.RestClient.ExecuteAsync<IRestResponse>(request, Method.POST);
        }

        protected async Task<IRestResponse> PutAsync(string resource, NewEmployeeDataModel model)
        {
            var request = new RestRequest(resource, Method.PUT);
            request.AddJsonBody(model);
            return await this.RestClient.ExecuteAsync<IRestResponse>(request, Method.PUT);
        }

        protected async Task<IRestResponse> DeleteAsync(string resource)
        {
            var request = new RestRequest(resource, Method.DELETE);
            return await this.RestClient.ExecuteAsync<IRestResponse>(request, Method.DELETE);
        }
    }
}
