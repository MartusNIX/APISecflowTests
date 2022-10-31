using APISecflowTests.Controllers;
using APISecflowTests.Models;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace APISecflowTests.Tests
{
    [Binding]
    public class DummyTestsStepDefinitions
    {
        private string actualStatus;
        private string actualId;
        private string actualMessage;

        private readonly EmployeeController employeeController;
        private readonly ScenarioContext scenarioContext;

        public DummyTestsStepDefinitions(ScenarioContext scenarioContext)
        {
            employeeController = new EmployeeController();
            this.scenarioContext = scenarioContext;
        }


        [When(@"the user gets all employees")]
        public async Task WhenTheUserGetsAllEmployees()
        {
            var response = await employeeController.GetEmployeesAsync();
            var jsonContent = JsonConvert.DeserializeObject<AllEmployeesModel>(response.Content);
            scenarioContext.Add("ActualStatus", jsonContent.status);
        }

        [Then(@"the user gets the response with ""([^""]*)"" status")]
        public void ThenTheUserGetsTheResponseWithStatus(string success)
        {
            actualStatus = scenarioContext.Get<string>("ActualStatus");
            Assert.AreEqual(success, actualStatus, "All Employees not found");
        }
 
        [When(@"the user gets the employee with the id ""([^""]*)""")]
        public async Task WhenTheUserGetsTheEmployeeWithTheId(string index)
        {
            var response = await employeeController.GetOneEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(response.Content);

            switch (jsonContent.status)
            {
                case "success":
                    scenarioContext.Add("ActualId", jsonContent.data.id);
                    break;
                case "error":
                    scenarioContext.Add("ActualStatus", jsonContent.status);
                    break;
            }
        }

        [Then(@"the user gets response with id employee ""([^""]*)""")]
        public void ThenTheUserGetsResponseWithIdEmployee(string expectedId)
        {
            actualId = scenarioContext.Get<string>("ActualId");
            Assert.AreEqual(expectedId, actualId, "User by ID not found");
        }
 
        [Then(@"the responce contains status ""([^""]*)""")]
        public void ThenTheResponceContainsStatus(string error)
        {
            actualStatus = scenarioContext.Get<string>("ActualStatus");
            Assert.AreEqual(error, actualStatus, "User by ID is found");
        }

        [When(@"the user sends the request to add the following employee")]
        public async Task WhenTheUserSendsTheRequestToAddTheFollowingEmployee(Table table)
        {
            var model = table.CreateInstance<NewEmployeeDataModel>();
            var sentResponse = await employeeController.PostEmployeeAsync(model);
            var jsonContent = JsonConvert.DeserializeObject<NewEmployeeDataModel>(sentResponse.Content);
            scenarioContext.Add("ActualMessage", jsonContent.message);
        }

        [Then(@"the response contains the following message ""([^""]*)""")]
        public void ThenTheResponseContainsTheFollowingMessage(string success)
        {
            actualMessage = scenarioContext.Get<string>("ActualMessage");
            Assert.AreEqual(success, actualMessage);
        }

        [When(@"the user sends the request to change the employee with id ""([^""]*)""")]
        public async Task WhenTheUserSendsRequestToChangeTheEmployeeWithId(string index, Table table)
        {
            var model = table.CreateInstance<NewEmployeeDataModel>();
            var sentResponse = await employeeController.PutEmployeeAsync(index, model);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(sentResponse.Content);
            scenarioContext.Add("ActualMessage", jsonContent.message);
        }

        [When(@"the user sends the request to delete the employee with id ""([^""]*)""")]
        public async Task WhenTheUserSendsRequestToDeleteTheEmployeeWithId(string index)
        {
            var response = await employeeController.DeleteEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<DelletedEmployeeModel>(response.Content);
            scenarioContext.Add("ActualMessage", jsonContent.message);
        }
    }
}