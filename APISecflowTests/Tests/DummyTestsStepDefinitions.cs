using System;
using TechTalk.SpecFlow;

namespace APISecflowTests.Tests
{
    [Binding]
    public class DummyTestsStepDefinitions
    {
        [When(@"the user sends GET request for all employees")]
        public void WhenTheUserSendsGETRequestForAllEmployees()
        {
            throw new PendingStepException();
        }

        [Then(@"the user gets the response with <success> status")]
        public void ThenTheUserGetsTheResponseWithSuccessStatus()
        {
            throw new PendingStepException();
        }

        [When(@"the user sends GET request for one employee")]
        public void WhenTheUserSendsGETRequestForOneEmployee()
        {
            throw new PendingStepException();
        }

        [Then(@"the user gets response with required employee")]
        public void ThenTheUserGetsResponseWithRequiredEmployee()
        {
            throw new PendingStepException();
        }

        [When(@"the user sends POST request")]
        public void WhenTheUserSendsPOSTRequest(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"the user gets response <Successfully! Record has been added\.>")]
        public void ThenTheUserGetsResponseSuccessfullyRecordHasBeenAdded_()
        {
            throw new PendingStepException();
        }

        [When(@"the user sends PUT request")]
        public void WhenTheUserSendsPUTRequest(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"the user gets response <Successfully! Record has been updated\.>")]
        public void ThenTheUserGetsResponseSuccessfullyRecordHasBeenUpdated_()
        {
            throw new PendingStepException();
        }

        [When(@"the user sends DELETE request")]
        public void WhenTheUserSendsDELETERequest()
        {
            throw new PendingStepException();
        }

        [Then(@"the user gets response <Successfully! Record has been deleted>")]
        public void ThenTheUserGetsResponseSuccessfullyRecordHasBeenDeleted()
        {
            throw new PendingStepException();
        }

        [When(@"the user sends GET request for specified employee")]
        public void WhenTheUserSendsGETRequestForSpecifiedEmployee()
        {
            throw new PendingStepException();
        }

        [Then(@"the user gets response about existence")]
        public void ThenTheUserGetsResponseAboutExistence()
        {
            throw new PendingStepException();
        }
    }
}
