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
	| Parameter | Value |
	| name      | Asuna |
	| salary    | 32000 |
	| age       | 21    |
	Then the user gets POST response "Successfully! Record has been added."

Scenario: 4 Update employee
	When the user sends PUT request for employee with index "2"
	| Parameter | Value  |
	| name      | Kirito |
	| salary    | 11000  |
	| age       | 26     |
	Then the user gets PUT response "Successfully! Record has been updated."

Scenario: 5 Delete employee
	When the user sends DELETE request for employee with index "24"
	Then the user gets DELETE response "Successfully! Record has been deleted"

Scenario: 6 Check if employee does not exist
	When the user sends GET request if employee exist with index "100"
	Then the user gets the response about user existence