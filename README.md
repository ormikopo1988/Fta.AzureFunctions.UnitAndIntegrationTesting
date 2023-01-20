# Fta.AzureFunctions.UnitAndIntegrationTesting
Unit and integration tests examples for Azure Functions

This repo is a sample .NET 6 Notes API written using Azure Functions template and contains examples on how to properly write unit and integration tests for the Functions classes.

# Prerequisites
The code in this repo requires knowledge of the following concepts and frameworks:

- Unit testing
- Integration testing
- xUnit => Testing framework
- NSubstitute => Mocking framework

The API uses Azure Cosmos DB for its storing purposes and to run it locally you must run your intergation test against local instance of Azure CosmosDB. 

It’s availalble for download here: https://aka.ms/cosmosdb-emulator

Also to be able to run this demo on your own in your local machine you need to create a local.settings.json file inside the Fta.DemoFunc.Api project.

As it’s not advisable to store keys and secrets inside a git repository, for local development you can use a local.settings.json file to store configuration.

Sample local.settings.json file:

{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  },
  "NotificationApiUrl": "https://63cacb2d4f53a004202b1df7.mockapi.io/api/v1/",
  "CosmosDb": {
    "ConnectionString": "AccountEndpoint=https://localhost:8081/;AccountKey=..."
  }
}

The "NotificationApiUrl" setting is a mock 3rd party API which we call to send notification events that a new note has been created into our system.

You can use the "NotificationApiUrl" setting as is to run the demo API locally. It is here to demonstrate how to handle integration tests against 3rd party APIs that you do not control. 
