Feature: Dummy tests

The http://dummy.restapiexample.com API testing using main methods 

Scenario: 1 Get all employees
	When the user gets all employees
	Then the user gets the response with "success" status

Scenario: 2 Get one employee
	When the user gets the employee with the id "10"
	Then the user gets response with id employee "10"

Scenario: 3 Create employee
	When the user sends the request to add the following employee
	| Parameter | Value |
	| name      | Asuna |
	| salary    | 32000 |
	| age       | 21    |
	#Then the user gets the response about user creating "Successfully! Record has been added."
	Then the user gets the response "Successfully! Record has been added."

Scenario: 4 Update employee
	When the user sends the request to change the employee with id "2"
	| Parameter | Value  |
	| name      | Kirito |
	| salary    | 11000  |
	| age       | 26     |
	#Then the user gets the response about user updating "Successfully! Record has been updated."
	Then the user gets the response "Successfully! Record has been updated."

Scenario: 5 Delete employee
	When the user sends the request to delete the employee with id "24"
	#Then the user gets the response about user deleting "Successfully! Record has been deleted"
	Then the user gets the response "Successfully! Record has been deleted"

Scenario: 6 Check if employee does not exist
	When the user sends the request if employee exist with id "100"
	Then the user gets the response about user existence