using APISecflowTests.Controllers;
using APISecflowTests.Models;
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

        public DummyTestsStepDefinitions()
        {
            employeeController = new EmployeeController();
        }


        [When(@"the user gets all employees")]
        public async Task WhenTheUserSendsGETRequestForAllEmployees()
        {
            var response = await employeeController.GetEmployeesAsync();
            var jsonContent = JsonConvert.DeserializeObject<AllEmployeesModel>(response.Content);
            actualStatus = jsonContent.status;
            
        }

        [Then(@"the user gets the response with ""([^""]*)"" status")]
        public void ThenTheUserGetsTheResponseWithStatus(string success)
        {
            Assert.AreEqual(success, actualStatus, "All Employees not found");
        }

        [When(@"the user gets the employee with the id ""([^""]*)""")]
        public async Task WhenTheUserSendsGETRequestForThEmployee(string index)
        {
            var response = await employeeController.GetOneEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(response.Content);
            actualId = jsonContent.data.id;
        }

        [Then(@"the user gets response with id employee ""([^""]*)""")]
        public void ThenTheUserGetsResponseWithIdEmployee(string expectedId)
        {
            Assert.AreEqual(expectedId, actualId, "User by ID not found");
        }

        [When(@"the user sends the request to add the following employee")]
        public async Task WhenTheUserSendsPOSTRequest(Table table)
        {
            var model = table.CreateInstance<NewEmployeeDataModel>();
            var sentResponse = await employeeController.PostEmployeeAsync(model);
            var jsonContent = JsonConvert.DeserializeObject<NewEmployeeDataModel>(sentResponse.Content);
            actualMessage = jsonContent.message;
        }

        [Then(@"the user gets the response about user creating ""([^""]*)""")]
        public void ThenTheUserGetsPOSTResponse(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, actualMessage, "User not created");
        }

        [When(@"the user sends the request to change the employee with id ""([^""]*)""")]
        public async Task WhenTheUserSendsPUTRequestForEmployeeWithIndex(string index, Table table)
        {
            var model = table.CreateInstance<NewEmployeeDataModel>();
            var sentResponse = await employeeController.PutEmployeeAsync(index, model);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(sentResponse.Content);
            actualMessage = jsonContent.message;
        }

        [Then(@"the user gets the response about user updating ""([^""]*)""")]
        public void ThenTheUserGetsPUTResponse(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, actualMessage, "User not updeted");
        }

        [When(@"the user sends the request to delete the employee with id ""([^""]*)""")]
        public async Task WhenTheUserSendsDELETERequestForEmployeeWithIndex(string index)
        {
            var response = await employeeController.DeleteEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<DelletedEmployeeModel>(response.Content);
            actualMessage = jsonContent.message;
        }

        [Then(@"the user gets the response about user deleting ""([^""]*)""")]
        public void ThenTheUserGetsDELETEResponse(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, actualMessage, "User not deleted");
        }

        [When(@"the user sends the request if employee exist with id ""([^""]*)""")]
        public async Task WhenTheUserSendsGETRequestIfEmployeeExistWithIndex(string index)
        {
            var response = await employeeController.GetOneEmployeeAsync(index);
            var jsonContent = JsonConvert.DeserializeObject<SingleEmployeeModel>(response.Content);
            dataIsNull = jsonContent.data == null;
        }

        [Then(@"the user gets the response about user existence")]
        public void ThenTheUserGetsTheResponseAboutUserExistence()
        {
            Assert.IsTrue(dataIsNull, "User data is not null, required user is exist");
        }
    }
}
