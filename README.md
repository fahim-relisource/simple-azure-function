# Simple Azure Function with SOAP Web Service

This repo showcase Soap Web Service consumption, Dependency Injection, Object Mapping and Request Body validation on Azure Function.

#### Dependencies:

* AutoMapper
* FluentValidation

#### How can run this

You can run this on your local environment please check you have `Azure Development Platform` installed on Visual Studio 2019 (Ohh! I recommend VS2019 but you need to use at least VS2017).

Please add `local.settings.json` on `TestAzureFunction` project which will look like this.

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
  }
}
```
To use this function on production you have to add `x-functions-key` on header. `x-functions-key` is needed when the authorization label of the Function is `Function`.
[Please check this section to find more](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook-trigger?tabs=csharp#api-key-authorization)

I also add `Postman Collection` to test it. On post man you will find the `Headers` and `Body` for the request.

Please import the file `Test Azure Function.postman_collection.json` on your postman or you can use other `API` Client.  