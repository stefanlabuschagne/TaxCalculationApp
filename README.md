This is a Tax CAlculation App Written in C#

It has a Front-end that accepts a Postal Code and Annual Taxable income
The front end calls a backend API that calculates the tax and stores the values in a SQLExpress database table.

FrontEnd:
Uses Razor pages for input - I could do a lot more to make it look nice and for the validation to display properly. (TIME)
It uses a repository pattern to call (inject) the API as a service (no fat Controllers).
HTTP is also injected into the service as specified in the program.cs

Backend:
The backend has a controller with a post-method
It uses a repository pattern to inject a service into the controller that calculates the Tax and writes the amounts to the database table.
It uses a Factory Pattern to calculate the tax which makes it easier to add new methods of calculating tax (just add another Interface).
I started to implement the pattern but it seemed an overkill for just one API call.

Swagger is included for the API documentation/testing of the API

Unit Tests
Included for testing the different methods of calculating Tax
Some tests need to be added to check for invalid postcodes and negative incomes.
Also outstanding, is testing the API call and the front-end

Code Formatting and standards.
I included the StyleCop Nuget libraries to give guidance for proper styling and coding standards.
