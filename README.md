# Simple Azure Function with SOAP Web Service

This repo showcase Soap Web Service consumption from Azure Function.

#### Dependencies:

* AutoMapper

#### How can run this

You can run this on your local environment please check you have `Azure Development Platform` installed on Visual Studio 2019 (Ohh! I recommend VS2019 but you need to use at least VS2017).

Please add `local.settings.json` on `TestAzureFunction` project which will look like this.

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "API_KEY": "5398a7fd-59c1-4937-8816-bfd32eafba37"
  }
}
```

This `API_KEY` I just randomly generated. Its not any real `API` key.

I also add `Postman Collection` to test it. On post man you will find the `Headers` and `Body` for the request.

Please import the file `Test Azure Function.postman_collection.json` on your postman or you can use other `API` Client.  