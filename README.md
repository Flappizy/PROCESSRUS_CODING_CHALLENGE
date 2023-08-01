# ProcessRUs Coding Challenge

Welcome to the ProcessRUs Coding Challenge! This project is a demonstration of a .NET 7 application with JWT Authentication and SQL Server LocalDB.

## Prerequisites

Before you begin, ensure you have the following installed:

- .NET 7
- SQL Server LocalDB

## API Endpoints

The application runs on `localhost:7233` and provides the following endpoints:

- `GET /api/Access/fruits`: Fetches a list of fruits.
- `POST /api/Auth/login`: Logs in a user.
- `POST /api/Auth/signup`: Registers a new user.

## Running the Application
To run the application, follow these steps:

1. Clone the repository.
2. Open the project in Visual Studio and press `Ctrl + F5` to run the code without debugging. This will open the Swagger UI in your browser.
3. Alternatively, you can run the application from the terminal using the `dotnet run` command. The application's port will be displayed in the terminal.

## Using the API

Here's how to use the available endpoints:

### Sign Up

Endpoint: `POST /api/Auth/signup`

Request body:
`json 
{ 
    "firstName": "string", 
    "lastName": "string", 
    "email": "string", 
    "password": "string", 
    "confirmPassword": "string", 
    "company": "string", 
    "accountType": 0 
}`

The `accountType` property specifies the type of account to create:

- `0`: FrontOffice
- `1`: BackOffice
- `2`: Admin

### Log In

Endpoint: `POST /api/Auth/login`

Request body:

`json
{
    "email": "string",
    "password": "string"
}`


### Get Fruits

Endpoint: `GET /api/Access/fruits`

No request body is required for this endpoint.

### DATA To Test With
When you run the application the database is automatically seeded with the following users with password `testPassword1!`, you can use the users to test the app
`{
    FirstName = "Ade",
    LastName = "Smith",
    Company = "Process",
    UserName = "ade.smith@gmail.com",
    Email = "ade.smith@gmail.com",
    AccountType = AccountType.Admin
}`

`{
    FirstName = "John",
    LastName = "Samuel",
    Company = "Process",
    UserName = "john.samuel@gmail.com",
    Email = "john.samuel@gmail.com",
    AccountType = AccountType.BackOffice
}`
            
`{
    FirstName = "Doe",
    LastName = "Leo",
    Company = "Process",
    UserName = "doe.low@gmail.com",
    Email = "doe.low@gmail.com",
    AccountType = AccountType.FrontOffice
}`
