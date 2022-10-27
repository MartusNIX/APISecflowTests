using APISecflowTests.Constants;
using APISecflowTests.Controllers;
using APISecflowTests.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace APISecflowTests.Tests
{
    [Binding]
    public class DummyTestsStepDefinitions : EmployeeController
    {
        private string actualStatus;
        private string actualId;


        [When(@"the user sends GET request for all employees")]
        public async Task WhenTheUserSendsGETRequestForAllEmployees()
        {
            var response = await this.GetEmployeesAsync();
            var jsonContent = JsonConvert.DeserializeObject<AllEmployeesModel>(response.Content);
            actualStatus = jsonContent.status;
            
        }

        [Then(@"the user gets the response with ""([^""]*)"" status")]
        public void ThenTheUserGetsTheResponseWithStatus(string success)
        {
            Assert.AreEqual(success, actualStatus, "All Employees not found");
        }

        [When(@"the user sends GET request for employee with index ""([^""]*)""")]
        public async Task WhenTheUserSendsGETRequestForThEmployee(string index)
        {
            var response = await this.GetOneEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(response.Content);
            actualId = jsonContent.data.id;
        }

        [Then(@"the user gets response with id employee ""([^""]*)"" ")]
        public void ThenTheUserGetsResponseWithIdEmployee(string expectedId)
        {
            Assert.AreEqual(expectedId, actualId, "User by ID not found");
        }

    }
}
