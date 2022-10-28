using APISecflowTests.Models;
using RestSharp;
using System.Threading.Tasks;
using APISecflowTests.Tests;

namespace APISecflowTests.Controllers
{
    public class EmployeeController : BaseController
    {
        private const string GetEmployeesUrl = "/employees";
        private const string GetEmployeeByIdUrl = "/employee/";
        private const string PostEmployeeUrl = "/create";
        private const string PutEmployeeUrl = "/update/";
        private const string DeleteEmployeeUrl = "/delete/";

        public async Task<IRestResponse> GetEmployeesAsync()
        {
            var resource = string.Concat(this.BaseUrl, GetEmployeesUrl);
            return await this.GetAsync(resource);
        }

        public async Task<IRestResponse> GetOneEmployeeAsync(string index)
        {
            var resource = string.Concat(this.BaseUrl, GetEmployeeByIdUrl, index);
            return await this.GetAsync(resource);
        }

        public async Task<IRestResponse> PostEmployeeAsync(NewEmployeeDataModel model)
        {
            var resourse = string.Concat(this.BaseUrl, PostEmployeeUrl);
            return await this.PostAsync(resourse, model);
        }

        public async Task<IRestResponse> PutEmployeeAsync(string index, NewEmployeeDataModel model)
        {
            var resource = string.Concat(BaseUrl, PutEmployeeUrl, index);
            return await PutAsync(resource, model);
        }

        public async Task<IRestResponse> DeleteEmployeeAsync(string index)
        {
            var resource = string.Concat(this.BaseUrl, DeleteEmployeeUrl, index);
            return await this.DeleteAsync(resource);
        }
    }
}
