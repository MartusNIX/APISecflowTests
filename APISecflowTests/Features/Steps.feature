Feature: Dummy tests

The http://dummy.restapiexample.com API testing using main methods 

Scenario: 1 Get all employees
	When the user sends GET request for all employees
	Then the user gets the response with "success" status

Scenario: 2 Get one employee
	When the user sends GET request for employee with index "10"
	Then the user gets response with id employee "10" 

Scenario: 3 Create employee
	When the user sends POST request
	| Parameter       | Value |
	| employee_name   | Asuna |
	| employee_salary | 32000 |
	| employee_age    | 21    |
	Then the user gets response "Successfully! Record has been added."

Scenario: 4 Update employee
	When the user sends PUT request
	| Parameter       | Value  |
	| employee_name   | Kirito |
	| employee_salary | 11000  |
	| employee_age    | 26     |
	Then the user gets response "Successfully! Record has been updated."

Scenario: 5 Delete employee
	When the user sends DELETE request
	Then the user gets response <Successfully! Record has been deleted>

Scenario: 6 Check if employee does not exist
	When the user sends GET request for specified employee
	Then the user gets response about existence
