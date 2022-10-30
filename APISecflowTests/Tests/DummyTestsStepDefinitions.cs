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
        private bool dataIsNull;

        private readonly EmployeeController employeeController;
        private readonly ScenarioContext scenarioContext;

        public DummyTestsStepDefinitions(ScenarioContext scenarioContext)
        {
            employeeController = new EmployeeController();
            this.scenarioContext = scenarioContext;
        }


        [When(@"the user gets all employees")]
        public async Task WhenTheUserSendsGETRequestForAllEmployees()
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
        public async Task WhenTheUserSendsGETRequestForThEmployee(string index)
        {
            var response = await employeeController.GetOneEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(response.Content);
            scenarioContext.Add("ActualId", jsonContent.data.id);
        }

        [Then(@"the user gets response with id employee ""([^""]*)""")]
        public void ThenTheUserGetsResponseWithIdEmployee(string expectedId)
        {
            actualId = scenarioContext.Get<string>("ActualId");
            Assert.AreEqual(expectedId, actualId, "User by ID not found");
        }

        [When(@"the user sends the request to add the following employee")]
        public async Task WhenTheUserSendsPOSTRequest(Table table)
        {
            var model = table.CreateInstance<NewEmployeeDataModel>();
            var sentResponse = await employeeController.PostEmployeeAsync(model);
            var jsonContent = JsonConvert.DeserializeObject<NewEmployeeDataModel>(sentResponse.Content);
            scenarioContext.Add("ActualMessage", jsonContent.message);
        }

        [Then(@"the user gets the response about user creating ""([^""]*)""")]
        public void ThenTheUserGetsPOSTResponse(string expectedMessage)
        {
            actualMessage = scenarioContext.Get<string>("ActualMessage");
            Assert.AreEqual(expectedMessage, actualMessage, "User not created");
        }

        [When(@"the user sends the request to change the employee with id ""([^""]*)""")]
        public async Task WhenTheUserSendsPUTRequestForEmployeeWithIndex(string index, Table table)
        {
            var model = table.CreateInstance<NewEmployeeDataModel>();
            var sentResponse = await employeeController.PutEmployeeAsync(index, model);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(sentResponse.Content);
            scenarioContext.Add("ActualMessage", jsonContent.message);
        }

        [Then(@"the user gets the response about user updating ""([^""]*)""")]
        public void ThenTheUserGetsPUTResponse(string expectedMessage)
        {
            actualMessage = scenarioContext.Get<string>("ActualMessage");
            Assert.AreEqual(expectedMessage, actualMessage, "User not updeted");
        }

        [When(@"the user sends the request to delete the employee with id ""([^""]*)""")]
        public async Task WhenTheUserSendsDELETERequestForEmployeeWithIndex(string index)
        {
            var response = await employeeController.DeleteEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<DelletedEmployeeModel>(response.Content);
            scenarioContext.Add("ActualMessage", jsonContent.message);
        }

        [Then(@"the user gets the response about user deleting ""([^""]*)""")]
        public void ThenTheUserGetsDELETEResponse(string expectedMessage)
        {
            actualMessage = scenarioContext.Get<string>("ActualMessage");
            Assert.AreEqual(expectedMessage, actualMessage, "User not deleted");
        }

        [When(@"the user sends the request if employee exist with id ""([^""]*)""")]
        public async Task WhenTheUserSendsGETRequestIfEmployeeExistWithIndex(string index)
        {
            var response = await employeeController.GetOneEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(response.Content);
            scenarioContext.Add("DataIsNull", jsonContent.data == null);
        }

        [Then(@"the user gets the response about user existence")]
        public void ThenTheUserGetsTheResponseAboutUserExistence()
        {
            dataIsNull = scenarioContext.Get<bool>("DataIsNull");
            Assert.IsTrue(dataIsNull, "User data is not null, required user is exist");
        }

        [Then(@"the user gets the response ""([^""]*)""")]
        public void ThenTheUserGetsTheResponse(string success)
        {
            actualMessage = scenarioContext.Get<string>("ActualMessage");
            switch (success)
            {
                case "Successfully! Record has been added.":
                    actualMessage.Should().Be(success);
                    break;
                case "Successfully! Record has been updated.":
                    actualMessage.Should().Be(success);
                    break;
                case "Successfully! Record has been deleted":
                    actualMessage.Should().Be(success);
                    break;
                default:
                    Console.WriteLine("Not success");
                    break;
            }
        }

    }
}